<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Head Page</title>
        <link rel="stylesheet" type="text/css" href="styles.css">
    </head>
    <frameset framespacing="0" border="0" frameborder="no" rows="85,30,*">
	<frame name="title" marginwidth="0" marginheight="0" scrolling="no" noresize src="title.jsp">
	<frame name="nav" marginwidth="0" marginheight="0" scrolling="no" noresize src="nav.jsp" target="main">
	<frame name="spacer" marginwidth="0" marginheight="0" scrolling="no" noresize src="spacer.html">
	<noframes>
	<body>
	<p>This page uses frames, but your browser doesn't support them.</p>
	</body>
	</noframes>
    </frameset>
</html>
