
if not exist %ROOT%SERVER\XFPL\AspProvidersSmc.xml goto no_file

dbs DBLDIR:mdu -i AspProvidersSmc.xml
dbs DBLDIR:mdu -v
goto done

:no_file
echo *ERROR* SMC file AspProvidersSmc.xml not found, get it from Vault!

:done
