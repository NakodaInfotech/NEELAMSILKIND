
Imports BL

Public Class DesignCardDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub DesignCardDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DESIGN MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub DesignCardDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("CARDID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objClsCommon As New ClsCommonMaster
            Dim dttable As DataTable = objClsCommon.search(" DESIGNCARD.DESIGNCARD_ID AS CARDID, DESIGNMASTER.DESIGN_NO AS DESIGNNO, ITEMMASTER.ITEM_NAME AS ITEMNAME, CATEGORYMASTER.CATEGORY_NAME AS CATEGORY, COLORMASTER.COLOR_name AS MATCHING, DESIGNCARD.DESIGNCARD_WARPTL AS WARPTL, DESIGNCARD.DESIGNCARD_WEFTTL AS WEFTTL, DESIGNCARD.DESIGNCARD_REED AS REED, DESIGNCARD.DESIGNCARD_REEDSPACE AS REEDSPACE, DESIGNCARD.DESIGNCARD_PICKS AS PICKS, DESIGNCARD.DESIGNCARD_TOTALWT AS TOTALWT, DESIGNCARD.DESIGNCARD_TOTALSELENDS AS TOTALSELENDS, DESIGNCARD.DESIGNCARD_TOTALSELWT AS TOTALSELWT, DESIGNCARD.DESIGNCARD_TOTALWARPENDS AS TOTALWARPENDS, DESIGNCARD.DESIGNCARD_TOTALWARPWT AS TOTALWARPWT, DESIGNCARD.DESIGNCARD_TOTALWEFTPICKS AS TOTALWEFTPICK, DESIGNCARD.DESIGNCARD_TOTALWEFTWT AS TOTALWEFTWT ", "", " DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN COLORMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = COLORMASTER.COLOR_id INNER JOIN ITEMMASTER ON DESIGNMASTER.DESIGN_ITEMID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = CATEGORYMASTER.CATEGORY_ID  ", " and DESIGNCARD.DESIGNCARD_YEARID = " & YearId)
            GRIDBILLDETAILS.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal CARDID As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJDESIGN As New DesignCardMaster
            OBJDESIGN.EDIT = EDITVAL
            OBJDESIGN.MdiParent = MDIMain
            OBJDESIGN.TEMPCARDID = CARDID
            OBJDESIGN.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDEXPORT_Click(sender As Object, e As EventArgs) Handles CMDEXPORT.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Design Card Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Design Card Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Design Card Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            MsgBox("Design Card Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDADDNEW.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("CARDID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class