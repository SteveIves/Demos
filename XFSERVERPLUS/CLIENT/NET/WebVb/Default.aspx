<%@ Page Language="VB" MasterPageFile="~/LoggedOutMaster.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="ASP.NET Demo Home Page" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v8.3, Version=8.3.20083.1009, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:content>
<asp:content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table border="0" align="center" cellspacing="10">
		<tr>
			<td>Username</td>
			<td><igtxt:WebTextEdit ID="TxtUsername" runat="server" Width="160px" MaxLength="40" /></td>
			<td><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtUsername">*</asp:requiredfieldvalidator></td>
		</tr>
		<tr>
			<td>Password</td>
			<td><igtxt:WebTextEdit ID="TxtPassword" runat="server" Width="160px" MaxLength="40" PasswordMode="true" /></td>
			<td><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtPassword">*</asp:requiredfieldvalidator></td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td colspan="2">
			    <igtxt:WebImageButton ID="BtnLogin" runat="server" Text="Login" />
			    <asp:label id="ErrorDisplay" runat="server" />
			</td>
		</tr>
	</table>
</asp:content>

