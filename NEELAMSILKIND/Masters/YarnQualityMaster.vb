

Imports System.ComponentModel
Imports BL

Public Class YarnQualityMaster

    Public EDIT As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempid As Integer            'Used for edit id

    Dim TEMPROW, TEMPSROW, TEMPSHADEROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDSTORESDOUBLECLICK, GRIDSHADEDOUBLECLICK As Boolean

    Sub clear()
        txtname.Clear()
        CMBCATEGORY.Text = ""

        txtremarks.Clear()
        txtname.Focus()
        CMBYARNQUALITY.Text = ""
        TXTPER.Clear()
        TXTBOXWT.Clear()
        TXTHSNCODE.Clear()
        TXTDENIER.Clear()
        TXTRATE.Clear()
        TXTCOSTRATE.Clear()

        TXTSSRNO.Clear()
        CMBSTOREITEM.Text = ""
        TXTSTOREQTY.Clear()

        TXTSRNO.Clear()
        CMBCOLOR.Text = ""
        CMBCOLORTYPE.Text = ""
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        'clearing grid
        GRIDSHADE.RowCount = 0
        GRIDCOMP.RowCount = 0
        GRIDSTORES.RowCount = 0
        TXTTOTALPER.Clear()

    End Sub

    Sub FILLSHADEGRID()

        If GRIDSHADEDOUBLECLICK = False Then
            GRIDSHADE.Rows.Add(Val(TXTSRNO.Text.Trim), CMBCOLOR.Text.Trim, CMBCOLORTYPE.Text.Trim, PBSOFTCOPY.Image)
            getsrno(GRIDSHADE)
        ElseIf GRIDSHADEDOUBLECLICK = True Then
            GRIDSHADE.Item(GSRNO.Index, TEMPSHADEROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDSHADE.Item(GCOLOR.Index, TEMPSHADEROW).Value = CMBCOLOR.Text.Trim
            GRIDSHADE.Item(GCOLORTYPE.Index, TEMPSHADEROW).Value = CMBCOLORTYPE.Text.Trim
            GRIDSHADE.Item(GIMGPATH.Index, TEMPSHADEROW).Value = PBSOFTCOPY.Image
            TEMPSHADEROW = GRIDSHADE.CurrentRow.Index
            TXTSRNO.Focus()
            GRIDSHADEDOUBLECLICK = False
        End If
        CMBCOLOR.Text = ""
        CMBCOLORTYPE.Text = ""
        PBSOFTCOPY.Image = Nothing
        GRIDSHADE.ClearSelection()
        CMBCOLOR.Focus()
    End Sub

    Private Sub CMDUPLOAD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMDUPLOAD.Validating
        CMBCOLORTYPE.Focus()
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
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If

        If Val(TXTTOTALPER.Text.Trim) <> 100 And GRIDCOMP.RowCount > 0 Then
            Ep.SetError(TXTTOTALPER, "Check %")
            bln = False
        End If

        If Val(TXTDENIER.Text.Trim) = 0 Then
            Ep.SetError(TXTDENIER, "Fill Denier")
            bln = False
        End If


        'THIS IS DONE BY GULKIT
        'IF THERE IS NO COMPOSITION THEN SAME ITEMNAME SHOULD BE PASSED IN THE GRID WITH 100%
        If GRIDCOMP.RowCount = 0 And txtname.Text.Trim <> "" Then
            GRIDCOMP.Rows.Add(txtname.Text.Trim, 100)
        End If

        Return bln
    End Function

    Private Sub citymaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TXTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If txtname.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(tempname) <> LCase(txtname.Text.Trim)) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("YARN_ID AS ID", "", "YARNQUALITYMASTER", " AND YARN_NAME = '" & txtname.Text.Trim & "' AND YARN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Yarn Quality Name Already Exists", MsgBoxStyle.Critical)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Try
                Ep.Clear()
                If Not errorvalid() Then
                    Exit Sub
                End If

                Dim OBJYARN As New ClsYarnQualityMaster
                OBJYARN.alParaval.Add(UCase(txtname.Text.Trim))
                OBJYARN.alParaval.Add(CMBCATEGORY.Text.Trim)
                OBJYARN.alParaval.Add(txtremarks.Text.Trim)
                OBJYARN.alParaval.Add(Val(TXTBOXWT.Text.Trim))
                OBJYARN.alParaval.Add(TXTHSNCODE.Text.Trim)
                OBJYARN.alParaval.Add(Val(TXTDENIER.Text.Trim))
                OBJYARN.alParaval.Add(Val(TXTRATE.Text.Trim))
                OBJYARN.alParaval.Add(Val(TXTCOSTRATE.Text.Trim))

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


                Dim STORESRNO As String = ""
                Dim STOREITEMNAME As String = ""
                Dim STOREQTY As String = ""

                For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSTORES.Rows
                    If row.Cells(0).Value <> Nothing Then
                        If STORESRNO = "" Then
                            STORESRNO = row.Cells(SSRNO.Index).Value.ToString
                            STOREITEMNAME = row.Cells(SSTOREITEM.Index).Value.ToString
                            STOREQTY = Val(row.Cells(SQTY.Index).Value)
                        Else
                            STORESRNO = STORESRNO & "|" & row.Cells(SSRNO.Index).Value.ToString
                            STOREITEMNAME = STOREITEMNAME & "|" & row.Cells(SSTOREITEM.Index).Value.ToString
                            STOREQTY = STOREQTY & "|" & Val(row.Cells(SQTY.Index).Value)
                        End If
                    End If
                Next

                OBJYARN.alParaval.Add(STORESRNO)
                OBJYARN.alParaval.Add(STOREITEMNAME)
                OBJYARN.alParaval.Add(STOREQTY)

                OBJYARN.alParaval.Add(CmpId)
                OBJYARN.alParaval.Add(Userid)
                OBJYARN.alParaval.Add(YearId)


                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    Dim INTRES As Integer = OBJYARN.SAVE()
                    MsgBox("Details Added")
                Else

                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    OBJYARN.alParaval.Add(tempid)
                    Dim INTRES As Integer = OBJYARN.UPDATE()
                    MsgBox("Details Updated")
                    EDIT = False
                End If
                If GRIDSHADE.RowCount > 0 Then SAVESHADE()
                clear()
                txtname.Focus()

            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVESHADE()
        Try
            'GRID ITINERARY
            Dim OBJYARN As New ClsYarnQualityMaster
            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSHADE.Rows
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(txtname.Text.Trim)
                    ALPARAVAL.Add(row.Cells(GSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GCOLOR.Index).Value)
                    ALPARAVAL.Add(row.Cells(GCOLORTYPE.Index).Value)

                    If row.Cells(GIMGPATH.Index).Value IsNot Nothing Then
                        Dim MS As New IO.MemoryStream
                        PBSOFTCOPY.Image = row.Cells(GIMGPATH.Index).Value
                        PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                        ALPARAVAL.Add(MS.ToArray)
                    Else
                        ALPARAVAL.Add(DBNull.Value)
                    End If

                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Userid)
                    ALPARAVAL.Add(YearId)

                    OBJYARN.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJYARN.SAVESHADE()
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            fillYARNQUALITY(CMBYARNQUALITY, False)
            fillCATEGORY(CMBCATEGORY, False)
            FILLSTOREITEMNAME(CMBSTOREITEM)
            FILLCOLOR(CMBCOLOR, "")
            FILLCOLORTYPE(CMBCOLORTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MillMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            txtname.Text = tempname

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJYARN As New ClsYarnQualityMaster
                OBJYARN.alParaval.Add(tempid)
                OBJYARN.alParaval.Add(YearId)
                Dim DT As DataTable = OBJYARN.GETYARN()
                If DT.Rows.Count > 0 Then
                    txtname.Text = DT.Rows(0).Item("NAME")
                    tempname = DT.Rows(0).Item("NAME")
                    CMBCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
                    txtremarks.Text = DT.Rows(0).Item("REMARKS")
                    TXTBOXWT.Text = Val(DT.Rows(0).Item("BOXWT"))
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    TXTDENIER.Text = Val(DT.Rows(0).Item("DENIER"))
                    TXTRATE.Text = Val(DT.Rows(0).Item("RATE"))
                    TXTCOSTRATE.Text = Val(DT.Rows(0).Item("COSTRATE"))

                    'COMPOSITION GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dttable1 As DataTable = OBJCMN.search(" ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(YARNQUALITYMASTER_COMPOSITION.YARN_PER, 0) AS PER ", "", " YARNQUALITYMASTER INNER JOIN YARNQUALITYMASTER_COMPOSITION ON YARNQUALITYMASTER.YARN_ID = YARNQUALITYMASTER_COMPOSITION.YARN_YARNQUALITYID AND YARNQUALITYMASTER.YARN_YEARID = YARNQUALITYMASTER_COMPOSITION.YARN_YEARID  ", " AND YARNQUALITYMASTER_COMPOSITION.YARN_ID = " & tempid & " AND YARNQUALITYMASTER_COMPOSITION.YARN_YEARID = " & YearId)
                    If dttable1.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable1.Rows
                            GRIDCOMP.Rows.Add(DTR("YARNQUALITY"), DTR("PER"))
                        Next

                        total()
                    End If


                    'STORES GRID
                    DT = OBJCMN.search(" ISNULL(YARNQUALITYMASTER_STORES.YARN_SRNO, 0) AS GRIDSRNO, ISNULL(STOREITEMMASTER.STOREITEM_NAME, '') AS STOREITEM, ISNULL(YARNQUALITYMASTER_STORES.YARN_QTY, 0) AS STOREQTY", "", "  STOREITEMMASTER INNER JOIN YARNQUALITYMASTER_STORES ON STOREITEMMASTER.STOREITEM_ID = YARNQUALITYMASTER_STORES.YARN_STOREITEMID ", " AND YARNQUALITYMASTER_STORES.YARN_ID = " & tempid & " AND YARNQUALITYMASTER_STORES.YARN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR1 As DataRow In DT.Rows
                            GRIDSTORES.Rows.Add(DTR1("GRIDSRNO"), DTR1("STOREITEM"), Val(DTR1("STOREQTY")))
                        Next
                    End If


                    'COLOR GRID
                    DT = OBJCMN.search(" ISNULL(YARNQUALITYMASTER_COLOR.YARN_SRNO, 0) AS GRIDSRNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(COLORTYPEMASTER.COLORTYPE_NAME,'') AS COLORTYPE, YARNQUALITYMASTER_COLOR.YARN_PHOTO AS PHOTO", "", " YARNQUALITYMASTER_COLOR INNER JOIN COLORMASTER ON YARNQUALITYMASTER_COLOR.YARN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN COLORTYPEMASTER ON YARN_COLORTYPEID = COLORTYPE_ID", " AND YARNQUALITYMASTER_COLOR.YARN_ID = " & tempid & " AND YARNQUALITYMASTER_COLOR.YARN_YEARID = " & YearId & " ORDER BY YARNQUALITYMASTER_COLOR.YARN_SRNO")
                    If dt.Rows.Count > 0 Then
                        For Each DTR1 As DataRow In DT.Rows
                            If IsDBNull(DTR1("PHOTO")) = False Then GRIDSHADE.Rows.Add(DTR1("GRIDSRNO"), DTR1("COLOR"), DTR1("COLORTYPE"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR1("PHOTO"), Byte())))) Else GRIDSHADE.Rows.Add(DTR1("GRIDSRNO"), DTR1("COLOR"), DTR1("COLORTYPE"), Nothing)
                        Next
                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
    End Sub

    Private Sub cmddelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If EDIT = True Then
                Dim OBJSHELF As New ClsYarnQualityMaster
                OBJSHELF.alParaval.Add(tempid)
                OBJSHELF.alParaval.Add(YearId)

                Dim intResult As Integer = OBJSHELF.DELETE
                MsgBox("Yarn Quality Deleted Successfully")
                clear()
                EDIT = False
                txtname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub TXTPER_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPER.KeyPress, TXTDENIER.KeyPress, TXTRATE.KeyPress, TXTBOXWT.KeyPress, TXTCOSTRATE.KeyPress
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

    Private Sub YarnQualityMaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "VAISHALI" Then
                CMBCATEGORY.BackColor = Color.LemonChiffon
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTOREITEM_Enter(sender As Object, e As EventArgs) Handles CMBSTOREITEM.Enter
        Try
            If CMBSTOREITEM.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEM)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTOREITEM_Validating(sender As Object, e As CancelEventArgs) Handles CMBSTOREITEM.Validating
        Try
            If CMBSTOREITEM.Text.Trim <> "" Then STOREITEMVALIDATE(CMBSTOREITEM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
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

    Sub FILLSTORESGRID()

        If GRIDSTORESDOUBLECLICK = False Then
            GRIDSTORES.Rows.Add(Val(TXTSSRNO.Text.Trim), CMBSTOREITEM.Text.Trim, Val(TXTSTOREQTY.Text.Trim))
            getsrno(GRIDSTORES)
        ElseIf GRIDSTORESDOUBLECLICK = True Then
            GRIDSTORES.Item(SSRNO.Index, TEMPSROW).Value = Val(TXTSSRNO.Text.Trim)
            GRIDSTORES.Item(SSTOREITEM.Index, TEMPSROW).Value = CMBSTOREITEM.Text.Trim
            GRIDSTORES.Item(SQTY.Index, TEMPSROW).Value = Val(TXTSTOREQTY.Text.Trim)
            TEMPSROW = GRIDSTORES.CurrentRow.Index
            TXTSSRNO.Focus()
            GRIDSTORESDOUBLECLICK = False
        End If
        CMBSTOREITEM.Text = ""
        TXTSTOREQTY.Clear()
        GRIDSTORES.ClearSelection()

    End Sub

    Private Sub TXTSSRNO_GotFocus(sender As Object, e As EventArgs) Handles TXTSSRNO.GotFocus
        TXTSSRNO.Text = Val(GRIDSTORES.RowCount + 1)
    End Sub

    Private Sub GRIDSTORES_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSTORES.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDSTORES.Item(SSTOREITEM.Index, e.RowIndex).Value <> Nothing Then
                GRIDSTORESDOUBLECLICK = True
                TEMPSROW = e.RowIndex
                TXTSSRNO.Text = Val(GRIDSTORES.Item(SSRNO.Index, e.RowIndex).Value)
                CMBSTOREITEM.Text = GRIDSTORES.Item(SSTOREITEM.Index, e.RowIndex).Value
                TXTSTOREQTY.Text = Val(GRIDSTORES.Item(SQTY.Index, e.RowIndex).Value)
                CMBSTOREITEM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSTORES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTORES.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDSTORES.Rows.RemoveAt(GRIDSTORES.CurrentRow.Index)
            getsrno(GRIDSTORES)
        End If
    End Sub

    Private Sub TXTSTOREQTY_Validated(sender As Object, e As EventArgs) Handles TXTSTOREQTY.Validated
        Try
            If CMBSTOREITEM.Text.Trim <> "" And Val(TXTSTOREQTY.Text.Trim) > 0 Then
                FILLSTORESGRID()
            Else
                If CMBSTOREITEM.Text.Trim = "" Then
                    MsgBox("Enter Store Item Name....", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, EDIT)
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

    Private Sub TXTHSNCODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTHSNCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()

                If OBJLEDGER.TEMPCODE <> "" Then TXTHSNCODE.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Enter(sender As Object, e As EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validating(sender As Object, e As CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSHADE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSHADE.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDSHADE.Item("GCOLOR", e.RowIndex).Value <> Nothing Then
                GRIDSHADEDOUBLECLICK = True
                TEMPSHADEROW = e.RowIndex
                TXTSRNO.Text = Val(GRIDSHADE.Item(GSRNO.Index, e.RowIndex).Value)
                CMBCOLOR.Text = GRIDSHADE.Item(GCOLOR.Index, e.RowIndex).Value
                CMBCOLORTYPE.Text = GRIDSHADE.Item(GCOLORTYPE.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = GRIDSHADE.Item(GIMGPATH.Index, e.RowIndex).Value
                CMBCOLOR.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validated(sender As Object, e As EventArgs) Handles CMBCOLOR.Validated
        CMDUPLOAD.Focus()
    End Sub

    Function CHECKCOLO() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDSHADE.Rows
                If (GRIDSHADEDOUBLECLICK = True And TEMPSHADEROW <> row.Index) Or GRIDSHADEDOUBLECLICK = False Then
                    If CMBCOLOR.Text.Trim = row.Cells(GCOLOR.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDSHADE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDSHADE.KeyDown
        If e.KeyCode = Keys.Delete And GRIDSHADE.RowCount > 0 Then
            If GRIDSHADEDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If
            GRIDSHADE.Rows.RemoveAt(GRIDSHADE.CurrentRow.Index)
            getsrno(GRIDSHADE)
        End If
    End Sub

    Private Sub CMBCOLORTYPE_Validated(sender As Object, e As EventArgs) Handles CMBCOLORTYPE.Validated
        If CMBCOLOR.Text.Trim <> "" And CMBCOLORTYPE.Text.Trim <> "" Then
            If Not CHECKCOLO() Then
                MsgBox("Color already Present in Grid below")
                Exit Sub
            End If
            FILLSHADEGRID()
        End If
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If GRIDSHADE.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLORTYPE_Enter(sender As Object, e As EventArgs) Handles CMBCOLORTYPE.Enter
        Try
            If CMBCOLORTYPE.Text.Trim = "" Then FILLCOLORTYPE(CMBCOLORTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLORTYPE_Validating(sender As Object, e As CancelEventArgs) Handles CMBCOLORTYPE.Validating
        Try
            If CMBCOLORTYPE.Text.Trim <> "" Then COLORTYPEVALIDATE(CMBCOLORTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSHADE_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSHADE.CellClick
        Try
            PBSOFTCOPY.Image = GRIDSHADE.CurrentRow.Cells(GIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class