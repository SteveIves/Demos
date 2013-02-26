<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="user_default" title="User Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h2>User Account</h2>
    <p>
        <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" />
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="False" StartFromCurrentNode="True" />
    </p>
</asp:Content>

