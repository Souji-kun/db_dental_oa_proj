Imports MySql.Data.MySqlClient


Public Class admin_transaction
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub admin_transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        Admin_Menu.Show()
    End Sub

    Private Sub S_tID_Click(sender As Object, e As EventArgs) Handles S_tID.Click
        Dim tID = tb1.Text

        Try
            conn.Open()

            If tID = "" Then
                sql = "SELECT t.transaction_id, p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS Patients, " &
                      "a.appointment_id, a.appointment_date, t.treatment_id, tm.treatment_name, " &
                      "t.price, t.amount_paid, t.amount_tendered " &
                      "FROM transactions t " &
                      "LEFT JOIN patients p ON t.patient_id = p.patient_id " &
                      "LEFT JOIN appointments a ON t.appointment_id = a.appointment_id " &
                      "LEFT JOIN treatments tm ON t.treatment_id = tm.treatment_id " &
                      "ORDER BY t.transaction_id DESC LIMIT 25"
            Else
                sql = "SELECT t.transaction_id, p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS Patients, " &
                      "a.appointment_id, a.appointment_date, t.treatment_id, tm.treatment_name, " &
                      "t.price, t.amount_paid, t.amount_tendered " &
                      "FROM transactions t " &
                      "LEFT JOIN patients p ON t.patient_id = p.patient_id " &
                      "LEFT JOIN appointments a ON t.appointment_id = a.appointment_id " &
                      "LEFT JOIN treatments tm ON t.treatment_id = tm.treatment_id " &
                      "WHERE t.transaction_id = " & tID
            End If

            Dim cmd As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "transactions")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "transactions"
            MsgBox("Transaction data loaded: " & ds.Tables("transactions").Rows.Count)

        Catch ex As MySqlException
            MsgBox("Error fetching data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tb1_TextChanged(sender As Object, e As EventArgs) Handles tb1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles tb3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tb2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles tb4.TextChanged

    End Sub

    Private Sub S_pID_Click(sender As Object, e As EventArgs) Handles S_pID.Click
        Dim pID = tb2.Text

        Try
            conn.Open()

            If pID = "" Then
                sql = "SELECT p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS Patients, " &
                      "t.transaction_id, a.appointment_id, a.appointment_date, t.treatment_id, tm.treatment_name, " &
                      "t.price, t.amount_paid, t.amount_tendered " &
                      "FROM patients p " &
                      "LEFT JOIN transactions t ON p.patient_id = t.patient_id " &
                      "LEFT JOIN appointments a ON t.appointment_id = a.appointment_id " &
                      "LEFT JOIN treatments tm ON t.treatment_id = tm.treatment_id " &
                      "ORDER BY p.patient_id DESC LIMIT 25"
            Else
                sql = "SELECT p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS Patients, " &
                      "t.transaction_id, a.appointment_id, a.appointment_date, t.treatment_id, tm.treatment_name, " &
                      "t.price, t.amount_paid, t.amount_tendered " &
                      "FROM patients p " &
                      "LEFT JOIN transactions t ON p.patient_id = t.patient_id " &
                      "LEFT JOIN appointments a ON t.appointment_id = a.appointment_id " &
                      "LEFT JOIN treatments tm ON t.treatment_id = tm.treatment_id " &
                      "WHERE p.patient_id = " & pID
            End If

            Dim cmd As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "patients")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "patients"
            MsgBox("Transaction data loaded: " & ds.Tables("patients").Rows.Count)

        Catch ex As MySqlException
            MsgBox("Error fetching data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ins_Click(sender As Object, e As EventArgs) Handles ins.Click
        Dim tID As String = tb1.Text
        Dim pID As String = tb2.Text
        Dim amount_date As String = tb3.Text

        Dim userID As Integer = 0

        Try
            conn.Open()
            sql = "INSERT INTO appointments (appointment_id, patients_patient_id, employees_employee_id, appointment_date) " &
              "VALUES (" & tID & ", " & pID & ", " & amount_date & "')"

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

    Private Sub del_Click(sender As Object, e As EventArgs) Handles del.Click
        Dim tID As String = Val(tb1.Text)
        Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this transaction record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirmDelete = DialogResult.Yes Then
            Try
                conn.Open()
                Dim sql As String = "DELETE FROM transactions WHERE transaction_id = " & tID
                Dim cmd As New MySqlCommand(sql, conn)
                Dim rowsDeleted As Integer = cmd.ExecuteNonQuery()

                MsgBox(If(rowsDeleted > 0, "Transaction record deleted.", "No record was deleted."))

            Catch ex As MySqlException
                MsgBox("Error deleting : " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("Deletion cancelled.")
        End If

    End Sub
End Class