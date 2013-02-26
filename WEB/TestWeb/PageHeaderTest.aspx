<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.PageHeaderTest" CodeFile="PageHeaderTest.aspx.vb" %>
<%@ Register TagPrefix="User" TagName="Header" Src="PageHeaderControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>PageHeaderTest</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
	<User:Header id="headerarea" runat="server" PageTitle="Header Test Page"></User:Header>
    <form id="Form1" method="post" runat="server">

    </form>
  </body>
</html>
