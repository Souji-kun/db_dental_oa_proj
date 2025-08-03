Imports MySql.Data.MySqlClient

Public Class About_Us
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub About_Us_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Me.Hide()
        Services.Show()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Dim userInput As String = InputBox("", "")

        Select Case userInput.Trim().ToLower()
            Case "admin_db@dental"
                Me.Hide()
                Admin_Menu.Show()
            Case "staff_db@dental"
                Me.Hide()
                staff_menu.Show()
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim username As String = InputBox("Enter your username:", "Login")
        Dim password As String = InputBox("Enter your password:", "Login")

        If username = "" Or password = "" Then
            MsgBox("Both fields are required.")
            Exit Sub
        End If

        Try
            conn.Open()
            sql = "SELECT user_id FROM users WHERE username = '" & username & "' AND password = '" & password & "'"
            Dim cmd As New MySqlCommand(sql, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim userID As Integer = reader.GetInt32("user_id")
                reader.Close()

                Dim updateSql As String = "UPDATE users SET status = 'logged' WHERE user_id = " & userID
                Dim updateCmd As New MySqlCommand(updateSql, conn)
                updateCmd.ExecuteNonQuery()
                Dim ui As New user_interface(userID, username)
                Me.Hide()
                ui.Show()
            Else
                MsgBox("Invalid username or password.")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class