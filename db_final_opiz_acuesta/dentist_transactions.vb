Imports MySql.Data.MySqlClient
Public Class dentist_transactions
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
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

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        dentist_menu.Show()
    End Sub

    Private Sub ins_Click(sender As Object, e As EventArgs) Handles ins.Click
        Dim tID As String = tb1.Text
        Dim pID As String = tb2.Text
        Dim aID As String = tb3.Text
        Dim tmID As String = tb4.Text
        Dim tmName As String = tb5.Text
        Dim total As Decimal = Convert.ToDecimal(tb6.Text)
        Dim amountPaid As Decimal = Convert.ToDecimal(tb7.Text)
        Dim amountTendered As Decimal = amountPaid - total
        Dim selectedDate As String = tb8.Value.ToString("yyyy-MM-dd")
        Dim selectedTime As String = ""


        If rb_8to9.Checked Then
            selectedTime = "08:00:00"
        ElseIf rb_9to10.Checked Then
            selectedTime = "09:00:00"
        ElseIf rb_10to11.Checked Then
            selectedTime = "10:00:00"
        ElseIf rb_11to12.Checked Then
            selectedTime = "11:00:00"
        ElseIf rb_12to1.Checked Then
            selectedTime = "12:00:00"
        ElseIf rb_1to2.Checked Then
            selectedTime = "13:00:00"
        ElseIf rb_2to3.Checked Then
            selectedTime = "14:00:00"
        ElseIf rb_3to4.Checked Then
            selectedTime = "15:00:00"
        ElseIf rb_4to5.Checked Then
            selectedTime = "16:00:00"
        Else
            MsgBox("Please select a time slot.")
            Exit Sub
        End If

        Dim fullDateTime As String = selectedDate & " " & selectedTime
        Try
            conn.Open()
            ' Get latest med history ID
            sql = "SELECT md_id FROM medical_history WHERE patients_patient_id = '" & pID & "' ORDER BY patients_patient_id DESC LIMIT 1"
            Dim dbcomm1 As New MySqlCommand(sql, conn)
            Dim medHistoryID As String = Convert.ToString(dbcomm1.ExecuteScalar())

            sql = "SELECT * FROM patients WHERE patient_id = '" & pID & "' AND medical_history_md_id = '" & medHistoryID & "'"
            ' Insert appointment
            Dim eID As Integer = 1
            sql = "INSERT INTO appointments(appointment_date, patients_patient_id, patients_medical_history_md_id, employees_employee_id, treatments_treatment_id, status) " &
                  "VALUES('" & fullDateTime & "' , '" & pID & "' , '" & medHistoryID & "' , '" & eID & "','" & tmID & "' , 'pending')"
            Dim dbcomm2 As New MySqlCommand(sql, conn)
            dbcomm2.ExecuteNonQuery()

            ' Fetch the latest appointment_id just inserted
            sql = "SELECT appointment_id FROM appointments WHERE patients_patient_id = '" & pID & "' ORDER BY appointment_date DESC LIMIT 1"
            Dim dbcomm3 As New MySqlCommand(sql, conn)
            Dim latestAppointmentID As String = Convert.ToString(dbcomm3.ExecuteScalar())

            ' Insert transaction linked to the appointment
            sql = "INSERT INTO transactions (transaction_id, patient_id, appointment_id, appointment_date, treatment_id, treatment_name, price, amount_paid, amount_tendered, status) " &
                  "VALUES ('" & tID & "', '" & pID & "', '" & latestAppointmentID & "', '" & fullDateTime & "', '" & tmID & "', '" & tmName & "', '" & total & "', '" & amountPaid & "', '" & amountTendered & "', 'processing')"
            Dim dbcomm4 As New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm4.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("Transactions inserted successfully")
            Else
                MsgBox("Insertion failed")
            End If

        Catch ex As MySqlException
            MsgBox("Error fetching data: " & ex.Message)
        Finally
            conn.Close()
        End Try

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

    Private Sub upd_Click(sender As Object, e As EventArgs) Handles upd.Click
        Dim tID = tb1.Text
        Dim updateFields As New List(Of String)
        Dim amountTendered = Val(tb7.Text) - Val(tb6.Text)

        If Not String.IsNullOrWhiteSpace(tb2.Text) Then updateFields.Add("patient_id = '" & tb2.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb3.Text) Then updateFields.Add("appointment_id = '" & tb3.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb4.Text) Then updateFields.Add("treatment_id = '" & tb4.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb5.Text) Then updateFields.Add("treatment_name = '" & tb5.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb6.Text) Then updateFields.Add("price = '" & tb6.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb7.Text) Then updateFields.Add("amount_paid = '" & tb7.Text & "'")

        If updateFields.Count > 0 Then
            Try
                Dim sql As String = "UPDATE transactions SET " &
                                    String.Join(", ", updateFields) &
                                    ", amount_tendered = '" & amountTendered.ToString() & "' " &
                                    "WHERE transaction_id = '" & tID & "'"

                Dim cmd As New MySqlCommand(sql, conn)
                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                MsgBox(If(rowsAffected > 0, "Transaction info updated.", "No record was updated."))
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("No fields to update. Please fill in at least one value.")
        End If
    End Sub

    Private Sub del_Click(sender As Object, e As EventArgs) Handles del.Click
        tb1.Clear()
        tb2.Clear()
        tb3.Clear()
        tb4.Clear()
        tb5.Clear()
        tb6.Clear()
        tb7.Clear()
        tb8.Value = Date.Today
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
    End Sub
End Class