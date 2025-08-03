Public Class thank_you
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        About_Us.Show()
    End Sub

    Private Sub thank_you_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Thank you for using our service!!!")
        Me.Hide()
        About_Us.Show()
    End Sub
End Class