<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.tb1 = New System.Windows.Forms.TextBox()
        Me.lb1 = New System.Windows.Forms.Label()
        Me.lb2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Transparent
        Me.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.ForeColor = System.Drawing.Color.Transparent
        Me.btn1.Location = New System.Drawing.Point(401, 470)
        Me.btn1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(277, 71)
        Me.btn1.TabIndex = 35
        Me.btn1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.Transparent
        Me.btn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2.ForeColor = System.Drawing.Color.Transparent
        Me.btn2.Location = New System.Drawing.Point(967, 34)
        Me.btn2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(63, 59)
        Me.btn2.TabIndex = 36
        Me.btn2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn2.UseVisualStyleBackColor = False
        '
        'tb1
        '
        Me.tb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb1.Location = New System.Drawing.Point(557, 405)
        Me.tb1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tb1.Name = "tb1"
        Me.tb1.Size = New System.Drawing.Size(249, 53)
        Me.tb1.TabIndex = 37
        '
        'lb1
        '
        Me.lb1.AutoSize = True
        Me.lb1.BackColor = System.Drawing.Color.Transparent
        Me.lb1.Font = New System.Drawing.Font("MV Boli", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb1.ForeColor = System.Drawing.Color.White
        Me.lb1.Location = New System.Drawing.Point(422, 218)
        Me.lb1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb1.Name = "lb1"
        Me.lb1.Size = New System.Drawing.Size(61, 62)
        Me.lb1.TabIndex = 38
        Me.lb1.Text = "0"
        Me.lb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb2
        '
        Me.lb2.AutoSize = True
        Me.lb2.BackColor = System.Drawing.Color.Transparent
        Me.lb2.Font = New System.Drawing.Font("MV Boli", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb2.ForeColor = System.Drawing.Color.White
        Me.lb2.Location = New System.Drawing.Point(498, 289)
        Me.lb2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb2.Name = "lb2"
        Me.lb2.Size = New System.Drawing.Size(323, 50)
        Me.lb2.TabIndex = 39
        Me.lb2.Text = "Dental CLeaning"
        Me.lb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Payment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.db_final_opiz_acuesta.My.Resources.Resources._41
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1085, 599)
        Me.Controls.Add(Me.lb2)
        Me.Controls.Add(Me.lb1)
        Me.Controls.Add(Me.tb1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Payment"
        Me.Text = "Payment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn1 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents tb1 As TextBox
    Friend WithEvents lb1 As Label
    Friend WithEvents lb2 As Label
End Class
