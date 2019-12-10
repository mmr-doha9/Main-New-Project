Imports Main_New_Project
Imports System.Math
Imports System.IO

Public Class frmDisagreed
    Implements IFormMainFunction

    Dim strTable, strFrmTag As String
    Dim LstCtrl As New List(Of Control) : Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    Dim bolAcceptAdd As Boolean = True
    Dim bolDealWithCombo As Boolean = True  ' لدم حدوث خطا في كومبو الادارة
    ''
    'Dim lstTxtBox As New List(Of Control)
    Dim bolOpenCalc As Boolean = True ' لعدم حساب المحضر اثناء الفتح من قاعدة البيانات
    Dim strOld1, strOld2, strOld3, strOld4, strOld5, strOld6 As String

    Dim strTmpTranNo As String = "" ' رقم الحركة السابقة
    Dim strTmpTranNoDisagreed As String = "" ' رقم الحركة السابقة في المحاضر
    Dim strAutoComplete1 As New List(Of String)
    Dim strAutoComplete2 As New List(Of String)
    Dim strAutoComplete3 As New List(Of String)
    ''''''''''''''''
    Dim bolAddTazloom As Boolean = False
    Dim typeFrm As frmEditType
    Dim BoluserFrmPer, BoluserOPen, BoluserDelete, BoluserSave, BoluserReSave, BolUserOpenOtherUserTran As Boolean ' الصلاحيات
    Dim bolUserOpenOtherUserTranTmp As Boolean ' للتنقل برقم اليوزر
    Dim typeCalc As typeCalc

    Public Sub New(strTableName As String, strFrmName As String, strFrmTagCode As String, Optional typeCalcMain As typeCalc = typeCalc.Auto)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        strTable = strTableName
        strFrmTag = strFrmTagCode
        TabPage1.Text = strFrmName

        If strTable = "Tblt_Zaina" Then
            Me.Tag = "0203"
        ElseIf strTable = "Tblt_ZainaSecond" Then
            Me.Tag = "0303"
        End If
        typeCalc = typeCalcMain
    End Sub

    Private Sub frmDisagreed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Mdi
        '''''''''''''''''
        Call SAddNew()
        Call SLoadControll()
        ''Permission
        If strUserType = 0 Then
            Call SLoadPermission(strFrmTag, BoluserFrmPer, BoluserOPen, BoluserDelete, BoluserSave, BoluserReSave, BolUserOpenOtherUserTran)
            bolUserOpenOtherUserTranTmp = IIf(BolUserOpenOtherUserTran = False, True, False)
        Else
            BoluserFrmPer = True : BoluserOPen = True : BoluserDelete = True : BoluserSave = True : BoluserReSave = True : BolUserOpenOtherUserTran = True
            cmdSearch.Visible = BoluserOPen
            bolUserOpenOtherUserTranTmp = False
        End If
        cmdSearch.Visible = BoluserOPen
        ''Permission
        Call SDrawPayedGrid(DataGridView1)
        Call SDrawGrievanceGrid(DataGridView5)
        BackgroundWorker1.RunWorkerAsync()
        If strTable = "Tblt_Zaina" Or strTable = "Tblt_ZainaSecond" Then
            Label35.Enabled = False : TxtBox20.Enabled = False : TxtBox21.Enabled = False : TxtBox22.Enabled = False : TxtBox23.Enabled = False : TxtBox24.Enabled = False
            Label3.Enabled = False : Label4.Enabled = False : Label14.Enabled = False : TxtBox5.Enabled = False : TxtBox6.Enabled = False : cmbCalcType.Enabled = False
            Label2.Text = "الحمل :" : Label6.Text = "القيمة :"
        End If
        If cmbCalcTypeManual.SelectedIndex = 1 Then cmdSearch.Visible = False : cmbCalcTypeManual.Visible = False
    End Sub

    Private Sub SLoadControll()
        LstCtrl.Clear()
        With LstCtrl
            .Add(DateTimePicker1)
            .Add(OptType1)
            .Add(OptType2)
            .Add(cmbPartionCode)
            .Add(CmbBranchCode)
            .Add(TxtBox2)
            .Add(TxtBox3)
            .Add(cmbActivitiesCode)
            .Add(cmbPlaceCode)
            .Add(TxtBox4)
            .Add(TxtBox7)
            .Add(cmbArtisticCode)
            .Add(cmbPoliceMenCode)
            .Add(cmbMabahsCode)
            .Add(DateTimePicker2)
            .Add(DateTimePicker3)
            .Add(ChkBox1)
            .Add(ChkBox2)
            .Add(cmbPayState)
            .Add(TxtBox9)
            .Add(TxtBox10)
            .Add(cmbPriceCode)
            .Add(TxtBox26)
            If strTable = "Tblt_Disagreed" Or strTable = "Tblt_DisagreedSecond" Then
                .Add(TxtBox5)     ' لوحة
                .Add(TxtBox6)     ' عداد
                .Add(TxtBox20)    ' مراجع حساب 
                .Add(TxtBox21)    ' مراجع حساب
                .Add(TxtBox22)    ' مراجع حساب
                .Add(TxtBox23)    ' مراجع حساب
                .Add(TxtBox24)    ' مراجع حساب
                .Add(cmbCalcType) ' للنفس / للغيير
            End If
            .Add(ChkTazloom)
            .Add(ChkNyaba)
            .Add(cmbCalcTypeManual)
        End With
    End Sub

    Public Sub SAddNew() Implements IFormMainFunction.SAddNew
        bolDealWithCombo = False
        '''''''''''''''''''''''
        TxtBox2.AutoCompleteCustomSource.Add(TxtBox2.Text)
        TxtBox3.AutoCompleteCustomSource.Add(TxtBox3.Text)
        TxtBox4.AutoCompleteCustomSource.Add(TxtBox4.Text)
        '''''
        Call ClearControl(TabPage1)
        ''''''''''''''''
        ''''''''''''''''
        Call cmbActivitiesCode_SelectedIndexChanged(sender:=Nothing, e:=Nothing)
        '''''''''''''''''
        Call SFillCombo(cmbActivitiesCode, "Tblc_ActivitiesCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbPlaceCode, "Tblc_PlaceCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbArtisticCode, "Tblc_ArtisticCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbPriceCode, "Tblt_PriceLevel", "DocNo", "DocDate", "PlaceCode='" & cmbActivitiesCode.SelectedValue & "'", False, "ID", ComboLoadItemSelect.Max)
        If strTable = "Tblt_Disagreed" Or strTable = "Tblt_Zaina" Then
            Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            lblPoliceMenCode.Text = "مندوب الشرطة ..."
            Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        ElseIf strTable = "Tblt_DisagreedSecond" Or strTable = "Tblt_ZainaSecond" Then
            Call SFillCombo(cmbPoliceMenCode, "Tblc_AccountMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            lblPoliceMenCode.Text = "م.الضبط القضائي ..."
            cmbMabahsCode.Enabled = False : lblMabahsCode.Enabled = False
        End If
        '''''''''''''''''
        TxtBox1.Text = FAutoNumber(strTable, FGetTagData(TxtBox1, Valadation.Tag), False, False)
        TxtBox2.Focus()                        '   start Focus
        '''''''''''''''''''''''''''
        bolDealWithCombo = True
        'BackgroundWorker1.RunWorkerAsync()
        'Call SAutoComplete()
        ''''''''''''''''''''''
        cmbPayState.SelectedIndex = 0
        OptType1.Checked = True
        TxtBox5.Text = "0" : TxtBox6.Text = "0" : TxtBox8.Text = "0"
        '''''''''''''''''''''''
        Call SLoadTypeCombox() ' Load partionCode and Branches
        '''''''''''''''''
        cmbArtisticCode.SelectedValue = 0 : cmbPoliceMenCode.SelectedValue = 0 : cmbPartionCode.SelectedValue = 0 : CmbBranchCode.SelectedValue = 0
        cmbActivitiesCode.SelectedValue = 0 : cmbPlaceCode.SelectedValue = 0 : cmbMabahsCode.SelectedValue = 0
        ''''''''''''''''
        typeFrm = frmEditType.Save : TxtTitle2.Text = "حفظ جديد"
        ''''''''''''''''
        If strOld5 <> "" Then OptType1.Checked = strOld5
        If strOld6 <> "" Then OptType2.Checked = strOld6
        If strOld1 <> "" Then cmbPartionCode.SelectedValue = strOld1
        If strOld2 <> "" Then CmbBranchCode.SelectedValue = strOld2
        If strOld3 <> "" Then DateTimePicker2.Value = strOld3
        If strOld4 <> "" Then cmbMabahsCode.SelectedValue = strOld4

        TxtBox4.Text = "تيار مباشر"
        ''
        Dim strCondition As String = "UserId=" & strUserID & " And Month(Date)=" & Month(DateTimePicker1.Value) & " And year(Date)=" & Year(DateTimePicker1.Value)

        TxtTitle.Text = "شهر:" & Month(DateTimePicker1.Value) & " / " & Year(DateTimePicker1.Value)
        TxtTitle.Text = TxtTitle.Text & " العدد= " & FGetColumnValue(strTable, "AsthlakVal", Expresion.Count, strCondition)
        TxtTitle.Text = TxtTitle.Text & " ، القيمة= " & FGetColumnValue(strTable, "AsthlakVal", Expresion.Sum, strCondition)
        ''
        strTmpTranNo = ""
        GbPayed.Enabled = True
        btnAddTazloom.Enabled = False : bolAddTazloom = False
        cmbCalcTypeManual.SelectedIndex = typeCalc
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If BackgroundWorker1.CancellationPending Then
                e.Cancel = True
                BackgroundWorker1.ReportProgress(100, "Cancelled.")
            End If
            ''''
            strAutoComplete1.AddRange(FAutoCompleteItem(strTable, "ID", "Name", "", False, "Name"))
            strAutoComplete2.AddRange(FAutoCompleteItem(strTable, "ID", "Address", "", False, "Name"))
            strAutoComplete3.AddRange(FAutoCompleteItem(strTable, "ID", "Description", "", False, "Description"))
        Catch ex As Exception
            MsgBox(ex.Message)
            e.Cancel = True
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Label1.Text = CType(e.UserState, String)
        'Label2.Text = " تم تحميل  " & e.ProgressPercentage.ToString & "  %  "
        'If BackgroundWorker1.CancellationPending Then
        '    'BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Cancelling...")
        '    'Exit For
        'End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            'هل انتهى backgroundWORKER بخطأ
            MessageBox.Show(e.Error.Message)
            Label1.Text = "حدثت مشكلة أثناء التحميل!"
        ElseIf e.Cancelled Then
            'فى حالة اغلاقه
            MessageBox.Show("Task cancelled!")
            Label1.Text = "تم إلغاء التحميل! - " & Now.ToShortTimeString
        Else
            TxtBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TxtBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtBox2.AutoCompleteCustomSource.AddRange(strAutoComplete1.ToArray)
            ''
            TxtBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TxtBox3.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtBox3.AutoCompleteCustomSource.AddRange(strAutoComplete2.ToArray)
            ''
            TxtBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TxtBox4.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtBox4.AutoCompleteCustomSource.AddRange(strAutoComplete3.ToArray)
        End If

    End Sub

    Private Sub SLoadTypeCombox()
        Dim intType As Integer = IIf(OptType1.Checked = True, 1, 0)
        Call SFillCombo(cmbPartionCode, "Tblc_PartionCode", "ID", "Name", "Type=" & intType, False, "", ComboLoadItemSelect.Min)
        If cmbPartionCode.Items.Count > 0 Then
            Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
        Else
            CmbBranchCode.DataSource = Nothing
            CmbBranchCode.DisplayMember = Nothing
            CmbBranchCode.Items.Clear()
        End If
    End Sub

    Private Sub SAutoComplete()
        TxtBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TxtBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
        SFillTextBox(TxtBox2, strTable, "ID", "Name", "", False, "Name")
        'TxtBox2.AutoCompleteCustomSource.
        ''''''
        TxtBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TxtBox3.AutoCompleteSource = AutoCompleteSource.CustomSource
        SFillTextBox(TxtBox3, strTable, "ID", "Address", "", False, "Name")
        ''''''
        TxtBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TxtBox4.AutoCompleteSource = AutoCompleteSource.CustomSource
        SFillTextBox(TxtBox4, strTable, "ID", "Description", "", False, "Description")
    End Sub

    Public Sub SOpen() Implements IFormMainFunction.SOpen
        bolOpenCalc = False ' لوقف حساب المحضر
        ''''''''''''''''''''''''''''
        strSQL = ("SELECT * FROM " & strTable & " WHERE ((" & strTable & "." & FGetTagData(TxtBox1, Valadation.Tag) & ")=" & TxtBox1.Text & ")")
        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            If dr.Read() = True Then
                For Each ctlItem In LstCtrl
                    If TypeOf ctlItem Is TextBox Then ' TextBox case
                        ctlItem.Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.ComboBox Then
                        If FGetTagData(ctlItem, Valadation.ComboType) = 1 Then
                            DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedValue = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 2 Then
                            DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedIndex = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 3 Then
                            DirectCast(ctlItem, System.Windows.Forms.ComboBox).Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        End If
                        ''''''''''''''''' checkBox
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.CheckBox Then
                        'Dim bolTemp As Boolean = IIf((dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString() = "0"), False, True)
                        DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString()

                        '''''''''''''''' checkBox
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.DateTimePicker Then
                        DirectCast(ctlItem, System.Windows.Forms.DateTimePicker).Value = dr.Item(FGetTagData(ctlItem, Valadation.Tag))
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.RadioButton Then
                        DirectCast(ctlItem, System.Windows.Forms.RadioButton).Checked = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                    Else
                        MsgBox(ctlItem.Name)
                    End If
                Next
                TxtBox1.Text = dr.Item("ID")
            Else
                SAddNew()
            End If
            dr.Close()
        ElseIf DataType = DataConnection.Access Then
            Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            If dr.Read() = True Then
                For Each ctlItem In LstCtrl
                    If TypeOf ctlItem Is TextBox Then ' TextBox case
                        ctlItem.Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.ComboBox Then
                        If FGetTagData(ctlItem, Valadation.ComboType) = 1 Then
                            DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedValue = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 2 Then
                            DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedIndex = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 3 Then
                            DirectCast(ctlItem, System.Windows.Forms.ComboBox).Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        End If
                        ''''''''''''''''' checkBox
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.CheckBox Then
                        Dim bolTemp As Boolean = IIf((dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString() = 0), False, True)
                        DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = bolTemp
                        '''''''''''''''' checkBox
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.DateTimePicker Then
                        DirectCast(ctlItem, System.Windows.Forms.DateTimePicker).Value = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.RadioButton Then
                        DirectCast(ctlItem, System.Windows.Forms.RadioButton).Checked = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                    Else
                        MsgBox(ctlItem.Name)
                    End If
                Next
                TxtBox1.Text = dr.Item("ID")
            Else
                SAddNew()
            End If
            dr.Close()
        End If
        Call SLoadGrid(strTable & "Payed", DataGridView1, "DocNo", TxtBox1.Text, False, "", "", False)
        Call SLoadGrid(strTable & "Tzaloom", DataGridView5, "DocNo", TxtBox1.Text, False, "", "", False)
        ''''''''''''''''''''''''''''
        Call SLoadCmbPayState()

        typeFrm = frmEditType.Edit : TxtTitle2.Text = "تعديل"
        GbPayed.Enabled = False
        btnAddTazloom.Enabled = True : Call SFillCtl()
        Call cmbCalcType_SelectedIndexChanged(sender:=Nothing, e:=Nothing)
        bolOpenCalc = True ' لاعادة تشغيل حساب المحضر
    End Sub
    Private Sub SLoadCmbPayState()
        If cmbPayState.SelectedIndex = 2 Then
            cmbPayState.Enabled = False
            TxtBox8.Enabled = False
            dtePayInvoice.Enabled = False
        Else
            cmbPayState.Enabled = True
        End If
    End Sub

    Public Sub SUpdate() Implements IFormMainFunction.SUpdate
        Try
            If FValidation(Me, TabControl1) = True Then
                If FCheckDemo(strTable, 5) = True Then
                    If FCheckPriviosRecord() = True Then
                        If FCheckPriviosRecordDisagreed() = True Then
                            '''''''''''
                            'Dim StrDocNoTemp As Boolean = FGetFeildValuesBol(strTable, "Name", "ID=" & TxtBox1.Text & " And BranchCode=" & CmbBranchCode.SelectedValue, False)

                            ''حفظ الحركة في جدول التظلمات في حالة اضافة تظلم جديد
                            If bolAddTazloom = True Then
                                ''حفظ بجداول التظلمات
                                Dim intDocNo As Integer = FAddNewRecord2("Tzaloom_" & strTable, lstCtlTag, lstCtlVal)

                                DataGridView5.Item("DocNoTzaloom", DataGridView5.RowCount - 1).Value = intDocNo
                                Call SSaveGrid(strTable & "Tzaloom", DataGridView5, "DocNo", Val(TxtBox1.Text), "", True, True, False) 'حفظ الحركة الاساسية
                                Call SSaveGrid("Tzaloom_" & strTable & "Payed", DataGridView1, "DocNo", intDocNo, "", True, False, False)
                                ''حفظ التظلم بجدول حركات المستخدمين
                                Call FSetTransaction(TransactionType.Tazloom, strFrmTag, TxtBox1.Text) ' transactions Tazloom Edit
                                ''حفظ التظلم بجدول حركات المستخدمين

                                bolAddTazloom = False
                            End If
                            ''حفظ الحركة في جدول التظلمات في حالة اضافة تظلم جديد

                            Call SFillCtl()
                            If typeFrm = frmEditType.Save Then
                                TxtBox1.Text = FAddNewRecord2(strTable, lstCtlTag, lstCtlVal)
                                Call FSetTransaction(TransactionType.Save, strFrmTag, TxtBox1.Text) ' transactions save
                            ElseIf typeFrm = frmEditType.Edit Then
                                FEditeRecord(strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, lstCtlTag, lstCtlVal)
                                Call FSetTransaction(TransactionType.Edit, strFrmTag, TxtBox1.Text) ' transactions save
                            End If
                            If cmbPayState.SelectedIndex = 1 Then Call SSavePayedStates()
                            Dim bolUpdate As Boolean = True
                            '''''''''''



                            If bolUpdate = True Then
                                If MsgBox("تم الحفظ بنجاح" & vbCrLf & "رقم الحركة الحالية هو " & TxtBox1.Text & vbCrLf & "هل تريد البدء فر حركة جديدة؟", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Yes Then
                                    strOld1 = cmbPartionCode.SelectedValue : strOld2 = CmbBranchCode.SelectedValue : strOld3 = DateTimePicker2.Value : strOld4 = cmbMabahsCode.SelectedValue
                                    strOld5 = OptType1.Checked : strOld6 = OptType2.Checked
                                    Call SAddNew()
                                Else

                                End If
                            Else
                                MsgBox("حدثت مشكلة خلال الحفظ" & vbCrLf & "فشلت عملية الحفظ ", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                            End If
                        Else
                            MsgBox("يوجد رقم حصر سابق في الضبطية القضائية" & vbCrLf & "رقم الحركة : " & strTmpTranNoDisagreed, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        End If
                    Else
                        MsgBox("يوجد رقم حصر سابق", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        If MsgBox("هل تريد فتح هذة الحركة", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
                            TxtBox1.Text = strTmpTranNo
                            Call SOpen()
                        End If
                    End If
                End If
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Private Function SSavePayedStates() As Boolean
        Try
            Call FDeleteRecord(strTable & "Payed", "DocNo =" & TxtBox1.Text)
            Dim lstCtlTagTmp, lstCtlValTmp As New List(Of String)

            lstCtlTagTmp.Clear() : lstCtlValTmp.Clear()
            '''''''''''''''''''''''''
            With lstCtlValTmp
                .Add(Val(TxtBox1.Text))
                .Add(cmbPayState.SelectedIndex)
                .Add(Val(TxtBox10.Text))
                .Add(Val(TxtBox8.Text))
                .Add(FFormatDate(dtePayInvoice.Value))
                .Add(strUserID)
            End With
            '''''''''''''''''''''''''
            With lstCtlTagTmp
                .Add("[DocNo]")
                .Add("[PayedState]")
                .Add("[PayedVal]")
                .Add("[InvoiceNo]")
                .Add("[PayedDate]")
                .Add("[UserId]")
            End With
            ''''''''''''''''''''''''''
            'If (FEditeRecord(strTable & "Payed", "ID", TxtBox1.Text, lstCtlTag, lstCtlVal)) = True Then
            Call FAddNewRecord2(strTable & "Payed", lstCtlTagTmp, lstCtlValTmp)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub SDelete() Implements IFormMainFunction.SDelete
        If MsgBox("هل تريد حذف السجل الحالي", CType(MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Ok Then
            Dim strCondition As String = (FGetTagData(TxtBox1, Valadation.Tag) & "=" & TxtBox1.Text)
            FDeleteRecord(strTable, strCondition)
            Call FSetTransaction(TransactionType.Delete, strFrmTag, TxtBox1.Text) ' transactions save
            Call SAddNew()
        End If
    End Sub

    Public Sub SMoveFirst() Implements IFormMainFunction.SMoveFirst
        Dim S As String = FNavigate(NavDirection.DMoveFirst, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", bolUserOpenOtherUserTranTmp, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveLast() Implements IFormMainFunction.SMoveLast
        Dim S As String = FNavigate(NavDirection.DMoveLast, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", bolUserOpenOtherUserTranTmp, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveNext() Implements IFormMainFunction.SMoveNext
        Dim S As String = FNavigate(NavDirection.DMoveNext, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", bolUserOpenOtherUserTranTmp, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMovePrevious() Implements IFormMainFunction.SMovePrevious
        Dim S As String = FNavigate(NavDirection.DMovePrevious, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", bolUserOpenOtherUserTranTmp, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SPrintReport() Implements IFormMainFunction.SPrintReport
        Try
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            SPrintRep(objReport, PrintType.Print)
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
    End Sub

    Public Sub SShowPrint() Implements IFormMainFunction.SShowPrint
        Try
            Try
                Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                SPrintRep(objReport, PrintType.Preview)
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
    End Sub

    Private Sub SPrintRep(ByVal objReport As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal PrintType As PrintType, Optional ByVal intCopyPrint As Integer = 1)
        Try
            Dim mySelectFormula As String = ""

            If DataType = DataConnection.SqlServer Then
                If strTable = "Tblt_Disagreed" Then
                    objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts01.rpt")
                ElseIf strTable = "Tblt_DisagreedSecond" Then
                    objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts11.rpt")
                End If
            ElseIf DataType = DataConnection.Access Then

            End If
            mySelectFormula = "{Tblt_Disagreed.ID} =" & TxtBox1.Text
            objReport.DataDefinition.FormulaFields.Item("FUserName").Text = "totext('" & strUserName & "')"
            objReport.DataDefinition.FormulaFields.Item("ZCompName").Text = "totext('" & strCompanyName & "')"
            Call GetServerNameAndDataBaseName(objReport)
            Dim frmReport As New frmReportViewer
            frmReport.CRViewer1.ReportSource = objReport
            frmReport.CRViewer1.SelectionFormula = mySelectFormula
            frmReport.CRViewer1.Zoom(100%)
            frmReport.CRViewer1.RefreshReport()
            Select Case PrintType
                Case Main_New_Project.PrintType.Preview
                    frmReport.Show()
                Case Main_New_Project.PrintType.Print
                    objReport.PrintToPrinter(intCopyPrint, True, 1, 100)
            End Select
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
    End Sub

    Private Sub cmbPartionCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPartionCode.SelectedIndexChanged
        If bolDealWithCombo = True Then

            If Not IsNothing(cmbPartionCode.SelectedValue) Then
                'CmbBranchCode.SelectedValue = FGetFeildValues("Tblc_MainBranchCode", "PartationCode", "ID=" & CmbBranchCode.SelectedValue, False, False)
                Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
                CmbBranchCode.Enabled = True
            End If
        End If
    End Sub

    Private Sub SFillCtl()
        lstCtlTag.Clear() : lstCtlVal.Clear()
        '''''''''''''''''''''''''''
        For Each ctlItem In LstCtrl
            'If ctlItem.Enabled = True Then
            lstCtlTag.Add("[" & FGetTagData(ctlItem, Valadation.Tag) & "]")
            '''''''''''''''''''''''''
            If TypeOf ctlItem Is TextBox Then ' TextBox case
                lstCtlVal.Add(ctlItem.Text)
            ElseIf TypeOf ctlItem Is System.Windows.Forms.ComboBox Then
                If FGetTagData(ctlItem, Valadation.ComboType) = 1 Then
                    lstCtlVal.Add(DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedValue)
                ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 2 Then
                    lstCtlVal.Add(DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedIndex)
                ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 3 Then
                    lstCtlVal.Add(DirectCast(ctlItem, System.Windows.Forms.ComboBox).Text)
                End If
                ''''''''''''''''' checkBox
            ElseIf TypeOf ctlItem Is System.Windows.Forms.CheckBox Then
                lstCtlVal.Add((DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked)) 'IIf((DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = True), 1, 0)
                '''''''''''''''' checkBox
            ElseIf TypeOf ctlItem Is System.Windows.Forms.DateTimePicker Then
                lstCtlVal.Add(FFormatDate(DirectCast(ctlItem, System.Windows.Forms.DateTimePicker).Value))
            ElseIf TypeOf ctlItem Is System.Windows.Forms.RadioButton Then
                Dim intTemp As Integer = IIf((DirectCast(ctlItem, System.Windows.Forms.RadioButton).Checked = True), 1, 0)
                lstCtlVal.Add(intTemp)
            End If
            'End If
        Next
        '''''''''''''''''''
        lstCtlTag.Add("[tranTime]")
        lstCtlVal.Add(FFormatTime(Now))
        lstCtlTag.Add("[UserID]")
        lstCtlVal.Add(Val(strUserID))
    End Sub

    Private Sub me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            If strUserType = 0 Then
                If typeFrm = frmEditType.Edit Then
                    If BoluserReSave = True Then
                        Call SUpdate()
                    Else
                        MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    End If
                ElseIf typeFrm = frmEditType.Save Then
                    If BoluserSave = True Then
                        Call SUpdate()
                    Else
                        MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    End If
                End If
            Else
                Call SUpdate()
            End If
        ElseIf e.Control And e.KeyCode = Keys.O Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SOpen()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SOpen()
            End If
        ElseIf e.Control And e.KeyCode = Keys.D Then
            If strUserType = 0 Then
                If BoluserDelete = True Then
                    Call SDelete()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SDelete()
            End If
        ElseIf e.Control And e.KeyCode = Keys.N Then
            Call SAddNew()
        ElseIf e.Control And e.KeyCode = Keys.Left Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMovePrevious()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMovePrevious()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Right Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMoveNext()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveNext()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Up Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMoveFirst()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveFirst()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Down Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMoveLast()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveLast()
            End If
            'End If
            ''''''''''''
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox10.KeyPress, TxtBox8.KeyPress, TxtBox7.KeyPress, TxtBox6.KeyPress, TxtBox5.KeyPress, TxtBox4.KeyPress, TxtBox3.KeyPress, TxtBox24.KeyPress, TxtBox23.KeyPress, TxtBox22.KeyPress, TxtBox21.KeyPress, TxtBox20.KeyPress, TxtBox2.KeyPress, TxtBox1.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox1.Name, TxtBox5.Name, TxtBox6.Name, TxtBox20.Name, TxtBox21.Name, TxtBox22.Name, TxtBox23.Name, TxtBox24.Name
                e.KeyChar = FJustNumber(e)
            Case TxtBox7.Name, TxtBox8.Name
                e.KeyChar = FJustIntNumber(e)

            Case Else

        End Select
    End Sub

    Private Sub TxtBox_GotFocus(sender As Object, e As EventArgs) Handles TxtBox10.GotFocus, TxtBox8.GotFocus, TxtBox7.GotFocus, TxtBox6.GotFocus, TxtBox5.GotFocus, TxtBox3.GotFocus, TxtBox24.GotFocus, TxtBox23.GotFocus, TxtBox22.GotFocus, TxtBox21.GotFocus, TxtBox20.GotFocus, TxtBox2.GotFocus, TxtBox1.GotFocus
        Call FChangeLang()
    End Sub

    Private Function FCalcEnergy(intAsthlak As Integer, intDocType As Integer) As Double
        Try
            If cmbCalcTypeManual.SelectedIndex = 0 Then
                '''''''''''''''''' Get Price Date
                Dim strCondition As String = ""
                If DataType = DataConnection.SqlServer Then
                    strCondition = "DocDate <='" & FFormatDate(DateTimePicker2.Text) & "' And DocDateTo >='" & FFormatDate(DateTimePicker2.Text) & "' And PlaceCode='" & cmbActivitiesCode.SelectedValue & "'"
                ElseIf DataType = DataConnection.Access Then
                    strCondition = "DocDate <=#" & FFormatDate(DateTimePicker2.Text) & "# And DocDateTo >=#" & FFormatDate(DateTimePicker2.Text) & "# And PlaceCode='" & cmbActivitiesCode.SelectedValue & "'"
                End If
                Dim strPriceCode As String = FGetFeildValues("Tblt_PriceLevel", "DocNo", strCondition, False, False)

                If strPriceCode <> Nothing Then
                    cmbPriceCode.SelectedValue = strPriceCode
                    '''''''''''''''''' Get Price Date
                    Dim intCalcType As Integer
                    If intDocType = 0 Then
                        intCalcType = 2
                    ElseIf intDocType = 1 Then
                        intCalcType = 5
                    End If

                    Return (intAsthlak * intCalcType * (FGetFeildValues("Tblt_PriceLevelGrid", "Price", "DocNo='" & strPriceCode & "' Order By SHNO  DESC")))
                    '''''''''''' غرامة العمدى
                    'If cmbPriceCalcType.SelectedIndex = 2 Then
                    '    TxtBox13.Text = ((FGetFeildValues("Tblt_PriceLevelGrid", "Price", "DocNo='" & strPriceCode & "' Order By SHNO  DESC") * Val(TxtBox10.Text)) - Val(TxtBox12.Text)) * 4
                    'Else
                    '    TxtBox13.Text = ((FGetFeildValues("Tblt_PriceLevelGrid", "Price", "DocNo='" & strPriceCode & "' Order By SHNO  DESC") * Val(TxtBox10.Text)) - Val(TxtBox12.Text)) * 2
                    'End If
                    '''''''''''' غرامة العمدى
                End If
            ElseIf cmbCalcTypeManual.SelectedIndex = 1 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub cmbActivitiesCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbActivitiesCode.SelectedIndexChanged
        If bolDealWithCombo = True Then
            'Call SFillCombo(cmbPriceCode, "Tblt_PriceLevel", "DocNo", "DocDate", "PlaceCode='" & cmbActivitiesCode.SelectedValue & "'", False, "ID", ComboLoadItemSelect.Max)
            'For i As Integer = 0 To DataGridView1.Rows.Count - 2
            '    DataGridView1.Item("HoursCount", i).Value = IIf(cmbActivitiesCode.Text = "منزلي", 8, 12)
            'Next
        End If
    End Sub

    Private Function FGbrNumber(ByVal dblnumber As Double) As Double
        Try
            Dim a As Double = Fix(dblnumber)
            Dim b As Double = dblnumber - a
            Select Case b           ''''1
                Case 0 To 0.05
                    b = 0.05        ''''2
                Case 0.05 To 0.1
                    b = 0.1         ''''3
                Case 0.1 To 0.15
                    b = 0.15        ''''4
                Case 0.15 To 0.2
                    b = 0.2         ''''5
                Case 0.2 To 0.25
                    b = 0.25        ''''6
                Case 0.25 To 0.3
                    b = 0.3         ''''7
                Case 0.3 To 0.35
                    b = 0.35        ''''8
                Case 0.35 To 0.4
                    b = 0.4         ''''9
                Case 0.4 To 0.45
                    b = 0.45       ''''10
                Case 0.45 To 0.5
                    b = 0.5        ''''11
                Case 0.5 To 0.55
                    b = 0.55       ''''12
                Case 0.55 To 0.6
                    b = 0.6        ''''13
                Case 0.6 To 0.65
                    b = 0.65       ''''14
                Case 0.65 To 0.7
                    b = 0.7        ''''15
                Case 0.7 To 0.75
                    b = 0.75       ''''16
                Case 0.7 To 0.8
                    b = 0.8        ''''17
                Case 0.8 To 0.85
                    b = 0.85       ''''18
                Case 0.8 To 0.9
                    b = 0.9        ''''19
                Case 0.9 To 0.95
                    b = 0.95       ''''20
                Case 0.95 To 1
                    b = 1          ''''21
            End Select
            Return a + b
            'Return b
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub cmbPayState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPayState.SelectedIndexChanged
        Try
            Select Case cmbPayState.SelectedIndex
                Case 0 ' ينتظر
                    TxtBox8.Text = ""
                    TxtBox8.Enabled = False
                    dtePayInvoice.Enabled = False
                    TxtBox26.Text = TxtBox10.Text
                Case 1 ' تم السداد
                    TxtBox8.Enabled = True
                    dtePayInvoice.Enabled = True : TxtBox26.Text = "0"
                Case 2 ' تم التقسيط
                    If bolOpenCalc = True Then
                        MsgBox("لا يمكن التقسيط من خلال تلك الشاشة" & vbCrLf & "يتم التقسيط من خلال شاشة السداد", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        cmbPayState.SelectedIndex = 0
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles OptType2.CheckedChanged, OptType1.CheckedChanged
        Call SLoadTypeCombox()
    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        Call SFillCtl()

        Dim frmNew As New frmMultiSave(strTable, lstCtlTag, lstCtlVal, DataGridView1, 10)
        frmNew.ShowDialog()

        'For i As Integer = 0 To intDocNoMain.Count - 1
        '    Call SSaveGrid(strTable & "Devices", DataGridView1, "DocNo", intDocNoMain(i), "", True, False, False)
        'Next
        Call SAddNew()
    End Sub

    Private Function FCheckPriviosRecord() As Boolean
        Dim strCondition As String = ""

        If strTable = "Tblt_Disagreed" Or strTable = "Tblt_Zaina" Then
            strCondition = "HasrNo='" & TxtBox7.Text & "' And MabahsCode=" & cmbMabahsCode.SelectedValue & " And year(Date2)= " & Year(DateTimePicker2.Value)
        ElseIf strTable = "Tblt_DisagreedSecond" Or strTable = "Tblt_ZainaSecond" Then
            strCondition = "HasrNo='" & TxtBox7.Text & "' And BranchCode=" & CmbBranchCode.SelectedValue & " And year(Date2)= " & Year(DateTimePicker2.Value)
        End If

        strTmpTranNo = (FGetFeildValues(strTable, "ID", strCondition, False, False))

        If strTmpTranNo <> Nothing Then
            If strTmpTranNo <> TxtBox1.Text Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
        '''''''''''''''''''''''''''
    End Function

    Private Function FCheckPriviosRecordDisagreed() As Boolean ' للتأكد من عدم وجود مخالفة سابقة لنفس رقم الحصر
        Dim strCondition As String = ""

        If strTable = "Tblt_Disagreed" Then
            strCondition = ""
        ElseIf strTable = "Tblt_DisagreedSecond" Then
            strCondition = "HasrNo='" & TxtBox7.Text & "' And BranchCode=" & CmbBranchCode.SelectedValue & " And year(Date2)= " & Year(DateTimePicker2.Value)
            strTmpTranNoDisagreed = (FGetFeildValues("Tblt_EnergyTheftsSecond", "ID", strCondition, False, False))
        End If
        
        If strTmpTranNoDisagreed <> Nothing Then
            Return False
        Else
            Return True
        End If
        '''''''''''''''''''''''''''
    End Function

    Private Sub cmbCalcType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalcType.SelectedIndexChanged
        If Not IsNothing(cmbCalcType.SelectedIndex) And TxtBox9.Text <> "" Then
            TxtBox10.Text = FCalcEnergy(Val(TxtBox9.Text), cmbCalcType.SelectedIndex)
        End If
    End Sub

    Private Sub btnAddTazloom_Click(sender As Object, e As EventArgs) Handles btnAddTazloom.Click
        Dim lstValue As New List(Of String)
        Dim lstCtlTag As New List(Of String) : lstCtlTag.AddRange({"TzaloomDate", "TzaloomNo", "Description"})

        Dim f As New frmTazlom(TxtBox1.Text, strTable, lstValue)
        f.ShowDialog()

        If lstValue.Count >= 2 Then
            DataGridView5.Rows.Add()
            DataGridView5.Item("DocNoTzaloom", DataGridView5.RowCount - 1).Value = TxtBox1.Text
            DataGridView5.Item("TzaloomDate", DataGridView5.RowCount - 1).Value = lstValue.Item(0)
            DataGridView5.Item("TzaloomNo", DataGridView5.RowCount - 1).Value = lstValue.Item(1)
            DataGridView5.Item("Asthlak", DataGridView5.RowCount - 1).Value = TxtBox9.Text
            DataGridView5.Item("AsthlakVal", DataGridView5.RowCount - 1).Value = TxtBox10.Text
            DataGridView5.Item("Total", DataGridView5.RowCount - 1).Value = TxtBox10.Text
            DataGridView5.Item("Description", DataGridView5.RowCount - 1).Value = lstValue.Item(2)
            bolAddTazloom = True ' تسجيل البدء في حركة جديدة
            ChkTazloom.Checked = True
            btnAddTazloom.Enabled = False
        End If
    End Sub

    Private Sub TxtBox9_TextChanged(sender As Object, e As EventArgs) Handles TxtBox9.TextChanged
        If strTable = "Tblt_Zaina" Or strTable = "Tblt_ZainaSecond" Then
            TxtBox10.Text = (FCalcZaina(Val(TxtBox9.Text))) * 300
            Call cmbPayState_SelectedIndexChanged(sender, e)
        Else
            If Not IsNothing(cmbCalcType.SelectedIndex) And TxtBox9.Text <> "" Then
                TxtBox10.Text = FCalcEnergy(Val(TxtBox9.Text), cmbCalcType.SelectedIndex)
            End If
        End If

    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Call SAddNew()
    End Sub

    Private Function FCalcZaina(intAsthlak As Integer)
        Try
            Dim dblNo As Double = (intAsthlak / 4000)
            Return RoundUp(dblNo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Dim frmNew As New frmTranSearch(strTable, "بحث " & TabPage1.Text, BolUserOpenOtherUserTran)
        frmNew.ShowDialog()
        If strDocNoSearch <> "" Then
            TxtBox1.Text = strDocNoSearch
            Call SOpen()
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If strUserType = 0 Then
            If typeFrm = frmEditType.Edit Then
                If BoluserReSave = True Then
                    Call SUpdate()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            ElseIf typeFrm = frmEditType.Save Then
                If BoluserSave = True Then
                    Call SUpdate()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            End If
        Else
            Call SUpdate()
        End If
    End Sub

    Private Sub lblPlaceCode_DoubleClick(sender As Object, e As EventArgs) Handles lblPlaceCode.DoubleClick
        Dim frmNew As New frmPlaceCode(loadType.ShowDialoge)
        frmNew.ShowDialog()
        If intComboItemNew > 0 Then
            Call SFillCombo(cmbPlaceCode, "Tblc_PlaceCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            cmbPlaceCode.SelectedValue = intComboItemNew
        End If
    End Sub


    Private Sub lblArtisticCode_DoubleClick(sender As Object, e As EventArgs) Handles lblArtisticCode.DoubleClick
        'bolDealWithCombo = False
        'bolDealWithCombo = True
        Dim frmNew As New frmArtisticCode(loadType.ShowDialoge)
        frmNew.ShowDialog()
        If intComboItemNew > 0 Then
            Call SFillCombo(cmbArtisticCode, "Tblc_ArtisticCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            cmbArtisticCode.SelectedValue = intComboItemNew
        End If
    End Sub

    Private Sub lblPoliceMenCode_DoubleClick(sender As Object, e As EventArgs) Handles lblPoliceMenCode.DoubleClick
        bolDealWithCombo = False
        If strTable = "Tblt_Disagreed" Then
            'Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            Dim frmNew As New frmPoliceMenCode(loadType.ShowDialoge)
            frmNew.ShowDialog()
            If intComboItemNew > 0 Then
                Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
                lblPoliceMenCode.Text = "مندوب الشرطة ..."
                cmbPoliceMenCode.SelectedValue = intComboItemNew
            End If
        ElseIf strTable = "Tblt_DisagreedSecond" Then
            Dim frmNew As New frmAccountMenCode(loadType.ShowDialoge)
            frmNew.ShowDialog()
            If intComboItemNew > 0 Then
                Call SFillCombo(cmbPoliceMenCode, "Tblc_AccountMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
                lblPoliceMenCode.Text = "م.الضبط القضائي ..."
                cmbPoliceMenCode.SelectedValue = intComboItemNew
                cmbMabahsCode.Enabled = False : lblMabahsCode.Enabled = False
            End If
        End If
        bolDealWithCombo = True
    End Sub

    Private Sub lblMabahsCode_DoubleClick(sender As Object, e As EventArgs) Handles lblMabahsCode.DoubleClick
        bolDealWithCombo = False
        'Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Dim frmNew As New frmMabahsCode(loadType.ShowDialoge)
        frmNew.ShowDialog()
        If intComboItemNew > 0 Then
            Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            cmbMabahsCode.SelectedValue = intComboItemNew
        End If
        bolDealWithCombo = True
    End Sub

    Private Sub cmdCheckPriviosRecord_Click(sender As Object, e As EventArgs) Handles cmdCheckPriviosRecord.Click
        If FCheckPriviosRecord() = True Then
            If FCheckPriviosRecordDisagreed() = True Then
                MsgBox("رقم الحصر متوافر", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            Else
                MsgBox("يوجد رقم حصر سابق في الضبطية القضائية" & vbCrLf & "رقم الحركة : " & strTmpTranNoDisagreed, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            End If
        Else
            MsgBox("يوجد رقم حصر سابق", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            If MsgBox("هل تريد فتح هذة الحركة", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
                TxtBox1.Text = strTmpTranNo
                Call SOpen()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Select Case e.ColumnIndex
            Case 1

            Case 2
                If DataGridView1.RowCount = 0 Then

                End If

                If DataGridView1.Item(0, e.RowIndex).Value = 1 Then
                    DataGridView1.Item(1, e.RowIndex).Value = "السداد بالكامل"
                ElseIf DataGridView1.Item(0, e.RowIndex).Value = 2 Then
                    DataGridView1.Item(1, e.RowIndex).Value = "سداد جــــــزء"
                End If
            Case 5
                If DataGridView1.Item("PayedType", e.RowIndex).Value = 0 Then
                    DataGridView1.Item("PayedTypeName", e.RowIndex).Value = "السداد يدوياً"
                ElseIf DataGridView1.Item("PayedType", e.RowIndex).Value = 1 Then
                    DataGridView1.Item("PayedTypeName", e.RowIndex).Value = "سداد آلـــي"
                End If
            Case 6

            Case 7 ' set datae time

        End Select
    End Sub

    Private Sub TxtBox10_TextChanged(sender As Object, e As EventArgs) Handles TxtBox10.TextChanged
        Call cmbPayState_SelectedIndexChanged(sender:=Nothing, e:=Nothing)
    End Sub

    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        Try
            Select Case e.ColumnIndex
                Case 7
                    Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    Dim strRepPath As String = Application.StartupPath & "\Reports\Rep Tzaloom\"

                    Select Case strTable
                        Case "Tblt_Disagreed"
                            objReport.Load(strRepPath & "RepEnergyTheftsTzaloom03.rpt")
                        Case "Tblt_EnergyTheftsSecond"
                            objReport.Load(strRepPath & "RepEnergyTheftsTzaloom04.rpt")
                        Case "Tblt_Zaina"
                            objReport.Load(strRepPath & "RepEnergyTheftsTzaloom05.rpt")
                        Case "Tblt_ZainaSecond"
                            objReport.Load(strRepPath & "RepEnergyTheftsTzaloom06.rpt")
                    End Select

                    Dim mySelectFormulaTmp As String = "{Tzaloom_" & strTable & ".ID} =" & DataGridView5.Item(0, e.RowIndex).Value

                    If RepSource = RepLoadSource.Database Then
                        Call GetServerNameAndDataBaseName(objReport)
                    ElseIf RepSource = RepLoadSource.Dataset Then

                    End If
                    objReport.DataDefinition.FormulaFields.Item("FUserName").Text = "totext('" & strUserName & "')"
                    objReport.DataDefinition.FormulaFields.Item("ZCompName").Text = "totext('" & strCompanyName & "')"
                    Dim frmReport As New frmReportViewer
                    frmReport.CRViewer1.ReportSource = objReport
                    frmReport.CRViewer1.SelectionFormula = mySelectFormulaTmp
                    frmReport.CRViewer1.Zoom(100%)
                    frmReport.CRViewer1.RefreshReport()
                    frmReport.Text = "حركة تظلمات"
                    'Call SUpdateDataForReport()
                    frmReport.Show()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCalcTypeManual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalcTypeManual.SelectedIndexChanged
        Try
            Select Case cmbCalcTypeManual.SelectedIndex
                Case 0 ' حساب الي
                    DataGridView1.Enabled = True
                    TxtBox10.Enabled = False
                Case 1 ' حساب يدوي
                    DataGridView1.Enabled = False
                    SDelGridData(DataGridView1)
                    TxtBox10.Enabled = True
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class