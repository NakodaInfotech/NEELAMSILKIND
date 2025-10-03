
Imports BL
Imports System.IO

Public Class StockReco

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Public TEMPRECONO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Public TEMPPROFORMANO As Integer = 0
    Public UNCHECKEDSTOCK As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockReco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.OemPipe Then
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
            GRIDSTOCK.Focus()
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        End If
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            If cmbitemname.Text = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try
            Dim OBJCLSPROFORMA As New ClsProforma()
            Dim dttable As DataTable = OBJCLSPROFORMA.SELECTPROFORMA(TEMPPROFORMANO, CmpId, Locationid, YearId)
            If dttable.Rows.Count > 0 Then
                For Each dr As DataRow In dttable.Rows
                    GRIDSTOCK.Rows.Add(GRIDSTOCK.RowCount + 1, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("BALENO"), dr("DESIGN"), dr("COLOR"), Format(Val(dr("PCS")), "0"), "", Format(Val(dr("MTRS")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"))
                Next
                txtremarks.Text = "Proforma No - " & Val(TEMPPROFORMANO)
                TOTAL()
                GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETUNCHECKEDDATA()
        Try
            Dim OBJCMN As New ClsCommon()
            Dim dttable As DataTable = OBJCMN.search("BARCODESTOCK.*", "", " BARCODESTOCK ", " AND BARCODESTOCK.BARCODE NOT IN (SELECT BARCODE FROM STOCKTAKING_DESC WHERE YEARID = " & YearId & ") AND BARCODESTOCK.YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                For Each dr As DataRow In dttable.Rows
                    GRIDSTOCK.Rows.Add(GRIDSTOCK.RowCount + 1, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("BALENO"), dr("DESIGNNO"), dr("COLOR"), Format(Val(dr("PCS")), "0"), dr("UNIT"), Format(Val(dr("MTRS")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("TYPE"))
                Next
                TOTAL()
                GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockReco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()

            If TEMPPROFORMANO > 0 Then GETDATA()
            If UNCHECKEDSTOCK = True Then GETUNCHECKEDDATA()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objSTOCK As New ClsStockAdjustment()
                Dim dttable As DataTable = objSTOCK.SELECTSTOCKADJUSTMENT(TEMPRECONO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        TXTRECONO.Text = TEMPRECONO
                        DTRECODATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbtrans.Text = dr("TRANSNAME")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        If Val(dr("GRIDSRNO")) > 0 Then GRIDSTOCK.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("BALENO"), dr("DESIGNNO").ToString, dr("COLOR").ToString, Format(dr("PCS"), "0.00"), dr("UNIT"), Format(dr("MTRS"), "0.00"), dr("BARCODE").ToString, dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"))
                    Next



                    'GET DATA FROM STOCKADJUSTMENT_INDESC
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STOCKADJUSTMENT_INDESC.SA_BALENO, '')  AS BALENO, ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDDESC, '') AS GRIDDESC, ISNULL(STOCKADJUSTMENT_INDESC.SA_LOTNO, '') AS LOTNO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(STOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OURWT, 0) AS OURWT, ISNULL(STOCKADJUSTMENT_INDESC.SA_AVGWT, 0) AS AVGWT, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTPCS, 0) AS OUTPCS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTMTRS, 0) AS OUTMTRS, STOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE, ISNULL(SHELFMASTER.SHELF_NAME, '') AS INSHELF, ISNULL(RACKMASTER.RACK_NAME, '') AS INRACK ", "", " STOCKADJUSTMENT_INDESC INNER JOIN PIECETYPEMASTER ON STOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN RACKMASTER ON STOCKADJUSTMENT_INDESC.SA_RACKID = RACKMASTER.RACK_ID LEFT OUTER JOIN SHELFMASTER ON STOCKADJUSTMENT_INDESC.SA_SHELFID = SHELFMASTER.SHELF_ID LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN  ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId & " ORDER BY STOCKADJUSTMENT_INDESC.SA_GRIDSRNO")
                    For Each DR As DataRow In DT.Rows
                        'Item Grid
                        GRIDSTOCKIN.Rows.Add(DR("GRIDSRNO").ToString, DR("PIECETYPE"), DR("ITEM").ToString, DR("QUALITY").ToString, DR("BALENO").ToString, DR("GRIDDESC"), DR("LOTNO"), DR("DESIGN").ToString, DR("COLOR"), Format(Val(DR("CUT")), "0.00"), Format(Val(DR("qty")), "0.00"), DR("UNIT").ToString, Format(Val(DR("MTRS")), "0.00"), Format(Val(DR("OURWT")), "0.00"), Format(Val(DR("AVGWT")), "0.00"), DR("INRACK").ToString, DR("INSHELF").ToString, DR("BARCODE"), 0, DR("OUTPCS"), DR("OUTMTRS"))

                        If Convert.ToBoolean(DR("GRIDDONE")) = True Or Val(DR("OUTPCS")) > 0 Or Val(DR("OUTMTRS")) > 0 Then
                            GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                        TabControl1.SelectedIndex = 1
                    Next

                Else
                    EDIT = False
                    CLEAR()
                End If

                TOTAL()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub CLEAR()

        EP.Clear()
        LBLCATEGORY.Text = ""

        DTRECODATE.Value = Now.Date
        tstxtbillno.Clear()
        TXTFROM.Clear()
        TXTTO.Clear()

        txtremarks.Clear()

        CMDSELECTSTOCK.Enabled = True

        lbllocked.Visible = False
        PBlock.Visible = False

        LBLTOTALOUTMTRS.Text = 0.0
        LBLTOTALOUTPCS.Text = 0.0
        LBLTOTALINMTRS.Text = 0.0
        LBLTOTALINPCS.Text = 0.0
        LBLTOTALOURWT.Text = 0.0
        LBLAVG.Text = 0.0

        cmbtrans.Text = ""

        TXTBARCODE.Clear()

        GRIDSTOCK.RowCount = 0


        txtsrno.Text = 1
        CMBPIECETYPE.Text = ""
        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        TXTBALENO.Clear()
        TXTGRIDDESC.Clear()
        TXTLOTNO.Clear()
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTCUT.Clear()
        txtqty.Text = 1
        TXTNOOFENTRIES.Clear()
        cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        CMBRACK.Text = ""
        CMBSHELF.Text = ""

        TXTINBARCODE.Clear()
        GRIDSTOCKIN.RowCount = 0


        GRIDDOUBLECLICK = False
        TabControl1.SelectedIndex = 0
        getmaxno()


    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If ClientName = "SOFTAS" And Val(LBLTOTALINMTRS.Text.Trim) <> Val(LBLTOTALOUTMTRS.Text.Trim) Then
                EP.SetError(LBLTOTALOUTMTRS, " In & Out Mtrs Should be same")
                bln = False
            End If

            If ClientName = "SOFTAS" And Val(LBLTOTALINPCS.Text.Trim) <> Val(LBLTOTALOUTPCS.Text.Trim) Then
                EP.SetError(LBLTOTALOUTPCS, " In & Out Pcs Should be same")
                bln = False
            End If

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                If ClientName <> "PARAS" Then
                    If Val(ROW.Cells(GPCS.Index).Value) = 0 Then
                        EP.SetError(LBLTOTALOUTPCS, "Pcs Cannot be 0")
                        bln = False
                    End If
                End If

                If Val(ROW.Cells(GMTRS.Index).Value) = 0 Then
                    EP.SetError(LBLTOTALOUTMTRS, "Mtrs Cannot be 0")
                    bln = False
                End If
            Next


            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            If Not CHECKBARCODE() Then
                bln = False
                EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
            End If

            If Not datecheck(DTRECODATE.Text) Then
                EP.SetError(DTRECODATE, "Date not in Accounting Year")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Function CHECKBARCODE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(SA_BARCODE,'') AS BARCODE ", "", " STOCKADJUSTMENT_INDESC ", " AND SA_YEARID =  " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    For Each ROW As System.WINDOWS.FORMS.DataGridViewRow In GRIDSTOCKIN.Rows
                        If ((EDIT = False) And Convert.ToString(DTR("BARCODE")) = ROW.Cells(GBARCODE.Index).Value.ToString) Then
                            BLN = False
                            Exit Function
                        End If
                    Next
                Next
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        DTRECODATE.Focus()
        TEMPPROFORMANO = 0
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SA_no),0) + 1 ", " STOCKADJUSTMENT ", " AND SA_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Format(DTRECODATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(Val(LBLTOTALOUTPCS.Text))
            alParaval.Add(Val(LBLTOTALOUTMTRS.Text))

            alParaval.Add(Val(LBLTOTALINMTRS.Text))
            alParaval.Add(Val(LBLTOTALINMTRS.Text))
            alParaval.Add(Val(LBLTOTALOURWT.Text))
            alParaval.Add(Val(LBLAVG.Text))

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
            Dim BALENO As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim MTRS As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSTOCK.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString

                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        PCS = row.Cells(GPCS.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString

                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString

                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString

                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        PCS = PCS & "|" & row.Cells(GPCS.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString

                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(BALENO)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
            alParaval.Add(MTRS)

            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim INGRIDSRNO As String = ""
            Dim INPIECETYPE As String = ""
            Dim INITEMNAME As String = ""
            Dim INQUALITY As String = ""
            Dim INBALENO As String = ""
            Dim INGRIDDESC As String = ""
            Dim INLOTNO As String = ""
            Dim INDESIGN As String = ""
            Dim INCOLOR As String = ""
            Dim INCUT As String = ""
            Dim INPCS As String = ""
            Dim INQTYUNIT As String = ""
            Dim INMTRS As String = ""
            Dim OURWT As String = ""
            Dim AVGWT As String = ""
            Dim INRACK As String = ""
            Dim INSHELF As String = ""
            Dim INBARCODE As String = ""
            Dim INDONE As String = ""
            Dim INOUTPCS As String = ""
            Dim INOUTMTRS As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSTOCKIN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If INGRIDSRNO = "" Then
                        INGRIDSRNO = row.Cells(GINSRNO.Index).Value.ToString
                        INPIECETYPE = row.Cells(GINPIECETYPE.Index).Value.ToString
                        INITEMNAME = row.Cells(GINITEMNAME.Index).Value.ToString
                        INQUALITY = row.Cells(GINQUALITY.Index).Value.ToString
                        INBALENO = row.Cells(GINBALENO.Index).Value.ToString
                        INGRIDDESC = row.Cells(GINDESC.Index).Value.ToString
                        INLOTNO = row.Cells(GINLOTNO.Index).Value.ToString
                        INDESIGN = row.Cells(GINDESIGN.Index).Value.ToString
                        INCOLOR = row.Cells(GINCOLOR.Index).Value.ToString
                        INCUT = row.Cells(GINCUT.Index).Value.ToString
                        INPCS = row.Cells(GINPCS.Index).Value.ToString
                        INQTYUNIT = row.Cells(GINUNIT.Index).Value.ToString
                        INMTRS = row.Cells(GINMTRS.Index).Value
                        OURWT = Val(row.Cells(GOURWT.Index).Value)
                        AVGWT = Val(row.Cells(GAVGWT.Index).Value)
                        INRACK = row.Cells(GRACK.Index).Value.ToString
                        INSHELF = row.Cells(GSHELF.Index).Value.ToString
                        INBARCODE = row.Cells(GINBARCODE.Index).Value
                        If row.Cells(GINDONE.Index).Value = True Then
                            INDONE = 1
                        Else
                            INDONE = 0
                        End If
                        INOUTPCS = row.Cells(GINOUTPCS.Index).Value
                        INOUTMTRS = row.Cells(GINOUTMTRS.Index).Value

                    Else

                        INGRIDSRNO = INGRIDSRNO & "|" & row.Cells(GINSRNO.Index).Value
                        INPIECETYPE = INPIECETYPE & "|" & row.Cells(GINPIECETYPE.Index).Value
                        INITEMNAME = INITEMNAME & "|" & row.Cells(GINITEMNAME.Index).Value
                        INQUALITY = INQUALITY & "|" & row.Cells(GINQUALITY.Index).Value.ToString
                        INBALENO = INBALENO & "|" & row.Cells(GINBALENO.Index).Value.ToString
                        INGRIDDESC = INGRIDDESC & "|" & row.Cells(GINDESC.Index).Value.ToString
                        INLOTNO = INLOTNO & "|" & row.Cells(GINLOTNO.Index).Value.ToString
                        INDESIGN = INDESIGN & "|" & row.Cells(GINDESIGN.Index).Value.ToString
                        INCOLOR = INCOLOR & "|" & row.Cells(GINCOLOR.Index).Value.ToString
                        INCUT = INCUT & "|" & row.Cells(GINCUT.Index).Value
                        INPCS = INPCS & "|" & row.Cells(GINPCS.Index).Value
                        INQTYUNIT = INQTYUNIT & "|" & row.Cells(GINUNIT.Index).Value
                        INMTRS = INMTRS & "|" & row.Cells(GINMTRS.Index).Value
                        OURWT = OURWT & "|" & Val(row.Cells(GOURWT.Index).Value)
                        AVGWT = AVGWT & "|" & Val(row.Cells(GAVGWT.Index).Value)
                        INRACK = INRACK & "," & row.Cells(GRACK.Index).Value.ToString
                        INSHELF = INSHELF & "," & row.Cells(GSHELF.Index).Value.ToString
                        INBARCODE = INBARCODE & "|" & row.Cells(GINBARCODE.Index).Value
                        If row.Cells(GINDONE.Index).Value = True Then
                            INDONE = INDONE & "|" & "1"
                        Else
                            INDONE = INDONE & "|" & "0"
                        End If
                        INOUTPCS = INOUTPCS & "|" & row.Cells(GINOUTPCS.Index).Value
                        INOUTMTRS = INOUTMTRS & "|" & row.Cells(GINOUTMTRS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(INGRIDSRNO)
            alParaval.Add(INPIECETYPE)
            alParaval.Add(INITEMNAME)
            alParaval.Add(INQUALITY)
            alParaval.Add(INBALENO)
            alParaval.Add(INGRIDDESC)
            alParaval.Add(INLOTNO)
            alParaval.Add(INDESIGN)
            alParaval.Add(INCOLOR)
            alParaval.Add(INCUT)
            alParaval.Add(INPCS)
            alParaval.Add(INQTYUNIT)
            alParaval.Add(INMTRS)
            alParaval.Add(OURWT)
            alParaval.Add(AVGWT)
            alParaval.Add(INRACK)
            alParaval.Add(INSHELF)
            alParaval.Add(INBARCODE)
            alParaval.Add(INDONE)
            alParaval.Add(INOUTPCS)
            alParaval.Add(INOUTMTRS)



            Dim objSTOCK As New ClsStockAdjustment()
            objSTOCK.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objSTOCK.SAVE()
                MsgBox("Details Added")
                TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
                TEMPRECONO = DTTABLE.Rows(0).Item(0)
                'PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPRECONO)
                IntResult = objSTOCK.UPDATE()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPRECONO)
                EDIT = False
            End If
            If GRIDSTOCKIN.RowCount > 0 Then PRINTBARCODE()


            TEMPPROFORMANO = 0
            CLEAR()
            DTRECODATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If ALLOWBARCODEPRINT Then

                'PRINT BARCODE
                Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'GET FRESH DATA FROM DATABASE (ONLY GRID)
                'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
                'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
                GRIDSTOCKIN.RowCount = 0
                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable = OBJCMN1.search("ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STOCKADJUSTMENT_INDESC.SA_BALENO, '')  AS BALENO, ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDDESC, '') AS GRIDDESC, ISNULL(STOCKADJUSTMENT_INDESC.SA_LOTNO, '') AS LOTNO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(STOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OURWT, 0) AS OURWT, ISNULL(STOCKADJUSTMENT_INDESC.SA_AVGWT, 0) AS AVGWT, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTPCS, 0) AS OUTPCS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTMTRS, 0) AS OUTMTRS, STOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE, ISNULL(SHELFMASTER.SHELF_NAME, '') AS INSHELF, ISNULL(RACKMASTER.RACK_NAME, '') AS INRACK ", "", " STOCKADJUSTMENT_INDESC INNER JOIN PIECETYPEMASTER ON STOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN RACKMASTER ON STOCKADJUSTMENT_INDESC.SA_RACKID = RACKMASTER.RACK_ID LEFT OUTER JOIN SHELFMASTER ON STOCKADJUSTMENT_INDESC.SA_SHELFID = SHELFMASTER.SHELF_ID LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN  ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId)
                For Each DR As DataRow In DT1.Rows
                    GRIDSTOCKIN.Rows.Add(DR("GRIDSRNO").ToString, DR("PIECETYPE"), DR("ITEM").ToString, DR("QUALITY").ToString, DR("BALENO").ToString, DR("GRIDDESC"), DR("LOTNO"), DR("DESIGN").ToString, DR("COLOR"), Format(Val(DR("CUT")), "0.00"), Format(Val(DR("qty")), "0.00"), DR("UNIT").ToString, Format(Val(DR("MTRS")), "0.00"), Format(Val(DR("OURWT")), "0.00"), Format(Val(DR("AVGWT")), "0.00"), DR("INRACK").ToString, DR("INSHELF").ToString, DR("BARCODE"), 0, DR("OUTPCS"), DR("OUTMTRS"))
                Next


                Dim WHOLESALEBARCODE As Integer = 0
                Dim TEMPHEADER As String = ""
                Dim SUPRIYAHEADER As String = ""

                For Each ROW As DataGridViewRow In GRIDSTOCKIN.Rows
                    'TO PRINT BARCODE FROM SELECTED SRNO
                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                        If Val(ROW.Cells(GSRNO.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(GSRNO.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                    End If

                    BARCODEPRINTING(ROW.Cells(GINBARCODE.Index).Value, ROW.Cells(GINPIECETYPE.Index).Value, ROW.Cells(GINITEMNAME.Index).Value, ROW.Cells(GINQUALITY.Index).Value, ROW.Cells(GINDESIGN.Index).Value, ROW.Cells(GINCOLOR.Index).Value, ROW.Cells(GINUNIT.Index).Value, ROW.Cells(GINLOTNO.Index).Value, ROW.Cells(GINBALENO.Index).Value, ROW.Cells(GINDESC.Index).Value, Val(ROW.Cells(GINMTRS.Index).Value), Val(ROW.Cells(GINPCS.Index).Value), ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:

                Next
            End If

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

    Sub TOTAL()
        Try
            LBLTOTALOUTMTRS.Text = 0.0
            LBLTOTALOUTPCS.Text = 0.0
            LBLTOTALINMTRS.Text = 0.0
            LBLTOTALINPCS.Text = 0.0
            LBLTOTALOURWT.Text = 0.0
            LBLAVG.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALOUTPCS.Text = Format(Val(LBLTOTALOUTPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALOUTMTRS.Text = Format(Val(LBLTOTALOUTMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next

            For Each ROW As DataGridViewRow In GRIDSTOCKIN.Rows
                If ROW.Cells(GINSRNO.Index).Value <> Nothing Then
                    If ROW.Cells(GINCUT.Index).EditedFormattedValue > 0 Then ROW.Cells(GINMTRS.Index).Value = Val(ROW.Cells(GINPCS.Index).EditedFormattedValue) * Val(ROW.Cells(GINCUT.Index).EditedFormattedValue)
                    LBLTOTALINPCS.Text = Format(Val(LBLTOTALINPCS.Text) + Val(ROW.Cells(GINPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALINMTRS.Text = Format(Val(LBLTOTALINMTRS.Text) + Val(ROW.Cells(GINMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALOURWT.Text = Format(Val(LBLTOTALOURWT.Text) + Val(ROW.Cells(GOURWT.Index).EditedFormattedValue), "0.00")
                    ROW.Cells(GAVGWT.Index).Value = Format(Val(ROW.Cells(GOURWT.Index).EditedFormattedValue) / Val(ROW.Cells(GINMTRS.Index).EditedFormattedValue) * 100, "0.00")
                End If
            Next
            If Val(LBLTOTALOURWT.Text.Trim) > 0 And Val(LBLTOTALINMTRS.Text.Trim) > 0 Then LBLAVG.Text = Format((Val(LBLTOTALOURWT.Text.Trim) / Val(LBLTOTALINMTRS.Text.Trim)) * 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTJO As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTJO = OBJSELECTGDN.DT
            If DTJO.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTJO.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    If DTROWPS("BARCODE") <> "" Then
                        For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                            If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
                        Next
                    End If

                    TXTLOTNO.Text = DTROWPS("LOTNO")

                    GRIDSTOCK.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("BALENO"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), Format(Val(DTROWPS("PCS")), "0.00"), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))

LINE1:
                Next
                'CMDSELECTSTOCK.Enabled = False
                GETSRNO(GRIDSTOCK)
                TOTAL()
            End If


            'CHANGES AS PER REQUOREMENT
            If ClientName = "AVIS" And GRIDSTOCK.RowCount > 0 Then
                CMBPIECETYPE.Text = GRIDSTOCK.Rows(0).Cells(GPIECETYPE.Index).Value
                cmbitemname.Text = GRIDSTOCK.Rows(0).Cells(GMERCHANT.Index).Value
                CMBQUALITY.Text = GRIDSTOCK.Rows(0).Cells(GQUALITY.Index).Value
                CMBDESIGN.Text = GRIDSTOCK.Rows(0).Cells(GDESIGN.Index).Value
                cmbcolor.Text = GRIDSTOCK.Rows(0).Cells(GCOLOR.Index).Value

                TXTMTRS.Text = Val(LBLTOTALOUTMTRS.Text.Trim)
                TXTGRIDDESC.Clear()
                For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                    If TXTGRIDDESC.Text = "" Then
                        TXTGRIDDESC.Text = "(" & Val(ROW.Cells(GMTRS.Index).Value)
                    Else
                        TXTGRIDDESC.Text = TXTGRIDDESC.Text & " + " & Val(ROW.Cells(GMTRS.Index).Value)
                    End If
                Next
                If TXTGRIDDESC.Text.Trim <> "" Then TXTGRIDDESC.Text = TXTGRIDDESC.Text & ")"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSTOCK.RowCount = 0
            GRIDSTOCKIN.RowCount = 0
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) - 1
            If TEMPRECONO > 0 Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO > 1 Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTRECONO.Text.Trim
            CLEAR()
            If Val(TXTRECONO.Text) - 1 >= TEMPRECONO Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO < MAXNO Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSTOCK.RowCount = 0
                GRIDSTOCKIN.RowCount = 0
                TEMPRECONO = Val(tstxtbillno.Text)
                If TEMPRECONO > 0 Then
                    EDIT = True
                    StockReco_Load(sender, e)
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
        Try
            GRIDSTOCKIN.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDSTOCKIN.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, TXTBALENO.Text.Trim, TXTGRIDDESC.Text.Trim, TXTLOTNO.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTOURWT.Text.Trim), "0.00"), 0, CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTINBARCODE.Text.Trim, 0, 0, 0)
                GETSRNO(GRIDSTOCKIN)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDSTOCKIN.Item(GINSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDSTOCKIN.Item(GINPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
                GRIDSTOCKIN.Item(GINITEMNAME.Index, TEMPROW).Value = cmbitemname.Text.Trim
                GRIDSTOCKIN.Item(GINQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDSTOCKIN.Item(GINBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
                GRIDSTOCKIN.Item(GINDESC.Index, TEMPROW).Value = TXTGRIDDESC.Text.Trim
                GRIDSTOCKIN.Item(GINLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
                GRIDSTOCKIN.Item(GINDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDSTOCKIN.Item(GINCOLOR.Index, TEMPROW).Value = cmbcolor.Text.Trim
                GRIDSTOCKIN.Item(GINCUT.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
                GRIDSTOCKIN.Item(GINPCS.Index, TEMPROW).Value = Val(txtqty.Text.Trim)
                GRIDSTOCKIN.Item(GINUNIT.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
                GRIDSTOCKIN.Item(GINMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
                GRIDSTOCKIN.Item(GOURWT.Index, TEMPROW).Value = Format(Val(TXTOURWT.Text.Trim), "0.00")
                GRIDSTOCKIN.Item(GRACK.Index, TEMPROW).Value = CMBRACK.Text.Trim
                GRIDSTOCKIN.Item(GSHELF.Index, TEMPROW).Value = CMBSHELF.Text.Trim
                GRIDDOUBLECLICK = False
            End If

            TOTAL()

            GRIDSTOCKIN.FirstDisplayedScrollingRowIndex = GRIDSTOCKIN.RowCount - 1

            txtsrno.Text = GRIDSTOCKIN.RowCount + 1
            TXTBALENO.Clear()
            TXTGRIDDESC.Clear()
            TXTOURWT.Clear()
            If ClientName <> "AVIS" Then TXTLOTNO.Clear()
            TXTMTRS.Clear()

            CMBPIECETYPE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTOCKIN.CellDoubleClick
        EDITROW()
    End Sub

    Sub EDITROW()
        Try
            If GRIDSTOCKIN.CurrentRow.Index >= 0 And GRIDSTOCKIN.Item(GSRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDSTOCKIN.Item(GINSRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDSTOCKIN.Item(GINPIECETYPE.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDSTOCKIN.Item(GINITEMNAME.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDSTOCKIN.Item(GINQUALITY.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDSTOCKIN.Item(GINBALENO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTGRIDDESC.Text = GRIDSTOCKIN.Item(GINDESC.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDSTOCKIN.Item(GINLOTNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDSTOCKIN.Item(GINDESIGN.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDSTOCKIN.Item(GINCOLOR.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDSTOCKIN.Item(GINCUT.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDSTOCKIN.Item(GINPCS.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = GRIDSTOCKIN.Item(GINUNIT.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDSTOCKIN.Item(GINMTRS.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTOURWT.Text = GRIDSTOCKIN.Item(GOURWT.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBRACK.Text = GRIDSTOCKIN.Item(GRACK.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBSHELF.Text = GRIDSTOCKIN.Item(GSHELF.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSTOCKIN.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRACK.Enter
        Try
            If CMBRACK.Text.Trim = "" Then FILLRACK(CMBRACK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRACK.Validating
        Try
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Validated
        Try
            If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) > 0 Then
                If ClientName = "SBA" Then
                    Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
                    If Val(TXTNOOFENTRIES.Text.Trim) = 0 Then txtqty.Text = 1 Else txtqty.Text = Val(TXTNOOFENTRIES.Text.Trim)
                    If Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTCUT.Text.Trim) * Val(txtqty.Text.Trim)
                    For I As Integer = 1 To Val(TEMPQTY)
                        If GRIDDOUBLECLICK = False Then
                            If EDIT = True Then
                                'GET LAST BARCODE SRNO
                                Dim LSRNO As Integer = 0
                                Dim RSRNO As Integer = 0
                                Dim SNO As Integer = 0
                                If GRIDSTOCKIN.RowCount > 0 Then
                                    LSRNO = InStr(GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                    RSRNO = InStr(LSRNO + 1, GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                    SNO = GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)
                                End If

                                TXTINBARCODE.Text = "SA-" & Val(TXTRECONO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                            Else
                                TXTINBARCODE.Text = "SA-" & Val(TXTRECONO.Text.Trim) & "/" & GRIDSTOCKIN.RowCount + 1 & "/" & YearId
                            End If
                        End If
                        FILLGRID()
                    Next
                Else
                    If GRIDDOUBLECLICK = False Then
                        If EDIT = True Then
                            'GET LAST BARCODE SRNO
                            Dim LSRNO As Integer = 0
                            Dim RSRNO As Integer = 0
                            Dim SNO As Integer = 0
                            If GRIDSTOCKIN.RowCount > 0 Then
                                LSRNO = InStr(GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                RSRNO = InStr(LSRNO + 1, GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                SNO = GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)
                            End If

                            TXTINBARCODE.Text = "SA-" & Val(TXTRECONO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                        Else
                            TXTINBARCODE.Text = "SA-" & Val(TXTRECONO.Text.Trim) & "/" & GRIDSTOCKIN.RowCount + 1 & "/" & YearId
                        End If
                    End If
                    FILLGRID()
                End If
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTNOOFENTRIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTCUT.KeyPress, TXTOURWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
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

    Private Sub GRIDSTOCK_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSTOCK.CellValidating
        Try
            Dim colNum As Integer = GRIDSTOCK.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPCS.Index, GMTRS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSTOCK.CurrentCell.Value = Nothing Then GRIDSTOCK.CurrentCell.Value = "0.00"
                        GRIDSTOCK.CurrentCell.Value = Convert.ToDecimal(GRIDSTOCK.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDSTOCK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCK.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCK.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSTOCK.Rows.RemoveAt(GRIDSTOCK.CurrentRow.Index)
                GETSRNO(GRIDSTOCK)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Stock Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                If lbllocked.Visible = True Then
                    MsgBox("Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                Dim ALPARAVAL As New ArrayList
                Dim OBSTOCK As New ClsStockAdjustment

                ALPARAVAL.Add(TEMPRECONO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                OBSTOCK.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBSTOCK.DELETE()
                MsgBox("Stock Adjustment Deleted Succesfully")
                CLEAR()
                EDIT = False
                DTRECODATE.Focus()
                TEMPPROFORMANO = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.GotFocus
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbqtyunit.Validating
        Try
            If cmbqtyunit.Text.Trim <> "" Then unitvalidate(cmbqtyunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCKIN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCKIN.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDSTOCKIN.Rows.RemoveAt(GRIDSTOCKIN.CurrentRow.Index)
                GETSRNO(GRIDSTOCKIN)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated, txtqty.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            If Val(txtqty.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
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
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
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
                Dim OBJQUALITY As New SelectQuality
                OBJQUALITY.ShowDialog()
                If OBJQUALITY.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQUALITY.TEMPNAME
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

            Dim OBJstock As New StockRecoDetails
            OBJstock.MdiParent = MDIMain
            OBJstock.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT()
                If GRIDSTOCKIN.RowCount > 0 Then PRINTBARCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJSA As New SaleOrderDesign
            OBJSA.MdiParent = MDIMain
            OBJSA.FORMULA = "{STOCKADJUSTMENT.SA_NO} = " & Val(TXTRECONO.Text.Trim) & " AND {STOCKADJUSTMENT.SA_YEARID} = " & YearId
            OBJSA.FRMSTRING = "STOCKRECO"
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(sender As Object, e As EventArgs) Handles cmbitemname.Validated
        Try
            'GET CATEGORY
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND ITEM_NAME = '" & cmbitemname.Text.Trim & "' AND ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable


                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'GET DATA FROM BARCODE
                DT = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next

                    Dim PCS As Double = 0
                    PCS = 1

                    GRIDSTOCK.Rows.Add(GRIDSTOCK.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("BALENO"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
                    GRIDSTOCKIN.Rows.Add(GRIDSTOCK.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("BALENO"), "", "", DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), 0, PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), 0, 0, "", "", "PK-" & Val(TXTRECONO.Text.Trim) & "/" & GRIDSTOCKIN.RowCount + 1 & "/" & YearId, 0, 0, 0)
                    TOTAL()
LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()


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