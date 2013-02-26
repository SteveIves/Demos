<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.SendMail" CodeFile="SendMail.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>SendMail</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>

    <form id="Form1" method="post" runat="server">
<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 504px; POSITION: absolute; TOP: 356px" runat="server" Text="Button" Width="96px" Height="36px"></asp:Button>
<asp:TextBox id="mailserver" style="Z-INDEX: 111; LEFT: 180px; POSITION: absolute; TOP: 40px" runat="server" Width="384px">smtp.westerncarriers.com</asp:TextBox>
<asp:Label id="Label5" style="Z-INDEX: 110; LEFT: 120px; POSITION: absolute; TOP: 44px" runat="server">Server</asp:Label>
<asp:TextBox id="message" style="Z-INDEX: 109; LEFT: 180px; POSITION: absolute; TOP: 168px" runat="server" Width="388px" Height="152px" textmode="MultiLine">Test body</asp:TextBox>
<asp:TextBox id="subject" style="Z-INDEX: 108; LEFT: 180px; POSITION: absolute; TOP: 136px" runat="server" Width="388px">Test message</asp:TextBox>
<asp:TextBox id="toaddress" style="Z-INDEX: 107; LEFT: 180px; POSITION: absolute; TOP: 104px" runat="server" Width="388px">steve.ives@synergex.com</asp:TextBox>
<asp:TextBox id="fromaddress" style="Z-INDEX: 106; LEFT: 180px; POSITION: absolute; TOP: 72px" runat="server" Width="384px">test@westerncarriers.com</asp:TextBox>
<asp:Label id="Label4" style="Z-INDEX: 105; LEFT: 120px; POSITION: absolute; TOP: 168px" runat="server">Message</asp:Label>
<asp:Label id="Label3" style="Z-INDEX: 104; LEFT: 120px; POSITION: absolute; TOP: 140px" runat="server">Subject</asp:Label>
<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 120px; POSITION: absolute; TOP: 108px" runat="server">To</asp:Label>
<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 120px; POSITION: absolute; TOP: 76px" runat="server">From</asp:Label>
<asp:ListBox id="log" style="Z-INDEX: 112; LEFT: 184px; POSITION: absolute; TOP: 336px" runat="server" Width="268px" Height="68px"></asp:ListBox>

    </form>

  </body>
</html>
