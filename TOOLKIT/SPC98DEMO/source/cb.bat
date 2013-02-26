rem @echo off
rem
rem build standalone programs.
rem

if not exist %1.dbl goto no_src

echo Compiling: %1

dbl -TXdo %temp%\%1 %1 > %temp%\%1.lis

if not exist %temp%\%1.dbo goto compile_fail

del %temp%\%1.lis
echo Linking:   %1

dblink -do %1.dbr %temp%\%1 WND:tklib.elb RPSLIB:ddlib.elb DBLDIR:axlib.elb

del %temp%\%1.dbo

goto the_end

check_no_path:

echo path
if not exist $%$2%1.dbr goto link_fail

goto the_end

:no_src
echo missing source: %1
pause
goto the_end

:compile_fail
echo  Compile failed: %1
notepad %temp%\%1.lis
pause
del %temp%\%1.lis
goto the_end

:link_fail
echo  Link failed: %1
pause
goto the_end

:the_end
