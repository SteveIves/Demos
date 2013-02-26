@echo off

echo ---------------------------------------------------------------------------
echo CREATING CA CERTIFICATE REQUEST AND PRIVATE KEY
echo ---------------------------------------------------------------------------
rem 
rem	Reads:		ca.cfg			CA configuration file
rem 
rem	Creates:	carequest.pem		CA certificate request
rem 			cakey.pem		CA private key
rem 

openssl req -newkey rsa:1024 -config ca.cfg -out carequest.pem -keyout cakey.pem

if not exist carequest.pem goto error1
if not exist cakey.pem goto error1

echo ---------------------------------------------------------------------------
echo CREATING SELF-SIGNED CA CERTIFICATE
echo ---------------------------------------------------------------------------
rem
rem	Reads:		ca.cfg			CA configuration file
rem 			carequest.pem		CA certificate request
rem			cakey.pem		CA private key
rem
rem	Creates:	ca.pem			CA certificate
rem

openssl x509 -req -in carequest.pem -signkey cakey.pem -out ca.pem -extfile ca.cfg

if not exist ca.pem goto error2

goto end

:error1
echo *** ERROR *** Failed to create request files
goto end

:error2
echo *** ERROR *** Failed to create certificate
goto end

:end