<%@page contentType="text/html" pageEncoding="UTF-8" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Navigation Page</title>
        <link rel="stylesheet" type="text/css" href="styles.css">
        <base target="main">
        <script language="javascript">
        function go(target) {
                window.parent.parent.parent.frames[1].navigate(target);
        }
        </script>
    </head>
    <body bgcolor="#ECEDF0">
<%
	if (session.getAttribute("LOGGEDIN") == "YES") {
		SynergyApp.User abc = new SynergyApp.User();
		SynergyApp.User CurrentUser = (SynergyApp.User)session.getAttribute("USER");
		SynergyApp.Customer CurrentCustomer = (SynergyApp.Customer)session.getAttribute("CUSTOMER");
%>
	<table border="0" width="100%">
	<tr>
		<td width="99%">
			<input type="button" value="Products" onclick='go("products.jsp");' class="button">
			<input type="button" value="Orders" onclick='go("orders.jsp");' class="button">
			User: <b><%=CurrentUser.getFirst_name()%> <%=CurrentUser.getLast_name()%></b> Company: <b><%=CurrentCustomer.getCompany()%></b>
		</td>
		<td width="1%" align="right">
			<input type="button" value="Logout" onclick='go("logout.jsp");' class="button">
		</td>
	</tr>
	</table>
<%}else{%>
	<table border="0" width="100%">
	<tr>
		<td align="right">
			<form action="login.jsp" method="post">
			<input type="text" size="10" maxlength="40" name="username">
			<input type="password" size="10" maxlength="40" name="password">
			<input type="submit" value="Login" class="button">
			</form>
		</td>
	</tr>
	</table>
<%}%>
    </body>
</html>
