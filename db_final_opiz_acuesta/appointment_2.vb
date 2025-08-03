Imports MySql.Data.MySqlClient

Public Class appointment2
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet

    Private patientInfo As Dictionary(Of String, String)
    Private currentUserID As Integer


    Private Sub PopulateFieldsFromInfo()
        If patientInfo.ContainsKey("medical_desc") Then
            tb8.Text = patientInfo("medical_desc")
        End If
    End Sub

    Public Sub New(data As Dictionary(Of String, String), userID As Integer)
        InitializeComponent()
        patientInfo = data
        currentUserID = userID
    End Sub


    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim selectedTime As String = ""
        Dim selectedTreatmentID As Integer = Convert.ToInt32(cb1.SelectedValue)
        Dim medicalDesc As String = tb8.Text.Trim()
        Dim patientID As Integer = 0


        ' Determine selected time slot from RadioButtons
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
            sql = "SELECT patient_id FROM patients WHERE users_user_id = " & currentUserID
            Dim checkCmd As New MySqlCommand(sql, conn)
            Dim existingPatientId = checkCmd.ExecuteScalar()

            Dim userEmail As String = patientInfo("email_address")
            sql = "UPDATE users SET email_address = '" & patientInfo("email_address") & "' WHERE user_id = " & currentUserID
            Dim updateUserCmd As New MySqlCommand(sql, conn)
            updateUserCmd.ExecuteNonQuery()

            If existingPatientId IsNot Nothing Then
                patientID = Convert.ToInt32(existingPatientId)
            Else
                '1. Insert the patient
                sql = "INSERT INTO patients (first_name, last_name, middle_name, birth_date, address, contact_number, email_address, treatments_treatment_id, users_user_id) " &
                      "VALUES ('" & patientInfo("first_name") & "', '" & patientInfo("last_name") & "', '" & patientInfo("middle_name") & "', '" &
                      DateTime.Parse(patientInfo("birth_date")).ToString("yyyy-MM-dd") & "', '" & patientInfo("address") & "', '" &
                      patientInfo("contact_number") & "', '" & userEmail & "', " & selectedTreatmentID & ", '" & currentUserID & "')"
                Dim insertPatientCmd As New MySqlCommand(sql, conn)
                Dim i As Integer = insertPatientCmd.ExecuteNonQuery()

                If i > 0 Then
                    sql = "SELECT LAST_INSERT_ID()"
                    Dim getIDCmd As New MySqlCommand(sql, conn)
                    patientID = Convert.ToInt32(getIDCmd.ExecuteScalar())
                Else
                    MsgBox("Failed to save patient record.")
                    Exit Sub
                End If
            End If

            ' Insert into medical_history first
            sql = "INSERT INTO medical_history (patients_patient_id, md_description) VALUES (" & patientID & ", '" & medicalDesc & "')"
            Dim insertHistoryCmd As New MySqlCommand(sql, conn)
            Dim k As Integer = insertHistoryCmd.ExecuteNonQuery()

            ' Now it's safe to fetch the inserted ID
            Dim newMdId As Integer = insertHistoryCmd.LastInsertedId

            ' Update patients table with the new md_id
            sql = "UPDATE patients SET medical_history_md_id = " & newMdId & " WHERE patient_id = " & patientID
            Dim updateCmd As New MySqlCommand(sql, conn)
            updateCmd.ExecuteNonQuery()

            MsgBox(If(k > 0, "Medical history saved and linked to patient.", "Failed to insert medical history."))

            ' 4. Insert appointment
            sql = "INSERT INTO appointments(patients_patient_id, appointment_date, status, employees_employee_id, treatments_treatment_id) " &
                  "VALUES (" & patientID & ", '" & fullDateTime & "' , 'pending', 1, '" & selectedTreatmentID & "')"
            Dim insertAppCmd As New MySqlCommand(sql, conn)
            Dim j As Integer = insertAppCmd.ExecuteNonQuery()
            Dim newAppID As Integer = insertAppCmd.LastInsertedId

            Dim drv As DataRowView = CType(cb1.SelectedItem, DataRowView)
            Dim selectedPrice As Integer = Convert.ToDecimal(drv("price"))
            Dim storedPatientID As Integer = patientID
            Dim storedTreatmentID As Integer = selectedTreatmentID
            Dim storedTreatmentName As String = cb1.GetItemText(cb1.SelectedItem)
            Dim storedAppointmentID As Integer = newAppID
            Dim storedPatientName As String = patientInfo("first_name") & " " & patientInfo("last_name")
            Dim storedTreatmentDate As Date = selectedDate

            Dim appointmentData As New Dictionary(Of String, Object)
            appointmentData("patient_id") = patientID
            appointmentData("treatment_id") = selectedTreatmentID
            appointmentData("appointment_id") = newAppID
            appointmentData("appointment_date") = fullDateTime
            appointmentData("price") = selectedPrice
            Dim nextForm As New Payment(appointmentData, storedPatientName, storedTreatmentDate, storedTreatmentName)
            nextForm.Show()
            Me.Hide()
        Catch ex As MySqlException
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        About_Us.Show()
    End Sub


    Private Sub appointment2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateFieldsFromInfo()
        Dim tooltip As New ToolTip()
        tooltip.SetToolTip(DateTimePicker1, "Sundays are unavailable for appointments.")

        If DateTimePicker1.Value.DayOfWeek = DayOfWeek.Sunday Then
            DateTimePicker1.Value = DateTimePicker1.Value.AddDays(1)
        End If


        Try
            conn.Open()
            sql = "SELECT treatment_id, treatment_name, price FROM treatments"
            Dim adapter As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            cb1.DataSource = dt
            cb1.DisplayMember = "treatment_name"   ' What the user sees
            cb1.ValueMember = "treatment_id" ' What you use in the insert

        Catch ex As Exception
            MsgBox("Error loading treatments: " & ex.Message)
        Finally
            conn.Close()
        End Try

        DateTimePicker1_ValueChanged(DateTimePicker1, EventArgs.Empty)

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim selectedDate As Date = DateTimePicker1.Value.Date
        Dim tooltip As New ToolTip()
        If DateTimePicker1.Value.DayOfWeek = DayOfWeek.Sunday Then
            MessageBox.Show("Clinic is closed on Sundays. Please select another date.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' Reset to next available day (e.g., Monday)
            DateTimePicker1.Value = DateTimePicker1.Value.AddDays(1)
        End If

        Try
            conn.Open()
            For Each ctrl As Control In gb1.Controls
                If TypeOf ctrl Is RadioButton Then
                    Dim rb As RadioButton = CType(ctrl, RadioButton)
                    Dim timeValue As String = ""

                    Select Case rb.Name
                        Case "rb_8to9" : timeValue = "08:00:00"
                        Case "rb_9to10" : timeValue = "09:00:00"
                        Case "rb_10to11" : timeValue = "10:00:00"
                        Case "rb_11to12" : timeValue = "11:00:00"
                        Case "rb_12to1" : timeValue = "12:00:00"
                        Case "rb_1to2" : timeValue = "13:00:00"
                        Case "rb_2to3" : timeValue = "14:00:00"
                        Case "rb_3to4" : timeValue = "15:00:00"
                        Case "rb_4to5" : timeValue = "16:00:00"
                    End Select

                    If TypeOf ctrl Is RadioButton Then
                        Select Case rb.Name
                            Case "rb_8to9" : timeValue = "08:00:00"
                            Case "rb_9to10" : timeValue = "09:00:00"
                            Case "rb_10to11" : timeValue = "10:00:00"
                            Case "rb_11to12" : timeValue = "11:00:00"
                            Case "rb_12to1" : timeValue = "12:00:00"
                            Case "rb_1to2" : timeValue = "13:00:00"
                            Case "rb_2to3" : timeValue = "14:00:00"
                            Case "rb_3to4" : timeValue = "15:00:00"
                            Case "rb_4to5" : timeValue = "16:00:00"
                        End Select

                        If timeValue <> "" Then
                            Dim fullSlotDateTime As DateTime = DateTime.Parse(selectedDate.ToString("yyyy-MM-dd") & " " & timeValue)
                            Dim isPastSlot As Boolean = (fullSlotDateTime < DateTime.Now)

                            sql = "SELECT COUNT(*) FROM appointments WHERE appointment_date = '" & fullSlotDateTime.ToString("yyyy-MM-dd HH:mm:ss") & "'"
                            Dim cmd As New MySqlCommand(sql, conn)
                            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                            Dim isSlotAvailable As Boolean = (count = 0 AndAlso Not isPastSlot)
                            rb.Enabled = isSlotAvailable
                            rb.Checked = False

                            If count > 0 Then
                                tooltip.SetToolTip(rb, "This slot is already booked.")
                            ElseIf isPastSlot Then
                                tooltip.SetToolTip(rb, "This slot has already passed.")
                            Else
                                tooltip.SetToolTip(rb, "Click to book this slot.")
                            End If

                            rb.ForeColor = If(isPastSlot, Color.Gray, Color.Black)
                        End If
                    End If

                End If
            Next
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

End Class