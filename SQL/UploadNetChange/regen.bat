@echo off
setlocal

pushd %~dp0

set CODEGEN_TPLDIR=.\TEMPLATES
set OPTS=-e -lf -r

rem Generate the UI toolkit maintenance program
codegen %OPTS% -s EMPLOYEE            -t TkTabbedMaintenance          -o SRC\LIBRARY
codegen %OPTS% -s DEPARTMENT          -t TkChangeMethod TkDrillMethod -o SRC\LIBRARY

rem Generate the SDMS I/O Routines
codegen %OPTS% -s DEPARTMENT EMPLOYEE -t SynIO                        -o SRC\LIBRARY

rem Generate the SQL Connection database classes
codegen %OPTS% -s EMPLOYEE            -t DatabaseTable                -o SRC\LIBRARY -n DatabaseTools -f l

rem Generate the utility programs
codegen %OPTS% -s EMPLOYEE            -t NetChange*                   -o SRC\TOOLS   -ut DATABASE_NAME=SqlUploadNetChange

popd
endlocal

