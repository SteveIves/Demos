<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.BoundDataGrid" trace="False" CodeFile="BoundDataGrid.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Bound DataGrid Example</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgcolor="#99ccff">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 102; LEFT: 44px; POSITION: absolute; TOP: 24px" runat="server"
				height="40px" width="368px" font-size="X-Large" font-names="Arial" font-bold="True">Customer Maintenance</asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 80px" runat="server"
				width="844px" height="84px" font-names="Arial" font-size="Small" allowsorting="True" cellpadding="2"
				backcolor="White" borderwidth="1px" borderstyle="None" bordercolor="#3366CC" autogeneratecolumns="False">
				<selecteditemstyle font-bold="True" forecolor="#CCFF99" backcolor="#009999"></selecteditemstyle>
				<edititemstyle backcolor="#FFFFCC"></edititemstyle>
				<itemstyle font-size="X-Small" forecolor="#003399" backcolor="White"></itemstyle>
				<headerstyle font-size="Small" font-names="Arial" font-bold="True" forecolor="#CCCCFF" backcolor="#003399"></headerstyle>
				<footerstyle font-size="Large" font-names="Arial" forecolor="#003399" backcolor="#99CCCC"></footerstyle>
				<columns>
					<asp:BoundColumn DataField="Account" ReadOnly="True" HeaderText="Account #">
						<headerstyle width="15%"></headerstyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Company" HeaderText="Company Name">
						<headerstyle width="30%"></headerstyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Contact" HeaderText="Contact Name">
						<headerstyle width="30%"></headerstyle>
					</asp:BoundColumn>
					<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" HeaderText="Maintain" CancelText="Cancel"
						EditText="Edit">
						<headerstyle width="17ex"></headerstyle>
					</asp:EditCommandColumn>
					<asp:ButtonColumn Text="Delete" ButtonType="PushButton" HeaderText="Delete" CommandName="Delete">
						<headerstyle width="8%"></headerstyle>
					</asp:ButtonColumn>
					<asp:ButtonColumn Text="Test" ButtonType="PushButton" HeaderText="Test" CommandName="Test"></asp:ButtonColumn>
				</columns>
				<pagerstyle nextpagetext="Next Page&amp;gt;" font-size="Larger" font-names="Arial" prevpagetext="&amp;lt;Prevoius Page"
					horizontalalign="Left" forecolor="#003399" backcolor="#99CCCC" mode="NumericPages"></pagerstyle>
			</asp:datagrid>
		</form>
	</body>
</HTML>
