<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.Calendar" CodeFile="Calendar.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>Calendar</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
<asp:Calendar id="Calendar1" style="Z-INDEX: 101; LEFT: 160px; POSITION: absolute; TOP: 92px" runat="server" borderwidth="8px" backcolor="White" width="252px" forecolor="#003399" height="204px" font-size="8pt" font-names="Verdana" bordercolor="#3366CC" cellpadding="1" font-bold="True" borderstyle="Outset" nextprevformat="ShortMonth" showgridlines="True">
<todaydaystyle forecolor="White" backcolor="#99CCCC">
</TodayDayStyle>

<selectorstyle forecolor="#336666" backcolor="#99CCCC">
</SelectorStyle>

<nextprevstyle font-size="8pt" forecolor="#CCCCFF">
</NextPrevStyle>

<dayheaderstyle height="1px" forecolor="#336666" backcolor="#99CCCC">
</DayHeaderStyle>

<selecteddaystyle font-bold="True" forecolor="#CCFF99" backcolor="#009999">
</SelectedDayStyle>

<titlestyle font-size="10pt" font-bold="True" height="25px" borderwidth="1px" forecolor="#CCCCFF" borderstyle="Solid" bordercolor="#3366CC" backcolor="#003399">
</TitleStyle>

<weekenddaystyle backcolor="#CCCCFF">
</WeekendDayStyle>

<othermonthdaystyle forecolor="#999999">
</OtherMonthDayStyle></asp:Calendar>
<asp:TextBox id="txtD6Date" style="Z-INDEX: 108; LEFT: 584px; POSITION: absolute; TOP: 224px" runat="server" Width="76px"></asp:TextBox>
<asp:Label id="Label3" style="Z-INDEX: 107; LEFT: 444px; POSITION: absolute; TOP: 228px" runat="server">Reverse D6 date</asp:Label>
<asp:TextBox id="TextBox1" style="Z-INDEX: 103; LEFT: 584px; POSITION: absolute; TOP: 180px" runat="server" Width="76px"></asp:TextBox>
<asp:TextBox id="txtD8Date" style="Z-INDEX: 104; LEFT: 584px; POSITION: absolute; TOP: 180px" runat="server" Width="76px"></asp:TextBox>
<asp:TextBox id="txtDate" style="Z-INDEX: 102; LEFT: 584px; POSITION: absolute; TOP: 140px" runat="server" width="76px"></asp:TextBox>
<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 444px; POSITION: absolute; TOP: 144px" runat="server">Formatted short date</asp:Label>
<asp:Label id="Label2" style="Z-INDEX: 106; LEFT: 444px; POSITION: absolute; TOP: 184px" runat="server">Reverse D8 date</asp:Label>
<asp:Button id="btnToday" style="Z-INDEX: 109; LEFT: 308px; POSITION: absolute; TOP: 312px" accessKey="T" runat="server" Text="Today"></asp:Button>
<asp:ListBox id="yearList" style="Z-INDEX: 110; LEFT: 196px; POSITION: absolute; TOP: 312px" accessKey="Y" runat="server" Height="24px" AutoPostBack="True"></asp:ListBox>

    </form>

  </body>
</html>
