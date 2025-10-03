
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class YarnPurchaseOrderClose

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub YarnPurchaseOrderClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Space And e.Control = True Then
                'SELECT ALL DATA
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = Not Convert.ToBoolean(dtrow("CLOSED"))
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub YarnPurchaseOrderClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("*", "", " (SELECT ISNULL(YARNPURCHASEORDER.YPO_NO, 0) AS PONO, YARNPURCHASEORDER.YPO_DATE AS PODATE, YARNPURCHASEORDER.YPO_DUEDATE AS DUEDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(YARNPURCHASEORDER.YPO_CRDAYS, 0) AS CRDAYS, ISNULL(YARNPURCHASEORDER.YPO_DELDAYS, 0) AS DELDAYS, ISNULL(YARNPURCHASEORDER.YPO_REFNO, '') AS REFNO, ISNULL(YARNPURCHASEORDER.YPO_DISCOUNT, 0) AS DISCOUNT, ISNULL(YARNPURCHASEORDER.YPO_REMARKS, '') AS REMARKS, 'PURCHASEORDER' AS TYPE, ISNULL(YARNPURCHASEORDER_DESC.YPO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(YARNPURCHASEORDER_DESC.YPO_DESC, '') AS [DESC], ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GRIDLEDGERS.Acc_cmpname, '') AS GRIDNAME, ISNULL(YARNPURCHASEORDER_DESC.YPO_BAGS, 0) AS BAGS, ISNULL(YARNPURCHASEORDER_DESC.YPO_WT, 0) AS WT, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNPURCHASEORDER_DESC.YPO_RATE, 0) AS RATE, ISNULL(YARNPURCHASEORDER_DESC.YPO_AMT, 0) AS AMT, ISNULL(YARNPURCHASEORDER_DESC.YPO_RECDBAGS, 0) AS RECDBAGS, ISNULL(YARNPURCHASEORDER_DESC.YPO_RECDWT, 0) AS RECDWT, ISNULL(YARNPURCHASEORDER_DESC.YPO_DONE, 0) AS DONE, ISNULL(YARNPURCHASEORDER_DESC.YPO_CLOSED, 0) AS CLOSED, (ISNULL(YARNPURCHASEORDER_DESC.YPO_BAGS, 0) - ISNULL(YARNPURCHASEORDER_DESC.YPO_RECDBAGS, 0)) AS BALBAGS , (ISNULL(YARNPURCHASEORDER_DESC.YPO_WT, 0) - ISNULL(YARNPURCHASEORDER_DESC.YPO_RECDWT, 0)) AS BALWT FROM  YARNPURCHASEORDER INNER JOIN YARNPURCHASEORDER_DESC ON YARNPURCHASEORDER.YPO_NO = YARNPURCHASEORDER_DESC.YPO_NO AND YARNPURCHASEORDER.YPO_YEARID = YARNPURCHASEORDER_DESC.YPO_YEARID LEFT OUTER JOIN COLORMASTER ON YARNPURCHASEORDER_DESC.YPO_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON YARNPURCHASEORDER_DESC.YPO_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN YARNQUALITYMASTER ON YARNPURCHASEORDER_DESC.YPO_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN LEDGERS AS GRIDLEDGERS ON YARNPURCHASEORDER_DESC.YPO_GRIDLEDGERID = GRIDLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON YARNPURCHASEORDER.YPO_LEDGERID = LEDGERS.Acc_id WHERE (ISNULL(YARNPURCHASEORDER_DESC.YPO_WT, 0) - ISNULL(YARNPURCHASEORDER_DESC.YPO_RECDWT, 0)) > 0 AND  ISNULL(YARNPURCHASEORDER_DESC.YPO_CLOSED, 0) = 'FALSE' AND dbo.YARNPURCHASEORDER.YPO_yearid=" & YearId & " UNION ALL  SELECT ISNULL(OPENINGYARNPURCHASEORDER.OYPO_NO, 0) AS PONO, OPENINGYARNPURCHASEORDER.OYPO_DATE AS PODATE, OPENINGYARNPURCHASEORDER.OYPO_DUEDATE AS DUEDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(OPENINGYARNPURCHASEORDER.OYPO_CRDAYS, 0) AS CRDAYS, ISNULL(OPENINGYARNPURCHASEORDER.OYPO_DELDAYS, 0) AS DELDAYS, ISNULL(OPENINGYARNPURCHASEORDER.OYPO_REFNO, '') AS REFNO, ISNULL(OPENINGYARNPURCHASEORDER.OYPO_DISCOUNT, 0) AS DISCOUNT, ISNULL(OPENINGYARNPURCHASEORDER.OYPO_REMARKS, '') AS REMARKS, 'OPENING' AS TYPE, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_DESC, '') AS [DESC], ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GRIDLEDGERS.ACC_CMPNAME,'') AS GRIDNAME, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_BAGS, 0) AS BAGS, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_WT, 0) AS WT, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_RATE, 0) AS RATE, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_AMT, 0) AS AMT, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_RECDBAGS, 0) AS RECDBAGS, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_RECDWT, 0)  AS RECDWT, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_DONE, 0) AS DONE, ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_CLOSED, 0) AS CLOSED, (ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_BAGS, 0) - ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_RECDBAGS, 0)) AS BALBAGS , (ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_WT, 0) - ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_RECDWT, 0)) AS BALWT FROM OPENINGYARNPURCHASEORDER INNER JOIN OPENINGYARNPURCHASEORDER_DESC ON OPENINGYARNPURCHASEORDER.OYPO_NO = OPENINGYARNPURCHASEORDER_DESC.OYPO_NO AND OPENINGYARNPURCHASEORDER.OYPO_YEARID = OPENINGYARNPURCHASEORDER_DESC.OYPO_YEARID LEFT OUTER JOIN COLORMASTER ON OPENINGYARNPURCHASEORDER_DESC.OYPO_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON OPENINGYARNPURCHASEORDER_DESC.OYPO_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN YARNQUALITYMASTER ON OPENINGYARNPURCHASEORDER_DESC.OYPO_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN LEDGERS AS GRIDLEDGERS ON OPENINGYARNPURCHASEORDER_DESC.OYPO_GRIDLEDGERID = GRIDLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON OPENINGYARNPURCHASEORDER.OYPO_LEDGERID = LEDGERS.Acc_id WHERE (ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_WT, 0) - ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_RECDWT, 0)) > 0 AND  ISNULL(OPENINGYARNPURCHASEORDER_DESC.OYPO_CLOSED, 0) = 'FALSE' AND dbo.OPENINGYARNPURCHASEORDER.OYPO_yearid=" & YearId & ") AS T", " ORDER BY PONO, GRIDSRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim OBJCMN As New ClsCommon
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                    If DTROW("TYPE") = "PURCHASEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE YARNPURCHASEORDER_DESC SET YPO_CLOSED = 1 WHERE YPO_NO = " & Val(DTROW("PONO")) & " AND YPO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND YPO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGYARNPURCHASEORDER_DESC SET OYPO_CLOSED = 1 WHERE OYPO_NO = " & Val(DTROW("PONO")) & " AND OYPO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND OYPO_YEARID = " & YearId, "", "")
                End If
            Next
            fillgrid()
            gridbill.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
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
            MsgBox("Purchase Order Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class