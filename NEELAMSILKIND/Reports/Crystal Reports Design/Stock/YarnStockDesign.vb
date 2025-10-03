
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class YarnStockDesign

    Public WHERECLAUSE As String = ""
    Public FRMSTRING As String = ""
    Public PERIOD As String = ""
    Public FROMDATE As Date
    Public TODATE As Date
    Public WARPWASTAGEPER As Double
    Public WEFTWASTAGEPER As Double
    Public OPENINGSTOCK As Double
    Public DENIER As Double
    Public JOBBERNAME As String = ""
    Public SHOWTL As Integer = 1
    Public LASTENTRYDATE As Date = Now.Date
    Public LASTENTRYNO As Integer = 0
    Public LASTSTOCK As Double = 0.0



    Dim RPTMILLSTOCKSUMM As New YarnMillWiseStockReport
    Dim RPTMILLSTOCKDETAIL As New YarnMillWiseStockDetailReport
    Dim RPTYARNSTOCKSUMM As New YarnQualityWiseStockReport
    Dim RPTYARNSTOCKDETAILS As New YarnQualityWiseStockDetailReport
    Dim RPTSHADESTOCKSUMM As New YarnShadeWiseStockReport
    Dim RPTSHADESTOCKDETAIL As New YarnShadeWiseStockDetailReport
    Dim RPTWEAVERYARNDESDETAILS As New YarnWeaverYarnDesignDetailReport

    Dim RPTJOBBERSTOCKDTLS As New JobberWiseYarnStockDetailReport
    Dim RPTJOBBERSTOCKSUMM As New JobberWiseYarnStockReport
    Dim RPTJOBBERYARNSTOCKSUMM As New JobberYarnQualityWiseStockReport
    Dim RPTJOBBERSHADESTOCKSUMM As New JobberYarnShadeWiseStockReport
    Dim RPTJOBBERQUALITYSHADESTOCKSUMM As New JobberYarnQualityShadeWiseStockReport
    Dim RPTJOBBERVIRTUALSTOCK As New JobberYarnVirtualStockReport

    Dim RPTPRODYARNSTOCKSUMM As New ProdYarnQualityWiseStockReport
    Dim RPTPRODDESIGNSTOCKSUMM As New ProdYarnDesignWiseStockReport
    Dim RPTPRODSHADESTOCKSUMM As New ProdYarnShadeWiseStockReport

    Private Sub YarnStockDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub YarnStockDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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



            If FRMSTRING = "MILLSTOCKSUMM" Then crTables = RPTMILLSTOCKSUMM.Database.Tables
            If FRMSTRING = "MILLSTOCKDETAIL" Then crTables = RPTMILLSTOCKDETAIL.Database.Tables
            If FRMSTRING = "QUALITYSTOCKSUMM" Then crTables = RPTYARNSTOCKSUMM.Database.Tables
            If FRMSTRING = "QUALITYSTOCKDETAIL" Then crTables = RPTYARNSTOCKDETAILS.Database.Tables
            If FRMSTRING = "SHADESTOCKSUMM" Then crTables = RPTSHADESTOCKSUMM.Database.Tables
            If FRMSTRING = "SHADESTOCKDETAIL" Then crTables = RPTSHADESTOCKDETAIL.Database.Tables
            If FRMSTRING = "WEAVERYARNDESIGNDETAIL" Then crTables = RPTWEAVERYARNDESDETAILS.Database.Tables

            If FRMSTRING = "JOBBERQUALITYSTOCKSUMM" Then crTables = RPTJOBBERYARNSTOCKSUMM.Database.Tables
            If FRMSTRING = "JOBBERSTOCKSUMM" Then crTables = RPTJOBBERSTOCKSUMM.Database.Tables
            If FRMSTRING = "JOBBERSTOCKDTLS" Then crTables = RPTJOBBERSTOCKDTLS.Database.Tables
            If FRMSTRING = "JOBBERSHADESTOCKSUMM" Then crTables = RPTJOBBERSHADESTOCKSUMM.Database.Tables
            If FRMSTRING = "JOBBERQUALITYSHADESTOCKSUMM" Then crTables = RPTJOBBERQUALITYSHADESTOCKSUMM.Database.Tables
            If FRMSTRING = "VIRTUALSTOCK" Then crTables = RPTJOBBERVIRTUALSTOCK.Database.Tables

            If FRMSTRING = "PRODQUALITYSTOCKSUMM" Then crTables = RPTPRODYARNSTOCKSUMM.Database.Tables
            If FRMSTRING = "PRODDESIGNSTOCKSUMM" Then crTables = RPTPRODDESIGNSTOCKSUMM.Database.Tables
            If FRMSTRING = "PRODSHADESTOCKSUMM" Then crTables = RPTPRODSHADESTOCKSUMM.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "MILLSTOCKSUMM" Then
                RPTMILLSTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' ITEM STOCK SUMMARY - " & PERIOD & "'"
                RPTMILLSTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTMILLSTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTMILLSTOCKSUMM
            ElseIf FRMSTRING = "MILLSTOCKDETAIL" Then
                RPTMILLSTOCKDETAIL.DataDefinition.FormulaFields("PERIOD").Text = "' ITEM STOCK DETAILS - " & PERIOD & "'"
                RPTMILLSTOCKDETAIL.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTMILLSTOCKDETAIL.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTMILLSTOCKDETAIL
            ElseIf FRMSTRING = "QUALITYSTOCKSUMM" Then
                RPTYARNSTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' QUALITY STOCK SUMMARY - " & PERIOD & "'"
                RPTYARNSTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTYARNSTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTYARNSTOCKSUMM
            ElseIf FRMSTRING = "QUALITYSTOCKDETAIL" Then
                RPTYARNSTOCKDETAILS.DataDefinition.FormulaFields("PERIOD").Text = "' QUALITY STOCK DETAILS - " & PERIOD & "'"
                RPTYARNSTOCKDETAILS.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTYARNSTOCKDETAILS.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTYARNSTOCKDETAILS
            ElseIf FRMSTRING = "SHADESTOCKSUMM" Then
                RPTSHADESTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' SHADE STOCK SUMMARY - " & PERIOD & "'"
                RPTSHADESTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTSHADESTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTSHADESTOCKSUMM
            ElseIf FRMSTRING = "SHADESTOCKDETAIL" Then
                RPTSHADESTOCKDETAIL.DataDefinition.FormulaFields("PERIOD").Text = "' SHADE STOCK DETAIL - " & PERIOD & "'"
                RPTSHADESTOCKDETAIL.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTSHADESTOCKDETAIL.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTSHADESTOCKDETAIL
            ElseIf FRMSTRING = "WEAVERYARNDESIGNDETAIL" Then
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("OPENINGSTOCK").Text = Val(OPENINGSTOCK)
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("SHOWTL").Text = Val(SHOWTL)
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("LASTENTRYDATE").Text = "'" & Format(Convert.ToDateTime(LASTENTRYDATE).Date, "dd/MM/yyyy") & "'"
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("LASTENTRYNO").Text = Val(LASTENTRYNO)
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("LASTENTRYSTOCK").Text = Val(LASTSTOCK)
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("DENIER").Text = Val(DENIER)
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("WARPWASTAGE").Text = Val(WARPWASTAGEPER)
                RPTWEAVERYARNDESDETAILS.DataDefinition.FormulaFields("WEFTWASTAGE").Text = Val(WEFTWASTAGEPER)

                RPTWEAVERYARNDESDETAILS.Subreports(0).DataDefinition.FormulaFields("TODATE").Text = Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"

                crpo.ReportSource = RPTWEAVERYARNDESDETAILS



            ElseIf FRMSTRING = "JOBBERQUALITYSTOCKSUMM" Then
                RPTJOBBERYARNSTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' QUALITY STOCK SUMMARY - " & PERIOD & "'"
                RPTJOBBERYARNSTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTJOBBERYARNSTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTJOBBERYARNSTOCKSUMM
            ElseIf FRMSTRING = "JOBBERSTOCKSUMM" Then
                RPTJOBBERSTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' YARN STOCK SUMMARY - " & PERIOD & "'"
                RPTJOBBERSTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTJOBBERSTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTJOBBERSTOCKSUMM
            ElseIf FRMSTRING = "JOBBERSTOCKDTLS" Then
                RPTJOBBERSTOCKDTLS.DataDefinition.FormulaFields("PERIOD").Text = "' YARN STOCK DETAILS - " & PERIOD & "'"
                RPTJOBBERSTOCKDTLS.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTJOBBERSTOCKDTLS.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTJOBBERSTOCKDTLS
            ElseIf FRMSTRING = "JOBBERSHADESTOCKSUMM" Then
                RPTJOBBERSHADESTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' SHADE STOCK SUMMARY - " & PERIOD & "'"
                RPTJOBBERSHADESTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTJOBBERSHADESTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTJOBBERSHADESTOCKSUMM
            ElseIf FRMSTRING = "JOBBERQUALITYSHADESTOCKSUMM" Then
                RPTJOBBERQUALITYSHADESTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' QUALITY - SHADE STOCK SUMMARY - " & PERIOD & "'"
                RPTJOBBERQUALITYSHADESTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTJOBBERQUALITYSHADESTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTJOBBERQUALITYSHADESTOCKSUMM
            ElseIf FRMSTRING = "VIRTUALSTOCK" Then
                RPTJOBBERVIRTUALSTOCK.DataDefinition.FormulaFields("WARPPER").Text = Val(WARPWASTAGEPER)
                RPTJOBBERVIRTUALSTOCK.DataDefinition.FormulaFields("WEFTPER").Text = Val(WEFTWASTAGEPER)
                RPTJOBBERVIRTUALSTOCK.DataDefinition.FormulaFields("PERIOD").Text = "' JOBBER VIRTUAL STOCK SUMMARY - " & PERIOD & "'"
                RPTJOBBERVIRTUALSTOCK.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTJOBBERVIRTUALSTOCK.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTJOBBERVIRTUALSTOCK


            ElseIf FRMSTRING = "PRODQUALITYSTOCKSUMM" Then
                RPTPRODYARNSTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' QUALITY STOCK SUMMARY - " & PERIOD & "'"
                RPTPRODYARNSTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTPRODYARNSTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTPRODYARNSTOCKSUMM
            ElseIf FRMSTRING = "PRODDESIGNSTOCKSUMM" Then
                RPTPRODDESIGNSTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' DESIGN STOCK SUMMARY - " & PERIOD & "'"
                RPTPRODDESIGNSTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTPRODDESIGNSTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTPRODDESIGNSTOCKSUMM
            ElseIf FRMSTRING = "PRODSHADESTOCKSUMM" Then
                RPTPRODSHADESTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' SHADE STOCK SUMMARY - " & PERIOD & "'"
                RPTPRODSHADESTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTPRODSHADESTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTPRODSHADESTOCKSUMM
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
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\STOCK.pdf"
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
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
            oDfDopt.DiskFileName = Application.StartupPath & "\STOCK.pdf"

            If FRMSTRING = "MILLSTOCKSUMM" Then
                expo = RPTMILLSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMILLSTOCKSUMM.Export()

            ElseIf FRMSTRING = "MILLSTOCKDETAIL" Then
                expo = RPTMILLSTOCKDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMILLSTOCKDETAIL.Export()

            ElseIf FRMSTRING = "QUALITYSTOCKSUMM" Then
                expo = RPTYARNSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNSTOCKSUMM.Export()

            ElseIf FRMSTRING = "QUALITYSTOCKDETAIL" Then
                expo = RPTYARNSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNSTOCKSUMM.Export()

            ElseIf FRMSTRING = "SHADESTOCKSUMM" Then
                expo = RPTSHADESTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADESTOCKSUMM.Export()

            ElseIf FRMSTRING = "SHADESTOCKDETAIL" Then
                expo = RPTSHADESTOCKDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADESTOCKDETAIL.Export()

            ElseIf FRMSTRING = "WEAVERYARNDESIGNDETAIL" Then
                expo = RPTWEAVERYARNDESDETAILS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTWEAVERYARNDESDETAILS.Export()






            ElseIf FRMSTRING = "JOBBERQUALITYSTOCKSUMM" Then
                expo = RPTJOBBERYARNSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERYARNSTOCKSUMM.Export()

            ElseIf FRMSTRING = "JOBBERSTOCKSUMM" Then
                expo = RPTJOBBERSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERSTOCKSUMM.Export()

            ElseIf FRMSTRING = "JOBBERSTOCKDTLS" Then
                expo = RPTJOBBERSTOCKDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERSTOCKDTLS.Export()

            ElseIf FRMSTRING = "JOBBERSHADESTOCKSUMM" Then
                expo = RPTJOBBERSHADESTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERSHADESTOCKSUMM.Export()

            ElseIf FRMSTRING = "JOBBERQUALITYSHADESTOCKSUMM" Then
                expo = RPTJOBBERQUALITYSHADESTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERQUALITYSHADESTOCKSUMM.Export()

            ElseIf FRMSTRING = "VIRTUALSTOCK" Then
                expo = RPTJOBBERVIRTUALSTOCK.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERVIRTUALSTOCK.Export()



            ElseIf FRMSTRING = "PRODQUALITYSTOCKSUMM" Then
                expo = RPTPRODYARNSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPRODYARNSTOCKSUMM.Export()

            ElseIf FRMSTRING = "PRODDESIGNSTOCKSUMM" Then
                expo = RPTPRODDESIGNSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPRODDESIGNSTOCKSUMM.Export()

            ElseIf FRMSTRING = "PRODSHADESTOCKSUMM" Then
                expo = RPTPRODSHADESTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPRODSHADESTOCKSUMM.Export()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class