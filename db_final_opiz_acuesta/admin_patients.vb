Imports MySql.Data.MySqlClient


Public Class admin_patients
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet

    Public Function GetPatientInfo() As Dictionary(Of String, String) 'library function - temporarily holds inserted date
        Dim info As New Dictionary(Of String, String)
        info("first_name") = tb2.Text
        info("last_name") = tb3.Text
        info("middle_name") = tb4.Text
        info("birth_date") = tb5.Value.ToString("yyyy-MM-dd")
        info("address") = tb6.Text
        info("contact_number") = tb7.Text
        info("email_address") = tb8.Text
        info("medical_desc") = tb9.Text
        Return info
    End Function

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        If String.IsNullOrWhiteSpace(tb2.Text) OrElse
         String.IsNullOrWhiteSpace(tb3.Text) OrElse
         String.IsNullOrWhiteSpace(tb4.Text) OrElse
         String.IsNullOrWhiteSpace(tb5.Text) OrElse
         String.IsNullOrWhiteSpace(tb6.Text) OrElse
         String.IsNullOrWhiteSpace(tb7.Text) OrElse
         String.IsNullOrWhiteSpace(tb8.Text) OrElse
         String.IsNullOrWhiteSpace(tb9.Text) Then
            MsgBox("Please fill out all fields before continuing.")
            Exit Sub
        End If

        ' Collect data
        Dim patientData As New Dictionary(Of String, String)
        patientData("first_name") = tb2.Text
        patientData("last_name") = tb3.Text
        patientData("middle_name") = tb4.Text
        patientData("birth_date") = tb5.Text
        patientData("address") = tb6.Text
        patientData("contact_number") = tb7.Text
        patientData("email_address") = tb8.Text
        patientData("medical_desc") = tb9.Text

        ' Open second form and pass data
        Dim previewForm = signup.CreateWithPatientData(patientData)
        previewForm.Show()
        Me.Hide()
    End Sub

    Private Sub admin_patients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler tb1.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb2.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb3.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb4.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb5.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb6.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb7.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb8.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb9.KeyDown, AddressOf TextBox_KeyDown
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Select Case DirectCast(sender, Control).Name
                Case "tb1" : tb2.Focus()
                Case "tb2" : tb3.Focus()
                Case "tb3" : tb4.Focus()
                Case "tb4" : tb5.Focus()
                Case "tb5" : tb6.Focus()
                Case "tb6" : tb7.Focus()
                Case "tb7" : btn1.Focus()
            End Select
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pID = tb1.Text
        Dim updateFields As New List(Of String)

        If Not String.IsNullOrWhiteSpace(tb2.Text) Then updateFields.Add("first_name = '" & tb2.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb3.Text) Then updateFields.Add("last_name = '" & tb3.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb4.Text) Then updateFields.Add("middle_name = '" & tb4.Text & "'")
        If tb5.Value <> Date.MinValue Then updateFields.Add("birth_date = '" & tb5.Value.ToString("yyyy-MM-dd") & "'")
        If Not String.IsNullOrWhiteSpace(tb6.Text) Then updateFields.Add("address = '" & tb6.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb7.Text) Then updateFields.Add("contact_number = '" & tb7.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb8.Text) Then updateFields.Add("email_address = '" & tb8.Text & "'")

        If updateFields.Count > 0 Then
            Try
                Dim sql As String = "UPDATE patients SET " & String.Join(", ", updateFields) & " WHERE patient_id = " & pID
                Dim cmd As New MySqlCommand(sql, conn)
                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                MsgBox(If(rowsAffected > 0, "Patient info updated.", "No record was updated."))
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("No fields to update. Please fill in at least one value.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pID As String = tb1.Text.Trim()
        Dim sql As String = ""

        Try
            conn.Open()

            If pID = "" Then
                ' No ID provided, get top 10 patients sorted by ID
                sql = "SELECT p.patient_id, p.first_name, p.last_name, p.middle_name, " &
                      "DATE_FORMAT(p.birth_date, '%Y-%m-%d') AS birth_date, " &
                      "p.address, p.contact_number, p.email_address, " &
                      "mdh.md_id, mdh.md_description " &
                      "FROM patients p " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "ORDER BY p.patient_id ASC LIMIT 10"
            Else
                ' Specific ID provided
                sql = "SELECT p.patient_id, p.first_name, p.last_name, p.middle_name, " &
                      "DATE_FORMAT(p.birth_date, '%Y-%m-%d') AS birth_date, " &
                      "p.address, p.contact_number, p.email_address, " &
                      "mdh.md_id, mdh.md_description " &
                      "FROM patients p " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "WHERE p.patient_id = " & Val(pID)
            End If

            Dim cmd As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "patients")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "patients"
            MsgBox("Patient data loaded: " & ds.Tables("patients").Rows.Count)

        Catch ex As MySqlException
            MsgBox("Error fetching data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pID As String = Val(tb1.Text)
        Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this patient record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirmDelete = DialogResult.Yes Then
            Try
                conn.Open()
                Dim sql As String = "DELETE FROM patients WHERE patient_id = " & pID
                Dim cmd As New MySqlCommand(sql, conn)
                Dim rowsDeleted As Integer = cmd.ExecuteNonQuery()

                MsgBox(If(rowsDeleted > 0, "Patient record deleted.", "No record was deleted."))

            Catch ex As MySqlException
                MsgBox("Error deleting patient: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("Deletion cancelled.")
        End If

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        Admin_Menu.Show()
    End Sub
End Class