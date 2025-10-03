
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class payment_advice

    Public payno As Integer
    Public payname As String
    Public REGNAME As String
    Public FRMSTRING As String
    Public LEDGERSNAME As String
    Public NEFTRTGSNORMAL As String = "PARTY"
    Public FROMNO, TONO As Integer
    Public WHERECLAUSE As String = ""
    Public PERIOD As String = ""
    Public SHOWNARR As Integer = 0

    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public PRINTSETTING As Object = Nothing


    Dim obj_paytype As New Paymentreport
    Dim OBJPAYREG As New PaymentRegisterReport

    Dim OBJCHQPAY As New ChqPayment
    Dim OBJCHQPAY_UNION As New ChqPayment_UNION
    Dim OBJCHQPAY_INDUS As New ChqPayment_INDUS
    Dim OBJCHQPAY_KOTAK As New ChqPayment_KOTAK
    Dim OBJCHQPAY_CORP As New ChqPayment_CORPORATION
    Dim OBJCHQPAY_HDFC As New ChqPayment_HDFC
    Dim OBJCHQPAY_CITIBANK As New ChqPayment_CITIBANK
    Dim OBJCHQPAY_SYNDICATE As New ChqPayment_Syndicate
    Dim OBJCHQPAY_CANARA As New ChqPayment_Canara
    Dim OBJCHQPAY_ICICI As New ChqPayment_ICICI
    Dim OBJCHQPAY_STANDARD As New ChqPayment_STANDARDCHAR

    Dim OBJENVELOPE As New EnvelopeReport

    Private Sub payment_advice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
    End Sub

    Private Sub payment_advice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

        Try
            If DIRECTPRINT = True Then
                If FRMSTRING = "CHQPRINT" Then
                    PRINTDIRECTLYTOPRINTER()
                Else
                    PRINTDIRECTADVICE()
                End If
                Exit Sub
            End If


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

            If FRMSTRING = "CHQPRINT" Then
                If ClientName = "KCRAYON" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "AVIS" Or ClientName = "CC" Or ClientName = "DILIP" Or ClientName = "SHREEVALLABH" Or ClientName = "MOOLTEX" Or ClientName = "SUPRIYA" Then
                    crTables = OBJCHQPAY_HDFC.Database.Tables
                ElseIf ClientName = "MOHAN" Then
                    crTables = OBJCHQPAY_INDUS.Database.Tables
                ElseIf ClientName = "SAKARIA" Then
                    crTables = OBJCHQPAY_CITIBANK.Database.Tables
                ElseIf ClientName = "AXIS" Or ClientName = "SBA" Or ClientName = "INDRAPUJA" Then
                    crTables = OBJCHQPAY_UNION.Database.Tables
                ElseIf ClientName = "MASHOK" Or ClientName = "NVAHAN" Or ClientName = "KDFAB" Or ClientName = "SOFTAS" Or ClientName = "MYCOT" Or ClientName = "DRDRAPES" Or ClientName = "YUMILONE" Then
                    crTables = OBJCHQPAY_KOTAK.Database.Tables
                ElseIf ClientName = "CHANDRA" Then
                    crTables = OBJCHQPAY_SYNDICATE.Database.Tables
                ElseIf ClientName = "DEVEN" Or ClientName = "ALENCOT" Then
                    crTables = OBJCHQPAY_CANARA.Database.Tables
                ElseIf ClientName = "MNARESH" Then
                    crTables = OBJCHQPAY_ICICI.Database.Tables
                ElseIf ClientName = "PARAS" Then
                    crTables = OBJCHQPAY_STANDARD.Database.Tables
                Else
                    crTables = OBJCHQPAY.Database.Tables
                End If
            ElseIf FRMSTRING = "PAYREGISTER" Then
                crTables = OBJPAYREG.Database.Tables
            ElseIf FRMSTRING = "ENVELOPE" Then
                crTables = OBJENVELOPE.Database.Tables
            Else
                crTables = obj_paytype.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "CHQPRINT" Then
                strsearch = strsearch & "  {PAYMENTMASTER.PAYMENT_NO}= " & payno & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_CMPID} = " & CmpId & " and {PAYMENTMASTER.PAYMENT_LOCATIONID} = " & Locationid & " and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                If ClientName = "KCRAYON" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "AVIS" Or ClientName = "CC" Or ClientName = "DILIP" Or ClientName = "SHREEVALLABH" Or ClientName = "MOOLTEX" Or ClientName = "SUPRIYA" Then
                    CRPO.ReportSource = OBJCHQPAY_HDFC
                ElseIf ClientName = "MOHAN" Then
                    CRPO.ReportSource = OBJCHQPAY_INDUS
                    OBJCHQPAY_INDUS.DataDefinition.FormulaFields("NEFTRTGSPARTY").Text = "'" & NEFTRTGSNORMAL & "'"
                ElseIf ClientName = "SAKARIA" Then
                    CRPO.ReportSource = OBJCHQPAY_CITIBANK
                ElseIf ClientName = "AXIS" Or ClientName = "SBA" Or ClientName = "INDRAPUJA" Then
                    CRPO.ReportSource = OBJCHQPAY_UNION
                ElseIf ClientName = "MASHOK" Or ClientName = "NVAHAN" Or ClientName = "KDFAB" Or ClientName = "SOFTAS" Or ClientName = "MYCOT" Or ClientName = "DRDRAPES" Or ClientName = "YUMILONE" Then
                    CRPO.ReportSource = OBJCHQPAY_KOTAK
                ElseIf ClientName = "CHANDRA" Then
                    CRPO.ReportSource = OBJCHQPAY_SYNDICATE
                ElseIf ClientName = "DEVEN" Or ClientName = "ALENCOT" Then
                    CRPO.ReportSource = OBJCHQPAY_CANARA
                ElseIf ClientName = "MNARESH" Then
                    CRPO.ReportSource = OBJCHQPAY_ICICI
                ElseIf ClientName = "PARAS" Then
                    CRPO.ReportSource = OBJCHQPAY_STANDARD
                Else

                    CRPO.ReportSource = OBJCHQPAY
                End If

            ElseIf FRMSTRING = "PAYREGISTER" Then
                CRPO.SelectionFormula = WHERECLAUSE
                CRPO.ReportSource = OBJPAYREG
                OBJPAYREG.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                OBJPAYREG.DataDefinition.FormulaFields("SHOWNARR").Text = SHOWNARR

            ElseIf FRMSTRING = "ENVELOPE" Then
                CRPO.SelectionFormula = " {LEDGERS.Acc_cmpname} = '" & LEDGERSNAME & "' and {LEDGERS.ACC_YEARID} = " & YearId
                CRPO.ReportSource = OBJENVELOPE

            Else
                strsearch = strsearch & "  {PAYMENT_REPORT.PAYMENTNO}= " & payno & " AND {PAYMENT_REPORT.REGNAME}= '" & REGNAME & "' and {LEDGERS.Acc_cmpname} = '" & payname & "' and {PAYMENT_REPORT.CMPID} = " & CmpId & " and {PAYMENT_REPORT.LOCATIONID} = " & Locationid & " and {PAYMENT_REPORT.YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = obj_paytype
            End If


            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()

        For I As Integer = FROMNO To TONO

            Dim OBJ As Object
            If ClientName = "KCRAYON" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "AVIS" Or ClientName = "CC" Or ClientName = "DILIP" Or ClientName = "SHREEVALLABH" Or ClientName = "MOOLTEX" Or ClientName = "SUPRIYA" Then
                OBJ = New ChqPayment_HDFC
            ElseIf ClientName = "MOHAN" Then
                OBJ = New ChqPayment_INDUS
            ElseIf ClientName = "SAKARIA" Then
                OBJ = New ChqPayment_CITIBANK
            ElseIf ClientName = "AXIS" Or ClientName = "SBA" Then
                OBJ = New ChqPayment_UNION
            ElseIf ClientName = "MASHOK" Or ClientName = "NVAHAN" Or ClientName = "KDFAB" Or ClientName = "SOFTAS" Or ClientName = "MYCOT" Or ClientName = "DRDRAPES" Or ClientName = "YUMILONE" Then
                OBJ = New ChqPayment_KOTAK
            ElseIf ClientName = "DEVEN" Or ClientName = "ALENCOT" Then
                OBJ = New ChqPayment_Canara
            ElseIf ClientName = "MNARESH" Then
                OBJ = New ChqPayment_ICICI
            ElseIf ClientName = "PARAS" Then
                OBJ = New ChqPayment_STANDARDCHAR
            Else
                OBJ = New ChqPayment
            End If


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

            crTables = OBJ.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = " {PAYMENTMASTER.PAYMENT_NO}= " & I & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
            OBJ.PrintToPrinter(1, True, 0, 0)

        Next
    End Sub

    Sub PRINTDIRECTADVICE()
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

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

            strsearch = "  {PAYMENT_REPORT.PAYMENTNO}= " & payno & " AND {PAYMENT_REPORT.REGNAME}= '" & REGNAME & "' and {LEDGERS.Acc_cmpname} = '" & payname & "' and {PAYMENT_REPORT.CMPID} = " & CmpId & " and {PAYMENT_REPORT.LOCATIONID} = " & Locationid & " and {PAYMENT_REPORT.YEARID} = " & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As Object = New Paymentreport
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = strsearch

            If DIRECTMAIL = True Then
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\PAYMENT_" & payno & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)

                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
       System.WINDOWS.FORMS.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        Dim objmail As New SendMail

        tempattachment = "PAYMENTREPORT"
        objmail.subject = "Payment Voucher"

        Try
            'Dim objmail As New SendMail
            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
       System.WINDOWS.FORMS.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            oDfDopt.DiskFileName = Application.StartupPath & "\PAYMENTREPORT.PDF"
            expo = obj_paytype.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            obj_paytype.Export()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class