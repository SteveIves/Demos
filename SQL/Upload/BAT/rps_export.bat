if exist %ROOT%RPS\sqlupload.sch del /q %ROOT%RPS\sqlupload.sch
dbs RPS:rpsutl -e %ROOT%RPS\sqlupload.sch
