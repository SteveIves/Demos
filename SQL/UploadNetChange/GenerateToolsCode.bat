@echo off
setlocal
pushd %~dp0

set CODEGEN_TPLDIR=.\TEMPLATES
set CODEGEN_OUTDIR=.\SRC\TOOLS

codegen -e -s EMPLOYEE -t NetChangeInitialUpload NetChangeShowSnapshots NetChangeUploadChanges -ut DATABASE_NAME=SqlUploadNetChange -r -lf

popd
endlocal

