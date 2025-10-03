<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnQualityRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YarnQualityRate))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.YARNDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.LBLSRNO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYARNQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOLDRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOLDCOSTRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOSTRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYARNID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CMBAGENTNAME = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLPRIVIOUS = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBAGENTNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.YARNDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.LBLSRNO)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(764, 556)
        Me.BlendPanel1.TabIndex = 14
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(19, 474)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(230, 79)
        Me.GroupBox5.TabIndex = 810
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
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(433, 487)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 809
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(347, 487)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 808
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'YARNDATE
        '
        Me.YARNDATE.AsciiOnly = True
        Me.YARNDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.YARNDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.YARNDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.YARNDATE.Location = New System.Drawing.Point(197, 7)
        Me.YARNDATE.Mask = "00/00/0000"
        Me.YARNDATE.Name = "YARNDATE"
        Me.YARNDATE.Size = New System.Drawing.Size(84, 23)
        Me.YARNDATE.TabIndex = 805
        Me.YARNDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.YARNDATE.ValidatingType = GetType(Date)
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.Linen
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.Location = New System.Drawing.Point(71, 7)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.ReadOnly = True
        Me.TXTNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTNO.TabIndex = 804
        Me.TXTNO.TabStop = False
        Me.TXTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLSRNO
        '
        Me.LBLSRNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSRNO.ForeColor = System.Drawing.Color.Black
        Me.LBLSRNO.Location = New System.Drawing.Point(19, 11)
        Me.LBLSRNO.Name = "LBLSRNO"
        Me.LBLSRNO.Size = New System.Drawing.Size(50, 14)
        Me.LBLSRNO.TabIndex = 807
        Me.LBLSRNO.Text = "Sr. No"
        Me.LBLSRNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(162, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 14)
        Me.Label9.TabIndex = 806
        Me.Label9.Text = "Date"
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(261, 487)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 801
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(347, 521)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 803
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 36)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.CMBAGENTNAME})
        Me.gridbilldetails.Size = New System.Drawing.Size(737, 433)
        Me.gridbilldetails.TabIndex = 257
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GYARNQUALITY, Me.GOLDRATE, Me.GOLDCOSTRATE, Me.GRATE, Me.GCOSTRATE, Me.GYARNID})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
        Me.GSRNO.Width = 40
        '
        'GYARNQUALITY
        '
        Me.GYARNQUALITY.Caption = "Yarn Quality"
        Me.GYARNQUALITY.FieldName = "YARNQUALITY"
        Me.GYARNQUALITY.Name = "GYARNQUALITY"
        Me.GYARNQUALITY.OptionsColumn.AllowEdit = False
        Me.GYARNQUALITY.Visible = True
        Me.GYARNQUALITY.VisibleIndex = 1
        Me.GYARNQUALITY.Width = 250
        '
        'GOLDRATE
        '
        Me.GOLDRATE.Caption = "Old Rate"
        Me.GOLDRATE.DisplayFormat.FormatString = "0.00"
        Me.GOLDRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOLDRATE.FieldName = "OLDRATE"
        Me.GOLDRATE.Name = "GOLDRATE"
        Me.GOLDRATE.OptionsColumn.AllowEdit = False
        Me.GOLDRATE.OptionsColumn.ReadOnly = True
        Me.GOLDRATE.Visible = True
        Me.GOLDRATE.VisibleIndex = 2
        Me.GOLDRATE.Width = 100
        '
        'GOLDCOSTRATE
        '
        Me.GOLDCOSTRATE.Caption = "Old Cost Rate"
        Me.GOLDCOSTRATE.DisplayFormat.FormatString = "0.00"
        Me.GOLDCOSTRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOLDCOSTRATE.FieldName = "OLDCOSTRATE"
        Me.GOLDCOSTRATE.Name = "GOLDCOSTRATE"
        Me.GOLDCOSTRATE.OptionsColumn.AllowEdit = False
        Me.GOLDCOSTRATE.Visible = True
        Me.GOLDCOSTRATE.VisibleIndex = 3
        Me.GOLDCOSTRATE.Width = 100
        '
        'GRATE
        '
        Me.GRATE.Caption = "New Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 4
        Me.GRATE.Width = 100
        '
        'GCOSTRATE
        '
        Me.GCOSTRATE.Caption = "Cost Rate"
        Me.GCOSTRATE.DisplayFormat.FormatString = "0.00"
        Me.GCOSTRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOSTRATE.FieldName = "COSTRATE"
        Me.GCOSTRATE.Name = "GCOSTRATE"
        Me.GCOSTRATE.Visible = True
        Me.GCOSTRATE.VisibleIndex = 5
        Me.GCOSTRATE.Width = 100
        '
        'GYARNID
        '
        Me.GYARNID.Caption = "Yarn Id"
        Me.GYARNID.FieldName = "YARNID"
        Me.GYARNID.Name = "GYARNID"
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'CMBAGENTNAME
        '
        Me.CMBAGENTNAME.AutoHeight = False
        Me.CMBAGENTNAME.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBAGENTNAME.Name = "CMBAGENTNAME"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.TOOLPRIVIOUS, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(764, 25)
        Me.ToolStrip1.TabIndex = 611
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
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(233, 0)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(66, 22)
        Me.tstxtbillno.TabIndex = 811
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'YarnQualityRate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(764, 581)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnQualityRate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Quality Rate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBAGENTNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDEXIT As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GYARNQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GOLDRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBAGENTNAME As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GOLDCOSTRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOSTRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYARNID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents YARNDATE As MaskedTextBox
    Friend WithEvents TXTNO As TextBox
    Friend WithEvents LBLSRNO As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmddelete As Button
    Friend WithEvents cmdclear As Button
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents tooldelete As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLPRIVIOUS As ToolStripButton
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tstxtbillno As TextBox
End Class
