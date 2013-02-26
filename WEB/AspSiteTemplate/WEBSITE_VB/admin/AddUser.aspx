<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AddUser.aspx.vb" Inherits="admin_AddUser" title="Add User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<table border="0" width="100%" cellspacing="10">
<!--Page heading-->
<tr>
    <td colspan="2">
        <h2>Create a User Account</h2>
    </td>
</tr>
<tr>
    <!--Left column - user details-->
    <td valign="top">
        <h3>User Details</h3>
        <table cellspacing="5">
        <tr>
	        <td>Approvd for login</td>
	        <td><asp:CheckBox ID="ChkIsApproved" runat="server" Checked="true" /></td>
	        <td>&nbsp;</td>
        </tr>
        <tr>
	        <td>User Name</td>
	        <td><asp:TextBox ID="TxtUsername" runat="server" /></td>
	        <td><asp:RequiredFieldValidator ID="ValidateUsername" runat="server" ControlToValidate="TxtUsername" ErrorMessage="Username is required" /></td>
        </tr>
        <tr>
	        <td>Password</td>
	        <td><asp:TextBox ID="TxtPassword" runat="server" /></td>
	        <td><asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ControlToValidate="TxtPassword" ErrorMessage="Password is required" /></td>
        </tr>
        <tr>
	        <td>Email</td>
	        <td><asp:TextBox ID="TxtEmail" runat="server" /></td>
	        <td><asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Valid email address is required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
	        <td>Comment</td>
	        <td><asp:TextBox ID="TxtComment" runat="server" /></td>
	        <td>&nbsp;</td>
        </tr>
        <tr>
	        <td colspan="3">
	            <br />
	            <asp:Button ID="BtnAddUser" runat="server" Text="Add User" />
	            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CausesValidation="false" />
	        </td>
        </tr>
        <tr>
	        <td colspan="3">
	            <asp:Label ID="Message" runat="server" />
	        </td>
        </tr>
        </table>
    </td>
    <!--Right column - roles-->
    <td valign="top">
        <h3>Roles For User</h3>
        <asp:CheckBoxList ID="UserRoles" runat="server" />
    </td>
</tr>
</table>
<asp:ObjectDataSource ID="MemberData" runat="server" DataObjectTypeName="System.Web.Security.MembershipUser" SelectMethod="GetUser" UpdateMethod="UpdateUser" TypeName="System.Web.Security.Membership">
	<SelectParameters>
		<asp:QueryStringParameter Name="username" QueryStringField="username" />
	</SelectParameters>
</asp:ObjectDataSource> 
</asp:Content>