<CODEGEN_FILENAME><StructureName>InitialUpload.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>DATABASE_NAME</REQUIRES_USERTOKEN>
import System.Collections
import Synergex.SynergyDE.Select
import DatabaseTools
import IsamTools

main <StructureName>InitialUpload

	record 
		tt, 					int
		fileChan,				int
		ok, 					boolean
		closeIsamFile, 			boolean
		disconnectFromDatabase,	boolean
		dbConnection, 			@DatabaseConnection
		<structureName>Table, 	@<StructureName>Table
	endrecord

	.define DB_CONSTR "VTX12_SQLNATIVE://<DATABASE_NAME>/.///Trusted_connection=yes"
	
proc

	ok = true
	open(tt=0,i,"tt:")
	xcall flags(7004020,1)

	;;Check we're running as administrator. synbackup -q will fail if not

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

	;;Check change tracking is NOT already enabled on the file

	if (ok)
	begin
		if (ChangeTracking.IsEnabled("<FILE_NAME>"))
		begin
			writes(tt,"ERROR: Change tracking already enabled on <FILE_NAME>")
			ok = false
		end
	end

	;;Check SynBackup is not active

	if (ok)
	begin
		if (SynBackup.IsEnabled && SynBackup.BackupState!=SynBackupState.Off)
		begin
			writes(tt,"ERROR: Change tracking can't be applied because of current SynBackup mode")
			ok = false
		end
	end

	;;Open the file for exclusive access

	if (ok)
	begin
		try
		begin
			open(fileChan=0,i:i,"<FILE_NAME>",SHARE:Q_EXCL_RW)
			closeIsamFile = true
		end
		catch (ex)
		begin
			writes(tt,"ERROR: Failed to open <FILE_NAME> for exclusive access!")
			closeIsamFile = false
			ok = false
		end
		endtry
	end
	
	;;Connect to the database

	if (ok)
	begin
		try
		begin
			dbConnection = new DatabaseConnection(1,DB_CONSTR)

			dbConnection.Connect()
			disconnectFromDatabase = true
			<structureName>Table = new <StructureName>Table(dbConnection)
		end
		catch (ex, @ApplicationException)
		begin
			writes(tt,"ERROR: Failed to connect to database. Message was: " + ex.Message)
			disconnectFromDatabase = false
			ok = false
		end
		endtry
	end

	;;If the table already exists in the database then delete it

	if (ok)
	begin
		if (<structureName>Table.Exists())
		begin
			if (!<structureName>Table.Drop())
			begin
				writes(tt,"ERROR: Failed to drop table <StructureName> from database")
				ok = false
			end
		end
	end

	;;Create a new table in the database

	if (ok)
	begin
		if (!<structureName>Table.Create())
		begin
			writes(tt,"ERROR: Failed to create table <StructureName> in database")
			ok = false
		end
	end

	;;Load all records into the database

	if (ok)
	begin
		data <structureName>, str<StructureName>
		data recordCount, int, 0
		foreach <structureName> in new Select(new From(fileChan,<structureName>))
		begin
			<structureName>Table.InsertRow(<structureName>)
			recordCount+=1
		end
		writes(tt,%string(recordCount) + " records were inserted into table <StructureName>")
	end

	;;Disconnect from the database

	if (disconnectFromDatabase)
		dbConnection.Disconnect()

	;;Close the file

	if (closeIsamFile)
		close fileChan

	;;Turn on change trackng in the file

	if (ok)
	begin
		if (ChangeTracking.Enable("<FILE_NAME>")) then
			writes(tt,"Change tracking has been enabled for <FILE_NAME>")
		else
		begin
			writes(tt,"ERROR: Failed to enable change tracking in <FILE_NAME>")
			ok = false
		end
	end

	;;All done

	begin
		data char, a1
		display(tt,"Press a key to exit: ")
		accept(tt,char)
	end

	close tt

	stop
	
endmain

