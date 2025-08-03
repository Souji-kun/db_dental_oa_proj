<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Me.tb1 = New System.Windows.Forms.TextBox()
        Me.tb2 = New System.Windows.Forms.TextBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.btn_signup = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb1
        '
        Me.tb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb1.Location = New System.Drawing.Point(691, 251)
        Me.tb1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tb1.Name = "tb1"
        Me.tb1.Size = New System.Drawing.Size(321, 37)
        Me.tb1.TabIndex = 49
        '
        'tb2
        '
        Me.tb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2.Location = New System.Drawing.Point(691, 353)
        Me.tb2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tb2.Name = "tb2"
        Me.tb2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb2.Size = New System.Drawing.Size(321, 37)
        Me.tb2.TabIndex = 50
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.Color.Transparent
        Me.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_login.FlatAppearance.BorderSize = 0
        Me.btn_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_login.ForeColor = System.Drawing.Color.Transparent
        Me.btn_login.Location = New System.Drawing.Point(661, 426)
        Me.btn_login.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(177, 43)
        Me.btn_login.TabIndex = 51
        Me.btn_login.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'btn_signup
        '
        Me.btn_signup.BackColor = System.Drawing.Color.Transparent
        Me.btn_signup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_signup.FlatAppearance.BorderSize = 0
        Me.btn_signup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_signup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_signup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_signup.ForeColor = System.Drawing.Color.Transparent
        Me.btn_signup.Location = New System.Drawing.Point(903, 426)
        Me.btn_signup.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_signup.Name = "btn_signup"
        Me.btn_signup.Size = New System.Drawing.Size(177, 43)
        Me.btn_signup.TabIndex = 52
        Me.btn_signup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_signup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_signup.UseVisualStyleBackColor = False
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.db_final_opiz_acuesta.My.Resources.Resources._21
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1089, 602)
        Me.Controls.Add(Me.btn_signup)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.tb2)
        Me.Controls.Add(Me.tb1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "login"
        Me.Text = "login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb1 As TextBox
    Friend WithEvents tb2 As TextBox
    Friend WithEvents btn_login As Button
    Friend WithEvents btn_signup As Button
End Class
