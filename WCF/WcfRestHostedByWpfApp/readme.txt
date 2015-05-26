
Title:          WcfRestHostedByWpfApp

Description:    An example of self-hosting a WCF REST service inside a WPF
                desktop application. Doing do would allow external applications
                to interact with the running WPF app.

Author:         Steve Ives, Synergex Professional Services Group

History:        Revision    Date             Description
                --------    -------------    ----------------------------------
                1           26th May 2015    Original example

===============================================================================

DesktopApp.synproj
------------------
This Visual Studio project contains a simple WPF desktop application. In
addition to running on the desktop, the application also hosts (on a seperate
thread) an instance of a WCF REST web service. This allows external
applications to send "messages" to the application in order to instruct that
the application to take some action.

With the application running you can view the WCF services help page at the
following URL:

http://localhost:8088/LocalAppService/help

In its default implementation the WVF service has a single operation defined.
This operation can be used to send a message to the application. A message
has two components, ID and DATA. The concept is that ID would identify the
type of messgae, and DATA would be any data that needs to accompany the
message. Both are defined as type string.

In order to send a message to the application you must issue an HTTP POST
to the services base URL, specifying the ID as part of the route specified
in the URL, for example to send a message with an ID of TEST:

http://localhost:8088/LocalAppService/messages/TEST

And the data to accompany the message would be specified in the body of the
HTTP POST request. For example:

"This data is sent with the TEST message"

The sample application is configured to respond to four messages:

ID		DATA    Action caused in desktop app
------  ------  ----------------------------
COLOR   RED     Changes the background color to red.
COLOR   WHITE   Changes the background color to white.
COLOR	BLUE    Changes the background color to blue.
EXIT	        Causes the desktop application to close.

DesktopApp.csproj
------------------
A C# version of the WPF desktop application

ClientApp.synproj
--------------
This project conains a console application that implements a simple client to
the WCF REST service that is hosted by the WPF desktop application. The code
in this project is compatible with traditional Synergy and could be executed
on Unix, Linux, OpenVMS or Windows.

HTTP Namespace Permissions
--------------------------
To be able to self-host a WCF service withinin a .NET application without the
process requiring administrator permissions it is necessary to reserve a
portion of the HTTP namespace that the service will use. This is done by
issuing NETSH commands.

Add reservation:
    NETSH HTTP ADD URLACL URL=http://+:8088/LocalAppService user=DOMAIN\user

View reservation:
    NETSH HTTP SHOW URLACL URL=http://+:8088/LocalAppService/

Delete a reservation:
    NETSH HTTP DELETE URLACL URL=http://+:8088/LocalAppService/

Including the trailing / for the SHOW and DELETE commands is required even if
the trailing / was not included on the ADD statement.

If a reservation is not made you must start Visual Studio "As Administrator" in
order to run the application that hosts the service. Failing to do so will
result in an AddressAccessDeniedException exception (HTTP could not register
URL XXXXXX. Your process does not have access rights to this namespace) being
thrown when you call the Open() method of your ServiceHost object.

More information at https://msdn.microsoft.com/en-us/library/ms733768.aspx


Running the WPF App in Visual Studio
------------------------------------
To host the WCF service in Visual Studio you must prevent WebFaultException
from being reported as "unprocessed by user code" by the debugger. To do this
use the DEBUG > Exceptions dialog and under Common Language Runtime Exceptions
you need to uncheck the "User-unhandled" checkbox that is displayed next to 
System.ServiceModel.Web.WebFaultException.

If you can't find the exception listed in the dialog then you will need to use
the Add... button to add the exception (using its full path name) under Common
Language Runtime Exceptions.


