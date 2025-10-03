
Imports System.ComponentModel
Imports BL

Public Class JobberYarnStockFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, False)
            If CMBMILLNAME.Text.Trim = "" Then FILLMILL(CMBMILLNAME, False)
            If CMBSHADE.Text.Trim = "" Then FILLYARNCOLOR(CMBSHADE, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobberYarnStockFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
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

    Private Sub JobberYarnStockFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RBVIRTUALYARNSTOCK.Checked = True Then

                'NO NEED OF DATE CLAUSE HERE
                'THIS REPORTS WILL BE AS ON DATE

                'FIRST WE WILL ADD THE JOBBERVIRTUALSTOCK
                Dim OBJCMN As New ClsCommon
                Dim WHERECLAUSE As String = " AND YEARID = " & YearId
                Dim NAMECLAUSE As String = ""
                Dim CUTWASTAGECLAUSE As String = ""

                If CMBNAME.Text.Trim <> "" Then
                    WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
                    NAMECLAUSE = NAMECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'"
                End If
                If CMBYARNQUALITY.Text.Trim <> "" Then
                    WHERECLAUSE = WHERECLAUSE & " AND YARNQUALITY = '" & CMBYARNQUALITY.Text.Trim & "'"
                    CUTWASTAGECLAUSE = CUTWASTAGECLAUSE & " AND YARNQUALITYMASTER.YARN_NAME = '" & CMBYARNQUALITY.Text.Trim & "'"
                End If
                If CMBSHADE.Text.Trim <> "" Then
                    WHERECLAUSE = WHERECLAUSE & " AND COLOR = '" & CMBSHADE.Text.Trim & "'"
                    CUTWASTAGECLAUSE = CUTWASTAGECLAUSE & " AND COLORMASTER.COLOR_NAME = '" & CMBSHADE.Text.Trim & "'"
                End If
                Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPVIRTUALSTOCK WHERE YEARID = " & YearId, "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT * FROM JOBBERVIRTUALSTOCKREGISTER WHERE 1 = 1 " & WHERECLAUSE, "", "")


                'NOW WE WILL ADD THE WASTAGEENTRY OF THE WEAVER AFTER THE DATE WHEN WE HAVE DONE THE YARN WASTAGE ENTRY
                If Val(TXTWARPWASTAGE.Text.Trim) > 0 And Val(TXTWEFTWASTAGE.Text.Trim) > 0 Then
                    Dim DTNAME As DataTable = OBJCMN.Execute_Any_String(" SELECT DISTINCT LEDGERS.ACC_CMPNAME AS NAME FROM GREYRECDKNITTING INNER JOIN LEDGERS ON GREY_LEDGERID = LEDGERS.ACC_ID WHERE GREYRECDKNITTING.GREY_YEARID = " & YearId & NAMECLAUSE, "", "")
                    For Each DTROWNAME As DataRow In DTNAME.Rows

                        Dim LASTDATE As Date = AccFrom.Date
                        DT = OBJCMN.Execute_Any_String(" Select MAX(YWASJOBBER_DATE) As [DATE] FROM YARNWASTAGEJOBBER INNER JOIN LEDGERS On YARNWASTAGEJOBBER.YWASJOBBER_LEDGERID = Acc_id WHERE LEDGERS.ACC_CMPNAME = '" & DTROWNAME("NAME") & "' AND YARNWASTAGEJOBBER.YWASJOBBER_YEARID = " & YearId, "", "")
                        If DT.Rows.Count > 0 AndAlso IsDBNull(DT.Rows(0).Item("DATE")) = False Then LASTDATE = Convert.ToDateTime(DT.Rows(0).Item("DATE")).Date

                        Dim DTDESIGN As DataTable = OBJCMN.Execute_Any_String(" SELECT DESIGNMASTER.DESIGN_NO AS DESIGNNO, COLORMASTER.COLOR_NAME AS MATCHING, SUM(GREY_MTRS) AS RECDMTRS FROM GREYRECDKNITTING INNER JOIN GREYRECDKNITTING_DESC ON GREYRECDKNITTING.GREY_NO = GREYRECDKNITTING_DESC.GREY_NO AND GREYRECDKNITTING.GREY_YEARID = GREYRECDKNITTING_DESC.GREY_YEARID INNER JOIN LEDGERS ON GREY_LEDGERID = ACC_ID INNER JOIN DESIGNMASTER ON DESIGN_ID = GREY_DESIGNID INNER JOIN COLORMASTER ON GREYRECDKNITTING_DESC.GREY_COLORID = COLOR_ID WHERE GREYRECDKNITTING.GREY_YEARID = " & YearId & " AND GREYRECDKNITTING.GREY_DATE >='" & Format(LASTDATE.Date, "MM/dd/yyyy") & "' AND LEDGERS.ACC_CMPNAME = '" & DTROWNAME("NAME") & "' GROUP BY DESIGNMASTER.DESIGN_NO, COLORMASTER.COLOR_name ", "", "")
                        For Each DTROWDESIGN As DataRow In DTDESIGN.Rows

                            'GET WEFT DETAILS AND INSERT
                            DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, '" & Format(AccTo.Date, "MM/dd/yyyy") & "' AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & DTROWNAME("NAME") & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((" & Val(DTROWDESIGN("RECDMTRS")) & " * DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTWT / DESIGNCARD.DESIGNCARD_WEFTTL)* " & Val(TXTWEFTWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WEFTCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_WEFTDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WEFTDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WEFTDETAILS.DESIGNCARD_WEFTSHADEID = COLORMASTER.COLOR_id INNER JOIN DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & CUTWASTAGECLAUSE & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                            'GET WARP DETAILS AND INSERT
                            DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, '" & Format(AccTo.Date, "MM/dd/yyyy") & "' AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & DTROWNAME("NAME") & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((((" & Val(DTROWDESIGN("RECDMTRS")) & " *DESIGNCARD.DESIGNCARD_WARPTL)/DESIGNCARD.DESIGNCARD_WEFTTL) * DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPWT / DESIGNCARD.DESIGNCARD_WARPTL)* " & Val(TXTWARPWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WARPCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_WARPDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_WARPDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_WARPDETAILS.DESIGNCARD_WARPSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID  WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & CUTWASTAGECLAUSE & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                            'GET SELVEDGE DETAILS AND INSERT
                            DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPVIRTUALSTOCK SELECT 0 AS NO, '" & Format(AccTo.Date, "MM/dd/yyyy") & "' AS DATE, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY, '' AS MILLNAME, '" & DTROWNAME("NAME") & "', ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, 0 AS WT, SUM(ROUND(((((" & Val(DTROWDESIGN("RECDMTRS")) & " *DESIGNCARD.DESIGNCARD_WARPTL)/DESIGNCARD.DESIGNCARD_WEFTTL) * DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELWT / DESIGNCARD.DESIGNCARD_WARPTL)* " & Val(TXTWARPWASTAGE.Text.Trim) & ")/100, 2)) AS RECDWT, 'WARPCUTWASTAGE' AS ISSREC, " & CmpId & " AS CMPID, " & YearId & " AS YEARID, 'YARNWASTAGE' AS TYPE, '" & DTROWDESIGN("DESIGNNO") & "' FROM DESIGNCARD INNER JOIN DESIGNCARD_SELVEDGEDETAILS ON DESIGNCARD.DESIGNCARD_ID = DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_ID INNER JOIN YARNQUALITYMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNCARD_SELVEDGEDETAILS.DESIGNCARD_SELSHADEID = COLORMASTER.COLOR_id INNER JOIN  DESIGNMASTER ON DESIGNCARD.DESIGNCARD_DESIGNID = DESIGNMASTER.DESIGN_ID INNER JOIN COLORMASTER AS MATCHINGMASTER ON DESIGNCARD.DESIGNCARD_MATCHINGID = MATCHINGMASTER.COLOR_ID WHERE DESIGNMASTER.DESIGN_NO = '" & DTROWDESIGN("DESIGNNO") & "' AND MATCHINGMASTER.COLOR_NAME = '" & DTROWDESIGN("MATCHING") & "' AND DESIGNCARD.DESIGNCARD_YEARID = " & YearId & CUTWASTAGECLAUSE & " GROUP BY YARNQUALITYMASTER.YARN_NAME, ISNULL(COLORMASTER.COLOR_name, '') ", "", "")

                        Next
                    Next
                End If
                Dim OBJVSTOCK As New YarnStockDesign
                OBJVSTOCK.MdiParent = MDIMain
                OBJVSTOCK.WHERECLAUSE = " {TEMPVIRTUALSTOCK.YEARID}=" & YearId
                OBJVSTOCK.FRMSTRING = "VIRTUALSTOCK"
                OBJVSTOCK.FROMDATE = AccFrom.Date.AddDays(-1)
                OBJVSTOCK.TODATE = AccTo.Date
                OBJVSTOCK.WARPWASTAGEPER = Val(TXTWARPWASTAGE.Text.Trim) / 100
                OBJVSTOCK.WEFTWASTAGEPER = Val(TXTWEFTWASTAGE.Text.Trim) / 100
                OBJVSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                OBJVSTOCK.Show()
                Exit Sub
            End If


            If RBSTOCKONHAND.Checked = True Then
                Dim OBJYARNSTOCK As New JobberYarnStockOnHand
                OBJYARNSTOCK.MdiParent = MDIMain
                OBJYARNSTOCK.Show()
                Exit Sub
            End If


            Dim OBJSTOCK As New YarnStockDesign
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.WHERECLAUSE = " {JOBBERYARNSTOCKREGISTER.YEARID}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJSTOCK.FROMDATE = dtfrom.Value.Date
                OBJSTOCK.TODATE = dtto.Value.Date
                OBJSTOCK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                OBJSTOCK.FROMDATE = AccFrom.Date
                OBJSTOCK.TODATE = AccTo.Date
                OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBNAME.Text.Trim <> "" Then
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " And {JOBBERYARNSTOCKREGISTER.NAME}='" & CMBNAME.Text.Trim & "'"
                OBJSTOCK.PERIOD = " (" & UCase(CMBNAME.Text.Trim) & ") - " & OBJSTOCK.PERIOD
            End If
            If CMBYARNQUALITY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.YARNQUALITY}='" & CMBYARNQUALITY.Text.Trim & "'"
            If CMBMILLNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.MILLNAME}='" & CMBMILLNAME.Text.Trim & "'"
            If CMBSHADE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.COLOR}='" & CMBSHADE.Text.Trim & "'"

            If RBYARNQUALITYSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERQUALITYSTOCKSUMM"
            ElseIf RBDETAILS.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERSTOCKDTLS"
            ElseIf RBJOBBERSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERSTOCKSUMM"
            ElseIf RBSHADESUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERSHADESTOCKSUMM"
            ElseIf RBQUALITYSHADE.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERQUALITYSHADESTOCKSUMM"
            End If

            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, False)
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

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLYARNCOLOR(CMBSHADE, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then YARNCOLORVALIDATE(CMBSHADE, e, Me, CMBYARNQUALITY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, "  AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMILLNAME.Enter
        Try
            If CMBMILLNAME.Text.Trim = "" Then FILLMILL(CMBMILLNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILLNAME.Validating
        Try
            If CMBMILLNAME.Text.Trim <> "" Then MILLVALIDATE(CMBMILLNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWARPWASTAGE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTWARPWASTAGE.KeyPress, TXTWEFTWASTAGE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class