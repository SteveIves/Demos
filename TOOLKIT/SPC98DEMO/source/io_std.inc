.include 'io.def'

stack record
        error,          i4
        key_of_ref,     i4
        search,         i4
        error_flag,     i4
        hold_key,       a100

.proc

;
;Standard include for file IO routine.  Performs access and error
;checking and display
;


  onerror fatal_io_error
  if %passed(a_key) hold_key=a_key
  if %passed(a_keynum)
  then key_of_ref=a_keynum
  else key_of_ref=D_PRIMKEY

  repeat
  begin

    case a_io_type of
    begincase
    D_IO_OPEN_INP :
    begin
      xcall u_open(a_channel, 'I:I', D_FILE_SPEC,, search, error_flag)
      if error_flag call open_error
    end
    D_IO_OPEN_UPD :
    begin
      xcall u_open(a_channel, 'U:I', D_FILE_SPEC,, search, error_flag)
      if error_flag call open_error
    end
    D_IO_FIND : find(a_channel,, a_key, KEYNUM:key_of_ref)
&                 [$ERR_EOF = end_of_file,
&                  $ERR_LOCKED = record_locked,
&                  $ERR_KEYNOT = key_not_found]
    D_IO_READ_FIRST : read(a_channel, a_data, ^FIRST, KEYNUM:key_of_ref)
&                 [$ERR_EOF = end_of_file,
&                  $ERR_LOCKED = record_locked,
&                  $ERR_KEYNOT = key_not_found]
    D_IO_READ : read(a_channel, a_data, a_key, KEYNUM:key_of_ref)
&                 [$ERR_EOF = end_of_file,
&                  $ERR_LOCKED = record_locked,
&                  $ERR_KEYNOT = key_not_found]
    D_IO_READ_NEXT : reads(a_channel, a_data)
&                 [$ERR_EOF = end_of_file,
&                  $ERR_LOCKED = record_locked,
&                  $ERR_KEYNOT = key_not_found]
    D_IO_CREATE : store(a_channel, a_data)
&                 [$ERR_NODUPS = duplicate_key]
    D_IO_DELETE : delete (a_channel)
&                 [$ERR_NOCURR = no_current_record]
    D_IO_UPDATE : write(a_channel, a_data)
&                 [$ERR_NOCURR = no_current_record]
    D_IO_UNLOCK : unlock a_channel
    D_IO_CLOSE : xcall u_close(a_channel)
    endcase
    else
    begin
        freturn D_IO_FATAL
    end
    offerror
    freturn D_IO_OK

record_locked,

  sleep 1       ;wait for a second

  end

;----------------------------------------------------------------------------

end_of_file,

  freturn D_IO_EOF

key_not_found,

  if %passed(a_key) a_key=hold_key
  freturn D_IO_NOT_FOUND

duplicate_key,

  freturn D_IO_DUP_KEY

no_current_record,

  freturn D_IO_NO_CUR_REC

fatal_io_error,

  offerror
  freturn D_IO_FATAL

open_error,

  freturn D_IO_OPN_ERR

;end of the standard include.
;----------------------------------------------------------------------------
