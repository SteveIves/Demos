if exist %ROOT%SERVER\XFPL\AspProvidersSmc.xml del /q %ROOT%SERVER\XFPL\AspProvidersSmc.xml
if exist %ROOT%SERVER\XFPL\AspProvidersSmc.xml goto delete_fail

dbs DBLDIR:mdu -v
dbs DBLDIR:mdu -e AspProvidersSmc.xml
goto done

:delete_fail
echo *ERROR* Failed to delete existing SMC file, did you check it out first?

:done
