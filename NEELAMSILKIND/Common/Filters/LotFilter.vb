
Imports BL

Public Class LotFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub CMBJOBBER_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBJOBBER.Enter
        Try
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBJOBBER.Validating
        Try
            If CMBJOBBER.Text.Trim <> "" Then namevalidate(CMBJOBBER, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
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

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LotFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.X) Or (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LotFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim LOTCLAUSE As String = ""
            If CHKGRIDDETAILS.Checked = True Then
                Dim OBJLOTGRID As New LotGridreport
                OBJLOTGRID.MdiParent = MDIMain
                OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " AND YEARID = " & YearId
                If chkdate.CheckState = CheckState.Checked Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and RECDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                If CMBJOBBER.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and JOBBERNAME='" & CMBJOBBER.Text.Trim & "'"
                If CMBITEMNAME.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and ITEMNAME='" & CMBITEMNAME.Text.Trim & "'"
                If CMBQUALITY.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and QUALITY='" & CMBQUALITY.Text.Trim & "'"
                If CMBCATEGORY.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and CATEGORYNAME='" & CMBCATEGORY.Text.Trim & "'"

                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If LOTCLAUSE = "" Then
                            LOTCLAUSE = " AND (LOTNO = '" & dtrow("LOTNO") & "'"
                        Else
                            LOTCLAUSE = LOTCLAUSE & " OR LOTNO = '" & dtrow("LOTNO") & "'"
                        End If
                    End If
                Next
                If LOTCLAUSE <> "" Then
                    LOTCLAUSE = LOTCLAUSE & ")"
                    OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & LOTCLAUSE
                End If

                If LOTSTATUSONMTRS = False Then
                    If RDBPENDING.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and BALPCS>0 AND LOTCOMPLETED='FALSE'"
                    ElseIf RDBCOMPLETE.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and (BALPCS=0 OR LOTCOMPLETED='TRUE')"
                    End If
                Else
                    If RDBPENDING.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and LOTCOMPLETED='FALSE'"
                    ElseIf RDBCOMPLETE.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and LOTCOMPLETED='TRUE'"
                    End If
                End If

                OBJLOTGRID.Show()
                Exit Sub
            End If



            Dim OBJGRN As New GRNDesign
            OBJGRN.MdiParent = MDIMain
            OBJGRN.WHERECLAUSE = " {LOT_VIEW.yearid}=" & YearId
            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@GRNDATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBJOBBER.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.JOBBERNAME}='" & CMBJOBBER.Text.Trim & "'"
            If CMBITEMNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.ITEMNAME}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.QUALITY}='" & CMBQUALITY.Text.Trim & "'"
            If CMBCATEGORY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.CATEGORYNAME}='" & CMBCATEGORY.Text.Trim & "'"

            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If LOTCLAUSE = "" Then
                        LOTCLAUSE = " AND ({LOT_VIEW.LOTNO} = '" & dtrow("LOTNO") & "'"
                    Else
                        LOTCLAUSE = LOTCLAUSE & " OR {LOT_VIEW.LOTNO} = '" & dtrow("LOTNO") & "'"
                    End If
                End If
            Next
            If LOTCLAUSE <> "" Then
                LOTCLAUSE = LOTCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & LOTCLAUSE
            End If


            If CHKSUMMARY.Checked = True Then
                OBJGRN.FRMSTRING = "FULLSUMMARY"
            ElseIf RDBFULL.Checked = True Then
                OBJGRN.FRMSTRING = "FULL"
            ElseIf RDBPENDING.Checked = True Then
                OBJGRN.FRMSTRING = "FULLPENDING"
            ElseIf RDBCOMPLETE.Checked = True Then
                OBJGRN.FRMSTRING = "FULLCOMPLETED"
            End If

            If LOTSTATUSONMTRS = False Then
                If RDBPENDING.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.BALPCS}>0 AND {LOT_VIEW.LOTCOMPLETED}=FALSE"
                ElseIf RDBCOMPLETE.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({LOT_VIEW.BALPCS}=0 OR {LOT_VIEW.LOTCOMPLETED}=TRUE)"
                End If
            Else
                If RDBPENDING.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.LOTCOMPLETED}=FALSE"
                ElseIf RDBCOMPLETE.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.LOTCOMPLETED}=TRUE"
                End If
            End If

            OBJGRN.Show()
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
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBJOBBER.Validated
        Try
            Dim OBJCMN As New ClsCommon
            'Dim dt As DataTable = OBJCMN.search(" DISTINCT  CAST (0 AS BIT) AS CHK, LOTNO ", " ", " (SELECT   DISTINCT  CHECKINGMASTER.CHECK_LOTNO AS LOTNO, CHECKINGMASTER.CHECK_NO AS FROMNO,  CHECKINGMASTER.CHECK_cmpid AS CMPID, CHECKINGMASTER.CHECK_locationid AS LOCATIONID, CHECKINGMASTER.CHECK_yearid AS YEARID FROM CHECKINGMASTER INNER JOIN CHECKINGMASTER_DESC ON CHECKINGMASTER.CHECK_NO = CHECKINGMASTER_DESC.CHECK_NO AND CHECKINGMASTER.CHECK_CMPID = CHECKINGMASTER_DESC.CHECK_CMPID AND CHECKINGMASTER.CHECK_LOCATIONID = CHECKINGMASTER_DESC.CHECK_LOCATIONID AND CHECKINGMASTER.CHECK_YEARID = CHECKINGMASTER_DESC.CHECK_YEARID INNER JOIN LEDGERS ON CHECKINGMASTER.CHECK_LEDGERID = LEDGERS.Acc_id AND CHECKINGMASTER.CHECK_CMPID = LEDGERS.Acc_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = LEDGERS.Acc_locationid AND CHECKINGMASTER.CHECK_YEARID = LEDGERS.Acc_yearid  WHERE LEDGERS.ACC_CMPNAME = '" & CMBJOBBER.Text.Trim & "' AND (CHECKINGMASTER.CHECK_TYPE = 'JOB WORK') AND CHECKINGMASTER_DESC.CHECK_CHECKINGDONE = 0  UNION ALL SELECT   DISTINCT  STOCKMASTER.SM_LOTNO, SM_NO AS FROMNO, SM_CMPID, SM_LOCATIONID, SM_YEARID  FROM STOCKMASTER INNER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERIDTO = LEDGERS.Acc_id AND STOCKMASTER.SM_CMPID = LEDGERS.Acc_cmpid AND STOCKMASTER.SM_LOCATIONID = LEDGERS.Acc_locationid And STOCKMASTER.SM_YEARID = LEDGERS.Acc_yearid WHERE LEDGERS.ACC_CMPNAME = '" & CMBJOBBER.Text.Trim & "' AND SM_TYPE = 'JOBBERSTOCK' AND SM_LOTNO <> ''  ) AS T ", " AND T.YEARID = " & YearId)
            Dim dt As DataTable = OBJCMN.search(" DISTINCT  CAST (0 AS BIT) AS CHK, LOTNO ", " ", " LOT_VIEW ", " AND LOTNO <> '' AND JOBBERNAME ='" & CMBJOBBER.Text.Trim & "' AND YEARID = " & YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class