<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDesignCardIssue
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
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCARDNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMATCHING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWARPTL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEFTTL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSELVEDGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPICKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACTUALPICKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOBBINCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWARPWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEFTWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(635, 545)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 2
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(549, 545)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 1
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 35)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 510)
        Me.gridbilldetails.TabIndex = 257
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCARDNO, Me.GDATE, Me.GNAME, Me.GCATEGORY, Me.GITEMNAME, Me.GDESIGNNO, Me.GMATCHING, Me.GCUT, Me.GWARPTL, Me.GWEFTTL, Me.GMTRS, Me.GSELVEDGE, Me.GPICKS, Me.GACTUALPICKS, Me.GRATE, Me.GBOBBINCHGS, Me.GTOTALCHGS, Me.GOTHERCHGS, Me.GGRIDDESC, Me.GWARPWASTAGE, Me.GWEFTWASTAGE, Me.GREMARKS})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCARDNO
        '
        Me.GCARDNO.Caption = "Card No"
        Me.GCARDNO.FieldName = "CARDNO"
        Me.GCARDNO.Name = "GCARDNO"
        Me.GCARDNO.Visible = True
        Me.GCARDNO.VisibleIndex = 1
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 200
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 4
        Me.GCATEGORY.Width = 150
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 5
        Me.GITEMNAME.Width = 150
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 6
        Me.GDESIGNNO.Width = 150
        '
        'GMATCHING
        '
        Me.GMATCHING.Caption = "Matching"
        Me.GMATCHING.FieldName = "MATCHING"
        Me.GMATCHING.Name = "GMATCHING"
        Me.GMATCHING.Visible = True
        Me.GMATCHING.VisibleIndex = 7
        Me.GMATCHING.Width = 150
        '
        'GCUT
        '
        Me.GCUT.Caption = "Cut"
        Me.GCUT.DisplayFormat.FormatString = "0"
        Me.GCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCUT.FieldName = "CUT"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCUT.Visible = True
        Me.GCUT.VisibleIndex = 8
        '
        'GWARPTL
        '
        Me.GWARPTL.Caption = "Warp TL"
        Me.GWARPTL.DisplayFormat.FormatString = "0"
        Me.GWARPTL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWARPTL.FieldName = "WARPTL"
        Me.GWARPTL.Name = "GWARPTL"
        Me.GWARPTL.Visible = True
        Me.GWARPTL.VisibleIndex = 9
        '
        'GWEFTTL
        '
        Me.GWEFTTL.Caption = "Weft TL"
        Me.GWEFTTL.DisplayFormat.FormatString = "0"
        Me.GWEFTTL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWEFTTL.FieldName = "WEFTTL"
        Me.GWEFTTL.Name = "GWEFTTL"
        Me.GWEFTTL.Visible = True
        Me.GWEFTTL.VisibleIndex = 10
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 11
        '
        'GSELVEDGE
        '
        Me.GSELVEDGE.Caption = "Selvedge"
        Me.GSELVEDGE.FieldName = "SELVEDGE"
        Me.GSELVEDGE.Name = "GSELVEDGE"
        Me.GSELVEDGE.Visible = True
        Me.GSELVEDGE.VisibleIndex = 12
        Me.GSELVEDGE.Width = 250
        '
        'GPICKS
        '
        Me.GPICKS.Caption = "Picks"
        Me.GPICKS.FieldName = "PICKS"
        Me.GPICKS.Name = "GPICKS"
        Me.GPICKS.Visible = True
        Me.GPICKS.VisibleIndex = 13
        '
        'GACTUALPICKS
        '
        Me.GACTUALPICKS.Caption = "Act Picks"
        Me.GACTUALPICKS.FieldName = "ACTUALPICKS"
        Me.GACTUALPICKS.Name = "GACTUALPICKS"
        Me.GACTUALPICKS.Visible = True
        Me.GACTUALPICKS.VisibleIndex = 14
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 15
        '
        'GBOBBINCHGS
        '
        Me.GBOBBINCHGS.Caption = "Bob Chgs"
        Me.GBOBBINCHGS.DisplayFormat.FormatString = "0.00"
        Me.GBOBBINCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBOBBINCHGS.FieldName = "BOBBINCHGS"
        Me.GBOBBINCHGS.Name = "GBOBBINCHGS"
        Me.GBOBBINCHGS.Visible = True
        Me.GBOBBINCHGS.VisibleIndex = 16
        '
        'GTOTALCHGS
        '
        Me.GTOTALCHGS.Caption = "Total Chgs"
        Me.GTOTALCHGS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCHGS.FieldName = "TOTALCHGS"
        Me.GTOTALCHGS.Name = "GTOTALCHGS"
        Me.GTOTALCHGS.Visible = True
        Me.GTOTALCHGS.VisibleIndex = 17
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.Caption = "Other Chgs"
        Me.GOTHERCHGS.DisplayFormat.FormatString = "0.00"
        Me.GOTHERCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERCHGS.FieldName = "OTHERCHGS"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.Visible = True
        Me.GOTHERCHGS.VisibleIndex = 18
        '
        'GGRIDDESC
        '
        Me.GGRIDDESC.Caption = "Description"
        Me.GGRIDDESC.FieldName = "GRIDDESC"
        Me.GGRIDDESC.Name = "GGRIDDESC"
        Me.GGRIDDESC.Visible = True
        Me.GGRIDDESC.VisibleIndex = 19
        Me.GGRIDDESC.Width = 250
        '
        'GWARPWASTAGE
        '
        Me.GWARPWASTAGE.Caption = "Warp Was"
        Me.GWARPWASTAGE.FieldName = "WARPWASTAGE"
        Me.GWARPWASTAGE.Name = "GWARPWASTAGE"
        Me.GWARPWASTAGE.Visible = True
        Me.GWARPWASTAGE.VisibleIndex = 20
        '
        'GWEFTWASTAGE
        '
        Me.GWEFTWASTAGE.Caption = "Weft Was"
        Me.GWEFTWASTAGE.FieldName = "WEFTWASTAGE"
        Me.GWEFTWASTAGE.Name = "GWEFTWASTAGE"
        Me.GWEFTWASTAGE.Visible = True
        Me.GWEFTWASTAGE.VisibleIndex = 21
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 22
        Me.GREMARKS.Width = 200
        '
        'SelectDesignCardIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectDesignCardIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Design Card Issue"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCARDNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMATCHING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWARPTL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEFTTL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSELVEDGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPICKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACTUALPICKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOBBINCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWARPWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEFTWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
End Class
