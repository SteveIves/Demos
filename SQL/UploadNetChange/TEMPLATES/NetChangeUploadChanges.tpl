<CODEGEN_FILENAME><StructureName>UploadChanges.dbl</CODEGEN_FILENAME>

import System.Collections
import Synergex.SynergyDE.Select
import DatabaseTools
import IsamTools

main <StructureName>UploadChanges

	record 
		tt,						int
		ok,						boolean
		disableSynBackup,		boolean
		disconnectFromDatabase,	boolean
		dbConnection, 			@DatabaseConnection
		<structureName>Table, 	@<StructureName>Table
	endrecord
	
	.define DB_CONSTR "VTX12_SQLNATIVE://<DATABASE_NAME>/.///Trusted_connection=yes"
	
proc

	ok = true
	open(tt=0,i,"tt:")
	xcall flags(7004020,1)
	
	;;Check we're running as an administrator, synbackup -q will fail if not.

	try
	begin
		data tmpch, int
		open(tmpch=0,i,"|synbackup -q")
		close tmpch
	end
	catch (ex)
	begin
		writes(tt,"ERROR: This program requires administrator rights")
		ok = false
	end
	endtry

	;;Check change tracking is ebabled on the file
	
	if (ok)
	begin
		if (ChangeTracking.IsEnabled("<FILE_NAME>")) then 
		begin

			data snapshots, @ArrayList, new ArrayList()
			if (!ChangeTracking.GetSnapshots("<FILE_NAME>",snapshots)) then 
			begin
				writes(tt,"ERROR: Failed to retrieve snapshot info for <FILE_NAME>")
				ok = false
			end
			else
			begin
				if (snapshots.Count==0)
				begin
					writes(tt,"ERROR: No snapshots found in <FILE_NAME>")
					ok = false
				end
			end
		end
		else
		begin
			writes(tt,"ERROR: Change tracking is not enabled for <FILE_NAME>")
			ok = false
		end
	end
	
	;;Check that SynBackup has been enabled on the system. If not enable it.
	
	if (ok)
	begin
		disableSynBackup = false
		if (!SynBackup.IsEnabled)
		begin
			if (SynBackup.Enable()) then
			begin
				writes(tt,"SynBackup has been enabled")
				disableSynBackup = true
			end
			else
			begin
				writes(tt,"ERROR: Failed to enable SynBackup.")
				ok = false
			end
		end
	end
	
	;;Make sure we can connect to the database
	
	if (ok)
	begin
		try
		begin
			dbConnection = new DatabaseConnection(1,DB_CONSTR)
			dbConnection.Connect()
			disconnectFromDatabase = true
			<structureName>Table = new EmployeeTable(dbConnection)
		end
		catch (ex, @ApplicationException)
		begin
			writes(tt,"ERROR: Failed to connect to database. Message was: " + ex.Message)
			disconnectFromDatabase = false
			ok = false
		end
		endtry
	end

	;;Apply a snapshot
	
	if (ok)
	begin
		;;Suspend all Synergy IO
		if (!SynBackup.SetBackupState(SynBackupState.On)) then
		begin
			writes(tt,"ERROR: Failed to set synbackup state to ON")
			ok = false
		end
		else
		begin
			writes(tt,"SynBackup state has been set to ON")

			;;Apply a new snapshot to all the files we're exporting
			if (ok)
			begin
				data latestSnapshotNumber, int
				if (ChangeTracking.AddSnapshot("<FILE_NAME>",latestSnapshotNumber)) then 
					writes(tt,"Snapshot #" + %string(latestSnapshotNumber) + " was created in <FILE_NAME>")
				else
				begin
					writes(tt,"ERROR: Failed to apply snapshot to <FILE_NAME>")
					ok = false
				end
			end

			;;Resume Synergy IO
			if (SynBackup.SetBackupState(SynBackupState.Off)) then 
			begin
				writes(tt,"SynBackup state has been set to OFF")
			end
			else
			begin
				writes(tt,"ERROR: Failed to set synbackup state to OFF. You should issue a synbackup -x command IMMEDIATELY!")
				ok = false
			end
		end
	end
	
	;;If we enabled SynBackup then we should disable it also
	
	if (disableSynBackup)
	begin
		if (SynBackup.Disable()) then 
			writes(tt,"SynBackup has been disabled")
		else
			writes(tt,"ERROR: Failed to disable synbackup. You should issue a synbackup - d command IMMEDIATELY.")
	end
	
	;;Now we can update the database
		
	if (ok)
	begin

		;;Earlier we checked that there was at least one snapshot in the file,
		;;and since then we have added another. So we know that there are AT
		;;LEAST two snapshots in the file now. We'll export all net change
		;;between the oldest and newest snapshots.

		data snapshots, @ArrayList
		data oldestSnapshot, int
		data newestSnapshot, int
		data <structureName>, str<StructureName>
		data results, @AlphaEnumerator
		data updates, int, 0
		data failures, int, 0
		data ctstate, CTState

		;;Get the collection of snapshots from the file.

		ChangeTracking.GetSnapshots("<FILE_NAME>",snapshots)

		;;Figure out the oldest and newest snapshot numbers

		oldestSnapshot = ((@Snapshot)snapshots[0]).SnapshotNumber
		newestSnapshot = ((@Snapshot)snapshots[snapshots.Count-1]).SnapshotNumber
		
		;;Select the net changes between the two snapshots

		results = new Select(new From("<FILE_NAME>",<structureName>),
		&	Where.NetChange(oldestSnapshot,newestSnapshot)).GetEnumerator()
		
		;;Work through the changes and bring the database up to date

		while (results.MoveNext())
		begin
			data success, boolean
			<structureName> = results.Current

			ctstate = results.GetCTInfo.GetCTState

			if (ctstate & CTState.Insert) then
			begin
				writes(tt,"INSERT: " + <structureName>(1:50))
				success = <structureName>Table.InsertRow(<structureName>)
			end
			else if (ctstate & CTState.Update) then
			begin
				writes(tt,"UPDATE: " + <structureName>(1:50))
				success = <structureName>Table.UpdateRow(<structureName>)
			end
			else if (ctstate & CTState.Delete) then
			begin
				writes(tt,"DELETE: " + <structureName>(1:50))
				success = <structureName>Table.DeleteRow(<PRIMARY_KEY><SEGMENT_LOOP><structureName>.<segment_name><,></SEGMENT_LOOP></PRIMARY_KEY>)
			end
			else
				writes(tt,"UNKNOWN CTState = " + %string(ctstate))
			
			;;Record the result

			if (success) then 
				updates += 1
			else
				failures += 1
		end

		;;Report how many changes we replicated

		writes(tt,%string(updates) + " changes were replicated")

		;;If there were failures then report the number of failures

		if (failures) then
			writes(tt,"ERROR: " + %string(failures) + " changes failed to replicate")
		else
		begin
			;;Delete all except the last snapshot from <FILE_NAME>
			if (ChangeTracking.DeleteOldSnapshots("<FILE_NAME>"))
				writes(tt,"All except the latest snapshots were removed from <FILE_NAME>")
		end
	end
		
	;;Disconnect from the database

	if (disconnectFromDatabase)
		dbConnection.Disconnect()

	;;All done

	begin
		data char, a1
		display(tt,"Press a key to exit: ")
		accept(tt,char)
	end

	stop
	
endmain
