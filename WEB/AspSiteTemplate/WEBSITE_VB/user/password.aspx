<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="password.aspx.vb" Inherits="user_password" title="Change Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h2>Change Your Password</h2>
<p>
    <asp:ChangePassword ID="ChangePassword1" runat="server"
        CancelDestinationPageUrl="~/user/default.aspx"
        ContinueDestinationPageUrl="~/user/default.aspx"
        EditProfileText="Edit your profile"
        EditProfileUrl="~/user/profile.aspx"
        PasswordRecoveryText="Recover your password"
        PasswordRecoveryUrl="~/user/password.aspx" ChangePasswordTitleText= ConfirmNewPasswordLabelText="Confirm new password:" CreateUserText="Create a new account" CreateUserUrl="~/public/register.aspx" NewPasswordLabelText="New password:" PasswordLabelText="Current password:">
    </asp:ChangePassword>
</p>
</asp:Content>

