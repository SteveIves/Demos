@echo off

echo ---------------------------------------------------------------------------
echo USING LOCAL CA TO CREATE TEST CERTIFICATE
echo ---------------------------------------------------------------------------
rem 
rem	Reads:		testrequest.pem		Certificate request
rem
rem 			..\CA\ca.cfg		CA configuration file
rem 			..\CA\ca.pem		CA certificate
rem			..\CA\cakey.pem		CA private key
rem 
rem 	Creates:	test.pem		Certificate
rem 
rem 	Comments:	This would normally be done by the CA after receiving a
rem			request from a third-party. The CA would subsequently
rem			return the certificate file to the requesting party.
rem 

if not exist testrequest.pem goto error1

if not exist ..\CA\ca.cfg goto error2
if not exist ..\CA\ca.pem goto error2
if not exist ..\CA\cakey.pem goto error2

openssl x509 -req -in testrequest.pem -extfile ..\CA\ca.cfg -CA ..\CA\ca.pem -CAkey ..\CA\cakey.pem -CAcreateserial -out test.pem

if not exist test.pem goto error3

goto end

:error1
echo *** ERROR *** No request file found
goto end

:error2
echo *** ERROR *** Failed to locate local CA
goto end

:error3
echo *** ERROR *** Failed to create certificate
goto end

:end
