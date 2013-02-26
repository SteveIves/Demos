-------------------------------------------------------------------------------

Name:           DotNetApiExamples.zip

Author:         Steve Ives
                Synergex Professional Services Group
                steve.ives@synergex.com

Platforms:      Windows

Minimum version: Synergy/DE 9.1.3, but 9.1.5 is strongly recommended

Revisions:       Version  Date                     Comment
                 -------  -----                    --------
                 1.0      13th May 2008            Original version

Disclaimer:      All code is supplied as seen and without warranty or support.
                 Use at your own risk. Neither the author nor Synergex accept 
                 any responsibility for any loss or damage which may result 
                 from the use of this code.

-------------------------------------------------------------------------------

This CodeExchange entry contains a collection of programs which demonstrate the
use of the new Synergy .NET Assembly API.

Instructions:

Use Workbench to open the Workspace DotNetApiExamples.vpw

Project example1.vpj
====================
This project contains three programs, each of which demonstrates the manual use
of the .NET Assembly API (i.e. without using the GENNET tool to create Synergy
wrapper classes for the .NET classes that you wish to use).

To run the demonstrations, open one of the three programs in the editor, then
select "Build > Compile" to compile, "Build > Build" to link, and then "Build
> Execute" to run the program.  Some of these programs have external dependencies
(see below).

Make the project current by right-clicking it ansd selecting "Set Active Project"

ReportViewer.dbl        This program demonstrates creating and processing a report
                        viewer capable of displaying reports from a SQL Server
                        2005 Reporting Services server.  In order to run the demo
                        you will need to install the supplied reports (see the
                        AdventureWorksReports folder) into your report server,
                        and your SQL Server database must have the AdventureWorks
                        sample database installed.  If your report server is not
                        on your local system you will need to edit the value of
                        the identifier D_REPORT_SERVER to point to your report
                        server, and you will need to check the report paths
                        (in the example main-line program) to make sure that they
                        are correct.

SendEmail.dbl           This program demonstrates sending an email message with
                        a binary attachment, in this case a PDF file.  If you
                        wish to run the program then you will need to edit the
                        value of the identifier d_SmtpServer to point to your
                        email (SMTP) server, and you may also with to review and
                        update the other identifiers in the same location.

WinForm1.dbl            This program demonstrates the creation and processing of
                        a Widows form.  The form includes controls which are not
                        available natively through UI Toolkit, such as a
                        PictureBox control and a TrackBar control.  This example
                        also demonstrates how to bind Synergy methods to events
                        which are raised in the underlying .NET objects being
                        used.

Project example2.vpj
====================
This project contains an example of using GENNET to create wrapers for a .NET
assembly, and then using those wrappers to write Synergy code to manipulate types
within the assembly.  This example creates wrappers for the "System.Xml"
assembly, and then uses several types to perform an XSL transformation,
transforming an XML file which contains raw data into an HTML file which includes
presentation information.

Make the project current by right-clicking it ansd selecting "Set Active Project"

First review the program code in XslTransform.dbl, and the "raw" data in
SalesReport.xml.

To review the steps involved in creating the .NET wrappers, review the batch file
called rebuild.bat

To generate the wrappers and compile and link the example, select "Build > Rebuild"

To run this example select "Build > Execute"

Project example3.vpj
====================
This project contains an example of creating Synergy wrapper classes for several
major .NET namespaces, including "System.Winfows.Forms", and then using those
wrappers to create and process a Windows form.  Although this is conceptually
similar to WinForm1.dbl in example1.vpj, the implementation is TOTALLY different.

First open and review the application code in WinForm2.dbl.  You will see that the
code is relatively simple, it creates and runs an instance of a class called
frmEmployee.

Next review frmEmployee.dbl.  This code is the code which defines the Windows form.
The code is the Synergy equivalent of the C# or VB code that you might create in
Visual Studio when using the graphical forms designers.  This code USES the
underlying .NET classes for which we will create wrappers.

Review the batch file "BuildWrappers.bat".  This procedure creates, prototypes and
compiles the Synergy class wrappers for several major .NET assembiles.

Review the batch file "BuildForm.bat".  This procedure compiles the program and the
windows form, and builds them against the generated wrapper classes.

To build and run the demo 

  1. Make the project current by right-clicking it ansd selecting "Set Active Project"
  2. From the Workbench menu, select "Tools > OS Shell" to open a DOS prompt"
  3. Execute the "BuildWrappers.bat" procedure.  This may take several minutes to
     complete!
  4. Execute the "BuildForm.bat" procedure.
  5. Execute the "run.bat" procedure.


-------------------------------------------------------------------------------

