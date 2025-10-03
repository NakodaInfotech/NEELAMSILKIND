<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignCardCostDetails
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
        Me.GCOSTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWARPTL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEFTTL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPICKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREEDSPACE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALACTUALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALACTUALCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDHARA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDHARACOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDHARAACTCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGECOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGEACTCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEAVING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEAVINGCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEAVINGACTCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOBINCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOBINACTCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERACTCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMARGINCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMARGINACTCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALACTCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GACTUALPICKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALCOSTDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 9
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 544)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 651
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
        Me.cmdok.Location = New System.Drawing.Point(534, 544)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 650
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1204, 510)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCOSTNO, Me.GDATE, Me.GDESIGNNO, Me.GITEMNAME, Me.GCATEGORY, Me.GWARPTL, Me.GWEFTTL, Me.GPICKS, Me.GACTUALPICKS, Me.GREED, Me.GREEDSPACE, Me.GTOTALWT, Me.GTOTALCOST, Me.GTOTALACTUALWT, Me.GTOTALACTUALCOST, Me.GDHARA, Me.GDHARACOST, Me.GDHARAACTCOST, Me.GWASTAGE, Me.GWASTAGECOST, Me.GWASTAGEACTCOST, Me.GWEAVING, Me.GWEAVINGCOST, Me.GWEAVINGACTCOST, Me.GBOBINCOST, Me.GBOBINACTCOST, Me.GOTHERCOST, Me.GOTHERACTCOST, Me.GMARGINCOST, Me.GMARGINACTCOST, Me.GFINALCOST, Me.GFINALACTCOST, Me.GFINALCOSTDIFF})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCOSTNO
        '
        Me.GCOSTNO.Caption = "Cost No"
        Me.GCOSTNO.FieldName = "COSTNO"
        Me.GCOSTNO.Name = "GCOSTNO"
        Me.GCOSTNO.Visible = True
        Me.GCOSTNO.VisibleIndex = 0
        Me.GCOSTNO.Width = 50
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "COSTDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 2
        Me.GDESIGNNO.Width = 250
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 3
        Me.GITEMNAME.Width = 250
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
        'GWARPTL
        '
        Me.GWARPTL.Caption = "Warp TL"
        Me.GWARPTL.DisplayFormat.FormatString = "0"
        Me.GWARPTL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWARPTL.FieldName = "WARPTL"
        Me.GWARPTL.Name = "GWARPTL"
        Me.GWARPTL.Visible = True
        Me.GWARPTL.VisibleIndex = 5
        '
        'GWEFTTL
        '
        Me.GWEFTTL.Caption = "Weft TL"
        Me.GWEFTTL.DisplayFormat.FormatString = "0"
        Me.GWEFTTL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWEFTTL.FieldName = "WEFTL"
        Me.GWEFTTL.Name = "GWEFTTL"
        Me.GWEFTTL.Visible = True
        Me.GWEFTTL.VisibleIndex = 6
        '
        'GPICKS
        '
        Me.GPICKS.Caption = "Picks"
        Me.GPICKS.FieldName = "PICKS"
        Me.GPICKS.Name = "GPICKS"
        Me.GPICKS.Visible = True
        Me.GPICKS.VisibleIndex = 7
        '
        'GREED
        '
        Me.GREED.Caption = "Reed"
        Me.GREED.FieldName = "REED"
        Me.GREED.Name = "GREED"
        Me.GREED.Visible = True
        Me.GREED.VisibleIndex = 9
        '
        'GREEDSPACE
        '
        Me.GREEDSPACE.Caption = "Reed Space"
        Me.GREEDSPACE.DisplayFormat.FormatString = "0.00"
        Me.GREEDSPACE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREEDSPACE.FieldName = "REEDSPACE"
        Me.GREEDSPACE.Name = "GREEDSPACE"
        Me.GREEDSPACE.Visible = True
        Me.GREEDSPACE.VisibleIndex = 10
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total Wt"
        Me.GTOTALWT.DisplayFormat.FormatString = "0.000"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 11
        Me.GTOTALWT.Width = 80
        '
        'GTOTALCOST
        '
        Me.GTOTALCOST.Caption = "Total Cost"
        Me.GTOTALCOST.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCOST.FieldName = "TCOST"
        Me.GTOTALCOST.Name = "GTOTALCOST"
        Me.GTOTALCOST.Visible = True
        Me.GTOTALCOST.VisibleIndex = 12
        Me.GTOTALCOST.Width = 80
        '
        'GTOTALACTUALWT
        '
        Me.GTOTALACTUALWT.Caption = "Actual Wt"
        Me.GTOTALACTUALWT.FieldName = "TACTWT"
        Me.GTOTALACTUALWT.Name = "GTOTALACTUALWT"
        Me.GTOTALACTUALWT.Visible = True
        Me.GTOTALACTUALWT.VisibleIndex = 13
        Me.GTOTALACTUALWT.Width = 80
        '
        'GTOTALACTUALCOST
        '
        Me.GTOTALACTUALCOST.Caption = "Actual Cost"
        Me.GTOTALACTUALCOST.FieldName = "TACTCOST"
        Me.GTOTALACTUALCOST.Name = "GTOTALACTUALCOST"
        Me.GTOTALACTUALCOST.Visible = True
        Me.GTOTALACTUALCOST.VisibleIndex = 14
        Me.GTOTALACTUALCOST.Width = 80
        '
        'GDHARA
        '
        Me.GDHARA.Caption = "Dhara"
        Me.GDHARA.DisplayFormat.FormatString = "0"
        Me.GDHARA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDHARA.FieldName = "DHARA"
        Me.GDHARA.Name = "GDHARA"
        Me.GDHARA.Visible = True
        Me.GDHARA.VisibleIndex = 15
        '
        'GDHARACOST
        '
        Me.GDHARACOST.Caption = "Dhara Cost"
        Me.GDHARACOST.DisplayFormat.FormatString = "0.00"
        Me.GDHARACOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDHARACOST.FieldName = "DHARACOST"
        Me.GDHARACOST.Name = "GDHARACOST"
        Me.GDHARACOST.Visible = True
        Me.GDHARACOST.VisibleIndex = 16
        '
        'GDHARAACTCOST
        '
        Me.GDHARAACTCOST.Caption = "Dhara Act Cost"
        Me.GDHARAACTCOST.DisplayFormat.FormatString = "0.00"
        Me.GDHARAACTCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDHARAACTCOST.FieldName = "DHARAACTCOST"
        Me.GDHARAACTCOST.Name = "GDHARAACTCOST"
        Me.GDHARAACTCOST.Visible = True
        Me.GDHARAACTCOST.VisibleIndex = 17
        '
        'GWASTAGE
        '
        Me.GWASTAGE.Caption = "Wastage"
        Me.GWASTAGE.DisplayFormat.FormatString = "0.00"
        Me.GWASTAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWASTAGE.FieldName = "WASTAGE"
        Me.GWASTAGE.Name = "GWASTAGE"
        Me.GWASTAGE.Visible = True
        Me.GWASTAGE.VisibleIndex = 18
        '
        'GWASTAGECOST
        '
        Me.GWASTAGECOST.Caption = "Was Cost"
        Me.GWASTAGECOST.DisplayFormat.FormatString = "0.00"
        Me.GWASTAGECOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWASTAGECOST.FieldName = "WASTAGECOST"
        Me.GWASTAGECOST.Name = "GWASTAGECOST"
        Me.GWASTAGECOST.Visible = True
        Me.GWASTAGECOST.VisibleIndex = 19
        '
        'GWASTAGEACTCOST
        '
        Me.GWASTAGEACTCOST.Caption = "Was Act Cost"
        Me.GWASTAGEACTCOST.DisplayFormat.FormatString = "0.00"
        Me.GWASTAGEACTCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWASTAGEACTCOST.FieldName = "WASTAGEACTCOST"
        Me.GWASTAGEACTCOST.Name = "GWASTAGEACTCOST"
        Me.GWASTAGEACTCOST.Visible = True
        Me.GWASTAGEACTCOST.VisibleIndex = 20
        '
        'GWEAVING
        '
        Me.GWEAVING.Caption = "Weaving"
        Me.GWEAVING.DisplayFormat.FormatString = "0.00"
        Me.GWEAVING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWEAVING.FieldName = "WEAVING"
        Me.GWEAVING.Name = "GWEAVING"
        Me.GWEAVING.Visible = True
        Me.GWEAVING.VisibleIndex = 21
        '
        'GWEAVINGCOST
        '
        Me.GWEAVINGCOST.Caption = "Weaving Cost"
        Me.GWEAVINGCOST.DisplayFormat.FormatString = "0.00"
        Me.GWEAVINGCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWEAVINGCOST.FieldName = "WEAVINGCOST"
        Me.GWEAVINGCOST.Name = "GWEAVINGCOST"
        Me.GWEAVINGCOST.Visible = True
        Me.GWEAVINGCOST.VisibleIndex = 22
        '
        'GWEAVINGACTCOST
        '
        Me.GWEAVINGACTCOST.Caption = "Weaving Act Cost"
        Me.GWEAVINGACTCOST.DisplayFormat.FormatString = "0.00"
        Me.GWEAVINGACTCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWEAVINGACTCOST.FieldName = "WEAVINGACTCOST"
        Me.GWEAVINGACTCOST.Name = "GWEAVINGACTCOST"
        Me.GWEAVINGACTCOST.Visible = True
        Me.GWEAVINGACTCOST.VisibleIndex = 23
        '
        'GBOBINCOST
        '
        Me.GBOBINCOST.Caption = "Bob Cost"
        Me.GBOBINCOST.DisplayFormat.FormatString = "0.00"
        Me.GBOBINCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBOBINCOST.FieldName = "BOBINCOST"
        Me.GBOBINCOST.Name = "GBOBINCOST"
        Me.GBOBINCOST.Visible = True
        Me.GBOBINCOST.VisibleIndex = 24
        '
        'GBOBINACTCOST
        '
        Me.GBOBINACTCOST.Caption = "Bob Act Cost"
        Me.GBOBINACTCOST.DisplayFormat.FormatString = "0.00"
        Me.GBOBINACTCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBOBINACTCOST.FieldName = "BOBINACTCOST"
        Me.GBOBINACTCOST.Name = "GBOBINACTCOST"
        Me.GBOBINACTCOST.Visible = True
        Me.GBOBINACTCOST.VisibleIndex = 25
        '
        'GOTHERCOST
        '
        Me.GOTHERCOST.Caption = "Other Cost"
        Me.GOTHERCOST.DisplayFormat.FormatString = "0.00"
        Me.GOTHERCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERCOST.FieldName = "OTHERCOST"
        Me.GOTHERCOST.Name = "GOTHERCOST"
        Me.GOTHERCOST.Visible = True
        Me.GOTHERCOST.VisibleIndex = 26
        '
        'GOTHERACTCOST
        '
        Me.GOTHERACTCOST.Caption = "Other Act Cost"
        Me.GOTHERACTCOST.DisplayFormat.FormatString = "0.00"
        Me.GOTHERACTCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERACTCOST.FieldName = "OTHERACTCOST"
        Me.GOTHERACTCOST.Name = "GOTHERACTCOST"
        Me.GOTHERACTCOST.Visible = True
        Me.GOTHERACTCOST.VisibleIndex = 27
        '
        'GMARGINCOST
        '
        Me.GMARGINCOST.Caption = "Margin (Cost)"
        Me.GMARGINCOST.DisplayFormat.FormatString = "0.00"
        Me.GMARGINCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMARGINCOST.FieldName = "MARGINCOST"
        Me.GMARGINCOST.Name = "GMARGINCOST"
        Me.GMARGINCOST.Visible = True
        Me.GMARGINCOST.VisibleIndex = 28
        '
        'GMARGINACTCOST
        '
        Me.GMARGINACTCOST.Caption = "Margin (Act Cost)"
        Me.GMARGINACTCOST.DisplayFormat.FormatString = "0.00"
        Me.GMARGINACTCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMARGINACTCOST.FieldName = "MARGINACTCOST"
        Me.GMARGINACTCOST.Name = "GMARGINACTCOST"
        Me.GMARGINACTCOST.Visible = True
        Me.GMARGINACTCOST.VisibleIndex = 29
        '
        'GFINALCOST
        '
        Me.GFINALCOST.Caption = "Final Cost"
        Me.GFINALCOST.DisplayFormat.FormatString = "0.00"
        Me.GFINALCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFINALCOST.FieldName = "FINALCOST"
        Me.GFINALCOST.Name = "GFINALCOST"
        Me.GFINALCOST.Visible = True
        Me.GFINALCOST.VisibleIndex = 30
        '
        'GFINALACTCOST
        '
        Me.GFINALACTCOST.Caption = "Final Act Cost"
        Me.GFINALACTCOST.DisplayFormat.FormatString = "0.00"
        Me.GFINALACTCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFINALACTCOST.FieldName = "FINALACTCOST"
        Me.GFINALACTCOST.Name = "GFINALACTCOST"
        Me.GFINALACTCOST.Visible = True
        Me.GFINALACTCOST.VisibleIndex = 31
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.TOOLREFRESH, Me.PrintToolStripButton, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.NEELAMSILKIND.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.NEELAMSILKIND.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GACTUALPICKS
        '
        Me.GACTUALPICKS.Caption = "Act Picks"
        Me.GACTUALPICKS.FieldName = "ACTUALPICKS"
        Me.GACTUALPICKS.Name = "GACTUALPICKS"
        Me.GACTUALPICKS.Visible = True
        Me.GACTUALPICKS.VisibleIndex = 8
        '
        'GFINALCOSTDIFF
        '
        Me.GFINALCOSTDIFF.Caption = "Final Cost Diff"
        Me.GFINALCOSTDIFF.DisplayFormat.FormatString = "0.00"
        Me.GFINALCOSTDIFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFINALCOSTDIFF.FieldName = "FINALCOSTDIFF"
        Me.GFINALCOSTDIFF.Name = "GFINALCOSTDIFF"
        Me.GFINALCOSTDIFF.Visible = True
        Me.GFINALCOSTDIFF.VisibleIndex = 32
        '
        'DesignCardCostDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignCardCostDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Cost Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCOSTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWARPTL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEFTTL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPICKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREEDSPACE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALACTUALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALACTUALCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GDHARA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDHARACOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDHARAACTCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGECOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGEACTCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEAVING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEAVINGCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEAVINGACTCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOBINCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOBINACTCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERACTCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMARGINCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMARGINACTCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALACTCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACTUALPICKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALCOSTDIFF As DevExpress.XtraGrid.Columns.GridColumn
End Class
