<%--
/////////////////////////////////////////////////////////////
//
// Default.aspx
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Silverlight Airlines Demo</title>

    <script type="text/javascript" src="JS/Silverlight.js"></script>
    <script type="text/javascript" src="JS/CreateSilverlight.js"></script>

    <style type="text/css">
        html,body
        {
            height:100%;
            margin:0px;
        }
        body
        {
            font-family:Arial;
            color:#817C90;
        }

        #Background
        {
            position:absolute;
            top:0px;
            left:0px;
            width:100%;
            height:100%;
        }

        #Logo
        {
            position:absolute;
        }

        #Menu
        {
            position:absolute;
            top:15px;
            right:10px;
        }

        #aspnetForm
        {
            position:absolute;
            top:60px;
        }

        #Footer
        {
            position:absolute;
            left:10px;
            bottom:5px;
            font-size:x-small;
            color:#777;
        }
        #Footer a
        {
            color:Black;
            text-decoration:none;
        }
        #Footer a:hover
        {
            text-decoration:underline;
            color:#FF896C;
        }
    </style>
</head>
<body>
    <img id="Background" src="Images/Background.jpg" alt="" />
    <img id="Logo" src="Images/Logo.png" alt="Silverlight Airlines" />
    <img id="Menu" src="Images/Menu.png" alt="Menu" />
    <div id="Footer">
        &#169; 2007 Microsoft Corporation. All rights reserved. <a href="http://www.microsoft.com/info/cpyright.mspx">Terms of Use</a> | <a href="http://www.microsoft.com/library/toolbar/3.0/trademarks/en-us.mspx">Trademarks</a> | <a href="http://www.microsoft.com/info/privacy.mspx">Privacy Statement</a>
    </div>

    <form id="aspnetForm" runat="server" onsubmit="" style="width:100%; height:80%;">
        <div style="width:100%; height:100%;">

            <div id="AgControl1Host" style="background-color:transparent; width:100%; height:100%" />

            <script type="text/javascript">
                createSilverlight();
            </script>

        </div>
    </form>
</body>
</html>
