
Imports BL

Public Class JobInDetails
    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPPONO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub JOBINDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub JOBINDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'JOB IN'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" AND dbo.JOBIN.JI_yearid=" & YearId & " order by dbo.JOBIN.JI_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName = "SVS" Then
                lbl.Text = "For Packing Details"
                Me.Text = "For Packing Details"
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" JOBIN.JI_no AS SRNO, JOBIN.JI_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, JOBIN.JI_TOTALQTY AS TOTALPCS, JOBIN.JI_TOTALMTRS AS TOTALMTRS, ISNULL(JI_JOBOUTNO,0) AS JONO, ISNULL(JOBIN.JI_remarks, '') AS REMARKS, ISNULL(JOBIN.JI_LOTNO,'') AS LOTNO, ISNULL(WEAVERLEDGERS.ACC_CMPNAME,'') AS WEAVERNAME, ISNULL(JOBIN.JI_WEAVERCHNO,'') AS WEAVERCHNO, ISNULL(JOBIN.JI_CHALLANNO,'') AS CHALLANNO", "", "  JOBIN INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON JOBIN.JI_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS WEAVERLEDGERS ON JOBIN.JI_PURLEDGERID = WEAVERLEDGERS.ACC_ID", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal JONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New JobIn
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPJOBINNO = JONO
                objREQ.Show()
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

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJJI As New JobInGridDetails
            OBJJI.MdiParent = MDIMain
            OBJJI.Show()
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

            Dim PATH As String = Application.StartupPath & "\Job In Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Job In Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job In Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Job In Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub JobInDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "KARAN" Then
                GWEAVERNAME.Visible = True
                GWEAVERCHNO.Visible = True
                GCHALLANNO.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class