<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:useBean id="synergy" scope="session" class="SynergyApp.SynergyMethods" />

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Logout</title>
        <%
            try {
                synergy.Cleanup();
            }
            catch (Exception e) {
            }

            try {
                synergy.disconnect();
            }
            catch (Exception e) {

            }

            session.removeAttribute("LOGGEDIN");
            session.removeAttribute("ERROR_TXT");
            session.removeAttribute("ERROR_CMT");
            session.removeAttribute("ORDERS");
            session.removeAttribute("LASTGROUP");
            session.removeAttribute("PRODUCTS");

            RequestDispatcher rd = request.getRequestDispatcher("home.jsp");
            rd.forward(request, response);
        %>
    </head>
    <body>
    </body>
</html>
