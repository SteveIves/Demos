<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="profile.aspx.vb" Inherits="user_profile" title="User Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h2>Update Your Profile</h2>
<p>
    <asp:Label id="lblFirstName" runat="server" Text="First Name"></asp:Label>
    <asp:TextBox id="txtFirstName" runat="server"></asp:TextBox></p>
    <p>
    <asp:Label id="lblLastName" runat="server" Text="Last Name"></asp:Label>
    <asp:TextBox id="txtLastName" runat="server"></asp:TextBox></p>
    <p>
    <asp:Button id="btnSave" runat="server" Text="Save" />
    <asp:Button id="btnCancel" runat="server" Text="Cancel" CausesValidation="false" />
</p>
    
</asp:Content>

