<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AccessRules.aspx.vb" Inherits="admin_AccessRules" title="Access Rules" %>
<%@ Import Namespace="System.Web.Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

<h2>Website Access Rules</h2>
<p>
	Use this page to manage access rules for your Web site. 
    Rules are applied to folders, thus providing robust folder-level
    security enforced by the ASP.NET infrastructure. Rules are
    persisted as XML in each folder's Web.config file.
    <i>Page-level security and inner-page security are not handled 
    using this tool &mdash; they are handled using specialized 
    code that is available to the Web Developers.</i>
</p>
<table width="100%">
<tr>
    <!-- Left column (treeview) -->
	<td valign="top" style="padding-right: 30px;">
		<asp:TreeView runat="server" ID="FolderTree" OnSelectedNodeChanged="FolderTree_SelectedNodeChanged">
			<RootNodeStyle ImageUrl="~/images/folder.gif" />
			<ParentNodeStyle ImageUrl="~/images/folder.gif" />
			<LeafNodeStyle ImageUrl="~/images/folder.gif" />
			<SelectedNodeStyle Font-Underline="true" ForeColor="#A21818" />
		</asp:TreeView>
	</td>
    <!-- End of left column (treeview), start of right column (detail) -->
	<td valign="top" style="padding-left: 30px; border-left: 1px solid #999;">
	    <asp:Panel runat="server" ID="SecurityInfoSection" Width="100%" Visible="false">
		<h3 runat="server" id="DetailTitle">Folder Access Rules</h3>
		<p>
		    Rules are applied in order. The first rule that matches applies, and the
		    permission in each rule overrides the permissions in all following rules. 
		    Use the Move Up and Move Down buttons to change the order of the selected 
		    rule. Rules that appear dimmed are inherited from the parent and cannot be 
		    changed at this level. 
		</p>
		<asp:GridView runat="server" ID="RulesGrid" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="RowDataBound" Width="100%">
			<Columns>
				<asp:TemplateField HeaderText="Action">
					<ItemTemplate>
						<%#GetAction(CType(Container.DataItem, AuthorizationRule))%>
					</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Roles">
					<ItemTemplate>
						<%#GetRole(CType(Container.DataItem, AuthorizationRule))%>
					</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="User">
					<ItemTemplate>
						<%#GetUser(CType(Container.DataItem, AuthorizationRule))%>
					</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Actions">
					<ItemTemplate>
						<asp:Button ID="Button1" runat="server" Text="Delete Rule" CommandArgument="<%# CType(Container.DataItem, AuthorizationRule) %>" OnClick="DeleteRule" OnClientClick="return confirm('Click OK to delete this rule.')" />
						<asp:Button ID="Button2" runat="server" Text="Move Up" CommandArgument="<%# CType(Container.DataItem, AuthorizationRule) %>" OnClick="MoveUp" />
						<asp:Button ID="Button3" runat="server" Text="Move Down" CommandArgument="<%# CType(Container.DataItem, AuthorizationRule) %>" OnClick="MoveDown" />
					</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
				</asp:TemplateField>
			</Columns>
		</asp:GridView>

		<br />
		<hr />
		<h3 runat="server" id="CreateNewTitle">Create New Access Rule</h3>
        <table border="0" width="100%">
        <tr>
            <td>
                <b>Rule type:</b>
            </td>
            <td>
		        <asp:RadioButton runat="server" ID="ActionAllow" GroupName="action" Text="Allow access" />
		        <asp:RadioButton runat="server" ID="ActionDeny" GroupName="action" Text="Deny access" Checked="true" />
            </td>
        </tr>
        <tr>
            <td>
        		<b>Rule applies to:</b>
            </td>
            <td>
		        <asp:RadioButton runat="server" ID="ApplyRole" GroupName="applyto" Text="Role:" Checked="true" />
		        <asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true">
    		        <asp:ListItem>Select Role</asp:ListItem>
		        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
		        <asp:RadioButton runat="server" ID="ApplyUser" GroupName="applyto" Text="User:" />
		        <asp:DropDownList ID="UserList" runat="server" AppendDataBoundItems="true">
    		        <asp:ListItem>Select User</asp:ListItem>
		        </asp:DropDownList>	
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
        		<asp:RadioButton runat="server" ID="ApplyAllUsers" GroupName="applyto" Text="All Users (*)"  />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
		        <asp:RadioButton runat="server" ID="ApplyAnonUser" GroupName="applyto" Text="Anonymous Users (?)"  />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
		        <asp:Button ID="Button4" runat="server" Text="Create Rule" OnClick="CreateRule" />
		        <asp:Literal runat="server" ID="RuleCreationError"></asp:Literal>
            </td>
        </tr>
        </table>
        </asp:Panel>
	</td>
    <!-- End of right column (detail) -->

</tr>
</table>
</asp:Content>

