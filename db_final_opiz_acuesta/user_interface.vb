Imports MySql.Data.MySqlClient

Public Class user_interface
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet

    Private currentUserID As Integer
    Private Uname As String

    ' 📌 Constructor to accept and store userID
    Public Sub New(userID As Integer, username As String)
        InitializeComponent()
        currentUserID = userID
        Uname = username
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim patientID As Integer

        Try
            conn.Open()

            sql = "SELECT patient_id FROM patients WHERE users_user_id = " & currentUserID
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()

            If dbread.Read() Then
                patientID = Convert.ToInt32(dbread("patient_id"))
            End If
            dbread.Close()
            sql = "SELECT concat(p.first_name,' ',p.last_name)as Patient, a.appointment_date, t.treatment_name, concat(e.first_name,' ',e.last_name)as Dentist " &
                  "FROM appointments a " &
                  "LEFT JOIN patients p ON a.patients_patient_id = p.patient_id " &
                  "LEFT JOIN treatments t ON p.treatments_treatment_id = t.treatment_id " &
                  "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                  "WHERE a.patients_patient_id = " & patientID
            dbcomm = New MySqlCommand(sql, conn)
            dbcomm.ExecuteNonQuery()
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "patients")
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "patients"
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lbl1.Click

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Try
            conn.Open()
            sql = "UPDATE users SET status = 'notlogged' WHERE user_id = " & currentUserID
            dbcomm = New MySqlCommand(sql, conn)
            dbcomm.ExecuteNonQuery()
            Me.Hide()
            About_Us.Show()
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub user_interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl1.Text = "Welcome, " & Uname
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim patientID As Integer

        Try
            conn.Open()

            ' Step 1: Find patient_id using currentUserID
            sql = "SELECT patient_id FROM patients WHERE users_user_id = " & currentUserID
            Dim lookupCmd As New MySqlCommand(sql, conn)
            dbread = lookupCmd.ExecuteReader()

            If dbread.Read() Then
                patientID = Convert.ToInt32(dbread("patient_id"))
            Else
                MsgBox("No patient found for the current user.")
                conn.Close()
                Exit Sub
            End If
            dbread.Close()

            ' Step 2: Fetch transactions linked to the patient with dentist info
            sql = "SELECT t.transaction_id, CONCAT(p.first_name, ' ', p.last_name) AS Patient, " &
                  "a.appointment_date, " &
                  "CONCAT(e.first_name, ' ', e.last_name) AS Dentist, " &
                  "t.price, t.amount_paid, t.amount_tendered, t.status " &
                  "FROM transactions t " &
                  "LEFT JOIN patients p ON t.patient_id = p.patient_id " &
                  "LEFT JOIN appointments a ON t.appointment_id = a.appointment_id " &
                  "LEFT JOIN employees e ON a.employees_employee_id = e.employee_id " &
                  "WHERE t.patient_id = " & patientID

            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "transactions")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "transactions"

        Catch ex As MySqlException
        Finally
            conn.Close()
        End Try
    End Sub
End Class