@echo off

echo ---------------------------------------------------------------------------
echo CREATING CERTIFICATE REQUEST AND PRIVATE KEY
echo ---------------------------------------------------------------------------
rem 
rem 	Reads:		test.cfg
rem 
rem 	Creates:	testrequest.pem
rem 			testkey.pem
rem 
rem 	Comments:	This would normally be done by a party requesting a
rem			certificate, who would subsequently send the request
rem			file to a CA.
rem 

openssl req -newkey rsa:1024 -out testrequest.pem -keyout testkey.pem -config test.cfg

if not exist testrequest.pem goto error
if not exist testkey.pem goto error

goto end

:error
echo *** ERROR *** Failed to create certificate request
goto end

:end
