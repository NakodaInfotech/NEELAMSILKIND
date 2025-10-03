
Imports DB

Public Class ClsDesignCardMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_DESIGNCARD_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REEDSPACE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTPICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTWT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SELSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELSHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELWT", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@WARPSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPSHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@WEFTSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTSHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTPICK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTWT", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer

        Dim strcommand As String = ""

        Try

            strcommand = "SP_MASTER_DESIGNCARD_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REEDSPACE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTPICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTWT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SELSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELSHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELWT", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@WARPSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPSHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@WEFTSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTSHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTPICK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTWT", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@TEMPCARDID", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable

        Try
            Dim strCommand As String = "SP_MASTER_DESIGNCARD_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPCARDID", alParaval(0)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
                I += 1
            End With
            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
