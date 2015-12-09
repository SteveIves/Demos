@echo off
setlocal
set DEVROOT=%~dp0
cd /d "%DEVROOT%"
set RPSMFIL=%DEVROOT%rps\rpsmain.ism
set RPSTFIL=%DEVROOT%rps\rpstext.ism
set CODEGEN_TPLDIR=%DEVROOT%Templates

echo Generating CRUD code...
codegen -e -s PART          -t CRUD -n PartsSystem -ut MAIN_CLASS=PartsSystemAPI -o PartsSystem -r
rem codegen -e -s PRODUCT_GROUP -t CRUD -n PartsSystem -ut MAIN_CLASS=PartsSystemAPI -o PartsSystem -r
rem codegen -e -s SUPPLIER      -t CRUD -n PartsSystem -ut MAIN_CLASS=PartsSystemAPI -o PartsSystem -r

echo Generating WCF Service code...
codegen -e -s PART          -t CRUDService -n server -ut WCF_SERVICE=PartsSystemService API_NAMESPACE=PartsSystem API_CLASS=PartsSystemAPI -o server -r
rem codegen -e -s PRODUCT_GROUP -t CRUDService -n server -ut WCF_SERVICE=PartsSystemService API_NAMESPACE=PartsSystem API_CLASS=PartsSystemAPI -o server -r
rem codegen -e -s SUPPLIER      -t CRUDService -n server -ut WCF_SERVICE=PartsSystemService API_NAMESPACE=PartsSystem API_CLASS=PartsSystemAPI -o server -r

echo Code generation complete

endlocal