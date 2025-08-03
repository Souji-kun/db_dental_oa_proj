Imports MySql.Data.MySqlClient

Public Class signup
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet

    Private patientInfo As Dictionary(Of String, String)
    Private currentUserID As Integer


    Public Sub New(Optional uname As String = "", Optional pwd As String = "", Optional data As Dictionary(Of String, String) = Nothing)
        InitializeComponent()
        tb1.Text = uname
        tb2.Text = pwd
        patientInfo = data
    End Sub

    Public Shared Function CreateWithPatientData(data As Dictionary(Of String, String)) As signup
        Dim form As New signup("", "") ' default login values
        form.patientInfo = data
        Return form
    End Function


    Private Sub signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tb1.Text = login.tb1.Text
        tb2.Text = login.tb2.Text
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uname = tb1.Text.Trim()
        Dim pwd = tb2.Text.Trim()
        Dim confirmPwd = tb3.Text.Trim()

        If pwd <> confirmPwd Then
            MsgBox("Error: Passwords do not match.")
            Exit Sub
        End If

        Try
            conn.Open()

            sql = "INSERT INTO users(username, password) VALUES('" & uname & "', '" & pwd & "')"
            Dim dbcomm As New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery()

            sql = "SELECT LAST_INSERT_ID()"
            dbcomm = New MySqlCommand(sql, conn)
            currentUserID = Convert.ToInt32(dbcomm.ExecuteScalar())

            If i > 0 Then
                MsgBox("User Account has been created successfully")

                If patientInfo IsNot Nothing Then
                    Dim form As New appointment2(patientInfo, currentUserID)
                    form.Show()
                Else
                    Dim form As New Appointment()
                    form.currentUserID = currentUserID
                    form.Show()
                End If

                Me.Hide()
            Else
                MsgBox("There is a problem within the system, kindly contact or ask nearby staff for assistance :>")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

End Class