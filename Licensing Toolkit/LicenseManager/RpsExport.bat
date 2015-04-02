if exist %ROOT%rps.sch del /q %ROOT%rps.sch
if exist %ROOT%rps.sch goto delete_fail
dbs RPS:rpsutl -e %ROOT%rps.sch
goto done
:delete_fail
@echo *ERROR* Failed to delete existing schema, did you check it out first?
:done
