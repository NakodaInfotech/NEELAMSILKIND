
Imports System.ComponentModel
Imports BL

Public Class DesignCardIssue

    Public EDIT As Boolean          'used for editing
    Public TEMPCARDNO As Integer          'used for editing
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMBDESIGNNO_Enter(sender As Object, e As EventArgs) Handles CMBDESIGNNO.Enter
        Try
            If CMBDESIGNNO.Text.Trim = "" Then FILLDESIGN(CMBDESIGNNO, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(sender As Object, e As CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGNNO, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMATCHING_Enter(sender As Object, e As EventArgs) Handles CMBMATCHING.Enter
        Try
            If CMBMATCHING.Text.Trim = "" Then FILLCOLOR(CMBMATCHING, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMATCHING_Validating(sender As Object, e As CancelEventArgs) Handles CMBMATCHING.Validating
        Try
            If CMBMATCHING.Text.Trim <> "" Then COLORVALIDATE(CMBMATCHING, e, Me, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS", TXTADD.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()

        TXTCARDNO.Clear()

        CMBNAME.Text = ""
        CARDDATE.Text = Now.Date
        tstxtbillno.Clear()

        CMBNAME.Text = ""
        TXTREMARKS.Clear()
        TXTWARPWASTAGE.Clear()
        TXTWEFTWASTAGE.Clear()

        LBLCLOSED.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False

        TXTTOTALCUT.Text = 0
        TXTTOTALMTRS.Text = 0.0

        TXTSRNO.Text = GRIDCARD.RowCount + 1
        CMBDESIGNNO.Text = ""
        CMBMATCHING.Text = ""
        TXTCUT.Clear()
        TXTWARPTL.Clear()
        TXTWEFTTL.Clear()
        TXTMTRS.Text = ""
        TXTSELVEDGE.Clear()
        TXTPICKS.Clear()
        TXTACTUALPICKS.Clear()
        TXTRATE.Clear()
        TXTBOBBINCHGS.Clear()
        TXTTOTALCHGS.Clear()
        TXTOTHERCHGS.Clear()
        TXTGRIDDESC.Clear()
        GRIDCARD.RowCount = 0

        GRIDDOUBLECLICK = False
        getmaxno()

    End Sub

    Sub TOTAL()
        Try
            TXTTOTALCUT.Text = 0
            TXTTOTALMTRS.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDCARD.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    TXTTOTALCUT.Text = Format(Val(TXTTOTALCUT.Text) + Val(ROW.Cells(GCUT.Index).EditedFormattedValue), "0")
                    TXTTOTALMTRS.Text = Format(Val(TXTTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub GETMAXNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CARD_no),0) + 1 ", " DESIGNCARDISSUE ", " AND CARD_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTCARDNO.Text = Val(DTTABLE.Rows(0).Item(0))
    End Sub

    Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Name")
            BLN = False
        End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, " Issue Closed")
            BLN = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, " Inward Done, Delete Inward First")
            BLN = False
        End If

        If GRIDCARD.RowCount = 0 Then
            EP.SetError(CMBNAME, "Fill Design Details")
            BLN = False
        End If

        For Each ROW As DataGridViewRow In GRIDCARD.Rows
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("DESIGNCARD_ID AS DESIGNCARDID", "", " DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGN_ID INNER JOIN COLORMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = COLORMASTER.COLOR_ID", " AND DESIGNMASTER.DESIGN_NO = '" & ROW.Cells(GDESIGNNO.Index).Value & "' AND COLORMASTER.COLOR_NAME = '" & ROW.Cells(GMATCHING.Index).Value & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count <= 0 Then
                ROW.DefaultCellStyle.BackColor = Color.LightGreen
                EP.SetError(CMBNAME, "Fill Design Card Master For " & ROW.Cells(GDESIGNNO.Index).Value & " AND " & ROW.Cells(GMATCHING.Index).Value)
                BLN = False
            End If
        Next

        Return BLN
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(CARDDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Val(TXTTOTALCUT.Text))
            alParaval.Add(Val(TXTTOTALMTRS.Text))
            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(Val(TXTWARPWASTAGE.Text.Trim))
            alParaval.Add(Val(TXTWEFTWASTAGE.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDSRNO As String = ""
            Dim DESIGNNO As String = ""
            Dim MATCHING As String = ""
            Dim CUT As String = ""
            Dim WARPTL As String = ""
            Dim WEFTTL As String = ""
            Dim MTRS As String = ""
            Dim SELVEDGE As String = ""
            Dim PICKS As String = ""
            Dim ACTUALPICKS As String = ""
            Dim RATE As String = ""
            Dim BOBBINCHGS As String = ""
            Dim TOTALCHGS As String = ""
            Dim OTHERCHGS As String = ""
            Dim GRIDDESC As String = ""
            Dim LOOMSMPRECD As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDCARD.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        DESIGNNO = row.Cells(GDESIGNNO.Index).Value.ToString
                        MATCHING = row.Cells(GMATCHING.Index).Value.ToString
                        CUT = Val(row.Cells(GCUT.Index).Value)
                        WARPTL = Val(row.Cells(GWARPTL.Index).Value)
                        WEFTTL = Val(row.Cells(GWEFTTL.Index).Value)
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        SELVEDGE = row.Cells(GSELVEDGE.Index).Value.ToString
                        PICKS = Val(row.Cells(GPICKS.Index).Value)
                        ACTUALPICKS = Val(row.Cells(GACTUALPICKS.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        BOBBINCHGS = Val(row.Cells(GBOBBINCHGS.Index).Value)
                        TOTALCHGS = Val(row.Cells(GTOTALCHGS.Index).Value)
                        OTHERCHGS = Val(row.Cells(GOTHERCHGS.Index).Value)
                        GRIDDESC = row.Cells(GGRIDDESC.Index).Value.ToString
                        LOOMSMPRECD = Convert.ToBoolean(row.Cells(GLOOMSMPRECD.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGNNO.Index).Value.ToString
                        MATCHING = MATCHING & "|" & row.Cells(GMATCHING.Index).Value.ToString
                        CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        WARPTL = WARPTL & "|" & Val(row.Cells(GWARPTL.Index).Value)
                        WEFTTL = WEFTTL & "|" & Val(row.Cells(GWEFTTL.Index).Value)
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        SELVEDGE = SELVEDGE & "|" & row.Cells(GSELVEDGE.Index).Value.ToString
                        PICKS = PICKS & "|" & Val(row.Cells(GPICKS.Index).Value)
                        ACTUALPICKS = ACTUALPICKS & "|" & Val(row.Cells(GACTUALPICKS.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        BOBBINCHGS = BOBBINCHGS & "|" & Val(row.Cells(GBOBBINCHGS.Index).Value)
                        TOTALCHGS = TOTALCHGS & "|" & Val(row.Cells(GTOTALCHGS.Index).Value)
                        OTHERCHGS = OTHERCHGS & "|" & Val(row.Cells(GOTHERCHGS.Index).Value)
                        GRIDDESC = GRIDDESC & "|" & row.Cells(GGRIDDESC.Index).Value.ToString
                        LOOMSMPRECD = LOOMSMPRECD & "|" & Convert.ToBoolean(row.Cells(GLOOMSMPRECD.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(DESIGNNO)
            alParaval.Add(MATCHING)
            alParaval.Add(CUT)
            alParaval.Add(WARPTL)
            alParaval.Add(WEFTTL)
            alParaval.Add(MTRS)
            alParaval.Add(SELVEDGE)
            alParaval.Add(PICKS)
            alParaval.Add(ACTUALPICKS)
            alParaval.Add(RATE)
            alParaval.Add(BOBBINCHGS)
            alParaval.Add(TOTALCHGS)
            alParaval.Add(OTHERCHGS)
            alParaval.Add(GRIDDESC)
            alParaval.Add(LOOMSMPRECD)

            Dim OBJCARD As New ClsDesignCardIssue()
            OBJCARD.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJCARD.SAVE()
                MsgBox("Details Added")

                TXTCARDNO.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPCARDNO)
                Dim IntResult As Integer = OBJCARD.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPCARDNO)

                EDIT = False
            End If

            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal YARNNO As Integer)
        Try
            Dim OBJPUR As New YarnDesign
            If MsgBox("Wish to Print Card Issue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "CARDISSUE"
                If MsgBox("Show Rate?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJPUR.SHOWRATE = 1 Else OBJPUR.SHOWRATE = 0
                OBJPUR.WHERECLAUSE = "{DESIGNCARDISSUE.CARD_NO}=" & Val(YARNNO) & " and {DESIGNCARDISSUE.CARD_YEARID}=" & YearId
                OBJPUR.Show()
            End If

            If MsgBox("Wish to Print Card Requirement Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            OBJPUR = New YarnDesign
            OBJPUR.MdiParent = MDIMain
            OBJPUR.WARPPER = Val(TXTWARPWASTAGE.Text.Trim)
            OBJPUR.WEFTPER = Val(TXTWEFTWASTAGE.Text.Trim)
            OBJPUR.FROMDATE = AccFrom.Date
            OBJPUR.TODATE = AccTo.Date
            OBJPUR.WHERECLAUSE = " {TEMPVIRTUALSTOCK.YEARID} = " & YearId
            OBJPUR.PERIOD = "DESIGN CARD YARN REQUIREMENT - ENTRY NO " & YARNNO
            OBJPUR.FRMSTRING = "CARDREQUIREMENT"

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPVIRTUALSTOCK WHERE YEARID = " & YearId, "", "")

            'GET WEFT DETAILS AND INSERT
            DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT DESIGNCARDISSUE.CARD_NO AS NO, DESIGNCARDISSUE.CARD_DATE AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, LEDGERS.Acc_cmpname AS NAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WEFTTL * DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT / DESIGNCARD.DESIGNCARD_WEFTTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWEFTCUT' AS ISSREC, DESIGNCARDISSUE_DESC.CARD_CMPID AS CMPID, DESIGNCARDISSUE_DESC.CARD_YEARID AS YEARID, 'DESIGNCARDISSUE' AS TYPE, DESIGNMASTER.DESIGN_NO AS DESIGNNO FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WEFTDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_id WHERE DESIGNCARDISSUE.CARD_NO = " & YARNNO & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY DESIGNCARDISSUE.CARD_NO, DESIGNCARDISSUE.CARD_DATE, YARNQUALITYMASTER.YARN_NAME, LEDGERS.Acc_cmpname, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CMPID, DESIGNCARDISSUE_DESC.CARD_YEARID, DESIGNCARDISSUE_DESC.CARD_CUT, DESIGN_NO  ", "", "")

            'GET WARP DETAILS AND INSERT
            DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT DESIGNCARDISSUE.CARD_NO AS NO, DESIGNCARDISSUE.CARD_DATE AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, LEDGERS.Acc_cmpname AS NAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC, DESIGNCARDISSUE_DESC.CARD_CMPID AS CMPID, DESIGNCARDISSUE_DESC.CARD_YEARID AS YEARID, 'DESIGNCARDISSUE' AS TYPE, DESIGNMASTER.DESIGN_NO AS DESIGNNO FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WARPDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WARPDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_id WHERE DESIGNCARDISSUE.CARD_NO = " & YARNNO & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY DESIGNCARDISSUE.CARD_NO, DESIGNCARDISSUE.CARD_DATE, YARNQUALITYMASTER.YARN_NAME, LEDGERS.Acc_cmpname, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CMPID, DESIGNCARDISSUE_DESC.CARD_YEARID, DESIGNCARDISSUE_DESC.CARD_CUT, DESIGN_NO ", "", "")

            'GET SELVEDGE DETAILS AND INSERT
            DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT DESIGNCARDISSUE.CARD_NO AS NO, DESIGNCARDISSUE.CARD_DATE AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, LEDGERS.Acc_cmpname AS NAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC, DESIGNCARDISSUE_DESC.CARD_CMPID AS CMPID, DESIGNCARDISSUE_DESC.CARD_YEARID AS YEARID, 'DESIGNCARDISSUE' AS TYPE, DESIGNMASTER.DESIGN_NO AS DESIGNNO FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_SELVEDGEDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_id WHERE DESIGNCARDISSUE.CARD_NO = " & YARNNO & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY DESIGNCARDISSUE.CARD_NO, DESIGNCARDISSUE.CARD_DATE, YARNQUALITYMASTER.YARN_NAME, LEDGERS.Acc_cmpname, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CMPID, DESIGNCARDISSUE_DESC.CARD_YEARID, DESIGNCARDISSUE_DESC.CARD_CUT, DESIGN_NO ", "", "")


            OBJPUR.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignCardIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                YarnRecd.Focus()
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignCardIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'YARN ISSUE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCARD As New ClsDesignCardIssue()
                Dim dttable As DataTable = OBJCARD.SELECTCARD(TEMPCARDNO, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTCARDNO.Text = TEMPCARDNO
                        CARDDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = dr("NAME")
                        TXTWARPWASTAGE.Text = Val(dr("WARPWASTAGE"))
                        TXTWEFTWASTAGE.Text = Val(dr("WEFTWASTAGE"))
                        TXTREMARKS.Text = dr("remarks")

                        GRIDCARD.Rows.Add(Val(dr("GRIDSRNO")), dr("DESIGNNO"), dr("MATCHING"), Val(dr("CUT")), Val(dr("WARPTL")), Val(dr("WEFTTL")), Val(dr("MTRS")), dr("SELVEDGE"), Val(dr("PICKS")), Val(dr("ACTUALPICKS")), Val(dr("RATE")), Val(dr("BOBBINCHGS")), Val(dr("TOTALCHGS")), Val(dr("OTHERCHGS")), dr("GRIDDESC"), dr("LOOMSMPRECD"))
                    Next

                    total()
                    GRIDCARD.FirstDisplayedScrollingRowIndex = GRIDCARD.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            FILLDESIGN(CMBDESIGNNO, "")
            FILLCOLOR(CMBMATCHING, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID(MATCHING As String, PICKS As Double)

        If GRIDDOUBLECLICK = False Then
            GRIDCARD.Rows.Add(Val(TXTSRNO.Text.Trim), CMBDESIGNNO.Text.Trim, MATCHING, Val(TXTCUT.Text.Trim), Val(TXTWARPTL.Text.Trim), Val(TXTWEFTTL.Text.Trim), Format(Val(TXTMTRS.Text.Trim), "0.00"), TXTSELVEDGE.Text.Trim, Val(PICKS), Val(PICKS), Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTBOBBINCHGS.Text.Trim), "0.00"), Format(Val(TXTTOTALCHGS.Text.Trim), "0.00"), Format(Val(TXTOTHERCHGS.Text.Trim), "0.00"), TXTGRIDDESC.Text.Trim, 0)
            GETSRNO(GRIDCARD)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDCARD.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDCARD.Item(GDESIGNNO.Index, TEMPROW).Value = CMBDESIGNNO.Text.Trim
            GRIDCARD.Item(GMATCHING.Index, TEMPROW).Value = MATCHING
            GRIDCARD.Item(GCUT.Index, TEMPROW).Value = Val(TXTCUT.Text.Trim)
            GRIDCARD.Item(GWARPTL.Index, TEMPROW).Value = Val(TXTWARPTL.Text.Trim)
            GRIDCARD.Item(GWEFTTL.Index, TEMPROW).Value = Val(TXTWEFTTL.Text.Trim)
            GRIDCARD.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDCARD.Item(GSELVEDGE.Index, TEMPROW).Value = TXTSELVEDGE.Text.Trim
            GRIDCARD.Item(GPICKS.Index, TEMPROW).Value = Val(TXTPICKS.Text.Trim)
            GRIDCARD.Item(GACTUALPICKS.Index, TEMPROW).Value = Val(TXTACTUALPICKS.Text.Trim)
            GRIDCARD.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDCARD.Item(GBOBBINCHGS.Index, TEMPROW).Value = Format(Val(TXTBOBBINCHGS.Text.Trim), "0.00")
            GRIDCARD.Item(GTOTALCHGS.Index, TEMPROW).Value = Format(Val(TXTTOTALCHGS.Text.Trim), "0.00")
            GRIDCARD.Item(GOTHERCHGS.Index, TEMPROW).Value = Format(Val(TXTOTHERCHGS.Text.Trim), "0.00")
            GRIDCARD.Item(GGRIDDESC.Index, TEMPROW).Value = TXTGRIDDESC.Text.Trim

            GRIDDOUBLECLICK = False
        End If

        TOTAL()
        GRIDCARD.FirstDisplayedScrollingRowIndex = GRIDCARD.RowCount - 1

    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCARD As New DesignCardIssueDetails
            OBJCARD.MdiParent = MDIMain
            OBJCARD.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDCARD.RowCount = 0
                TEMPCARDNO = Val(tstxtbillno.Text)
                If TEMPCARDNO > 0 Then
                    EDIT = True
                    DesignCardIssue_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDCARD.RowCount = 0
LINE1:
            TEMPCARDNO = Val(TXTCARDNO.Text) - 1
            If TEMPCARDNO > 0 Then
                EDIT = True
                DesignCardIssue_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDCARD.RowCount = 0 And TEMPCARDNO > 1 Then
                TXTCARDNO.Text = TEMPCARDNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPCARDNO = Val(TXTCARDNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTCARDNO.Text.Trim
            CLEAR()
            If Val(TXTCARDNO.Text) - 1 >= TEMPCARDNO Then
                EDIT = True
                DesignCardIssue_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDCARD.RowCount = 0 And TEMPCARDNO < MAXNO Then
                TXTCARDNO.Text = TEMPCARDNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCARD_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDCARD.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCARD.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDCARD.Rows.RemoveAt(GRIDCARD.CurrentRow.Index)
                getsrno(GRIDCARD)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPCARDNO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Design Card Issue?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJCARD As New ClsDesignCardIssue
                ALPARAVAL.Add(TEMPCARDNO)
                ALPARAVAL.Add(YearId)
                OBJCARD.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJCARD.DELETE()
                MsgBox("Entry Deleted Succesfully")
                CLEAR()
                EDIT = False
                CMBNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTREMARKS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTREMARKS.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CARDDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CARDDATE.GotFocus
        CARDDATE.SelectAll()
    End Sub

    Private Sub CARDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CARDDATE.Validating
        Try
            If CARDDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CARDDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCARD_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCARD.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub TXTWARPTL_Validated(sender As Object, e As EventArgs) Handles TXTWARPTL.Validated
        Try
            If Val(TXTCUT.Text.Trim) > 0 And Val(TXTWARPTL.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(TXTCUT.Text.Trim) * Val(TXTWARPTL.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDCARD.CurrentRow.Index >= 0 And GRIDCARD.Item(gsrno.Index, GRIDCARD.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDCARD.Item(gsrno.Index, GRIDCARD.CurrentRow.Index).Value.ToString
                CMBDESIGNNO.Text = GRIDCARD.Item(GDESIGNNO.Index, GRIDCARD.CurrentRow.Index).Value.ToString
                CMBMATCHING.Text = GRIDCARD.Item(GMATCHING.Index, GRIDCARD.CurrentRow.Index).Value.ToString
                TXTCUT.Text = Val(GRIDCARD.Item(GCUT.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTWARPTL.Text = Val(GRIDCARD.Item(GWARPTL.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTWEFTTL.Text = Val(GRIDCARD.Item(GWEFTTL.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTMTRS.Text = Val(GRIDCARD.Item(GMTRS.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTSELVEDGE.Text = GRIDCARD.Item(GSELVEDGE.Index, GRIDCARD.CurrentRow.Index).Value.ToString
                TXTPICKS.Text = Val(GRIDCARD.Item(GPICKS.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTACTUALPICKS.Text = Val(GRIDCARD.Item(GACTUALPICKS.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTRATE.Text = Val(GRIDCARD.Item(GRATE.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTBOBBINCHGS.Text = Val(GRIDCARD.Item(GBOBBINCHGS.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTTOTALCHGS.Text = Val(GRIDCARD.Item(GTOTALCHGS.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTOTHERCHGS.Text = Val(GRIDCARD.Item(GOTHERCHGS.Index, GRIDCARD.CurrentRow.Index).Value)
                TXTGRIDDESC.Text = GRIDCARD.Item(GGRIDDESC.Index, GRIDCARD.CurrentRow.Index).Value

                TEMPROW = GRIDCARD.CurrentRow.Index
                CMBDESIGNNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCUT.KeyPress, TXTWARPTL.KeyPress, TXTWEFTTL.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTWARPWASTAGE.KeyPress, TXTWEFTWASTAGE.KeyPress, TXTACTUALPICKS.KeyPress, TXTRATE.KeyPress, TXTBOBBINCHGS.KeyPress, TXTOTHERCHGS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGRIDDESC_Validating(sender As Object, e As CancelEventArgs) Handles TXTGRIDDESC.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" And Val(TXTCUT.Text.Trim) > 0 And Val(TXTWARPTL.Text.Trim) > 0 And Val(TXTWEFTTL.Text.Trim) > 0 Then

                'IF MATCHING IS NOT BLANK THEN ADD ONLY THAT MATCHING
                If CMBMATCHING.Text.Trim = "" And GRIDDOUBLECLICK = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT COLORMASTER.COLOR_name AS MATCHING FROM DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID INNER JOIN COLORMASTER ON DESIGNMASTER_COLOR.DESIGN_COLORID = COLORMASTER.COLOR_id WHERE DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND DESIGNMASTER.DESIGN_YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DT.Rows

                        'IF DESIGNCARD IS NOT FILLED FOR THAT DESIGN AND MATCHING THEN ALLOW TO ADD
                        Dim DTMATCH As DataTable = OBJCMN.Execute_Any_String("SELECT DESIGNCARD_ID, ISNULL(DESIGNCARD_PICKS,0) AS PICKS FROM DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD_DESIGNID = DESIGN_ID INNER JOIN COLORMASTER ON DESIGNCARD_MATCHINGID = COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND COLORMASTER.COLOR_NAME = '" & DTROW("MATCHING") & "' AND DESIGNCARD_YEARID = " & YearId, "", "")
                        If DTMATCH.Rows.Count > 0 Then
                            FILLGRID(DTROW("MATCHING"), Val(DTMATCH.Rows(0).Item("PICKS")))
                        Else
                            MsgBox("Design Card Not made for " & DTROW("MATCHING"))
                        End If

                    Next
                Else

                    'IF DESIGNCARD IS NOT FILLED FOR THAT DESIGN AND MATCHING THEN ALLOW TO ADD
                    Dim OBJCMN As New ClsCommon
                    Dim DTMATCH As DataTable = OBJCMN.Execute_Any_String("SELECT DESIGNCARD_ID, ISNULL(DESIGNCARD_PICKS,0) AS PICKS FROM DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD_DESIGNID = DESIGN_ID INNER JOIN COLORMASTER ON DESIGNCARD_MATCHINGID = COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND COLORMASTER.COLOR_NAME = '" & CMBMATCHING.Text.Trim & "' AND DESIGNCARD_YEARID = " & YearId, "", "")
                    If DTMATCH.Rows.Count > 0 Then
                        FILLGRID(CMBMATCHING.Text.Trim, Val(DTMATCH.Rows(0).Item("PICKS")))
                    Else
                        MsgBox("Design Card Not made for " & CMBMATCHING.Text.Trim)
                    End If


                End If


                CMBDESIGNNO.Text = ""
                CMBMATCHING.Text = ""
                TXTCUT.Clear()
                TXTWARPTL.Clear()
                TXTWEFTTL.Clear()
                TXTMTRS.Clear()
                TXTSELVEDGE.Clear()
                TXTPICKS.Clear()
                TXTACTUALPICKS.Clear()
                TXTRATE.Clear()
                TXTBOBBINCHGS.Clear()
                TXTTOTALCHGS.Clear()
                TXTOTHERCHGS.Clear()
                TXTGRIDDESC.Clear()
                TXTSRNO.Text = GRIDCARD.RowCount + 1
                CMBDESIGNNO.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCARD_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDCARD.CellContentClick

    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated, TXTBOBBINCHGS.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            TXTTOTALCHGS.Text = Format(Val(TXTRATE.Text.Trim) + Val(TXTBOBBINCHGS.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCARD_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDCARD.CellValidating
        Try
            Dim colNum As Integer = GRIDCARD.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPICKS.Index, GACTUALPICKS.Index
                    Dim dDebit As Integer
                    Dim bValid As Boolean = Integer.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCARD.CurrentCell.Value = Nothing Then GRIDCARD.CurrentCell.Value = "0"
                        GRIDCARD.CurrentCell.Value = Convert.ToInt16(GRIDCARD.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case GRATE.Index, GBOBBINCHGS.Index, GOTHERCHGS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCARD.CurrentCell.Value = Nothing Then GRIDCARD.CurrentCell.Value = "0.00"
                        GRIDCARD.CurrentCell.Value = Convert.ToDecimal(GRIDCARD.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class