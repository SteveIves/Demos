@echo off
setlocal
set DEVROOT=%~dp0
cd /d "%DEVROOT%"
set CODEGEN_TPLDIR=%DEVROOT%templates

echo Generating CRUD code...
codegen -e -s PART PRODUCT_GROUP SUPPLIER -t CRUD -n PartsSystem -ut MAIN_CLASS=PartsSystemAPI -o PartsSystem -r

echo Generating WCF Service code...
codegen -e -s PART PRODUCT_GROUP SUPPLIER -t CRUDService -n WcfServiceLibrary -ut WCF_SERVICE=PartsService API_NAMESPACE=PartsSystem API_CLASS=PartsSystemAPI -o WcfServiceLibrary -r

endlocal