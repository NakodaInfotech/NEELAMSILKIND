
Imports BL

Public Class SelectYarnStock

    Public DT As New DataTable
    Public GODOWN As String = ""
    Public JOBBERNAME As String = ""
    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectYarnStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode =System.WINDOWS.FORMS.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid("  AND yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If GODOWN <> "" Then TEMPCONDITION = TEMPCONDITION & " AND GODOWN ='" & GODOWN & "'"
            If JOBBERNAME <> "" Then TEMPCONDITION = TEMPCONDITION & " AND NAME ='" & JOBBERNAME & "'"
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If FRMSTRING = "WASTAGEJOBBER" Then
                DT = OBJCMN.search(" CAST(0 AS BIT) AS CHK, YARNQUALITY, '' AS CATEGORY, '' AS MILLNAME, COLOR, '' AS BOXNO, '' AS LOTNO,  SUM(ISNULL(CONES,0)) - SUM(ISNULL(RECDCONES,0)) AS CONES, SUM(BAGS) - SUM(RECDBAGS) AS BAGS, ROUND(SUM(WT)-SUM(RECDWT),2) AS WT, '' AS DONO ", "", "  JOBBERYARNSTOCKREGISTER ", TEMPCONDITION & " GROUP BY YARNQUALITY, COLOR HAVING ROUND(SUM(WT)-SUM(RECDWT),2) > 0 ")
            Else
                DT = OBJCMN.search(" CAST(0 AS BIT) AS CHK, YARNQUALITY, CATEGORY, MILLNAME, COLOR, BOXNO, LOTNO,  SUM(ISNULL(CONES,0)) AS CONES, SUM(BAGS) AS BAGS, SUM(WT) AS WT, DONO ", "", "  YARNSTOCKVIEW ", TEMPCONDITION & " GROUP BY GODOWN, YARNQUALITY, CATEGORY, MILLNAME, COLOR, BOXNO, LOTNO, DONO HAVING SUM(WT) > 0 ")
            End If
            gridbilldetails.DataSource = DT
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            DT.Columns.Add("YARNQUALITY")
            DT.Columns.Add("MILLNAME")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("BOXNO")
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("BAGS")
            DT.Columns.Add("WT")
            DT.Columns.Add("CONES")
            DT.Columns.Add("DONO")

            For I As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("YARNQUALITY"), dtrow("MILLNAME"), dtrow("COLOR"), dtrow("BOXNO"), dtrow("LOTNO"), Val(dtrow("BAGS")), Val(dtrow("WT")), Val(dtrow("CONES")), dtrow("DONO"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectYarnStock_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If FRMSTRING = "WASATAGEJOBBER" Then
                GCATEGORY.Visible = False
                GMILLNAME.Visible = False
                GBOXNO.Visible = False
                GLOTNO.Visible = False
                GDONO.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class