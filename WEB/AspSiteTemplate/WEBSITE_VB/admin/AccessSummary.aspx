<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AccessSummary.aspx.vb" Inherits="admin_AccessSummary" title="Access Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h2>Website Access Summary</h2>
<table>
<tr>
	<td valign="top" style="padding-right: 30px;">
		
		<asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DisplayRoleSummary">
    		<asp:ListItem>Select Role</asp:ListItem>
		</asp:DropDownList>
		
		&nbsp;&nbsp;&nbsp;&nbsp;<b>&mdash;&nbsp;&nbsp;OR&nbsp;&nbsp;&mdash;</b>
		&nbsp;&nbsp;&nbsp;				
		
		<asp:DropDownList ID="UserList" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DisplayUserSummary">
    		<asp:ListItem>Select User</asp:ListItem>
	    	<asp:ListItem Text="Anonymous users (?)" Value="?"></asp:ListItem>
		    <asp:ListItem Text="Authenticated users not in a role (*)" Value="*"></asp:ListItem>
		</asp:DropDownList>	
	
		<br />
		
		<asp:TreeView runat="server" ID="FolderTree"
			OnSelectedNodeChanged="FolderTree_SelectedNodeChanged"
			>
			<RootNodeStyle ImageUrl="~/images/folder.gif" />
			<ParentNodeStyle ImageUrl="~/images/folder.gif" />
			<LeafNodeStyle ImageUrl="~/images/folder.gif" />
			<SelectedNodeStyle Font-Underline="true" ForeColor="#A21818" />
		</asp:TreeView>
	</td>
</tr>
</table>
</asp:Content>

