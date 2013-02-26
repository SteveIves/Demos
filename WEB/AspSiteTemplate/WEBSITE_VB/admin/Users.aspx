<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="admin_Users" title="Users" %>
<%@ Register Src="UsersNav.ascx" TagName="UsersNav" TagPrefix="uc1" %>
<%@ Register TagPrefix="dc" TagName="alphalinks" Src="alphalinks.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h2>Users By Name</h2>
<p><uc1:UsersNav ID="UsersNav1" runat="server" /></p>
<p>User Name filter:&nbsp;&nbsp;<dc:alphalinks runat="server" ID="Alphalinks" /></p>
<asp:GridView runat="server" ID="Users" AutoGenerateColumns="False" GridLines="None" Width="100%">
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
