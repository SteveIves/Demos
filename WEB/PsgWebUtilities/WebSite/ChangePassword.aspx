<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>This page allows you to change the password that you use to log in to the PSG Web Server.</p>
    <p>Please enter data into all of the fields on the form opposite, then click the "Change Password" button.</p>
    <p>To return to the PSG SharePoint Server without changing your password, click the "Back to Site" button.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="4" cellspacing="4">
                <tr>
                    <td><asp:Label ID="lblUsername" runat="server" Text="Username" /></td>
                    <td><asp:TextBox ID="txtUsername" runat="server" /></td>
                    <td><asp:RequiredFieldValidator ID="valUsername" runat="server" ErrorMessage="Required" ControlToValidate="txtUsername" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblOldPassword" runat="server" Text="Current Password" /></td>
                    <td><asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" /></td>
                    <td><asp:RequiredFieldValidator ID="valOldPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtOldPassword" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNewPassword1" runat="server" Text="New Password" /></td>
                    <td><asp:TextBox ID="txtNewPassword1" runat="server" TextMode="Password" /></td>
                    <td><asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtNewPassword1" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNewPassword2" runat="server" Text="Repeat New Password" /></td>
                    <td><asp:TextBox ID="txtNewPassword2" runat="server" TextMode="Password" /></td>
                    <td><asp:CompareValidator ID="valPasswordMatch" runat="server" ErrorMessage="New passwords do not match!" ControlToCompare="txtNewPassword1" ControlToValidate="txtNewPassword2"/></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnOk" runat="server" Text="Change Password" onclick="btnOk_Click" />
                        <asp:Button ID="btnBack" runat="server" Text="Back to Site" onclick="btnBack_Click" CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" />
                    </td>
                </tr>
                </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

