
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class SaleOrderDetails

    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SALEOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SALEOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.SALEORDER.SO_yearid=" & YearId & " order by dbo.SALEORDER.SO_no, SALEORDER_DESC.SO_GRIDSRNO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" SALEORDER.so_no AS SONO, SALEORDER.so_date AS SODATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENTNAME, SALEORDER.so_pono AS PARTYPONO, SALEORDER.SO_DUEDATE AS DELDATE, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, ISNULL(SALEORDER_DESC.SO_PARTYPONO,'') AS GRIDPARTYPONO, ISNULL(SO_GRIDREMARKS,'') AS GRIDREMARKS, SALEORDER_DESC.SO_QTY AS PCS, SALEORDER_DESC.SO_CUT AS CUT, SALEORDER_DESC.SO_MTRS AS MTRS, SALEORDER_DESC.SO_RATE AS RATE, SALEORDER_DESC.SO_QTY- SALEORDER_DESC.SO_RECDQTY AS BALPCS, (SALEORDER_DESC.SO_MTRS- ISNULL(SALEORDER_DESC.SO_RECDMTRS,0)) AS BALMTRS, SO_REMARKS AS REMARKS, ISNULL(SO_CLOSED,0) AS CLOSED, ISNULL(SO_FORWARD,'') AS FORWARD, ISNULL(SO_CLOSEDDATE,GETDATE()) AS CLOSEDDATE, ISNULL(SO_CLOSEDREASON,'') AS REASON ", "", " SALEORDER_DESC INNER JOIN SALEORDER ON SALEORDER_DESC.SO_NO = SALEORDER.so_no AND SALEORDER_DESC.SO_YEARID = SALEORDER.SO_YEARID INNER JOIN LEDGERS ON SALEORDER.so_ledgerid = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SALEORDER_DESC.SO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SALEORDER_DESC.SO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON SALEORDER.so_Agentid = AGENTLEDGERS.Acc_id ", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SOno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPO As New SaleOrder
                objPO.MdiParent = MDIMain
                objPO.edit = editval
                objPO.TEMPSONO = SOno
                objPO.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Order Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Order from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Sale Order ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal ORDERMAIL As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            If ORDERMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJORDER As New SaleOrderDesign
                OBJORDER.MdiParent = MDIMain
                OBJORDER.DIRECTPRINT = True
                OBJORDER.FRMSTRING = "SOREPORT"
                OBJORDER.DIRECTMAIL = ORDERMAIL
                OBJORDER.PRINTSETTING = PRINTDIALOG
                OBJORDER.SONO = Val(I)
                OBJORDER.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJORDER.Show()
                OBJORDER.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\SALEORDER_" & I & ".pdf")
            Next

            If ORDERMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Sale Order"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal ORDERMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If ORDERMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJORDER As New SaleOrderDesign
                OBJORDER.MdiParent = MDIMain
                OBJORDER.DIRECTPRINT = True
                OBJORDER.FRMSTRING = "SOREPORT"
                OBJORDER.DIRECTMAIL = ORDERMAIL
                OBJORDER.PRINTSETTING = PRINTDIALOG
                OBJORDER.SONO = Val(ROW("SONO"))
                OBJORDER.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJORDER.Show()
                OBJORDER.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\SALEORDER_" & Val(ROW("SONO")) & ".pdf")
            Next

            If ORDERMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Sale Order"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRINTTOOL_Click(sender As Object, e As EventArgs) Handles PRINTTOOL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Entry Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Entries from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Entries ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRINTEXCEL_Click(sender As Object, e As EventArgs) Handles PRINTEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Sale Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Sale Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Sale Order Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightSkyBlue
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class