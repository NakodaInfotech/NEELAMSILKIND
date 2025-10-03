
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class YarnPurchaseOrderDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub YarnPurchaseOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub YarnPurchaseOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = ""
            If CHKFROM.CheckState = CheckState.Checked Then WHERECLAUSE = " and YARNPURCHASEORDER.YPO_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND YARNPURCHASEORDER.YPO_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search("ISNULL(YARNPURCHASEORDER.YPO_NO, 0) AS PONO, YARNPURCHASEORDER.YPO_DATE AS PODATE, YARNPURCHASEORDER.YPO_DUEDATE AS DUEDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(YARNPURCHASEORDER.YPO_CRDAYS, 0) AS CRDAYS, ISNULL(YARNPURCHASEORDER.YPO_DELDAYS, 0) AS DELDAYS, ISNULL(YARNPURCHASEORDER.YPO_REFNO, '') AS REFNO, ISNULL(YARNPURCHASEORDER.YPO_DISCOUNT, 0) AS DISCOUNT, ISNULL(YARNPURCHASEORDER.YPO_REMARKS, '') AS REMARKS, ISNULL(YARNPURCHASEORDER.YPO_ORDERTYPE, '') AS ORDERTYPE, ISNULL(YARNPURCHASEORDER.YPO_LBLTOTALAMT, 0) AS LBLTOTALPCS, ISNULL(YARNPURCHASEORDER.YPO_INWORDS, '') AS INWORDS, ISNULL(BROKERLEDGERS.Acc_cmpname, '') AS BROKER, ISNULL(YARNPURCHASEORDER_DESC.YPO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(YARNPURCHASEORDER_DESC.YPO_DESC, '') AS [DESC], ISNULL(UNITMASTER.unit_name, '') AS UNIT, ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GRIDLEDGERS.Acc_cmpname, '') AS GRIDNAME, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNPURCHASEORDER_DESC.YPO_BAGS, 0) AS BAGS, ISNULL(YARNPURCHASEORDER_DESC.YPO_WT, 0) AS WT, ISNULL(YARNPURCHASEORDER_DESC.YPO_CONES, 0) AS CONES, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(LEDGERS.Acc_mobile, '') AS MOBILENO, ISNULL(YARNPURCHASEORDER_DESC.YPO_RATE, 0) AS RATE, ISNULL(YARNPURCHASEORDER_DESC.YPO_AMT, 0) AS AMT, ISNULL(YARNPURCHASEORDER_DESC.YPO_RECDBAGS, 0) AS RECDBAGS, ISNULL(YARNPURCHASEORDER_DESC.YPO_RECDWT, 0) AS RECDWT, ISNULL(YARNPURCHASEORDER_DESC.YPO_DONE, 0) AS DONE, ISNULL(YARNPURCHASEORDER_DESC.YPO_CLOSED, 0) AS CLOSED, ISNULL(YPO_MRPNO,0) AS MRPNO, ISNULL(YPO_MRPSRNO,0) AS MRPSRNO ", "", "   YARNPURCHASEORDER INNER JOIN YARNPURCHASEORDER_DESC ON YARNPURCHASEORDER.YPO_NO = YARNPURCHASEORDER_DESC.YPO_NO AND YARNPURCHASEORDER.YPO_YEARID = YARNPURCHASEORDER_DESC.YPO_YEARID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNPURCHASEORDER_DESC.YPO_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS GRIDLEDGERS ON YARNPURCHASEORDER_DESC.YPO_GRIDLEDGERID = GRIDLEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON YARNPURCHASEORDER_DESC.YPO_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON YARNPURCHASEORDER_DESC.YPO_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN YARNQUALITYMASTER ON YARNPURCHASEORDER_DESC.YPO_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON YARNPURCHASEORDER.YPO_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON YARNPURCHASEORDER.YPO_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON YARNPURCHASEORDER_DESC.YPO_UNITID = UNITMASTER.unit_id ", WHERECLAUSE & "  and YARNPURCHASEORDER.YPO_YEARID =" & YearId & " ORDER BY dbo.YARNPURCHASEORDER.YPO_NO, dbo.YARNPURCHASEORDER_DESC.YPO_GRIDSRNO ")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal PONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPO As New YarnPurchaseOrder
                objPO.MdiParent = MDIMain
                objPO.EDIT = editval
                objPO.tempono = PONO
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
            showform(True, gridbill.GetFocusedRowCellValue("PONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        fillgrid()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PONO"))
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
                    e.Appearance.BackColor = Color.Yellow
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Purchase Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn PO Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub


End Class