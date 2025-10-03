<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateLotNo
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTITEMNAME = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTCHALLANNO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RECDATE = New System.Windows.Forms.MaskedTextBox()
        Me.LBLLOTDATE = New System.Windows.Forms.Label()
        Me.CMBDYEING = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.TXTGRNNO = New System.Windows.Forms.TextBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDUPDATE = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRS)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTCHALLANNO)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.RECDATE)
        Me.BlendPanel1.Controls.Add(Me.LBLLOTDATE)
        Me.BlendPanel1.Controls.Add(Me.CMBDYEING)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel1.Controls.Add(Me.TXTGRNNO)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDUPDATE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(337, 283)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(219, 128)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.ReadOnly = True
        Me.TXTMTRS.Size = New System.Drawing.Size(86, 23)
        Me.TXTMTRS.TabIndex = 675
        Me.TXTMTRS.TabStop = False
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(187, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 15)
        Me.Label8.TabIndex = 676
        Me.Label8.Text = "Mtrs"
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(90, 128)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.ReadOnly = True
        Me.TXTPCS.Size = New System.Drawing.Size(86, 23)
        Me.TXTPCS.TabIndex = 673
        Me.TXTPCS.TabStop = False
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(61, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 15)
        Me.Label7.TabIndex = 674
        Me.Label7.Text = "Qty"
        '
        'TXTITEMNAME
        '
        Me.TXTITEMNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMNAME.Location = New System.Drawing.Point(90, 99)
        Me.TXTITEMNAME.Name = "TXTITEMNAME"
        Me.TXTITEMNAME.ReadOnly = True
        Me.TXTITEMNAME.Size = New System.Drawing.Size(215, 23)
        Me.TXTITEMNAME.TabIndex = 671
        Me.TXTITEMNAME.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 672
        Me.Label6.Text = "Item Name"
        '
        'TXTCHALLANNO
        '
        Me.TXTCHALLANNO.BackColor = System.Drawing.Color.Linen
        Me.TXTCHALLANNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHALLANNO.Location = New System.Drawing.Point(90, 70)
        Me.TXTCHALLANNO.Name = "TXTCHALLANNO"
        Me.TXTCHALLANNO.ReadOnly = True
        Me.TXTCHALLANNO.Size = New System.Drawing.Size(215, 23)
        Me.TXTCHALLANNO.TabIndex = 669
        Me.TXTCHALLANNO.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 670
        Me.Label5.Text = "Challan No"
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(90, 41)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(215, 23)
        Me.TXTNAME.TabIndex = 667
        Me.TXTNAME.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 668
        Me.Label2.Text = "Name"
        '
        'RECDATE
        '
        Me.RECDATE.AsciiOnly = True
        Me.RECDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.RECDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RECDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.RECDATE.Location = New System.Drawing.Point(223, 185)
        Me.RECDATE.Mask = "00/00/0000"
        Me.RECDATE.Name = "RECDATE"
        Me.RECDATE.Size = New System.Drawing.Size(82, 23)
        Me.RECDATE.TabIndex = 3
        Me.RECDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.RECDATE.ValidatingType = GetType(Date)
        '
        'LBLLOTDATE
        '
        Me.LBLLOTDATE.AutoSize = True
        Me.LBLLOTDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLLOTDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLOTDATE.ForeColor = System.Drawing.Color.Black
        Me.LBLLOTDATE.Location = New System.Drawing.Point(188, 189)
        Me.LBLLOTDATE.Name = "LBLLOTDATE"
        Me.LBLLOTDATE.Size = New System.Drawing.Size(31, 15)
        Me.LBLLOTDATE.TabIndex = 666
        Me.LBLLOTDATE.Text = "Date"
        '
        'CMBDYEING
        '
        Me.CMBDYEING.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDYEING.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDYEING.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBDYEING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDYEING.FormattingEnabled = True
        Me.CMBDYEING.Location = New System.Drawing.Point(90, 157)
        Me.CMBDYEING.MaxDropDownItems = 14
        Me.CMBDYEING.Name = "CMBDYEING"
        Me.CMBDYEING.Size = New System.Drawing.Size(215, 23)
        Me.CMBDYEING.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(44, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 634
        Me.Label4.Text = "Dyeing"
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(90, 185)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(86, 23)
        Me.TXTLOTNO.TabIndex = 2
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRNNO
        '
        Me.TXTGRNNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGRNNO.Location = New System.Drawing.Point(90, 12)
        Me.TXTGRNNO.Name = "TXTGRNNO"
        Me.TXTGRNNO.Size = New System.Drawing.Size(86, 23)
        Me.TXTGRNNO.TabIndex = 0
        Me.TXTGRNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(225, 234)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 6
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(139, 234)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 5
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDUPDATE
        '
        Me.CMDUPDATE.Location = New System.Drawing.Point(53, 234)
        Me.CMDUPDATE.Name = "CMDUPDATE"
        Me.CMDUPDATE.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPDATE.TabIndex = 4
        Me.CMDUPDATE.Text = "&Update"
        Me.CMDUPDATE.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Lot No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GRN No"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'UpdateLotNo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(337, 283)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UpdateLotNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Update Lot No"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMDUPDATE As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTGRNNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RECDATE As MaskedTextBox
    Friend WithEvents LBLLOTDATE As Label
    Friend WithEvents CMBDYEING As ComboBox
    Friend WithEvents TXTMTRS As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTPCS As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTITEMNAME As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTCHALLANNO As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTNAME As TextBox
    Friend WithEvents Label2 As Label
End Class
