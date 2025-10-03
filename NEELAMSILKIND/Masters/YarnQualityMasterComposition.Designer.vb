<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnQualityMasterComposition
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.TXTHSNCODE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTDENIER = New System.Windows.Forms.TextBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.GRPCOMPOSITION = New System.Windows.Forms.GroupBox()
        Me.TXTTOTALPER = New System.Windows.Forms.TextBox()
        Me.CMBYARNQUALITY = New System.Windows.Forms.ComboBox()
        Me.TXTPER = New System.Windows.Forms.TextBox()
        Me.GRIDCOMP = New System.Windows.Forms.DataGridView()
        Me.GYARNQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.GRPCOMPOSITION.SuspendLayout()
        CType(Me.GRIDCOMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTDENIER)
        Me.BlendPanel1.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel1.Controls.Add(Me.lblcategory)
        Me.BlendPanel1.Controls.Add(Me.GRPCOMPOSITION)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(656, 310)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(57, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 14)
        Me.Label5.TabIndex = 359
        Me.Label5.Text = "Rate"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.Linen
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(90, 76)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.ReadOnly = True
        Me.TXTRATE.Size = New System.Drawing.Size(73, 22)
        Me.TXTRATE.TabIndex = 6
        Me.TXTRATE.TabStop = False
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTHSNCODE
        '
        Me.TXTHSNCODE.BackColor = System.Drawing.Color.Linen
        Me.TXTHSNCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHSNCODE.Location = New System.Drawing.Point(90, 104)
        Me.TXTHSNCODE.Name = "TXTHSNCODE"
        Me.TXTHSNCODE.ReadOnly = True
        Me.TXTHSNCODE.Size = New System.Drawing.Size(73, 22)
        Me.TXTHSNCODE.TabIndex = 5
        Me.TXTHSNCODE.TabStop = False
        Me.TXTHSNCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 14)
        Me.Label3.TabIndex = 356
        Me.Label3.Text = "HSN Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(48, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 313
        Me.Label2.Text = "Denier"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTDENIER
        '
        Me.TXTDENIER.BackColor = System.Drawing.Color.Linen
        Me.TXTDENIER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDENIER.Location = New System.Drawing.Point(90, 49)
        Me.TXTDENIER.Name = "TXTDENIER"
        Me.TXTDENIER.ReadOnly = True
        Me.TXTDENIER.Size = New System.Drawing.Size(73, 22)
        Me.TXTDENIER.TabIndex = 4
        Me.TXTDENIER.TabStop = False
        Me.TXTDENIER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(90, 21)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(233, 22)
        Me.CMBQUALITY.TabIndex = 0
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.Transparent
        Me.lblcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(21, 25)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(66, 14)
        Me.lblcategory.TabIndex = 311
        Me.lblcategory.Text = "Yarn Quality"
        '
        'GRPCOMPOSITION
        '
        Me.GRPCOMPOSITION.BackColor = System.Drawing.Color.Transparent
        Me.GRPCOMPOSITION.Controls.Add(Me.TXTTOTALPER)
        Me.GRPCOMPOSITION.Controls.Add(Me.CMBYARNQUALITY)
        Me.GRPCOMPOSITION.Controls.Add(Me.TXTPER)
        Me.GRPCOMPOSITION.Controls.Add(Me.GRIDCOMP)
        Me.GRPCOMPOSITION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRPCOMPOSITION.ForeColor = System.Drawing.Color.Black
        Me.GRPCOMPOSITION.Location = New System.Drawing.Point(335, 21)
        Me.GRPCOMPOSITION.Name = "GRPCOMPOSITION"
        Me.GRPCOMPOSITION.Size = New System.Drawing.Size(292, 246)
        Me.GRPCOMPOSITION.TabIndex = 1
        Me.GRPCOMPOSITION.TabStop = False
        Me.GRPCOMPOSITION.Text = "Yarn Composition"
        '
        'TXTTOTALPER
        '
        Me.TXTTOTALPER.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPER.Location = New System.Drawing.Point(211, 218)
        Me.TXTTOTALPER.Name = "TXTTOTALPER"
        Me.TXTTOTALPER.ReadOnly = True
        Me.TXTTOTALPER.Size = New System.Drawing.Size(40, 22)
        Me.TXTTOTALPER.TabIndex = 355
        Me.TXTTOTALPER.TabStop = False
        Me.TXTTOTALPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBYARNQUALITY
        '
        Me.CMBYARNQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBYARNQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBYARNQUALITY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBYARNQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBYARNQUALITY.FormattingEnabled = True
        Me.CMBYARNQUALITY.Location = New System.Drawing.Point(11, 21)
        Me.CMBYARNQUALITY.MaxDropDownItems = 14
        Me.CMBYARNQUALITY.Name = "CMBYARNQUALITY"
        Me.CMBYARNQUALITY.Size = New System.Drawing.Size(200, 22)
        Me.CMBYARNQUALITY.TabIndex = 0
        '
        'TXTPER
        '
        Me.TXTPER.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPER.Location = New System.Drawing.Point(211, 21)
        Me.TXTPER.Name = "TXTPER"
        Me.TXTPER.Size = New System.Drawing.Size(40, 22)
        Me.TXTPER.TabIndex = 1
        Me.TXTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDCOMP
        '
        Me.GRIDCOMP.AllowUserToAddRows = False
        Me.GRIDCOMP.AllowUserToDeleteRows = False
        Me.GRIDCOMP.AllowUserToResizeColumns = False
        Me.GRIDCOMP.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDCOMP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDCOMP.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCOMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCOMP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDCOMP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDCOMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCOMP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GYARNQUALITY, Me.GPER})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCOMP.DefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDCOMP.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDCOMP.Location = New System.Drawing.Point(11, 43)
        Me.GRIDCOMP.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDCOMP.MultiSelect = False
        Me.GRIDCOMP.Name = "GRIDCOMP"
        Me.GRIDCOMP.ReadOnly = True
        Me.GRIDCOMP.RowHeadersVisible = False
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCOMP.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDCOMP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDCOMP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCOMP.Size = New System.Drawing.Size(270, 170)
        Me.GRIDCOMP.TabIndex = 2
        '
        'GYARNQUALITY
        '
        Me.GYARNQUALITY.HeaderText = "Yarn Quality"
        Me.GYARNQUALITY.Name = "GYARNQUALITY"
        Me.GYARNQUALITY.ReadOnly = True
        Me.GYARNQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GYARNQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GYARNQUALITY.Width = 200
        '
        'GPER
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPER.DefaultCellStyle = DataGridViewCellStyle8
        Me.GPER.HeaderText = "%"
        Me.GPER.Name = "GPER"
        Me.GPER.ReadOnly = True
        Me.GPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPER.Width = 40
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(191, 200)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 3
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(105, 200)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(148, 233)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'YarnQualityMasterComposition
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(656, 310)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnQualityMasterComposition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Quality Composition"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GRPCOMPOSITION.ResumeLayout(False)
        Me.GRPCOMPOSITION.PerformLayout()
        CType(Me.GRIDCOMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTRATE As TextBox
    Friend WithEvents TXTHSNCODE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTDENIER As TextBox
    Friend WithEvents CMBQUALITY As ComboBox
    Friend WithEvents lblcategory As Label
    Friend WithEvents GRPCOMPOSITION As GroupBox
    Friend WithEvents TXTTOTALPER As TextBox
    Friend WithEvents CMBYARNQUALITY As ComboBox
    Friend WithEvents TXTPER As TextBox
    Friend WithEvents GRIDCOMP As DataGridView
    Friend WithEvents GYARNQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents GPER As DataGridViewTextBoxColumn
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents Ep As ErrorProvider
End Class
