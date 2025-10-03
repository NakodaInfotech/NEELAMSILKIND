<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GreyRecdJobberDetails
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
        Me.TXTAVG = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOOMNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAVGWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDIFFWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKFROM = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKFROM)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTAVG)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'TXTAVG
        '
        Me.TXTAVG.BackColor = System.Drawing.Color.Linen
        Me.TXTAVG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTAVG.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAVG.Location = New System.Drawing.Point(1007, 541)
        Me.TXTAVG.Name = "TXTAVG"
        Me.TXTAVG.Size = New System.Drawing.Size(87, 23)
        Me.TXTAVG.TabIndex = 755
        Me.TXTAVG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 258
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.NEELAMSILKIND.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(491, 541)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 654
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
        Me.cmdexit.Location = New System.Drawing.Point(663, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 653
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
        Me.cmdok.Location = New System.Drawing.Point(577, 541)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 652
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 34)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1210, 501)
        Me.gridbilldetails.TabIndex = 257
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GGODOWN, Me.GNAME, Me.GCHALLAN, Me.GCHALLANDATE, Me.GITEMNAME, Me.GDESIGN, Me.GSHADE, Me.GLOOMNO, Me.GROLLNO, Me.GQTY, Me.GMTRS, Me.GWT, Me.GOURWT, Me.GAVGWT, Me.GDIFFWT, Me.GTRANSNAME, Me.GLRNO, Me.GLRDATE, Me.GREMARKS})
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
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 55
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 2
        Me.GGODOWN.Width = 140
        '
        'GNAME
        '
        Me.GNAME.Caption = "Jobber Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 180
        '
        'GCHALLAN
        '
        Me.GCHALLAN.Caption = "Challan No"
        Me.GCHALLAN.FieldName = "CHALLANNO"
        Me.GCHALLAN.Name = "GCHALLAN"
        Me.GCHALLAN.Visible = True
        Me.GCHALLAN.VisibleIndex = 4
        Me.GCHALLAN.Width = 70
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Challan Date"
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.Visible = True
        Me.GCHALLANDATE.VisibleIndex = 5
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 6
        Me.GITEMNAME.Width = 150
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 7
        Me.GDESIGN.Width = 150
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Matching"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 8
        Me.GSHADE.Width = 150
        '
        'GLOOMNO
        '
        Me.GLOOMNO.Caption = "Loom No"
        Me.GLOOMNO.FieldName = "LOOMNO"
        Me.GLOOMNO.Name = "GLOOMNO"
        Me.GLOOMNO.Visible = True
        Me.GLOOMNO.VisibleIndex = 9
        '
        'GROLLNO
        '
        Me.GROLLNO.Caption = "Roll No"
        Me.GROLLNO.FieldName = "ROLLNO"
        Me.GROLLNO.Name = "GROLLNO"
        Me.GROLLNO.Visible = True
        Me.GROLLNO.VisibleIndex = 10
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty."
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 11
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs."
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 12
        '
        'GWT
        '
        Me.GWT.Caption = "Wt."
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 13
        '
        'GOURWT
        '
        Me.GOURWT.Caption = "Our Wt."
        Me.GOURWT.DisplayFormat.FormatString = "0.00"
        Me.GOURWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOURWT.FieldName = "OURWT"
        Me.GOURWT.Name = "GOURWT"
        Me.GOURWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOURWT.Visible = True
        Me.GOURWT.VisibleIndex = 14
        Me.GOURWT.Width = 60
        '
        'GAVGWT
        '
        Me.GAVGWT.Caption = "Avg Wt"
        Me.GAVGWT.DisplayFormat.FormatString = "0.00"
        Me.GAVGWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAVGWT.FieldName = "AVGWT"
        Me.GAVGWT.Name = "GAVGWT"
        Me.GAVGWT.Visible = True
        Me.GAVGWT.VisibleIndex = 15
        '
        'GDIFFWT
        '
        Me.GDIFFWT.Caption = "Diff Wt"
        Me.GDIFFWT.DisplayFormat.FormatString = "0.00"
        Me.GDIFFWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDIFFWT.FieldName = "DIFFWT"
        Me.GDIFFWT.Name = "GDIFFWT"
        Me.GDIFFWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDIFFWT.Visible = True
        Me.GDIFFWT.VisibleIndex = 16
        '
        'GTRANSNAME
        '
        Me.GTRANSNAME.Caption = "Transport Name"
        Me.GTRANSNAME.FieldName = "TRANSNAME"
        Me.GTRANSNAME.Name = "GTRANSNAME"
        Me.GTRANSNAME.Visible = True
        Me.GTRANSNAME.VisibleIndex = 17
        Me.GTRANSNAME.Width = 150
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "L.R. No."
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 18
        '
        'GLRDATE
        '
        Me.GLRDATE.Caption = "L.R. Date"
        Me.GLRDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GLRDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GLRDATE.FieldName = "LRDATE"
        Me.GLRDATE.Name = "GLRDATE"
        Me.GLRDATE.Visible = True
        Me.GLRDATE.VisibleIndex = 19
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 20
        Me.GREMARKS.Width = 180
        '
        'CHKFROM
        '
        Me.CHKFROM.AutoSize = True
        Me.CHKFROM.Location = New System.Drawing.Point(402, 3)
        Me.CHKFROM.Name = "CHKFROM"
        Me.CHKFROM.Size = New System.Drawing.Size(54, 19)
        Me.CHKFROM.TabIndex = 805
        Me.CHKFROM.Text = "From"
        Me.CHKFROM.UseVisualStyleBackColor = True
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(574, 2)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 23)
        Me.dtto.TabIndex = 804
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(459, 2)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(87, 23)
        Me.dtfrom.TabIndex = 803
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(549, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 14)
        Me.Label9.TabIndex = 802
        Me.Label9.Text = "To"
        '
        'GreyRecdJobberDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GreyRecdJobberDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Grey Recd Jobber Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOOMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAVGWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDIFFWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTAVG As TextBox
    Friend WithEvents CHKFROM As CheckBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label9 As Label
End Class
