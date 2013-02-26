<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EditUser.aspx.vb" Inherits="admin_EditUser" title="Edit User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<table border="0" width="100%" cellspacing="10">
<!--Page heading-->
<tr><td colspan="2"><h2>View / Edit User Account</h2></td></tr>
<tr>
    <!--Left column - User details-->
    <td valign="top">
        <h3>User Details</h3>
        <asp:DetailsView AutoGenerateRows="False" DataSourceID="MemberData" ID="UserInfo" runat="server" OnItemUpdating="UserInfo_ItemUpdating" Width="407px" CellSpacing="5" GridLines="None">
        <Fields>
	        <asp:BoundField DataField="UserName" HeaderText="Username" ReadOnly="True" />
	        <asp:BoundField DataField="Email" HeaderText="Email address" />
	        <asp:BoundField DataField="Comment" HeaderText="Comment" />
	        <asp:CheckBoxField DataField="IsApproved" HeaderText="Approved user" />
	        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Locked Out" ReadOnly="True" />
	        <asp:CheckBoxField DataField="IsOnline" HeaderText="On-line now" ReadOnly="True" />
	        <asp:BoundField DataField="CreationDate" HeaderText="Account created" ReadOnly="True" />
	        <asp:BoundField DataField="LastLoginDate" HeaderText="Last login" ReadOnly="True" />
	        <asp:BoundField DataField="LastActivityDate" HeaderText="Last activity" ReadOnly="True" />
	        <asp:BoundField DataField="LastLockoutDate" HeaderText="Last lockout" ReadOnly="True" />
	        <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="Last password change" ReadOnly="True" />
	        <asp:CommandField ButtonType="Button" ShowEditButton="True" EditText="Edit User Info" />
        </Fields>
        </asp:DetailsView>
        <!--Error message display-->
        <br />
        <asp:Label ID="Message" runat="server" />
    </td>
    <!--Right column-->
    <td valign="top">
        <!--Roles-->
        <h3>Roles</h3>
        <asp:CheckBoxList ID="cbUserRoles" runat="server" />
        <!--Additional options buttons-->
        <h3>Other Options</h3>
        <p><asp:Button ID="BtnDelete" runat="server" Text="Delete User" OnClick="DeleteUser" OnClientClick="return confirm('Are Your Sure?')" style="width:120px;" /></p>
        <p><asp:Button ID="BtnUnlock" runat="server" Text="Unlock User" OnClick="UnlockUser" OnClientClick="return confirm('Click OK to unlock this user.')" Enabled="False" style="width:120px;" /></p>
    </td>
</tr>
</table>
<asp:ObjectDataSource ID="MemberData" runat="server" DataObjectTypeName="System.Web.Security.MembershipUser" SelectMethod="GetUser" UpdateMethod="UpdateUser" TypeName="System.Web.Security.Membership">
	<SelectParameters>
		<asp:QueryStringParameter Name="username" QueryStringField="username" />
	</SelectParameters>
</asp:ObjectDataSource> 
</asp:Content>