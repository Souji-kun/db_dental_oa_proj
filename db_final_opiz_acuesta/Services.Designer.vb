<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Services
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
        Me.btn1.Location = New System.Drawing.Point(51, 382)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(166, 43)
        Me.btn1.TabIndex = 8
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
        Me.btn2.Location = New System.Drawing.Point(744, 21)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(47, 48)
        Me.btn2.TabIndex = 10
        Me.btn2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn2.UseVisualStyleBackColor = False
        '
        'Services
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.db_final_opiz_acuesta.My.Resources.Resources.Services_2_
        Me.ClientSize = New System.Drawing.Size(813, 488)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Name = "Services"
        Me.Text = "Services"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn1 As Button
    Friend WithEvents btn2 As Button
End Class
