
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class YarnDyeingProgramClose

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub YarnDyeingProgramClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Space And e.Control = True Then
                'SELECT ALL DATA
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = Not Convert.ToBoolean(dtrow("CLOSED"))
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub YarnDyeingProgramClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'YARN ISSUE'")
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
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("*", "", " (SELECT ISNULL(YARNDYEINGPROGRAM.PROG_NO, 0) AS PROGNO, YARNDYEINGPROGRAM.PROG_DATE AS PROGDATE, YARNDYEINGPROGRAM.PROG_DUEDATE AS DUEDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(YARNDYEINGPROGRAM.PROG_CRDAYS, 0) AS CRDAYS, ISNULL(YARNDYEINGPROGRAM.PROG_DELDAYS, 0) AS DELDAYS, ISNULL(YARNDYEINGPROGRAM.PROG_REFNO, '') AS REFNO, ISNULL(YARNDYEINGPROGRAM.PROG_DISCOUNT, 0) AS DISCOUNT, ISNULL(YARNDYEINGPROGRAM.PROG_REMARKS, '') AS REMARKS, 'YARNDYEINGPROGRAM' AS TYPE, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_DESC, '') AS [DESC], ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GRIDLEDGERS.Acc_cmpname, '') AS GRIDNAME, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_BAGS, 0) AS BAGS, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_WT, 0) AS WT, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RECDBAGS, 0) AS RECDBAGS, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RECDWT, 0) AS RECDWT, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_DONE, 0) AS DONE, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_CLOSED, 0) AS CLOSED, (ISNULL(YARNDYEINGPROGRAM_DESC.PROG_BAGS, 0) - ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RECDBAGS, 0)) AS BALBAGS , (ISNULL(YARNDYEINGPROGRAM_DESC.PROG_WT, 0) - ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RECDWT, 0)) AS BALWT FROM  YARNDYEINGPROGRAM INNER JOIN YARNDYEINGPROGRAM_DESC ON YARNDYEINGPROGRAM.PROG_NO = YARNDYEINGPROGRAM_DESC.PROG_NO AND YARNDYEINGPROGRAM.PROG_YEARID = YARNDYEINGPROGRAM_DESC.PROG_YEARID LEFT OUTER JOIN COLORMASTER ON YARNDYEINGPROGRAM_DESC.PROG_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON YARNDYEINGPROGRAM_DESC.PROG_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN YARNQUALITYMASTER ON YARNDYEINGPROGRAM_DESC.PROG_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON YARNDYEINGPROGRAM.PROG_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS GRIDLEDGERS ON YARNDYEINGPROGRAM_DESC.PROG_GRIDLEDGERID = GRIDLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON YARNDYEINGPROGRAM.PROG_LEDGERID = LEDGERS.Acc_id WHERE (ISNULL(YARNDYEINGPROGRAM_DESC.PROG_WT, 0) - ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RECDWT, 0)) > 0 AND  ISNULL(YARNDYEINGPROGRAM_DESC.PROG_CLOSED, 0) = 'FALSE' AND dbo.YARNDYEINGPROGRAM.PROG_yearid=" & YearId & " UNION ALL  SELECT ISNULL(OPENINGYARNDYEINGPROGRAM.PROG_NO, 0) AS PROGNO, OPENINGYARNDYEINGPROGRAM.PROG_DATE AS PROGDATE, OPENINGYARNDYEINGPROGRAM.PROG_DUEDATE AS DUEDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(OPENINGYARNDYEINGPROGRAM.PROG_CRDAYS, 0) AS CRDAYS, ISNULL(OPENINGYARNDYEINGPROGRAM.PROG_DELDAYS, 0) AS DELDAYS, ISNULL(OPENINGYARNDYEINGPROGRAM.PROG_REFNO, '') AS REFNO, ISNULL(OPENINGYARNDYEINGPROGRAM.PROG_DISCOUNT, 0) AS DISCOUNT, ISNULL(OPENINGYARNDYEINGPROGRAM.PROG_REMARKS, '') AS REMARKS, 'OPENING' AS TYPE, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_DESC, '') AS [DESC], ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GRIDLEDGERS.ACC_CMPNAME,'') AS GRIDNAME, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_BAGS, 0) AS BAGS, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_WT, 0) AS WT, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_RECDBAGS, 0) AS RECDBAGS, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_RECDWT, 0)  AS RECDWT, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_DONE, 0) AS DONE, ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_CLOSED, 0) AS CLOSED, (ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_BAGS, 0) - ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_RECDBAGS, 0)) AS BALBAGS , (ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_WT, 0) - ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_RECDWT, 0)) AS BALWT FROM OPENINGYARNDYEINGPROGRAM INNER JOIN OPENINGYARNDYEINGPROGRAM_DESC ON OPENINGYARNDYEINGPROGRAM.PROG_NO = OPENINGYARNDYEINGPROGRAM_DESC.PROG_NO AND OPENINGYARNDYEINGPROGRAM.PROG_YEARID = OPENINGYARNDYEINGPROGRAM_DESC.PROG_YEARID LEFT OUTER JOIN COLORMASTER ON OPENINGYARNDYEINGPROGRAM_DESC.PROG_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON OPENINGYARNDYEINGPROGRAM_DESC.PROG_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN YARNQUALITYMASTER ON OPENINGYARNDYEINGPROGRAM_DESC.PROG_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON OPENINGYARNDYEINGPROGRAM.PROG_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS GRIDLEDGERS ON OPENINGYARNDYEINGPROGRAM_DESC.PROG_GRIDLEDGERID = GRIDLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON OPENINGYARNDYEINGPROGRAM.PROG_LEDGERID = LEDGERS.Acc_id WHERE (ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_WT, 0) - ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_RECDWT, 0)) > 0 AND  ISNULL(OPENINGYARNDYEINGPROGRAM_DESC.PROG_CLOSED, 0) = 'FALSE' AND dbo.OPENINGYARNDYEINGPROGRAM.PROG_yearid=" & YearId & ") AS T", " ORDER BY PROGNO, GRIDSRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim OBJCMN As New ClsCommon
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                    If DTROW("TYPE") = "YARNDYEINGPROGRAM" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE YARNDYEINGPROGRAM_DESC SET PROG_CLOSED = 1 WHERE PROG_NO = " & Val(DTROW("PROGNO")) & " AND PROG_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND PROG_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGYARNDYEINGPROGRAM_DESC SET PROG_CLOSED = 1 WHERE PROG_NO = " & Val(DTROW("PROGNO")) & " AND PROG_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND PROG_YEARID = " & YearId, "", "")
                End If
            Next
            fillgrid()
            gridbill.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Dyeing Program Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Dyeing Program Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Dyeing Program Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class