@echo off
setlocal
set DEVROOT=%~dp0

cd /d "%DEVROOT%"

set CODEGEN_TPLDIR=%DEVROOT%templates
set CODEGEN_OUTDIR=%DEVROOT%PartsSystem

codegen -e -s PART -t DataClassFull -n PartsSystem -r

endlocal