<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPDetails
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
        Me.GMRPNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSUENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSUEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWARPWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEFTWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYARNQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALREQ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEAVERSTOCK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGSTOCK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWNSTOCK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDEREDSTOCK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNEWORDERSTOCK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALMATCHING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPODONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 510)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GMRPNO, Me.GDATE, Me.GNAME, Me.GISSUENO, Me.GISSUEDATE, Me.GWARPWASTAGE, Me.GWEFTWASTAGE, Me.GYARNQUALITY, Me.GSHADE, Me.GTOTALREQ, Me.GWEAVERSTOCK, Me.GPENDINGSTOCK, Me.GGODOWNSTOCK, Me.GORDEREDSTOCK, Me.GNEWORDERSTOCK, Me.GTOTALMATCHING, Me.GREMARKS, Me.GPODONE})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GMRPNO
        '
        Me.GMRPNO.Caption = "MRP No"
        Me.GMRPNO.FieldName = "MRPNO"
        Me.GMRPNO.Name = "GMRPNO"
        Me.GMRPNO.Visible = True
        Me.GMRPNO.VisibleIndex = 0
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 200
        '
        'GISSUENO
        '
        Me.GISSUENO.Caption = "Issue No"
        Me.GISSUENO.FieldName = "ISSUENO"
        Me.GISSUENO.Name = "GISSUENO"
        Me.GISSUENO.Visible = True
        Me.GISSUENO.VisibleIndex = 3
        '
        'GISSUEDATE
        '
        Me.GISSUEDATE.Caption = "Iss Date"
        Me.GISSUEDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GISSUEDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GISSUEDATE.FieldName = "ISSUEDATE"
        Me.GISSUEDATE.Name = "GISSUEDATE"
        Me.GISSUEDATE.Visible = True
        Me.GISSUEDATE.VisibleIndex = 4
        Me.GISSUEDATE.Width = 80
        '
        'GWARPWASTAGE
        '
        Me.GWARPWASTAGE.Caption = "Warp Was"
        Me.GWARPWASTAGE.FieldName = "WARPWASTAGE"
        Me.GWARPWASTAGE.Name = "GWARPWASTAGE"
        Me.GWARPWASTAGE.Visible = True
        Me.GWARPWASTAGE.VisibleIndex = 5
        '
        'GWEFTWASTAGE
        '
        Me.GWEFTWASTAGE.Caption = "Weft Was"
        Me.GWEFTWASTAGE.FieldName = "WEFTWASTAGE"
        Me.GWEFTWASTAGE.Name = "GWEFTWASTAGE"
        Me.GWEFTWASTAGE.Visible = True
        Me.GWEFTWASTAGE.VisibleIndex = 6
        '
        'GYARNQUALITY
        '
        Me.GYARNQUALITY.Caption = "Yarn Quality"
        Me.GYARNQUALITY.FieldName = "YARNQUALITY"
        Me.GYARNQUALITY.Name = "GYARNQUALITY"
        Me.GYARNQUALITY.Visible = True
        Me.GYARNQUALITY.VisibleIndex = 7
        Me.GYARNQUALITY.Width = 200
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 8
        Me.GSHADE.Width = 150
        '
        'GTOTALREQ
        '
        Me.GTOTALREQ.Caption = "Total Req"
        Me.GTOTALREQ.DisplayFormat.FormatString = "0.00"
        Me.GTOTALREQ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALREQ.FieldName = "TOTALREQ"
        Me.GTOTALREQ.Name = "GTOTALREQ"
        Me.GTOTALREQ.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALREQ.Visible = True
        Me.GTOTALREQ.VisibleIndex = 9
        Me.GTOTALREQ.Width = 85
        '
        'GWEAVERSTOCK
        '
        Me.GWEAVERSTOCK.Caption = "Weaver Stock"
        Me.GWEAVERSTOCK.DisplayFormat.FormatString = "0.00"
        Me.GWEAVERSTOCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWEAVERSTOCK.FieldName = "WEAVERSTOCK"
        Me.GWEAVERSTOCK.Name = "GWEAVERSTOCK"
        Me.GWEAVERSTOCK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWEAVERSTOCK.Visible = True
        Me.GWEAVERSTOCK.VisibleIndex = 10
        Me.GWEAVERSTOCK.Width = 85
        '
        'GPENDINGSTOCK
        '
        Me.GPENDINGSTOCK.Caption = "Pending Stock"
        Me.GPENDINGSTOCK.DisplayFormat.FormatString = "0.00"
        Me.GPENDINGSTOCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGSTOCK.FieldName = "PENDINGSTOCK"
        Me.GPENDINGSTOCK.Name = "GPENDINGSTOCK"
        Me.GPENDINGSTOCK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPENDINGSTOCK.Visible = True
        Me.GPENDINGSTOCK.VisibleIndex = 11
        Me.GPENDINGSTOCK.Width = 85
        '
        'GGODOWNSTOCK
        '
        Me.GGODOWNSTOCK.Caption = "Godown Stock"
        Me.GGODOWNSTOCK.DisplayFormat.FormatString = "0.00"
        Me.GGODOWNSTOCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGODOWNSTOCK.FieldName = "GODOWNSTOCK"
        Me.GGODOWNSTOCK.Name = "GGODOWNSTOCK"
        Me.GGODOWNSTOCK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGODOWNSTOCK.Visible = True
        Me.GGODOWNSTOCK.VisibleIndex = 12
        Me.GGODOWNSTOCK.Width = 85
        '
        'GORDEREDSTOCK
        '
        Me.GORDEREDSTOCK.Caption = "Ordered Stock"
        Me.GORDEREDSTOCK.DisplayFormat.FormatString = "0.00"
        Me.GORDEREDSTOCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GORDEREDSTOCK.FieldName = "ORDEREDSTOCK"
        Me.GORDEREDSTOCK.Name = "GORDEREDSTOCK"
        Me.GORDEREDSTOCK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GORDEREDSTOCK.Visible = True
        Me.GORDEREDSTOCK.VisibleIndex = 13
        Me.GORDEREDSTOCK.Width = 85
        '
        'GNEWORDERSTOCK
        '
        Me.GNEWORDERSTOCK.Caption = "New Order Stock"
        Me.GNEWORDERSTOCK.DisplayFormat.FormatString = "0.00"
        Me.GNEWORDERSTOCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNEWORDERSTOCK.FieldName = "NEWORDERSTOCK"
        Me.GNEWORDERSTOCK.Name = "GNEWORDERSTOCK"
        Me.GNEWORDERSTOCK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNEWORDERSTOCK.Visible = True
        Me.GNEWORDERSTOCK.VisibleIndex = 14
        Me.GNEWORDERSTOCK.Width = 85
        '
        'GTOTALMATCHING
        '
        Me.GTOTALMATCHING.Caption = "Total Match"
        Me.GTOTALMATCHING.DisplayFormat.FormatString = "0"
        Me.GTOTALMATCHING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALMATCHING.FieldName = "TOTALMATCHING"
        Me.GTOTALMATCHING.Name = "GTOTALMATCHING"
        Me.GTOTALMATCHING.Visible = True
        Me.GTOTALMATCHING.VisibleIndex = 15
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 16
        Me.GREMARKS.Width = 200
        '
        'GPODONE
        '
        Me.GPODONE.Caption = "PODONE"
        Me.GPODONE.FieldName = "PODONE"
        Me.GPODONE.Name = "GPODONE"
        Me.GPODONE.Visible = True
        Me.GPODONE.VisibleIndex = 17
        Me.GPODONE.Width = 60
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
        'MRPDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MRPDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MRP Details"
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
    Friend WithEvents GMRPNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSUENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSUEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWARPWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEFTWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYARNQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALREQ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEAVERSTOCK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGSTOCK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWNSTOCK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDEREDSTOCK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNEWORDERSTOCK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALMATCHING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GPODONE As DevExpress.XtraGrid.Columns.GridColumn
End Class
