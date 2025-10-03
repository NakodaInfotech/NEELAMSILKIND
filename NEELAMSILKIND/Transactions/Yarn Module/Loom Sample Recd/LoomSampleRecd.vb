
Imports System.ComponentModel
Imports BL

Public Class LoomSampleRecd

    Dim IntResult As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public TEMPSMP As String

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GET_MAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SMP_NO),0) + 1 ", " LOOMSAMPLERECD ", " and SMP_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSMPNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If


            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(SMPDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim DESIGNNO As String = ""
            Dim MATCHING As String = ""
            Dim CARDNO As String = ""
            Dim CARDSRNO As String = ""
            Dim REED As String = ""
            Dim PICK As String = ""
            Dim SAMPLEREED As String = ""
            Dim SAMPLEPICK As String = ""
            Dim APPROVED As String = ""
            Dim REASON As String = ""
            Dim GRIDREMARKS As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSAMPLE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If DESIGNNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        DESIGNNO = row.Cells(GDESIGNNO.Index).Value.ToString
                        MATCHING = row.Cells(GMATCHING.Index).Value
                        CARDNO = Val(row.Cells(GCARDNO.Index).Value)
                        CARDSRNO = Val(row.Cells(GCARDSRNO.Index).Value)
                        REED = row.Cells(GREED.Index).Value
                        PICK = Val(row.Cells(GPICK.Index).Value)
                        SAMPLEREED = row.Cells(GSMPREED.Index).Value
                        SAMPLEPICK = Val(row.Cells(GSMPPICK.Index).Value)
                        If row.Cells(GAPPROVED.Index).Value = "Yes" Then
                            APPROVED = "1"
                        Else
                            APPROVED = "0"
                        End If
                        If row.Cells(GREASON.Index).Value = Nothing Then REASON = "" Else REASON = row.Cells(GREASON.Index).Value
                        If row.Cells(GGRIDREMARKS.Index).Value = Nothing Then GRIDREMARKS = "" Else GRIDREMARKS = row.Cells(GGRIDREMARKS.Index).Value
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGNNO.Index).Value.ToString
                        MATCHING = MATCHING & "|" & row.Cells(GMATCHING.Index).Value
                        CARDNO = CARDNO & "|" & Val(row.Cells(GCARDNO.Index).Value)
                        CARDSRNO = CARDSRNO & "|" & Val(row.Cells(GCARDSRNO.Index).Value)
                        REED = REED & "|" & row.Cells(GREED.Index).Value
                        PICK = PICK & "|" & Val(row.Cells(GPICK.Index).Value)
                        SAMPLEREED = SAMPLEREED & "|" & row.Cells(GSMPREED.Index).Value
                        SAMPLEPICK = SAMPLEPICK & "|" & Val(row.Cells(GSMPPICK.Index).Value)
                        If row.Cells(GAPPROVED.Index).Value = "Yes" Then
                            APPROVED = APPROVED & "|" & "1"
                        Else
                            APPROVED = APPROVED & "|" & "0"
                        End If
                        If row.Cells(GREASON.Index).Value = Nothing Then REASON = REASON & "|" & "" Else REASON = REASON & "|" & row.Cells(GREASON.Index).Value
                        If row.Cells(GGRIDREMARKS.Index).Value = Nothing Then GRIDREMARKS = GRIDREMARKS & "|" & "" Else GRIDREMARKS = GRIDREMARKS & "|" & row.Cells(GGRIDREMARKS.Index).Value
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(DESIGNNO)
            alParaval.Add(MATCHING)
            alParaval.Add(CARDNO)
            alParaval.Add(CARDSRNO)
            alParaval.Add(REED)
            alParaval.Add(PICK)
            alParaval.Add(SAMPLEREED)
            alParaval.Add(SAMPLEPICK)
            alParaval.Add(APPROVED)
            alParaval.Add(REASON)
            alParaval.Add(GRIDREMARKS)


            Dim OBJSMP As New ClsLoomSampleRecd()
            OBJSMP.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJSMP.SAVE()
                TXTSMPNO.Text = DTT.Rows(0).Item(0)
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSMP)
                Dim IntResult As Integer = OBJSMP.UPDATE()
                MsgBox("Details Updated")

            End If

            EDIT = False
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True


        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Jobber Name")
            bln = False
        End If

        If GRIDSAMPLE.RowCount = 0 Then
            EP.SetError(CMBNAME, " Please Enter Sample Details")
            bln = False
        End If


        If SMPDATE.Text = "__/__/____" Then
            EP.SetError(SMPDATE, " Please Enter Proper Date")
            bln = False
        End If
        Return bln

    End Function

    Sub CLEAR()
        Try
            EP.Clear()
            SMPDATE.Text = Now.Date
            CMBNAME.Text = ""
            txtremarks.Clear()
            GRIDSAMPLE.RowCount = 0
            GET_MAX_NO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If MsgBox("Wish To Delete Loom Sample Recd?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                'DONE BY GULKIT
                'BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPSMP)
                ALPARAVAL.Add(YearId)


                Dim OBJPRO As New ClsLoomSampleRecd
                OBJPRO.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJPRO.DELETE
                MsgBox("Entry Deleted Sucessfully")

                CLEAR()
                EDIT = False
                CMBNAME.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " And GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SMP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'YARN ISSUE'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSMP As New ClsLoomSampleRecd()
                OBJSMP.alParaval.Add(TEMPSMP)
                OBJSMP.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSMP.SELECTSMP()
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        TXTSMPNO.Text = TEMPSMP
                        SMPDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)
                        GRIDSAMPLE.Rows.Add(Val(dr("GRIDSRNO")), dr("DESIGNNO"), dr("MATCHING"), Val(dr("CARDNO")), Val(dr("CARDSRNO")), dr("REED"), Val(dr("PICK")), dr("SAMPLEREED"), Val(dr("SAMPLEPICK")), dr("APPROVED"), dr("REASON"), dr("GRIDREMARKS"))

                    Next
                    GRIDSAMPLE.FirstDisplayedScrollingRowIndex = GRIDSAMPLE.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
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

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRIVIOUS.Click
        Try
            GRIDSAMPLE.RowCount = 0
