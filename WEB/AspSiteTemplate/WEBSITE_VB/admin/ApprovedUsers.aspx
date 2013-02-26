<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ApprovedUsers.aspx.vb" Inherits="admin_ApprovedUsers" title="Approved Users" %>
<%@ Register Src="UsersNav.ascx" TagName="UsersNav" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h2>Approved / Unapproved Users</h2>
<uc1:UsersNav ID="UsersNav1" runat="server" />
<br />
<asp:RadioButtonList ID="rbApproved" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
    <asp:ListItem Selected="True" Value="true">Approved users</asp:ListItem>
    <asp:ListItem Value="false">Unapproved users</asp:ListItem>
</asp:RadioButtonList><br />
<asp:GridView runat="server" ID="Users" AutoGenerateColumns="false" GridLines="none" AllowSorting="true" Width="100%" >
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
