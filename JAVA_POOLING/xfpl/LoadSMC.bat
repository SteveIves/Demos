@echo off
setlocal

rem Delete any existing file to make sure we get a new one
if exist %XFPL_SMCPATH%\SynergyServerSMC.xml del /q %XFPL_SMCPATH%\SynergyServerSMC.xml

rem Generate a new SMC XML file from our method sources
echo Processing source files...
dbl2xml %SRC%\*.dbl -out %XFPL_SMCPATH%\SynergyServerSMC.xml
if ERRORLEVEL 1 goto parse_fail

rem Load the XML file into the SMC
echo Loading method catalog...
dbs DBLDIR:mdu -u %XFPL_SMCPATH%\SynergyServerSMC.xml
if ERRORLEVEL 1 goto load_fail
echo Method catalog was loaded

goto done

:parse_fail
echo ERROR: Failed to extract SMC data from code
goto done

:load_fail
echo ERROR: Failed to load method catalog

:done
endlocal
