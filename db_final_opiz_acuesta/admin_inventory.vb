Imports MySql.Data.MySqlClient

Public Class admin_inventory
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ins.Click
        Dim iID = tb1.Text
        Dim item_name = tb2.Text
        Dim qty = tb3.Text
        Dim price = tb4.Text
        Dim sID = tb5.Text
        Dim exp_date = tb6.Value.ToString("yyyy-MM-dd")
        Dim doA = tb7.Value.ToString("yyyy-MM-dd")

        Try
            conn.Open()
            sql = "INSERT INTO inventory(item_id, item_name, quantity, item_price, supplier_id, expiration_date, date_of_acquirement) " &
                  "VALUES('" & iID & "' , '" & item_name & "' , '" & qty & "' , '" & price & "' , '" & sID & "' , '" & exp_date & "' , '" & doA & "')"
            Dim dbcomm As New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("inventory inserted successfully")
            Else
                MsgBox("Insertion failed")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles s_ID.Click
        Dim iID = tb1.Text
        Try
            If iID = "" Then
                sql = "Select item_id, item_name, quantity, item_price, supplier_id, expiration_date, date_of_acquirement " &
                  "FROM inventory"
            Else
                sql = "SELECT item_id, item_name, quantity, item_price, supplier_id, expiration_date, date_of_acquirement " &
                  "FROM inventory " &
                  "WHERE item_id = " & iID
            End If

            Dim cmd As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "inventory")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "inventory"
            MsgBox("Patient data loaded: " & ds.Tables("inventory").Rows.Count)

        Catch ex As MySqlException
            MsgBox("Error fetching data: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub upd_Click(sender As Object, e As EventArgs) Handles upd.Click
        Dim iID = tb1.Text
        Dim item_name = tb2.Text
        Dim qty = tb3.Text
        Dim price = tb4.Text
        Dim sID = tb5.Text
        Dim exp_date = tb6.Value.ToString("yyyy-MM-dd")
        Dim doA = tb7.Value.ToString("yyyy-MM-dd")

        Dim updateFields As New List(Of String)

        If Not String.IsNullOrWhiteSpace(tb1.Text) Then updateFields.Add("item_id = '" & tb1.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb2.Text) Then updateFields.Add("item_name = '" & tb2.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb3.Text) Then updateFields.Add("quantity = '" & tb3.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb4.Text) Then updateFields.Add("price = '" & tb4.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb5.Text) Then updateFields.Add("supplier_id = '" & tb6.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb6.Text) Then updateFields.Add("expiration_date = '" & tb6.Value.ToString("yyyy-MM-dd") & "'")
        If Not String.IsNullOrWhiteSpace(tb7.Text) Then updateFields.Add("date_of_acquirement = '" & tb7.Value.ToString("yyyy-MM-dd") & "'")

        If updateFields.Count > 0 Then
            Try
                Dim sql As String = "UPDATE inventory SET " & String.Join(", ", updateFields) & " WHERE item_id = " & iID
                Dim cmd As New MySqlCommand(sql, conn)
                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                MsgBox(If(rowsAffected > 0, "inventory info updated.", "No record was updated."))
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
        Dim iID = tb1.Text
        Dim confirmMessage As String = "Are you sure you want to delete this item?"
        Try
            conn.Open()
            Dim result As DialogResult = MessageBox.Show(confirmMessage, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then
                conn.Close()
                Exit Sub
            End If

            sql = "DELETE FROM inventory WHERE item_id = " & iID
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

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        Admin_Menu.Show()
    End Sub
End Class