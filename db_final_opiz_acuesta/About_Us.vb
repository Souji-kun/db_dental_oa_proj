Public Class About_Us
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
End Class