<jsp:useBean id="synergy" scope="session" class="xfpldemo.utils" /> 
<HTML>
<HEAD>
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
</HEAD>
<BODY>
</BODY>
</HTML>

