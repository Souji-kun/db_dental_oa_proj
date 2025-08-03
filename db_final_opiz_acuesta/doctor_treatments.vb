Imports MySql.Data.MySqlClient
Public Class doctor_treatments
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim tID = tb1.Text

        Try
            If String.IsNullOrWhiteSpace(tID) Then
                ' Show top 10 recent treatments
                sql = "SELECT t.treatment_id, t.treatment_name, t.price, t.description, " &
                      "p.patient_id, CONCAT(p.first_name,' ',p.last_name) AS Patient, " &
                      "CONCAT(e.first_name,' ',e.last_name) AS Dentist, " &
                      "a.appointment_id, a.appointment_date, a.status, " &
                      "mdh.md_id, mdh.md_description " &
                      "FROM treatments t " &
                      "LEFT JOIN patients p ON p.treatments_treatment_id = t.treatment_id " &
                      "LEFT JOIN appointments a ON p.patient_id = a.patients_patient_id " &
                      "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "ORDER BY t.treatment_id DESC LIMIT 10"
            Else

                sql = "SELECT t.treatment_id, t.treatment_name, t.price, t.description, " &
                  "p.patient_id, concat(p.first_name,' ',p.last_name)as Patient, " &
                  "concat(e.first_name,' ',e.last_name)as Dentist, " &
                  "a.appointment_id, a.appointment_date, a.status, " &
                  "mdh.md_id, mdh.md_description " &
                  "FROM treatments t " &
                  "LEFT JOIN patients p ON p.treatments_treatment_id = t.treatment_id " &
                  "LEFT JOIN appointments a ON p.patient_id = a.patients_patient_id " &
                  "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                  "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                  "WHERE t.treatment_id = " & tID
            End If
            Dim dbcomm As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "treatments")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "treatments"
            MsgBox("Rows fetched: " & ds.Tables("treatments").Rows.Count)


        Catch ex As MySqlException
            Dim unused = MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tID = tb1.Text
        Dim pID = tb2.Text
        Dim dID = tb3.Text
        Dim selectedDate = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        Try
            conn.Open()
            sql = "INSERT INTO appointments (treatments_treatment_id, patients_patient_id, employees_employee_id, appointment_date) " &
              "VALUES ('" & tID & "', '" & pID & "', '" & dID & "',  '" & selectedDate & "')"

            Dim dbcomm As New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("Appointment inserted successfully")
            Else
                MsgBox("Insertion failed")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pID = tb2.Text
        Try
            If String.IsNullOrWhiteSpace(pID) Then
                sql = "SELECT p.patient_id, CONCAT(p.first_name,' ',p.last_name) AS Patient, " &
                      "e.employee_id, CONCAT(e.first_name,' ',e.last_name) AS Dentist, " &
                      "t.treatment_id, t.treatment_name, t.price, a.appointment_id, a.appointment_date, " &
                      "mdh.md_id, mdh.md_description " &
                      "FROM patients p " &
                      "LEFT JOIN appointments a ON p.patient_id = a.patients_patient_id " &
                      "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                      "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "ORDER BY p.patient_id DESC LIMIT 10"
            Else
                sql = "SELECT p.patient_id, concat(p.first_name,' ',p.last_name)as Patient, " &
                 " e.employee_id, concat(e.first_name,' ',e.last_name)as Dentist, " &
                 " t.treatment_id, t.treatment_name, t.price, a.appointment_id, a.appointment_date, " &
                 " mdh.md_id, mdh.md_description " &
                 " FROM patients p " &
                 " LEFT JOIN appointments a ON p.patient_id = a.patients_patient_id " &
                 " LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                 " LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                 " LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                 " WHERE p.patient_id = " & pID
            End If
            Dim dbcomm As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "patients")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "patients"
            MsgBox("Rows fetched: " & ds.Tables("patients").Rows.Count)

        Catch ex As Exception
            Dim unused = MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub S_dID_Click(sender As Object, e As EventArgs) Handles S_dID.Click
        Dim dID = tb3.Text
        Try
            If String.IsNullOrWhiteSpace(dID) Then
                sql = "SELECT e.employee_id, CONCAT(e.first_name,' ',e.last_name) AS Dentist, " &
                      "p.patient_id, CONCAT(p.first_name,' ',p.last_name) AS Patient, " &
                      "t.treatment_id, t.treatment_name, t.price, a.appointment_id, a.appointment_date, " &
                                 "mdh.md_id, mdh.md_description " &
                      "FROM employees e " &
                      "LEFT JOIN appointments a ON e.employee_id = a.employees_employee_id " &
                      "LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
                      "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "ORDER BY a.appointment_date DESC LIMIT 10"
            Else
                sql = "SELECT e.employee_id, concat(e.first_name,' ',e.last_name)as Dentist, " &
                 " p.patient_id, concat(e.first_name,' ',e.last_name)as Patient, " &
                 " t.treatment_id, t.treatment_name, t.price, a.appointment_id, a.appointment_date, " &
                 " mdh.md_id, mdh.md_description " &
                 " FROM employees e " &
                 " LEFT JOIN appointments a ON e.employee_id = a.employees_employee_id " &
                 " LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
                 " LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                 " LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                 " WHERE e.employee_id = " & dID
            End If
            Dim dbcomm As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "employees")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "employees"
            MsgBox("Rows fetched: " & ds.Tables("employees").Rows.Count)

        Catch ex As Exception
            Dim unused = MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub doctor_treatments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim aID As String = tb1.Text
        Dim pID As String = tb2.Text
        Dim dID As String = tb3.Text
        Dim statusText As String = tb4.Text.Trim().ToLower()

        If Not {"pending", "processing", "cancelled", "finished"}.Contains(statusText) Then
            MsgBox("Invalid status. Use: pending, processing, cancelled, or finished.")
            tb4.SelectAll()
            tb4.Focus()
            Exit Sub
        End If

        Try
            conn.Open()
            sql = "UPDATE appointments SET status = '" & statusText & "' " &
              "WHERE appointment_id = " & aID & " AND patients_patient_id = " & pID & " AND employees_employee_id = " & dID

            Dim dbcomm As New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("Status updated successfully")
            Else
                MsgBox("No matching appointment found")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class