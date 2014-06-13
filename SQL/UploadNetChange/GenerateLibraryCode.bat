@echo off
setlocal

pushd %~dp0

set CODEGEN_TPLDIR=.\TEMPLATES
set CODEGEN_OUTDIR=.\SRC\LIBRARY
set OPTS=-e -lf -r

rem Generate the UI toolkit maintenance program
codegen %OPTS% -s EMPLOYEE            -t TkTabbedMaintenance
codegen %OPTS% -s DEPARTMENT          -t TkChangeMethod TkDrillMethod

rem Generate the SDMS I/O Routines
codegen %OPTS% -s DEPARTMENT EMPLOYEE -t SynIO

rem Generate the SQL Connection database classes
codegen %OPTS% -s EMPLOYEE -t DatabaseTable -o SRC\LIBRARY -n DatabaseTools -f l

popd
endlocal

