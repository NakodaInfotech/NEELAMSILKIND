Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports NEELAMSILKIND

Public Class Journal_Contra_Design

    Dim rptJVDtls As New Journal_Details_Report
    Dim RPTJV As New JournalReport
    Dim rptContraDtls As New Contra_Detail_Report
    Public strsearch As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public FRMSTRING As String
    Dim tempattachment As String

    Private Sub Journal_Contra_Details_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = False
            End With

            If FRMSTRING = "Open-ContraPartyReport" Then
                crTables = rptContraDtls.Database.Tables
            ElseIf FRMSTRING = "Open-JournalPartyReport" Then
                crTables = rptJVDtls.Database.Tables
            ElseIf FRMSTRING = "JOURNAL" Then
                crTables = RPTJV.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************************ END *******************

            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "Open-ContraPartyReport" Then
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue

                crParameterFieldDefinitions = rptContraDtls.DataDefinition.ParameterFields

                crParameterDiscreteValue.Value = CmpId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = Locationid
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@LOCATIONID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = YearId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@YEARID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = FROMDATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FROMDATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = TODATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TODATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                CRPO.ReportSource = rptContraDtls


            ElseIf FRMSTRING = "Open-JournalPartyReport" Then

                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue

                crParameterFieldDefinitions = rptJVDtls.DataDefinition.ParameterFields

                crParameterDiscreteValue.Value = CmpId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = Locationid
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@LOCATIONID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = YearId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@YEARID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = FROMDATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FROMDATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = TODATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TODATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                CRPO.ReportSource = rptJVDtls

            ElseIf FRMSTRING = "JOURNAL" Then
                CRPO.ReportSource = RPTJV
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

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
       System.WINDOWS.FORMS.Cursor.Current = Cursors.WaitCursor
        Transfer()

        If FRMSTRING = "Open-JournalPartyReport" Then
            tempattachment = "JOURNALREPORT"
        ElseIf FRMSTRING = "Open-ContraPartyReport" Then
            tempattachment = "CONTRAREPORT"
        ElseIf FRMSTRING = "JOURNAL" Then
            tempattachment = "JOURNALREPORT"
        End If


        Try
            Dim objmail As New SendMail
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

            If FRMSTRING = "Open-JournalPartyReport" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\JOURNALREPORT.PDF"
                expo = rptJVDtls.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptJVDtls.Export()

            ElseIf FRMSTRING = "Open-ContraPartyReport" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\CONTRAREPORT.PDF"
                expo = rptContraDtls.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptContraDtls.Export()

            ElseIf FRMSTRING = "JOURNAL" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\JOURNALREPORT.PDF"
                expo = RPTJV.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJV.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class