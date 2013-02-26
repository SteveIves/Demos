<%@ Page Language="VB" AutoEventWireup="false" CodeFile="email.aspx.vb" Inherits="email" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LblFrom" runat="server" Height="19px" Style="z-index: 100; left: 76px;
            position: absolute; top: 131px" Text="From" Width="82px"></asp:Label>
        <asp:Label ID="LblTo" runat="server" Height="19px" Style="z-index: 101; left: 76px;
            position: absolute; top: 166px" Text="To" Width="82px"></asp:Label>
        <asp:Label ID="LblSubject" runat="server" Style="z-index: 102; left: 76px; position: absolute;
            top: 202px" Text="Subject" Width="82px"></asp:Label>
        <asp:Label ID="LblBody" runat="server" Style="z-index: 103; left: 76px; position: absolute;
            top: 240px" Text="Message" Width="82px"></asp:Label>
        <asp:TextBox ID="TxtFrom" runat="server" Style="z-index: 104; left: 169px; position: absolute;
            top: 129px" Width="330px">steve@ivesworld.com</asp:TextBox>
        <asp:TextBox ID="TxtTo" runat="server" Style="z-index: 105; left: 170px; position: absolute;
            top: 166px" Width="330px">steve.ives@synergex.com</asp:TextBox>
        <asp:TextBox ID="TxtSubject" runat="server" Style="z-index: 106; left: 172px; position: absolute;
            top: 200px" Width="330px">Test message</asp:TextBox>
        <asp:TextBox ID="TxtBody" runat="server" Height="173px" Style="z-index: 107; left: 173px;
            position: absolute; top: 238px" TextMode="MultiLine" Width="329px">This is a test message, please ignore it!</asp:TextBox>
        <asp:Button ID="BtnSend" runat="server" Style="z-index: 108; left: 410px; position: absolute;
            top: 437px" Text="Send Email" />
        <asp:Label ID="LblTitle" runat="server" Font-Size="XX-Large" Style="z-index: 109;
            left: 220px; position: absolute; top: 64px" Text="Send an Email"></asp:Label>
        <asp:Label ID="ErrorDisplay" runat="server" ForeColor="Red" Height="118px" Style="z-index: 111;
            left: 173px; position: absolute; top: 478px" Width="335px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
