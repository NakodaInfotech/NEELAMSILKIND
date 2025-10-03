
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class YarnDesign

    Public WHERECLAUSE As String = ""
    Public FRMSTRING As String = ""
    Public PENDINGPROG As String = ""
    Public PERIOD As String = ""
    Public PARTYNAME As String = ""
    Public AGENTNAME As String = ""
    Public FROMDATE As Date
    Public TODATE As Date
    Public SHOWRATE As Integer = 0
    Public WARPPER As Double = 0.0
    Public WEFTPER As Double = 0.0

    Dim RPTYARNISSUE As New YarnIssueReport
    Dim RPTCHALLAN As New YarnChallanReport
    Dim RPTCARDISS As New DesignCardIssueReport
    Dim RPTCARDREQ As New DesignCardReqReport


    Dim RPTDYEINGPROG As New YarnDyeingProgReport
    Dim RPTDYEINGPROGPARTY As New YarnDyeingProgPartyWiseReport


    Dim RPTYARNPO As New YarnPOReport
    Dim RPTYARNPOPARTY As New YarnPOPartyWiseReport

    Dim RPTYARNSO As New YarnSOReport
    Dim RPTYARNSOSTATUS As New YarnSOStatusReport
    Dim RPTYARNSOSTATUSDTLS As New YarnSOStatusDetailsReport


    Dim RPTYARNRECDDYEING As New YarnRecdDyeingReport
    Dim RPTYARNRECDPUR As New YarnRecdReport
    Dim RPTYARNRECDJOBBER As New YarnRecdJobberReport
    Dim RPTYARNPURRETURN As New YarnPurReturnReport

    Dim RPTGREYRECD As New GreyRecdJobberReport
    Dim RPTGREYWEAVERDTLS As New GreyWeaverDtlsReport
    Dim RPTGREYWEAVERDESIGNDTLS As New GreyWeaverDesignDtlsReport
    Dim RPTGREYWTDIFF As New GreyWtDiffReport

    Dim TEMPATTACHMENT As String = ""

    Private Sub StockDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub BeamIssueDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "YARNISSUE" Then
                crTables = RPTYARNISSUE.Database.Tables
            ElseIf FRMSTRING = "YARNCHALLAN" Then
                crTables = RPTCHALLAN.Database.Tables
            ElseIf FRMSTRING = "CARDISSUE" Then
                crTables = RPTCARDISS.Database.Tables
            ElseIf FRMSTRING = "CARDREQUIREMENT" Then
                crTables = RPTCARDREQ.Database.Tables


            ElseIf FRMSTRING = "YARNPO" Then
                crTables = RPTYARNPO.Database.Tables
            ElseIf FRMSTRING = "YARNPOPARTY" Then
                crTables = RPTYARNPOPARTY.Database.Tables


            ElseIf FRMSTRING = "YARNSO" Then
                crTables = RPTYARNSO.Database.Tables
            ElseIf FRMSTRING = "YARNSOSTATUS" Then
                crTables = RPTYARNSOSTATUS.Database.Tables
            ElseIf FRMSTRING = "YARNSOSTATUSDTLS" Then
                crTables = RPTYARNSOSTATUSDTLS.Database.Tables


            ElseIf FRMSTRING = "DYEINGPROG" Then
                crTables = RPTDYEINGPROG.Database.Tables
            ElseIf FRMSTRING = "DYEINGPROGPARTY" Then
                crTables = RPTDYEINGPROGPARTY.Database.Tables


            ElseIf FRMSTRING = "YARNRECDDYEING" Then
                crTables = RPTYARNRECDDYEING.Database.Tables
            ElseIf FRMSTRING = "YARNRECDPUR" Then
                crTables = RPTYARNRECDPUR.Database.Tables
            ElseIf FRMSTRING = "YARNRECDJOBBER" Then
                crTables = RPTYARNRECDJOBBER.Database.Tables
            ElseIf FRMSTRING = "YARNPURRETURN" Then
                crTables = RPTYARNPURRETURN.Database.Tables

            ElseIf FRMSTRING = "GREYRECD" Then
                crTables = RPTGREYRECD.Database.Tables
            ElseIf FRMSTRING = "GREYWEAVERDTLS" Then
                crTables = RPTGREYWEAVERDTLS.Database.Tables
            ElseIf FRMSTRING = "GREYWEAVERDESIGNDTLS" Then
                crTables = RPTGREYWEAVERDESIGNDTLS.Database.Tables
            ElseIf FRMSTRING = "GREYWTDIFF" Then
                crTables = RPTGREYWTDIFF.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "YARNISSUE" Then
                crpo.ReportSource = RPTYARNISSUE
            ElseIf FRMSTRING = "YARNCHALLAN" Then
                crpo.ReportSource = RPTCHALLAN
            ElseIf FRMSTRING = "CARDISSUE" Then
                crpo.ReportSource = RPTCARDISS
                RPTCARDISS.DataDefinition.FormulaFields("SHOWRATE").Text = SHOWRATE
            ElseIf FRMSTRING = "CARDREQUIREMENT" Then
                crpo.ReportSource = RPTCARDREQ
                RPTCARDREQ.DataDefinition.FormulaFields("WARPPER").Text = Val(WARPPER) / 100
                RPTCARDREQ.DataDefinition.FormulaFields("WEFTPER").Text = Val(WEFTPER) / 100
                RPTCARDREQ.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCARDREQ.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTCARDREQ.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"

            ElseIf FRMSTRING = "YARNPO" Then
                crpo.ReportSource = RPTYARNPO
            ElseIf FRMSTRING = "YARNPOPARTY" Then
                crpo.ReportSource = RPTYARNPOPARTY


            ElseIf FRMSTRING = "YARNSO" Then
                crpo.ReportSource = RPTYARNSO
            ElseIf FRMSTRING = "YARNSOSTATUS" Then
                crpo.ReportSource = RPTYARNSOSTATUS
            ElseIf FRMSTRING = "YARNSOSTATUSDTLS" Then
                crpo.ReportSource = RPTYARNSOSTATUSDTLS


            ElseIf FRMSTRING = "DYEINGPROG" Then
                crpo.ReportSource = RPTDYEINGPROG
            ElseIf FRMSTRING = "DYEINGPROGPARTY" Then
                crpo.ReportSource = RPTDYEINGPROGPARTY

            ElseIf FRMSTRING = "YARNRECDDYEING" Then
                crpo.ReportSource = RPTYARNRECDDYEING
            ElseIf FRMSTRING = "YARNRECDPUR" Then
                crpo.ReportSource = RPTYARNRECDPUR
            ElseIf FRMSTRING = "YARNRECDJOBBER" Then
                crpo.ReportSource = RPTYARNRECDJOBBER
            ElseIf FRMSTRING = "YARNPURRETURN" Then
                crpo.ReportSource = RPTYARNPURRETURN

            ElseIf FRMSTRING = "GREYRECD" Then
                crpo.ReportSource = RPTGREYRECD
            ElseIf FRMSTRING = "GREYWEAVERDTLS" Then
                crpo.ReportSource = RPTGREYWEAVERDTLS
            ElseIf FRMSTRING = "GREYWEAVERDESIGNDTLS" Then
                crpo.ReportSource = RPTGREYWEAVERDESIGNDTLS
            ElseIf FRMSTRING = "GREYWTDIFF" Then
                crpo.ReportSource = RPTGREYWTDIFF
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

            If FRMSTRING = "GREYRECD" Or FRMSTRING = "GREYWEAVERDTLS" Or FRMSTRING = "GREYWEAVERDESIGNDTLS" Or FRMSTRING = "GREYWTDIFF" Then TEMPATTACHMENT = "GREY" Else TEMPATTACHMENT = "YARN"

            Transfer()
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
            oDfDopt.DiskFileName = Application.StartupPath & "\" & TEMPATTACHMENT & ".pdf"

            If FRMSTRING = "YARNISSUE" Then
                expo = RPTYARNISSUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNISSUE.Export()

            ElseIf FRMSTRING = "YARNCHALLAN" Then
                expo = RPTCHALLAN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHALLAN.Export()

            ElseIf FRMSTRING = "CARDISSUE" Then
                expo = RPTCARDISS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCARDISS.Export()

            ElseIf FRMSTRING = "CARDREQUIREMENT" Then
                expo = RPTCARDREQ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCARDREQ.Export()




            ElseIf FRMSTRING = "YARNPO" Then
                expo = RPTYARNPO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNPO.Export()

            ElseIf FRMSTRING = "YARNPOPARTY" Then
                expo = RPTYARNPOPARTY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNPOPARTY.Export()



            ElseIf FRMSTRING = "YARNSO" Then
                expo = RPTYARNSO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNSO.Export()

            ElseIf FRMSTRING = "YARNSOSTATUS" Then
                expo = RPTYARNSOSTATUS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNSOSTATUS.Export()

            ElseIf FRMSTRING = "YARNSOSTATUSDTLS" Then
                expo = RPTYARNSOSTATUSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNSOSTATUSDTLS.Export()




            ElseIf FRMSTRING = "DYEINGPROG" Then
                expo = RPTDYEINGPROG.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDYEINGPROG.Export()

            ElseIf FRMSTRING = "DYEINGPROGPARTY" Then
                expo = RPTDYEINGPROGPARTY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDYEINGPROGPARTY.Export()




            ElseIf FRMSTRING = "YARNRECDDYEING" Then
                expo = RPTYARNRECDDYEING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNRECDDYEING.Export()

            ElseIf FRMSTRING = "YARNRECDPUR" Then
                expo = RPTYARNRECDPUR.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNRECDPUR.Export()

            ElseIf FRMSTRING = "YARNRECDJOBBER" Then
                expo = RPTYARNRECDJOBBER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNRECDJOBBER.Export()

            ElseIf FRMSTRING = "YARNPURRETURN" Then
                expo = RPTYARNPURRETURN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNPURRETURN.Export()


            ElseIf FRMSTRING = "GREYRECD" Then
                expo = RPTGREYRECD.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGREYRECD.Export()

            ElseIf FRMSTRING = "GREYWEAVERDTLS" Then
                expo = RPTGREYWEAVERDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGREYWEAVERDTLS.Export()

            ElseIf FRMSTRING = "GREYWEAVERDESIGNDTLS" Then
                expo = RPTGREYWEAVERDESIGNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGREYWEAVERDESIGNDTLS.Export()

            ElseIf FRMSTRING = "GREYWTDIFF" Then
                expo = RPTGREYWTDIFF.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGREYWTDIFF.Export()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class