<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <table border="0" width="780" height="100%" align="center" class="PageBackground">
    <tr>
    <td valign="top">
    <form id="form1" runat="server">
    <div>
    <h1>Multilingual Web Demo</h1>
    <p>This web site demonstrates the ability to present information to users in a variety of languages.&nbsp;
    The information that you see below the line will be customized based on the default language selected in the 
    users web browser settings. The demonstration provides support for five languages, English (en-US), French (fr-FR), 
    Spanish (es-ES), German (de-DE) and Italian (it-IT). To see an alternate language simply set your browser to one of 
    these languages and refresh the page. If you set your browser to some other language then the content will 
    be displayed in the sites default language, which in this case is set to US English (en-US).</p>
    <p>CurrentCulture is: <%=System.Globalization.CultureInfo.CurrentCulture.Name%> CurrentUICulture is: <%=System.Globalization.CultureInfo.CurrentUICulture.Name%></p>
    <p>
        Current language
        <asp:DropDownList ID="LstLanguage" runat="server" AutoPostBack="true">
            <asp:ListItem Value="en-US">English</asp:ListItem>
            <asp:ListItem Value="fr-FR">French</asp:ListItem>
            <asp:ListItem Value="es-ES">Spanish</asp:ListItem>
            <asp:ListItem Value="de-DE">German</asp:ListItem>
            <asp:ListItem Value="it-IT">Italian</asp:ListItem>
        </asp:DropDownList>
        </p>
    <hr />
    <h2><asp:Literal ID="HeaderText" runat="server" Text="<%$ Resources:language,TitleText %>" />&nbsp;</h2>
    <p><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language,WelcomeText %>" /></p>
    <p><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:language,EnglishText %>" /></p>
    <table border="0" align="center">
    <tr>
        <td><asp:Label ID="LblUsername" runat="server" Text="<%$ Resources:language,UsernamePrompt %>"/></td>
        <td><asp:TextBox ID="TxtUsername" runat="server" Width="150px"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="ValUsername" runat="server" ControlToValidate="TxtUsername" ErrorMessage="<%$ Resources:language,UsernameRequired %>"></asp:RequiredFieldValidator><br /></td>
    </tr>
    <tr>
        <td><asp:Label ID="LblPassword" runat="server" Text="<%$ Resources:language,PasswordPrompt %>"/></td>
        <td><asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="ValPassword" runat="server" ControlToValidate="TxtPassword" ErrorMessage="<%$ Resources:language,PasswordRequired %>"></asp:RequiredFieldValidator><br /></td>
    </tr>
    <tr>
        <td></td>
        <td align="right"><asp:Button ID="BtnLogin" runat="server" Text="<%$ Resources:language,LoginButtonText %>" /></td>
        <td></td>
    </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="484px" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="Field1" HeaderText="<%$ Resources:language,GridHeader1 %>" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Field2" HeaderText="<%$ Resources:language,GridHeader2 %>" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Field3" HeaderText="<%$ Resources:language,GridHeader3 %>" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>    
    </div>
    </form>
    </td>
    </tr>
    </table>
</body>
</html>
