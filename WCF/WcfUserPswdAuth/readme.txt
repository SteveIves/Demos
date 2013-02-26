
WCF Services with Username / Password Authentication
====================================================

Author:			Steve Ives (Synergex Professional Services Group)

Date:			13th March 2012

Platform:		Synergy .NET

Requires:		Visual Studio 2010 with Synergy Language Integration 9.5.3
				or higher.

Description:	Demonstrates a technique for implementing WCF services which
				are protected by custom username / password authentication.

				The WCFService project exposes a WCF service which is secured
				by a custom username / password validator.

				The WebHost project hosts the service in an ASP.NET web
				application. Review the Web.Config file for important service
				configuration settings.

				The ClientApp project is a sample test client for the
				username / password secured service. Refer to the App.Config
				file for important client configuration settings.

				In order to use this demonstration it is necessary to generate
				a certificate file and register that certificate in your
				windows certificate store. You can do this by executing the
				setup.bat procedure. iy can remove uninstall and delete the
				certificate by executing the cleanup.bat procedure.