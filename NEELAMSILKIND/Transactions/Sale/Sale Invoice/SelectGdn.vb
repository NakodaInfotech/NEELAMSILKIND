
Imports BL

Public Class SelectGdn

    Public BALENO As String = ""
    Public PARTYNAME As String = ""
    Public FRMSTRING As String = ""
    Public DT1 As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectMfgforPS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectMfgforPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid()
        gridbilldetails.ForceInitialize()
        gridbill.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
    End Sub
    
    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If PARTYNAME <> "" Then where = where & " AND LEDGERS.Acc_cmpname='" & PARTYNAME & "'"
            Dim OBJCMN As New ClsCommon()
            Dim DT1 As DataTable = OBJCMN.search("*", "", "(SELECT DISTINCT CAST (0 AS BIT) AS CHK, GDN.GDN_NO AS GDNNO, 0 AS GPNO, GDN.GDN_date AS GPDATE, GDN.GDN_TYPENO AS [TYPECHALLANNO], GDN.GDN_date AS GDNDATE, ISNULL(GDN_TRANSREFNO,'') AS PARTYCHALLANNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(ITEM_NAME, '') AS ITEMNAME, ISNULL(DESIGN_NO, '') AS DESIGNNO, ISNULL(COLOR_NAME, '') AS SHADE, SUM(ISNULL(GDN_DESC.GDN_PCS, 0)) AS PCS, SUM(ISNULL(GDN_DESC.GDN_MTRS, 0)) AS MTRS, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GDN.GDN_TOTALBALES, 0) AS TOTALBALES, ISNULL(GDN.GDN_TOTALAMT, 0) AS TOTALAMT, ISNULL(packingLEDGERS.Acc_cmpname,'') AS DELIVERYAT, ISNULL(GDN_TRANSREMARKS,'') AS PONO, ISNULL(GDN_DESC.GDN_RATE,0) AS RATE, 'GDN' AS FROMTYPE  FROM  GDN INNER JOIN GDN_DESC ON GDN.GDN_NO = GDN_DESC.GDN_NO AND GDN.GDN_YEARID = GDN_DESC.GDN_YEARID LEFT OUTER JOIN GODOWNMASTER ON GDN.GDN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON GDN_ITEMID = ITEM_ID LEFT OUTER JOIN DESIGNMASTER ON GDN_DESIGNID = DESIGN_ID LEFT OUTER JOIN COLORMASTER ON GDN_COLORID = COLOR_ID  LEFT OUTER JOIN LEDGERS AS packingLEDGERS ON GDN.GDN_DISPATCHTOID = packingLEDGERS.Acc_id WHERE GDN_DESC.GDN_SALEDONE = 0 AND ISNULL(GDN.GDN_HOLDFORAPPROVAL,0) = 0 and ROUND(ISNULL(GDN.GDN_OUTMTRS,0),0) = 0 AND GDN.GDN_YEARID = " & YearId & where & " GROUP BY GDN.GDN_NO, GDN.GDN_TYPENO, GDN.GDN_date, ISNULL(GDN_TRANSREFNO,''), LEDGERS.Acc_cmpname, ISNULL(ITEM_NAME, '') , ISNULL(DESIGN_NO, ''), ISNULL(COLOR_NAME, '') , ISNULL(GODOWNMASTER.GODOWN_name, ''), ISNULL(GDN.GDN_TOTALBALES, 0), ISNULL(GDN.GDN_TOTALAMT, 0), ISNULL(packingLEDGERS.Acc_cmpname,''), ISNULL(GDN_TRANSREMARKS,''), ISNULL(GDN_DESC.GDN_RATE,0) UNION ALL SELECT DISTINCT CAST (0 AS BIT) AS CHK, YARNCHALLAN.YARN_NO AS GDNNO, 0 AS GPNO, YARNCHALLAN.YARN_date AS GPDATE, 0 AS [TYPECHALLANNO], YARNCHALLAN.YARN_date AS YARNCHALLANDATE, ISNULL(YARN_REFNO,'') AS PARTYCHALLANNO, LEDGERS.Acc_cmpname AS NAME, 'YARN' AS ITEMNAME, '' AS DESIGNNO, ISNULL(COLOR_NAME, '') AS SHADE, SUM(ISNULL(YARNCHALLAN_DESC.YARN_QTY, 0)) AS PCS, SUM(ISNULL(YARNCHALLAN_DESC.YARN_WT, 0)) AS MTRS, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, 0 AS TOTALBALES, 0 AS TOTALAMT, ISNULL(packingLEDGERS.Acc_cmpname,'') AS DELIVERYAT, '' AS PONO, 0 AS RATE, 'YARN' AS FROMTYPE FROM YARNCHALLAN INNER JOIN YARNCHALLAN_DESC ON YARNCHALLAN.YARN_NO = YARNCHALLAN_DESC.YARN_NO AND YARNCHALLAN.YARN_YEARID = YARNCHALLAN_DESC.YARN_YEARID LEFT OUTER JOIN GODOWNMASTER ON YARNCHALLAN.YARN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS ON YARNCHALLAN.YARN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON YARN_COLORID = COLOR_ID  LEFT OUTER JOIN LEDGERS AS packingLEDGERS ON YARNCHALLAN.YARN_DISPATCHTOID = packingLEDGERS.Acc_id WHERE  ROUND(ISNULL(YARNCHALLAN.YARN_OUTWT,0),0) = 0 AND YARNCHALLAN.YARN_YEARID = " & YearId & " GROUP BY YARNCHALLAN.YARN_NO, YARNCHALLAN.YARN_date, ISNULL(YARN_REFNO,''), LEDGERS.Acc_cmpname, ISNULL(COLOR_NAME, '') , ISNULL(GODOWNMASTER.GODOWN_name, ''), ISNULL(packingLEDGERS.Acc_cmpname,'')) AS T ", " order by T.GDNNO ")
            gridbilldetails.DataSource = DT1
            If DT1.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT1.Columns.Add("GDNNO")
            DT1.Columns.Add("GDNDATE")
            DT1.Columns.Add("CHALLANNO")
            DT1.Columns.Add("NAME")
            DT1.Columns.Add("PCS")
            DT1.Columns.Add("MTRS")
            DT1.Columns.Add("GODOWN")
            DT1.Columns.Add("TOTALBALES")
            DT1.Columns.Add("TOTALAMT")
            DT1.Columns.Add("GPNO")
            DT1.Columns.Add("GPDATE")
            DT1.Columns.Add("FROMTYPE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT1.Rows.Add(dtrow("GDNNO"), dtrow("GDNDATE"), dtrow("PARTYCHALLANNO"), dtrow("NAME"), Val(dtrow("PCS")), Val(dtrow("MTRS")), dtrow("GODOWN"), Val(dtrow("TOTALBALES")), Val(dtrow("TOTALAMT")), Val(dtrow("GPNO")), dtrow("GPDATE"), dtrow("FROMTYPE"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = chkall.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class