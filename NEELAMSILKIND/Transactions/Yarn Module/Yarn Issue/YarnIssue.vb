
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL

Public Class YarnIssue

    Public EDIT As Boolean          'used for editing
    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public TEMPYARNNO As Integer          'used for editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim PARTYCHALLANNO As String

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
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS", CMBTRANS.Text)
        Catch ex As Exception
            Throw ex
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

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, CMBCODE, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")
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

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()
        TXTYISSUENO.Clear()
        TXTYISSUENO.ReadOnly = False

        CMBGODOWN.Enabled = True
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        CMBNAME.Text = ""
        TXTCHALLANNO.Clear()
        CMBPROCESS.Text = ""
        CMBMACHINE.Text = ""
        TXTADD.Clear()
        YISSDATE.Text = Now.Date
        tstxtbillno.Clear()

        CMBTRANS.Text = ""
        CMBTRANS2.Text = ""
        TXTLRNO.Clear()
        DTLRDATE.Value = Now.Date
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

        lbltotalqty.Text = 0.0
        LBLTOTALWT.Text = 0.0
        LBLTOTALCONES.Text = 0.0

        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        TXTLOTNO.Clear()
        TXTBAGS.Clear()
        TXTCONES.Clear()
        cmbcolor.Text = ""
        TXTBOXNO.Clear()
        TXTLRNO.Clear()
        TXTWT.Clear()

        TXTEWBNO.Clear()
        TXTVEHICLENO.Clear()
        CHKMANUALAMT.CheckState = CheckState.Unchecked
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRANDTOTAL.Clear()

        GRIDYARN.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        getmaxno()


        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALCONES.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0

            If CHKMANUALAMT.Checked = False Then TXTTAXABLEAMT.Clear()
            TXTCGSTAMT.Clear()
            TXTCGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTIGSTAMT.Clear()
            TXTIGSTPER.Clear()

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            For Each ROW As DataGridViewRow In GRIDYARN.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCONES.Text = Format(Val(LBLTOTALCONES.Text) + Val(ROW.Cells(GCONES.Index).EditedFormattedValue), "0.00")

                    If CHKMANUALAMT.Checked = False Then
                        'GET RATE FROM YARNQUALITY AND MULTIPLY WITH WT TO GET TAXABLE AMT
                        DT = OBJCMN.search("ISNULL(YARN_RATE,0) AS RATE", "", "YARNQUALITYMASTER", " AND YARN_NAME = '" & ROW.Cells(GYARNQUALITY.Index).Value & "' AND YARN_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then TXTTAXABLEAMT.Text = Format(Val(TXTTAXABLEAMT.Text) + (Val(DT.Rows(0).Item("RATE")) * Val(ROW.Cells(GWT.Index).Value)), "0.00")
                    End If
                End If
            Next


            'GET GST PERCENT AND CALC AMT
            If Val(TXTTAXABLEAMT.Text.Trim) > 0 And GRIDYARN.RowCount > 0 And CMBNAME.Text.Trim <> "" Then
                DT = OBJCMN.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "YARNQUALITYMASTER INNER JOIN HSNMASTER ON YARN_HSNCODEID = HSN_ID", " AND YARN_NAME = '" & GRIDYARN.Rows(0).Cells(GYARNQUALITY.Index).Value & "' AND YARN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    Dim DTLEDGER As DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(STATEMASTER.state_remark, '') AS STATECODE FROM LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  WHERE LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId, "", "")
                    If DTLEDGER.Rows(0).Item("STATECODE") = CMPSTATECODE Then
                        TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                        TXTCGSTAMT.Text = Format(Val(DT.Rows(0).Item("CGSTPER")) * Val(TXTTAXABLEAMT.Text.Trim) / 100, "0.00")
                        TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        TXTSGSTAMT.Text = Format(Val(DT.Rows(0).Item("SGSTPER")) * Val(TXTTAXABLEAMT.Text.Trim) / 100, "0.00")
                    Else
                        TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        TXTIGSTAMT.Text = Format(Val(DT.Rows(0).Item("IGSTPER")) * Val(TXTTAXABLEAMT.Text.Trim) / 100, "0.00")
                    End If
                End If
            End If

            TXTGRANDTOTAL.Text = Format(Val(TXTTAXABLEAMT.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(YARN_no),0) + 1 ", " YARNISSUE ", " AND YARN_cmpid=" & CmpId & " and YARN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTYISSUENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function ERRORVALID() As Boolean
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

            If LBLCLOSED.Visible = True Then
                EP.SetError(LBLCLOSED, " Issue Closed")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDYARN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            Dim OBJCMN As New ClsCommon()
            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim DT As DataTable = OBJCMN.search(" YARN_challanno, LEDGERS.ACC_cmpname", "", " YARNISSUE inner join LEDGERS on LEDGERS.ACC_id = YARN_ledgerid ", " and YARN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND YARN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If

            If TXTYISSUENO.Text <> "" And EDIT = False Then
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(YARNISSUE.YARN_NO,0)  AS YARNNO", "", " YARNISSUE ", "  AND YARNISSUE.YARN_NO=" & TXTYISSUENO.Text.Trim & " AND YARNISSUE.YARN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTYISSUENO, "Issue No Already Exist")
                    bln = False
                End If
            End If


            If YISSDATE.Text = "__/__/____" Then
                EP.SetError(YISSDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(YISSDATE.Text) Then
                    EP.SetError(YISSDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If Val(TXTYISSUENO.Text.Trim) = 0 Then
                EP.SetError(TXTYISSUENO, "Enter Job Out No")
                bln = False
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

            If TXTYISSUENO.ReadOnly = False Then
                alParaval.Add(Val(TXTYISSUENO.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Format(Convert.ToDateTime(YISSDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBMACHINE.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)

            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(CMBTRANS2.Text.Trim)


            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALCONES.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTEWBNO.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(CHKMANUALAMT.Checked)
            alParaval.Add(Val(TXTTAXABLEAMT.Text))
            alParaval.Add(Val(TXTCGSTPER.Text))
            alParaval.Add(Val(TXTCGSTAMT.Text))
            alParaval.Add(Val(TXTSGSTPER.Text))
            alParaval.Add(Val(TXTSGSTAMT.Text))
            alParaval.Add(Val(TXTIGSTPER.Text))
            alParaval.Add(Val(TXTIGSTAMT.Text))
            alParaval.Add(Val(TXTGRANDTOTAL.Text))



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
            Dim LRNO As String = ""
            Dim LRDATE As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BOXNO = row.Cells(GBOXNO.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        qty = row.Cells(GQTY.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value
                        CONES = Val(row.Cells(GCONES.Index).Value)
                        LRNO = row.Cells(GLRNO.Index).Value.ToString
                        If row.Cells(GLRDATE.Index).Value <> "" Then LRDATE = Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy") Else LRDATE = Format(Now.Date, "MM/dd/yyyy")


                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value

                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BOXNO = BOXNO & "|" & row.Cells(GBOXNO.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        qty = qty & "|" & row.Cells(GQTY.Index).Value
                        WT = WT & "|" & row.Cells(GWT.Index).Value

                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)
                        LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value
                        If row.Cells(GLRDATE.Index).Value <> "" Then LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy") Else LRDATE = LRDATE & "|" & Format(Now.Date, "MM/dd/yyyy")

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
            alParaval.Add(LRNO)
            alParaval.Add(LRDATE)


            Dim objCUTTING As New ClsYarnIssue()
            objCUTTING.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objCUTTING.SAVE()
                MsgBox("Details Added")

                TXTYISSUENO.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPYARNNO)
                IntResult = objCUTTING.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPYARNNO)

                If gridupload.RowCount > 0 Then SAVEUPLOAD()
                EDIT = False
            End If


            CLEAR()
            YISSDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsYarnIssue


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

    Sub PRINTREPORT(ByVal YARNNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Yarn Issue?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJPUR As New YarnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "YARNISSUE"
                OBJPUR.WHERECLAUSE = "{YARNISSUE.YARN_NO}=" & Val(YARNNO) & " and {YARNISSUE.YARN_YEARID}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOBOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And (e.KeyCode =System.WINDOWS.FORMS.Keys.D1) Then
            TabControl1.Focus()
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And (e.KeyCode =System.WINDOWS.FORMS.Keys.D2) Then
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{Tab}")
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
    End Sub

    Private Sub JOBOUT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objJO As New ClsYarnIssue()
                Dim ALPARAVAL As New ArrayList
                objJO.alParaval = ALPARAVAL
                Dim dttable As DataTable = objJO.SELECTYARN(TEMPYARNNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTYISSUENO.Text = TEMPYARNNO
                        TXTYISSUENO.ReadOnly = True

                        YISSDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBMACHINE.Text = dr("MACHINE")
                        CMBGODOWN.Enabled = False
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBPROCESS.Text = Convert.ToString(dr("PROCESS").ToString)
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        CMBTRANS2.Text = dr("TRANSNAME2").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        TXTEWBNO.Text = dr("EWBNO")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        CHKMANUALAMT.Checked = Convert.ToBoolean(dr("MANUALAMT"))
                        TXTTAXABLEAMT.Text = dr("TAXABLEAMT")
                        TXTCGSTPER.Text = dr("CGSTPER")
                        TXTCGSTAMT.Text = dr("CGSTAMT")
                        TXTSGSTPER.Text = dr("SGSTPER")
                        TXTSGSTAMT.Text = dr("SGSTAMT")
                        TXTIGSTPER.Text = dr("IGSTPER")
                        TXTIGSTAMT.Text = dr("IGSTAMT")
                        TXTGRANDTOTAL.Text = Val(dr("GRANDTOTAL"))



                        Dim TEMPLRDATE As String = ""
                        If dr("LRNO") <> "" Then TEMPLRDATE = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        GRIDYARN.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("MILLNAME").ToString, dr("COLOR"), dr("BOXNO"), dr("LOTNO"), Format(dr("qty"), "0"), Format(dr("WT"), "0.00"), Format(dr("CONES"), "0"), dr("LRNO"), TEMPLRDATE)

                        If Convert.ToDecimal(dr("RECDWT")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next


                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" YARNISSUE_UPLOAD.YARN_SRNO AS GRIDSRNO, YARNISSUE_UPLOAD.YARN_REMARKS AS REMARKS, YARNISSUE_UPLOAD.YARN_NAME AS NAME, YARNISSUE_UPLOAD.YARN_PHOTO AS IMGPATH ", "", " YARNISSUE_UPLOAD ", " AND YARNISSUE_UPLOAD.YARN_NO = " & TEMPYARNNO & " AND YARN_YEARID = " & YearId & " ORDER BY YARNISSUE_UPLOAD.YARN_SRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If

                    total()
                    GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1
                    'chkchange.CheckState = CheckState.Checked
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

    Sub fillcmb()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)

            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLYARNCOLOR(cmbcolor, CMBYARNQUALITY.Text.Trim)
            FILLMACHINE(CMBMACHINE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then YARNCOLORVALIDATE(cmbcolor, e, Me, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTLRDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTLRDATE.Validated
        Try

            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                fillgrid()
            ElseIf CMBYARNQUALITY.Text.Trim = "" Then
                MsgBox("Enter Yarn Quality Name", MsgBoxStyle.Critical)
                CMBYARNQUALITY.Focus()
                Exit Sub

            ElseIf Val(TXTWT.Text.Trim) <= 0 Then
                MsgBox("Enter Weight", MsgBoxStyle.Critical)
                TXTWT.Focus()
                Exit Sub

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDYARN.Enabled = True

        Dim TEMPQTY As Integer = Val(TXTBAGS.Text.Trim)
        Dim TEMPLRDATE As String = ""
        If TXTLRNO.Text.Trim <> "" Then TEMPLRDATE = Format(DTLRDATE.Value.Date, "dd/MM/yyyy")

        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, cmbcolor.Text.Trim, TXTBOXNO.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(TXTBAGS.Text.Trim), "0"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0"), TXTLRNO.Text.Trim, TEMPLRDATE, 0, 0, 0, 0, 0)
            getsrno(GRIDYARN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDYARN.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDYARN.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDYARN.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim
            GRIDYARN.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDYARN.Item(GBOXNO.Index, TEMPROW).Value = TXTBOXNO.Text.Trim
            GRIDYARN.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            GRIDYARN.Item(GQTY.Index, TEMPROW).Value = Format(Val(TXTBAGS.Text.Trim), "0")
            GRIDYARN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            GRIDYARN.Item(GCONES.Index, TEMPROW).Value = Format(Val(TXTCONES.Text.Trim), "0")
            GRIDYARN.Item(GLRNO.Index, TEMPROW).Value = TXTLRNO.Text.Trim
            GRIDYARN.Item(GLRDATE.Index, TEMPROW).Value = TEMPLRDATE


            GRIDDOUBLECLICK = False

        End If

        total()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        cmbcolor.Text = ""
        TXTBOXNO.Clear()
        TXTLOTNO.Clear()
        TXTBAGS.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTLRNO.Clear()
        DTLRDATE.Value = Now.Date


        txtsrno.Text = GRIDYARN.RowCount + 1
        CMBYARNQUALITY.Focus()

    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJEMB As New YarnIssueDetails
            OBJEMB.MdiParent = MDIMain
            OBJEMB.Show()
        Catch ex As Exception
            Throw ex
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

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTYARN As New DataTable
            Dim OBJSTOCK As New SelectYarnStock
            OBJSTOCK.GODOWN = CMBGODOWN.Text.Trim
            OBJSTOCK.ShowDialog()
            DTYARN = OBJSTOCK.DT
            If DTYARN.Rows.Count > 0 Then
                For Each DTROW As DataRow In DTYARN.Rows
                    GRIDYARN.Rows.Add(0, DTROW("YARNQUALITY"), DTROW("MILLNAME"), DTROW("COLOR"), DTROW("BOXNO"), DTROW("LOTNO"), Format(Val(DTROW("BAGS")), "0"), Format(Val(DTROW("WT")), "0.00"), Format(Val(DTROW("CONES")), "0"), DTROW("DONO"), Format(DTLRDATE.Value.Date, "dd/MM/yyyy"))
                Next
                getsrno(GRIDYARN)
                total()
                GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1
            End If
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
                    JOBOUT_Load(sender, e)
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
            GRIDYARN.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYISSUENO.Text) - 1
            If TEMPYARNNO > 0 Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO > 1 Then
                TXTYISSUENO.Text = TEMPYARNNO
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
            TEMPYARNNO = Val(TXTYISSUENO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTYISSUENO.Text.Trim
            CLEAR()
            If Val(TXTYISSUENO.Text) - 1 >= TEMPYARNNO Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO < MAXNO Then
                TXTYISSUENO.Text = TEMPYARNNO
                GoTo LINE1
            End If
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

    Private Sub GRIDYARN_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDYARN.CellValidating
        Try
            Dim colNum As Integer = GRIDYARN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDYARN.CurrentCell.Value = Nothing Then GRIDYARN.CurrentCell.Value = "0.00"
                        GRIDYARN.CurrentCell.Value = Convert.ToDecimal(GRIDYARN.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDYARN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDYARN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDYARN.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDYARN.Rows.RemoveAt(GRIDYARN.CurrentRow.Index)
                getsrno(GRIDYARN)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT(TEMPYARNNO)
                PRINTEWB()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Yarn Issue?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJEMB As New ClsYarnIssue

                ALPARAVAL.Add(TEMPYARNNO)
                ALPARAVAL.Add(YearId)
                OBJEMB.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJEMB.DELETE()
                MsgBox("Yarn Issue Deleted Succesfully")
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

    Private Sub JODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YISSDATE.GotFocus
        YISSDATE.SelectAll()
    End Sub

    Private Sub JODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YISSDATE.Validating
        Try
            If YISSDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(YISSDATE.Text, TEMP) Then
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
                    Dim objclscommon As New ClsCommon()
                    Dim dt As DataTable = objclscommon.search(" YARN_challanno, LEDGERS.ACC_cmpname", "", " YARNISSUE inner join LEDGERS on LEDGERS.ACC_id = YARN_ledgerid ", " and YARN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND YARN_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "NEELAMSILKIND")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDYARN_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDYARN.CellDoubleClick
        EDITROW()
    End Sub

    Sub EDITROW()
        Try
            If GRIDYARN.CurrentRow.Index >= 0 And GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBYARNQUALITY.Text = GRIDYARN.Item(GYARNQUALITY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBMILL.Text = GRIDYARN.Item(GMILLNAME.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                cmbcolor.Text = GRIDYARN.Item(gcolor.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTBOXNO.Text = GRIDYARN.Item(GBOXNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDYARN.Item(GLOTNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                TXTBAGS.Text = GRIDYARN.Item(GQTY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
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

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBAGS.KeyPress, TXTCONES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress, TXTTAXABLEAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles cmbcolor.Enter
        Try
            FILLYARNCOLOR(cmbcolor, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINE_Enter(sender As Object, e As EventArgs) Handles CMBMACHINE.Enter
        Try
            If CMBMACHINE.Text.Trim = "" Then FILLMACHINE(CMBMACHINE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINE_Validating(sender As Object, e As CancelEventArgs) Handles CMBMACHINE.Validating
        Try
            If CMBMACHINE.Text.Trim <> "" Then MACHINEVALIDATE(CMBMACHINE, e, Me)
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
            If CMBNAME.Text.Trim = "" Then Exit Sub
            If EDIT = False Then Exit Sub
            Dim FROMCITY, TOCITY As String

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

            If CMPCITYNAME <> "" Then FROMCITY = CMPCITYNAME Else FROMCITY = ""
            TOCITY = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CITY_NAME,'') AS TOCITY", "", "LEDGERS LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TOCITY = DT.Rows(0).Item("TOCITY")


            If FROMCITY = "" Then
                MsgBox("Enter City Name in Company Master", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TOCITY = "" Then
                MsgBox("Enter City Name in Jobber Details", MsgBoxStyle.Critical)
                Exit Sub
            End If


            If MsgBox("Generate E-Way Bill?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTEWBNO.Text.Trim <> "" Then
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

            'CMP ADDRESS DETAILS
            DT = OBJCMN.search(" ISNULL(CMP_DISPATCHFROM, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2 ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
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


            'NO NEED OF SHIPTO DETAILS HERE
            ''FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            'If TXTDELIVERYAT.Text.Trim <> "" AndAlso cmbname.Text.Trim <> TXTDELIVERYAT.Text.Trim Then
            '    DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_RANGE,'') AS KOTHARIPLACE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & TXTDELIVERYAT.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
            '        MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
            '        Exit Sub
            '    Else
            '        SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
            '        PARTYPINCODE = DT.Rows(0).Item("PINCODE")
            '        PARTYKMS = Val(DT.Rows(0).Item("KMS"))
            '        PARTYADD1 = DT.Rows(0).Item("ADD1")
            '        PARTYADD2 = DT.Rows(0).Item("ADD2")
            '        SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
            '        SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
            '    End If
            'End If


            'TRANSPORT GSTING IS NOT MANDATORY
            'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            If CMBTRANS.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & CMBTRANS.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
                'FOR LOCAL TRANSPORT THERE IS NO GSTIN
                'If TRANSGSTIN = "" Then
                '    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If
            Else
                MsgBox("Enter Transport Details", MsgBoxStyle.Critical)
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
            'Dim URL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.03/authenticate?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)
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
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'DO','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                Exit Sub
            End If



            'GENERATING EWAY BILL 
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.03/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"


                Dim j As String = ""

                j = "{"
                j = j & """supplyType"":""O"","
                j = j & """subSupplyType"":""4"","
                j = j & """subSupplyDesc"":"""","
                j = j & """docType"":""CHL"","

                j = j & """docNo"":""" & Val(TXTYISSUENO.Text.Trim) & """" & ","

                j = j & """docDate"":""" & YISSDATE.Text & """" & ","
                j = j & """fromGstin"":""" & CMPGSTIN & """" & ","
                j = j & """fromTrdName"":""" & CmpName & """" & ","
                j = j & """fromAddr1"":""" & TEMPCMPADD1 & """" & ","
                j = j & """fromAddr2"":""" & TEMPCMPADD2 & """" & ","
                j = j & """fromPlace"":""" & FROMCITY & """" & ","
                j = j & """fromPincode"":""" & CMPPINCODE & """" & ","
                j = j & """actFromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """fromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """toGstin"":""" & PARTYGSTIN & """" & ","
                j = j & """toTrdName"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """toAddr1"":""" & PARTYADD1 & """" & ","
                j = j & """toAddr2"":""" & PARTYADD2 & """" & ","
                j = j & """toPlace"":""" & CMBNAME.Text.Trim & "-" & TOCITY & """" & ","
                j = j & """toPincode"":""" & PARTYPINCODE & """" & ","
                j = j & """actToStateCode"":""" & SHIPTOSTATECODE & """" & ","
                j = j & """toStateCode"":""" & PARTYSTATECODE & """" & ","

                j = j & """transactionType"":""4"","
                j = j & """dispatchFromGSTIN"":""" & CMPGSTIN & """" & ","
                j = j & """dispatchFromTradeName"":""" & CmpName & """" & ","
                j = j & """shipToGSTIN"":""" & SHIPTOGSTIN & """" & ","
                j = j & """shipToTradeName"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """otherValue"":""0"","


                j = j & """totalValue"":""" & Val(TXTTAXABLEAMT.Text.Trim) & """" & ","
                j = j & """cgstValue"":""" & Val(TXTCGSTAMT.Text.Trim) & """" & ","
                j = j & """sgstValue"":""" & Val(TXTSGSTAMT.Text.Trim) & """" & ","
                j = j & """igstValue"":""" & Val(TXTIGSTAMT.Text.Trim) & """" & ","

                j = j & """cessValue"":""" & "0" & """" & ","
                j = j & """cessNonAdvolValue"":""" & "0" & """" & ","
                j = j & """totInvValue"":""" & Val(TXTTAXABLEAMT.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) & """" & ","
                j = j & """transporterId"":""" & TRANSGSTIN & """" & ","
                j = j & """transporterName"":""" & CMBTRANS.Text.Trim & """" & ","


                If TXTVEHICLENO.Text.Trim = "" Then
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":"""","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":"""","
                    j = j & """vehicleType"":"""","
                Else
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":""" & "1" & """" & ","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                    j = j & """vehicleType"":""" & "R" & """" & ","
                End If


                j = j & """itemList"":[{"


                'WE NEED TO FETCH SUMMARY OF ITEMS AND HSN TO PASS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT YARN_NAME AS ITEMNAME, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGST, ISNULL(HSN_SGST,0) AS SGST, ISNULL(HSN_IGST,0) AS IGST, SUM(YARN_WT) AS MTRS FROM YARNISSUE_DESC INNER JOIN YARNQUALITYMASTER ON YARN_id = YARN_YARNQUALITYID INNER JOIN HSNMASTER ON HSN_ID = YARN_HSNCODEID WHERE YARNISSUE_DESC.YARN_NO = " & Val(TEMPYARNNO) & " and YARNISSUE_DESC.YARN_YEARID = " & YearId & " GROUP BY YARN_NAME, ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0)", "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows
                    If CURRROW > 0 Then j = j & ",{"
                    j = j & """productName"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """productDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """hsnCode"":""" & DTROW("HSNCODE") & """" & ","
                    j = j & """quantity"":""" & Val(DTROW("MTRS")) & """" & ","
                    j = j & """qtyUnit"":""" & "KGS" & """" & ","

                    j = j & """cgstRate"":""" & Val(TXTCGSTPER.Text.Trim) & """" & ","
                    j = j & """sgstRate"":""" & Val(TXTSGSTPER.Text.Trim) & """" & ","
                    j = j & """igstRate"":""" & Val(TXTIGSTPER.Text.Trim) & """" & ","

                    j = j & """cessRate"":""" & "0" & """" & ","
                    'THIS CODE WAS IN V1.02
                    'j = j & """cessAdvol"":""" & "0" & """" & ","
                    j = j & """cessNonAdvol"":""" & "0" & """" & ","
                    j = j & """taxableAmount"":""" & Val(TXTTAXABLEAMT.Text.Trim) & """"
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
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EWAYENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'DO','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                RESPONSE = ex.Response
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'DO','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                Dim ERRORMSG As String = ""
                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("message") + Len("message") + 5
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("}", STARTPOS) - 2
                ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
                MsgBox("Error While Generating EWB, " & ERRORMSG)


                Exit Sub
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()




            Dim EWBNO As String = ""

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ewayBillNo") + Len("ewayBillNo") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS)
            EWBNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            TXTEWBNO.Text = EWBNO

            'WE NEED TO UPDATE THIS EWBNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE YARNISSUE SET YARN_EWBNO = '" & TXTEWBNO.Text.Trim & "' WHERE YARN_NO = " & Val(TXTYISSUENO.Text.Trim) & " AND YARN_YEARID = " & YearId, "", "")

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'YARNISSUE','" & TOKEN & "','" & EWBNO & "','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTEWB()
        Try

            If PRINTEWAYBILL = False Then Exit Sub
            If EDIT = False Then Exit Sub
            If TXTEWBNO.Text.Trim = "" Then Exit Sub


            If MsgBox("Print EWB?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim TOKENNO As String = ""
            Dim EWBNO As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TOKENNO, '') AS TOKENNO, ISNULL(EWBNO, '') AS EWBNO ", "", " EWAYENTRY ", " AND EWBNO = '" & TXTEWBNO.Text.Trim & "' And YearId = " & YearId)
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
                File.WriteAllBytes(Application.StartupPath & "\EWB_" & TXTEWBNO.Text.Trim & ".pdf", BFFER)
                System.Diagnostics.Process.Start(Application.StartupPath & "\EWB_" & TXTEWBNO.Text.Trim & ".pdf")

                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'YARNISSUE','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'YARNISSUE','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Printing EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'YARNISSUE','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTYISSUENO.Text.Trim) & ",'YARNISSUE','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTAXABLEAMT_Validated(sender As Object, e As EventArgs) Handles TXTTAXABLEAMT.Validated
        TOTAL()
    End Sub

    Private Sub TXTYISSUENO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTYISSUENO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTYISSUENO_Validating(sender As Object, e As CancelEventArgs) Handles TXTYISSUENO.Validating
        Try
            If Val(TXTYISSUENO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(YARNISSUE.YARN_NO,0)  AS YARNNO", "", " YARNISSUE ", "  AND YARNISSUE.YARN_NO=" & TXTYISSUENO.Text.Trim & " AND YARNISSUE.YARN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Issue No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validated(sender As Object, e As EventArgs) Handles CMBGODOWN.Validated
        Try
            If CMBGODOWN.Text.Trim <> "" Then CMBGODOWN.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUALAMT_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALAMT.CheckedChanged
        TOTAL()
    End Sub
End Class