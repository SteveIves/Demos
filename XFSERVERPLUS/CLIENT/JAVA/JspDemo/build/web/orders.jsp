<%@ page import="java.util.ArrayList,java.util.Date,java.text.DateFormat" %>
<%@ include file="checklogin.inc" %>
<jsp:useBean id="synergy" scope="session" class="xfpldemo.utils" /> 
<HTML>
<HEAD>
<link rel="stylesheet" type="text/css" href="styles.css">
<%

	//Retrieve cached customer record
	xfpldemo.Customer CurrentCustomer = (xfpldemo.Customer)session.getAttribute("CUSTOMER");

	if (request.getParameter("mode")!=null) {
		if (request.getParameter("mode").equals("refresh"))
			session.removeAttribute("ORDERS");
	}	
		
	//Get order data for currently logged in users company
	
	ArrayList order = null;
	int orderCount=0;

	int cnt;
	boolean usingCache = false;
	
	if (session.getAttribute("ORDERS")!=null) {
        order = (ArrayList)session.getAttribute("ORDERS");
		orderCount = order.size();		
		usingCache = true;
	}
	else {

	    xfpldemo.User CurrentUser;
		String customerCode;
	
		CurrentUser = (xfpldemo.User)session.getAttribute("USER");
		customerCode = CurrentUser.getUser_customer();
		
		order = new ArrayList();
		orderCount = synergy.GetOrders(customerCode,order);
	
		//Cache the orders array for reuse later
		if (orderCount!=0)	{
			session.setAttribute("ORDERS",order);
		}

	}

%>
</HEAD>
<BODY link="blue" vlink="blue" alink="blue">
<table border="0" width="80%" align="center">
<tr>
<td align="center">
<h2>Orders for <%=CurrentCustomer.getCompany()%></h2>
<%if (orderCount == 0) {%>
No orders found for <%=CurrentCustomer.getCompany()%>.
<%} else {%>
<table border='0' width='100%' align='center'>
<tr>
  <td class="data">
  <%if (usingCache) {%>
    <%=orderCount%> orders displayed from cache. Click to <a href='orders.jsp?mode=refresh'>refresh</a> orders.
  <%} else {%>
    <%=orderCount%> orders retrieved from server.
  <%}%>
  </td>
</tr>
<tr>
  <td>
    <table border='0' width='100%'>
    <tr>
      <td class="prompt" bgcolor='#ecedf0'>Date of Order</td>
      <td class="prompt" bgcolor='#ecedf0'>Order Number</td>
      <td class="prompt" bgcolor='#ecedf0'>Your Ref.</td>
      <td class="prompt" bgcolor='#ecedf0'>Status</td>
      <td class="prompt" bgcolor='#ecedf0'>Shipped</td>
      <td class="prompt" bgcolor='#ecedf0'>Delivered</td>
    </tr>
<%
	
	DateFormat df = DateFormat.getDateInstance(DateFormat.MEDIUM);
	Date defaultDate = new Date();
	
	String orderDate="";
	String shipDate="";
	String deliveryDate="";
	
	xfpldemo.Order_header thisOrder;

	for (cnt=0; cnt<orderCount; cnt++) {

		thisOrder = (xfpldemo.Order_header)order.get(cnt);

		orderDate = df.format(thisOrder.getOrder_date());
		
		shipDate = "";
		if (thisOrder.getShip_date().getYear()>0) {
			shipDate = df.format(thisOrder.getShip_date());
		}
		
		deliveryDate = "";
		if (thisOrder.getDelivery_date().getYear()>0) {
			deliveryDate = df.format(thisOrder.getDelivery_date());
		}

		String tempStatus="";
		if (thisOrder.getStatus().equals("O")) {
			tempStatus="Open";
		}
		if (thisOrder.getStatus().equals("P")) {
			tempStatus="Processing";
		}
		if (thisOrder.getStatus().equals("S")) {
			tempStatus="Shipped";
		}
		if (thisOrder.getStatus().equals("D")) {
			tempStatus="Delivered";
		}
		if (thisOrder.getStatus().equals("C")) {
			tempStatus="Cancelled";
		}
		if (thisOrder.getStatus().equals("B")) {
			tempStatus="Back Ordered";
		}

%>
    <tr>
      <td class="data"><a href='order.jsp?order=<%=cnt%>'><%=orderDate%></a></td>
      <td class="data"><a href='order.jsp?order=<%=cnt%>'><%=thisOrder.getOrder()%></a></td>
      <td class="data"><%=thisOrder.getCustomer_order_ref()%></td>
      <td class="data"><%=tempStatus%></td>
      <td class="data"><%=shipDate%></td>
      <td class="data"><%=deliveryDate%></td>
    </tr>
<%	} %>
    <tr>
      <td class="data" colspan="6" >&nbsp;</td>
    </tr>
    <tr>
      <td class="data" colspan="6" bgcolor='#ecedf0'>&nbsp;</td>
    </tr>
    </table>
  </td>
</tr>
</table>
<% } %>
</td>
</tr>
</table>
</BODY>
</HTML>

