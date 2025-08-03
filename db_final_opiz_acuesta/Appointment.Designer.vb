<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Appointment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tb1 = New System.Windows.Forms.TextBox()
        Me.tb2 = New System.Windows.Forms.TextBox()
        Me.tb3 = New System.Windows.Forms.TextBox()
        Me.tb5 = New System.Windows.Forms.TextBox()
        Me.tb6 = New System.Windows.Forms.TextBox()
        Me.tb7 = New System.Windows.Forms.TextBox()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.tb4 = New System.Windows.Forms.DateTimePicker()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb1
        '
        Me.tb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb1.Location = New System.Drawing.Point(193, 69)
        Me.tb1.Name = "tb1"
        Me.tb1.Size = New System.Drawing.Size(250, 26)
        Me.tb1.TabIndex = 0
        '
        'tb2
        '
        Me.tb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2.Location = New System.Drawing.Point(193, 101)
        Me.tb2.Name = "tb2"
        Me.tb2.Size = New System.Drawing.Size(250, 26)
        Me.tb2.TabIndex = 1
        '
        'tb3
        '
        Me.tb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb3.Location = New System.Drawing.Point(193, 133)
        Me.tb3.Name = "tb3"
        Me.tb3.Size = New System.Drawing.Size(250, 26)
        Me.tb3.TabIndex = 2
        '
        'tb5
        '
        Me.tb5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb5.Location = New System.Drawing.Point(193, 207)
        Me.tb5.Name = "tb5"
        Me.tb5.Size = New System.Drawing.Size(250, 26)
        Me.tb5.TabIndex = 4
        '
        'tb6
        '
        Me.tb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb6.Location = New System.Drawing.Point(193, 248)
        Me.tb6.Name = "tb6"
        Me.tb6.Size = New System.Drawing.Size(250, 26)
        Me.tb6.TabIndex = 5
        '
        'tb7
        '
        Me.tb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb7.Location = New System.Drawing.Point(193, 280)
        Me.tb7.Name = "tb7"
        Me.tb7.Size = New System.Drawing.Size(250, 26)
        Me.tb7.TabIndex = 6
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
        Me.btn1.Location = New System.Drawing.Point(263, 324)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(132, 37)
        Me.btn1.TabIndex = 7
        Me.btn1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn1.UseVisualStyleBackColor = False
        '
        'tb4
        '
        Me.tb4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb4.Location = New System.Drawing.Point(193, 172)
        Me.tb4.Name = "tb4"
        Me.tb4.Size = New System.Drawing.Size(250, 24)
        Me.tb4.TabIndex = 8
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
        Me.btn2.Location = New System.Drawing.Point(724, 28)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(47, 48)
        Me.btn2.TabIndex = 9
        Me.btn2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn2.UseVisualStyleBackColor = False
        '
        'Appointment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BackgroundImage = Global.db_final_opiz_acuesta.My.Resources.Resources.USER_APPOINTMENT1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(815, 488)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.tb4)
        Me.Controls.Add(Me.tb7)
        Me.Controls.Add(Me.tb6)
        Me.Controls.Add(Me.tb5)
        Me.Controls.Add(Me.tb3)
        Me.Controls.Add(Me.tb2)
        Me.Controls.Add(Me.tb1)
        Me.Controls.Add(Me.btn1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Appointment"
        Me.Text = "Appoointment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb1 As TextBox
    Friend WithEvents tb2 As TextBox
    Friend WithEvents tb3 As TextBox
    Friend WithEvents tb5 As TextBox
    Friend WithEvents tb6 As TextBox
    Friend WithEvents tb7 As TextBox
    Friend WithEvents btn1 As Button
    Friend WithEvents tb4 As DateTimePicker
    Friend WithEvents btn2 As Button
End Class
