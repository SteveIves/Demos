Imports system
Imports System.Web
Imports System.Web.SessionState

Public Class UtilsClass

    Public Sub SayHello()

        'Get a handle on the various ASP.NET objects that we need.  You only need to
        'declare the ones that you are using in this method, but I put them all here
        'to show you how to do it.  This routine only uses Session and Response for example.

        Dim Server As System.Web.HttpServerUtility = HttpContext.Current.Server
        Dim Session As HttpSessionState = HttpContext.Current.Session
        Dim Request As HttpRequest = HttpContext.Current.Request
        Dim Response As HttpResponse = HttpContext.Current.Response

        Dim HelloText As String = Session("HELLOTEXT")
        Response.Write(HelloText)

    End Sub

End Class
