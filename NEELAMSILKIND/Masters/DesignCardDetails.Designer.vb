<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignCardDetails
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
        Me.CMDEXPORT = New System.Windows.Forms.Button()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMATCHING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWARPTL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEFTTL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREEDSPACE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPICKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCARDID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDADDNEW = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDEDIT = New System.Windows.Forms.Button()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDEXPORT)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDADDNEW)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1207, 581)
        Me.BlendPanel1.TabIndex = 333
        '
        'CMDEXPORT
        '
        Me.CMDEXPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXPORT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXPORT.FlatAppearance.BorderSize = 0
        Me.CMDEXPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXPORT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXPORT.Location = New System.Drawing.Point(735, 541)
        Me.CMDEXPORT.Name = "CMDEXPORT"
        Me.CMDEXPORT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXPORT.TabIndex = 333
        Me.CMDEXPORT.Text = "Export"
        Me.CMDEXPORT.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(14, 12)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(1179, 524)
        Me.GRIDBILLDETAILS.TabIndex = 332
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GITEMNAME, Me.GCATEGORY, Me.GMATCHING, Me.GWARPTL, Me.GWEFTTL, Me.GREED, Me.GREEDSPACE, Me.GPICKS, Me.GTOTALWT, Me.GCARDID})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Design No"
        Me.GNAME.FieldName = "DESIGNNO"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 180
        '
        'GMATCHING
        '
        Me.GMATCHING.Caption = "Matching"
        Me.GMATCHING.FieldName = "MATCHING"
        Me.GMATCHING.Name = "GMATCHING"
        Me.GMATCHING.Visible = True
        Me.GMATCHING.VisibleIndex = 3
        Me.GMATCHING.Width = 150
        '
        'GWARPTL
        '
        Me.GWARPTL.Caption = "Warp TL"
        Me.GWARPTL.FieldName = "WARPTL"
        Me.GWARPTL.Name = "GWARPTL"
        Me.GWARPTL.Visible = True
        Me.GWARPTL.VisibleIndex = 4
        '
        'GWEFTTL
        '
        Me.GWEFTTL.Caption = "Weft TL"
        Me.GWEFTTL.FieldName = "WEFTTL"
        Me.GWEFTTL.Name = "GWEFTTL"
        Me.GWEFTTL.Visible = True
        Me.GWEFTTL.VisibleIndex = 5
        '
        'GREED
        '
        Me.GREED.Caption = "Reed"
        Me.GREED.FieldName = "REED"
        Me.GREED.Name = "GREED"
        Me.GREED.Visible = True
        Me.GREED.VisibleIndex = 6
        '
        'GREEDSPACE
        '
        Me.GREEDSPACE.Caption = "Reed Space"
        Me.GREEDSPACE.DisplayFormat.FormatString = "0"
        Me.GREEDSPACE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREEDSPACE.FieldName = "REEDSPACE"
        Me.GREEDSPACE.Name = "GREEDSPACE"
        Me.GREEDSPACE.Visible = True
        Me.GREEDSPACE.VisibleIndex = 7
        '
        'GPICKS
        '
        Me.GPICKS.Caption = "Picks"
        Me.GPICKS.DisplayFormat.FormatString = "0"
        Me.GPICKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPICKS.FieldName = "PICKS"
        Me.GPICKS.Name = "GPICKS"
        Me.GPICKS.Visible = True
        Me.GPICKS.VisibleIndex = 8
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total Wt"
        Me.GTOTALWT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 9
        '
        'GCARDID
        '
        Me.GCARDID.Caption = "Card ID"
        Me.GCARDID.FieldName = "CARDID"
        Me.GCARDID.Name = "GCARDID"
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(477, 542)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 331
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'CMDADDNEW
        '
        Me.CMDADDNEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDADDNEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDADDNEW.FlatAppearance.BorderSize = 0
        Me.CMDADDNEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDADDNEW.ForeColor = System.Drawing.Color.Black
        Me.CMDADDNEW.Location = New System.Drawing.Point(391, 542)
        Me.CMDADDNEW.Name = "CMDADDNEW"
        Me.CMDADDNEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDADDNEW.TabIndex = 330
        Me.CMDADDNEW.Text = "&Add New"
        Me.CMDADDNEW.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(649, 542)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 328
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'CMDEDIT
        '
        Me.CMDEDIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEDIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEDIT.FlatAppearance.BorderSize = 0
        Me.CMDEDIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEDIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEDIT.Location = New System.Drawing.Point(563, 542)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 329
        Me.CMDEDIT.Text = "&Edit"
        Me.CMDEDIT.UseVisualStyleBackColor = False
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 2
        Me.GCATEGORY.Width = 150
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 200
        '
        'DesignCardDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1207, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignCardDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Card Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents CMDADDNEW As Button
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDEDIT As Button
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMATCHING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWARPTL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEFTTL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREEDSPACE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPICKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCARDID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDEXPORT As Button
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
End Class
