<CODEGEN_FILENAME><structure_name>_repkey.dbl</CODEGEN_FILENAME>
main <structure_name>_repkey

    .include "GENSRC:StructureIO.def"
    .include "<STRUCTURE_NOALIAS>" repository, record="<structure_name>"

    record
        ok,         boolean
        ttchn,      int
        filechn,    int
        added,      int
        existing,   int
    endrecord

proc

    ok = true

    xcall flags(7004020,1)
    open(ttchn=0,i,"tt:")

    ;;Open the file
    if (%<structure_noalias>_io(IO_OPEN_UPD,filechn) != IO_OK)
    begin
        writes(ttchn,"Failed to open file <FILE_NAME>")
        clear filechn
        ok = false
    end

    if (ok)
    begin
        ;;Process each record, adding a replication key value if necessary
        repeat
        begin
            using %<structure_noalias>_io(IO_READ_NEXT,filechn,,,<structure_name>,true) select
            (IO_LOCKED),
            begin
                ;;Record locked, report it and wait a while
                data now, a14, %datetime
                writes(ttchn,%string(^d(now),"XXXX-XX-XX XX.XX.XX") + " Record " + %keyval(filechn,<structure_name>,0) + " locked, retrying...")
                sleep 0.1
            end
            (IO_EOF),
            begin
                ;;All done
                exitloop
            end
            (),
            begin
                ;;Got a record to process
                if (<structure_name>.replication_key)
                begin
                    ;;It already has a replication key value
                    data now, a14, %datetime
                    writes(ttchn,%string(^d(now),"XXXX-XX-XX XX.XX.XX") + " record " + %keyval(filechn,<structure_name>,0) + " has replication key " + <structure_name>.replication_key)
                    unlock filechn
                    existing += 1
                    nextloop
                end
                ;;Assign a replication key value
                repeat
                begin
                    <structure_name>.replication_key = %datetime
                    if (%<structure_noalias>_io(IO_UPDATE,filechn,,,<structure_name>)==IO_OK) then
                    begin
                        ;;Report what we did
                        data now, a14, %datetime
                        writes(ttchn,%string(^d(now),"XXXX-XX-XX XX.XX.XX")+ " record " + %keyval(filechn,<structure_name>,0) + " NEW replication key " + <structure_name>.replication_key)
                        added += 1
                        exitloop
                    end
                    else
                    begin
                        ;;Update failed, report it
                        ;;Update failed, report it
                        data now, a14, %datetime
                        writes(ttchn,%string(^d(now),"XXXX-XX-XX XX.XX.XX")+ " record " + %keyval(filechn,<structure_name>,0) + " FAILED TO ADD replication key " + <structure_name>.replication_key)
                        sleep 0.1
                    end
                end
            end
            endusing
        end
    end

    ;;Close the file
    if (filechn && %chopen(filechn))
        close filechn

    writes(ttchn,"Result: Exsiting " + %string(existing) + " Added: " + %string(added))
    display(ttchn,"Press a key: ")
    accept(ttchn,filechn)

    close ttchn

    stop

endmain
