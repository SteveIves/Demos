<%@ Page Language="vb" AutoEventWireup="false" Inherits="TestWebSolution.Menus" CodeFile="Menus.aspx.vb" %>
<%@ Register TagPrefix="ignav" Namespace="Infragistics.WebUI.UltraWebNavigator" Assembly="Infragistics2.WebUI.UltraWebNavigator.v10.1, Version=10.1.20101.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Menus</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<ignav:UltraWebMenu id="UltraWebMenu1" style="Z-INDEX: 101; LEFT: 44px; POSITION: absolute; TOP: 36px"
				runat="server" ScrollImageBottom="ig_menu_scrolldown.gif" ScrollImageTopDisabled="ig_menu_scrollup_disabled.gif"
				ScrollImageBottomDisabled="ig_menu_scrolldown_disabled.gif" Cursor="Default" ScrollImageTop="ig_menu_scrollup.gif"
				SubMenuImage="ig_menuTri.gif">
				<DisabledStyle ForeColor="LightGray"></DisabledStyle>
				<HoverItemStyle Cursor="Default" ForeColor="White" BackColor="DarkBlue"></HoverItemStyle>
				<IslandStyle Cursor="Default" BorderWidth="1px" Font-Size="8pt" Font-Names="MS Sans Serif" BorderStyle="Outset"
					ForeColor="Black" BackColor="LightGray"></IslandStyle>
				<ExpandEffects ShadowColor="LightGray"></ExpandEffects>
				<SeparatorStyle BackgroundImage="ig_menuSep.gif" CssClass="SeparatorClass" CustomRules="background-repeat:repeat-x; "></SeparatorStyle>
				<Levels>
					<ignav:Level Index="0"></ignav:Level>
				</Levels>
				<Items>
					<ignav:Item Text="Column 1">
						<Items>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item Text="Column 2">
						<Items>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item Text="Column3">
						<Items>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item Text="Column4">
						<Items>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
							<ignav:Item Text="Sub Menu Item"></ignav:Item>
						</Items>
					</ignav:Item>
				</Items>
			</ignav:UltraWebMenu>
		</form>
	</body>
</HTML>
