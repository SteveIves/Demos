@echo off
echo Building %1
dbl -dXT -o OBJ:%1 UT:%1
if "%ERRORLEVEL%"=="1" goto error
dblibr -rw OBJ:utility.olb OBJ:%1
goto end
:error
pause
:end