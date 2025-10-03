
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraGrid.Views.Grid

Public Class GDNDetails

    Public EDIT As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SALEOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SALEOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLCHALLANTYPE(CMBTYPE)
            If ClientName <> "SAFFRON" And ClientName <> "SAFFRONOFF" Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = ""
            If CHKFROM.CheckState = CheckState.Checked Then WHERECLAUSE = " and GDN_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND GDN_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" GDN.GDN_TYPENO AS TYPECHALLANNO, GDN.GDN_NO AS SRNO, ISNULL(GDN.GDN_TRANSREFNO, '') AS CHNO, GDN.GDN_date AS DATE, LEDGERS.Acc_cmpname AS CMPNAME, ISNULL(JOBBERLEDGERS.Acc_cmpname,'') AS JOBBERNAME, ISNULL(GDN.GDN_CONSIGNEE, '') AS CONSIGNEE, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENT, GDN.GDN_SONO AS SONO, GDN.GDN_SODATE AS SODATE, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, SUM(GDN_DESC.GDN_PCS) AS PCS, SUM(GDN_DESC.GDN_MTRS) AS MTRS, GDN.GDN_TOTALBALES AS TOTALBALES, GDN.GDN_BALENOFROM AS BALENOFROM, GDN_DESC.GDN_BALENO AS BALENO, ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS PACKING, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ISNULL(GDN.GDN_TRANSREMARKS,'') AS PARTYPONO, ISNULL(GDN_DESC.GDN_GRIDPARTYPONO,'') AS GRIDPARTYPONO, ISNULL(GDN.GDN_HOLDFORAPPROVAL,0) AS HOLDFORAPPROVAL, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSPORT  ", "", " GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_DESC ON GDN.GDN_NO = GDN_DESC.GDN_NO AND GDN.GDN_YEARID = GDN_DESC.GDN_YEARID INNER JOIN ITEMMASTER ON GDN_DESC.GDN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON GDN_DESC.GDN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GDN_DESC.GDN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON GDN.GDN_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON GDN.GDN_JOBBERID = JOBBERLEDGERS.Acc_id LEFT OUTER JOIN CHALLANTYPEMASTER ON CHALLANTYPEMASTER.CHALLANTYPE_ID = GDN.GDN_TYPEID LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON GDN.GDN_DISPATCHTOID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_transid = TRANSLEDGERS.Acc_id ", WHERECLAUSE & " AND GDN.GDN_YEARID = " & YearId & " GROUP BY GDN.GDN_NO, ISNULL(GDN.GDN_TRANSREFNO, ''), GDN.GDN_date, LEDGERS.Acc_cmpname, ISNULL(GDN.GDN_CONSIGNEE, ''), GDN.GDN_SONO, GDN.GDN_SODATE, ITEMMASTER.item_name,  ISNULL(DESIGNMASTER.DESIGN_NO, ''), GDN.GDN_TOTALBALES, GDN_DESC.GDN_BALENO, GDN.GDN_TYPENO, ISNULL(PACKINGLEDGERS.Acc_cmpname, ''), ISNULL(CATEGORYMASTER.category_name, ''),  ISNULL(GDN.GDN_TRANSREMARKS, ''), ISNULL(GDN.GDN_HOLDFORAPPROVAL, 0), GDN.GDN_BALENOFROM, ISNULL(GDN_DESC.GDN_GRIDPARTYPONO, ''), ISNULL(COLORMASTER.COLOR_name, ''), ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(JOBBERLEDGERS.Acc_cmpname, ''), ISNULL(AGENTLEDGERS.Acc_cmpname, '')")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal gdnno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New GDN
                objgdn.MdiParent = MDIMain
                objgdn.EDIT = editval
                objgdn.TEMPGDNNO = gdnno
                objgdn.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub TXTCOPIES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOPIES.Validating
        If Val(TXTCOPIES.Text.Trim) <= 0 Then TXTCOPIES.Text = 1
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress, TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            'If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0 Then Exit Sub

            'If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
            '    MsgBox("Enter Propoer Challan Nos", MsgBoxStyle.Critical)
            '    Exit Sub
            'Else
            '    If MsgBox("Wish To Print Challan from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            '    serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim))
            'End If

            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub

            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Challan Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish To Print Challan from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
                    serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim))
                End If
            Else
                If MsgBox("Wish To Print Selected Challan ?", MsgBoxStyle.YesNo) = vbYes Then
                    If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
                    SERVERPROPSELECTED(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim))
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop(ByVal fromno As Integer, ByVal tono As Integer, Optional ByVal NOOFCOPIES As Integer = 1, Optional ByVal FRMSTRING As String = "PRINT")
        Try
            Dim ALATTACHMENT As New ArrayList
            For I As Integer = fromno To tono

                '**************** SET SERVER ************************
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue

                Dim crtableLogonInfo As New TableLogOnInfo
                Dim crConnecttionInfo As New ConnectionInfo
                Dim crTables As Tables
                Dim crTable As Table

                With crConnecttionInfo
                    .ServerName = SERVERNAME
                    .DatabaseName = DatabaseName
                    .UserID = DBUSERNAME
                    .Password = Dbpassword
                    .IntegratedSecurity = Dbsecurity
                End With

                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions

                Dim OBJ As New Object
                OBJ = New GDNReport_COMMON
                If CHKWHITELABEL.Checked = True Then OBJ.DataDefinition.FormulaFields("WHITELABEL").Text = 1
                If FRMSTRING <> "PRINT" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"

                crTables = OBJ.Database.Tables
                For Each crTable In crTables
                    crtableLogonInfo = crTable.LogOnInfo
                    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                    crTable.ApplyLogOnInfo(crtableLogonInfo)
                Next

                OBJ.RecordSelectionFormula = "{GDN.GDN_no}=" & Val(I) & " And {GDN.GDN_yearid}=" & YearId

                If FRMSTRING = "PRINT" Then
                    OBJ.PrintOptions.PrinterName = PRINTDIALOG.PrinterSettings.PrinterName
                    If ClientName <> "AVIS" Then OBJ.PrintOptions.PaperSize = PaperSize.DefaultPaperSize Else OBJ.PrintOptions.PaperSize = PaperSize.PaperA5
                    OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\GDN_" & I & ".pdf"
                    expo = OBJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJ.Export()
                    ALATTACHMENT.Add(oDfDopt.DiskFileName)
                End If
            Next

            If FRMSTRING = "MAIL" Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Challan"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(ByVal fromno As Integer, ByVal tono As Integer, Optional ByVal NOOFCOPIES As Integer = 1, Optional ByVal FRMSTRING As String = "PRINT")
        Try

            Dim ALATTACHMENT As New ArrayList

            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                '**************** SET SERVER ************************
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue

                Dim crtableLogonInfo As New TableLogOnInfo
                Dim crConnecttionInfo As New ConnectionInfo
                Dim crTables As Tables
                Dim crTable As Table

                With crConnecttionInfo
                    .ServerName = SERVERNAME
                    .DatabaseName = DatabaseName
                    .UserID = DBUSERNAME
                    .Password = Dbpassword
                    .IntegratedSecurity = Dbsecurity
                End With

                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions


                Dim OBJ As New Object
                OBJ = New GDNReport_COMMON
                If CHKWHITELABEL.Checked = True Then OBJ.DataDefinition.FormulaFields("WHITELABEL").Text = 1
                    If FRMSTRING <> "PRINT" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"

                crTables = OBJ.Database.Tables
                For Each crTable In crTables
                    crtableLogonInfo = crTable.LogOnInfo
                    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                    crTable.ApplyLogOnInfo(crtableLogonInfo)
                Next

                OBJ.RecordSelectionFormula = "{GDN.GDN_no}=" & Val(ROW("SRNO")) & " And {GDN.GDN_yearid}=" & YearId

                If FRMSTRING = "PRINT" Then
                    OBJ.PrintOptions.PrinterName = PRINTDIALOG.PrinterSettings.PrinterName
                    If ClientName <> "AVIS" Then OBJ.PrintOptions.PaperSize = PaperSize.DefaultPaperSize Else OBJ.PrintOptions.PaperSize = PaperSize.PaperA5
                    OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\GDN_" & ROW("SRNO") & ".pdf"
                    expo = OBJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJ.Export()
                    ALATTACHMENT.Add(oDfDopt.DiskFileName)
                End If



                'Dim OBJINVOICE As New saledesign
                'OBJINVOICE.MdiParent = MDIMain
                'OBJINVOICE.DIRECTPRINT = True
                'OBJINVOICE.FRMSTRING = "INVOICE"
                'OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                'Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search("ISNULL(STATE_REMARK,'') AS STATECODE", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATE_ID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID ", " AND INVOICEMASTER.INVOICE_NO = " & Val(ROW("SRNO")) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
            'If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("STATECODE") <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
            'OBJINVOICE.registername = cmbregister.Text.Trim
            'OBJINVOICE.PRINTSETTING = PrintDialog
            'OBJINVOICE.INVNO = Val(ROW("SRNO"))
            'OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
            'OBJINVOICE.Show()
            'OBJINVOICE.Close()
            'ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If FRMSTRING = "MAIL" Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Challan"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Challan Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Challan Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Challan Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Challan Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub GDNDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                CMBTYPE.Visible = True
                LBLTYPE.Visible = True
                GTYPECHALLANNO.Visible = True
                GTYPECHALLANNO.VisibleIndex = 0
                gsrno.Visible = False
                GCHALLANNO.Caption = "Ref No."
                CMBTYPE.Focus()
            End If

            If ClientName = "DJIMPEX" Then
                GCHALLANNO.Caption = "Gross Wt"
                GBALENOFROM.Caption = "Container No"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If CMBTYPE.Text <> "" And (ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF") Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMAIL.Click
        Try
            'If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0 Then Exit Sub

            'If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
            '    MsgBox("Enter Propoer Challan Nos", MsgBoxStyle.Critical)
            '    Exit Sub
            'Else
            '    If MsgBox("Wish to Mail Challan from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            '    serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim), "MAIL")
            'End If

            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Challan Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Challan from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim), "MAIL")
                End If
            Else
                If MsgBox("Wish to Mail Selected Challan ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim), "MAIL")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("HOLDFORAPPROVAL")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class