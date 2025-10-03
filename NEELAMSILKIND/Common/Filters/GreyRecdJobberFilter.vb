
Imports System.ComponentModel
Imports BL

Public Class GreyRecdJobberFilter

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
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, "")
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, "", "")
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GreyRecdJobberFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GreyRecdJobberFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(sender As Object, e As EventArgs) Handles cmdshow.Click
        Try

            If RBBALANCECUT.Checked = True Then
                Dim OBJCUT As New JobberBalanceCutReport
                OBJCUT.MdiParent = MDIMain
                If CMBNAME.Text.Trim <> "" Then OBJCUT.WHERECLAUSE = OBJCUT.WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
                If CMBITEMNAME.Text.Trim <> "" Then OBJCUT.WHERECLAUSE = OBJCUT.WHERECLAUSE & " AND ITEMNAME = '" & CMBITEMNAME.Text.Trim & "'"
                If CMBDESIGN.Text.Trim <> "" Then OBJCUT.WHERECLAUSE = OBJCUT.WHERECLAUSE & " AND DESIGNNO = '" & CMBDESIGN.Text.Trim & "'"
                If CMBSHADE.Text.Trim <> "" Then OBJCUT.WHERECLAUSE = OBJCUT.WHERECLAUSE & " AND MATCHING = '" & CMBSHADE.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJCUT.WHERECLAUSE = OBJCUT.WHERECLAUSE & " AND CATEGORY = '" & CMBCATEGORY.Text.Trim & "'"
                OBJCUT.Show()
                Exit Sub
            End If



            Dim OBJSTOCK As New YarnDesign
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.WHERECLAUSE = " {GREYRECDKNITTING.GREY_YEARID}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJSTOCK.FROMDATE = dtfrom.Value.Date
                OBJSTOCK.TODATE = dtto.Value.Date
                OBJSTOCK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJSTOCK.FROMDATE = AccFrom.Date
                OBJSTOCK.TODATE = AccTo.Date
                OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
            If CMBCATEGORY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text.Trim & "'"
            If CMBSHADE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"

            If RBWEAVERDTLS.Checked = True Then
                OBJSTOCK.FRMSTRING = "GREYWEAVERDTLS"
            ElseIf RBWEAVERDESIGNDTLS.Checked = True Then
                OBJSTOCK.FRMSTRING = "GREYWEAVERDESIGNDTLS"
            ElseIf RBWTDIFF.Checked = True Then
                OBJSTOCK.FRMSTRING = "GREYWTDIFF"
            End If

            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
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

    Private Sub CMBDESIGN_Enter(sender As Object, e As EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(sender As Object, e As CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(sender As Object, e As EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORVALIDATE(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class