
Imports BL

Public Class JobberBalanceCutReport

    Public WHERECLAUSE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobberBalanceCutReport_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobberBalanceCutReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search(" NAME, ITEMNAME, DESIGNNO,  MATCHING, CATEGORY, CUT ", "", " BALANCECUT ", WHERECLAUSE & " AND yearid=" & YearId & " ORDER BY NAME, ITEMNAME, DESIGNNO,  MATCHING")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
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
            PATH = Application.StartupPath & "\Balance Cut Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Balance Cut Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Balance Cut Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Balance Cut Report Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class