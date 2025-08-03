Imports MySql.Data.MySqlClient


Public Class admin_users
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim uName = tb1.Text
        Dim pwd = tb2.Text
        Dim email = tb3.Text
        Try
            conn.Open()
            sql = "INSERT INTO users(username, password, email_address) " &
                  "VALUES('" & uName & "' , '" & pwd & "' , '" & email & "')"

            Dim dbcomm As New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("User Info inserted successfully")
            Else
                MsgBox("Insertion failed")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim uID As String = tb1.Text
        Try
            conn.Open()
            If String.IsNullOrWhiteSpace(uID) Then
                sql = "SELECT u.user_id, u.username, u.password, u.email_address, " &
                      "p.patient_id, concat(p.first_name,' ',p.last_name)as Patient " &
                      "FROM users u " &
                      "LEFT JOIN patients p ON u.user_id = p.users_user_id " &
                      "ORDER BY u.user_id ASC " &
                      "LIMIT 100"
            Else
                sql = "SELECT u.user_id, u.username, u.password, u.email_address, " &
                      "p.patient_id, concat(p.first_name,' ',p.last_name)as Patient " &
                      "FROM users u " &
                      "LEFT JOIN patients p ON u.user_id = p.users_user_id " &
                      "WHERE u.user_id = " & uID
            End If

            Dim dbcomm As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "users")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "users"
            MsgBox("Rows fetched: " & ds.Tables("users").Rows.Count)


        Catch ex As MySqlException
            Dim unused = MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uID = tb1.Text
        Dim uName = tb2.Text
        Dim pwd = tb3.Text
        Dim email = tb4.Text
        Dim updateFields As New List(Of String)

        If Not String.IsNullOrWhiteSpace(tb1.Text) Then updateFields.Add("user_id = '" & tb1.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb2.Text) Then updateFields.Add("username = '" & tb2.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb3.Text) Then updateFields.Add("password = '" & tb3.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb4.Text) Then updateFields.Add("email_address = '" & tb4.Text & "'")
        If updateFields.Count > 0 Then
            Try
                Dim sql As String = "UPDATE users SET " & String.Join(", ", updateFields) & " WHERE user_id = " & uID
                Dim cmd As New MySqlCommand(sql, conn)
                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                MsgBox(If(rowsAffected > 0, "user info updated.", "No record was updated."))
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("No fields to update. Please fill in at least one value.")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim uID = tb1.Text
        Dim confirmMessage As String = "Are you sure you want to delete this user?"
        Try
            conn.Open()
            Dim result As DialogResult = MessageBox.Show(confirmMessage, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then
                conn.Close()
                Exit Sub
            End If

            sql = "DELETE FROM users WHERE item_id = " & uID
            Dim deleteCmd As New MySqlCommand(sql, conn)
            Dim i As Integer = deleteCmd.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("User deleted successfully.")
            Else
                MsgBox("Deletion failed.")
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