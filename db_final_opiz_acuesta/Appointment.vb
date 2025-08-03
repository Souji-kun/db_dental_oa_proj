Imports mySql.Data.MySqlClient
Public Class Appointment

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler tb1.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb2.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb3.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb4.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb5.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb6.KeyDown, AddressOf TextBox_KeyDown
        AddHandler tb7.KeyDown, AddressOf TextBox_KeyDown
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Select Case DirectCast(sender, Control).Name
                Case "tb1" : tb2.Focus()
                Case "tb2" : tb3.Focus()
                Case "tb3" : tb4.Focus()
                Case "tb4" : tb5.Focus()
                Case "tb5" : tb6.Focus()
                Case "tb6" : tb7.Focus()
                Case "tb7" : btn1.Focus()
            End Select
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        ' Validate each textbox
        If String.IsNullOrWhiteSpace(tb1.Text) OrElse
       String.IsNullOrWhiteSpace(tb2.Text) OrElse
       String.IsNullOrWhiteSpace(tb3.Text) OrElse
       String.IsNullOrWhiteSpace(tb4.Text) OrElse
       String.IsNullOrWhiteSpace(tb5.Text) OrElse
       String.IsNullOrWhiteSpace(tb6.Text) OrElse
       String.IsNullOrWhiteSpace(tb7.Text) Then
            MsgBox("Please fill out all fields before continuing.")
            Exit Sub
        End If

        ' Collect data
        Dim patientData As New Dictionary(Of String, String)
        patientData("first_name") = tb1.Text
        patientData("last_name") = tb2.Text
        patientData("middle_name") = tb3.Text
        patientData("birth_date") = tb4.Text
        patientData("address") = tb5.Text
        patientData("contact_number") = tb6.Text
        patientData("email_address") = tb7.Text

        ' Open second form and pass data
        Dim previewForm As New appointment2(patientData, currentUserID)
        previewForm.Show()
        Me.Hide()

    End Sub

    Public Property currentUserID As Integer

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        About_Us.Show()
    End Sub
End Class
