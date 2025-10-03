<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDate
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
        Me.OLDDATE = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.TXTQTY = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NEWDATE = New System.Windows.Forms.MaskedTextBox()
        Me.LBLLOTDATE = New System.Windows.Forms.Label()
        Me.TXTENTRYNO = New System.Windows.Forms.TextBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDUPDATE = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.OLDDATE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.TXTQTY)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.NEWDATE)
        Me.BlendPanel1.Controls.Add(Me.LBLLOTDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTENTRYNO)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDUPDATE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(358, 227)
        Me.BlendPanel1.TabIndex = 0
        '
        'OLDDATE
        '
        Me.OLDDATE.AsciiOnly = True
        Me.OLDDATE.BackColor = System.Drawing.Color.Linen
        Me.OLDDATE.Enabled = False
        Me.OLDDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OLDDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.OLDDATE.Location = New System.Drawing.Point(235, 52)
        Me.OLDDATE.Mask = "00/00/0000"
        Me.OLDDATE.Name = "OLDDATE"
        Me.OLDDATE.Size = New System.Drawing.Size(82, 23)
        Me.OLDDATE.TabIndex = 679
        Me.OLDDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.OLDDATE.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(180, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 680
        Me.Label3.Text = "Old Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(52, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 678
        Me.Label9.Text = "Type"
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"YARNISSUE", "GREYRECD"})
        Me.CMBTYPE.Location = New System.Drawing.Point(86, 23)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(231, 23)
        Me.CMBTYPE.TabIndex = 0
        '
        'TXTQTY
        '
        Me.TXTQTY.BackColor = System.Drawing.Color.Linen
        Me.TXTQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQTY.Location = New System.Drawing.Point(86, 110)
        Me.TXTQTY.Name = "TXTQTY"
        Me.TXTQTY.ReadOnly = True
        Me.TXTQTY.Size = New System.Drawing.Size(82, 23)
        Me.TXTQTY.TabIndex = 673
        Me.TXTQTY.TabStop = False
        Me.TXTQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(57, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 15)
        Me.Label7.TabIndex = 674
        Me.Label7.Text = "Qty"
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(86, 81)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(231, 23)
        Me.TXTNAME.TabIndex = 667
        Me.TXTNAME.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 15)
        Me.Label2.TabIndex = 668
        Me.Label2.Text = "Name"
        '
        'NEWDATE
        '
        Me.NEWDATE.AsciiOnly = True
        Me.NEWDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.NEWDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NEWDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.NEWDATE.Location = New System.Drawing.Point(86, 139)
        Me.NEWDATE.Mask = "00/00/0000"
        Me.NEWDATE.Name = "NEWDATE"
        Me.NEWDATE.Size = New System.Drawing.Size(82, 23)
        Me.NEWDATE.TabIndex = 2
        Me.NEWDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.NEWDATE.ValidatingType = GetType(Date)
        '
        'LBLLOTDATE
        '
        Me.LBLLOTDATE.AutoSize = True
        Me.LBLLOTDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLLOTDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLOTDATE.ForeColor = System.Drawing.Color.Black
        Me.LBLLOTDATE.Location = New System.Drawing.Point(26, 143)
        Me.LBLLOTDATE.Name = "LBLLOTDATE"
        Me.LBLLOTDATE.Size = New System.Drawing.Size(58, 15)
        Me.LBLLOTDATE.TabIndex = 666
        Me.LBLLOTDATE.Text = "New Date"
        '
        'TXTENTRYNO
        '
        Me.TXTENTRYNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTENTRYNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTENTRYNO.Location = New System.Drawing.Point(86, 52)
        Me.TXTENTRYNO.Name = "TXTENTRYNO"
        Me.TXTENTRYNO.Size = New System.Drawing.Size(82, 23)
        Me.TXTENTRYNO.TabIndex = 1
        Me.TXTENTRYNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(222, 179)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 5
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(136, 179)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 4
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDUPDATE
        '
        Me.CMDUPDATE.Location = New System.Drawing.Point(50, 179)
        Me.CMDUPDATE.Name = "CMDUPDATE"
        Me.CMDUPDATE.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPDATE.TabIndex = 3
        Me.CMDUPDATE.Text = "&Update"
        Me.CMDUPDATE.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Entry No"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'UpdateDate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(358, 227)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UpdateDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Update Date"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTQTY As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTNAME As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NEWDATE As MaskedTextBox
    Friend WithEvents LBLLOTDATE As Label
    Friend WithEvents TXTENTRYNO As TextBox
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDUPDATE As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents OLDDATE As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CMBTYPE As ComboBox
    Friend WithEvents EP As ErrorProvider
End Class
