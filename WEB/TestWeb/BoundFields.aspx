<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.BoundFields" CodeFile="BoundFields.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>BoundFields</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>

    <form id="Form1" method="post" runat="server">
	<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 148px; POSITION: absolute; TOP: 120px" runat="server">Account</asp:Label>
<asp:button id="btnCancel" style="Z-INDEX: 109; LEFT: 320px; POSITION: absolute; TOP: 216px" accessKey="C" runat="server" Width="65px" Text="Cancel"></asp:button>
	<asp:label id="Label2" style="Z-INDEX: 101; LEFT: 148px; POSITION: absolute; TOP: 148px" runat="server">Company</asp:label>
	<asp:label id="Label3" style="Z-INDEX: 102; LEFT: 148px; POSITION: absolute; TOP: 180px" runat="server">Contact</asp:label>
	<asp:textbox id="txtAccount" text="<%#C.Account%>" style="Z-INDEX: 103; LEFT: 236px; POSITION: absolute; TOP: 112px" runat="server" readonly="True"></asp:textbox>
	<asp:TextBox id="txtCompany" text="<%#C.Company%>" style="Z-INDEX: 104; LEFT: 236px; POSITION: absolute; TOP: 146px" runat="server"></asp:TextBox>
	<asp:textbox id="txtContact" text="<%#C.Contact%>" style="Z-INDEX: 105; LEFT: 236px; POSITION: absolute; TOP: 180px" runat="server"></asp:textbox>
	<asp:button id="btnOK" style="Z-INDEX: 107; LEFT: 244px; POSITION: absolute; TOP: 216px" accesskey="O" runat="server" text="OK" width="65px"></asp:button>
    </form>

  </body>
</html>
