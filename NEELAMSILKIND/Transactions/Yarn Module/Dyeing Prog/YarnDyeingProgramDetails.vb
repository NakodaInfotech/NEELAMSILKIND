
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class YarnDyeingProgramDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub YarnDyeingProgramDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub YarnDyeingProgramDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim WHERECLAUSE As String = ""
            If CHKFROM.CheckState = CheckState.Checked Then WHERECLAUSE = " and YARNDYEINGPROGRAM.PROG_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND YARNDYEINGPROGRAM.PROG_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search("ISNULL(YARNDYEINGPROGRAM.PROG_NO, 0) AS PROGNO, YARNDYEINGPROGRAM.PROG_DATE AS PROGDATE, YARNDYEINGPROGRAM.PROG_DUEDATE AS DUEDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(YARNDYEINGPROGRAM.PROG_CRDAYS, 0) AS CRDAYS, ISNULL(YARNDYEINGPROGRAM.PROG_DELDAYS, 0) AS DELDAYS, ISNULL(YARNDYEINGPROGRAM.PROG_REFNO, '') AS REFNO, ISNULL(YARNDYEINGPROGRAM.PROG_DISCOUNT, 0) AS DISCOUNT, ISNULL(YARNDYEINGPROGRAM.PROG_REMARKS, '') AS REMARKS, ISNULL(YARNDYEINGPROGRAM.PROG_ORDERTYPE, '') AS ORDERTYPE, ISNULL(YARNDYEINGPROGRAM.PROG_LBLTOTALAMT, 0) AS LBLTOTALPCS, ISNULL(YARNDYEINGPROGRAM.PROG_INWORDS, '') AS INWORDS, ISNULL(BROKERLEDGERS.Acc_cmpname, '') AS BROKER, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_DESC, '') AS [DESC], ISNULL(UNITMASTER.unit_name, '') AS UNIT, ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GRIDLEDGERS.Acc_cmpname, '') AS GRIDNAME, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_BAGS, 0) AS BAGS, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_WT, 0) AS WT, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_CONES, 0) AS CONES, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(LEDGERS.Acc_mobile, '') AS MOBILENO, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RATE, 0) AS RATE, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_AMT, 0) AS AMT, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RECDBAGS, 0) AS RECDBAGS, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_RECDWT, 0) AS RECDWT, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_DONE, 0) AS DONE, ISNULL(YARNDYEINGPROGRAM_DESC.PROG_CLOSED, 0) AS CLOSED, ISNULL(FROMYARNQUALITYMASTER.YARN_NAME,'') AS FROMYARNQUALITY,ISNULL(FROMCOLORMASTER.COLOR_NAME,'') AS FROMSHADE, ISNULL(PROG_REDYEING,0) AS REDYEING,  ISNULL(PROG_MRPNO,0) AS MRPNO, ISNULL(PROG_MRPSRNO,0) AS MRPSRNO ", "", "   YARNDYEINGPROGRAM INNER JOIN YARNDYEINGPROGRAM_DESC ON YARNDYEINGPROGRAM.PROG_NO = YARNDYEINGPROGRAM_DESC.PROG_NO AND YARNDYEINGPROGRAM.PROG_YEARID = YARNDYEINGPROGRAM_DESC.PROG_YEARID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNDYEINGPROGRAM_DESC.PROG_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS GRIDLEDGERS ON YARNDYEINGPROGRAM_DESC.PROG_GRIDLEDGERID = GRIDLEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON YARNDYEINGPROGRAM_DESC.PROG_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON YARNDYEINGPROGRAM_DESC.PROG_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN YARNQUALITYMASTER ON YARNDYEINGPROGRAM_DESC.PROG_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON YARNDYEINGPROGRAM.PROG_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON YARNDYEINGPROGRAM.PROG_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON YARNDYEINGPROGRAM_DESC.PROG_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN YARNQUALITYMASTER AS FROMYARNQUALITYMASTER ON YARNDYEINGPROGRAM.PROG_FROMYARNQUALITYID = FROMYARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER AS FROMCOLORMASTER ON YARNDYEINGPROGRAM.PROG_FROMSHADEID = FROMCOLORMASTER.COLOR_id ", WHERECLAUSE & "  and YARNDYEINGPROGRAM.PROG_yearid=" & YearId & " ORDER BY dbo.YARNDYEINGPROGRAM.PROG_NO, dbo.YARNDYEINGPROGRAM_DESC.PROG_GRIDSRNO ")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal PROGNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJPROG As New YarnDyeingProgram
                OBJPROG.MdiParent = MDIMain
                OBJPROG.EDIT = editval
                OBJPROG.TEMPPROGNO = PROGNO
                OBJPROG.Show()
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
            showform(True, gridbill.GetFocusedRowCellValue("PROGNO"))
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PROGNO"))
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
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Program Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Program Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Program Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn PO Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class