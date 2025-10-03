
Imports BL

Public Class CategoryDetails

    Public FRMSTRING As String      'Used for form Category or GRade

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CategoryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode =System.WINDOWS.FORMS.Keys.N) Then   'for Exit
            showform(False, "", 0)
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"), gridledger.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CategoryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "CATEGORY" Then
                Me.Text = "Category Master"
            ElseIf FRMSTRING = "COLORTYPE" Then
                Me.Text = "Color Type Master"
            ElseIf FRMSTRING = "MATERIAL TYPE" Then
                Me.Text = "Material Type Master"
            ElseIf FRMSTRING = "COLOR" Then
                Me.Text = "Color Master"
            ElseIf FRMSTRING = "DEPARTMENT" Then
                Me.Text = "Department Master"
            ElseIf FRMSTRING = "PIECE TYPE" Then
                Me.Text = "Piece Type Master"
            ElseIf FRMSTRING = "RATE TYPE" Then
                Me.Text = "Rate Type Master"
            ElseIf FRMSTRING = "NARRATION" Then
                Me.Text = "Narration Master"
            ElseIf FRMSTRING = "PARTYBANK" Then
                Me.Text = "Bank Name Master"
            ElseIf FRMSTRING = "PROCESS" Then
                Me.Text = "Process Master"
            ElseIf FRMSTRING = "EMAIL" Then
                Me.Text = "Email Master"
            ElseIf FRMSTRING = "QUALITY" Then
                Me.Text = "Quality Master"
            ElseIf FRMSTRING = "GODOWN" Then
                Me.Text = "Godown Master"
            End If
            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If FRMSTRING = "CATEGORY" Then
            dttable = objClsCommon.search(" category_name AS NAME, category_id AS ID", "", "categorymaster", " and category_cmpid = " & CmpId & " and category_Locationid = " & Locationid & " and category_Yearid = " & YearId)
        ElseIf FRMSTRING = "COLORTYPE" Then
            dttable = objClsCommon.search(" COLORTYPE_name AS NAME, COLORTYPE_id AS ID", "", "COLORTYPEmaster", " and COLORTYPE_cmpid = " & CmpId & " and COLORTYPE_Locationid = " & Locationid & " and COLORTYPE_Yearid = " & YearId)
        ElseIf FRMSTRING = "MATERIAL TYPE" Then
            dttable = objClsCommon.search(" material_name AS NAME, material_id AS ID", "", "materialtypemaster", " and material_cmpid = " & CmpId & " and material_Locationid = " & Locationid & " and material_Yearid = " & YearId)
        ElseIf FRMSTRING = "COLOR" Then
            dttable = objClsCommon.search(" COLOR_name AS NAME, COLOR_id AS ID", "", "COLORmaster", " and COLOR_cmpid = " & CmpId & " and COLOR_Locationid = " & Locationid & " and COLOR_Yearid = " & YearId)
        ElseIf FRMSTRING = "DEPARTMENT" Then
            dttable = objClsCommon.search(" DEPARTMENT_name AS NAME, DEPARTMENT_id AS ID", "", "DEPARTMENTmaster", " and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_Locationid = " & Locationid & " and DEPARTMENT_Yearid = " & YearId)
        ElseIf FRMSTRING = "PIECE TYPE" Then
            dttable = objClsCommon.search(" PIECETYPE_name AS NAME, PIECETYPE_id AS ID", "", "PIECEtypemaster", " and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_Locationid = " & Locationid & " and PIECETYPE_Yearid = " & YearId)
        ElseIf FRMSTRING = "NARRATION" Then
            dttable = objClsCommon.search(" NARRATION_name AS NAME, NARRATION_id AS ID", "", "NARRATIONmaster", " and NARRATION_cmpid = " & CmpId & " and NARRATION_Locationid = " & Locationid & " and NARRATION_Yearid = " & YearId)
        ElseIf FRMSTRING = "PARTYBANK" Then
            dttable = objClsCommon.search(" PARTYBANK_name AS NAME, PARTYBANK_id AS ID", "", "PARTYBANKmaster", " and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_Locationid = " & Locationid & " and PARTYBANK_Yearid = " & YearId)
        ElseIf FRMSTRING = "PROCESS" Then
            dttable = objClsCommon.search(" PROCESS_name AS NAME, PROCESS_id AS ID", "", "PROCESSmaster", " and PROCESS_cmpid = " & CmpId & " and PROCESS_Locationid = " & Locationid & " and PROCESS_Yearid = " & YearId)
        ElseIf FRMSTRING = "EMAIL" Then
            dttable = objClsCommon.search(" EMAIL_ID AS NAME, EMAIL_UNIQUEID AS ID", "", "EMAILMASTER", " and EMAIL_Yearid = " & YearId)
        ElseIf FRMSTRING = "GODOWN" Then
            dttable = objClsCommon.search(" GODOWN_name AS NAME, GODOWN_id AS ID", "", "GODOWNmaster", " and GODOWN_cmpid = " & CmpId & " and GODOWN_Locationid = " & Locationid & " and GODOWN_Yearid = " & YearId)
        ElseIf FRMSTRING = "QUALITY" Then
            dttable = objClsCommon.search(" QUALITY_name AS NAME, QUALITY_id AS ID", "", "QUALITYmaster", " and QUALITY_cmpid = " & CmpId & " and QUALITY_Locationid = " & Locationid & " and QUALITY_Yearid = " & YearId)
        End If
        GRIDNAME.DataSource = dttable

    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"), gridledger.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try
            Dim objCategorymaster As New CategoryMaster
            objCategorymaster.EDIT = editval
            objCategorymaster.MdiParent = MDIMain
            objCategorymaster.frmString = FRMSTRING
            objCategorymaster.TempName = name
            objCategorymaster.TempID = id
            objCategorymaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        fillgrid()
    End Sub
End Class