WcfRestDynamicResponse
======================

The classes in this assembly can be used to implement WCF REST services which are
capable of accepting and returning data in either XML or JSON format between the client
and service, but without duplicating code in the service.

To use:

1. Add a reference to this assembly in the project where your WCF REST services
   are defined.

2. Add the {DynamicResponseType} attribute to all of your services operation methods


The code in this example is based on a conversion of an example originally written in
C# by Damian Mehers, which is discussed at http://damianblog.com/?s=wcf+dynamic+response.


