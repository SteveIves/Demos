cd /d %ROOT%
if not exist SqlUpload.vpw goto end
del /s /q %ROOT%\*.dbo
del /s /q %ROOT%\*.dbr
del /s /q %ROOT%\*.elb
del /s /q %ROOT%\*.ism
del /s /q %ROOT%\*.is1
del /s /q %ROOT%\*.vtg
del /s /q %ROOT%\*.vpwhist
:end
