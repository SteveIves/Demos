@echo off
echo Building %1
dbl -XT -o OBJ:%1.dbo SRC:%1
if "%ERRORLEVEL%"=="1" goto error
dblibr -rw LIB:AspProviders.olb OBJ:%1.dbo
goto end
:error
pause
:end
