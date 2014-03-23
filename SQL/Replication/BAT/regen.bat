@echo off
setlocal

rem Configure the CodeGen environment

set ROOT_FOLDER=%~dp0..
set CODEGEN_TPLDIR=%ROOT_FOLDER%\SRC\TEMPLATES
set CODEGEN_OUTDIR=%ROOT_FOLDER%\SRC\LIBRARY
set CODEGEN_AUTHOR="Steve Ives"
set CODEGEN_COMPANY="Synergex Professional Services Group"

rem In this example we are using CodeGen Structure Mapping, so the structures
rem being used are structures that have been created for this purpose. They
rem have different names and field names to the original structures, and
rem may have various field data manipulations that take place.

codegen -s EMPLOYEE   -t SqlIO -r -v
codegen -s DEPARTMENT -t SynIO -r -v

endlocal
