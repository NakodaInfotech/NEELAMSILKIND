
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Public Class GDNDESIGN

    Public FORMULA As String

    Dim RPTJO As New JOReport_COMMON
    Dim RPTJI As New JobInReport_COMMON
    Dim RPTGDN As New GDNReport_COMMON
    Dim RPTTRANSGDN As New GDNTransReport
    Dim RPTGODOWNTRANSFER As New GodownTransferReport
    Dim RPTPS As New PackingSlipReport


    Dim rptdispatchpartywise As New DispatchReportPartywise
    Dim rptdispatchpartydetails As New DispatchReportPartywiseDetailed
    Dim rptdispatchdesignwise As New DispatchReportDesignwise
    Dim rptdispatchdesigndetails As New DispatchReportDesignwiseDetailed

    Dim RPTPENDINGDTLC As New PendingDetailsReport
    Dim RPTDAILYACT As New DailyActivityReport

    Dim RPTPROFORMA As New ProformaReport


    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    ' Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String
    Public agentname As String
    'NEWLY ADDED

    Public FRMSTRING As String
    Public FROMDATE As String
    Public TODATE As String
    Public OPENINGDATE As String
    Public selfor_ss As String
    Public PERIOD As String
    Public HIDEPCSDETAILS As Boolean = False
    Public WHITELABEL As Boolean = False
    Public GSTRPT As Boolean = False
    Public PRINTINYARDS As Boolean = True

    Private Sub GDNDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            '**************** SET SERVER ************************
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

            If FRMSTRING = "PARTYWISE" Then
                crpo.ReportSource = rptdispatchpartywise
                crTables = rptdispatchpartywise.Database.Tables
            ElseIf FRMSTRING = "PARTYWISEDETAILS" Then
                crpo.ReportSource = rptdispatchpartydetails
                crTables = rptdispatchpartydetails.Database.Tables
            ElseIf FRMSTRING = "DESIGNWISE" Then
                crpo.ReportSource = rptdispatchdesignwise
                crTables = rptdispatchdesignwise.Database.Tables
            ElseIf FRMSTRING = "DESIGNWISEDETAILS" Then
                crpo.ReportSource = rptdispatchdesigndetails
                crTables = rptdispatchdesigndetails.Database.Tables

            ElseIf FRMSTRING = "JOBOUT" Then
                crTables = RPTJO.Database.Tables

            ElseIf FRMSTRING = "JOBIN" Then
                crTables = RPTJI.Database.Tables

            ElseIf FRMSTRING = "PACKINGSLIP" Then
                crTables = RPTPS.Database.Tables

            ElseIf FRMSTRING = "GDN" Then
                crTables = RPTGDN.Database.Tables


            ElseIf FRMSTRING = "PROFORMA" Then
                crTables = RPTPROFORMA.Database.Tables

            ElseIf FRMSTRING = "GODOWNTRANSFER" Then
                crTables = RPTGODOWNTRANSFER.Database.Tables


            ElseIf FRMSTRING = "TRANSGDN" Then
                crTables = RPTTRANSGDN.Database.Tables

            ElseIf FRMSTRING = "PENDINGDETAILS" Then
                crpo.ReportSource = RPTPENDINGDTLC
                crTables = RPTPENDINGDTLC.Database.Tables

            ElseIf FRMSTRING = "DAILYACTIVITY" Then
                crpo.ReportSource = RPTDAILYACT
                crTables = RPTDAILYACT.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If FRMSTRING = "GDN" Or FRMSTRING = "PROFORMA" Or FRMSTRING = "TRANSGDN" Or FRMSTRING = "JOBOUT" Or FRMSTRING = "JOBIN" Or FRMSTRING = "PACKINGSLIP" Or FRMSTRING = "GATEPASS" Or FRMSTRING = "GPPACKINGSLIP" Or FRMSTRING = "GPEXPPACKINGSLIP" Then crpo.SelectionFormula = FORMULA
            If FRMSTRING = "PARTYWISE" Or FRMSTRING = "PARTYWISEDETAILS" Or FRMSTRING = "DESIGNWISE" Or FRMSTRING = "DESIGNWISEDETAILS" Or FRMSTRING = "PENDINGDETAILS" Or FRMSTRING = "DAILYACTIVITY" Then crpo.SelectionFormula = selfor_ss


            If FRMSTRING = "JOBOUT" Then
                crpo.ReportSource = RPTJO
                If GSTRPT = True Then RPTJO.DataDefinition.FormulaFields("GSTRPT").Text = 1 Else RPTJO.DataDefinition.FormulaFields("GSTRPT").Text = 0

            ElseIf FRMSTRING = "JOBIN" Then
                crpo.ReportSource = RPTJI

            ElseIf FRMSTRING = "PARTYWISE" Then
                crpo.ReportSource = rptdispatchpartywise
            ElseIf FRMSTRING = "PARTYWISEDETAILS" Then
                crpo.ReportSource = rptdispatchpartydetails
            ElseIf FRMSTRING = "DESIGNWISE" Then
                crpo.ReportSource = rptdispatchdesignwise
            ElseIf FRMSTRING = "DESIGNWISEDETAILS" Then
                crpo.ReportSource = rptdispatchdesigndetails

            ElseIf FRMSTRING = "PACKINGSLIP" Then
                crpo.ReportSource = RPTPS
                If WHITELABEL = True Then RPTPS.DataDefinition.FormulaFields("WHITELABEL").Text = 1


            ElseIf FRMSTRING = "GDN" Then
                If WHITELABEL = True Then RPTGDN.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTGDN.DataDefinition.FormulaFields("WHITELABEL").Text = 0
                If HIDEPCSDETAILS = True Then RPTGDN.DataDefinition.FormulaFields("HIDEPCSDETAILS").Text = 1 Else RPTGDN.DataDefinition.FormulaFields("HIDEPCSDETAILS").Text = 0
                crpo.ReportSource = RPTGDN


            ElseIf FRMSTRING = "PROFORMA" Then
                crpo.ReportSource = RPTPROFORMA

            ElseIf FRMSTRING = "GODOWNTRANSFER" Then
                crpo.ReportSource = RPTGODOWNTRANSFER


            ElseIf FRMSTRING = "TRANSGDN" Then
                crpo.ReportSource = RPTTRANSGDN

            ElseIf FRMSTRING = "PENDINGDETAILS" Then
                crpo.ReportSource = RPTPENDINGDTLC

            ElseIf FRMSTRING = "DAILYACTIVITY" Then
                crpo.ReportSource = RPTDAILYACT
                RPTDAILYACT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            '************************ END *******************
            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Dim EMAILID1 As String = ""
           System.WINDOWS.FORMS.Cursor.Current = Cursors.WaitCursor
            Transfer()


            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            If agentname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & agentname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    EMAILID1 = dt.Rows(0).Item(0).ToString
                End If
            End If
            Dim objmail As New SendMail

            'tempattachment = "GDN"
            If FRMSTRING = "JOBIN" Then
                tempattachment = "JOBIN"
                objmail.subject = "Job In"
            ElseIf FRMSTRING = "JOBOUT" Then
                tempattachment = "JOBOUT"
                objmail.subject = "Job Challan"
            ElseIf FRMSTRING = "GDN" Then
                tempattachment = "GDN"
                objmail.subject = "Challan"
            ElseIf FRMSTRING = "TRANSGDN" Then
                tempattachment = "TRANSGDN"
                objmail.subject = "Transport Challan"
            ElseIf FRMSTRING = "PROFORMA" Then
                tempattachment = "PROFORMA"
                objmail.subject = "Proforma"
            ElseIf FRMSTRING = "GODOWNTRANSFER" Then
                tempattachment = "GODOWNTRANSFER"
                objmail.subject = "Godown Transfer Voucher"
            ElseIf FRMSTRING = "PENDINGDETAILS" Then
                tempattachment = "PENDINGDETAILS"
                objmail.subject = "PENDINGDETAILS"
            ElseIf FRMSTRING = "DAILYACTIVITY" Then
                tempattachment = "DAILYACTIVITY"
                objmail.subject = "DAILYACTIVITY"
            ElseIf FRMSTRING = "GATEPASS" Then
                tempattachment = "GATEPASS"
                objmail.subject = "GATEPASS"
            ElseIf FRMSTRING = "GPPACKINGSLIP" Or FRMSTRING = "GPEXPPACKINGSLIP" Then
                tempattachment = "PACKINGSLIP"
                objmail.subject = "PACKINGSLIP"
            End If

            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"

            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If

            If EMAILID1 <> "" Then
                objmail.cmbsecondadd.Text = EMAILID1
            End If
            objmail.Show()
            objmail.BringToFront()
           System.WINDOWS.FORMS.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "GDN" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\GDN.PDF"

                RPTGDN.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = RPTGDN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDN.Export()
                RPTGDN.DataDefinition.FormulaFields("SENDMAIL").Text = "0"


            ElseIf FRMSTRING = "PROFORMA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\PROFORMA.PDF"
                expo = RPTPROFORMA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPROFORMA.Export()

            ElseIf FRMSTRING = "GODOWNTRANSFER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\GODOWNTRANSFER.PDF"
                expo = RPTGODOWNTRANSFER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGODOWNTRANSFER.Export()



            ElseIf FRMSTRING = "JOBIN" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\JOBIN.pdf"
                expo = RPTJI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTJI.Export()


            ElseIf FRMSTRING = "JOBOUT" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\JOBOUT.pdf"
                expo = RPTJO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTJO.Export()

            ElseIf FRMSTRING = "PENDINGDETAILS" Then
                expo = RPTPENDINGDTLC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPENDINGDTLC.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If Val(TXTCOPIES.Text.Trim) <= 0 Then
                MsgBox("No of Copies cannot be zero", MsgBoxStyle.Critical)
                Exit Sub
            Else
                If FRMSTRING = "GDN" Then RPTGDN.PrintToPrinter(Val(TXTCOPIES.Text.Trim), True, 0, 0)
                If FRMSTRING = "PROFORMA" Then RPTPROFORMA.PrintToPrinter(Val(TXTCOPIES.Text.Trim), True, 0, 0)
                If FRMSTRING = "TRANSGDN" Then RPTTRANSGDN.PrintToPrinter(Val(TXTCOPIES.Text.Trim), True, 0, 0)
                If FRMSTRING = "JOBOUT" Then RPTJO.PrintToPrinter(Val(TXTCOPIES.Text.Trim), True, 0, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPIES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub GDNDESIGN_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            If ClientName = "DAKSH" Or ClientName = "SHALIBHADRA" Then
                PrintToolStripButton.Visible = True
                TXTCOPIES.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class