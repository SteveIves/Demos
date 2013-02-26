<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Wizard.aspx.vb" Inherits="Wizard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Wizard ID="Wizard1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE"
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
            Height="355px" Style="z-index: 100; left: 92px; position: absolute; top: 97px"
            Width="599px" ActiveStepIndex="0" HeaderText="Site Registration Wizard">
            <StepStyle Font-Size="0.8em" ForeColor="#333333" />
            <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" Width="150px" />
            <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
            <WizardSteps>
                <asp:WizardStep runat="server" Title="Personal Details">
                    <asp:Label ID="LblIntroText" runat="server" Height="32px" Style="z-index: 107; left: 166px; position: absolute; top: 29px" Text="You can use this Wizard to request access to this web site.  Complete the details on this page, then click the &quot;Next&quot; button to continue." Width="412px"></asp:Label>
                    <asp:Label ID="LblFirstName" runat="server" Style="z-index: 100; left: 167px; position: absolute; top: 85px" Text="First Name"></asp:Label>
                    <asp:TextBox ID="TxtFirstName" runat="server" Style="z-index: 103; left: 260px; position: absolute; top: 82px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server" ControlToValidate="TxtFirstName" ErrorMessage="Required" Style="z-index: 109; left: 425px; position: absolute; top: 85px"></asp:RequiredFieldValidator>
                    <asp:Label ID="LblMiddleInitials" runat="server" Style="z-index: 108; left: 167px; position: absolute; top: 128px" Text="Middle Initials"></asp:Label>
                    <asp:TextBox ID="TxtMiddleInitials" runat="server" Style="z-index: 104; left: 260px; position: absolute; top: 124px"></asp:TextBox>
                    <asp:Label ID="LblLastName" runat="server" Style="z-index: 101; left: 167px; position: absolute; top: 171px" Text="Last Name"></asp:Label>
                    <asp:TextBox ID="TxtLastName" runat="server" Style="z-index: 105; left: 260px; position: absolute; top: 166px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" ControlToValidate="TxtLastName" ErrorMessage="Required" Style="z-index: 111; left: 428px; position: absolute; top: 167px"></asp:RequiredFieldValidator>
                    <asp:Label ID="LblJobTitle" runat="server" Style="z-index: 102; left: 170px; position: absolute; top: 213px" Text="Job Title"></asp:Label>
                    <asp:TextBox ID="TxtJobTitle" runat="server" Style="z-index: 106; left: 261px; position: absolute; top: 211px"></asp:TextBox>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Company Details">
                    <asp:CheckBox ID="CheckBox1" runat="server" Style="z-index: 100; left: 184px; position: absolute;
                        top: 46px" Text="Option 1" />
                    <asp:CheckBox ID="CheckBox2" runat="server" Style="z-index: 102; left: 183px; position: absolute;
                        top: 85px" Text="Option 2" />
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Contact Details">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Style="z-index: 100; left: 179px;
                        position: absolute; top: 45px">
                        <asp:ListItem Selected="True">One</asp:ListItem>
                        <asp:ListItem>Two</asp:ListItem>
                        <asp:ListItem>Three</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Login Details" StepType="Finish">
                </asp:WizardStep>
            </WizardSteps>
            <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
            <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="0px"
                Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        </asp:Wizard>
        <asp:Label ID="LblTitle" runat="server" Font-Size="XX-Large" Style="z-index: 101;
            left: 93px; position: absolute; top: 38px" Text="Wizard Control"></asp:Label>
        <asp:Label ID="Message" runat="server" Style="z-index: 103; left: 565px; position: absolute;
            top: 545px" Width="125px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
