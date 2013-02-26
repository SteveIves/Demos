<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
        <strong><span style="font-size: 32pt">Steves Todo List</span></strong></div>
    <div>
        Status:
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True" Value="false">Active</asp:ListItem>
            <asp:ListItem Value="true">Completed</asp:ListItem>
        </asp:DropDownList>
        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div>Updating...</div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <div><strong><span style="font-size: 16pt">ToDo List Items</span></strong></div>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                                            AllowSorting="True"
                                                            AutoGenerateColumns="False" 
                                                            DataKeyNames="TaskId" 
                                                            DataSourceID="ObjectDataSource1"
                                                            gridlines="None" Width="721px" CellPadding="4" ForeColor="#333333">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="TaskId" HeaderText="TaskId" InsertVisible="False" ReadOnly="True"
                            SortExpression="TaskId" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:CheckBoxField DataField="Complete" HeaderText="Complete" SortExpression="Complete" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        
        
        <div>
            <strong><span style="font-size: 16pt">Add A New Task</span></strong></div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DetailsView ID="DetailsView1" runat="server" 
                                                                Height="160px" 
                                                                Width="719px" 
                                                                AutoGenerateRows="False" 
                                                                DataKeyNames="TaskId" 
                                                                DataSourceID="ObjectDataSource1" 
                                                                DefaultMode="Insert"
                                                                GridLines="None" CellPadding="4" ForeColor="#333333">
                        <Fields>
                            <asp:BoundField DataField="TaskId" HeaderText="TaskId" InsertVisible="False" ReadOnly="True"
                                SortExpression="TaskId" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:CheckBoxField DataField="Complete" HeaderText="Complete" SortExpression="Complete" />
                            <asp:CommandField ShowInsertButton="True" />
                        </Fields>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <EditRowStyle BackColor="#999999" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:DetailsView>
                </ContentTemplate>
            </asp:UpdatePanel>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTasksByStatus"
            TypeName="TasksDataSetTableAdapters.TasksTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_TaskId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Complete" Type="Boolean" />
                <asp:Parameter Name="Original_TaskId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="IsComplete" PropertyName="SelectedValue"
                    Type="Boolean" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Complete" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
