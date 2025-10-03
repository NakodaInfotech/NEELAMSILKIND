
Imports BL
Imports System.IO

Public Class Reprint

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            Dim WHOLESALEBARCODE As Integer = 0
            Dim TEMPHEADER As String = ""
            Dim SUPRIYAHEADER As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable


            For Each ROW As DataGridViewRow In GRIDREPRINT.Rows
                For I As Integer = 1 To Val(txtcopies.Text.Trim)
                    BARCODEPRINTING(ROW.Cells(GBARCODE.Index).Value, ROW.Cells(GPIECETYPE.Index).Value, ROW.Cells(GITEMNAME.Index).Value, ROW.Cells(GQUALITY.Index).Value, ROW.Cells(GDESIGN.Index).Value, ROW.Cells(GSHADE.Index).Value, ROW.Cells(GUNIT.Index).Value, ROW.Cells(GLOTNO.Index).Value, ROW.Cells(GBALENO.Index).Value, ROW.Cells(GPRINTDESC.Index).Value, Val(ROW.Cells(GMTRS.Index).Value), 1, ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE, ROW.Cells(GCHALLANNO.Index).Value, ROW.Cells(GNAME.Index).Value)
                Next
            Next
LINE1:
            clear()
            txtbarcode.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelprint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub clear()
        Try
            txtbarcode.Clear()
            txtcopies.Text = 1
            GRIDREPRINT.RowCount = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelprint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clear()
    End Sub

    Private Sub txtcopies_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcopies.KeyPress
        numkeypress(e, sender, Me)
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

    Private Sub txtbarcode_Validated(sender As Object, e As EventArgs) Handles txtbarcode.Validated
        Try
            If txtbarcode.Text.Trim = "" Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & txtbarcode.Text.Trim & "' AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                GRIDREPRINT.Rows.Add(0, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("GRIDREMARKS"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DT.Rows(0).Item("UNIT"), DT.Rows(0).Item("LOTNO"), Format((Val(DT.Rows(0).Item("CUT"))), "0.00"), Format((Val(DT.Rows(0).Item("MTRS"))), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("RACK"), DT.Rows(0).Item("BALENO"), "", Val(DT.Rows(0).Item("FROMNO")), Val(DT.Rows(0).Item("FROMSRNO")), DT.Rows(0).Item("TYPE"), DT.Rows(0).Item("CHALLANNO"), DT.Rows(0).Item("JOBBERNAME"))
            Else
                MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
            End If
            txtbarcode.Clear()
            txtbarcode.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(sender As Object, e As EventArgs) Handles CMDSELECTSTOCK.Click
        Try

            Dim DTGDN As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            OBJSELECTGDN.ShowDialog()
            DTGDN = OBJSELECTGDN.DT

            If DTGDN.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTGDN.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDREPRINT.Rows
                        If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Or (DTROWPS("BARCODE") = "" And Val(ROW.Cells(GFROMNO.Index).Value) = Val(DTROWPS("FROMNO")) And Val(ROW.Cells(GFROMSRNO.Index).Value) = Val(DTROWPS("FROMSRNO"))) Then GoTo LINE1
                    Next

                    Dim GRIDDESC As String = ""
                    GRIDREPRINT.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("GRIDREMARKS"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), DTROWPS("UNIT"), DTROWPS("LOTNO"), Format(Val(DTROWPS("CUT")), "0.00"), Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), DTROWPS("RACK"), DTROWPS("BALENO"), "", Val(DTROWPS("FROMNO")), Val(DTROWPS("FROMSRNO")), DTROWPS("TYPE"), DTROWPS("CHALLANNO"), DTROWPS("JOBBERNAME"))
LINE1:
                Next
                CMDSELECTSTOCK.Enabled = True
                getsrno(GRIDREPRINT)
                GRIDREPRINT.FirstDisplayedScrollingRowIndex = GRIDREPRINT.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class