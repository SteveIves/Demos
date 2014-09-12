<CODEGEN_FILENAME>Services<StructureName>.dbl</CODEGEN_FILENAME>
<PROCESS_TEMPLATE>MethodStatus</PROCESS_TEMPLATE>
;;******************************************************************************
;;WARNING: This file was created by CodeGen. Changes will be lost if regenerated
;;******************************************************************************

import System.Collections
import Synergex.SynergyDE.Select

.include "<STRUCTURE_NOALIAS>" repository, structure="str<StructureName>", end
 
{xfMethod(interface="Services")}
function Create<StructureName>, METHOD_STATUS
    required in  a<StructureName>, str<StructureName>
    required out aErrorMessage, string
    endparams
    stack record
        ch, int
        status, METHOD_STATUS
    endrecord
proc
    status = METHOD_STATUS.SUCCESS
    aErrorMessage = ""

    try
    begin
        open(ch=0,u:i,"<FILE_NAME>")
        store(ch,a<StructureName>)
    end
    catch (e, @FileNameException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @NoFileFoundException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @DuplicateException)
    begin
        status = METHOD_STATUS.FAIL
        aErrorMessage = "Record already exists!"
    end
    catch (e, @Exception)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = e.Message
    end
    finally
    begin
        if (ch&&chopen(ch))
            close ch
    end
    endtry

    freturn status

endfunction

{xfMethod(interface="Services")}
function ReadAll<StructureName>s, METHOD_STATUS
    {xfParameter(collectionType=xfCollectType.structure,structure="str<StructureName>")}
    required out a<StructureName>s, @ArrayList
    required out aErrorMessage, string
    endparams
    stack record 
        status, METHOD_STATUS
    endrecord
proc

    status = METHOD_STATUS.SUCCESS
    aErrorMessage = ""

    a<StructureName>s = new ArrayList()

    try
    begin
        data rec, str<StructureName>
        foreach rec in new Select(new From("<FILE_NAME>",rec))
            a<StructureName>s.Add((@str<StructureName>)rec)
    end
    catch (e, @FileNameException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @NoFileFoundException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @Exception)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = e.Message
    end
    endtry

    freturn status

endfunction

<PRIMARY_KEY>
{xfMethod(interface="Services")}
function Read<StructureName>, METHOD_STATUS
    <SEGMENT_LOOP>
    required in  a<SegmentName>, <SEGMENT_SPEC>
    </SEGMENT_LOOP>
    required out a<StructureName>, str<StructureName>
    required out aGrfa, String
    required out aErrorMessage, string
    endparams
    stack record
        ch, int
        status, METHOD_STATUS
        grfa, a10
    endrecord
proc
    status = METHOD_STATUS.SUCCESS
    aErrorMessage = ""

    init a<StructureName>
    <SEGMENT_LOOP>
    <IF DATE_YYYYMMDD>
    a<StructureName>.<segment_name> = DataUtils.D8FromDate(a<SegmentName>)
    <ELSE>
    a<StructureName>.<segment_name> = a<SegmentName>
    </IF DATE_YYYYMMDD>
    </SEGMENT_LOOP>

    try
    begin
        open(ch=0,I:I,"<FILE_NAME>")
        read(ch,a<StructureName>,%keyval(ch,a<StructureName>,<KEY_NUMBER>),GETRFA:grfa)
        aGrfa = grfa
    end
    catch (e, @FileNameException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @NoFileFoundException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @EndOfFileException)
    begin
        init a<StructureName>
        status = METHOD_STATUS.FAIL
      aErrorMessage = "Record not found"
    end
    catch (e, @KeyNotSameException)
    begin
	init a<StructureName>
        status = METHOD_STATUS.FAIL
        aErrorMessage = "Record not found!"
    end
    catch (e, @Exception)
    begin
        init a<StructureName>
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = e.Message
    end
    finally
    begin
        if (ch&&chopen(ch))
            close ch
    end
    endtry

    freturn status

endfunction

