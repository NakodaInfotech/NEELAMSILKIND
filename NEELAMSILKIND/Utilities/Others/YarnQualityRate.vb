
Imports BL
Imports DevExpress.XtraEditors.Controls

Public Class YarnQualityRate

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Public TEMPENTRYNO As String

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GET_MAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(YARNRATE_NO),0) + 1 ", " YARNRATEMASTER ", " and YARNRATE_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try

            'dont allow to update rates, only user can delete or save new
            If EDIT = True Then
                MsgBox("Rate Update not allowed, Cannot Update Rates", MsgBoxStyle.Critical)
                Exit Sub
            End If

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList


            alParaval.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(txtremarks.Text.Trim)


            Dim SRNO As String = ""
            Dim YARNQUALITY As String = ""
            Dim OLDRATE As String = ""
            Dim OLDCOSTRATE As String = ""
            Dim RATE As String = ""
            Dim COSTRATE As String = ""


            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If YARNQUALITY = "" Then
                    SRNO = Val(ROW("SRNO"))
                    YARNQUALITY = ROW("YARNQUALITY")
                    OLDRATE = Val(ROW("OLDRATE"))
                    OLDCOSTRATE = Val(ROW("OLDCOSTRATE"))
                    RATE = Val(ROW("RATE"))
                    COSTRATE = Val(ROW("COSTRATE"))
                Else
                    SRNO = SRNO & "|" & Val(ROW("SRNO"))
                    YARNQUALITY = YARNQUALITY & "|" & ROW("YARNQUALITY")
                    OLDRATE = OLDRATE & "|" & Val(ROW("OLDRATE"))
                    OLDCOSTRATE = OLDCOSTRATE & "|" & Val(ROW("OLDCOSTRATE"))
                    RATE = RATE & "|" & Val(ROW("RATE"))
                    COSTRATE = COSTRATE & "|" & Val(ROW("COSTRATE"))
                End If

                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                'UPDATE IN YARNQUALITYMASTER
                DT = OBJCMN.Execute_Any_String("UPDATE YARNQUALITYMASTER SET YARN_RATE = " & Val(ROW("RATE")) & " WHERE YARN_ID = " & Val(ROW("YARNID")) & " AND YARN_YEARID = " & YearId, "", "")
                DT = OBJCMN.Execute_Any_String("UPDATE YARNQUALITYMASTER SET YARN_COSTRATE = " & Val(ROW("COSTRATE")) & " WHERE YARN_ID = " & Val(ROW("YARNID")) & " AND YARN_YEARID = " & YearId, "", "")

            Next

            alParaval.Add(SRNO)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(OLDRATE)
            alParaval.Add(OLDCOSTRATE)
            alParaval.Add(RATE)
            alParaval.Add(COSTRATE)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim OBJYARN As New ClsYarnQualityRate()
            OBJYARN.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJYARN.SAVE()
                TXTNO.Text = DTT.Rows(0).Item(0)
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPENTRYNO)
                Dim IntResult As Integer = OBJYARN.UPDATE()
                MsgBox("Details Updated")

            End If

            EDIT = False
            CLEAR()
            FILLGRID()
            gridbill.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

LINE1:
        For I As Integer = 0 To gridbill.RowCount - 1
            Dim ROW As DataRow = gridbill.GetDataRow(I)
            If Val(ROW("OLDRATE")) = Val(ROW("RATE")) And Val(ROW("OLDCOSTRATE")) = Val(ROW("COSTRATE")) Then
                Dim DV As DevExpress.XtraGrid.Views.Grid.GridView = gridbill
                DV.DeleteRow(I)
                DV.UpdateCurrentRow()
                GoTo LINE1
            End If
        Next
        GETSRNO()

        If gridbill.RowCount = 0 Then
            EP.SetError(YARNDATE, "No Rows to Save")
            bln = False
        End If


        If YARNDATE.Text = "__/__/____" Then
            EP.SetError(YARNDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(YARNDATE.Text) Then
                EP.SetError(YARNDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If
        Return bln

    End Function

    Sub CLEAR()
        EP.Clear()
        tstxtbillno.Clear()
        TXTNO.Clear()
        YARNDATE.Text = Now.Date
        txtremarks.Clear()
        GET_MAX_NO()
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If MsgBox("Wish to Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPENTRYNO)
                ALPARAVAL.Add(YearId)

                Dim OBJPRO As New ClsYarnQualityRate
                OBJPRO.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJPRO.DELETE
                MsgBox("Entry Deleted Sucessfully")

                CLEAR()
                EDIT = False
                FILLGRID()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YarnQualityRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YarnQualityRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            CLEAR()
            If EDIT = False Then FILLGRID()

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJYARN As New ClsYarnQualityRate()
                OBJYARN.alParaval.Add(TEMPENTRYNO)
                OBJYARN.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJYARN.SELECTRATE()

                If dttable.Rows.Count > 0 Then
                    TXTNO.Text = TEMPENTRYNO
                    YARNDATE.Text = Format(Convert.ToDateTime(dttable.Rows(0).Item("DATE")), "dd/MM/yyyy")
                    txtremarks.Text = Convert.ToString(dttable.Rows(0).Item("REMARKS").ToString)
                    gridbilldetails.DataSource = dttable
                    If dttable.Rows.Count > 0 Then
                        gridbill.FocusedRowHandle = gridbill.RowCount - 1
                        gridbill.TopRowIndex = gridbill.RowCount - 15
                    End If
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

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search(" 0 AS SRNO, YARN_ID AS YARNID, YARN_NAME AS YARNQUALITY, ISNULL(YARN_RATE, 0) AS OLDRATE, ISNULL(YARN_COSTRATE, 0) AS OLDCOSTRATE, ISNULL(YARN_RATE, 0) AS RATE, ISNULL(YARN_COSTRATE, 0) AS COSTRATE ", "", " YARNQUALITYMASTER ", " AND YARNQUALITYMASTER.YARN_YEARID = " & YearId & " ORDER BY YARNQUALITYMASTER.YARN_NAME")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
            GETSRNO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Sub GETSRNO()
        Try
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                ROW("SRNO") = I + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRIVIOUS.Click
        Try
            gridbilldetails.DataSource = Nothing
LINE1:
            TEMPENTRYNO = Val(TXTNO.Text) - 1
            If TEMPENTRYNO > 0 Then
                EDIT = True
                YarnQualityRate_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPENTRYNO > 1 Then
                TXTNO.Text = TEMPENTRYNO
                GoTo LINE1
            End If
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

            Dim OBJYARN As New YarnQualityRateDetails
            OBJYARN.MdiParent = MDIMain
            OBJYARN.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridbilldetails.DataSource = Nothing
LINE1:
            TEMPENTRYNO = Val(TXTNO.Text) + 1
            GET_MAX_NO()
            Dim MAXNO As Integer = TXTNO.Text.Trim
            CLEAR()
            If Val(TXTNO.Text) - 1 >= TEMPENTRYNO Then
                EDIT = True
                YarnQualityRate_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPENTRYNO < MAXNO Then
                TXTNO.Text = TEMPENTRYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        FILLGRID()
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridbilldetails.DataSource = Nothing
                TEMPENTRYNO = Val(tstxtbillno.Text)
                If TEMPENTRYNO > 0 Then
                    EDIT = True
                    YarnQualityRate_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class