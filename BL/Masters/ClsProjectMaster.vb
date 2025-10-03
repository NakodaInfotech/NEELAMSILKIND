
Imports DB

Public Class ClsProjectMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_CITYMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@city_name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_remark", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_transfer", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_CITYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@city_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@city_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@city_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@city_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@city_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@city_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@city_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cityid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
