Imports BL

Public Class LoomSampleRecdDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal SMPNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJPO As New LoomSampleRecd
            OBJPO.EDIT = EDITVAL
            OBJPO.MdiParent = MDIMain
            OBJPO.TEMPSMP = SMPNO
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub LoomSampleRecdDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub LoomSampleRecdDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
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
            Dim OBJSMP As New ClsLoomSampleRecd()
            OBJSMP.alParaval.Add(0)
            OBJSMP.alParaval.Add(YearId)
            Dim dttable As DataTable = OBJSMP.SELECTSMP()
            gridbilldetails.DataSource = dttable
            gridbill.FocusedRowHandle = gridbill.RowCount - 1
            gridbill.TopRowIndex = gridbill.RowCount - 15
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            SHOWFORM(True, gridbill.GetFocusedRowCellValue("SMPNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(sender As Object, e As EventArgs) Handles gridbilldetails.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            SHOWFORM(True, gridbill.GetFocusedRowCellValue("SMPNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            SHOWFORM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = Application.StartupPath & "\LoomSample Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "  Loom Sample Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "LoomSample  Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class