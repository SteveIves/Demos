<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:useBean id="synergy" scope="session" class="SynergyApp.SynergyMethods" />

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Error Page</title>
        <link rel="stylesheet" type="text/css" href="styles.css">
    </head>
    <body>
        <h1>ERROR!!!</h1>
        <table border="1">
	<tr>
		<td>Error comment</td>
		<td><%=session.getAttribute("ERROR_CMT")%></td>
	</tr>
	<tr>
		<td>Error text</td>
		<td><%=session.getAttribute("ERROR_TXT")%></td>
	</tr>
        </table>
    </body>
</html>