</PRIMARY_KEY>
{xfMethod(interface="Services")}
function Update<StructureName>, METHOD_STATUS
    required inout a<StructureName>, str<StructureName>
    required inout aGrfa, String
    required out aErrorMessage, string
    endparams
    stack record
        ch, int
        rec, str<StructureName>
        status, METHOD_STATUS
        grfa, a10
    endrecord
proc
    status = METHOD_STATUS.SUCCESS
    aErrorMessage = ""

    try
    begin
        open(ch=0,u:i,"<FILE_NAME>")
        ;;Attempt to read the original record by GRFA to make sure that
        ;;nobody else has modified or deleted it
        grfa=aGrfa
        read(ch,rec,RFA:grfa,GETRFA:grfa)
        write(ch,a<StructureName>)
    end
    catch (e, @FileNameException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @NoFileFoundException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (ex, @RecordNotSameException)
    begin
        ;;Failed to lock the original record, it must have been changed
        ;;by another process since this user obtained it. We'll return
        ;;the new record and it's GRFA to the user
        a<StructureName> = rec
        aGrfa = grfa
        status = METHOD_STATUS.FAIL
        aErrorMessage = "Record was changed by another user!"
    end
    catch (e, @DuplicateException)
    begin
        status = METHOD_STATUS.FAIL
        aErrorMessage = "Duplicate key error!"
    end
    catch (e, @Exception)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = e.Message
    end
    finally
    begin
        if (ch&&chopen(ch))
            close ch
    end
    endtry

    freturn status

endfunction

{xfMethod(interface="Services")}
function Delete<StructureName>, METHOD_STATUS
    required in aGrfa, String
    required out aErrorMessage, string
    endparams
    stack record
        ch, int
        rec, str<StructureName>
        status, METHOD_STATUS
        grfa, a10
    endrecord
proc
    status = METHOD_STATUS.SUCCESS
    aErrorMessage = ""

    try
    begin
        open(ch=0,u:i,"<FILE_NAME>")
        ;;Attempt to read the original record by GRFA to make sure that
        ;;nobody else has modified or deleted it
        grfa=aGrfa
        read(ch,rec,RFA:grfa)
        delete(ch)
    end
    catch (e, @FileNameException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @NoFileFoundException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (ex, @RecordNotSameException)
    begin
        status = METHOD_STATUS.FAIL
        aErrorMessage = "The record has been changed by another user!"
    end
    catch (e, @Exception)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = e.Message
    end
    finally
    begin
        if (ch&&chopen(ch))
            close ch
    end
    endtry

    freturn status

endfunction

{xfMethod(interface="Services")}
function <StructureName>Exists, METHOD_STATUS
    <PRIMARY_KEY>
    <SEGMENT_LOOP>
    required in  a<SegmentName>, <SEGMENT_SPEC>
    </SEGMENT_LOOP>
    </PRIMARY_KEY>
    required out aErrorMessage, string
    endparams
    stack record
        ch, int
        rec, str<StructureName>
        status, METHOD_STATUS
    endrecord
proc
    status = METHOD_STATUS.SUCCESS
    aErrorMessage = ""

    init rec
    <PRIMARY_KEY>
    <SEGMENT_LOOP>
    rec.<segment_name> = a<SegmentName>
    </SEGMENT_LOOP>
    </PRIMARY_KEY>

    try
    begin
        open(ch=0,I:I,"<FILE_NAME>")
        find(ch,,%keyval(ch,rec,0))
    end
    catch (e, @FileNameException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @NoFileFoundException)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = "File not found! CHECK THE DAT SETTING IN THE WEB.CONFIG FILE AND MAKE SURE IT IS CORRECT FOR YOUR SYSTEM!"
    end
    catch (e, @EndOfFileException)
    begin
        status = METHOD_STATUS.FAIL
        aErrorMessage = "Record not found!"
    end
    catch (e, @KeyNotSameException)
    begin
        status = METHOD_STATUS.FAIL
        aErrorMessage = "Record not found!"
    end
    catch (e, @Exception)
    begin
        status = METHOD_STATUS.FATAL_ERROR
        aErrorMessage = e.Message
    end
    finally
    begin
        if (ch&&chopen(ch))
            close ch
    end
    endtry

    freturn status

endfunction
