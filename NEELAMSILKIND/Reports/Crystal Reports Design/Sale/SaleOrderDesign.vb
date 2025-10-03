
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO

Public Class SaleOrderDesign

    Public FORMULA As String

    Dim RPTSO As New SOReport

    Dim RPTSMP As New SampleNoteReport
    Dim RPTSMPPRICELIST As New SamplePriceListReport
    Dim RPTSTOCKRECO As New StockRecoReport


    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String
    'NEWLY ADDED

    Public FRMSTRING As String
    Public FROMDATE As String
    Public TODATE As String
    Public OPENINGDATE As String
    Public selfor_ss As String
    Public PERIOD As String
    Public PARTYNAME As String
    Public AGENTNAME As String
    Public SONO As Integer
    Public HIDERATE As Integer
    Public INVOICECOPYNAME As String

    Public PRINTSETTING As Object = Nothing

    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1

    Private Sub SaleOrderDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()
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

            strsearch = "{SALEORDER.SO_NO}=" & Val(SONO) & " and {SALEORDER.SO_yearid}=" & YearId
            crpo.SelectionFormula = strsearch

            Dim OBJ As New Object
            If FRMSTRING = "SOREPORT" Then
                OBJ = New SOReport
            End If


SKIPINVOICE:
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = strsearch

            If DIRECTMAIL = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\SALEORDER_" & SONO & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)

                expo = OBJ.ExportOptions
                'OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaleOrderDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
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

            If FRMSTRING = "SOREPORT" Then
                crTables = RPTSO.Database.Tables
            ElseIf FRMSTRING = "SAMPLENOTE" Then
                crTables = RPTSMP.Database.Tables
            ElseIf FRMSTRING = "SAMPLEPRICELIST" Then
                crTables = RPTSMPPRICELIST.Database.Tables
            ElseIf FRMSTRING = "STOCKRECO" Then
                crTables = RPTSTOCKRECO.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = FORMULA

            If FRMSTRING = "SOREPORT" Then
                crpo.ReportSource = RPTSO
                If HIDERATE = 1 Then RPTSO.DataDefinition.FormulaFields("HIDERATE").Text = 1
            ElseIf FRMSTRING = "SAMPLENOTE" Then
                crpo.ReportSource = RPTSMP
            ElseIf FRMSTRING = "SAMPLEPRICELIST" Then
                crpo.ReportSource = RPTSMPPRICELIST
            ElseIf FRMSTRING = "STOCKRECO" Then
                crpo.ReportSource = RPTSTOCKRECO
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

        Dim emailid As String = ""
        Dim emailid1 As String = ""
       System.WINDOWS.FORMS.Cursor.Current = Cursors.WaitCursor
        Transfer()

        If PARTYNAME <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID=" & YearId)
            If dt.Rows.Count > 0 Then
                emailid = dt.Rows(0).Item(0).ToString
            End If
        End If

        If AGENTNAME <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & AGENTNAME & "' AND ACC_YEARID=" & YearId)
            If dt.Rows.Count > 0 Then
                emailid1 = dt.Rows(0).Item(0).ToString
            End If
        End If

        Dim tempattachment As String

        Dim objmail As New SendMail

        If FRMSTRING = "" Then
            tempattachment = "SOREPORT"
            objmail.subject = "Sale Order"
        ElseIf FRMSTRING = "SOREPORT" Or FRMSTRING = "SOCAD" Then
            tempattachment = "SOREPORT"
            objmail.subject = "Sale Order"

        ElseIf FRMSTRING = "SCHEDULEREPORT" Then
            tempattachment = "SCHEDULEREPORT"
            objmail.subject = "Schedule"

        ElseIf FRMSTRING = "SAMPLENOTE" Then
            tempattachment = "SAMPLENOTE"
            objmail.subject = "Sample Note"
        ElseIf FRMSTRING = "SAMPLEPRICELIST" Then
            tempattachment = "SAMPLEPRICELIST"
            objmail.subject = "Sample Price List"
        End If

        Try
            'Dim objmail As New SendMail
            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            If emailid1 <> "" Then
                objmail.cmbsecondadd.Text = emailid1
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

            If FRMSTRING = "" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SOREPORT.PDF"
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt

            ElseIf FRMSTRING = "SOREPORT" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SOREPORT.PDF"
                expo = RPTSO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSO.Export()

            ElseIf FRMSTRING = "SAMPLENOTE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SAMPLENOTE.PDF"
                expo = RPTSMP.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSMP.Export()
            ElseIf FRMSTRING = "SAMPLEPRICELIST" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SAMPLEPRICELIST.PDF"
                expo = RPTSMPPRICELIST.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSMPPRICELIST.Export()
            ElseIf FRMSTRING = "SALEORDER" Then
                RPTSO.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = RPTSO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSO.Export()
                RPTSO.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            ElseIf FRMSTRING = "STOCKRECO" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\STOCKRECO.PDF"
                expo = RPTSTOCKRECO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTOCKRECO.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class