<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleOrderVsStockGridReport
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
        Me.GRIDORDERDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDORDER = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ONAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ODUEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDSTOCKDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDSTOCK = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SPIECETYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERTOTALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDORDERDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDORDER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GRIDORDERDETAILS)
        Me.BlendPanel1.Controls.Add(Me.GRIDSTOCKDETAILS)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1264, 581)
        Me.BlendPanel1.TabIndex = 3
        '
        'GRIDORDERDETAILS
        '
        Me.GRIDORDERDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDERDETAILS.Location = New System.Drawing.Point(782, 314)
        Me.GRIDORDERDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDORDERDETAILS.MainView = Me.GRIDORDER
        Me.GRIDORDERDETAILS.Name = "GRIDORDERDETAILS"
        Me.GRIDORDERDETAILS.Size = New System.Drawing.Size(502, 255)
        Me.GRIDORDERDETAILS.TabIndex = 449
        Me.GRIDORDERDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDORDER})
        '
        'GRIDORDER
        '
        Me.GRIDORDER.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDER.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDORDER.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDER.Appearance.Row.Options.UseFont = True
        Me.GRIDORDER.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDORDER.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDORDER.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDER.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDORDER.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ONAME, Me.OORDERNO, Me.ODUEDATE, Me.OUNIT, Me.OPCS, Me.OMTRS})
        Me.GRIDORDER.GridControl = Me.GRIDORDERDETAILS
        Me.GRIDORDER.Name = "GRIDORDER"
        Me.GRIDORDER.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDORDER.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDORDER.OptionsBehavior.Editable = False
        Me.GRIDORDER.OptionsMenu.EnableColumnMenu = False
        Me.GRIDORDER.OptionsView.ColumnAutoWidth = False
        Me.GRIDORDER.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDORDER.OptionsView.ShowAutoFilterRow = True
        Me.GRIDORDER.OptionsView.ShowFooter = True
        Me.GRIDORDER.OptionsView.ShowGroupPanel = False
        '
        'ONAME
        '
        Me.ONAME.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.ONAME.AppearanceCell.Options.UseBackColor = True
        Me.ONAME.Caption = "Name"
        Me.ONAME.FieldName = "NAME"
        Me.ONAME.Name = "ONAME"
        Me.ONAME.Visible = True
        Me.ONAME.VisibleIndex = 0
        Me.ONAME.Width = 160
        '
        'OORDERNO
        '
        Me.OORDERNO.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OORDERNO.AppearanceCell.Options.UseBackColor = True
        Me.OORDERNO.Caption = "Order No"
        Me.OORDERNO.FieldName = "ORDERNO"
        Me.OORDERNO.Name = "OORDERNO"
        Me.OORDERNO.Visible = True
        Me.OORDERNO.VisibleIndex = 1
        Me.OORDERNO.Width = 65
        '
        'ODUEDATE
        '
        Me.ODUEDATE.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.ODUEDATE.AppearanceCell.Options.UseBackColor = True
        Me.ODUEDATE.Caption = "Due Date"
        Me.ODUEDATE.FieldName = "DUEDATE"
        Me.ODUEDATE.Name = "ODUEDATE"
        Me.ODUEDATE.Visible = True
        Me.ODUEDATE.VisibleIndex = 2
        '
        'OUNIT
        '
        Me.OUNIT.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OUNIT.AppearanceCell.Options.UseBackColor = True
        Me.OUNIT.Caption = "Unit"
        Me.OUNIT.FieldName = "UNIT"
        Me.OUNIT.Name = "OUNIT"
        Me.OUNIT.Visible = True
        Me.OUNIT.VisibleIndex = 3
        Me.OUNIT.Width = 60
        '
        'OPCS
        '
        Me.OPCS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OPCS.AppearanceCell.Options.UseBackColor = True
        Me.OPCS.Caption = "Pcs"
        Me.OPCS.DisplayFormat.FormatString = "0"
        Me.OPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.OPCS.FieldName = "PCS"
        Me.OPCS.Name = "OPCS"
        Me.OPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.OPCS.Visible = True
        Me.OPCS.VisibleIndex = 4
        Me.OPCS.Width = 40
        '
        'OMTRS
        '
        Me.OMTRS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OMTRS.AppearanceCell.Options.UseBackColor = True
        Me.OMTRS.Caption = "Mtrs"
        Me.OMTRS.DisplayFormat.FormatString = "0.00"
        Me.OMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.OMTRS.FieldName = "MTRS"
        Me.OMTRS.Name = "OMTRS"
        Me.OMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.OMTRS.Visible = True
        Me.OMTRS.VisibleIndex = 5
        Me.OMTRS.Width = 60
        '
        'GRIDSTOCKDETAILS
        '
        Me.GRIDSTOCKDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCKDETAILS.Location = New System.Drawing.Point(782, 38)
        Me.GRIDSTOCKDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDSTOCKDETAILS.MainView = Me.GRIDSTOCK
        Me.GRIDSTOCKDETAILS.Name = "GRIDSTOCKDETAILS"
        Me.GRIDSTOCKDETAILS.Size = New System.Drawing.Size(440, 255)
        Me.GRIDSTOCKDETAILS.TabIndex = 448
        Me.GRIDSTOCKDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDSTOCK})
        '
        'GRIDSTOCK
        '
        Me.GRIDSTOCK.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDSTOCK.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.Row.Options.UseFont = True
        Me.GRIDSTOCK.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDSTOCK.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDSTOCK.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDSTOCK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SPIECETYPE, Me.SUNIT, Me.GridColumn4, Me.GridColumn5})
        Me.GRIDSTOCK.GridControl = Me.GRIDSTOCKDETAILS
        Me.GRIDSTOCK.Name = "GRIDSTOCK"
        Me.GRIDSTOCK.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDSTOCK.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDSTOCK.OptionsBehavior.Editable = False
        Me.GRIDSTOCK.OptionsMenu.EnableColumnMenu = False
        Me.GRIDSTOCK.OptionsView.ColumnAutoWidth = False
        Me.GRIDSTOCK.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDSTOCK.OptionsView.ShowAutoFilterRow = True
        Me.GRIDSTOCK.OptionsView.ShowFooter = True
        Me.GRIDSTOCK.OptionsView.ShowGroupPanel = False
        '
        'SPIECETYPE
        '
        Me.SPIECETYPE.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.SPIECETYPE.AppearanceCell.Options.UseBackColor = True
        Me.SPIECETYPE.Caption = "Piece Type"
        Me.SPIECETYPE.FieldName = "PIECETYPE"
        Me.SPIECETYPE.Name = "SPIECETYPE"
        Me.SPIECETYPE.Visible = True
        Me.SPIECETYPE.VisibleIndex = 0
        Me.SPIECETYPE.Width = 100
        '
        'SUNIT
        '
        Me.SUNIT.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.SUNIT.AppearanceCell.Options.UseBackColor = True
        Me.SUNIT.Caption = "Unit"
        Me.SUNIT.FieldName = "UNIT"
        Me.SUNIT.Name = "SUNIT"
        Me.SUNIT.Visible = True
        Me.SUNIT.VisibleIndex = 1
        Me.SUNIT.Width = 100
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GridColumn4.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn4.Caption = "Pcs"
        Me.GridColumn4.DisplayFormat.FormatString = "0"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "PCS"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GridColumn5.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn5.Caption = "Mtrs"
        Me.GridColumn5.DisplayFormat.FormatString = "0.00"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "MTRS"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 100
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(12, 38)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(752, 497)
        Me.GRIDBILLDETAILS.TabIndex = 447
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDBILL.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDBILL.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMNAME, Me.GCATEGORY, Me.GMILLNAME, Me.GDESIGNNO, Me.GSHADE, Me.GPCS, Me.GMTRS, Me.GORDERTOTALPCS, Me.GPENDINGMTRS, Me.GBALPCS, Me.GPENDINGPCS})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsMenu.EnableColumnMenu = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowFooter = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 180
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 1
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 2
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 3
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 4
        '
        'GPCS
        '
        Me.GPCS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GPCS.AppearanceCell.Options.UseBackColor = True
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 5
        '
        'GMTRS
        '
        Me.GMTRS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 6
        '
        'GORDERTOTALPCS
        '
        Me.GORDERTOTALPCS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.GORDERTOTALPCS.AppearanceCell.Options.UseBackColor = True
        Me.GORDERTOTALPCS.Caption = "Total Order"
        Me.GORDERTOTALPCS.DisplayFormat.FormatString = "0"
        Me.GORDERTOTALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GORDERTOTALPCS.FieldName = "ORDERPCS"
        Me.GORDERTOTALPCS.Name = "GORDERTOTALPCS"
        Me.GORDERTOTALPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GORDERTOTALPCS.Visible = True
        Me.GORDERTOTALPCS.VisibleIndex = 7
        '
        'GPENDINGMTRS
        '
        Me.GPENDINGMTRS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.GPENDINGMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GPENDINGMTRS.Caption = "Pending Order"
        Me.GPENDINGMTRS.DisplayFormat.FormatString = "0.00"
        Me.GPENDINGMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGMTRS.FieldName = "PENDINGMTRS"
        Me.GPENDINGMTRS.Name = "GPENDINGMTRS"
        Me.GPENDINGMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPENDINGMTRS.Visible = True
        Me.GPENDINGMTRS.VisibleIndex = 8
        '
        'GBALPCS
        '
        Me.GBALPCS.Caption = "Bal Stock"
        Me.GBALPCS.DisplayFormat.FormatString = "0"
        Me.GBALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALPCS.FieldName = "BALPCS"
        Me.GBALPCS.Name = "GBALPCS"
        Me.GBALPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALPCS.Visible = True
        Me.GBALPCS.VisibleIndex = 9
        '
        'GPENDINGPCS
        '
        Me.GPENDINGPCS.Caption = "Pending Pcs"
        Me.GPENDINGPCS.DisplayFormat.FormatString = "0"
        Me.GPENDINGPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGPCS.FieldName = "PENDINGPCS"
        Me.GPENDINGPCS.Name = "GPENDINGPCS"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(509, 541)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(595, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 430
        Me.ToolStrip1.Text = "v"
        '
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.NEELAMSILKIND.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Export to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SaleOrderVsStockGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1264, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleOrderVsStockGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale Order Vs Stock Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDORDERDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDORDER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERTOTALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents GRIDSTOCKDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDSTOCK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SPIECETYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDORDERDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDORDER As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ONAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ODUEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGPCS As DevExpress.XtraGrid.Columns.GridColumn
End Class
