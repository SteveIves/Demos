<CODEGEN_FILENAME><StructureName>ShowSnapshots.dbl</CODEGEN_FILENAME>
import System.Collections
import IsamTools

main <StructureName>ShowSnapshots
	record 
		tt, int
	endrecord
proc

	open(tt=0,i,"tt:")
	xcall flags(7004020,1)
	
	;;Check change tracking is enabled 
	
	if (!ChangeTracking.IsEnabled("<FILE_NAME>")) then 
		writes(tt,"ERROR: Change tracking is not enabled for <FILE_NAME>")
	else
	begin
		;Get snapshot details from the file
		data snapshots, @ArrayList, new ArrayList()
		if (!ChangeTracking.GetSnapshots("<FILE_NAME>",snapshots)) then 
			writes(tt,"ERROR: Failed to retrieve snapshots for <FILE_NAME>")
		else
		begin
			if (snapshots.Count==0) then 
				writes(tt,"No snapshots exist in <FILE_NAME>")
			else
			begin
				data snapshot, @Snapshot
				writes(tt,"Snapshot details for <FILE_NAME>")
				writes(tt,"")
				foreach snapshot in snapshots
				begin
					writes(tt," Shapshot: "+%string(snapshot.SnapshotNumber)+" taken "+%string(snapshot.DateTimeTaken,"XXXX-XX-XX XX:XX:XX"))
					writes(tt,"  Changes: "+%string(snapshot.Changes))
					writes(tt,"  Inserts: "+%string(snapshot.Inserts))
					writes(tt,"  Updates: "+%string(snapshot.Updates))
					writes(tt,"  Deletes: "+%string(snapshot.Deletes))
					writes(tt," Unlinked: "+%string(snapshot.Unlinked))
					writes(tt,"")
				end
			end
		end
	end
	
	begin
		data char, a1
		display(tt,"Press a key to exit: ")
		accept(tt,char)
	end

	stop
	
endmain

