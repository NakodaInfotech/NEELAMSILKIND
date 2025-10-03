<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HSNMaster
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
        Me.TXTEXPORTIGST = New System.Windows.Forms.TextBox()
        Me.TXTEXPORTSGST = New System.Windows.Forms.TextBox()
        Me.TXTEXPORTCGST = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTRATE1 = New System.Windows.Forms.TextBox()
        Me.TXTIGST1 = New System.Windows.Forms.TextBox()
        Me.TXTSGST1 = New System.Windows.Forms.TextBox()
        Me.TXTCGST1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.TXTIGST = New System.Windows.Forms.TextBox()
        Me.TXTSGST = New System.Windows.Forms.TextBox()
        Me.TXTCGST = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.TXTITEMDESC = New System.Windows.Forms.TextBox()
        Me.LBLITEMDESC = New System.Windows.Forms.Label()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTHSNCODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTHSNNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTEXPORTIGST)
        Me.BlendPanel1.Controls.Add(Me.TXTEXPORTSGST)
        Me.BlendPanel1.Controls.Add(Me.TXTEXPORTCGST)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE1)
        Me.BlendPanel1.Controls.Add(Me.TXTIGST1)
        Me.BlendPanel1.Controls.Add(Me.TXTSGST1)
        Me.BlendPanel1.Controls.Add(Me.TXTCGST1)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.TXTIGST)
        Me.BlendPanel1.Controls.Add(Me.TXTSGST)
        Me.BlendPanel1.Controls.Add(Me.TXTCGST)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTDESC)
        Me.BlendPanel1.Controls.Add(Me.TXTITEMDESC)
        Me.BlendPanel1.Controls.Add(Me.LBLITEMDESC)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTHSNNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(520, 355)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTEXPORTIGST
        '
        Me.TXTEXPORTIGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTEXPORTIGST.Location = New System.Drawing.Point(439, 257)
        Me.TXTEXPORTIGST.Name = "TXTEXPORTIGST"
        Me.TXTEXPORTIGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTEXPORTIGST.TabIndex = 15
        Me.TXTEXPORTIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTEXPORTSGST
        '
        Me.TXTEXPORTSGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTEXPORTSGST.Location = New System.Drawing.Point(439, 228)
        Me.TXTEXPORTSGST.Name = "TXTEXPORTSGST"
        Me.TXTEXPORTSGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTEXPORTSGST.TabIndex = 14
        Me.TXTEXPORTSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTEXPORTCGST
        '
        Me.TXTEXPORTCGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTEXPORTCGST.Location = New System.Drawing.Point(439, 200)
        Me.TXTEXPORTCGST.Name = "TXTEXPORTCGST"
        Me.TXTEXPORTCGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTEXPORTCGST.TabIndex = 13
        Me.TXTEXPORTCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(356, 260)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 15)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Export IGST %"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(355, 232)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 15)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Export SGST %"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(354, 203)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 15)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Export CGST %"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(177, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Rate > Then"
        '
        'TXTRATE1
        '
        Me.TXTRATE1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE1.Location = New System.Drawing.Point(248, 167)
        Me.TXTRATE1.Name = "TXTRATE1"
        Me.TXTRATE1.Size = New System.Drawing.Size(60, 23)
        Me.TXTRATE1.TabIndex = 9
        Me.TXTRATE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTIGST1
        '
        Me.TXTIGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTIGST1.Location = New System.Drawing.Point(248, 254)
        Me.TXTIGST1.Name = "TXTIGST1"
        Me.TXTIGST1.Size = New System.Drawing.Size(60, 23)
        Me.TXTIGST1.TabIndex = 12
        Me.TXTIGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSGST1
        '
        Me.TXTSGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSGST1.Location = New System.Drawing.Point(248, 225)
        Me.TXTSGST1.Name = "TXTSGST1"
        Me.TXTSGST1.Size = New System.Drawing.Size(60, 23)
        Me.TXTSGST1.TabIndex = 11
        Me.TXTSGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCGST1
        '
        Me.TXTCGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCGST1.Location = New System.Drawing.Point(248, 197)
        Me.TXTCGST1.Name = "TXTCGST1"
        Me.TXTCGST1.Size = New System.Drawing.Size(60, 23)
        Me.TXTCGST1.TabIndex = 10
        Me.TXTCGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(203, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "IGST %"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(201, 229)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 15)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "SGST %"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(200, 201)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 15)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "CGST %"
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.Location = New System.Drawing.Point(86, 167)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(60, 23)
        Me.TXTRATE.TabIndex = 5
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(15, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Rate > Then"
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(349, 298)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 19
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Location = New System.Drawing.Point(263, 298)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 18
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(177, 298)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 17
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(91, 298)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 16
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'TXTIGST
        '
        Me.TXTIGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTIGST.Location = New System.Drawing.Point(86, 254)
        Me.TXTIGST.Name = "TXTIGST"
        Me.TXTIGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTIGST.TabIndex = 8
        Me.TXTIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSGST
        '
        Me.TXTSGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSGST.Location = New System.Drawing.Point(86, 225)
        Me.TXTSGST.Name = "TXTSGST"
        Me.TXTSGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTSGST.TabIndex = 7
        Me.TXTSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCGST
        '
        Me.TXTCGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCGST.Location = New System.Drawing.Point(86, 196)
        Me.TXTCGST.Name = "TXTCGST"
        Me.TXTCGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTCGST.TabIndex = 6
        Me.TXTCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(41, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "IGST %"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(39, 229)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "SGST %"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(38, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "CGST %"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(67, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Description"
        '
        'TXTDESC
        '
        Me.TXTDESC.BackColor = System.Drawing.Color.White
        Me.TXTDESC.Location = New System.Drawing.Point(139, 114)
        Me.TXTDESC.MaxLength = 500
        Me.TXTDESC.Multiline = True
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(365, 47)
        Me.TXTDESC.TabIndex = 4
        '
        'TXTITEMDESC
        '
        Me.TXTITEMDESC.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTITEMDESC.Location = New System.Drawing.Point(139, 85)
        Me.TXTITEMDESC.MaxLength = 100
        Me.TXTITEMDESC.Name = "TXTITEMDESC"
        Me.TXTITEMDESC.Size = New System.Drawing.Size(365, 23)
        Me.TXTITEMDESC.TabIndex = 3
        '
        'LBLITEMDESC
        '
        Me.LBLITEMDESC.BackColor = System.Drawing.Color.Transparent
        Me.LBLITEMDESC.Location = New System.Drawing.Point(15, 89)
        Me.LBLITEMDESC.Name = "LBLITEMDESC"
        Me.LBLITEMDESC.Size = New System.Drawing.Size(122, 15)
        Me.LBLITEMDESC.TabIndex = 6
        Me.LBLITEMDESC.Text = "Item Description"
        Me.LBLITEMDESC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"Goods", "Services"})
        Me.CMBTYPE.Location = New System.Drawing.Point(139, 27)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(105, 23)
        Me.CMBTYPE.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(47, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "HSN / SAC Code"
        '
        'TXTHSNCODE
        '
        Me.TXTHSNCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTHSNCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTHSNCODE.Location = New System.Drawing.Point(139, 56)
        Me.TXTHSNCODE.MaxLength = 10
        Me.TXTHSNCODE.Name = "TXTHSNCODE"
        Me.TXTHSNCODE.Size = New System.Drawing.Size(105, 23)
        Me.TXTHSNCODE.TabIndex = 2
        Me.TXTHSNCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(106, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type"
        '
        'TXTHSNNO
        '
        Me.TXTHSNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTHSNNO.Location = New System.Drawing.Point(303, 3)
        Me.TXTHSNNO.Name = "TXTHSNNO"
        Me.TXTHSNNO.Size = New System.Drawing.Size(105, 23)
        Me.TXTHSNNO.TabIndex = 0
        Me.TXTHSNNO.TabStop = False
        Me.TXTHSNNO.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(257, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "HSN ID"
        Me.Label1.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'HSNMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(520, 355)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "HSNMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "HSN Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTHSNCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTHSNNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTIGST As System.Windows.Forms.TextBox
    Friend WithEvents TXTSGST As System.Windows.Forms.TextBox
    Friend WithEvents TXTCGST As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents TXTITEMDESC As System.Windows.Forms.TextBox
    Friend WithEvents LBLITEMDESC As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents TXTRATE1 As System.Windows.Forms.TextBox
    Friend WithEvents TXTIGST1 As System.Windows.Forms.TextBox
    Friend WithEvents TXTSGST1 As System.Windows.Forms.TextBox
    Friend WithEvents TXTCGST1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTEXPORTIGST As TextBox
    Friend WithEvents TXTEXPORTSGST As TextBox
    Friend WithEvents TXTEXPORTCGST As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
End Class
