<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReadMe.aspx.vb" Inherits="ReadMe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Multilingual Web Demo<br />
        <br />
        In web.config, add:<br />
        <br />
        &lt;system.web&gt;<br />
        &nbsp; &nbsp; &lt;globalization culture="auto" uiCulture="auto" /&gt;<globalization culture="auto" uiculture="auto"></globalization><globalization culture="auto" uiculture="auto"></globalization><globalization culture="auto" uiculture="auto"></globalization><br />
        &lt;/system.web&gt;<br />
        <br />
        Or, in each page declaration, add:<br />
        <br />
        &lt;%@ Page ... <strong>Culture="auto" UICulture="auto"</strong> %&gt;<br />
        <br />
        Create an ASP.NET special folder called App_GlobalResources<br />
        <br />
        In the App_GlobalResources folder create a resource file for the "default" language (e.g. language.resx).<br />
        <br />
        In the default language file add name value pairs for all the text strings used in web sites UI.<br />
        <br />
        In web pages, remove the static test and replace it with references to the entries in the resource file., e.g.:<br />
        <br />
        &lt;asp:Label ID="LblUsername" runat="server" Width="150" Text="<strong>&lt;%$ Resources:language,UsernamePrompt %&gt;</strong>"/&gt;<br />
        &lt;asp:Button ID="BtnLogin" runat="server" Text="<strong>&lt;%$ Resources:language,LoginButtonText %&gt;</strong>" /&gt;<br />
        <br />
        For any static text on a page, use an &lt;asp:literal&gt; control:<br />
        <br />
        &lt;h1&gt;<strong>&lt;asp:Literal ID="Literal1" runat="server" Text="&lt;%$ Resources:language,TitleText %&gt;" /&gt;</strong>&lt;/h1&gt;<br />
        &lt;p&gt;<strong>&lt;asp:Literal ID="Literal2" runat="server" Text="&lt;%$ Resources:language,WelcomeText %&gt;" /&gt;</strong>&lt;/p&gt;<br />
        <br />
        To implement alternate languages add additional resource files for each language that you wish to support.&nbsp; The file name must include the language code.&nbsp; e.g.:<br />
        <strong>
            <br />
            language.fr.resx<br />
            language.es.resx<br />
            language.it.resx</strong><br />
        <br />
        In each alternate language file, add translated versions of any of the text entries from the main language file that you wish to be translated on the web pages.<br />
        <br />
        When the browser is displaying web pages from the site the user will see text from the resource file which corresponds to their browsers default language code.&nbsp; If a language specific resource file does not contain entries for all of the text strings used by the site then the missing ones will be taken from the sites default language resource file.&nbsp; If the users browser is set to a language for which the site does not have a resource file then the default resource file will be used.<br />
    </div>
    </form>
</body>
</html>
