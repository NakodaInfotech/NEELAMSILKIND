
Imports BL
Imports System.IO
Imports System.ComponentModel

Public Class DesignMaster

    Public EDIT As Boolean              'Used for edit
    Public tempdesignno As String           'Used for edit name
    Public tempid As Integer            'Used for edit id
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPPROW As Integer
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Sub CALC()
        Try
            TXTTOTAL.Text = Format(Val(TXTFABRIC.Text.Trim) + Val(TXTDYEING.Text.Trim) + Val(TXTJOBWORK.Text.Trim) + Val(TXTFINISHING.Text.Trim) + Val(TXTEXTRA.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("DESIGN_NO", "", " DESIGNMASTER ", " and DESIGN_cmpid = " & CmpId & " and DESIGN_locationid = " & Locationid & " and DESIGN_yearid = " & YearId)
        If DT.Rows.Count > 0 Then
            DT.DefaultView.Sort = "DESIGN_NO"
            CMBDESIGNNO.DataSource = DT
            CMBDESIGNNO.DisplayMember = "DESIGN_NO"
            CMBDESIGNNO.Text = tempdesignno
        End If
        FILLCOLOR(CMBCOLOR, "")
        fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' AND ISNULL(ITEMMASTER.ITEM_HIDEINDESIGN,0) = 0")
    End Sub

    Private Sub DesignMasterg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DESIGN MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            'clear()

            CMBDESIGNNO.Text = tempdesignno
            CMBITEM.Text = ""

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsJO As New ClsDesignMaster()
                Dim dttable As New DataTable

                dttable = objclsJO.selectdesign(tempdesignno, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows
                        tempdesignno = dr("design").ToString
                        tempid = dr("DESIGNID").ToString
                        CMBMILL.Text = dr("MILLNAME").ToString
                        TXTCADNO.Text = dr("CADNO")
                        TXTPURRATE.Text = Val(dr("PURRATE"))
                        TXTSALERATE.Text = Val(dr("SALERATE"))
                        TXTWRATE.Text = Val(dr("WRATE"))
                        TXTSELVEDGE.Text = dr("SELVEDGE").ToString
                        txtremarks.Text = dr("remarks").ToString
                        TXTPROCESSSTAMPING.Text = dr("PROCESSSTAMPING").ToString

                        TXTFABRIC.Text = Val(dr("FABRIC"))
                        TXTDYEING.Text = Val(dr("DYEING"))
                        TXTJOBWORK.Text = Val(dr("JOBWORK"))
                        TXTFINISHING.Text = Val(dr("FINISHING"))
                        TXTEXTRA.Text = Val(dr("EXTRA"))
                        TXTTOTAL.Text = Val(dr("TOTAL"))
                        CMBITEM.Text = dr("ITEMNAME").ToString
                        TXTCATEGORY.Text = dr("CATEGORY").ToString
                        TXTUNIT.Text = dr("UNIT").ToString
                        TXTHSNCODE.Text = dr("HSNCODE").ToString

                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                        CHKHIDEINCARD.Checked = Convert.ToBoolean(dttable.Rows(0).Item("HIDEINCARD"))

                        If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                            PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                            TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                        Else
                            PBPHOTO.Image = Nothing
                        End If
                    Next

                    'COLOR GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dt As DataTable = OBJCMN.search(" ISNULL(DESIGNMASTER_COLOR.DESIGN_SRNO, 0) AS GRIDSRNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR", "", " DESIGNMASTER_COLOR LEFT OUTER JOIN COLORMASTER ON DESIGNMASTER_COLOR.DESIGN_COLORID = COLORMASTER.COLOR_id ", " AND DESIGNMASTER_COLOR.DESIGN_ID = " & tempid & " AND DESIGNMASTER_COLOR.DESIGN_YEARID = " & YearId & " ORDER BY DESIGNMASTER_COLOR.DESIGN_SRNO")
                    If dt.Rows.Count > 0 Then
                        For Each DTR1 As DataRow In dt.Rows
                            GRIDSHADE.Rows.Add(DTR1("GRIDSRNO"), DTR1("COLOR"))
                        Next
                    End If
                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            Dim IntResult As Integer

            Dim alParaval As New ArrayList

            alParaval.Add(UCase(CMBDESIGNNO.Text.Trim))
            alParaval.Add(CMBMILL.Text.Trim)
            alParaval.Add(TXTCADNO.Text.Trim)
            alParaval.Add(Val(TXTPURRATE.Text.Trim))
            alParaval.Add(Val(TXTSALERATE.Text.Trim))
            alParaval.Add(Val(TXTWRATE.Text.Trim))
            alParaval.Add(TXTSELVEDGE.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTPROCESSSTAMPING.Text.Trim)

            alParaval.Add(Val(TXTFABRIC.Text.Trim))
            alParaval.Add(Val(TXTDYEING.Text.Trim))
            alParaval.Add(Val(TXTJOBWORK.Text.Trim))
            alParaval.Add(Val(TXTFINISHING.Text.Trim))
            alParaval.Add(Val(TXTEXTRA.Text.Trim))
            alParaval.Add(Val(TXTTOTAL.Text.Trim))
            alParaval.Add(CMBITEM.Text.Trim)
            alParaval.Add(CHKBLOCKED.CheckState)
            alParaval.Add(CHKHIDEINCARD.CheckState)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If


            Dim gridsrno As String = ""
            Dim COLOR As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSHADE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                    End If
                End If
            Next


            alParaval.Add(gridsrno)
            alParaval.Add(COLOR)


            Dim objDESIGN As New ClsDesignMaster
            objDESIGN.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objDESIGN.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempid)
                IntResult = objDESIGN.UPDATE()
                MsgBox("Details Updated")
            End If
            EDIT = False

            CLEAR()
            EDIT = False
            CMBDESIGNNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            CMBDESIGNNO.Text = ""
            TXTCADNO.Clear()
            TXTPURRATE.Clear()
            TXTSALERATE.Clear()
            TXTWRATE.Clear()
            CMBMILL.Text = ""
            TXTPHOTOIMGPATH.Clear()
            PBPHOTO.Image = Nothing

            TXTSELVEDGE.Clear()
            txtremarks.Clear()
            TXTPROCESSSTAMPING.Clear()

            TXTFABRIC.Clear()
            TXTDYEING.Clear()
            TXTJOBWORK.Clear()
            TXTFINISHING.Clear()
            TXTEXTRA.Clear()
            TXTTOTAL.Clear()

            CMBITEM.Text = ""
            TXTCATEGORY.Clear()
            TXTUNIT.Clear()
            TXTHSNCODE.Clear()
            CHKBLOCKED.CheckState = CheckState.Unchecked
            CHKHIDEINCARD.CheckState = CheckState.Unchecked

            TXTSRNO.Clear()
            CMBCOLOR.Text = ""
            GRIDSHADE.RowCount = 0
            tempdesignno = ""
            tempid = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignMasterg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
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

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If CMBDESIGNNO.Text.Trim <> "" Then
                pcase(CMBDESIGNNO)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(CMBDESIGNNO.Text) <> LCase(tempdesignno)) Then
                    dt = objclscommon.search("DESIGN_NO", "", " DESIGNMASTER ", " And DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " AND DESIGN_LOCATIONID = " & Locationid & " AND DESIGN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Design Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                        BLN = False
                    End If
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean

        Dim bln As Boolean = True

        If CMBDESIGNNO.Text.Trim.Length = 0 Then
            Ep.SetError(CMBDESIGNNO, "Fill Design No")
            bln = False
        End If

        If CMBITEM.Text.Trim = "" Then
            Ep.SetError(CMBITEM, "Fill Item Name")
            bln = False
        End If

        If Not CHECKDUPLICATE() Then
            Ep.SetError(CMBDESIGNNO, "Design Already Exists")
            bln = False
        End If

        Return bln
    End Function

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGNNO.Enter
        Try
            If CMBDESIGNNO.Text.Trim = "" Then
                'FILLCMB()
                CMBDESIGNNO.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then
                uppercase(CMBDESIGNNO)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(CMBDESIGNNO.Text) <> LCase(tempdesignno)) Then
                    dt = objclscommon.search("DESIGN_NO", "", " DESIGNMASTER ", " AND DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " AND DESIGN_LOCATIONID = " & Locationid & " AND DESIGN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Design Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDPHOTOUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTPHOTOIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTPHOTOIMGPATH.Text.Trim.Length <> 0 Then PBPHOTO.ImageLocation = TXTPHOTOIMGPATH.Text.Trim
    End Sub

    Private Sub CMDPHOTOREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOREMOVE.Click
        Try
            PBPHOTO.Image = Nothing
            TXTPHOTOIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPHOTOVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOVIEW.Click
        Try
            If TXTPHOTOIMGPATH.Text.Trim <> "" Then
                If Path.GetExtension(TXTPHOTOIMGPATH.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(TXTPHOTOIMGPATH.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBPHOTO.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURRATE.KeyPress, TXTWRATE.KeyPress, TXTSALERATE.KeyPress, TXTFABRIC.KeyPress, TXTDYEING.KeyPress, TXTJOBWORK.KeyPress, TXTFINISHING.KeyPress, TXTEXTRA.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTFABRIC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTFABRIC.Validated, TXTDYEING.Validated, TXTJOBWORK.Validated, TXTFINISHING.Validated, TXTEXTRA.Validated
        CALC()
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'  AND ISNULL(ITEMMASTER.ITEM_HIDEINDESIGN,0) = 0")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEM.Validating
        Try
            If CMBITEM.Text.Trim <> "" Then itemvalidate(CMBITEM, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' ", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDSHADE.Rows.Add(Val(TXTSRNO.Text.Trim), CMBCOLOR.Text.Trim)
            getsrno(GRIDSHADE)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSHADE.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDSHADE.Item(GCOLOR.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            TEMPPROW = GRIDSHADE.CurrentRow.Index
            TXTSRNO.Focus()
            GRIDDOUBLECLICK = False
        End If
        CMBCOLOR.Text = ""
        GRIDSHADE.ClearSelection()
        CMBCOLOR.Focus()
    End Sub

    Private Sub CMBCOLOR_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Validated
        If CMBCOLOR.Text.Trim <> "" Then
            If Not CHECKCOLO() Then
                MsgBox("Color already Present in Grid below")
                Exit Sub
            End If
            fillgrid()
        End If
    End Sub

    Function CHECKCOLO() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDSHADE.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If CMBCOLOR.Text.Trim = row.Cells(GCOLOR.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDPROCESS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSHADE.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDSHADE.Item("GCOLOR", e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                TXTSRNO.Text = Val(GRIDSHADE.Item("GSRNO", e.RowIndex).Value)
                CMBCOLOR.Text = GRIDSHADE.Item("GCOLOR", e.RowIndex).Value
                CMBCOLOR.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROCESS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSHADE.KeyDown
        If e.KeyCode = Keys.Delete And GRIDSHADE.RowCount > 0 Then
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            GRIDSHADE.Rows.RemoveAt(GRIDSHADE.CurrentRow.Index)
            getsrno(GRIDSHADE)

            'ElseIf e.KeyCode = Keys.F5 Then
            '    EDITROW()
        End If

    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If EDIT = True Then

                Dim objcls As New ClsDesignMaster()
                If MsgBox("Wish To Delete?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(tempid)
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(YearId)
                objcls.alParaval = alParaval
                Dim DT As DataTable = objcls.Delete()
                MsgBox(DT.Rows(0).Item(0))
                CLEAR()
                EDIT = False

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Enter(sender As Object, e As EventArgs) Handles CMBMILL.Enter
        Try
            If CMBMILL.Text.Trim = "" Then FILLMILL(CMBMILL, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Validating(sender As Object, e As CancelEventArgs) Handles CMBMILL.Validating
        Try
            If CMBMILL.Text.Trim <> "" Then MILLVALIDATE(CMBMILL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validated(sender As Object, e As EventArgs) Handles CMBITEM.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE", "", " ITEMMASTER LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEMMASTER.ITEM_NAME = '" & CMBITEM.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                TXTCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
                TXTUNIT.Text = DT.Rows(0).Item("UNIT")
                TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPROCESSSTAMPING_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPROCESSSTAMPING.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTPROCESSSTAMPING.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class