Imports MySql.Data.MySqlClient

Public Class staff_inventory
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub s_tID_Click(sender As Object, e As EventArgs) Handles s_tID.Click
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

    Private Sub tb6_ValueChanged(sender As Object, e As EventArgs) Handles tb6.ValueChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tb1.Clear()
        tb2.Clear()
        tb3.Clear()
        tb4.Clear()
        tb5.Clear()
        tb6.Value = Date.Today
        tb7.Value = Date.Today
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        staff_menu.Show()
    End Sub
End Class