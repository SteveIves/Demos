<CODEGEN_FILENAME>IsNumeric.dbl</CODEGEN_FILENAME>
;;*****************************************************************************
;;
;; Title:       IsNumeric.dbl
;;
;; Description: Validates a numeric value
;;
;;*****************************************************************************
;;
namespace <NAMESPACE>

	function IsNumeric, ^val

		a_number        ,a
		endparams

		stack record
			retval          ,i4
			number          ,d28.10
		endrecord

	proc

		retval = 1
		onerror ($ERR_DIGIT) bad
		number = a_number
		if (0)
	bad,    clear retval
		offerror

		freturn retval

	endfunction

endnamespace
