@echo off
setlocal

set DEVROOT=%~dp0
cd /d "%DEVROOT%"
set RPSMFIL=%DEVROOT%rps\rpsmain.ism
set RPSTFIL=%DEVROOT%rps\rpstext.ism
set CODEGEN_TPLDIR=%DEVROOT%templates

set STRUCTURES=PART PRODUCT_GROUP SUPPLIER

set LOGIC_PROJECT=BusinessLogic
set SERVICES_PROJECT=Services
set HOST_PROJECT=ServiceHost

codegen -e -r -s %STRUCTURES%     -t ServiceStack_Code    -n %LOGIC_PROJECT%    -o %LOGIC_PROJECT%
codegen -e -r -s %STRUCTURES%     -t ServiceStack_Service -n %SERVICES_PROJECT% -o %SERVICES_PROJECT% -ut LOGIC_PROJECT=%LOGIC_PROJECT%
codegen -e -r -s %STRUCTURES% -ms -t ServiceStack_AppHost -n %HOST_PROJECT%     -o %HOST_PROJECT%     -ut SERVICES_PROJECT=%SERVICES_PROJECT% LOGIC_PROJECT=%LOGIC_PROJECT%

echo Code generation complete

endlocal