<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="public_login" title="User Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h2>Login To Your Account</h2>
            <asp:Login ID="LoginControl" runat="server" DestinationPageUrl="user/Default.aspx" CreateUserText="Create new account" CreateUserUrl="~/public/register.aspx" PasswordRecoveryText="Recover your password" PasswordRecoveryUrl="~/public/recovery.aspx" VisibleWhenLoggedIn="False" RememberMeText="Remember me" TitleText="">
            </asp:Login>
</asp:Content>

