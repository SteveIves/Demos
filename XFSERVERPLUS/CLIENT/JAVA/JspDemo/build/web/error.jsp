<jsp:useBean id="synergy" scope="session" class="xfpldemo.utils" /> 
<HTML>
<HEAD>
<link rel="stylesheet" type="text/css" href="styles.css">
</HEAD>
<BODY>
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
</BODY>
</HTML>

