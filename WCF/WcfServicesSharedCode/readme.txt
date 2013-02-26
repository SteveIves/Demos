

WCF Services with Shared Code
=============================

Author:			Steve Ives (Synergex Professional Services Group)

Date:			13th March 2012

Platform:		Synergy .NET

Requires:		Visual Studio 2010 with Synergy Language Integration 9.5.3
				or higher.

Description:	Demonstrates a technique for implementing multiple service
				contracts within a single WCF service, where some method
				implementations are shared between multiple contracts.

				In the WcfLibrary project two Interfaces (and service
				contracts are defined in the ICalculatorService.dbl file.
				These contracts are ISimpleCalculator and IComplexCalculator.

				ISimpleCalculator has two methods, named "Add" and "Subtract".

				IComplexCalculator has four methods, named "Add", "Subtract",
				"Multiply" and "Divide".

				When a WCF service exposes multiple service contracts, it is
				a requirement that method names are not duplicated across those
				contracts. However, you can use the "Name" property of the
				OperationContract attribute to change a methods external name,
				thus resolving any such conflict.

				While this approach may not be perfrct, in that you might want
				to have the same name in multiple service contracts, it does
				at least allow you to implement the functionality without
				duplicating server-side code.