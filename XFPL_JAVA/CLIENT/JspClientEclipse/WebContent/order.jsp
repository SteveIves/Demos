<%@page contentType="text/html" pageEncoding="UTF-8" import="java.util.ArrayList,java.util.Date,java.text.DateFormat,java.text.NumberFormat,SynergyApp.*"%>
<%@ include file="checklogin.jspf" %>
<jsp:useBean id="synergy" scope="session" class="SynergyApp.SynergyMethods" />

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Order Page</title>
        <link rel="stylesheet" type="text/css" href="styles.css">
    </head>
    <body link="blue" vlink="blue" alink="blue">
		<table border="0" width="80%" align="center">
		<tr>
		<td>
		<h2>Order Summary</h2>
		<%		
			//Local work variables
			int cnt;
			int lineCount;
		
			NumberFormat nf = NumberFormat.getCurrencyInstance();
		
			//Retrieve the cached order array
			@SuppressWarnings("unchecked") 
			ArrayList<Order_header> orders = (ArrayList<Order_header>)session.getAttribute("ORDERS");
		
			//Get the order header record from the cache
			int orderArrayIndex = Integer.parseInt(request.getParameter("order"));
			SynergyApp.Order_header order = (SynergyApp.Order_header)orders.get(orderArrayIndex);
		
			//Setup display variables
			String giftWrap;
			if (order.getGift_wrap()==0)
				giftWrap="No";
			else
				giftWrap="Yes";
		
			DateFormat df = DateFormat.getDateInstance(DateFormat.MEDIUM);
			Date defaultDate = new Date();
		
			String orderDate="";
		    orderDate = df.format(order.getOrder_date().getTime());
		
			String shipDate="";
		    //if (order.getShip_date().getYear()>0)
		    if (order.getShip_date().getTime().getYear()>0)
				shipDate = df.format(order.getShip_date().getTime());
		
			String deliveryDate="";
			//if (order.getDelivery_date().getYear()>0) {
			if (order.getDelivery_date().getTime().getYear()>0) {
				deliveryDate = df.format(order.getDelivery_date().getTime());
			}
		
			String orderStatus="";
			if (order.getStatus().equals("O")) {
				orderStatus="Open";
			}
			if (order.getStatus().equals("P")) {
				orderStatus="Processing";
			}
			if (order.getStatus().equals("S")) {
				orderStatus="Shipped";
			}
			if (order.getStatus().equals("D")) {
				orderStatus="Delivered";
			}
			if (order.getStatus().equals("C")) {
				orderStatus="Cancelled";
			}
			if (order.getStatus().equals("B")) {
				orderStatus="Back Ordered";
			}

			//Get the order line items
			ArrayList<Order_line> orderline = new ArrayList<Order_line>();
			lineCount = synergy.GetOrderItems(order.getOrder(),orderline);
		
		%>
		
		<!--Display order header information-->
		<table border="0" width="100%">
		<tr>
		  <td class="prompt" width="20%">Order number</td>
		  <td class="data"><%=order.getOrder()%></td>
		  <td class="prompt" width="20%">Date of order</td>
		  <td class="data" align="right" width="20%"><%=orderDate%></td>
		</tr>
		<tr>
		  <td class="prompt">Customer reference</td>
		  <td class="data"><%=order.getCustomer_order_ref()%>&nbsp;</td>
		  <td class="prompt">Ship date</td>
		  <td class="data" align="right">&nbsp;<%=shipDate%></td>
		</tr>
		<tr>
		  <td class="prompt">Status</td>
		  <td class="data"><%=orderStatus%></td>
		  <td class="prompt">Delivery date</td>
		  <td class="data" align="right">&nbsp;<%=deliveryDate%></td>
		</tr>
		<tr>
		  <td class="prompt">Customer account</td>
		  <td class="data"><%=order.getCustomer()%></td>
		  <td class="prompt">Items ordered</td>
		  <td class="data" align="right"><%=lineCount%></td>
		</tr>
		<tr>
		  <td class="prompt">Gift wrap</td>
		  <td class="data"><%=giftWrap%></td>
		  <td class="prompt">&nbsp;</td>
		  <td class="data" align="right">&nbsp;</td>
		</tr>
		<tr>
		  <td class="prompt">Gift message</td>
		  <td class="data" colspan="3"><%=order.getGift_message()%>&nbsp;</td>
		</tr>
		</table>
		
		<!--Display order line items-->
		<p>
		<table border="0" width="100%">
		<tr valign="top">
		  <td class="prompt" bgcolor='#ecedf0'>Product</td>
		  <td class="prompt" bgcolor='#ecedf0'>Description</td>
		  <td class="prompt" align="right" bgcolor='#ecedf0'>Cost Each</td>
		  <td class="prompt" align="right" bgcolor='#ecedf0'>Qty Ordered</td>
		  <td class="prompt" align="right" bgcolor='#ecedf0'>Goods Cost</td>
		</tr>
		<%
		  for (cnt=0; cnt<lineCount; cnt++) {
			  SynergyApp.Order_line thisLine = (SynergyApp.Order_line)orderline.get(cnt);
		%>
		<tr class="data" valign="top">
		  <td class="data"><a href="product.jsp?sku=<%=thisLine.getSku()%>"><%=thisLine.getSku()%></a></td>
		  <td class="data"><%=thisLine.getDescription()%></td>
		  <td class="data" align="right"><%=nf.format(thisLine.getPrice()).toString()%></td>
		  <td class="data" align="right"><%=thisLine.getQty_ordered()%></td>
		  <td class="data" align="right"><%=nf.format(thisLine.getLine_value()).toString()%></td>
		</tr>
		<%
		  }
		%>
		<tr valign="top">
		  <td bgcolor='#ecedf0'>&nbsp;</td>
		  <td bgcolor='#ecedf0'>&nbsp;</td>
		  <td bgcolor='#ecedf0'>&nbsp;</td>
		  <td bgcolor='#ecedf0'>&nbsp;</td>
		  <td bgcolor='#ecedf0'>&nbsp;</td>
		</tr>
		<tr valign="top">
		  <td class="data" colspan="3">&nbsp;</td>
		  <td class="data">Goods</td>
		  <td class="data" align="right"><%=nf.format(order.getGoods_value()).toString()%></td>
		</tr>
		<tr valign="top">
		  <td class="data" colspan="3">&nbsp;</td>
		  <td class="data">Tax</td>
		  <td class="data" align="right"><%=nf.format(order.getTax_value()).toString()%></td>
		</tr>
		<tr valign="top">
		  <td class="data" colspan="3">&nbsp;</td>
		  <td class="data" bgcolor="#ffffff">Shipping</td>
		  <td class="data" align="right"><%=nf.format(order.getShipping_value()).toString()%></td>
		</tr>
		<tr valign="top">
		  <td class="prompt" colspan="3">&nbsp;</td>
		  <td class="prompt" bgcolor='#ecedf0'>Order total</td>
		  <td class="prompt" bgcolor='#ecedf0' align="right"><%=nf.format(order.getGoods_value() + order.getTax_value() + order.getShipping_value()).toString()%></td>
		</tr>
		</table>
		
		</td>
		</tr>
		</table>
    </body>
</html>
