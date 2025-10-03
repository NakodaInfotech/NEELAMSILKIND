<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsolidatedStockGridReport
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
        Me.CHKFOLLOWUP = New System.Windows.Forms.CheckBox()
        Me.CHKREPEAT = New System.Windows.Forms.CheckBox()
        Me.CHKSAMPLEOUT = New System.Windows.Forms.CheckBox()
        Me.CHKDESPATCH = New System.Windows.Forms.CheckBox()
        Me.CHKALL = New System.Windows.Forms.CheckBox()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGWEAVERQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTOCK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGORDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTOCKLESSORDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALLESSORDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GSODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKFOLLOWUP)
        Me.BlendPanel1.Controls.Add(Me.CHKREPEAT)
        Me.BlendPanel1.Controls.Add(Me.CHKSAMPLEOUT)
        Me.BlendPanel1.Controls.Add(Me.CHKDESPATCH)
        Me.BlendPanel1.Controls.Add(Me.CHKALL)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 581)
        Me.BlendPanel1.TabIndex = 11
        '
        'CHKFOLLOWUP
        '
        Me.CHKFOLLOWUP.AutoSize = True
        Me.CHKFOLLOWUP.BackColor = System.Drawing.Color.Transparent
        Me.CHKFOLLOWUP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKFOLLOWUP.ForeColor = System.Drawing.Color.Black
        Me.CHKFOLLOWUP.Location = New System.Drawing.Point(584, 3)
        Me.CHKFOLLOWUP.Name = "CHKFOLLOWUP"
        Me.CHKFOLLOWUP.Size = New System.Drawing.Size(117, 18)
        Me.CHKFOLLOWUP.TabIndex = 767
        Me.CHKFOLLOWUP.Text = "Weaver Follow Up"
        Me.CHKFOLLOWUP.UseVisualStyleBackColor = False
        '
        'CHKREPEAT
        '
        Me.CHKREPEAT.AutoSize = True
        Me.CHKREPEAT.BackColor = System.Drawing.Color.Transparent
        Me.CHKREPEAT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKREPEAT.ForeColor = System.Drawing.Color.Black
        Me.CHKREPEAT.Location = New System.Drawing.Point(464, 4)
        Me.CHKREPEAT.Name = "CHKREPEAT"
        Me.CHKREPEAT.Size = New System.Drawing.Size(61, 18)
        Me.CHKREPEAT.TabIndex = 766
        Me.CHKREPEAT.Text = "Repeat"
        Me.CHKREPEAT.UseVisualStyleBackColor = False
        '
        'CHKSAMPLEOUT
        '
        Me.CHKSAMPLEOUT.AutoSize = True
        Me.CHKSAMPLEOUT.BackColor = System.Drawing.Color.Transparent
        Me.CHKSAMPLEOUT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSAMPLEOUT.ForeColor = System.Drawing.Color.Black
        Me.CHKSAMPLEOUT.Location = New System.Drawing.Point(316, 4)
        Me.CHKSAMPLEOUT.Name = "CHKSAMPLEOUT"
        Me.CHKSAMPLEOUT.Size = New System.Drawing.Size(84, 18)
        Me.CHKSAMPLEOUT.TabIndex = 765
        Me.CHKSAMPLEOUT.Text = "Sample Out"
        Me.CHKSAMPLEOUT.UseVisualStyleBackColor = False
        '
        'CHKDESPATCH
        '
        Me.CHKDESPATCH.AutoSize = True
        Me.CHKDESPATCH.BackColor = System.Drawing.Color.Transparent
        Me.CHKDESPATCH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDESPATCH.ForeColor = System.Drawing.Color.Black
        Me.CHKDESPATCH.Location = New System.Drawing.Point(191, 4)
        Me.CHKDESPATCH.Name = "CHKDESPATCH"
        Me.CHKDESPATCH.Size = New System.Drawing.Size(71, 18)
        Me.CHKDESPATCH.TabIndex = 764
        Me.CHKDESPATCH.Text = "Despatch"
        Me.CHKDESPATCH.UseVisualStyleBackColor = False
        '
        'CHKALL
        '
        Me.CHKALL.AutoSize = True
        Me.CHKALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKALL.ForeColor = System.Drawing.Color.Black
        Me.CHKALL.Location = New System.Drawing.Point(44, 4)
        Me.CHKALL.Name = "CHKALL"
        Me.CHKALL.Size = New System.Drawing.Size(91, 18)
        Me.CHKALL.TabIndex = 763
        Me.CHKALL.Text = "Show 0 Stock"
        Me.CHKALL.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(559, 550)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 258
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(645, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 2
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(19, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1246, 516)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCATEGORY, Me.GITEMNAME, Me.GDESIGNNO, Me.GPENDINGWEAVERQTY, Me.GSTOCK, Me.GPENDINGORDER, Me.GSTOCKLESSORDER, Me.GTOTALLESSORDER, Me.GTOTAL, Me.GSODATE})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 0
        Me.GCATEGORY.Width = 120
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 180
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 2
        Me.GDESIGNNO.Width = 200
        '
        'GPENDINGWEAVERQTY
        '
        Me.GPENDINGWEAVERQTY.Caption = "Pending Weaver Qty"
        Me.GPENDINGWEAVERQTY.DisplayFormat.FormatString = "0"
        Me.GPENDINGWEAVERQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGWEAVERQTY.FieldName = "PENDINGWEAVERQTY"
        Me.GPENDINGWEAVERQTY.Name = "GPENDINGWEAVERQTY"
        Me.GPENDINGWEAVERQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPENDINGWEAVERQTY.Visible = True
        Me.GPENDINGWEAVERQTY.VisibleIndex = 3
        Me.GPENDINGWEAVERQTY.Width = 130
        '
        'GSTOCK
        '
        Me.GSTOCK.Caption = "Godown Stock"
        Me.GSTOCK.DisplayFormat.FormatString = "0"
        Me.GSTOCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTOCK.FieldName = "STOCK"
        Me.GSTOCK.Name = "GSTOCK"
        Me.GSTOCK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSTOCK.Visible = True
        Me.GSTOCK.VisibleIndex = 4
        Me.GSTOCK.Width = 130
        '
        'GPENDINGORDER
        '
        Me.GPENDINGORDER.Caption = "Pending Order"
        Me.GPENDINGORDER.DisplayFormat.FormatString = "0"
        Me.GPENDINGORDER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGORDER.FieldName = "PENDINGORDER"
        Me.GPENDINGORDER.Name = "GPENDINGORDER"
        Me.GPENDINGORDER.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPENDINGORDER.Visible = True
        Me.GPENDINGORDER.VisibleIndex = 5
        Me.GPENDINGORDER.Width = 130
        '
        'GSTOCKLESSORDER
        '
        Me.GSTOCKLESSORDER.Caption = "Stock Less Order"
        Me.GSTOCKLESSORDER.FieldName = "STOCKLESSORDER"
        Me.GSTOCKLESSORDER.Name = "GSTOCKLESSORDER"
        Me.GSTOCKLESSORDER.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSTOCKLESSORDER.Visible = True
        Me.GSTOCKLESSORDER.VisibleIndex = 6
        Me.GSTOCKLESSORDER.Width = 110
        '
        'GTOTALLESSORDER
        '
        Me.GTOTALLESSORDER.Caption = "Total (Less Order)"
        Me.GTOTALLESSORDER.DisplayFormat.FormatString = "0"
        Me.GTOTALLESSORDER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALLESSORDER.FieldName = "TOTALLESSORDER"
        Me.GTOTALLESSORDER.Name = "GTOTALLESSORDER"
        Me.GTOTALLESSORDER.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALLESSORDER.Visible = True
        Me.GTOTALLESSORDER.VisibleIndex = 7
        Me.GTOTALLESSORDER.Width = 120
        '
        'GTOTAL
        '
        Me.GTOTAL.Caption = "Total"
        Me.GTOTAL.DisplayFormat.FormatString = "0"
        Me.GTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTAL.FieldName = "TOTALQTY"
        Me.GTOTAL.Name = "GTOTAL"
        Me.GTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTAL.Visible = True
        Me.GTOTAL.VisibleIndex = 8
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'GSODATE
        '
        Me.GSODATE.Caption = "SO Date"
        Me.GSODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GSODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GSODATE.FieldName = "SODATE"
        Me.GSODATE.Name = "GSODATE"
        '
        'ConsolidatedStockGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ConsolidatedStockGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Consolidated Stock Grid Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdexit As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGWEAVERQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTOCK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGORDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTOCKLESSORDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALLESSORDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents CHKALL As CheckBox
    Friend WithEvents CHKSAMPLEOUT As CheckBox
    Friend WithEvents CHKDESPATCH As CheckBox
    Friend WithEvents CHKFOLLOWUP As CheckBox
    Friend WithEvents CHKREPEAT As CheckBox
    Friend WithEvents GSODATE As DevExpress.XtraGrid.Columns.GridColumn
End Class
