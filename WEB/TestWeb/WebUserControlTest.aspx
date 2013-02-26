<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.WebUserControlTest" CodeFile="WebUserControlTest.aspx.vb" %>
<%@ Register TagPrefix="UserControls" TagName="Navigator" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
<title>WebUserControlTest</title>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
<body>
<form id="Form1" method="post" runat="server">
<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 492px; POSITION: absolute; TOP: 60px" runat="server" Width="28px" Height="16px">
<usercontrols:navigator id="nav1" runat="server"></usercontrols:navigator></asp:Panel>
</form>
</body>
</html>
