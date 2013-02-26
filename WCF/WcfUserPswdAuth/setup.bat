echo off
set SERVER_NAME=localhost
echo ---------------------------------------------------------------------
echo cleaning up the certificates from previous run
certmgr.exe -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%
certmgr.exe -del -r LocalMachine -s My -c -n %SERVER_NAME%

echo ---------------------------------------------------------------------
echo Server certificate setup starting for server: %SERVER_NAME%
echo Making server certificate...
makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe
echo Copying server certificate to client's CurrentUser store...
certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople
echo ---------------------------------------------------------------------
