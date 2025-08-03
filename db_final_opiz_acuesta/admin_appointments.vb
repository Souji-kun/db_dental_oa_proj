Imports MySql.Data.MySqlClient


Public Class admin_appointments
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles S_aID.Click
        Dim aID As String = tb1.Text
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Try
            conn.Open()
            If aID = "" Then
                sql = "SELECT a.appointment_id, a.status, a.appointment_date, " &
      "p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS full_name, " &
      "e.employee_id, CONCAT(e.first_name, ' ', e.last_name) AS Dentist, " &
      "mdh.md_id, mdh.md_description, t.treatment_name " &
      "FROM appointments a " &
      "LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
      "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
      "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
      "ORDER BY a.appointment_id DESC"
            Else
                sql = "SELECT a.appointment_id, status, a.appointment_date, " &
                      "p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS full_name, " &
                      "e.employee_id, CONCAT(e.first_name, ' ', e.last_name) AS Dentist, " &
                      "mdh.md_id, mdh.md_description, t.treatment_name " &
                      "FROM appointments a " &
                      "LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                      "LEFT JOIN roles r ON e.roles_role_id = r.role_id " &
                      "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                      "WHERE a.appointment_id = " & aID
            End If
            Dim dbcomm As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "appointments")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "appointments"
            MsgBox("Rows fetched: " & ds.Tables("appointments").Rows.Count)


        Catch ex As MySqlException
            Dim unused = MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tb1_TextChanged(sender As Object, e As EventArgs) Handles tb1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ins.Click
        Dim aID As String = tb1.Text
        Dim pID As String = tb2.Text
        Dim dID As String = tb3.Text
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim userID As Integer = 0

        Try
            conn.Open()
            sql = "INSERT INTO appointments (appointment_id, patients_patient_id, employees_employee_id, appointment_date) " &
              "VALUES (" & aID & ", " & pID & ", " & dID & ", '" & selectedDate & "')"

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles S_dID.Click
        Dim dID As String = tb3.Text
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        Try
            conn.Open()
            If String.IsNullOrWhiteSpace(dID) Then
                sql = "SELECT e.employee_id, CONCAT(e.first_name, ' ', e.last_name) AS Dentist, " &
                      "r.role_name, p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS Patient_Name, " &
                      "mdh.md_id, mdh.md_description, t.treatment_name, a.appointment_date " &
                      "FROM appointments a " &
                      "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                      "LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "LEFT JOIN roles r ON e.roles_role_id = r.role_id " &
                      "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                      "ORDER BY a.appointment_date DESC"
            Else
                sql = "SELECT e.employee_id, " &
                      "CONCAT(e.first_name, ' ', e.last_name) AS Dentist, " &
                      "r.role_name, " &
                      "p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS Patient_Name, " &
                      "mdh.md_id, mdh.md_description, " &
                      "t.treatment_name, a.appointment_date " &
                      "FROM employees e " &
                      "LEFT JOIN appointments a ON e.employee_id = a.employees_employee_id " &
                      "LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "LEFT JOIN roles r ON e.roles_role_id = r.role_id " &
                      "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                      "WHERE e.employee_id = " & dID
            End If
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "employees")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "employees"
            MsgBox("Rows fetched: " & ds.Tables("employees").Rows.Count)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles S_pID.Click
        Dim pID As String = tb2.Text
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        Try
            conn.Open()
            If String.IsNullOrWhiteSpace(pID) Then
                sql = "SELECT a.appointment_id, CONCAT(p.first_name,' ',p.last_name) AS Patient, " &
                      "CONCAT(e.first_name,' ',e.last_name) AS Dentist, r.role_name, " &
                      "mdh.md_id, mdh.md_description, a.appointment_date, t.treatment_name " &
                      "FROM appointments a " &
                      "LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
                      "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                      "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                      "LEFT JOIN roles r ON e.roles_role_id = r.role_id " &
                      "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                      "ORDER BY a.appointment_date DESC"
            Else
                sql = "SELECT a.appointment_id, CONCAT(p.first_name,' ',p.last_name) AS Patient, " &
                  "CONCAT(e.first_name,' ',e.last_name) AS Dentist, r.role_name, " &
                  "mdh.md_id, mdh.md_description, " & "a.appointment_date, " & "treatment_name " &
                  "FROM patients p " &
                  "LEFT JOIN appointments a ON p.patient_id = a.patients_patient_id " &
                  "LEFT JOIN medical_history mdh ON p.patient_id = mdh.patients_patient_id " &
                  "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                  "LEFT JOIN roles r ON e.roles_role_id = r.role_id " &
                  "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                  "WHERE p.patient_id = " & pID
            End If
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "patients")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "patients"
            MsgBox("Rows fetched: " & ds.Tables("patients").Rows.Count)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles del.Click
        Dim aID As String = tb1.Text
        Dim statusText As String = ""

        Try
            conn.Open()

            ' Step 1: Check current status
            sql = "SELECT status FROM appointments WHERE appointment_id = " & aID
            Dim checkCmd As New MySqlCommand(sql, conn)
            Dim reader As MySqlDataReader = checkCmd.ExecuteReader()

            If reader.Read() Then
                statusText = reader("status").ToString().ToLowerInvariant()
            Else
                MsgBox("Appointment ID not found.")
                reader.Close()
                conn.Close()
                Exit Sub
            End If
            reader.Close()

            ' Step 2: Show confirmation based on status
            Dim confirmMessage As String
            If statusText = "cancelled" Then
                confirmMessage = "This appointment is already cancelled. Do you still want to delete it?"
            Else
                confirmMessage = "This appointment is not cancelled (status: " & statusText & "). Are you sure you want to delete it?"
            End If

            Dim result As DialogResult = MessageBox.Show(confirmMessage, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then
                conn.Close()
                Exit Sub
            End If

            ' Step 3: Proceed with deletion
            sql = "DELETE FROM appointments WHERE appointment_id = " & aID
            Dim deleteCmd As New MySqlCommand(sql, conn)
            Dim i As Integer = deleteCmd.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("Appointment deleted successfully.")
            Else
                MsgBox("Deletion failed.")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles upd.Click
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

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        Admin_Menu.Show()
    End Sub
End Class