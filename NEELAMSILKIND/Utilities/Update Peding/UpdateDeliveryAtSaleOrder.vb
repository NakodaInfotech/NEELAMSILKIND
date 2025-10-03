
Imports System.ComponentModel
Imports BL

Public Class UpdateDeliveryAtSaleOrder

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            TXTSONO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            CMBTYPE.SelectedIndex = 0
            TXTSONO.Clear()
            TXTNAME.Clear()
            TXTDELIVERYAT.Clear()
            TXTITEMNAME.Clear()
            TXTPCS.Clear()
            CMBDELIVERYAT.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPDATE.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DTLEDGER As DataTable = OBJCMN.search("ISNULL(ACC_ID,0) AS LEDGERID", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBDELIVERYAT.Text.Trim & "' AND ACC_YEARID = " & YearId)
            Dim DT As New DataTable
            If CMBTYPE.Text = "SALE ORDER" Then
                DT = OBJCMN.Execute_Any_String(" UPDATE SALEORDER SET SALEORDER.SO_PACKINGID = " & DTLEDGER.Rows(0).Item("LEDGERID") & " WHERE SALEORDER.SO_NO = " & Val(TXTSONO.Text.Trim) & " AND SALEORDER.SO_YEARID = " & YearId, "", "")
            Else
                DT = OBJCMN.Execute_Any_String(" UPDATE OPENINGSALEORDER SET OPENINGSALEORDER.OPSO_PACKINGID = " & DTLEDGER.Rows(0).Item("LEDGERID") & " WHERE OPENINGSALEORDER.OPSO_NO = " & Val(TXTSONO.Text.Trim) & " AND OPENINGSALEORDER.OPSO_YEARID = " & YearId, "", "")
            End If
            MsgBox("Delivery At Updated Successfully")
            CLEAR()
            TXTSONO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Val(TXTSONO.Text.Trim) = 0 Then
            EP.SetError(TXTSONO, "Enter SO No")
            bln = False
        End If

        If CMBDELIVERYAT.Text.Trim = "" Then
            EP.SetError(CMBDELIVERYAT, "Delivery Name Cannot be Blank")
            bln = False
        End If

        Return bln
    End Function

    Private Sub TXTSONO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSONO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub UpdateDeliveryAtSaleOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSONO_Validated(sender As Object, e As EventArgs) Handles TXTSONO.Validated
        Try
            If Val(TXTSONO.Text.Trim) > 0 Then
                'GET DYEING NAME
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If CMBTYPE.Text = "SALE ORDER" Then
                    DT = OBJCMN.search(" TOP 1 ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME, ISNULL(SALEORDER.SO_TOTALQTY,0) AS PCS, ISNULL(DELIVERYATLEDGERS.ACC_CMPNAME,'') AS DELIVERYAT ", "", "SALEORDER INNER JOIN LEDGERS ON SALEORDER.SO_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN LEDGERS AS DELIVERYATLEDGERS ON SALEORDER.SO_PACKINGID = DELIVERYATLEDGERS.ACC_ID INNER JOIN SALEORDER_DESC ON SALEORDER.SO_NO = SALEORDER_DESC.SO_NO AND SALEORDER.SO_YEARID = SALEORDER_DESC.SO_YEARID LEFT OUTER JOIN ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.ITEM_ID", " AND SALEORDER.SO_NO = " & Val(TXTSONO.Text.Trim) & " AND SALEORDER.SO_YEARID = " & YearId)
                Else
                    DT = OBJCMN.search(" TOP 1 ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME, ISNULL(OPENINGSALEORDER.OPSO_TOTALQTY,0) AS PCS, ISNULL(DELIVERYATLEDGERS.ACC_CMPNAME,'') AS DELIVERYAT ", "", " OPENINGSALEORDER INNER JOIN LEDGERS ON OPENINGSALEORDER.OPSO_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN LEDGERS AS DELIVERYATLEDGERS ON OPENINGSALEORDER.OPSO_PACKINGID = DELIVERYATLEDGERS.ACC_ID INNER JOIN OPENINGSALEORDER_DESC ON OPENINGSALEORDER.OPSO_NO = OPENINGSALEORDER_DESC.OPSO_NO AND OPENINGSALEORDER.OPSO_YEARID = OPENINGSALEORDER_DESC.OPSO_YEARID LEFT OUTER JOIN ITEMMASTER ON OPENINGSALEORDER_DESC.OPSO_ITEMID = ITEMMASTER.ITEM_ID", " AND OPENINGSALEORDER.OPSO_NO = " & Val(TXTSONO.Text.Trim) & " AND OPENINGSALEORDER.OPSO_YEARID = " & YearId)
                End If
                If DT.Rows.Count > 0 Then
                    TXTNAME.Text = DT.Rows(0).Item("NAME")
                    TXTDELIVERYAT.Text = DT.Rows(0).Item("DELIVERYAT")
                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    TXTPCS.Text = Val(DT.Rows(0).Item("PCS"))
                    CMBDELIVERYAT.Text = DT.Rows(0).Item("DELIVERYAT")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateDeliveryAtSaleOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillname(CMBDELIVERYAT, False, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')   AND ACC_TYPE = 'ACCOUNTS'")
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDELIVERYAT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDELIVERYAT.Validating
        Try
            If CMBDELIVERYAT.Text.Trim <> "" Then namevalidate(CMBDELIVERYAT, CMBCODE, e, Me, TXTADD, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class