Imports MySql.Data.MySqlClient

Public Class login
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_signup.Click
        Dim uname As String = tb1.Text
        Dim pwd As String = tb2.Text
        Dim signupForm As New signup(uname, pwd)
        signupForm.Show()
        Me.Hide()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim uname = tb1.Text.Trim()
        Dim pwd = tb2.Text.Trim()
        Dim currentUserID As Integer = 0

        Try
            conn.Open()

            sql = "SELECT user_id FROM users WHERE username = '" & uname & "' AND password = '" & pwd & "'"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()

            If dbread.Read() Then
                currentUserID = Convert.ToInt32(dbread("user_id"))
                MsgBox("User login successful")

                conn.Close()
                conn.Open()

                ' Check if user has matching patient entry
                sql = "SELECT * FROM patients WHERE users_user_id = " & currentUserID
                dbcomm = New MySqlCommand(sql, conn)
                dbread = dbcomm.ExecuteReader()

                If dbread.Read() Then
                    Dim patientData As New Dictionary(Of String, String) From {
                    {"patient_id", dbread("patient_id").ToString()},
                    {"first_name", dbread("first_name").ToString()},
                    {"last_name", dbread("last_name").ToString()},
                    {"middle_name", dbread("middle_name").ToString()},
                    {"birth_date", Convert.ToDateTime(dbread("birth_date")).ToString("yyyy-MM-dd")},
                    {"address", dbread("address").ToString()},
                    {"contact_number", dbread("contact_number").ToString()},
                    {"email_address", dbread("email_address").ToString()}
                }
                    Dim form As New appointment2(patientData, currentUserID)
                    form.Show()
                Else
                    MsgBox("No patient record found for this user.")
                    Dim form As New Appointment()
                    form.currentUserID = currentUserID
                    form.Show()
                End If

                Me.Hide()
            Else
                MsgBox("Invalid username or password.")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Property currentUserID As Integer

    Private Sub tb1_TextChanged(sender As Object, e As EventArgs) Handles tb1.TextChanged


    End Sub
End Class