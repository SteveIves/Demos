<%@page import="Synergex.util.*,PoolTest.*"%>
<html>
<head>
	<title>xfNetLink JAVA Pool Test</title>
</head>
<body>
<%
	out.println("<h1>xfNetLink JAVA Pool Test</h1>");
	out.println("<hr noshade>");

	boolean PoolFound=false;
	if (application.getAttribute("PoolMgr")==null)
		out.println("<font color=#ff0000><b>STATUS: NO POOL MANAGER FOUND</b></font>");
	else
	{
		out.println("<font color=#00ff00><b>STATUS: POOL MANAGER WAS FOUND</b></font>");
		PoolFound=true;
	}

	out.println("<hr noshade>");
	
	if (PoolFound)
	{
		out.print("[<a href='index.jsp?mode=test'>Test pool</a>] ");
		out.print("[<a href='index.jsp?mode=shutdown'>Shutdown pool</a>] ");
		out.print("[<a href='index.jsp?mode=destroy'>Destroy pool</a>] ");
		out.print("[<a href='index.jsp?mode=reload'>Reload pool properties</a>] ");
		out.println("[<a href='index.jsp'>Start over</a>]");
	}
	else
	{
		out.print("[<a href='index.jsp?mode=start'>Start pool</a>] ");
		out.println("[<a href='index.jsp'>Start over</a>]");
	}

	out.println("<hr noshade>");

	String mode=" ";
	if (!(request.getParameter("mode")==null))
		mode = request.getParameter("mode");

	if (mode.equals("start"))
	{
		/*
			There is no pool manager stored in the JSP application, so lets
			create a new one and store it there.  This essentially starts
			the pool.  This logic would normally be included at one location
			in the application source, perhaps at the point where a login
			function is being performed.  The pool would then be started
			the when the first user logs in after the application server
			is started. 
		*/
		out.println("Starting new pool manager...<br>");
		try {
			SWPManager TmpPoolMgr = SWPManager.getInstance();
			out.println("Pool manager was started<br>");
			application.setAttribute("PoolMgr",TmpPoolMgr);
			TmpPoolMgr = null;
		}
		catch (Exception e)
		{
			out.println("ERROR: Failed to create new pool manager<br>");
			out.println(" - " + e.getClass().toString()+"<br>");
			out.println(" - " + e.getMessage()+"<br>");
		}
		out.println("<a href='index.jsp'>Continue</a>");
	}
	else if (mode.equals("test"))
	{
		//First time in to page

		boolean ok=true;
		boolean created=false;
		boolean connected=false;
		SynergyMethods x=null;

		/*
			Retrieve the pool manager instance.
			This code woud be used any time a page needed to make a call to
			the Synergy server.  It retrieves an instance of the pool manager
			from the JSP application context.
		*/
		SWPManager PoolMgr = null;
		
		if (ok)
		{
			out.println("Retrieving pool manager...<br>");
			try
			{
				PoolMgr = ((SWPManager)application.getAttribute("PoolMgr")).getInstance();
			}
			catch (Exception e)
			{
				out.println("ERROR: Failed to retrieve pool manager instance<br>");
				out.println(" - "+e.getMessage()+"<br>");
				ok=false;
			}
		}

		/*
			Create an instance of the Synergy procedural class, tell it to use
			a pooled connection, and connect.  The .connedt() method will
			associate an existing pooled connection with the object.
		*/
		
		if (ok)
		{
			out.println("Creating new object...<br>");
			x = new SynergyMethods();
			created = true;

			//Connect to xfServerPlus using pooled connection
			try
			{
				x.usePool("MyPool",PoolMgr);
				x.connect();
				connected=true;
			}
			catch (Exception e)
			{
				out.println("ERROR: Failed to connect to xfServerPlus<br>");
				out.println(" - "+e.getMessage()+"<br>");
				ok=false;
			}
		}

		if (ok)
		{
			out.println("Calling setGreeting method...<br>");
			try
			{
				x.setGreeting("Hello Steve");
			}
			catch (Exception e)
			{
				out.println("ERROR: Failed to call setGreeting method<br>");
				out.println(" - "+e.getMessage()+"<br>");
				ok=false;
			}
		}

		if (ok)
		{
			out.println("Calling getGreeting method...<br>");
			StringBuffer greeting = new StringBuffer();
			try
			{
				x.getGreeting(greeting);
				out.println("Data returned was: " + greeting + "<br>");
			}
			catch (Exception e)
			{
				out.println("ERROR: Failed to call getGreeting method<br>");
				out.println(" - "+e.getMessage()+"<br>");
				ok=false;
			}
		}

		if (connected)
		{
			//Disconnect from xfServerPlus (release connection)
			try
			{
				out.println("Disconnecting from xfServerPlus...<br>");
				x.disconnect();
			}
			catch (Exception e)
			{
				out.println("ERROR: Failed to disconnect from xfServerPlus (release connection back to pool)<br>");
				out.println(" - "+e.getMessage()+"<br>");
			}			
		}

		//Delete object
		if (created) {
			out.println("Deleting object...<br>");
			x = null;
		}
		
		out.println("<a href='index.jsp'>Continue</a>");
	}
	else if (mode.equals("shutdown"))
	{
		/*
		This code closes down the pool.  It retrieves the pool manager from the
		JSP application, calls the shutdown() method, then removed the pool manager
		from the JSP application context.
		*/

		//Create an instance of the pool manager.
		out.println("Getting pool manager instance...<br>");
		try
		{
			SWPManager PoolMgr = ((SWPManager)application.getAttribute("PoolMgr")).getInstance();
			if(PoolMgr==null)
				out.println("No pool manager found<br>");
			else
			{
				try
				{
					out.println("Closing down pool manager<br>");
					PoolMgr.shutdown();
					out.println("Removing pool manager from JSP application context<br>");
					application.removeAttribute("PoolMgr");
					PoolMgr = null;
				}
				catch (Exception e)
				{
					out.println("ERROR: Failed to shut down pool manager<br>");
					out.println(" - "+e.getClass().toString()+"<br>");
					out.println(" - "+e.getMessage()+"<br>");
					application.removeAttribute("PoolMgr");
				}
			}
		}
		catch (xfPoolException e)
		{
			out.println("ERROR: Failed to get pool manager instance<br>");
			out.println(" - "+e.getMessage()+"<br>");
		}
		out.println("<a href='index.jsp'>Continue</a>");
	}
	else if (mode.equals("destroy"))
	{
		/*
			This code is a "brute force" way of getting rid of the pool.  It simply
			deletes the pool manager from the JSP application context.  This is for
			testing only and should never be done in a real application without
			first calling the shutdown method.
		*/

		//Create an instance of the pool manager.
		out.println("Destroying pool manager instance...<br>");
		application.removeAttribute("PoolMgr");
		out.println("<a href='index.jsp'>Continue</a>");
	}
	else if (mode.equals("reload"))
	{
		// This code causes the pool manager to re-read the pool properties file.
	
		//Create an instance of the pool manager.
		out.println("Getting pool manager instance...<br>");
		try
		{
			SWPManager PoolMgr = ((SWPManager)application.getAttribute("PoolMgr")).getInstance();
			if(PoolMgr==null)
				out.println("No pool manager found<br>");
			else
			{
				try
				{
					out.println("Reloading pool manager properties<br>");
					PoolMgr.resetPoolProperties("MyPool");
					out.println("Pool manager properties reloaded<br>");
				}
				catch (Exception e)
				{
					out.println("ERROR: Failed to shut down pool manager<br>");
					out.println(" - "+e.getClass().toString()+"<br>");
					out.println(" - "+e.getMessage()+"<br>");
				}
			}
		}
		catch (xfPoolException e) {
			out.println("ERROR: Failed to get pool manager instance<br>");
			out.println(" - "+e.getMessage()+"<br>");
		}
		out.println("<a href='index.jsp'>Continue</a>");
	}
%>
</body>
</html>
