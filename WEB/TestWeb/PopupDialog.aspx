<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.PopupDialog" CodeFile="PopupDialog.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
<meta name=vs_snapToGrid content="True">
<meta name=vs_showGrid content="True">
<title>Popup Dialog Example</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content="Visual Basic .NET 7.1" name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<script language=javascript>
<!--
function doModalDialog()
{
	var data = showModalDialog("PopupDialogChild.aspx",0,"dialogWidth:300px;dialogHeight:300px");
	if (data != null) {
		Form1.txtCustomer.value=data;
		Form1.submit
	}
}
-->
</script>
</HEAD>
<body>
<form id=Form1 method=post runat="server">
<asp:label id=lblCustomer style="Z-INDEX: 101; LEFT: 256px; POSITION: absolute; TOP: 256px" runat="server">Customer</asp:label>
<asp:textbox id=txtCustomer style="Z-INDEX: 102; LEFT: 320px; POSITION: absolute; TOP: 256px" runat="server"></asp:textbox>
<INPUT type="button" value="..." onclick="doModalDialog();" style="Z-INDEX: 103; LEFT: 480px; WIDTH: 20px; POSITION: absolute; TOP: 256px; HEIGHT: 24px"> 
<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 236px; POSITION: absolute; TOP: 188px" runat="server" Width="316px" Height="36px" Font-Size="X-Large" Font-Bold="True">Popup Dialog Example</asp:Label> 
</form>
</body>
</HTML>
