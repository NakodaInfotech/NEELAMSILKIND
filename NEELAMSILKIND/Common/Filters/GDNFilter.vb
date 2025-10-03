
Imports System.ComponentModel
Imports BL

Public Class GDNFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.X) Or (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf (e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.S) Then
                cmdshow_Click(sender, e)
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " AND LEDGERS.ACC_TYPE = 'AGENT' ")
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEM.Text.Trim)
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GDNFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJGRN As New DispatchDesign
            OBJGRN.MdiParent = MDIMain
            OBJGRN.WHERECLAUSE = "  {GDN.GDN_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "PARTYWISEDTLS" Else OBJGRN.FRMSTRING = "PARTYWISESUMM"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBITEM.Checked = True Then
                If CMBNAME.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBAGENT.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "ITEMWISEDTLS" Else OBJGRN.FRMSTRING = "ITEMWISESUMM"
                If CMBITEM.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"

            ElseIf RDBQUALITY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "QUALITYWISEDTLS" Else OBJGRN.FRMSTRING = "QUALITYWISESUMM"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"

            ElseIf RDBDESIGN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "DESIGNWISEDTLS" Else OBJGRN.FRMSTRING = "DESIGNWISESUMM"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text.Trim & "'"

            ElseIf RDBSHADE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "SHADEWISEDTLS" Else OBJGRN.FRMSTRING = "SHADEWISESUMM"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"

            ElseIf RDBGODOWN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "GODOWNWISEDTLS" Else OBJGRN.FRMSTRING = "GODOWNWISESUMM"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"

            ElseIf RDBAGENT.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "AGENTWISEDTLS" Else OBJGRN.FRMSTRING = "AGENTWISESUMM"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"

            ElseIf RDBPARTYDETAILS.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"

            ElseIf RDBPARTYWISESUMM.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYSUMM"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            ElseIf RDBDESIGNDETAILS.Checked = True Then
                OBJGRN.FRMSTRING = "DESIGNDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"

            ElseIf RDBDESIGNWISESUM.Checked = True Then
                OBJGRN.FRMSTRING = "DESIGNSUMM"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            ElseIf RDBDISPPARTYITEMSHADEDTLS.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYITEMSHADEDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"

            ElseIf RDBDISPPARTYDESIGNDTLS.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYDESIGNDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"

            End If

            If CMBDONE.Text <> "" Then
                If CMBDONE.Text = "Pending Challan" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GDN.GDN_DONE}=FALSE"
                If CMBDONE.Text = "Bill Done" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GDN.GDN_DONE}=TRUE"
            End If

            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEM.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(sender As Object, e As EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class