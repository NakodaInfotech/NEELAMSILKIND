<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoomSampleRecd
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoomSampleRecd))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.SMPDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMDSELECTISSUE = New System.Windows.Forms.Button()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.TXTSMPNO = New System.Windows.Forms.TextBox()
        Me.LBLSRNO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GRIDSAMPLE = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGNNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMATCHING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCARDNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCARDSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GREED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPICK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSMPREED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSMPPICK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAPPROVED = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GREASON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGRIDREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLPRIVIOUS = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GRIDSAMPLE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.SMPDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTISSUE)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTSMPNO)
        Me.BlendPanel1.Controls.Add(Me.LBLSRNO)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'SMPDATE
        '
        Me.SMPDATE.AsciiOnly = True
        Me.SMPDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.SMPDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.SMPDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.SMPDATE.Location = New System.Drawing.Point(1102, 65)
        Me.SMPDATE.Mask = "00/00/0000"
        Me.SMPDATE.Name = "SMPDATE"
        Me.SMPDATE.Size = New System.Drawing.Size(84, 23)
        Me.SMPDATE.TabIndex = 1
        Me.SMPDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.SMPDATE.ValidatingType = GetType(Date)
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.White
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTADD.Location = New System.Drawing.Point(1163, 28)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.ReadOnly = True
        Me.TXTADD.Size = New System.Drawing.Size(23, 22)
        Me.TXTADD.TabIndex = 737
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'CMDSELECTISSUE
        '
        Me.CMDSELECTISSUE.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTISSUE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTISSUE.FlatAppearance.BorderSize = 0
        Me.CMDSELECTISSUE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTISSUE.ForeColor = System.Drawing.Color.Black
        Me.CMDSELECTISSUE.Location = New System.Drawing.Point(528, 507)
        Me.CMDSELECTISSUE.Name = "CMDSELECTISSUE"
        Me.CMDSELECTISSUE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSELECTISSUE.TabIndex = 3
        Me.CMDSELECTISSUE.Text = "Select Issue"
        Me.CMDSELECTISSUE.UseVisualStyleBackColor = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(1149, 28)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(51, 22)
        Me.CMBCODE.TabIndex = 721
        Me.CMBCODE.Visible = False
        '
        'TXTSMPNO
        '
        Me.TXTSMPNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSMPNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSMPNO.Location = New System.Drawing.Point(1102, 37)
        Me.TXTSMPNO.Name = "TXTSMPNO"
        Me.TXTSMPNO.ReadOnly = True
        Me.TXTSMPNO.Size = New System.Drawing.Size(84, 23)
        Me.TXTSMPNO.TabIndex = 0
        Me.TXTSMPNO.TabStop = False
        Me.TXTSMPNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLSRNO
        '
        Me.LBLSRNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSRNO.ForeColor = System.Drawing.Color.Black
        Me.LBLSRNO.Location = New System.Drawing.Point(1050, 41)
        Me.LBLSRNO.Name = "LBLSRNO"
        Me.LBLSRNO.Size = New System.Drawing.Size(50, 14)
        Me.LBLSRNO.TabIndex = 630
        Me.LBLSRNO.Text = "Sr. No"
        Me.LBLSRNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1067, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 14)
        Me.Label9.TabIndex = 622
        Me.Label9.Text = "Date"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(13, 72)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1209, 412)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GRIDSAMPLE)
        Me.TabPage1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1201, 384)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1. Yarn Quality Details"
        '
        'GRIDSAMPLE
        '
        Me.GRIDSAMPLE.AllowUserToAddRows = False
        Me.GRIDSAMPLE.AllowUserToDeleteRows = False
        Me.GRIDSAMPLE.AllowUserToResizeColumns = False
        Me.GRIDSAMPLE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSAMPLE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSAMPLE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSAMPLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSAMPLE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSAMPLE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSAMPLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSAMPLE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GDESIGNNO, Me.GMATCHING, Me.GCARDNO, Me.GCARDSRNO, Me.GREED, Me.GPICK, Me.GSMPREED, Me.GSMPPICK, Me.GAPPROVED, Me.GREASON, Me.GGRIDREMARKS})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSAMPLE.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDSAMPLE.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSAMPLE.Location = New System.Drawing.Point(3, 3)
        Me.GRIDSAMPLE.MultiSelect = False
        Me.GRIDSAMPLE.Name = "GRIDSAMPLE"
        Me.GRIDSAMPLE.RowHeadersVisible = False
        Me.GRIDSAMPLE.RowHeadersWidth = 30
        Me.GRIDSAMPLE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSAMPLE.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDSAMPLE.RowTemplate.Height = 20
        Me.GRIDSAMPLE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSAMPLE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDSAMPLE.Size = New System.Drawing.Size(1192, 375)
        Me.GRIDSAMPLE.TabIndex = 542
        Me.GRIDSAMPLE.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.HeaderText = "Design No"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.ReadOnly = True
        Me.GDESIGNNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGNNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGNNO.Width = 300
        '
        'GMATCHING
        '
        Me.GMATCHING.HeaderText = "Matching"
        Me.GMATCHING.Name = "GMATCHING"
        Me.GMATCHING.ReadOnly = True
        Me.GMATCHING.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMATCHING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMATCHING.Width = 150
        '
        'GCARDNO
        '
        Me.GCARDNO.HeaderText = "Card No"
        Me.GCARDNO.Name = "GCARDNO"
        Me.GCARDNO.ReadOnly = True
        Me.GCARDNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCARDNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCARDNO.Width = 80
        '
        'GCARDSRNO
        '
        Me.GCARDSRNO.HeaderText = "Card Sr No"
        Me.GCARDSRNO.Name = "GCARDSRNO"
        Me.GCARDSRNO.ReadOnly = True
        Me.GCARDSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCARDSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCARDSRNO.Width = 80
        '
        'GREED
        '
        Me.GREED.HeaderText = "Reed"
        Me.GREED.Name = "GREED"
        Me.GREED.ReadOnly = True
        Me.GREED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREED.Width = 80
        '
        'GPICK
        '
        Me.GPICK.HeaderText = "Pick"
        Me.GPICK.Name = "GPICK"
        Me.GPICK.ReadOnly = True
        Me.GPICK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPICK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPICK.Width = 80
        '
        'GSMPREED
        '
        Me.GSMPREED.HeaderText = "Smp Reed"
        Me.GSMPREED.Name = "GSMPREED"
        Me.GSMPREED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSMPREED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSMPREED.Width = 80
        '
        'GSMPPICK
        '
        Me.GSMPPICK.HeaderText = "Smp Pick"
        Me.GSMPPICK.Name = "GSMPPICK"
        Me.GSMPPICK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSMPPICK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSMPPICK.Width = 80
        '
        'GAPPROVED
        '
        Me.GAPPROVED.HeaderText = "App"
        Me.GAPPROVED.Items.AddRange(New Object() {"No", "Yes"})
        Me.GAPPROVED.Name = "GAPPROVED"
        Me.GAPPROVED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAPPROVED.Width = 60
        '
        'GREASON
        '
        Me.GREASON.HeaderText = "Reason"
        Me.GREASON.Name = "GREASON"
        Me.GREASON.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREASON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREASON.Width = 250
        '
        'GGRIDREMARKS
        '
        Me.GGRIDREMARKS.HeaderText = "Narration"
        Me.GGRIDREMARKS.Name = "GGRIDREMARKS"
        Me.GGRIDREMARKS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGRIDREMARKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGRIDREMARKS.Width = 300
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(577, 541)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 10
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(23, 490)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(230, 79)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(7, 16)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(217, 57)
        Me.txtremarks.TabIndex = 0
        Me.txtremarks.TabStop = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(490, 541)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 9
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(614, 507)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(664, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 11
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(255, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(66, 22)
        Me.tstxtbillno.TabIndex = 25
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 14)
        Me.Label6.TabIndex = 434
        Me.Label6.Text = "Jobber Name"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(104, 37)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(234, 22)
        Me.CMBNAME.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.TOOLPRIVIOUS, Me.toolnext, Me.ToolStripSeparator1})
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
        'TOOLPRIVIOUS
        '
        Me.TOOLPRIVIOUS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOOLPRIVIOUS.Image = Global.NEELAMSILKIND.My.Resources.Resources.POINT02
        Me.TOOLPRIVIOUS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPRIVIOUS.Name = "TOOLPRIVIOUS"
        Me.TOOLPRIVIOUS.Size = New System.Drawing.Size(73, 22)
        Me.TOOLPRIVIOUS.Text = "Previous"
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
        'LoomSampleRecd
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LoomSampleRecd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Loom Sample Recd"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.GRIDSAMPLE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents SMPDATE As MaskedTextBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMDSELECTISSUE As Button
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents TXTSMPNO As TextBox
    Friend WithEvents LBLSRNO As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GRIDSAMPLE As DataGridView
    Friend WithEvents cmddelete As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents cmdclear As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CMBNAME As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents tooldelete As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLPRIVIOUS As ToolStripButton
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGNNO As DataGridViewTextBoxColumn
    Friend WithEvents GMATCHING As DataGridViewTextBoxColumn
    Friend WithEvents GCARDNO As DataGridViewTextBoxColumn
    Friend WithEvents GCARDSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GREED As DataGridViewTextBoxColumn
    Friend WithEvents GPICK As DataGridViewTextBoxColumn
    Friend WithEvents GSMPREED As DataGridViewTextBoxColumn
    Friend WithEvents GSMPPICK As DataGridViewTextBoxColumn
    Friend WithEvents GAPPROVED As DataGridViewComboBoxColumn
    Friend WithEvents GREASON As DataGridViewTextBoxColumn
    Friend WithEvents GGRIDREMARKS As DataGridViewTextBoxColumn
End Class
