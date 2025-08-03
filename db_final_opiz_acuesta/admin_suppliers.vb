Imports MySql.Data.MySqlClient

Public Class admin_suppliers
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        Admin_Menu.Show()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim sID = tb1.Text
        Dim name = tb2.Text
        Dim address = tb3.Text
        Dim email = tb4.Text
        Dim contact = tb5.Text
        Dim iName = tb6.Text
        Dim iID = tb7.Text


        Try
            conn.Open()
            sql = "INSERT INTO suppliers(supplier_id, supplier_name, address, email, contact_number)" &
                  "VALUES('" & sID & "' , '" & name & "' , '" & address & "' , '" & email & "' , '" & contact & "')"
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sID As String = tb1.Text
        Try
            conn.Open()
            If sID = "" Then
                sql = "SELECT s.supplier_id, s.supplier_name, s.address, s.email, s.contact_number, i.item_id, i.item_name " &
                      "FROM suppliers s " &
                      "LEFT JOIN inventory i ON s.supplier_id = i.supplier_id "
            Else
                sql = "SELECT s.supplier_id, s.supplier_name, s.address, s.email, s.contact_number, i.item_id, i.item_name " &
                      "FROM suppliers s " &
                      "LEFT JOIN inventory i On s.supplier_id = i.supplier_id " &
                      "WHERE s.supplier_id = " & sID
            End If
            Dim dbcomm As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "suppliers")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "suppliers"
            MsgBox("Rows fetched: " & ds.Tables("suppliers").Rows.Count)


        Catch ex As MySqlException
            Dim unused = MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim iID As String = tb7.Text
        Try
            conn.Open()
            If iID = "" Then
                sql = "SELECT i.item_id, i.item_name, s.supplier_id, s.supplier_name, s.address, s.email, s.contact_number " &
                      "FROM suppliers s " &
                      "LEFT JOIN inventory i ON s.supplier_id = i.supplier_id"
            Else
                sql = "SELECT i.item_id, i.item_name, s.supplier_id, s.supplier_name, s.address, s.email, s.contact_number " &
                      "FROM suppliers s " &
                      "LEFT JOIN inventory i On s.supplier_id = i.supplier_id " &
                      "WHERE i.item_id = " & iID
            End If
            Dim dbcomm As New MySqlCommand(sql, conn)
            dataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            dataAdapter1.Fill(ds, "suppliers")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "suppliers"
            MsgBox("Rows fetched: " & ds.Tables("suppliers").Rows.Count)


        Catch ex As MySqlException
            Dim unused = MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sID = tb1.Text
        Dim updateFields As New List(Of String)

        If Not String.IsNullOrWhiteSpace(tb2.Text) Then updateFields.Add("supplier_name = '" & tb2.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb3.Text) Then updateFields.Add("address = '" & tb3.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb3.Text) Then updateFields.Add("email = '" & tb4.Text & "'")
        If Not String.IsNullOrWhiteSpace(tb7.Text) Then updateFields.Add("contact_number = '" & tb5.Text & "'")

        If updateFields.Count > 0 Then
            Try
                Dim sql As String = "UPDATE suppliers SET " & String.Join(", ", updateFields) & " WHERE supplier_id = " & sID
                Dim cmd As New MySqlCommand(sql, conn)
                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                MsgBox(If(rowsAffected > 0, "Supplier info updated.", "No record was updated."))
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
        Dim sID As String = Val(tb1.Text)
        Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this patient record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirmDelete = DialogResult.Yes Then
            Try
                conn.Open()
                Dim sql As String = "DELETE FROM suppliers WHERE supplier_id = " & sID
                Dim cmd As New MySqlCommand(sql, conn)
                Dim rowsDeleted As Integer = cmd.ExecuteNonQuery()

                MsgBox(If(rowsDeleted > 0, "Supplier record deleted.", "No record was deleted."))

            Catch ex As MySqlException
                MsgBox("Error deleting supplier: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("Deletion cancelled.")
        End If

    End Sub
End Class