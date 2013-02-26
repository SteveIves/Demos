@echo off
setlocal
rem Check for the XML file for the default SMC
if not exist "%XFPL_SMCPATH%\DefaultSMC.xml" goto no_xml
rem
rem Load the XML file into the SMC
echo Loading default method catalog...
dbs DBLDIR:mdu -i %XFPL_SMCPATH%\DefaultSMC.xml
if ERRORLEVEL 1 goto fail
echo Default method catalog was loaded
goto done

:no_xml
echo ERROR: Can't find file DefaultSMC.xml
goto done

:fail
echo ERROR: Failed to load method catalog

:done
endlocal
