Public Class receipt
    ' Declare variables to store values passed in
    Private treatmentName As String
    Private cost As Integer
    Private paid As Integer
    Private tendered As Integer

    ' Constructor to accept values
    Public Sub New(name As String, price As Integer, paidAmount As Integer, tenderedAmount As Integer)
        InitializeComponent()
        treatmentName = name
        cost = price
        paid = paidAmount
        tendered = tenderedAmount
    End Sub


    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        About_Us.Show()
    End Sub


    Private Sub receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lb2.Text = treatmentName
        lb1.Text = "₱" & cost.ToString()
        lb3.Text = "₱" & paid.ToString()
        lb4.Text = "₱" & tendered.ToString()
    End Sub
End Class