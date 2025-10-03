
Imports System.ComponentModel
Imports BL

Public Class YarnRecdFromJobber

    Dim GRIDDOUBLECLICK, GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPYARNNO As Integer     'used for poation no while editing
    Dim TEMPROW, TEMPUPLOADROW As Integer
    Public Shared SELECTPOTABLE As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim PARTYCHALLANNO As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        EP.Clear()
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""


        YARNDATE.Text = Now.Date
        CMBTONAME.Enabled = True
        CMBTONAME.Text = ""
        CMBPROCESS.Text = ""
        cmbtrans.Text = ""
        CMBTRANS2.Text = ""
        dtpchallan.Value = Now.Date
        TXTCHALLANNO.Clear()
        CMBDELIVERYAT.Text = ""



        CMBJONO.Text = ""
        CMBJONO.Enabled = True
        TXTBALWT.Clear()

        txttransref.Clear()
        txttransremarks.Clear()
        TXTREMARKS.Clear()

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        txtimgpath.Clear()
        TXTFILENAME.Clear()
        TXTNEWIMGPATH.Clear()
        PBSoftCopy.Image = Nothing
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0

        lbllocked.Visible = False
        PBlock.Visible = False

        txtsrno.Text = 1
        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBCOLOR.Text = ""
        TXTBOXNO.Clear()
        TXTLOTNO.Clear()
        TXTQTY.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        GRIDYARN.RowCount = 0
        GRIDPROG.RowCount = 0

        CMDSELECTPROG.Enabled = True
        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        GETMAXNO()

        LBLTOTALCONES.Text = 0
        LBLTOTALQTY.Text = 0
        LBLTOTALWT.Text = 0

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALCONES.Text = 0.0
            LBLTOTALWT.Text = 0.0
            LBLTOTALQTY.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDYARN.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCONES.Text = Format(Val(LBLTOTALCONES.Text) + Val(ROW.Cells(GCONES.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        YARNDATE.Focus()
    End Sub

    Private Sub GRNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YARNDATE.GotFocus
        YARNDATE.SelectAll()
    End Sub

    Private Sub GRNDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YARNDATE.Validating
        Try
            If YARNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(YARNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAXNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(YARN_no),0) + 1 ", "YARNRECDJOBBER", " and YARN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTYARNNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBTONAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBTONAME, " Please Fill Company Name ")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If


            If GRIDYARN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If


            'coz if it it other item type then mtrs will be blank
            'if want to enable then check for materialtype
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable

            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    DT = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBTONAME.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If


            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPPROGROWNO As Integer = -1
            Dim TEMPPROGMATCH As Boolean = False
            If GRIDPROG.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDPROG.Rows
                    ORDROW.Cells(ORECDWT.Index).Value = 0
                Next

                For Each ROW As DataGridViewRow In GRIDYARN.Rows
                    For Each ORDROW As DataGridViewRow In GRIDPROG.Rows
                        If ROW.Cells(GYARNQUALITY.Index).Value = ORDROW.Cells(OYARNQUALITY.Index).Value And ROW.Cells(gcolor.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
                            TEMPPROGMATCH = True
                            'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                            If Val(ORDROW.Cells(ORECDWT.Index).Value) >= Val(ORDROW.Cells(OWT.Index).Value) Then
                                TEMPPROGROWNO = ORDROW.Index
                                GoTo CHECKNEXTLINE
                            End If
                            ORDROW.Cells(ORECDWT.Index).Value = Val(ORDROW.Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                            TEMPPROGROWNO = -1
                            Exit For
CHECKNEXTLINE:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPPROGROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPPROGROWNO >= 0 Then
                        GRIDPROG.Rows(TEMPPROGROWNO).Cells(ORECDWT.Index).Value = Val(GRIDPROG.Rows(TEMPPROGROWNO).Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                        TEMPPROGROWNO = -1
                    End If
                    If TEMPPROGMATCH = False Then
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen
                        If MsgBox("There are Items which are not Present in Selected Program, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            EP.SetError(CMBTONAME, "There are Items which are not Present in Selected Program")
                            bln = False
                        End If
                    End If
                    TEMPPROGMATCH = False
                Next
            End If


            If YARNDATE.Text = "__/__/____" Then
                EP.SetError(YARNDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(YARNDATE.Text) Then
                    EP.SetError(YARNDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If


            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()

            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)

            alParaval.Add(CMBTONAME.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Format(dtpchallan.Value.Date, "MM/dd/yyyy"))

            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(CMBTRANS2.Text.Trim)

            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALCONES.Text))

            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(CMBJONO.Text.Trim)
            alParaval.Add(TXTBALWT.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim COLOR As String = ""
            Dim BOXNO As String = ""
            Dim LOTNO As String = ""
            Dim qty As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BOXNO = row.Cells(GBOXNO.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        qty = Val(row.Cells(GQTY.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value

                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BOXNO = BOXNO & "|" & row.Cells(GBOXNO.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(GQTY.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(COLOR)
            alParaval.Add(BOXNO)
            alParaval.Add(LOTNO)
            alParaval.Add(qty)
            alParaval.Add(WT)
            alParaval.Add(CONES)



            Dim PROGGRIDSRNO As String = ""
            Dim PROGYARNQUALITY As String = ""
            Dim PROGCOLOR As String = ""
            Dim PROGWT As String = ""
            Dim PROGFROMNO As String = ""
            Dim PROGFROMSRNO As String = ""
            Dim PROGFROMTYPE As String = ""
            Dim PROGRECDWT As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDPROG.Rows
                If row.Cells(0).Value <> Nothing AndAlso Val(row.Cells(ORECDWT.Index).Value) > 0 Then

                    If PROGGRIDSRNO = "" Then
                        PROGGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        PROGYARNQUALITY = row.Cells(OYARNQUALITY.Index).Value.ToString
                        PROGCOLOR = row.Cells(OCOLOR.Index).Value.ToString
                        PROGWT = Val(row.Cells(OWT.Index).Value)
                        PROGFROMNO = Val(row.Cells(OFROMNO.Index).Value)
                        PROGFROMSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        PROGFROMTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        PROGRECDWT = Val(row.Cells(ORECDWT.Index).Value)
                    Else
                        PROGGRIDSRNO = PROGGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        PROGYARNQUALITY = PROGYARNQUALITY & "|" & row.Cells(OYARNQUALITY.Index).Value.ToString
                        PROGCOLOR = PROGCOLOR & "|" & row.Cells(OCOLOR.Index).Value.ToString
                        PROGWT = PROGWT & "|" & Val(row.Cells(OWT.Index).Value)
                        PROGFROMNO = PROGFROMNO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        PROGFROMSRNO = PROGFROMSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        PROGFROMTYPE = PROGFROMTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        PROGRECDWT = PROGRECDWT & "|" & Val(row.Cells(ORECDWT.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(PROGGRIDSRNO)
            alParaval.Add(PROGYARNQUALITY)
            alParaval.Add(PROGCOLOR)
            alParaval.Add(PROGWT)
            alParaval.Add(PROGFROMNO)
            alParaval.Add(PROGFROMSRNO)
            alParaval.Add(PROGFROMTYPE)
            alParaval.Add(PROGRECDWT)


            Dim objclsGRN As New ClsYarnRecdFromJobber()
            objclsGRN.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsGRN.SAVE()
                TXTYARNNO.Text = Val(DTTABLE.Rows(0).Item(0))
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPYARNNO)

                Dim IntResult As Integer = objclsGRN.UPDATE()
                MsgBox("Details Updated")
            End If

            If EDIT = False Then
                If MsgBox("Issue Yarn Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJISSUE As New YarnDirectIssueJobber
                    OBJISSUE.ShowDialog()
                    If OBJISSUE.CMBJOBBER.Text.Trim = "" Then GoTo LINE1
                    DIRECTISSUEJOBBER(OBJISSUE.CMBJOBBER.Text.Trim, OBJISSUE.CMBPROCESS.Text.Trim, OBJISSUE.txtremarks.Text.Trim, OBJISSUE.cmbtrans.Text.Trim, OBJISSUE.CMBTRANS2.Text.Trim)
                End If
            End If

LINE1:


            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            PRINTREPORT(TXTYARNNO.Text.Trim)

            EDIT = False
            CLEAR()
            YARNDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DIRECTISSUEJOBBER(ByVal JOBBERNAME As String, PROCESSNAME As String, REMARKS As String, TRANS1 As String, TRANS2 As String)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(0)
            ALPARAVAL.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(JOBBERNAME)
            ALPARAVAL.Add("")   'MACHINE
            ALPARAVAL.Add(PROCESSNAME)   'PROCESS
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)

            ALPARAVAL.Add(TRANS1)
            ALPARAVAL.Add(TRANS2)   'TRANS2

            ALPARAVAL.Add(Val(LBLTOTALQTY.Text))
            ALPARAVAL.Add(Val(LBLTOTALWT.Text))
            ALPARAVAL.Add(Val(LBLTOTALCONES.Text))

            ALPARAVAL.Add(REMARKS)
            ALPARAVAL.Add("")   'EWAYBILLNO
            ALPARAVAL.Add("")   'VEHICLENO
            ALPARAVAL.Add(0)    'MANUALAMT
            ALPARAVAL.Add(0)    'TAXABLEAMT
            ALPARAVAL.Add(0)    'CGSTPER
            ALPARAVAL.Add(0)    'CGSTAMT
            ALPARAVAL.Add(0)    'SGSTPER
            ALPARAVAL.Add(0)    'SGSTAMT
            ALPARAVAL.Add(0)    'IGSTPER
            ALPARAVAL.Add(0)    'IGSTAMT
            ALPARAVAL.Add(0)    'GRANDTOTAL
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)


            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim COLOR As String = ""
            Dim BOXNO As String = ""
            Dim LOTNO As String = ""
            Dim qty As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""
            Dim LRNO As String = ""
            Dim LRDATE As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BOXNO = row.Cells(GBOXNO.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        qty = Val(row.Cells(GQTY.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)
                        LRNO = ""
                        LRDATE = Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy")


                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BOXNO = BOXNO & "|" & row.Cells(GBOXNO.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(GQTY.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)
                        LRNO = LRNO & "|" & ""
                        LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy")

                    End If
                End If
            Next

            ALPARAVAL.Add(gridsrno)
            ALPARAVAL.Add(YARNQUALITY)
            ALPARAVAL.Add(MILLNAME)
            ALPARAVAL.Add(COLOR)
            ALPARAVAL.Add(BOXNO)
            ALPARAVAL.Add(LOTNO)
            ALPARAVAL.Add(qty)
            ALPARAVAL.Add(WT)

            ALPARAVAL.Add(CONES)
            ALPARAVAL.Add(LRNO)
            ALPARAVAL.Add(LRDATE)

            Dim OBJYAARNISSUE As New ClsYarnIssue
            OBJYAARNISSUE.alParaval = ALPARAVAL
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim DT As DataTable = OBJYAARNISSUE.SAVE()
            MsgBox("Yarn Issued To Jobber")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsYarnRecdFromJobber


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPYARNNO)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSoftCopy.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSoftCopy.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJBILL.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJBILL.SAVEUPLOAD()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDYARN.Focus()
        End If
    End Sub

    Private Sub GRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOB IN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            FILLCMB()
            CLEAR()


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsYARN As New ClsYarnRecdFromJobber()
                Dim dttable As New DataTable

                dttable = objclsYARN.SELECTYARN(TEMPYARNNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTYARNNO.Text = TEMPYARNNO
                        YARNDATE.Text = Format(Convert.ToDateTime(dr("YARNDATE")).Date, "dd/MM/yyyy")
                        CMBTONAME.Text = Convert.ToString(dr("TONAME").ToString)
                        CMBTONAME.Enabled = False
                        CMBPROCESS.Text = dr("PROCESS")
                        CMBJONO.Text = Convert.ToString(dr("JONO").ToString)
                        CMBJONO.Enabled = False

                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTLOTNO.Text = Convert.ToString(dr("LOTNO").ToString)
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        dtpchallan.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        cmbtrans.Text = dr("TRANSNAME").ToString
                        CMBTRANS2.Text = dr("TRANSNAME2").ToString
                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)
                        GRIDYARN.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("MILLNAME").ToString, dr("COLOR"), dr("BOXNO"), dr("LOTNO"), Format(Val(dr("qty")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("CONES")), "0"))

                    Next
                    'CMDSELECTPROG.Enabled = False
                    TOTAL()
                Else
                    EDIT = False
                    CLEAR()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" YARNRECDJOBBER_UPLOAD.YARN_SRNO AS GRIDSRNO, YARNRECDJOBBER_UPLOAD.YARN_REMARKS AS REMARKS, YARNRECDJOBBER_UPLOAD.YARN_NAME AS NAME, YARNRECDJOBBER_UPLOAD.YARN_PHOTO AS IMGPATH ", "", " YARNRECDJOBBER_UPLOAD ", " AND YARNRECDJOBBER_UPLOAD.YARN_NO = " & TEMPYARNNO & " AND YARN_YEARID = " & YearId & " ORDER BY YARNRECDJOBBER_UPLOAD.YARN_SRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                    Next
                End If


                'ORDER GRID
                'Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" YARNRECDJOBBER_PROGDETAILS.YARN_GRIDSRNO AS GRIDSRNO, YARNQUALITYMASTER.YARN_name AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(YARNRECDJOBBER_PROGDETAILS.YARN_PROGWT,0) AS PROGWT, YARNRECDJOBBER_PROGDETAILS.YARN_FROMNO AS FROMNO, YARNRECDJOBBER_PROGDETAILS.YARN_FROMSRNO AS FROMSRNO, YARNRECDJOBBER_PROGDETAILS.YARN_FROMTYPE AS FROMTYPE, ISNULL(YARNRECDJOBBER_PROGDETAILS.YARN_WT,0) AS RECDWT ", "", " YARNRECDJOBBER_PROGDETAILS INNER JOIN YARNQUALITYMASTER ON YARNRECDJOBBER_PROGDETAILS.YARN_YARNQUALITYID= YARNQUALITYMASTER.YARN_id LEFT OUTER JOIN COLORMASTER ON YARNRECDJOBBER_PROGDETAILS.YARN_COLORID = COLORMASTER.COLOR_id ", " AND YARNRECDJOBBER_PROGDETAILS.YARN_NO = " & TEMPYARNNO & " AND YARNRECDJOBBER_PROGDETAILS.YARN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDPROG.Rows.Add(Val(DTR("GRIDSRNO")), DTR("YARNQUALITY"), DTR("COLOR"), Val(DTR("PROGWT")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("RECDWT")))
                    Next
                End If
                getsrno(GRIDPROG)

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If CMBDELIVERYAT.Text.Trim = "" Then fillname(CMBDELIVERYAT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")

            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")
            If CMBTRANS2.Text.Trim = "" Then fillname(CMBTRANS2, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

            FILLPROCESS(CMBPROCESS)
            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLYARNCOLOR(CMBCOLOR, CMBYARNQUALITY.Text.Trim)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objgrndetails As New YarnRecdFromJobberDetails()
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
            objgrndetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS2.Enter
        Try
            If CMBTRANS2.Text.Trim = "" Then fillname(CMBTRANS2, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS2.Validating
        Try
            If CMBTRANS2.Text.Trim <> "" Then namevalidate(CMBTRANS2, CMBCODE, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")
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

    Private Sub txtchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If TXTCHALLANNO.Text.Trim.Length > 0 Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As New DataTable
                    dt = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBTONAME.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "NEELAMSILKIND")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub dtpchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpchallan.Validating
        If Not datecheck(dtpchallan.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDYARN.RowCount = 0
                TEMPYARNNO = Val(tstxtbillno.Text)
                If TEMPYARNNO > 0 Then
                    EDIT = True
                    GRN_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDYARN.Enabled = True

        Dim TEMPQTY As Integer = Val(TXTQTY.Text.Trim)
        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBCOLOR.Text.Trim, TXTBOXNO.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0"))
            getsrno(GRIDYARN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDYARN.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDYARN.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDYARN.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim
            GRIDYARN.Item(gcolor.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDYARN.Item(GBOXNO.Index, TEMPROW).Value = TXTBOXNO.Text.Trim
            GRIDYARN.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            GRIDYARN.Item(GQTY.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
            GRIDYARN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            GRIDYARN.Item(GCONES.Index, TEMPROW).Value = Format(Val(TXTCONES.Text.Trim), "0")

            GRIDDOUBLECLICK = False

        End If

        TOTAL()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        txtgridremarks.Clear()
        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBCOLOR.Text = ""
        TXTBOXNO.Clear()
        TXTLOTNO.Clear()
        TXTQTY.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()

        txtsrno.Text = Val(GRIDYARN.RowCount) + 1
        CMBYARNQUALITY.Focus()


    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath.Text.Trim.Length <> 0 Then PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSoftCopy.ImageLocation <> "" Then
                FILLUPLOAD()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLUPLOAD()

        If GRIDUPLOADDOUBLECLICK = False Then
            gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSoftCopy.Image)
            getsrno(gridupload)
        ElseIf GRIDUPLOADDOUBLECLICK = True Then

            gridupload.Item(GUSRNO.Index, TEMPUPLOADROW).Value = txtuploadsrno.Text.Trim
            gridupload.Item(GUREMARKS.Index, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, TEMPUPLOADROW).Value = PBSoftCopy.Image

            GRIDUPLOADDOUBLECLICK = False

        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        txtuploadsrno.Text = gridupload.RowCount + 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSoftCopy.Image = Nothing
        txtimgpath.Clear()

        txtuploadremarks.Focus()

    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDUPLOADDOUBLECLICK = True
                txtuploadsrno.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSoftCopy.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                TEMPUPLOADROW = e.RowIndex
                txtuploadremarks.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDUPLOADDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                getsrno(gridupload)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSoftCopy.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GUSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Sub EDITROW()
        Try
            If GRIDYARN.CurrentRow.Index >= 0 And GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBYARNQUALITY.Text = GRIDYARN.Item(GYARNQUALITY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBMILL.Text = GRIDYARN.Item(GMILLNAME.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDYARN.Item(gcolor.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTBOXNO.Text = GRIDYARN.Item(GBOXNO.Index, GRIDYARN.CurrentRow.Index).Value
                TXTLOTNO.Text = GRIDYARN.Item(GLOTNO.Index, GRIDYARN.CurrentRow.Index).Value
                TXTQTY.Text = Val(GRIDYARN.Item(GQTY.Index, GRIDYARN.CurrentRow.Index).Value)
                TXTWT.Text = Val(GRIDYARN.Item(GWT.Index, GRIDYARN.CurrentRow.Index).Value)
                TXTCONES.Text = Val(GRIDYARN.Item(GCONES.Index, GRIDYARN.CurrentRow.Index).Value)

                TEMPROW = GRIDYARN.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDYARN.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor

            GRIDYARN.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYARNNO.Text) - 1
            If TEMPYARNNO > 0 Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO > 1 Then
                TXTYARNNO.Text = TEMPYARNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDYARN.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYARNNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTYARNNO.Text.Trim
            CLEAR()
            If Val(TXTYARNNO.Text) - 1 >= TEMPYARNNO Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO < MAXNO Then
                TXTYARNNO.Text = TEMPYARNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTCONES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If lbllocked.Visible = True Then
                    MsgBox("Unable to Delete, Checking Done / Item Used", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Delete Yarn?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(TXTYARNNO.Text.Trim)
                alParaval.Add(YearId)

                Dim Clsgrn As New ClsYarnRecdFromJobber()
                Clsgrn.alParaval = alParaval
                Dim IntResult As Integer = Clsgrn.DELETE()
                MsgBox("Yarn Deleted")
                CLEAR()
                EDIT = False
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridgrn_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDYARN.CellValidating
        Try

            Dim colNum As Integer = GRIDYARN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GQTY.Index, GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDYARN.CurrentCell.Value = Nothing Then GRIDYARN.CurrentCell.Value = "0.00"
                        GRIDYARN.CurrentCell.Value = Convert.ToDecimal(GRIDYARN.Item(colNum, e.RowIndex).Value)
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

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDYARN.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDYARN.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDYARN.Rows.RemoveAt(GRIDYARN.CurrentRow.Index)
                getsrno(GRIDYARN)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDYARN.RowCount > 0 Then
                'If gridgrn.CurrentRow.Cells(gitemname.Index).Value <> "" Then
                '    gridgrn.Rows.Add(CloneWithValues(gridgrn.CurrentRow))
                '    getsrno(gridgrn)
                '    total()
                'End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.GotFocus
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
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTONAME.Enter
        Try
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTONAME.Validating
        Try
            If CMBTONAME.Text.Trim <> "" Then namevalidate(CMBTONAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTONAME.Enter
        Try
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTONAME.Validating
        Try
            If CMBTONAME.Text.Trim <> "" Then namevalidate(CMBTONAME, CMBTOCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDELIVERYAT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDELIVERYAT.Enter
        Try
            If CMBDELIVERYAT.Text.Trim = "" Then fillname(CMBDELIVERYAT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDELIVERYAT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDELIVERYAT.Validating
        Try
            If CMBDELIVERYAT.Text.Trim <> "" Then namevalidate(CMBDELIVERYAT, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSoftCopy.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPYARNNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTONAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTONAME.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTONAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTONAME.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Sub PRINTREPORT(ByVal YARNNO As Integer)
        Try
            If MsgBox("Wish to Print Yarn Recd?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJPUR As New YarnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "YARNRECDJOBBER"
                OBJPUR.WHERECLAUSE = "{YARNRECDJOBBER.YARN_NO}=" & Val(YARNNO) & " and {YARNRECDJOBBER.YARN_YEARID}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub CMBMILL_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMILL.Enter
        Try
            If CMBMILL.Text.Trim = "" Then FILLMILL(CMBMILL, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILL.Validating
        Try
            If CMBMILL.Text.Trim <> "" Then MILLVALIDATE(CMBMILL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMDSELECTPROG_Click(sender As Object, e As EventArgs) Handles CMDSELECTPROG.Click
        Try
            If CMBTONAME.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                CMBTONAME.Focus()
                Exit Sub
            End If

            Dim DTPO As New DataTable
            Dim OBJPROG As New SelectDyeingProg
            OBJPROG.DELIVERYAT = CMBDELIVERYAT.Text.Trim
            OBJPROG.PARTYNAME = CMBTONAME.Text.Trim
            OBJPROG.ShowDialog()
            DTPO = OBJPROG.DT

            If DTPO.Rows.Count > 0 Then

                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTPO.Rows
                    For Each ROW As DataGridViewRow In GRIDPROG.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("PROGNO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next

                    GRIDPROG.Rows.Add(0, DTROW("YARNQUALITY"), DTROW("COLOR"), Val(DTROW("WT")), DTROW("PROGNO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0)
                    GRIDYARN.Rows.Add(0, DTROW("YARNQUALITY"), "", DTROW("COLOR"), "", "", 0, Val(DTROW("WT")), 0)

NEXTLINE:
                Next
                getsrno(GRIDPROG)
                getsrno(GRIDYARN)

            End If

            CMDSELECTPROG.Enabled = True
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJONO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBJONO.Validating
        Try
            If Val(CMBJONO.Text) > 0 Then

                Dim OBJCMN As New ClsCommon
                'FILL COMBO WHICH HAS BEEN OUT

                'FOR OPENING
                'IF USER HAS NOT WRITTEN BILLNO THEN IT WONT BE SHOWN HERE
                'IF USER HAS WRITTEN LOTNO THEN IT WONT BE SHOWN HERE

                Dim DT As DataTable = OBJCMN.search(" (ISNULL(YARN_TOTALWT,0)-ISNULL(YARN_RECDWT,0)) AS BALANCEWT, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PROCESS_NAME,'') AS PROCESS ", "", "YARNISSUE INNER JOIN LEDGERS ON YARNISSUE.YARN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN PROCESSMASTER ON YARN_PROCESSID = PROCESS_ID", " AND (ISNULL(YARN_TOTALWT,0)-ISNULL(YARN_RECDWT,0)) > 0 AND YARNISSUE.YARN_CLOSE=0 AND ISNULL(YARNISSUE.YARN_NO,'')='" & CMBJONO.Text.Trim & "' AND ISNULL(LEDGERS.Acc_cmpname,'')='" & CMBTONAME.Text.Trim & "' AND YARNISSUE.YARN_YEARID=" & YearId)

                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("BALANCEWT") > 0 Then
                        CMBJONO.Enabled = False
                        TXTBALWT.Text = Format(Val(DT.Rows(0).Item("BALANCEWT")), "0.00")
                        CMBPROCESS.Text = DT.Rows(0).Item("PROCESS")
                    Else
                        MsgBox("Challan Already Cleared", MsgBoxStyle.Critical)
                        e.Cancel = True
                        CMBJONO.Text = ""
                        Exit Sub
                    End If
                Else
                    MsgBox("Invalid Challan No !", MsgBoxStyle.Critical)
                    e.Cancel = True
                    CMBJONO.Text = ""
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTONAME.Validated
        Try
            If EDIT = False And CMBTONAME.Text.Trim <> "" Then
                CMBJONO.Items.Clear()
                'FILL JOBOUT NO
                'IF USER HAS NOT WRITTEN BILLNO THEN IT WONT BE SHOWN HERE
                'IF USER HAS WRITTEN LOTNO THEN IT WONT BE SHOWN HERE
                Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" JONO ", "", " (SELECT JOBOUT.JO_no AS JONO FROM JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id WHERE LEDGERS.Acc_CMPNAME='" & cmbname.Text.Trim & "' AND ROUND((JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS),2) > 0 AND JOBOUT.JO_CLOSE=0 AND JOBOUT.JO_YEARID = " & YearId & " UNION ALL SELECT DISTINCT SM_BILLNO AS JONO FROM STOCKMASTER INNER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERIDTO= LEDGERS.Acc_id WHERE LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ROUND((SM_MTRS - SM_OUTMTRS),2) > 0 AND SM_BILLNO <> 0 AND (SM_LOTNO = '' or SM_LOTNO = 0) AND SM_YEARID = " & YearId & ") AS T", "")
                Dim DT As DataTable = OBJCMN.search(" ISNULL(YARN_NO,0) AS JONO, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME ", "", " YARNISSUE INNER JOIN LEDGERS ON YARNISSUE.YARN_ledgerid = LEDGERS.Acc_id", " AND (ISNULL(YARN_TOTALWT,0)-ISNULL(YARN_RECDWT,0)) > 0 AND YARNISSUE.YARN_CLOSE=0 AND ISNULL(LEDGERS.Acc_cmpname,'')='" & CMBTONAME.Text.Trim & "' AND YARNISSUE.YARN_CMPID=" & CmpId & " AND YARNISSUE.YARN_YEARID=" & YearId)

                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        CMBJONO.Items.Add(DTROW("JONO"))
                    Next
                    CMBTONAME.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCONES.Validated
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Enter(sender As Object, e As EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(sender As Object, e As CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class