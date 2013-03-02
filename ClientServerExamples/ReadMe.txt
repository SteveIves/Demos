
Synergy/DE CodeExchange Item
--------------------------------------------------------------------------------

Title:		ClientServerExamples.zip

Description:	Examples of various types of client / server applications

Author:		Steve Ives (Synergex Professional Services Group)

Revision:	1.0 (May 2011)


Description:    This CodeExchange item contains several examples of various
                types of client / server appliction architectures.

--------------------------------------------------------------------------------

Configuring the environment:
---------------------------

It is strongly recommended that the Zip File be placed in the following folder:

    C:\CodeExchange\SynNet

And then be extracted to that location using WinZip, by right-clicking on the
ZIP file and selecting "WinZip > Extract to here". If you do this you will see
a folder structure like this:

    C:\CodeExchange\SynNet\ClientServerExamples
    C:\CodeExchange\SynNet\ClientServerExamples\1_xfpl_xfnl
    C:\CodeExchange\SynNet\ClientServerExamples\2_xfpl_xfnl_web_service
    C:\CodeExchange\SynNet\ClientServerExamples\3_xfpl_xfnl_wcf_service
         ...

If this is the case then ignore the remainder of this section and continue with
"Setting up xfServerPlus" below.

If you place the files in another location then you must complete the following
changes in order to use the environment fully.

1.  Start Workbench and open the Workspace file SynergyServer.vpw

2.  Right-click on the project file xfNetLink.vpj and select
    "Component Information".

3.  Under "Assembly Output", change the "Directory" field to your
    "ClientServerExamples\xfNetLink" folder.

4.  Under "Repository", change "Main File" to your
    "ClientServerExamples\xfServerPlus\rps\rpsmain.ism" file

5.  Under "Repository", change "Text File" to your
    "ClientServerExamples\xfServerPlus\rps\rpstext.ism" file

6.  Under "Interfaces", click "Change Directory" and then select your
    "ClientServerExamples\xfServerPlus\xfpl" directory, then check the
    "SynergyServer" interface.

7.  Click the OK button to save your changes.

8.  Right-click on the project file xfNetLink_wcf.vpj and select
    "Component Information".

9.  Under "Assembly Output", change the "Directory" field to your
    "ClientServerExamples\xfNetLink_wcf" folder.

10. Under "Repository", change "Main File" to your
    "ClientServerExamples\xfServerPlus\rps\rpsmain.ism" file

11. Under "Repository", change "Text File" to your
    "ClientServerExamples\xfServerPlus\rps\rpstext.ism" file

12. Under "Interfaces", click "Change Directory" and then select your
    "ClientServerExamples\xfServerPlus\xfpl" directory, then check the
    "SynergyServer" interface.

13. Click the OK button to save your changes.

14. Under the project "xfServerPlus.vpj", expand the folder "Other Files".

15. Double-click on the file xfpl.ini and then change the values for the following
    settings:

    - XFPL_LOGFILE                ...\ClientServerExamples\xfServerPlus\xfpl\xfpl.log

    - XFPL_LOGICAL:XFPL_SMCPATH   ...\ClientServerExamples\xfServerPlus\xfpl

    - XFPL_LOGICAL:EXE            ...\ClientServerExamples\xfServerPlus\exe

    - XFPL_LOGICAL:DAT            ...\ClientServerExamples\xfServerPlus\dat


16. Save and close the file, then close Workbench.

--------------------------------------------------------------------------------

Setting up xfServerPlus:
-----------------------

1.  Start the Synergy Configuration Program. If you're on a 64-bit system make
    sure you start the 64-bit version of the program.

2.  Switch to the xfServer/xfServerPlus tab.

3.  Click the "Add xfServerPlus Service" button.

4.  Enter a "Service Name", e.g. demo_xfpl

5.  Enter a "Port Number 2356.

6.  Enter a valid username (must not be an administrator account)).

7.  Enter the password for the user account.

8.  Click the "Environment Settings" button.

9.  If you're on a 64-bit Synergy system then change the definition of
    DBLDIR from the 64-bit versoin of Synergy to the 32-bit version of Synergy.

10. Add a new environment setting (in the same area as the DBLDIR setting)
    named XFPL_INIPATH and set its value to the xfServerPlus\xfpl folder
    that was part of the directory structure that you unzipped.

11. Click the OK button to save the changes to the environment settings.

12. Clikc the OK button to save the new xfServerPlus service.

13. Ckick the Apply button to save the new service.

14. Click the "Start Service" button to start the new service.

