<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UsersByRole.aspx.vb" Inherits="admin_UsersByRole" title="Users By Role" %>
<%@ Register Src="UsersNav.ascx" TagName="UsersNav" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h2>Users by Role</h2>
<p><uc1:UsersNav ID="UsersNav1" runat="server" /></p>
<p>Role filter: 
<asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
<asp:ListItem>Show All</asp:ListItem>
</asp:DropDownList>
</p>
<asp:GridView runat="server" ID="Users" AutoGenerateColumns="false" GridLines="none" AllowSorting="true" Width="100%">
<Columns>
	<asp:TemplateField>
		<HeaderTemplate>Username</HeaderTemplate>
		<ItemTemplate>
		<a href="EditUser.aspx?username=<%# Eval("UserName") %>"><%# Eval("UserName") %></a>
		</ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
	</asp:TemplateField>
	<asp:BoundField DataField="email" HeaderText="Email" >
        <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
	<asp:BoundField DataField="isapproved" HeaderText="Active" >
        <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
	<asp:BoundField DataField="isonline" HeaderText="Online" >
        <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
	<asp:BoundField DataField="islockedout" HeaderText="Locked" >
        <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
	<asp:BoundField DataField="lastactivitydate" HeaderText="Last Activity" >
        <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
</Columns>
</asp:GridView>
</asp:Content>
