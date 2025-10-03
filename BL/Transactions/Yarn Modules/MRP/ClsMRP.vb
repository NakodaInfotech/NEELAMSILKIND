
Imports DB

Public Class ClsMRP

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
        Dim DT As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_MRP_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MRPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTOTALREQ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEAVERSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPENDINGSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGODOWNSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALORDEREDSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNEWORDERSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREQ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVERSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PENDINGSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWNSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDEREDSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWORDERSTOCK", alParaval(I)))
                I = I + 1


            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_MRP_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MRPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WARPWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEFTWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTOTALREQ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWEAVERSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPENDINGSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGODOWNSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALORDEREDSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNEWORDERSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREQ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVERSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PENDINGSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWNSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDEREDSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWORDERSTOCK", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@MRP_NO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTMRP() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_MRP_SELECT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MRPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

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
            Dim strCommand As String = "SP_TRANS_MRP_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MRPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

End Class
