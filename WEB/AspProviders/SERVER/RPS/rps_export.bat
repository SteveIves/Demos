if exist %ROOT%SERVER\RPS\repository.sch del /q %ROOT%SERVER\RPS\repository.sch
if exist %ROOT%SERVER\RPS\repository.sch goto delete_fail
dbs RPS:rpsutl -e %ROOT%SERVER\RPS\repository.sch
goto done
:delete_fail
echo *ERROR* Failed to delete existing schema, did you check it out first?
:done