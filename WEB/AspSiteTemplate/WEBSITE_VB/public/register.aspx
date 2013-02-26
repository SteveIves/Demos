<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="public_register" title="Register For An Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h2>Register For An Account</h2>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/default.aspx">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