LINE1:
            TEMPSMP = Val(TXTSMPNO.Text) - 1
            If TEMPSMP > 0 Then
                EDIT = True
                SMP_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSAMPLE.RowCount = 0 And TEMPSMP > 1 Then
                TXTSMPNO.Text = TEMPSMP
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDSAMPLE.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.NumPad1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.NumPad2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
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

            Dim OBJSMP As New LoomSampleRecdDetails
            OBJSMP.MdiParent = MDIMain
            OBJSMP.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDSAMPLE.RowCount = 0
LINE1:
            TEMPSMP = Val(TXTSMPNO.Text) + 1
            GET_MAX_NO()
            Dim MAXNO As Integer = TXTSMPNO.Text.Trim
            CLEAR()
            If Val(TXTSMPNO.Text) - 1 >= TEMPSMP Then
                EDIT = True
                SMP_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSAMPLE.RowCount = 0 And TEMPSMP < MAXNO Then
                TXTSMPNO.Text = TEMPSMP
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTISSUE_Click(sender As Object, e As EventArgs) Handles CMDSELECTISSUE.Click
        Try

            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Select Name First", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim OBJSMP As New SelectDesignCardIssue
            OBJSMP.JOBBERNAME = CMBNAME.Text.Trim
            OBJSMP.FRMSTRING = "LOOMSAMPLE"
            OBJSMP.ShowDialog()
            Dim DTTABLE As DataTable = OBJSMP.DT
            If DTTABLE.Rows.Count > 0 Then GRIDSAMPLE.RowCount = 0
            For Each DTROW As DataRow In DTTABLE.Rows
                FETCHISSUEDATA(DTROW("ISSUENO"), DTROW("ISSUESRNO"))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FETCHISSUEDATA(ISSUENO As Integer, ISSUESRNO As Integer)
        Try


            'FETCH ALL RELATED DATA FROM DESIGNCARDISSUE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DESIGNMASTER.DESIGN_NO AS DESIGNNO, COLORMASTER.COLOR_name AS MATCHING, DESIGNCARDISSUE.CARD_NO AS CARDNO, DESIGNCARDISSUE_DESC.CARD_GRIDSRNO AS CARDSRNO, DESIGNCARD.DESIGNCARD_REED AS REED, DESIGNCARD.DESIGNCARD_PICKS AS PICK", "", " DESIGNCARDISSUE INNER JOIN DESIGNCARDISSUE_DESC ON DESIGNCARDISSUE.CARD_NO = DESIGNCARDISSUE_DESC.CARD_NO AND DESIGNCARDISSUE.CARD_YEARID = DESIGNCARDISSUE_DESC.CARD_YEARID INNER JOIN DESIGNMASTER ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN DESIGNCARD ON DESIGNCARDISSUE_DESC.CARD_DESIGNID = DESIGNCARD.DESIGNCARD_DESIGNID AND DESIGNCARDISSUE_DESC.CARD_MATCHINGID = DESIGNCARD.DESIGNCARD_MATCHINGID INNER JOIN COLORMASTER ON DESIGNCARDISSUE_DESC.CARD_MATCHINGID = COLORMASTER.COLOR_id ", " AND DESIGNCARDISSUE.CARD_NO = " & Val(ISSUENO) & " AND DESIGNCARDISSUE_DESC.CARD_GRIDSRNO = " & Val(ISSUESRNO) & " AND DESIGNCARDISSUE.CARD_YEARID = " & YearId & " ORDER BY DESIGNCARDISSUE.CARD_NO, DESIGNCARDISSUE_DESC.CARD_GRIDSRNO ")
            For Each DR As DataRow In DT.Rows
                GRIDSAMPLE.Rows.Add(0, DR("DESIGNNO"), DR("MATCHING"), Val(DR("CARDNO")), Val(DR("CARDSRNO")), DR("REED"), Val(DR("PICK")), "", 0, "No", "", "")
            Next
            GETSRNO(GRIDSAMPLE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSAMPLE.RowCount = 0
                TEMPSMP = Val(tstxtbillno.Text)
                If TEMPSMP > 0 Then
                    EDIT = True
                    SMP_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(sender As Object, e As EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSMPNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSMPNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " And GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSAMPLE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDSAMPLE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSAMPLE.RowCount > 0 Then
                GRIDSAMPLE.Rows.RemoveAt(GRIDSAMPLE.CurrentRow.Index)
                GETSRNO(GRIDSAMPLE)
            ElseIf e.KeyCode = Keys.F1 And GRIDSAMPLE.CurrentCell.ColumnIndex = GREASON.Index Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "REASON"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then GRIDSAMPLE.CurrentCell.Value = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class