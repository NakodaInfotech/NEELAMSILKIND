
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL

Public Class YarnRecd

    Dim GRIDDOUBLECLICK, GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPYARNNO As Integer     'used for poation no while editing
    Dim TEMPROW, TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim PARTYCHALLANNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        EP.Clear()
        YARNDATE.Text = Now.Date
        CMBNAME.Enabled = True
        CMBNAME.Text = ""
        CMBDELIVERYAT.Text = ""
        TXTPONO.Clear()
        PODATE.Value = Now.Date
        CHALLANDATE.Value = Now.Date
        TXTCHALLANNO.Clear()
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        CMBFROMGODOWN.Text = ""
        CMBTRANSPORT.Text = ""
        CMBFREIGHT.Text = ""

        TXTVEHICLENO.Clear()
        CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""
        TXTEWAYBILLNO.Clear()
        TXTSUBTOTAL.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTROUNDOFF.Clear()
        TXTGRANDTOTAL.Clear()

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

        TXTSRNO.Text = 1
        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBCOLOR.Text = ""
        TXTGRIDLOTNO.Clear()
        TXTBOXNO.Clear()
        TXTQTY.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTLRNO.Clear()
        DTLRDATE.Value = Now.Date
        GRIDYARN.RowCount = 0

        GRIDORDER.RowCount = 0

        CMDSELECTPO.Enabled = True
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

            'GET AMOUNT AND GST VALUES
            If TXTEWAYBILLNO.Text.Trim = "" And CMBNAME.Text.Trim <> "" And GRIDYARN.RowCount > 0 Then
                TXTCGSTPER.Text = 0
                TXTCGSTAMT.Clear()
                TXTSGSTPER.Text = 0
                TXTSGSTAMT.Clear()
                TXTIGSTPER.Text = 0
                TXTIGSTAMT.Clear()
                If CHKMANUALAMT.Checked = False Then TXTSUBTOTAL.Clear()
                TXTROUNDOFF.Clear()
                TXTGRANDTOTAL.Clear()


                'GST HSN OF 1ST ENTRY
                Dim OBJCMN As New ClsCommon
                Dim DTHSN As DataTable = OBJCMN.Execute_Any_String(" SELECT ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER FROM HSNMASTER INNER JOIN YARNQUALITYMASTER ON HSN_ID = YARN_HSNCODEID WHERE YARN_NAME = '" & GRIDYARN.Rows(0).Cells(GYARNQUALITY.Index).Value & "' AND YARN_YEARID = " & YearId, "", "")
                If DTHSN.Rows.Count > 0 Then
                    'CHECK STATECODE OF PARTY AND ACCORDINGLY SET GSTPER
                    Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(CAST(STATE_REMARK AS VARCHAR(10)),'') AS STATECODE FROM LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATEMASTER.STATE_ID WHERE LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId, "", "")
                    If DT.Rows(0).Item("STATECODE") = CMPSTATECODE Then
                        TXTCGSTPER.Text = Val(DTHSN.Rows(0).Item("CGSTPER"))
                        TXTSGSTPER.Text = Val(DTHSN.Rows(0).Item("SGSTPER"))
                    Else
                        TXTIGSTPER.Text = Val(DTHSN.Rows(0).Item("IGSTPER"))
                    End If
                End If


                'FETCH RATES OF ALL QUALITY FROM YARNQYALITY AND GET THE TOTAL AMOUNT
                If CHKMANUALAMT.Checked = False Then
                    For Each ROW As DataGridViewRow In GRIDYARN.Rows
                        Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(YARN_RATE,0) AS YARNRATE FROM YARNQUALITYMASTER WHERE YARN_NAME = '" & ROW.Cells(GYARNQUALITY.Index).Value & "' AND YARN_YEARID = " & YearId, "", "")
                        If DT.Rows.Count > 0 Then
                            TXTSUBTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + (Val(DT.Rows(0).Item("YARNRATE")) * Val(ROW.Cells(GWT.Index).Value)), "0.00")
                        End If
                    Next
                End If

                TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text.Trim) * Val(TXTSUBTOTAL.Text.Trim)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text.Trim) * Val(TXTSUBTOTAL.Text.Trim)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text.Trim) * Val(TXTSUBTOTAL.Text.Trim)) / 100, "0.00")

                TXTGRANDTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0")
                TXTROUNDOFF.Text = Format(Val(TXTGRANDTOTAL.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)), "0.00")
                TXTGRANDTOTAL.Text = Format(Val(TXTGRANDTOTAL.Text), "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub GRNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YARNDATE.GotFocus
        YARNDATE.SelectAll()
    End Sub

    Private Sub GRNDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YARNDATE.Validating
        Try
            If YARNDATE.Text.Trim <> "__/__/____" Then
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
        Dim DTTABLE As DataTable = getmax(" isnull(max(YARN_NO),0) + 1 ", "YARNRECD", " And YARN_yearid= " & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTYARNNO.Text = Val(DTTABLE.Rows(0).Item(0))
    End Sub

    Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True
        Try

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Company Name ")
                BLN = False
            End If

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown Name ")
                BLN = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Entry Locked")
                BLN = False
            End If

            If GRIDYARN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                BLN = False
            End If


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    DT = objclscommon.search(" YARNRECD.YARN_challanno, LEDGERS.ACC_cmpname", "", " YARNRECD inner join LEDGERS On LEDGERS.ACC_id = YARNRECD.YARN_ledgerid ", " And YARNRECD.YARN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND YARNRECD.YARN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        BLN = False
                    End If
                End If
            End If


            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(ORECDBAGS.Index).Value = 0
                    ORDROW.Cells(ORECDWT.Index).Value = 0
                Next

                'GET MULTISONO
                Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OFROMNO.Index).Value)).Distinct.ToArray
                TXTPONO.Clear()
                For Each a As String In MULTISONO
                    If TXTPONO.Text = "" Then
                        TXTPONO.Text = a
                    Else
                        TXTPONO.Text = TXTPONO.Text & "," & a
                    End If
                Next

                For Each ROW As DataGridViewRow In GRIDYARN.Rows
                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                        If ROW.Cells(GYARNQUALITY.Index).Value = ORDROW.Cells(OYARNQUALITY.Index).Value And ROW.Cells(gcolor.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
                            TEMPORDERMATCH = True
                            'IF ITEM / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                            If Val(ORDROW.Cells(ORECDWT.Index).Value) >= Val(ORDROW.Cells(OWT.Index).Value) Then
                                TEMPORDERROWNO = ORDROW.Index
                                GoTo CHECKNEXTLINE
                            End If
                            ORDROW.Cells(ORECDBAGS.Index).Value = Val(ORDROW.Cells(ORECDBAGS.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                            ORDROW.Cells(ORECDWT.Index).Value = Val(ORDROW.Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                            TEMPORDERROWNO = -1
                            Exit For
CHECKNEXTLINE:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPORDERROWNO >= 0 Then
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDBAGS.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDBAGS.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDWT.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                        TEMPORDERROWNO = -1
                    End If
                    If TEMPORDERMATCH = False Then
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen
                        If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            EP.SetError(CMBNAME, "There are Items which are not Present in Selected Order")
                            BLN = False
                        End If
                    End If
                    TEMPORDERMATCH = False
                Next
            End If


            If YARNDATE.Text = "__/__/____" Then
                EP.SetError(YARNDATE, " Please Enter Proper Date")
                BLN = False
            Else
                If Not datecheck(YARNDATE.Text) Then
                    EP.SetError(YARNDATE, "Date not in Accounting Year")
                    BLN = False
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
        Return BLN
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()

            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTPONO.Text.Trim)
            alParaval.Add(Format(PODATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Format(CHALLANDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBTRANSPORT.Text.Trim)
            alParaval.Add(CMBFREIGHT.Text.Trim)

            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALCONES.Text))

            alParaval.Add(CMBFROMGODOWN.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(CMBFROMCITY.Text.Trim)
            alParaval.Add(CMBTOCITY.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)
            alParaval.Add(Val(TXTSUBTOTAL.Text))
            alParaval.Add(Val(TXTCGSTPER.Text))
            alParaval.Add(Val(TXTCGSTAMT.Text))
            alParaval.Add(Val(TXTSGSTPER.Text))
            alParaval.Add(Val(TXTSGSTAMT.Text))
            alParaval.Add(Val(TXTIGSTPER.Text))
            alParaval.Add(Val(TXTIGSTAMT.Text))
            alParaval.Add(Val(TXTROUNDOFF.Text))
            alParaval.Add(Val(TXTGRANDTOTAL.Text))


            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim COLOR As String = ""
            Dim BOXNO As String = ""
            Dim GRIDLOTNO As String = ""
            Dim QTY As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""
            Dim LRNO As String = ""
            Dim LRDATE As String = ""
            Dim DONE As String = ""
            Dim PONO As String = ""
            Dim POGRIDSRNO As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BOXNO = row.Cells(GBOXNO.Index).Value.ToString
                        GRIDLOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)
                        LRNO = row.Cells(GLRNO.Index).Value.ToString
                        LRDATE = Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0
                        PONO = Val(row.Cells(GPONO.Index).Value)
                        POGRIDSRNO = Val(row.Cells(GGRIDSRNO.Index).Value)

                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BOXNO = BOXNO & "|" & row.Cells(GBOXNO.Index).Value.ToString
                        GRIDLOTNO = GRIDLOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)
                        LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value
                        LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")
                        If row.Cells(GDONE.Index).Value = True Then DONE = DONE & "|" & "1" Else DONE = DONE & "|" & "0"
                        PONO = PONO & "|" & Val(row.Cells(GPONO.Index).Value)
                        POGRIDSRNO = POGRIDSRNO & "|" & Val(row.Cells(GGRIDSRNO.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(COLOR)
            alParaval.Add(BOXNO)
            alParaval.Add(GRIDLOTNO)
            alParaval.Add(QTY)
            alParaval.Add(WT)
            alParaval.Add(CONES)
            alParaval.Add(LRNO)
            alParaval.Add(LRDATE)
            alParaval.Add(DONE)
            alParaval.Add(PONO)
            alParaval.Add(POGRIDSRNO)


            Dim ORDERGRIDSRNO As String = ""
            Dim ORDERYARNQUALITY As String = ""
            Dim ORDERCOLOR As String = ""
            Dim ORDERBAGS As String = ""
            Dim ORDERWT As String = ""
            Dim ORDERFROMNO As String = ""
            Dim ORDERFROMSRNO As String = ""
            Dim ORDERFROMTYPE As String = ""
            Dim ORDERRECDBAGS As String = ""
            Dim ORDERRECDWT As String = ""
            Dim ORDERRATE As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(0).Value <> Nothing AndAlso Val(row.Cells(ORECDWT.Index).Value) > 0 Then

                    If ORDERGRIDSRNO = "" Then
                        ORDERGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        ORDERYARNQUALITY = row.Cells(OYARNQUALITY.Index).Value.ToString
                        ORDERCOLOR = row.Cells(OCOLOR.Index).Value.ToString
                        ORDERBAGS = Val(row.Cells(OBAGS.Index).Value)
                        ORDERWT = Val(row.Cells(OWT.Index).Value)
                        ORDERFROMNO = Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERRECDBAGS = Val(row.Cells(ORECDBAGS.Index).Value)
                        ORDERRECDWT = Val(row.Cells(ORECDWT.Index).Value)
                        ORDERRATE = Val(row.Cells(ORATE.Index).Value)
                    Else
                        ORDERGRIDSRNO = ORDERGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        ORDERYARNQUALITY = ORDERYARNQUALITY & "|" & row.Cells(OYARNQUALITY.Index).Value.ToString
                        ORDERCOLOR = ORDERCOLOR & "|" & row.Cells(OCOLOR.Index).Value.ToString
                        ORDERBAGS = ORDERBAGS & "|" & Val(row.Cells(OBAGS.Index).Value)
                        ORDERWT = ORDERWT & "|" & Val(row.Cells(OWT.Index).Value)
                        ORDERFROMNO = ORDERFROMNO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = ORDERFROMSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = ORDERFROMTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERRECDBAGS = ORDERRECDBAGS & "|" & Val(row.Cells(ORECDBAGS.Index).Value)
                        ORDERRECDWT = ORDERRECDWT & "|" & Val(row.Cells(ORECDWT.Index).Value)
                        ORDERRATE = ORDERRATE & "|" & Val(row.Cells(ORATE.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(ORDERGRIDSRNO)
            alParaval.Add(ORDERYARNQUALITY)
            alParaval.Add(ORDERCOLOR)
            alParaval.Add(ORDERBAGS)
            alParaval.Add(ORDERWT)
            alParaval.Add(ORDERFROMNO)
            alParaval.Add(ORDERFROMSRNO)
            alParaval.Add(ORDERFROMTYPE)
            alParaval.Add(ORDERRECDBAGS)
            alParaval.Add(ORDERRECDWT)
            alParaval.Add(ORDERRATE)


            Dim objclsGRN As New ClsYarnRecd()
            objclsGRN.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsGRN.SAVE()
                TXTYARNNO.Text = Val(DTTABLE.Rows(0).Item(0))
                MsgBox("Details Added")

                GENERATEEWB()
                PRINTEWB()

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
            EDIT = False

            CLEAR()
            CMBNAME.Focus()

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
                        LRNO = row.Cells(GLRNO.Index).Value.ToString
                        LRDATE = Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")


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
                        LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value
                        LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")

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
            Dim OBJBILL As New ClsYarnRecd


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPYARNNO)
                    'ALPARAVAL.Add(TEMPREGNAME)
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
        ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.D1 Then
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.D2 Then
            TabControl1.SelectedIndex = (1)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.D3 Then
            TabControl1.SelectedIndex = (2)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDYARN.Focus()
        End If
    End Sub

    Private Sub GRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
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

                Dim OBJYARN As New ClsYarnRecd()
                Dim DTTABLE As DataTable = OBJYARN.SELECTYARN(TEMPYARNNO, YearId)

                If DTTABLE.Rows.Count > 0 Then

                    For Each dr As DataRow In DTTABLE.Rows

                        TXTYARNNO.Text = TEMPYARNNO
                        YARNDATE.Text = Format(Convert.ToDateTime(dr("YARNDATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim
                        CMBFREIGHT.Text = dr("FREIGHT")

                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        TXTPONO.Text = Convert.ToString(dr("PONO").ToString)
                        PODATE.Value = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")


                        CMBTRANSPORT.Text = dr("TRANSNAME").ToString


                        CMBFROMGODOWN.Text = dr("FROMGODOWN")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        CMBFROMCITY.Text = dr("FROMCITY")
                        CMBTOCITY.Text = dr("TOCITY")
                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")

                        TXTSUBTOTAL.Text = Val(dr("SUBTOTAL"))
                        TXTCGSTPER.Text = Val(dr("CGSTPER"))
                        TXTCGSTAMT.Text = Val(dr("CGSTAMT"))
                        TXTSGSTPER.Text = Val(dr("SGSTPER"))
                        TXTSGSTAMT.Text = Val(dr("SGSTAMT"))
                        TXTIGSTPER.Text = Val(dr("IGSTPER"))
                        TXTIGSTAMT.Text = Val(dr("IGSTAMT"))
                        TXTROUNDOFF.Text = Val(dr("ROUNDOFF"))
                        TXTGRIDLOTNO.Text = Val(dr("GRANDTOTAL"))


                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)
                        GRIDYARN.Rows.Add(Val(dr("GRIDSRNO")), dr("YARNQUALITY"), dr("MILLNAME"), dr("COLOR"), dr("BOXNO"), dr("GRIDLOTNO"), Format(dr("QTY"), "0"), Format(dr("WT"), "0.00"), Format(dr("CONES"), "0"), dr("LRNO"), Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy"), dr("DONE").ToString, Val(dr("OUTPCS")), Val(dr("OUTMTRS")), dr("GRIDPONO").ToString, dr("POGRIDSRNO").ToString)

                    Next
                    CMDSELECTPO.Enabled = False
                    TOTAL()
                    Validate()
                Else
                    EDIT = False
                    CLEAR()
                End If

                Dim OBJCMN As New ClsCommon
                DTTABLE = OBJCMN.search(" YARNRECD_UPLOAD.YARN_SRNO AS GRIDSRNO, YARNRECD_UPLOAD.YARN_REMARKS AS REMARKS, YARNRECD_UPLOAD.YARN_NAME AS NAME, YARNRECD_UPLOAD.YARN_PHOTO AS IMGPATH ", "", " YARNRECD_UPLOAD ", " AND YARNRECD_UPLOAD.YARN_NO = " & TEMPYARNNO & " AND YARN_YEARID = " & YearId & " ORDER BY YARNRECD_UPLOAD.YARN_SRNO")
                If DTTABLE.Rows.Count > 0 Then
                    For Each DTR As DataRow In DTTABLE.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                    Next
                End If

                'ORDER GRID
                'Dim OBJCMN As New ClsCommon
                DTTABLE = OBJCMN.search(" YARNRECD_PODETAILS.YARN_GRIDSRNO AS GRIDSRNO, YARNQUALITYMASTER.YARN_name AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, YARNRECD_PODETAILS.YARN_ORDERBAGS AS ORDERBAGS, ISNULL(YARNRECD_PODETAILS.YARN_ORDERWT,0) AS ORDERWT, YARNRECD_PODETAILS.YARN_FROMNO AS FROMNO, YARNRECD_PODETAILS.YARN_FROMSRNO AS FROMSRNO, YARNRECD_PODETAILS.YARN_FROMTYPE AS FROMTYPE, YARNRECD_PODETAILS.YARN_BAGS AS RECDBAGS, ISNULL(YARNRECD_PODETAILS.YARN_WT,0) AS RECDWT, ISNULL(YARNRECD_PODETAILS.YARN_RATE,0) AS RATE ", "", " YARNRECD_PODETAILS INNER JOIN YARNQUALITYMASTER ON YARNRECD_PODETAILS.YARN_YARNQUALITYID= YARNQUALITYMASTER.YARN_id LEFT OUTER JOIN COLORMASTER ON YARNRECD_PODETAILS.YARN_COLORID = COLORMASTER.COLOR_id ", " AND YARNRECD_PODETAILS.YARN_NO = " & TEMPYARNNO & " AND YARNRECD_PODETAILS.YARN_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then
                    For Each DTR As DataRow In DTTABLE.Rows
                        GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("YARNQUALITY"), DTR("COLOR"), Val(DTR("ORDERBAGS")), Val(DTR("ORDERWT")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("RECDBAGS")), Val(DTR("RECDWT")), Val(DTR("RATE")))
                    Next
                End If
                getsrno(GRIDORDER)

                If TXTPONO.Text.Trim.Trim.Length = 0 Then
                    CMDSELECTPO.Enabled = False
                    CMBNAME.Enabled = True
                Else
                    CMDSELECTPO.Enabled = True
                    CMBNAME.Enabled = False
                End If

            End If

            TXTSRNO.Text = GRIDYARN.RowCount + 1

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBFROMGODOWN.Text.Trim = "" Then fillGODOWN(CMBFROMGODOWN, EDIT)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If CMBDELIVERYAT.Text.Trim = "" Then fillname(CMBDELIVERYAT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLYARNCOLOR(CMBCOLOR, CMBYARNQUALITY.Text.Trim)
            fillCITY(CMBFROMCITY, EDIT)
            fillCITY(CMBTOCITY, EDIT)

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

    Private Sub cmbGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGODOWN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectGodown
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBGODOWN.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMGODOWN.Enter
        Try
            If CMBFROMGODOWN.Text.Trim = "" Then fillGODOWN(CMBFROMGODOWN, EDIT)
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
            Dim OBJYARN As New YarnRecdDetails
            OBJYARN.MdiParent = MDIMain
            OBJYARN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORT.Enter
        Try
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORT.Validating
        Try
            If CMBTRANSPORT.Text.Trim <> "" Then namevalidate(CMBTRANSPORT, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")
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
                    dt = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
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

    Private Sub dtpchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHALLANDATE.Validating
        If Not datecheck(CHALLANDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTPO.Click
        Try

            If CMBNAME.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim DTPO As New DataTable
            Dim OBJSELECTPO As New SelectYarnPO
            OBJSELECTPO.PARTYNAME = CMBNAME.Text.Trim
            OBJSELECTPO.DELIVERYAT = CMBDELIVERYAT.Text.Trim
            OBJSELECTPO.ShowDialog()
            DTPO = OBJSELECTPO.DT

            If DTPO.Rows.Count > 0 Then

                ''  GETTING DISTINCT PONO NO IN TEXTBOX
                Dim DV As DataView = DTPO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "PONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTPONO.Text.Trim = "" Then
                        TXTPONO.Text = DTR("PONO").ToString
                    Else
                        TXTPONO.Text = TXTPONO.Text & "," & DTR("PONO").ToString
                    End If
                Next

                fillledger(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = '" & DTPO.Rows(0).Item("GROUPNAME") & "' ")
                CMBNAME.Text = DTPO.Rows(0).Item("NAME")
                PODATE.Value = DTPO.Rows(0).Item("PODATE")
                TXTPONO.Enabled = False


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTPO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("PONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next

                    GRIDORDER.Rows.Add(0, DTROW("YARNQUALITY"), DTROW("COLOR"), Val(DTROW("BAGS")), Val(DTROW("WT")), DTROW("PONO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0, 0, Val(DTROW("RATE")))
                    GRIDYARN.Rows.Add(0, DTROW("YARNQUALITY"), DTROW("MILLNAME"), DTROW("COLOR"), "", "", Val(DTROW("BAGS")), Val(DTROW("WT")), 0, 0, Now.Date, 0, 0, 0, DTROW("PONO"), DTROW("GRIDSRNO"))
NEXTLINE:
                Next
                getsrno(GRIDORDER)
                getsrno(GRIDYARN)

            End If

            CMDSELECTPO.Enabled = True
            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try

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

    Sub FILLGRID()

        GRIDYARN.Enabled = True

        Dim TEMPQTY As Integer = Val(TXTQTY.Text.Trim)
        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(TXTSRNO.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBCOLOR.Text.Trim, TXTBOXNO.Text.Trim, TXTGRIDLOTNO.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0"), TXTLRNO.Text.Trim, Format(DTLRDATE.Value.Date, "dd/MM/yyyy"), 0, 0, 0, 0, 0)
            getsrno(GRIDYARN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDYARN.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDYARN.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDYARN.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim
            GRIDYARN.Item(gcolor.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDYARN.Item(GBOXNO.Index, TEMPROW).Value = TXTBOXNO.Text.Trim
            GRIDYARN.Item(GLOTNO.Index, TEMPROW).Value = TXTGRIDLOTNO.Text.Trim
            GRIDYARN.Item(GQTY.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0")
            GRIDYARN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            GRIDYARN.Item(GCONES.Index, TEMPROW).Value = Format(Val(TXTCONES.Text.Trim), "0")
            GRIDYARN.Item(GLRNO.Index, TEMPROW).Value = TXTLRNO.Text.Trim
            GRIDYARN.Item(GLRDATE.Index, TEMPROW).Value = Format(DTLRDATE.Value.Date, "dd/MM/yyyy")


            GRIDDOUBLECLICK = False

        End If

        TOTAL()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBCOLOR.Text = ""
        TXTBOXNO.Clear()
        TXTGRIDLOTNO.Clear()
        TXTQTY.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTLRNO.Clear()
        DTLRDATE.Value = Now.Date

        TXTSRNO.Text = GRIDYARN.RowCount + 1
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
                TXTSRNO.Text = GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBYARNQUALITY.Text = GRIDYARN.Item(GYARNQUALITY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBMILL.Text = GRIDYARN.Item(GMILLNAME.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                CMBCOLOR.Text = GRIDYARN.Item(gcolor.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTBOXNO.Text = GRIDYARN.Item(GBOXNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTGRIDLOTNO.Text = GRIDYARN.Item(GLOTNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDYARN.Item(GQTY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDYARN.Item(GWT.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTCONES.Text = GRIDYARN.Item(GCONES.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTLRNO.Text = GRIDYARN.Item(GLRNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                DTLRDATE.Text = GRIDYARN.Item(GLRDATE.Index, GRIDYARN.CurrentRow.Index).Value

                TEMPROW = GRIDYARN.CurrentRow.Index
                CMBYARNQUALITY.Focus()
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

    Private Sub podate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PODATE.Validating
        If Not datecheck(PODATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Dim IntResult As Integer
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
                If MsgBox("Delete Entry?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTYARNNO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim Clsgrn As New ClsYarnRecd()
                    Clsgrn.alParaval = alParaval
                    IntResult = Clsgrn.DELETE()
                    MsgBox("Yarn Deleted")
                    CLEAR()
                    EDIT = False
                End If
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
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDYARN.Rows.RemoveAt(GRIDYARN.CurrentRow.Index)
                getsrno(GRIDYARN)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
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
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", CMBTRANSPORT.Text, "")
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

    Private Sub CMBYARNQUALITY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Validated
        Try
            If CMBYARNQUALITY.Text = "" Then CMDOK.Focus()
        Catch ex As Exception
            Throw ex
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

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANSPORT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANSPORT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBCOLOR.Text = OBJCOLOR.TEMPNAME
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

    Sub PRINTREPORT(ByVal INVOICENO As Integer)
        Try
            If MsgBox("Wish To Print Recd Challan?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJGRN As New YarnDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "YARNRECDPUR"
                OBJGRN.WHERECLAUSE = " {YARNRECD.YARN_NO}= " & INVOICENO & "  AND {YARNRECD.YARN_YEARID}=" & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEWB_Click(sender As Object, e As EventArgs) Handles TOOLEWB.Click
        Try
            If EDIT = False Then Exit Sub
            GENERATEEWB()
            PRINTEWB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GENERATEEWB()
        Try
            If ALLOWEWAYBILL = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub
            If MsgBox("Generate E-Way Bill?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            If TXTCHALLANNO.Text.Trim = "" Then
                MsgBox("Enter Party Challan No", MsgBoxStyle.Critical)
                Exit Sub
            End If


            If CMBFROMCITY.Text.Trim = "" Then
                MsgBox("Enter From City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBTOCITY.Text.Trim = "" Then
                MsgBox("Enter to City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TXTEWAYBILLNO.Text.Trim <> "" Then
                MsgBox("E-Way Bill No Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            MsgBox("E-Way Bill will not be Generated if there are special characters like {*,/,""""} in Quality Name ", MsgBoxStyle.Critical)

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim TRANSGSTIN As String = ""
            Dim GODOWNPINCODE As String = ""
            Dim GODOWNKMS As Double = 0
            Dim GODOWNSTATENAME As String = ""
            Dim GODOWNSTATECODE As String = ""


            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_DISPATCHFROM, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2 ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            If CMBFROMGODOWN.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(GODOWN_PINCODE,'') AS PINCODE, ISNULL(GODOWN_KMS,0) AS KMS, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE ", "", " GODOWNMASTER LEFT OUTER JOIN STATEMASTER ON GODOWN_STATEID = STATE_ID ", " AND GODOWN_NAME = '" & CMBFROMGODOWN.Text.Trim & "' AND GODOWN_YEARID = " & YearId)
                If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                    MsgBox(" Godown Details are not filled properly ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    GODOWNPINCODE = DT.Rows(0).Item("PINCODE")
                    GODOWNKMS = Val(DT.Rows(0).Item("KMS"))
                    GODOWNSTATENAME = DT.Rows(0).Item("STATENAME")
                    GODOWNSTATECODE = DT.Rows(0).Item("STATECODE")
                End If
            Else
                MsgBox(" Please select Godown", MsgBoxStyle.Critical)
                Exit Sub
            End If




            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            If CMBTRANSPORT.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & CMBTRANSPORT.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
                If TRANSGSTIN = "" Then
                    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            'CHECKING COUNTER AND VALIDATE WHETHER EWAY BILL WILL BE ALLOWED OR NOT, FOR EACH EWAY BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EWB)
            If CMPEWAYCOUNTER = 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EWAYCOUNTER
            Dim USEDEWAYCOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EWAYCOUNT", "", "EWAYENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER <= 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EWAYEXPDATE Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE 1% THEN INTIMATE
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER < Format((CMPEWAYCOUNTER * 0.01), "0") Then
                MsgBox("Only " & (CMPEWAYCOUNTER - USEDEWAYCOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of EWB Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EWAY BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("https://gstsandbox.charteredinfo.com/ewaybillapi/dec/v1.03/auth?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&username=TaxProEnvPON&ewbpwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/auth?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTCHALLANNO.Text.Trim) & ",'YARNRECD','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                Exit Sub
            End If



            'GENERATING EWAY BILL 
            'FOR SANBOX TEST
            'Dim FURL As New Uri("https://gstsandbox.charteredinfo.com/ewaybillapi/dec/v1.03/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&username=TaxProEnvPON&authtoken=" & TOKEN)
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"


                Dim j As String = ""

                j = "{"
                j = j & """supplyType"":""I"","
                j = j & """subSupplyType"":""1"","
                j = j & """subSupplyDesc"":"""","
                j = j & """docType"":""INV"","
                j = j & """docNo"":""" & TXTCHALLANNO.Text.Trim & """" & ","
                j = j & """docDate"":""" & CHALLANDATE.Text & """" & ","

                j = j & """fromGstin"":""" & PARTYGSTIN & """" & ","
                j = j & """fromTrdName"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """fromAddr1"":""" & PARTYADD1 & """" & ","
                j = j & """fromAddr2"":""" & CMBFROMGODOWN.Text.Trim & """" & ","
                j = j & """fromPlace"":""" & CMBFROMGODOWN.Text.Trim & "-" & CMBFROMCITY.Text.Trim & """" & ","

                j = j & """fromPincode"":""" & GODOWNPINCODE & """" & ","
                j = j & """actFromStateCode"":""" & GODOWNSTATECODE & """" & ","
                j = j & """fromStateCode"":""" & GODOWNSTATECODE & """" & ","

                j = j & """toGstin"":""" & CMPGSTIN & """" & ","
                j = j & """toTrdName"":""" & CmpName & """" & ","
                j = j & """toAddr1"":""" & TEMPCMPADD1 & """" & ","
                j = j & """toAddr2"":""" & TEMPCMPADD2 & """" & ","
                j = j & """toPlace"":""" & CMBTOCITY.Text.Trim & """" & ","
                j = j & """toPincode"":""" & CMPPINCODE & """" & ","
                j = j & """actToStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """toStateCode"":""" & CMPSTATECODE & """" & ","

                j = j & """transactionType"":""4"","
                j = j & """dispatchFromGSTIN"":""" & PARTYGSTIN & """" & ","
                j = j & """dispatchFromTradeName"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """shipToGSTIN"":""" & CMPGSTIN & """" & ","
                j = j & """shipToTradeName"":""" & CmpName & """" & ","
                j = j & """otherValue"":""0"","


                If INVOICESCREENTYPE = "TOTAL GST" Then
                    j = j & """totalValue"":""" & Val(TXTSUBTOTAL.Text.Trim) & """" & ","
                    j = j & """cgstValue"":""" & Val(TXTCGSTAMT.Text.Trim) & """" & ","
                    j = j & """sgstValue"":""" & Val(TXTSGSTAMT.Text.Trim) & """" & ","
                    j = j & """igstValue"":""" & Val(TXTIGSTAMT.Text.Trim) & """" & ","
                End If

                j = j & """cessValue"":""" & "0" & """" & ","
                j = j & """cessNonAdvolValue"":""" & "0" & """" & ","
                j = j & """totInvValue"":""" & Val(TXTGRANDTOTAL.Text.Trim) & """" & ","
                j = j & """transporterId"":""" & TRANSGSTIN & """" & ","
                j = j & """transporterName"":""" & CMBTRANSPORT.Text.Trim & """" & ","


                If TXTVEHICLENO.Text.Trim = "" Then
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":"""","
                    j = j & """transDistance"":""" & GODOWNKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":"""","
                    j = j & """vehicleType"":"""","
                Else
                    j = j & """transDocNo"":""" & TXTLRNO.Text.Trim & """" & ","
                    j = j & """transMode"":""" & "1" & """" & ","
                    j = j & """transDistance"":""" & GODOWNKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                    j = j & """vehicleType"":""" & "R" & """" & ","
                End If


                j = j & """itemList"":[{"


                'WE NEED TO FETCH SUMMARY OF ITEMS AND HSN TO PASS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT ISNULL(YARNQUALITYMASTER.YARN_NAME,'') AS ITEMNAME, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGST, ISNULL(HSN_SGST,0) AS SGST, ISNULL(HSN_IGST,0) AS IGST, SUM(YARNRECD_DESC.YARN_WT) AS WT, ISNULL(YARNRECD.YARN_SUBTOTAL,0) AS TAXABLEAMT FROM YARNRECD INNER JOIN YARNRECD_DESC ON YARNRECD_DESC.YARN_YEARID = YARNRECD.YARN_YEARID AND YARNRECD_DESC.YARN_NO = YARNRECD.YARN_NO INNER JOIN YARNQUALITYMASTER ON YARNRECD_DESC.YARN_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID INNER JOIN HSNMASTER ON HSNMASTER.HSN_ID = YARNQUALITYMASTER.YARN_HSNCODEID WHERE YARNRECD.YARN_NO = " & Val(TEMPYARNNO) & " and YARNRECD.YARN_YEARID = " & YearId & " GROUP BY ISNULL(YARNQUALITYMASTER.YARN_NAME,''), ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0), ISNULL(YARNRECD.YARN_SUBTOTAL,0)", "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows
                    If CURRROW > 0 Then j = j & ",{"
                    j = j & """productName"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """productDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """hsnCode"":""" & DTROW("HSNCODE") & """" & ","
                    j = j & """quantity"":""" & Val(DTROW("WT")) & """" & ","
                    j = j & """qtyUnit"":""" & "KGS" & """" & ","
                    j = j & """cgstRate"":""" & Val(TXTCGSTPER.Text.Trim) & """" & ","
                    j = j & """sgstRate"":""" & Val(TXTSGSTPER.Text.Trim) & """" & ","
                    j = j & """igstRate"":""" & Val(TXTIGSTPER.Text.Trim) & """" & ","

                    j = j & """cessRate"":""" & "0" & """" & ","
                    j = j & """cessNonAdvol"":""" & "0" & """" & ","
                    j = j & """taxableAmount"":""" & Val(DTROW("TAXABLEAMT")) & """"
                    j = j & " }"
                    CURRROW += 1
                Next

                j = j & " ]}"

                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Generating EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTCHALLANNO.Text.Trim) & ",'YARNRECD','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()




            Dim EWBNO As String = ""

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ewayBillNo") + Len("ewayBillNo") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS)
            EWBNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            TXTEWAYBILLNO.Text = EWBNO

            'WE NEED TO UPDATE THIS EWBNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE YARNRECD SET YARN_EWAYBILLNO = '" & TXTEWAYBILLNO.Text.Trim & "' FROM YARNRECD WHERE YARN_NO = " & Val(TEMPYARNNO) & " AND YARN_YEARID = " & YearId, "", "")

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTCHALLANNO.Text.Trim) & ",'YARNRECD','" & TOKEN & "','" & EWBNO & "','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTEWB()
        Try

            If PRINTEWAYBILL = False Then Exit Sub
            If EDIT = False Then Exit Sub
            If TXTEWAYBILLNO.Text.Trim = "" Then Exit Sub


            If MsgBox("Print EWB?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim TOKENNO As String = ""
            Dim EWBNO As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TOKENNO, '') AS TOKENNO, ISNULL(EWBNO, '') AS EWBNO ", "", " EWAYENTRY ", " AND EWBNO = '" & TXTEWAYBILLNO.Text.Trim & "' And YearId = " & YearId)
            If DT.Rows.Count = 0 Then Exit Sub
            TOKENNO = DT.Rows(0).Item("TOKENNO")
            EWBNO = DT.Rows(0).Item("EWBNO")

            'Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/authenticate?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GetEwayBill&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&authtoken=" & TOKENNO & "&ewbNo=" & EWBNO)


            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)
            REQUEST.Method = "Get"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()
            Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(REQUESTEDTEXT)

            Dim FURL As New Uri("https://einvapi.charteredinfo.com/aspapi/v1.0/printewb?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/x-www-form-urlencoded"
                REQUEST.ContentLength = buffer.Length

                Dim stream As Stream = REQUEST.GetRequestStream()
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()
                Dim STRREADER As Stream = RESPONSE.GetResponseStream()
                Dim BINREADER As New BinaryReader(STRREADER)
                Dim BFFER As Byte() = BINREADER.ReadBytes(CInt(RESPONSE.ContentLength))
                File.WriteAllBytes(Application.StartupPath & "\EWB_" & TXTEWAYBILLNO.Text.Trim & ".pdf", BFFER)
                System.Diagnostics.Process.Start(Application.StartupPath & "\EWB_" & TXTEWAYBILLNO.Text.Trim & ".pdf")

                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTCHALLANNO.Text.Trim) & ",'YARNRECD','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTCHALLANNO.Text.Trim) & ",'YARNRECD','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Printing EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTCHALLANNO.Text.Trim) & ",'YARNRECD','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTCHALLANNO.Text.Trim) & ",'YARNRECD','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End Try

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

    Private Sub DTLRDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTLRDATE.Validated
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                FILLGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBFROMGODOWN_Validating(sender As Object, e As CancelEventArgs) Handles CMBFROMGODOWN.Validating
        Try
            If CMBFROMGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBFROMGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKMANUALAMT_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALAMT.CheckedChanged
        Try
            If CHKMANUALAMT.CheckState = CheckState.Checked Then
                TXTSUBTOTAL.ReadOnly = False
                TXTSUBTOTAL.BackColor = Color.White
            Else
                TXTSUBTOTAL.ReadOnly = True
                TXTSUBTOTAL.BackColor = Color.Linen
            End If
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSUBTOTAL_Validated(sender As Object, e As EventArgs) Handles TXTSUBTOTAL.Validated
        TOTAL()
    End Sub
End Class