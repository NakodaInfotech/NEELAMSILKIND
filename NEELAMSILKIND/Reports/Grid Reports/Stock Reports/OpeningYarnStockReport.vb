
Imports BL

Public Class OpeningYarnStockReport

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningYarnStockReport_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, cmbtype, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpeningYarnStockReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal cmbtype As ComboBox, NO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objOP As New OpeningStockYarn
                objOP.FRMSTRING = cmbtype.Text
                objOP.TEMPNO = NO
                objOP.MdiParent = MDIMain
                objOP.EDIT = editval
                objOP.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If cmbtype.Text <> "" Then
                Dim objclsCMST As New ClsCommonMaster
                Dim dt As DataTable = objclsCMST.search(" STOCKMASTER_YARN.SM_GRIDSRNO AS SRNO, ISNULL(STOCKMASTER_YARN.SM_LOTNO, '') AS LOTNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(STOCKMASTER_YARN.SM_BOXNO, '') AS BOXNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, STOCKMASTER_YARN.SM_BAGS AS BAGS, STOCKMASTER_YARN.SM_WT AS WT, STOCKMASTER_YARN.SM_CONES AS CONES, STOCKMASTER_YARN.SM_NO AS SMNO  ", "", " STOCKMASTER_YARN LEFT OUTER JOIN PROCESSMASTER ON STOCKMASTER_YARN.SM_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN YARNQUALITYMASTER ON STOCKMASTER_YARN.SM_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN MILLMASTER ON STOCKMASTER_YARN.SM_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN COLORMASTER ON STOCKMASTER_YARN.SM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN LEDGERS ON STOCKMASTER_YARN.SM_LEDGERIDTO = LEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON STOCKMASTER_YARN.SM_GODOWNID = GODOWNMASTER.GODOWN_id ", TEMPCONDITION)
                gridbilldetails.DataSource = dt

                If dt.Rows.Count > 0 Then
                    gridbill.FocusedRowHandle = gridbill.RowCount - 1
                    gridbill.TopRowIndex = gridbill.RowCount - 15
                End If
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
            showform(False, cmbtype, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        showform(False, cmbtype, Val(gridbill.GetFocusedDataRow("SMNO")))
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        Try
            fillgrid(" and STOCKMASTER_YARN.SM_type='" & cmbtype.Text & "' and dbo.STOCKMASTER_YARN.SM_yearid=" & YearId & " order by dbo.STOCKMASTER_YARN.SM_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Opening Yarn Stock Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Opening Yarn Stock Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Opening Yarn Stock Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Opening Yarn Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(sender As Object, e As EventArgs) Handles gridbill.DoubleClick
        Call cmdok_Click(sender, e)
    End Sub
End Class