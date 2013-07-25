<%@ Page Language="VB" MasterPageFile="~/LoggedInMaster.master" AutoEventWireup="false" CodeFile="ProductBrowser.aspx.vb" Inherits="ProductBrowser" title="Product Browser" %>
<%@ Register tagprefix="igcmbo" namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics35.WebUI.WebCombo.v8.3, Version=8.3.20083.1009, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register tagprefix="igtbl" namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics35.WebUI.UltraWebGrid.v8.3, Version=8.3.20083.1009, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register tagprefix="cc1" namespace="Infragistics.Web.UI.LayoutControls" Assembly="Infragistics35.Web.v8.3, Version=8.3.20083.1009, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register tagprefix="igtxt" namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v8.3, Version=8.3.20083.1009, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" Runat="Server">
</asp:content>
<asp:content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:label id="lblProductGroup" runat="server" text="Product Group" />
	<igcmbo:WebCombo ID="cboProductGroup" runat="server" Version="4.00" DataTextField="Description" DataValueField="Name">
        <Columns>
            <igtbl:UltraGridColumn>
                <header caption="Column0" />
            </igtbl:UltraGridColumn>
        </Columns>
        <expandeffects shadowcolor="LightGray" />
        <dropdownlayout version="4.00" BaseTableName="" XmlLoadOnDemandType="Accumulative">
            <framestyle height="130px" width="325px" />
        </dropdownlayout>
    </igcmbo:WebCombo>
	<br />
    <igtbl:UltraWebGrid ID="grdProducts" runat="server" Height="404px" Width="781px">
        <Bands>
            <igtbl:UltraGridBand>
                <Columns>
                    <igtbl:UltraGridColumn BaseColumnName="Sku" Key="Sku">
                        <Header Caption="SKU" />
                    </igtbl:UltraGridColumn>
                    <igtbl:UltraGridColumn BaseColumnName="Description" Key="Description">
                        <Header Caption="Description">
                            <RowLayoutColumnInfo OriginX="1" />
                        </Header>
                        <Footer>
                            <RowLayoutColumnInfo OriginX="1" />
                        </Footer>
                    </igtbl:UltraGridColumn>
                    <igtbl:UltraGridColumn BaseColumnName="Selling_price" Key="Selling_price">
                        <Header Caption="Price">
                            <RowLayoutColumnInfo OriginX="2" />
                        </Header>
                        <Footer>
                            <RowLayoutColumnInfo OriginX="2" />
                        </Footer>
                    </igtbl:UltraGridColumn>
                </Columns>
                <AddNewRow View="NotSet" Visible="NotSet" />
            </igtbl:UltraGridBand>
        </Bands>
        <DisplayLayout BorderCollapseDefault="Separate" Name="grdProducts" 
            RowHeightDefault="20px" Version="4.00" AllowColSizingDefault="Free" 
            AllowSortingDefault="OnClient" SelectTypeRowDefault="Single" 
            AutoGenerateColumns="False">
            <FrameStyle Height="404px" Width="781px" />
            <ActivationObject BorderColor="" BorderWidth="" />
        </DisplayLayout>
    </igtbl:UltraWebGrid>
	<br />
    </asp:content>

