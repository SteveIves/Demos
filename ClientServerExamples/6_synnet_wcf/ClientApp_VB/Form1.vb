
Public Class Form1

    Dim svr As spc2011.SynergyServerClient = Nothing
    Dim savedContact As spc2011.Contact
    Dim savedGrfa() As Byte
    Dim msg As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gridCustomers.AutoGenerateColumns = False
        gridContacts.AutoGenerateColumns = False
        svr = New spc2011.SynergyServerClient()
        savedGrfa = New Byte(9) {}

        Dim customers As New List(Of spc2011.Customer)
        Try
            customers = svr.GetAllCustomers()
            gridCustomers.DataSource = customers

            'If we have customers then load the contacts for the one that is now selected
            If (gridCustomers.SelectedRows.Count > 0) Then
                Dim tmpCustomer As spc2011.Customer = CType(gridCustomers.Rows(gridCustomers.SelectedRows(0).Index).DataBoundItem, spc2011.Customer)
                loadContacts(tmpCustomer.Customer_id)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub gridCustomers_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCustomers.RowEnter
        If gridCustomers.SelectedRows.Count > 0 Then
            displayBlankContact()
            Dim cus As List(Of spc2011.Customer)
            Dim c As spc2011.Customer
            cus = DirectCast(gridCustomers.DataSource, List(Of spc2011.Customer))
            c = DirectCast(cus(gridCustomers.SelectedRows(0).Index), spc2011.Customer)
            loadContacts(c.Customer_id)
        End If
    End Sub

    Private Sub loadContacts(ByVal customer_id As Integer)
        Dim cts As New List(Of spc2011.Contact)
        Try
            cts = svr.GetCustomerContacts(customer_id)
            gridContacts.DataSource = cts

            'If we have a selected contact then display it
            If gridContacts.SelectedRows.Count > 0 Then
                savedContact = DirectCast(gridContacts.Rows(gridContacts.SelectedRows(0).Index).DataBoundItem, spc2011.Contact)
                Try
                    svr.GetContactForUpdate(savedContact, savedGrfa, msg, savedContact.Customer_id, savedContact.Contact_id)
                    displaySavedContact()
                Catch
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub gridContacts_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridContacts.RowEnter
        If gridContacts.SelectedRows.Count > 0 Then
            savedContact = DirectCast(gridContacts.Rows(e.RowIndex).DataBoundItem, spc2011.Contact)

            'Get the latest version of the contact, and it's current GRFA
            Dim currentContact As New spc2011.Contact()

            Try
                svr.GetContactForUpdate(currentContact, savedGrfa, msg, savedContact.Customer_id, savedContact.Contact_id)
                savedContact = currentContact

                'Update the contact in the grids datasource
                Dim cts As List(Of spc2011.Contact)
                cts = DirectCast(gridContacts.DataSource, List(Of spc2011.Contact))
                cts(e.RowIndex) = currentContact

                displaySavedContact()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        saveContact()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        displaySavedContact()
        allowSave = False
    End Sub

    Private Sub exitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub displaySavedContact()
        txtFirstName.Text = savedContact.First_name
        txtLastName.Text = savedContact.Last_name
        txtFullName.Text = savedContact.Friendly_name
        txtPrefix.Text = savedContact.Salutation
        txtTitle.Text = savedContact.Title
        txtDepartment.Text = savedContact.Department
        If savedContact.Work_phone <> 0 Then
            txtWorkPhone.Text = savedContact.Work_phone.ToString()
        Else
            txtWorkPhone.Text = ""
        End If
        If savedContact.Mobile_phone <> 0 Then
            txtMobilePhone.Text = savedContact.Mobile_phone.ToString()
        Else
            txtMobilePhone.Text = ""
        End If
        If savedContact.Home_phone <> 0 Then
            txtHomePhone.Text = savedContact.Home_phone.ToString()
        Else
            txtHomePhone.Text = ""
        End If
        If savedContact.Fax <> 0 Then
            txtFax.Text = savedContact.Fax.ToString()
        Else
            txtFax.Text = ""
        End If
        txtWebSite.Text = savedContact.Web_site
        txtEmail.Text = savedContact.Email
        chkManagementContact.Checked = savedContact.Management_contact
        chkBillingContact.Checked = savedContact.Billing_contact
        chkSalesContact.Checked = savedContact.Sales_contact
        chkTechnicalContact.Checked = savedContact.Technical_contact
        chkGeneralContact.Checked = savedContact.General_contact
        allowSave = False
    End Sub

    Private Sub saveContact()
        If Not validateFormData() Then
            Return
        End If

        'Save the new contact info locally
        savedContact.First_name = txtFirstName.Text
        savedContact.Last_name = txtLastName.Text
        savedContact.Friendly_name = txtFullName.Text
        savedContact.Salutation = txtPrefix.Text
        savedContact.Title = txtTitle.Text
        savedContact.Department = txtDepartment.Text
        If txtWorkPhone.Text.Length > 0 Then
            savedContact.Work_phone = Long.Parse(txtWorkPhone.Text)
        Else
            savedContact.Work_phone = 0
        End If
        If txtMobilePhone.Text.Length > 0 Then
            savedContact.Mobile_phone = Long.Parse(txtMobilePhone.Text)
        Else
            savedContact.Mobile_phone = 0
        End If
        If txtHomePhone.Text.Length > 0 Then
            savedContact.Home_phone = Long.Parse(txtHomePhone.Text)
        Else
            savedContact.Home_phone = 0
        End If
        If txtFax.Text.Length > 0 Then
            savedContact.Fax = Long.Parse(txtFax.Text)
        Else
            savedContact.Fax = 0
        End If
        savedContact.Web_site = txtWebSite.Text
        savedContact.Email = txtEmail.Text
        savedContact.Management_contact = chkManagementContact.Checked
        savedContact.Billing_contact = chkBillingContact.Checked
        savedContact.Sales_contact = chkSalesContact.Checked
        savedContact.Technical_contact = chkTechnicalContact.Checked
        savedContact.General_contact = chkGeneralContact.Checked

        'Save the new data to the server
        Try
            svr.UpdateContact(savedContact, savedGrfa, msg)

            'Update the contact in the grids datasource
            Dim cts As List(Of spc2011.Contact)
            cts = DirectCast(gridContacts.DataSource, List(Of spc2011.Contact))
            cts(gridContacts.SelectedRows(0).Index) = savedContact
            gridContacts.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()
        End Try

        allowSave = False
    End Sub

    Private Function validateFormData() As Boolean
        Dim retval As Boolean = True

        Dim errorMessage As String = ""

        If txtFirstName.Text.Length = 0 Then
            errorMessage = [String].Format("{0}/nFirst name cannot be blank", errorMessage)
            retval = False
        End If

        If txtLastName.Text.Length = 0 Then
            errorMessage = [String].Format("{0}/nLast name cannot be blank", errorMessage)
            retval = False
        End If

        If txtWorkPhone.Text.Length > 0 Then
            Dim tmpPhone As Long
            If Not Long.TryParse(txtWorkPhone.Text, tmpPhone) Then
                errorMessage = [String].Format("{0}" & vbLf & "Work phone must be numeric", errorMessage)
                retval = False
            End If
        End If

        If txtMobilePhone.Text.Length > 0 Then
            Dim tmpPhone As Long
            If Not Long.TryParse(txtMobilePhone.Text, tmpPhone) Then
                errorMessage = [String].Format("{0}" & vbLf & "Mobile phone must be numeric", errorMessage)
                retval = False
            End If
        End If

        If txtHomePhone.Text.Length > 0 Then
            Dim tmpPhone As Long
            If Not Long.TryParse(txtHomePhone.Text, tmpPhone) Then
                errorMessage = [String].Format("{0}" & vbLf & "Home phone must be numeric", errorMessage)
                retval = False
            End If
        End If

        If txtFax.Text.Length > 0 Then
            Dim tmpPhone As Long
            If Not Long.TryParse(txtFax.Text, tmpPhone) Then
                errorMessage = [String].Format("{0}" & vbLf & "Fax number must be numeric", errorMessage)
                retval = False
            End If
        End If

        If Not retval Then
            MessageBox.Show(errorMessage, "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return retval
    End Function

    Private Sub displayBlankContact()
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtFullName.Text = ""
        txtPrefix.Text = ""
        txtTitle.Text = ""
        txtDepartment.Text = ""
        txtWorkPhone.Text = ""
        txtMobilePhone.Text = ""
        txtHomePhone.Text = ""
        txtFax.Text = ""
        txtWebSite.Text = ""
        txtEmail.Text = ""
        chkManagementContact.Checked = False
        chkBillingContact.Checked = False
        chkSalesContact.Checked = False
        chkTechnicalContact.Checked = False
        chkGeneralContact.Checked = False
    End Sub

    Private _allowSave As Boolean
    Private Property allowSave() As Boolean
        Get
            Return _allowSave
        End Get
        Set(ByVal value As Boolean)
            _allowSave = value
            btnOK.Enabled = _allowSave
            btnCancel.Enabled = _allowSave
        End Set
    End Property


    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstName.TextChanged
        txtFullName.Text = String.Format("{0} {1}", txtFirstName.Text, txtLastName.Text)
        allowSave = True
    End Sub

    Private Sub txtLastName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLastName.TextChanged
        txtFullName.Text = String.Format("{0} {1}", txtFirstName.Text, txtLastName.Text)
        allowSave = True
    End Sub

    Private Sub fieldChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkPhone.TextChanged, txtWebSite.TextChanged, txtTitle.TextChanged, txtPrefix.TextChanged, txtMobilePhone.TextChanged, txtHomePhone.TextChanged, txtFullName.TextChanged, txtFax.TextChanged, txtEmail.TextChanged, txtDepartment.TextChanged, chkTechnicalContact.CheckedChanged, chkSalesContact.CheckedChanged, chkManagementContact.CheckedChanged, chkGeneralContact.CheckedChanged, chkBillingContact.CheckedChanged
        allowSave = True
    End Sub

End Class
