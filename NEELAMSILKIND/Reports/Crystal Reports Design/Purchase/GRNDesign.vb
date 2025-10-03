
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class GRNDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String
    Public GRNNO As Integer

    Dim RPTGRN As New GRNReport

    Dim RPTLETTER As New GRNLetter

    Dim RPTPARTYDTLS As New GRNPartyWiseDetails
    Dim RPTPARTYSUMM As New GRNPartyWiseSummary
    Dim RPTJOBBERDTLS As New GRNJobberWiseDetails
    Dim RPTJOBBERSUMM As New GRNJobberWiseSummary
    Dim RPTITEMDTLS As New GRNItemWiseDetails
    Dim RPTITEMSUMM As New GRNItemWiseSummary
    Dim RPTQUALITYDTLS As New GRNQualityWiseDetails
    Dim RPTQUALITYSUMM As New GRNQualityWiseSummary
    Dim RPTDESIGNDTLS As New GRNDesignWiseDetails
    Dim RPTDESIGNSUMM As New GRNDesignWiseSummary
    Dim RPTSHADEDTLS As New GRNShadeWiseDetails
    Dim RPTSHADESUMM As New GRNShadeWiseSummary
    Dim RPTMONTHLY As New GRNMonthWise
    Dim RPTPENDING As New GRNPendingCheck


    Dim RPTLOTREPORT As New LotStatus_Detail
    Dim RPTLOTREPORTSUMMARY As New LotStatus_Summary
    Dim RPTLOTDETAIL As New LotStatus_LEDGERS

    Private Sub GDNDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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




            If FRMSTRING = "GRN" Then
                crTables = RPTGRN.Database.Tables
            End If

            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "JOBBERWISEDTLS" Then crTables = RPTJOBBERDTLS.Database.Tables
            If FRMSTRING = "JOBBERWISESUMM" Then crTables = RPTJOBBERSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "QUALITYWISEDTLS" Then crTables = RPTQUALITYDTLS.Database.Tables
            If FRMSTRING = "QUALITYWISESUMM" Then crTables = RPTQUALITYSUMM.Database.Tables

            If FRMSTRING = "DESIGNWISEDTLS" Then crTables = RPTDESIGNDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISESUMM" Then crTables = RPTDESIGNSUMM.Database.Tables

            If FRMSTRING = "SHADEWISEDTLS" Then crTables = RPTSHADEDTLS.Database.Tables
            If FRMSTRING = "SHADEWISESUMM" Then crTables = RPTSHADESUMM.Database.Tables

            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables
            If FRMSTRING = "PENDING" Then crTables = RPTPENDING.Database.Tables
            If FRMSTRING = "DETAIL" Then crTables = RPTLOTDETAIL.Database.Tables

            If FRMSTRING = "LETTER" Then crTables = RPTLETTER.Database.Tables

            If FRMSTRING = "FULL" Or FRMSTRING = "FULLPENDING" Or FRMSTRING = "FULLCOMPLETED" Then crTables = RPTLOTREPORT.Database.Tables
            If FRMSTRING = "FULLSUMMARY" Then crTables = RPTLOTREPORTSUMMARY.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "PARTYWISEDTLS" Then
                crpo.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GRN" Then
                crpo.ReportSource = RPTGRN
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                crpo.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                crpo.ReportSource = RPTJOBBERDTLS
                RPTJOBBERDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                crpo.ReportSource = RPTJOBBERSUMM
                RPTJOBBERSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                crpo.ReportSource = RPTQUALITYDTLS
                RPTQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                crpo.ReportSource = RPTQUALITYSUMM
                RPTQUALITYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                crpo.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                crpo.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                crpo.ReportSource = RPTSHADEDTLS
                RPTSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                crpo.ReportSource = RPTSHADESUMM
                RPTSHADESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "MONTHLY" Then
                crpo.ReportSource = RPTMONTHLY
                RPTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PENDING" Then
                crpo.ReportSource = RPTPENDING
                RPTPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DETAIL" Then
                crpo.ReportSource = RPTLOTDETAIL
                RPTLOTDETAIL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "FULL" Then
                crpo.ReportSource = RPTLOTREPORT
                RPTLOTREPORT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "FULLPENDING" Then
                crpo.ReportSource = RPTLOTREPORT
                RPTLOTREPORT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTLOTREPORT.DataDefinition.FormulaFields("FILTER").Text = "'PENDING'"
            ElseIf FRMSTRING = "FULLCOMPLETED" Then
                crpo.ReportSource = RPTLOTREPORT
                RPTLOTREPORT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTLOTREPORT.DataDefinition.FormulaFields("FILTER").Text = "'COMPLETED'"
            ElseIf FRMSTRING = "FULLSUMMARY" Then
                crpo.ReportSource = RPTLOTREPORTSUMMARY
                RPTLOTREPORTSUMMARY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "LETTER" Then
                crpo.ReportSource = RPTLETTER
            End If

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
           System.WINDOWS.FORMS.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "GRN"
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
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
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\GRN.pdf"

            If FRMSTRING = "PARTYWISEDTLS" Then
                expo = RPTPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYDTLS.Export()

            ElseIf FRMSTRING = "LETTER" Then
                expo = RPTLETTER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLETTER.Export()

            ElseIf FRMSTRING = "GRN" Then
                expo = RPTGRN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGRN.Export()

            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                expo = RPTPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYSUMM.Export()
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                expo = RPTJOBBERDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERDTLS.Export()
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                expo = RPTJOBBERSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERSUMM.Export()
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                expo = RPTITEMDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMDTLS.Export()
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                expo = RPTITEMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMSUMM.Export()
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                expo = RPTQUALITYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQUALITYDTLS.Export()
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                expo = RPTQUALITYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQUALITYSUMM.Export()
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                expo = RPTDESIGNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNDTLS.Export()
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                expo = RPTDESIGNSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNSUMM.Export()
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                expo = RPTSHADEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADEDTLS.Export()
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                expo = RPTSHADESUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADESUMM.Export()
            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            ElseIf FRMSTRING = "PENDING" Then
                expo = RPTPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPENDING.Export()
            ElseIf FRMSTRING = "FULL" Then
                expo = RPTLOTREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLOTREPORT.Export()
            ElseIf FRMSTRING = "FULLSUMMARY" Then
                expo = RPTLOTREPORTSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLOTREPORTSUMMARY.Export()
            ElseIf FRMSTRING = "DETAIL" Then
                expo = RPTLOTDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLOTDETAIL.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class