15. Test the new service by opening a command prompt with a 32-bit Synergy
    environment (dblvars32.bat) and type the following command:

    dbs DBLDIR:xfnlst localhost 2356

    You should see output like this:

    DBL/MS-WINDOWS Version 9.5.1a
    Running xfServer connection tests for:
    Machine: localhost
    Port: 2356

    Test 1. xfpl_tst1.
    Test 1 successful!
    Test 2. xfpl_tst2.
    Test 2 successful!
    Test 3. xfpl_tst3.
    Test 3 successful!
    Test 4. xfpl_tst4.
    Test 4 successful!
    Test 5. xfpl_tst5.
    Test 5 successful!
    Test 6. xfpl_tst6.
    Test 6 successful!
    Test 7. xfpl_tst7.
    Test 7 successful!
    Server: DBL/MS-WINDOWS Version 9.5.1a

    If you don't see the "Successful" messages then you got something wrong,
    or you don't have xfServerPlus installed or licensed!

--------------------------------------------------------------------------------

About the Demos:
---------------

In each of six folders included you will find a diferent implementation of the
same .NET client application, but with different technologies being used to
"communicate" with the "back-end" server. In fact, each of the folders contains
three seperate versions of the client application, one developed in C# (CS),
one developed in Synergy .NET (SN), and one developed with Visual Basic .NET (VB).

In order to fully execute these examples, you will need the following:

 - Synergy/DE 9.5.1a (or higher) with xfServerPlus. (On a 64-bit system you'll
   need BOTH 32 and 64 bit versions of Synergy installed.

 - Visual Studio 2010 Professional SP1 or higher

 - Synergy Language Integration for Visual Studio 9.5.1a or higher.


The first three apps rely on an instance of xfServerPlus being setup on port
2356. Follow the instructions at the bottom of this file to setup the service.

The examples are as follows:

Folder				Description
------				-----------

1_xfpl_xfnl			The  client applications use xfNetLink .NET
				to communicate directly with xfServerPlus.
				The business logic is provided by traditional
				Synergy subroutines and functions, which could
				operate on any platform supported by traditional
				Synergy (Windows, Unix, Linux or OpenVMS). This
				type of solution is only really appropriate
				when client and server applications communicate
				over a local area network.

2_xfl_xfnl_web_service		The client applications communicate with an
				ASP.NET web service, which in turn uses
				xfNetLink .NET to communicate with
				xfServerPlus. The business logic is provided
				by traditional Synergy subroutines and functions,
				which could operate on any platform supported
				by traditional Synergy (Windows, Unix, Linux
				or OpenVMS), but the ASP.NET web service
				must be hosted in an IIS web server on a
				Windows system. This approach would have been
				common when if it was necessary for the client
				to communicate with the server over wide area
				networks or the Internet, but better solutions
				now exist.

3_xfpl_xfnl_wcf_service		The client application communicates with
				a WCF service which is hosted in an ASP.NET
				web application. The WCF service was created
				using xfNetLink .NET with the optional -w
				switch to the GENCS utility. xfServerPlus
				is still providing the business logic in
				the form of traditional Synergy subroutines
				and functions. The WCF service must be hosted
				on a Windows system. This is a good way of
				enhancing existing xfNetLink / xfServerPlus
				applications so that thet can communicate
				over wide area networks or the Internet.

4_synnet_interop		In this example the business logic routines
				have been included in a Synergy .NET "Interop"
				assembly, and are accessed directly by the
				various .NET client applications, "in process".
				xfNetLink and xfServerPlus are no longer
				being used. This application is not really
				a client / server application, as all of the
				logic is included directly within the client
				applications. This example would operate only
				on Windows systems. Data could be accessed on
				a remote system via xfServer. Using Interop
				in this way is a good solution for factoring
				out xfNetLink and xfServerPlus from existing
				applications where both the client and server
				both exist on the same Windows server. This
				may be the case for Windows based web
				applications where the Synergy logic is also
				on the same Windows server, or for desktop
				applications deployed on Windows Terminal
				Server systems.

5_synnet_interop_wcf		This example also uses a Synergy .NET
				Interop assembly, but takes advantage of the
				Interop projects ability to expose a WCF
				Service, which is then hosted in an ASP.NET
				web application. The various client apps
				then communicate with the WCF service. This
				example would operate on Windows systems for
				the client and server portions of the app, but
				data could be hosted on other systems and
				accessed via xfServer.

6_synnet_wcf			In this final example the client application
				again communicates with a WCF service, but
				this time the service provided by native
				Synergy .NET OO code. xfServerPlus, xfNetLink
				and Interop projects are not used. Ths client
				and server are both .NET and as such must
				operate on a Windows system, however the data
				could still be accessed from a remote server
				via xfServer. This would be the recommended
				mechanism when developing new client / server
				solutions.

Important note
--------------
In all of the examples which include the use of a WCF service, that WCF
service is hosted in an ASP.NET web application, but other options are also
available. In many cases, for example, it is appropriate to "self host" the
WCF service in an application, often a Windows Service application. This
means that operating an IIS web server is not a requirement in order to
expose a WCF service.

