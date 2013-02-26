<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MultiView.aspx.vb" Inherits="MultiView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 100; left: 0px; width: 100%; position: static; top: 0px; height: 50px">
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Style="z-index: 100; left: 21px;
                position: absolute; top: 22px" Text="MultiView And View Controls"></asp:Label>
            <asp:Button ID="BtnNext" runat="server" Style="z-index: 102; left: 627px; position: absolute;
                top: 29px" Text="Next View" />
        </div>
    
    </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                This is view 1</asp:View>
            <asp:View ID="View2" runat="server">
                This is view 2</asp:View>
            <asp:View ID="View3" runat="server">
                This is view 3</asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
