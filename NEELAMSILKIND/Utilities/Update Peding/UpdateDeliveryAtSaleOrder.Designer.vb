<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDeliveryAtSaleOrder
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.TXTDELIVERYAT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTITEMNAME = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBDELIVERYAT = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTSONO = New System.Windows.Forms.TextBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDUPDATE = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTDELIVERYAT)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBDELIVERYAT)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTSONO)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDUPDATE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(333, 310)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.Linen
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(292, 158)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.ReadOnly = True
        Me.TXTADD.Size = New System.Drawing.Size(28, 23)
        Me.TXTADD.TabIndex = 678
        Me.TXTADD.TabStop = False
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(265, 161)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMBCODE.TabIndex = 677
        Me.CMBCODE.Visible = False
        '
        'TXTDELIVERYAT
        '
        Me.TXTDELIVERYAT.BackColor = System.Drawing.Color.Linen
        Me.TXTDELIVERYAT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDELIVERYAT.Location = New System.Drawing.Point(89, 99)
        Me.TXTDELIVERYAT.Name = "TXTDELIVERYAT"
        Me.TXTDELIVERYAT.ReadOnly = True
        Me.TXTDELIVERYAT.Size = New System.Drawing.Size(215, 23)
        Me.TXTDELIVERYAT.TabIndex = 675
        Me.TXTDELIVERYAT.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 676
        Me.Label5.Text = "Delivery At"
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(89, 157)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.ReadOnly = True
        Me.TXTPCS.Size = New System.Drawing.Size(86, 23)
        Me.TXTPCS.TabIndex = 673
        Me.TXTPCS.TabStop = False
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(59, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 15)
        Me.Label7.TabIndex = 674
        Me.Label7.Text = "Qty"
        '
        'TXTITEMNAME
        '
        Me.TXTITEMNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMNAME.Location = New System.Drawing.Point(89, 128)
        Me.TXTITEMNAME.Name = "TXTITEMNAME"
        Me.TXTITEMNAME.ReadOnly = True
        Me.TXTITEMNAME.Size = New System.Drawing.Size(215, 23)
        Me.TXTITEMNAME.TabIndex = 671
        Me.TXTITEMNAME.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 672
        Me.Label6.Text = "Item Name"
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(89, 70)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(215, 23)
        Me.TXTNAME.TabIndex = 667
        Me.TXTNAME.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 15)
        Me.Label2.TabIndex = 668
        Me.Label2.Text = "Name"
        '
        'CMBDELIVERYAT
        '
        Me.CMBDELIVERYAT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDELIVERYAT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDELIVERYAT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBDELIVERYAT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDELIVERYAT.FormattingEnabled = True
        Me.CMBDELIVERYAT.Location = New System.Drawing.Point(89, 186)
        Me.CMBDELIVERYAT.MaxDropDownItems = 14
        Me.CMBDELIVERYAT.Name = "CMBDELIVERYAT"
        Me.CMBDELIVERYAT.Size = New System.Drawing.Size(215, 23)
        Me.CMBDELIVERYAT.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(7, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 634
        Me.Label4.Text = "New Delivery"
        '
        'TXTSONO
        '
        Me.TXTSONO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSONO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSONO.Location = New System.Drawing.Point(89, 41)
        Me.TXTSONO.Name = "TXTSONO"
        Me.TXTSONO.Size = New System.Drawing.Size(86, 23)
        Me.TXTSONO.TabIndex = 1
        Me.TXTSONO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(225, 215)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 5
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(139, 215)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 4
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDUPDATE
        '
        Me.CMDUPDATE.Location = New System.Drawing.Point(53, 215)
        Me.CMDUPDATE.Name = "CMDUPDATE"
        Me.CMDUPDATE.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPDATE.TabIndex = 3
        Me.CMDUPDATE.Text = "&Update"
        Me.CMDUPDATE.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SO No"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"SALE ORDER", "OPENING"})
        Me.CMBTYPE.Location = New System.Drawing.Point(89, 12)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(130, 23)
        Me.CMBTYPE.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(55, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 680
        Me.Label3.Text = "Type"
        '
        'UpdateDeliveryAtSaleOrder
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(333, 310)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UpdateDeliveryAtSaleOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Update Delivery At in Sale Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTPCS As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTITEMNAME As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTNAME As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBDELIVERYAT As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTSONO As TextBox
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDUPDATE As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTDELIVERYAT As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents CMBTYPE As ComboBox
    Friend WithEvents Label3 As Label
End Class
