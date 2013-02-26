Readme for Synergy/DE Licensing Toolkit
Version 9.1.5b
April 2009

This readme is part of the Licensing_TK.zip file, which also includes 
lmk.exe and lt915.pdf. 

=========================
Installing the License Key Generator Utility

1. Once you unzip the file that contains this readme, copy 
   lmk.exe to your SynergyDE\dbl\bin directory. 

2. Put the PDF and readme files anywhere you like. You may want 
   to put the PDF in SynergyDE\Manuals with the other online 
   manuals. 


=========================
Documentation

See the "Licensing Toolkit User's Guide" (lt915.pdf) for 
information on using the License Key Generator utility and 
the Licensing Toolkit API. This document requires that 
you have Adobe Reader or Adobe Acrobat version 7 or higher 
installed. We distribute version 8 of Adobe Reader on the 
Synergy/DE Online Manuals CD or you can visit Adobe's website 
at http://www.adobe.com to download a free copy of the Reader.  


=========================
Code Examples

See Licensing_TK_Examples.zip, available from CodeExchange in the 
Resource Center on the Synergex website, http://www.synergex.com.
It contains an interactive interface to the License Key Generator 
utility, as well as other programs and routines that illustrate 
the use of Licensing Toolkit. 


=========================
Revision 9.1.5b

-- The License Manager Kit product is now named Licensing 
Toolkit and includes the following: 

   - The Licensing Toolkit API, which is distributed with 
   Core Components on Windows and UNIX
   
   - The License Key Generator utility, which you received 
   with this readme (Windows only)
   
   - The "Licensing Toolkit User's Guide", which includes
   documentation for the API and the License Key Generator 
   utility 

-- Previously, the LM_LOGIN routine had two forms, the second 
of which returned License Manager information about the system 
on which the application was running. We have renamed this 
second form to LM_INFO to better reflect what it does and to 
simplify the arguments. Code using the previous routine name 
and arguments will still run. 

-- In addition to Synergy routines, the Licensing Toolkit API 
now includes syncli_api.dll, which contains three C functions 
that can be called from a C, C++, .NET, or any other application 
that can call a DLL. For example, you can use syncli_api.dll to 
secure an xfNetLink .NET application. The three functions are 
win_lm_login, win_lm_logout, and win_lm_stat. The last can be 
used to check the current license usage for an application 
that has been secured with the Licensing Toolkit API. 

-- Both the Synergy and the C login/logout routines now include 
a "seat" argument. In a server environment where there are 
multiple processes, the seat argument enables you to ensure 
that the correct license is logged out. 

-- We removed the need to create and distribute a producer 
file. If you used License Manager previously to secure your 
Synergy applications, you had to create and distribute a 
producer file. This functionality is now built into the 
application. You should REMOVE THE PRODUCER FILE from the 
machine that you use to generate keys as well as from your 
customers' machines. If a customer reports the error "Cannot 
open Producer entry" when configuring license keys, the problem 
is likely an old producer file. 

-- The license server and all license clients must be at least 
version 9.1.5a. 
