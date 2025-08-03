<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receipt
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
        Me.btn2 = New System.Windows.Forms.Button()
        Me.lb2 = New System.Windows.Forms.Label()
        Me.lb1 = New System.Windows.Forms.Label()
        Me.lb3 = New System.Windows.Forms.Label()
        Me.lb4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        Me.btn2.Location = New System.Drawing.Point(967, 33)
        Me.btn2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(63, 59)
        Me.btn2.TabIndex = 11
        Me.btn2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn2.UseVisualStyleBackColor = False
        '
        'lb2
        '
        Me.lb2.AutoSize = True
        Me.lb2.BackColor = System.Drawing.Color.Transparent
        Me.lb2.Font = New System.Drawing.Font("MV Boli", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb2.ForeColor = System.Drawing.Color.White
        Me.lb2.Location = New System.Drawing.Point(279, 332)
        Me.lb2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb2.Name = "lb2"
        Me.lb2.Size = New System.Drawing.Size(323, 50)
        Me.lb2.TabIndex = 42
        Me.lb2.Text = "Dental CLeaning"
        Me.lb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb1
        '
        Me.lb1.AutoSize = True
        Me.lb1.BackColor = System.Drawing.Color.Transparent
        Me.lb1.Font = New System.Drawing.Font("MV Boli", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb1.ForeColor = System.Drawing.Color.White
        Me.lb1.Location = New System.Drawing.Point(405, 213)
        Me.lb1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb1.Name = "lb1"
        Me.lb1.Size = New System.Drawing.Size(61, 62)
        Me.lb1.TabIndex = 41
        Me.lb1.Text = "0"
        Me.lb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb3
        '
        Me.lb3.AutoSize = True
        Me.lb3.BackColor = System.Drawing.Color.Transparent
        Me.lb3.Font = New System.Drawing.Font("MV Boli", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb3.ForeColor = System.Drawing.Color.White
        Me.lb3.Location = New System.Drawing.Point(537, 396)
        Me.lb3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb3.Name = "lb3"
        Me.lb3.Size = New System.Drawing.Size(61, 62)
        Me.lb3.TabIndex = 43
        Me.lb3.Text = "0"
        Me.lb3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb4
        '
        Me.lb4.AutoSize = True
        Me.lb4.BackColor = System.Drawing.Color.Transparent
        Me.lb4.Font = New System.Drawing.Font("MV Boli", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb4.ForeColor = System.Drawing.Color.White
        Me.lb4.Location = New System.Drawing.Point(435, 453)
        Me.lb4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb4.Name = "lb4"
        Me.lb4.Size = New System.Drawing.Size(61, 62)
        Me.lb4.TabIndex = 44
        Me.lb4.Text = "0"
        Me.lb4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'receipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.db_final_opiz_acuesta.My.Resources.Resources._23
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1087, 597)
        Me.Controls.Add(Me.lb4)
        Me.Controls.Add(Me.lb3)
        Me.Controls.Add(Me.lb2)
        Me.Controls.Add(Me.lb1)
        Me.Controls.Add(Me.btn2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "receipt"
        Me.Text = "receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn2 As Button
    Friend WithEvents lb2 As Label
    Friend WithEvents lb1 As Label
    Friend WithEvents lb3 As Label
    Friend WithEvents lb4 As Label
End Class
