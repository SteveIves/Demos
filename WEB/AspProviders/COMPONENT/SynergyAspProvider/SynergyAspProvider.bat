IF EXIST "SynergyAspProvider.dll" del "SynergyAspProvider.dll"
IF NOT EXIST "SynergyAspProvider.snk" sn -k "SynergyAspProvider.snk"
if '%1' == '-p' goto pooling
csc /nologo /target:library /out:"SynergyAspProvider.dll" /reference:"%XFNLNET%\xfnlnet.dll" /optimize /keyfile:"SynergyAspProvider.snk" %SYNCSCOPT% @SynergyAspProvider.rsp
goto done
:pooling
csc /nologo /target:library /define:POOLING /out:"SynergyAspProvider.dll" /reference:"%XFNLNET%\xfnlnet.dll" /optimize /keyfile:"SynergyAspProvider.snk" %SYNCSCOPT% @SynergyAspProvider.rsp
:done
