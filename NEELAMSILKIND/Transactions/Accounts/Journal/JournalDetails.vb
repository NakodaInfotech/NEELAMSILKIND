
Imports BL

Public Class JournalDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Private Sub JournalDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.N) Or (e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.A) Then       'for AddNew 
                showform(False, 0)
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" dbo.journalMaster.journal_no AS [Sr. No], dbo.Ledgers.acc_cmpname AS [Party Name] ,dbo.JournalMaster.journal_date AS [Date], sum(dbo.journalMaster.journal_credit) as Amount, dbo.journalMaster.journal_remarks AS [Remarks]", "", "  dbo.JournalMaster LEFT OUTER JOIN dbo.Ledgers ON dbo.JournalMaster.journal_cmpid = dbo.Ledgers.acc_cmpid AND dbo.JournalMaster.journal_LOCATIONid = dbo.Ledgers.acc_LOCATIONid AND dbo.JournalMaster.journal_YEARid = dbo.Ledgers.acc_YEARid AND dbo.journalMaster.journal_ledgerid = dbo.Ledgers.acc_id  ", tempcondition & " GROUP BY dbo.journalMaster.journal_no, dbo.Ledgers.acc_cmpname  ,dbo.JournalMaster.journal_date , dbo.journalMaster.journal_remarks order by dbo.JOURNALMASTER.JOURNAL_NO")
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridjournal.FocusedRowHandle = gridjournal.RowCount - 1
                gridjournal.TopRowIndex = gridjournal.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridjournal.RowCount > 0) Then
                Dim objJVmaster As New journal
                objJVmaster.MdiParent = MDIMain
                objJVmaster.edit = editval
                objJVmaster.tempjvno = billno
                objJVmaster.TEMPREGNAME = cmbregister.Text.Trim
                objJVmaster.Show()
                'Me.Close()
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

    Private Sub gridjournal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridjournal.DoubleClick
        Try
            showform(True, gridjournal.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'JOURNAL'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    JVREGID = dt.Rows(0).Item(0)
                    fillgrid(" and dbo.JOURNALMASTER.JOURNAL_cmpid=" & CmpId & " and dbo.JOURNALMASTER.JOURNAL_LOCATIONid=" & Locationid & " and dbo.JOURNALMASTER.JOURNAL_YEARid=" & YearId & " AND JOURNALMASTER.JOURNAL_registerid = " & JVREGID & " AND DBO.JOURNALMASTER.JOURNAL_DEBIT = 0")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOURNAL VOUCHER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJJV As New JournalGridDetails
            OBJJV.MdiParent = MDIMain
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridjournal.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Journal Register Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Journal Register Details"
            gridjournal.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Journal Register Details", gridjournal.VisibleColumns.Count + gridjournal.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Journal Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub JournalDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class