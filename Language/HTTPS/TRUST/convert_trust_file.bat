@echo off

echo ---------------------------------------------------------------------------
echo CONVERTING TRUSTED CA FILE TO PEM FORMAT
echo ---------------------------------------------------------------------------
rem 
rem	Reads:		trusted_cas.p7b		File exported from IE
rem 
rem	Creates:	trusted_cas.pem		Trusted CA's file in PEM format
rem 

if not exist trusted_cas.p7b goto error
openssl pkcs7 -inform DER -outform PEM -in trusted_cas.p7b -out trusted_cas.pem -print_certs

goto end

:error
echo *** ERROR *** Input file trusted_cas.p7b not found

:end
