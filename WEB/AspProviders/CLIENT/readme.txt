
Example code from web.config for configuring the Synergy membership provider:

	<system.web>
		<compilation debug="true">
			<assemblies>
				<add assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
				<add assembly="SynergyAspProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=F1B4F3A2EB361AFF"/>
				<add assembly="xfnlnet, Version=1.0.11.0, Culture=neutral, PublicKeyToken=114C5DBB1312A8BC"/>
			</assemblies>
		</compilation>
		<membership defaultProvider="SynergyMembershipProvider" userIsOnlineTimeWindow="10">
			<providers>
				<clear/>
				<add name="SynergyMembershipProvider" type="SynPSG.ASP.SynergyMembershipProvider" description="Synergy ASP.NET Membersip Provider" applicationName="TemplateSite" MaxInvalidPasswordAttempts="5" PasswordAttemptWindow="10" minRequiredAlphaNumericCharacters="1" minRequiredPasswordLength="7" passwordStrengthRegularExpression="" EnablePasswordReset="true" EnablePasswordRetrieval="true" RequiresQuestionAndAnswer="true" RequiresUniqueEmail="false" WriteExceptionsToEventLog="true" PasswordFormat="Clear"/>
			</providers>
		</membership>
		<roleManager enabled="true" defaultProvider="SynergyRoleProvider">
			<providers>
				<clear/>
				<add name="SynergyRoleProvider" type="SynPSG.ASP.SynergyRoleProvider" description="Synergy ASP.NET Role Provider" applicationName="TemplateSite" writeExceptionsToEventLog="true"/>
			</providers>
		</roleManager>
		<!--
	    <profile defaultProvider="SynergyProfileProvider">
			<providers>
				<clear/>
				<add name="SynergyProfileProvider" 
            type="SynPSG.ASP.SynergyProfileProvider" 
            description="Synergy ASP.NET Profile Provider" 
            applicationName="TemplateSite"/>
			</providers>
			<properties>
				<add name="FirstName" defaultValue=""/>
				<add name="LastName" defaultValue=""/>
			</properties>
		</profile>
		-->
		<profile>
			<properties>
				<add name="FirstName" defaultValue=""/>
				<add name="LastName" defaultValue=""/>
			</properties>
		</profile>
		<authentication mode="Forms"/>
		<pages>
			<!--these references are used by the authorization admin system-->
			<namespaces>
				<add namespace="System.Data"/>
				<add namespace="System.IO"/>
			</namespaces>
		</pages>
		<siteMap defaultProvider="foo" enabled="true">
			<providers>
				<add name="foo" siteMapFile="Web.sitemap" type="System.Web.XmlSiteMapProvider" securityTrimmingEnabled="true"/>
			</providers>
		</siteMap>
		<!--
            The <customErrors> section enables configuration 
            of what to do if/when an unhandled error occurs 
            during the execution of a request. Specifically, 
            it enables developers to configure html error pages 
            to be displayed in place of a error stack trace.

        <customErrors mode="RemoteOnly" defaultRedirect="GenericErrorPage.htm">
            <error statusCode="403" redirect="NoAccess.htm" />
            <error statusCode="404" redirect="FileNotFound.htm" />
        </customErrors>
        -->
	</system.web>


