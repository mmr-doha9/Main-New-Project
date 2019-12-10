Imports Main_New_Project

Public Class frmPayed
    Implements IFormMainFunction

    Dim strTable As String
    Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    ''
    Dim BolUserThefts, BolUserTheftsDisagreed, BolUserTheftsZaina, BolUserThefts2, BolUserThefts2Disagreed, BolUserTheftsZainaSecond As Boolean ' الصلاحيات

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        TabPage1.Text = "شاشة السداد"
    End Sub

    Private Sub cmbTableName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTableName.SelectedIndexChanged
        Try
            Select Case cmbTableName.SelectedItem
                Case "محاضر السرقات"
                    strTable = "Tblt_EnergyThefts"
                    GPSearchBox.Enabled = True
                Case "مخالفات السرقات"
                    strTable = "Tblt_Disagreed"
                    GPSearchBox.Enabled = True
                Case "الزينه سرقات"
                    strTable = "Tblt_Zaina"
                    GPSearchBox.Enabled = True
                Case "محاضر الضبطيه"
                    strTable = "Tblt_EnergyTheftsSecond"
                    GPSearchBox.Enabled = True
                Case "مخالفات الضبطيه"
                    strTable = "Tblt_DisagreedSecond"
                    GPSearchBox.Enabled = True
                Case "الزينة الضبطيه"
                    strTable = "Tblt_ZainaSecond"
                    GPSearchBox.Enabled = True
                Case Else
                    GPSearchBox.Enabled = False
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPayed_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        DataGridView1.ReadOnly = True
        Call SLoadPermission()
        Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        If strTable = "Tblt_EnergyThefts" Then
            cmbMabahsCode.Enabled = True
            Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
            cmbMabahsCode.Enabled = False
        End If
        OptType1.Checked = True
        Call SLoadTypeCombox() ' Load partionCode and Branches
        '''''''''''''''''
        Call SDrawPayedGrid(DataGridView2)
        cmbPartionCode.SelectedValue = 0 : CmbBranchCodeSearch.SelectedValue = 0 : cmbMabahsCode.SelectedValue = 0
        Call SAddNew()
        TxtBoxSearchID.Focus()
    End Sub

    Private Sub SLoadPermission()
        Dim frmTag As String = Me.Tag
        If strUserAdmin = "" Then
            If strUserType = 0 Then
                '                              0                  1                 2               3                 4                     5
                Dim strTmp() As String = {"chkThefts", "chkTheftsDisagreed", "chkTheftsZaina", "chkThefts2", "chkThefts2Disagreed", "chkTheftsZainaSecond"}
                Dim StrFrmPer As String() = FGetFeildValuesArry("Tblt_UserFormPerMain", strTmp, "UserCode='" & strUserID & "'", False, "")

                BolUserThefts = StrFrmPer(0)
                BoluserTheftsDisagreed = StrFrmPer(1)
                BoluserTheftsZaina = StrFrmPer(2)
                BolUserThefts2 = StrFrmPer(3)
                BolUserThefts2Disagreed = StrFrmPer(4)
                BolUserTheftsZainaSecond = StrFrmPer(5)
            Else
                BolUserThefts = True
                BolUserTheftsDisagreed = True
                BolUserTheftsZaina = True
                BolUserThefts2 = True
                BolUserThefts2Disagreed = True
                BolUserTheftsZainaSecond = True
            End If
        End If

        If BolUserThefts = True Then cmbTableName.Items.Add("محاضر السرقات")
        If BolUserTheftsDisagreed = True Then cmbTableName.Items.Add("مخالفات السرقات")
        If BolUserTheftsZaina = True Then cmbTableName.Items.Add("الزينه سرقات")
        If BolUserThefts2 = True Then cmbTableName.Items.Add("محاضر الضبطيه")
        If BolUserThefts2Disagreed = True Then cmbTableName.Items.Add("مخالفات الضبطيه")
        If BolUserTheftsZainaSecond = True Then cmbTableName.Items.Add("الزينة الضبطيه")

    End Sub

    Private Sub me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call cmdSearch_Click(sender, e)
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Try
            Dim strCondition As String = ""
            Dim lstFld As New List(Of String)

            If IsNothing(cmbTableName.SelectedIndex) = True Then MsgBox("يرجي أختيار احد شاشات البحث ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)

            With lstFld
                .Add("ID") : .Add("Date") : .Add("Name") : .Add("Address") : .Add("BranchCode") : .Add("HasrNo") : .Add("MabahsCode") : .Add("PoliceMenCode") : .Add("UserId")
            End With
            ''''''''
            DataGridView1.DataMember = Nothing : DataGridView1.DataSource = Nothing : DataGridView1.Columns.Clear()
            ''''''''
            '''''''' Condition 1  ' ID
            If TxtBoxSearchID.Text <> "" Then
                strCondition = " " & strTable & ".ID=" & TxtBoxSearchID.Text
            End If
            '''''''' Condition 1

            '''''''' Condition 2   ' Name
            If TxtBoxSearchName.Text <> "" Then
                If strCondition <> "" Then
                    strCondition = strCondition & " And " & strTable & ".Name Like '%" & TxtBoxSearchName.Text & "%'"
            Else
                    strCondition = " " & strTable & ".Name LIKE '%" & TxtBoxSearchName.Text & "%'"
                End If
            End If
            '''''''' Condition 2

            '''''''' Condition 3   ' Address
            If TxtBoxSearchAdd.Text <> "" Then
                If strCondition <> "" Then
                    strCondition = strCondition & " And " & strTable & ".Address LIKE '%" & TxtBoxSearchAdd.Text & "%'"
                Else
                    strCondition = " " & strTable & ".Address LIKE '%" & TxtBoxSearchAdd.Text & "%'"
                End If
            End If
            '''''''' Condition 3

            '''''''' Condition 4  ' Date
            If DateTimePicker1.Enabled = True Then
                If strCondition <> "" Then
                    If DataType = DataConnection.SqlServer Then
                        strCondition = strCondition & " And " & strTable & ".Date ='" & FFormatDate(DateTimePicker1.Text) & "'"
                    ElseIf DataType = DataConnection.Access Then
                        strCondition = strCondition & " And " & strTable & ".Date =#" & FFormatDate(DateTimePicker1.Text) & "#"
                    End If
                Else
                    If DataType = DataConnection.SqlServer Then
                        strCondition = " " & strTable & ".Date ='" & FFormatDate(DateTimePicker1.Text) & "'"
                    ElseIf DataType = DataConnection.Access Then
                        strCondition = " " & strTable & ".Date =#" & FFormatDate(DateTimePicker1.Text) & "#"
                    End If
                End If
            End If
            '''''''' Condition 4

            '''''''' Condition 5
            If CmbBranchCodeSearch.Text <> Nothing Then
                If strCondition <> "" Then
                    strCondition = strCondition & " And " & strTable & ".BranchCode=" & CmbBranchCodeSearch.SelectedValue
                Else
                    strCondition = " " & strTable & ".BranchCode=" & CmbBranchCodeSearch.SelectedValue
                End If
            End If
            '''''''' Condition 5

            '''''''' Condition 6
            If TxtHasrNo.Text <> "" Then
                If strCondition <> "" Then
                    strCondition = strCondition & " And " & strTable & ".HasrNo=" & TxtHasrNo.Text
                Else
                    strCondition = " " & strTable & ".HasrNo=" & TxtHasrNo.Text
                End If
            End If
            '''''''' Condition 6

            '''''''' Condition 7
            If cmbMabahsCode.Text <> "" Then
                If strCondition <> "" Then
                    strCondition = strCondition & " And " & strTable & ".MabahsCode=" & cmbMabahsCode.SelectedValue
                Else
                    strCondition = " " & strTable & ".MabahsCode=" & cmbMabahsCode.SelectedValue
                End If
            End If
            '''''''' Condition 7

            '''''''' Condition 8
            If strCondition = "" Then
                MsgBox("يرجي أختيار أحد بنود البحث", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                Exit Sub
            Else
                strCondition = strCondition & " And " & strTable & ".PayState<>1"
            End If

            '''''''' Condition 8

            ''''''' Load field
            Dim strTmp As String = ""
            For i As Integer = 0 To lstFld.Count - 1
                If strTmp = "" Then
                    strTmp = lstFld(i).ToString
                Else
                    strTmp = strTmp & "," & lstFld(i).ToString
                End If
            Next
            ''''''' Load field
            strSQL = ""
            If strCondition <> "" Then
                strSQL = ("SELECT " & strTmp & " from " & strTable & "  WHERE" & strCondition)
            Else
                'strSQL = ("SELECT " & strTmp & " from " & strTable )
            End If
            If strSQL <> "" Then
                If DataType = DataConnection.SqlServer Then
                    Dim Adpt As New SqlClient.SqlDataAdapter(strSQL, CON)
                    Dim ds As New DataSet()
                    Adpt.Fill(ds, strTable)
                    DataGridView1.DataSource = ds.Tables(0)
                ElseIf DataType = DataConnection.Access Then
                    Dim Adpt As New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                    Dim ds As New DataSet()
                    Adpt.Fill(ds, strTable)
                    DataGridView1.DataSource = ds.Tables(0)
                End If
                DataGridView1.Columns(0).HeaderText = "رقم الحركة" : DataGridView1.Columns(0).Width = 50
                DataGridView1.Columns(1).HeaderText = "التاريخ" : DataGridView1.Columns(1).Width = 85
                DataGridView1.Columns(2).HeaderText = "الاسم"
                DataGridView1.Columns(3).HeaderText = "العنوان"
                DataGridView1.Columns(4).HeaderText = "رقم الإدارة" : DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).HeaderText = "رقم الحصر" : DataGridView1.Columns(5).Width = 75
                DataGridView1.Columns(6).HeaderText = "رقم وحدة المباحث" : DataGridView1.Columns(6).Visible = False
                DataGridView1.Columns(7).HeaderText = "مندوب الضبط" : DataGridView1.Columns(7).Visible = False
                DataGridView1.Columns(8).HeaderText = "اسم المستخدم" : DataGridView1.Columns(8).Visible = False

                '''''''''''''''''''
                Dim BranchName As New DataGridViewTextBoxColumn
                With BranchName
                    .HeaderText = "أسم الإدارة" : .Width = 110 : .Tag = "BranchName" : .Name = "BranchName" : .ReadOnly = True
                End With
                DataGridView1.Columns.Insert(9, BranchName)
                '''''''''''''''''''
                Dim MabahsName As New DataGridViewTextBoxColumn
                With MabahsName
                    .HeaderText = "أسم وحدة المباحث" : .Width = 110 : .Tag = "MabahsName" : .Name = "MabahsName" : .ReadOnly = True
                End With
                DataGridView1.Columns.Insert(10, MabahsName)
                '''''''''''''''''''
                Dim PoliceMenName As New DataGridViewTextBoxColumn
                With PoliceMenName
                    .HeaderText = "مندوب الضبط" : .Width = 110 : .Tag = "PoliceMenName" : .Name = "PoliceMenName" ': .ReadOnly = True
                End With
                DataGridView1.Columns.Insert(11, PoliceMenName)
                '''''''''''''''''''
                Dim UserName As New DataGridViewTextBoxColumn
                With UserName
                    .HeaderText = "أسم المستخدم" : .Width = 110 : .Tag = "UserName" : .Name = "UserName" ' : .ReadOnly = True
                End With
                DataGridView1.Columns.Insert(12, UserName)
                '''''''''''''''''''

                DataGridView1.AllowUserToAddRows = False
                DataGridView1.AllowUserToDeleteRows = False
                DataGridView1.RowHeadersWidth = 50
                DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
                DataGridView1.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
                ''''''
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    Dim k As Integer = i + 1
                    DataGridView1.Rows(i).HeaderCell.Value = k.ToString
                    DataGridView1.Item("BranchName", i).Value = FGetFeildValues("Tblc_MainBranchCode", "Name", "Code=" & "" & DataGridView1.Item(4, i).Value & "", False)
                    DataGridView1.Item("MabahsName", i).Value = FGetFeildValues("Tblc_MabahsCode", "Name", "ID=" & "'" & DataGridView1.Item(6, i).Value & "'", False)
                    DataGridView1.Item("PoliceMenName", i).Value = FGetFeildValues("Tblc_PoliceMenCode", "Name", "ID=" & "'" & DataGridView1.Item(7, i).Value & "'", False)
                    DataGridView1.Item("UserName", i).Value = FGetFeildValues("Tblc_UserCode", "UserName", "ID=" & "'" & DataGridView1.Item(8, i).Value & "'", False)
                Next
            Else
                MsgBox("يرجي أختيار أحد بنود البحث", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DateTimePicker_DoubleClick(sender As Object, e As EventArgs) Handles Label7.DoubleClick
        If DateTimePicker1.Enabled = True Then
            DateTimePicker1.Enabled = False
        Else
            DateTimePicker1.Enabled = True
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            TxtBoxData1.Text = DataGridView1.Item(0, e.RowIndex).Value.ToString
            Call SOpen()
            Call ClearControl(GroupBox2)
        End If
    End Sub

    Private Sub SOpen()

        Dim strTmp() As String

        Select Case strTable
            Case "Tblt_EnergyThefts", "Tblt_EnergyTheftsSecond"   ' محاضر السرقات
                '              0          1       2        3              4                5      6         7         8               
                strTmp = {"BranchCode", "Name", "Date", "Address", "PayMotbaqyVal", "PayState", "Date2", "HasrNo", "Total"}
            Case Else
                '              0          1       2        3              4                5      6         7         8               
                strTmp = {"BranchCode", "Name", "Date", "Address", "PayMotbaqyVal", "PayState", "Date2", "HasrNo", "AsthlakVal"}
        End Select
        
        Dim StrValueTmp As String() = FGetFeildValuesArry(strTable, strTmp, "ID=" & TxtBoxData1.Text, False, "")
        CmbBranchCode.SelectedValue = StrValueTmp(0)
        TxtBoxData2.Text = StrValueTmp(1)
        dtePayed.Text = StrValueTmp(2)
        TxtBoxData3.Text = StrValueTmp(3)
        TxtBoxData4.Text = StrValueTmp(8)
        TxtBoxData6.Text = StrValueTmp(4)
        DateTimePicker2.Value = StrValueTmp(6)
        TxtBoxData5.Text = StrValueTmp(7)
        '''''''''''''''''''''''''''
        Call SLoadGrid(strTable & "Payed", DataGridView2, "DocNo", TxtBoxData1.Text, False, "", "", False)
        cmdAddToGrid.Enabled = True
    End Sub

    Public Sub SAddNew() Implements IFormMainFunction.SAddNew
        'TxtBoxSearchID.Text = "" : TxtBoxSearchName.Text = "" : CmbBranchCodeSearch.Text = "" : TxtBoxSearchAdd.Text = "" : DateTimePicker1.Value = Now.Date
        '''''''''''''''''''''''''''''
        'TxtBoxSearchID.Text = ""
        'TxtBoxSearchName.Text = ""
        'TxtBoxSearchAdd.Text = ""
        'TxtHasrNo.Text = ""
        'CmbBranchCodeSearch.Text = "" : cmbMabahsCode.Text = ""
        '''''''''''''''''''''''''''''''
        '
        Call ClearControl(TabPage1)
        Call ClearControl(GPSearchBox)
        DataGridView1.DataSource = "" : DataGridView1.DataMember = ""
        cmdPay.Enabled = False
        '''''''
        Select Case strTable
            Case "Tblt_EnergyThefts"  ' محاضر السرقات
                cmbTableName.SelectedIndex = "0"
            Case "Tblt_Disagreed"  ' مخالفات السرقات
                cmbTableName.SelectedIndex = "1"
            Case "Tblt_Zaina"  ' الزينه سرقات
                cmbTableName.SelectedIndex = "2"
            Case "Tblt_EnergyTheftsSecond"  ' محاضر الضبطيه 
                cmbTableName.SelectedIndex = "3"
            Case "Tblt_DisagreedSecond"  ' مخالفات الضبطيه
                cmbTableName.SelectedIndex = "4"
            Case "Tblt_ZainaSecond"  ' الزينة الضبطيه
                cmbTableName.SelectedIndex = "5"
        End Select
        '''''''
        Call cmbTableName_SelectedIndexChanged(sender:=Nothing, e:=Nothing)
    End Sub

    Private Sub IFormMainFunction_SOpen() Implements IFormMainFunction.SOpen
        ''
    End Sub
    Public Sub SUpdate() Implements IFormMainFunction.SUpdate
        ''
    End Sub

    Private Sub SFillCtl()
        lstCtlTag.Clear() : lstCtlVal.Clear()
        '''''''''''''''''''''''''
        With lstCtlVal
            If Val(TxtBox3.Text) > 0 Then
                .Add(cmbPayState.SelectedIndex + 1)
            Else
                .Add(1) ' لو قيمة المتبقي صفر يتم حفظ تم السداد بالكامل حتي لو لو يتم أختيار السداد بالكامل
            End If
            .Add(Val(TxtBox3.Text))
        End With
        '''''''''''''''''''''''''
        With lstCtlTag
            .Add("[PayState]")
            .Add("[PayMotbaqyVal]")
        End With
        ''''''''''''''''''''''''''
    End Sub

    Public Sub SDelete() Implements IFormMainFunction.SDelete
        ''
    End Sub

    Public Sub SMoveFirst() Implements IFormMainFunction.SMoveFirst
        ''
    End Sub

    Public Sub SMovePrevious() Implements IFormMainFunction.SMovePrevious
        ''
    End Sub

    Public Sub SMoveNext() Implements IFormMainFunction.SMoveNext
        ''
    End Sub

    Public Sub SMoveLast() Implements IFormMainFunction.SMoveLast
        ''
    End Sub

    Public Sub SPrintReport() Implements IFormMainFunction.SPrintReport
        ''
    End Sub

    Public Sub SShowPrint() Implements IFormMainFunction.SShowPrint
        ''
    End Sub

    Private Sub SLoadDataGridPayed() ' للتقسيط في الجريدة يتم الايقاف

        'If TxtBox4.Text <> "" Then
        '    Dim dblQstVal As Double = 0
        '    Dim intQstCount As Integer = 0

        '    Call SDelGridData(DataGridView2)
        '    'TxtBox6.Text) قيمة القسط 
        '    TxtBox7.Text = Val(TxtBox4.Text) - Val(TxtBox5.Text)

        '    If Val(TxtBox8.Text) > 0 Then
        '        DataGridView2.RowCount = Val(TxtBox8.Text)
        '        dblQstVal = Math.Round((TxtBox7.Text / TxtBox8.Text), 2)
        '        intQstCount = Val(TxtBox8.Text)

        '        Dim dblMainVal As Double = Val(TxtBox7.Text)
        '        Dim dblNewMainVal As Double = Val(TxtBox7.Text)

        '        For i As Integer = 0 To DataGridView2.RowCount - 1
        '            DataGridView2.Item(1, i).Value = dblNewMainVal
        '            DataGridView2.Item(2, i).Value = dblQstVal
        '            DataGridView2.Item(3, i).Value = intQstCount
        '            If i = (Val(TxtBox8.Text) - 1) Then
        '                DataGridView2.Item(4, i).Value = 0
        '            Else
        '                DataGridView2.Item(4, i).Value = (DataGridView2.Item(1, i).Value) - (DataGridView2.Item(2, i).Value)
        '                dblNewMainVal = Math.Round((dblNewMainVal - dblQstVal), 2)
        '            End If
        '            DataGridView2.Item(6, i).Value = 0
        '            DataGridView2.Item(7, i).Value = "" ' Null

        '            intQstCount -= 1
        '        Next
        '    End If
        'End If
    End Sub

    'Private Sub TxtBox_TextChanged(sender As Object, e As EventArgs) Handles TxtBox5.TextChanged, TxtBox8.TextChanged
    '    Call SLoadDataGridPayed()
    'End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBoxData1.KeyPress, TxtBoxData2.KeyPress, TxtBoxData3.KeyPress, TxtBoxData4.KeyPress, TxtBox3.KeyPress, TxtBox2.KeyPress, TxtBoxSearchID.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBoxSearchID.Name, TxtBoxData1.Name, TxtBoxData4.Name, TxtBox2.Name, TxtBox3.Name, TxtBox2.Name
                e.KeyChar = FJustNumber(e)
                If e.KeyChar = Chr(13) Then
                    SendKeys.Send("{TAB}")
                End If
            Case Else
                If e.KeyChar = Chr(13) Then
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

    Private Sub cmdPay_Click(sender As Object, e As EventArgs) Handles cmdPay.Click
        Try
            If FCheckDemo(TabPage1.Tag, 5) = True Then
                Call SFillCtl()
                If (FSaveGrid(strTable & "Payed", DataGridView2, "DocNo", Val(TxtBoxData1.Text), "", True, True, False)) = True Then
                    If (FEditeRecord(strTable, "ID", TxtBoxData1.Text, lstCtlTag, lstCtlVal)) = True Then
                        Call FSetTransaction(TransactionType.Payed, cmbTableName.SelectedItem, TxtBoxData1.Text) ' transactions save
                        MsgBox("تم الحفظ بنجاح", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                        Call SAddNew()
                    Else
                        MsgBox("حدثت مشكلة أثناء حفظ جريدة البيانات" & vbCrLf & "يرجي الأتصال بالدعم الفنى", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                    End If
                Else
                    MsgBox("حدثت مشكلة أثناء حفظ الحركة" & vbCrLf & "لن يتم أستكمال باقي خطوات الحفظ" & vbCrLf & "يرجي الأتصال بالدعم الفنى", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Function FCheckGridTemp(ByVal grdCtl As DataGridView, ByVal strGrdMessage As String) As Boolean
    '    If grdCtl.RowCount = 1 Then
    '        MsgBox("من فضلك اكمل ادخال البيانات داخل الجريدة" & vbCrLf & " لم يتم ادخال البيانات بـ" & strGrdMessage, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
    '        Return False
    '    Else
    '        For i As Integer = 0 To grdCtl.Rows.Count - 2
    '            For x As Integer = 0 To grdCtl.Columns.Count - 1
    '                If grdCtl.Columns(x).Visible = True Then
    '                    If grdCtl.Columns(x).CellType.Name = "DataGridViewTextBoxCell" Then
    '                        Dim strTmp As String = grdCtl.Item(x, i).Value
    '                        If strTmp = "" Then
    '                            MsgBox("من فضلك اكمل ادخال البيانات داخل الجريدة" & vbCrLf & " يجب اكمال ادخال البيانات في " & strGrdMessage & vbCrLf & "في السطر رقم " & (i + 1) & "وفي عمود " & grdCtl.Columns(x).HeaderText, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
    '                        End If
    '                    ElseIf grdCtl.Columns(x).CellType.Name = "DataGridViewCheckBoxCell" Then

    '                    End If
    '                End If
    '            Next
    '        Next
    '        Return True
    '    End If
    'End Function

    Private Sub OptType1_CheckedChanged(sender As Object, e As EventArgs) Handles OptType1.CheckedChanged
        Call SLoadTypeCombox()
    End Sub

    Private Sub SLoadTypeCombox()
        Dim intType As Integer = IIf(OptType1.Checked = True, 1, 0)
        Call SFillCombo(cmbPartionCode, "Tblc_PartionCode", "ID", "Name", "Type=" & intType, False, "", ComboLoadItemSelect.Min)
        If cmbPartionCode.Items.Count > 0 Then
            Call SFillCombo(CmbBranchCodeSearch, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
        Else
            CmbBranchCode.DataSource = Nothing
            CmbBranchCode.DisplayMember = Nothing
            CmbBranchCode.Items.Clear()
        End If
    End Sub
    Private Sub cmbPartionCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPartionCode.SelectedIndexChanged
        If Not IsNothing(cmbPartionCode.SelectedValue) Then
            Call SFillCombo(CmbBranchCodeSearch, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
            CmbBranchCodeSearch.Enabled = True
        End If
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Call SAddNew()
    End Sub

    Private Sub mnuGridEdit_Click(sender As Object, e As EventArgs) Handles mnuGridEdit.Click
        Try
            If MsgBox("هل تريد فعلا حذف حركة السداد ؟ ", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Yes Then
                If MsgBox("تحذير أخير لن يمكنك التراجع" & vbCrLf & "هل تريد تأكيد حذف حركة السداد ؟ ", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Yes Then
                    Call FDeletePay(DataGridView2, DataGridView2.CurrentRow.Index)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function FDeletePay(dataGridView As DataGridView, intRowNo As Integer) As Boolean
        Try
            Dim dblPayedVal As Double = 0
            lstCtlTag.Clear() : lstCtlVal.Clear()

            dblPayedVal = DataGridView2.Item("PayedVal", intRowNo).Value 'قيمة السداد المحذزف
            dblPayedVal = Val(TxtBoxData6.Text) + dblPayedVal
            dataGridView.Rows.RemoveAt(intRowNo)

            '''''''''''''''''''''''''
            If Val(TxtBoxData4.Text) = dblPayedVal Then
                lstCtlVal.Add(0) ' ينتظر
                lstCtlVal.Add(Val(TxtBoxData4.Text))
            ElseIf Val(TxtBoxData4.Text) > dblPayedVal Then
                lstCtlVal.Add(2) ' تم سداد جزء
                lstCtlVal.Add(dblPayedVal)
            End If
            '''''''''''''''''''''''''
            With lstCtlTag
                .Add("[PayState]")
                .Add("[PayMotbaqyVal]")
            End With
            ''''''''''''''''''''''''''
            If (FSaveGrid(strTable & "Payed", DataGridView2, "DocNo", Val(TxtBoxData1.Text), "", True, True, False)) = True Then
                If (FEditeRecord(strTable, "ID", TxtBoxData1.Text, lstCtlTag, lstCtlVal)) = True Then
                    Call FSetTransaction(TransactionType.Delete, "سداد " & cmbTableName.SelectedItem, TxtBoxData1.Text) ' transactions save
                    MsgBox("تم الحفظ بنجاح", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                    Call SAddNew()
                Else
                    MsgBox("حدثت مشكلة أثناء حفظ جريدة البيانات" & vbCrLf & "يرجي الأتصال بالدعم الفنى", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                    Return False
                End If
            Else
                MsgBox("حدثت مشكلة أثناء حفظ الحركة" & vbCrLf & "لن يتم أستكمال باقي خطوات الحفظ" & vbCrLf & "يرجي الأتصال بالدعم الفنى", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub SFillCtlTmp()
        lstCtlTag.Clear() : lstCtlVal.Clear()
        '''''''''''''''''''''''''
        With lstCtlVal
            If Val(TxtBox3.Text) > 0 Then
                .Add(cmbPayState.SelectedIndex + 1)
            Else
                .Add(1) ' لو قيمة المتبقي صفر يتم حفظ تم السداد بالكامل حتي لو لو يتم أختيار السداد بالكامل
            End If
            .Add(Val(TxtBox3.Text))
        End With
        '''''''''''''''''''''''''
        With lstCtlTag
            .Add("[PayState]")
            .Add("[PayMotbaqyVal]")
        End With
        ''''''''''''''''''''''''''
    End Sub

    Private Sub cmbPayState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPayState.SelectedIndexChanged
        Select Case cmbPayState.SelectedIndex
            Case 0
                TxtBox1.Text = Val(TxtBoxData6.Text)
                TxtBox1.Enabled = False
            Case 1
                TxtBox1.Text = "0"
                TxtBox1.Enabled = True
        End Select
    End Sub

    Private Sub TxtBox7_TextChanged(sender As Object, e As EventArgs) Handles TxtBox3.TextChanged
        'If Val(TxtBox7.Text) = 0 Then
        '    TxtBox8.Enabled = False
        'Else
        '    TxtBox8.Enabled = True
        'End If
    End Sub

    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        Select Case e.ColumnIndex
            Case 1

            Case 2
                If DataGridView2.RowCount = 0 Then

                End If

                If DataGridView2.Item(0, e.RowIndex).Value = 1 Then
                    DataGridView2.Item(1, e.RowIndex).Value = "السداد بالكامل"
                ElseIf DataGridView2.Item(0, e.RowIndex).Value = 2 Then
                    DataGridView2.Item(1, e.RowIndex).Value = "سداد جــــــزء"
                End If
            Case 5
                If DataGridView2.Item("PayedType", e.RowIndex).Value = 0 Then
                    DataGridView2.Item("PayedTypeName", e.RowIndex).Value = "السداد يدوياً"
                ElseIf DataGridView2.Item("PayedType", e.RowIndex).Value = 1 Then
                    DataGridView2.Item("PayedTypeName", e.RowIndex).Value = "سداد آلـــي"
                End If
            Case 6

            Case 7 ' set datae time

        End Select
    End Sub

    Private Sub cmdAddToGrid_Click(sender As Object, e As EventArgs) Handles cmdAddToGrid.Click
        Try
            If cmbPayState.SelectedIndex = -1 Then MsgBox("يرجي إختيار حالة السداد", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) : Exit Sub
            If Val(TxtBox1.Text) <= 0 Then MsgBox("يرجي إدخال مبلغ السداد", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) : Exit Sub
            If Val(TxtBox2.Text) <= 0 Then MsgBox("يرجي إدخال رقم إيصال السداد", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) : Exit Sub

            DataGridView2.Rows.Add()
            DataGridView2.Item(0, DataGridView2.RowCount - 1).Value = (cmbPayState.SelectedIndex + 1)
            DataGridView2.Item(1, DataGridView2.RowCount - 1).Value = (cmbPayState.Text)
            DataGridView2.Item(2, DataGridView2.RowCount - 1).Value = Val(TxtBox1.Text) : TxtBox1.Text = ""
            DataGridView2.Item(3, DataGridView2.RowCount - 1).Value = Val(TxtBox2.Text) : TxtBox2.Text = ""
            DataGridView2.Item(4, DataGridView2.RowCount - 1).Value = FFormatDate(dtePayed.Value)
            DataGridView2.Item("PayedType", DataGridView2.RowCount - 1).Value = "0"
            Call SCalcGrid2Total()
            cmdAddToGrid.Enabled = False
            cmdPay.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SCalcGrid2Total()
        Try
            Dim dblTotal As Double = 0

            For i As Integer = 0 To DataGridView2.Rows.Count - 1
                dblTotal += DataGridView2.Item(2, i).Value
            Next
            TxtBox3.Text = Val(TxtBoxData4.Text) - dblTotal
            If (DataGridView2.RowCount - 1) > 0 And Val(TxtBox3.Text) = 0 Then
                GroupBox2.Enabled = False
            Else
                GroupBox2.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class