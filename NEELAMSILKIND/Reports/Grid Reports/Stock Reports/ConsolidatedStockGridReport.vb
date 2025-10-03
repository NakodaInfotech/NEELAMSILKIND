
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class ConsolidatedStockGridReport

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsolidatedStockGridReport_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ConsolidatedStockGridReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            'IF CHK IS TRUE THEN GET ALL STOCK WITH 0 ALSO
            Dim TEMPCONDITION As String = ""
            If CHKALL.Checked = False Then TEMPCONDITION = TEMPCONDITION & " AND (PENDINGWEAVERQTY > 0 OR STOCK > 0 OR PENDINGORDER > 0) AND YEARID = " & YearId Else TEMPCONDITION = TEMPCONDITION & " AND YEARID = " & YearId
            If CHKDESPATCH.Checked = True Then TEMPCONDITION = TEMPCONDITION & " AND (STOCK > 0 AND PENDINGORDER > 0) AND YEARID = " & YearId

            If CHKREPEAT.Checked = True Then TEMPCONDITION = TEMPCONDITION & " AND (STOCK <= 0 AND PENDINGWEAVERQTY <= 0 AND PENDINGORDER > 0) AND YEARID = " & YearId
            If CHKFOLLOWUP.Checked = True Then TEMPCONDITION = TEMPCONDITION & " AND (PENDINGWEAVERQTY > 0 AND STOCKLESSORDER <0) AND YEARID = " & YearId
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If CHKSAMPLEOUT.Checked = True Then
                TEMPCONDITION = TEMPCONDITION & " AND ((PENDINGWEAVERQTY + STOCK)-PENDINGORDER <=0) AND YEARID = " & YearId
                GSODATE.Visible = True
                DT = OBJCMN.Execute_Any_String(" SELECT * FROM GREYSTOCKVIEW CROSS APPLY (SELECT TOP 1 SO_DATE AS SODATE FROM SALEORDER INNER JOIN SALEORDER_DESC ON SALEORDER.SO_NO = SALEORDER_DESC.SO_NO AND SALEORDER.SO_YEARID = SALEORDER_DESC.SO_YEARID INNER JOIN DESIGNMASTER ON SALEORDER_DESC.SO_DESIGNID = DESIGN_ID WHERE GREYSTOCKVIEW.DESIGNNO = DESIGNMASTER.DESIGN_NO AND SALEORDER_DESC.SO_YEARID = GREYSTOCKVIEW.YEARID AND SALEORDER.SO_YEARID = " & YearId & " ORDER BY SALEORDER.SO_DATE DESC) AS T  WHERE 1 = 1 " & TEMPCONDITION, "", "")
            Else
                GSODATE.Visible = False
                DT = OBJCMN.Execute_Any_String(" SELECT * FROM GREYSTOCKVIEW WHERE 1 = 1 " & TEMPCONDITION, "", "")
            End If
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Stock Summary.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Stock Summary"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Summary", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Stock Summary Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            gridbill.ClearColumnsFilter()
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("STOCK"))) > 0 And Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("PENDINGORDER"))) > 0 Then
                    e.Appearance.BackColor = Color.Yellow
                ElseIf Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("TOTALLESSORDER"))) < 0 Then
                    e.Appearance.BackColor = Color.LightBlue
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(sender As Object, e As EventArgs) Handles gridbill.DoubleClick
        Try
            Dim OBJGRN As New SaleInvoiceDesign
            OBJGRN.MdiParent = MDIMain
            OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            OBJGRN.PENDINGSO = "PENDING"
            OBJGRN.POSOFRMSTRING = "SO"
            OBJGRN.WHERECLAUSE = " {ALLSALEORDER.SO_yearid}=" & YearId
            OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & gridbill.GetFocusedRowCellValue("DESIGNNO") & "'"
            OBJGRN.FRMSTRING = "SOSTATUS"
            OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@BALANCE} > 0 and {ALLSALEORDER_DESC.SO_Closed}=FALSE "
            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class