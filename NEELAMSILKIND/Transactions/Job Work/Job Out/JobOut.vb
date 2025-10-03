
Imports BL
Imports System.IO
Imports System.Net

Public Class JobOut

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public TEMPJONO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim PARTYCHALLANNO As String
    Dim ALLOWMANUALJONO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        TXTJONO.Clear()

        If ALLOWMANUALJONO = True Then
            TXTJONO.ReadOnly = False
            TXTJONO.BackColor = Color.LemonChiffon
        Else
            TXTJONO.ReadOnly = True
            TXTJONO.BackColor = Color.Linen
        End If

        TXTTYPEJONO.Clear()
        If CMBTYPE.Items.Count > 0 Then
            CMBTYPE.Enabled = True
            CMBTYPE.SelectedIndex = 0
            GETMAXTYPEJONO()
        End If

        CMBNAME.Text = ""
        CMBPARTYNAME.Text = ""
        TXTCHALLANNO.Clear()
        CMBPROCESS.Text = ""
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        txtDeliveryadd.Clear()
        TXTADD.Clear()
        JODATE.Text = Now.Date
        tstxtbillno.Clear()
        CMBPACKING.Text = ""


        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Now.Date
        txtremarks.Clear()

        txtuploadsrno.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0

        CMDSELECTSTOCK.Enabled = True
        LBLCLOSED.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False



        LBLTOTALMTRS.Text = 0.0
        LBLTOTALPCS.Text = 0.0
        TXTBARCODE.Clear()
        TXTVEHICLENO.Clear()
        TXTEWAYBILLNO.Clear()
        TXTBALENUMBER.Clear()
        GRIDJO.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        getmaxno()

        TXTLOTNO.Clear()
        GRIDLOT.RowCount = 0
        txtuploadsrno.Text = 1


        txtsrno.Clear()
        CMBPIECETYPE.Text = "FRESH"
        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        TXTBALENO.Clear()
        CMBDESIGN.Text = ""
        CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""
        CMBPACKING.Text = ""
        cmbcolor.Text = ""
        TXTCUT.Clear()
        TXTDESCRIPTION.Clear()
        TXTPCS.Clear()
        TXTMTRS.Clear()
        TXTRATE.Clear()
        LBLRATE.Text = 0.0
        lbltotalwt.Text = 0.0

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            LBLRATE.Text = 0.0
            lbltotalwt.Text = 0.0

            Dim DONE As Boolean = False
            GRIDLOT.RowCount = 0


            For Each ROW As DataGridViewRow In GRIDJO.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = ROW.Cells(GPCS.Index).EditedFormattedValue * ROW.Cells(gcut.Index).EditedFormattedValue
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLRATE.Text = Format(Val(LBLRATE.Text) + Val(ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                    lbltotalwt.Text = Format(Val(lbltotalwt.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                End If

                DONE = False
                If Val(ROW.Cells(GMTRS.Index).EditedFormattedValue) > 0 Then
                    If GRIDLOT.RowCount = 0 Then
                        GRIDLOT.Rows.Add(ROW.Cells(GBALENO.Index).Value, Format(Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0"), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
                    Else
                        For Each SUMMROW As DataGridViewRow In GRIDLOT.Rows
                            If SUMMROW.Cells(DLOTNO.Index).Value = ROW.Cells(GBALENO.Index).Value Then
                                SUMMROW.Cells(DPCS.Index).Value = Val(SUMMROW.Cells(DPCS.Index).Value) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue)
                                SUMMROW.Cells(DMTRS.Index).Value = Val(SUMMROW.Cells(DMTRS.Index).Value) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue)
                                DONE = True
                            End If
                        Next
                        If DONE = False Then GRIDLOT.Rows.Add(ROW.Cells(GBALENO.Index).Value, Format(Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0"), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JO_no),0) + 1 ", " JOBOUT ", " AND JO_cmpid=" & CmpId & " and JO_locationid=" & Locationid & " and JO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTJONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Name")
                bln = False
            End If

            If CMBPROCESS.Text.Trim.Length = 0 Then
                EP.SetError(CMBPROCESS, " Select Process Name")
                bln = False
            End If

            If LBLCLOSED.Visible = True Then
                EP.SetError(LBLCLOSED, " Issue Closed")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDJO.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim DT As DataTable = objclscommon.search(" JO_challanno, LEDGERS.ACC_cmpname", "", " JOBOUT inner join LEDGERS on LEDGERS.ACC_id = JO_ledgerid ", " and JO_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND JO_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If


            If JODATE.Text = "__/__/____" Then
                EP.SetError(JODATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(JODATE.Text) Then
                    EP.SetError(JODATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If Val(TXTJONO.Text.Trim) = 0 Then
                EP.SetError(TXTJONO, "Enter Job Out No")
                bln = False
            End If

            If ALLOWMANUALJONO = True Then
                If TXTJONO.Text <> "" And CMBNAME.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBOUT.JO_NO,0)  AS JONO", "", " JOBOUT ", "  AND JOBOUT.JO_NO=" & TXTJONO.Text.Trim & " AND JOBOUT.JO_CMPID = " & CmpId & " AND JOBOUT.JO_LOCATIONID = " & Locationid & " AND JOBOUT.JO_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTJONO, "Job Out No Already Exist")
                        bln = False
                    End If
                End If
            End If

            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                If CMBTYPE.Text.Trim = "" Then
                    EP.SetError(CMBTYPE, " Please Select Job Out Type")
                    bln = False
                End If

                If Val(TXTTYPEJONO.Text.Trim) = 0 Then
                    EP.SetError(CMBTYPE, " Please Select Job Out Type")
                    bln = False
                End If
            End If


            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTJONO.ReadOnly = False Then
                alParaval.Add(Val(TXTJONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(JODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(CMBPARTYNAME.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(CMBFROMCITY.Text.Trim)
            alParaval.Add(CMBTOCITY.Text.Trim)
            alParaval.Add(CMBPACKING.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)
            alParaval.Add(TXTBALENUMBER.Text.Trim)
            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(lbltotalwt.Text))
            alParaval.Add(Val(LBLRATE.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)




            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim BALENO As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim DESCRIPTION As String = ""
            Dim CUT As String = ""
            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim RATE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED

            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            Dim FRAMES As String = ""
            Dim EMBPRODDONE As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDJO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = row.Cells(GBALENO.Index).Value.ToString Else BALENO = ""
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        If row.Cells(GDESCRIPTION.Index).Value <> Nothing Then DESCRIPTION = row.Cells(GDESCRIPTION.Index).Value.ToString Else DESCRIPTION = ""
                        If ClientName <> "PURVITEX" And ClientName <> "BARKHA" And ClientName <> "MANAS" Then
                            If Val(row.Cells(gcut.Index).Value) = 0 Then CUT = Format(Val(row.Cells(GMTRS.Index).Value) / Val(row.Cells(GPCS.Index).Value), "0.00") Else CUT = Val(row.Cells(gcut.Index).Value)
                        ElseIf ClientName = "BARKHA" Then
                            CUT = Val(row.Cells(gcut.Index).Value)
                        Else
                            CUT = 0
                        End If
                        PCS = Val(row.Cells(GPCS.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        FRAMES = Val(row.Cells(GFRAMES.Index).Value)
                        EMBPRODDONE = row.Cells(GEMBPRODDONE.Index).Value

                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString

                        If row.Cells(GDESCRIPTION.Index).Value <> Nothing Then DESCRIPTION = DESCRIPTION & "|" & row.Cells(GDESCRIPTION.Index).Value.ToString Else DESCRIPTION = DESCRIPTION & "|" & ""
                        If ClientName <> "PURVITEX" And ClientName <> "BARKHA" And ClientName <> "MANAS" Then
                            If Val(row.Cells(gcut.Index).Value) = 0 Then CUT = CUT & "|" & Format(Val(row.Cells(GMTRS.Index).Value) / Val(row.Cells(GPCS.Index).Value), "0.00") Else CUT = CUT & "|" & Val(row.Cells(gcut.Index).Value)
                        ElseIf ClientName = "BARKHA" Then
                            CUT = CUT & "|" & Val(row.Cells(gcut.Index).Value)
                        Else
                            CUT = CUT & "|" & 0
                        End If
                        PCS = PCS & "|" & Val(row.Cells(GPCS.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = OUTPCS & "|" & Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = OUTMTRS & "|" & Val(row.Cells(GOUTMTRS.Index).Value)
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString

                        FRAMES = FRAMES & "|" & Val(row.Cells(GFRAMES.Index).Value)
                        EMBPRODDONE = EMBPRODDONE & "|" & row.Cells(GEMBPRODDONE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(BALENO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(DESCRIPTION)
            alParaval.Add(CUT)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(RATE)
            alParaval.Add(BARCODE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)

            alParaval.Add(FRAMES)
            alParaval.Add(EMBPRODDONE)

            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As System.WINDOWS.FORMS.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)

            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(Val(TXTTYPEJONO.Text.Trim))

            Dim objCUTTING As New ClsCuttingIssue()
            objCUTTING.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objCUTTING.SAVE()
                MsgBox("Details Added")

                If ClientName = "SVS" Then
                    If MsgBox("Wish to Stock Reco Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        RECOSAVE()
                    End If
                End If

                TXTJONO.Text = DTTABLE.Rows(0).Item(0)
                If ClientName <> "MJFABRIC" Then PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPJONO)
                IntResult = objCUTTING.Update()
                MsgBox("Details Updated")
                If ClientName <> "MJFABRIC" Then PRINTREPORT(TEMPJONO)
                EDIT = False
            End If

            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next

            clear()
            JODATE.Focus()




        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub RECOSAVE()
        Try

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(JODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)


            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            'alParaval.Add(Val(LBLRATE.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            'Dim RATE As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""


            Dim PRESENT As Boolean = False
            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDJO.Rows
                Dim objclscommon As New ClsCommonMaster
                Dim dt1 As DataTable = objclscommon.search(" ISNULL(MTRS,0) AS MTRS ", "", " BARCODESTOCK", " AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND FROMNO= " & Val(row.Cells(GFROMNO.Index).Value) & " AND FROMSRNO= " & Val(row.Cells(GFROMSRNO.Index).Value) & " AND TYPE='" & row.Cells(GFROMTYPE.Index).Value & "' AND Yearid = " & YearId)
                If dt1.Rows.Count > 0 Then
                    If Val(dt1.Rows(0).Item(0)) <= 3 Then
                        PRESENT = True
                        TEMPMTRS = Val(dt1.Rows(0).Item(0))
                        If gridsrno = "" Then
                            gridsrno = row.Cells(GSRNO.Index).Value.ToString
                            PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                            ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                            QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = row.Cells(GCOLOR.Index).Value.ToString
                            PCS = row.Cells(GPCS.Index).Value.ToString
                            MTRS = TEMPMTRS
                            'RATE = row.Cells(GRATE.Index).Value.ToString
                            BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                            FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                            FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                            FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        Else
                            gridsrno = gridsrno & "," & row.Cells(GSRNO.Index).Value.ToString
                            PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value.ToString
                            ITEMNAME = ITEMNAME & "," & row.Cells(GMERCHANT.Index).Value.ToString
                            QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = COLOR & "," & row.Cells(GCOLOR.Index).Value.ToString
                            PCS = PCS & "," & row.Cells(GPCS.Index).Value.ToString
                            MTRS = MTRS & "," & TEMPMTRS
                            'RATE = RATE & "," & row.Cells(GRATE.Index).Value.ToString
                            BARCODE = BARCODE & "," & row.Cells(GBARCODE.Index).Value.ToString
                            FROMNO = FROMNO & "," & row.Cells(GFROMNO.Index).Value.ToString
                            FROMSRNO = FROMSRNO & "," & row.Cells(GFROMSRNO.Index).Value.ToString
                            FROMTYPE = FROMTYPE & "," & row.Cells(GFROMTYPE.Index).Value.ToString
                        End If

                    End If
                End If
            Next


            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            'alParaval.Add(RATE)
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim objclsPurord As New ClsStockAdjustment()
            objclsPurord.alParaval = alParaval

            If PRESENT = True Then Dim DT As DataTable = objclsPurord.SAVE()
            MsgBox("Reco done Successfully!")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOBOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And (e.KeyCode =System.WINDOWS.FORMS.Keys.D1) Then
            TabControl1.Focus()
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And (e.KeyCode =System.WINDOWS.FORMS.Keys.D2) Then
            TabControl1.SelectedIndex = (1)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDJO.Focus()
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
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub JOBOUT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB OUT'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            If ClientName = "MANINATH" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "MJFABRIC" Or ClientName = "RUCHITA" Then
                ALLOWMANUALJONO = True
            End If

            fillcmb()
            clear()

            If ClientName = "SVS" Then GPCS.ReadOnly = True

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objJO As New ClsCuttingIssue()
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPJONO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                objJO.alParaval = ALPARAVAL
                Dim dttable As DataTable = objJO.SELECTJO()

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTJONO.Text = TEMPJONO
                        TXTJONO.ReadOnly = True

                        CMBTYPE.Text = Convert.ToString(dr("JOBOUTTYPE").ToString)
                        CMBTYPE.Enabled = False
                        TXTTYPEJONO.Text = Val(dr("TYPEJOBOUTNO"))

                        JODATE.Text = Format(Convert.ToDateTime(dr("JODATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBPROCESS.Text = Convert.ToString(dr("PROCESS").ToString)
                        CMBPARTYNAME.Text = Convert.ToString(dr("PARTYNAME").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        CMBFROMCITY.Text = Convert.ToString(dr("FROMCITY"))
                        CMBTOCITY.Text = Convert.ToString(dr("TOCITY"))
                        CMBPACKING.Text = Convert.ToString(dr("PACKING"))

                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")
                        TXTBALENUMBER.Text = dr("BALENUMBER")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        TXTLOTNO.Text = dr("LOTNO").ToString
                        LBLRATE.Text = Val(dr("TOTALRATE"))
                        lbltotalwt.Text = Val(dr("TOTALWT"))

                        'Item Grid


                        GRIDJO.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("BALENO").ToString, dr("ITEM").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("COLOR").ToString, dr("DESCRIPTION").ToString, Format(Val(dr("CUT")), "0.00"), Format(dr("PCS"), "0.00"), dr("UNIT"), Format(dr("MTRS"), "0.00"), Format(dr("WT"), "0.00"), Val(dr("RATE")), dr("BARCODE").ToString, Format(dr("OUTPCS"), "0.00"), Format(dr("OUTMTRS"), "0.00"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), Val(dr("FRAMES")), dr("EMBPRODDONE"))

                        If Convert.ToDecimal(dr("RECDMTRS")) > 0 Or Convert.ToBoolean(dr("LOTCOMPLETED")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(dr("CLOSE")) = True Then
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If
                    Next


                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" JO_GRIDSRNO AS GRIDSRNO, JO_REMARKS AS REMARKS, JO_NAME AS NAME, JO_IMGPATH AS IMGPATH, JO_NEWIMGPATH AS NEWIMGPATH", "", " JOBOUT_UPLOAD", " AND JO_NO = " & TEMPJONO & " AND JO_CMPID = " & CmpId & " AND JO_LOCATIONID = " & Locationid & " AND JO_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                        Next
                    End If
                    total()
                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    chkchange.CheckState = CheckState.Checked
                Else
                    EDIT = False
                    clear()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT' ")
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)
            If CMBTOCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, EDIT)
            If CMBPACKING.Text.Trim = "" Then filljobbername(CMBPACKING, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
            FILLJOBOUTTYPE(CMBTYPE)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJEMB As New JobOutDetails
            OBJEMB.MdiParent = MDIMain
            OBJEMB.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTJO As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            If ALLOWPACKINGSLIP = True And ClientName <> "MARKIN" Then OBJSELECTGDN.FILTER = " AND BARCODE = ''"
            OBJSELECTGDN.ShowDialog()
            DTJO = OBJSELECTGDN.DT
            If DTJO.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTJO.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDJO.Rows
                        If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
                    Next

                    If ClientName = "KANVASU" Then
                        GRIDJO.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("LOTNO"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), "", 0, Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), 0, 0, DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"), 0, 0)
                    ElseIf ClientName = "BARKHA" Then
                        GRIDJO.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("BALENO"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), "", DTROWPS("CUT"), Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), 0, 0, DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"), 0, 0)
                    Else
                        GRIDJO.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("BALENO"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), "", 0, Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), 0, 0, DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"), 0, 0)
                    End If
                    If ClientName <> "AVIS" Then TXTLOTNO.Text = DTROWPS("LOTNO")

LINE1:
                Next
                getsrno(GRIDJO)
                total()
                GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDJO.RowCount = 0
                TEMPJONO = Val(tstxtbillno.Text)
                If TEMPJONO > 0 Then
                    EDIT = True
                    JOBOUT_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            GRIDJO.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDJO.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, TXTBALENO.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTDESCRIPTION.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTPCS.Text.Trim), "0.00"), "", Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Val(TXTRATE.Text.Trim), TXTBARCODE.Text.Trim, 0, 0, 0, 0, "", 0, 0)
                getsrno(GRIDJO)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDJO.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDJO.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
                GRIDJO.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
                GRIDJO.Item(GMERCHANT.Index, TEMPROW).Value = cmbitemname.Text.Trim
                GRIDJO.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDJO.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDJO.Item(GCOLOR.Index, TEMPROW).Value = cmbcolor.Text.Trim
                GRIDJO.Item(GDESCRIPTION.Index, TEMPROW).Value = TXTDESCRIPTION.Text.Trim
                GRIDJO.Item(gcut.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
                GRIDJO.Item(GPCS.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
                GRIDJO.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
                GRIDJO.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
                GRIDJO.Item(GRATE.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
                GRIDDOUBLECLICK = False
            End If

            total()

            GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

            txtsrno.Clear()
            'cmbitemname.Text = ""
            ' CMBQUALITY.Text = ""
            ' CMBDESIGN.Text = ""
            ' cmbcolor.Text = ""
            'TXTCUT.Clear()
            TXTBALENO.Clear()




            If GRIDJO.RowCount > 0 Then
                txtsrno.Text = Val(GRIDJO.Rows(GRIDJO.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
            CMBPIECETYPE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub fillgridscan()
        Try
            If GRIDUPLOADDOUBLECLICK = False Then
                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)
            ElseIf GRIDUPLOADDOUBLECLICK = True Then
                gridupload.Item(0, TEMPUPLOADROW).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
                gridupload.Item(3, TEMPUPLOADROW).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, TEMPUPLOADROW).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, TEMPUPLOADROW).Value = TXTFILENAME.Text.Trim

                GRIDUPLOADDOUBLECLICK = False
            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDJO.CurrentRow.Index >= 0 And GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDJO.Item(GPIECETYPE.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDJO.Item(GBALENO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDJO.Item(GMERCHANT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDJO.Item(GQUALITY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDJO.Item(GDESIGN.Index, GRIDJO.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDJO.Item(GCOLOR.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTDESCRIPTION.Text = GRIDJO.Item(GDESCRIPTION.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDJO.Item(gcut.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTPCS.Text = GRIDJO.Item(GPCS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDJO.Item(GMTRS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDJO.Item(GWT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDJO.Item(GRATE.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDJO.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTJONO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                GRIDUPLOADDOUBLECLICK = True
                TEMPUPLOADROW = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDJO.RowCount = 0
LINE1:
            TEMPJONO = Val(TXTJONO.Text) - 1
            If TEMPJONO > 0 Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPJONO > 1 Then
                TXTJONO.Text = TEMPJONO
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
            TEMPJONO = Val(TXTJONO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTJONO.Text.Trim
            clear()
            If Val(TXTJONO.Text) - 1 >= TEMPJONO Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPJONO < MAXNO Then
                TXTJONO.Text = TEMPJONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
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
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS", cmbtrans.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJO_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDJO.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPJONO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub PRINTREPORT(ByVal JONO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Job Out?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "JOBOUT"
                'If ClientName = "SUCCESS" Then
                If MsgBox("Wish to Print Job Out With GST...?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGDN.GSTRPT = True
                'End If
                OBJGDN.FORMULA = "{JOBOUT.JO_NO}=" & Val(JONO) & " and {JOBOUT.JO_yearid}=" & YearId
                OBJGDN.Show()
            End If


            If ClientName = "KCRAYON" Then
                If MsgBox("Wish to Print Job Sheet?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJJO As New JobOutDesign
                    OBJJO.MdiParent = MDIMain
                    OBJJO.FRMSTRING = "JOBSHEET"
                    OBJJO.WHERECLAUSE = "{JOBOUT.JO_NO}=" & Val(JONO) & " and {JOBOUT.JO_yearid}=" & YearId
                    OBJJO.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            TEMPMSG = MsgBox("Wish to Close Job Out?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTJONO.Text)
                    alParaval.Add(1)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim intresult As Integer
                    Dim clsobjjo As New ClsCuttingIssue()
                    clsobjjo.alParaval = alParaval
                    intresult = clsobjjo.CLOSE()
                    MsgBox("Job Out Closed")
                    clear()

                Else
                    Exit Sub
                End If
                Exit Sub
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If ClientName = "SAFFRON" Then
                    If lbllocked.Visible = True Then
                        MsgBox("Entry Locked", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Job Out?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJEMB As New ClsCuttingIssue

                ALPARAVAL.Add(TEMPJONO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                OBJEMB.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJEMB.Delete()
                MsgBox("Job Out Deleted Succesfully")
                clear()
                EDIT = False
                CMBNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        '        Try
        '            If TXTBARCODE.Text.Trim.Length > 0 Then

        '                If CMBGODOWN.Text.Trim = "" Then
        '                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
        '                    Exit Sub
        '                End If

        '                'GET DATA FROM BARCODE
        '                Dim OBJCMN As New ClsCommon
        '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
        '                If DT.Rows.Count > 0 Then

        '                    'VALIDATE GODOWN
        '                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
        '                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
        '                        TXTBARCODE.Clear()
        '                        Exit Sub
        '                    End If

        '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
        '                    For Each ROW As DataGridViewRow In GRIDJO.Rows
        '                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
        '                    Next


        '                    Dim PCS As Double = 0
        '                    If ClientName = "TCOT" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

        '                    GRIDJO.Rows.Add(GRIDJO.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("BALENO"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), "", Format(Val(DT.Rows(0).Item("CUT")), "0.00"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), 0, 0, DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0, 0)
        '                    total()
        '                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

        'LINE1:
        '                    TXTBARCODE.Clear()
        '                    'Else
        '                    '    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
        '                    '    GoTo LINE1
        '                    '    Exit Sub
        '                End If
        '            End If
        '        Catch ex As Exception
        '            Throw ex
        '        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                    'Else
                    '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPARTYNAME.Enter
        Try
            If ClientName = "BARKHA" Or ClientName = "KARAN" Then
                fillname(CMBPARTYNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            Else
                fillname(CMBPARTYNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPARTYNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                If ClientName = "BARKHA" Or ClientName = "KARAN" Then
                    OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                Else
                    OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                    OBJLEDGER.ShowDialog()
                    If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                    If OBJLEDGER.TEMPNAME <> "" Then CMBPARTYNAME.Text = OBJLEDGER.TEMPNAME
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYNAME.Validating
        Try

            If CMBPARTYNAME.Text.Trim <> "" Then
                If ClientName = "BARKHA" Or ClientName = "KARAN" Then namevalidate(CMBPARTYNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS", cmbtrans.Text) Else namevalidate(CMBPARTYNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS", cmbtrans.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles JODATE.GotFocus
        JODATE.SelectAll()
    End Sub

    Private Sub JODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles JODATE.Validating
        Try
            If JODATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(JODATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLANNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If TXTCHALLANNO.Text.Trim.Length > 0 Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As DataTable = objclscommon.search(" JO_challanno, LEDGERS.ACC_cmpname", "", " JOBOUT inner join LEDGERS on LEDGERS.ACC_id = JO_ledgerid ", " and JO_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND JO_YEARID =" & YearId)
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

    Private Sub CMBPROCESS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTJONO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTJONO.KeyPress
        numkeypress(e, TXTJONO, Me)
    End Sub

    Private Sub TXTJONO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTJONO.Validating
        Try
            If Val(TXTJONO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBOUT.JO_NO,0)  AS JONO", "", " JOBOUT ", "  AND JOBOUT.JO_NO=" & TXTJONO.Text.Trim & " AND JOBOUT.JO_CMPID = " & CmpId & " AND JOBOUT.JO_LOCATIONID = " & Locationid & " AND JOBOUT.JO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Job Out No Already Exists")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAXTYPEJONO()
        Try
            'GET MAX NO WITH RESPECT TO SELECTED JOBOUTTYPE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("isnull(max(JO_TYPENO),0) + 1", "", "JOBOUT INNER JOIN  JOBOUTTYPEMASTER ON JO_TYPEID = JOTYPE_ID", " AND JOTYPE_NAME = '" & CMBTYPE.Text.Trim & "' AND JO_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTTYPEJONO.Text = Val(DT.Rows(0).Item(0))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobOut_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try


            If ClientName = "KARAN" Then
                LBLPARTYNAME.Text = "Weaver Name"
                GDESCRIPTION.ReadOnly = False
            End If


            If ClientName = "MJFABRIC" Or ClientName = "MANAS" Then
                CMBPARTYNAME.TabStop = False
                TXTBARCODE.TabStop = False
                TXTMOBILENO.TabStop = False
                TXTLOTNO.TabStop = False
                TXTCHALLANNO.TabStop = False
                TXTEWAYBILLNO.TabStop = False
                TXTBALENUMBER.TabStop = False
                txtsrno.TabStop = False
                TXTBALENO.TabStop = False
                CMBQUALITY.TabStop = False
                CMBDESIGN.TabStop = False
                cmbcolor.TabStop = False
                TXTDESCRIPTION.TabStop = False
                TXTCUT.TabStop = False
                TXTRATE.TabStop = True
                CMDSELECTSTOCK.TabStop = False
            End If

            If ClientName = "BARKHA" Or ClientName = "MJFABRIC" Or ClientName = "SOFTAS" Or ClientName = "NVAHAN" Or ClientName = "RUCHITA" Or ClientName = "MANAS" Or ClientName = "MOHATUL" Then
                If ClientName = "BARKHA" Then
                    LBLPARTYNAME.Text = "Dyeing Name"
                    GDESCRIPTION.HeaderText = "Chart No"
                End If
                txtsrno.Visible = True
                CMBPIECETYPE.Visible = True
                TXTBALENO.Visible = True
                cmbitemname.Visible = True
                CMBQUALITY.Visible = True
                CMBDESIGN.Visible = True
                cmbcolor.Visible = True
                TXTDESCRIPTION.Visible = True
                TXTCUT.Visible = True
                TXTPCS.Visible = True
                TXTMTRS.Visible = True
                'TXTRATE.Visible = True

            End If

            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                LBLTYPE.Visible = True
                CMBTYPE.Visible = True
                TXTTYPEJONO.Visible = True
                LBLSRNO.Visible = True
            Else
                LBLTYPE.Visible = False
                CMBTYPE.Visible = False
                TXTTYPEJONO.Visible = False
            End If

            If ClientName = "AVIS" Then
                LBLPARTYNAME.Visible = False
                CMBPARTYNAME.Visible = False
                GDESCRIPTION.ReadOnly = False
            End If


            If ClientName = "SUCCESS" Or ClientName = "MAHAVIR" Or ClientName = "RSONS" Or ClientName = "MJFABRIC" Or ClientName = "YASHVI" Or ClientName = "RMANILAL" Or ClientName = "MOHAN" Or ClientName = "SOFTAS" Or ClientName = "AVIS" Or ClientName = "MOHATUL" Then
                GRATE.Visible = True
                LBLRATE.Visible = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPIECETYPE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJPieceType As New SelectPieceType
                OBJPieceType.ShowDialog()
                If OBJPieceType.TEMPNAME <> "" Then CMBPIECETYPE.Text = OBJPieceType.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then cmbitemname.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub CMBQUALITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQUALITY As New SelectQuality
                OBJQUALITY.ShowDialog()
                If OBJQUALITY.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQUALITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New SelectDesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcolor.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then cmbcolor.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            GETMAXTYPEJONO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDJO.CellValidating
        Try
            Dim colNum As Integer = GRIDJO.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPCS.Index, GMTRS.Index, gcut.Index, GRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDJO.CurrentCell.Value = Nothing Then GRIDJO.CurrentCell.Value = "0.00"
                        GRIDJO.CurrentCell.Value = Convert.ToDecimal(GRIDJO.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
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

    Private Sub GRIDJO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDJO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDJO.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDJO.Rows.RemoveAt(GRIDJO.CurrentRow.Index)
                getsrno(GRIDJO)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated, TXTPCS.Validated
        CALC()
        'total()
    End Sub

    Private Sub BlendPanel1_Click(sender As Object, e As EventArgs) Handles BlendPanel1.Click

    End Sub

    Sub CALC()
        Try
            If Val(TXTPCS.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(TXTPCS.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        Try
            If ClientName = "MJFABRIC" Then Exit Sub
            If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) > 0 Then

                fillgrid()

            Else
                If CMBPIECETYPE.Text.Trim = "" Then
                    MsgBox("Enter Piece Type", MsgBoxStyle.Critical)
                    CMBPIECETYPE.Focus()
                ElseIf cmbitemname.Text.Trim = "" Then
                    MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                    cmbitemname.Focus()
                ElseIf Val(TXTMTRS.Text.Trim) = 0 Then
                    MsgBox("Enter Mtrs", MsgBoxStyle.Critical)
                    TXTMTRS.Focus()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOCITY.Enter
        Try
            If CMBTOCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCITY.Validating
        Try
            If CMBTOCITY.Text.Trim <> "" Then CITYVALIDATE(CMBTOCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBFROMCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBFROMCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If EDIT = False Then Exit Sub
            GENERATEEWB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTOCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBTOCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKING.Enter
        Try
            If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO ", "", " LEDGERS ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    'If cmbtrans.Text.Trim = "" Then cmbtrans.Text = DT.Rows(0).Item("TRANSNAME")
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLSMS_Click(sender As Object, e As EventArgs) Handles TOOLSMS.Click
        If EDIT = False Then Exit Sub
        SMSCODE()
    End Sub

    Private Sub CMBPACKING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKING.Validating
        Try
            If CMBPACKING.Text.Trim <> "" Then namevalidate(CMBPACKING, CMBCODE, e, Me, txtDeliveryadd, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GENERATEEWB()
        Try
            If ALLOWEWAYBILL = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub
            If EDIT = False Then Exit Sub

            'If Val(LBLTOTALCGSTAMT.Text.Trim) = 0 And Val(TXTCGSTAMT1.Text.Trim) = 0 And Val(LBLTOTALSGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT1.Text.Trim) = 0 And Val(LBLTOTALIGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT1.Text.Trim) = 0 Then Exit Sub


            If txtlrno.Text.Trim <> "" AndAlso lrdate.Text <> "__/__/____" Then
                If Convert.ToDateTime(lrdate.Text).Date < Convert.ToDateTime(JODATE.Text).Date Then
                    MsgBox("LR Date cannot be Before Invoice Date", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            If CMBFROMCITY.Text.Trim = "" Then
                MsgBox("Enter From City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBTOCITY.Text.Trim = "" Then
                MsgBox("Enter to City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Generate E-Way Bill?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTEWAYBILLNO.Text.Trim <> "" Then
                MsgBox("E-Way Bill No Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

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
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim TRANSGSTIN As String = ""

            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_DISPATCHFROM, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2 ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN,  (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            If CMBPACKING.Text.Trim <> "" AndAlso CMBNAME.Text.Trim <> CMBPACKING.Text.Trim Then
                DT = OBJCMN.search("  (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & CMBPACKING.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                    MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                    PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                    PARTYADD1 = DT.Rows(0).Item("ADD1")
                    PARTYADD2 = DT.Rows(0).Item("ADD2")
                End If
            End If



            'TRANSPORT GSTIN
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
            If TRANSGSTIN = "" Then
                MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                Exit Sub
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
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER = 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE 1% THEN INTIMATE
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER < Format((CMPEWAYCOUNTER * 0.01), "0") Then
                MsgBox("Only " & (CMPEWAYCOUNTER - USEDEWAYCOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of EWB Package", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'FOR GENERATING EWAY BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.02/authenticate?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)
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
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTJONO.Text.Trim) & ",'JOBOUT','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                Exit Sub
            End If



            'GENERATING EWAY BILL 
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.02/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"


                Dim j As String = ""

                j = "{"
                j = j & """supplyType"":""O"","
                j = j & """subSupplyType"":""1"","
                j = j & """subSupplyDesc"":"""","
                j = j & """docType"":""CHL"","
                j = j & """docNo"":""" & Val(TXTJONO.Text.Trim) & """" & ","
                j = j & """docDate"":""" & JODATE.Text & """" & ","
                j = j & """fromGstin"":""" & CMPGSTIN & """" & ","
                j = j & """fromTrdName"":""" & CmpName & """" & ","
                j = j & """fromAddr1"":""" & TEMPCMPADD1 & """" & ","
                j = j & """fromAddr2"":""" & TEMPCMPADD2 & """" & ","
                j = j & """fromPlace"":""" & CMBFROMCITY.Text.Trim & """" & ","
                j = j & """fromPincode"":""" & CMPPINCODE & """" & ","
                j = j & """actFromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """fromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """toGstin"":""" & PARTYGSTIN & """" & ","
                j = j & """toTrdName"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """toAddr1"":""" & PARTYADD1 & """" & ","
                j = j & """toAddr2"":""" & PARTYADD2 & """" & ","
                j = j & """toPlace"":""" & CMBTOCITY.Text.Trim & """" & ","
                j = j & """toPincode"":""" & PARTYPINCODE & """" & ","
                j = j & """actToStateCode"":""" & PARTYSTATECODE & """" & ","
                j = j & """toStateCode"":""" & PARTYSTATECODE & """" & ","
                'If INVOICESCREENTYPE = "TOTAL GST" Then
                '    j = j & """totalValue"":""" & Val(TXTSUBTOTAL.Text.Trim) & """" & ","
                '    j = j & """cgstValue"":""" & Val(TXTCGSTAMT1.Text.Trim) & """" & ","
                '    j = j & """sgstValue"":""" & Val(TXTSGSTAMT1.Text.Trim) & """" & ","
                '    j = j & """igstValue"":""" & Val(TXTIGSTAMT1.Text.Trim) & """" & ","
                'End If
                'j = j & """cessValue"":""" & "0" & """" & ","
                'j = j & """totInvValue"":""" & Val(txtgrandtotal.Text.Trim) & """" & ","
                'j = j & """transporterId"":""" & TRANSGSTIN & """" & ","
                'j = j & """transporterName"":""" & cmbtrans.Text.Trim & """" & ","
                'j = j & """transDocNo"":""" & txtlrno.Text.Trim & """" & ","
                'j = j & """transMode"":""" & "1" & """" & ","
                'j = j & """transDistance"":""" & PARTYKMS & """" & ","
                'If lrdate.Text <> "__/__/____" Then j = j & """transDocDate"":""" & lrdate.Text & """" & "," Else j = j & """transDocDate"":"""","
                'If TXTVEHICLENO.Text.Trim = "" Then j = j & """vehicleNo"":""" & "LOC0000" & """" & "," Else j = j & """vehicleNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                'j = j & """vehicleType"":""" & "R" & """" & ","
                'j = j & """itemList"":[{"
                'j = j & """productName"":""" & GRIDJO.Item(GITEMNAME.Index, 0).Value & """" & ","
                'j = j & """productDesc"":""" & GRIDJO.Item(GITEMNAME.Index, 0).Value & """" & ","
                'j = j & """hsnCode"":""" & GRIDJO.Item(GHSNCODE.Index, 0).Value & """" & ","
                'j = j & """quantity"":""" & Val(GRIDJO.Item(GMTRS.Index, 0).Value) & """" & ","
                'j = j & """qtyUnit"":""" & "MTR" & """" & ","
                'If INVOICESCREENTYPE = "TOTAL GST" Then
                '    j = j & """cgstRate"":""" & Val(TXTCGSTPER1.Text.Trim) & """" & ","
                '    j = j & """sgstRate"":""" & Val(TXTSGSTPER1.Text.Trim) & """" & ","
                '    j = j & """igstRate"":""" & Val(TXTIGSTPER1.Text.Trim) & """" & ","

                'End If
                'j = j & """cessRate"":""" & "0" & """" & ","
                'j = j & """cessAdvol"":""" & "0" & """" & ","
                'If INVOICESCREENTYPE = "TOTAL GST" Then
                '    j = j & """taxableAmount"":""" & Val(TXTSUBTOTAL.Text.Trim) & """"

                'End If
                j = j & " }]}"

                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Generating EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTJONO.Text.Trim) & ",'JOBOUT','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
            DT = OBJCMN.Execute_Any_String("UPDATE JOBOUT SET JO_EWAYBILLNO = '" & TXTEWAYBILLNO.Text.Trim & "' FROM JOBOUT WHERE JOB_NO = " & Val(TEMPJONO) & "  AND INVOICE_YEARID = " & YearId, "", "")

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTJONO.Text.Trim) & ",'JOBOUT','" & TOKEN & "','" & EWBNO & "','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SMSCODE()
        If ALLOWSMS = True Then
            If ClientName <> "KOTHARI" And TXTMOBILENO.Text.Trim = "" Then Exit Sub
            If ClientName = "KOTHARI" And CMBPACKING.Text.Trim = "" Then Exit Sub

            If MsgBox("Send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim MSG As String
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'If ClientName = "KOTHARI" Then
            '    DT = OBJCMN.search("ACC_CODE AS LEDGERCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBPACKING.Text.Trim & "' AND ACC_YEARID = " & YearId)

            '    If DT.Rows.Count > 0 Then MSG = DT.Rows(0).Item("LEDGERCODE") & "\n"
            '    MSG = MSG & txtchallan.Text.Trim & "\n"
            '    MSG = MSG & GRIDINVOICE.Rows(0).Cells(GITEMNAME.Index).Value & "-" & GRIDINVOICE.Rows(0).Cells(GDESCRIPTION.Index).Value & "\n"
            '    DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then MSG = MSG & DT.Rows(0).Item("TRANSCODE") & "\n"
            '    MSG = MSG & txtlrno.Text.Trim & "\n"
            '    MSG = MSG & lrdate.Text

            'ElseIf ClientName = "KCRAYON" Then
            '    MSG = "INV NO " & Val(TEMPINVOICENO) & "\n"
            '    DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT NAME-" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & txtlrno.Text.Trim & "\n"
            '    For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
            '        MSG = MSG & ROW.Cells(GITEMNAME.Index).Value & "-" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & "\n"
            '    Next
            '    MSG = MSG & "THANK YOU"

            'ElseIf ClientName = "NVAHAN" Then
            '    MSG = "GOODS DESP" & "\n"
            '    MSG = MSG & "INV-" & Val(TEMPINVOICENO) & "\n"
            '    MSG = MSG & "LRNO-" & txtlrno.Text.Trim & "\n"
            '    MSG = MSG & "DT-" & lrdate.Text & "\n"
            '    DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then MSG = MSG & "TRANS-" & DT.Rows(0).Item("TRANSCODE") & "\n"
            '    MSG = MSG & "ITEM-" & GRIDINVOICE.Rows(0).Cells(GITEMNAME.Index).Value & "\n" & "PCS-" & Val(GRIDINVOICE.Rows(0).Cells(GPCS.Index).Value) & "\n" & "MTRS-" & Val(GRIDINVOICE.Rows(0).Cells(GMTRS.Index).Value) & "\n" & "BALE-" & GRIDINVOICE.Rows(0).Cells(GBALENO.Index).Value

            'ElseIf ClientName = "YASHVI" Then
            '    MSG = CMBNAME.Text.Trim & "\n"
            '    MSG = MSG & "BALENO-" & txtchallan.Text.Trim & "\n"
            '    DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then MSG = MSG & DT.Rows(0).Item("TRANSCODE") & "\n"
            '    MSG = MSG & "LRNO-" & txtlrno.Text.Trim & "\n"
            '    MSG = MSG & "DT-" & lrdate.Text & "\n"
            '    MSG = MSG & "QTY-" & Val(LBLTOTALMTRS.Text.Trim) & "\n"
            '    MSG = MSG & CmpName

            If ClientName = "SANGHVI" Then
                MSG = "CHALLAN NO " & Val(TEMPJONO) & "\n"
                MSG = MSG & "DT-" & JODATE.Text & "\n"
                DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT NAME-" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & txtlrno.Text.Trim & "\n"
                MSG = MSG & "LRDT-" & lrdate.Text & "\n"
                MSG = MSG & "PCS-" & Val(LBLTOTALPCS.Text.Trim) & "\n"
                MSG = MSG & "MTRS-" & Val(LBLTOTALMTRS.Text.Trim) & "\n"
                'MSG = MSG & " & BUNDLES-" & TXTBALENOFROM.Text.Trim & "\n"
                ''For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
                ''    MSG = MSG & ROW.Cells(GITEMNAME.Index).Value & "-" & Format(Val(ROW.Cells(Gmtrs.Index).Value), "0.00") & "\n"
                ''Next
                MSG = MSG & "THANK YOU"
                'Else
                '    MSG = "SALE NO " & Val(TEMPINVOICENO) & "\n"
                'DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
                'If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT NAME-" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & txtlrno.Text.Trim & "\n"
                'For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
                '    MSG = MSG & ROW.Cells(GITEMNAME.Index).Value & "-" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & "\n"
                'Next
                'MSG = MSG & "THANK YOU"
            End If

            If SENDMSG(MSG, TXTMOBILENO.Text.Trim) = "1701" Then
                MsgBox("Message Sent")
                DT = OBJCMN.Execute_Any_String("UPDATE JOBOUT SET JO_SMSSEND = 1 WHERE JO_NO = " & TEMPJONO & " AND JO_YEARID = " & YearId, "", "")
                LBLSMS.Visible = True
            Else
                MsgBox("Error Sending Message")
            End If
        End If
    End Sub

    Private Sub TXTBALENUMBER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTBALENUMBER.KeyPress
        Try
            numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'GET DATA FROM BARCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDJO.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next


                    Dim PCS As Double = 0
                    If ClientName = "TCOT" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

                    GRIDJO.Rows.Add(GRIDJO.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("BALENO"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), "", Format(Val(DT.Rows(0).Item("CUT")), "0.00"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), 0, 0, DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0, 0)
                    total()
                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                    'Else
                    '    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
                    '    GoTo LINE1
                    '    Exit Sub
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class