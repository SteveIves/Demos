<%@ Page Language="VB" MasterPageFile="~/LoggedInMaster.master" AutoEventWireup="false" CodeFile="OrderBrowser.aspx.vb" Inherits="OrderBrowser" title="Untitled Page" %>
<%@ Register tagprefix="igsch" namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics35.WebUI.WebDateChooser.v8.3, Version=8.3.20083.1009, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" Runat="Server">
</asp:content>
<asp:content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
	<table border="0">
	<tr>
		<td><asp:label id="lblFromDate" runat="server" text="From Date" /></td>
		<td><igsch:webdatechooser id="datFromDate" runat="server" nulldatelabel="Earliest order" nullvaluerepresentation="Null" /></td>
		<td><asp:label id="lblToDate" runat="server" text="To Date" /></td>
		<td><igsch:webdatechooser id="datToDate" runat="server" nulldatelabel="Latest Order" nullvaluerepresentation="Null" /></td>
		<td><asp:button id="btnSearch" runat="server" text="Search" /></td>
	</tr>
	</table>
	<asp:gridview id="grdOrders" runat="server" cellpadding="4" forecolor="#333333" 
		gridlines="None" width="888px" autogeneratecolumns="False">
		<footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
		<rowstyle backcolor="#F7F6F3" forecolor="#333333" />
		<columns>
			<asp:hyperlinkfield datanavigateurlfields="Order" 
				datanavigateurlformatstring="ViewOrder.aspx?order={0}" datatextfield="Order" 
				headertext="Order #">
				<headerstyle horizontalalign="Left" />
				<itemstyle horizontalalign="Left" />
			</asp:hyperlinkfield>
			<asp:boundfield datafield="Order" headertext="Order #">
				<headerstyle horizontalalign="Left" />
				<itemstyle horizontalalign="Left" />
			</asp:boundfield>
			<asp:boundfield datafield="Order_date" headertext="Date" 
				dataformatstring="{0:d}">
				<headerstyle horizontalalign="Left" />
				<itemstyle horizontalalign="Left" />
			</asp:boundfield>
			<asp:boundfield datafield="Goods_value" headertext="Goods">
				<headerstyle horizontalalign="Right" />
				<itemstyle horizontalalign="Right" />
			</asp:boundfield>
			<asp:boundfield datafield="Tax_value" headertext="Tax">
				<headerstyle horizontalalign="Right" />
				<itemstyle horizontalalign="Right" />
			</asp:boundfield>
			<asp:boundfield datafield="Shipping_value" headertext="Shipping">
				<headerstyle horizontalalign="Right" />
				<itemstyle horizontalalign="Right" />
			</asp:boundfield>
		</columns>
		<pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
		<selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
		<headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
		<editrowstyle backcolor="#999999" />
		<alternatingrowstyle backcolor="White" forecolor="#284775" />
	</asp:gridview>
</asp:content>

