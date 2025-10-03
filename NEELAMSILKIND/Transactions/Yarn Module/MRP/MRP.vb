
Imports System.ComponentModel
Imports BL

Public Class MRP

    Dim IntResult As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public TEMPMRP As String

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GET_MAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(MRP_NO),0) + 1 ", " MRP ", " and MRP_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTMRPNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If


            Dim alParaval As New ArrayList

            alParaval.Add(TXTMRPNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(MRPDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Val(TXTISSUENO.Text.Trim))
            alParaval.Add(Format(Convert.ToDateTime(ISSUEDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Val(TXTWARPWASTAGE.Text.Trim))
            alParaval.Add(Val(TXTWEFTWASTAGE.Text.Trim))
            alParaval.Add(Val(LBLTOTALREQ.Text.Trim))
            alParaval.Add(Val(LBLTOTALWEAVERSTOCK.Text.Trim))
            alParaval.Add(Val(LBLTOTALPENDINGSTOCK.Text.Trim))
            alParaval.Add(Val(LBLTOTALGODOWNSTOCK.Text.Trim))
            alParaval.Add(Val(LBLTOTALORDEREDSTOCK.Text.Trim))
            alParaval.Add(Val(LBLTOTALNEWORDERSTOCK.Text.Trim))
            alParaval.Add(Val(TXTTOTALMATCHING.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim DESIGNNO As String = ""
            Dim MATCHING As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDDESIGN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If DESIGNNO = "" Then
                        DESIGNNO = row.Cells(GDESIGNNO.Index).Value.ToString
                        MATCHING = Val(row.Cells(GMATCHING.Index).Value)
                    Else
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGNNO.Index).Value.ToString
                        MATCHING = MATCHING & "|" & Val(row.Cells(GMATCHING.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(DESIGNNO)
            alParaval.Add(MATCHING)


            Dim SRNO As String = ""
            Dim YARNQUALITY As String = ""
            Dim SHADE As String = ""
            Dim TOTALREQ As String = ""
            Dim WEAVERSTOCK As String = ""
            Dim PENDINGSTOCK As String = ""
            Dim GODOWNSTOCK As String = ""
            Dim ORDEREDSTOCK As String = ""
            Dim NEWORDERSTOCK As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDMRP.Rows
                If row.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = Val(row.Cells(GSRNO.Index).Value)
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        SHADE = row.Cells(GSHADE.Index).Value.ToString
                        TOTALREQ = Val(row.Cells(GTOTALREQ.Index).Value)
                        WEAVERSTOCK = Val(row.Cells(GWEAVERSTOCK.Index).Value)
                        PENDINGSTOCK = Val(row.Cells(GPENDINGSTOCK.Index).Value)
                        GODOWNSTOCK = Val(row.Cells(GGODOWNSTOCK.Index).Value)
                        ORDEREDSTOCK = Val(row.Cells(GORDERSTOCK.Index).Value)
                        NEWORDERSTOCK = Val(row.Cells(GNEWORDERSTOCK.Index).Value)
                    Else
                        SRNO = SRNO & "|" & row.Cells(GSRNO.Index).Value
                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        SHADE = SHADE & "|" & row.Cells(GSHADE.Index).Value.ToString
                        TOTALREQ = TOTALREQ & "|" & Val(row.Cells(GTOTALREQ.Index).Value)
                        WEAVERSTOCK = WEAVERSTOCK & "|" & Val(row.Cells(GWEAVERSTOCK.Index).Value)
                        PENDINGSTOCK = PENDINGSTOCK & "|" & Val(row.Cells(GPENDINGSTOCK.Index).Value)
                        GODOWNSTOCK = GODOWNSTOCK & "|" & Val(row.Cells(GGODOWNSTOCK.Index).Value)
                        ORDEREDSTOCK = ORDEREDSTOCK & "|" & Val(row.Cells(GORDERSTOCK.Index).Value)
                        NEWORDERSTOCK = NEWORDERSTOCK & "|" & Val(row.Cells(GNEWORDERSTOCK.Index).Value)
                    End If
                End If



            Next

            alParaval.Add(SRNO)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(SHADE)
            alParaval.Add(TOTALREQ)
            alParaval.Add(WEAVERSTOCK)
            alParaval.Add(PENDINGSTOCK)
            alParaval.Add(GODOWNSTOCK)
            alParaval.Add(ORDEREDSTOCK)
            alParaval.Add(NEWORDERSTOCK)


            Dim OBJMRP As New ClsMRP()
            OBJMRP.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJMRP.SAVE()
                TXTMRPNO.Text = DTT.Rows(0).Item(0)
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPMRP)
                Dim IntResult As Integer = OBJMRP.UPDATE()
                MsgBox("Details Updated")

            End If

            EDIT = False
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True

        If Val(TXTISSUENO.Text.Trim) = 0 Then
            EP.SetError(TXTISSUENO, "Select Design Card Issue")
            bln = False
        End If

        If Val(TXTISSUENO.Text.Trim) <> Val(TXTMRPNO.Text.Trim) Then
            EP.SetError(TXTMRPNO, "Issue No / MRP No cannot be different")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, " Unable to Save, Entry Locked")
            bln = False
        End If


        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Jobber Name")
            bln = False
        End If

        If GRIDMRP.RowCount = 0 Then
            EP.SetError(CMBNAME, " Please Design Card Issue")
            bln = False
        End If

        If TXTMRPNO.Text <> "" And EDIT = False Then
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search(" ISNULL(MRP.MRP_NO, '') AS MRPNO ", "", " MRP ", "  AND MRP_NO = " & Val(TXTMRPNO.Text.Trim) & " AND MRP.MRP_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                EP.SetError(TXTMRPNO, "MRP No Already Exist")
                bln = False
            End If
        End If

        If MRPDATE.Text = "__/__/____" Then
            EP.SetError(MRPDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(MRPDATE.Text) Then
                EP.SetError(MRPDATE, "Date Not In Accounting Year")
                bln = False
            End If
        End If
        Return bln

    End Function

    Sub CLEAR()

        EP.Clear()
        TXTMRPNO.Clear()
        TXTMRPNO.ReadOnly = False
        MRPDATE.Text = Now.Date

        lbllocked.Visible = False
        PBlock.Visible = False

        CMBNAME.Text = ""
        TXTISSUENO.Clear()
        ISSUEDATE.Clear()
        TXTWARPWASTAGE.Clear()
        TXTWEFTWASTAGE.Clear()
        LBLTOTALREQ.Text = 0
        LBLTOTALWEAVERSTOCK.Text = 0
        LBLTOTALPENDINGSTOCK.Text = 0
        LBLTOTALGODOWNSTOCK.Text = 0
        LBLTOTALORDEREDSTOCK.Text = 0
        LBLTOTALNEWORDERSTOCK.Text = 0

        TXTTOTALMATCHING.Clear()
        txtremarks.Clear()

        GRIDDESIGN.RowCount = 0
        GRIDMRP.RowCount = 0
        GET_MAX_NO()
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If MsgBox("Wish To Delete MRP?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                'DONE BY GULKIT
                'BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPMRP)
                ALPARAVAL.Add(YearId)


                Dim OBJPRO As New ClsMRP
                OBJPRO.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJPRO.DELETE
                MsgBox("Shrinkage Deleted Sucessfully")

                CLEAR()
                EDIT = False
                CMBNAME.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " And GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MRP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'YARN ISSUE'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJMRP As New ClsMRP()
                OBJMRP.alParaval.Add(TEMPMRP)
                OBJMRP.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJMRP.SELECTMRP()
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        TXTMRPNO.Text = TEMPMRP
                        TXTMRPNO.ReadOnly = True
                        MRPDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        TXTISSUENO.Text = Val(dr("ISSUENO"))
                        ISSUEDATE.Text = Format(Convert.ToDateTime(dr("ISSUEDATE")), "dd/MM/yyyy")
                        TXTWARPWASTAGE.Text = Val(dr("WARPWASTAGE"))
                        TXTWEFTWASTAGE.Text = Val(dr("WEFTWASTAGE"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)
                        GRIDMRP.Rows.Add(Val(dr("SRNO")), dr("YARNQUALITY"), dr("SHADE"), Format(Val(dr("TOTALREQ")), "0.00"), Format(Val(dr("WEAVERSTOCK")), "0.00"), Format(Val(dr("PENDINGSTOCK")), "0.00"), Format(Val(dr("GODOWNSTOCK")), "0.00"), Format(Val(dr("ORDEREDSTOCK")), "0.00"), Format(Val(dr("NEWORDERSTOCK")), "0.00"), 0, dr("PODONE"))

                        If Convert.ToBoolean(dr("PODONE")) = True Then
                            GRIDMRP.Rows(GRIDMRP.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            GRIDMRP.Rows(GRIDMRP.RowCount - 1).Cells(GCHK.Index).ReadOnly = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(MRP_MATCHING,0) AS MATCHING", "", " MRP_DESIGNDESC INNER JOIN DESIGNMASTER ON MRP_DESIGNID = DESIGNMASTER.DESIGN_ID ", " AND MRP_NO = " & TEMPMRP & " AND MRP_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            GRIDDESIGN.Rows.Add(DTR("DESIGNNO"), Val(DTR("MATCHING")))
                        Next
                    End If


                    TOTAL()
                    GRIDMRP.FirstDisplayedScrollingRowIndex = GRIDMRP.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
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

    Sub TOTAL()
        Try
            LBLTOTALREQ.Text = 0.0
            LBLTOTALWEAVERSTOCK.Text = 0.0
            LBLTOTALPENDINGSTOCK.Text = 0.0
            LBLTOTALGODOWNSTOCK.Text = 0.0
            LBLTOTALORDEREDSTOCK.Text = 0.0
            LBLTOTALNEWORDERSTOCK.Text = 0.0
            TXTTOTALMATCHING.Text = 0.0
            TXTTOTALWEAVERSTOCK.Text = 0.0


            For Each row As DataGridViewRow In GRIDMRP.Rows
                LBLTOTALREQ.Text = Format(Val(LBLTOTALREQ.Text) + Val(row.Cells(GTOTALREQ.Index).EditedFormattedValue), "0.00")
                LBLTOTALWEAVERSTOCK.Text = Format(Val(LBLTOTALWEAVERSTOCK.Text) + Val(row.Cells(GWEAVERSTOCK.Index).EditedFormattedValue), "0.00")
                LBLTOTALPENDINGSTOCK.Text = Format(Val(LBLTOTALPENDINGSTOCK.Text) + Val(row.Cells(GPENDINGSTOCK.Index).EditedFormattedValue), "0.00")
                LBLTOTALGODOWNSTOCK.Text = Format(Val(LBLTOTALGODOWNSTOCK.Text) + Val(row.Cells(GGODOWNSTOCK.Index).EditedFormattedValue), "0.00")
                LBLTOTALORDEREDSTOCK.Text = Format(Val(LBLTOTALORDEREDSTOCK.Text) + Val(row.Cells(GORDERSTOCK.Index).EditedFormattedValue), "0.00")
                LBLTOTALNEWORDERSTOCK.Text = Format(Val(LBLTOTALNEWORDERSTOCK.Text) + Val(row.Cells(GNEWORDERSTOCK.Index).EditedFormattedValue), "0.00")
            Next


            If GRIDDESIGN.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDDESIGN.Rows
                    TXTTOTALMATCHING.Text = Format(Val(TXTTOTALMATCHING.Text) + Val(row.Cells(GMATCHING.Index).EditedFormattedValue), "0")
                Next
            End If

            For Each row As DataGridViewRow In GRIDWEAVER.Rows
                TXTTOTALWEAVERSTOCK.Text = Format(Val(TXTTOTALWEAVERSTOCK.Text) + Val(row.Cells(WWEAVERSTOCK.Index).EditedFormattedValue), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRIVIOUS.Click
        Try
            GRIDMRP.RowCount = 0
LINE1:
            TEMPMRP = Val(TXTMRPNO.Text) - 1
            If TEMPMRP > 0 Then
                EDIT = True
                MRP_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDMRP.RowCount = 0 And TEMPMRP > 1 Then
                TXTMRPNO.Text = TEMPMRP
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MRP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDMRP.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.NumPad1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.NumPad2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJMRP As New MRPDetails
            OBJMRP.MdiParent = MDIMain
            OBJMRP.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDMRP.RowCount = 0
LINE1:
            TEMPMRP = Val(TXTMRPNO.Text) + 1
            GET_MAX_NO()
            Dim MAXNO As Integer = TXTMRPNO.Text.Trim
            CLEAR()
            If Val(TXTMRPNO.Text) - 1 >= TEMPMRP Then
                EDIT = True
                MRP_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDMRP.RowCount = 0 And TEMPMRP < MAXNO Then
                TXTMRPNO.Text = TEMPMRP
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTISSUE_Click(sender As Object, e As EventArgs) Handles CMDSELECTISSUE.Click
        Try

            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Select Name First", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If


            Dim OBJMRP As New SelectDesignCardIssue
            OBJMRP.JOBBERNAME = CMBNAME.Text.Trim
            OBJMRP.FRMSTRING = "MRP"
            OBJMRP.ShowDialog()
            Dim DTTABLE As DataTable = OBJMRP.DT
            If DTTABLE.Rows.Count > 0 Then
                FETCHISSUEDATA(DTTABLE.Rows(0).Item("ISSUENO"), 0, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FETCHISSUEDATA(ISSUENO As Integer, WARPWAS As Double, WEFTWAS As Double)
        Try

            GRIDMRP.RowCount = 0

            'FETCH ALL RELATED DATA FROM DESIGNCARDISSUE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DESIGNCARDISSUE.CARD_NO AS ISSUENO, DESIGNCARDISSUE.CARD_DATE AS ISSUEDATE, ISNULL(DESIGNCARDISSUE.CARD_WARPWASTAGE, 0) AS WARPWASTAGE, ISNULL(DESIGNCARDISSUE.CARD_WEFTWASTAGE,0) AS WEFTWASTAGE, DESIGNMASTER.DESIGN_NO AS DESIGNNO, COUNT(COLORMASTER.COLOR_name) AS MATCHING ", "", " DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN DESIGNMASTER ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON DESIGNCARDISSUE_DESC.CARD_MATCHINGID = COLORMASTER.COLOR_id ", " AND DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY DESIGNCARDISSUE.CARD_NO, DESIGNCARDISSUE.CARD_DATE, ISNULL(DESIGNCARDISSUE.CARD_WARPWASTAGE, 0), ISNULL(DESIGNCARDISSUE.CARD_WEFTWASTAGE,0) , DESIGNMASTER.DESIGN_NO ")
            For Each DTROW As DataRow In DT.Rows
                TXTISSUENO.Text = Val(DTROW("ISSUENO"))
                ISSUEDATE.Text = Format(Convert.ToDateTime(DTROW("ISSUEDATE")).Date, "dd/MM/yyyy")
                If WARPWAS = 0 Then TXTWARPWASTAGE.Text = Val(DTROW("WARPWASTAGE"))
                If WEFTWAS = 0 Then TXTWEFTWASTAGE.Text = Val(DTROW("WEFTWASTAGE"))

                GRIDDESIGN.Rows.Add(DTROW("DESIGNNO"), Val(DTROW("MATCHING")))
            Next


            Dim TOTALREQ As Double = 0.0
            Dim WEAVERSTOCK As Double = 0.0
            Dim TEMPWEFTWASTAGE As Double = 0
            Dim TEMPWARPWASTAGE As Double = 0
            Dim PENDINGSTOCK As Double = 0.0
            Dim GODOWNSTOCK As Double = 0.0
            Dim ORDEREDSTOCK As Double = 0.0
            Dim NEWORDERSTOCK As Double = 0.0

            Dim DTTEMP As New DataTable

            DT = OBJCMN.search(" T.YARNQUALITY, T.COLOR, ISNULL(SUM(T.RECDWT),0) AS RECDWT ", "", " (SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WEFTTL * DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT / DESIGNCARD.DESIGNCARD_WEFTTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWEFTCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WEFTDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT UNION ALL  SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WARPDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WARPDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT UNION ALL SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_SELVEDGEDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT) AS T", " GROUP BY T.YARNQUALITY, T.COLOR ORDER BY T.YARNQUALITY")
            For Each DR As DataRow In DT.Rows


                TOTALREQ = Val(DR("RECDWT"))
                'IF WARP/WEFT WASTAGE IS PRESENT THEN ADD THAT IN THE TOTALREQ WT COL
                If Val(TXTWARPWASTAGE.Text.Trim) > 0 Then
                    DTTEMP = OBJCMN.search(" ISNULL(SUM(T.RECDWT),0) AS WT ", "", " (SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WEFTTL * DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT / DESIGNCARD.DESIGNCARD_WEFTTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWEFTCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WEFTDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT UNION ALL  SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WARPDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WARPDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT UNION ALL SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_SELVEDGEDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT) AS T", " AND T.ISSREC = 'VIRTUALWARPCUT' AND T.YARNQUALITY = '" & DR("YARNQUALITY") & "' AND T.COLOR = '" & DR("COLOR") & "'")
                    If DTTEMP.Rows.Count > 0 Then TOTALREQ = Format(Val(TOTALREQ) + Val(Val(DTTEMP.Rows(0).Item("WT")) * Val(TXTWARPWASTAGE.Text.Trim) / 100), "0.00")
                End If
                If Val(TXTWEFTWASTAGE.Text.Trim) > 0 Then
                    DTTEMP = OBJCMN.search(" ISNULL(SUM(T.RECDWT),0) AS WT ", "", " (SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WEFTTL * DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT / DESIGNCARD.DESIGNCARD_WEFTTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWEFTCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WEFTDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT UNION ALL  SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_WARPDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WARPDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT UNION ALL SELECT YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ROUND(DESIGNCARDISSUE_DESC.CARD_WARPTL * DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT / DESIGNCARD.DESIGNCARD_WARPTL, 2))*DESIGNCARDISSUE_DESC.CARD_CUT AS RECDWT, 'VIRTUALWARPCUT' AS ISSREC FROM DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN LEDGERS ON DESIGNCARDISSUE.CARD_LEDGERID = LEDGERS.Acc_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID= DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN DESIGNCARD_SELVEDGEDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id WHERE DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, ''), DESIGNCARDISSUE_DESC.CARD_CUT) AS T", " AND T.ISSREC = 'VIRTUALWEFTCUT' AND T.YARNQUALITY = '" & DR("YARNQUALITY") & "' AND T.COLOR = '" & DR("COLOR") & "'")
                    If DTTEMP.Rows.Count > 0 Then TOTALREQ = Format(Val(TOTALREQ) + Val(Val(DTTEMP.Rows(0).Item("WT")) * Val(TXTWEFTWASTAGE.Text.Trim) / 100), "0.00")
                End If



                '************* WEVAERSTOCK **************
                WEAVERSTOCK = 0
                DTTEMP = OBJCMN.Execute_Any_String("DELETE FROM TEMPVIRTUALSTOCK WHERE YEARID = " & YearId, "", "")
                DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT * FROM JOBBERVIRTUALSTOCKREGISTER WHERE NAME = '" & CMBNAME.Text.Trim & "' AND YARNQUALITY = '" & DR("YARNQUALITY") & "' AND COLOR = '" & DR("COLOR") & "' AND YEARID = " & YearId, "", "")

                'Now WE WILL ADD THE WASTAGEENTRY OF THE WEAVER AFTER THE DATE WHEN WE HAVE DONE THE YARN WASTAGE ENTRY
                If Val(TXTWARPWASTAGE.Text.Trim) > 0 And Val(TXTWEFTWASTAGE.Text.Trim) > 0 Then
                    Dim LASTDATE As Date = AccFrom.Date
                    DTTEMP = OBJCMN.Execute_Any_String(" Select MAX(YWASJOBBER_DATE) As [DATE] FROM YARNWASTAGEJOBBER INNER JOIN LEDGERS On YARNWASTAGEJOBBER.YWASJOBBER_LEDGERID = Acc_id WHERE LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND YARNWASTAGEJOBBER.YWASJOBBER_YEARID = " & YearId, "", "")
                    If DTTEMP.Rows.Count > 0 AndAlso IsDBNull(DTTEMP.Rows(0).Item("DATE")) = False Then LASTDATE = Convert.ToDateTime(DTTEMP.Rows(0).Item("DATE")).Date

                    Dim DTDESIGN As DataTable = OBJCMN.Execute_Any_String(" SELECT ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_NAME,'') AS MATCHING, SUM(GREY_MTRS) AS RECDMTRS FROM GREYRECDKNITTING INNER JOIN GREYRECDKNITTING_DESC ON GREYRECDKNITTING.GREY_NO = GREYRECDKNITTING_DESC.GREY_NO AND GREYRECDKNITTING.GREY_YEARID = GREYRECDKNITTING_DESC.GREY_YEARID INNER JOIN LEDGERS ON GREY_LEDGERID = ACC_ID INNER JOIN DESIGNMASTER ON DESIGN_ID = GREY_DESIGNID INNER JOIN COLORMASTER ON GREYRECDKNITTING_DESC.GREY_COLORID = COLOR_ID WHERE GREYRECDKNITTING.GREY_YEARID = " & YearId & " AND GREYRECDKNITTING.GREY_DATE >='" & Format(LASTDATE.Date, "MM/dd/yyyy") & "' AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' GROUP BY ISNULL(DESIGNMASTER.DESIGN_NO,''), ISNULL(COLORMASTER.COLOR_name,'') ", "", "")
                    For Each DTROWDESIGN As DataRow In DTDESIGN.Rows

                        'GET WEFT DETAILS AND INSERT
                        DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, GETDATE() AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & CMBNAME.Text.Trim & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((" & Val(DTROWDESIGN("RECDMTRS")) & " * DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT / DESIGNCARD.DESIGNCARD_WEFTTL)* " & Val(TXTWEFTWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WEFTCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_WEFTDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & " AND YARNQUALITYMASTER.YARN_NAME = '" & DR("YARNQUALITY") & "' AND COLORMASTER.COLOR_NAME = '" & DR("COLOR") & "' GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                        'GET WARP DETAILS AND INSERT
                        DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, GETDATE() AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & CMBNAME.Text.Trim & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((((" & Val(DTROWDESIGN("RECDMTRS")) & " *DESIGNCARD.DESIGNCARD_WARPTL)/DESIGNCARD.DESIGNCARD_WEFTTL) * DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT / DESIGNCARD.DESIGNCARD_WARPTL)* " & Val(TXTWARPWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WARPCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_WARPDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WARPDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID  WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & " AND YARNQUALITYMASTER.YARN_NAME = '" & DR("YARNQUALITY") & "' AND COLORMASTER.COLOR_NAME = '" & DR("COLOR") & "' GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                        'GET SELVEDGE DETAILS AND INSERT
                        DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, GETDATE() AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & CMBNAME.Text.Trim & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((((" & Val(DTROWDESIGN("RECDMTRS")) & " *DESIGNCARD.DESIGNCARD_WARPTL)/DESIGNCARD.DESIGNCARD_WEFTTL) * DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT / DESIGNCARD.DESIGNCARD_WARPTL)* " & Val(TXTWARPWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WARPCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_SELVEDGEDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & " AND YARNQUALITYMASTER.YARN_NAME = '" & DR("YARNQUALITY") & "' AND COLORMASTER.COLOR_NAME = '" & DR("COLOR") & "' GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                    Next
                End If
                If Val(TXTWARPWASTAGE.Text.Trim) > 0 Then
                    DTTEMP = OBJCMN.search(" ISNULL(SUM(RECDWT),0) AS WARPWT ", "", " TEMPVIRTUALSTOCK ", " AND ISSREC = 'VIRTUALWARPCUT' AND YEARID = " & YearId)
                    If DTTEMP.Rows.Count > 0 Then TEMPWARPWASTAGE = Format(Val(DTTEMP.Rows(0).Item("WARPWT")) * Val(TXTWARPWASTAGE.Text.Trim) / 100, "0.00")
                End If

                If Val(TXTWEFTWASTAGE.Text.Trim) > 0 Then
                    DTTEMP = OBJCMN.search(" ISNULL(SUM(RECDWT),0) AS WEFTWT ", "", " TEMPVIRTUALSTOCK ", " AND ISSREC = 'VIRTUALWEFTCUT' AND YEARID = " & YearId)
                    If DTTEMP.Rows.Count > 0 Then TEMPWEFTWASTAGE = Format(Val(DTTEMP.Rows(0).Item("WEFTWT")) * Val(TXTWEFTWASTAGE.Text.Trim) / 100, "0.00")
                End If
                DTTEMP = OBJCMN.search(" ISNULL(SUM(WT) - SUM(RECDWT),0) As WT ", "", " TEMPVIRTUALSTOCK ", " AND YEARID = " & YearId)
                If DTTEMP.Rows.Count > 0 Then WEAVERSTOCK = Format(Val(DTTEMP.Rows(0).Item("WT")) - Val(TEMPWARPWASTAGE) - Val(TEMPWEFTWASTAGE), "0.00")
                '*************** END OF WEAVERVIRTUALSTOCK *****************



                '******** PENDING YARN DYEING PROGRAM AND PENDING YARN PURCHASE ORDER *************
                PENDINGSTOCK = 0
                DTTEMP = OBJCMN.search(" SUM(T.BALANCEWT) As BALANCEWT ", "", "(Select ROUND(ISNULL(SUM(PROG_WT - PROG_RECDWT),0),2) As BALANCEWT FROM ALLYARNDYEINGPROGRAM_DESC INNER JOIN YARNQUALITYMASTER On PROG_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER On PROG_SHADEID = COLOR_ID INNER JOIN LEDGERS On PROG_GRIDLEDGERID = LEDGERS.ACC_ID WHERE ALLYARNDYEINGPROGRAM_DESC.PROG_CLOSED = 0 And ROUND(PROG_WT - PROG_RECDWT,2) >0 And YARNQUALITYMASTER.YARN_NAME = '" & DR("YARNQUALITY") & "' AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & DR("COLOR") & "' AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ALLYARNDYEINGPROGRAM_DESC.PROG_YEARID = " & YearId & " UNION ALL SELECT ROUND(ISNULL(SUM(YPO_WT - YPO_RECDWT),0),2) AS BALANCEWT FROM ALLYARNPURCHASEORDER_DESC INNER JOIN YARNQUALITYMASTER ON YPO_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON YPO_SHADEID = COLOR_ID INNER JOIN LEDGERS ON YPO_GRIDLEDGERID = LEDGERS.ACC_ID WHERE ALLYARNPURCHASEORDER_DESC.YPO_CLOSED = 0 AND ROUND(YPO_WT - YPO_RECDWT,2) >0 AND YARNQUALITYMASTER.YARN_NAME = '" & DR("YARNQUALITY") & "' AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & DR("COLOR") & "' AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ALLYARNPURCHASEORDER_DESC.YPO_YEARID = " & YearId & ") AS T ", "")
                If DTTEMP.Rows.Count > 0 Then PENDINGSTOCK = Format(Val(DTTEMP.Rows(0).Item("BALANCEWT")), "0.00")



                '******** GODOW STOCK *************
                GODOWNSTOCK = 0
                DTTEMP = OBJCMN.search(" ISNULL(SUM(WT),0) AS WT ", "", "YARNSTOCKVIEW", " AND YARNQUALITY = '" & DR("YARNQUALITY") & "' AND COLOR = '" & DR("COLOR") & "' AND YEARID = " & YearId)
                If DTTEMP.Rows.Count > 0 Then GODOWNSTOCK = Format(Val(DTTEMP.Rows(0).Item("WT")), "0.00")


                '******** PENDING YARN DYEING PROGRAM AND PENDING YARN PURCHASE ORDER WHERE DELIVERYAT IS BLANK *************
                ORDEREDSTOCK = 0
                DTTEMP = OBJCMN.search(" SUM(T.BALANCEWT) AS BALANCEWT ", "", "(SELECT ROUND(ISNULL(SUM(PROG_WT - PROG_RECDWT),0),2) AS BALANCEWT FROM ALLYARNDYEINGPROGRAM_DESC INNER JOIN YARNQUALITYMASTER ON PROG_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON PROG_SHADEID = COLOR_ID WHERE ALLYARNDYEINGPROGRAM_DESC.PROG_CLOSED = 0 AND ROUND(PROG_WT - PROG_RECDWT,2) >0 AND ISNULL(ALLYARNDYEINGPROGRAM_DESC.PROG_GRIDLEDGERID,0) = 0 AND YARNQUALITYMASTER.YARN_NAME = '" & DR("YARNQUALITY") & "' AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & DR("COLOR") & "' AND ALLYARNDYEINGPROGRAM_DESC.PROG_YEARID = " & YearId & " UNION ALL SELECT ROUND(ISNULL(SUM(YPO_WT - YPO_RECDWT),0),2) AS BALANCEWT FROM ALLYARNPURCHASEORDER_DESC INNER JOIN YARNQUALITYMASTER ON YPO_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON YPO_SHADEID = COLOR_ID WHERE ALLYARNPURCHASEORDER_DESC.YPO_CLOSED = 0 AND ROUND(YPO_WT - YPO_RECDWT,2) >0 AND ISNULL(ALLYARNPURCHASEORDER_DESC.YPO_GRIDLEDGERID,0) = 0 AND YARNQUALITYMASTER.YARN_NAME = '" & DR("YARNQUALITY") & "' AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & DR("COLOR") & "' AND ALLYARNPURCHASEORDER_DESC.YPO_YEARID = " & YearId & ") AS T ", "")
                If DTTEMP.Rows.Count > 0 Then ORDEREDSTOCK = Format(Val(DTTEMP.Rows(0).Item("BALANCEWT")), "0.00")

                NEWORDERSTOCK = Val(TOTALREQ) - Val(WEAVERSTOCK) - Val(PENDINGSTOCK) - Val(GODOWNSTOCK) - Val(ORDEREDSTOCK)

                GRIDMRP.Rows.Add(0, DR("YARNQUALITY"), DR("COLOR"), Format(Val(TOTALREQ), "0.00"), Format(Val(WEAVERSTOCK), "0.00"), Format(Val(PENDINGSTOCK), "0.00"), Format(Val(GODOWNSTOCK), "0.00"), Format(Val(ORDEREDSTOCK), "0.00"), Format(Val(NEWORDERSTOCK), "0.00"), 0, 0)
            Next

            GETSRNO(GRIDMRP)
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCALC_Click(sender As Object, e As EventArgs) Handles CMDCALC.Click
        If Val(TXTISSUENO.Text.Trim) > 0 Then FETCHISSUEDATA(Val(TXTISSUENO.Text.Trim), Val(TXTWARPWASTAGE.Text.Trim), Val(TXTWEFTWASTAGE.Text.Trim))
    End Sub

    Private Sub CMDSHOW_Click(sender As Object, e As EventArgs) Handles CMDSHOW.Click
        Try
            GRIDWEAVER.RowCount = 0
            TXTTEMPYARNQUALITY.Clear()
            TXTTEMPCOLOR.Clear()
            TXTTOTALWEAVERSTOCK.Clear()


            TXTTEMPYARNQUALITY.Text = GRIDMRP.CurrentRow.Cells(GYARNQUALITY.Index).Value
            TXTTEMPCOLOR.Text = GRIDMRP.CurrentRow.Cells(GSHADE.Index).Value


            Dim OBJCMN As New ClsCommon
            Dim DTTEMP As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPVIRTUALSTOCK WHERE YEARID = " & YearId, "", "")
            DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT * FROM JOBBERVIRTUALSTOCKREGISTER WHERE NAME <> '" & CMBNAME.Text.Trim & "' AND YARNQUALITY = '" & TXTTEMPYARNQUALITY.Text.Trim & "' AND COLOR = '" & TXTTEMPCOLOR.Text.Trim & "' AND YEARID = " & YearId, "", "")

            'Now WE WILL ADD THE WASTAGEENTRY OF THE WEAVER AFTER THE DATE WHEN WE HAVE DONE THE YARN WASTAGE ENTRY
            If Val(TXTWARPWASTAGE.Text.Trim) > 0 And Val(TXTWEFTWASTAGE.Text.Trim) > 0 Then

                Dim DTNAME As DataTable = OBJCMN.Execute_Any_String(" SELECT DISTINCT LEDGERS.ACC_CMPNAME AS NAME FROM GREYRECDKNITTING INNER JOIN LEDGERS ON GREY_LEDGERID = LEDGERS.ACC_ID WHERE LEDGERS.ACC_CMPNAME <> '" & CMBNAME.Text.Trim & "' AND GREYRECDKNITTING.GREY_YEARID = " & YearId, "", "")
                For Each DTROWNAME As DataRow In DTNAME.Rows

                    Dim LASTDATE As Date = AccFrom.Date
                    DTTEMP = OBJCMN.Execute_Any_String(" Select MAX(YWASJOBBER_DATE) As [DATE] FROM YARNWASTAGEJOBBER INNER JOIN LEDGERS On YARNWASTAGEJOBBER.YWASJOBBER_LEDGERID = Acc_id WHERE LEDGERS.ACC_CMPNAME = '" & DTROWNAME("NAME") & "' AND YARNWASTAGEJOBBER.YWASJOBBER_YEARID = " & YearId, "", "")
                    If DTTEMP.Rows.Count > 0 AndAlso IsDBNull(DTTEMP.Rows(0).Item("DATE")) = False Then LASTDATE = Convert.ToDateTime(DTTEMP.Rows(0).Item("DATE")).Date

                    Dim DTDESIGN As DataTable = OBJCMN.Execute_Any_String(" SELECT ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_NAME,'') AS MATCHING, SUM(GREY_MTRS) AS RECDMTRS FROM GREYRECDKNITTING INNER JOIN GREYRECDKNITTING_DESC ON GREYRECDKNITTING.GREY_NO = GREYRECDKNITTING_DESC.GREY_NO AND GREYRECDKNITTING.GREY_YEARID = GREYRECDKNITTING_DESC.GREY_YEARID INNER JOIN LEDGERS ON GREY_LEDGERID = ACC_ID INNER JOIN DESIGNMASTER ON DESIGN_ID = GREY_DESIGNID INNER JOIN COLORMASTER ON GREYRECDKNITTING_DESC.GREY_COLORID = COLOR_ID WHERE GREYRECDKNITTING.GREY_YEARID = " & YearId & " AND GREYRECDKNITTING.GREY_DATE >='" & Format(LASTDATE.Date, "MM/dd/yyyy") & "' AND LEDGERS.ACC_CMPNAME = '" & DTROWNAME("NAME") & "' GROUP BY ISNULL(DESIGNMASTER.DESIGN_NO,''), ISNULL(COLORMASTER.COLOR_name,'') ", "", "")
                    For Each DTROWDESIGN As DataRow In DTDESIGN.Rows

                        'GET WEFT DETAILS AND INSERT
                        DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, GETDATE() AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & DTROWNAME("NAME") & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((" & Val(DTROWDESIGN("RECDMTRS")) & " * DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT / DESIGNCARD.DESIGNCARD_WEFTTL)* " & Val(TXTWEFTWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WEFTCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_WEFTDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & " AND YARNQUALITYMASTER.YARN_NAME = '" & TXTTEMPYARNQUALITY.Text.Trim & "' AND COLORMASTER.COLOR_NAME = '" & TXTTEMPCOLOR.Text.Trim & "' GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                        'GET WARP DETAILS AND INSERT
                        DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, GETDATE() AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & DTROWNAME("NAME") & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((((" & Val(DTROWDESIGN("RECDMTRS")) & " *DESIGNCARD.DESIGNCARD_WARPTL)/DESIGNCARD.DESIGNCARD_WEFTTL) * DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT / DESIGNCARD.DESIGNCARD_WARPTL)* " & Val(TXTWARPWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WARPCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_WARPDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WARPDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID  WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & " AND YARNQUALITYMASTER.YARN_NAME = '" & TXTTEMPYARNQUALITY.Text.Trim & "' AND COLORMASTER.COLOR_NAME = '" & TXTTEMPCOLOR.Text.Trim & "' GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                        'GET SELVEDGE DETAILS AND INSERT
                        DTTEMP = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, GETDATE() AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & DTROWNAME("NAME") & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((((" & Val(DTROWDESIGN("RECDMTRS")) & " *DESIGNCARD.DESIGNCARD_WARPTL)/DESIGNCARD.DESIGNCARD_WEFTTL) * DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT / DESIGNCARD.DESIGNCARD_WARPTL)* " & Val(TXTWARPWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WARPCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_SELVEDGEDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & " AND YARNQUALITYMASTER.YARN_NAME = '" & TXTTEMPYARNQUALITY.Text.Trim & "' AND COLORMASTER.COLOR_NAME = '" & TXTTEMPCOLOR.Text.Trim & "' GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                    Next
                Next
            End If


            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT DISTINCT NAME FROM TEMPVIRTUALSTOCK WHERE YEARID = " & YearId & " ORDER BY NAME", "", "")
            For Each DTROWNAME As DataRow In DT.Rows

                Dim TEMPWARPWASTAGE As Double = 0.00
                Dim TEMPWEFTWASTAGE As Double = 0.00
                Dim WEAVERSTOCK As Double = 0.00
                If Val(TXTWARPWASTAGE.Text.Trim) > 0 Then
                    DTTEMP = OBJCMN.search(" ISNULL(SUM(RECDWT),0) AS WARPWT ", "", " TEMPVIRTUALSTOCK ", " AND NAME = '" & DTROWNAME("NAME") & "' AND ISSREC = 'VIRTUALWARPCUT' AND YEARID = " & YearId)
                    If DTTEMP.Rows.Count > 0 Then TEMPWARPWASTAGE = Format(Val(DTTEMP.Rows(0).Item("WARPWT")) * Val(TXTWARPWASTAGE.Text.Trim) / 100, "0.00")
                End If

                If Val(TXTWEFTWASTAGE.Text.Trim) > 0 Then
                    DTTEMP = OBJCMN.search(" ISNULL(SUM(RECDWT),0) AS WEFTWT ", "", " TEMPVIRTUALSTOCK ", " AND NAME = '" & DTROWNAME("NAME") & "' AND ISSREC = 'VIRTUALWEFTCUT' AND YEARID = " & YearId)
                    If DTTEMP.Rows.Count > 0 Then TEMPWEFTWASTAGE = Format(Val(DTTEMP.Rows(0).Item("WEFTWT")) * Val(TXTWEFTWASTAGE.Text.Trim) / 100, "0.00")
                End If

                DTTEMP = OBJCMN.search(" ISNULL(SUM(WT) - SUM(RECDWT),0) As WT ", "", " TEMPVIRTUALSTOCK ", " AND NAME = '" & DTROWNAME("NAME") & "' AND YEARID = " & YearId)
                If DTTEMP.Rows.Count > 0 Then WEAVERSTOCK = Format(Val(DTTEMP.Rows(0).Item("WT")) - Val(TEMPWARPWASTAGE) - Val(TEMPWEFTWASTAGE), "0.00")

                GRIDWEAVER.Rows.Add(GRIDWEAVER.RowCount + 1, DTROWNAME("NAME"), WEAVERSTOCK)
            Next
            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDGENERATEDYEINGPROG_Click(sender As Object, e As EventArgs) Handles CMDGENERATEDYEINGPROG.Click
        Try
            If EDIT = False Then Exit Sub

            If MsgBox("Wish To Generate Yarn Dyeing Program", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim DT As New DataTable
            DT.Columns.Add("YARNQUALITY")
            DT.Columns.Add("SHADE")
            DT.Columns.Add("WT")
            DT.Columns.Add("MRPNO")
            DT.Columns.Add("MRPSRNO")

            Dim WT As Double = 0.0

            For Each ROW As DataGridViewRow In GRIDMRP.Rows
                If Convert.ToBoolean(ROW.Cells(GCHK.Index).Value) = True Then
                    If Val(ROW.Cells(GNEWORDERSTOCK.Index).Value) < 0 Then WT = Val(ROW.Cells(GNEWORDERSTOCK.Index).Value) * -1 Else WT = Val(ROW.Cells(GNEWORDERSTOCK.Index).Value)
                    DT.Rows.Add(ROW.Cells(GYARNQUALITY.Index).Value, ROW.Cells(GSHADE.Index).Value, Val(WT), Val(TXTMRPNO.Text.Trim), Val(ROW.Cells(GSRNO.Index).Value))
                End If
            Next

            If DT.Rows.Count > 0 Then
                Dim OBJDYEINGPROG As New YarnDyeingProgram
                OBJDYEINGPROG.AUTOYARNDYEINGPROG = True
                OBJDYEINGPROG.AUTODT = DT
                OBJDYEINGPROG.MdiParent = MDIMain
                OBJDYEINGPROG.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDMRP.RowCount = 0
                TEMPMRP = Val(tstxtbillno.Text)
                If TEMPMRP > 0 Then
                    EDIT = True
                    MRP_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDGENERATEPURCHASEPO_Click(sender As Object, e As EventArgs) Handles CMDGENERATEPURCHASEPO.Click
        Try
            If EDIT = False Then Exit Sub

            If MsgBox("Wish To Generate Yarn Purchase Order", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim DT As New DataTable
            DT.Columns.Add("YARNQUALITY")
            DT.Columns.Add("SHADE")
            DT.Columns.Add("WT")
            DT.Columns.Add("MRPNO")
            DT.Columns.Add("MRPSRNO")

            Dim WT As Double = 0.0

            For Each ROW As DataGridViewRow In GRIDMRP.Rows
                If Convert.ToBoolean(ROW.Cells(GCHK.Index).Value) = True Then
                    If Val(ROW.Cells(GNEWORDERSTOCK.Index).Value) < 0 Then WT = Val(ROW.Cells(GNEWORDERSTOCK.Index).Value) * -1 Else WT = Val(ROW.Cells(GNEWORDERSTOCK.Index).Value)
                    DT.Rows.Add(ROW.Cells(GYARNQUALITY.Index).Value, ROW.Cells(GSHADE.Index).Value, Val(WT), Val(TXTMRPNO.Text.Trim), Val(ROW.Cells(GSRNO.Index).Value))
                End If
            Next

            If DT.Rows.Count > 0 Then
                Dim OBJYPO As New YarnPurchaseOrder
                OBJYPO.AUTOYARNDYEINGPROG = True
                OBJYPO.AUTODT = DT
                OBJYPO.MdiParent = MDIMain
                OBJYPO.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " And GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMRPNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTMRPNO.Validating
        Try
            If (Val(TXTMRPNO.Text.Trim) <> 0 And EDIT = False) Or (EDIT = True And TEMPMRP <> Val(TXTMRPNO.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(MRP.MRP_NO,0)  AS MRPNO", "", " MRP ", "  AND MRP.MRP_NO=" & TXTMRPNO.Text.Trim & " AND MRP.MRP_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("MRP No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMRPNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMRPNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class