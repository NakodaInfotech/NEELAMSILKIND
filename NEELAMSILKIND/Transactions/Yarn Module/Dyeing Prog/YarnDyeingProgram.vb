
Imports System.ComponentModel
Imports BL

Public Class YarnDyeingProgram

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPPROGNO As Integer
    Public AUTOYARNDYEINGPROG As Boolean = False
    Public AUTODT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub getmax_PROG_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(PROG_no),0) + 1 ", "YARNDYEINGPROGRAM", " and PROG_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPROGNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then filltransname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, cmbcode, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        PROGDATE.Text = Now.Date
        cmbname.Text = ""
        cmbname.Enabled = True
        TXTMOBILENO.Clear()
        TXTEMAILADD.Clear()

        TXTCRDAYS.Clear()
        txtdiscount.Clear()
        TXTDELPERIOD.Clear()
        txtRefno.Clear()
        duedate.Value = Now.Date

        CMBBROKER.Text = ""
        CMBORDERTYPE.SelectedIndex = 0

        CMBFROMYARNQUALITY.Text = ""
        CMBFROMSHADE.Text = ""
        CHKREDYEING.CheckState = CheckState.Unchecked

        txtsrno.Text = 1
        CMBYARNQUALITY.Text = ""
        TXTDESC.Clear()
        CMBMILLNAME.Text = ""
        CMBCOLOR.Text = ""
        CMBGRIDNAME.Text = ""
        CMBTRANS.Text = ""
        TXTBAGS.Clear()
        CMBUNIT.Text = "Kgs"
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        GRIDPROG.RowCount = 0
        GRIDSUMM.RowCount = 0

        LBLTOTALBAGS.Text = 0
        LBLTOTALWT.Text = 0
        LBLTOTALCONES.Text = 0
        lbltotalamt.Text = 0

        EP.Clear()

        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        PBlock.Visible = False
        txtremarks.Clear()
        PBPHOTO.Image = Nothing
        PBSELPHOTO.Image = Nothing

        txtinwords.Clear()
        getmax_PROG_no()
        GRIDDOUBLECLICK = False

        CMBORDERTYPE.SelectedIndex = 0

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub YarnDyeingProgram_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                GRIDPROG.Focus()
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call TOOLPREVIOUS_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call TOOLNEXT_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call TOOLPRINT_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBBROKER.Text.Trim = "" Then fillagentledger(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
            If CMBGRIDNAME.Text.Trim = "" Then fillname(CMBGRIDNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBTRANS.Text.Trim = "" Then filltransname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            fillYARNQUALITY(CMBFROMYARNQUALITY, EDIT)
            fillunit(CMBUNIT)
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, "")
            FILLCOLOR(CMBFROMSHADE, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub YarnDyeingProgram_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'YARN ISSUE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            CLEAR()


            'GET ALL DATA FROM MRP AND POPULATE IN GRID
            If EDIT = False And AUTOYARNDYEINGPROG = True Then
                For Each DR As DataRow In AUTODT.Rows
                    GRIDPROG.Rows.Add(0, DR("YARNQUALITY").ToString, "", "", DR("SHADE"), "", "", 0, "Kgs", Format(Val(DR("WT")), "0.00"), 0, 0, 0, 0, 0, 0, 0, PBSELPHOTO.Image, Val(DR("MRPNO")), Val(DR("MRPSRNO")))
                Next
                getsrno(GRIDPROG)
                TOTAL()
            End If


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim OBJPROG As New ClsYarndyeingProgram()
                Dim dt_po As DataTable = OBJPROG.SELECTPROGRAM(TEMPPROGNO, CmpId, Locationid, YearId)
                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows

                        TXTPROGNO.Text = dr("PROGNO")
                        PROGDATE.Text = Format(Convert.ToDateTime(dr("PROGDATE")), "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))

                        TXTCRDAYS.Text = Val(dr("CRDAYS"))
                        TXTDELPERIOD.Text = Val(dr("DELDAYS"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))
                        txtdiscount.Text = Convert.ToString(dr("DISCOUNT"))
                        txtRefno.Text = Convert.ToString(dr("REFNO"))

                        CMBBROKER.Text = Convert.ToString(dr("BROKER"))
                        CMBORDERTYPE.Text = Convert.ToString(dr("ORDERTYPE"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))

                        CMBFROMYARNQUALITY.Text = Convert.ToString(dr("FROMYARNQUALITY"))
                        CMBFROMSHADE.Text = Convert.ToString(dr("FROMSHADE"))
                        CHKREDYEING.Checked = Convert.ToBoolean(dr("REDYEING"))

                        PBSELPHOTO.Image = FETCHPHOTO(dr("YARNQUALITY"), dr("SHADE"))
                        GRIDPROG.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("DESC").ToString, dr("MILLNAME").ToString, dr("SHADE").ToString, dr("GRIDNAME"), dr("TRANSNAME"), Format(Val(dr("BAGS")), "0.00"), dr("UNIT").ToString, Format(Val(dr("WT")), "0.00"), Val(dr("CONES")), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMT")), "0.00"), Val(dr("RECDBAGS")), Val(dr("RECDWT")), dr("DONE").ToString, dr("CLOSED"), PBSELPHOTO.Image, Val(dr("MRPNO")), Val(dr("MRPSRNO")))

                        If Val(dr("RECDBAGS")) > 0 Or Val(dr("RECDWT")) > 0 Then
                            GRIDPROG.Rows(GRIDPROG.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            cmbname.Enabled = False
                        End If

                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            GRIDPROG.Rows(GRIDPROG.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    GRIDPROG.FirstDisplayedScrollingRowIndex = GRIDPROG.RowCount - 1

                End If
                TOTAL()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Function FETCHPHOTO(QUALITYNAME As String, SHADE As String) As Image
        Try
            Dim PHOTO As Image = Nothing
            If QUALITYNAME <> "" And SHADE <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT YARN_PHOTO AS IMGPATH FROM YARNQUALITYMASTER INNER JOIN YARNQUALITYMASTER_COLOR ON YARNQUALITYMASTER.YARN_ID = YARNQUALITYMASTER_COLOR.YARN_ID INNER JOIN COLORMASTER ON YARN_COLORID = COLOR_ID WHERE YARN_NAME = '" & QUALITYNAME & "' AND COLOR_NAME = '" & SHADE & "' AND YARNQUALITYMASTER.YARN_YEARID = " & YearId, "", "")
                If DT.Rows.Count > 0 Then
                    If IsDBNull(DT.Rows(0).Item("IMGPATH")) = False Then
                        PHOTO = Image.FromStream(New IO.MemoryStream(DirectCast(DT.Rows(0).Item("IMGPATH"), Byte())))
                    Else
                        PHOTO = Nothing
                    End If
                End If
            End If
            Return PHOTO
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBBROKER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBROKER.Enter
        Try
            If CMBBROKER.Text.Trim = "" Then fillagentledger(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKER.Validating
        Try
            If CMBBROKER.Text.Trim <> "" Then namevalidate(CMBBROKER, cmbcode, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(PROGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(duedate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(Val(TXTDELPERIOD.Text.Trim))
            alParaval.Add(txtRefno.Text.Trim)

            alParaval.Add(txtdiscount.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBORDERTYPE.Text.Trim)

            alParaval.Add(CMBFROMYARNQUALITY.Text.Trim)
            alParaval.Add(CMBFROMSHADE.Text.Trim)
            alParaval.Add(CHKREDYEING.Checked)

            alParaval.Add(Val(LBLTOTALBAGS.Text.Trim))
            alParaval.Add(Val(LBLTOTALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALCONES.Text.Trim))
            alParaval.Add(Val(lbltotalamt.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim yarnquality As String = ""
            Dim desc As String = ""
            Dim MILLNAME As String = ""
            Dim SHADE As String = ""
            Dim GRIDNAME As String = ""
            Dim TRANSNAME As String = ""
            Dim BAGS As String = ""
            Dim UNIT As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""
            Dim RATE As String = ""
            Dim AMT As String = ""
            Dim MRPNO As String = ""
            Dim MRPSRNO As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDPROG.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        yarnquality = row.Cells(GYARNQUALITY.Index).Value.ToString
                        desc = row.Cells(gdesc.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        SHADE = row.Cells(gcolor.Index).Value.ToString
                        GRIDNAME = row.Cells(GNAME.Index).Value.ToString
                        TRANSNAME = row.Cells(GTRANSNAME.Index).Value.ToString
                        BAGS = Val(row.Cells(GBAGS.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)
                        RATE = Val(row.Cells(grate.Index).Value)
                        AMT = Val(row.Cells(gamt.Index).Value)
                        MRPNO = Val(row.Cells(GMRPNO.Index).Value)
                        MRPSRNO = Val(row.Cells(GMRPSRNO.Index).Value)

                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        yarnquality = yarnquality & "|" & row.Cells(GYARNQUALITY.Index).Value
                        desc = desc & "|" & row.Cells(gdesc.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        SHADE = SHADE & "|" & row.Cells(gcolor.Index).Value.ToString
                        GRIDNAME = GRIDNAME & "|" & row.Cells(GNAME.Index).Value.ToString
                        TRANSNAME = TRANSNAME & "|" & row.Cells(GTRANSNAME.Index).Value.ToString
                        BAGS = BAGS & "|" & Val(row.Cells(GBAGS.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(grate.Index).Value)
                        AMT = AMT & "|" & Val(row.Cells(gamt.Index).Value)
                        MRPNO = MRPNO & "|" & Val(row.Cells(GMRPNO.Index).Value)
                        MRPSRNO = MRPSRNO & "|" & Val(row.Cells(GMRPSRNO.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(yarnquality)
            alParaval.Add(desc)
            alParaval.Add(MILLNAME)
            alParaval.Add(SHADE)
            alParaval.Add(GRIDNAME)
            alParaval.Add(TRANSNAME)
            alParaval.Add(BAGS)
            alParaval.Add(UNIT)
            alParaval.Add(WT)
            alParaval.Add(CONES)
            alParaval.Add(RATE)
            alParaval.Add(AMT)
            alParaval.Add(MRPNO)
            alParaval.Add(MRPSRNO)

            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)

            Dim objclsPurord As New ClsYarndyeingProgram()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTPROGNO.Text = DT.Rows(0).Item(0)
            Else
                alParaval.Add(TEMPPROGNO)

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT()

            CLEAR()
            cmbname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True
        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If

        If CMBFROMYARNQUALITY.Text.Trim.Length = 0 And CHKREDYEING.CheckState = CheckState.Unchecked Then
            EP.SetError(CMBFROMYARNQUALITY, " Please Fill Yarn Quality")
            bln = False
        End If

        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked")
            bln = False
        End If

        If PROGDATE.Text = "__/__/____" Then
            EP.SetError(PROGDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(PROGDATE.Text) Then
                EP.SetError(PROGDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub TOTAL()
        LBLTOTALBAGS.Text = "0"
        LBLTOTALWT.Text = "0.00"
        LBLTOTALCONES.Text = 0
        lbltotalamt.Text = "0.00"

        GRIDSUMM.RowCount = 0
        Dim DONE As Boolean = False

        If GRIDPROG.RowCount > 0 Then
            For Each row As DataGridViewRow In GRIDPROG.Rows
                row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).Value) * Val(row.Cells(GWT.Index).Value), "0.00")
                If Val(row.Cells(GBAGS.Index).Value) <> 0 Then LBLTOTALBAGS.Text = Val(LBLTOTALBAGS.Text) + Val(row.Cells(GBAGS.Index).Value)
                If Val(row.Cells(GWT.Index).Value) <> 0 Then LBLTOTALWT.Text = Val(LBLTOTALWT.Text) + Val(row.Cells(GWT.Index).Value)
                If Val(row.Cells(GCONES.Index).Value) <> 0 Then LBLTOTALCONES.Text = Val(LBLTOTALCONES.Text) + Val(row.Cells(GCONES.Index).Value)
                If Val(row.Cells(gamt.Index).Value) <> 0 Then lbltotalamt.Text = Val(lbltotalamt.Text) + Val(row.Cells(gamt.Index).Value)


                DONE = False
                If Val(row.Cells(GWT.Index).EditedFormattedValue) > 0 Then
                    If GRIDSUMM.RowCount = 0 Then
                        GRIDSUMM.Rows.Add(row.Cells(GYARNQUALITY.Index).Value, row.Cells(gcolor.Index).Value, Format(Val(row.Cells(GWT.Index).EditedFormattedValue), "0.00"))
                    Else
                        For Each SUMMROW As DataGridViewRow In GRIDSUMM.Rows
                            If SUMMROW.Cells(SQUALITY.Index).Value = row.Cells(GYARNQUALITY.Index).Value And SUMMROW.Cells(SSHADE.Index).Value = row.Cells(gcolor.Index).Value Then
                                SUMMROW.Cells(SWT.Index).Value = Val(SUMMROW.Cells(SWT.Index).Value) + Val(row.Cells(GWT.Index).EditedFormattedValue)
                                DONE = True
                            End If
                        Next
                        If DONE = False Then GRIDSUMM.Rows.Add(row.Cells(GYARNQUALITY.Index).Value, row.Cells(gcolor.Index).Value, Format(Val(row.Cells(GWT.Index).EditedFormattedValue), "0.00"))
                    End If
                End If

            Next
        End If


    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDPROG.RowCount > 0 Then
                txtsrno.Text = Val(GRIDPROG.Rows(GRIDPROG.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMYARNQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMYARNQUALITY.Enter
        Try
            If CMBFROMYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBFROMYARNQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMYARNQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMYARNQUALITY.Validating
        Try
            If CMBFROMYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBFROMYARNQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDPROG.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDPROG.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, TXTDESC.Text.Trim, CMBMILLNAME.Text.Trim, CMBCOLOR.Text.Trim, CMBGRIDNAME.Text.Trim, CMBTRANS.Text.Trim, Val(TXTBAGS.Text.Trim), CMBUNIT.Text.Trim, Val(TXTWT.Text.Trim), Val(TXTCONES.Text.Trim), Val(TXTRATE.Text.Trim), 0, 0, 0, 0, 0, 0, 0)
            getsrno(GRIDPROG)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDPROG.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDPROG.Item(gdesc.Index, TEMPROW).Value = TXTDESC.Text.Trim
            GRIDPROG.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILLNAME.Text.Trim
            GRIDPROG.Item(gcolor.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDPROG.Item(GNAME.Index, TEMPROW).Value = CMBGRIDNAME.Text.Trim
            GRIDPROG.Item(GTRANSNAME.Index, TEMPROW).Value = CMBTRANS.Text.Trim
            GRIDPROG.Item(GBAGS.Index, TEMPROW).Value = Val(TXTBAGS.Text.Trim)
            GRIDPROG.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim
            GRIDPROG.Item(GWT.Index, TEMPROW).Value = Val(TXTWT.Text.Trim)
            GRIDPROG.Item(GCONES.Index, TEMPROW).Value = Val(TXTCONES.Text.Trim)
            GRIDPROG.Item(grate.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        GRIDPROG.FirstDisplayedScrollingRowIndex = GRIDPROG.RowCount - 1

        txtsrno.Text = GRIDPROG.RowCount + 1
        CMBYARNQUALITY.Text = ""
        TXTDESC.Clear()
        CMBMILLNAME.Text = ""
        CMBCOLOR.Text = ""
        CMBGRIDNAME.Text = ""
        CMBTRANS.Text = ""
        TXTBAGS.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTRATE.Clear()

        TOTAL()
        CMBYARNQUALITY.Focus()

    End Sub

    Private Sub GRIDPO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPROG.CellDoubleClick
        If e.RowIndex >= 0 And GRIDPROG.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(GRIDPROG.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPROG.Rows(e.RowIndex).Cells(GCLOSED.Index).Value) = True Then
                MsgBox("Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            GRIDDOUBLECLICK = True
            txtsrno.Text = Val(GRIDPROG.Item(gsrno.Index, e.RowIndex).Value)
            CMBYARNQUALITY.Text = GRIDPROG.Item(GYARNQUALITY.Index, e.RowIndex).Value.ToString
            TXTDESC.Text = GRIDPROG.Item(gdesc.Index, e.RowIndex).Value.ToString
            CMBMILLNAME.Text = GRIDPROG.Item(GMILLNAME.Index, e.RowIndex).Value.ToString
            CMBCOLOR.Text = GRIDPROG.Item(gcolor.Index, e.RowIndex).Value.ToString
            CMBGRIDNAME.Text = GRIDPROG.Item(GNAME.Index, e.RowIndex).Value.ToString
            CMBTRANS.Text = GRIDPROG.Item(GTRANSNAME.Index, e.RowIndex).Value.ToString
            TXTBAGS.Text = Val(GRIDPROG.Item(GBAGS.Index, e.RowIndex).Value)
            CMBUNIT.Text = GRIDPROG.Item(GUNIT.Index, e.RowIndex).Value.ToString
            TXTWT.Text = Val(GRIDPROG.Item(GWT.Index, e.RowIndex).Value)
            TXTCONES.Text = Val(GRIDPROG.Item(GCONES.Index, e.RowIndex).Value)
            TXTRATE.Text = Val(GRIDPROG.Item(grate.Index, e.RowIndex).Value)

            TEMPROW = e.RowIndex
            CMBYARNQUALITY.Focus()
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress, TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PROGDATE.GotFocus
        PROGDATE.SelectAll()
    End Sub

    Private Sub PODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PROGDATE.Validating
        Try
            If PROGDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PROGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
                    MsgBox("PO Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Order ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TEMPPROGNO)
                alParaval.Add(YearId)

                Dim clspo As New ClsYarndyeingProgram()
                clspo.alParaval = alParaval
                IntResult = clspo.Delete()
                MsgBox("Purchase Order Deleted")
                CLEAR()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, cmbcode, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS", CMBTRANS.Text.Trim, CMBBROKER.Text)
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_CRDAYS,0),  isnull(LEDGERS_1.Acc_cmpname,'') AS transport, isnull(LEDGERS_2.Acc_cmpname,'') AS agent, ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO, ISNULL(LEDGERS.ACC_EMAIL,'') AS EMAIL, ISNULL(LEDGERS.ACC_DISC,0) AS DISC ", "", "  LEDGERS LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid And LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid ", " AND ledgers.ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ledgers.ACC_CMPID = " & CmpId & " AND ledgers.ACC_LOCATIONID = " & Locationid & " AND ledgers.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(TXTCRDAYS.Text.Trim) = 0 Then TXTCRDAYS.Text = Val(DT.Rows(0).Item(0))
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                    TXTEMAILADD.Text = DT.Rows(0).Item("EMAIL")
                    If Val(txtdiscount.Text.Trim) = 0 Then txtdiscount.Text = Val(DT.Rows(0).Item("DISC"))
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPROG.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = GRIDPROG.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, GBAGS.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDPROG.CurrentCell.Value = Nothing Then GRIDPROG.CurrentCell.Value = "0.00"
                    GRIDPROG.CurrentCell.Value = Convert.ToDecimal(GRIDPROG.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    GRIDPROG.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(GRIDPROG.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(GRIDPROG.Rows(e.RowIndex).Cells(GWT.Index).EditedFormattedValue), "0.00")
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                TOTAL()

        End Select
    End Sub

    Sub EDITROW()
        Try
            If GRIDPROG.CurrentRow.Index >= 0 And GRIDPROG.Item(gsrno.Index, GRIDPROG.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(GRIDPROG.Rows(GRIDPROG.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPROG.Rows(GRIDPROG.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                txtsrno.Text = Val(GRIDPROG.Item(gsrno.Index, GRIDPROG.CurrentRow.Index).Value)
                CMBYARNQUALITY.Text = GRIDPROG.Item(GYARNQUALITY.Index, GRIDPROG.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDPROG.Item(gdesc.Index, GRIDPROG.CurrentRow.Index).Value.ToString
                CMBMILLNAME.Text = GRIDPROG.Item(GMILLNAME.Index, GRIDPROG.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDPROG.Item(gcolor.Index, GRIDPROG.CurrentRow.Index).Value.ToString
                CMBGRIDNAME.Text = GRIDPROG.Item(GNAME.Index, GRIDPROG.CurrentRow.Index).Value.ToString
                CMBTRANS.Text = GRIDPROG.Item(GTRANSNAME.Index, GRIDPROG.CurrentRow.Index).Value.ToString
                TXTBAGS.Text = Val(GRIDPROG.Item(GBAGS.Index, GRIDPROG.CurrentRow.Index).Value)
                CMBUNIT.Text = GRIDPROG.Item(GUNIT.Index, GRIDPROG.CurrentRow.Index).Value.ToString
                TXTWT.Text = Val(GRIDPROG.Item(GWT.Index, GRIDPROG.CurrentRow.Index).Value)
                TXTCONES.Text = Val(GRIDPROG.Item(GCONES.Index, GRIDPROG.CurrentRow.Index).Value)
                TXTRATE.Text = Val(GRIDPROG.Item(grate.Index, GRIDPROG.CurrentRow.Index).Value)

                TEMPROW = GRIDPROG.CurrentRow.Index
                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPROG.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDPROG.RowCount > 0 Then

                If Convert.ToBoolean(GRIDPROG.Rows(GRIDPROG.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPROG.Rows(GRIDPROG.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDPROG.Rows.RemoveAt(GRIDPROG.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDPROG)
                TOTAL()

            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPROG.RowCount = 0
                TEMPPROGNO = Val(tstxtbillno.Text)
                If TEMPPROGNO > 0 Then
                    EDIT = True
                    YarnDyeingProgram_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles CMBCOLOR.Enter
        Try
            FILLYARNCOLOR(CMBCOLOR, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then YARNCOLORVALIDATE(CMBCOLOR, e, Me, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMSHADE_Enter(sender As Object, e As EventArgs) Handles CMBFROMSHADE.Enter
        Try
            FILLYARNCOLOR(CMBFROMSHADE, CMBFROMYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMSHADE.Validating
        Try
            If CMBFROMSHADE.Text.Trim <> "" Then YARNCOLORVALIDATE(CMBFROMSHADE, e, Me, CMBFROMYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJPO As New YarnDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.FRMSTRING = "DYEINGPROG"
            OBJPO.WHERECLAUSE = "{YARNDYEINGPROGRAM.PROG_NO}=" & Val(TXTPROGNO.Text) & " and {YARNDYEINGPROGRAM.PROG_yearid}=" & YearId
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPREVIOUS.Click
        Try
            GRIDPROG.RowCount = 0
LINE1:
            TEMPPROGNO = Val(TXTPROGNO.Text) - 1
            If TEMPPROGNO > 0 Then
                EDIT = True
                YarnDyeingProgram_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPROG.RowCount = 0 And TEMPPROGNO > 1 Then
                TXTPROGNO.Text = TEMPPROGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDPROG.RowCount = 0
LINE1:
            TEMPPROGNO = Val(TXTPROGNO.Text) + 1
            getmax_PROG_no()
            Dim MAXNO As Integer = TXTPROGNO.Text.Trim
            CLEAR()
            If Val(TXTPROGNO.Text) - 1 >= TEMPPROGNO Then
                EDIT = True
                YarnDyeingProgram_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPROG.RowCount = 0 And TEMPPROGNO < MAXNO Then
                TXTPROGNO.Text = TEMPPROGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTDELPERIOD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDELPERIOD.Validated
        Try
            If PROGDATE.Text <> "__/__/____" Then
                If Val(TXTDELPERIOD.Text.Trim) > 0 Then duedate.Value = Convert.ToDateTime(PROGDATE.Text).Date.AddDays(Val(TXTDELPERIOD.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub duedate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles duedate.Validated
        Try
            If PROGDATE.Text <> "__/__/____" And Val(TXTDELPERIOD.Text.Trim) = 0 Then TXTDELPERIOD.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(PROGDATE.Text).Date, duedate.Value.Date)
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

            Dim objINVDTLS As New YarnDyeingProgramDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Enter(sender As Object, e As EventArgs) Handles CMBMILLNAME.Enter
        Try
            If CMBMILLNAME.Text.Trim = "" Then FILLMILL(CMBMILLNAME, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBMILLNAME.Validating
        Try
            If CMBMILLNAME.Text.Trim <> "" Then MILLVALIDATE(CMBMILLNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCONES.KeyPress
        numkeypress(e, TXTCONES, Me)
    End Sub

    Private Sub GRIDPO_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPROG.CellClick
        PBPHOTO.Image = GRIDPROG.CurrentRow.Cells(GIMGPATH.Index).Value
    End Sub

    Private Sub CMBGRIDNAME_Enter(sender As Object, e As EventArgs) Handles CMBGRIDNAME.Enter
        Try
            If CMBGRIDNAME.Text.Trim = "" Then fillname(CMBGRIDNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBGRIDNAME.Validating
        Try
            If CMBGRIDNAME.Text.Trim <> "" Then namevalidate(CMBGRIDNAME, cmbcode, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'", "SUNDRY CREDITORS", "ACCOUNTS", CMBTRANS.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validated(sender As Object, e As EventArgs) Handles CMBCOLOR.Validated
        PBSELPHOTO.Image = FETCHPHOTO(CMBYARNQUALITY.Text.Trim, CMBCOLOR.Text.Trim)
    End Sub
End Class