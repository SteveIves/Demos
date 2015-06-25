cd /d "%~dp0""
call "%VS120COMNTOOLS%vsvars32.bat"
echo Regenerating client proxy code...
svcutil /nologo /language=Synergy /namespace=*,WcfServiceClient /collectionType:System.Collections.Generic.List`1 http://localhost/WebHost/PartsService.svc