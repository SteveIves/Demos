@echo off

echo ---------------------------------------------------------------------------
echo ADDING LOCAL CA TO TRUSTED CA'S FILE
echo ---------------------------------------------------------------------------
rem 
rem	Reads:		trusted_cas.pem		Trusted CA's file in PEM format
rem
rem			..\CA\ca.pem		Local CA certificate
rem 
rem	Creates:	trusted_cas.pem		Trusted CA's file in PEM format (including local CA)
rem 

if not exist trusted_cas.pem goto error1
if not exist ..\CA\ca.pem goto error2

copy trusted_cas.pem + ..\CA\ca.pem trusted_cas.pem

goto end

:error1
echo *** ERROR *** Trusted CA's file (trusted_cas.pem) not found
goto end

:error2
echo *** ERROR *** Local CA certificate (..\CA\ca.pem) not found
goto end

:end









