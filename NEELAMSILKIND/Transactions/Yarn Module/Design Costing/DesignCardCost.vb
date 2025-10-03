
Imports System.ComponentModel
Imports BL

Public Class DesignCardCost

    Public EDIT As Boolean          'used for editing
    Public TEMPCARDNO As Integer          'used for editing

    Private Sub CMBDESIGNNO_Enter(sender As Object, e As EventArgs) Handles CMBDESIGNNO.Enter
        Try
            If CMBDESIGNNO.Text.Trim = "" Then FILLDESIGN(CMBDESIGNNO, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()

        TXTCOSTNO.Clear()
        COSTDATE.Text = Now.Date
        tstxtbillno.Clear()

        CMBDESIGNNO.Text = ""
        CMBDESIGNNO.Enabled = True
        TXTITEMNAME.Clear()
        TXTCATEGORY.Clear()
        TXTWARPTL.Clear()
        TXTWEFTTL.Clear()
        TXTPICKS.Clear()
        TXTACTUALPICKS.Clear()
        TXTREED.Clear()
        TXTREEDSPACE.Clear()

        GRIDSELVEDGE.RowCount = 0
        GRIDWARP.RowCount = 0
        GRIDWEFT.RowCount = 0

        TXTTOTALSELENDS.Clear()
        TXTTOTALSELWT.Clear()
        TXTTOTALSELCOST.Clear()
        TXTTOTALSELACTUALWT.Clear()
        TXTTOTALSELACTUALCOST.Clear()

        TXTTOTALWARPENDS.Clear()
        TXTTOTALWARPWT.Clear()
        TXTTOTALWARPCOST.Clear()
        TXTTOTALWARPACTUALWT.Clear()
        TXTTOTALWARPACTUALCOST.Clear()

        TXTTOTALWEFTPICK.Clear()
        TXTTOTALWEFTWT.Clear()
        TXTTOTALWEFTCOST.Clear()
        TXTTOTALWEFTACTUALWT.Clear()
        TXTTOTALWEFTACTUALCOST.Clear()

        TXTTOTALWT.Clear()
        TXTTOTALCOST.Clear()
        TXTTOTALACTUALWT.Clear()
        TXTTOTALACTUALCOST.Clear()

        TXTDHARA.Clear()
        TXTDHARACOST.Clear()
        TXTDHARAACTUALCOST.Clear()

        TXTWASTAGE.Clear()
        TXTWASTAGECOST.Clear()
        TXTWASTAGEACTUALCOST.Clear()

        TXTWEAVING.Clear()
        TXTWEAVINGCOST.Clear()
        TXTWEAVINGACTUALCOST.Clear()

        TXTBOBINCOST.Clear()
        TXTBOBINACTUALCOST.Clear()
        TXTOTHERCOST.Clear()
        TXTOTHERACTUALCOST.Clear()
        TXTMARGINCOST.Clear()
        TXTMARGINACTUALCOST.Clear()

        TXTFINALCOST.Clear()
        TXTFINALACTUALCOST.Clear()
        TXTFINALCOSTDIFF.Clear()

        GETMAXNO()

    End Sub

    Sub TOTAL()
        Try
            TXTTOTALWT.Clear()
            TXTTOTALCOST.Clear()
            TXTTOTALACTUALCOST.Clear()
            TXTTOTALSELENDS.Clear()
            TXTTOTALSELWT.Clear()
            TXTTOTALSELCOST.Clear()
            TXTTOTALSELACTUALWT.Clear()
            TXTTOTALSELACTUALCOST.Clear()
            TXTTOTALWARPENDS.Clear()
            TXTTOTALWARPWT.Clear()
            TXTTOTALWARPCOST.Clear()
            TXTTOTALWARPACTUALWT.Clear()
            TXTTOTALWARPACTUALCOST.Clear()
            TXTTOTALWEFTPICK.Clear()
            TXTTOTALWEFTWT.Clear()
            TXTTOTALWEFTCOST.Clear()
            TXTTOTALWEFTACTUALWT.Clear()
            TXTTOTALWEFTACTUALCOST.Clear()

            TXTDHARACOST.Clear()
            TXTDHARAACTUALCOST.Clear()
            TXTWASTAGECOST.Clear()
            TXTWASTAGEACTUALCOST.Clear()
            TXTWEAVINGCOST.Clear()
            TXTWEAVINGACTUALCOST.Clear()
            TXTFINALCOST.Clear()
            TXTFINALACTUALCOST.Clear()
            TXTFINALCOSTDIFF.Clear()

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            For Each ROW As DataGridViewRow In GRIDSELVEDGE.Rows
                TXTTOTALSELENDS.Text = Format(Val(TXTTOTALSELENDS.Text.Trim) + Val(ROW.Cells(SENDS.Index).EditedFormattedValue), "0")
                TXTTOTALSELWT.Text = Format(Val(TXTTOTALSELWT.Text.Trim) + Val(ROW.Cells(SWT.Index).EditedFormattedValue), "0.00")

                'GET GSTPER FROM HSNMASTER AND GET RATEGST
                DT = OBJCMN.search("ISNULL(HSNMASTER.HSN_IGST,0) AS GSTPER", "", " YARNQUALITYMASTER INNER JOIN HSNMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID ", " AND YARNQUALITYMASTER.YARN_NAME = '" & ROW.Cells(SQUALITY.Index).Value & "' AND YARNQUALITYMASTER.YARN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then ROW.Cells(SRATEGST.Index).Value = Format(Val(ROW.Cells(SRATE.Index).EditedFormattedValue) + (Val(ROW.Cells(SRATE.Index).EditedFormattedValue) * Val(DT.Rows(0).Item("GSTPER"))) / 100, "0.00")

                ROW.Cells(SCOST.Index).Value = Format((Val(ROW.Cells(SWT.Index).EditedFormattedValue) * Val(ROW.Cells(SRATEGST.Index).EditedFormattedValue)) / 100, "0.00")
                TXTTOTALSELCOST.Text = Format(Val(TXTTOTALSELCOST.Text.Trim) + Val(ROW.Cells(SCOST.Index).EditedFormattedValue), "0.00")
            Next


            For Each ROW As DataGridViewRow In GRIDWARP.Rows
                TXTTOTALWARPENDS.Text = Format(Val(TXTTOTALWARPENDS.Text.Trim) + Val(ROW.Cells(WENDS.Index).EditedFormattedValue), "0")
                TXTTOTALWARPWT.Text = Format(Val(TXTTOTALWARPWT.Text.Trim) + Val(ROW.Cells(WWT.Index).EditedFormattedValue), "0.00")

                'GET GSTPER FROM HSNMASTER AND GET RATEGST
                DT = OBJCMN.search("ISNULL(HSNMASTER.HSN_IGST,0) AS GSTPER", "", " YARNQUALITYMASTER INNER JOIN HSNMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID ", " AND YARNQUALITYMASTER.YARN_NAME = '" & ROW.Cells(WQUALITY.Index).Value & "' AND YARNQUALITYMASTER.YARN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then ROW.Cells(WRATEGST.Index).Value = Format(Val(ROW.Cells(WRATE.Index).EditedFormattedValue) + (Val(ROW.Cells(WRATE.Index).EditedFormattedValue) * Val(DT.Rows(0).Item("GSTPER"))) / 100, "0.00")

                ROW.Cells(WCOST.Index).Value = Format((Val(ROW.Cells(WWT.Index).EditedFormattedValue) * Val(ROW.Cells(WRATEGST.Index).EditedFormattedValue)) / 100, "0.00")
                TXTTOTALWARPCOST.Text = Format(Val(TXTTOTALWARPCOST.Text.Trim) + Val(ROW.Cells(WCOST.Index).EditedFormattedValue), "0.00")
            Next


            For Each ROW As DataGridViewRow In GRIDWEFT.Rows
                TXTTOTALWEFTPICK.Text = Format(Val(TXTTOTALWEFTPICK.Text.Trim) + Val(ROW.Cells(FPICK.Index).EditedFormattedValue), "0.00")
                TXTTOTALWEFTWT.Text = Format(Val(TXTTOTALWEFTWT.Text.Trim) + Val(ROW.Cells(FWT.Index).EditedFormattedValue), "0.00")

                'GET GSTPER FROM HSNMASTER AND GET RATEGST
                DT = OBJCMN.search("ISNULL(HSNMASTER.HSN_IGST,0) AS GSTPER", "", " YARNQUALITYMASTER INNER JOIN HSNMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID ", " AND YARNQUALITYMASTER.YARN_NAME = '" & ROW.Cells(FQUALITY.Index).Value & "' AND YARNQUALITYMASTER.YARN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then ROW.Cells(FRATEGST.Index).Value = Format(Val(ROW.Cells(FRATE.Index).EditedFormattedValue) + (Val(ROW.Cells(FRATE.Index).EditedFormattedValue) * Val(DT.Rows(0).Item("GSTPER"))) / 100, "0.00")


                ROW.Cells(FCOST.Index).Value = Format((Val(ROW.Cells(FWT.Index).EditedFormattedValue) * Val(ROW.Cells(FRATEGST.Index).EditedFormattedValue)) / 100, "0.00")
                TXTTOTALWEFTCOST.Text = Format(Val(TXTTOTALWEFTCOST.Text.Trim) + Val(ROW.Cells(FCOST.Index).EditedFormattedValue), "0.00")
            Next




            TXTTOTALWT.Text = Format(Val(TXTTOTALSELWT.Text.Trim) + Val(TXTTOTALWARPWT.Text.Trim) + Val(TXTTOTALWEFTWT.Text.Trim), "0.00")
            TXTTOTALCOST.Text = Format(Val(TXTTOTALSELCOST.Text.Trim) + Val(TXTTOTALWARPCOST.Text.Trim) + Val(TXTTOTALWEFTCOST.Text.Trim), "0.00")


            'FOR ACTUALCALCUALATION
            For Each ROW As DataGridViewRow In GRIDSELVEDGE.Rows
                If Val(TXTTOTALACTUALWT.Text.Trim) > 0 Then ROW.Cells(SACTUALWT.Index).Value = Format((Val(TXTTOTALACTUALWT.Text.Trim) * Val(ROW.Cells(SWT.Index).EditedFormattedValue)) / Val(TXTTOTALWT.Text.Trim), "0.00")
                ROW.Cells(SACTUALCOST.Index).Value = Format((Val(ROW.Cells(SACTUALWT.Index).EditedFormattedValue) * Val(ROW.Cells(SRATEGST.Index).EditedFormattedValue)) / 100, "0.00")
                TXTTOTALSELACTUALWT.Text = Format(Val(TXTTOTALSELACTUALWT.Text.Trim) + Val(ROW.Cells(SACTUALWT.Index).EditedFormattedValue), "0.00")
                TXTTOTALSELACTUALCOST.Text = Format(Val(TXTTOTALSELACTUALCOST.Text.Trim) + Val(ROW.Cells(SACTUALCOST.Index).EditedFormattedValue), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDWARP.Rows
                If Val(TXTTOTALACTUALWT.Text.Trim) > 0 Then ROW.Cells(WACTUALWT.Index).Value = Format((Val(TXTTOTALACTUALWT.Text.Trim) * Val(ROW.Cells(WWT.Index).EditedFormattedValue)) / Val(TXTTOTALWT.Text.Trim), "0.00")
                ROW.Cells(WACTUALCOST.Index).Value = Format((Val(ROW.Cells(WACTUALWT.Index).EditedFormattedValue) * Val(ROW.Cells(WRATEGST.Index).EditedFormattedValue)) / 100, "0.00")
                TXTTOTALWARPACTUALWT.Text = Format(Val(TXTTOTALWARPACTUALWT.Text.Trim) + Val(ROW.Cells(WACTUALWT.Index).EditedFormattedValue), "0.00")
                TXTTOTALWARPACTUALCOST.Text = Format(Val(TXTTOTALWARPACTUALCOST.Text.Trim) + Val(ROW.Cells(WACTUALCOST.Index).EditedFormattedValue), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDWEFT.Rows
                If Val(TXTTOTALACTUALWT.Text.Trim) > 0 Then ROW.Cells(FACTUALWT.Index).Value = Format((Val(TXTTOTALACTUALWT.Text.Trim) * Val(ROW.Cells(FWT.Index).EditedFormattedValue)) / Val(TXTTOTALWT.Text.Trim), "0.00")
                ROW.Cells(FACTUALCOST.Index).Value = Format((Val(ROW.Cells(FACTUALWT.Index).EditedFormattedValue) * Val(ROW.Cells(FRATEGST.Index).EditedFormattedValue)) / 100, "0.00")
                TXTTOTALWEFTACTUALWT.Text = Format(Val(TXTTOTALWEFTACTUALWT.Text.Trim) + Val(ROW.Cells(FACTUALWT.Index).EditedFormattedValue), "0.00")
                TXTTOTALWEFTACTUALCOST.Text = Format(Val(TXTTOTALWEFTACTUALCOST.Text.Trim) + Val(ROW.Cells(FACTUALCOST.Index).EditedFormattedValue), "0.00")
            Next

            TXTTOTALACTUALCOST.Text = Format(Val(TXTTOTALSELACTUALCOST.Text.Trim) + Val(TXTTOTALWARPACTUALCOST.Text.Trim) + Val(TXTTOTALWEFTACTUALCOST.Text.Trim), "0.00")

            If Val(TXTDHARA.Text.Trim) > 0 Then
                TXTDHARACOST.Text = Format((Val(TXTTOTALCOST.Text.Trim) * Val(TXTDHARA.Text.Trim)) / 100, "0.00")
                TXTDHARAACTUALCOST.Text = Format((Val(TXTTOTALACTUALCOST.Text.Trim) * Val(TXTDHARA.Text.Trim)) / 100, "0.00")
            End If

            'WASTAGE WILL BE CALC ON TOTALCOST + DHARACOST
            If Val(TXTWASTAGE.Text.Trim) > 0 Then
                TXTWASTAGECOST.Text = Format(((Val(TXTTOTALCOST.Text.Trim) + Val(TXTDHARACOST.Text.Trim)) * Val(TXTWASTAGE.Text.Trim)) / 100, "0.00")
                TXTWASTAGEACTUALCOST.Text = Format(((Val(TXTTOTALACTUALCOST.Text.Trim) + Val(TXTDHARAACTUALCOST.Text.Trim)) * Val(TXTWASTAGE.Text.Trim)) / 100, "0.00")
            End If

            'WEAVING WILL BE CALC ON ACTUALPICKS
            If Val(TXTWEAVING.Text.Trim) > 0 And Val(TXTACTUALPICKS.Text.Trim) > 0 Then
                TXTWEAVINGCOST.Text = Format(Val(TXTACTUALPICKS.Text.Trim) * (Val(TXTWEAVING.Text.Trim) + (Val(TXTWEAVING.Text.Trim) * 0.05)), "0.00")
                TXTWEAVINGACTUALCOST.Text = Format(Val(TXTACTUALPICKS.Text.Trim) * (Val(TXTWEAVING.Text.Trim) + (Val(TXTWEAVING.Text.Trim) * 0.05)), "0.00")
            End If


            TXTFINALCOST.Text = Format(Val(TXTTOTALCOST.Text.Trim) + Val(TXTDHARACOST.Text.Trim) + Val(TXTWASTAGECOST.Text.Trim) + Val(TXTWEAVINGCOST.Text.Trim) + Val(TXTBOBINCOST.Text.Trim) + Val(TXTOTHERCOST.Text.Trim) + Val(TXTMARGINCOST.Text.Trim), "0.00")
            TXTFINALACTUALCOST.Text = Format(Val(TXTTOTALACTUALCOST.Text.Trim) + Val(TXTDHARAACTUALCOST.Text.Trim) + Val(TXTWASTAGEACTUALCOST.Text.Trim) + Val(TXTWEAVINGACTUALCOST.Text.Trim) + Val(TXTBOBINACTUALCOST.Text.Trim) + Val(TXTOTHERACTUALCOST.Text.Trim) + Val(TXTMARGINACTUALCOST.Text.Trim), "0.00")
            TXTFINALCOSTDIFF.Text = Format(Val(TXTFINALCOST.Text.Trim) - Val(TXTFINALACTUALCOST.Text.Trim), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBDESIGNNO.Focus()
    End Sub

    Sub GETMAXNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(DESIGNCARDCOST_no),0) + 1 ", " DESIGNCARDCOST ", " AND DESIGNCARDCOST_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTCOSTNO.Text = Val(DTTABLE.Rows(0).Item(0))
    End Sub

    Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True

        If CMBDESIGNNO.Text.Trim.Length = 0 Then
            EP.SetError(CMBDESIGNNO, " Please Fill Design No")
            BLN = False
        End If

        If GRIDWARP.RowCount = 0 Then
            EP.SetError(GRIDWARP, "Enter Warp Details")
            BLN = False
        End If

        If GRIDWEFT.RowCount = 0 Then
            EP.SetError(GRIDWEFT, "Enter Weft Details")
            BLN = False
        End If

        Return BLN
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If
            Dim IntResult As Integer

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(COSTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(UCase(CMBDESIGNNO.Text.Trim))
            alParaval.Add(Val(TXTWARPTL.Text.Trim))
            alParaval.Add(Val(TXTWEFTTL.Text.Trim))
            alParaval.Add(TXTREED.Text.Trim)
            alParaval.Add(Val(TXTREEDSPACE.Text.Trim))
            alParaval.Add(Val(TXTPICKS.Text.Trim))
            alParaval.Add(Val(TXTACTUALPICKS.Text.Trim))
            alParaval.Add(Val(TXTTOTALWT.Text.Trim))

            alParaval.Add(Val(TXTTOTALSELENDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALSELWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALSELCOST.Text.Trim))
            alParaval.Add(Val(TXTTOTALSELACTUALWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALSELACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTTOTALWARPENDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALWARPWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALWARPCOST.Text.Trim))
            alParaval.Add(Val(TXTTOTALWARPACTUALWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALWARPACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTTOTALWEFTPICK.Text.Trim))
            alParaval.Add(Val(TXTTOTALWEFTWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALWEFTCOST.Text.Trim))
            alParaval.Add(Val(TXTTOTALWEFTACTUALWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALWEFTACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTTOTALCOST.Text.Trim))
            alParaval.Add(Val(TXTTOTALACTUALWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTDHARA.Text.Trim))
            alParaval.Add(Val(TXTDHARACOST.Text.Trim))
            alParaval.Add(Val(TXTDHARAACTUALCOST.Text.Trim))


            alParaval.Add(Val(TXTWASTAGE.Text.Trim))
            alParaval.Add(Val(TXTWASTAGECOST.Text.Trim))
            alParaval.Add(Val(TXTWASTAGEACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTWEAVING.Text.Trim))
            alParaval.Add(Val(TXTWEAVINGCOST.Text.Trim))
            alParaval.Add(Val(TXTWEAVINGACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTBOBINCOST.Text.Trim))
            alParaval.Add(Val(TXTBOBINACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTOTHERCOST.Text.Trim))
            alParaval.Add(Val(TXTOTHERACTUALCOST.Text.Trim))


            alParaval.Add(Val(TXTMARGINCOST.Text.Trim))
            alParaval.Add(Val(TXTMARGINACTUALCOST.Text.Trim))

            alParaval.Add(Val(TXTFINALCOST.Text.Trim))
            alParaval.Add(Val(TXTFINALACTUALCOST.Text.Trim))
            alParaval.Add(Val(TXTFINALCOSTDIFF.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)



            Dim SELSRNO As String = ""
            Dim SELQUALITY As String = ""
            Dim SELSHADE As String = ""
            Dim SELENDS As String = ""
            Dim SELWT As String = ""
            Dim SELRATE As String = ""
            Dim SELRATEANDGST As String = ""
            Dim SELCOST As String = ""
            Dim SELACTWT As String = ""
            Dim SELACTCOST As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSELVEDGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If SELSRNO = "" Then
                        SELSRNO = Val(row.Cells(SSRNO.Index).Value)
                        SELQUALITY = row.Cells(SQUALITY.Index).Value.ToString
                        SELSHADE = row.Cells(SSHADE.Index).Value.ToString
                        SELENDS = Val(row.Cells(SENDS.Index).Value)
                        SELWT = Val(row.Cells(SWT.Index).Value)
                        SELRATE = Val(row.Cells(SRATE.Index).Value)
                        SELRATEANDGST = Val(row.Cells(SRATEGST.Index).Value)
                        SELCOST = Val(row.Cells(SCOST.Index).Value)
                        SELACTWT = Val(row.Cells(SACTUALWT.Index).Value)
                        SELACTCOST = Val(row.Cells(SACTUALCOST.Index).Value)

                    Else
                        SELSRNO = SELSRNO & "|" & Val(row.Cells(SSRNO.Index).Value)
                        SELQUALITY = SELQUALITY & "|" & row.Cells(SQUALITY.Index).Value.ToString
                        SELSHADE = SELSHADE & "|" & row.Cells(SSHADE.Index).Value.ToString
                        SELENDS = SELENDS & "|" & Val(row.Cells(SENDS.Index).Value)
                        SELWT = SELWT & "|" & Val(row.Cells(SWT.Index).Value)
                        SELRATE = SELRATE & "|" & Val(row.Cells(SRATE.Index).Value)
                        SELRATEANDGST = SELRATEANDGST & "|" & Val(row.Cells(SRATEGST.Index).Value)
                        SELCOST = SELCOST & "|" & Val(row.Cells(SCOST.Index).Value)
                        SELACTWT = SELACTWT & "|" & Val(row.Cells(SACTUALWT.Index).Value)
                        SELACTCOST = SELACTCOST & "|" & Val(row.Cells(SACTUALCOST.Index).Value)

                    End If
                End If
            Next


            alParaval.Add(SELSRNO)
            alParaval.Add(SELQUALITY)
            alParaval.Add(SELSHADE)
            alParaval.Add(SELENDS)
            alParaval.Add(SELWT)
            alParaval.Add(SELRATE)
            alParaval.Add(SELRATEANDGST)
            alParaval.Add(SELCOST)
            alParaval.Add(SELACTWT)
            alParaval.Add(SELACTCOST)


            Dim WARPSRNO As String = ""
            Dim WARPQUALITY As String = ""
            Dim WARPSHADE As String = ""
            Dim WARPENDS As String = ""
            Dim WARPWT As String = ""
            Dim WARPRATE As String = ""
            Dim WARPRATEGST As String = ""
            Dim WARPCOST As String = ""
            Dim WARPACTWT As String = ""
            Dim WARPACTCOST As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDWARP.Rows
                If row.Cells(0).Value <> Nothing Then
                    If WARPSRNO = "" Then
                        WARPSRNO = Val(row.Cells(WSRNO.Index).Value)
                        WARPQUALITY = row.Cells(WQUALITY.Index).Value.ToString
                        WARPSHADE = row.Cells(WSHADE.Index).Value.ToString
                        WARPENDS = Val(row.Cells(WENDS.Index).Value)
                        WARPWT = Val(row.Cells(WWT.Index).Value)
                        WARPRATE = Val(row.Cells(WRATE.Index).Value)
                        WARPRATEGST = Val(row.Cells(WRATEGST.Index).Value)
                        WARPCOST = Val(row.Cells(WCOST.Index).Value)
                        WARPACTWT = Val(row.Cells(WACTUALWT.Index).Value)
                        WARPACTCOST = Val(row.Cells(WACTUALCOST.Index).Value)
                    Else
                        WARPSRNO = WARPSRNO & "|" & Val(row.Cells(WSRNO.Index).Value)
                        WARPQUALITY = WARPQUALITY & "|" & row.Cells(WQUALITY.Index).Value.ToString
                        WARPSHADE = WARPSHADE & "|" & row.Cells(WSHADE.Index).Value.ToString
                        WARPENDS = WARPENDS & "|" & Val(row.Cells(WENDS.Index).Value)
                        WARPWT = WARPWT & "|" & Val(row.Cells(WWT.Index).Value)
                        WARPRATE = WARPRATE & "|" & Val(row.Cells(WRATE.Index).Value)
                        WARPRATEGST = WARPRATEGST & "|" & Val(row.Cells(WRATEGST.Index).Value)
                        WARPCOST = WARPCOST & "|" & Val(row.Cells(WCOST.Index).Value)
                        WARPACTWT = WARPACTWT & "|" & Val(row.Cells(WACTUALWT.Index).Value)
                        WARPACTCOST = WARPACTCOST & "|" & Val(row.Cells(WACTUALCOST.Index).Value)

                    End If
                End If
            Next


            alParaval.Add(WARPSRNO)
            alParaval.Add(WARPQUALITY)
            alParaval.Add(WARPSHADE)
            alParaval.Add(WARPENDS)
            alParaval.Add(WARPWT)
            alParaval.Add(WARPRATE)
            alParaval.Add(WARPRATEGST)
            alParaval.Add(WARPCOST)
            alParaval.Add(WARPACTWT)
            alParaval.Add(WARPACTCOST)


            Dim WEFTSRNO As String = ""
            Dim WEFTQUALITY As String = ""
            Dim WEFTSHADE As String = ""
            Dim WEFTPICK As String = ""
            Dim WEFTWT As String = ""
            Dim WEFTRATE As String = ""
            Dim WEFTRATEGST As String = ""
            Dim WEFTCOST As String = ""
            Dim WEFTACTWT As String = ""
            Dim WEFTACTCOST As String = ""


            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDWEFT.Rows
                If row.Cells(0).Value <> Nothing Then
                    If WEFTSRNO = "" Then
                        WEFTSRNO = Val(row.Cells(FSRNO.Index).Value)
                        WEFTQUALITY = row.Cells(FQUALITY.Index).Value.ToString
                        WEFTSHADE = row.Cells(FSHADE.Index).Value.ToString
                        WEFTPICK = Val(row.Cells(FPICK.Index).Value)
                        WEFTWT = Val(row.Cells(FWT.Index).Value)
                        WEFTRATE = Val(row.Cells(FRATE.Index).Value)
                        WEFTRATEGST = Val(row.Cells(FRATEGST.Index).Value)
                        WEFTCOST = Val(row.Cells(FCOST.Index).Value)
                        WEFTACTWT = Val(row.Cells(FACTUALWT.Index).Value)
                        WEFTACTCOST = Val(row.Cells(FACTUALCOST.Index).Value)
                    Else
                        WEFTSRNO = WEFTSRNO & "|" & Val(row.Cells(FSRNO.Index).Value)
                        WEFTQUALITY = WEFTQUALITY & "|" & row.Cells(FQUALITY.Index).Value.ToString
                        WEFTSHADE = WEFTSHADE & "|" & row.Cells(FSHADE.Index).Value.ToString
                        WEFTPICK = WEFTPICK & "|" & Val(row.Cells(FPICK.Index).Value)
                        WEFTWT = WEFTWT & "|" & Val(row.Cells(FWT.Index).Value)
                        WEFTRATE = WEFTRATE & "|" & Val(row.Cells(FRATE.Index).Value)
                        WEFTRATEGST = WEFTRATEGST & "|" & Val(row.Cells(FRATEGST.Index).Value)
                        WEFTCOST = WEFTCOST & "|" & Val(row.Cells(FCOST.Index).Value)
                        WEFTACTWT = WEFTACTWT & "|" & Val(row.Cells(FACTUALWT.Index).Value)
                        WEFTACTCOST = WEFTACTCOST & "|" & Val(row.Cells(FACTUALCOST.Index).Value)

                    End If
                End If
            Next


            alParaval.Add(WEFTSRNO)
            alParaval.Add(WEFTQUALITY)
            alParaval.Add(WEFTSHADE)
            alParaval.Add(WEFTPICK)
            alParaval.Add(WEFTWT)
            alParaval.Add(WEFTRATE)
            alParaval.Add(WEFTRATEGST)
            alParaval.Add(WEFTCOST)
            alParaval.Add(WEFTACTWT)
            alParaval.Add(WEFTACTCOST)


            Dim OBJDESIGN As New ClsDesignCardCost
            OBJDESIGN.alParaval = alParaval

            If EDIT = False Then
                IntResult = OBJDESIGN.SAVE()
                MsgBox("Details Added")
            Else
                alParaval.Add(TEMPCARDNO)
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

    Private Sub DESIGNCARDCOST_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode =System.WINDOWS.FORMS.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                YarnRecd.Focus()
            ElseIf e.Alt = True And e.KeyCode =System.WINDOWS.FORMS.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DESIGNCARDCOST_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Cursor.Current = Cursors.WaitCursor

            FILLDESIGN(CMBDESIGNNO, "", " AND DESIGNMASTER.DESIGN_HIDEINCARD = 'FALSE'")
            CLEAR()

            If EDIT = True Then

                Dim OBJCMN As New ClsCommon
                Dim OBJCARD As New ClsDesignCardCost()
                OBJCARD.alParaval.Add(TEMPCARDNO)
                OBJCARD.alParaval.Add(YearId)
                Dim DT As DataTable = OBJCARD.SELECTCOST()

                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows
                        TXTCOSTNO.Text = dr("COSTNO")
                        COSTDATE.Text = Format(Convert.ToDateTime(dr("COSTDATE")).Date, "dd/MM/yyyy")
                        CMBDESIGNNO.Text = dr("DESIGNNO")
                        CMBDESIGNNO.Enabled = False
                        TXTITEMNAME.Text = dr("ITEMNAME")
                        TXTCATEGORY.Text = dr("CATEGORY")
                        TXTWARPTL.Text = Val(dr("WARPTL"))
                        TXTWEFTTL.Text = Val(dr("WEFTL"))
                        TXTREED.Text = dr("REED")
                        TXTREEDSPACE.Text = Val(dr("REEDSPACE"))
                        TXTPICKS.Text = Val(dr("PICKS"))
                        TXTACTUALPICKS.Text = Val(dr("ACTUALPICKS"))

                        TXTTOTALACTUALWT.Text = Val(dr("TACTWT"))

                        TXTDHARA.Text = Val(dr("DHARA"))
                        TXTWASTAGE.Text = Val(dr("WASTAGE"))
                        TXTWEAVING.Text = Val(dr("WEAVING"))
                        TXTBOBINCOST.Text = Val(dr("BOBINCOST"))
                        TXTBOBINACTUALCOST.Text = Val(dr("BOBINACTCOST"))
                        TXTOTHERCOST.Text = Val(dr("OTHERCOST"))
                        TXTOTHERACTUALCOST.Text = Val(dr("OTHERACTCOST"))
                        TXTMARGINCOST.Text = Val(dr("MARGINCOST"))
                        TXTMARGINACTUALCOST.Text = Val(dr("MARGINACTCOST"))
                    Next
                End If


                'SELVEDGE GRID
                DT = OBJCMN.search(" DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNQUALITYMASTER.YARN_DENIER,0) AS DENIER, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELENDS AS ENDS, DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELWT AS WT, ISNULL(DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELRATE,0) AS YARNRATE, ISNULL(DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELRATEGST,0) AS RATEGST, ISNULL(DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELCOST,0) AS COST, ISNULL(DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELACTWT,0) AS ACTUALWT, ISNULL(DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELACTCOST,0) AS ACTUALCOST ", "", " DESIGNCARDCOST_SELVEDGEDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_NO = " & Val(TEMPCARDNO) & " AND DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_YEARID = " & YearId & " ORDER BY DESIGNCARDCOST_SELVEDGEDETAILS.DESIGNCARDCOST_SELSRNO")
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        GRIDSELVEDGE.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(ROW("DENIER")), Val(ROW("ENDS")), Val(ROW("WT")), Val(ROW("YARNRATE")), Val(ROW("RATEGST")), Val(ROW("COST")), Val(ROW("ACTUALWT")), Val(ROW("ACTUALCOST")))
                    Next
                End If


                'WARPGRID
                DT = OBJCMN.search(" DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNQUALITYMASTER.YARN_DENIER,0) AS DENIER, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPENDS AS ENDS, DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPWT AS WT, ISNULL(DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPRATE,0) AS YARNRATE, ISNULL(DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPRATEGST,0) AS RATEGST, ISNULL(DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPCOST,0) AS COST, ISNULL(DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPACTWT,0) AS ACTUALWT, ISNULL(DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPACTCOST,0) AS ACTUALCOST ", "", " DESIGNCARDCOST_WARPDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_NO = " & Val(TEMPCARDNO) & " AND DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_YEARID = " & YearId & " ORDER BY DESIGNCARDCOST_WARPDETAILS.DESIGNCARDCOST_WARPSRNO")
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        GRIDWARP.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(ROW("DENIER")), Val(ROW("ENDS")), Val(ROW("WT")), Val(ROW("YARNRATE")), Val(ROW("RATEGST")), Val(ROW("COST")), Val(ROW("ACTUALWT")), Val(ROW("ACTUALCOST")))
                    Next
                End If


                'WEFT
                DT = OBJCMN.search(" DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNQUALITYMASTER.YARN_DENIER,0) AS DENIER, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTPICK AS PICK, DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTWT AS WT, ISNULL(DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTRATE,0) AS YARNRATE, ISNULL(DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTRATEGST,0) AS RATEGST, ISNULL(DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTCOST,0) AS COST, ISNULL(DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTACTWT,0) AS ACTUALWT, ISNULL(DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTACTCOST,0) AS ACTUALCOST ", "", " DESIGNCARDCOST_WEFTDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTSHADEID = COLORMASTER.COLOR_id ", " AND DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_NO = " & Val(TEMPCARDNO) & " AND DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_YEARID = " & YearId & " ORDER BY DESIGNCARDCOST_WEFTDETAILS.DESIGNCARDCOST_WEFTSRNO")
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        GRIDWEFT.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(ROW("DENIER")), Val(ROW("PICK")), Val(ROW("WT")), Val(ROW("YARNRATE")), Val(ROW("RATEGST")), Val(ROW("COST")), Val(ROW("ACTUALWT")), Val(ROW("ACTUALCOST")))
                    Next
                End If

                TOTAL()

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJCARD As New DesignCardCostDetails
            OBJCARD.MdiParent = MDIMain
            OBJCARD.Show()
        Catch ex As Exception
            Throw ex
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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDWARP.RowCount = 0
                TEMPCARDNO = Val(tstxtbillno.Text)
                If TEMPCARDNO > 0 Then
                    EDIT = True
                    DESIGNCARDCOST_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            GRIDWARP.RowCount = 0
LINE1:
            TEMPCARDNO = Val(TXTCOSTNO.Text) - 1
            If TEMPCARDNO > 0 Then
                EDIT = True
                DESIGNCARDCOST_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDWARP.RowCount = 0 And TEMPCARDNO > 1 Then
                TXTCOSTNO.Text = TEMPCARDNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
LINE1:
            TEMPCARDNO = Val(TXTCOSTNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTCOSTNO.Text.Trim
            CLEAR()
            If Val(TXTCOSTNO.Text) - 1 >= TEMPCARDNO Then
                EDIT = True
                DESIGNCARDCOST_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDWARP.RowCount = 0 And TEMPCARDNO < MAXNO Then
                TXTCOSTNO.Text = TEMPCARDNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Design Card Issue?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJCARD As New ClsDesignCardCost
                ALPARAVAL.Add(TEMPCARDNO)
                ALPARAVAL.Add(YearId)
                OBJCARD.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJCARD.DELETE()
                MsgBox("Entry Deleted Succesfully")
                CLEAR()
                EDIT = False
                CMBDESIGNNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub COSTDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles COSTDATE.GotFocus
        COSTDATE.SelectAll()
    End Sub

    Private Sub COSTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles COSTDATE.Validating
        Try
            If COSTDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(COSTDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(sender As Object, e As CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGNNO, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validated(sender As Object, e As EventArgs) Handles CMBDESIGNNO.Validated
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then

                'CHECK WHETHER COST FOR SAME DESIGN IS MADE OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                If EDIT = False Then
                    DT = OBJCMN.search("ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO", "", "DESIGNCARDCOST INNER JOIN DESIGNMASTER ON DESIGNCARDCOST_DESIGNID = DESIGNMASTER.DESIGN_ID ", " AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND DESIGNCARDCOST.DESIGNCARDCOST_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Cost for This Design already made", MsgBoxStyle.Critical)
                        CMBDESIGNNO.Text = ""
                        Exit Sub
                    End If
                End If

                CMBDESIGNNO.Enabled = False

                    GRIDSELVEDGE.RowCount = 0
                    GRIDWARP.RowCount = 0
                    GRIDWEFT.RowCount = 0

                    Dim TCID As Integer = 0
                    DT = OBJCMN.search(" TOP 1 DESIGNCARD.DESIGNCARD_ID AS CARDID, DESIGNMASTER.DESIGN_NO AS DESIGNNO, ITEMMASTER.ITEM_NAME AS ITEMNAME, CATEGORYMASTER.CATEGORY_NAME AS CATEGORY, COLORMASTER.COLOR_name AS MATCHING, DESIGNCARD.DESIGNCARD_WARPTL AS WARPTL, DESIGNCARD.DESIGNCARD_WEFTTL AS WEFTTL, DESIGNCARD.DESIGNCARD_REED AS REED, DESIGNCARD.DESIGNCARD_REEDSPACE AS REEDSPACE, DESIGNCARD.DESIGNCARD_PICKS AS PICKS, DESIGNCARD.DESIGNCARD_TOTALWT AS TOTALWT, DESIGNCARD.DESIGNCARD_TOTALSELENDS AS TOTALSELENDS, DESIGNCARD.DESIGNCARD_TOTALSELWT AS TOTALSELWT, DESIGNCARD.DESIGNCARD_TOTALWARPENDS AS TOTALWARPENDS, DESIGNCARD.DESIGNCARD_TOTALWARPWT AS TOTALWARPWT, DESIGNCARD.DESIGNCARD_TOTALWEFTPICKS AS TOTALWEFTPICK, DESIGNCARD.DESIGNCARD_TOTALWEFTWT AS TOTALWEFTWT ", "", " DESIGNCARD INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN COLORMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = COLORMASTER.COLOR_id INNER JOIN ITEMMASTER ON DESIGNMASTER.DESIGN_ITEMID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = CATEGORYMASTER.CATEGORY_ID ", " AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        TCID = Val(DT.Rows(0).Item("CARDID"))
                        TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                        TXTCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
                        TXTWARPTL.Text = Val(DT.Rows(0).Item("WARPTL"))
                        TXTWEFTTL.Text = Val(DT.Rows(0).Item("WEFTTL"))
                        TXTPICKS.Text = Val(DT.Rows(0).Item("PICKS"))
                        TXTREED.Text = DT.Rows(0).Item("REED")
                        TXTREEDSPACE.Text = Val(DT.Rows(0).Item("REEDSPACE"))
                    End If


                    'SELVEDGE GRID
                    DT = OBJCMN.search(" DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNQUALITYMASTER.YARN_DENIER,0) AS DENIER, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELENDS AS ENDS, DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT AS WT, ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0) AS RATE, (ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0)*ISNULL(HSNMASTER.HSN_IGST,0)/100)+ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0) AS RATEGST  ", "", " DESIGNCARD_SELVEDGEDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN HSNMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID ", " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_YEARID = " & YearId & " ORDER BY DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSRNO")
                    If DT.Rows.Count > 0 Then
                        For Each ROW As DataRow In DT.Rows
                            GRIDSELVEDGE.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(ROW("DENIER")), Val(ROW("ENDS")), Val(ROW("WT")), Val(ROW("RATE")), Val(ROW("RATEGST")), 0, 0, 0)
                        Next
                    End If


                    'WARPGRID
                    DT = OBJCMN.search(" DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNQUALITYMASTER.YARN_DENIER,0) AS DENIER, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPENDS AS ENDS, DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT AS WT, ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0) AS RATE, (ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0)*ISNULL(HSNMASTER.HSN_IGST,0)/100)+ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0) AS RATEGST  ", "", " DESIGNCARD_WARPDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN HSNMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID ", " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_WARPDETAILS.DESIGNCARD_YEARID = " & YearId & " ORDER BY DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSRNO")
                    If DT.Rows.Count > 0 Then
                        For Each ROW As DataRow In DT.Rows
                            GRIDWARP.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(ROW("DENIER")), Val(ROW("ENDS")), Val(ROW("WT")), Val(ROW("RATE")), Val(ROW("RATEGST")), 0, 0, 0)
                        Next
                    End If


                    'WEFT
                    DT = OBJCMN.search(" DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, ISNULL(YARNQUALITYMASTER.YARN_DENIER,0) AS DENIER, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTPICK AS PICK, DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT AS WT, ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0) AS RATE, (ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0)*ISNULL(HSNMASTER.HSN_IGST,0)/100)+ISNULL(YARNQUALITYMASTER.YARN_COSTRATE,0) AS RATEGST  ", "", " DESIGNCARD_WEFTDETAILS INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN HSNMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID  ", " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID = " & Val(TCID) & " AND DESIGNCARD_WEFTDETAILS.DESIGNCARD_YEARID = " & YearId & " ORDER BY DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSRNO")
                    If DT.Rows.Count > 0 Then
                        For Each ROW As DataRow In DT.Rows
                            GRIDWEFT.Rows.Add(Val(ROW("SRNO")), ROW("YARNQUALITY"), ROW("SHADE"), Val(ROW("DENIER")), Val(ROW("PICK")), Val(ROW("WT")), Val(ROW("RATE")), Val(ROW("RATEGST")), 0, 0, 0)
                        Next
                    End If



                    'GET ACTUAL WT FROM GREY RECD FROM WEAVER WITH RESPECT TO SELSECTED DESIGNNO
                    DT = OBJCMN.search(" (CASE WHEN ISNULL(SUM(GREY_MTRS),0) > 0 THEN (ISNULL(SUM(GREY_OURWT),0)/ISNULL(SUM(GREY_MTRS),0)) * 100 ELSE 0 END) AS OURWT", "", " GREYRECDKNITTING_DESC INNER JOIN DESIGNMASTER ON GREY_DESIGNID = DESIGNMASTER.DESIGN_ID", " AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND GREY_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTTOTALACTUALWT.Text = Format(Val(DT.Rows(0).Item("OURWT")), "0.00")



                    'GET ACTUAL PICKS,  RATE AND BOBIN CHARGES FROM DESIGNCARD ISSUE GET LAST ENTRY OF THIS DESIGN
                    DT = OBJCMN.search("  TOP 1 ISNULL(CARD_ACTUALPICKS,0) AS ACTUALPICKS, ISNULL(CARD_RATE,0) AS RATE, ISNULL(CARD_BOBBINCHGS,0) AS BOBCHGS, ISNULL(CARD_OTHERCHGS,0) AS OTHERCHGS ", "", " DESIGNCARDISSUE_DESC INNER JOIN DESIGNMASTER ON CARD_DESIGNID = DESIGNMASTER.DESIGN_ID ", " AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND CARD_YEARID = " & YearId & " ORDER BY DESIGNCARDISSUE_DESC.CARD_NO DESC ")
                    If DT.Rows.Count > 0 Then
                        TXTACTUALPICKS.Text = Val(DT.Rows(0).Item("ACTUALPICKS"))
                        TXTWEAVING.Text = Format(Val(DT.Rows(0).Item("RATE")), "0.00")
                        TXTBOBINCOST.Text = Format(Val(DT.Rows(0).Item("BOBCHGS")), "0.00")
                        TXTBOBINACTUALCOST.Text = Format(Val(DT.Rows(0).Item("BOBCHGS")), "0.00")
                        TXTOTHERCOST.Text = Format(Val(DT.Rows(0).Item("OTHERCHGS")), "0.00")
                        TXTOTHERACTUALCOST.Text = Format(Val(DT.Rows(0).Item("OTHERCHGS")), "0.00")
                    End If

                    If Val(TXTACTUALPICKS.Text.Trim) = 0 Then TXTACTUALPICKS.Text = Val(TXTPICKS.Text.Trim)

                    TOTAL()
                End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTOTALACTUALWT_Validated(sender As Object, e As EventArgs) Handles TXTTOTALACTUALWT.Validated, TXTDHARA.Validated, TXTWASTAGE.Validated, TXTWEAVING.Validated, TXTBOBINCOST.Validated, TXTBOBINACTUALCOST.Validated, TXTOTHERCOST.Validated, TXTOTHERACTUALCOST.Validated, TXTMARGINCOST.Validated, TXTMARGINACTUALCOST.Validated, TXTACTUALPICKS.Validated
        TOTAL()
    End Sub

    Private Sub CMDCALC_Click(sender As Object, e As EventArgs) Handles CMDCALC.Click
        Try
            CMBDESIGNNO_Validated(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTOTALACTUALWT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTOTALACTUALWT.KeyPress, TXTDHARA.KeyPress, TXTWASTAGE.KeyPress, TXTWEAVING.KeyPress, TXTBOBINCOST.KeyPress, TXTBOBINACTUALCOST.KeyPress, TXTOTHERCOST.KeyPress, TXTOTHERACTUALCOST.KeyPress, TXTMARGINCOST.KeyPress, TXTMARGINACTUALCOST.KeyPress, TXTACTUALPICKS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDSELVEDGE_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDSELVEDGE.CellValidating
        Try
            Dim colNum As Integer = GRIDSELVEDGE.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case colNum

                Case SRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSELVEDGE.CurrentCell.Value = Nothing Then GRIDSELVEDGE.CurrentCell.Value = "0.00"
                        GRIDSELVEDGE.CurrentCell.Value = Convert.ToDecimal(GRIDSELVEDGE.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWARP_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDWARP.CellValidating
        Try
            Dim colNum As Integer = GRIDWARP.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case colNum

                Case WRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDWARP.CurrentCell.Value = Nothing Then GRIDWARP.CurrentCell.Value = "0.00"
                        GRIDWARP.CurrentCell.Value = Convert.ToDecimal(GRIDWARP.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWEFT_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDWEFT.CellValidating
        Try
            Dim colNum As Integer = GRIDWEFT.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case colNum

                Case FRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDWEFT.CurrentCell.Value = Nothing Then GRIDWEFT.CurrentCell.Value = "0.00"
                        GRIDWEFT.CurrentCell.Value = Convert.ToDecimal(GRIDWEFT.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXCEL_Click(sender As Object, e As EventArgs) Handles CMDEXCEL.Click
        Try
            If EDIT = False Then Exit Sub
            Dim OBJRPT As New clsReportDesigner("Design Card Costing", System.AppDomain.CurrentDomain.BaseDirectory & "Design Card Costing.xlsx", 2)
            OBJRPT.DESIGNCARDCOSTING_EXCEL(CmpId, YearId, TEMPCARDNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class