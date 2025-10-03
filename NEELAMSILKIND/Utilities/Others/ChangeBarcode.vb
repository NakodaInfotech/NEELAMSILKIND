Imports BL
Imports System.IO

Public Class ChangeBarcode
    Public EDIT As Boolean

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try

            If CMBITEMNAME.Text.Trim = "" And CMBDESIGN.Text.Trim = "" And CMBQUALITY.Text.Trim = "" And CMBSHADE.Text.Trim = "" And CMBUNIT.Text.Trim = "" Then
                MsgBox("Fill Proper Data", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'UPDATE THE BARCODE FIRST THEN PRINT
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            Dim UPDATEQUERY As String = ""


            Dim ITEMID As Integer = 0
            Dim QUALITYID As Integer = 0
            Dim DESIGNID As Integer = 0
            Dim COLORID As Integer = 0
            Dim UNITID As Integer = 0

            If CMBITEMNAME.Text.Trim <> "" Then
                DT = OBJCMN.search("ITEM_ID AS ITEMID", "", "ITEMMASTER", " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND ITEM_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then ITEMID = DT.Rows(0).Item("ITEMID")
            End If

            If CMBQUALITY.Text.Trim <> "" Then
                DT = OBJCMN.search("QUALITY_ID AS QUALITYID", "", "QUALITYMASTER", " AND QUALITY_NAME = '" & CMBQUALITY.Text.Trim & "' AND QUALITY_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then QUALITYID = DT.Rows(0).Item("QUALITYID")
            End If

            If CMBDESIGN.Text.Trim <> "" Then
                DT = OBJCMN.search("DESIGN_ID AS DESIGNID", "", "DESIGNMASTER", " AND DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then DESIGNID = DT.Rows(0).Item("DESIGNID")
            End If

            If CMBSHADE.Text.Trim <> "" Then
                DT = OBJCMN.search("COLOR_ID AS COLORID", "", "COLORMASTER", " AND COLOR_NAME = '" & CMBSHADE.Text.Trim & "' AND COLOR_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then COLORID = DT.Rows(0).Item("COLORID")
            End If

            If CMBUNIT.Text.Trim <> "" Then
                DT = OBJCMN.search("UNIT_ID AS UNITID", "", "UNITMASTER", " AND UNIT_ABBR = '" & CMBUNIT.Text.Trim & "' AND UNIT_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then UNITID = DT.Rows(0).Item("UNITID")
            End If


            If TXTTYPE.Text.Trim = "OPENING" Then
                UPDATEQUERY = "SM_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SM_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", SM_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SM_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", SM_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SM_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", SM_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SM_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", SM_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SM_UNITID = " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", SM_UNITID = 0"
                If TXTSTAMPING.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SM_REMARKS = '" & TXTSTAMPING.Text.Trim & "'"

                DT = OBJCMN.Execute_Any_String(" UPDATE STOCKMASTER SET " & UPDATEQUERY & " WHERE SM_NO = " & Val(TXTFROMNO.Text.Trim) & " AND SM_YEARID = " & YearId, "", "")


            ElseIf TXTTYPE.Text.Trim = "GRN" Then
                UPDATEQUERY = "GRN_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GRN_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", GRN_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GRN_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", GRN_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GRN_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", GRN_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GRN_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", GRN_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GRN_QTYUNITID = " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", GRN_QTYUNITID = 0"
                If TXTSTAMPING.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GRN_GRIDREMARKS = '" & TXTSTAMPING.Text.Trim & "'"

                DT = OBJCMN.Execute_Any_String(" UPDATE GRN_DESC SET " & UPDATEQUERY & " WHERE GRN_NO = " & Val(TXTFROMNO.Text.Trim) & " AND GRN_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND GRN_YEARID = " & YearId, "", "")


            ElseIf TXTTYPE.Text.Trim = "MATREC" Then
                UPDATEQUERY = "MATREC_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", MATREC_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", MATREC_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", MATREC_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", MATREC_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", MATREC_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", MATREC_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", MATREC_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", MATREC_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", MATREC_QTYUNITID = " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", MATREC_QTYUNITID = 0"

                DT = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT_DESC SET " & UPDATEQUERY & " WHERE MATREC_NO= " & Val(TXTFROMNO.Text.Trim) & " AND MATREC_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND MATREC_YEARID = " & YearId, "", "")


            ElseIf TXTTYPE.Text.Trim = "INHOUSECHECK" Then
                UPDATEQUERY = "CHECK_USERID = " & Userid
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", CHECK_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", CHECK_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", CHECK_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", CHECK_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", CHECK_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", CHECK_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", CHECK_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", CHECK_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", CHECK_UNITID = " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", CHECK_UNITID = 0"
                If TXTSTAMPING.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", CHECK_NARR = '" & TXTSTAMPING.Text.Trim & "'"

                DT = OBJCMN.Execute_Any_String(" UPDATE INHOUSECHECKING_DESC SET " & UPDATEQUERY & " WHERE CHECK_NO = " & Val(TXTFROMNO.Text.Trim) & " AND CHECK_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND CHECK_YEARID = " & YearId & "", "", "")


            ElseIf TXTTYPE.Text.Trim = "FINALPACKING" Then
                UPDATEQUERY = "FP_USERID = " & Userid
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", FP_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", FP_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", FP_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", FP_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", FP_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", FP_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", FP_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", FP_COLORID = 0"

                DT = OBJCMN.Execute_Any_String(" UPDATE FINALPACKING_DESC SET " & UPDATEQUERY & " WHERE FP_NO = " & Val(TXTFROMNO.Text.Trim) & "  AND FP_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND FP_YEARID = " & YearId, "", "")

            ElseIf TXTTYPE.Text.Trim = "KNITTING" Then
                UPDATEQUERY = "GREY_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GREY_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", GREY_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GREY_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", GREY_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GREY_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", GREY_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GREY_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", GREY_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", GREY_QTYUNITID= " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", GREY_QTYUNITID = 0"
                If Val(TXTOURWT.Text.Trim) <> 0 Then UPDATEQUERY = UPDATEQUERY + ", GREY_OURWT = " & Format(Val(TXTOURWT.Text.Trim), "0.00")

                DT = OBJCMN.Execute_Any_String(" UPDATE GREYRECDKNITTING_DESC SET " & UPDATEQUERY & " WHERE GREY_NO = " & Val(TXTFROMNO.Text.Trim) & " AND GREY_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND GREY_YEARID = " & YearId, "", "")


            ElseIf TXTTYPE.Text.Trim = "JOBIN" Then
                UPDATEQUERY = "JI_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", JI_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", JI_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", JI_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", JI_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", JI_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", JI_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", JI_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", JI_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", JI_QTYUNITID= " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", JI_QTYUNITID = 0"

                DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN_DESC SET " & UPDATEQUERY & " WHERE JI_NO = " & Val(TXTFROMNO.Text.Trim) & " AND JI_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND JI_YEARID = " & YearId, "", "")

            ElseIf TXTTYPE.Text.Trim = "PACKING" Then
                UPDATEQUERY = "REC_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", REC_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", REC_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", REC_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", REC_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", REC_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", REC_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", REC_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", REC_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", REC_QTYUNITID = " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", REC_QTYUNITID = 0"
                If TXTSTAMPING.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", REC_GRIDREMARKS = '" & TXTSTAMPING.Text.Trim & "'"

                DT = OBJCMN.Execute_Any_String(" UPDATE RECPACKING_DESC SET " & UPDATEQUERY & " WHERE REC_NO = " & Val(TXTFROMNO.Text.Trim) & " AND REC_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND REC_YEARID = " & YearId, "", "")

            ElseIf TXTTYPE.Text.Trim = "SALERET" Then
                UPDATEQUERY = "SALRET_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SALRET_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", SALRET_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SALRET_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", SALRET_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SALRET_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", SALRET_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SALRET_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", SALRET_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SALRET_QTYUNITID = " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", SALRET_QTYUNITID = 0"

                DT = OBJCMN.Execute_Any_String(" UPDATE SALERETURN_DESC SET " & UPDATEQUERY & " WHERE SALRET_NO = " & Val(TXTFROMNO.Text.Trim) & " AND SALRET_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND SALRET_YEARID = " & YearId, "", "")

            ElseIf TXTTYPE.Text.Trim = "STOCKADJUSTMENT" Then
                UPDATEQUERY = "SA_MODIFIED = GETDATE()"
                If CMBITEMNAME.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SA_ITEMID = " & ITEMID Else UPDATEQUERY = UPDATEQUERY + ", SA_ITEMID = 0"
                If CMBQUALITY.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SA_QUALITYID = " & QUALITYID Else UPDATEQUERY = UPDATEQUERY + ", SA_QUALITYID = 0"
                If CMBDESIGN.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SA_DESIGNID = " & DESIGNID Else UPDATEQUERY = UPDATEQUERY + ", SA_DESIGNID = 0"
                If CMBSHADE.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SA_COLORID = " & COLORID Else UPDATEQUERY = UPDATEQUERY + ", SA_COLORID = 0"
                If CMBUNIT.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SA_QTYUNITID = " & UNITID Else UPDATEQUERY = UPDATEQUERY + ", SA_QTYUNITID = 0"
                If TXTSTAMPING.Text.Trim <> "" Then UPDATEQUERY = UPDATEQUERY + ", SA_GRIDDESC = '" & TXTSTAMPING.Text.Trim & "'"

                DT = OBJCMN.Execute_Any_String(" UPDATE STOCKADJUSTMENT_INDESC SET " & UPDATEQUERY & " WHERE SA_NO = " & Val(TXTFROMNO.Text.Trim) & " AND SA_GRIDSRNO = " & Val(TXTFROMSRNO.Text.Trim) & " AND SA_YEARID = " & YearId, "", "")

            End If

            If MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


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


                For I As Integer = 1 To Val(txtcopies.Text.Trim)
                    BARCODEPRINTING(txtbarcode.Text.Trim, TXTPIECETYPE.Text.Trim, CMBITEMNAME.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, CMBSHADE.Text.Trim, CMBUNIT.Text.Trim, "", TXTDESC.Text.Trim, TXTDESC.Text.Trim, Val(TXTMTRS.Text.Trim), 1, "", TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
                Next
                clear()
                txtbarcode.Focus()
            Else
                clear()
                txtbarcode.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelprint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            txtbarcode.Clear()
            txtcopies.Text = 1
            TXTPIECETYPE.Clear()
            TXTITEMNAME.Clear()
            TXTQUALITY.Clear()
            TXTDESIGN.Clear()
            TXTSHADE.Clear()
            TXTUNIT.Clear()
            TXTGODOWN.Clear()
            TXTMTRS.Clear()
            CMBDESIGN.Text = ""
            CMBQUALITY.Text = ""
            CMBITEMNAME.Text = ""
            CMBSHADE.Text = ""
            CMBUNIT.Text = ""
            TXTLOTNO.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelprint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            clear()
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, "")
            If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcopies_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcopies.KeyPress
        numkeypress(e, txtcopies, Me)
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
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

    Private Sub CMBDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBSHADE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBSHADE.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            txtbarcode.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeBarcode_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "CC" Or ClientName = "SHREEDEV" Then CHKBARCODE.Visible = True
        If ClientName = "SANGHVI" Or ClientName = "KDFAB" Then
            LBLDESC.Visible = True
            TXTDESC.Visible = True
        End If
    End Sub

    Private Sub txtbarcode_Validated(sender As Object, e As EventArgs) Handles txtbarcode.Validated
        Try
            If Len(txtbarcode.Text.Trim) > 7 Then

                'GET DATA FROM BARCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & txtbarcode.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("DONE") = 1 Then
                        MsgBox("Barcode is Locked", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    TXTPIECETYPE.Text = DT.Rows(0).Item("PIECETYPE")
                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    TXTQUALITY.Text = DT.Rows(0).Item("QUALITY")
                    TXTDESIGN.Text = DT.Rows(0).Item("DESIGNNO")
                    TXTSHADE.Text = DT.Rows(0).Item("COLOR")
                    TXTUNIT.Text = DT.Rows(0).Item("UNIT")
                    TXTGODOWN.Text = DT.Rows(0).Item("GODOWN")
                    TXTLOTNO.Text = DT.Rows(0).Item("CHALLANNO")
                    TXTMTRS.Text = Format((Val(DT.Rows(0).Item("MTRS"))), "0.00")
                    TXTSTAMPING.Text = DT.Rows(0).Item("GRIDREMARKS")

                    CMBITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    CMBDESIGN.Text = DT.Rows(0).Item("DESIGNNO")
                    CMBQUALITY.Text = DT.Rows(0).Item("QUALITY")
                    CMBSHADE.Text = DT.Rows(0).Item("COLOR")
                    CMBUNIT.Text = DT.Rows(0).Item("UNIT")

                    TXTFROMNO.Text = Val(DT.Rows(0).Item("FROMNO"))
                    TXTFROMSRNO.Text = Val(DT.Rows(0).Item("FROMSRNO"))
                    TXTTYPE.Text = DT.Rows(0).Item("TYPE")

                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    txtbarcode.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOURWT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTOURWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class