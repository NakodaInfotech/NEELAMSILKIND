
Imports BL

Public Class YarnIssueDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN ISSUE'")
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
            If CHKFROM.CheckState = CheckState.Checked Then WHERECLAUSE = " and YARN_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND YARN_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" ISNULL(YARNISSUE.YARN_NO, 0) AS SRNO, ISNULL(YARNISSUE.YARN_DATE, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(YARNISSUE.YARN_CHALLANNO, '') AS CHALLANNO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(TRANSLEDGERS2.Acc_cmpname, '') AS TRANSNAME2, ISNULL(YARNISSUE.YARN_TOTALBAGS, 0) AS TOTALBAGS, ISNULL(YARNISSUE.YARN_TOTALWT, 0) AS TOTALWT, ISNULL(YARNISSUE.YARN_TOTALCONES, 0) AS TOTALCONES, ISNULL(YARNISSUE.YARN_remarks, '') AS REMARKS, ISNULL(YARNISSUE.YARN_RECDWT, 0) AS RECDWT, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(YARNISSUE_DESC.YARN_BOXNO, '') AS BOXNO, ISNULL(YARNISSUE_DESC.YARN_LOTNO, '') AS LOTNO, ISNULL(YARNISSUE_DESC.YARN_BAGS, 0) AS QTY, ISNULL(YARNISSUE_DESC.YARN_WT, 0) AS WT, ISNULL(YARNISSUE_DESC.YARN_CONES, 0) AS CONES, ISNULL(YARNISSUE_DESC.YARN_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(YARNISSUE_DESC.YARN_LRNO, '') AS LRNO, ISNULL(YARNISSUE_DESC.YARN_LRDATE, GETDATE()) AS LRDATE, ISNULL(MACHINEMASTER.MACHINE_NAME, '') AS MACHINE, ISNULL(YARNISSUE.YARN_EWBNO, '') AS EWBNO, ISNULL(YARNISSUE.YARN_VEHICLENO, '') AS VEHICLENO, ISNULL(YARN_MANUALAMT,0) AS MANUALAMT, ISNULL(YARNISSUE.YARN_TAXABLEAMT, 0) AS TAXABLEAMT, ISNULL(YARNISSUE.YARN_CGSTPER, 0) AS CGSTPER, ISNULL(YARNISSUE.YARN_CGSTAMT, 0) AS CGSTAMT, ISNULL(YARNISSUE.YARN_SGSTPER, 0) AS SGSTPER, ISNULL(YARNISSUE.YARN_SGSTAMT, 0) AS SGSTAMT, ISNULL(YARNISSUE.YARN_IGSTPER, 0) AS IGSTPER, ISNULL(YARNISSUE.YARN_IGSTAMT, 0) AS IGSTAMT, ISNULL(YARN_GRANDTOTAL,0) AS GRANDTOTAL", "", "YARNISSUE INNER JOIN YARNISSUE_DESC ON YARNISSUE.YARN_NO = YARNISSUE_DESC.YARN_NO AND YARNISSUE.YARN_yearid = YARNISSUE_DESC.YARN_YEARID INNER JOIN GODOWNMASTER ON YARNISSUE.YARN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON YARNISSUE.YARN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN PROCESSMASTER ON YARNISSUE.YARN_PROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN YARNQUALITYMASTER ON YARNISSUE_DESC.YARN_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON YARNISSUE_DESC.YARN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON YARNISSUE_DESC.YARN_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNISSUE.YARN_transledgerid = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS2 ON YARNISSUE.YARN_TRANSLEDGERID2 = TRANSLEDGERS2.Acc_id LEFT OUTER JOIN MACHINEMASTER ON YARNISSUE.YARN_MACHINEID = MACHINEMASTER.MACHINE_ID ", WHERECLAUSE & "  and dbo.YARNISSUE.YARN_yearid=" & YearId & " order by dbo.YARNISSUE.YARN_no ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SRNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objGRN As New YarnIssue
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.TEMPYARNNO = SRNO
                objGRN.Show()
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Yarn Issue Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Yarn Issue Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Yarn Issue Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn Issue Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class