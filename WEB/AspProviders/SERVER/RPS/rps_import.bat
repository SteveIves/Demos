@echo off
rem Test to see if the schema will load
echo Testing schema load...
dbs RPS:rpsutl -i %ROOT%SERVER\RPS\repository.sch -ia -ir -s
if "%ERRORLEVEL%"=="1" goto parse_fail
if exist rpsmain.new del /q rpsmain.new
if exist rpsmain.ne1 del /q rpsmain.ne1
if exist rpstext.new del /q rpstext.new
if exist rpstext.ne1 del /q rpstext.ne1
echo Test OK
rem Load the schema
echo Performing schema load...
dbs RPS:rpsutl -i %ROOT%SERVER\RPS\repository.sch -ia -ir
if "%ERRORLEVEL%"=="1" goto load_fail
echo Schema loaded OK
goto done
:parse_fail
echo *ERROR* Schema parse failed - repository not changed
goto done
:load_fail
echo *ERROR* Schema load failed - repository not changed
:done
