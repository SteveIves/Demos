<%@page contentType="text/html" pageEncoding="UTF-8" import="java.util.ArrayList,java.text.NumberFormat" %>
<%@include file="checklogin.jspf" %>
<jsp:useBean id="synergy" scope="session" class="SynergyApp.SynergyMethods" />

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Products Page</title>
<script language="javascript">
//Cause the navigation frame to reload for login
window.parent.frames[0].frames[1].frames[1].navigate("nav.jsp");
</script>
<link rel="stylesheet" type="text/css" href="styles.css">
<%

	//Local work variables
	int cnt;
	boolean usingCache = false;


	//Retrieve cached product groups
	ArrayList ProductGroups = (ArrayList)session.getAttribute("GROUPS");

	//Request to invalidate cache?
	if (!(request.getParameter("mode")==null)) {
		if (((String)request.getParameter("mode")).equals("refresh")) {
			session.removeAttribute("LASTGROUP");
			session.removeAttribute("PRODUCTS");
		}
	}

	//Initial default to first product group
	String SelectedGroup = ((SynergyApp.Product_group)ProductGroups.get(0)).getName();

	//Specific group requested?
	if (!(request.getParameter("group")==null)) {

		SelectedGroup = request.getParameter("group");

		//Change of group with cache present?
		if (!(session.getAttribute("LASTGROUP")==null)) {
			if (!SelectedGroup.equals((String)session.getAttribute("LASTGROUP"))) {
				//Different group - invalidate cache
				session.removeAttribute("LASTGROUP");
				session.removeAttribute("PRODUCTS");
			}
		}
	}
	else {

		//Not a post-back - was there a previously selected group
		if (session.getAttribute("LASTGROUP")!=null) {
			SelectedGroup = (String)session.getAttribute("LASTGROUP");
		}
	}

	//Get products for first or selected group

	int ProductCount=0;
	ArrayList Products = null;

	if ((session.getAttribute("LASTGROUP")!=null) && (session.getAttribute("PRODUCTS")!=null)) {

		//We have a last group, there should be a product array in cache
		Products = (ArrayList)session.getAttribute("PRODUCTS");
		ProductCount=Products.size();
		usingCache = true;

	} else {

		//Go to the server for an array of products for the required group
		Products = new ArrayList();
		ProductCount = synergy.GetProductsInGroup(SelectedGroup,Products);
		if (ProductCount > 0) {
			//Cache the product array
			session.setAttribute("LASTGROUP",SelectedGroup);
			session.setAttribute("PRODUCTS",Products);
		}
	}

%>
    </head>
    <body link="blue" vlink="blue" alink="blue">
<table border="0" width="80%" align="center">
<tr>
  <td align="center">
    <h2>Product Browser</h2>
    <form action="products.jsp" method="post">
    <table border="0">
    <tr>
      <td><div class="prompt">Product group</div></td>
      <td>
        <select name="group">
<%

	for (cnt=0; cnt<ProductGroups.size(); cnt++)
	{
		out.print("          <option value='" + ((SynergyApp.Product_group)ProductGroups.get(cnt)).getName() + "'");
		if (SelectedGroup.equals(((SynergyApp.Product_group)ProductGroups.get(cnt)).getName())) {
			out.print(" selected");
		}
		out.println( ">"+((SynergyApp.Product_group)ProductGroups.get(cnt)).getDescription()+"</option>");
	}

%>
        </select>
      </td>
      <td>
        <input type="submit" name ="mode" value="Search">
      </td>
    </tr>
    </table>
    </form>
  </td>
</tr>
</table>

<%
	if (ProductCount>0) {
%>
<table border='0' width='80%' align='center'>
<tr>
  <td class="data" colspan="3">
  <%if (usingCache) {%>
    <%=ProductCount%> products displayed from cache. Click to <a href='products.jsp?mode=refresh&group=<%=SelectedGroup%>'>refresh</a> products.
  <%} else {%>
    <%=ProductCount%> products retrieved from server.
  <%}%>
  </td>
</tr>
<tr>
  <td>
    <table border='0' width='100%'>
    <tr>
      <td class="prompt" bgcolor='#ecedf0'>Product Description</td>
      <td class="prompt" align='right' bgcolor='#ecedf0'>Selling Price</td>
      <td class="prompt" align='right' bgcolor='#ecedf0'>Available</td>
    </tr>
<%

	  NumberFormat nf = NumberFormat.getCurrencyInstance();
	  String sellingPrice="";

	  for (cnt=0; cnt<ProductCount; cnt++) {

		SynergyApp.Product CurrentProduct = (SynergyApp.Product)Products.get(cnt);

%>
		<tr>
		  <td class="data"><a href='product.jsp?sku=<%=CurrentProduct.getSku()%>'><%=CurrentProduct.getDescription()%></a></td>
		  <td class="data" align='right'><%=sellingPrice = nf.format(CurrentProduct.getSelling_price()).toString()%></td>
		  <td class="data" align='right'><%=(CurrentProduct.getQty_in_stock() - CurrentProduct.getQty_allocated())%></td>
		</tr>
<%
	  }
%>
    <tr>
      <td colspan="3" >&nbsp;</td>
    </tr>
    <tr>
      <td colspan="3" class="data" bgcolor='#ecedf0'>&nbsp;</td>
    </tr>
    </table>
  </td>
</tr>
</table>
<%
	}
%>

    </body>
</html>
