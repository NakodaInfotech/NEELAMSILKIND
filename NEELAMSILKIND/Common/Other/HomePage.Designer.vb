<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomePage
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.GBYARNSTOCK = New System.Windows.Forms.GroupBox()
        Me.GRIDYARNDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDYARN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GYARNQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOXNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBSTOCK = New System.Windows.Forms.GroupBox()
        Me.GRIDSTOCKDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDSTOCK = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBPURORDER = New System.Windows.Forms.GroupBox()
        Me.GRIDPODETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDPO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPONAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOYARNQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELIVERYAT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBSALEORDER = New System.Windows.Forms.GroupBox()
        Me.GRIDSODETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDSO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSONAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSODESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBPJOBORDER = New System.Windows.Forms.GroupBox()
        Me.GRIDJODETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDJO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GJONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJONAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOYARNQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJODELIVERYAT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBRECOUTSTANDING = New System.Windows.Forms.GroupBox()
        Me.GRIDRECDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDREC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel2.SuspendLayout()
        Me.GBYARNSTOCK.SuspendLayout()
        CType(Me.GRIDYARNDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDYARN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSTOCK.SuspendLayout()
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBPURORDER.SuspendLayout()
        CType(Me.GRIDPODETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSALEORDER.SuspendLayout()
        CType(Me.GRIDSODETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBPJOBORDER.SuspendLayout()
        CType(Me.GRIDJODETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDJO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBRECOUTSTANDING.SuspendLayout()
        CType(Me.GRIDRECDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.GBYARNSTOCK)
        Me.BlendPanel2.Controls.Add(Me.GBSTOCK)
        Me.BlendPanel2.Controls.Add(Me.GBPURORDER)
        Me.BlendPanel2.Controls.Add(Me.GBSALEORDER)
        Me.BlendPanel2.Controls.Add(Me.GBPJOBORDER)
        Me.BlendPanel2.Controls.Add(Me.GBRECOUTSTANDING)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel2.TabIndex = 13
        '
        'GBYARNSTOCK
        '
        Me.GBYARNSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.GBYARNSTOCK.Controls.Add(Me.GRIDYARNDETAILS)
        Me.GBYARNSTOCK.Location = New System.Drawing.Point(12, 3)
        Me.GBYARNSTOCK.Name = "GBYARNSTOCK"
        Me.GBYARNSTOCK.Size = New System.Drawing.Size(872, 290)
        Me.GBYARNSTOCK.TabIndex = 19
        Me.GBYARNSTOCK.TabStop = False
        Me.GBYARNSTOCK.Text = "Yarn Stock Details"
        '
        'GRIDYARNDETAILS
        '
        Me.GRIDYARNDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDYARNDETAILS.Location = New System.Drawing.Point(8, 21)
        Me.GRIDYARNDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDYARNDETAILS.MainView = Me.GRIDYARN
        Me.GRIDYARNDETAILS.Name = "GRIDYARNDETAILS"
        Me.GRIDYARNDETAILS.Size = New System.Drawing.Size(858, 262)
        Me.GRIDYARNDETAILS.TabIndex = 7
        Me.GRIDYARNDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDYARN})
        '
        'GRIDYARN
        '
        Me.GRIDYARN.Appearance.Empty.BackColor = System.Drawing.Color.LemonChiffon
        Me.GRIDYARN.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDYARN.Appearance.Row.BackColor = System.Drawing.Color.LemonChiffon
        Me.GRIDYARN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDYARN.Appearance.Row.Options.UseBackColor = True
        Me.GRIDYARN.Appearance.Row.Options.UseFont = True
        Me.GRIDYARN.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDYARN.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDYARN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GYARNQUALITY, Me.GSHADE, Me.GMILLNAME, Me.GLOTNO, Me.GBOXNO, Me.GGODOWN, Me.GCONES, Me.GBAGS, Me.GWT})
        Me.GRIDYARN.GridControl = Me.GRIDYARNDETAILS
        Me.GRIDYARN.Name = "GRIDYARN"
        Me.GRIDYARN.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDYARN.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDYARN.OptionsBehavior.Editable = False
        Me.GRIDYARN.OptionsView.ColumnAutoWidth = False
        Me.GRIDYARN.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDYARN.OptionsView.ShowAutoFilterRow = True
        Me.GRIDYARN.OptionsView.ShowGroupPanel = False
        '
        'GYARNQUALITY
        '
        Me.GYARNQUALITY.Caption = "Yarn Quality"
        Me.GYARNQUALITY.FieldName = "YARNQUALITY"
        Me.GYARNQUALITY.ImageIndex = 0
        Me.GYARNQUALITY.Name = "GYARNQUALITY"
        Me.GYARNQUALITY.Visible = True
        Me.GYARNQUALITY.VisibleIndex = 0
        Me.GYARNQUALITY.Width = 150
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 1
        Me.GSHADE.Width = 100
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 2
        Me.GMILLNAME.Width = 150
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 3
        '
        'GBOXNO
        '
        Me.GBOXNO.Caption = "Box No"
        Me.GBOXNO.FieldName = "BOXNO"
        Me.GBOXNO.Name = "GBOXNO"
        Me.GBOXNO.Visible = True
        Me.GBOXNO.VisibleIndex = 4
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 5
        '
        'GCONES
        '
        Me.GCONES.Caption = "Cones"
        Me.GCONES.FieldName = "CONES"
        Me.GCONES.Name = "GCONES"
        Me.GCONES.Visible = True
        Me.GCONES.VisibleIndex = 6
        Me.GCONES.Width = 60
        '
        'GWT
        '
        Me.GWT.Caption = "Wt"
        Me.GWT.DisplayFormat.FormatString = "0.00"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 8
        '
        'GBSTOCK
        '
        Me.GBSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.GBSTOCK.Controls.Add(Me.GRIDSTOCKDETAILS)
        Me.GBSTOCK.Location = New System.Drawing.Point(607, 293)
        Me.GBSTOCK.Name = "GBSTOCK"
        Me.GBSTOCK.Size = New System.Drawing.Size(277, 290)
        Me.GBSTOCK.TabIndex = 18
        Me.GBSTOCK.TabStop = False
        Me.GBSTOCK.Text = "Stock Details"
        '
        'GRIDSTOCKDETAILS
        '
        Me.GRIDSTOCKDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCKDETAILS.Location = New System.Drawing.Point(6, 21)
        Me.GRIDSTOCKDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDSTOCKDETAILS.MainView = Me.GRIDSTOCK
        Me.GRIDSTOCKDETAILS.Name = "GRIDSTOCKDETAILS"
        Me.GRIDSTOCKDETAILS.Size = New System.Drawing.Size(265, 262)
        Me.GRIDSTOCKDETAILS.TabIndex = 6
        Me.GRIDSTOCKDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDSTOCK})
        '
        'GRIDSTOCK
        '
        Me.GRIDSTOCK.Appearance.Empty.BackColor = System.Drawing.Color.LemonChiffon
        Me.GRIDSTOCK.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDSTOCK.Appearance.Row.BackColor = System.Drawing.Color.LemonChiffon
        Me.GRIDSTOCK.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.Row.Options.UseBackColor = True
        Me.GRIDSTOCK.Appearance.Row.Options.UseFont = True
        Me.GRIDSTOCK.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDSTOCK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMNAME, Me.GDESIGN, Me.GCATEGORY, Me.GPCS, Me.GMTRS})
        Me.GRIDSTOCK.GridControl = Me.GRIDSTOCKDETAILS
        Me.GRIDSTOCK.Name = "GRIDSTOCK"
        Me.GRIDSTOCK.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDSTOCK.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDSTOCK.OptionsBehavior.Editable = False
        Me.GRIDSTOCK.OptionsView.ColumnAutoWidth = False
        Me.GRIDSTOCK.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDSTOCK.OptionsView.ShowAutoFilterRow = True
        Me.GRIDSTOCK.OptionsView.ShowGroupPanel = False
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.ImageIndex = 0
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 100
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design No"
        Me.GDESIGN.FieldName = "DESIGNNO"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 1
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        '
        'GPCS
        '
        Me.GPCS.AppearanceCell.Options.UseTextOptions = True
        Me.GPCS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0.00"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.ImageIndex = 1
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 2
        Me.GPCS.Width = 60
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
        Me.GMTRS.VisibleIndex = 3
        Me.GMTRS.Width = 60
        '
        'GBPURORDER
        '
        Me.GBPURORDER.BackColor = System.Drawing.Color.Transparent
        Me.GBPURORDER.Controls.Add(Me.GRIDPODETAILS)
        Me.GBPURORDER.Location = New System.Drawing.Point(315, 293)
        Me.GBPURORDER.Name = "GBPURORDER"
        Me.GBPURORDER.Size = New System.Drawing.Size(277, 290)
        Me.GBPURORDER.TabIndex = 17
        Me.GBPURORDER.TabStop = False
        Me.GBPURORDER.Text = "Pending Yarn Purchase Order"
        '
        'GRIDPODETAILS
        '
        Me.GRIDPODETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPODETAILS.Location = New System.Drawing.Point(6, 22)
        Me.GRIDPODETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDPODETAILS.MainView = Me.GRIDPO
        Me.GRIDPODETAILS.Name = "GRIDPODETAILS"
        Me.GRIDPODETAILS.Size = New System.Drawing.Size(265, 262)
        Me.GRIDPODETAILS.TabIndex = 6
        Me.GRIDPODETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDPO})
        '
        'GRIDPO
        '
        Me.GRIDPO.Appearance.Empty.BackColor = System.Drawing.Color.Linen
        Me.GRIDPO.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDPO.Appearance.Row.BackColor = System.Drawing.Color.Linen
        Me.GRIDPO.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPO.Appearance.Row.Options.UseBackColor = True
        Me.GRIDPO.Appearance.Row.Options.UseFont = True
        Me.GRIDPO.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPO.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDPO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GPONO, Me.GPODATE, Me.GPONAME, Me.GPOMILLNAME, Me.GPOYARNQUALITY, Me.GPOSHADE, Me.GPOQTY, Me.GDELIVERYAT})
        Me.GRIDPO.GridControl = Me.GRIDPODETAILS
        Me.GRIDPO.Name = "GRIDPO"
        Me.GRIDPO.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDPO.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDPO.OptionsBehavior.Editable = False
        Me.GRIDPO.OptionsView.ColumnAutoWidth = False
        Me.GRIDPO.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDPO.OptionsView.ShowAutoFilterRow = True
        Me.GRIDPO.OptionsView.ShowGroupPanel = False
        '
        'GPONO
        '
        Me.GPONO.Caption = "PO No"
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 0
        Me.GPONO.Width = 60
        '
        'GPODATE
        '
        Me.GPODATE.Caption = "Date"
        Me.GPODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GPODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GPODATE.FieldName = "PODATE"
        Me.GPODATE.Name = "GPODATE"
        Me.GPODATE.Visible = True
        Me.GPODATE.VisibleIndex = 1
        '
        'GPONAME
        '
        Me.GPONAME.Caption = "Name"
        Me.GPONAME.FieldName = "NAME"
        Me.GPONAME.ImageIndex = 0
        Me.GPONAME.Name = "GPONAME"
        Me.GPONAME.Visible = True
        Me.GPONAME.VisibleIndex = 2
        Me.GPONAME.Width = 200
        '
        'GPOMILLNAME
        '
        Me.GPOMILLNAME.Caption = "Mill Name"
        Me.GPOMILLNAME.FieldName = "MILLNAME"
        Me.GPOMILLNAME.Name = "GPOMILLNAME"
        Me.GPOMILLNAME.Visible = True
        Me.GPOMILLNAME.VisibleIndex = 3
        Me.GPOMILLNAME.Width = 150
        '
        'GPOYARNQUALITY
        '
        Me.GPOYARNQUALITY.Caption = "Yarn Quality"
        Me.GPOYARNQUALITY.FieldName = "YARNQUALITY"
        Me.GPOYARNQUALITY.Name = "GPOYARNQUALITY"
        Me.GPOYARNQUALITY.Visible = True
        Me.GPOYARNQUALITY.VisibleIndex = 4
        Me.GPOYARNQUALITY.Width = 150
        '
        'GPOSHADE
        '
        Me.GPOSHADE.Caption = "Shade"
        Me.GPOSHADE.FieldName = "SHADE"
        Me.GPOSHADE.Name = "GPOSHADE"
        Me.GPOSHADE.Visible = True
        Me.GPOSHADE.VisibleIndex = 5
        Me.GPOSHADE.Width = 120
        '
        'GPOQTY
        '
        Me.GPOQTY.Caption = "Qty"
        Me.GPOQTY.DisplayFormat.FormatString = "0.00"
        Me.GPOQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPOQTY.FieldName = "QTY"
        Me.GPOQTY.Name = "GPOQTY"
        Me.GPOQTY.Visible = True
        Me.GPOQTY.VisibleIndex = 6
        '
        'GDELIVERYAT
        '
        Me.GDELIVERYAT.Caption = "Delivery At"
        Me.GDELIVERYAT.FieldName = "DELIVERYAT"
        Me.GDELIVERYAT.Name = "GDELIVERYAT"
        Me.GDELIVERYAT.Visible = True
        Me.GDELIVERYAT.VisibleIndex = 7
        Me.GDELIVERYAT.Width = 150
        '
        'GBSALEORDER
        '
        Me.GBSALEORDER.BackColor = System.Drawing.Color.Transparent
        Me.GBSALEORDER.Controls.Add(Me.GRIDSODETAILS)
        Me.GBSALEORDER.Location = New System.Drawing.Point(14, 293)
        Me.GBSALEORDER.Name = "GBSALEORDER"
        Me.GBSALEORDER.Size = New System.Drawing.Size(277, 290)
        Me.GBSALEORDER.TabIndex = 16
        Me.GBSALEORDER.TabStop = False
        Me.GBSALEORDER.Text = "Pending Sale Order"
        '
        'GRIDSODETAILS
        '
        Me.GRIDSODETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSODETAILS.Location = New System.Drawing.Point(6, 22)
        Me.GRIDSODETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDSODETAILS.MainView = Me.GRIDSO
        Me.GRIDSODETAILS.Name = "GRIDSODETAILS"
        Me.GRIDSODETAILS.Size = New System.Drawing.Size(265, 262)
        Me.GRIDSODETAILS.TabIndex = 6
        Me.GRIDSODETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDSO})
        '
        'GRIDSO
        '
        Me.GRIDSO.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDSO.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDSO.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDSO.Appearance.Row.BorderColor = System.Drawing.Color.Black
        Me.GRIDSO.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSO.Appearance.Row.Options.UseBackColor = True
        Me.GRIDSO.Appearance.Row.Options.UseBorderColor = True
        Me.GRIDSO.Appearance.Row.Options.UseFont = True
        Me.GRIDSO.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSO.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDSO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSONAME, Me.GSOITEMNAME, Me.GSODESIGN, Me.GSOCOLOR, Me.GSOPCS})
        Me.GRIDSO.GridControl = Me.GRIDSODETAILS
        Me.GRIDSO.Name = "GRIDSO"
        Me.GRIDSO.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDSO.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDSO.OptionsBehavior.Editable = False
        Me.GRIDSO.OptionsView.ColumnAutoWidth = False
        Me.GRIDSO.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDSO.OptionsView.ShowAutoFilterRow = True
        Me.GRIDSO.OptionsView.ShowGroupPanel = False
        '
        'GSONAME
        '
        Me.GSONAME.Caption = "Name"
        Me.GSONAME.FieldName = "NAME"
        Me.GSONAME.ImageIndex = 0
        Me.GSONAME.Name = "GSONAME"
        Me.GSONAME.Visible = True
        Me.GSONAME.VisibleIndex = 0
        Me.GSONAME.Width = 200
        '
        'GSOITEMNAME
        '
        Me.GSOITEMNAME.Caption = "Item Name"
        Me.GSOITEMNAME.FieldName = "ITEMNAME"
        Me.GSOITEMNAME.Name = "GSOITEMNAME"
        Me.GSOITEMNAME.Visible = True
        Me.GSOITEMNAME.VisibleIndex = 1
        Me.GSOITEMNAME.Width = 100
        '
        'GSODESIGN
        '
        Me.GSODESIGN.Caption = "Design No"
        Me.GSODESIGN.FieldName = "DESIGNNO"
        Me.GSODESIGN.Name = "GSODESIGN"
        Me.GSODESIGN.Visible = True
        Me.GSODESIGN.VisibleIndex = 2
        Me.GSODESIGN.Width = 150
        '
        'GSOCOLOR
        '
        Me.GSOCOLOR.Caption = "Shade"
        Me.GSOCOLOR.FieldName = "COLOR"
        Me.GSOCOLOR.Name = "GSOCOLOR"
        '
        'GSOPCS
        '
        Me.GSOPCS.AppearanceCell.Options.UseTextOptions = True
        Me.GSOPCS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GSOPCS.Caption = "Pcs"
        Me.GSOPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSOPCS.FieldName = "PCS"
        Me.GSOPCS.ImageIndex = 1
        Me.GSOPCS.Name = "GSOPCS"
        Me.GSOPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSOPCS.Visible = True
        Me.GSOPCS.VisibleIndex = 3
        Me.GSOPCS.Width = 70
        '
        'GBPJOBORDER
        '
        Me.GBPJOBORDER.BackColor = System.Drawing.Color.Transparent
        Me.GBPJOBORDER.Controls.Add(Me.GRIDJODETAILS)
        Me.GBPJOBORDER.Location = New System.Drawing.Point(909, 293)
        Me.GBPJOBORDER.Name = "GBPJOBORDER"
        Me.GBPJOBORDER.Size = New System.Drawing.Size(315, 290)
        Me.GBPJOBORDER.TabIndex = 15
        Me.GBPJOBORDER.TabStop = False
        Me.GBPJOBORDER.Text = "Job Order"
        '
        'GRIDJODETAILS
        '
        Me.GRIDJODETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJODETAILS.Location = New System.Drawing.Point(6, 21)
        Me.GRIDJODETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDJODETAILS.MainView = Me.GRIDJO
        Me.GRIDJODETAILS.Name = "GRIDJODETAILS"
        Me.GRIDJODETAILS.Size = New System.Drawing.Size(303, 262)
        Me.GRIDJODETAILS.TabIndex = 7
        Me.GRIDJODETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDJO})
        '
        'GRIDJO
        '
        Me.GRIDJO.Appearance.Empty.BackColor = System.Drawing.Color.Linen
        Me.GRIDJO.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDJO.Appearance.Row.BackColor = System.Drawing.Color.Linen
        Me.GRIDJO.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJO.Appearance.Row.Options.UseBackColor = True
        Me.GRIDJO.Appearance.Row.Options.UseFont = True
        Me.GRIDJO.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJO.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDJO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GJONO, Me.GJODATE, Me.GJONAME, Me.GJOMILLNAME, Me.GJOYARNQUALITY, Me.GJOSHADE, Me.GJOQTY, Me.GJODELIVERYAT})
        Me.GRIDJO.GridControl = Me.GRIDJODETAILS
        Me.GRIDJO.Name = "GRIDJO"
        Me.GRIDJO.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDJO.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDJO.OptionsBehavior.Editable = False
        Me.GRIDJO.OptionsView.ColumnAutoWidth = False
        Me.GRIDJO.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDJO.OptionsView.ShowAutoFilterRow = True
        Me.GRIDJO.OptionsView.ShowGroupPanel = False
        '
        'GJONO
        '
        Me.GJONO.Caption = "PO No"
        Me.GJONO.FieldName = "JONO"
        Me.GJONO.Name = "GJONO"
        Me.GJONO.Visible = True
        Me.GJONO.VisibleIndex = 0
        Me.GJONO.Width = 60
        '
        'GJODATE
        '
        Me.GJODATE.Caption = "Date"
        Me.GJODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GJODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GJODATE.FieldName = "JODATE"
        Me.GJODATE.Name = "GJODATE"
        Me.GJODATE.Visible = True
        Me.GJODATE.VisibleIndex = 1
        '
        'GJONAME
        '
        Me.GJONAME.Caption = "Name"
        Me.GJONAME.FieldName = "NAME"
        Me.GJONAME.ImageIndex = 0
        Me.GJONAME.Name = "GJONAME"
        Me.GJONAME.Visible = True
        Me.GJONAME.VisibleIndex = 2
        Me.GJONAME.Width = 200
        '
        'GJOMILLNAME
        '
        Me.GJOMILLNAME.Caption = "Mill Name"
        Me.GJOMILLNAME.FieldName = "MILLNAME"
        Me.GJOMILLNAME.Name = "GJOMILLNAME"
        Me.GJOMILLNAME.Visible = True
        Me.GJOMILLNAME.VisibleIndex = 3
        Me.GJOMILLNAME.Width = 150
        '
        'GJOYARNQUALITY
        '
        Me.GJOYARNQUALITY.Caption = "Yarn Quality"
        Me.GJOYARNQUALITY.FieldName = "YARNQUALITY"
        Me.GJOYARNQUALITY.Name = "GJOYARNQUALITY"
        Me.GJOYARNQUALITY.Visible = True
        Me.GJOYARNQUALITY.VisibleIndex = 4
        Me.GJOYARNQUALITY.Width = 150
        '
        'GJOSHADE
        '
        Me.GJOSHADE.Caption = "Shade"
        Me.GJOSHADE.FieldName = "SHADE"
        Me.GJOSHADE.Name = "GJOSHADE"
        Me.GJOSHADE.Visible = True
        Me.GJOSHADE.VisibleIndex = 5
        Me.GJOSHADE.Width = 120
        '
        'GJOQTY
        '
        Me.GJOQTY.Caption = "Qty"
        Me.GJOQTY.DisplayFormat.FormatString = "0.00"
        Me.GJOQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJOQTY.FieldName = "QTY"
        Me.GJOQTY.Name = "GJOQTY"
        Me.GJOQTY.Visible = True
        Me.GJOQTY.VisibleIndex = 6
        '
        'GJODELIVERYAT
        '
        Me.GJODELIVERYAT.Caption = "Delivery At"
        Me.GJODELIVERYAT.FieldName = "DELIVERYAT"
        Me.GJODELIVERYAT.Name = "GJODELIVERYAT"
        Me.GJODELIVERYAT.Visible = True
        Me.GJODELIVERYAT.VisibleIndex = 7
        Me.GJODELIVERYAT.Width = 150
        '
        'GBRECOUTSTANDING
        '
        Me.GBRECOUTSTANDING.BackColor = System.Drawing.Color.Transparent
        Me.GBRECOUTSTANDING.Controls.Add(Me.GRIDRECDETAILS)
        Me.GBRECOUTSTANDING.Location = New System.Drawing.Point(907, 3)
        Me.GBRECOUTSTANDING.Name = "GBRECOUTSTANDING"
        Me.GBRECOUTSTANDING.Size = New System.Drawing.Size(315, 290)
        Me.GBRECOUTSTANDING.TabIndex = 14
        Me.GBRECOUTSTANDING.TabStop = False
        Me.GBRECOUTSTANDING.Text = "Rec Outstanding"
        '
        'GRIDRECDETAILS
        '
        Me.GRIDRECDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDRECDETAILS.Location = New System.Drawing.Point(2, 21)
        Me.GRIDRECDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDRECDETAILS.MainView = Me.GRIDREC
        Me.GRIDRECDETAILS.Name = "GRIDRECDETAILS"
        Me.GRIDRECDETAILS.Size = New System.Drawing.Size(313, 262)
        Me.GRIDRECDETAILS.TabIndex = 5
        Me.GRIDRECDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDREC})
        '
        'GRIDREC
        '
        Me.GRIDREC.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GRIDREC.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDREC.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GRIDREC.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDREC.Appearance.Row.Options.UseBackColor = True
        Me.GRIDREC.Appearance.Row.Options.UseFont = True
        Me.GRIDREC.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDREC.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDREC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GRBALANCE})
        Me.GRIDREC.GridControl = Me.GRIDRECDETAILS
        Me.GRIDREC.Name = "GRIDREC"
        Me.GRIDREC.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDREC.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDREC.OptionsBehavior.Editable = False
        Me.GRIDREC.OptionsView.ColumnAutoWidth = False
        Me.GRIDREC.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDREC.OptionsView.ShowAutoFilterRow = True
        Me.GRIDREC.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 200
        '
        'GRBALANCE
        '
        Me.GRBALANCE.AppearanceCell.Options.UseTextOptions = True
        Me.GRBALANCE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GRBALANCE.Caption = "Amount"
        Me.GRBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GRBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRBALANCE.FieldName = "BALANCE"
        Me.GRBALANCE.ImageIndex = 1
        Me.GRBALANCE.Name = "GRBALANCE"
        Me.GRBALANCE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRBALANCE.Visible = True
        Me.GRBALANCE.VisibleIndex = 1
        Me.GRBALANCE.Width = 70
        '
        'GBAGS
        '
        Me.GBAGS.Caption = "Bags"
        Me.GBAGS.DisplayFormat.FormatString = "0"
        Me.GBAGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBAGS.FieldName = "BAGS"
        Me.GBAGS.Name = "GBAGS"
        Me.GBAGS.Visible = True
        Me.GBAGS.VisibleIndex = 7
        Me.GBAGS.Width = 50
        '
        'HomePage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "HomePage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.GBYARNSTOCK.ResumeLayout(False)
        CType(Me.GRIDYARNDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDYARN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSTOCK.ResumeLayout(False)
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBPURORDER.ResumeLayout(False)
        CType(Me.GRIDPODETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSALEORDER.ResumeLayout(False)
        CType(Me.GRIDSODETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBPJOBORDER.ResumeLayout(False)
        CType(Me.GRIDJODETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDJO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBRECOUTSTANDING.ResumeLayout(False)
        CType(Me.GRIDRECDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents GBRECOUTSTANDING As System.Windows.Forms.GroupBox
    Private WithEvents GRIDRECDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDREC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBSTOCK As System.Windows.Forms.GroupBox
    Private WithEvents GRIDSTOCKDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDSTOCK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBPURORDER As System.Windows.Forms.GroupBox
    Private WithEvents GRIDPODETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDPO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GPONAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBSALEORDER As System.Windows.Forms.GroupBox
    Private WithEvents GRIDSODETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDSO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSONAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBYARNSTOCK As GroupBox
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSODESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBPJOBORDER As GroupBox
    Private WithEvents GRIDYARNDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDYARN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GYARNQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOXNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOYARNQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELIVERYAT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDJODETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDJO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GJONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJONAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOYARNQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJODELIVERYAT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBAGS As DevExpress.XtraGrid.Columns.GridColumn
End Class
