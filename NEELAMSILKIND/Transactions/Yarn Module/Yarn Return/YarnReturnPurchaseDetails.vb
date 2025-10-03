

Imports BL

Public Class YarnReturnPurchaseDetails

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

            fillgrid(" and dbo.YARNPURCHASERETURN.YARNRET_yearid=" & YearId & " order by dbo.YARNPURCHASERETURN.YARNRET_NO ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim dt As DataTable = OBJCMN.search(" ISNULL(YARNPURCHASERETURN.YARNRET_NO, 0) AS SRNO, ISNULL(YARNPURCHASERETURN.YARNRET_date, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN,ISNULL(YARNPURCHASERETURN.YARNRET_CHALLANNO, '') AS CHALLANNO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNPURCHASERETURN.YARNRET_remarks, '') AS REMARKS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(MILLMASTER.MILL_NAME, '') AS MILL, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(YARNPURCHASERETURN_DESC.YARNRET_BOXNO, '') AS BOXNO, ISNULL(YARNPURCHASERETURN_DESC.YARNRET_LOTNO, '') AS LOTNO, ISNULL(YARNPURCHASERETURN_DESC.YARNRET_BAGS, 0) AS BAGS, ISNULL(YARNPURCHASERETURN_DESC.YARNRET_WT, 0) AS WT, ISNULL(YARNPURCHASERETURN_DESC.YARNRET_CONES, 0) AS CONES ", "", "YARNPURCHASERETURN INNER JOIN GODOWNMASTER ON YARNPURCHASERETURN.YARNRET_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON YARNPURCHASERETURN.YARNRET_LEDGERID = LEDGERS.Acc_id INNER JOIN YARNPURCHASERETURN_DESC ON YARNPURCHASERETURN.YARNRET_NO = YARNPURCHASERETURN_DESC.YARNRET_NO AND YARNPURCHASERETURN.YARNRET_yearid = YARNPURCHASERETURN_DESC.YARNRET_YEARID INNER JOIN YARNQUALITYMASTER ON YARNPURCHASERETURN_DESC.YARNRET_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID INNER JOIN MILLMASTER ON YARNPURCHASERETURN_DESC.YARNRET_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN COLORMASTER ON YARNPURCHASERETURN_DESC.YARNRET_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNPURCHASERETURN.YARNRET_transledgerid = TRANSLEDGERS.Acc_id", TEMPCONDITION)
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
                Dim objGRN As New YarnReturnPurchase
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.TEMPYARNRETNO = SRNO
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.YARNPURCHASERETURN.YARNRET_yearid=" & YearId & " order by dbo.YARNPURCHASERETURN.YARNRET_NO ")
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

            Dim PATH As String = Application.StartupPath & "\Yarn Return Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Yarn Return Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Yarn Return Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn Return Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid(" and dbo.YARNPURCHASERETURN.yarnRET_yearid=" & YearId & " order by dbo.YARNPURCHASERETURN.yarnRET_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class