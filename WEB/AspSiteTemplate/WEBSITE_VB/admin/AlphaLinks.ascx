<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AlphaLinks.ascx.vb" Inherits="admin_AlphaLinks" %>
<asp:Repeater runat="server" ID="__theAlphalink" OnItemDataBound="DisableSelectedLink">
<ItemTemplate>
	<asp:LinkButton runat="server" ID="link" 
		text="<%# Container.DataItem %>"
		CommandName="Filter"
		CommandArgument='<%# DataBinder.Eval(Container, "DataItem")%>'
		OnCommand="SelectLink"
		 />&nbsp;
</ItemTemplate>
</asp:Repeater>