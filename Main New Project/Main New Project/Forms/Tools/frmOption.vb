Public Class frmOption
    Dim arrCtl() As String = {} : Dim arrVal() As String = {} : Dim i As Integer

    Private Sub cmdDelData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelData.Click
        frmDelData.ShowDialog()
    End Sub

    Private Sub frmOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = MDI
        'On Error Resume Next

        
        Dim strPrintName As String
        If Printing.PrinterSettings.InstalledPrinters.Count > 0 Then
            For Each strPrintName In Printing.PrinterSettings.InstalledPrinters
                cmbMainPrinter.Items.Add(strPrintName)
            Next
        End If

        Call SLoadOption()
        Call SLoadUserOption()
        If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode=" & "'" & strUserID & "'") = 0 Then TabControl.TabPages.Remove(TabPage1)
    End Sub

    Private Sub SSaveOption()
        Try
            Call FDeleteRecord("Tblc_Option")

            If DataType = DataConnection.SqlServer Then
                Dim strSQL As String = "insert into Tblc_Option (DealWithColor,DealWithSize,DealWithPrice,SetDayDate,MinStock,MaxStock,ReOrderStock,StoreStock,ShowItemInSales,ShowItemInCasher,ShowPurchColInPurch,ShowPurchColInStore,MakeBackupInOpen,MakeBackupInClose,LogoPath)" & _
                "values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15) "

                Dim cmd As New SqlClient.SqlCommand '(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader ' = cmd.ExecuteReader

                cmd.Connection = CON : cmd.CommandType = CommandType.Text : cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                Dim intStoreStock As Integer = 0


                cmd.Parameters.AddWithValue("@8", intStoreStock)
                cmd.Parameters.AddWithValue("@13", chkMakeBackupInOpen.Checked)
                cmd.Parameters.AddWithValue("@14", chkMakeBackupInClose.Checked)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim strSQL As String = "insert into Tblc_Option (DealWithColor,DealWithSize,DealWithPrice,SetDayDate,MinStock,MaxStock,ReOrderStock,StoreStock,ShowItemInSales,ShowItemInCasher,ShowPurchColInPurch,ShowPurchColInStore,MakeBackupInOpen,MakeBackupInClose,LogoPath)" & _
                "values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15) "

                Dim cmd As New OleDb.OleDbCommand '(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader ' = cmd.ExecuteReader

                cmd.Connection = CONAccess : cmd.CommandType = CommandType.Text : cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                Dim intStoreStock As Integer = 0

                cmd.Parameters.AddWithValue("@8", intStoreStock)
                cmd.Parameters.AddWithValue("@13", chkMakeBackupInOpen.Checked)
                cmd.Parameters.AddWithValue("@14", chkMakeBackupInClose.Checked)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, ProgName)
            Exit Sub
        End Try
        MsgBox("تم الحفظ خصائص النظام", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
    End Sub

    Private Sub SLoadOption()
        Try
            strSQL = ("SELECT * FROM Tblc_Option")

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read

                    chkMakeBackupInOpen.Checked = dr.Item("MakeBackupInOpen")
                    chkMakeBackupInClose.Checked = dr.Item("MakeBackupInClose")
                    cmbMainPrinter.Text = dr.Item("ReportPrinter")
                Loop
            Else
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While dr.Read

                    chkMakeBackupInOpen.Checked = dr.Item("MakeBackupInOpen")
                    chkMakeBackupInClose.Checked = dr.Item("MakeBackupInClose")
                    cmbMainPrinter.Text = dr.Item("ReportPrinter")
                Loop
            End If

        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Private Sub SSaveUserOption()
        Try
            Call FDeleteRecord("Tblc_UserOption", "UserID=" & "'" & strUserID & "'")

            If DataType = DataConnection.SqlServer Then
                Dim strSQL As String = "insert into Tblc_UserOption (UserID,SetPurches,PurchesStore,PurchesCasher,SetCasher,CasherSales,CasherStore,CasherCash,SetStore,StoreFrom,StoreTo,PrintWithSaveCasher,PrintWithSaveRetCasher,CasherCopyNo,RetCasherCopyNo,PrintWithSaveChange,ChangeCasherCopyNo,ReportPrinter,ReciptPrinter,BarCodePrinter)" & _
                "values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20) "

                Dim cmd As New SqlClient.SqlCommand '(strSQL, CON)
                'Dim dr As SqlClient.SqlDataReader ' = cmd.ExecuteReader

                cmd.Connection = CON : cmd.CommandType = CommandType.Text : cmd.CommandText = strSQL
                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("@1", strUserID)
                cmd.Parameters.AddWithValue("@12", chkPrintCasher.Checked)
                cmd.Parameters.AddWithValue("@13", chkPrintCasherRet.Checked)
                cmd.Parameters.AddWithValue("@14", Val(txtCasherPrintCount.Text))
                cmd.Parameters.AddWithValue("@15", Val(txtCasheRetrPrintCount.Text))
                cmd.Parameters.AddWithValue("@16", chkPrintChange.Checked)
                cmd.Parameters.AddWithValue("@17", Val(txtChangePrintCount.Text))
                cmd.Parameters.AddWithValue("@18", cmbMainPrinter.Text)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim strSQL As String = "insert into Tblc_UserOption (UserID,SetPurches,PurchesStore,PurchesCasher,SetCasher,CasherSales,CasherStore,CasherCash,SetStore,StoreFrom,StoreTo,PrintWithSaveCasher,PrintWithSaveRetCasher,CasherCopyNo,RetCasherCopyNo,PrintWithSaveChange,ChangeCasherCopyNo,ReportPrinter,ReciptPrinter,BarCodePrinter)" & _
               "values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20) "

                Dim cmd As New OleDb.OleDbCommand '(strSQL, CONAccess)
                'Dim dr As OleDb.OleDbDataReader ' = cmd.ExecuteReader

                cmd.Connection = CONAccess : cmd.CommandType = CommandType.Text : cmd.CommandText = strSQL
                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("@1", strUserID)
                cmd.Parameters.AddWithValue("@12", chkPrintCasher.Checked)
                cmd.Parameters.AddWithValue("@13", chkPrintCasherRet.Checked)
                cmd.Parameters.AddWithValue("@14", Val(txtCasherPrintCount.Text))
                cmd.Parameters.AddWithValue("@15", Val(txtCasheRetrPrintCount.Text))
                cmd.Parameters.AddWithValue("@16", chkPrintChange.Checked)
                cmd.Parameters.AddWithValue("@17", Val(txtChangePrintCount.Text))
                cmd.Parameters.AddWithValue("@18", cmbMainPrinter.Text)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, ProgName)
            Exit Sub
        End Try
        MsgBox("تم الحفظ خصائص المستخدمين", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
    End Sub

    Private Sub SLoadUserOption()
        Try
            strSQL = ("SELECT * FROM Tblc_UserOption where UserID=" & "'" & strUserID & "'")

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    chkPrintCasher.Checked = dr.Item("PrintWithSaveCasher")
                    chkPrintCasherRet.Checked = dr.Item("PrintWithSaveRetCasher")
                    txtCasherPrintCount.Text = dr.Item("CasherCopyNo")
                    txtCasheRetrPrintCount.Text = dr.Item("RetCasherCopyNo")
                    chkPrintChange.Checked = dr.Item("PrintWithSaveChange")
                    txtChangePrintCount.Text = dr.Item("ChangeCasherCopyNo")
                    cmbMainPrinter.Text = dr.Item("ReportPrinter")
                Loop
            Else
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While dr.Read
                    chkPrintCasher.Checked = dr.Item("PrintWithSaveCasher")
                    chkPrintCasherRet.Checked = dr.Item("PrintWithSaveRetCasher")
                    txtCasherPrintCount.Text = dr.Item("CasherCopyNo")
                    txtCasheRetrPrintCount.Text = dr.Item("RetCasherCopyNo")
                    chkPrintChange.Checked = dr.Item("PrintWithSaveChange")
                    txtChangePrintCount.Text = dr.Item("ChangeCasherCopyNo")
                    cmbMainPrinter.Text = dr.Item("ReportPrinter")
                Loop
            End If

        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call SSaveOption()
        Call SSaveUserOption()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click, cmdCancel2.Click
        Me.Close()
    End Sub

    Private Sub cmdSaveUserOpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveUserOpt.Click
        Call SSaveUserOption()
    End Sub

    Private Sub chkPrintCasher_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintCasher.CheckedChanged
        If chkPrintCasher.Checked = True Then
            txtCasherPrintCount.Enabled = True
        Else
            txtCasherPrintCount.Text = "0"
            txtCasherPrintCount.Enabled = False
        End If
    End Sub

    Private Sub chkPrintCasherRet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintCasherRet.CheckedChanged
        If chkPrintCasherRet.Checked = True Then
            txtCasheRetrPrintCount.Enabled = True
        Else
            txtCasheRetrPrintCount.Text = "0"
            txtCasheRetrPrintCount.Enabled = False
        End If
    End Sub

    Private Sub chkPrintChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintChange.CheckedChanged
        If chkPrintChange.Checked = True Then
            txtChangePrintCount.Enabled = True
        Else
            txtChangePrintCount.Text = "0"
            txtChangePrintCount.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("هل انت متأكد من أغلاق وترصيد الارصدة بقاعدة البيانات؟", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
            If FCloseAndEndData() = True Then
                MsgBox("تم تنفيذ العملية بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                'frmStore.Show() : frmStore.TxtBox1.Text = "1" : frmStore.SOpen(frmStore.TxtBox1, frmStore.TabPage1, frmStore.DataGridView1)
            Else
                MsgBox("فشلت العملية", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            End If
        Else
            MsgBox("تم ألغاء العملية", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'المخازن
        Dim strSqlQry As String
        Try
            Call FDeleteRecord("Tblu_CloseItemTranForCasher")

            strSqlQry = "INSERT INTO Tblu_CloseItemTranForCasher ( ItemCode, StoreCode,DocType, SignQuantity, CompanyID )" & _
            " SELECT Tblt_ItemTran.ItemCode, Tblt_ItemTran.StoreCode,Tblt_ItemTran.DocType, Sum(Tblt_ItemTran.SignQuantity) AS SumOfSignQuantity, Tblt_ItemTran.CompanyID" & _
            " FROM Tblt_ItemTran Where (DocType=5 or DocType=6 or DocType=15 or DocType=16) and CompanyID='" & strCompanyID & "'" & _
            " GROUP BY Tblt_ItemTran.ItemCode, Tblt_ItemTran.StoreCode,Tblt_ItemTran.DocType, Tblt_ItemTran.CompanyID;"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If

            Call FDeleteRecord("Tblu_ItemTran", "(DocType=5 or DocType=6 or DocType=15 or DocType=16) and CompanyID='" & strCompanyID & "'")

            Dim strTmp() As String = {""}
            Dim strSQLTmp As String = "select * from Tblu_CloseItemTranForCasher;"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQLTmp, CON)
                Dim TmpTmpdr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While TmpTmpdr.Read()
                    ReDim Preserve strTmp(strSQLTmp.Length - 1)
                    strTmp(strTmp.Length - 1) = TmpTmpdr.Item(strFldName)
                Loop
                TmpTmpdr.Close()

            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQLTmp, CONAccess)
                cmd.ExecuteNonQuery()

                'Dim cmd As New OleDb.OleDbCommand(strSQLTmp, CONAccess)
                Dim TmpTmpdr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While TmpTmpdr.Read()
                    ReDim Preserve strTmp(strSQLTmp.Length - 1)
                    strTmp(strTmp.Length - 1) = TmpTmpdr.Item(strFldName)
                Loop
                TmpTmpdr.Close()


            End If
        Catch Exp As OleDb.OleDbException
            'Return False
        End Try
        'المخازن
    End Sub

    Private Sub cmdDeletePrePaidVal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePrePaidVal.Click
        If MsgBox("هل انت متأكد من إلغاء جميع بيانات الدفعات المقدمة؟", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
            Call FDeleteRecord("Tblt_AddPaid", "CompanyID='" & strCompanyID & "'")
            Call FDeleteRecord("Tblt_AddPaidGrid", "CompanyID='" & strCompanyID & "'")
            Call FDeleteRecord("Tblt_PaidTran", "CompanyID='" & strCompanyID & "'")
            Call FDeleteRecord("Tblt_PaidTran2", "CompanyID='" & strCompanyID & "'")
            MsgBox("تم حذف جميع بيانات الدفعات المقدمة بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        Else
            MsgBox("تم إلغاء العملية", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        End If
    End Sub

    Private Sub cmdDeleteRasidVal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRasidVal.Click
        If MsgBox("هل انت متأكد من إلغاء جميع بيانات الأرصدة المخُتاره؟", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
            Call SDelRasidTran()
            MsgBox("تم الحذف بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        Else
            MsgBox("تم إلغاء العملية", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        End If
    End Sub

    Private Sub SDelRasidTran()

        If ChkBox1Rasid.Checked = True Then     '  رصيد الانارة
            Call FDeleteRecord("Tblt_RasidIng", True)
            Call FDeleteRecord("Tblt_RasidIngGridExp", True)
            Call FDeleteRecord("Tblt_RasidIngGridIncome", True)
        End If
        ''''''''''''''''''''''
        If ChkBox2Rasid.Checked = True Then     '  رصيد فواتير الاصلاح
            Call FDeleteRecord("Tblt_RasidRepaireInvoice", True)
            Call FDeleteRecord("Tblt_RasidRepaireInvoiceGridExp", True)
            Call FDeleteRecord("Tblt_RasidRepaireInvoiceGridIncome", True)
        End If
        ''''''''''''''''''''''
        If ChkBox3Rasid.Checked = True Then     '  رصيد السرقات
            Call FDeleteRecord("Tblt_RasidThefts", True)
            Call FDeleteRecord("Tblt_RasidTheftsGridExp", True)
            Call FDeleteRecord("Tblt_RasidTheftsGridIncome", True)
        End If
        ''''''''''''''''''''''
        If ChkBox4Rasid.Checked = True Then     '  رصيد النظافة
            Call FDeleteRecord("Tblt_RasidClean", True)
            Call FDeleteRecord("Tblt_RasidCleanGridExp", True)
            Call FDeleteRecord("Tblt_RasidCleanGridIncome", True)
        End If
        ''''''''''''''''''''''
        If ChkBox5Rasid.Checked = True Then     '  رصيد فوائد الجدولة
            Call FDeleteRecord("Tblt_RasidGadwla", True)
            Call FDeleteRecord("Tblt_RasidGadwlaGridExp", True)
            Call FDeleteRecord("Tblt_RasidGadwlaGridIncome", True)
        End If
        ''''''''''''''''''''''
        If ChkBox6Rasid.Checked = True Then     '  رصيد اللمبات
            Call FDeleteRecord("Tblt_RasidLambat", True)
            Call FDeleteRecord("Tblt_RasidLambatGridExp", True)
            Call FDeleteRecord("Tblt_RasidLambatGridIncome", True)
        End If
        ''''''''''''''''''''''
        If ChkBox7Rasid.Checked = True Then     '  رصيد الطاقة المباعه
            Call FDeleteRecord("Tblt_RasidPayIng", True)
            Call FDeleteRecord("Tblt_RasidPayIngGridExp", True)
            Call FDeleteRecord("Tblt_RasidPayIngGridIncome", True)
        End If
        ''''''''''''''''''''''
        If ChkBox8Rasid.Checked = True Then     '  رصيد الضبطية القضائية
            Call FDeleteRecord("Tblt_RasidDbtya", True)
            Call FDeleteRecord("Tblt_RasidDbtyaGridExp", True)
            Call FDeleteRecord("Tblt_RasidDbtyaGridIncome", True)
        End If
        ''''''''''''''''''''''
    End Sub

    Private Sub chkDelAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkDelAllRasid.CheckedChanged
        ChkBox1Rasid.Checked = chkDelAllRasid.Checked
        ChkBox2Rasid.Checked = chkDelAllRasid.Checked
        ChkBox3Rasid.Checked = chkDelAllRasid.Checked
        ChkBox4Rasid.Checked = chkDelAllRasid.Checked
        ChkBox5Rasid.Checked = chkDelAllRasid.Checked
        ChkBox6Rasid.Checked = chkDelAllRasid.Checked
        ChkBox7Rasid.Checked = chkDelAllRasid.Checked
        ChkBox8Rasid.Checked = chkDelAllRasid.Checked
    End Sub

    Private Sub cmdDeleteSaderVal_Click(sender As Object, e As EventArgs) Handles cmdDeleteSaderVal.Click
        If MsgBox("هل انت متأكد من إلغاء جميع بيانات الصوادر المخُتاره؟", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
            Call SDelSaderTran()
            MsgBox("تم الحذف بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        Else
            MsgBox("تم إلغاء العملية", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        End If
    End Sub

    Private Sub SDelSaderTran()

        If ChkBox1Sader.Checked = True Then     '  صادر الانارة
            Call FDeleteRecord("Tblt_SaderIng", True)
            Call FDeleteRecord("Tblt_SaderIngGrid1", True)
            Call FDeleteRecord("Tblt_SaderIngGrid2", True)
            Call FDeleteRecord("Tblt_SaderIngGrid3", True)
            Call FDeleteRecord("Tblt_SaderIngGrid4", True)
            Call FDeleteRecord("Tblt_SaderIngGrid5", True)
            Call FDeleteRecord("Tblt_SaderIngGrid6", True)
            Call FDeleteRecord("Tblt_SaderIngGrid7", True)
        End If
        ''''''''''''''''''''''
        If ChkBox2Sader.Checked = True Then     '  صادر فواتير الاصلاح
            Call FDeleteRecord("Tblt_SaderRepaireInvoice", True)
            Call FDeleteRecord("Tblt_SaderRepaireInvoiceGrid1", True)
            Call FDeleteRecord("Tblt_SaderRepaireInvoiceGrid2", True)
            Call FDeleteRecord("Tblt_SaderRepaireInvoiceGrid3", True)
            Call FDeleteRecord("Tblt_SaderRepaireInvoiceGrid4", True)
            Call FDeleteRecord("Tblt_SaderRepaireInvoiceGrid5", True)
            Call FDeleteRecord("Tblt_SaderRepaireInvoiceGrid6", True)
            Call FDeleteRecord("Tblt_SaderRepaireInvoiceGrid7", True)
        End If
        ''''''''''''''''''''''
        If ChkBox3Sader.Checked = True Then     '  صادر السرقات
            Call FDeleteRecord("Tblt_SaderThefts", True)
            Call FDeleteRecord("Tblt_SaderTheftsGrid1", True)
            Call FDeleteRecord("Tblt_SaderTheftsGrid2", True)
            Call FDeleteRecord("Tblt_SaderTheftsGrid3", True)
            Call FDeleteRecord("Tblt_SaderTheftsGrid4", True)
            Call FDeleteRecord("Tblt_SaderTheftsGrid5", True)
            Call FDeleteRecord("Tblt_SaderTheftsGrid6", True)
            Call FDeleteRecord("Tblt_SaderTheftsGrid7", True)
        End If
        ''''''''''''''''''''''
        If ChkBox4Sader.Checked = True Then     '  صادر النظافة
            Call FDeleteRecord("Tblt_SaderClean", True)
            Call FDeleteRecord("Tblt_SaderCleanGrid1", True)
            Call FDeleteRecord("Tblt_SaderCleanGrid2", True)
            Call FDeleteRecord("Tblt_SaderCleanGrid3", True)
            Call FDeleteRecord("Tblt_SaderCleanGrid4", True)
            Call FDeleteRecord("Tblt_SaderCleanGrid5", True)
            Call FDeleteRecord("Tblt_SaderCleanGrid6", True)
            Call FDeleteRecord("Tblt_SaderCleanGrid7", True)
        End If
        ''''''''''''''''''''''
        If ChkBox5Sader.Checked = True Then     '  صادر اللمبات
            Call FDeleteRecord("Tblt_SaderLambat", True)
            Call FDeleteRecord("Tblt_SaderLambatGrid1", True)
            Call FDeleteRecord("Tblt_SaderLambatGrid2", True)
            Call FDeleteRecord("Tblt_SaderLambatGrid3", True)
            Call FDeleteRecord("Tblt_SaderLambatGrid4", True)
            Call FDeleteRecord("Tblt_SaderLambatGrid5", True)
            Call FDeleteRecord("Tblt_SaderLambatGrid6", True)
            Call FDeleteRecord("Tblt_SaderLambatGrid7", True)
        End If
        ''''''''''''''''''''''
        If ChkBox6Sader.Checked = True Then     '  صادر الضبطية القضائية
            Call FDeleteRecord("Tblt_SaderDbtya", True)
            Call FDeleteRecord("Tblt_SaderDbtyaGrid1", True)
            Call FDeleteRecord("Tblt_SaderDbtyaGrid2", True)
            Call FDeleteRecord("Tblt_SaderDbtyaGrid3", True)
            Call FDeleteRecord("Tblt_SaderDbtyaGrid4", True)
            Call FDeleteRecord("Tblt_SaderDbtyaGrid5", True)
            Call FDeleteRecord("Tblt_SaderDbtyaGrid6", True)
            Call FDeleteRecord("Tblt_SaderDbtyaGrid7", True)
        End If
        ''''''''''''''''''''''
    End Sub

    Private Sub chkDelAllSader_CheckedChanged(sender As Object, e As EventArgs) Handles chkDelAllSader.CheckedChanged
        ChkBox1Sader.Checked = chkDelAllSader.Checked
        ChkBox2Sader.Checked = chkDelAllSader.Checked
        ChkBox3Sader.Checked = chkDelAllSader.Checked
        ChkBox4Sader.Checked = chkDelAllSader.Checked
        ChkBox5Sader.Checked = chkDelAllSader.Checked
        ChkBox6Sader.Checked = chkDelAllSader.Checked
    End Sub

End Class