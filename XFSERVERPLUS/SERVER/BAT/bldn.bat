@echo off
echo Building %1
dbl -XT -qstrict -o OBJ:%1.dbo SRC:%1.dbl
if "%ERRORLEVEL%"=="1" goto end
dblibr -rw LIB:server.olb OBJ:%1.dbo
:end
