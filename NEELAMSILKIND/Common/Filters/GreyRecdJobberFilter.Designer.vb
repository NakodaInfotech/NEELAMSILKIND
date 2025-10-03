<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GreyRecdJobberFilter
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
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBSHADE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBWTDIFF = New System.Windows.Forms.RadioButton()
        Me.RBWEAVERDESIGNDTLS = New System.Windows.Forms.RadioButton()
        Me.RBWEAVERDTLS = New System.Windows.Forms.RadioButton()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RBBALANCECUT = New System.Windows.Forms.RadioButton()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.TXTADD)
        Me.BlendPanel2.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBNAME)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(439, 408)
        Me.BlendPanel2.TabIndex = 0
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(105, 68)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBITEMNAME.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(34, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 14)
        Me.Label3.TabIndex = 760
        Me.Label3.Text = "Item Name"
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(105, 40)
        Me.CMBCATEGORY.MaxDropDownItems = 14
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(230, 22)
        Me.CMBCATEGORY.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(48, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 758
        Me.Label2.Text = "Category"
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(399, 3)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBCODE.TabIndex = 756
        Me.CMBCODE.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(385, 2)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(30, 23)
        Me.TXTADD.TabIndex = 755
        Me.TXTADD.Visible = False
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(105, 96)
        Me.CMBDESIGN.MaxDropDownItems = 14
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(230, 22)
        Me.CMBDESIGN.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(56, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 14)
        Me.Label9.TabIndex = 754
        Me.Label9.Text = "Design"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(81, 297)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "To :"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(12, -2)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "From :"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(105, 12)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBNAME.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(18, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 14)
        Me.Label8.TabIndex = 752
        Me.Label8.Text = "Weaver Name"
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(105, 124)
        Me.CMBSHADE.MaxDropDownItems = 14
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(230, 22)
        Me.CMBSHADE.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(44, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 14)
        Me.Label6.TabIndex = 750
        Me.Label6.Text = "Matching"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBBALANCECUT)
        Me.GroupBox3.Controls.Add(Me.RBWTDIFF)
        Me.GroupBox3.Controls.Add(Me.RBWEAVERDESIGNDTLS)
        Me.GroupBox3.Controls.Add(Me.RBWEAVERDTLS)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(33, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(382, 121)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'RBWTDIFF
        '
        Me.RBWTDIFF.AutoSize = True
        Me.RBWTDIFF.Location = New System.Drawing.Point(20, 45)
        Me.RBWTDIFF.Name = "RBWTDIFF"
        Me.RBWTDIFF.Size = New System.Drawing.Size(165, 18)
        Me.RBWTDIFF.TabIndex = 2
        Me.RBWTDIFF.Text = "Design Wt - Actual Wt Diff"
        Me.RBWTDIFF.UseVisualStyleBackColor = True
        '
        'RBWEAVERDESIGNDTLS
        '
        Me.RBWEAVERDESIGNDTLS.AutoSize = True
        Me.RBWEAVERDESIGNDTLS.Location = New System.Drawing.Point(191, 21)
        Me.RBWEAVERDESIGNDTLS.Name = "RBWEAVERDESIGNDTLS"
        Me.RBWEAVERDESIGNDTLS.Size = New System.Drawing.Size(181, 18)
        Me.RBWEAVERDESIGNDTLS.TabIndex = 1
        Me.RBWEAVERDESIGNDTLS.Text = "Weaver Design Wise Details"
        Me.RBWEAVERDESIGNDTLS.UseVisualStyleBackColor = True
        '
        'RBWEAVERDTLS
        '
        Me.RBWEAVERDTLS.AutoSize = True
        Me.RBWEAVERDTLS.Checked = True
        Me.RBWEAVERDTLS.Location = New System.Drawing.Point(20, 21)
        Me.RBWEAVERDTLS.Name = "RBWEAVERDTLS"
        Me.RBWEAVERDTLS.Size = New System.Drawing.Size(140, 18)
        Me.RBWEAVERDTLS.TabIndex = 0
        Me.RBWEAVERDTLS.TabStop = True
        Me.RBWEAVERDTLS.Text = "Weaver Wise Details"
        Me.RBWEAVERDTLS.UseVisualStyleBackColor = True
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(130, 363)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 8
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(224, 363)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBBALANCECUT
        '
        Me.RBBALANCECUT.AutoSize = True
        Me.RBBALANCECUT.Location = New System.Drawing.Point(20, 69)
        Me.RBBALANCECUT.Name = "RBBALANCECUT"
        Me.RBBALANCECUT.Size = New System.Drawing.Size(89, 18)
        Me.RBBALANCECUT.TabIndex = 3
        Me.RBBALANCECUT.Text = "Balance Cut"
        Me.RBBALANCECUT.UseVisualStyleBackColor = True
        '
        'GreyRecdJobberFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(439, 408)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GreyRecdJobberFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Grey Recd Jobber Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBDESIGN As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents CMBNAME As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CMBSHADE As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RBWEAVERDTLS As RadioButton
    Friend WithEvents cmdshow As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents RBWEAVERDESIGNDTLS As RadioButton
    Friend WithEvents RBWTDIFF As RadioButton
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CMBCATEGORY As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RBBALANCECUT As RadioButton
End Class
