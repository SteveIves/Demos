<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ServiceUnavailable.aspx.vb" Inherits="ServiceUnavailable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border=0>
            <tr>
                <td>Page</td>
                <td><asp:Label ID="lblPage" runat="server" /></td>
            </tr>
            <tr>
                <td>Method</td>
                <td><asp:Label ID="lblMethod" runat="server" /></td>
            </tr>
            <tr>
                <td>Exception</td>
                <td><asp:Label ID="lblException" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnContinue" runat="server" Text="Continue" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
