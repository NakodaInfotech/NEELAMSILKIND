
Imports DB

Public Class ClsDesignCardCost

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
            Dim strCommand As String = "SP_MASTER_DESIGNCARDCOST_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@COSTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ACTUALPICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTPICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DHARA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DHARACOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DHARAACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGECOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGEACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVINGCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVINGACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOBINCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOBINACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARGINCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARGINACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALCOSTDIFF", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1



                ''FOR GRIDSEL

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
                .Add(New SqlClient.SqlParameter("@SELRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELRATEANDGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELCOST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELACTWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELACTCOST", alParaval(I)))
                I += 1

                ''For GRIDWARP

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
                .Add(New SqlClient.SqlParameter("@WARPRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPRATEGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPCOST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPACTWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPACTCOST", alParaval(I)))
                I += 1


                ''For GRIDWEFT
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
                .Add(New SqlClient.SqlParameter("@WEFTRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTRATEGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTCOST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTACTWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTACTCOST", alParaval(I)))
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

            strcommand = "SP_MASTER_DESIGNCARDCOST_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@COSTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ACTUALPICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSELACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWARPACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTPICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEFTACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DHARA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DHARACOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DHARAACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGECOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGEACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVINGCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVINGACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOBINCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOBINACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARGINCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARGINACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALACTCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALCOSTDIFF", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1



                ''FOR GRIDSEL

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
                .Add(New SqlClient.SqlParameter("@SELRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELRATEANDGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELCOST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELACTWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELACTCOST", alParaval(I)))
                I += 1

                ''For GRIDWARP

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
                .Add(New SqlClient.SqlParameter("@WARPRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPRATEGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPCOST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPACTWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARPACTCOST", alParaval(I)))
                I += 1


                ''For GRIDWEFT
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
                .Add(New SqlClient.SqlParameter("@WEFTRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTRATEGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTCOST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTACTWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTACTCOST", alParaval(I)))
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

    Public Function DELETE() As Integer

        Try
            Dim strCommand As String = "SP_MASTER_DESIGNCARDCOST_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPCARDID", alParaval(0)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
                I += 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
            Return 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SELECTCOST() As DataTable

        Try
            Dim strCommand As String = "SP_MASTER_DESIGNCARDCOST_SELECT"
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
