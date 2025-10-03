
Imports BL
Imports System.ComponentModel

Public Class SaleOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim PARTYPONO As String
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPSONO As String

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            'CALL TOTAL HERE, DONE BY GULKIT
            total()

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            If TXTSONO.ReadOnly = True Then
                alParaval.Add(0)
            Else
                alParaval.Add(Val(TXTSONO.Text.Trim))
            End If

            alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBHASTE.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)

            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(DUEDATE.Value)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(cmbtrans2.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)

            alParaval.Add(CMBRISK.Text.Trim)
            alParaval.Add(TXTCONSIGNOR.Text.Trim)
            alParaval.Add(TXTCONSIGNEE.Text.Trim)
            alParaval.Add(CMBPACKING.Text.Trim)
            alParaval.Add(CMBCURRENCY.Text.Trim)
            alParaval.Add(LBLTOTALQTY.Text.Trim)
            alParaval.Add(LBLTOTALMTRS.Text.Trim)
            alParaval.Add(LBLTOTALDESIGN.Text.Trim)       '' *** TOTAL DSIGNS 
            alParaval.Add(lbltotalamt.Text.Trim)

            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(txtnote.Text.Trim)
            alParaval.Add(txttnc.Text.Trim)


            alParaval.Add(Val(TXTDISC.Text.Trim))
            alParaval.Add(Val(TXTCASHDISC.Text.Trim))
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(CMBSALESMAN.Text.Trim)
            alParaval.Add(CMBPACKINGTYPE.Text.Trim)
            alParaval.Add(CMBFORWARD.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim MERCHANT As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim gridremarks As String = ""
            Dim COLOR As String = ""
            Dim PARTYPONO As String = ""
            Dim qty As String = ""
            Dim QTYUNIT As String = ""
            Dim CUT As String = ""
            Dim MTRS As String = ""
            Dim RATE As String = ""
            Dim PER As String = ""
            Dim AMOUNT As String = ""
            Dim RECDQTY As String = ""
            Dim RECDMTRS As String = ""
            Dim DONE As String = ""
            Dim SAMPLEDONE As String = ""
            Dim CLOSED As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        MERCHANT = row.Cells(gitemname.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        PARTYPONO = row.Cells(GPARTYPONO.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value.ToString
                        QTYUNIT = row.Cells(gqtyunit.Index).Value.ToString
                        CUT = row.Cells(gcut.Index).Value
                        MTRS = row.Cells(GMTRS.Index).Value
                        RATE = row.Cells(GRATE.Index).Value
                        PER = row.Cells(GPER.Index).Value
                        AMOUNT = row.Cells(GAMOUNT.Index).Value
                        RECDQTY = Val(row.Cells(GRECDQTY.Index).Value)
                        RECDMTRS = Val(row.Cells(GRECDMTRS.Index).Value)

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then DONE = 1 Else DONE = 0
                        If Convert.ToBoolean(row.Cells(GSAMPLEDONE.Index).Value) = True Then SAMPLEDONE = 1 Else SAMPLEDONE = 0
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(gsrno.Index).Value.ToString
                        MERCHANT = MERCHANT & "|" & row.Cells(gitemname.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        PARTYPONO = PARTYPONO & "|" & row.Cells(GPARTYPONO.Index).Value.ToString
                        qty = qty & "|" & row.Cells(gQty.Index).Value.ToString
                        QTYUNIT = QTYUNIT & "|" & row.Cells(gqtyunit.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(gcut.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value
                        PER = PER & "|" & row.Cells(GPER.Index).Value
                        AMOUNT = AMOUNT & "|" & row.Cells(GAMOUNT.Index).Value
                        RECDQTY = RECDQTY & "|" & Val(row.Cells(GRECDQTY.Index).Value)
                        RECDMTRS = RECDMTRS & "|" & Val(row.Cells(GRECDMTRS.Index).Value)

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then DONE = DONE & "|" & "1" Else DONE = DONE & "|" & "0"
                        If Convert.ToBoolean(row.Cells(GSAMPLEDONE.Index).Value) = True Then SAMPLEDONE = SAMPLEDONE & "|" & "1" Else SAMPLEDONE = SAMPLEDONE & "|" & "0"
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(MERCHANT)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(gridremarks)
            alParaval.Add(COLOR)
            alParaval.Add(PARTYPONO)
            alParaval.Add(qty)
            alParaval.Add(QTYUNIT)
            alParaval.Add(CUT)
            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(PER)
            alParaval.Add(AMOUNT)
            alParaval.Add(RECDQTY)
            alParaval.Add(RECDMTRS)
            alParaval.Add(DONE)
            alParaval.Add(SAMPLEDONE)
            alParaval.Add(CLOSED)

            Dim OBJSO As New ClsSaleOrder()
            OBJSO.alParaval = alParaval


            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = OBJSO.SAVE()
                MessageBox.Show("Details Added")
                TXTSONO.Text = DT.Rows(0).Item(0)
            Else
                alParaval.Add(TEMPSONO)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = OBJSO.UPDATE()
                MessageBox.Show("Details Updated")
            End If

            If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PRINTREPORT()

            EDIT = False
            CLEAR()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXIT.Click
        Me.Close()
    End Sub

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.GotFocus
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND ACC_TYPE='AGENT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID(MATCHING As String)

        GRIDSO.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDSO.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, txtgridremarks.Text.Trim, MATCHING, TXTPARTYPONO.Text.Trim, Format(Val(txtQTY.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMOUNT.Text.Trim), "0.00"), 0, 0, 0, 0, 0)
            GETSRNO(GRIDSO)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSO.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDSO.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
            GRIDSO.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDSO.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDSO.Item(gdesc.Index, TEMPROW).Value = txtgridremarks.Text.Trim
            GRIDSO.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDSO.Item(GPARTYPONO.Index, TEMPROW).Value = TXTPARTYPONO.Text.Trim
            GRIDSO.Item(gQty.Index, TEMPROW).Value = Format(Val(txtQTY.Text.Trim), "0.00")
            GRIDSO.Item(gqtyunit.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
            GRIDSO.Item(gcut.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
            GRIDSO.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDSO.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDSO.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim
            GRIDSO.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False
        End If

        GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1

    End Sub

    Sub CLEAR()
        Try
            cmbname.Enabled = True
            CMBPACKING.Enabled = True

            TXTBARCODE.Clear()
            tstxtbillno.Clear()
            TXTMOBILENO.Clear()
            CMBPACKINGTYPE.Text = ""
            LBLPACKINGTYPE.Text = ""
            SODATE.Text = Now.Date
            cmbname.Text = ""
            cmbname.Enabled = True
            CMBHASTE.Text = ""
            CMBAGENT.Text = ""
            CMBCURRENCY.Text = ""
            CMBRISK.Text = ""
            CMBSALESMAN.Text = ""
            CMBFORWARD.Text = ""
            LBLBALQTY.Text = 0

            TXTITEMNAME.Clear()
            TXTCATEGORY.Clear()

            txtpono.Clear()
            DUEDATE.Value = Now.Date
            deldate.Value = Now.Date
            TXTCRDAYS.Clear()
            txtDeliveryadd.Clear()
            TXTCOPYSONO.Clear()

            CMBPACKING.Text = ""

            cmbtrans.Text = ""
            cmbtrans2.Text = ""
            cmbcity.Text = ""
            TXTREFNO.Clear()

            TXTCONSIGNOR.Text = CmpName
            TXTCONSIGNEE.Clear()

            TXTDISC.Clear()
            TXTCASHDISC.Clear()
            TXTCRDAYS.Clear()

            TXTAMOUNT.Clear()
            TXTRATE.Clear()
            LBLTOTALDESIGN.Text = ""

            txtsrno.Text = 1
            CMBITEMCODE.Text = ""
            cmbitemname.Text = ""
            CMBQUALITY.Text = ""
            CMBDESIGN.Text = ""
            txtgridremarks.Clear()
            cmbcolor.Text = ""
            TXTPARTYPONO.Clear()
            txtQTY.Clear()
            cmbqtyunit.Text = "PCS"

            TXTCUT.Clear()
            TXTMTRS.Clear()
            TXTRATE.Clear()
            CMBPER.Text = "Mtrs"
            TXTAMOUNT.Clear()

            cmbtrans.Text = ""
            cmbtrans2.Text = ""
            txtlrno.Clear()
            cmbcity.Text = ""
            txttransremarks.Clear()
            txttransref.Clear()


            EP.Clear()
            lbllocked.Visible = False
            PBlock.Visible = False
            LBLCLOSED.Visible = False
            LBLSMS.Visible = False
            LBLTOTALMTRS.Text = "0.00"

            TXTREMARKS.Clear()
            txtinwordedu.Clear()
            txtinwordexcise.Clear()
            txtinwordhse.Clear()
            txtinwords.Clear()

            txtadd.Clear()
            txtnote.Clear()
            txttnc.Clear()

            GRIDSO.RowCount = 0
            getmax_SO_no()
            GRIDDOUBLECLICK = False


            TXTREMARKS.Clear()

            cmbgodown1.Text = ""
            cmbgodown2.Text = ""

            TXTSTOCKITEMNAME.Clear()
            TXTPCSINHOUSE.Clear()
            TXTPCSJOBBER.Clear()
            TXTPCSORDERED.Clear()
            TXTMTRSINHOUSE.Clear()
            TXTMTRSJOBBER.Clear()
            TXTMTRSORDERED.Clear()
            TXTPCSBALANCE.Clear()
            TXTMTRSBALANCE.Clear()

            TXTSONO.ReadOnly = False


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmax_SO_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SO_no),0) + 1 ", "SALEORDER", " AND SO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub TOTAL()
        LBLTOTALQTY.Text = 0.0
        LBLTOTALMTRS.Text = 0.0


        For Each row As DataGridViewRow In GRIDSO.Rows
            If Val(row.Cells(gQty.Index).EditedFormattedValue) > 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
            If Val(row.Cells(GMTRS.Index).EditedFormattedValue) > 0 Then LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
            If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Then
                If Val(row.Cells(GRATE.Index).EditedFormattedValue) > 0 Then row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
            ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Qty" Then
                If Val(row.Cells(GRATE.Index).EditedFormattedValue) > 0 Then row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
            End If
            If Val(row.Cells(GAMOUNT.Index).EditedFormattedValue) > 0 Then lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
        Next
        DESIGNCOUNT()
    End Sub

    Sub DESIGNCOUNT()
        Try
            LBLTOTALDESIGN.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDSO.Rows.Count - 1
                If Not GRIDSO.Rows(i).IsNewRow Then
                    cellValue = GRIDSO(GDESIGN.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALDESIGN.Text = Val(dic.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Buyer Name ")
            bln = False
        End If

        If GRIDSO.RowCount = 0 Then
            EP.SetError(TXTAMOUNT, "Enter Item Details")
            bln = False
        End If


        Dim OBJCMN As New ClsCommon
        Dim DTTABLE As New DataTable
        For Each row As DataGridViewRow In GRIDSO.Rows
            If Val(row.Cells(gQty.Index).Value) = 0 Then
                EP.SetError(cmbname, "Qty Cannot be 0")
                bln = False
            End If
        Next


        If lbllocked.Visible = True And LBLCLOSED.Visible = False Then
            EP.SetError(lbllocked, "Unable to Update, SO Locked")
            bln = False
        ElseIf lbllocked.Visible = True And LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Unable to Update, SO Closed")
            bln = False
        End If

        If SODATE.Text = "__/__/____" Then
            EP.SetError(SODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(SODATE.Text) Then
                EP.SetError(SODATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If Val(TXTSONO.Text.Trim) > 0 And EDIT = False And TXTSONO.ReadOnly = False Then
            DTTABLE = OBJCMN.search("  ISNULL(so_no, 0) AS SONO ", "", " SALEORDER ", "  AND SALEORDER.so_no=" & TXTSONO.Text.Trim & " AND SALEORDER.SO_CMPID = " & CmpId & " AND SALEORDER.SO_LOCATIONID = " & Locationid & " AND SALEORDER.SO_YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then
                EP.SetError(TXTSONO, "Sale Order No Already Exist")
                bln = False
            End If
        End If


        Return bln
    End Function

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbCITY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.GotFocus
        Try
            If cmbcity.Text.Trim = "" Then fillCITY(cmbcity, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TexPro_V1")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKING.Enter
        Try
            If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')   AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKING.Validating
        Try
            If CMBPACKING.Text.Trim <> "" Then namevalidate(CMBPACKING, CMBCODE, e, Me, txtDeliveryadd, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text, CMBAGENT.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALEORDER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()
            cmbname.Enabled = True

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSO As New ClsSaleOrder()
                Dim DT As DataTable = OBJSO.SELECTSO(TEMPSONO, YearId)
                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows

                        TXTSONO.Text = dr("SONO")
                        TXTSONO.ReadOnly = True
                        SODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))

                        CMBHASTE.Text = Convert.ToString(dr("HASTE"))
                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        CMBRISK.Text = Convert.ToString(dr("RISK"))

                        txtpono.Text = Convert.ToString(dr("PONO"))
                        DUEDATE.Value = Convert.ToDateTime(dr("DUEDATE"))
                        daysremains()

                        cmbtrans.Text = Convert.ToString(dr("TRANS"))
                        cmbtrans2.Text = Convert.ToString(dr("TRANS2"))
                        cmbcity.Text = Convert.ToString(dr("CITY"))
                        TXTREFNO.Text = Convert.ToString(dr("REFNO"))

                        TXTCONSIGNEE.Text = Convert.ToString(dr("CONSIGNEE"))
                        TXTCONSIGNOR.Text = Convert.ToString(dr("CONSIGNOR"))
                        CMBPACKING.Text = Convert.ToString(dr("PACKING"))
                        CMBCURRENCY.Text = Convert.ToString(dr("CURRENCY"))
                        txtnote.Text = Convert.ToString(dr("NOTE"))
                        txttnc.Text = Convert.ToString(dr("TNC"))
                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))

                        CMBSALESMAN.Text = Convert.ToString(dr("SALESMAN"))
                        CMBPACKINGTYPE.Text = Convert.ToString(dr("PACKINGTYPE"))

                        CMBFORWARD.Text = dr("FORWARD")


                        GRIDSO.Rows.Add(dr("SRNO").ToString, dr("ITEM").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("GRIDREMARKS").ToString, dr("COLOR").ToString, dr("PARTYPONO"), Format(Val(dr("QTY")), "0.00"), dr("UNIT").ToString, Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), Format(Val(dr("AMOUNT")), "0.00"), Val(dr("RECDQTY")), Val(dr("RECDMTRS")), dr("DONE"), dr("SAMPLEDONE"), dr("CLOSED"))

                        If Val(dr("RECDQTY")) > 0 Or Val(dr("RECDMTRS")) > 0 Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                            If ClientName <> "DAKSH" And ClientName <> "SHALIBHADRA" Then cmbname.Enabled = False
                        End If

                        If Convert.ToBoolean(dr("SMSSEND")) = True Then LBLSMS.Visible = True

                        TXTDISC.Text = dr("DISCDEALER")
                        TXTCASHDISC.Text = dr("CD")
                        TXTCRDAYS.Text = dr("DAYS")

                        If lbllocked.Visible = True Then
                            cmbname.Enabled = False
                            CMBPACKING.Enabled = False
                        End If

                    Next
                    GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1
                Else
                    EDIT = False
                    clear()

                End If
                total()

            End If

            If GRIDSO.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSO.Rows(GRIDSO.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' AND ACC_TYPE='AGENT'")
            If cmbtrans.Text.Trim = "" Then filltransname(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE='TRANSPORT'")
            If cmbtrans2.Text.Trim = "" Then filltransname(cmbtrans2, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE='TRANSPORT'")
            fillCITY(cmbcity, EDIT)

            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            fillunit(cmbqtyunit)

            If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub daysremains()
        Dim tsTimeSpan As TimeSpan
        'tsTimeSpan = deldate.Value.Subtract(SODATE.Value)
        tsTimeSpan = deldate.Value.Subtract(Format(Convert.ToDateTime(SODATE.Text), "dd/MM/yyyy"))
        TXTCRDAYS.Text = tsTimeSpan.Days
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub SALEORDER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F5 Then       'for grid foucs
                GRIDSO.Focus()
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                ToolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                Toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call ToolStripButton3_Click(sender, e)
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F12 Then
                Dim OBJRATE As New PurchaseItemRateReport
                If cmbname.Text <> "" Then OBJRATE.WHERECLAUSE = OBJRATE.WHERECLAUSE & " and LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "'"
                If cmbitemname.Text <> "" Then OBJRATE.WHERECLAUSE = OBJRATE.WHERECLAUSE & " and ITEMMASTER.ITEM_NAME='" & cmbitemname.Text.Trim & "'"
                OBJRATE.MdiParent = MDIMain
                OBJRATE.FRMSTRING = "SALE"
                OBJRATE.Show()
                Exit Sub
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then txtsrno.Text = GRIDSO.RowCount + 1
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

    Sub GETPENDINGBALES(ByVal ROW As Integer)
        Try
            If SALEORDERONMTRS = False Then LBLBALQTY.Text = Val(GRIDSO.Item(gQty.Index, ROW).EditedFormattedValue) - Val(GRIDSO.Item(GRECDQTY.Index, ROW).EditedFormattedValue) Else LBLBALQTY.Text = Val(GRIDSO.Item(GMTRS.Index, ROW).EditedFormattedValue) - Val(GRIDSO.Item(GRECDMTRS.Index, ROW).EditedFormattedValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSO.CellClick
        Try
            'GET BALANCE BALES AND GETSTOCK
            If e.RowIndex >= 0 Then
                GETPENDINGBALES(e.RowIndex)
                GETSTOCK(GRIDSO.CurrentRow.Cells(gitemname.Index).Value, GRIDSO.CurrentRow.Cells(GDESIGN.Index).Value, GRIDSO.CurrentRow.Cells(gcolor.Index).Value)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSO.CellDoubleClick
        EDITROW()
    End Sub

    Sub CALC()
        Try
            If Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(TXTCUT.Text.Trim) * Val(txtQTY.Text.Trim), "0.00")
            If CMBPER.Text.Trim = "Mtrs" Then
                TXTAMOUNT.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTMTRS.Text.Trim), "0.00")
            Else
                TXTAMOUNT.Text = Format(Val(TXTRATE.Text.Trim) * Val(txtQTY.Text.Trim), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If cmbitemname.Text.Trim = "" And CMBDESIGN.Text.Trim <> "" Then CMBDESIGN_Validated(sender, e)
            If cmbitemname.Text.Trim <> "" And CMBDESIGN.Text.Trim <> "" And Val(txtQTY.Text.Trim) > 0 Then

                'IF COLOR IS NOT BLANK THEN ADD ONLY THAT MATCHING
                If cmbcolor.Text.Trim = "" And GRIDDOUBLECLICK = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT COLORMASTER.COLOR_name AS MATCHING FROM DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID INNER JOIN COLORMASTER ON DESIGNMASTER_COLOR.DESIGN_COLORID = COLORMASTER.COLOR_id WHERE DESIGNMASTER.DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGNMASTER.DESIGN_YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DT.Rows
                        CALC()
                        fillgrid(DTROW("MATCHING"))
                        total()
                    Next
                Else
                    CALC()
                    fillgrid(cmbcolor.Text.Trim)
                    total()
                End If

                txtsrno.Text = GRIDSO.RowCount + 1
                cmbitemname.Text = ""
                TXTPARTYPONO.Clear()
                txtgridremarks.Clear()
                cmbcolor.Text = ""
                txtQTY.Clear()
                TXTRATE.Clear()
                TXTMTRS.Clear()
                CMBPER.Text = "Mtrs"
                TXTAMOUNT.Clear()
                TXTITEMNAME.Clear()
                TXTCATEGORY.Clear()

                CMBDESIGN.Focus()

            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQTY.KeyPress, TXTCRDAYS.KeyPress, TXTSONO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTCASHDISC.KeyPress, TXTDISC.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try
            If EDIT = False Then Exit Sub

            If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

            If lbllocked.Visible = True Then
                MsgBox("Unable to Delete, SO Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Delete Sale Order ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim alParaval As New ArrayList
            alParaval.Add(TXTSONO.Text.Trim)
            alParaval.Add(YearId)

            Dim OBJSO As New ClsSaleOrder()
            OBJSO.alParaval = alParaval
            IntResult = OBJSO.DELETE()
            MsgBox("Sale Order Deleted")
            clear()
            EDIT = False

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS", cmbtrans.Text, CMBAGENT.Text)
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_CRDAYS,0) AS CRDAYS, ISNULL(ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO,ISNULL(PACKINGTYPEMASTER.PACKINGTYPE_name, '') AS PACKINGTYPE,ISNULL(SALESMANMASTER.SALESMAN_NAME, '') AS SALESMAN, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME", "", "  LEDGERS LEFT OUTER JOIN PACKINGTYPEMASTER ON LEDGERS.ACC_PACKINGTYPEID = PACKINGTYPEMASTER.PACKINGTYPE_id LEFT OUTER JOIN SALESMANMASTER ON LEDGERS.ACC_SALESMANID = SALESMANMASTER.SALESMAN_ID LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_DELIVERYATID = CITY_ID ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTCRDAYS.Text = Val(DT.Rows(0).Item("CRDAYS"))
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                    If CMBPACKINGTYPE.Text.Trim = "" Then
                        CMBPACKINGTYPE.Text = DT.Rows(0).Item("PACKINGTYPE")
                        cmbcity.Text = DT.Rows(0).Item("CITYNAME")
                    End If
                    CMBSALESMAN.Text = DT.Rows(0).Item("SALESMAN")

                    TXTCONSIGNEE.Text = cmbname.Text
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSO.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = GRIDSO.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case GRATE.Index, gQty.Index, gcut.Index, GMTRS.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDSO.CurrentCell.Value = Nothing Then GRIDSO.CurrentCell.Value = "0.00"
                    GRIDSO.CurrentCell.Value = Convert.ToDecimal(GRIDSO.Item(colNum, e.RowIndex).Value)
                    '' everything is good

                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If
                total()

        End Select
    End Sub

    Sub EDITROW()
        Try
            If GRIDSO.CurrentRow.Index >= 0 And GRIDSO.Item(gsrno.Index, GRIDSO.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(GRIDSO.Rows(GRIDSO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                    MsgBox("Item Locked. First Delete from SALEORDER")
                    Exit Sub
                End If
                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDSO.Item(gsrno.Index, GRIDSO.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDSO.Item(gitemname.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDSO.Item(GQUALITY.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDSO.Item(GDESIGN.Index, GRIDSO.CurrentRow.Index).Value.ToString
                txtgridremarks.Text = GRIDSO.Item(gdesc.Index, GRIDSO.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDSO.Item(gcolor.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTPARTYPONO.Text = GRIDSO.Item(GPARTYPONO.Index, GRIDSO.CurrentRow.Index).Value.ToString
                txtQTY.Text = GRIDSO.Item(gQty.Index, GRIDSO.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = GRIDSO.Item(gqtyunit.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDSO.Item(gcut.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDSO.Item(GMTRS.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDSO.Item(GRATE.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBPER.Text = GRIDSO.Item(GPER.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDSO.Item(GAMOUNT.Index, GRIDSO.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSO.CurrentRow.Index
                CMBDESIGN.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSO.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block


                'DONT ALLOW TO DELETE ANY ROW IF LOCKED IS VISIBLE
                If lbllocked.Visible = True Then
                    MessageBox.Show("Unable to Delete Row, Sale Order is Locked")
                    Exit Sub
                End If


                GRIDSO.Rows.RemoveAt(GRIDSO.CurrentRow.Index)
                total()
                getsrno(GRIDSO)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSO.RowCount = 0
                TEMPSONO = Val(tstxtbillno.Text)
                If TEMPSONO > 0 Then
                    EDIT = True
                    SALEORDER_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCRDAYS.Validated
        'deldate.Value = DateAdd(DateInterval.Day, CDbl(Val(txtcrdays.Text)), SODATE.Value)
        Try
            If SODATE.Text = "__/__/____" Then
                If Val(TXTCRDAYS.Text.Trim) > 0 Then deldate.Value = Convert.ToDateTime(SODATE.Text).Date.AddDays(Val(TXTCRDAYS.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub deldate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles deldate.Validating
        daysremains()
    End Sub

    Private Sub txtqty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQTY.Validating
        CALC()
    End Sub

    Private Sub ToolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPREVIOUS.Click
        Try
            GRIDSO.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTSONO.Text) - 1
            If TEMPSONO > 0 Then
                EDIT = True
                SALEORDER_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSO.RowCount = 0 And TEMPSONO > 1 Then
                TXTSONO.Text = TEMPSONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolnext.Click
        Try
            GRIDSO.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTSONO.Text) + 1
            getmax_SO_no()
            Dim MAXNO As Integer = TXTSONO.Text.Trim
            clear()
            If Val(TXTSONO.Text) - 1 >= TEMPSONO Then
                EDIT = True
                SALEORDER_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSO.RowCount = 0 And TEMPSONO < MAXNO Then
                TXTSONO.Text = TEMPSONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            Dim OBJsaleOrder As New SaleOrderDesign
            OBJsaleOrder.MdiParent = MDIMain
            OBJsaleOrder.FRMSTRING = "SOREPORT"
            OBJsaleOrder.PARTYNAME = cmbname.Text.Trim
            OBJsaleOrder.AGENTNAME = CMBAGENT.Text.Trim
            OBJsaleOrder.SONO = Val(TXTSONO.Text.Trim)
            OBJsaleOrder.FORMULA = "{saleOrder.so_no}=" & Val(TXTSONO.Text) & " and {saleOrder.SO_yearid}=" & YearId
            If MsgBox("Hide Rate?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJsaleOrder.HIDERATE = 1
            OBJsaleOrder.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then filltransname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE='TRANSPORT'")
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
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"

                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans2.Enter
        Try
            If cmbtrans2.Text.Trim = "" Then filltransname(cmbtrans2, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans2.Validating
        Try
            If cmbtrans2.Text.Trim <> "" Then namevalidate(cmbtrans2, CMBCODE, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSO As New SaleOrderDetails
            OBJSO.MdiParent = MDIMain
            OBJSO.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdOK_Click(sender, e)
    End Sub

    Private Sub CMBGODOWN1_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodown1.Enter
        Try
            If cmbgodown1.Text.Trim = "" Then fillGODOWN(cmbgodown1, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodown1.Validating
        Try
            If cmbgodown1.Text.Trim <> "" Then GODOWNVALIDATE(cmbgodown1, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN2_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodown2.Enter
        Try
            If cmbgodown2.Text.Trim = "" Then fillGODOWN(cmbgodown2, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodown2.Validating
        Try
            If cmbgodown2.Text.Trim <> "" Then GODOWNVALIDATE(cmbgodown2, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLCLOSE.Click
        Try
            Dim OBJSO As New SaleOrderClose
            OBJSO.MdiParent = MDIMain
            OBJSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleOrder_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND ACC_TYPE='AGENT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
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
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me, cmbitemname.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans2.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans2.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcity.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then cmbcity.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.Enter
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbqtyunit.Validating
        Try
            If cmbqtyunit.Text.Trim <> "" Then unitvalidate(cmbqtyunit, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPER.Validated
        CALC()
    End Sub

    Private Sub TXTCUT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCUT.Validating
        CALC()
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress
        numdotkeypress(e, TXTMTRS, Me)
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        CALC()
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

    Private Sub CMBQUALITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQ As New SelectQuality
                OBJQ.FRMSTRING = "QUALITY"
                OBJQ.ShowDialog()
                If OBJQ.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQ.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
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

    Private Sub TXTREMARKS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTREMARKS.KeyDown
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

    Sub GETSTOCK(ByVal ITEMNAME As String, ByVal DESIGNNO As String, ByVal COLOR As String)
        Try
            If ITEMNAME <> "" And DESIGNNO <> "" And COLOR <> "" Then

                'GET STOCK OF THIS ITEM
                TXTPCSINHOUSE.Clear()
                TXTMTRSINHOUSE.Clear()
                TXTPCSJOBBER.Clear()
                TXTMTRSJOBBER.Clear()
                TXTPCSORDERED.Clear()
                TXTMTRSORDERED.Clear()
                TXTPCSBALANCE.Clear()
                TXTMTRSBALANCE.Clear()

                TXTSTOCKITEMNAME.Text = ITEMNAME
                Dim WHERECLAUSE As String = " AND YEARID = " & YearId & " AND ITEMNAME = '" & ITEMNAME & "' AND DESIGNNO = '" & DESIGNNO & "' AND COLOR = '" & COLOR & "'"

                'IN HOUSE STOCK
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(SUM(PCS),0) AS PCS, ISNULL(SUM(MTRS),0) AS MTRS", "", "BARCODESTOCK", WHERECLAUSE & " AND ROUND(MTRS,0) > 0 ")
                If DT.Rows.Count > 0 Then
                    TXTPCSINHOUSE.Text = Val(DT.Rows(0).Item("PCS"))
                    TXTMTRSINHOUSE.Text = Val(DT.Rows(0).Item("MTRS"))
                End If


                'WEAVER CUTSTOCK
                DT = OBJCMN.search("ISNULL(SUM(CUT),0) AS PCS, 0 AS MTRS", "", "BALANCECUT", " AND YEARID = " & YearId & " AND ITEMNAME = '" & ITEMNAME & "' AND DESIGNNO = '" & DESIGNNO & "' AND MATCHING = '" & COLOR & "'")
                If DT.Rows.Count > 0 Then
                    TXTPCSJOBBER.Text = Val(DT.Rows(0).Item("PCS"))
                    TXTMTRSJOBBER.Text = Val(DT.Rows(0).Item("MTRS"))
                End If


                'PENDING SALE ORDER STOCK
                DT = OBJCMN.search("(ISNULL(ALLSALEORDER_DESC.SO_QTY,0) - ISNULL(ALLSALEORDER_DESC.SO_RECDQTY,0)) AS PCS, (ISNULL(ALLSALEORDER_DESC.SO_MTRS,0) - ISNULL(ALLSALEORDER_DESC.SO_RECDMTRS,0)) AS MTRS", "", " ALLSALEORDER_DESC INNER JOIN ITEMMASTER ON ALLSALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id INNER JOIN DESIGNMASTER ON ALLSALEORDER_DESC.SO_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER ON ALLSALEORDER_DESC.SO_COLORID = COLORMASTER.COLOR_id ", " AND (ALLSALEORDER_DESC.SO_QTY - ALLSALEORDER_DESC.SO_RECDQTY) > 0 AND ITEMMASTER.ITEM_NAME = '" & ITEMNAME & "' AND DESIGN_NO = '" & DESIGNNO & "' AND ISNULL(COLOR_NAME,'') = '" & COLOR & "' AND ALLSALEORDER_DESC.SO_CLOSED = 'FALSE' AND ALLSALEORDER_DESC.SO_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTPCSORDERED.Text = Val(DT.Rows(0).Item("PCS"))
                    TXTMTRSORDERED.Text = Val(DT.Rows(0).Item("MTRS"))
                End If

                'BALANCE STOCK
                TXTPCSBALANCE.Text = Val(TXTPCSINHOUSE.Text.Trim) + Val(TXTPCSJOBBER.Text.Trim) - Val(TXTPCSORDERED.Text.Trim)
                TXTMTRSBALANCE.Text = Val(TXTMTRSINHOUSE.Text.Trim) + Val(TXTMTRSJOBBER.Text.Trim) - Val(TXTMTRSORDERED.Text.Trim)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SODATE.GotFocus
        SODATE.SelectAll()
    End Sub

    Private Sub SODATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SODATE.Validating
        Try
            If SODATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SODATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                    If Not datecheck(SODATE.Text) Then
                        EP.SetError(SODATE, "Date not in Accounting Year")
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='Sundry Debtors' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSALESMAN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSALESMAN.Enter
        Try
            If CMBSALESMAN.Text.Trim = "" Then FILLSALESMAN(CMBSALESMAN)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSALESMAN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSALESMAN.Validating
        Try
            If CMBSALESMAN.Text.Trim <> "" Then SALESMANVALIDATE(CMBSALESMAN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTSONO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSONO.Validating
        Try
            If Val(TXTSONO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search("  ISNULL(so_no, 0) AS SONO ", "", " SALEORDER ", "  AND SALEORDER.so_no=" & Val(TXTSONO.Text.Trim) & " AND SALEORDER.SO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Sale Order No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Validated
        Try
            If CMBDESIGN.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME, ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " DESIGNMASTER INNER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbitemname.Text = DT.Rows(0).Item("ITEMNAME")
                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    TXTCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
                End If
                GETSTOCK(cmbitemname.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Validated
        Try
            If cmbitemname.Text.Trim <> "" And cmbname.Text.Trim <> "" Then

                'GET STAMPING
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(PARTYITEMWISECHART.PAR_STAMPING, '') AS STAMPING", "", " PARTYITEMWISECHART INNER JOIN LEDGERS ON PARTYITEMWISECHART.PAR_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PARTYITEMWISECHART.PAR_ITEMID = ITEMMASTER.item_id ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND ITEMMASTER.ITEM_NAME = '" & cmbitemname.Text.Trim & " ' AND PARTYITEMWISECHART.PAR_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso txtgridremarks.Text.Trim = "" Then txtgridremarks.Text = (DT.Rows(0).Item("STAMPING"))

                'GET RATE
                'FOR THIS WE NEED TO GET THE COLUMN NAME FROM RATETYPEMASREER 
                DT = OBJCMN.search(" ISNULL(LEDGERS.ACC_PRICELISTCOLUMN, '') AS COLNAME", "", " LEDGERS ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("COLNAME") <> "" Then
                    Dim DTRATE As DataTable = OBJCMN.search(DT.Rows(0).Item("COLNAME") & " AS RATE", "", "ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMPRICELIST.ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & cmbitemname.Text.Trim & "' AND ITEM_YEARID = " & YearId)
                    If DTRATE.Rows.Count > 0 AndAlso Val(TXTRATE.Text.Trim) = 0 Then TXTRATE.Text = Val(DTRATE.Rows(0).Item("RATE"))
                End If


                If (ClientName = "MAHAVIR" Or ClientName = "BARKHA") Then
                    DT = OBJCMN.search("  ISNULL(item_reorder, 0) AS CUT, ISNULL(ITEM_RATE, 0) AS RATE,ISNULL(ITEM_FOLD, '') AS [DESC],ISNULL(UNITMASTER.unit_abbr, '') AS UNIT", "", " ITEMMASTER LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id ", " AND ITEMMASTER.item_name = '" & cmbitemname.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID='" & YearId & "' ")
                    If DT.Rows.Count > 0 Then
                        TXTCUT.Text = DT.Rows(0).Item("CUT")
                        TXTRATE.Text = DT.Rows(0).Item("RATE")
                        If DT.Rows(0).Item("UNIT") = "Pcs" Then CMBPER.Text = "Pcs" Else CMBPER.Text = "Mtrs"
                        If ClientName = "MAHAVIR" Then txtgridremarks.Text = DT.Rows(0).Item("DESC")
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" And CMBPACKING.Text.Trim = "" Then CMBPACKING.Text = cmbname.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKINGTYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPACKINGTYPE.Enter
        Try
            If CMBPACKINGTYPE.Text.Trim = "" Then FILLPACKINGTYPE(CMBPACKINGTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKINGTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKINGTYPE.Validating
        Try
            If CMBPACKINGTYPE.Text.Trim <> "" Then PACKINGTYPEVALIDATE(CMBPACKINGTYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCOPYSONO_Validated(sender As Object, e As EventArgs) Handles TXTCOPYSONO.Validated
        Try
            If Val(TXTCOPYSONO.Text.Trim) > 0 And EDIT = False Then
                If MsgBox("Wish to Copy SO No " & Val(TXTCOPYSONO.Text.Trim) & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim OBJSO As New ClsSaleOrder()
                Dim DT As DataTable = OBJSO.SELECTSO(Val(TXTCOPYSONO.Text.Trim), YearId)

                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows

                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))

                        CMBHASTE.Text = Convert.ToString(dr("HASTE"))
                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        CMBRISK.Text = Convert.ToString(dr("RISK"))

                        txtpono.Text = Convert.ToString(dr("PONO"))
                        DUEDATE.Value = Convert.ToDateTime(dr("DUEDATE"))
                        daysremains()

                        cmbtrans.Text = Convert.ToString(dr("TRANS"))
                        cmbtrans2.Text = Convert.ToString(dr("TRANS2"))
                        cmbcity.Text = Convert.ToString(dr("CITY"))
                        TXTREFNO.Text = Convert.ToString(dr("REFNO"))

                        TXTCONSIGNEE.Text = Convert.ToString(dr("CONSIGNEE"))
                        TXTCONSIGNOR.Text = Convert.ToString(dr("CONSIGNOR"))
                        CMBPACKING.Text = Convert.ToString(dr("PACKING"))
                        CMBCURRENCY.Text = Convert.ToString(dr("CURRENCY"))
                        txtnote.Text = Convert.ToString(dr("NOTE"))
                        txttnc.Text = Convert.ToString(dr("TNC"))
                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))

                        CMBSALESMAN.Text = Convert.ToString(dr("SALESMAN"))

                        CMBPACKINGTYPE.Text = Convert.ToString(dr("PACKINGTYPE"))

                        CMBFORWARD.Text = dr("FORWARD")


                        GRIDSO.Rows.Add(dr("SRNO").ToString, dr("ITEM").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("GRIDREMARKS").ToString, dr("COLOR").ToString, dr("PARTYPONO"), Format(Val(dr("QTY")), "0.00"), dr("UNIT").ToString, Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), Format(Val(dr("AMOUNT")), "0.00"), 0, 0, 0, 0, 0)

                        TXTDISC.Text = dr("DISCDEALER")
                        TXTCASHDISC.Text = dr("CD")
                        TXTCRDAYS.Text = dr("DAYS")
                    Next
                    GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Enter(sender As Object, e As EventArgs) Handles CMBCURRENCY.Enter
        Try
            If CMBCURRENCY.Text.Trim = "" Then fillCURRENCY(CMBCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCURRENCY.Validating
        Try
            If CMBCURRENCY.Text.Trim <> "" Then CURRENCYVALIDATE(CMBCURRENCY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validated(sender As Object, e As EventArgs) Handles cmbcolor.Validated
        Try
            GETSTOCK(cmbitemname.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                'GET DATA FROM SAMPLE BARCODE
                'no need for yearid clause here as we need to fetch this barcode in all acccouting year
                DT = OBJCMN.search(" SAMPLEBARCODE.SB_NO AS SBNO, SAMPLEBARCODE.SB_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(SAMPLEBARCODE.SB_REMARKS, '') AS REMARKS, SAMPLEBARCODE.SB_BARCODE AS BARCODE, ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " SAMPLEBARCODE INNER JOIN ITEMMASTER ON SAMPLEBARCODE.SB_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID LEFT OUTER JOIN COLORMASTER ON SAMPLEBARCODE.SB_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SAMPLEBARCODE.SB_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND SB_BARCODE = '" & TXTBARCODE.Text.Trim & "'")
                If DT.Rows.Count > 0 Then

                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    TXTCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
                    CMBDESIGN.Text = DT.Rows(0).Item("DESIGNNO")
                    txtQTY.Text = 1

                    TXTRATE.Focus()
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class