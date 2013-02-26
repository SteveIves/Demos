<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.PopupDialogChild" CodeFile="PopupDialogChild.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Customer Lookup</title>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<SCRIPT LANGUAGE="JavaScript">
<!--
function returnData(retVal) {
	window.returnValue = retVal;
	window.close();
}
-->
</SCRIPT>
</HEAD>
<body>
<h3><font face="Arial, Helvetica, sans-serif">Select Customer Account ...</font></h3>
<FORM NAME="DrillData">
<INPUT TYPE="RADIO" NAME="data" VALUE="ABC001" ONCLICK="returnData('ABC001');">ABC Dynamics<BR>
<INPUT TYPE="RADIO" NAME="data" VALUE="BOB001" ONCLICK="returnData('BOB001');">Bobs Tyre Mart<BR>
<INPUT TYPE="RADIO" NAME="data" VALUE="FID001" ONCLICK="returnData('FID001');">Fido Pet Foods<BR>
<INPUT TYPE="RADIO" NAME="data" VALUE="FOU001" ONCLICK="returnData('FOU001');">Fountain of Knowledge<BR>
<INPUT TYPE="RADIO" NAME="data" VALUE="HOT001" ONCLICK="returnData('HOT001');">Hot Tubs Are Us<BR>
</FORM>
<form id="Form1" method="post" runat="server">
</form>
</body>
</HTML>
