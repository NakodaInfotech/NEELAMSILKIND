<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoomSampleRecdDetails
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSAMPNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMATCHING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCARDNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCARDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPICK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSAMPLEREED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSAMPPICK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAPPROVED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREASON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSAMPNO, Me.GSRNO, Me.GDATE, Me.GNAME, Me.GREMARKS, Me.GDESIGNNO, Me.GMATCHING, Me.GCARDNO, Me.GCARDSRNO, Me.GREED, Me.GPICK, Me.GSAMPLEREED, Me.GSAMPPICK, Me.GAPPROVED, Me.GREASON, Me.GRIDREMARKS})
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
        'GSAMPNO
        '
        Me.GSAMPNO.Caption = "Sam No"
        Me.GSAMPNO.FieldName = "SMPNO"
        Me.GSAMPNO.Name = "GSAMPNO"
        Me.GSAMPNO.OptionsColumn.AllowEdit = False
        Me.GSAMPNO.Visible = True
        Me.GSAMPNO.VisibleIndex = 0
        Me.GSAMPNO.Width = 50
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "GRIDSRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 50
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
        Me.GNAME.Width = 150
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 4
        Me.GREMARKS.Width = 150
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 5
        Me.GDESIGNNO.Width = 150
        '
        'GMATCHING
        '
        Me.GMATCHING.Caption = "Matching"
        Me.GMATCHING.FieldName = "MATCHING"
        Me.GMATCHING.Name = "GMATCHING"
        Me.GMATCHING.Visible = True
        Me.GMATCHING.VisibleIndex = 6
        '
        'GCARDNO
        '
        Me.GCARDNO.Caption = "Card No"
        Me.GCARDNO.FieldName = "CARDNO"
        Me.GCARDNO.Name = "GCARDNO"
        Me.GCARDNO.Visible = True
        Me.GCARDNO.VisibleIndex = 7
        '
        'GCARDSRNO
        '
        Me.GCARDSRNO.Caption = "Card Sr No"
        Me.GCARDSRNO.FieldName = "CARDSRNO"
        Me.GCARDSRNO.Name = "GCARDSRNO"
        Me.GCARDSRNO.Visible = True
        Me.GCARDSRNO.VisibleIndex = 8
        '
        'GREED
        '
        Me.GREED.Caption = "Reed"
        Me.GREED.FieldName = "REED"
        Me.GREED.Name = "GREED"
        Me.GREED.Visible = True
        Me.GREED.VisibleIndex = 9
        '
        'GPICK
        '
        Me.GPICK.Caption = "Pick"
        Me.GPICK.FieldName = "PICK"
        Me.GPICK.Name = "GPICK"
        Me.GPICK.Visible = True
        Me.GPICK.VisibleIndex = 10
        '
        'GSAMPLEREED
        '
        Me.GSAMPLEREED.Caption = "Sam Reed"
        Me.GSAMPLEREED.FieldName = "SAMPLEREED"
        Me.GSAMPLEREED.Name = "GSAMPLEREED"
        Me.GSAMPLEREED.Visible = True
        Me.GSAMPLEREED.VisibleIndex = 11
        Me.GSAMPLEREED.Width = 80
        '
        'GSAMPPICK
        '
        Me.GSAMPPICK.Caption = "Sam Pick"
        Me.GSAMPPICK.FieldName = "SAMPLEPICK"
        Me.GSAMPPICK.Name = "GSAMPPICK"
        Me.GSAMPPICK.Visible = True
        Me.GSAMPPICK.VisibleIndex = 12
        Me.GSAMPPICK.Width = 80
        '
        'GAPPROVED
        '
        Me.GAPPROVED.Caption = "Approved"
        Me.GAPPROVED.FieldName = "APPROVED"
        Me.GAPPROVED.Name = "GAPPROVED"
        Me.GAPPROVED.Visible = True
        Me.GAPPROVED.VisibleIndex = 13
        Me.GAPPROVED.Width = 80
        '
        'GREASON
        '
        Me.GREASON.Caption = "Reason"
        Me.GREASON.FieldName = "REASON"
        Me.GREASON.Name = "GREASON"
        Me.GREASON.Visible = True
        Me.GREASON.VisibleIndex = 14
        Me.GREASON.Width = 80
        '
        'GRIDREMARKS
        '
        Me.GRIDREMARKS.Caption = "DESC"
        Me.GRIDREMARKS.FieldName = "GRIDREMARKS"
        Me.GRIDREMARKS.Name = "GRIDREMARKS"
        Me.GRIDREMARKS.Visible = True
        Me.GRIDREMARKS.VisibleIndex = 15
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
        Me.BlendPanel1.TabIndex = 10
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
        'LoomSampleRecdDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LoomSampleRecdDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Loom Sample Recd Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSAMPNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMATCHING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCARDNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCARDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPICK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSAMPLEREED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSAMPPICK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAPPROVED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREASON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRIDREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
