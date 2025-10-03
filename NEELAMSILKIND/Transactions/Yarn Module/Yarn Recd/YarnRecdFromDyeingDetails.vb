
Imports BL

Public Class YarnRecdFromDyeingDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub YarnRecdFromDyeingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub YarnRecdFromDyeingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOB IN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.YARNRECDDYEING.YARN_yearid=" & YearId & " order by dbo.YARNRECDDYEING.YARN_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try

            If CHKFROM.Checked = True Then TEMPCONDITION = " AND YARNRECDDYEING.YARN_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND YARNRECDDYEING.YARN_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'" & TEMPCONDITION

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" ISNULL(YARNRECDDYEING.YARN_no, 0) AS SRNO, ISNULL(YARNRECDDYEING.YARN_date, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(TONAME.Acc_cmpname, '') AS TONAME, ISNULL(YARNRECDDYEING.YARN_challanno, '') AS CHALLANNO, (CASE WHEN YARNRECDDYEING.YARN_CHALLANNO = '' THEN '' ELSE CAST(YARNRECDDYEING.YARN_CHALLANDT AS VARCHAR(10)) END) AS CHALLANDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNRECDDYEING.YARN_remarks, '') AS REMARKS, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARN,  ISNULL(MILLMASTER.MILL_NAME, '') AS MILL, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(YARNRECDDYEING_DESC.YARN_BOXNO, '') AS BOXNO, ISNULL(YARNRECDDYEING_DESC.YARN_LOTNO, '') AS LOTNO, ISNULL(YARNRECDDYEING_DESC.YARN_QTY, 0) AS QTY, ISNULL(YARNRECDDYEING_DESC.YARN_WT, 0) AS WT, ISNULL(YARNRECDDYEING_DESC.YARN_CONES, 0) AS CONES, ISNULL(PROCESSMASTER.PROCESS_NAME,'') AS PROCESS  ", "", " YARNRECDDYEING INNER JOIN GODOWNMASTER ON YARNRECDDYEING.YARN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS AS TONAME ON YARNRECDDYEING.YARN_TOLEDGERID = TONAME.Acc_id INNER JOIN YARNRECDDYEING_DESC ON YARNRECDDYEING.YARN_no = YARNRECDDYEING_DESC.YARN_NO AND YARNRECDDYEING.YARN_yearid = YARNRECDDYEING_DESC.YARN_YEARID LEFT OUTER JOIN MILLMASTER ON YARNRECDDYEING_DESC.YARN_MILLID = MILLMASTER.MILL_ID INNER JOIN YARNQUALITYMASTER ON YARNRECDDYEING_DESC.YARN_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON YARNRECDDYEING_DESC.YARN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN LEDGERS ON YARNRECDDYEING.YARN_transledgerid = LEDGERS.Acc_id LEFT OUTER JOIN PROCESSMASTER ON YARN_PROCESSID = PROCESS_ID", TEMPCONDITION)
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
                Dim objGRN As New YarnRecdFromDyeing
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
            fillgrid(" and dbo.YARNRECDDYEING.YARN_yearid=" & YearId & " order by dbo.YARNRECDDYEING.YARN_no ")
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

            Dim PATH As String = Application.StartupPath & "\Yarn Received From Dyeing Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Yarn Received From Dyeing Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Yarn Received From Dyeing Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn Recd Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class