Imports Main_New_Project
Imports System.Math
Imports System.IO

Public Class frmEnergyThefts
    Implements IFormMainFunction

    Dim strTable As String '= "Tblt_EnergyThefts"
    Dim LstCtrl As New List(Of Control) : Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    Dim bolAcceptAdd As Boolean = True
    Dim bolDealWithCombo As Boolean = True  ' لدم حدوث خطا في كومبو الادارة
    ''
    'Dim lstTxtBox As New List(Of Control)
    Dim bolOpenCalc As Boolean = True ' لعدم حساب المحضر اثناء الفتح من قاعدة البيانات
    Dim strOld1, strOld2, strOld3, strOld4, strOld5, strOld6 As String

    Dim typeFrm As frmEditType
    Dim strTmpTranNo As String = "" ' رقم الحركة السابقة
    ''''''''''''''''

    Public Sub New(strTableName As String, strFrmName As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        strTable = strTableName
        TabPage1.Text = strFrmName
    End Sub

    Private Sub frmEnergyThefts_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        '''''''''''''''''
        Call SDrawenergyQuantityGrid(DataGridView1)
        Call SDrawPersonsGrid(DataGridView2)
        Call SDrawPriceSharehaNoGrid(DataGridView3)
        Call SDrawPayedGrid(DataGridView4)
        '''''''''''''''''
        Call SAddNew()
        Call SLoadControll()
        'Call SLoadPermission()
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
            .Add(chkCustData)
            .Add(TxtBox5)
            .Add(TxtBox6)
            .Add(TxtBox7)
            .Add(cmbArtisticCode)
            .Add(cmbPoliceMenCode)
            .Add(cmbMabahsCode)
            .Add(DateTimePicker2)
            .Add(DateTimePicker3)
            .Add(ChkBox1)
            .Add(ChkBox2)
            .Add(cmbPayState)
            .Add(TxtBox8)
            .Add(dtePayInvoice)
            .Add(cmbPriceCalcType)
            .Add(DateTimePicker4)
            .Add(DateTimePicker5)
            .Add(TxtBox9)
            .Add(TxtBox10)
            .Add(TxtBox11)
            .Add(TxtBox12)
            .Add(TxtBox13)
            .Add(TxtBox14)
            .Add(TxtBox15)
            .Add(TxtBox16)
            .Add(TxtBox17)
            .Add(TxtBox18)
            .Add(TxtBox19)
            .Add(TxtBox20)
            .Add(TxtBox21)
            .Add(TxtBox22)
            .Add(TxtBox23)
            .Add(TxtBox24)
        End With
    End Sub

    Public Sub SAddNew() Implements IFormMainFunction.SAddNew
        bolDealWithCombo = False
        '''''''''''''''''''''''
        Call ClearControl(TabPage1)
        Call ClearControl(TabControlTotal)
        ''''''''''''''''
        ''''''''''''''''
        Call cmbActivitiesCode_SelectedIndexChanged(sender:=Nothing, e:=Nothing)
        '''''''''''''''''
        Call SFillCombo(cmbActivitiesCode, "Tblc_ActivitiesCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbPlaceCode, "Tblc_PlaceCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbArtisticCode, "Tblc_ArtisticCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbPriceCode, "Tblt_PriceLevel", "DocNo", "DocDate", "PlaceCode='" & cmbActivitiesCode.SelectedValue & "'", False, "ID", ComboLoadItemSelect.Max)
        If strTable = "Tblt_EnergyThefts" Then
            Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            lblPoliceMenCode.Text = "مندوب الشرطة ..."
            Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
            Call SFillCombo(cmbPoliceMenCode, "Tblc_AccountMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            lblPoliceMenCode.Text = "م.الضبط القضائي ..."
            cmbMabahsCode.Enabled = False : lblMabahsCode.Enabled = False
        End If
        '''''''''''''''''
        TxtBox1.Text = FAutoNumber(strTable, FGetTagData(TxtBox1, Valadation.Tag), False, False)
        cmbPriceCalcType.SelectedIndex = 0
        TxtBox2.Focus()                        '   start Focus
        '''''''''''''''''''''''''''
        bolDealWithCombo = True : Call SAutoComplete()
        ''''''''''''''''''''''
        cmbPayState.SelectedIndex = 0
        chkCustData.Checked = False
        OptType1.Checked = True
        TxtBox5.Text = "0" : TxtBox6.Text = "0" : TxtBox8.Text = "0"
        '''''''''''''''''''''''
        Call SLoadTypeCombox() ' Load partionCode and Branches
        '''''''''''''''''
        Call chkCustData_CheckedChanged(sender:="", e:=Nothing)
        cmbArtisticCode.Text = "" : cmbPoliceMenCode.Text = "" : cmbPartionCode.Text = "" : CmbBranchCode.Text = ""
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
        TxtBox13.Enabled = False ' غرامة العمدي
        TxtBox15.Enabled = False ' اذاعه
        TxtBox16.Enabled = False ' استهلاك
        TxtBox17.Enabled = False ' محافظة
        ''
        strTmpTranNo = ""
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
                        Dim bolTemp As Boolean = IIf((dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString() = "0"), False, True)
                        DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = bolTemp
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
        ''''''''''''''
        Call SLoadGrid(strTable & "Devices", DataGridView1, "DocNo", TxtBox1.Text, False, "", "", False)
        Call SLoadGrid(strTable & "People", DataGridView2, "DocNo", TxtBox1.Text, False, "", "", False)
        Call SLoadGrid(strTable & "PriceLevel", DataGridView3, "DocNo", TxtBox1.Text, False, "", "", False)
        Call SLoadGrid(strTable & "Payed", DataGridView4, "DocNo", TxtBox1.Text, False, "", "", False)
        ''''''''''''''''''''''''''''
        Call SLoadCmbPayState()
        bolOpenCalc = True ' لاعادة تشغيل حساب المحضر
        typeFrm = frmEditType.Edit : TxtTitle2.Text = "تعديل"
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

    Private Sub SSetCtlEnable()
        If cmbPayState.SelectedIndex = 5 Then
            cmbPayState.Enabled = False : TxtBox8.Enabled = False : dtePayInvoice.Enabled = False : Label21.Enabled = False
        Else
            cmbPayState.Enabled = True : TxtBox8.Enabled = True : dtePayInvoice.Enabled = True : Label21.Enabled = True
        End If
    End Sub

    Public Sub SUpdate() Implements IFormMainFunction.SUpdate
        Try
            If FValidation(Me, TabControl) = True Then
                If FCheckDemo(TabPage1.Tag, 5) = True Then
                    If FCheckGrid(DataGridView1, "جريدة الأحمال") = True Then
                        If FCheckPriviosRecord() = True Then
                            '''''''''''
                            'Dim StrDocNoTemp As Boolean = FGetFeildValuesBol(strTable, "Name", "ID=" & TxtBox1.Text & " And BranchCode=" & CmbBranchCode.SelectedValue, False)
                            Call SFillCtl()
                            If typeFrm = frmEditType.Save Then
                                TxtBox1.Text = FAddNewRecord2(strTable, lstCtlTag, lstCtlVal)
                            ElseIf typeFrm = frmEditType.Edit Then
                                FEditeRecord(strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, lstCtlTag, lstCtlVal)
                            End If

                            Call SSaveGrid(strTable & "Devices", DataGridView1, "DocNo", Val(TxtBox1.Text), "", True, False, False)
                            Call SSaveGrid(strTable & "People", DataGridView2, "DocNo", Val(TxtBox1.Text), "", True, False, False)
                            Call SSaveGrid(strTable & "PriceLevel", DataGridView3, "DocNo", Val(TxtBox1.Text), "", True, True, False)
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
                            MsgBox("يوجد رقم حصر سابق", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                            If MsgBox("هل تريد فتح هذة الحركة", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
                                TxtBox1.Text = strTmpTranNo
                                Call SOpen()
                            End If
                        End If
                    End If
                End If
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SDelete() Implements IFormMainFunction.SDelete
        If MsgBox("هل تريد حذف السجل الحالي", CType(MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Ok Then
            Dim strCondition As String = (FGetTagData(TxtBox1, Valadation.Tag) & "=" & TxtBox1.Text)
            FDeleteRecord(strTable, strCondition)
            Call SAddNew()
        End If
    End Sub

    Public Sub SMoveFirst() Implements IFormMainFunction.SMoveFirst
        Dim S As String = FNavigate(NavDirection.DMoveFirst, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveLast() Implements IFormMainFunction.SMoveLast
        Dim S As String = FNavigate(NavDirection.DMoveLast, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveNext() Implements IFormMainFunction.SMoveNext
        Dim S As String = FNavigate(NavDirection.DMoveNext, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMovePrevious() Implements IFormMainFunction.SMovePrevious
        Dim S As String = FNavigate(NavDirection.DMovePrevious, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
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
                If strTable = "Tblt_EnergyThefts" Then
                    objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts02.rpt")
                ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
                    objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts12.rpt")
                End If
            ElseIf DataType = DataConnection.Access Then
                If strTable = "Tblt_EnergyThefts" Then
                    objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts02.rpt")
                ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
                    objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts12.rpt")
                End If
            End If
            mySelectFormula = "{Tblt_EnergyThefts.ID} =" & TxtBox1.Text
            objReport.DataDefinition.FormulaFields.Item("FUserName").Text = "totext('" & strUserName & "')"
            objReport.DataDefinition.FormulaFields.Item("ZCompName").Text = "totext('" & strCompanyName & "')"
            Call GetServerNameAndDataBaseName(objReport)
            Dim frmReport As New frmReportViewer
            'frmReport.CRViewer1.ReportSource = objReport
            'frmReport.CRViewer1.SelectionFormula = mySelectFormula
            'frmReport.CRViewer1.Zoom(100%)
            'frmReport.CRViewer1.RefreshReport()
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
                Dim intTemp As Integer = IIf((DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = True), 1, 0)
                lstCtlVal.Add(intTemp)
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
        lstCtlTag.Add("[UserID]")
        lstCtlVal.Add(Val(strUserID))
    End Sub

    Private Sub me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserEdit", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SUpdate()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SUpdate()
            End If
        ElseIf e.Control And e.KeyCode = Keys.O Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SOpen()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SOpen()
            End If
        ElseIf e.Control And e.KeyCode = Keys.D Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserDel", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
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
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMovePrevious()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMovePrevious()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Right Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMoveNext()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveNext()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Up Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMoveFirst()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveFirst()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Down Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMoveLast()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveLast()
            End If
        End If
        '''''''''''''
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox1.KeyPress, TxtBox2.KeyPress, TxtBox3.KeyPress, TxtBox4.KeyPress, TxtBox5.KeyPress, TxtBox6.KeyPress, TxtBox7.KeyPress, TxtBox8.KeyPress, TxtBox9.KeyPress, TxtBox10.KeyPress, TxtBox11.KeyPress, TxtBox12.KeyPress, TxtBox13.KeyPress, TxtBox14.KeyPress, TxtBox15.KeyPress, TxtBox16.KeyPress, TxtBox17.KeyPress, TxtBox18.KeyPress, TxtBox19.KeyPress, TxtBox20.KeyPress, TxtBox21.KeyPress, TxtBox22.KeyPress, TxtBox23.KeyPress, TxtBox24.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox1.Name, TxtBox5.Name, TxtBox6.Name, TxtBox8.Name, TxtBox10.Name, TxtBox11.Name, TxtBox12.Name, TxtBox13.Name, TxtBox14.Name, TxtBox15.Name, TxtBox16.Name, TxtBox17.Name, TxtBox18.Name, TxtBox19.Name, TxtBox20.Name, TxtBox21.Name, TxtBox22.Name, TxtBox23.Name, TxtBox24.Name
                e.KeyChar = FJustNumber(e)
                'If e.KeyChar = Chr(13) Then
                '    SendKeys.Send("{TAB}")
                'End If
            Case Else
                'If e.KeyChar = Chr(13) Then
                '    SendKeys.Send("{TAB}")
                'End If
        End Select
    End Sub

    Private Sub CmbBranchCode_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPartionCode.KeyDown, CmbBranchCode.KeyDown, cmbActivitiesCode.KeyDown, cmbPlaceCode.KeyDown, cmbArtisticCode.KeyDown, cmbPoliceMenCode.KeyDown, cmbMabahsCode.KeyDown, cmbPayState.KeyDown, cmbPriceCalcType.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub DateTimePicker_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker2.KeyDown, DateTimePicker2.KeyDown, DateTimePicker3.KeyDown, DateTimePicker3.KeyDown, DateTimePicker4.KeyDown, DateTimePicker5.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub TxtBox_GotFocus(sender As Object, e As EventArgs) Handles TxtBox1.GotFocus, TxtBox2.GotFocus, TxtBox3.GotFocus, TxtBox5.GotFocus, TxtBox6.GotFocus, TxtBox7.GotFocus, TxtBox8.GotFocus, TxtBox9.GotFocus, TxtBox10.GotFocus, TxtBox11.GotFocus, TxtBox12.GotFocus, TxtBox13.GotFocus, TxtBox14.GotFocus, TxtBox15.GotFocus, TxtBox16.GotFocus, TxtBox17.GotFocus, TxtBox18.GotFocus, TxtBox19.GotFocus, TxtBox20.GotFocus, TxtBox21.GotFocus, TxtBox22.GotFocus, TxtBox23.GotFocus, TxtBox24.GotFocus
        Call FChangeLang()
    End Sub

    Private Sub DateTimePicker_EditValueChanged(sender As Object, e As EventArgs)
        If DateTimePicker5.Text = "" Or DateTimePicker5.Text = "" Then

        Else
            Dim dteOne As Date = FormatDateTime(DateTimePicker5.Text, DateFormat.ShortDate)
            Dim dteTwo As Date = FormatDateTime(DateTimePicker5.Text, DateFormat.ShortDate)

            TxtBox9.Text = DateDiff(DateInterval.Day, dteOne, dteTwo)
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                DataGridView1.Item(7, i).Value = TxtBox9.Text
            Next
        End If
    End Sub

    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged, DateTimePicker5.ValueChanged
        'If cmbPriceCalcType.SelectedIndex = 2 Then
        Dim dteOne As Date = FormatDateTime(DateTimePicker4.Value, DateFormat.ShortDate)
        Dim dteTwo As Date = FormatDateTime(DateTimePicker5.Value, DateFormat.ShortDate)

        TxtBox9.Text = DateDiff(DateInterval.Day, dteOne, dteTwo)
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            DataGridView1.Item("DaysCount", i).Value = TxtBox9.Text
        Next
        'End If
    End Sub

    Private Sub DateTimePicker5_EditValueChanging(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged, DateTimePicker5.ValueChanged
        If cmbPriceCalcType.SelectedIndex = 2 Then
            Dim dteOne As Date = FormatDateTime(DateTimePicker4.Text, DateFormat.ShortDate)
            Dim dteTwo As Date = FormatDateTime(DateTimePicker5.Text, DateFormat.ShortDate)

            TxtBox9.Text = DateDiff(DateInterval.Day, dteOne, dteTwo)
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                DataGridView1.Item(7, i).Value = TxtBox9.Text
            Next
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.ColumnIndex >= 0 Then
            Select Case DataGridView1.Columns(e.ColumnIndex).Index
                Case "0"
                    If e.RowIndex <> -1 Then
                        Call SAddGridRow(DataGridView1)
                        Me.DataGridView1.BeginEdit(True)
                        Me.DataGridView1.Item(0, e.RowIndex).Value = FSearch("Tblc_EnergyDevices", "ID", "", "", "ID", "Name", 1, 0)
                        SendKeys.Send("{enter}")
                        Me.DataGridView1.EndEdit()
                        Me.DataGridView1.Item(6, e.RowIndex).Value = IIf(cmbActivitiesCode.Text = "منزلي", 8, 12)
                        'SendKeys.Send("{enter}")
                    End If
                Case "2"
                    'If e.RowIndex <> -1 Then
                    '    Me.DataGridView1.BeginEdit(True)
                    '    Me.DataGridView1.Item(2, e.RowIndex).Value = FSearch("Tblc_KiloHorseWat", "Code", "", "", "Code", "Code", 1)
                    '    SendKeys.Send("{enter}")
                    '    Me.DataGridView1.EndEdit()
                    '    'SendKeys.Send("{enter}")
                    'End If
            End Select
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Dim autoText As TextBox = TryCast(e.Control, TextBox)
        If autoText IsNot Nothing Then
            If DataGridView1.CurrentCell.ColumnIndex = 1 AndAlso TypeOf e.Control Is TextBox Then
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                Dim DataCollection As New AutoCompleteStringCollection()
                SFillTextBoxGrid(DataCollection, "Tblc_EnergyDevices", "ID", "Name", "", False, "")
                autoText.AutoCompleteCustomSource = DataCollection
                'ElseIf DataGridView1.CurrentCell.ColumnIndex = 3 AndAlso TypeOf e.Control Is TextBox Then
                '    autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                '    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                '    Dim DataCollection As New AutoCompleteStringCollection()
                '    SFillTextBoxGrid(DataCollection, "Tblc_KiloHorseWat", "Code", "Name", "", False, "")
                '    autoText.AutoCompleteCustomSource = DataCollection
            Else
                autoText.AutoCompleteMode = AutoCompleteMode.None
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Select Case DataGridView1.Columns(e.ColumnIndex).Index
            Case "0"
                Dim StrTemp() As String = FGetFeildValuesArry("Tblc_EnergyDevices", {"Name", "Type", "Power"}, "ID=" & Me.DataGridView1.Item(0, e.RowIndex).Value)
                If StrTemp(0) <> "" Then
                    Me.DataGridView1.Item("EnergyName", e.RowIndex).Value = StrTemp(0)
                    Me.DataGridView1.Item("KWHHorseWattCode", e.RowIndex).Value = StrTemp(1)
                    If (StrTemp(1) = 2) Then DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightPink Else DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    Me.DataGridView1.Item("EnergyQuntity", e.RowIndex).Value = StrTemp(2)
                    Me.DataGridView1.Item("EnergyDevicesCount", e.RowIndex).Value = "1"
                    Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
                Else
                    MsgBox("كود الجهاز الكهربائي الذي تم ادخالة غير صحيح", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "كود المفتش الذي تم ادخالة غير صحيح"
                    DataGridView1.CurrentCell = Me.DataGridView1.Item(e.ColumnIndex, e.RowIndex)
                End If
            Case "2"
                Dim StrTemp As String = FGetFeildValues("Tblc_KiloHorseWat", "Name", "Code=" & Me.DataGridView1.Item(2, e.RowIndex).Value)
                If StrTemp <> "" Then
                    Me.DataGridView1.Item(3, e.RowIndex).Value = StrTemp
                    Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
                Else
                    MsgBox("كود الجهاز الكهربائي الذي تم ادخالة غير صحيح", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "كود المفتش الذي تم ادخالة غير صحيح"
                    DataGridView1.CurrentCell = Me.DataGridView1.Item(e.ColumnIndex, e.RowIndex)
                End If
                '''''''''''''  
                If DataGridView1.Item("KWHHorseWattCode", e.RowIndex).Value = 1 Then
                    DataGridView1.Item("Elkodra", e.RowIndex).Value = (DataGridView1.Item("EnergyQuntity", e.RowIndex).Value) * 1
                Else
                    DataGridView1.Item("Elkodra", e.RowIndex).Value = Math.Ceiling(((DataGridView1.Item("EnergyQuntity", e.RowIndex).Value) * 746))
                End If
            Case 4
                If DataGridView1.Item("KWHHorseWattCode", e.RowIndex).Value = 1 Then
                    DataGridView1.Item("Elkodra", e.RowIndex).Value = (DataGridView1.Item("EnergyQuntity", e.RowIndex).Value) * 1
                Else
                    DataGridView1.Item("Elkodra", e.RowIndex).Value = Math.Ceiling(((DataGridView1.Item("EnergyQuntity", e.RowIndex).Value) * 746))
                End If
            Case 5
                'DataGridView1.Item("Elkodra", e.RowIndex).Value = (DataGridView1.Item("EnergyDevicesCount", e.RowIndex).Value) * (DataGridView1.Item("EnergyQuntity", e.RowIndex).Value)
                If DataGridView1.Item("KWHHorseWattCode", e.RowIndex).Value = 1 Then
                    DataGridView1.Item("Elkodra", e.RowIndex).Value = DataGridView1.Item("EnergyDevicesCount", e.RowIndex).Value * (DataGridView1.Item("EnergyQuntity", e.RowIndex).Value) * 1
                Else
                    DataGridView1.Item("Elkodra", e.RowIndex).Value = DataGridView1.Item("EnergyDevicesCount", e.RowIndex).Value * Math.Ceiling(((DataGridView1.Item("EnergyQuntity", e.RowIndex).Value) * 746))
                    'Dim m As Double = Math.Ceiling(((DataGridView1.Item("EnergyQuntity", e.RowIndex).Value) * 746))
                End If
        End Select
        Call SCalcGridTotal()
    End Sub

    Private Sub SCalcGridTotal()
        If bolOpenCalc = True Then
            Dim intAlmightiness As Integer = 0
            Dim dblAsthlakVal As Double = 0

            For i As Integer = 0 To DataGridView1.RowCount - 1
                '''''''''''''''''
                If DataGridView1.Item("DaysCount", i).Value = Nothing Then
                    If cmbPriceCalcType.SelectedIndex >= 0 Then
                        Call SCmbPriceType()
                    End If
                End If
                ''''''''''''''''
                DataGridView1.Item("Asthlak", i).Value = Math.Round(((DataGridView1.Item("Elkodra", i).Value) * (DataGridView1.Item("HoursCount", i).Value) * (DataGridView1.Item("DaysCount", i).Value)) / 1000, 0)
                intAlmightiness += DataGridView1.Item("Asthlak", i).Value
            Next
            TxtBox10.Text = intAlmightiness
            Call FCalcEnergy() ' حساب التسوية
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Select Case e.ColumnIndex
            Case 1
                DataGridView1.Item("EnergyCode", e.RowIndex).Value = FGetFeildValues("Tblc_EnergyDevices", "ID", "Name='" & DataGridView1.Item(1, e.RowIndex).Value & "'", False, False)
            Case 3
                DataGridView1.Item("KWHHorseWattCode", e.RowIndex).Value = FGetFeildValues("Tblc_KiloHorseWat", "Code", "Name='" & DataGridView1.Item(3, e.RowIndex).Value & "'", False, False)
        End Select
    End Sub

    Private Sub DataGridView1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.GotFocus, DataGridView2.GotFocus
        Call FChangeLang()
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        If Val(e.RowIndex) > 0 Then
            Me.DataGridView1.Item("HoursCount", e.RowIndex - 1).Value = IIf(cmbActivitiesCode.Text = "منزلي", 8, 12)
            Me.DataGridView1.Item("DaysCount", e.RowIndex - 1).Value = TxtBox9.Text
        End If

        'If DataGridView1.RowCount > 0 Then
        '    For i As Integer = 0 To DataGridView1.RowCount - 1
        '        Dim k As Integer = i + 1
        '        DataGridView1.Rows(i).HeaderCell.Value = k.ToString
        '    Next i
        'End If
    End Sub
    Private Sub cmbPriceCalcType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPriceCalcType.SelectedIndexChanged
        Call SCmbPriceType()
    End Sub

    Private Sub SCmbPriceType()
        Try
            Select Case cmbPriceCalcType.SelectedIndex
                Case 0 'سنوي
                    'GroupControlDatePriceCalc.Enabled = False
                    TxtBox9.Text = "365"
                    DateTimePicker5.Text = DateTimePicker2.Text
                    DateTimePicker4.Text = DateAdd(DateInterval.Day, -365, CType(DateTimePicker2.Text, Date))
                Case 1 'اعمال مؤقتة
                    'GroupControlDatePriceCalc.Enabled = False
                    DateTimePicker5.Text = DateTimePicker2.Text
                    DateTimePicker4.Text = DateAdd(DateInterval.Day, -90, CType(DateTimePicker2.Text, Date))
                    TxtBox9.Text = "90"
                Case 2 'ضبط سابق
                    'GroupControlDatePriceCalc.Enabled = True

                    'DateTimePicker5.Text = DateTimePicker2.Text
                    'DateTimePicker4.Text = DateTimePicker2.Text       
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FCalcEnergy() As Double
        '''''''''''''''''' Get Price Date
        Dim strCondition As String = ""
        If DataType = DataConnection.SqlServer Then
            strCondition = "DocDate <='" & FFormatDate(DateTimePicker5.Text) & "' And DocDateTo >='" & FFormatDate(DateTimePicker5.Text) & "' And PlaceCode='" & cmbActivitiesCode.SelectedValue & "'"
        ElseIf DataType = DataConnection.Access Then
            strCondition = "DocDate <=#" & FFormatDate(DateTimePicker5.Text) & "# And DocDateTo >=#" & FFormatDate(DateTimePicker5.Text) & "# And PlaceCode='" & cmbActivitiesCode.SelectedValue & "'"
        End If
        Dim strPriceCode As String = FGetFeildValues("Tblt_PriceLevel", "DocNo", strCondition, False, False)

        If strPriceCode <> Nothing Then
            cmbPriceCode.SelectedValue = strPriceCode
            '''''''''''''''''' Get Price Date
            TxtBox11.Text = calcAsthlakVal(strPriceCode, Val(TxtBox10.Text), Val(TxtBox9.Text))
            '''''''''''' غرامة العمدى
            If cmbPriceCalcType.SelectedIndex = 2 Then
                TxtBox13.Text = ((FGetFeildValues("Tblt_PriceLevelGrid", "Price", "DocNo='" & strPriceCode & "' Order By SHNO  DESC") * Val(TxtBox10.Text)) - Val(TxtBox12.Text)) * 4
            Else
                TxtBox13.Text = ((FGetFeildValues("Tblt_PriceLevelGrid", "Price", "DocNo='" & strPriceCode & "' Order By SHNO  DESC") * Val(TxtBox10.Text)) - Val(TxtBox12.Text)) * 2
            End If
            '''''''''''' غرامة العمدى
            Call SCalcStamp()

            Dim dblTot As Double = 0
            dblTot = Round(Val(TxtBox11.Text) - Val(TxtBox12.Text) + Val(TxtBox13.Text) + Val(TxtBox14.Text) + Val(TxtBox15.Text) + Val(TxtBox16.Text) + Val(TxtBox17.Text) + Val(TxtBox18.Text), 2)

            ''TxtBox18.Text = Round(FGbrNumber(dblTot) - dblTot, 2) ' لجبر قيمة المحضر لاقرب 5 قروش
            'TxtBox19.Text = TxtBox18.Text + dblTot
            TxtBox19.Text = FGbrNumber(dblTot)
            TxtBox18.Text = Round(TxtBox19.Text - dblTot)
        End If
    End Function

    Private Function calcAsthlakVal(strPriceCode As String, intAsthlak As Integer, intEffectDay As Integer, Optional ByVal bolDealWithAddVal As Boolean = False) As Double
        Try
            Dim IntOldAsthlak As Double = intAsthlak 'وضع قيمة إجمالي الإستهلاك
            Dim intNewAsthlak As Double = intAsthlak ' وضع قيمة مبدائية
            Dim tmpFrom, tmpTo, tmpPrice, tmpAdd, tmpValue, Tmp As Double ' true
            Dim X As Integer = 0    'خاص بالسعر الجديدوالاسعار المتداخلة
            DataGridView3.Rows.Clear() ''' لتفريغ جريدة الاسعار

            Dim strSQL As String = " Select * From Tblt_PriceLevelGrid Where (((Tblt_PriceLevelGrid.DocNo) = '" & strPriceCode & "'))" &
            " ORDER BY Tblt_PriceLevelGrid.SHNO ;"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim reader As SqlClient.SqlDataReader = cmd.ExecuteReader()
                Do While reader.Read
                    tmpFrom = reader.Item("From") : tmpTo = reader.Item("To") : tmpPrice = reader.Item("Price") 'set val

                    ''''لتصفير الشريحة في الاسعار الجديدة
                    If tmpFrom = 1 And X > 0 Then
                        tmpValue = 0 : intNewAsthlak = intAsthlak : X = 0
                        DataGridView3.Rows.Clear() ''' لتفريغ جريدة الاسعار
                    End If
                    ''''لتصفير الشريحة في الاسعار الجديدة

                    '''''''''''''' جزء خاص برسوم الإصدار
                    If bolDealWithAddVal = True Then
                        tmpAdd = (reader.Item("Add") / 30) * intEffectDay
                    ElseIf bolDealWithAddVal = False Then
                        tmpAdd = 0
                    End If
                    '''''''''''''' جزء خاص برسوم الإصدار

                    'Tmp = Math.Round((((tmpTo - tmpFrom) + 1) / 30) * intEffectDay) ' نصيب اليوم من الشريحة
                    If cmbPriceCalcType.SelectedIndex = 0 Then     ' في حالة المدة سنة
                        Tmp = (((tmpTo - tmpFrom) + 1) * 12)
                    ElseIf cmbPriceCalcType.SelectedIndex = 1 Then ' في حالة المدة 90 يوم
                        Tmp = ((((tmpTo - tmpFrom) + 1) * 12) / 4)
                    Else                                           ' في حالة المدة باليوم
                        Tmp = Math.Round(((((tmpTo - tmpFrom) + 1) * 12) / 365) * intEffectDay)
                    End If

                    'Tmp = ((((tmpTo - tmpFrom) + 1) / 30) * intEffectDay) ' نصيب اليوم من الشريحة
                    If intNewAsthlak <= Tmp Then
                        ''''''''''''''''
                        DataGridView3.Rows.Add()
                        DataGridView3.Item(0, DataGridView3.Rows.Count - 1).Value = reader.Item("SHNO")
                        DataGridView3.Item(1, DataGridView3.Rows.Count - 1).Value = intNewAsthlak
                        DataGridView3.Item(2, DataGridView3.Rows.Count - 1).Value = reader.Item("Price")
                        DataGridView3.Item(3, DataGridView3.Rows.Count - 1).Value = intEffectDay
                        DataGridView3.Item(4, DataGridView3.Rows.Count - 1).Value = intNewAsthlak * reader.Item("Price")
                        DataGridView3.Item(5, DataGridView3.Rows.Count - 1).Value = ((tmpTo - tmpFrom) + 1)
                        '''''''''''''''''
                        reader.Close()
                        'Return Math.Round(((tmpValue + (intNewAsthlak * tmpPrice)) + tmpAdd), 2)
                        Return ((tmpValue + (intNewAsthlak * tmpPrice)) + tmpAdd)
                    Else
                        tmpValue = tmpValue + (Tmp * tmpPrice)
                        intNewAsthlak -= Tmp
                        ''''''''''''''''
                        DataGridView3.Rows.Add()
                        DataGridView3.Item(0, DataGridView3.Rows.Count - 1).Value = reader.Item("SHNO")
                        DataGridView3.Item(1, DataGridView3.Rows.Count - 1).Value = Tmp
                        DataGridView3.Item(2, DataGridView3.Rows.Count - 1).Value = reader.Item("Price")
                        DataGridView3.Item(3, DataGridView3.Rows.Count - 1).Value = intEffectDay
                        DataGridView3.Item(4, DataGridView3.Rows.Count - 1).Value = Tmp * reader.Item("Price")
                        DataGridView3.Item(5, DataGridView3.Rows.Count - 1).Value = ((tmpTo - tmpFrom) + 1)
                        '''''''''''''''''
                    End If
                    X += 1
                Loop
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim reader As OleDb.OleDbDataReader = cmd.ExecuteReader()
                Do While reader.Read
                    tmpFrom = reader.Item("From") : tmpTo = reader.Item("To") : tmpPrice = reader.Item("Price") 'set val

                    ''''لتصفير الشريحة في الاسعار الجديدة
                    If tmpFrom = 1 And X > 0 Then
                        tmpValue = 0 : intNewAsthlak = intAsthlak : X = 0
                        DataGridView3.Rows.Clear() ''' لتفريغ جريدة الاسعار
                    End If
                    ''''لتصفير الشريحة في الاسعار الجديدة

                    '''''''''''''' جزء خاص برسوم الإصدار
                    If bolDealWithAddVal = True Then
                        tmpAdd = (reader.Item("Add") / 30) * intEffectDay
                    ElseIf bolDealWithAddVal = False Then
                        tmpAdd = 0
                    End If
                    '''''''''''''' جزء خاص برسوم الإصدار

                    'Tmp = Math.Round((((tmpTo - tmpFrom) + 1) / 30) * intEffectDay) ' نصيب اليوم من الشريحة
                    If cmbPriceCalcType.SelectedIndex = 0 Then     ' في حالة المدة سنة
                        Tmp = (((tmpTo - tmpFrom) + 1) * 12)
                    ElseIf cmbPriceCalcType.SelectedIndex = 1 Then ' في حالة المدة 90 يوم
                        Tmp = ((((tmpTo - tmpFrom) + 1) * 12) / 4)
                    Else                                           ' في حالة المدة باليوم
                        Tmp = Math.Round(((((tmpTo - tmpFrom) + 1) * 12) / 365) * intEffectDay)
                    End If

                    'Tmp = ((((tmpTo - tmpFrom) + 1) / 30) * intEffectDay) ' نصيب اليوم من الشريحة
                    If intNewAsthlak <= Tmp Then
                        ''''''''''''''''
                        DataGridView3.Rows.Add()
                        DataGridView3.Item(0, DataGridView3.Rows.Count - 1).Value = reader.Item("SHNO")
                        DataGridView3.Item(1, DataGridView3.Rows.Count - 1).Value = intNewAsthlak
                        DataGridView3.Item(2, DataGridView3.Rows.Count - 1).Value = reader.Item("Price")
                        DataGridView3.Item(3, DataGridView3.Rows.Count - 1).Value = intEffectDay
                        DataGridView3.Item(4, DataGridView3.Rows.Count - 1).Value = intNewAsthlak * reader.Item("Price")
                        DataGridView3.Item(5, DataGridView3.Rows.Count - 1).Value = ((tmpTo - tmpFrom) + 1)
                        '''''''''''''''''
                        reader.Close()
                        'Return Math.Round(((tmpValue + (intNewAsthlak * tmpPrice)) + tmpAdd), 2)
                        Return ((tmpValue + (intNewAsthlak * tmpPrice)) + tmpAdd)
                    Else
                        tmpValue = tmpValue + (Tmp * tmpPrice)
                        intNewAsthlak -= Tmp
                        ''''''''''''''''
                        DataGridView3.Rows.Add()
                        DataGridView3.Item(0, DataGridView3.Rows.Count - 1).Value = reader.Item("SHNO")
                        DataGridView3.Item(1, DataGridView3.Rows.Count - 1).Value = Tmp
                        DataGridView3.Item(2, DataGridView3.Rows.Count - 1).Value = reader.Item("Price")
                        DataGridView3.Item(3, DataGridView3.Rows.Count - 1).Value = intEffectDay
                        DataGridView3.Item(4, DataGridView3.Rows.Count - 1).Value = Tmp * reader.Item("Price")
                        DataGridView3.Item(5, DataGridView3.Rows.Count - 1).Value = ((tmpTo - tmpFrom) + 1)
                        '''''''''''''''''
                    End If
                    X += 1
                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub SCalcStamp()
        Try
            Dim dblAsthlakTmp As Double = 0
            If Val(TxtBox9.Text) > 0 Then dblAsthlakTmp = ((Val(TxtBox10.Text) / Val(TxtBox9.Text)) * 30) Else dblAsthlakTmp = 0 ' نصيب الشهر من الكيلووات

            Select Case cmbActivitiesCode.SelectedValue
                Case "1" ' منزلي
                    If dblAsthlakTmp >= 45 Then             'دمغة اذاعه
                        TxtBox15.Text = Round((0.09 * Round((Int(Val(TxtBox9.Text) / 30)), 0)), 2)
                    Else
                        TxtBox15.Text = Round((Val(TxtBox10.Text) * 0.002), 2)  'دمغة اذاعه
                    End If
                    TxtBox16.Text = "0" ' دمغة استهلاك
                    TxtBox17.Text = 0.01 * Round(Int(Val(TxtBox9.Text) / 30), 0)  'دمغة ايصال
                Case Else 'الانشطة غير المنزلي
                    TxtBox15.Text = Round((Val(TxtBox10.Text) * 0.002), 2)  'دمغة اذاعه
                    If Val(TxtBox14.Text) > 0 Then
                        TxtBox16.Text = "0"
                    Else
                        TxtBox16.Text = Round((0.03 * Val(TxtBox10.Text)), 2)
                    End If
                    TxtBox17.Text = 0.01 * Round(Int(Val(TxtBox9.Text) / 30), 0)  'دمغة ايصال
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbActivitiesCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbActivitiesCode.SelectedIndexChanged
        If bolDealWithCombo = True Then
            Call SFillCombo(cmbPriceCode, "Tblt_PriceLevel", "DocNo", "DocDate", "PlaceCode='" & cmbActivitiesCode.SelectedValue & "'", False, "ID", ComboLoadItemSelect.Max)
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                DataGridView1.Item("HoursCount", i).Value = IIf(cmbActivitiesCode.Text = "منزلي", 8, 12)
            Next
        End If
    End Sub

    Private Sub TxtBox_TextChanged(sender As Object, e As EventArgs) Handles TxtBox12.TextChanged, TxtBox13.TextChanged, TxtBox14.TextChanged, TxtBox15.TextChanged, TxtBox16.TextChanged, TxtBox17.TextChanged, TxtBox18.TextChanged
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox12.Name
                Call FCalcEnergy()
            Case TxtBox14.Name
                Call SCalcStamp()
        End Select
        'TxtBox19.Text = Val(TxtBox11.Text) - Val(TxtBox12.Text) + Val(TxtBox13.Text) + Val(TxtBox14.Text) + Val(TxtBox15.Text) + Val(TxtBox16.Text) + Val(TxtBox17.Text) + Val(TxtBox18.Text)
        'TxtBox18.Text = FGbrNumber(TxtBox19.Text) ' لجبر قيمة المحضر لاقرب 5 قروش
    End Sub

    Private Sub cmdIndustrialHallmark_Click(sender As Object, e As EventArgs) Handles cmdIndustrialHallmark.Click
        TxtBox14.Text = Round((Val(TxtBox10.Text) * 0.006), 2)
        Call SCalcStamp()
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        If cmbPriceCode.Enabled = True Then cmbPriceCode.Enabled = False Else cmbPriceCode.Enabled = True
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
                Case 1 ' تم السداد
                    TxtBox8.Enabled = True
                    dtePayInvoice.Enabled = True
                Case 2 ' تم التقسيط
                    If bolOpenCalc = True Then
                        MsgBox("لا يمكن التقسيط من خلال تلك الشاشة" & vbCrLf & "يتم التقسيط من خلال شاشة السداد", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        cmbPayState.SelectedIndex = 0
                        'TxtBox8.Text = ""
                        'TxtBox8.Enabled = False
                        'dtePayInvoice.Enabled = False
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdAtt_Click(sender As Object, e As EventArgs) Handles cmdAtt.Click
        Dim myStream As Stream = Nothing

        OpenFileDialog1.InitialDirectory = "D:\"
        OpenFileDialog1.Filter = "All files (*.*)|*.*"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Multiselect = True

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = OpenFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then

                    Dim s() As String = OpenFileDialog1.FileNames
                    Dim x() As String = OpenFileDialog1.SafeFileNames
                    Dim strPath As String = (Application.StartupPath & "\Attach\EnergyThefts\Zattach files\" & TxtBox1.Text)

                    If IO.Directory.Exists(strPath) = False Then
                        IO.Directory.CreateDirectory(strPath)
                    Else

                    End If

                    For i As Integer = 0 To s.Count - 1
                        IO.File.Copy(s(i).ToString, strPath & "\" & x(i).ToString) ' copt templete file
                    Next
                End If

                MsgBox("تم إضافة المرفقات بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub cmdOpenPathAttach_Click(sender As Object, e As EventArgs) Handles cmdOpenPathAttach.Click
        Dim strPath As String = Application.StartupPath & "\Attach\EnergyThefts\Zattach files\" & TxtBox1.Text

        If IO.Directory.Exists(strPath) = False Then
            MsgBox("لا يوجد مرفقات لهذة الحركة", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        Else
            Process.Start("explorer.exe", strPath)
        End If
    End Sub

    Private Sub cmdDeleteAttach_Click(sender As Object, e As EventArgs) Handles cmdDeleteAttach.Click
        If MsgBox("سيتم مسح المرفقات الخاصة بتلك الحركة" & vbCrLf & "هل أنت متأكد من الحذف؟", MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Ok Then
            If IO.Directory.Exists((Application.StartupPath & "\Attach\EnergyThefts\Zattach files\" & TxtBox1.Text)) = True Then
                IO.Directory.Delete((Application.StartupPath & "\Attach\EnergyThefts\Zattach files\" & TxtBox1.Text), True)
            Else

            End If
        End If
    End Sub
    Private Sub chkCustData_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustData.CheckedChanged
        If chkCustData.Checked = True Then
            GBCustData.Enabled = True
            TxtBox12.Enabled = True
        Else
            GBCustData.Enabled = False
            TxtBox12.Enabled = False
        End If
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles OptType1.CheckedChanged, OptType2.CheckedChanged
        Call SLoadTypeCombox()
    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
        With lstCtlVal
            .Add(FFormatDate(DateTimePicker1.Value))
            .Add(OptType1.Checked)
            .Add(OptType2.Checked)
            .Add(CmbBranchCode.SelectedValue)
            .Add(cmbPartionCode.SelectedValue)
            .Add(TxtBox2.Text)
            .Add(TxtBox3.Text)
            .Add(cmbActivitiesCode.SelectedValue)
            .Add(cmbPlaceCode.SelectedValue)
            .Add(TxtBox4.Text)
            .Add(TxtBox5.Text)
            .Add(TxtBox6.Text)
            .Add(cmbArtisticCode.SelectedValue)
            .Add(cmbPoliceMenCode.SelectedValue)
            .Add(cmbMabahsCode.SelectedValue)
            .Add(FFormatDate(DateTimePicker2.Value))
            .Add(FFormatDate(DateTimePicker3.Value))
            .Add(ChkBox1.Checked)
            .Add(ChkBox2.Checked)
            .Add(cmbPayState.SelectedIndex)
            .Add(TxtBox8.Text)
            .Add(FFormatDate(dtePayInvoice.Value))
            .Add(cmbPriceCalcType.SelectedIndex)
            .Add(FFormatDate(DateTimePicker4.Value))
            .Add(FFormatDate(DateTimePicker5.Value))
            .Add(Val(strUserID))
        End With
        ''''''''''
        With lstCtlTag
            .Add("[" & FGetTagData(DateTimePicker1, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(OptType1, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(OptType2, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(CmbBranchCode, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbPartionCode, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox2, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox3, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbActivitiesCode, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbPlaceCode, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox4, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox5, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox6, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbArtisticCode, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbPoliceMenCode, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbMabahsCode, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(DateTimePicker2, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(DateTimePicker3, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(ChkBox1, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(ChkBox2, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbPayState, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox8, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(dtePayInvoice, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(cmbPriceCalcType, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(DateTimePicker4, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(DateTimePicker5, Valadation.Tag) & "]")
            .Add("[UserID]")
        End With
        ''''''''''
        Dim frmNew As New frmMultiSave(strTable, lstCtlTag, lstCtlVal)
        frmNew.ShowDialog()
        Call SSaveGridMultiTran
    End Sub

    Private Sub SSaveGridMultiTran()
        For i As Integer = 0 To strDocNo.Count - 1
            Call SSaveGrid(strTable & "Devices", DataGridView1, "DocNo", strDocNo(i), "", True, False, False)
        Next

    End Sub



    Private Sub frmEnergyThefts_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        bolDealWithCombo = False
        ''Call SFillCombo(cmbActivitiesCode, "Tblc_ActivitiesCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        'Call SFillCombo(cmbPlaceCode, "Tblc_PlaceCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        'Call SFillCombo(cmbArtisticCode, "Tblc_ArtisticCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        'Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        'Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        'If strTable = "Tblt_EnergyThefts" Then
        '    Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        '    lblPoliceMenCode.Text = "مندوب الشرطة :"
        'ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
        '    Call SFillCombo(cmbPoliceMenCode, "Tblc_AccountMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        '    lblPoliceMenCode.Text = "م.الضبط القضائي :"
        'End If
        bolDealWithCombo = True
    End Sub

    Private Function FCheckPriviosRecord() As Boolean
        Dim strCondition As String = ""

        If strTable = "Tblt_EnergyThefts" Then
            strCondition = "HasrNo='" & TxtBox7.Text & "' And MabahsCode=" & cmbMabahsCode.SelectedValue & " And year(Date2)= " & Year(DateTimePicker2.Value)
        ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
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
        If strTable = "Tblt_EnergyThefts" Then
            'Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            Dim frmNew As New frmPoliceMenCode(loadType.ShowDialoge)
            frmNew.ShowDialog()
            If intComboItemNew > 0 Then
                Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
                lblPoliceMenCode.Text = "مندوب الشرطة ..."
                cmbPoliceMenCode.SelectedValue = intComboItemNew
            End If
        ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
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

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Select Case DirectCast(sender, DataGridView).Name
            Case DataGridView1.Name
                If e.KeyData.ToString = "Delete" Then
                    If MsgBox("هل أنت متأكد من حذف هذا السطر" & TxtBox1.Text & vbCrLf & "هل تريد البدء فر حركة جديدة؟", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Yes Then
                        DataGridView1.CurrentRow.Selected = True
                    End If
                End If
            Case DataGridView2.Name

        End Select
    End Sub

    Private Sub cmdCheckPriviosRecord_Click(sender As Object, e As EventArgs) Handles cmdCheckPriviosRecord.Click
        If FCheckPriviosRecord() = True Then
            MsgBox("رقم الحصر متوافر", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        Else
            MsgBox("يوجد رقم حصر سابق", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            If MsgBox("هل تريد فتح هذة الحركة", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
                TxtBox1.Text = strTmpTranNo
                Call SOpen()
            End If
        End If
    End Sub

End Class