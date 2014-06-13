<%@ LANGUAGE="VBScript" %>
<%
  Option Explicit
  Response.Buffer = True
  Response.Expires = -1441

  Dim Mode
  Mode = Request("mode")
  If (Mode="") Then Mode="list"

  Select Case Mode
  Case "do_create"

    'Add code to create a new record
    '
    '
    Mode="list"

  Case "do_update"

    'Add code to update an existing record
    '
    '
    Mode="list"

  Case "do_delete"

    'Add code to delete an existing record
    '
    '
    Mode="list"

  End Select
%>
<html>
<head>
<title></title>
<script language="JavaScript">
<!--
function validate() {
  alert("Validate data");
}
function cancel() {
  alert("Cancel action");
}
-->
</script>
</head>
<body>

<!-- LIST MODE ------------------------------------------->
<%If (Mode="list") Then%>
  <!-- Add code here to present a list of records -->
<%End If%>

<!-- CREATE / AMEND MODE --------------------------------->
<%
  If (Mode="create" Or Mode="amend") Then

    Dim SR_CODE_DATA
    Dim SR_NAME_DATA

    If (Mode="amend") Then

      'Get and lock existing record
      Dim Status, Key, Data, Lock
      Key=Request("key")
      Data=""
      Lock=1

      Status=Synergy.xfSubr("salesrep_read",Key,Data,Lock)

      If (VarType(Status) = vbError) Then
        Session("ERROR_PAGE") = "salesrep.asp"
        Session("ERROR_PAGE_MODE") = Mode
        Session("ERROR_ROUTINE") = "salesrep_read"
        Session("ERROR_TEXT") = Synergy.getxfErrorMessage
        Response.Redirect("error.asp")
      Else
        If (Status <> 0) Then
          Session("ERROR_PAGE") = "salesrep.asp"
          Session("ERROR_PAGE_MODE") = Mode
          Session("ERROR_ROUTINE") = "salesrep_read"
          Session("ERROR_TEXT") = "Routine returned error " & Status
          Response.Redirect("error.asp")
        End If
      End If

      'Load current values into field data for editing
      SR_CODE_DATA = Mid(Data,1,3)
      SR_NAME_DATA = Mid(Data,4,30)

    Else

      'Setup default values in field data for new record
      SR_CODE_DATA = ""
      SR_NAME_DATA = ""

    End If
%>
<form name="salesrep" action="salesrep.asp" method="post">
  <table border="0">
    <tr>
      <td><font face="Arial">Rep code</font></td>
      <td><input type="text" name="SR_CODE" size="3" maxlength="3" value="<%=SR_CODE_DATA%>"></td>
    </tr>
    <tr>
      <td><font face="Arial">Name</font></td>
      <td><input type="text" name="SR_NAME" size="30" maxlength="30" value="<%=SR_NAME_DATA%>"></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>
        <input type="hidden" name="mode" value="do_<%=Mode%>">
        <input type="button" value="OK" onclick="validate();">
        <input type="button" value="Cancel" onclick="cancel();">
      </td>
    </tr>
  </table>
</form>
<%End If%>

</body>
</html>
