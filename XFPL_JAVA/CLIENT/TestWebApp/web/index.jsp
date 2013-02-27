<%-- 
    Document   : index
    Created on : Jan 26, 2011, 2:23:12 PM
    Author     : Steve Ives
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Hello World!</h1>
        <%
            java.util.Date dt = new java.util.Date(2011,1,25);
            out.println("Year: " + dt.getYear());
        %>
    </body>
</html>
