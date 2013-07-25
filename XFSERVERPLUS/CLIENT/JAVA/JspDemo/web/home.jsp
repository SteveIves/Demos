<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<title>Home Page</title>
<link rel="stylesheet" type="text/css" href="styles.css">
<script language="javascript">
//Cause the navigation frame to reload (for logout)
window.parent.frames[0].frames[1].frames[1].navigate("nav.jsp");
</script>
</head>
<body>
<%
	if (request.getParameter("show_error")!=null) {
		if (request.getParameter("show_error").equals("yes")) { 
			out.println("<script language='javascript'>");
			out.println("  alert('" + session.getAttribute("ERROR_TXT") +"');");
			out.println("</script>");
			session.removeAttribute("ERROR_TXT");
		}
	}
%>

<table width="60%" height="50%" align="center">
<tr>
  <td valign="middle">
    <p>This web site demonstrates the integration of Java Server Pages (JSP) with a 
    Synergy/DE back-end business application.  The integration is performed using
    the Synergy/DE <i>xf</i>NetLink JAVA and <i>xf</i>ServerPlus products.</p>
	
	<p>This demo was originally created for use at SPC2004, and the source code
	for both the web site and the supporting Synergy/DE server environment can
	be found on the conference CD.</p>
  </td>
</tr>
</table>
</body>
</html>