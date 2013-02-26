README.TXT
==========



Synergex distributes this example program to enable you to more 
easily learn and take advantage of new features.  Because the 
program requires that a variety of third party ActiveX controls be 
installed on your system, Synergex provides this code "as is", and 
does not offer any guarantees that all features will work correctly 
on your particular configuration.  In addition, Synergex does not 
offer support for this program.  Synergex encourages you to review 
and execute this sample code to learn how to use these features 
most effectively.

If you would like help configuring your system or you would like
training on the new features, please contact your Account Executive
who can arrange a consulting engagement.



This readme file describes how to setup the environment to run and
recompile the demonstration program first shown at the 1998 
Synergex Success Partners Conference in Orlando.

You must have Synergy/DE version 6.3.0 or later installed, however 
version 6.3.1 is recommended.

The ENV.BAT file sets up the environment for a DOS window.  You 
must use this batch file, unless you move the SYNERGY.INI to your 
windows system folder.

Both ENV.BAT and SYNERGY.INI assume that the demo program is 
installed in the C:\SYNERGYDE\TOOLKIT\EXAMPLES\SPC98 folder.  If 
not, please modify both of these files to use the relevant folder.  
Only the setting of the logical DEMOLOG needs to be changed in 
either file.


Folder use
----------

BITMAPS	contains .BMP, .WAV, .AVI and .ICO files.  These are mainly 
used by the buttons on the toolbar.

CONTROLS contains the Synergex supplied ActiveX controls. These 
will need to be registered (see below).

DATA contains the data files
	descript.ism - the long descriptions used by the printing 
		       routine
	price.ism - pricing information
	quote_head.ism & quote_detail.ism - copies of saved quotes

EXECUTE contains the DBR file(s)
	demoprog.dbr - the executable program

LIBRARY contains the Synergy Window library
	demo.ism - the window library data file

RPSDAT contains the Synergy/DE repository files
	rpsmain.ism & rpstext.ism - the standard repository files

SOURCE contains all source code files required to rebuild the 
       application

URL contains the files required to emulate the Synergex Home page
	synergex.html and images folder


ActiveX Controls
----------------

The following controls are supplied by Synergex, and are 
registered by the installation (if the controls were not able to 
be registered, the installation program displays an error message 
stating this): MAILWORKING.ocx, PRGABOUTBOX.ocx, PROGRESS.ocx, 
SYNERGEXWEB.ocx and SYNERGYQUOTEWIZARD.ocx.  These can be installed 
manually by using the ActiveX Diagnostic Utility, which is supplied 
as part of Synergy 6.3.

The following controls are supplied by Microsoft, and should be 
installed by a Microsoft application: MSSTKPRP.dll, SHDOCVW.dll, 
MARQUEE.ocx, MCI32.ocx, MSMAPI32.ocx, TABCTL32.ocx, MSVBVM50.dll, 
COMCT232.ocx, COMCTL32.ocx, OLEAUT32.dll, OLEPRO32.dll, 
ASYCFILT.dll, CTL3D32.dll, COMCAT.dll, STDOLE2.tlb.  Most of these 
controls are available on systems with Microsoft Outlook, Microsoft 
Internext Explorer 4.0 and Microsoft Visual Basic.


Running from an ICON
--------------------

To run the demo program from an icon, you must have copied the 
SYNERGY.INI file in the demo install directory to the windows 
system folder, or manually modified the SYNERGY.INI in the windows 
system directory with the details of the [demoprog] section from 
the install directory.  Ideally, you should also set up a file 
association between .DBR files and the Synergy/DE DBR.EXE program.  
If you have done both of these, the properties section of the icon
should be 'C:\synergyde\toolkit\examples\spc98\execute\demoprog.dbr'.


Re-compiling the application
----------------------------

Use the CB.BAT file in the .\source folder.  To recompile the demo 
program type "CB DEMOPROG" (without the quotes) at the command 
prompt.

It's possible to rebuild the program as a single executable, 
because the demoprog.dbl includes the source code for all of the 
required routines, effectively forcing the Synergy compiler to 
treat the entire application as a single source file.


Source Code
-----------

The source code is best viewed using an editor which has tab stops 
every 4 characters.


Use of Logicals
---------------

Logicals have been used to store certain data elements, in addition 
to the more traditional use.  Please refer to SYNERGY.INI, where 
all logicals are defined.
