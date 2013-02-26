IF EXIST "SynergyComponent.dll" del "SynergyComponent.dll"
IF NOT EXIST "SynergyComponent.snk" sn -k "SynergyComponent.snk"
if '%1' == '-p' goto pooling
csc /nologo /target:library /out:"SynergyComponent.dll" /reference:"%XFNLNET%\xfnlnet.dll" /optimize /keyfile:"SynergyComponent.snk" %SYNCSCOPT% @SynergyComponent.rsp
goto done
:pooling
csc /nologo /target:library /define:POOLING /out:"SynergyComponent.dll" /reference:"%XFNLNET%\xfnlnet.dll" /optimize /keyfile:"SynergyComponent.snk" %SYNCSCOPT% @SynergyComponent.rsp
:done
