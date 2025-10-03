<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectMaster
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.LBLCODE = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.TXTPROJECTNAME = New System.Windows.Forms.TextBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.LBLCODE)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.TXTPROJECTNAME)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(492, 188)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(163, 148)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 3
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'LBLCODE
        '
        Me.LBLCODE.BackColor = System.Drawing.Color.Transparent
        Me.LBLCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCODE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLCODE.Location = New System.Drawing.Point(12, 41)
        Me.LBLCODE.Name = "LBLCODE"
        Me.LBLCODE.Size = New System.Drawing.Size(79, 22)
        Me.LBLCODE.TabIndex = 154
        Me.LBLCODE.Text = "Remarks"
        Me.LBLCODE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LBLCODE.Visible = False
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(94, 41)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(278, 86)
        Me.txtremarks.TabIndex = 1
        Me.txtremarks.Visible = False
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(249, 148)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 4
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'CMDSAVE
        '
        Me.CMDSAVE.BackColor = System.Drawing.Color.Transparent
        Me.CMDSAVE.FlatAppearance.BorderSize = 0
        Me.CMDSAVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSAVE.ForeColor = System.Drawing.Color.Black
        Me.CMDSAVE.Location = New System.Drawing.Point(77, 148)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 2
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = False
        '
        'lblgroup
        '
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(12, 13)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(79, 22)
        Me.lblgroup.TabIndex = 149
        Me.lblgroup.Text = "Project Name"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTPROJECTNAME
        '
        Me.TXTPROJECTNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPROJECTNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPROJECTNAME.Location = New System.Drawing.Point(94, 13)
        Me.TXTPROJECTNAME.MaxLength = 100
        Me.TXTPROJECTNAME.Name = "TXTPROJECTNAME"
        Me.TXTPROJECTNAME.Size = New System.Drawing.Size(278, 22)
        Me.TXTPROJECTNAME.TabIndex = 0
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(335, 148)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 5
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'ProjectMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(492, 188)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProjectMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Project Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents LBLCODE As Label
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents CMDSAVE As Button
    Friend WithEvents lblgroup As Label
    Friend WithEvents TXTPROJECTNAME As TextBox
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
End Class
