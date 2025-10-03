
Imports BL
Imports System.IO
Imports System.ComponentModel

Public Class ItemMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDPROCESSDOUBLECLICK, GRIDSTORESDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPPROW, TEMPUPLOADROW, TEMPSROW As Integer
    Public EDIT As Boolean
    Public tempItemName, tempItemCODE, frmstring As String
    Dim tempItemId As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbmaterial.Text.Trim)
            alParaval.Add(cmbcategory.Text.Trim)
            alParaval.Add(TXTDISPLAYNAME.Text.Trim)
            alParaval.Add(UCase(cmbitemname.Text.Trim))

            alParaval.Add(CMBDEPARTMENT.Text.Trim)
            alParaval.Add(CMBCODE.Text.Trim)
            alParaval.Add(cmbunit.Text.Trim)
            alParaval.Add(TXTFOLD.Text.Trim)
            alParaval.Add(TXTRATE.Text.Trim)
            alParaval.Add(Val(TXTTRANSPORTRATE.Text.Trim))
            alParaval.Add(Val(TXTCHECKINGRATE.Text.Trim))
            alParaval.Add(Val(TXTPACKINGRATE.Text.Trim))
            alParaval.Add(Val(TXTDESIGNRATE.Text.Trim))
            alParaval.Add(txtreorder.Text.Trim)
            alParaval.Add(txtupper.Text.Trim)
            alParaval.Add(txtlower.Text.Trim)
            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(CHKBLOCKED.CheckState)
            alParaval.Add(CHKHIDEINDESIGN.CheckState)

            alParaval.Add(TXTWIDTH.Text.Trim)
            alParaval.Add(TXTGREYWIDTH.Text.Trim)
            alParaval.Add(TXTSHRINKFROM.Text.Trim)
            alParaval.Add(TXTSHRINKTO.Text.Trim)
            alParaval.Add(TXTSELVEDGE.Text.Trim)


            'FOR GRIDPARAMETER
            Dim RATETYPE As String = ""
            Dim RATE As String = ""

            For Each ROW As DataGridViewRow In GRIDRATE.Rows
                If ROW.Cells(gratetype.Index).Value <> Nothing Then
                    If RATETYPE = "" Then
                        RATETYPE = ROW.Cells(gratetype.Index).Value.ToString
                        RATE = ROW.Cells(grate.Index).Value
                    Else
                        RATETYPE = RATETYPE & "|" & ROW.Cells(gratetype.Index).Value.ToString
                        RATE = RATE & "|" & ROW.Cells(grate.Index).Value
                    End If
                End If
            Next


            alParaval.Add(RATETYPE)
            alParaval.Add(RATE)

            Dim YARNQUALITY As String = ""
            Dim PER As String = ""

            For Each ROW As DataGridViewRow In GRIDCOMP.Rows
                If ROW.Cells(GYARNQUALITY.Index).Value <> Nothing Then
                    If YARNQUALITY = "" Then
                        YARNQUALITY = ROW.Cells(GYARNQUALITY.Index).Value.ToString
                        PER = Val(ROW.Cells(GPER.Index).Value)
                    Else
                        YARNQUALITY = YARNQUALITY & "|" & ROW.Cells(GYARNQUALITY.Index).Value.ToString
                        PER = PER & "|" & Val(ROW.Cells(GPER.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(YARNQUALITY)
            alParaval.Add(PER)



            Dim gridsrno As String = ""
            Dim PROCESS As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDPROCESS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(PSRNO.Index).Value.ToString
                        PROCESS = row.Cells(PPROCESS.Index).Value.ToString
                    Else
                        gridsrno = gridsrno & "|" & row.Cells(PSRNO.Index).Value.ToString
                        PROCESS = PROCESS & "|" & row.Cells(PPROCESS.Index).Value.ToString
                    End If
                End If
            Next


            alParaval.Add(gridsrno)
            alParaval.Add(PROCESS)

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(frmstring)

            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTWARP.Text.Trim)
            alParaval.Add(TXTWEFT.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)



            Dim STORESRNO As String = ""
            Dim STOREITEMNAME As String = ""
            Dim STOREQTY As String = ""

            For Each row As System.WINDOWS.FORMS.DataGridViewRow In GRIDSTORES.Rows
                If row.Cells(0).Value <> Nothing Then
                    If STORESRNO = "" Then
                        STORESRNO = row.Cells(SSRNO.Index).Value.ToString
                        STOREITEMNAME = row.Cells(SSTOREITEM.Index).Value.ToString
                        STOREQTY = Val(row.Cells(SQTY.Index).Value)
                    Else
                        STORESRNO = STORESRNO & "|" & row.Cells(SSRNO.Index).Value.ToString
                        STOREITEMNAME = STOREITEMNAME & "|" & row.Cells(SSTOREITEM.Index).Value.ToString
                        STOREQTY = STOREQTY & "|" & Val(row.Cells(SQTY.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(STORESRNO)
            alParaval.Add(STOREITEMNAME)
            alParaval.Add(STOREQTY)


            Dim objclsItemMaster As New clsItemmaster
            objclsItemMaster.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsItemMaster.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempItemId)
                IntResult = objclsItemMaster.UPDATE()
                MsgBox("Details Updated")

            End If
            EDIT = False

            clear()
            cmbitemname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(cmbitemname.Text) <> LCase(tempItemName)) Then
                dt = objclscommon.search("item_name", "", "ItemMaster", " and item_name = '" & cmbitemname.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "NEELAMSILKIND")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTDISPLAYNAME.Text.Trim.Length = 0 Then
            Ep.SetError(TXTDISPLAYNAME, "Fill Item Name")
            bln = False
        End If

        If TXTHSNCODE.Text.Trim.Length = 0 Then
            Ep.SetError(TXTHSNCODE, "Fill HSN Code")
            bln = False
        End If

        If cmbitemname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbitemname, "Fill Item Name")
            bln = False
        End If

        If Not CHECKDUPLICATE() Then
            Ep.SetError(cmbitemname, "Item Name Already Exists")
            bln = False
        End If

        If CMBCODE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBCODE, "Fill Item Code")
            bln = False
        End If

        If cmbmaterial.Text.Trim.Length = 0 Then
            Ep.SetError(cmbmaterial, "Select Material Type")
            bln = False
        End If

        If Val(TXTTOTALPER.Text.Trim) <> 100 And GRIDCOMP.RowCount > 0 Then
            Ep.SetError(TXTTOTALPER, "Check %")
            bln = False
        End If

        If ClientName = "AVIS" And cmbcategory.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcategory, "Select Category")
            bln = False
        End If



        Return bln
    End Function

    Sub CLEAR()

        cmbmaterial.Text = ""
        cmbcategory.Text = ""
        TXTDISPLAYNAME.Clear()
        cmbitemname.Text = ""
        CMBDEPARTMENT.Text = ""
        cmbunit.Text = ""
        CMBCODE.Text = ""
        TXTFOLD.Clear()
        TXTRATE.Clear()
        TXTTRANSPORTRATE.Clear()
        TXTPACKINGRATE.Clear()
        TXTCHECKINGRATE.Clear()
        TXTDESIGNRATE.Clear()
        txtlower.Clear()
        txtreorder.Clear()
        txtupper.Clear()
        If ClientName = "SOFTAS" Then TXTHSNCODE.Text = "5407" Else TXTHSNCODE.Clear()
        TXTPHOTOIMGPATH.Clear()
        PBPHOTO.Image = Nothing
        If ClientName = "SAFFRON" Then txtremarks.Text = "SPUNTEX MIX QUALITY" Else txtremarks.Clear()
        CMBYARNQUALITY.Text = ""
        TXTPER.Clear()
        CHKBLOCKED.CheckState = CheckState.Unchecked
        CHKHIDEINDESIGN.CheckState = CheckState.Unchecked

        If ClientName = "KEMLINO" Then
            TXTWIDTH.Text = "147 CMS"
        ElseIf ClientName = "MOHATUL" Then
            TXTWIDTH.Text = "58"
        Else
            TXTWIDTH.Clear()
        End If
        TXTGREYWIDTH.Clear()
        TXTSHRINKFROM.Clear()
        TXTSHRINKTO.Clear()
        TXTSELVEDGE.Clear()
        TXTWARP.Clear()
        TXTWEFT.Clear()

        CMBPROCESS.Text = ""
        TXTPSRNO.Clear()

        TXTSSRNO.Clear()
        CMBSTOREITEM.Text = ""
        TXTSTOREQTY.Clear()



        GRIDRATE.RowCount = 0
        GRIDCOMP.RowCount = 0
        GRIDPROCESS.RowCount = 0
        GRIDSTORES.RowCount = 0
        TXTTOTALPER.Clear()

        GRIDDOUBLECLICK = False
        GRIDPROCESSDOUBLECLICK = False
        GRIDSTORESDOUBLECLICK = False

    End Sub

    Private Sub cmbcategory_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Enter
        Try
            If cmbcategory.Text.Trim = "" Then fillCATEGORY(cmbcategory, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcategory.Validating
        Try
            If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.Enter
        Try
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode =System.WINDOWS.FORMS.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        fillCATEGORY(cmbcategory, False)

        dt = objclscommon.search("item_name", "", "ItemMaster", " AND ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Item_name"
            cmbitemname.DataSource = dt
            cmbitemname.DisplayMember = "Item_name"
            cmbitemname.Text = ""
        End If


        dt = objclscommon.search("item_CODE", "", "ItemMaster", " AND ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Item_CODE"
            CMBCODE.DataSource = dt
            CMBCODE.DisplayMember = "Item_CODE"
            CMBCODE.Text = ""
        End If

        If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        If CMBSTOREITEM.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEM)

    End Sub

    Private Sub ItemMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            cmbitemname.Text = tempItemName
            CMBCODE.Text = tempItemCODE
            If ClientName = "SAFFRON" Then txtremarks.Text = "SPUNTEX MIX QUALITY" Else txtremarks.Clear()
            If ClientName = "SOFTAS" Then TXTHSNCODE.Text = "5407"
            If ClientName = "MOHATUL" Then TXTWIDTH.Text = "58"

            If frmstring = "MERCHANT" Then
                cmbmaterial.Visible = False
                lblmaterial.Visible = False
                cmbmaterial.Text = "Finished Goods"
            End If

            If EDIT = True Then

                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search("  ITEMMASTER.item_id AS ITEMID, MATERIALTYPEMASTER.material_name AS MATERIALTYPE, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_BLOCKED, 0) AS BLOCKED, ISNULL(ITEMMASTER.item_HIDEINDESIGN, 0) AS HIDEINDESIGN,  ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ITEMMASTER.item_reorder AS REORDER, ITEMMASTER.ITEM_FOLD AS FOLD, ITEMMASTER.ITEM_RATE AS RATE,ITEMMASTER.ITEM_TRANSRATE AS TRANSPORTRATE,ITEMMASTER.ITEM_CHECKRATE AS CHECKINGRATE,ITEMMASTER.ITEM_PACKRATE AS PACKINGRATE,ITEMMASTER.ITEM_DESIGNRATE AS DESIGNRATE, ITEMMASTER.item_upper AS UPPER, ITEMMASTER.item_lower AS LOWER, ISNULL(ITEM_WIDTH,'') AS WIDTH, ISNULL(ITEM_GREYWIDTH,'') AS GREYWIDTH, ISNULL(ITEM_SHRINKFROM,0) AS SHRINKFROM, ISNULL(ITEM_SHRINKTO,0) AS SHRINKTO, ISNULL(ITEM_SELVEDGE,'') AS SELVEDGE, ISNULL(ITEMMASTER.item_remarks, '') AS REMARKS,ITEMMASTER.ITEM_PHOTO AS IMGPATH,ISNULL(ITEM_WARP,'') AS WARP ,ISNULL(ITEM_WEFT,'') AS WEFT, ISNULL(ITEMMASTER.ITEM_DISPLAYNAME, '') AS DISPLAYNAME, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE ", "", " ITEMMASTER INNER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id ", " and ITEMMASTER.Item_Name = '" & tempItemName & "' AND ITEMMASTER.ITEM_FRMSTRING = '" & frmstring & "' and ITEMMASTER.Item_yearid = " & YearId)
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        tempItemId = ROW("ITEMID")
                        cmbmaterial.Text = ROW("MATERIALTYPE").ToString
                        cmbcategory.Text = ROW("CATEGORY").ToString
                        TXTDISPLAYNAME.Text = ROW("DISPLAYNAME").ToString
                        cmbitemname.Text = ROW("ITEMNAME").ToString
                        CMBCODE.Text = ROW("ITEMCODE").ToString
                        tempItemCODE = ROW("ITEMCODE").ToString
                        cmbunit.Text = ROW("UNIT").ToString
                        CMBDEPARTMENT.Text = ROW("DEPARTMENT").ToString
                        txtreorder.Text = Val(ROW("REORDER").ToString)
                        TXTFOLD.Text = ROW("FOLD").ToString
                        TXTRATE.Text = Val(ROW("RATE").ToString)
                        TXTTRANSPORTRATE.Text = Val(ROW("TRANSPORTRATE").ToString)
                        TXTCHECKINGRATE.Text = Val(ROW("CHECKINGRATE").ToString)
                        TXTPACKINGRATE.Text = Val(ROW("PACKINGRATE").ToString)
                        TXTDESIGNRATE.Text = Val(ROW("DESIGNRATE").ToString)
                        txtupper.Text = Val(ROW("UPPER").ToString)
                        txtlower.Text = Val(ROW("LOWER").ToString)
                        TXTHSNCODE.Text = ROW("HSNCODE").ToString
                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                        CHKHIDEINDESIGN.Checked = Convert.ToBoolean(dttable.Rows(0).Item("HIDEINDESIGN"))

                        TXTWIDTH.Text = ROW("WIDTH").ToString
                        TXTGREYWIDTH.Text = ROW("GREYWIDTH").ToString
                        TXTSHRINKFROM.Text = Val(ROW("SHRINKFROM"))
                        TXTSHRINKTO.Text = Val(ROW("SHRINKTO"))
                        TXTSELVEDGE.Text = ROW("SELVEDGE").ToString


                        txtremarks.Text = ROW("REMARKS").ToString
                        If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                            PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                            TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                        Else
                            PBPHOTO.Image = Nothing
                            TXTWARP.Text = ROW("WARP").ToString
                            TXTWEFT.Text = ROW("WEFT").ToString
                        End If
                    Next



                    'CHARGES GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dttable1 As DataTable = OBJCMN.search(" ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(ITEMMASTER_COMPOSITION.ITEM_PER, 0) AS PER ", "", " YARNQUALITYMASTER INNER JOIN ITEMMASTER_COMPOSITION ON YARNQUALITYMASTER.YARN_ID = ITEMMASTER_COMPOSITION.ITEM_YARNQUALITYID RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_COMPOSITION.ITEM_YEARID = ITEMMASTER.item_yearid AND ITEMMASTER_COMPOSITION.ITEM_ID = ITEMMASTER.item_id ", " AND ITEMMASTER_COMPOSITION.ITEM_ID = " & tempItemId & " AND ITEMMASTER_COMPOSITION.ITEM_YEARID = " & YearId)
                    If dttable1.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable1.Rows
                            GRIDCOMP.Rows.Add(DTR("YARNQUALITY"), DTR("PER"))
                        Next
                        TOTAL()
                    End If


                    'PROCESS GRID
                    Dim dt As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER_PROCESS.ITEM_SRNO, 0) AS GRIDSRNO, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS", "", "  PROCESSMASTER LEFT OUTER JOIN ITEMMASTER_PROCESS ON PROCESSMASTER.PROCESS_ID = ITEMMASTER_PROCESS.ITEM_PROCESSID ", " AND ITEMMASTER_PROCESS.ITEM_ID = " & tempItemId & " AND ITEMMASTER_PROCESS.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTR1 As DataRow In dt.Rows
                            GRIDPROCESS.Rows.Add(DTR1("GRIDSRNO"), DTR1("PROCESS"))
                        Next
                    End If


                    'STORES GRID
                    dt = OBJCMN.search(" ISNULL(ITEMMASTER_STORES.ITEM_SRNO, 0) AS GRIDSRNO, ISNULL(STOREITEMMASTER.STOREITEM_NAME, '') AS STOREITEM, ISNULL(ITEMMASTER_STORES.ITEM_QTY, 0) AS STOREQTY", "", "  STOREITEMMASTER INNER JOIN ITEMMASTER_STORES ON STOREITEMMASTER.STOREITEM_ID = ITEMMASTER_STORES.ITEM_STOREITEMID ", " AND ITEMMASTER_STORES.ITEM_ID = " & tempItemId & " AND ITEMMASTER_STORES.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTR1 As DataRow In dt.Rows
                            GRIDSTORES.Rows.Add(DTR1("GRIDSRNO"), DTR1("STOREITEM"), Val(DTR1("STOREQTY")))
                        Next
                    End If

                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_name", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Item_name"
                    cmbitemname.DataSource = dt
                    cmbitemname.DisplayMember = "Item_name"
                    cmbitemname.Text = ""
                End If
                cmbitemname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Validated
        Try
            If CMBCODE.Text.Trim = "" And cmbitemname.Text.Trim <> "" Then CMBCODE.Text = cmbitemname.Text.Trim
            If TXTDISPLAYNAME.Text.Trim = "" And cmbitemname.Text.Trim <> "" Then TXTDISPLAYNAME.Text = cmbitemname.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        If cmbitemname.Text.Trim <> "" Then
            uppercase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(cmbitemname.Text) <> LCase(tempItemName)) Then
                dt = objclscommon.search("item_name", "", "ItemMaster", " and item_name = '" & cmbitemname.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "NEELAMSILKIND")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        '**** code for to delete the selected imtem from item master *****
        ' ****Logic 
        ' looking for in SalesOrder_Desc Table if Item master Name is Exists OR Not
        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        If cmbitemname.Text.Trim = "" Then
            MsgBox("Item Name Can Not Be Blank ")
            Exit Sub
        End If

        If EDIT = False Then
            'since user can delete Master only in edit mode
            MsgBox("Item Name Can Delete only in Edit Mode", MsgBoxStyle.Critical, "NEELAMSILKIND")
            Exit Sub
        End If
        If cmbitemname.Text.Trim <> "" Then
            pcase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("item_name", "", " dbo.ITEMMASTER RIGHT OUTER JOIN  dbo.SALEORDER_DESC ON dbo.ITEMMASTER.item_id = dbo.SALEORDER_DESC.so_itemid ", " and item_name = '" & cmbitemname.Text.Trim & "' AND item_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "NEELAMSILKIND")
                Exit Sub
            End If

            dt = objclscommon.search("ITEMNAME", "", " BARCODESTOCK ", " and ITEMNAME = '" & cmbitemname.Text.Trim & "' AND YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "NEELAMSILKIND")
                Exit Sub
            End If

            dt = objclscommon.search("ITEMNAME", "", " OUTBARCODESTOCK ", " and ITEMNAME = '" & cmbitemname.Text.Trim & "' AND YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "NEELAMSILKIND")
                Exit Sub
            End If

        End If
        'Dim tempMsg As Integer
        ''if above all conditions are false then only user can delete Particular Master
        If MsgBox("Delete Item Name ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim alParaval As New ArrayList
            alParaval.Add(cmbitemname.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(YearId)
            Dim clsitemst As New clsItemmaster
            clsitemst.alParaval = alParaval
            IntResult = clsitemst.Delete()
            MsgBox("Item Deleted")
            CLEAR()
            EDIT = False
        End If

    End Sub

    Private Sub CMBDEPARTMENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_CODE", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Item_CODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "Item_CODE"
                    CMBCODE.Text = ""
                End If
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                uppercase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(CMBCODE.Text) <> LCase(tempItemCODE)) Then
                    dt = objclscommon.search("item_CODE", "", "ItemMaster", " and item_CODE = '" & CMBCODE.Text.Trim & "' And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Item Code Already Exists", MsgBoxStyle.Critical, "NEELAMSILKIND")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGRIDRATE.KeyPress, TXTRATE.KeyPress, TXTSHRINKFROM.KeyPress, TXTSHRINKTO.KeyPress, TXTPER.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtrate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGRIDRATE.Validating
        Try
            If Val(TXTGRIDRATE.Text.Trim) > 0 And cmbratetype.Text.Trim <> "" Then
                If Not checkRATETYPE() Then
                    MsgBox("Rate already Present in Grid below")
                    Exit Sub
                End If

                fillgrid()
                cmbratetype.Text = ""
                TXTGRIDRATE.Clear()
                cmbratetype.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkRATETYPE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDRATE.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If cmbratetype.Text.Trim = row.Cells(gratetype.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDRATE.Rows.Add(cmbratetype.Text.Trim, Val(TXTGRIDRATE.Text.Trim))
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDRATE.Item("GRATETYPE", TEMPROW).Value = cmbratetype.Text.Trim
            GRIDRATE.Item("GRATE", TEMPROW).Value = Val(TXTGRIDRATE.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        GRIDRATE.ClearSelection()

    End Sub

    Private Sub GRIDRATE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRATE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDRATE.Item("GRATETYPE", e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                cmbratetype.Text = GRIDRATE.Item("GRATETYPE", e.RowIndex).Value
                TXTGRIDRATE.Text = GRIDRATE.Item("GRATE", e.RowIndex).Value
                cmbratetype.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRATE.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDRATE.Rows.RemoveAt(GRIDRATE.CurrentRow.Index)
        End If
    End Sub

    Private Sub CMDPHOTOUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTPHOTOIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTPHOTOIMGPATH.Text.Trim.Length <> 0 Then PBPHOTO.ImageLocation = TXTPHOTOIMGPATH.Text.Trim
    End Sub

    Private Sub CMDPHOTOREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOREMOVE.Click
        Try
            PBPHOTO.Image = Nothing
            TXTPHOTOIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPHOTOVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOVIEW.Click
        Try
            If TXTPHOTOIMGPATH.Text.Trim <> "" Then
                If Path.GetExtension(TXTPHOTOIMGPATH.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(TXTPHOTOIMGPATH.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBPHOTO.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTHSNCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTHSNCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then TXTHSNCODE.Text = OBJLEDGER.TEMPCODE

                If OBJLEDGER.TEMPCODE <> "" Then
                    TXTHSNCODE.Text = OBJLEDGER.TEMPCODE
                End If

                If OBJLEDGER.TEMPCODEDESC <> "" And ClientName = "SAFFRON" Then
                    txtremarks.Text = OBJLEDGER.TEMPCODEDESC
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If HIDESTORES = False Then GPSTORES.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPER.Validating
        Try
            If Val(TXTPER.Text.Trim) < 0 And Val(TXTPER.Text.Trim) > 100 Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPER.Validated
        Try
            If Val(TXTPER.Text.Trim) > 0 And CMBYARNQUALITY.Text.Trim <> "" Then
                If Not checkPERTYPE() Then
                    MsgBox("% already Present in Grid below")
                    Exit Sub
                End If

                fillgridCOMP()
                TOTAL()

                CMBYARNQUALITY.Text = ""
                TXTPER.Clear()
                CMBYARNQUALITY.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridCOMP()

        If GRIDDOUBLECLICK = False Then
            GRIDCOMP.Rows.Add(CMBYARNQUALITY.Text.Trim, Val(TXTPER.Text.Trim))
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDCOMP.Item("GYARNQUALITY", TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDCOMP.Item("GPER", TEMPROW).Value = Val(TXTPER.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        TOTAL()
        CMBYARNQUALITY.Text = ""
        TXTPER.Clear()

        GRIDCOMP.ClearSelection()

    End Sub

    Function checkPERTYPE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDCOMP.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If CMBYARNQUALITY.Text.Trim = row.Cells(GYARNQUALITY.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDCOMP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCOMP.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCOMP.Item("GYARNQUALITY", e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                CMBYARNQUALITY.Text = GRIDCOMP.Item("GYARNQUALITY", e.RowIndex).Value
                TXTPER.Text = GRIDCOMP.Item("GPER", e.RowIndex).Value
                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCOMP.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDCOMP.Rows.RemoveAt(GRIDCOMP.CurrentRow.Index)
        End If
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALPER.Text = "0.00"

            For Each ROW As DataGridViewRow In GRIDCOMP.Rows
                TXTTOTALPER.Text = Format(Val(TXTTOTALPER.Text) + Val(ROW.Cells(GPER.Index).EditedFormattedValue), "0.00")
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillPROCESSgrid()

        If GRIDPROCESSDOUBLECLICK = False Then
            GRIDPROCESS.Rows.Add(Val(TXTPSRNO.Text.Trim), CMBPROCESS.Text.Trim)
            getsrno(GRIDPROCESS)
        ElseIf GRIDPROCESSDOUBLECLICK = True Then
            GRIDPROCESS.Item("PSRNO", TEMPPROW).Value = Val(TXTPSRNO.Text.Trim)
            GRIDPROCESS.Item("PPROCESS", TEMPPROW).Value = CMBPROCESS.Text.Trim
            TEMPPROW = GRIDPROCESS.CurrentRow.Index
            TXTPSRNO.Focus()
            GRIDPROCESSDOUBLECLICK = False
        End If
        CMBPROCESS.Text = ""
        GRIDPROCESS.ClearSelection()

    End Sub

    Private Sub CMBPROCESS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Validated
        If CMBPROCESS.Text.Trim <> "" Then
            fillPROCESSgrid()
        Else
            If CMBPROCESS.Text.Trim = "" Then
                MsgBox("Enter Process Name....", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub TXTPSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPSRNO.GotFocus
        TXTPSRNO.Text = Val(GRIDPROCESS.RowCount + 1)
    End Sub

    Private Sub GRIDPROCESS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPROCESS.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDPROCESS.Item("PPROCESS", e.RowIndex).Value <> Nothing Then
                GRIDPROCESSDOUBLECLICK = True
                TEMPPROW = e.RowIndex
                TXTPSRNO.Text = Val(GRIDPROCESS.Item("PSRNO", e.RowIndex).Value)
                CMBPROCESS.Text = GRIDPROCESS.Item("PPROCESS", e.RowIndex).Value
                CMBPROCESS.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROCESS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPROCESS.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDPROCESS.Rows.RemoveAt(GRIDPROCESS.CurrentRow.Index)
            getsrno(GRIDPROCESS)
        End If
    End Sub

    Private Sub TXTTRANSPORTRATE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTRANSPORTRATE.KeyPress, TXTDESIGNRATE.KeyPress, TXTPACKINGRATE.KeyPress, TXTCHECKINGRATE.KeyPress, TXTSTOREQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBSTOREITEM_Enter(sender As Object, e As EventArgs) Handles CMBSTOREITEM.Enter
        Try
            If CMBSTOREITEM.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEM)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTOREITEM_Validating(sender As Object, e As CancelEventArgs) Handles CMBSTOREITEM.Validating
        Try
            If CMBSTOREITEM.Text.Trim <> "" Then STOREITEMVALIDATE(CMBSTOREITEM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSTORESGRID()

        If GRIDSTORESDOUBLECLICK = False Then
            GRIDSTORES.Rows.Add(Val(TXTSSRNO.Text.Trim), CMBSTOREITEM.Text.Trim, Val(TXTSTOREQTY.Text.Trim))
            getsrno(GRIDSTORES)
        ElseIf GRIDSTORESDOUBLECLICK = True Then
            GRIDSTORES.Item(SSRNO.Index, TEMPSROW).Value = Val(TXTSSRNO.Text.Trim)
            GRIDSTORES.Item(SSTOREITEM.Index, TEMPSROW).Value = CMBSTOREITEM.Text.Trim
            GRIDSTORES.Item(SQTY.Index, TEMPSROW).Value = Val(TXTSTOREQTY.Text.Trim)
            TEMPSROW = GRIDSTORES.CurrentRow.Index
            TXTSSRNO.Focus()
            GRIDSTORESDOUBLECLICK = False
        End If
        CMBSTOREITEM.Text = ""
        TXTSTOREQTY.Clear()
        GRIDSTORES.ClearSelection()

    End Sub

    Private Sub TXTSSRNO_GotFocus(sender As Object, e As EventArgs) Handles TXTSSRNO.GotFocus
        TXTSSRNO.Text = Val(GRIDSTORES.RowCount + 1)
    End Sub

    Private Sub GRIDSTORES_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSTORES.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDSTORES.Item(SSTOREITEM.Index, e.RowIndex).Value <> Nothing Then
                GRIDSTORESDOUBLECLICK = True
                TEMPSROW = e.RowIndex
                TXTSSRNO.Text = Val(GRIDSTORES.Item(SSRNO.Index, e.RowIndex).Value)
                CMBSTOREITEM.Text = GRIDSTORES.Item(SSTOREITEM.Index, e.RowIndex).Value
                TXTSTOREQTY.Text = Val(GRIDSTORES.Item(SQTY.Index, e.RowIndex).Value)
                CMBSTOREITEM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSTORES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTORES.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDSTORES.Rows.RemoveAt(GRIDSTORES.CurrentRow.Index)
            getsrno(GRIDSTORES)
        End If
    End Sub

    Private Sub TXTSTOREQTY_Validated(sender As Object, e As EventArgs) Handles TXTSTOREQTY.Validated
        Try
            If CMBSTOREITEM.Text.Trim <> "" And Val(TXTSTOREQTY.Text.Trim) > 0 Then
                FILLSTORESGRID()
            Else
                If CMBSTOREITEM.Text.Trim = "" Then
                    MsgBox("Enter Store Item Name....", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFOLD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTFOLD.KeyPress
        Try
            If ClientName = "KARAN" Then numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class