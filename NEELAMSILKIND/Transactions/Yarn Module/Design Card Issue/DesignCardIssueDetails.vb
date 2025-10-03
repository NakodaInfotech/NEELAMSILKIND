
Imports BL

Public Class DesignCardIssueDetails

    Public EDIT As Boolean
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
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN ISSUE'")
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
            If CHKFROM.CheckState = CheckState.Checked Then WHERECLAUSE = " and DESIGNCARDISSUE.CARD_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DESIGNCARDISSUE.CARD_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search("DESIGNCARDISSUE.CARD_NO AS CARDNO, DESIGNCARDISSUE.CARD_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, DESIGNCARDISSUE.CARD_TOTALCUT AS TOTALCUT, DESIGNCARDISSUE.CARD_TOTALMTRS AS TOTALMTRS, DESIGNCARDISSUE.CARD_REMARKS AS REMARKS, DESIGNCARDISSUE_DESC.CARD_GRIDSRNO AS GRIDSRNO, DESIGNMASTER.DESIGN_NO AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS MATCHING, DESIGNCARDISSUE_DESC.CARD_CUT AS CUT, DESIGNCARDISSUE_DESC.CARD_WARPTL AS WARPTL, DESIGNCARDISSUE_DESC.CARD_WEFTTL AS WEFTTL, DESIGNCARDISSUE_DESC.CARD_MTRS AS MTRS, DESIGNCARDISSUE_DESC.CARD_SELVEDGE AS SELVEDGE, ISNULL(DESIGNCARDISSUE.CARD_WARPWASTAGE, 0) AS WARPWASTAGE, ISNULL(DESIGNCARDISSUE.CARD_WEFTWASTAGE, 0) AS WEFTWASTAGE, ISNULL(DESIGNCARDISSUE_DESC.CARD_PICKS, 0) AS PICKS, ISNULL(DESIGNCARDISSUE_DESC.CARD_ACTUALPICKS, 0) AS ACTUALPICKS, ISNULL(DESIGNCARDISSUE_DESC.CARD_RATE, 0) AS RATE, ISNULL(DESIGNCARDISSUE_DESC.CARD_BOBBINCHGS, 0) AS BOBBINCHGS, ISNULL(DESIGNCARDISSUE_DESC.CARD_TOTALCHGS, 0) AS TOTALCHGS, ISNULL(DESIGNCARDISSUE_DESC.CARD_OTHERCHGS, 0) AS OTHERCHGS, ISNULL(DESIGNCARDISSUE_DESC.CARD_GRIDDESC, '') AS GRIDDESC, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNCARDISSUE_DESC.CARD_LOOMSMPRECD,0) AS LOOMSMPRECD, ISNULL(DESIGNCARD.DESIGNCARD_REED, '') AS REED", "", "   CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER RIGHT OUTER JOIN DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNMASTER ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID = DESIGNCARD.DESIGNCARD_MATCHINGID ON ITEMMASTER.item_id = DESIGNMASTER.DESIGN_ITEMID ON CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid LEFT OUTER JOIN COLORMASTER ON DESIGNCARDISSUE_DESC.CARD_MATCHINGID = COLORMASTER.COLOR_id ", WHERECLAUSE & "  and DESIGNCARDISSUE.CARD_yearid=" & YearId & " ORDER BY CARDNO, GRIDSRNO ")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
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
                Dim OBJCARD As New DesignCardIssue
                OBJCARD.MdiParent = MDIMain
                OBJCARD.EDIT = editval
                OBJCARD.TEMPCARDNO = SRNO
                OBJCARD.Show()
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
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CARDNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CARDNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Design Issue Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Design Issue Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Design Issue Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Design Issue Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class