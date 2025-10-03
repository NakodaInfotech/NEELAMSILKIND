
Imports BL
Imports System.Windows.Forms

Public Class GRNDetails

    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If FRMSTRING = "GRN" Then
                cmbtype.Text = "G.R.N"
            ElseIf FRMSTRING = "GRNJOB" Then
                cmbtype.Text = "Job Work"
                gridbill.Columns("GODOWN").Visible = False
                gridbill.Columns("BROKER").Visible = False
                gridbill.Columns("LOTNO").Visible = True
                gridbill.Columns("JOBBERNAME").Visible = True
            ElseIf FRMSTRING = "GRN FANCY" Then
                cmbtype.Text = "FANCY MATERIAL"
                gridbill.Columns("LOTNO").Visible = False
                gridbill.Columns("JOBBERNAME").Visible = False
            End If
            fillgrid(" and grn.grn_type='" & cmbtype.Text & "' and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" GRN.grn_no AS SRNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, GRN.grn_challanno AS CHALLANNO, GRN.grn_challandt AS CHALLANDATE, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(BROKERLEDGERS.Acc_cmpname, '') AS BROKER, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GRN_DESC.GRN_QTY, 0) AS PCS, ISNULL(GRN_DESC.GRN_MTRS, 0) AS MTRS, ISNULL(GRN.GRN_PLOTNO,'') AS LOTNO, GRN.GRN_RECDATE AS LOTDATE, ISNULL(GRN.GRN_PONO,'') AS PONO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_NAME, '') AS SHADE, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY ", "", " GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_yearid = GRN_DESC.GRN_YEARID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE LEFT OUTER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON GRN.GRN_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON GRN.GRN_TOLEDGERID = JOBBERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GRN.GRN_TRANSLEDGERID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON COLOR_ID = GRN_DESC.GRN_COLORID LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SRNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objGRN As New GRN
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.tempgrnno = SRNO
                objGRN.FRMSTRING = FRMSTRING
                objGRN.Show()
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

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\GRN Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "GRN Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRN Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("GRN Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        Try
            If cmbtype.Text.Trim <> "" Then fillgrid(" and grn.grn_type='" & cmbtype.Text & "' and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()

            If SELECTEDROWS.Length <= 0 Then Exit Sub
            Dim OBJGDN As New GRNDesign
            Dim SRNOCLAUSE As String = ""
            If MsgBox("Wish to Print Mill Letter ?", MsgBoxStyle.YesNo) = vbYes Then
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "LETTER"
                OBJGDN.WHERECLAUSE = " {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "' and {GRN.GRN_yearid}=" & YearId
            End If

            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                If SRNOCLAUSE = "" Then
                    SRNOCLAUSE = " And ({GRN.GRN_NO} = " & Val(ROW("SRNO"))
                Else
                    SRNOCLAUSE = SRNOCLAUSE & " OR {GRN.GRN_NO} = " & Val(ROW("SRNO"))
                End If
            Next
            If SRNOCLAUSE <> "" Then
                SRNOCLAUSE = SRNOCLAUSE & ")"
                OBJGDN.WHERECLAUSE = OBJGDN.WHERECLAUSE & SRNOCLAUSE
            End If
            OBJGDN.Show()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class