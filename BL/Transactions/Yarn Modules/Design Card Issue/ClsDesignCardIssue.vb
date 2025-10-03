
Imports DB

Public Class ClsDesignCardIssue

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
            Dim strCommand As String = "SP_TRANS_DESIGNCARDISSUE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTWASTAGE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SELVEDGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALPICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOBBINCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOOMSMPRECD", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_DESIGNCARDISSUE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTWASTAGE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTTL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SELVEDGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALPICKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOBBINCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOOMSMPRECD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CARDNO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTCARD(ByVal CARDNO As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTDESIGNCARDISSUE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CARDNO", CARDNO))
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
            Dim strCommand As String = "SP_TRANS_DESIGNCARDISSUE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CARDNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
