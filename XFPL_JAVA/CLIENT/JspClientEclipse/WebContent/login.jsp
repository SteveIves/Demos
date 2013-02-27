<%@page contentType="text/html" pageEncoding="UTF-8" import="java.util.ArrayList,SynergyApp.Product_group"  %>
<jsp:useBean id="synergy" scope="session" class="SynergyApp.SynergyMethods" />

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Login</title>
        <link rel="stylesheet" type="text/css" href="styles.css">
    </head>
    <body>
	<%
	//Define work variables
	boolean ok = true;
	boolean back = false;
	int sts;
	StringBuffer ErrorText= new StringBuffer();

	//Define data which will be cached
	SynergyApp.User CurrentUser = new SynergyApp.User();
	SynergyApp.Customer CurrentCustomer = new SynergyApp.Customer();
	ArrayList<SynergyApp.Product_group> ProductGroups = null;

	//Get ready to connect
	synergy.setxfHost("localhost");
	synergy.setxfPort(2356);

	//Connect
	try {
		synergy.connect();
	}
	catch (Exception e) {
		session.setAttribute("ERROR_CMT","Connect() failed");
		session.setAttribute("ERROR_TXT",e.getMessage());
		ok=false;
	}

	if (ok) {
		//Setup the server-side environment
		try {
			sts = synergy.Initialize();
			if (sts!=0) {
				session.setAttribute("ERROR_CMT","Initialize() failed");
				session.setAttribute("ERROR_TXT","Return status was " + sts);
				ok=false;
			}
		}
		catch (Exception e) {
			session.setAttribute("ERROR_CMT","Initialize() failed");
			session.setAttribute("ERROR_TXT",e.getMessage());
			ok=false;
		}
	}


	if (ok) {
		//Server is ready, call the login method
		String username = request.getParameter("username");
		String password = request.getParameter("password");
		try {
			sts = synergy.Login(username,password,CurrentUser,ErrorText);
			if (sts!=0) {
				session.setAttribute("ERROR_TXT",ErrorText);
				ok=false;
				back=true;
			}
		}
		catch (Exception e) {
			session.setAttribute("ERROR_CMT","Login failed");
			session.setAttribute("ERROR_TXT",e.getMessage());
			ok=false;
		}
	}

	if (ok) {
		//We're logged in, retrieve the customer record
		try {
			CurrentCustomer.setAccount(CurrentUser.getUser_customer());
			sts = synergy.GetCustomer(CurrentCustomer,ErrorText);
			if (sts!=0) {
				session.setAttribute("ERROR_CMT","get_customer() failed");
				session.setAttribute("ERROR_TXT",ErrorText);
				ok=false;
			}
		}
		catch (Exception e) {
			session.setAttribute("ERROR_CMT","get_customer() failed");
			session.setAttribute("ERROR_TXT",e.getMessage());
			ok=false;
		}
	}

	if (ok) {
		//Retrieve product groups
		try {
			ProductGroups = new ArrayList<Product_group>();
			synergy.GetProductGroups2(ProductGroups);
		}
		catch (Exception e) {
			session.setAttribute("ERROR_CMT","get_product_groups_arraylist() failed");
			session.setAttribute("ERROR_TXT",e.getMessage());
			ok=false;
		}
	}

	if (!ok) {
		if (back) {
		RequestDispatcher rd = request.getRequestDispatcher("home.jsp?show_error=yes");
		rd.forward(request, response);
		}
		else {
		RequestDispatcher rd = request.getRequestDispatcher("error.jsp");
		rd.forward(request, response);
		}
	}
	else {
		//Cache user, customer and product group data
		session.setAttribute("USER",    CurrentUser);
		session.setAttribute("CUSTOMER",CurrentCustomer);
		session.setAttribute("GROUPS",  ProductGroups);

		//Successful login
		session.setAttribute("LOGGEDIN","YES");
		RequestDispatcher rd = request.getRequestDispatcher("products.jsp");
		rd.forward(request, response);
	}
	%>
    </body>
</html>
