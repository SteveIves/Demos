<CODEGEN_FILENAME><StructureName>PendingChanges.dbl</CODEGEN_FILENAME>

import System.Collections
import Synergex.SynergyDE.Select
import DatabaseTools
import IsamTools

main <StructureName>PendingChanges

    record
        tt,                     int
        ok,                     boolean
        disableSynBackup,       boolean
        disconnectFromDatabase, boolean
        dbConnection,           @DatabaseConnection
        <structureName>Table,   @<StructureName>Table
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

    ;;Now we can update the database

    if (ok)
    begin

        ;;Earlier we checked that there was at least one snapshot in the file,
        ;;and since then we have added another. So we know that there are AT
        ;;LEAST two snapshots in the file now. We'll export all net change
        ;;between the oldest and newest snapshots.

        data snapshots, @ArrayList
        data newestSnapshot, int
        data <structureName>, str<StructureName>
        data results, @AlphaEnumerator
        data inserts, int, 0
        data updates, int, 0
        data deletes, int, 0
        data ctstate, CTState

        ;;Get the collection of snapshots from the file.

        ChangeTracking.GetSnapshots("<FILE_NAME>",snapshots)

        ;;Figure out the oldest and newest snapshot numbers

        newestSnapshot = ((@Snapshot)snapshots[snapshots.Count-1]).SnapshotNumber

        ;;Select the net change since the last snapshot

        results = new Select(new From("<FILE_NAME>",<structureName>),
        &   Where.NetChange(newestSnapshot,newestSnapshot+1)).GetEnumerator()

        ;;Display the changes

        while (results.MoveNext())
        begin
            data success, boolean
            <structureName> = results.Current

            ctstate = results.GetCTInfo.GetCTState

            if (ctstate & CTState.Insert) then
            begin
                writes(tt,"INSERT: " + <structureName>(1:50))
                inserts += 1
            end
            else if (ctstate & CTState.Update) then
            begin
                writes(tt,"UPDATE: " + <structureName>(1:50))
                updates += 1
            end
            else if (ctstate & CTState.Delete) then
            begin
                writes(tt,"DELETE: " + <structureName>(1:50))
                deletes += 1
            end
            else
            begin
                writes(tt,"UNKNOWN CTState = " + %string(ctstate))
            end

        end

        ;;Report the totals

        writes(tt,%string(inserts) + " inserts, " + %string(updates) + " updates, " + %string(deletes) + " deletes")

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
