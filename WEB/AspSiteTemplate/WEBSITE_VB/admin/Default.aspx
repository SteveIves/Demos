<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="admin_Default" title="Admin Home Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h2>Site Administration Menu</h2>
    <h3>Access Control Options</h3>
    <ul>
        <li><a href="Users.aspx">Users</a></li>
        <li><a href="Roles.aspx">Roles</a></li>
        <li><a href="AccessRules.aspx">Access Rules</a></li>
        <li><a href="AccessSummary.aspx">Access Summary</a></li>
        <li><a href="AddUser.aspx">Add User</a></li>
    </ul>
</asp:Content>

