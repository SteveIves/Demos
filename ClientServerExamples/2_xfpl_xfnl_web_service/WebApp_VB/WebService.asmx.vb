Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports spc2011

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetAllCustomers() As List(Of Customer)
        Dim svr As New SynergyServer()
        Dim customers As New List(Of Customer)
        svr.GetAllCustomers(customers)
        Return customers
    End Function

    <WebMethod()> _
    Public Function GetCustomerContacts(ByVal CustomerId As Integer) As List(Of Contact)
        Dim svr As New SynergyServer()
        Dim contacts As New List(Of Contact)
        svr.GetCustomerContacts(CustomerId, contacts)
        Return contacts
    End Function

    <WebMethod()> _
    Public Function GetContactForUpdate(ByVal customerId As Integer, ByVal contactId As Integer, ByRef contact As Contact, ByRef grfa() As Byte, ByVal msg As String) As Method_status
        Dim svr As New SynergyServer()
        contact = New Contact()
        Return svr.GetContactForUpdate(customerId, contactId, contact, grfa, msg)
    End Function

    <WebMethod()> _
    Public Function UpdateContact(ByRef contact As Contact, ByRef grfa() As Byte, ByRef msg As String) As Method_status
        Dim svr As New SynergyServer()
        Return svr.UpdateContact(contact, grfa, msg)
    End Function
End Class