
Imports BL

Public Class YarnDyeingProgramFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public FRMSTRING As String

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
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry CREDITORS' AND ACC_TYPE='AGENT'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SOFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
            FILLGRID()

            If FRMSTRING = "YARNPO" Then
                Me.Text = "Yarn Purchase Order Filter"
                LBLNO.Text = "PO No"
                GPFROMQUALITY.Visible = False
                GPFROMSHADE.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim OBJYARN As New YarnDesign
            OBJYARN.MdiParent = MDIMain

            If FRMSTRING = "YARNPROG" Then
                OBJYARN.WHERECLAUSE = " {ALLYARNDYEINGPROGRAM.PROG_yearid}=" & YearId
                If Val(TXTPROGRAMNO.Text.Trim) <> 0 Then OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {ALLYARNDYEINGPROGRAM.PROG_NO}=" & Val(TXTPROGRAMNO.Text.Trim)
                If RDBPENDING.Checked = True Then
                    OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {@BALANCE} > 0 and {ALLYARNDYEINGPROGRAM_DESC.PROG_CLOSED}=FALSE "
                    OBJYARN.PENDINGPROG = "PENDING"
                End If
                If RDBCOMPLETE.Checked = True Then
                    OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {@BALANCE} <= 0 and {ALLYARNDYEINGPROGRAM_DESC.PROG_CLOSED}=FALSE "
                    OBJYARN.PENDINGPROG = "COMPLETED"
                End If
                If RDBCLOSED.Checked = True Then OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {ALLYARNDYEINGPROGRAM_DESC.PROG_CLOSED}=true "


                'FOR FROMYARNQUALITY
                GRIDBILLQUALITY.ClearColumnsFilter()
                Dim ITEMCLAUSE As String = ""
                For i As Integer = 0 To GRIDBILLQUALITY.RowCount - 1
                    Dim dtrow As DataRow = GRIDBILLQUALITY.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If ITEMCLAUSE = "" Then
                            ITEMCLAUSE = " AND ({FROMYARNQUALITYMASTER.YARN_NAME} = '" & dtrow("YARNQUALITY") & "'"
                        Else
                            ITEMCLAUSE = ITEMCLAUSE & " OR {FROMYARNQUALITYMASTER.YARN_NAME} = '" & dtrow("YARNQUALITY") & "'"
                        End If
                    End If
                Next
                If ITEMCLAUSE <> "" Then
                    ITEMCLAUSE = ITEMCLAUSE & ")"
                    OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & ITEMCLAUSE
                End If




                'FOR FROM COLOR
                gridbillcolor.ClearColumnsFilter()
                Dim COLORCLAUSE As String = ""
                For i As Integer = 0 To gridbillcolor.RowCount - 1
                    Dim dtrow As DataRow = gridbillcolor.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If COLORCLAUSE = "" Then
                            COLORCLAUSE = " AND ({FROMCOLORMASTER.COLOR_NAME} = '" & dtrow("COLOR") & "'"
                        Else
                            COLORCLAUSE = COLORCLAUSE & " OR {FROMCOLORMASTER.COLOR_NAME} = '" & dtrow("COLOR") & "'"
                        End If
                    End If
                Next
                If COLORCLAUSE <> "" Then
                    COLORCLAUSE = COLORCLAUSE & ")"
                    OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & COLORCLAUSE
                End If


                If RDBPARTYDTLS.Checked = True Then
                    OBJYARN.FRMSTRING = "DYEINGPROGPARTY"
                End If


            Else
                OBJYARN.WHERECLAUSE = " {ALLYARNPURCHASEORDER.YPO_yearid}=" & YearId
                If Val(TXTPROGRAMNO.Text.Trim) <> 0 Then OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {ALLYARNPURCHASEORDER.YPO_NO}=" & Val(TXTPROGRAMNO.Text.Trim)
                If RDBPENDING.Checked = True Then
                    OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {@BALANCE} > 0 and {ALLYARNPURCHASEORDER_DESC.YPO_CLOSED}=FALSE "
                    OBJYARN.PENDINGPROG = "PENDING"
                End If
                If RDBCOMPLETE.Checked = True Then
                    OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {@BALANCE} <= 0 and {ALLYARNPURCHASEORDER_DESC.YPO_CLOSED}=FALSE "
                    OBJYARN.PENDINGPROG = "COMPLETED"
                End If
                If RDBCLOSED.Checked = True Then OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {ALLYARNPURCHASEORDER_DESC.YPO_CLOSED}=true "

                If RDBPARTYDTLS.Checked = True Then
                    OBJYARN.FRMSTRING = "YARNPOPARTY"
                End If
            End If



            If chkdate.Checked = True Then
                getFromToDate()
                OBJYARN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJYARN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If


            If CMBAGENT.Text <> "" Then OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & " and {BROKERLEDERS.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"



            'FOR PARTYNAME
            gridbill.ClearColumnsFilter()
            Dim NAMECLAUSE As String = ""
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then
                        NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    Else
                        NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next
            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & NAMECLAUSE
            End If



            'FOR DELIVERYPARTYNAME
            GRIDBILLDELIVERYAT.ClearColumnsFilter()
            Dim GRIDNAMECLAUSE As String = ""
            For i As Integer = 0 To GRIDBILLDELIVERYAT.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLDELIVERYAT.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If GRIDNAMECLAUSE = "" Then
                        GRIDNAMECLAUSE = " AND ({GRIDLEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    Else
                        GRIDNAMECLAUSE = GRIDNAMECLAUSE & " OR {GRIDLEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next
            If GRIDNAMECLAUSE <> "" Then
                GRIDNAMECLAUSE = GRIDNAMECLAUSE & ")"
                OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & GRIDNAMECLAUSE
            End If


            'FOR MILLNAME
            GRIDBILLMILL.ClearColumnsFilter()
            Dim MILLCLAUSE As String = ""
            For i As Integer = 0 To GRIDBILLMILL.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLMILL.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If MILLCLAUSE = "" Then
                        MILLCLAUSE = " AND ({MILLMASTER.MILL_NAME} = '" & dtrow("MILLNAME") & "'"
                    Else
                        MILLCLAUSE = MILLCLAUSE & " OR {MILLMASTER.MILL_NAME} = '" & dtrow("MILLNAME") & "'"
                    End If
                End If
            Next
            If MILLCLAUSE <> "" Then
                MILLCLAUSE = MILLCLAUSE & ")"
                OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & MILLCLAUSE
            End If



            'FOR YARNQUALITY
            GRIDBILLGRIDYARNQUALITY.ClearColumnsFilter()
            Dim GRIDITEMCLAUSE As String = ""
            For i As Integer = 0 To GRIDBILLGRIDYARNQUALITY.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLGRIDYARNQUALITY.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If GRIDITEMCLAUSE = "" Then
                        GRIDITEMCLAUSE = " AND ({YARNQUALITYMASTER.YARN_NAME} = '" & dtrow("YARNQUALITY") & "'"
                    Else
                        GRIDITEMCLAUSE = GRIDITEMCLAUSE & " OR {YARNQUALITYMASTER.YARN_NAME} = '" & dtrow("YARNQUALITY") & "'"
                    End If
                End If
            Next
            If GRIDITEMCLAUSE <> "" Then
                GRIDITEMCLAUSE = GRIDITEMCLAUSE & ")"
                OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & GRIDITEMCLAUSE
            End If




            'FOR COLOR
            GRIDBILLGRIDCOLOR.ClearColumnsFilter()
            Dim GRIDCOLORCLAUSE As String = ""
            For i As Integer = 0 To GRIDBILLGRIDCOLOR.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLGRIDCOLOR.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If GRIDCOLORCLAUSE = "" Then
                        GRIDCOLORCLAUSE = " AND ({COLORMASTER.COLOR_NAME} = '" & dtrow("COLOR") & "'"
                    Else
                        GRIDCOLORCLAUSE = GRIDCOLORCLAUSE & " OR {COLORMASTER.COLOR_NAME} = '" & dtrow("COLOR") & "'"
                    End If
                End If
            Next
            If GRIDCOLORCLAUSE <> "" Then
                GRIDCOLORCLAUSE = GRIDCOLORCLAUSE & ")"
                OBJYARN.WHERECLAUSE = OBJYARN.WHERECLAUSE & GRIDCOLORCLAUSE
            End If


            OBJYARN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

            Dim DTDELIVERYAT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            GRIDBILLDETAILSDELIVERYAT.DataSource = DTDELIVERYAT
            If DTDELIVERYAT.Rows.Count > 0 Then
                GRIDBILLDELIVERYAT.FocusedRowHandle = GRIDBILLDELIVERYAT.RowCount - 1
                GRIDBILLDELIVERYAT.TopRowIndex = GRIDBILLDELIVERYAT.RowCount - 15
            End If

            Dim DTMILL As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, MILLMASTER.MILL_NAME AS MILLNAME ", " ", " MILLMASTER ", " AND MILLMASTER.MILL_YEARID = '" & YearId & "' ORDER BY MILLMASTER.MILL_NAME")
            GRIDBILLDETAILSMILL.DataSource = DTMILL
            If DTMILL.Rows.Count > 0 Then
                GRIDBILLMILL.FocusedRowHandle = GRIDBILLMILL.RowCount - 1
                GRIDBILLMILL.TopRowIndex = GRIDBILLMILL.RowCount - 15
            End If

            Dim DTYARNQUALITY As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY ", " ", " YARNQUALITYMASTER ", " AND YARNQUALITYMASTER.YARN_YEARID = '" & YearId & "' ORDER BY YARNQUALITYMASTER.YARN_NAME")
            GRIDBILLDETAILSQUALITY.DataSource = DTYARNQUALITY
            If DTYARNQUALITY.Rows.Count > 0 Then
                GRIDBILLQUALITY.FocusedRowHandle = GRIDBILLQUALITY.RowCount - 1
                GRIDBILLQUALITY.TopRowIndex = GRIDBILLQUALITY.RowCount - 15
            End If

            Dim DTCOLOR As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, COLORMASTER.COLOR_NAME AS COLOR ", " ", " COLORMASTER ", " AND COLORMASTER.COLOR_YEARID = '" & YearId & "' ORDER BY COLORMASTER.COLOR_NAME")
            gridbilldetailscolor.DataSource = DTCOLOR
            If DTCOLOR.Rows.Count > 0 Then
                gridbillcolor.FocusedRowHandle = gridbillcolor.RowCount - 1
                gridbillcolor.TopRowIndex = gridbillcolor.RowCount - 15
            End If

            Dim DTGRIDYARNQUALITY As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, YARNQUALITYMASTER.YARN_NAME AS YARNQUALITY ", " ", " YARNQUALITYMASTER ", " AND YARNQUALITYMASTER.YARN_YEARID = '" & YearId & "' ORDER BY YARNQUALITYMASTER.YARN_NAME")
            GRIDBILLDETAILSGRIDYARNQUALITY.DataSource = DTGRIDYARNQUALITY
            If DTGRIDYARNQUALITY.Rows.Count > 0 Then
                GRIDBILLGRIDYARNQUALITY.FocusedRowHandle = GRIDBILLGRIDYARNQUALITY.RowCount - 1
                GRIDBILLGRIDYARNQUALITY.TopRowIndex = GRIDBILLGRIDYARNQUALITY.RowCount - 15
            End If

            Dim DTGRIDCOLOR As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, COLORMASTER.COLOR_NAME AS COLOR ", " ", " COLORMASTER ", " AND COLORMASTER.COLOR_YEARID = '" & YearId & "' ORDER BY COLORMASTER.COLOR_NAME")
            GRIDBILLDETAILSGRIDCOLOR.DataSource = DTGRIDCOLOR
            If DTGRIDCOLOR.Rows.Count > 0 Then
                GRIDBILLGRIDCOLOR.FocusedRowHandle = GRIDBILLGRIDCOLOR.RowCount - 1
                GRIDBILLGRIDCOLOR.TopRowIndex = GRIDBILLGRIDCOLOR.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTNAME_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTNAME.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = CHKSELECTNAME.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTDELIVERYAT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTDELIVERYAT.CheckedChanged
        Try
            For i As Integer = 0 To GRIDBILLDELIVERYAT.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLDELIVERYAT.GetDataRow(i)
                dtrow("CHK") = CHKSELECTDELIVERYAT.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTMILL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTMILL.CheckedChanged
        Try
            For i As Integer = 0 To GRIDBILLMILL.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLMILL.GetDataRow(i)
                dtrow("CHK") = CHKSELECTMILL.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTQUALITY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTQUALITY.CheckedChanged
        Try
            For i As Integer = 0 To GRIDBILLQUALITY.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLQUALITY.GetDataRow(i)
                dtrow("CHK") = CHKSELECTQUALITY.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTCOLOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTCOLOR.CheckedChanged
        Try
            For i As Integer = 0 To gridbillcolor.RowCount - 1
                Dim dtrow As DataRow = gridbillcolor.GetDataRow(i)
                dtrow("CHK") = CHKSELECTCOLOR.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTGRIDQUALITY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTGRIDQUALITY.CheckedChanged
        Try
            For i As Integer = 0 To GRIDBILLGRIDYARNQUALITY.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLGRIDYARNQUALITY.GetDataRow(i)
                dtrow("CHK") = CHKSELECTGRIDQUALITY.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTGRIDCOLOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTGRIDCOLOR.CheckedChanged
        Try
            For i As Integer = 0 To GRIDBILLGRIDCOLOR.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLGRIDCOLOR.GetDataRow(i)
                dtrow("CHK") = CHKSELECTGRIDCOLOR.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class