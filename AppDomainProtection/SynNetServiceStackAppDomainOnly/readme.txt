
Title:          SynNetServiceStackAppDomainOnly

Description:    An example of how to implement ServiceStack services using
                Synergy .NET while providing the required AppDomain isolation
                needed for Synergy .NET code.

                This example DOES NOT provide thread locking protection for
                xfServer, so xfServer should not be used with this example.

Author:         Steve Ives, Synergex Professional Services Group

Revision:       1.0

Date:           4th December 2014

Requirements:   Synergy .NET 10.3.1 or higher

--------------------------------------------------------------------------------
Change history

1.0             Original example.

--------------------------------------------------------------------------------

There are some special considerations that must be taken into account when
executing Synergy .NET code in any multi-threaded environment. Specifically a
developer must give special consideration to how the following entities are
used within the code, all of which exist at the process level:

    * Channels
    * COMMON data
    * GLOBAL data
    * STATIC data or other entities
    * Environment variables

In traditional Synergy environments (when compiling with dbl.exe and executing
your code with dbr.exe) your code executes in a process that is dedicated to
running your program. If other users are running the same code then they are
running it in the context of a totally seperate process. This means that each
instance of the code has private channels and common data, etc.

However, in Synergy .NET it is possible to execute code in environments where
multi-threading (running several "threads" of code all within a single process)
is supported. Examples of multi-threaded environments include:

    * Code that you write to execute code in multiple threads

    * Web applications
      - ASP.NET
      - ASP.NET MVC

    * Web Services Wnvironments
      - Windows Communication Foundation (WCF)
      - ServiceStack

There are two main things that must be considered when running code in any
multi-threaded environment:

    1. By default code running in all threads share the same Channels, COMMON
       data, GLOBAL data and STATICs.

    2. If the code uses xfServer then it is critical that any given entity of
       code always executes on the same thread, and the code must execute
       xcall s_server_thread_init before accessing xfServer. This example
       assumes that xfServer is NOT being used and does not provide this
       type of protection.

If you want each instance of code to be isolated from all other instances, so
that channels, COMMONs, GLOBALs, etc. are unique to that thread, then the way
to achieve that is to load each instance of the code into a seperate "AppDomain".
The sample code included with this example demonstrates how to do that when
implementing a ServiceStack service.

IMPORTANT:

* This example code does not address the issue of environment variables. If your
  application uses XCALL SETLOG to set environment variables at runtime, and if
  the values of those environment variables vary (based on user, or some other
  criteria) then you must implement that functionality in some other way. In
  Synergy (including Syenrgy .NET) environment variables are always set at the
  process level, and AppDomain protection DOES NOT CHANGE THAT!

* This example assumes that xfServer is not being used to access the data. If
  xfServer is required then additional protection steps are necessary in order
  to lock xfServer connections to the thread that they are initially created on,
  and to ensure that each service instance always executes on the same thread.

The solution has been configured so that when you run the application BOTH
the ServiceHost and TestClientCS applications will be launched. You will see
the server applications console window appear almost immediately, but it is
normal for the TestClient application to take a few seconds to appear. This
is because we're simultaneously launching two applications from one solution.

================================================================================
BusinessLogic Project

This project is a Synergy .NET Class Library that essentially contains Synergy
business logic and database access code. The code in this class library is called
by the code in the ServiceStack service.

Most of the code in this project was code generated using CodeGen. The CodeGen
templates that were used can be found in the "Templates" solution folder, and
the CodeGen commands that were used can be found in the regen.bat batch file
in the "Solution Items" solution folder.

================================================================================
Services Project

This project is again a Synergy .NET class library. It contains classes that
"wrap" the business logic in the previous project in a series of ServiceStack
services.

Again, most of the code in this project was code generated using CodeGen.

================================================================================
ServiceHost Project

This project is a Synergy .NET console application that is used to host the
ServiceStack services. When the service host program starts you should see a
console window apper, and it should contain text similar to this:

	ServiceStack SelfHost listening at http://localhost:8088
	Metadata is available at http://localhost:8088/metadata
	Press a key to terminate the server:

You can view the services metadata by going to the metadata URL with a Web browser.

================================================================================
TestClientCS Project

This project is a very simple WPF application. It has a ServiceStack Service
Reference to the services exposed by the server solution, and exercises some of
the services methods
