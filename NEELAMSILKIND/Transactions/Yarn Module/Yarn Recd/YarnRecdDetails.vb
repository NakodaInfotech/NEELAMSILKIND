
Imports BL

Public Class YarnRecdDetails

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
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.YARNRECD.YARN_yearid=" & YearId)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try

            If CHKFROM.Checked = True Then TEMPCONDITION = TEMPCONDITION & " AND YARNRECD.YARN_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND YARNRECD.YARN_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim OBJDEPT As New ClsCommon
            Dim DT As DataTable = OBJDEPT.search(" ISNULL(YARNRECD.YARN_NO, 0) AS YARNNO, ISNULL(YARNRECD.YARN_DATE, GETDATE()) AS YARNDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(YARNRECD.YARN_PONO, '') AS pono, ISNULL(YARNRECD.YARN_PODATE, GETDATE()) AS podate, ISNULL(YARNRECD.YARN_CHALLANNO, '') AS CHALLANNO, ISNULL(YARNRECD.YARN_CHALLANDT, GETDATE()) AS CHALLANDATE, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNRECD.YARN_FREIGHT, '') AS FREIGHT, ISNULL(YARNRECD.YARN_TOTALQTY, 0) AS TOTALQTY, ISNULL(YARNRECD.YARN_TOTALWT, 0) AS TOTALWT, ISNULL(YARNRECD.YARN_TOTALCONES, 0) AS TOTALCONES, ISNULL(YARNRECD.YARN_REMARKS, '') AS REMARKS, ISNULL(YARNRECD_DESC.YARN_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(YARNRECD_DESC.YARN_BOXNO, '') AS BOXNO, ISNULL(YARNRECD_DESC.YARN_QTY, 0) AS QTY, ISNULL(YARNRECD_DESC.YARN_WT, 0) AS WT, ISNULL(YARNRECD_DESC.YARN_CONES, 0) AS CONES, ISNULL(YARNRECD_DESC.YARN_LRNO, '') AS LRNO, ISNULL(YARNRECD_DESC.YARN_LRDATE, GETDATE()) AS LRDATE, ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(YARNRECD.YARN_DONE, 0) AS DONE, ISNULL(YARNRECD_DESC.YARN_OUTPCS, 0) AS OUTPCS, ISNULL(YARNRECD_DESC.YARN_OUTMTRS, 0) AS OUTMTRS, ISNULL(YARNRECD_DESC.YARN_GRIDPONO, 0) AS GRIDPONO, ISNULL(YARNRECD_DESC.YARN_POGRIDSRNO, 0) AS POGRIDSRNO, ISNULL(YARNRECD_DESC.YARN_GRIDLOTNO, '') AS GRIDLOTNO, ISNULL(YARNRECD.YARN_VEHICLENO, '') AS VEHICLENO, ISNULL(FROMCITYMASTER.city_name, '') AS FROMCITY, ISNULL(TOCITYMASTER.city_name, '') AS TOCITY, ISNULL(YARNRECD.YARN_EWAYBILLNO, '') AS EWAYBILLNO, ISNULL(YARNRECD.YARN_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(YARNRECD.YARN_CGSTPER, 0) AS CGSTPER, ISNULL(YARNRECD.YARN_CGSTAMT, 0) AS CGSTAMT, ISNULL(YARNRECD.YARN_SGSTPER, 0) AS SGSTPER, ISNULL(YARNRECD.YARN_SGSTAMT, 0) AS SGSTAMT, ISNULL(YARNRECD.YARN_IGSTPER, 0) AS IGSTPER, ISNULL(YARNRECD.YARN_IGSTAMT, 0) AS IGSTAMT, ISNULL(YARNRECD.YARN_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(YARNRECD.YARN_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(FROMGODOWNMASTER.GODOWN_NAME,'') AS FROMGODOWN ", "", " GODOWNMASTER RIGHT OUTER JOIN YARNRECD INNER JOIN YARNRECD_DESC ON YARNRECD.YARN_NO = YARNRECD_DESC.YARN_NO AND YARNRECD.YARN_YEARID = YARNRECD_DESC.YARN_YEARID INNER JOIN LEDGERS ON YARNRECD.YARN_LEDGERID = LEDGERS.Acc_id INNER JOIN YARNQUALITYMASTER ON YARNRECD_DESC.YARN_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN CITYMASTER AS TOCITYMASTER ON YARNRECD.YARN_TOCITYID = TOCITYMASTER.city_id LEFT OUTER JOIN CITYMASTER AS FROMCITYMASTER ON YARNRECD.YARN_FROMCITYID = FROMCITYMASTER.city_id LEFT OUTER JOIN MILLMASTER ON YARNRECD_DESC.YARN_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN COLORMASTER ON YARNRECD_DESC.YARN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNRECD.YARN_TRANSLEDGERID = TRANSLEDGERS.Acc_id ON GODOWNMASTER.GODOWN_id = YARNRECD.YARN_GODOWNID LEFT OUTER JOIN GODOWNMASTER AS FROMGODOWNMASTER ON YARN_FROMGODOWNID = FROMGODOWNMASTER.GODOWN_id ", "" & TEMPCONDITION & " order by dbo.YARNRECD.YARN_no ")
            gridbilldetails.DataSource = DT
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
                Dim objGRN As New YarnRecd
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.tempYARNno = SRNO
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
            fillgrid(" and dbo.YARNRECD.YARN_yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("YARNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("YARNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Yarn Received Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Yarn Received Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Yarn Received Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn Recd Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class