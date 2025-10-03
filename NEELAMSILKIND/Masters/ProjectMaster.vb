
Imports BL

Public Class ProjectMaster
    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            TXTPROJECTNAME.Clear()
            txtremarks.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(sender As Object, e As EventArgs) Handles CMDSAVE.Click
        Try
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(TXTPROJECTNAME.Text.Trim)
            ALPARAVAL.Add(txtremarks.Text.Trim)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            Dim OBJPROJECT As New ClsProjectMaster




        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class