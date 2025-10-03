
Imports BL

Public Class UpdateDate

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            TXTENTRYNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            CMBTYPE.SelectedIndex = 0
            TXTENTRYNO.Clear()
            OLDDATE.Text = ""
            TXTNAME.Clear()
            TXTQTY.Clear()
            NEWDATE.Text = Now.Date
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMDUPDATE_Click(sender As Object, e As EventArgs) Handles CMDUPDATE.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If CMBTYPE.Text = "YARNISSUE" Then
                DT = OBJCMN.Execute_Any_String(" UPDATE YARNISSUE SET YARN_DATE = '" & Format(Convert.ToDateTime(NEWDATE.Text).Date, "MM/dd/yyyy") & "' WHERE YARNISSUE.YARN_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND YARNISSUE.YARN_YEARID = " & YearId, "", "")
            Else
                DT = OBJCMN.Execute_Any_String(" UPDATE GREYRECDKNITTING SET GREY_DATE = '" & Format(Convert.ToDateTime(NEWDATE.Text).Date, "MM/dd/yyyy") & "' WHERE GREYRECDKNITTING.GREY_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND GREYRECDKNITTING.GREY_YEARID = " & YearId, "", "")
            End If
            CLEAR()
            CMBTYPE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Val(TXTENTRYNO.Text.Trim) = 0 Then
            EP.SetError(TXTENTRYNO, "Select Entry")
            bln = False
        End If
        Return bln
    End Function

    Private Sub TXTENTRYNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTENTRYNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTENTRYNO_Validated(sender As Object, e As EventArgs) Handles TXTENTRYNO.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If CMBTYPE.Text = "YARNISSUE" Then
                DT = OBJCMN.search(" YARN_DATE AS OLDDATE, LEDGERS.Acc_cmpname AS NAME, YARNISSUE.YARN_TOTALWT AS QTY ", "", " YARNISSUE INNER JOIN LEDGERS ON YARNISSUE.YARN_LEDGERID = LEDGERS.ACC_ID ", " AND YARNISSUE.YARN_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND YARNISSUE.YARN_yearid = " & YearId)
            Else
                DT = OBJCMN.search("GREY_DATE AS OLDDATE, LEDGERS.Acc_cmpname AS NAME, GREYRECDKNITTING.GREY_TOTALWT AS QTY ", "", " GREYRECDKNITTING INNER JOIN LEDGERS ON GREYRECDKNITTING.GREY_LEDGERID = LEDGERS.ACC_ID ", " AND GREYRECDKNITTING.GREY_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND GREYRECDKNITTING.GREY_yearid = " & YearId)
            End If
            If DT.Rows.Count > 0 Then
                OLDDATE.Text = DT.Rows(0).Item("OLDDATE")
                TXTNAME.Text = DT.Rows(0).Item("NAME")
                TXTQTY.Text = Val(DT.Rows(0).Item("QTY"))
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateDate_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateDate_MinimumSizeChanged(sender As Object, e As EventArgs) Handles Me.MinimumSizeChanged

    End Sub
End Class