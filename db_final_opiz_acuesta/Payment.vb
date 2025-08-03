Imports MySql.Data.MySqlClient

Public Class Payment
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost; Database=db_dental; Uid=root; Pwd=;")
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public dataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Hide()
        About_Us.Show()
    End Sub

    Private appointmentData As Dictionary(Of String, Object)
    Private storedPatientID As Integer
    Private storedTreatmentID As Integer
    Private storedAppointmentID As Integer
    Private storedPatientName As String
    Private storedAppointmentDate As String
    Private storedTreatmentName As String
    Private storedTreatmentPrice As Integer

    Private treatments As New Dictionary(Of Integer, Tuple(Of String, Integer)) From {
    {1, Tuple.Create("Dental Cleaning", 1200)},
    {2, Tuple.Create("Dental Whitening", 6000)},
    {3, Tuple.Create("Dental Implants", 80000)},
    {4, Tuple.Create("Dental X-Ray", 1000)},
    {5, Tuple.Create("Tooth Extraction", 1500)},
    {6, Tuple.Create("Dental Fillings", 1500)},
    {7, Tuple.Create("Braces/Orthodontics", 60000)},
    {8, Tuple.Create("Root Canal Treatment", 8000)}
}

    Public Sub New(data As Dictionary(Of String, Object), patientName As String, treatmentDate As DateTime, treatmentName As String)
        InitializeComponent()
        appointmentData = data
        storedPatientName = patientName
        storedAppointmentDate = treatmentDate
        storedTreatmentName = treatmentName
        storedPatientID = appointmentData("patient_id")
        storedTreatmentID = appointmentData("treatment_id")
        storedAppointmentID = appointmentData("appointment_id")
        storedAppointmentDate = appointmentData("appointment_date")
        storedTreatmentPrice = appointmentData("price")

        If treatments.ContainsKey(storedTreatmentID) Then
            lb2.Text = treatments(storedTreatmentID).Item1 ' Treatment Name
            lb1.Text = treatments(storedTreatmentID).Item2.ToString() ' Treatment Price
        Else
            lb2.Text = "Unknown Treatment"
            lb1.Text = "0"
        End If
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lb1.Click

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim paymentAmount As Integer
        Dim treatmentCost As Integer

        If Integer.TryParse(tb1.Text, paymentAmount) Then
            If Integer.TryParse(lb1.Text, treatmentCost) Then
                Dim amountTendered As Integer = paymentAmount - treatmentCost

                ' Payment logic
                If paymentAmount < treatmentCost Then
                    MsgBox("Payment is not enough. Required: ₱" & treatmentCost, MsgBoxStyle.Exclamation)
                Else
                    Dim change As Integer = paymentAmount - treatmentCost
                    MsgBox("Payment accepted! Change: ₱" & change, MsgBoxStyle.Information)

                    ' DB insert only if payment is valid
                    Try
                        conn.Open()
                        sql = "INSERT INTO transactions(patient_id, name, appointment_date, treatment_id, treatment_name, price, amount_paid, amount_tendered, appointment_id, status)" &
                      "VALUES('" & storedPatientID & "' , '" & storedPatientName & "' , '" & storedAppointmentDate & "' , '" & storedTreatmentID & "' ,'" & storedTreatmentName & "' , '" & storedTreatmentPrice & "' , '" & paymentAmount & "' , '" & amountTendered & "' , '" & storedAppointmentID & "', 'processing')"

                        Dim dbcomm As New MySqlCommand(sql, conn)
                        Dim i As Integer = dbcomm.ExecuteNonQuery()
                        Dim receiptForm As New receipt(storedTreatmentName, storedTreatmentPrice, paymentAmount, amountTendered)
                        receiptForm.Show()

                        If i > 0 Then
                            MsgBox("Thank You for Choosing our service, you may now check your appointment in your profile page!!")
                        End If
                    Catch ex As Exception
                        MsgBox("Error: " & ex.Message)
                    Finally
                        conn.Close()
                    End Try
                End If
            Else
                MsgBox("Could not determine treatment cost.", MsgBoxStyle.Critical)
            End If
        ElseIf tb1.Text <> "" Then
            MsgBox("Please enter a valid numeric payment.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lb2_Click(sender As Object, e As EventArgs) Handles lb2.Click

    End Sub

    Private Sub tb1_TextChanged(sender As Object, e As EventArgs) Handles tb1.TextChanged

    End Sub
    Public Sub SetLabelText(value As String)
        lb2.Text = value
    End Sub
End Class