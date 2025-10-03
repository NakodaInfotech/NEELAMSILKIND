
Imports DB

Public Class ClsOpeningYarnDyeingProgram

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

    Public Function SAVE() As DataTable
        Dim DTTABLE As DataTable
        Try
            'save purchase order
            Dim strCommand As String = "SP_TRANS_OPENINGYARNDYEINGPROGRAM_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PROGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@refNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@discount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMYARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REDYEING", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@rate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1




            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_OPENINGYARNDYEINGPROGRAM_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PROGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@refNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@discount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMYARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REDYEING", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@rate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PROGRAMNO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPROGRAM(ByVal PROGRAMNO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTOPENINGYARNDYEINGPROGRAM_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PROGRAMNO", PROGRAMNO))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_OPENINGYARNDYEINGPROGRAM_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PROGRAMNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
