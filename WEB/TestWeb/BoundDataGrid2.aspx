<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.BoundDataGrid2" CodeFile="BoundDataGrid2.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BoundDataGrid2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 36px; POSITION: absolute; TOP: 88px" runat="server"
				allowsorting="True" cellpadding="2" backcolor="White" borderwidth="1px" borderstyle="None"
				bordercolor="#3366CC" autogeneratecolumns="False" PageSize="15" AllowPaging="True" height="84px"
				width="692px" font-size="Small" font-names="Arial">
				<FooterStyle Font-Size="Large" Font-Names="Arial" ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<EditItemStyle BackColor="#FFFFCC"></EditItemStyle>
				<ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Names="Arial" Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="Account" ReadOnly="True" HeaderText="Account #">
						<HeaderStyle Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Company" HeaderText="Company Name">
						<HeaderStyle Width="40%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Contact" HeaderText="Contact Name">
						<HeaderStyle Width="40%"></HeaderStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="Next Page&amp;gt;" Font-Names="Arial" PrevPageText="&amp;lt;Prevoius Page"
					HorizontalAlign="Center" ForeColor="#CCCCFF" BackColor="#003399" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:label id="Label1" style="Z-INDEX: 102; LEFT: 36px; POSITION: absolute; TOP: 36px" runat="server"
				height="40px" width="240px" font-size="X-Large" font-names="Arial" font-bold="True">Customer List</asp:label>
			<asp:Panel id="Panel1" style="Z-INDEX: 103; LEFT: 36px; POSITION: absolute; TOP: 468px" runat="server"
				Width="692px" Height="44px">This demonstration uses a DataGrid 
control which is bound to a DataTable.&nbsp; The DataTable has been dynamically 
created and loaded from an array of objects, simulating an array of Structures 
from a Synergy call.</asp:Panel></FORM>
	</body>
</HTML>
