<%@page contentType="text/html" pageEncoding="UTF-8" import="java.util.ArrayList,java.text.DateFormat,java.text.NumberFormat" %>
<%@include file="checklogin.jspf" %>
<jsp:useBean id="synergy" scope="session" class="SynergyApp.SynergyMethods" />

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Product Page</title>
        <link rel="stylesheet" type="text/css" href="styles.css">
<%

	boolean ok = true;
	int sts;
	int cnt;

	NumberFormat nf = NumberFormat.getCurrencyInstance();

	SynergyApp.Product product = new SynergyApp.Product();
	product.setSku(request.getParameter("sku"));

	try {
                StringBuffer errorText = new StringBuffer();
		sts = synergy.GetProduct(product,errorText);
		if (sts!=0) {
			session.setAttribute("ERROR_CMT","get_product() failed");
			session.setAttribute("ERROR_TXT","Return status was " + sts);
			ok=false;
		}
	} catch (Exception e) {
		session.setAttribute("ERROR_CMT","Call to get_product() failed");
		session.setAttribute("ERROR_TXT",e.getMessage());
		ok=false;
	}

	if (!ok) {
		RequestDispatcher rd = request.getRequestDispatcher("error.jsp");
		rd.forward(request, response);
	}


	DateFormat df = DateFormat.getDateInstance(DateFormat.MEDIUM);

	String releaseDate="Unknown";
	if (product.getRelease_date().getYear()>0) {
		releaseDate = df.format(product.getRelease_date());
	}

	String lastSaleDate="Unknown";
	if (product.getLast_sale().getYear()>0) {
		lastSaleDate = df.format(product.getLast_sale());
	}

%>
    </head>
    <body link="blue" vlink="blue" alink="blue">

<table border="0" width="80%" align="center">
<tr>
  <td>
    <h2>Product <%=product.getSku()%></h2>
    <table border="0" width="100%">
    <tr>
      <td class="prompt">Description</td>
      <td class="data" colspan="3"><%=product.getDescription()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="data" colspan="4">&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt" width="20%">Product Group</td>
      <td class="data">
<%

	ArrayList ProductGroups = (ArrayList)session.getAttribute("GROUPS");

	for (cnt=0; cnt<ProductGroups.size(); cnt++) {
		if (product.getGroup().equals(((SynergyApp.Product_group)ProductGroups.get(cnt)).getName())) {
			out.print("<a href='products.jsp?group=" + ((SynergyApp.Product_group)ProductGroups.get(cnt)).getName() + "'>");
			out.print(((SynergyApp.Product_group)ProductGroups.get(cnt)).getDescription());
			out.print("</a>");
		}
	}

%>
	  &nbsp;
	  </td>
      <td class="prompt" width="20%">Selling Price</td>
      <td class="data" align="right"><%=nf.format(product.getSelling_price()).toString()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">Reference</td>
      <td class="data"><%=product.getReference()%>&nbsp;</td>
      <td class="prompt">Last Cost Price</td>
      <td class="data" align="right"><%=nf.format(product.getLast_cost_price()).toString()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">&nbsp;</td>
      <td class="data">&nbsp;</td>
      <td class="prompt">Average Cost Price</td>
      <td class="data" align="right"><%=nf.format(product.getMoving_ave_cost_price()).toString()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="data" colspan="4">&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">Publisher</td>
      <td class="data"><%=product.getPublisher()%>&nbsp;</td>
      <td class="prompt">Qty In Stock</td>
      <td class="data" align="right"><%=product.getQty_in_stock()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">Author</td>
      <td class="data"><%=product.getAuthor()%>&nbsp;</td>
      <td class="prompt">Qty Allocated</td>
      <td class="data" align="right"><%=product.getQty_allocated()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">Type</td>
      <td class="data"><%=product.getType()%>&nbsp;</td>
      <td class="prompt">Qty In Transit</td>
      <td class="data" align="right"><%=product.getQty_in_transit()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">&nbsp;</td>
      <td class="data">&nbsp;</td>
      <td class="prompt">Qty On Order</td>
      <td class="data" align="right"><%=product.getQty_on_order()%>&nbsp;</td>
    </tr>
    <tr>
      <td class="data" colspan="4">&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">Rating</td>
      <td class="data"><%=product.getRating()%>&nbsp;</td>
      <td class="prompt">Release Date</td>
      <td class="data" align="right"><%=releaseDate%>&nbsp;</td>
    </tr>
    <tr>
      <td class="prompt">&nbsp;</td>
      <td class="data">&nbsp;</td>
      <td class="prompt">Last Sale</td>
      <td class="data" align="right"><%=lastSaleDate%>&nbsp;</td>
    </tr>
    </table>
  </td>
</tr>
</table>


    </body>
</html>
