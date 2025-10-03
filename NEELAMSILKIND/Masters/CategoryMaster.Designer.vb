<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoryMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label63 = New System.Windows.Forms.Label()
        Me.TXTKMS = New System.Windows.Forms.TextBox()
        Me.cmbstate = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXTPINCODE = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GBGODOWN = New System.Windows.Forms.GroupBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBGODOWN.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GBGODOWN)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.txtname)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(332, 334)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDDELETE.Location = New System.Drawing.Point(124, 294)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 3
        Me.CMDDELETE.Text = "Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(18, 89)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(306, 75)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 18)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(294, 47)
        Me.txtremarks.TabIndex = 0
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(3, 3)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 147
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'lblgroup
        '
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(14, 22)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(73, 22)
        Me.lblgroup.TabIndex = 143
        Me.lblgroup.Text = "Category"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(91, 20)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(199, 23)
        Me.txtname.TabIndex = 0
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(18, 3)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(67, 26)
        Me.cmdedit.TabIndex = 145
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(38, 294)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(48, 48)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(197, 47)
        Me.lbl.TabIndex = 144
        Me.lbl.Text = "Enter Area                                            (e.g.  Kalbadevi,Santacruz." &
    ".., etc. )"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(210, 294)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(208, 26)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(31, 15)
        Me.Label63.TabIndex = 699
        Me.Label63.Text = "KMS"
        '
        'TXTKMS
        '
        Me.TXTKMS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTKMS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKMS.Location = New System.Drawing.Point(241, 22)
        Me.TXTKMS.Name = "TXTKMS"
        Me.TXTKMS.Size = New System.Drawing.Size(48, 23)
        Me.TXTKMS.TabIndex = 695
        Me.TXTKMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbstate
        '
        Me.cmbstate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbstate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbstate.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbstate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstate.FormattingEnabled = True
        Me.cmbstate.Location = New System.Drawing.Point(65, 51)
        Me.cmbstate.MaxDropDownItems = 14
        Me.cmbstate.Name = "cmbstate"
        Me.cmbstate.Size = New System.Drawing.Size(224, 23)
        Me.cmbstate.TabIndex = 696
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(30, 55)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 15)
        Me.Label23.TabIndex = 698
        Me.Label23.Text = "State"
        '
        'TXTPINCODE
        '
        Me.TXTPINCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPINCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPINCODE.Location = New System.Drawing.Point(65, 22)
        Me.TXTPINCODE.Name = "TXTPINCODE"
        Me.TXTPINCODE.Size = New System.Drawing.Size(85, 23)
        Me.TXTPINCODE.TabIndex = 694
        Me.TXTPINCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(9, 26)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 15)
        Me.Label22.TabIndex = 697
        Me.Label22.Text = "Pin Code"
        '
        'GBGODOWN
        '
        Me.GBGODOWN.BackColor = System.Drawing.Color.Transparent
        Me.GBGODOWN.Controls.Add(Me.TXTPINCODE)
        Me.GBGODOWN.Controls.Add(Me.Label63)
        Me.GBGODOWN.Controls.Add(Me.Label22)
        Me.GBGODOWN.Controls.Add(Me.TXTKMS)
        Me.GBGODOWN.Controls.Add(Me.Label23)
        Me.GBGODOWN.Controls.Add(Me.cmbstate)
        Me.GBGODOWN.Location = New System.Drawing.Point(12, 170)
        Me.GBGODOWN.Name = "GBGODOWN"
        Me.GBGODOWN.Size = New System.Drawing.Size(306, 91)
        Me.GBGODOWN.TabIndex = 700
        Me.GBGODOWN.TabStop = False
        Me.GBGODOWN.Visible = False
        '
        'CategoryMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(332, 334)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CategoryMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Category Master"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBGODOWN.ResumeLayout(False)
        Me.GBGODOWN.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents Label63 As Label
    Friend WithEvents TXTKMS As TextBox
    Friend WithEvents cmbstate As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TXTPINCODE As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents GBGODOWN As GroupBox
End Class
