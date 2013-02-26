<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.RadioButtons" CodeFile="RadioButtons.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>RadioButtons</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:RadioButton id="RadioButton1" style="Z-INDEX: 100; LEFT: 20px; POSITION: absolute; TOP: 100px"
				runat="server" GroupName="Group1" Text="Red"></asp:RadioButton>
			<asp:Label id="Label2" style="Z-INDEX: 111; LEFT: 20px; POSITION: absolute; TOP: 248px" runat="server"
				Width="660px" Height="44px">Setting the AutoPostback property on the controls causes postback to occur immediately when a radio button is clicked.</asp:Label>
			<asp:Label id="Results2" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 360px"
				runat="server" Width="160px"></asp:Label>
			<asp:RadioButton id="RadioButton6" style="Z-INDEX: 107; LEFT: 20px; POSITION: absolute; TOP: 312px"
				runat="server" GroupName="Group2" Text="Red" AutoPostBack="True"></asp:RadioButton>
			<asp:RadioButton id="RadioButton5" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 336px"
				runat="server" GroupName="Group2" Text="Green" AutoPostBack="True"></asp:RadioButton>
			<asp:RadioButton id="RadioButton4" style="Z-INDEX: 103; LEFT: 20px; POSITION: absolute; TOP: 360px"
				runat="server" GroupName="Group2" Text="Blue" Checked="True" AutoPostBack="True"></asp:RadioButton>
			<asp:RadioButton id="RadioButton2" style="Z-INDEX: 102; LEFT: 20px; POSITION: absolute; TOP: 124px"
				runat="server" GroupName="Group1" Text="Green" Checked="True"></asp:RadioButton>
			<asp:RadioButton id="RadioButton3" style="Z-INDEX: 104; LEFT: 20px; POSITION: absolute; TOP: 148px"
				runat="server" GroupName="Group1" Text="Blue"></asp:RadioButton>
			<asp:Button id="BtnSubmit" style="Z-INDEX: 105; LEFT: 148px; POSITION: absolute; TOP: 104px"
				runat="server" Text="Submit"></asp:Button>
			<asp:Label id="Results" style="Z-INDEX: 106; LEFT: 152px; POSITION: absolute; TOP: 148px" runat="server"
				Width="156px"></asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 110; LEFT: 20px; POSITION: absolute; TOP: 20px" runat="server"
				Width="660px" Height="64px">Radio buttons are grouped together by assigning a common GroupName property. The  initial value of one of the grouped radio buttons is set with the Checked  propertyBy default, RadioButton controls do NOT cause immediate postback.</asp:Label>
		</form>
	</body>
</HTML>
