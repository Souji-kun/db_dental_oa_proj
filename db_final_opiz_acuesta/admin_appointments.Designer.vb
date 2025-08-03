<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class admin_appointments
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
        Me.btn2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.tb1 = New System.Windows.Forms.TextBox()
        Me.tb3 = New System.Windows.Forms.TextBox()
        Me.tb4 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.S_aID = New System.Windows.Forms.Button()
        Me.S_dID = New System.Windows.Forms.Button()
        Me.ins = New System.Windows.Forms.Button()
        Me.upd = New System.Windows.Forms.Button()
        Me.S_pID = New System.Windows.Forms.Button()
        Me.del = New System.Windows.Forms.Button()
        Me.tb2 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btn2.Location = New System.Drawing.Point(725, 27)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(47, 48)
        Me.btn2.TabIndex = 10
        Me.btn2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn2.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(220, 81)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(552, 221)
        Me.DataGridView1.TabIndex = 11
        '
        'tb1
        '
        Me.tb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb1.Location = New System.Drawing.Point(186, 309)
        Me.tb1.Name = "tb1"
        Me.tb1.Size = New System.Drawing.Size(192, 22)
        Me.tb1.TabIndex = 27
        '
        'tb3
        '
        Me.tb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb3.Location = New System.Drawing.Point(186, 368)
        Me.tb3.Name = "tb3"
        Me.tb3.Size = New System.Drawing.Size(192, 22)
        Me.tb3.TabIndex = 29
        '
        'tb4
        '
        Me.tb4.AutoCompleteCustomSource.AddRange(New String() {"pending", "processing", "cancelled", "completed"})
        Me.tb4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb4.Location = New System.Drawing.Point(186, 452)
        Me.tb4.Name = "tb4"
        Me.tb4.Size = New System.Drawing.Size(192, 22)
        Me.tb4.TabIndex = 31
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(186, 402)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(192, 26)
        Me.DateTimePicker1.TabIndex = 32
        '
        'S_aID
        '
        Me.S_aID.BackColor = System.Drawing.Color.Transparent
        Me.S_aID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.S_aID.FlatAppearance.BorderSize = 0
        Me.S_aID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.S_aID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.S_aID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.S_aID.ForeColor = System.Drawing.Color.Transparent
        Me.S_aID.Location = New System.Drawing.Point(441, 328)
        Me.S_aID.Name = "S_aID"
        Me.S_aID.Size = New System.Drawing.Size(133, 35)
        Me.S_aID.TabIndex = 33
        Me.S_aID.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.S_aID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.S_aID.UseVisualStyleBackColor = False
        '
        'S_dID
        '
        Me.S_dID.BackColor = System.Drawing.Color.Transparent
        Me.S_dID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.S_dID.FlatAppearance.BorderSize = 0
        Me.S_dID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.S_dID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.S_dID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.S_dID.ForeColor = System.Drawing.Color.Transparent
        Me.S_dID.Location = New System.Drawing.Point(595, 328)
        Me.S_dID.Name = "S_dID"
        Me.S_dID.Size = New System.Drawing.Size(133, 35)
        Me.S_dID.TabIndex = 34
        Me.S_dID.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.S_dID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.S_dID.UseVisualStyleBackColor = False
        '
        'ins
        '
        Me.ins.BackColor = System.Drawing.Color.Transparent
        Me.ins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ins.FlatAppearance.BorderSize = 0
        Me.ins.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ins.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ins.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ins.ForeColor = System.Drawing.Color.Transparent
        Me.ins.Location = New System.Drawing.Point(441, 373)
        Me.ins.Name = "ins"
        Me.ins.Size = New System.Drawing.Size(133, 35)
        Me.ins.TabIndex = 35
        Me.ins.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ins.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ins.UseVisualStyleBackColor = False
        '
        'upd
        '
        Me.upd.BackColor = System.Drawing.Color.Transparent
        Me.upd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.upd.FlatAppearance.BorderSize = 0
        Me.upd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.upd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.upd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.upd.ForeColor = System.Drawing.Color.Transparent
        Me.upd.Location = New System.Drawing.Point(595, 374)
        Me.upd.Name = "upd"
        Me.upd.Size = New System.Drawing.Size(133, 35)
        Me.upd.TabIndex = 36
        Me.upd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.upd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.upd.UseVisualStyleBackColor = False
        '
        'S_pID
        '
        Me.S_pID.BackColor = System.Drawing.Color.Transparent
        Me.S_pID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.S_pID.FlatAppearance.BorderSize = 0
        Me.S_pID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.S_pID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.S_pID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.S_pID.ForeColor = System.Drawing.Color.Transparent
        Me.S_pID.Location = New System.Drawing.Point(441, 424)
        Me.S_pID.Name = "S_pID"
        Me.S_pID.Size = New System.Drawing.Size(133, 31)
        Me.S_pID.TabIndex = 37
        Me.S_pID.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.S_pID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.S_pID.UseVisualStyleBackColor = False
        '
        'del
        '
        Me.del.BackColor = System.Drawing.Color.Transparent
        Me.del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.del.FlatAppearance.BorderSize = 0
        Me.del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.del.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.del.ForeColor = System.Drawing.Color.Transparent
        Me.del.Location = New System.Drawing.Point(595, 424)
        Me.del.Name = "del"
        Me.del.Size = New System.Drawing.Size(133, 31)
        Me.del.TabIndex = 38
        Me.del.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.del.UseVisualStyleBackColor = False
        '
        'tb2
        '
        Me.tb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2.Location = New System.Drawing.Point(186, 339)
        Me.tb2.Name = "tb2"
        Me.tb2.Size = New System.Drawing.Size(192, 22)
        Me.tb2.TabIndex = 39
        '
        'admin_appointments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.db_final_opiz_acuesta.My.Resources.Resources.ADMIN_TRANSACTION__3_
        Me.ClientSize = New System.Drawing.Size(816, 486)
        Me.Controls.Add(Me.tb2)
        Me.Controls.Add(Me.del)
        Me.Controls.Add(Me.S_pID)
        Me.Controls.Add(Me.upd)
        Me.Controls.Add(Me.ins)
        Me.Controls.Add(Me.S_dID)
        Me.Controls.Add(Me.S_aID)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.tb4)
        Me.Controls.Add(Me.tb3)
        Me.Controls.Add(Me.tb1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn2)
        Me.Name = "admin_appointments"
        Me.Text = "admin_appointments"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents tb1 As TextBox
    Friend WithEvents tb3 As TextBox
    Friend WithEvents tb4 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents S_aID As Button
    Friend WithEvents S_dID As Button
    Friend WithEvents ins As Button
    Friend WithEvents upd As Button
    Friend WithEvents S_pID As Button
    Friend WithEvents del As Button
    Friend WithEvents tb2 As TextBox
End Class
