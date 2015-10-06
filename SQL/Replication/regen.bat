@echo off
setlocal

rem Configure the CodeGen environment

set ROOT_FOLDER=%~dp0
set CODEGEN_TPLDIR=%ROOT_FOLDER%\SRC\TEMPLATES
set CODEGEN_AUTHOR="Steve Ives"
set CODEGEN_COMPANY="Synergex Professional Services Group"

rem In this example we are using CodeGen Structure Mapping, so the structures
rem being used are structures that have been created for this purpose. They
rem have different names and field names to the original structures, and
rem may have various field data manipulations that take place.

codegen -e -s EMPLOYEE   -t SqlIO -o "%ROOT_FOLDER%\SRC\LIBRARY" -r -lf
codegen -e -s DEPARTMENT -t SynIO -o "%ROOT_FOLDER%\SRC\LIBRARY" -r -lf

codegen -e -s EMPLOYEE   -t AddReplicationKey -o "%ROOT_FOLDER%\SRC\LOAD" -r -lf

endlocal
