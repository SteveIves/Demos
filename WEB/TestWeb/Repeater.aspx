<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.Repeater" CodeFile="Repeater.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
<title>Repeater</title>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
<body>
<form id=Form1 method=post runat="server">
<asp:label id="Label1" style="Z-INDEX: 102; LEFT: 72px; POSITION: absolute; TOP: 20px" runat="server" font-bold="True" height="40px" width="240px" font-size="X-Large" font-names="Arial">Customer List</asp:label>&nbsp;

<asp:panel id="Panel1" style="Z-INDEX: 101; LEFT: 68px; POSITION: absolute; TOP: 72px" runat="server" Width="348px" Height="144px">
<asp:repeater id="Repeater1" runat="server">
<headertemplate>
<table border="1" width="400">
<tr>
	<td><b>Account</b></td>
	<td><b>Company</b></td>
	<td><b>Contact</b></td>
</tr>
</HeaderTemplate>
<itemtemplate>
<tr>
	<td><%# DataBinder.Eval(Container.DataItem,"Account")%></td>
	<td><a href="customer.aspx?account=<%# DataBinder.Eval(Container.DataItem,"Account")%>"><%# DataBinder.Eval(Container.DataItem,"Company")%></a></td>
	<td><%# DataBinder.Eval(Container.DataItem,"Contact") %></td>
</tr>
</ItemTemplate>
<footertemplate>
</table>
</FooterTemplate>
</asp:repeater>
</asp:panel>

</form>
</body>
</html>
