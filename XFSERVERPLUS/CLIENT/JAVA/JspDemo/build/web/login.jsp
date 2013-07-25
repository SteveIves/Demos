<%@ page import="java.util.ArrayList" %>
<jsp:useBean id="synergy" scope="session" class="xfpldemo.utils" /> 
<HTML>
<HEAD>
<link rel="stylesheet" type="text/css" href="styles.css">
</HEAD>
<BODY>
<%

	//Define work variables
	boolean ok = true;
	boolean back = false;
	int sts;
	StringBuffer ErrorText= new StringBuffer();

	//Define data which will be cached
	xfpldemo.User CurrentUser = new xfpldemo.User();
	xfpldemo.Customer CurrentCustomer = new xfpldemo.Customer();
	ArrayList ProductGroups = null;

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
			sts = synergy.Login(username,password,ErrorText,CurrentUser);
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
			ProductGroups = new ArrayList();
			synergy.GetProductGroups(ProductGroups);
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
</BODY>
</HTML>

