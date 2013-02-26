<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Roles.aspx.vb" Inherits="admin_Roles" title="Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h3>Manage Roles</h3>
 New Role: <asp:TextBox runat="server" ID="NewRole"></asp:TextBox>
 <asp:Button ID="BtnAddRole" runat="server" Text="Add Role" />
<p>
    <asp:Label id="ConfirmationMessage" runat="server" CssClass="ErrorText" />
</p>
<asp:GridView runat="server" ID="UserRoles" AutoGenerateColumns="False" GridLines="None" Width="387px">
	<Columns>
		<asp:TemplateField>
			<HeaderTemplate>Role Name</HeaderTemplate>
			<ItemTemplate>
				<%# Eval("Role Name") %>
			</ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>User Count</HeaderTemplate>
			<ItemTemplate>
				<%# Eval("User Count") %>
			</ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>Delete Role</HeaderTemplate>
			<ItemTemplate>
				<asp:Button ID="Button1" runat="server" OnCommand="DeleteRole" CommandName="DeleteRole" CommandArgument='<%# Eval("Role Name") %>' Text="Delete" OnClientClick="return confirm('Are you sure?')" />
			</ItemTemplate>
            <HeaderStyle HorizontalAlign="Right" />
            <ItemStyle HorizontalAlign="Right" />
		</asp:TemplateField>
	</Columns>
</asp:GridView>
</asp:Content>