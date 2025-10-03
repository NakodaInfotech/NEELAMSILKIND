<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignCardIssue
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignCardIssue))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TXTGRIDDESC = New System.Windows.Forms.TextBox()
        Me.TXTOTHERCHGS = New System.Windows.Forms.TextBox()
        Me.TXTTOTALCHGS = New System.Windows.Forms.TextBox()
        Me.TXTBOBBINCHGS = New System.Windows.Forms.TextBox()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.TXTACTUALPICKS = New System.Windows.Forms.TextBox()
        Me.TXTPICKS = New System.Windows.Forms.TextBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox()
        Me.GRIDCARD = New System.Windows.Forms.DataGridView()
        Me.CMBMATCHING = New System.Windows.Forms.ComboBox()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTCUT = New System.Windows.Forms.TextBox()
        Me.TXTWARPTL = New System.Windows.Forms.TextBox()
        Me.TXTTOTALMTRS = New System.Windows.Forms.TextBox()
        Me.TXTWEFTTL = New System.Windows.Forms.TextBox()
        Me.TXTTOTALCUT = New System.Windows.Forms.TextBox()
        Me.TXTSELVEDGE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTWARPWASTAGE = New System.Windows.Forms.TextBox()
        Me.TXTWEFTWASTAGE = New System.Windows.Forms.TextBox()
        Me.CARDDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTCARDNO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.LBLCLOSED = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGNNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMATCHING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GWARPTL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GWEFTTL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSELVEDGE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPICKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GACTUALPICKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBOBBINCHGS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTOTALCHGS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOTHERCHGS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGRIDDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOOMSMPRECD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GRIDCARD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Panel1)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTWARPWASTAGE)
        Me.BlendPanel1.Controls.Add(Me.TXTWEFTWASTAGE)
        Me.BlendPanel1.Controls.Add(Me.CARDDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTCARDNO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.LBLCLOSED)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TXTGRIDDESC)
        Me.Panel1.Controls.Add(Me.TXTOTHERCHGS)
        Me.Panel1.Controls.Add(Me.TXTTOTALCHGS)
        Me.Panel1.Controls.Add(Me.TXTBOBBINCHGS)
        Me.Panel1.Controls.Add(Me.TXTRATE)
        Me.Panel1.Controls.Add(Me.TXTACTUALPICKS)
        Me.Panel1.Controls.Add(Me.TXTPICKS)
        Me.Panel1.Controls.Add(Me.TXTSRNO)
        Me.Panel1.Controls.Add(Me.CMBDESIGNNO)
        Me.Panel1.Controls.Add(Me.GRIDCARD)
        Me.Panel1.Controls.Add(Me.CMBMATCHING)
        Me.Panel1.Controls.Add(Me.TXTMTRS)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TXTCUT)
        Me.Panel1.Controls.Add(Me.TXTWARPTL)
        Me.Panel1.Controls.Add(Me.TXTTOTALMTRS)
        Me.Panel1.Controls.Add(Me.TXTWEFTTL)
        Me.Panel1.Controls.Add(Me.TXTTOTALCUT)
        Me.Panel1.Controls.Add(Me.TXTSELVEDGE)
        Me.Panel1.Location = New System.Drawing.Point(12, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1210, 416)
        Me.Panel1.TabIndex = 5
        '
        'TXTGRIDDESC
        '
        Me.TXTGRIDDESC.BackColor = System.Drawing.Color.White
        Me.TXTGRIDDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGRIDDESC.Location = New System.Drawing.Point(1443, 3)
        Me.TXTGRIDDESC.Name = "TXTGRIDDESC"
        Me.TXTGRIDDESC.Size = New System.Drawing.Size(200, 23)
        Me.TXTGRIDDESC.TabIndex = 13
        '
        'TXTOTHERCHGS
        '
        Me.TXTOTHERCHGS.BackColor = System.Drawing.Color.White
        Me.TXTOTHERCHGS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOTHERCHGS.Location = New System.Drawing.Point(1363, 3)
        Me.TXTOTHERCHGS.Name = "TXTOTHERCHGS"
        Me.TXTOTHERCHGS.Size = New System.Drawing.Size(80, 23)
        Me.TXTOTHERCHGS.TabIndex = 12
        Me.TXTOTHERCHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALCHGS
        '
        Me.TXTTOTALCHGS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALCHGS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCHGS.Location = New System.Drawing.Point(1293, 3)
        Me.TXTTOTALCHGS.Name = "TXTTOTALCHGS"
        Me.TXTTOTALCHGS.ReadOnly = True
        Me.TXTTOTALCHGS.Size = New System.Drawing.Size(70, 23)
        Me.TXTTOTALCHGS.TabIndex = 11
        Me.TXTTOTALCHGS.TabStop = False
        Me.TXTTOTALCHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTBOBBINCHGS
        '
        Me.TXTBOBBINCHGS.BackColor = System.Drawing.Color.White
        Me.TXTBOBBINCHGS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBOBBINCHGS.Location = New System.Drawing.Point(1223, 3)
        Me.TXTBOBBINCHGS.Name = "TXTBOBBINCHGS"
        Me.TXTBOBBINCHGS.Size = New System.Drawing.Size(70, 23)
        Me.TXTBOBBINCHGS.TabIndex = 10
        Me.TXTBOBBINCHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.White
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(1153, 3)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(70, 23)
        Me.TXTRATE.TabIndex = 9
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTACTUALPICKS
        '
        Me.TXTACTUALPICKS.BackColor = System.Drawing.Color.White
        Me.TXTACTUALPICKS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACTUALPICKS.Location = New System.Drawing.Point(1083, 3)
        Me.TXTACTUALPICKS.Name = "TXTACTUALPICKS"
        Me.TXTACTUALPICKS.Size = New System.Drawing.Size(70, 23)
        Me.TXTACTUALPICKS.TabIndex = 8
        Me.TXTACTUALPICKS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPICKS
        '
        Me.TXTPICKS.BackColor = System.Drawing.Color.Linen
        Me.TXTPICKS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPICKS.Location = New System.Drawing.Point(1013, 3)
        Me.TXTPICKS.Name = "TXTPICKS"
        Me.TXTPICKS.ReadOnly = True
        Me.TXTPICKS.Size = New System.Drawing.Size(70, 23)
        Me.TXTPICKS.TabIndex = 7
        Me.TXTPICKS.TabStop = False
        Me.TXTPICKS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(3, 3)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBDESIGNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(33, 3)
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(200, 23)
        Me.CMBDESIGNNO.TabIndex = 0
        '
        'GRIDCARD
        '
        Me.GRIDCARD.AllowUserToAddRows = False
        Me.GRIDCARD.AllowUserToDeleteRows = False
        Me.GRIDCARD.AllowUserToResizeColumns = False
        Me.GRIDCARD.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCARD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDCARD.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCARD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCARD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDCARD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDCARD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCARD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GDESIGNNO, Me.GMATCHING, Me.GCUT, Me.GWARPTL, Me.GWEFTTL, Me.GMTRS, Me.GSELVEDGE, Me.GPICKS, Me.GACTUALPICKS, Me.GRATE, Me.GBOBBINCHGS, Me.GTOTALCHGS, Me.GOTHERCHGS, Me.GGRIDDESC, Me.GLOOMSMPRECD})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCARD.DefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDCARD.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCARD.Location = New System.Drawing.Point(2, 26)
        Me.GRIDCARD.MultiSelect = False
        Me.GRIDCARD.Name = "GRIDCARD"
        Me.GRIDCARD.RowHeadersVisible = False
        Me.GRIDCARD.RowHeadersWidth = 30
        Me.GRIDCARD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCARD.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDCARD.RowTemplate.Height = 20
        Me.GRIDCARD.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCARD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDCARD.Size = New System.Drawing.Size(1692, 339)
        Me.GRIDCARD.TabIndex = 14
        Me.GRIDCARD.TabStop = False
        '
        'CMBMATCHING
        '
        Me.CMBMATCHING.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMATCHING.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMATCHING.BackColor = System.Drawing.Color.White
        Me.CMBMATCHING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMATCHING.FormattingEnabled = True
        Me.CMBMATCHING.Location = New System.Drawing.Point(233, 3)
        Me.CMBMATCHING.Name = "CMBMATCHING"
        Me.CMBMATCHING.Size = New System.Drawing.Size(200, 23)
        Me.CMBMATCHING.TabIndex = 1
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(633, 3)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.Size = New System.Drawing.Size(80, 23)
        Me.TXTMTRS.TabIndex = 5
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(396, 374)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 744
        Me.Label1.Text = "Total"
        '
        'TXTCUT
        '
        Me.TXTCUT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCUT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCUT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCUT.Location = New System.Drawing.Point(433, 3)
        Me.TXTCUT.Name = "TXTCUT"
        Me.TXTCUT.Size = New System.Drawing.Size(60, 23)
        Me.TXTCUT.TabIndex = 2
        Me.TXTCUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTWARPTL
        '
        Me.TXTWARPTL.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTWARPTL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTWARPTL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWARPTL.Location = New System.Drawing.Point(493, 3)
        Me.TXTWARPTL.Name = "TXTWARPTL"
        Me.TXTWARPTL.Size = New System.Drawing.Size(70, 23)
        Me.TXTWARPTL.TabIndex = 3
        Me.TXTWARPTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALMTRS
        '
        Me.TXTTOTALMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALMTRS.Location = New System.Drawing.Point(633, 371)
        Me.TXTTOTALMTRS.Name = "TXTTOTALMTRS"
        Me.TXTTOTALMTRS.ReadOnly = True
        Me.TXTTOTALMTRS.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALMTRS.TabIndex = 18
        Me.TXTTOTALMTRS.TabStop = False
        Me.TXTTOTALMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTWEFTTL
        '
        Me.TXTWEFTTL.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTWEFTTL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTWEFTTL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWEFTTL.Location = New System.Drawing.Point(563, 3)
        Me.TXTWEFTTL.Name = "TXTWEFTTL"
        Me.TXTWEFTTL.Size = New System.Drawing.Size(70, 23)
        Me.TXTWEFTTL.TabIndex = 4
        Me.TXTWEFTTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALCUT
        '
        Me.TXTTOTALCUT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALCUT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOTALCUT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCUT.Location = New System.Drawing.Point(433, 371)
        Me.TXTTOTALCUT.Name = "TXTTOTALCUT"
        Me.TXTTOTALCUT.ReadOnly = True
        Me.TXTTOTALCUT.Size = New System.Drawing.Size(60, 23)
        Me.TXTTOTALCUT.TabIndex = 17
        Me.TXTTOTALCUT.TabStop = False
        Me.TXTTOTALCUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSELVEDGE
        '
        Me.TXTSELVEDGE.BackColor = System.Drawing.Color.White
        Me.TXTSELVEDGE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSELVEDGE.Location = New System.Drawing.Point(713, 3)
        Me.TXTSELVEDGE.Name = "TXTSELVEDGE"
        Me.TXTSELVEDGE.Size = New System.Drawing.Size(300, 23)
        Me.TXTSELVEDGE.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(776, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 14)
        Me.Label4.TabIndex = 764
        Me.Label4.Text = "Weft Wastage"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(773, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 14)
        Me.Label2.TabIndex = 763
        Me.Label2.Text = "Warp Wastage"
        '
        'TXTWARPWASTAGE
        '
        Me.TXTWARPWASTAGE.Location = New System.Drawing.Point(862, 32)
        Me.TXTWARPWASTAGE.Name = "TXTWARPWASTAGE"
        Me.TXTWARPWASTAGE.Size = New System.Drawing.Size(68, 23)
        Me.TXTWARPWASTAGE.TabIndex = 3
        Me.TXTWARPWASTAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTWEFTWASTAGE
        '
        Me.TXTWEFTWASTAGE.Location = New System.Drawing.Point(862, 61)
        Me.TXTWEFTWASTAGE.Name = "TXTWEFTWASTAGE"
        Me.TXTWEFTWASTAGE.Size = New System.Drawing.Size(68, 23)
        Me.TXTWEFTWASTAGE.TabIndex = 4
        Me.TXTWEFTWASTAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CARDDATE
        '
        Me.CARDDATE.AsciiOnly = True
        Me.CARDDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CARDDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CARDDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.CARDDATE.Location = New System.Drawing.Point(991, 61)
        Me.CARDDATE.Mask = "00/00/0000"
        Me.CARDDATE.Name = "CARDDATE"
        Me.CARDDATE.Size = New System.Drawing.Size(82, 23)
        Me.CARDDATE.TabIndex = 2
        Me.CARDDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.CARDDATE.ValidatingType = GetType(Date)
        '
        'TXTCARDNO
        '
        Me.TXTCARDNO.BackColor = System.Drawing.Color.Linen
        Me.TXTCARDNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARDNO.Location = New System.Drawing.Point(991, 32)
        Me.TXTCARDNO.Name = "TXTCARDNO"
        Me.TXTCARDNO.ReadOnly = True
        Me.TXTCARDNO.Size = New System.Drawing.Size(82, 23)
        Me.TXTCARDNO.TabIndex = 1
        Me.TXTCARDNO.TabStop = False
        Me.TXTCARDNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(949, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 630
        Me.Label12.Text = "Sr. No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(956, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 15)
        Me.Label9.TabIndex = 622
        Me.Label9.Text = "Date"
        '
        'TXTADD
        '
        Me.TXTADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTADD.Location = New System.Drawing.Point(378, 30)
        Me.TXTADD.Multiline = True
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(35, 22)
        Me.TXTADD.TabIndex = 0
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'LBLCLOSED
        '
        Me.LBLCLOSED.AutoSize = True
        Me.LBLCLOSED.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLOSED.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCLOSED.ForeColor = System.Drawing.Color.Red
        Me.LBLCLOSED.Location = New System.Drawing.Point(936, 506)
        Me.LBLCLOSED.Name = "LBLCLOSED"
        Me.LBLCLOSED.Size = New System.Drawing.Size(80, 29)
        Me.LBLCLOSED.TabIndex = 743
        Me.LBLCLOSED.Text = "Closed"
        Me.LBLCLOSED.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.White
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(368, 28)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(56, 23)
        Me.CMBCODE.TabIndex = 742
        Me.CMBCODE.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(21, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 727
        Me.Label3.Text = "Jobber Name"
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.NEELAMSILKIND.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(870, 508)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 446
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(100, 37)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(262, 23)
        Me.CMBNAME.TabIndex = 0
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(594, 510)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(82, 27)
        Me.cmddelete.TabIndex = 9
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(28, 505)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(268, 68)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.ForeColor = System.Drawing.Color.Black
        Me.TXTREMARKS.Location = New System.Drawing.Point(5, 16)
        Me.TXTREMARKS.MaxLength = 2000
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(253, 46)
        Me.TXTREMARKS.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(506, 510)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(82, 27)
        Me.cmdclear.TabIndex = 8
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(418, 510)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(82, 27)
        Me.cmdok.TabIndex = 7
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(506, 542)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(82, 27)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(239, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(74, 22)
        Me.tstxtbillno.TabIndex = 11
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(936, 539)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 445
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 610
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.NEELAMSILKIND.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.NEELAMSILKIND.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 30
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.HeaderText = "Design No"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.ReadOnly = True
        Me.GDESIGNNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGNNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGNNO.Width = 200
        '
        'GMATCHING
        '
        Me.GMATCHING.HeaderText = "Matching"
        Me.GMATCHING.Name = "GMATCHING"
        Me.GMATCHING.ReadOnly = True
        Me.GMATCHING.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMATCHING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMATCHING.Width = 200
        '
        'GCUT
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCUT.DefaultCellStyle = DataGridViewCellStyle3
        Me.GCUT.HeaderText = "Cut"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.ReadOnly = True
        Me.GCUT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCUT.Width = 60
        '
        'GWARPTL
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWARPTL.DefaultCellStyle = DataGridViewCellStyle4
        Me.GWARPTL.HeaderText = "Warp TL"
        Me.GWARPTL.Name = "GWARPTL"
        Me.GWARPTL.ReadOnly = True
        Me.GWARPTL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWARPTL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWARPTL.Width = 70
        '
        'GWEFTTL
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWEFTTL.DefaultCellStyle = DataGridViewCellStyle5
        Me.GWEFTTL.HeaderText = "Weft TL"
        Me.GWEFTTL.Name = "GWEFTTL"
        Me.GWEFTTL.ReadOnly = True
        Me.GWEFTTL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWEFTTL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWEFTTL.Width = 70
        '
        'GMTRS
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle6
        Me.GMTRS.HeaderText = "Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.ReadOnly = True
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 80
        '
        'GSELVEDGE
        '
        Me.GSELVEDGE.HeaderText = "Selvedge"
        Me.GSELVEDGE.Name = "GSELVEDGE"
        Me.GSELVEDGE.ReadOnly = True
        Me.GSELVEDGE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSELVEDGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSELVEDGE.Width = 300
        '
        'GPICKS
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPICKS.DefaultCellStyle = DataGridViewCellStyle7
        Me.GPICKS.HeaderText = "Picks"
        Me.GPICKS.Name = "GPICKS"
        Me.GPICKS.ReadOnly = True
        Me.GPICKS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPICKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPICKS.Width = 70
        '
        'GACTUALPICKS
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GACTUALPICKS.DefaultCellStyle = DataGridViewCellStyle8
        Me.GACTUALPICKS.HeaderText = "Act Picks"
        Me.GACTUALPICKS.Name = "GACTUALPICKS"
        Me.GACTUALPICKS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GACTUALPICKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GACTUALPICKS.Width = 70
        '
        'GRATE
        '
        Me.GRATE.HeaderText = "Rate"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE.Width = 70
        '
        'GBOBBINCHGS
        '
        Me.GBOBBINCHGS.HeaderText = "Bob Chgs"
        Me.GBOBBINCHGS.Name = "GBOBBINCHGS"
        Me.GBOBBINCHGS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBOBBINCHGS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBOBBINCHGS.Width = 70
        '
        'GTOTALCHGS
        '
        Me.GTOTALCHGS.HeaderText = "Total Chgs"
        Me.GTOTALCHGS.Name = "GTOTALCHGS"
        Me.GTOTALCHGS.ReadOnly = True
        Me.GTOTALCHGS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTOTALCHGS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GTOTALCHGS.Width = 70
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.HeaderText = "Other Chgs"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOTHERCHGS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GOTHERCHGS.Width = 80
        '
        'GGRIDDESC
        '
        Me.GGRIDDESC.HeaderText = "Description"
        Me.GGRIDDESC.Name = "GGRIDDESC"
        Me.GGRIDDESC.ReadOnly = True
        Me.GGRIDDESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGRIDDESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGRIDDESC.Width = 200
        '
        'GLOOMSMPRECD
        '
        Me.GLOOMSMPRECD.HeaderText = "Loom Sample Recd"
        Me.GLOOMSMPRECD.Name = "GLOOMSMPRECD"
        Me.GLOOMSMPRECD.ReadOnly = True
        Me.GLOOMSMPRECD.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOOMSMPRECD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLOOMSMPRECD.Visible = False
        '
        'DesignCardIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignCardIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Card Issue"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GRIDCARD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTCUT As TextBox
    Friend WithEvents TXTMTRS As TextBox
    Friend WithEvents CMBMATCHING As ComboBox
    Friend WithEvents GRIDCARD As DataGridView
    Friend WithEvents CMBDESIGNNO As ComboBox
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents CARDDATE As MaskedTextBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents LBLCLOSED As Label
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PBlock As PictureBox
    Friend WithEvents CMBNAME As ComboBox
    Friend WithEvents TXTCARDNO As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmddelete As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TXTREMARKS As TextBox
    Friend WithEvents cmdclear As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents lbllocked As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents tooldelete As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents toolprevious As ToolStripButton
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TXTWEFTTL As TextBox
    Friend WithEvents TXTWARPTL As TextBox
    Friend WithEvents TXTSELVEDGE As TextBox
    Friend WithEvents TXTTOTALMTRS As TextBox
    Friend WithEvents TXTTOTALCUT As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTWARPWASTAGE As TextBox
    Friend WithEvents TXTWEFTWASTAGE As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TXTGRIDDESC As TextBox
    Friend WithEvents TXTOTHERCHGS As TextBox
    Friend WithEvents TXTTOTALCHGS As TextBox
    Friend WithEvents TXTBOBBINCHGS As TextBox
    Friend WithEvents TXTRATE As TextBox
    Friend WithEvents TXTACTUALPICKS As TextBox
    Friend WithEvents TXTPICKS As TextBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGNNO As DataGridViewTextBoxColumn
    Friend WithEvents GMATCHING As DataGridViewTextBoxColumn
    Friend WithEvents GCUT As DataGridViewTextBoxColumn
    Friend WithEvents GWARPTL As DataGridViewTextBoxColumn
    Friend WithEvents GWEFTTL As DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GSELVEDGE As DataGridViewTextBoxColumn
    Friend WithEvents GPICKS As DataGridViewTextBoxColumn
    Friend WithEvents GACTUALPICKS As DataGridViewTextBoxColumn
    Friend WithEvents GRATE As DataGridViewTextBoxColumn
    Friend WithEvents GBOBBINCHGS As DataGridViewTextBoxColumn
    Friend WithEvents GTOTALCHGS As DataGridViewTextBoxColumn
    Friend WithEvents GOTHERCHGS As DataGridViewTextBoxColumn
    Friend WithEvents GGRIDDESC As DataGridViewTextBoxColumn
    Friend WithEvents GLOOMSMPRECD As DataGridViewTextBoxColumn
End Class
