@echo off
setlocal

rem Configure the CodeGen environment

set ROOT_FOLDER=%~dp0
set CODEGEN_TPLDIR=%ROOT_FOLDER%\TEMPLATES
set CODEGEN_OUTDIR=%ROOT_FOLDER%\SRC
set CODEGEN_AUTHOR="Steve Ives"
set CODEGEN_COMPANY="Synergex Professional Services Group"

rem In this example we are using CodeGen Structure Mapping, so the structures
rem being used are structures that have been created for this purpose. They
rem have different names and field names to the original structures, and
rem may have various field data manipulations that take place.

rem Generate the test program
codegen                  -t DatabaseTableTest   -n SqlUploadDemo -v

rem Generate code for CUSTOMER (original structure CUSMAS)
codegen -s CUSTOMER      -t DatabaseTableMapped -n SqlUploadDemo -v -r

rem Generate code for PRODUCT_GROUP (original structure INVGRP)
codegen -s PRODUCT_GROUP -t DatabaseTableMapped -n SqlUploadDemo -v -r

rem Generate code for PRODUCT (original structure INVMAS)
codegen -s PRODUCT       -t DatabaseTableMapped -n SqlUploadDemo -v -r

rem Generate code for ORDER_HEADER (original structure ORDHDR)
codegen -s ORDER_HEADER  -t DatabaseTableMapped -n SqlUploadDemo -v -r

rem Generate code for ORDER_LINE (original structure ORDLIN)
codegen -s ORDER_LINE    -t DatabaseTableMapped -n SqlUploadDemo -v -r

endlocal
