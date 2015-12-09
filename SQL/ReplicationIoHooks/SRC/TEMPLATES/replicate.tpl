<CODEGEN_FILENAME>Replicate.dbl</CODEGEN_FILENAME>
;;*****************************************************************************
;;
;; Title:       Replicate.dbl
;;
;; Description: Adds a new transaction record to the replication servers
;;              transaction file
;;
;;*****************************************************************************
;;

namespace <NAMESPACE>

	.include "REPLICATION_INSTRUCTION" REPOSITORY, ENUM, END

	subroutine Replicate

		required in a_action    ,REPLICATION_INSTRUCTION
		optional in a_structure ,a  ;Structure name
		optional in a_strkey    ,a  ;Unique key of record affected
		endparams

		.INCLUDE "REPLICATION" REPOSITORY, LOCAL RECORD = "INSTRUCTION"

		static record
			chn ,i4
		endrecord

	proc

		;Do we need to open the replication transaction file?
		if (!chn)
			open(chn=0,"U:I","DAT:REPLICATION.ISM")

		using a_action select

		(REPLICATION_INSTRUCTION.CLOSE_FILE),
		begin
			if (chn && %chopen(chn))
			begin
				close chn
				init chn
			end
		end

		(REPLICATION_INSTRUCTION.DELETE_ALL_INSTRUCTIONS),
		begin
			;Delete pending instructions
			repeat
			begin
				try
				begin
					read(chn,instruction,^FIRST)
					delete(chn)
				end
				catch (ex, @EndOfFileException)
				begin
					exitloop
				end
				catch (ex, @Exception)
				begin
					sleep 0.01
				end
				endtry
			end
		end

		(),
		begin
			;Issue new instruction

			init instruction

			instruction.action = (i)a_action

			if (^passed(a_structure) && a_structure)
				instruction.structure_name = a_structure

			if (^passed(a_strkey) && a_strkey)
				instruction.structure_key = a_strkey

			repeat
			begin
				try
				begin
					instruction.transaction_id = %datetime
					store(chn,instruction)
					exitloop
				end
				catch (ex, @DuplicateException)
				begin
					sleep 0.01
				end
				endtry
			end
		end
		endusing

		xreturn

	endsubroutine

endnamespace

