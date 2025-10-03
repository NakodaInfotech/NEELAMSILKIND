
Imports BL
Imports System.IO

Public Class InHouseChecking

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPCHECKINGNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            EP.Clear()
            CMDSELECTLOT.Enabled = True

            tstxtbillno.Clear()
            TXTFROM.Clear()
            TXTTO.Clear()
            GRIDCHECKING.RowCount = 0

            TXTCHECKINGNO.Clear()
            CHECKINGDATE.Text = Now.Date
            TXTNAME.Clear()
            TXTGODOWN.Clear()
            TXTLOTNO.Clear()
            TXTMATRECNO.Clear()
            TXTTYPE.Clear()
            TXTCHECKEDBY.Clear()

            TXTTOTALGREYMTRS.Text = 0.0
            TXTTOTALRECDMTRS.Text = 0.0
            TXTTOTALCHECKEDMTRS.Text = 0.0
            LBLSHORTAGE.Text = "Shortage"
            TXTTOTALDIFF.Text = 0.0
            TXTTOTALWT.Text = 0.0
            TXTTOTALPCS.Text = 0
            txtremarks.Clear()

            lbllocked.Visible = False
            PBlock.Visible = False


            CMDSELECTLOT.Enabled = True
            GRIDDOUBLECLICK = False
            getmaxno()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            TXTTOTALGREYMTRS.Text = 0.0
            TXTTOTALRECDMTRS.Text = 0.0
            TXTTOTALCHECKEDMTRS.Text = 0.0
            TXTTOTALDIFF.Text = 0.0
            TXTTOTALWT.Text = 0.0
            TXTSHRINKAGEPER.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    ROW.Cells(GDIFF.Index).Value = Format(Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue) - Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALGREYMTRS.Text = Format(Val(TXTTOTALGREYMTRS.Text) + Val(ROW.Cells(GGREYMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALRECDMTRS.Text = Format(Val(TXTTOTALRECDMTRS.Text) + Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALCHECKEDMTRS.Text = Format(Val(TXTTOTALCHECKEDMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALDIFF.Text = Format(Val(TXTTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue), "0.00")
                    TXTTOTALWT.Text = Format(Val(TXTTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                End If
            Next
            TXTTOTALPCS.Text = Val(GRIDCHECKING.RowCount)
            If Val(TXTTOTALDIFF.Text.Trim) < 0 Then LBLSHORTAGE.Text = "Longation" Else LBLSHORTAGE.Text = "Shortage"
            TXTSHRINKAGEPER.Text = Format(((Val(TXTTOTALGREYMTRS.Text.Trim) - Val(TXTTOTALCHECKEDMTRS.Text.Trim)) / Val(TXTTOTALGREYMTRS.Text.Trim)) * 100, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            EDIT = False
            CHECKINGDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECKINGDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHECKINGDATE.GotFocus
        CHECKINGDATE.SelectAll()
    End Sub

    Private Sub CHECKINGDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKINGDATE.Validating
        Try
            If CHECKINGDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CHECKINGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(CHECK_NO),0) + 1 ", " INHOUSECHECKING", " AND CHECK_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTCHECKINGNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If TXTNAME.Text.Trim.Length = 0 Then
                EP.SetError(TXTNAME, " Please Select Data ")
                bln = False
            End If

            'If TXTLOTNO.Text.Trim.Length = 0 Then
            '    EP.SetError(TXTLOTNO, "Please Select Lot No")
            '    bln = False
            'End If

            If TXTCHECKEDBY.Text.Trim.Length = 0 Then
                EP.SetError(TXTCHECKEDBY, "Please Enter Checked By")
                bln = False
            End If


            'WE DONT HAVE TO LOCK FULL ENTRY, WE WILL LOCK ONLY OUTMTRS ENTRY
            'If lbllocked.Visible = True Then
            '    EP.SetError(lbllocked, "Item Used in Mfg, Delete Mfg First")
            '    bln = False
            'End If

            If GRIDCHECKING.RowCount = 0 Then
                EP.SetError(TXTLOTNO, "Fill Item Details")
                bln = False
            End If


            For Each row As DataGridViewRow In GRIDCHECKING.Rows
                If Val(row.Cells(GMTRS.Index).Value) = 0 And ClientName <> "PARAS" Then
                    EP.SetError(TXTLOTNO, "Checking Mtrs Cannot be kept Blank")
                    bln = False
                End If
            Next

            If CHECKINGDATE.Text = "__/__/____" Then
                EP.SetError(CHECKINGDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(CHECKINGDATE.Text) Then
                    EP.SetError(CHECKINGDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If


            'check WHETHER SAME LOT NO AND NAME IS SAVED BEFORE OR NOT
            If EDIT = False And TXTLOTNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("CHECK_NO AS CHECKNO", "", " INHOUSECHECKING INNER JOIN LEDGERS ON CHECK_LEDGERID = LEDGERS.ACC_ID ", " AND LEDGERS.ACC_CMPNAME = '" & TXTNAME.Text.Trim & "' AND CHECK_LOTNO = '" & TXTLOTNO.Text.Trim & "'  AND CHECK_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If MsgBox("Lot No already saved before, wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        EP.SetError(TXTNAME, "Lot No already saved before")
                        bln = False
                    End If
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
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Format(Convert.ToDateTime(CHECKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(TXTGODOWN.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(Val(TXTMATRECNO.Text.Trim))
            alParaval.Add(TXTTYPE.Text.Trim)
            alParaval.Add(TXTCHECKEDBY.Text.Trim)


            alParaval.Add(Val(TXTTOTALGREYMTRS.Text))
            alParaval.Add(Val(TXTTOTALRECDMTRS.Text))
            alParaval.Add(Val(TXTTOTALCHECKEDMTRS.Text.Trim))
            alParaval.Add(Val(TXTSHRINKAGEPER.Text.Trim))
            alParaval.Add(Val(TXTTOTALDIFF.Text))
            alParaval.Add(Val(TXTTOTALWT.Text))
            alParaval.Add(Val(TXTTOTALPCS.Text))

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim GREYMTRS As String = ""
            Dim RECDMTRS As String = ""
            Dim CHECKEDMTRS As String = ""
            Dim GRIDREMARKS As String = ""
            Dim PIECETYPE As String = ""
            Dim DIFF As String = ""
            Dim UNIT As String = ""
            Dim WT As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim BARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDCHECKING.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        GREYMTRS = Val(row.Cells(GGREYMTRS.Index).Value)
                        RECDMTRS = Val(row.Cells(GRECDMTRS.Index).Value)
                        CHECKEDMTRS = Val(row.Cells(GMTRS.Index).Value)
                        If row.Cells(Gdesc.Index).Value <> Nothing Then GRIDREMARKS = row.Cells(Gdesc.Index).Value.ToString Else GRIDREMARKS = ""
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        DIFF = Val(row.Cells(GDIFF.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value
                        WT = Val(row.Cells(GWT.Index).Value)
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTPCS = Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        GREYMTRS = GREYMTRS & "|" & Val(row.Cells(GGREYMTRS.Index).Value)
                        RECDMTRS = RECDMTRS & "|" & Val(row.Cells(GRECDMTRS.Index).Value)
                        CHECKEDMTRS = CHECKEDMTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        If row.Cells(Gdesc.Index).Value <> Nothing Then GRIDREMARKS = GRIDREMARKS & "|" & row.Cells(Gdesc.Index).Value.ToString Else GRIDREMARKS = GRIDREMARKS & ""
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        DIFF = DIFF & "|" & Val(row.Cells(GDIFF.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTPCS = OUTPCS & "|" & Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = OUTMTRS & "|" & Val(row.Cells(GOUTMTRS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(GREYMTRS)
            alParaval.Add(RECDMTRS)
            alParaval.Add(CHECKEDMTRS)
            alParaval.Add(GRIDREMARKS)
            alParaval.Add(PIECETYPE)
            alParaval.Add(DIFF)
            alParaval.Add(UNIT)
            alParaval.Add(WT)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(BARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)


            Dim OBJCHECKING As New ClsInHouseChecking()
            OBJCHECKING.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = OBJCHECKING.SAVE()
                TEMPCHECKINGNO = DT.Rows(0).Item(0)
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCHECKINGNO)
                Dim IntResult As Integer = OBJCHECKING.UPDATE()
                MsgBox("Details Updated")
            End If
            PRINTREPORT()

            EDIT = False
            clear()
            CHECKINGDATE.Focus()

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

                Dim WHOLESALEBARCODE As Integer = 0
                If ClientName = "CC" Or ClientName = "SHREEDEV" Then WHOLESALEBARCODE = MsgBox("Wish to Print Wholesale Barcode?", MsgBoxStyle.YesNo)

                Dim TEMPHEADER As String = ""
                If ClientName = "YASHVI" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (M/N/O/P)")
                    If TEMPHEADER <> "M" And TEMPHEADER <> "N" And TEMPHEADER <> "O" And TEMPHEADER <> "P" Then Exit Sub
                    If TEMPHEADER = "M" Then TEMPHEADER = "MAFATLAL"
                    If TEMPHEADER = "N" Or TEMPHEADER = "P" Then TEMPHEADER = ""
                    If TEMPHEADER = "O" Then TEMPHEADER = "ORGALIN"
                End If

                Dim SUPRIYAHEADER As String = ""
                If ClientName = "SUPRIYA" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (1/2/3/4/5/6/7)")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" And TEMPHEADER <> "4" And TEMPHEADER <> "5" And TEMPHEADER <> "6" And TEMPHEADER <> "7" Then Exit Sub
                    If TEMPHEADER = "1" Or TEMPHEADER = "6" Then SUPRIYAHEADER = "ROYAL TEX"
                    If TEMPHEADER = "2" Or TEMPHEADER = "7" Then SUPRIYAHEADER = "DEEP BLUE"
                    If TEMPHEADER = "3" Then SUPRIYAHEADER = ""
                    If TEMPHEADER = "4" Then SUPRIYAHEADER = "KAMDHENU"
                    If TEMPHEADER = "5" Then SUPRIYAHEADER = "5"
                End If

                Dim OBJCHECKING As New ClsInHouseChecking()
                Dim dttable As DataTable = OBJCHECKING.SELECTCHECKING(TEMPCHECKINGNO, YearId)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        'TO PRINT BARCODE FROM SELECTED SRNO
                        If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                            If Val(dr("GRIDSRNO")) < Val(TXTFROM.Text.Trim) Or Val(dr("GRIDSRNO")) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                        End If

                        BARCODEPRINTING(dr("BARCODE"), dr("PIECETYPE"), dr("ITEMNAME"), dr("QUALITY"), dr("DESIGN"), dr("COLOR"), dr("UNIT"), dr("LOTNO"), dr("NARR"), dr("NARR"), Val(dr("CHECKEDMTRS")), 1, "", TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:
                    Next
                End If
            End If

            '                        Dim oWrite As System.IO.StreamWriter
            '                        'Writing in file
            '                        oWrite = File.CreateText("D:\Barcode.txt")


            '                        'TO PRINT BARCODE FROM SELECTED SRNO
            '                        If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
            '                            If Val(dr("GRIDSRNO")) < Val(TXTFROM.Text.Trim) Or Val(dr("GRIDSRNO")) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
            '                        End If


            '                        Dim dirresults As String = ""



            '                        If ClientName = "SVS" Then
            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='25.0 mm'></xpml>I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q400")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q200,25")
            '                            oWrite.WriteLine("KI80")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.0 mm'></xpml>N")
            '                            oWrite.WriteLine("A376,160,2,2,1,1,N,""QUALITY""")
            '                            oWrite.WriteLine("A376,114,2,2,1,1,N,""D.NO""")
            '                            oWrite.WriteLine("A376,136,2,2,1,1,N,""SHADE""")
            '                            oWrite.WriteLine("B384,91,2,1,2,4,61,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A279,24,2,2,1,1,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A197,114,2,2,1,1,N,""QTY""")
            '                            oWrite.WriteLine("A376,183,2,2,1,1,N,""" & CmpName & """")    'cmpname
            '                            oWrite.WriteLine("A277,114,2,2,1,1,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A291,114,2,2,1,1,N,"":""")
            '                            oWrite.WriteLine("A291,136,2,2,1,1,N,"":""")
            '                            oWrite.WriteLine("A277,136,2,2,1,1,N,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("A291,162,2,2,1,1,N,"":""")
            '                            oWrite.WriteLine("A277,162,2,2,1,1,N,""" & dr("QUALITY") & """")
            '                            oWrite.WriteLine("A157,114,2,2,1,1,N,"":""")
            '                            'oWrite.WriteLine("A143,114,2,2,1,1,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & " MTR""")
            '                            Dim TEMPQTYUNIT As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search("ISNULL(UNITMASTER.unit_abbr, '') AS UNIT ", "", " QUALITYMASTER LEFT OUTER JOIN UNITMASTER ON QUALITYMASTER.QUALITY_unitid = UNITMASTER.unit_id ", " AND QUALITY_NAME = '" & dr("QUALITY") & "' AND QUALITY_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPQTYUNIT = DT.Rows(0).Item("UNIT")
            '                            End If
            '                            oWrite.WriteLine("A143,114,2,2,1,1,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & " " & TEMPQTYUNIT & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "MARKIN" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='75.1 mm'></xpml>SIZE 97.5 mm, 75.1 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='75.1 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 709,566,""0"",180,16,16,""" & CmpName & """")
            '                            oWrite.WriteLine("TEXT 738,421,""0"",180,14,14,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 738,353,""0"",180,14,14,""COLOR""")
            '                            oWrite.WriteLine("TEXT 738,285,""0"",180,14,14,""LOTNO""")
            '                            oWrite.WriteLine("TEXT 738,488,""0"",180,14,14,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 738,216,""0"",180,14,14,""MTRS""")
            '                            oWrite.WriteLine("BARCODE 738,160,""128M"",74,0,180,3,6,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 597,79,""0"",180,16,16,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 527,488,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 527,421,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 527,353,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 527,285,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 527,216,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 498,488,""0"",180,14,14,""" & dr("ITEMNAME") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 498,421,""0"",180,14,14,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 498,353,""0"",180,14,14,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 498,285,""0"",180,14,14,""" & dr("LOTNO") & """")
            '                            oWrite.WriteLine("TEXT 498,227,""0"",180,22,22,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("BAR 43,505, 695, 3")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "SHALIBHADRA" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='25.4 mm'></xpml>I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q406")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q203,25")
            '                            oWrite.WriteLine("KI80")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.4 mm'></xpml>N")
            '                            oWrite.WriteLine("B369,101,2,1,2,4,51,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A295,43,2,4,1,1,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A380,179,2,4,1,1,N,""Lot""")
            '                            oWrite.WriteLine("A380,138,2,4,1,1,N,""D.No""")
            '                            oWrite.WriteLine("A309,179,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A292,179,2,4,1,1,N,""" & Val(dr("LOTNO") & """"))
            '                            oWrite.WriteLine("A308,138,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A292,138,2,4,1,1,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A124,186,2,4,1,1,N,""Mtrs""")
            '                            oWrite.WriteLine("A176,150,2,3,2,2,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "KCRAYON" Then

            '                            oWrite.WriteLine("SIZE 101.6 mm, 50.8 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 783,377,""2"",180,3,3,""" & dr("DESIGN") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 783,283,""2"",180,2,2,""SHADE""")
            '                            If dr("NARR") <> "" Then oWrite.WriteLine("TEXT 111,283,""2"",180,2,2,""TP""") Else oWrite.WriteLine("TEXT 111,283,""2"",180,2,2,""""")
            '                            oWrite.WriteLine("TEXT 405,216,""2"",180,2,2,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 783,216,""2"",180,2,2,""MTRS""")
            '                            oWrite.WriteLine("TEXT 265,216,""2"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 672,216,""2"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 631,283,""2"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 603,283,""2"",180,2,2,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 631,216,""2"",180,2,2,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 237,216,""2"",180,2,2,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("BARCODE 783,161,""128M"",95,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 601,55,""2"",180,2,2,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.Dispose()


            '                        ElseIf ClientName = "DAKSH" Then

            '                            oWrite.WriteLine("G0")
            '                            oWrite.WriteLine("n")
            '                            oWrite.WriteLine("M0500")
            '                            oWrite.WriteLine("O0214")
            '                            oWrite.WriteLine("V0")
            '                            oWrite.WriteLine("t1")
            '                            oWrite.WriteLine("Kf0070")
            '                            oWrite.WriteLine("L")
            '                            oWrite.WriteLine("D11")
            '                            oWrite.WriteLine("ySPM")
            '                            oWrite.WriteLine("A2")
            '                            oWrite.WriteLine("1911C2401560027LINEN VENZO")
            '                            oWrite.WriteLine("1X1100001550005L263001")
            '                            oWrite.WriteLine("1e4203600230043B" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911C1000060084" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911C1401280011" & dr("ITEMNAME"))
            '                            oWrite.WriteLine("1911C1001090012SHADE")
            '                            oWrite.WriteLine("1911C1000610012QUALITY")
            '                            oWrite.WriteLine("1911C1001090077:")
            '                            oWrite.WriteLine("1911C1000610077:")
            '                            oWrite.WriteLine("1911C1401060086" & dr("COLOR"))
            '                            oWrite.WriteLine("1911C1000610086" & dr("QUALITY"))
            '                            oWrite.WriteLine("1911C1000840012MTRS")
            '                            oWrite.WriteLine("1911C1000840077:")
            '                            oWrite.WriteLine("1911C1400810086" & Format(Val(dr("CHECKEDMTRS")), "0.00"))
            '                            oWrite.WriteLine("1911C1001090162D. NO")
            '                            oWrite.WriteLine("1911C1001090204:")
            '                            oWrite.WriteLine("1911C1201080212" & dr("DESIGN"))
            '                            oWrite.WriteLine("1911C1000840162LOT")
            '                            oWrite.WriteLine("1911C1000840204:")
            '                            oWrite.WriteLine("1911C1000840213" & TXTLOTNO.Text.Trim)
            '                            oWrite.WriteLine("Q0001")
            '                            oWrite.WriteLine("E")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "PARAS" Then

            '                            If Val(dr("CHECKEDMTRS")) > 0 Then
            '                                oWrite.WriteLine("SIZE 99.10 mm, 50 mm")
            '                                oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                                oWrite.WriteLine("DIRECTION 0,0")
            '                                oWrite.WriteLine("REFERENCE 0,0")
            '                                oWrite.WriteLine("OFFSET 0 mm")
            '                                oWrite.WriteLine("SET PEEL OFF")
            '                                oWrite.WriteLine("SET CUTTER OFF")
            '                                oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                                oWrite.WriteLine("SET TEAR ON")
            '                                oWrite.WriteLine("CLS")
            '                                oWrite.WriteLine("CODEPAGE 1252")
            '                                oWrite.WriteLine("TEXT 620,371,""ROMAN.TTF"",180,1,14,"":""")
            '                                oWrite.WriteLine("TEXT 600,374,""ROMAN.TTF"",180,1,16,""" & dr("ITEMNAME") & """")
            '                                oWrite.WriteLine("TEXT 782,371,""ROMAN.TTF"",180,1,14,""QUALITY""")
            '                                oWrite.WriteLine("TEXT 782,310,""ROMAN.TTF"",180,1,14,""DESIGN""")
            '                                oWrite.WriteLine("TEXT 600,310,""ROMAN.TTF"",180,1,14,""" & dr("DESIGN") & """")
            '                                oWrite.WriteLine("TEXT 620,310,""ROMAN.TTF"",180,1,14,"":""")
            '                                oWrite.WriteLine("TEXT 360,310,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                                oWrite.WriteLine("TEXT 237,310,""ROMAN.TTF"",180,1,14,"":""")

            '                                'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                                Dim TEMPWIDTH As String = ""
            '                                Dim OBJCMN As New ClsCommon
            '                                Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                                If DT.Rows.Count > 0 Then
            '                                    TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                                End If
            '                                oWrite.WriteLine("TEXT 211,310,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")


            '                                oWrite.WriteLine("TEXT 782,249,""ROMAN.TTF"",180,1,14,""LOTNO""")
            '                                oWrite.WriteLine("TEXT 620,249,""ROMAN.TTF"",180,1,14,"":""")
            '                                oWrite.WriteLine("TEXT 600,249,""ROMAN.TTF"",180,1,14,""" & TXTLOTNO.Text.Trim & """")
            '                                oWrite.WriteLine("TEXT 363,249,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                                oWrite.WriteLine("TEXT 231,249,""ROMAN.TTF"",180,1,14,"": """)
            '                                oWrite.WriteLine("TEXT 211,249,""ROMAN.TTF"",180,1,14,""" & dr("COLOR") & """")
            '                                oWrite.WriteLine("TEXT 782,187,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                                oWrite.WriteLine("TEXT 620,187,""ROMAN.TTF"",180,1,14,"":""")
            '                                oWrite.WriteLine("BARCODE 776,134,""128M"",83,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                                oWrite.WriteLine("TEXT 499,47,""ROMAN.TTF"",180,1,11,""" & dr("BARCODE") & """")
            '                                oWrite.WriteLine("TEXT 600,192,""ROMAN.TTF"",180,1,18,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                                oWrite.WriteLine("PRINT 1,1")
            '                            End If
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "ARIHANT" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("BARCODE 508,154,""128M"",106,0,180,2,4,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 408,42,""0"",180,10,10,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 508,378,""0"",180,16,16,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 508,316,""0"",180,12,12,""D.NO""")
            '                            oWrite.WriteLine("TEXT 508,265,""0"",180,12,12,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 166,316,""0"",180,12,12,""" & dr("LOTNO") & """")
            '                            oWrite.WriteLine("TEXT 508,210,""0"",180,12,12,""MTRS""")
            '                            oWrite.WriteLine("TEXT 405,316,""0"",180,12,12,"":""")
            '                            oWrite.WriteLine("TEXT 405,265,""0"",180,12,12,"":""")
            '                            oWrite.WriteLine("TEXT 405,210,""0"",180,12,12,"":""")
            '                            oWrite.WriteLine("TEXT 377,316,""0"",180,12,12,""" & dr("DESIGN") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If
            '                            oWrite.WriteLine("TEXT 377,265,""0"",180,12,12,""" & TEMPWIDTH & """")

            '                            oWrite.WriteLine("TEXT 377,217,""0"",180,18,18,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "KEMLINO" Then

            '                            oWrite.WriteLine("SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 581,354,""ROMAN.TTF"",180,1,19,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 738,282,""ROMAN.TTF"",180,1,14,""D.NO""")
            '                            oWrite.WriteLine("TEXT 738,228,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                            oWrite.WriteLine("TEXT 738,172,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                            oWrite.WriteLine("TEXT 738,119,""ROMAN.TTF"",180,1,14,""UNIT""")
            '                            oWrite.WriteLine("QRCODE 237,280,L,10,A,180,M2,S7,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 237,65,""ROMAN.TTF"",180,1,10,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 609,282,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 609,228,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 609,172,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 609,119,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 581,282,""ROMAN.TTF"",180,1,14,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 581,228,""ROMAN.TTF"",180,1,14,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 581,176,""ROMAN.TTF"",180,1,18,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If
            '                            oWrite.WriteLine("TEXT 581,67,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")


            '                            oWrite.WriteLine("TEXT 738,67,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 609,67,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 581,119,""ROMAN.TTF"",180,1,14,""" & dr("UNIT") & """")
            '                            oWrite.WriteLine("TEXT 738,348,""ROMAN.TTF"",180,1,14,""PROD""")
            '                            oWrite.WriteLine("TEXT 609,348,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("BAR 29,297, 708, 3")
            '                            oWrite.WriteLine("TEXT 410,119,""ROMAN.TTF"",180,1,14,""" & dr("LOTNO") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "PURVITEX" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>SIZE 101.6 mm, 50.8 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("BARCODE 790,113,""128M"",68,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 506,40,""ROMAN.TTF"",180,1,10,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 794,384,""ROMAN.TTF"",180,1,16,""QUALITY""")
            '                            oWrite.WriteLine("TEXT 793,313,""ROMAN.TTF"",180,1,16,""SHADE""")
            '                            oWrite.WriteLine("TEXT 789,171,""ROMAN.TTF"",180,1,16,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 794,242,""ROMAN.TTF"",180,1,16,""MTRS""")
            '                            oWrite.WriteLine("TEXT 588,384,""ROMAN.TTF"",180,1,16,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 614,384,""ROMAN.TTF"",180,1,16,"":""")
            '                            oWrite.WriteLine("TEXT 614,313,""ROMAN.TTF"",180,1,16,"":""")
            '                            oWrite.WriteLine("TEXT 588,313,""ROMAN.TTF"",180,1,16,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 614,171,""ROMAN.TTF"",180,1,16,"":""")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 588,171,""ROMAN.TTF"",180,1,16,""" & TEMPWIDTH & """")

            '                            oWrite.WriteLine("TEXT 614,243,""0"",180,16,17,"":""")
            '                            oWrite.WriteLine("TEXT 588,252,""ROMAN.TTF"",180,1,24,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("TEXT 233,171,""ROMAN.TTF"",180,1,16,""" & TXTLOTNO.Text.Trim & """")
            '                            oWrite.WriteLine("TEXT 255,171,""ROMAN.TTF"",180,1,16,"":""")
            '                            oWrite.WriteLine("TEXT 412,171,""ROMAN.TTF"",180,1,16,""LOT NO""")
            '                            oWrite.WriteLine("TEXT 372,242,""ROMAN.TTF"",180,1,16,""DESC""")
            '                            oWrite.WriteLine("TEXT 255,242,""ROMAN.TTF"",180,1,16,"":""")
            '                            oWrite.WriteLine("TEXT 233,242,""ROMAN.TTF"",180,1,16,""" & dr("NARR") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "DJIMPEX" Then

            '                            oWrite.WriteLine("SIZE 99.10 mm, 50 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 768,362,""ROMAN.TTF"",180,1,14,""QUALITY""")
            '                            oWrite.WriteLine("TEXT 768,303,""ROMAN.TTF"",180,1,14,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 768,244,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                            oWrite.WriteLine("TEXT 768,185,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 271,232,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                            oWrite.WriteLine("TEXT 614,362,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 614,303,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 614,244,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 614,185,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 170,235,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 593,362,""ROMAN.TTF"",180,1,14,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 593,303,""ROMAN.TTF"",180,1,14,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 593,244,""ROMAN.TTF"",180,1,14,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 593,185,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 149,235,""ROMAN.TTF"",180,1,16,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("BARCODE 768,133,""128M"",76,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 768,51,""ROMAN.TTF"",180,1,12,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 253,51,""ROMAN.TTF"",180,1,11,""WWW.DJIMPEX.IN""")
            '                            oWrite.WriteLine("TEXT 270,185,""ROMAN.TTF"",180,1,14,""YDS""")
            '                            oWrite.WriteLine("TEXT 170,185,""ROMAN.TTF"",180,1,14,"":""")
            '                            oWrite.WriteLine("TEXT 149,189,""ROMAN.TTF"",180,1,16,""" & Format(Val(dr("CHECKEDMTRS")) * 1.094, "0.00") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "RATAN" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 745,378,""0"",180,11,11,""QUALITY""")
            '                            oWrite.WriteLine("TEXT 745,330,""0"",180,11,11,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 745,282,""0"",180,11,11,""SHADE""")
            '                            oWrite.WriteLine("TEXT 308,186,""0"",180,11,11,""MTRS""")
            '                            oWrite.WriteLine("TEXT 745,186,""0"",180,13,13,""WIDTH""")
            '                            oWrite.WriteLine("BARCODE 745,126,""128M"",70,0,180,3,6,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 567,50,""0"",180,12,12,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 590,378,""0"",180,11,11,"":""")
            '                            oWrite.WriteLine("TEXT 590,330,""0"",180,11,11,"":""")
            '                            oWrite.WriteLine("TEXT 590,282,""0"",180,11,11,"":""")
            '                            oWrite.WriteLine("TEXT 590,186,""0"",180,11,11,"":""")
            '                            oWrite.WriteLine("TEXT 216,186,""0"",180,11,11,"":""")
            '                            oWrite.WriteLine("TEXT 564,382,""0"",180,15,15,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 564,331,""0"",180,13,13,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 564,282,""0"",180,11,11,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 564,186,""0"",180,11,11,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 188,193,""0"",180,18,18,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("TEXT 745,234,""0"",180,11,11,""LOT NO""")
            '                            oWrite.WriteLine("TEXT 590,234,""0"",180,11,11,"":""")
            '                            oWrite.WriteLine("TEXT 564,234,""0"",180,11,11,""" & TXTLOTNO.Text.Trim & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "KENCOT" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>SIZE 101.6 mm, 50.8 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("SPEED 4")
            '                            oWrite.WriteLine("DENSITY 10")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 506,377,""ROMAN.TTF"",180,1,17,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("BARCODE 780,140,""128M"",85,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 484,50,""ROMAN.TTF"",180,1,9,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 780,298,""ROMAN.TTF"",180,1,14,""DESIGN NO""")
            '                            oWrite.WriteLine("TEXT 321,298,""ROMAN.TTF"",180,1,14,""SHADE NO""")
            '                            oWrite.WriteLine("TEXT 585,302,""ROMAN.TTF"",180,1,17,"":""")
            '                            oWrite.WriteLine("TEXT 125,302,""ROMAN.TTF"",180,1,17,"":""")
            '                            oWrite.WriteLine("TEXT 555,311,""ROMAN.TTF"",180,1,24,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 95,305,""ROMAN.TTF"",180,1,17,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 382,209,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 266,214,""ROMAN.TTF"",180,1,17,"":""")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 243,213,""0"",180,17,17,""" & TEMPWIDTH & """")

            '                            oWrite.WriteLine("TEXT 677,214,""ROMAN.TTF"",180,1,17,"":""")
            '                            oWrite.WriteLine("TEXT 780,209,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                            oWrite.WriteLine("TEXT 625,223,""ROMAN.TTF"",180,1,24,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("TEXT 780,373,""ROMAN.TTF"",180,1,14,""MERCHANT NO :""")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "DRDRAPES" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 734,287,""0"",180,13,13,""Quality""")
            '                            oWrite.WriteLine("TEXT 734,242,""0"",180,13,13,""Design""")
            '                            oWrite.WriteLine("TEXT 735,197,""0"",180,13,13,""Shade""")
            '                            oWrite.WriteLine("TEXT 734,151,""0"",180,13,13,""Mtrs""")
            '                            oWrite.WriteLine("TEXT 615,286,""0"",180,13,13,"":""")
            '                            oWrite.WriteLine("TEXT 615,241,""0"",180,13,13,"":""")
            '                            oWrite.WriteLine("TEXT 615,195,""0"",180,13,13,"":""")
            '                            oWrite.WriteLine("TEXT 615,150,""0"",180,13,13,"":""")
            '                            oWrite.WriteLine("TEXT 595,286,""0"",180,13,13,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 595,241,""0"",180,14,14,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 595,196,""0"",180,14,14,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 595,151,""0"",180,14,14,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("BARCODE 726,107,""128M"",55,0,180,3,6,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 537,47,""0"",180,10,10,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "SUCCESS" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='100.1 mm'></xpml>SIZE 99.10 mm, 100.1 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='100.1 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 767,429,""0"",180,24,24,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("BARCODE 682,578,""128M"",89,0,180,3,6,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 491,483,""0"",180,10,10,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 767,339,""0"",180,16,16,""D. NO""")
            '                            oWrite.WriteLine("TEXT 610,339,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 583,339,""0"",180,16,16,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 340,339,""0"",180,16,16,""SHADE""")
            '                            oWrite.WriteLine("TEXT 190,339,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 167,339,""0"",180,16,16,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 767,272,""0"",180,16,16,""GRADE""")
            '                            oWrite.WriteLine("TEXT 610,272,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 583,272,""0"",180,16,16,""" & dr("PIECETYPE") & """")
            '                            oWrite.WriteLine("TEXT 340,272,""0"",180,16,16,""MTRS""")
            '                            oWrite.WriteLine("TEXT 190,272,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 167,272,""0"",180,16,16,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("TEXT 750,183,""0"",180,12,12,""FAST TO NORMAL WASHING. BLENDED FABRIC""")
            '                            oWrite.WriteLine("TEXT 652,137,""0"",180,12,12,""POLYSTER - 65%     VISCOSE - 35%""")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "YASHVI" Then

            '                            oWrite.WriteLine("SIZE 72.5 mm, 50 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 526,255,""ROMAN.TTF"",180,1,11,""QUALITY""")
            '                            oWrite.WriteLine("TEXT 526,220,""ROMAN.TTF"",180,1,11,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 526,185,""ROMAN.TTF"",180,1,11,""SHADE NO""")
            '                            oWrite.WriteLine("TEXT 526,150,""ROMAN.TTF"",180,1,11,""MTRS""")
            '                            oWrite.WriteLine("TEXT 526,115,""ROMAN.TTF"",180,1,11,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 357,255,""ROMAN.TTF"",180,1,11,"":""")
            '                            oWrite.WriteLine("TEXT 357,220,""ROMAN.TTF"",180,1,11,"":""")
            '                            oWrite.WriteLine("TEXT 357,185,""ROMAN.TTF"",180,1,11,"":""")
            '                            oWrite.WriteLine("TEXT 357,150,""ROMAN.TTF"",180,1,11,"":""")
            '                            oWrite.WriteLine("TEXT 357,115,""ROMAN.TTF"",180,1,11,"":""")
            '                            oWrite.WriteLine("TEXT 337,255,""ROMAN.TTF"",180,1,11,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 337,220,""ROMAN.TTF"",180,1,11,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 337,185,""ROMAN.TTF"",180,1,11,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 337,150,""ROMAN.TTF"",180,1,11,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("TEXT 218,150,""ROMAN.TTF"",180,1,11,""" & dr("UNIT") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                                TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                                TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                            End If

            '                            oWrite.WriteLine("TEXT 337,115,""ROMAN.TTF"",180,1,11,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 526,311,""ROMAN.TTF"",180,1,15,""" & TEMPHEADER & """")
            '                            oWrite.WriteLine("TEXT 30,259,""ROMAN.TTF"",270,1,8,""" & TEMPREMARKS & """")
            '                            oWrite.WriteLine("BARCODE 522,82,""128M"",50,0,180,2,4,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 422,27,""ROMAN.TTF"",180,1,10,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "TARUN" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 755,241,""0"",180,14,14,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 299,241,""0"",180,14,14,""SHADE""")
            '                            oWrite.WriteLine("TEXT 755,184,""0"",180,14,14,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 755,352,""0"",180,14,14,""MERCHANT""")
            '                            oWrite.WriteLine("TEXT 755,299,""0"",180,14,14,""QUALITY""")
            '                            oWrite.WriteLine("BARCODE 767,136,""128M"",55,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 502,75,""0"",180,12,12,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 544,352,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 544,299,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 544,241,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 544,184,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 163,241,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 299,184,""0"",180,14,14,""MTRS""")
            '                            oWrite.WriteLine("TEXT 163,184,""0"",180,14,14,"":""")
            '                            oWrite.WriteLine("TEXT 516,352,""0"",180,14,14,""" & dr("ITEMNAME") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                                TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                                TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                            End If

            '                            oWrite.WriteLine("TEXT 516,299,""0"",180,14,14,""" & TEMPCATEGORY & """")
            '                            oWrite.WriteLine("TEXT 516,241,""0"",180,14,14,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 516,184,""0"",180,14,14,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 139,241,""0"",180,14,14,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 139,184,""0"",180,14,14,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "YUMILONE" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 760,375,""0"",180,16,16,""MERCHANT""")
            '                            oWrite.WriteLine("TEXT 760,320,""0"",180,16,16,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 760,265,""0"",180,16,16,""SHADE""")
            '                            oWrite.WriteLine("TEXT 760,210,""0"",180,16,16,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 311,210,""0"",180,16,16,""MTRS""")
            '                            oWrite.WriteLine("BARCODE 767,143,""128M"",88,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 502,49,""0"",180,12,12,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 539,375,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 539,320,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 539,265,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 539,210,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 190,210,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 518,375,""0"",180,16,16,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 518,320,""0"",180,16,16,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 518,265,""0"",180,16,16,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                                TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                                TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                            End If

            '                            oWrite.WriteLine("TEXT 518,210,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 167,215,""0"",180,20,20,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "ALENCOT" Then

            '                            If dr("PIECETYPE") <> "FRESH" Then Exit Sub

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                            oWrite.WriteLine("n")
            '                            oWrite.WriteLine("M0500")
            '                            oWrite.WriteLine("O0214")
            '                            oWrite.WriteLine("V0")
            '                            oWrite.WriteLine("t1")
            '                            oWrite.WriteLine("Kf0070")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                            oWrite.WriteLine("D11")
            '                            oWrite.WriteLine("ySPM")
            '                            oWrite.WriteLine("A2")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                                TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                                TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                            End If

            '                            oWrite.WriteLine("1911C1401710016" & TEMPREMARKS)
            '                            oWrite.WriteLine("1911C1200750149" & TEMPWIDTH)
            '                            oWrite.WriteLine("1911C1201440070" & TEMPCATEGORY)

            '                            oWrite.WriteLine("1911C1201440007Quality")
            '                            oWrite.WriteLine("1911C1201210007Design")
            '                            oWrite.WriteLine("1911C1001450063:")
            '                            oWrite.WriteLine("1911C1201210070" & dr("ITEMNAME"))
            '                            oWrite.WriteLine("1911C1001210063:")
            '                            oWrite.WriteLine("1911C1200750007Mtrs")
            '                            oWrite.WriteLine("1911C1000760063:")
            '                            oWrite.WriteLine("1911C1200750070" & Format(Val(dr("CHECKEDMTRS")), "0.00"))
            '                            oWrite.WriteLine("1e4204000300000B" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911A1200110028" & dr("BARCODE"))
            '                            oWrite.WriteLine("1X1100101710011P0010001016900110169017701710177")
            '                            oWrite.WriteLine("1911C1200980007Shade")
            '                            oWrite.WriteLine("1911C1000990063:")
            '                            oWrite.WriteLine("1911C1200980070" & dr("COLOR"))
            '                            oWrite.WriteLine("Q0001")
            '                            oWrite.WriteLine("E")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "AVIS" Then

            '                            If dr("PIECETYPE") <> "FRESH" Then Exit Sub

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                            oWrite.WriteLine("n")
            '                            oWrite.WriteLine("M0739")
            '                            oWrite.WriteLine("O0214")
            '                            oWrite.WriteLine("V0")
            '                            oWrite.WriteLine("t1")
            '                            oWrite.WriteLine("Kf0070")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                            oWrite.WriteLine("D11")
            '                            oWrite.WriteLine("ySPM")
            '                            oWrite.WriteLine("A2")
            '                            oWrite.WriteLine("1911C1402500039Quality")
            '                            oWrite.WriteLine("1911C1402230039D. No")
            '                            oWrite.WriteLine("1911C1401950039Shade")
            '                            oWrite.WriteLine("1911C1401670039Grade")
            '                            oWrite.WriteLine("1911C1401390039Mtrs")
            '                            oWrite.WriteLine("1e6303800410038B" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911C1200220120" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911C1402500118:")
            '                            oWrite.WriteLine("1911C1402230118:")
            '                            oWrite.WriteLine("1911C1401950118:")
            '                            oWrite.WriteLine("1911C1401670118:")
            '                            oWrite.WriteLine("1911C1401390118:")
            '                            oWrite.WriteLine("1911C1402500141" & dr("ITEMNAME"))
            '                            oWrite.WriteLine("1911C1402230141" & dr("DESIGN"))
            '                            oWrite.WriteLine("1911C1401950141" & dr("COLOR"))
            '                            oWrite.WriteLine("1911C1401670141" & dr("UNIT"))
            '                            oWrite.WriteLine("1911C1401390141" & Format(Val(dr("CHECKEDMTRS")), "0.00"))
            '                            If dr("NARR") <> "" Then oWrite.WriteLine("1911C1001180141 (" & dr("NARR") & ")")
            '                            oWrite.WriteLine("1911C1400890039Lot No")
            '                            oWrite.WriteLine("1911C1400890118:")
            '                            oWrite.WriteLine("1911C1400890141" & TXTLOTNO.Text.Trim)
            '                            oWrite.WriteLine("Q0001")
            '                            oWrite.WriteLine("E")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "SBA" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                            oWrite.WriteLine("n")
            '                            oWrite.WriteLine("M0500")
            '                            oWrite.WriteLine("O0214")
            '                            oWrite.WriteLine("V0")
            '                            oWrite.WriteLine("t1")
            '                            oWrite.WriteLine("Kf0070")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                            oWrite.WriteLine("D11")
            '                            oWrite.WriteLine("ySPM")
            '                            oWrite.WriteLine("A2")
            '                            oWrite.WriteLine("1911A2401590067" & dr("ITEMNAME"))
            '                            oWrite.WriteLine("1911A1001430011QUALITY")
            '                            oWrite.WriteLine("1911A1001430079:")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS, TEMPCMPSTAMP As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                                TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                                TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                            End If

            '                            oWrite.WriteLine("1911A1001430090" & TEMPCATEGORY)
            '                            oWrite.WriteLine("1911A1001240090" & TEMPREMARKS)
            '                            oWrite.WriteLine("1911A1001070090" & TEMPWIDTH)

            '                            oWrite.WriteLine("1911A1001070011WIDTH")
            '                            oWrite.WriteLine("1911A1001070079:")

            '                            oWrite.WriteLine("1911A1001070185DESIGN NO")
            '                            oWrite.WriteLine("1911A1001070267:")
            '                            oWrite.WriteLine("1911A1001070276" & dr("DESIGN"))
            '                            oWrite.WriteLine("1e6304700360025B" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911A0800220128" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911A1000880011MTRS")
            '                            oWrite.WriteLine("1911A1000880079:")
            '                            oWrite.WriteLine("1911A1400850090" & Format(Val(dr("CHECKEDMTRS")), "0.00"))
            '                            oWrite.WriteLine("1911A1000880185SHADE")
            '                            oWrite.WriteLine("1911A1000880267:")
            '                            oWrite.WriteLine("1911A1000880276" & dr("COLOR"))
            '                            oWrite.WriteLine("1911A1000080140A PRODUCT OF ")
            '                            oWrite.WriteLine("1X1100000010253L117028")
            '                            oWrite.WriteLine("A1")
            '                            DT = OBJCMN.search(" ISNULL(CMPMASTER.CMP_BUSINESSLINE, '') AS CMPSTAMP", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            '                            If DT.Rows.Count > 0 Then TEMPCMPSTAMP = DT.Rows(0).Item("CMPSTAMP")
            '                            oWrite.WriteLine("1911A1800010255" & TEMPCMPSTAMP)

            '                            oWrite.WriteLine("A2")
            '                            oWrite.WriteLine("1X1100001610007L376003")

            '                            oWrite.WriteLine("Q0001")
            '                            oWrite.WriteLine("E")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "POOJA" Then

            '                            oWrite.WriteLine("SIZE 98.5 mm, 37.5 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 754,267,""1"",180,2,2,""ITEM""")
            '                            oWrite.WriteLine("TEXT 637,267,""1"",180,2,2,"":""")
            '                            oWrite.WriteLine("BARCODE 762,103,""39"",65,0,180,3,8,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 473,30,""1"",180,1,1,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 754,204,""1"",180,2,2,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 637,204,""1"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 750,141,""1"",180,2,2,""COLOR""")
            '                            oWrite.WriteLine("TEXT 637,141,""1"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 352,141,""1"",180,2,2,""MTRS""")
            '                            oWrite.WriteLine("TEXT 263,141,""1"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 243,162,""3"",180,2,2,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("TEXT 609,274,""1"",180,3,3,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 609,204,""1"",180,2,2,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 609,141,""1"",180,2,2,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 372,200,""1"",180,2,2,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 263,200,""1"",180,2,2,"":""")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 239,200,""1"",180,2,2,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("BAR 37, 219, 719, 3")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "DETLINE" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>I8,A")
            '                            oWrite.WriteLine("q792")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q406,25")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>N")
            '                            oWrite.WriteLine("A762,304,2,1,3,3,N,""D. NO""")
            '                            oWrite.WriteLine("A595,304,2,1,3,3,N,"":""")

            '                            oWrite.WriteLine("A554,304,2,1,3,3,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A762,237,2,1,3,3,N,""SHADE""")
            '                            oWrite.WriteLine("A595,237,2,1,3,3,N,"":""")
            '                            oWrite.WriteLine("A554,237,2,1,3,3,N,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("A762,173,2,1,3,3,N,""WIDTH""")
            '                            oWrite.WriteLine("A595,173,2,1,3,3,N,"":""")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("A554,173,2,1,3,3,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A423,239,2,1,3,3,N,""MTRS""")
            '                            oWrite.WriteLine("A303,237,2,1,3,3,N,"":""")
            '                            oWrite.WriteLine("A266,241,2,2,3,3,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("B762,119,2,1,3,6,65,N,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("A647,50,2,2,2,2,N,""" & dr("BARCODE") & """")
            '                            'oWrite.WriteLine("A521,381,2,2,3,3,N,""")
            '                            oWrite.WriteLine("LO246,326,298,3")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "MYCOT" Then

            '                            If dr("PIECETYPE") <> "FRESH" Then Exit Sub
            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='100.1 mm'></xpml>SIZE 97.5 mm, 100.1 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='100.1 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 757,509,""2"",180,2,2,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 757,436,""2"",180,2,2,""SHADE""")
            '                            oWrite.WriteLine("TEXT 757,366,""2"",180,2,2,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 366,366,""2"",180,2,2,""MTRS""")
            '                            oWrite.WriteLine("BARCODE 767,294,""128M"",96,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 529,188,""1"",180,2,2,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 588,509,""2"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 588,436,""2"",180,2,2,"":""")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 559,366,""2"",180,2,2,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 244,366,""2"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 559,509,""2"",180,2,2,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 559,436,""2"",180,2,2,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("TEXT 588,366,""2"",180,2,2,"":""")
            '                            oWrite.WriteLine("TEXT 211,372,""3"",180,2,2,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "RMANILAL" Then

            '                            If dr("PIECETYPE") <> "FRESH" Then Exit Sub
            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 757,377,""0"",180,16,16,""ITEM NAME""")
            '                            oWrite.WriteLine("TEXT 757,313,""0"",180,16,16,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 757,248,""0"",180,16,16,""SHADE""")
            '                            oWrite.WriteLine("TEXT 526,377,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 526,315,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 526,251,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 505,377,""0"",180,16,16,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 504,315,""0"",180,16,16,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 504,251,""0"",180,16,16,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("BARCODE 767,126,""128M"",77,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 502,44,""0"",180,16,16,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 757,184,""0"",180,16,16,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 348,184,""0"",180,16,16,""MTRS""")
            '                            oWrite.WriteLine("TEXT 526,184,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 218,184,""0"",180,16,16,"":""")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 504,184,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 190,189,""0"",180,20,20,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "SUNCOTT" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            oWrite.WriteLine("ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 754,375,""0"",180,16,16,""ITEM""")
            '                            oWrite.WriteLine("TEXT 754,316,""0"",180,16,16,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 754,258,""0"",180,16,16,""SHADE""")
            '                            oWrite.WriteLine("TEXT 754,197,""0"",180,16,16,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 338,197,""0"",180,16,16,""MTRS""")
            '                            oWrite.WriteLine("TEXT 592,375,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 592,316,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 592,258,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 592,197,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 210,197,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 564,380,""0"",180,20,20,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 564,316,""0"",180,16,16,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 564,258,""0"",180,16,16,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 564,197,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 190,201,""0"",180,20,20,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("BARCODE 767,135,""128M"",74,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 503,55,""0"",180,12,12,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 376,258,""0"",180,16,16,""LOT NO""")
            '                            oWrite.WriteLine("TEXT 210,258,""0"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 187,258,""0"",180,16,16,""" & TXTLOTNO.Text.Trim & """")

            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "MANMANDIR" Then

            '                            oWrite.WriteLine("SIZE 97.5 mm, 50 mm")
            '                            oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            oWrite.WriteLine("DIRECTION 0,0")
            '                            oWrite.WriteLine("REFERENCE 0,0")
            '                            oWrite.WriteLine("OFFSET 0 mm")
            '                            oWrite.WriteLine("SET PEEL OFF")
            '                            oWrite.WriteLine("SET CUTTER OFF")
            '                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                            oWrite.WriteLine("SET TEAR ON")
            '                            oWrite.WriteLine("CLS")
            '                            oWrite.WriteLine("CODEPAGE 1252")
            '                            oWrite.WriteLine("TEXT 754,375,""ROMAN.TTF"",180,16,16,""ITEM""")
            '                            oWrite.WriteLine("TEXT 754,318,""ROMAN.TTF"",180,16,16,""DESIGN""")
            '                            oWrite.WriteLine("TEXT 754,258,""ROMAN.TTF"",180,16,16,""SHADE""")
            '                            oWrite.WriteLine("TEXT 754,197,""ROMAN.TTF"",180,16,16,""WIDTH""")
            '                            oWrite.WriteLine("TEXT 338,197,""ROMAN.TTF"",180,16,16,""MTRS""")
            '                            oWrite.WriteLine("TEXT 592,375,""ROMAN.TTF"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 592,318,""ROMAN.TTF"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 592,258,""ROMAN.TTF"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 592,197,""ROMAN.TTF"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 210,197,""ROMAN.TTF"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 564,380,""ROMAN.TTF"",180,20,20,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("TEXT 564,318,""ROMAN.TTF"",180,16,16,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("TEXT 564,258,""ROMAN.TTF"",180,16,16,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("TEXT 564,197,""ROMAN.TTF"",180,16,16,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("TEXT 190,201,""ROMAN.TTF"",180,20,20,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("BARCODE 767,135,""128M"",74,0,180,4,8,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("TEXT 503,55,""ROMAN.TTF"",180,12,12,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("TEXT 358,318,""ROMAN.TTF"",180,16,16,""LOT NO""")
            '                            oWrite.WriteLine("TEXT 192,318,""ROMAN.TTF"",180,16,16,"":""")
            '                            oWrite.WriteLine("TEXT 160,318,""ROMAN.TTF"",180,16,16,""" & dr("LOTNO") & """")
            '                            oWrite.WriteLine("PRINT 1,1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "CC" Or ClientName = "SHREEDEV" Then

            '                            oWrite.WriteLine("I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q418")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q203,25")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("B396,96,2,1,2,4,65,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A291,25,2,2,1,1,N,""" & dr("BARCODE") & """") 'BARCODE

            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_PURRATE,0) AS PURRATE, ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", " DESIGNMASTER ", " AND DESIGN_NO = '" & dr("DESIGN") & "' AND DESIGN_YEARID =  " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                If WHOLESALEBARCODE = 7 Then oWrite.WriteLine("A147,175,2,4,1,1,N,""" & Val(DT.Rows(0).Item("SALERATE")) & "/-""") Else oWrite.WriteLine("A147,175,2,4,1,1,N,""" & Val(DT.Rows(0).Item("WRATE")) / 10 & """")
            '                            Else
            '                                oWrite.WriteLine("A147,175,2,4,1,1,N,""")    'SALERATE
            '                            End If

            '                            oWrite.WriteLine("A399,173,2,2,1,1,N,""D.No""")
            '                            oWrite.WriteLine("A354,173,2,2,1,1,N,"":""")
            '                            oWrite.WriteLine("A339,173,2,2,1,1,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A399,126,2,2,1,1,N,""Item""")
            '                            oWrite.WriteLine("A354,126,2,2,1,1,N,"":""")
            '                            oWrite.WriteLine("A339,126,2,2,1,1,N,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "MNARESH" Then

            '                            If dr("PIECETYPE") <> "FRESH" Then Exit Sub
            '                            oWrite.WriteLine("I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q799")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("KIZZQ0")
            '                            oWrite.WriteLine("KI9+0.0")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q400,25")
            '                            oWrite.WriteLine("Arglabel 500 31")
            '                            oWrite.WriteLine("exit")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("A770,367,2,2,2,2,N,""ITEM""")
            '                            oWrite.WriteLine("B776,132,2,1,4,8,78,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A538,48,2,1,2,2,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A770,200,2,2,2,2,N,""WIDTH""")
            '                            oWrite.WriteLine("A651,367,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A651,200,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A625,367,2,2,2,2,N,""" & dr("ITEMNAME") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("A625,200,2,2,2,2,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A289,214,2,3,3,3,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("A421,200,2,2,2,2,N,""MTRS""")
            '                            oWrite.WriteLine("A318,200,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A770,256,2,2,2,2,N,""SHADE""")
            '                            oWrite.WriteLine("A651,256,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A625,256,2,2,2,2,N,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("A770,312,2,2,2,2,N,""D.NO""")
            '                            oWrite.WriteLine("A651,312,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A625,312,2,2,2,2,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "MANINATH" Then

            '                            oWrite.WriteLine("I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q812")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q406,25")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("A772,386,2,4,2,2,N,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("A772,310,2,3,2,2,N,""D.NO""")
            '                            oWrite.WriteLine("A772,243,2,3,2,2,N,""SHADE""")
            '                            oWrite.WriteLine("A772,174,2,3,2,2,N,""MTRS""")
            '                            oWrite.WriteLine("B772,110,2,1,3,6,67,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A592,37,2,4,1,1,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A367,174,2,3,2,2,N,""WIDTH""")
            '                            oWrite.WriteLine("A608,310,2,3,2,2,N,"":""")
            '                            oWrite.WriteLine("A608,243,2,3,2,2,N,"":""")
            '                            oWrite.WriteLine("A608,174,2,3,2,2,N,"":""")
            '                            oWrite.WriteLine("A219,174,2,3,2,2,N,"":""")
            '                            oWrite.WriteLine("A580,310,2,3,2,2,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A580,243,2,3,2,2,N,""" & dr("SHADE") & """")
            '                            oWrite.WriteLine("A580,174,2,3,2,2,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If
            '                            oWrite.WriteLine("A184,174,2,3,2,2,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "DEVEN" Then

            '                            oWrite.WriteLine("I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q609")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("KIZZQ0")
            '                            oWrite.WriteLine("KI9+0.0")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q426,25")
            '                            oWrite.WriteLine("Arglabel 533 31")
            '                            oWrite.WriteLine("exit")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("A562,385,2,2,3,3,N,""" & dr("itemname") & """")
            '                            oWrite.WriteLine("A563,313,2,1,2,2,N,""LOT""")
            '                            oWrite.WriteLine("A456,313,2,1,2,2,N,"":""")
            '                            oWrite.WriteLine("A433,313,2,1,2,2,N,""" & TXTLOTNO.Text.Trim & """")
            '                            oWrite.WriteLine("A202,313,2,1,2,2,N,""CMS""")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("A105,313,2,1,2,2,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A133,313,2,1,2,2,N,"":""")
            '                            oWrite.WriteLine("A563,259,2,1,2,2,N,""D NO""")
            '                            oWrite.WriteLine("A455,259,2,1,2,2,N,"":""")
            '                            oWrite.WriteLine("A432,259,2,1,2,2,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A223,259,2,1,2,2,N,""S NO""")
            '                            oWrite.WriteLine("A104,259,2,1,2,2,N,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("A132,259,2,1,2,2,N,"":""")
            '                            oWrite.WriteLine("A563,206,2,1,2,2,N,""MTRS""")
            '                            oWrite.WriteLine("A455,206,2,1,2,2,N,"":""")
            '                            oWrite.WriteLine("A432,206,2,1,3,3,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("B583,142,2,1,3,6,89,N,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("A411,47,2,4,1,1,N,""" & dr("BARCODE") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "RSONS" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='38.2 mm'></xpml>I8,A")
            '                            oWrite.WriteLine("q629")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("WN")
            '                            oWrite.WriteLine("D9")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q305,25")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='38.2 mm'></xpml>N")
            '                            oWrite.WriteLine("A618,234,2,4,1,1,N,""DESIGN""")
            '                            oWrite.WriteLine("B618,107,2,1,3,6,73,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A433,28,2,3,1,1,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A618,271,2,4,1,1,N,""QUALITY""")
            '                            oWrite.WriteLine("A334,234,2,4,1,1,N,""COLOR""")
            '                            oWrite.WriteLine("A618,159,2,4,1,1,N,""WIDTH""")
            '                            oWrite.WriteLine("A507,271,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A507,234,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A246,234,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A506,159,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A478,271,2,4,1,1,N,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("A478,234,2,4,1,1,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A229,234,2,4,1,1,N,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("A478,159,2,4,1,1,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A318,159,2,4,1,1,N,""MTRS""")
            '                            oWrite.WriteLine("A246,159,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A233,167,2,3,2,2,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("A618,197,2,4,1,1,N,""FABRIC""")
            '                            oWrite.WriteLine("A507,197,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A478,197,2,4,1,1,N,""" & dr("QUALITY") & """")
            '                            oWrite.WriteLine("A67,167,2,3,2,2,N,""" & dr("NARR") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "SANGHVI" Then

            '                            oWrite.WriteLine("I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q406")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q305,25")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("A386,197,2,4,1,1,N,""COLOR""")
            '                            oWrite.WriteLine("A386,155,2,4,1,1,N,""MTRS""")
            '                            oWrite.WriteLine("A300,197,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A300,155,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A362,280,2,4,1,1,N,""TINU MINU EMBROIDERY""")
            '                            oWrite.WriteLine("A151,239,2,4,1,1,N,""WIDTH""")
            '                            oWrite.WriteLine("A277,197,2,4,1,1,N,""" & dr("COLOR") & """")
            '                            oWrite.WriteLine("A277,155,2,4,1,1,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("A51,239,2,4,1,1,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A67,239,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("B390,112,2,1,2,4,63,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A313,43,2,4,1,1,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A386,239,2,4,1,1,N,""D.NO""")
            '                            oWrite.WriteLine("A300,239,2,4,1,1,N,"":""")
            '                            oWrite.WriteLine("A278,239,2,4,1,1,N,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("A151,155,2,4,1,1,N,""" & dr("NARR") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()


            '                        ElseIf ClientName = "MJFABRIC" Then

            '                            oWrite.WriteLine("I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q799")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q400,25")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("A774,312,2,2,2,2,N,""QUALITY""")
            '                            oWrite.WriteLine("A774,365,2,2,2,2,N,""DESIGN""")
            '                            oWrite.WriteLine("A774,252,2,2,2,2,N,""SHADE""")
            '                            oWrite.WriteLine("A774,193,2,2,2,2,N,""WIDTH""")
            '                            oWrite.WriteLine("A355,193,2,2,2,2,N,""MTRS""")
            '                            oWrite.WriteLine("B782,141,2,1,4,8,90,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A543,45,2,1,2,2,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A598,365,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A598,312,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A598,252,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A598,193,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A247,193,2,2,2,2,N,"":""")
            '                            oWrite.WriteLine("A558,365,2,2,2,2,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A558,314,2,2,2,2,N,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("A558,254,2,2,2,2,N,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            End If

            '                            oWrite.WriteLine("A558,193,2,2,2,2,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A213,205,2,4,2,2,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "KDFAB" Then

            '                            oWrite.WriteLine("I8,A")
            '                            oWrite.WriteLine("ZN")
            '                            oWrite.WriteLine("q401")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("KIZZQ0")
            '                            oWrite.WriteLine("KI9+0.0")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("Q304,25")
            '                            oWrite.WriteLine("Arglabel 380 31")
            '                            oWrite.WriteLine("exit")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("B386,112,2,1,2,4,75,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A281,31,2,2,1,1,N,""" & dr("BARCODE") & """") 'BARCODE
            '                            oWrite.WriteLine("A381,239,2,3,1,1,N,""NAME""")
            '                            oWrite.WriteLine("A381,194,2,3,1,1,N,""D. NO""")
            '                            oWrite.WriteLine("A305,290,2,2,2,2,N,""K. D. FAB""")
            '                            oWrite.WriteLine("A381,151,2,3,1,1,N,""MTRS""")
            '                            oWrite.WriteLine("A290,239,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A290,194,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A290,151,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A275,239,2,3,1,1,N,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("A275,194,2,3,1,1,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A275,155,2,2,2,2,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")

            '                            oWrite.WriteLine("A71,194,2,3,1,1,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A117,151,2,3,1,1,N,""" & dr("NARR") & """")
            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "BRILLANTO" Then

            '                            oWrite.WriteLine("I8,A,001")
            '                            oWrite.WriteLine("")
            '                            oWrite.WriteLine("")
            '                            oWrite.WriteLine("Q384,024")
            '                            oWrite.WriteLine("q863")
            '                            oWrite.WriteLine("rN")
            '                            oWrite.WriteLine("S3")
            '                            oWrite.WriteLine("D14")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("R253,0")
            '                            oWrite.WriteLine("f100")
            '                            oWrite.WriteLine("N")
            '                            oWrite.WriteLine("A341,164,2,3,1,1,N,""Grade""")
            '                            oWrite.WriteLine("A342,202,2,3,1,1,N,""Shade No.""")
            '                            oWrite.WriteLine("A344,238,2,3,1,1,N,""Width""")
            '                            oWrite.WriteLine("A344,274,2,3,1,1,N,""Mtrs""")
            '                            oWrite.WriteLine("A342,309,2,3,1,1,N,""M. Name""")
            '                            oWrite.WriteLine("A213,164,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A213,202,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A213,238,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A213,274,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A213,309,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A213,345,2,3,1,1,N,"":""")
            '                            oWrite.WriteLine("A198,164,2,3,1,1,N,""" & dr("PIECETYPE") & """")
            '                            oWrite.WriteLine("A198,202,2,3,1,1,N,""" & dr("COLOR") & """")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            oWrite.WriteLine("A198,238,2,3,1,1,N,""" & TEMPWIDTH & """")
            '                            oWrite.WriteLine("A111,273,2,3,1,1,N,""" & dr("UNIT") & """")

            '                            oWrite.WriteLine("A198,274,2,3,1,1,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            oWrite.WriteLine("A198,309,2,3,1,1,N,""" & dr("ITEMNAME") & """")
            '                            oWrite.WriteLine("A198,345,2,3,1,1,N,""" & dr("DESIGN") & """")
            '                            oWrite.WriteLine("A342,345,2,3,1,1,N,""Design No""")
            '                            oWrite.WriteLine("B352,122,2,1,2,6,81,B,""" & dr("BARCODE") & """")

            '                            oWrite.WriteLine("P1")
            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "MIDAS" Then

            '                            oWrite.WriteLine("<xpml><page quantity='0' pitch='38.2 mm'></xpml>G0")
            '                            oWrite.WriteLine("n")
            '                            oWrite.WriteLine("M0500")
            '                            oWrite.WriteLine("O0214")
            '                            oWrite.WriteLine("V0")
            '                            oWrite.WriteLine("t1")
            '                            oWrite.WriteLine("Kf0070")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='38.2 mm'></xpml>L")
            '                            oWrite.WriteLine("D11")
            '                            oWrite.WriteLine("ySPM")
            '                            oWrite.WriteLine("A2")
            '                            oWrite.WriteLine("1911C1401220034" & dr("ITEMNAME"))
            '                            oWrite.WriteLine("1911A1001000012D. NO")
            '                            oWrite.WriteLine("1X1100001190011L226001")
            '                            oWrite.WriteLine("1911A1000800012SHADE")
            '                            oWrite.WriteLine("1911A1000600012MTRS")
            '                            oWrite.WriteLine("1e4203200240011B" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911A0800100062" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911A1001000074:")
            '                            oWrite.WriteLine("1911A1000800074:")
            '                            oWrite.WriteLine("1911A1000600074:")
            '                            oWrite.WriteLine("1911A1001000086" & dr("DESIGN"))
            '                            oWrite.WriteLine("1911A1000800086" & dr("COLOR"))
            '                            oWrite.WriteLine("1911C1200590086" & Format(Val(dr("CHECKEDMTRS")), "0.00"))
            '                            oWrite.WriteLine("1911A1000600164PCS-1")
            '                            oWrite.WriteLine("Q0001")
            '                            oWrite.WriteLine("E")
            '                            oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")

            '                            oWrite.Dispose()

            '                        ElseIf ClientName = "TCOT" Then

            '                            oWrite.WriteLine("G0")
            '                            oWrite.WriteLine("n")
            '                            oWrite.WriteLine("M0690")
            '                            oWrite.WriteLine("O0214")
            '                            oWrite.WriteLine("V0")
            '                            oWrite.WriteLine("t1")
            '                            oWrite.WriteLine("Kf0070")
            '                            oWrite.WriteLine("L")
            '                            oWrite.WriteLine("D11")
            '                            oWrite.WriteLine("ySPM")
            '                            oWrite.WriteLine("A2")
            '                            oWrite.WriteLine("1911C1202480037QLTY")
            '                            oWrite.WriteLine("1911C1202250037DSGN.NO")
            '                            oWrite.WriteLine("1911C1202040037CH.NO.")
            '                            oWrite.WriteLine("1911C1201820037SHD.NO.")
            '                            oWrite.WriteLine("1911C1201600037LOT NO")
            '                            oWrite.WriteLine("1911C1201380037WIDTH")
            '                            oWrite.WriteLine("1911C1201160037MTRS")
            '                            oWrite.WriteLine("1911C1200940037GRADE")
            '                            oWrite.WriteLine("1911C1200710037RACK")
            '                            oWrite.WriteLine("1911C1202480124:")
            '                            oWrite.WriteLine("1911C1202250124:")
            '                            oWrite.WriteLine("1911C1202040124:")
            '                            oWrite.WriteLine("1911C1201820124:")
            '                            oWrite.WriteLine("1911C1201600124:")
            '                            oWrite.WriteLine("1911C1200940124:")
            '                            oWrite.WriteLine("1911C1201160124:")
            '                            oWrite.WriteLine("1911C1201380124:")
            '                            oWrite.WriteLine("1911C1200710124:")
            '                            oWrite.WriteLine("1e6303300310036B" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911C1200110114" & dr("BARCODE"))
            '                            oWrite.WriteLine("1911C1202480138" & dr("ITEMNAME"))
            '                            oWrite.WriteLine("1911C1202250138" & dr("DESIGN"))
            '                            oWrite.WriteLine("1911C1202040138" & dr("NARR"))
            '                            oWrite.WriteLine("1911C1201820138" & dr("COLOR"))
            '                            oWrite.WriteLine("1911C1201600138" & TXTLOTNO.Text.Trim)

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH As String = ""
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")


            '                            oWrite.WriteLine("1911C1201380138" & TEMPWIDTH)
            '                            oWrite.WriteLine("1911C1201160138" & Format(Val(dr("CHECKEDMTRS")), "0.00"))
            '                            oWrite.WriteLine("1911C1200710138")
            '                            oWrite.WriteLine("1911C1200940138" & dr("PIECETYPE"))
            '                            oWrite.WriteLine("Q0001")
            '                            oWrite.WriteLine("E")

            '                            oWrite.Dispose()


            '                        ElseIf ClientName = "SAFFRON" Then


            '                            'If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                            oWrite.WriteLine("I8,A,001")
            '                            oWrite.WriteLine("")
            '                            oWrite.WriteLine("")
            '                            oWrite.WriteLine("Q400,024")
            '                            oWrite.WriteLine("q831")
            '                            oWrite.WriteLine("rN")
            '                            oWrite.WriteLine("S5")
            '                            oWrite.WriteLine("D2")
            '                            oWrite.WriteLine("ZT")
            '                            oWrite.WriteLine("JF")
            '                            oWrite.WriteLine("O")
            '                            oWrite.WriteLine("R136,0")
            '                            oWrite.WriteLine("f100")
            '                            oWrite.WriteLine("N")

            '                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                            Dim TEMPWIDTH, TEMPCONTAIN As String
            '                            Dim OBJCMN As New ClsCommon
            '                            Dim DT As DataTable = OBJCMN.search(" ISNULL(CATEGORYMASTER.category_remarks, '') AS WIDTH, ISNULL(ITEMMASTER.item_remarks, '') AS CONTAIN , ISNULL(ITEMMASTER.item_DISPLAYNAME, '') AS DISPLAYNAME, ISNULL(HSN_CODE,'') AS HSNCODE ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then
            '                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                                TEMPCONTAIN = DT.Rows(0).Item("CONTAIN")
            '                            End If

            '                            oWrite.WriteLine("A419,146,0,1,3,3,N,""" & DT.Rows(0).Item("HSNCODE") & """")    'HSNCODE
            '                            oWrite.WriteLine("A151,154,0,1,2,2,N,""" & TEMPWIDTH & """")    'GIVE ITEM CATEGORY'S REMARKS
            '                            oWrite.WriteLine("A133,102,0,1,3,3,N,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")    'MTRS
            '                            oWrite.WriteLine("A459,104,0,1,3,3,N,""" & dr("COLOR") & """")       'COLOR
            '                            oWrite.WriteLine("A8,6,0,1,3,3,N,""" & DT.Rows(0).Item("DISPLAYNAME") & """")       'QUALITY
            '                            oWrite.WriteLine("A171,199,0,1,2,2,N,""" & TEMPCONTAIN & """")        'ITEMREMARKS
            '                            oWrite.WriteLine("A231,57,0,1,3,3,N,""" & dr("ITEMNAME") & """")      'ITEMNAME
            '                            oWrite.WriteLine("A11,200,0,1,2,2,N,""Contain:""")
            '                            oWrite.WriteLine("A318,154,0,1,2,2,N,""HSN :""")
            '                            oWrite.WriteLine("A318,111,0,1,2,2,N,""Shade :""")
            '                            oWrite.WriteLine("A11,153,0,1,2,2,N,""Width :""")
            '                            oWrite.WriteLine("A11,60,0,1,2,2,N,""Design No :""")
            '                            oWrite.WriteLine("A11,107,0,1,2,2,N,""Mtrs :""")
            '                            oWrite.WriteLine("B8,257,0,1,2,6,87,B,""" & dr("BARCODE") & """")       'BARCODE
            '                            oWrite.WriteLine("P1")

            '                            oWrite.Dispose()

            '                            'Else
            '                            '    oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 99.10 mm, 50 mm")
            '                            '    oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                            '    oWrite.WriteLine("SET RIBBON ON")
            '                            '    oWrite.WriteLine("DIRECTION 0,0")
            '                            '    oWrite.WriteLine("REFERENCE 0,0")
            '                            '    oWrite.WriteLine("OFFSET 0 mm")
            '                            '    oWrite.WriteLine("SET PEEL OFF")
            '                            '    oWrite.WriteLine("SET CUTTER OFF")
            '                            '    oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                            '    oWrite.WriteLine("CLS")
            '                            '    oWrite.WriteLine("CODEPAGE 1252")
            '                            '    oWrite.WriteLine("TEXT 758,273,""0"",180,16,16,""D.NO""")
            '                            '    oWrite.WriteLine("TEXT 646,50,""0"",180,25,14,""" & dr("BARCODE") & """") 'BARCODE
            '                            '    oWrite.WriteLine("TEXT 661,373,""0"",180,24,16,""" & CmpName & """")    'cmpname
            '                            '    oWrite.WriteLine("TEXT 625,326,""0"",180,18,10,""MEELON SILK MILLS""")   'barcode
            '                            '    oWrite.WriteLine("TEXT 622,274,""0"",180,16,16,"":""")
            '                            '    oWrite.WriteLine("TEXT 622,215,""0"",180,16,16,"":""")
            '                            '    oWrite.WriteLine("TEXT 214,217,""0"",180,16,16,"":""")
            '                            '    oWrite.WriteLine("TEXT 582,273,""0"",180,16,16,""" & dr("DESIGN") & """")
            '                            '    oWrite.WriteLine("TEXT 366,214,""0"",180,16,16,""SHADE""")
            '                            '    oWrite.WriteLine("TEXT 190,214,""0"",180,16,16,""" & dr("COLOR") & """")
            '                            '    oWrite.WriteLine("TEXT 758,214,""0"",180,16,16,""MTRS""")
            '                            '    oWrite.WriteLine("TEXT 582,214,""0"",180,16,16,""" & Format(Val(dr("CHECKEDMTRS")), "0.00") & """")
            '                            '    oWrite.WriteLine("BARCODE 698,159,""128M"",104,0,180,3,6,""" & dr("BARCODE") & """")
            '                            '    oWrite.WriteLine("PRINT 1,1")
            '                            '    oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")

            '                            '    oWrite.Dispose()

            '                        End If

            '                        'Printing Barcode
            '                        Dim psi As New ProcessStartInfo()
            '                        psi.FileName = "cmd.exe"
            '                        psi.RedirectStandardInput = False
            '                        psi.RedirectStandardOutput = True
            '                        'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
            '                        psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
            '                        'psi.Arguments = "print /d:\\admin-pc\ARGOX D:\Barcode.txt"    ' specify your command
            '                        psi.UseShellExecute = False

            '                        Dim proc As Process
            '                        proc = Process.Start(psi)
            '                        dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
            '                        '// do something with result stream
            '                        proc.WaitForExit()
            '                        proc.Dispose()

            'NEXTLINE:
            '                        oWrite.Dispose()




            '        Next
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InHouseChecking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.X) Or (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F5 Then       'for Delete
            GRIDCHECKING.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for CLEAR
            tstxtbillno.Focus()
        ElseIf e.keycode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub InHouseChecking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
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

                Dim OBJCHECKING As New ClsInHouseChecking()
                Dim dttable As DataTable = OBJCHECKING.SELECTCHECKING(TEMPCHECKINGNO, YearId)
                If dttable.Rows.Count > 0 Then
                    CMDSELECTLOT.Enabled = False

                    For Each dr As DataRow In dttable.Rows
                        TXTCHECKINGNO.Text = TEMPCHECKINGNO
                        CHECKINGDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        TXTNAME.Text = Convert.ToString(dr("NAME").ToString)
                        TXTGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTLOTNO.Text = Val(dr("LOTNO"))
                        TXTMATRECNO.Text = Val(dr("MATRECNO"))
                        TXTTYPE.Text = dr("TYPE")
                        TXTCHECKEDBY.Text = Convert.ToString(dr("CHECKEDBY").ToString)

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        GRIDCHECKING.Rows.Add(dr("GRIDSRNO").ToString, Format(Val(dr("GREYMTRS")), "0.00"), Format(Val(dr("RECDMTRS")), "0.00"), Format(Val(dr("CHECKEDMTRS")), "0.00"), dr("NARR").ToString, dr("PIECETYPE").ToString, Format(Val(dr("DIFF")), "0.00"), dr("UNIT").ToString, Format(Val(dr("WT")), "0.00"), dr("ITEMNAME"), dr("QUALITY"), dr("DESIGN"), dr("COLOR").ToString, dr("BARCODE"), dr("DONE"), Val(dr("OUTPCS")), Val(dr("OUTMTRS")))

                        If Val(dr("OUTMTRS")) > 0 Then
                            GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                            GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).ReadOnly = True
                        End If

                    Next
                    total()
                    GRIDCHECKING.FirstDisplayedScrollingRowIndex = GRIDCHECKING.RowCount - 1
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
            'FILL PIECETYPE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(PIECETYPE_NAME,'') AS PIECETYPE", "", " PIECETYPEMASTER ", " AND PIECETYPE_YEARID =" & YearId)
            If DT.Rows.Count > 0 Then
                GPIECETYPE.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    GPIECETYPE.Items.Add(ROW("PIECETYPE"))
                Next
            End If

            DT = OBJCMN.search("ISNULL(UNIT_ABBR,'') AS UNIT", "", " UNITMASTER ", " AND UNIT_YEARID =" & YearId)
            If DT.Rows.Count > 0 Then
                GUNIT.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    GUNIT.Items.Add(ROW("UNIT"))
                Next
            End If

            DT = OBJCMN.search("ISNULL(COLOR_NAME,'') AS COLOR", "", " COLORMASTER ", " AND COLOR_YEARID =" & YearId)
            If DT.Rows.Count > 0 Then
                GCOLOR.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    GCOLOR.Items.Add(ROW("COLOR"))
                Next
            End If

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
            Dim OBJCHECKING As New InHouseCheckingDetails
            OBJCHECKING.MdiParent = MDIMain
            OBJCHECKING.Show()
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

    Private Sub CMDSELECTLOT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDSELECTLOT.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSELECTLOT As New SelectLot
            Dim DT As DataTable = OBJSELECTLOT.DT
            OBJSELECTLOT.ShowDialog()

            If DT.Rows.Count > 0 Then

                TXTNAME.Text = DT.Rows(0).Item("NAME")
                TXTGODOWN.Text = DT.Rows(0).Item("GODOWN")
                TXTMATRECNO.Text = Val(DT.Rows(0).Item("MATRECNO"))
                If DT.Rows(0).Item("LOTNO") <> "0" Then TXTLOTNO.Text = DT.Rows(0).Item("LOTNO")
                TXTTYPE.Text = DT.Rows(0).Item("TYPE")

                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As New DataTable
                If TXTTYPE.Text = "MATREC" Then
                    DTTABLE = OBJCMN.search(" MATERIALRECEIPT_DESC.MATREC_MTRS AS GREYMTRS, MATERIALRECEIPT_DESC.MATREC_RECDMTRS AS RECDMTRS, ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR , MATREC_GRIDSRNO AS FROMSRNO, ISNULL(UNIT_ABBR,'') AS UNIT, ISNULL(MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO,'') AS LOTNO", "", " MATERIALRECEIPT_DESC INNER JOIN ITEMMASTER ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON MATERIALRECEIPT_DESC.MATREC_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON MATERIALRECEIPT_DESC.MATREC_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON MATERIALRECEIPT_DESC.MATREC_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN UNITMASTER ON MATERIALRECEIPT_DESC.MATREC_QTYUNITID = UNITMASTER.UNIT_id", " AND MATREC_NO = " & Val(DT.Rows(0).Item("MATRECNO")) & " AND MATREC_YEARID = " & YearId)
                ElseIf TXTTYPE.Text = "JOBIN" Then
                    DTTABLE = OBJCMN.search("  JOBIN_DESC.JI_MTRS AS GREYMTRS, JOBIN_DESC.JI_MTRS AS RECDMTRS, ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, JOBIN_DESC.JI_GRIDSRNO AS FROMSRNO, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(JOBIN.JI_LOTNO, '') AS LOTNO", "", " JOBIN_DESC INNER JOIN ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id INNER JOIN JOBIN ON JOBIN_DESC.JI_NO = JOBIN.JI_no AND JOBIN_DESC.JI_YEARID = JOBIN.JI_yearid LEFT OUTER JOIN COLORMASTER ON JOBIN_DESC.JI_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBIN_DESC.JI_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN UNITMASTER ON JOBIN_DESC.JI_QTYUNITID = UNITMASTER.unit_id ", " AND JOBIN.JI_NO = " & Val(DT.Rows(0).Item("MATRECNO")) & " AND JOBIN.JI_YEARID = " & YearId)
                Else
                    DTTABLE = OBJCMN.search(" GRN_DESC.GRN_MTRS AS GREYMTRS, GRN_DESC.GRN_MTRS AS RECDMTRS, ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR , GRN_GRIDSRNO AS FROMSRNO, ISNULL(UNIT_ABBR,'') AS UNIT, '' AS LOTNO", "", " GRN_DESC INNER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON GRN_DESC.GRN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN UNITMASTER ON GRN_DESC.GRN_QTYUNITID = UNITMASTER.UNIT_id ", " AND GRN_GRIDTYPE = 'FANCY MATERIAL' AND GRN_NO = " & Val(DT.Rows(0).Item("MATRECNO")) & " AND GRN_YEARID = " & YearId)
                End If
                For Each ROW As DataRow In DTTABLE.Rows
                    Dim CHECKEDMTRS As Decimal = Val(ROW("RECDMTRS"))
                    If ClientName = "PARAS" Then CHECKEDMTRS = 0
                    If TXTLOTNO.Text.Trim = "" And ROW("LOTNO") <> "0" And ROW("LOTNO") <> "" Then TXTLOTNO.Text = ROW("LOTNO")
                    GRIDCHECKING.Rows.Add(0, Val(ROW("GREYMTRS")), Val(ROW("RECDMTRS")), Val(CHECKEDMTRS), "", "FRESH", 0, ROW("UNIT"), 0, ROW("ITEMNAME"), ROW("QUALITY"), ROW("DESIGN"), ROW("COLOR"), "", 0, 0, 0)
                Next
                CMDSELECTLOT.Enabled = False
                total()
                getsrno(GRIDCHECKING)
                CHECKINGDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDCHECKING.RowCount = 0
                TEMPCHECKINGNO = Val(tstxtbillno.Text)
                If TEMPCHECKINGNO > 0 Then
                    EDIT = True
                    InHouseChecking_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDCHECKING.RowCount = 0
LINE1:
            TEMPCHECKINGNO = Val(TXTCHECKINGNO.Text) - 1
            If TEMPCHECKINGNO > 0 Then
                EDIT = True
                InHouseChecking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDCHECKING.RowCount = 0 And TEMPCHECKINGNO > 1 Then
                TXTCHECKINGNO.Text = TEMPCHECKINGNO
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
            GRIDCHECKING.RowCount = 0
LINE1:
            TEMPCHECKINGNO = Val(TXTCHECKINGNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTCHECKINGNO.Text.Trim
            clear()
            If Val(TXTCHECKINGNO.Text) - 1 >= TEMPCHECKINGNO Then
                EDIT = True
                InHouseChecking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDCHECKING.RowCount = 0 And TEMPCHECKINGNO < MAXNO Then
                TXTCHECKINGNO.Text = TEMPCHECKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

                If lbllocked.Visible = True Then
                    MsgBox("Unable to Delete, Checking Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Checking?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTCHECKINGNO.Text.Trim))
                alParaval.Add(TXTTYPE.Text.Trim)
                alParaval.Add(YearId)

                Dim ClsInHouseChecking As New ClsInHouseChecking()
                ClsInHouseChecking.alParaval = alParaval
                IntResult = ClsInHouseChecking.DELETE()
                MsgBox("Checking Deleted")
                clear()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCHECKING_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDCHECKING.CellValidating
        Try
            Dim colNum As Integer = GRIDCHECKING.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCHECKING.CurrentCell.Value = Nothing Then GRIDCHECKING.CurrentCell.Value = "0.00"
                        GRIDCHECKING.CurrentCell.Value = Format(Convert.ToDecimal(GRIDCHECKING.Item(colNum, e.RowIndex).Value), "0.00")
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

    Private Sub GRIDCHECKING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHECKING.KeyDown
        Try
            If e.KeyCode = Keys.F12 And GRIDCHECKING.RowCount > 0 And EDIT = False Then
                If GRIDCHECKING.CurrentRow.Cells(GITEMNAME.Index).Value <> "" Then
                    GRIDCHECKING.Rows.Add(CloneWithValues(GRIDCHECKING.CurrentRow))
                    GRIDCHECKING.Item(GRECDMTRS.Index, GRIDCHECKING.RowCount - 1).Value = 0
                    getsrno(GRIDCHECKING)
                    total()
                End If
            ElseIf e.KeyCode = Keys.Delete And GRIDCHECKING.Item(GRECDMTRS.Index, GRIDCHECKING.CurrentRow.Index).Value = 0 Then
                If GRIDCHECKING.Item(GOUTMTRS.Index, GRIDCHECKING.CurrentRow.Index).Value > 0 Then
                    MsgBox("Unable To Delete, Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                GRIDCHECKING.Rows.RemoveAt(GRIDCHECKING.CurrentRow.Index)
                getsrno(GRIDCHECKING)
                total()
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

    Sub PRINTREPORT()
        Try
            If MsgBox("Print Checking Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJPRINT As New InHouseDesign
                OBJPRINT.MdiParent = MDIMain
                OBJPRINT.WHERECLAUSE = "{INHOUSECHECKING.CHECK_NO} = " & TEMPCHECKINGNO & " AND {INHOUSECHECKING.CHECK_YEARID} = " & YearId
                OBJPRINT.Show()
            End If

            PRINTBARCODE()
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then PRINTREPORT()
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    'Private Sub GRIDCHECKING_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles GRIDCHECKING.DataError
    '    If (e.Context = (DataGridViewDataErrorContexts.Formatting Or DataGridViewDataErrorContexts.PreferredSize)) Then
    '        e.ThrowException = False
    '    End If
    'End Sub
End Class