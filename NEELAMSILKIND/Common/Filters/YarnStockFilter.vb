
Imports BL

Public Class YarnStockFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, False)
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, False)
            If CMBMILLNAME.Text.Trim = "" Then fillmill(CMBMILLNAME, False)
            If CMBSHADE.Text.Trim = "" Then FILLYARNCOLOR(CMBSHADE, CMBYARNQUALITY.Text.Trim)
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub YarnStockFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YarnStockFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RBSTOCKONHAND.Checked = True Then
                Dim OBJYARNSTOCK As New YarnOnHandStock
                OBJYARNSTOCK.MdiParent = MDIMain
                OBJYARNSTOCK.Show()
                Exit Sub
            End If


            Dim OBJSTOCK As New YarnStockDesign
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.WHERECLAUSE = " {YARNSTOCKREGISTER.YEARID}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJSTOCK.FROMDATE = dtfrom.Value.Date
                OBJSTOCK.TODATE = dtto.Value.Date
                OBJSTOCK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                OBJSTOCK.FROMDATE = AccFrom.Date
                OBJSTOCK.TODATE = AccTo.Date
                OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBGODOWN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {YARNSTOCKREGISTER.GODOWN}='" & CMBGODOWN.Text.Trim & "'"
            If CMBYARNQUALITY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {YARNSTOCKREGISTER.YARNQUALITY}='" & CMBYARNQUALITY.Text.Trim & "'"
            If CMBMILLNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {YARNSTOCKREGISTER.MILLNAME}='" & CMBMILLNAME.Text.Trim & "'"
            If CMBSHADE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {YARNSTOCKREGISTER.COLOR}='" & CMBSHADE.Text.Trim & "'"
            If CMBNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {YARNSTOCKREGISTER.NAME}='" & CMBNAME.Text.Trim & "'"
            If CMBCATEGORY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {YARNSTOCKREGISTER.CATEGORY}='" & CMBCATEGORY.Text.Trim & "'"

            If RBYARNQUALITYSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "QUALITYSTOCKSUMM"
            ElseIf RBYARNQUALITYDETAIL.Checked = True Then
                OBJSTOCK.FRMSTRING = "QUALITYSTOCKDETAIL"
            ElseIf RBMILLSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "MILLSTOCKSUMM"
            ElseIf RDBMILLDETAIL.Checked = True Then
                OBJSTOCK.FRMSTRING = "MILLSTOCKDETAIL"
            ElseIf RBSHADESUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "SHADESTOCKSUMM"
            ElseIf RDBSHADEDETAIL.Checked = True Then
                OBJSTOCK.FRMSTRING = "SHADESTOCKDETAIL"

            ElseIf RDBWEAVERYARNDESIGNDETAILS.Checked = True Then
                If CMBNAME.Text.Trim = "" Or CMBYARNQUALITY.Text.Trim = "" Or Val(TXTDENIER.Text.Trim) = 0 Then
                    MsgBox("Select Proper Details", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                OBJSTOCK.WHERECLAUSE = " {DESIGNCARDISSUEYARNDETAILS.YEARID}=" & YearId
                If chkdate.Checked = True Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
                If CMBNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {DESIGNCARDISSUEYARNDETAILS.JOBBERNAME}='" & CMBNAME.Text.Trim & "'"
                If CMBYARNQUALITY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {DESIGNCARDISSUEYARNDETAILS.YARNQUALITY}='" & CMBYARNQUALITY.Text.Trim & "'"
                If CMBSHADE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {DESIGNCARDISSUEYARNDETAILS.COLOR}='" & CMBSHADE.Text.Trim & "'"

                If MsgBox("Show TL?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJSTOCK.SHOWTL = 1 Else OBJSTOCK.SHOWTL = 0


                'GET LAST WASTAGE DETAILS
                Dim OBJCMN As New ClsCommon
                Dim WHERECLAUSE As String = ""
                If CMBSHADE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND COLORMASTER.COLOR_NAME = '" & CMBSHADE.Text.Trim & "' "
                Dim DTWAS As DataTable = OBJCMN.search("ISNULL(YWASJOBBER_DATE, GETDATE()) AS LASTENTRYDATE, ISNULL(YARNWASTAGEJOBBER.YWASJOBBER_NO,0) AS LASTENTRYNO ,  ISNULL(YWASJOBBER_ACTUALWT,0) AS LASTSTOCK", "", " YARNWASTAGEJOBBER INNER JOIN YARNWASTAGEJOBBER_DESC ON YARNWASTAGEJOBBER.YWASJOBBER_NO = YARNWASTAGEJOBBER_DESC.YWASJOBBER_NO AND YARNWASTAGEJOBBER.YWASJOBBER_YEARID = YARNWASTAGEJOBBER_DESC.YWASJOBBER_YEARID INNER JOIN LEDGERS ON YWASJOBBER_LEDGERID = LEDGERS.ACC_ID INNER JOIN YARNQUALITYMASTER ON YWASJOBBER_QUALITYID = YARN_ID INNER JOIN COLORMASTER ON YWASJOBBER_COLORID = COLOR_ID ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND YARN_NAME = '" & CMBYARNQUALITY.Text.Trim & "' AND YARNWASTAGEJOBBER.YWASJOBBER_YEARID = " & YearId & WHERECLAUSE)
                If DTWAS.Rows.Count > 0 Then
                    OBJSTOCK.LASTENTRYDATE = DTWAS.Rows(0).Item("LASTENTRYDATE")
                    OBJSTOCK.LASTENTRYNO = Val(DTWAS.Rows(0).Item("LASTENTRYNO"))
                    OBJSTOCK.LASTSTOCK = Val(DTWAS.Rows(0).Item("LASTSTOCK"))
                End If

                OBJSTOCK.OPENINGSTOCK = Val(TXTOPENING.Text.Trim)
                OBJSTOCK.DENIER = Val(TXTDENIER.Text.Trim)
                OBJSTOCK.WARPWASTAGEPER = Val(TXTWARPWASTAGE.Text.Trim)
                OBJSTOCK.WEFTWASTAGEPER = Val(TXTWEFTWASTAGE.Text.Trim)
                OBJSTOCK.PERIOD = "(" & CMBNAME.Text.Trim & " - " & CMBYARNQUALITY.Text.Trim & " - " & CMBSHADE.Text.Trim & ")   WEAVER - YARN - DESIGN DETAIL - " & OBJSTOCK.PERIOD
                OBJSTOCK.FRMSTRING = "WEAVERYARNDESIGNDETAIL"
            End If

            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLYARNCOLOR(CMBSHADE, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then YARNCOLORVALIDATE(CMBSHADE, e, Me, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, False)
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

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " And GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, "  AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMILLNAME.Enter
        Try
            If CMBMILLNAME.Text.Trim = "" Then fillmill(CMBMILLNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILLNAME.Validating
        Try
            If CMBMILLNAME.Text.Trim <> "" Then MILLVALIDATE(CMBMILLNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validated(sender As Object, e As EventArgs) Handles CMBYARNQUALITY.Validated
        Try
            'GET DENIER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(YARN_DENIER,0) AS DENIER", "", " YARNQUALITYMASTER", " AND YARN_NAME = '" & CMBYARNQUALITY.Text.Trim & "' AND YARN_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTDENIER.Text = Val(DT.Rows(0).Item("DENIER"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOPENING_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTOPENING.KeyPress, TXTWARPWASTAGE.KeyPress, TXTWEFTWASTAGE.KeyPress, TXTDENIER.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class