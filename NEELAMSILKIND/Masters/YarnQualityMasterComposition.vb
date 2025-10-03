
Imports System.ComponentModel
Imports BL

Public Class YarnQualityMasterComposition

    Public EDIT As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempid As Integer            'Used for edit id

    Dim TEMPROW, TEMPSROW, TEMPSHADEROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDSTORESDOUBLECLICK, GRIDSHADEDOUBLECLICK As Boolean

    Sub clear()
        CMBQUALITY.Text = ""
        CMBQUALITY.Enabled = True
        TXTHSNCODE.Clear()
        TXTDENIER.Clear()
        TXTRATE.Clear()

        CMBYARNQUALITY.Text = ""
        TXTPER.Clear()
        GRIDCOMP.RowCount = 0
        TXTTOTALPER.Clear()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBQUALITY.Text.Trim.Length = 0 Then
            Ep.SetError(CMBQUALITY, "Fill Quality Name")
            bln = False
        End If

        If Val(TXTTOTALPER.Text.Trim) <> 100 And GRIDCOMP.RowCount > 0 Then
            Ep.SetError(TXTTOTALPER, "Check %")
            bln = False
        End If


        'THIS IS DONE BY GULKIT
        'IF THERE IS NO COMPOSITION THEN SAME ITEMNAME SHOULD BE PASSED IN THE GRID WITH 100%
        If GRIDCOMP.RowCount = 0 And CMBQUALITY.Text.Trim <> "" Then
            GRIDCOMP.Rows.Add(CMBQUALITY.Text.Trim, 100)
        End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Try
                Ep.Clear()
                If Not errorvalid() Then
                    Exit Sub
                End If

                Dim OBJYARN As New ClsYarnQualityMaster
                Dim YARNQUALITY As String = ""
                Dim PER As String = ""

                For Each ROW As DataGridViewRow In GRIDCOMP.Rows
                    If ROW.Cells(GYARNQUALITY.Index).Value <> Nothing Then
                        If YARNQUALITY = "" Then
                            YARNQUALITY = ROW.Cells(GYARNQUALITY.Index).Value.ToString
                            PER = Val(ROW.Cells(GPER.Index).Value)
                        Else
                            YARNQUALITY = YARNQUALITY & "|" & ROW.Cells(GYARNQUALITY.Index).Value.ToString
                            PER = PER & "|" & Val(ROW.Cells(GPER.Index).Value)
                        End If
                    End If
                Next

                OBJYARN.alParaval.Add(YARNQUALITY)
                OBJYARN.alParaval.Add(PER)
                OBJYARN.alParaval.Add(CmpId)
                OBJYARN.alParaval.Add(Userid)
                OBJYARN.alParaval.Add(YearId)
                OBJYARN.alParaval.Add(tempid)
                Dim INTRES As Integer = OBJYARN.SAVECOMPOSITION()
                MsgBox("Details Updated")
                clear()
                CMBQUALITY.Focus()

            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            fillYARNQUALITY(CMBYARNQUALITY, False)
            fillYARNQUALITY(CMBQUALITY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YarnQualityMasterComposition_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        CMBQUALITY.Focus()
    End Sub

    Sub total()
        Try
            TXTTOTALPER.Text = "0.00"
            For Each ROW As DataGridViewRow In GRIDCOMP.Rows
                TXTTOTALPER.Text = Format(Val(TXTTOTALPER.Text) + Val(ROW.Cells(GPER.Index).EditedFormattedValue), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPER_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPER.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
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

    Private Sub TXTPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPER.Validating
        Try
            If Val(TXTPER.Text.Trim) < 0 And Val(TXTPER.Text.Trim) > 100 Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPER.Validated
        Try
            If Val(TXTPER.Text.Trim) > 0 And CMBYARNQUALITY.Text.Trim <> "" Then
                If Not checkPERTYPE() Then
                    MsgBox("% already Present in Grid below")
                    Exit Sub
                End If

                fillgridCOMP()
                total()

                CMBYARNQUALITY.Text = ""
                TXTPER.Clear()
                CMBYARNQUALITY.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridCOMP()

        If GRIDDOUBLECLICK = False Then
            GRIDCOMP.Rows.Add(CMBYARNQUALITY.Text.Trim, Val(TXTPER.Text.Trim))
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDCOMP.Item("GYARNQUALITY", TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDCOMP.Item("GPER", TEMPROW).Value = Val(TXTPER.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        total()
        CMBYARNQUALITY.Text = ""
        TXTPER.Clear()

        GRIDCOMP.ClearSelection()

    End Sub

    Function checkPERTYPE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDCOMP.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If CMBYARNQUALITY.Text.Trim = row.Cells(GYARNQUALITY.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDCOMP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCOMP.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCOMP.Item("GYARNQUALITY", e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                CMBYARNQUALITY.Text = GRIDCOMP.Item("GYARNQUALITY", e.RowIndex).Value
                TXTPER.Text = GRIDCOMP.Item("GPER", e.RowIndex).Value
                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCOMP.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDCOMP.Rows.RemoveAt(GRIDCOMP.CurrentRow.Index)
        End If
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

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validated(sender As Object, e As EventArgs) Handles CMBQUALITY.Validated
        Try
            If CMBQUALITY.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(YARN_DENIER,0) AS DENIER, ISNULL(YARN_RATE,0) AS RATE, ISNULL(HSN_CODE,'') AS HSNCODE, YARN_ID AS YARNID", "", "YARNQUALITYMASTER INNER JOIN HSNMASTER ON YARN_HSNCODEID = HSN_ID", " AND YARN_NAME = '" & CMBQUALITY.Text.Trim & "' AND YARN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTDENIER.Text = DT.Rows(0).Item("DENIER")
                    TXTRATE.Text = DT.Rows(0).Item("RATE")
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    tempid = Val(DT.Rows(0).Item("YARNID"))

                    Dim dttable1 As DataTable = OBJCMN.search(" ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(YARNQUALITYMASTER_COMPOSITION.YARN_PER, 0) AS PER ", "", " YARNQUALITYMASTER INNER JOIN YARNQUALITYMASTER_COMPOSITION ON YARNQUALITYMASTER.YARN_ID = YARNQUALITYMASTER_COMPOSITION.YARN_YARNQUALITYID AND YARNQUALITYMASTER.YARN_YEARID = YARNQUALITYMASTER_COMPOSITION.YARN_YEARID  ", " AND YARNQUALITYMASTER_COMPOSITION.YARN_ID = " & tempid & " AND YARNQUALITYMASTER_COMPOSITION.YARN_YEARID = " & YearId)
                    If dttable1.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable1.Rows
                            GRIDCOMP.Rows.Add(DTR("YARNQUALITY"), DTR("PER"))
                        Next
                        total()
                    End If
                End If

                CMBQUALITY.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YarnQualityMasterComposition_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class