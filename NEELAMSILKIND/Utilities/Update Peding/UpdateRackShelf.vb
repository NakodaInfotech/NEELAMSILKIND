
Imports System.ComponentModel
Imports BL

Public Class UpdateRackShelf

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateRackShelf_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT, if YES THEN GIVE A MESSAGE THAT BARCODE EXISTS
                    Dim DTROW As DataRow
                    For I As Integer = 0 To gridbill.RowCount - 1
                        DTROW = gridbill.GetDataRow(I)
                        If LCase(DTROW("BARCODE")) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next
                    Dim DTGRID As DataTable = gridbilldetails.DataSource
                    DTGRID.ImportRow(DT.Rows(0))
LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateRackShelf_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            'THIS CODE IS WRITTEN WRONG BY GULKIT
            'WE HAVE PASSED YEARID=0, DONT CHANGE THIS CODE
            'THIS IS DONE AS WE NEED DATASOURCE TO BE LINKED WITH GRID
            Dim objclsCMST As New ClsCommon
            Dim dt As DataTable = objclsCMST.Execute_Any_String(" SELECT * FROM BARCODESTOCK WHERE BARCODESTOCK.YEARID = 0 ", "", "")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Enter(sender As Object, e As EventArgs) Handles CMBRACK.Enter
        Try
            If CMBRACK.Text.Trim = "" Then FILLRACK(CMBRACK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Validating(sender As Object, e As CancelEventArgs) Handles CMBRACK.Validating
        Try
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Enter(sender As Object, e As EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(sender As Object, e As EventArgs) Handles CMDSAVE.Click
        Try
            If CMBRACK.Text.Trim = "" And CMBSHELF.Text.Trim = "" Then Exit Sub

            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If ROW Is Nothing Then Exit Sub
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                Dim RACKID As Integer = 0
                Dim SHELFID As Integer = 0

                If CMBRACK.Text.Trim <> "" Then
                    DT = OBJCMN.search("RACK_ID AS RACKID", "", "RACKMASTER", " AND RACK_NAME = '" & CMBRACK.Text.Trim & "' AND RACK_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then RACKID = DT.Rows(0).Item("RACKID")
                End If

                If CMBSHELF.Text.Trim <> "" Then
                    DT = OBJCMN.search("SHELF_ID AS SHELFID", "", "SHELFMASTER", " AND SHELF_NAME = '" & CMBSHELF.Text.Trim & "' AND SHELF_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then SHELFID = DT.Rows(0).Item("SHELFID")
                End If

                If ROW("TYPE") = "OPENING" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE STOCKMASTER SET SM_RACKID = " & RACKID & " , SM_SHELFID = " & SHELFID & " WHERE SM_BARCODE = '" & ROW("BARCODE") & "' AND SM_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "GRN" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE GRN_DESC SET GRN_RACKID = " & RACKID & " , GRN_SHELFID = " & SHELFID & " WHERE GRN_BARCODE = '" & ROW("BARCODE") & "' AND GRN_GRIDTYPE = 'FANCY MATERIAL' AND GRN_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "MATREC" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT_DESC SET MATREC_RACKID = " & RACKID & " , MATREC_SHELFID = " & SHELFID & " WHERE MATREC_BARCODE = '" & ROW("BARCODE") & "' AND MATREC_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "JOBIN" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN_DESC SET JI_RACKID = " & RACKID & " , JI_SHELFID = " & SHELFID & " WHERE JI_BARCODE = '" & ROW("BARCODE") & "' AND JI_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "PACKING" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE RECPACKING_DESC SET REC_RACKID = " & RACKID & " , REC_SHELFID = " & SHELFID & " WHERE REC_BARCODE = '" & ROW("BARCODE") & "' AND REC_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "SALERET" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE SALERETURN_DESC SET SALRET_RACKID = " & RACKID & " , SALRET_SHELFID = " & SHELFID & " WHERE SALRET_BARCODE = '" & ROW("BARCODE") & "' AND SALRET_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "STOCKADJUSTMENT" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE STOCKADJUSTMENT_INDESC SET SA_RACKID = " & RACKID & ", SA_SHELFID = " & SHELFID & " WHERE SA_BARCODE = '" & ROW("BARCODE") & "' AND SA_YEARID = " & YearId, "", "")
                End If

            Next
            MsgBox("Details Added")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridbill.RowCount > 0 Then
                Dim DT As DataTable = gridbilldetails.DataSource
                Dim ROW As DataRow = gridbill.GetFocusedDataRow
                DT.Rows.Remove(ROW)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class