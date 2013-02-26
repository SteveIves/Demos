Imports Microsoft.VisualBasic

Public Class EmployeeManager

    Public Shared Function GetAllEmployees() As Generic.List(Of Employee)

        Dim C As Integer
        Dim NewEmployee As Employee
        Dim Employees As Generic.List(Of Employee)

        For C = 1 To 4
            NewEmployee = New Employee
            With NewEmployee
                .EmployeeID = C
                .FirstName = "Firstname" & C
                .LastName = "Lastname" & C
                .JobTitle = "Jobtitle" & C
            End With
            Employees.Add(NewEmployee)
        Next

        Return Employees

    End Function

End Class
