
Imports System.ComponentModel
Imports BL

Public Class DesignCardMaster

    Public EDIT As Boolean              'Used for edit
    Public TEMPCARDID As Integer            'Used for edit id
    Dim GRIDDOUBLECLICK, GRIDWARPDOUBLECLICK, GRIDWEFTDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPWARPROW, TEMPWEFTROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Sub TOTAL()
        Try
            TXTTOTALWT.Clear()
            TXTTOTALSELENDS.Clear()
            TXTTOTALSELWT.Clear()
            TXTTOTALWARPENDS.Clear()
            TXTTOTALWARPWT.Clear()
            TXTTOTALSELWARPENDS.Clear()
            TXTTOTALSELWARPWT.Clear()
            TXTTOTALWEFTPICK.Clear()
            TXTTOTALWEFTWT.Clear()


            For Each ROW As DataGridViewRow In GRIDSELVEDGE.Rows
                TXTTOTALSELENDS.Text = Format(Val(TXTTOTALSELENDS.Text.Trim) + Val(ROW.Cells(SENDS.Index).Value), "0")
                TXTTOTALSELWT.Text = Format(Val(TXTTOTALSELWT.Text.Trim) + Val(ROW.Cells(SWT.Index).Value), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDWARP.Rows
                TXTTOTALWARPENDS.Text = Format(Val(TXTTOTALWARPENDS.Text.Trim) + Val(ROW.Cells(WENDS.Index).Value), "0")
                TXTTOTALWARPWT.Text = Format(Val(TXTTOTALWARPWT.Text.Trim) + Val(ROW.Cells(WWT.Index).Value), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDWEFT.Rows
                TXTTOTALWEFTPICK.Text = Format(Val(TXTTOTALWEFTPICK.Text.Trim) + Val(ROW.Cells(FPICK.Index).Value), "0.00")
                TXTTOTALWEFTWT.Text = Format(Val(TXTTOTALWEFTWT.Text.Trim) + Val(ROW.Cells(FWT.Index).Value), "0.00")
            Next

            TXTTOTALSELWARPENDS.Text = Format(Val(TXTTOTALSELENDS.Text.Trim) + Val(TXTTOTALWARPENDS.Text.Trim), "0")
            TXTTOTALSELWARPWT.Text = Format(Val(TXTTOTALSELWT.Text.Trim) + Val(TXTTOTALWARPWT.Text.Trim), "0.00")
            TXTTOTALWT.Text = Format(Val(TXTTOTALSELWT.Text.Trim) + Val(TXTTOTALWARPWT.Text.Trim) + Val(TXTTOTALWEFTWT.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        FILLDESIGN(CMBDESIGNNO, "", " AND DESIGNMASTER.DESIGN_HIDEINCARD = 'FALSE'")
        FILLDESIGN(CMBCOPYDESIGN, "", " AND DESIGNMASTER.DESIGN_HIDEINCARD = 'FALSE'")
        FILLCOLOR(CMBMATCHING, CMBDESIGNNO.Text.Trim)
        FILLCOLOR(CMBCOPYMATCHING, CMBDESIGNNO.Text.Trim)
        fillYARNQUALITY(CMBSELQUALITY, EDIT)
        fillYARNQUALITY(CMBWARPQUALITY, EDIT)
        fillYARNQUALITY(CMBWEFTQUALITY, EDIT)
        FILLYARNCOLOR(CMBSELSHADE, CMBSELQUALITY.Text.Trim)
        FILLYARNCOLOR(CMBWARPSHADE, CMBWARPQUALITY.Text.Trim)
        FILLYARNCOLOR(CMBWEFTSHADE, CMBWEFTQUALITY.Text.Trim)
    End Sub

    Private Sub DesignCardMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            If EDIT = True Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DESIGNCARD.DESIGNCARD_ID AS CARDID, DESIGNMASTER.DESIGN_NO AS DESIGNNO, ITEMMASTER.ITEM_NAME AS ITEMNAME, CATEGORYMASTER.CATEGORY_NAME AS CATEGORY, COLORMASTER.COLOR_name AS MATCHING, DESIGNCARD.DESIGNCARD_WARPTL AS WARPTL, DESIGNCARD.DESIGNCARD_WEFTTL AS WEFTTL, DESIGNCARD.DESIGNCARD_REED AS REED, DESIGNCARD.DESIGNCARD_REEDSPACE AS REEDSPACE, DESIGNCARD.DESIGNCARD_PICKS AS PICKS, DESIGNCARD.DESIGNCARD_TOTALWT AS TOTALWT, DESIGNCARD.DESIGNCARD_TOTALSELENDS AS TOTALSELENDS, DESIGNCARD.DESIGNCARD_TOTALSELWT AS TOTALSELWT, DESIGNCARD.DESIGNCARD_TOTALWARPENDS AS TOTALWARPENDS, DESIGNCARD.DESIGNCARD_TOTALWARPWT AS TOTALWARPWT, DESIGNCARD.DESIGNCARD_TOTALWEFTPICKS AS TOTALWEFTPICK, DESIGNCARD.DESIGNCARD_TOTALWEFTWT AS TOTALWEFTWT ", "", " DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN COLORMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = COLORMASTER.COLOR_id INNER JOIN ITEMMASTER ON DESIGNMASTER.DESIGN_ITEMID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = CATEGORYMASTER.CATEGORY_ID ", " AND DESIGNCARD.DESIGNCARD_ID = " & Val(TEMPCARDID) & " AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    CMBDESIGNNO.Text = DT.Rows(0).Item("DESIGNNO")
                    CMBDESIGNNO.Enabled = False
                    CMBDESIGNNO_Validated(sender, e)

                    CMBMATCHING.Text = DT.Rows(0).Item("MATCHING")
                    CMBMATCHING.Enabled = False
                    TXTWARPTL.Text = Val(DT.Rows(0).Item("WARPTL"))
                    TXTWEFTTL.Text = Val(DT.Rows(0).Item("WEFTTL"))
                    TXTREED.Text = DT.Rows(0).Item("REED")
                    TXTREEDSPACE.Text = Val(DT.Rows(0).Item("REEDSPACE"))
                    TXTPICKS.Text = Val(DT.Rows(0).Item("PICKS"))
                End If


                'SELVEDGE GRID
                DT = OBJCMN.search(" DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELENDS AS ENDS, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT AS WT ", "", " DESIGNCARD_SELVEDGEDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID = " & Val(TEMPCARDID) & " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        TXTSELDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                        PBSELPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                        GRIDSELVEDGE.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTSELDENIER.Text.Trim), Val(ROW("ENDS")), Val(ROW("WT")), PBSELPHOTO.Image)
                        TXTSELDENIER.Clear()
                        PBSELPHOTO.Image = Nothing
                    Next
                End If


                'WARPGRID
                DT = OBJCMN.search(" DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPENDS AS ENDS, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT AS WT ", "", " DESIGNCARD_WARPDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_ID = " & Val(TEMPCARDID) & " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        TXTWARPDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                        PBWARPPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                        GRIDWARP.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTWARPDENIER.Text.Trim), Val(ROW("ENDS")), Val(ROW("WT")), PBWARPPHOTO.Image)
                        TXTWARPDENIER.Clear()
                        PBWARPPHOTO.Image = Nothing
                    Next
                End If


                'WEFT
                DT = OBJCMN.search(" DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTPICK AS PICK, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT AS WT ", "", " DESIGNCARD_WEFTDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID = " & Val(TEMPCARDID) & " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        TXTWEFTDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                        PBWEFTPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                        GRIDWEFT.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTWEFTDENIER.Text.Trim), Val(ROW("PICK")), Val(ROW("WT")), PBWEFTPHOTO.Image)
                        TXTWEFTDENIER.Clear()
                        PBWEFTPHOTO.Image = Nothing
                    Next
                End If

                TOTAL()
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
            If Not ERRORVALID() Then
                Exit Sub
            End If
            Dim IntResult As Integer

            Dim alParaval As New ArrayList

            alParaval.Add(UCase(CMBDESIGNNO.Text.Trim))
            alParaval.Add(UCase(CMBMATCHING.Text.Trim))
            alParaval.Add(Val(TXTWARPTL.Text.Trim))
            alParaval.Add(Val(TXTWEFTTL.Text.Trim))
            alParaval.Add(TXTREED.Text.Trim)
            alParaval.Add(Val(TXTREEDSPACE.Text.Trim))
            alParaval.Add(Val(TXTPICKS.Text.Trim))
            alParaval.Add(Val(TXTTOTALWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALSELENDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALSELWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALWARPENDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALWARPWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALWEFTPICK.Text.Trim))
            alParaval.Add(Val(TXTTOTALWEFTWT.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)



            Dim SELSRNO As String = ""
            Dim SELQUALITY As String = ""
            Dim SELSHADE As String = ""
            Dim SELENDS As String = ""
            Dim SELWT As String = ""

            For Each row As System.Windows.Forms.DataGridViewRow In GRIDSELVEDGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If SELSRNO = "" Then
                        SELSRNO = Val(row.Cells(SSRNO.Index).Value)
                        SELQUALITY = row.Cells(SQUALITY.Index).Value.ToString
                        SELSHADE = row.Cells(SSHADE.Index).Value.ToString
                        SELENDS = Val(row.Cells(SENDS.Index).Value)
                        SELWT = Val(row.Cells(SWT.Index).Value)
                    Else
                        SELSRNO = SELSRNO & "|" & Val(row.Cells(SSRNO.Index).Value)
                        SELQUALITY = SELQUALITY & "|" & row.Cells(SQUALITY.Index).Value.ToString
                        SELSHADE = SELSHADE & "|" & row.Cells(SSHADE.Index).Value.ToString
                        SELENDS = SELENDS & "|" & Val(row.Cells(SENDS.Index).Value)
                        SELWT = SELWT & "|" & Val(row.Cells(SWT.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(SELSRNO)
            alParaval.Add(SELQUALITY)
            alParaval.Add(SELSHADE)
            alParaval.Add(SELENDS)
            alParaval.Add(SELWT)



            Dim WARPSRNO As String = ""
            Dim WARPQUALITY As String = ""
            Dim WARPSHADE As String = ""
            Dim WARPENDS As String = ""
            Dim WARPWT As String = ""

            For Each row As System.Windows.Forms.DataGridViewRow In GRIDWARP.Rows
                If row.Cells(0).Value <> Nothing Then
                    If WARPSRNO = "" Then
                        WARPSRNO = Val(row.Cells(WSRNO.Index).Value)
                        WARPQUALITY = row.Cells(WQUALITY.Index).Value.ToString
                        WARPSHADE = row.Cells(WSHADE.Index).Value.ToString
                        WARPENDS = Val(row.Cells(WENDS.Index).Value)
                        WARPWT = Val(row.Cells(WWT.Index).Value)
                    Else
                        WARPSRNO = WARPSRNO & "|" & Val(row.Cells(WSRNO.Index).Value)
                        WARPQUALITY = WARPQUALITY & "|" & row.Cells(WQUALITY.Index).Value.ToString
                        WARPSHADE = WARPSHADE & "|" & row.Cells(WSHADE.Index).Value.ToString
                        WARPENDS = WARPENDS & "|" & Val(row.Cells(WENDS.Index).Value)
                        WARPWT = WARPWT & "|" & Val(row.Cells(WWT.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(WARPSRNO)
            alParaval.Add(WARPQUALITY)
            alParaval.Add(WARPSHADE)
            alParaval.Add(WARPENDS)
            alParaval.Add(WARPWT)



            Dim WEFTSRNO As String = ""
            Dim WEFTQUALITY As String = ""
            Dim WEFTSHADE As String = ""
            Dim WEFTPICK As String = ""
            Dim WEFTWT As String = ""

            For Each row As System.Windows.Forms.DataGridViewRow In GRIDWEFT.Rows
                If row.Cells(0).Value <> Nothing Then
                    If WEFTSRNO = "" Then
                        WEFTSRNO = Val(row.Cells(FSRNO.Index).Value)
                        WEFTQUALITY = row.Cells(FQUALITY.Index).Value.ToString
                        WEFTSHADE = row.Cells(FSHADE.Index).Value.ToString
                        WEFTPICK = Val(row.Cells(FPICK.Index).Value)
                        WEFTWT = Val(row.Cells(FWT.Index).Value)
                    Else
                        WEFTSRNO = WEFTSRNO & "|" & Val(row.Cells(FSRNO.Index).Value)
                        WEFTQUALITY = WEFTQUALITY & "|" & row.Cells(FQUALITY.Index).Value.ToString
                        WEFTSHADE = WEFTSHADE & "|" & row.Cells(FSHADE.Index).Value.ToString
                        WEFTPICK = WEFTPICK & "|" & Val(row.Cells(FPICK.Index).Value)
                        WEFTWT = WEFTWT & "|" & Val(row.Cells(FWT.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(WEFTSRNO)
            alParaval.Add(WEFTQUALITY)
            alParaval.Add(WEFTSHADE)
            alParaval.Add(WEFTPICK)
            alParaval.Add(WEFTWT)


            Dim OBJDESIGN As New ClsDesignCardMaster
            OBJDESIGN.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJDESIGN.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCARDID)
                IntResult = OBJDESIGN.UPDATE()
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
            CMBCOPYDESIGN.Text = ""
            CMBDESIGNNO.Text = ""
            CMBDESIGNNO.Enabled = True
            TXTITEMNAME.Clear()
            TXTCATEGORY.Clear()
            CMBMATCHING.Text = ""
            CMBMATCHING.Enabled = True
            CMBCOPYMATCHING.Text = ""
            TXTTOTALMATCHING.Clear()
            TXTWARPTL.Clear()
            TXTWEFTTL.Clear()
            TXTREED.Clear()
            TXTREEDSPACE.Clear()
            TXTPICKS.Clear()
            TXTTOTALWT.Clear()

            PBPHOTO.Image = Nothing
            PBSELPHOTO.Image = Nothing
            PBWARPPHOTO.Image = Nothing
            PBWEFTPHOTO.Image = Nothing

            TXTSELSRNO.Clear()
            CMBSELQUALITY.Text = ""
            CMBSELSHADE.Text = ""
            TXTSELDENIER.Clear()
            TXTSELENDS.Clear()
            TXTSELWT.Clear()
            TXTTOTALSELENDS.Clear()
            TXTTOTALSELWT.Clear()
            GRIDSELVEDGE.RowCount = 0

            TXTWARPSRNO.Clear()
            CMBWARPQUALITY.Text = ""
            CMBWARPSHADE.Text = ""
            TXTWARPDENIER.Clear()
            TXTWARPENDS.Clear()
            TXTWARPWT.Clear()
            TXTTOTALWARPENDS.Clear()
            TXTTOTALWARPWT.Clear()
            GRIDWARP.RowCount = 0

            TXTWEFTSRNO.Clear()
            CMBWEFTQUALITY.Text = ""
            CMBWEFTSHADE.Text = ""
            TXTWEFTDENIER.Clear()
            TXTWEFTPICK.Clear()
            TXTWEFTWT.Clear()
            TXTTOTALSELWARPENDS.Clear()
            TXTTOTALSELWARPWT.Clear()
            TXTTOTALWEFTPICK.Clear()
            TXTTOTALWEFTWT.Clear()
            GRIDWEFT.RowCount = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignCardMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
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

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True

        If CMBDESIGNNO.Text.Trim.Length = 0 Then
            Ep.SetError(CMBDESIGNNO, "Fill Design No")
            bln = False
        End If


        If CMBMATCHING.Text.Trim.Length = 0 Then
            Ep.SetError(CMBMATCHING, "Select Matching")
            bln = False
        End If

        If Val(TXTWARPTL.Text.Trim) = 0 Then
            Ep.SetError(TXTWARPTL, "Enter Warp TL")
            bln = False
        End If

        If Val(TXTWEFTTL.Text.Trim) = 0 Then
            Ep.SetError(TXTWEFTTL, "Enter Weft TL")
            bln = False
        End If

        If Val(TXTREED.Text.Trim) = 0 Then
            Ep.SetError(TXTREED, "Enter Reed")
            bln = False
        End If

        If Val(TXTREEDSPACE.Text.Trim) = 0 Then
            Ep.SetError(TXTREEDSPACE, "Enter Reed Space")
            bln = False
        End If

        If Val(TXTPICKS.Text.Trim) = 0 Then
            Ep.SetError(TXTPICKS, "Enter Picks")
            bln = False
        End If

        If Val(TXTPICKS.Text.Trim) <> Val(TXTTOTALWEFTPICK.Text.Trim) Then
            Ep.SetError(TXTPICKS, "Picks Does not match")
            bln = False
        End If

        If GRIDWARP.RowCount = 0 Then
            Ep.SetError(GRIDWARP, "Enter Warp Details")
            bln = False
        End If

        If GRIDWEFT.RowCount = 0 Then
            Ep.SetError(GRIDWEFT, "Enter Weft Details")
            bln = False
        End If

        Return bln
    End Function

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGNNO.Enter
        Try
            If CMBDESIGNNO.Text.Trim = "" Then FILLDESIGN(CMBDESIGNNO, "", " AND DESIGNMASTER.DESIGN_HIDEINCARD = 'FALSE'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(sender As Object, e As CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGNNO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMATCHING_Enter(sender As Object, e As EventArgs) Handles CMBMATCHING.Enter
        Try
            If CMBMATCHING.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" DISTINCT COLOR_ID, COLOR_NAME ", "", " DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID RIGHT OUTER JOIN COLORMASTER ON DESIGNMASTER_COLOR.DESIGN_COLORID = COLORMASTER.COLOR_id  ", " And ISNULL(DESIGNMASTER.DESIGN_NO,'')='" & CMBDESIGNNO.Text.Trim & "' AND COLORMASTER.COLOR_ID NOT IN (SELECT DESIGNCARD_MATCHINGID FROM DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID WHERE DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND DESIGNCARD_YEARID = " & YearId & ")  And COLOR_yearid = " & YearId)
                CMBMATCHING.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COLOR_NAME"
                    CMBMATCHING.DisplayMember = "COLOR_NAME"
                    CMBMATCHING.ValueMember = "COLOR_ID"
                    CMBMATCHING.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMATCHING_Validating(sender As Object, e As CancelEventArgs) Handles CMBMATCHING.Validating
        Try
            If CMBMATCHING.Text.Trim <> "" Then COLORVALIDATE(CMBMATCHING, e, Me, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSELQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBSELQUALITY.Enter
        Try
            If CMBSELQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBSELQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSELQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBSELQUALITY.Validating
        Try
            If CMBSELQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBSELQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSELSHADE_Enter(sender As Object, e As EventArgs) Handles CMBSELSHADE.Enter
        Try
            If CMBSELSHADE.Text.Trim = "" Then FILLYARNCOLOR(CMBSELSHADE, CMBSELQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSELSHADE_Validating(sender As Object, e As CancelEventArgs) Handles CMBSELSHADE.Validating
        Try
            If CMBSELSHADE.Text.Trim <> "" Then YARNCOLORVALIDATE(CMBSELSHADE, e, Me, CMBSELQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWARPQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBWARPQUALITY.Enter
        Try
            If CMBWARPQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBWARPQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWARPQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBWARPQUALITY.Validating
        Try
            If CMBWARPQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBWARPQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWARPSHADE_Enter(sender As Object, e As EventArgs) Handles CMBWARPSHADE.Enter
        Try
            If CMBWARPSHADE.Text.Trim = "" Then FILLYARNCOLOR(CMBWARPSHADE, CMBWARPQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWARPSHADE_Validating(sender As Object, e As CancelEventArgs) Handles CMBWARPSHADE.Validating
        Try
            If CMBWARPSHADE.Text.Trim <> "" Then YARNCOLORVALIDATE(CMBWARPSHADE, e, Me, CMBWARPQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEFTQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBWEFTQUALITY.Enter
        Try
            If CMBWEFTQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBWEFTQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEFTQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBWEFTQUALITY.Validating
        Try
            If CMBWEFTQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBWEFTQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEFTSHADE_Enter(sender As Object, e As EventArgs) Handles CMBWEFTSHADE.Enter
        Try
            If CMBWEFTSHADE.Text.Trim = "" Then FILLYARNCOLOR(CMBWEFTSHADE, CMBWEFTQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEFTSHADE_Validating(sender As Object, e As CancelEventArgs) Handles CMBWEFTSHADE.Validating
        Try
            If CMBWEFTSHADE.Text.Trim <> "" Then YARNCOLORVALIDATE(CMBWEFTSHADE, e, Me, CMBWEFTQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validated(sender As Object, e As EventArgs) Handles CMBDESIGNNO.Validated
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(CategoryMaster.category_name,'') As CATEGORY, COUNT(DESIGNMASTER_COLOR.DESIGN_COLORID) AS TOTALMATCHING ", "", " CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER ON CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid RIGHT OUTER JOIN DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID ON ITEMMASTER.item_id = DESIGNMASTER.DESIGN_ITEMID ", " And DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND DESIGNMASTER.DESIGN_YEARID = " & YearId & " GROUP BY ITEMMASTER.item_name, CATEGORYMASTER.category_name")
                If DT.Rows.Count > 0 Then
                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    TXTCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
                    TXTTOTALMATCHING.Text = DT.Rows(0).Item("TOTALMATCHING")
                    CMBDESIGNNO.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPHOTOVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOVIEW.Click
        Try
            Dim objVIEW As New ViewImage
            objVIEW.pbsoftcopy.Image = PBPHOTO.Image
            objVIEW.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWARPTL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTWARPTL.KeyPress, TXTWEFTTL.KeyPress, TXTREEDSPACE.KeyPress, TXTSELENDS.KeyPress, TXTWARPENDS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPICKS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPICKS.KeyPress, TXTSELWT.KeyPress, TXTWARPWT.KeyPress, TXTWEFTPICK.KeyPress, TXTWEFTWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Function FETCHDENIER(QUALITYNAME As String) As Double
        Try
            Dim DENIER As Double = 0
            If QUALITYNAME <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(YARN_DENIER,0) AS DENIER FROM YARNQUALITYMASTER WHERE YARN_NAME = '" & QUALITYNAME & "' AND YARN_YEARID = " & YearId, "", "")
                If DT.Rows.Count > 0 Then DENIER = Val(DT.Rows(0).Item("DENIER"))
            End If
            Return DENIER
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function FETCHPHOTO(QUALITYNAME As String, SHADE As String) As Image
        Try
            Dim PHOTO As Image = Nothing
            If QUALITYNAME <> "" And SHADE <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT YARN_PHOTO AS IMGPATH FROM YARNQUALITYMASTER INNER JOIN YARNQUALITYMASTER_COLOR ON YARNQUALITYMASTER.YARN_ID = YARNQUALITYMASTER_COLOR.YARN_ID INNER JOIN COLORMASTER ON YARN_COLORID = COLOR_ID WHERE YARN_NAME = '" & QUALITYNAME & "' AND COLOR_NAME = '" & SHADE & "' AND YARNQUALITYMASTER.YARN_YEARID = " & YearId, "", "")
                If DT.Rows.Count > 0 Then
                    If IsDBNull(DT.Rows(0).Item("IMGPATH")) = False Then
                        PHOTO = Image.FromStream(New IO.MemoryStream(DirectCast(DT.Rows(0).Item("IMGPATH"), Byte())))
                    Else
                        PHOTO = Nothing
                    End If
                End If
            End If
            Return PHOTO
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBSELQUALITY_Validated(sender As Object, e As EventArgs) Handles CMBSELQUALITY.Validated
        TXTSELDENIER.Text = FETCHDENIER(CMBSELQUALITY.Text.Trim)
        CALC()
    End Sub

    Private Sub CMBWARPQUALITY_Validated(sender As Object, e As EventArgs) Handles CMBWARPQUALITY.Validated
        TXTWARPDENIER.Text = FETCHDENIER(CMBWARPQUALITY.Text.Trim)
        CALC()
    End Sub

    Private Sub CMBWEFTQUALITY_Validated(sender As Object, e As EventArgs) Handles CMBWEFTQUALITY.Validated
        TXTWEFTDENIER.Text = FETCHDENIER(CMBWEFTQUALITY.Text.Trim)
        CALC()
    End Sub

    Sub CALC()
        Try
            If Val(TXTSELWT.Text.Trim) = 0 And Val(TXTSELENDS.Text.Trim) > 0 And Val(TXTWARPTL.Text.Trim) > 0 And Val(TXTSELDENIER.Text.Trim) > 0 Then
                TXTSELWT.Text = Format((Val(TXTSELENDS.Text.Trim) * Val(TXTWARPTL.Text.Trim) * Val(TXTSELDENIER.Text.Trim)) / 9000000, "0.000")
            End If

            If Val(TXTWARPWT.Text.Trim) = 0 And Val(TXTWARPENDS.Text.Trim) > 0 And Val(TXTWARPTL.Text.Trim) > 0 And Val(TXTWARPDENIER.Text.Trim) > 0 Then
                TXTWARPWT.Text = Format((Val(TXTWARPENDS.Text.Trim) * Val(TXTWARPTL.Text.Trim) * Val(TXTWARPDENIER.Text.Trim)) / 9000000, "0.000")
            End If

            If CMBWEFTQUALITY.Text.Trim <> "" And Val(TXTWEFTPICK.Text.Trim) > 0 And Val(TXTREEDSPACE.Text.Trim) > 0 And Val(TXTWEFTTL.Text.Trim) > 0 And Val(TXTWEFTWT.Text.Trim) = 0 Then
                TXTWEFTWT.Text = Format((Val(TXTREEDSPACE.Text.Trim) * Val(TXTWEFTPICK.Text.Trim) * Val(TXTWEFTTL.Text.Trim) * Val(TXTWEFTDENIER.Text.Trim)) / 9000000, "0.000")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSELGRID()

        If GRIDDOUBLECLICK = False Then
            GRIDSELVEDGE.Rows.Add(Val(TXTSELSRNO.Text.Trim), CMBSELQUALITY.Text.Trim, CMBSELSHADE.Text.Trim, Val(TXTSELDENIER.Text.Trim), Val(TXTSELENDS.Text.Trim), Val(TXTSELWT.Text.Trim), PBSELPHOTO.Image)
            getsrno(GRIDSELVEDGE)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSELVEDGE.Item(SSRNO.Index, TEMPROW).Value = Val(TXTSELSRNO.Text.Trim)
            GRIDSELVEDGE.Item(SQUALITY.Index, TEMPROW).Value = CMBSELQUALITY.Text.Trim
            GRIDSELVEDGE.Item(SSHADE.Index, TEMPROW).Value = CMBSELSHADE.Text.Trim
            GRIDSELVEDGE.Item(SDENIER.Index, TEMPROW).Value = Val(TXTSELDENIER.Text.Trim)
            GRIDSELVEDGE.Item(SENDS.Index, TEMPROW).Value = Val(TXTSELENDS.Text.Trim)
            GRIDSELVEDGE.Item(SWT.Index, TEMPROW).Value = Val(TXTSELWT.Text.Trim)
            GRIDSELVEDGE.Item(SIMGPATH.Index, TEMPROW).Value = PBSELPHOTO.Image

            TEMPROW = GRIDSELVEDGE.CurrentRow.Index
            GRIDDOUBLECLICK = False
        End If
        TOTAL()
        CMBSELQUALITY.Text = ""
        CMBSELSHADE.Text = ""
        TXTSELDENIER.Clear()
        TXTSELENDS.Clear()
        TXTSELWT.Clear()
        PBSELPHOTO.Image = Nothing
        TXTSELSRNO.Text = GRIDSELVEDGE.RowCount + 1
        CMBSELQUALITY.Focus()
    End Sub

    Sub FILLWARPGRID()

        If GRIDWARPDOUBLECLICK = False Then
            GRIDWARP.Rows.Add(Val(TXTWARPSRNO.Text.Trim), CMBWARPQUALITY.Text.Trim, CMBWARPSHADE.Text.Trim, Val(TXTWARPDENIER.Text.Trim), Val(TXTWARPENDS.Text.Trim), Val(TXTWARPWT.Text.Trim), PBWARPPHOTO.Image)
            getsrno(GRIDWARP)
        ElseIf GRIDWARPDOUBLECLICK = True Then
            GRIDWARP.Item(WSRNO.Index, TEMPWARPROW).Value = Val(TXTWARPSRNO.Text.Trim)
            GRIDWARP.Item(WQUALITY.Index, TEMPWARPROW).Value = CMBWARPQUALITY.Text.Trim
            GRIDWARP.Item(WSHADE.Index, TEMPWARPROW).Value = CMBWARPSHADE.Text.Trim
            GRIDWARP.Item(WDENIER.Index, TEMPWARPROW).Value = Val(TXTWARPDENIER.Text.Trim)
            GRIDWARP.Item(WENDS.Index, TEMPWARPROW).Value = Val(TXTWARPENDS.Text.Trim)
            GRIDWARP.Item(WWT.Index, TEMPWARPROW).Value = Val(TXTWARPWT.Text.Trim)
            GRIDWARP.Item(WIMGPATH.Index, TEMPWARPROW).Value = PBWARPPHOTO.Image

            TEMPWARPROW = GRIDWARP.CurrentRow.Index
            GRIDWARPDOUBLECLICK = False
        End If
        TOTAL()
        CMBWARPQUALITY.Text = ""
        CMBWARPSHADE.Text = ""
        TXTWARPDENIER.Clear()
        TXTWARPENDS.Clear()
        TXTWARPWT.Clear()
        PBWARPPHOTO.Image = Nothing
        TXTWARPSRNO.Text = GRIDWARP.RowCount + 1
        CMBWARPQUALITY.Focus()
    End Sub

    Sub FILLWEFTGRID()

        If GRIDWEFTDOUBLECLICK = False Then
            GRIDWEFT.Rows.Add(Val(TXTWEFTSRNO.Text.Trim), CMBWEFTQUALITY.Text.Trim, CMBWEFTSHADE.Text.Trim, Val(TXTWEFTDENIER.Text.Trim), Val(TXTWEFTPICK.Text.Trim), Val(TXTWEFTWT.Text.Trim), PBWEFTPHOTO.Image)
            getsrno(GRIDWEFT)
        ElseIf GRIDWEFTDOUBLECLICK = True Then
            GRIDWEFT.Item(FSRNO.Index, TEMPWEFTROW).Value = Val(TXTWEFTSRNO.Text.Trim)
            GRIDWEFT.Item(FQUALITY.Index, TEMPWEFTROW).Value = CMBWEFTQUALITY.Text.Trim
            GRIDWEFT.Item(FSHADE.Index, TEMPWEFTROW).Value = CMBWEFTSHADE.Text.Trim
            GRIDWEFT.Item(FDENIER.Index, TEMPWEFTROW).Value = Val(TXTWEFTDENIER.Text.Trim)
            GRIDWEFT.Item(FPICK.Index, TEMPWEFTROW).Value = Val(TXTWEFTPICK.Text.Trim)
            GRIDWEFT.Item(FWT.Index, TEMPWEFTROW).Value = Val(TXTWEFTWT.Text.Trim)
            GRIDWEFT.Item(FIMGPATH.Index, TEMPWEFTROW).Value = PBWEFTPHOTO.Image

            TEMPWEFTROW = GRIDWEFT.CurrentRow.Index
            GRIDWEFTDOUBLECLICK = False
        End If
        TOTAL()
        CMBWEFTQUALITY.Text = ""
        CMBWEFTSHADE.Text = ""
        TXTWEFTDENIER.Clear()
        TXTWEFTPICK.Clear()
        TXTWEFTWT.Clear()
        PBWEFTPHOTO.Image = Nothing
        TXTWEFTSRNO.Text = GRIDWEFT.RowCount + 1
        CMBWEFTQUALITY.Focus()
    End Sub

    Private Sub TXTSELWT_Validated(sender As Object, e As EventArgs) Handles TXTSELWT.Validated
        Try
            If CMBSELQUALITY.Text.Trim <> "" And Val(TXTSELENDS.Text.Trim) > 0 And Val(TXTSELWT.Text.Trim) > 0 Then
                If Not CHECKSELVEDGE() Then
                    MsgBox("Yarn already Present in Grid below")
                    Exit Sub
                End If
                FILLSELGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKSELVEDGE() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each row As DataGridViewRow In GRIDSELVEDGE.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If CMBSELQUALITY.Text.Trim = row.Cells(SQUALITY.Index).Value And CMBSELSHADE.Text.Trim = row.Cells(SSHADE.Index).Value Then BLN = False
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTWARPWT_Validated(sender As Object, e As EventArgs) Handles TXTWARPWT.Validated
        Try
            If CMBWARPQUALITY.Text.Trim <> "" And Val(TXTWARPENDS.Text.Trim) > 0 And Val(TXTWARPWT.Text.Trim) > 0 Then
                If Not CHECKWARP() Then
                    MsgBox("Yarn already Present in Grid below")
                    Exit Sub
                End If
                FILLWARPGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKWARP() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each row As DataGridViewRow In GRIDWARP.Rows
                If (GRIDWARPDOUBLECLICK = True And TEMPWARPROW <> row.Index) Or GRIDWARPDOUBLECLICK = False Then
                    If CMBWARPQUALITY.Text.Trim = row.Cells(WQUALITY.Index).Value And CMBWARPSHADE.Text.Trim = row.Cells(WSHADE.Index).Value Then BLN = False
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTWEFTWT_Validated(sender As Object, e As EventArgs) Handles TXTWEFTWT.Validated
        Try
            If CMBWEFTQUALITY.Text.Trim <> "" And Val(TXTWEFTPICK.Text.Trim) > 0 And Val(TXTWEFTWT.Text.Trim) > 0 Then
                If Not CHECKWEFT() Then
                    MsgBox("Yarn already Present in Grid below")
                    Exit Sub
                End If
                FILLWEFTGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKWEFT() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each row As DataGridViewRow In GRIDWEFT.Rows
                If (GRIDWEFTDOUBLECLICK = True And TEMPWEFTROW <> row.Index) Or GRIDWEFTDOUBLECLICK = False Then
                    If CMBWEFTQUALITY.Text.Trim = row.Cells(FQUALITY.Index).Value And CMBWEFTSHADE.Text.Trim = row.Cells(FSHADE.Index).Value Then BLN = False
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDSELVEDGE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSELVEDGE.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDSELVEDGE.Item(SQUALITY.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                TXTSELSRNO.Text = Val(GRIDSELVEDGE.Item(SSRNO.Index, e.RowIndex).Value)
                CMBSELQUALITY.Text = GRIDSELVEDGE.Item(SQUALITY.Index, e.RowIndex).Value
                CMBSELSHADE.Text = GRIDSELVEDGE.Item(SSHADE.Index, e.RowIndex).Value
                TXTSELDENIER.Text = GRIDSELVEDGE.Item(SDENIER.Index, e.RowIndex).Value
                TXTSELENDS.Text = GRIDSELVEDGE.Item(SENDS.Index, e.RowIndex).Value
                TXTSELWT.Text = GRIDSELVEDGE.Item(SWT.Index, e.RowIndex).Value
                PBSELPHOTO.Image = GRIDSELVEDGE.Item(SIMGPATH.Index, e.RowIndex).Value
                CMBSELQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWARP_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWARP.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDWARP.Item(WQUALITY.Index, e.RowIndex).Value <> Nothing Then
                GRIDWARPDOUBLECLICK = True
                TEMPWARPROW = e.RowIndex
                TXTWARPSRNO.Text = Val(GRIDWARP.Item(WSRNO.Index, e.RowIndex).Value)
                CMBWARPQUALITY.Text = GRIDWARP.Item(WQUALITY.Index, e.RowIndex).Value
                CMBWARPSHADE.Text = GRIDWARP.Item(WSHADE.Index, e.RowIndex).Value
                TXTWARPDENIER.Text = GRIDWARP.Item(WDENIER.Index, e.RowIndex).Value
                TXTWARPENDS.Text = GRIDWARP.Item(WENDS.Index, e.RowIndex).Value
                TXTWARPWT.Text = GRIDWARP.Item(WWT.Index, e.RowIndex).Value
                PBWARPPHOTO.Image = GRIDWARP.Item(WIMGPATH.Index, e.RowIndex).Value
                CMBWARPQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWEFT_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWEFT.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDWEFT.Item(FQUALITY.Index, e.RowIndex).Value <> Nothing Then
                GRIDWEFTDOUBLECLICK = True
                TEMPWEFTROW = e.RowIndex
                TXTWEFTSRNO.Text = Val(GRIDWEFT.Item(FSRNO.Index, e.RowIndex).Value)
                CMBWEFTQUALITY.Text = GRIDWEFT.Item(FQUALITY.Index, e.RowIndex).Value
                CMBWEFTSHADE.Text = GRIDWEFT.Item(FSHADE.Index, e.RowIndex).Value
                TXTWEFTDENIER.Text = GRIDWEFT.Item(FDENIER.Index, e.RowIndex).Value
                TXTWEFTPICK.Text = GRIDWEFT.Item(FPICK.Index, e.RowIndex).Value
                TXTWEFTWT.Text = GRIDWEFT.Item(FWT.Index, e.RowIndex).Value
                PBWEFTPHOTO.Image = GRIDWEFT.Item(FIMGPATH.Index, e.RowIndex).Value
                CMBWEFTQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSELVEDGE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDSELVEDGE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSELVEDGE.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDSELVEDGE.Rows.RemoveAt(GRIDSELVEDGE.CurrentRow.Index)
                getsrno(GRIDSELVEDGE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSELENDS_Validated(sender As Object, e As EventArgs) Handles TXTSELENDS.Validated, TXTWARPENDS.Validated, TXTWEFTPICK.Validated
        CALC()
    End Sub

    Private Sub GRIDWARP_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDWARP.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDWARP.RowCount > 0 Then
                If GRIDWARPDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDWARP.Rows.RemoveAt(GRIDWARP.CurrentRow.Index)
                getsrno(GRIDWARP)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWEFT_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDWEFT.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDWEFT.RowCount > 0 Then
                If GRIDWEFTDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDWEFT.Rows.RemoveAt(GRIDWEFT.CurrentRow.Index)
                getsrno(GRIDWEFT)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
            CMBDESIGNNO.Focus()
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

                Dim objcls As New ClsDesignCardMaster()
                If MsgBox("Wish To Delete?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(TEMPCARDID)
                alParaval.Add(YearId)
                objcls.alParaval = alParaval
                Dim DT As DataTable = objcls.DELETE()
                MsgBox(DT.Rows(0).Item(0))
                CLEAR()
                EDIT = False

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSELSHADE_Validated(sender As Object, e As EventArgs) Handles CMBSELSHADE.Validated
        PBSELPHOTO.Image = FETCHPHOTO(CMBSELQUALITY.Text.Trim, CMBSELSHADE.Text.Trim)
    End Sub

    Private Sub CMBWARPSHADE_Validated(sender As Object, e As EventArgs) Handles CMBWARPSHADE.Validated
        PBWARPPHOTO.Image = FETCHPHOTO(CMBWARPQUALITY.Text.Trim, CMBWARPSHADE.Text.Trim)
    End Sub

    Private Sub CMBWEFTSHADE_Validated(sender As Object, e As EventArgs) Handles CMBWEFTSHADE.Validated
        PBWEFTPHOTO.Image = FETCHPHOTO(CMBWEFTQUALITY.Text.Trim, CMBWEFTSHADE.Text.Trim)
    End Sub

    Private Sub CMDEXCEL_Click(sender As Object, e As EventArgs) Handles CMDEXCEL.Click
        Try
            If EDIT = False Then Exit Sub
            Dim OBJRPT As New clsReportDesigner("Design Card", System.AppDomain.CurrentDomain.BaseDirectory & "Design Card.xlsx", 2)
            OBJRPT.DESIGNCARD_EXCEL(CmpId, YearId, TEMPCARDID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSELVEDGE_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSELVEDGE.CellClick
        PBPHOTO.Image = GRIDSELVEDGE.CurrentRow.Cells(SIMGPATH.Index).Value
    End Sub

    Private Sub GRIDWARP_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWARP.CellClick
        PBPHOTO.Image = GRIDWARP.CurrentRow.Cells(WIMGPATH.Index).Value
    End Sub

    Private Sub GRIDWEFT_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWEFT.CellClick
        PBPHOTO.Image = GRIDWEFT.CurrentRow.Cells(FIMGPATH.Index).Value
    End Sub

    Private Sub CMBMATCHING_Validated(sender As Object, e As EventArgs) Handles CMBMATCHING.Validated
        Try
            If CMBMATCHING.Text.Trim <> "" And CMBDESIGNNO.Text.Trim <> "" Then CMBMATCHING.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYMATCHING_Enter(sender As Object, e As EventArgs) Handles CMBCOPYMATCHING.Enter
        Try
            If CMBCOPYMATCHING.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" DISTINCT COLOR_ID, COLOR_NAME ", "", " DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID RIGHT OUTER JOIN COLORMASTER ON DESIGNMASTER_COLOR.DESIGN_COLORID = COLORMASTER.COLOR_id  ", " And ISNULL(DESIGNMASTER.DESIGN_NO,'')='" & CMBDESIGNNO.Text.Trim & "' AND COLORMASTER.COLOR_ID IN (SELECT DESIGNCARD_MATCHINGID FROM DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID WHERE DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND DESIGNCARD_YEARID = " & YearId & ")  And COLOR_yearid = " & YearId)
                CMBCOPYMATCHING.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COLOR_NAME"
                    CMBCOPYMATCHING.DisplayMember = "COLOR_NAME"
                    CMBCOPYMATCHING.ValueMember = "COLOR_ID"
                    CMBCOPYMATCHING.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYMATCHING_Validating(sender As Object, e As CancelEventArgs) Handles CMBCOPYMATCHING.Validating
        Try
            If CMBCOPYMATCHING.Text.Trim <> "" Then COLORVALIDATE(CMBCOPYMATCHING, e, Me, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYMATCHING_Validated(sender As Object, e As EventArgs) Handles CMBCOPYMATCHING.Validated
        Try

            If EDIT = True Or CMBCOPYMATCHING.Text.Trim = "" Then Exit Sub
            If MsgBox("Wish to Copy Matching", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            'FIRST GET CARDID OF THE MATCHING AND THEN FETCH THE DATA
            Dim TCID As Integer = 0
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("DESIGNCARD_ID AS CARDID, DESIGNCARD.DESIGNCARD_WARPTL AS WARPTL, DESIGNCARD.DESIGNCARD_WEFTTL AS WEFTTL, DESIGNCARD.DESIGNCARD_REED AS REED, DESIGNCARD.DESIGNCARD_REEDSPACE AS REEDSPACE, DESIGNCARD.DESIGNCARD_PICKS AS PICKS", "", " DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD_DESIGNID = DESIGN_ID INNER JOIN COLORMASTER ON DESIGNCARD_MATCHINGID = COLOR_ID ", " AND DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND COLOR_NAME = '" & CMBCOPYMATCHING.Text.Trim & "' AND DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                TCID = Val(DT.Rows(0).Item("CARDID"))
                TXTWARPTL.Text = Val(DT.Rows(0).Item("WARPTL"))
                TXTWEFTTL.Text = Val(DT.Rows(0).Item("WEFTTL"))
                TXTREED.Text = DT.Rows(0).Item("REED")
                TXTREEDSPACE.Text = Val(DT.Rows(0).Item("REEDSPACE"))
                TXTPICKS.Text = Val(DT.Rows(0).Item("PICKS"))
            End If

            'SELVEDGE GRID
            DT = OBJCMN.search(" DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELENDS AS ENDS, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT AS WT ", "", " DESIGNCARD_SELVEDGEDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    TXTSELDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                    PBSELPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                    GRIDSELVEDGE.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTSELDENIER.Text.Trim), Val(ROW("ENDS")), Val(ROW("WT")), PBSELPHOTO.Image)
                    TXTSELDENIER.Clear()
                    PBSELPHOTO.Image = Nothing
                Next
            End If


            'WARPGRID
            DT = OBJCMN.search(" DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPENDS AS ENDS, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT AS WT ", "", " DESIGNCARD_WARPDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    TXTWARPDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                    PBWARPPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                    GRIDWARP.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTWARPDENIER.Text.Trim), Val(ROW("ENDS")), Val(ROW("WT")), PBWARPPHOTO.Image)
                    TXTWARPDENIER.Clear()
                    PBWARPPHOTO.Image = Nothing
                Next
            End If


            'WEFT
            DT = OBJCMN.search(" DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTPICK AS PICK, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT AS WT ", "", " DESIGNCARD_WEFTDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    TXTWEFTDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                    PBWEFTPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                    GRIDWEFT.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTWEFTDENIER.Text.Trim), Val(ROW("PICK")), Val(ROW("WT")), PBWEFTPHOTO.Image)
                    TXTWEFTDENIER.Clear()
                    PBWEFTPHOTO.Image = Nothing
                Next
            End If

            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYDESIGN_Validated(sender As Object, e As EventArgs) Handles CMBCOPYDESIGN.Validated
        Try

            If EDIT = True Or CMBCOPYDESIGN.Text.Trim = "" Then Exit Sub
            If MsgBox("Wish to Copy Design", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            'FIRST GET CARDID OF THE FIRST MATCHING AND THEN FETCH THE DATA
            Dim TCID As Integer = 0
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" TOP 1 DESIGNCARD_ID AS CARDID, DESIGNCARD.DESIGNCARD_WARPTL AS WARPTL, DESIGNCARD.DESIGNCARD_WEFTTL AS WEFTTL, DESIGNCARD.DESIGNCARD_REED AS REED, DESIGNCARD.DESIGNCARD_REEDSPACE AS REEDSPACE, DESIGNCARD.DESIGNCARD_PICKS AS PICKS", "", " DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD_DESIGNID = DESIGN_ID INNER JOIN COLORMASTER ON DESIGNCARD_MATCHINGID = COLOR_ID ", " AND DESIGN_NO = '" & CMBCOPYDESIGN.Text.Trim & "' AND DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                TCID = Val(DT.Rows(0).Item("CARDID"))
                TXTWARPTL.Text = Val(DT.Rows(0).Item("WARPTL"))
                TXTWEFTTL.Text = Val(DT.Rows(0).Item("WEFTTL"))
                TXTREED.Text = DT.Rows(0).Item("REED")
                TXTREEDSPACE.Text = Val(DT.Rows(0).Item("REEDSPACE"))
                TXTPICKS.Text = Val(DT.Rows(0).Item("PICKS"))
            End If

            'SELVEDGE GRID
            DT = OBJCMN.search(" DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELENDS AS ENDS, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT AS WT ", "", " DESIGNCARD_SELVEDGEDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    TXTSELDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                    PBSELPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                    GRIDSELVEDGE.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTSELDENIER.Text.Trim), Val(ROW("ENDS")), Val(ROW("WT")), PBSELPHOTO.Image)
                    TXTSELDENIER.Clear()
                    PBSELPHOTO.Image = Nothing
                Next
            End If


            'WARPGRID
            DT = OBJCMN.search(" DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPENDS AS ENDS, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT AS WT ", "", " DESIGNCARD_WARPDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    TXTWARPDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                    PBWARPPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                    GRIDWARP.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTWARPDENIER.Text.Trim), Val(ROW("ENDS")), Val(ROW("WT")), PBWARPPHOTO.Image)
                    TXTWARPDENIER.Clear()
                    PBWARPPHOTO.Image = Nothing
                Next
            End If


            'WEFT
            DT = OBJCMN.search(" DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTPICK AS PICK, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT AS WT ", "", " DESIGNCARD_WEFTDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    TXTWEFTDENIER.Text = FETCHDENIER(ROW("YARNQUALITY"))
                    PBWEFTPHOTO.Image = FETCHPHOTO(ROW("YARNQUALITY"), ROW("SHADE"))
                    GRIDWEFT.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(TXTWEFTDENIER.Text.Trim), Val(ROW("PICK")), Val(ROW("WT")), PBWEFTPHOTO.Image)
                    TXTWEFTDENIER.Clear()
                    PBWEFTPHOTO.Image = Nothing
                Next
            End If

            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYDESIGN_Enter(sender As Object, e As EventArgs) Handles CMBCOPYDESIGN.Enter
        Try
            If CMBCOPYDESIGN.Text.Trim = "" Then FILLDESIGN(CMBCOPYDESIGN, "", " AND DESIGNMASTER.DESIGN_HIDEINCARD = 'FALSE'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYDESIGN_Validating(sender As Object, e As CancelEventArgs) Handles CMBCOPYDESIGN.Validating
        Try
            If CMBCOPYDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBCOPYDESIGN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class