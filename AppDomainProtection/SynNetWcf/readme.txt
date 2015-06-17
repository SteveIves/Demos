
Title:          SynNetWcf

Description:    An example of how to implement WCF services using Synergy .NET
                while providing the required AppDomain isolation and multi-
                threading protection needed for Synergy .NET code. This example
                implements the WCF service directly in code, not via a Synergy
                .NET Interop project. A different solution would be required
                in that case.

Authors:        Steve Ives, Synergex Professional Services Group
                Jeff Greene, Synergex Development

Revision:       1.3

Date:           17th June 2015

Requirements:   Synergy .NET 10.3.1a or higher

--------------------------------------------------------------------------------
Change history

1.0             Original example.

1.1             Simple bug fix.

1.2             Enhanced the code in the AppDomainProtection assembly to work
                better when hosted in IIS.

1.3             Re-worked the mechanisms used in the AppDomainProtection code
                and significantly improved the suggested coding pattern for
                the WCF service methods.

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
    * ASP.NET Web applications
    * Windows Communication Foundation (WCF) services

There are two main things that must be considered when running code in any
multi-threaded environment:

    1. By default code running in all threads share the same Channels, COMMON
       data, GLOBAL data and STATICs.

    2. If the code uses xfServer then it is critical that any given entity of
       code always executes on the same thread, and the code must execute
       xcall s_server_thread_init before accessing xfServer.

If you want each instance of code to be isolated from all other instances, so
that channels, COMMONs, GLOBALs, etc. are unique to that thread, then the way
to achieve that is to load each instance of the code into a seperate "AppDomain",
and if xfServer is being used then it must also be ensured that each instance
of the code always executes on the same thread. The sample code included with
this example demonstrates how to do that when implementing a WCF service.

IMPORTANT: This example code does not address the issue of environment variables.
If your application uses XCALL SETLOG to set environment variables at runtime,
and if the values of those environment variables vary (based on user, or some
other criteria) then you must implement that functionality in some other way.
In Synergy (including Syenrgy .NET) environment variables are always set at the
process level, and AppDomain protection DOES NOT CHANGE THAT!

IMPORTANT: The instance of Visual Studio that is used to open and run this
demo code MUST be "Run as Administrator". If you don't do this then the server
application will fail to start because it won't have permissions to bind to
your network adapter.

The solution has been configured so that when you run the application BOTH
the ServiceHost and TestClient applications will be launched. You will see
the server applications console window appear almost immediately, but it is
normal for the TestClient application to take a few seconds to appear. This
is because we're simultaneously launching two applications from one solution,
and also because there is generally a brief delay in response from a WCF
service the first time a client connects after the service starts.

================================================================================
AppDomainProtection Project

The most important code in this example is in the AppDomainProtection project.
It has been distributed this way so that you can easily re-use it with your own
WCF services.

Included in the AppDomainProtection project are:

AppDomainPoolManager        This class implments a simple pooling mechanism
                            which allows AppDomains to be re-used. This is
                            a way of optimising performance, because creating
                            an AppDomain is a relatively "expensive" operation.

BackgroundDispatcher        This class controls the processing of background
                            tasks on different threads.

IAppDomainPoolable          This interface can be implemented by classes whose
                            functionality is to be executed inside an AppDomain
                            pooling environment such as that provided by
                            AppDomainPoolManager. Implementing this interface
                            enables AppDomain pooling, and provides several
                            call-back methods that are called during the
                            lifetime of an object.

IsolatableServiceBase       This class is a base class to be used for WCF services
                            whose code is to be isolated by being loaded into
                            an AppDomain.

ServiceInstanceProvider     This class implements a custom provider that will be
                            called by WCF whenever a new instance of the WCF
                            service is required. This functionality is implemented
                            by attributing your WCF service class or interface
                            with SingletonBehaviorAttribute.

SingletonBehaviorAttribute  This class implements an attribute that can be applied
                            to a WCF service class (or interface) in order to
                            implement a custom WCF service instance provider
                            that provides AppDomain and multi-threading
                            protection for any Synergy .NET code that executes
                            within the service. The custom service instance
                            provider is implemented in the ServiceInstanceProvider
                            class.

================================================================================
PartsSystem Project

This project is a Synergy .NET Class Library that essentially contains Synergy
business logic and database access code. The code in this class library is called
by the code in the WCF service.

Most of the code in this project was code generated using CodeGen. The CodeGen
templates that were used can be found in the "Templates" solution folder, and
the CodeGen commands that were used can be found in the regen.bat batch file
in the "Solution Items" solution folder.

================================================================================
WcfServiceLibrary Project

This project is again a Synergy .NET class library. It contains classes that
"wrap" the business logic in the previous project in a WCF service.

Again, most of the code in this project was code generated using CodeGen.

================================================================================
ServiceHost Project

This project is a Synergy .NET console application that is used to host the
WCF service. To start the service make sure this project is set as the "Startup
Project" and then use Debug > Start Without Debugging" to start the service.

When you start the service you should see a console window apper, and it should
contain text similar to this:

The service is ready at http://localhost:56565

Press a key to terminate the service

================================================================================
TestClient Project

This project is a very simple Synergy .NET WPF application. It has a service
reference to the WCF service exposed by the server solution, and uses some of
the WCF services methods

================================================================================
Strong Name Signing

If you intend to host your Synergy .NET WCF services in Internet Information
Server (IIS) then all assemblies that will be loaded in IIS (in the case of
this example that would be AppDomainProtection.dll, PartsSystem.dll and
WcfServiceLibrary.dll) must be strong name signed.
