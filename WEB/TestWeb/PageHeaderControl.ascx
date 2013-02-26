<%@ Control Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.PageHeaderControl" CodeFile="PageHeaderControl.ascx.vb" %>
<div id="HeaderArea" style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-SIZE: 8pt; PADDING-BOTTOM: 0px; MARGIN: 0px; WIDTH: 780px; COLOR: navy; PADDING-TOP: 0px; FONT-FAMILY: Arial; POSITION: relative; HEIGHT: 89px; BACKGROUND-COLOR: #9999ff" runat="server">
<div id="TitleArea"  style="DISPLAY: inline; FONT-SIZE: 18pt; Z-INDEX: 101; LEFT: 8px; WIDTH: 376px; POSITION: absolute; TOP: 8px; HEIGHT: 32px"><%=PageTitle%></div>
<asp:Image id="Image1" style="Z-INDEX: 102; LEFT: 616px; POSITION: absolute; TOP: 12px" runat="server" Width="48px" Height="48px"></asp:Image>
</div>
