Imports Main_New_Project
Imports System.Math
Imports System.IO
Imports System.ComponentModel

Public Class frmCasherOrder
    Dim strTable As String = "view_tran"
    Dim strOtherCondition As String
    Dim LstCtrl As New List(Of Control) : Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    Dim DicTranName As New Dictionary(Of Integer, String)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmCasherOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        '''''''''''''''''
        SDrawPayedOrderGrid(DataGridView1)
        Call SAddNew()
        Call SLoadControll()
        Call SLoadMyGrid()
        Call SLoadDictionary(DicTranName, "Tblu_TranName", "ID", "TranName")
    End Sub

    Public Sub SDrawPayedOrderGrid(ByVal strDataGrid As DataGridView)
        Dim ID As New DataGridViewTextBoxColumn
        With ID
            .HeaderText = "رقم الحركة" : .Width = 80 : .Visible = True : .Tag = "ID" : .Name = "ID" : .ReadOnly = True
        End With
        '''''''''''
        Dim DocType As New DataGridViewTextBoxColumn
        With DocType
            .HeaderText = "نوع الحركة" : .Visible = False : .Width = 50 : .Tag = "DocType" : .Name = "DocType" : .ReadOnly = True
        End With
        '''''''''''
        Dim DocTypeName As New DataGridViewTextBoxColumn
        With DocTypeName
            .HeaderText = "نوع الحركة" : .Width = 125 : .Name = "DocTypeName" : .ReadOnly = True ': .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '''''''''''
        Dim PayedName As New DataGridViewTextBoxColumn
        With PayedName
            .HeaderText = "الأسم" : .Width = 150 : .Tag = "PayedName" : .Name = "PayedName" : .ReadOnly = True
        End With
        '''''''''''
        Dim IDPersonNO As New DataGridViewTextBoxColumn
        With IDPersonNO
            .HeaderText = "رقم البطاقة" : .Width = 130 : .Tag = "IDPersonNO" : .Name = "IDPersonNO" : .ReadOnly = True
        End With
        '''''''''''
        Dim PayedState As New DataGridViewTextBoxColumn
        With PayedState
            .HeaderText = "ح.السداد" : .Width = 50 : .Tag = "PayedState" : .Name = "PayedState" : .ReadOnly = True : .Visible = False
        End With
        '''''''''''
        Dim PayedStateName As New DataGridViewTextBoxColumn
        With PayedStateName
            .HeaderText = "السداد" : .Width = 110 : .Name = "PayedStateName" : .ReadOnly = True
        End With
        '''''''''''
        Dim Value As New DataGridViewTextBoxColumn
        With Value
            .HeaderText = "مبلغ السداد" : .Visible = True : .Width = 90 : .Tag = "Value" : .Name = "Value" : .ReadOnly = True
        End With
        '''''''''''
        Dim PayedDate As New DataGridViewTextBoxColumn
        With PayedDate
            .HeaderText = "تاريخ السداد" : .Visible = True : .Width = 90 : .Tag = "PayedDate" : .Name = "PayedDate" : .ReadOnly = True
        End With
        '''''''''''
        Dim PayedTime As New DataGridViewTextBoxColumn
        With PayedTime
            .HeaderText = "وقت السداد" : .Visible = True : .Width = 90 : .Tag = "PayedTime" : .Name = "PayedTime" : .ReadOnly = True
        End With
        '''''''''''
        Dim PayMotbaqyVal As New DataGridViewTextBoxColumn
        With PayMotbaqyVal
            .HeaderText = "المتبقي" : .Visible = True : .Width = 90 : .Tag = "PayMotbaqyVal" : .Name = "PayMotbaqyVal" : .ReadOnly = True
        End With
        '''''''''''


        strDataGrid.Columns.Add(ID)
        strDataGrid.Columns.Add(DocType)
        strDataGrid.Columns.Add(DocTypeName)
        strDataGrid.Columns.Add(PayedName)
        strDataGrid.Columns.Add(IDPersonNO)
        strDataGrid.Columns.Add(PayedState)
        strDataGrid.Columns.Add(PayedStateName)
        strDataGrid.Columns.Add(Value)
        strDataGrid.Columns.Add(PayedDate)
        strDataGrid.Columns.Add(PayedTime)
        strDataGrid.Columns.Add(PayMotbaqyVal)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        'strDataGrid.RowHeadersVisible = False
        strDataGrid.RowHeadersWidth = 30
        strDataGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        strDataGrid.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        'strDataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub SLoadControll()
        LstCtrl.Clear()
        With LstCtrl
            .Add(TxtBox1)
            .Add(cmbTableName)
            .Add(TxtBox6)
            .Add(TxtBox7)
        End With
    End Sub

    Public Sub SAddNew()
        Call ClearControl(TabPage1)
        Call SFillCombo(cmbTableName, "Tblu_TranName", "ID", "TranName", "", False, "", ComboLoadItemSelect.Nothing)
        'cmbTableName.SelectedValue = 0
        cmdSearch.Enabled = False
        cmbTableName.Enabled = True
        GBPayed.Enabled = False
        Call SLoadMyGrid()
    End Sub

    Public Sub SLoadDictionary(ByRef DictionaryName As Dictionary(Of Integer, String), strTableName As String, strIDName As String, strName As String)
        Try
            strSQL = "SELECT * FROM " & strTableName & ""
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim TmpTmpdr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While TmpTmpdr.Read
                    DictionaryName.Add(TmpTmpdr(strIDName), TmpTmpdr(strName))
                Loop
                TmpTmpdr.Dispose()
            ElseIf DataType = DataConnection.Access Then
                'Dim Dp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                'Dim ds2 As New DataSet
                'Dp.Fill(ds2, strTableName)
                'ctrl.DisplayMember = "" & strTableName & "." & strFldName & ""
                'ctrl.ValueMember = "" & strTableName & "." & strFldCode & ""
                'ctrl.DataSource = ds2

                'Dp.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub SOpen()

        Dim strTmp() As String = {"Name", "Address", "Total", "PayMotbaqyVal"}
        '& " And cashType=0 And PayedType=0"

        Dim StrValueTmp As String() = FGetFeildValuesArry(strTable, strTmp, "ID=" & TxtBox1.Text & " And  DocType=" & cmbTableName.SelectedValue, False, "")
        TxtBox2.Text = StrValueTmp(0)
        TxtBox3.Text = StrValueTmp(1)
        TxtBox4.Text = StrValueTmp(2)
        TxtBox5.Text = StrValueTmp(3)
        '''''''''''''''''''''''''''
        'cmdAddToGrid.Enabled = True
    End Sub

    Public Sub SUpdate()
        Try
            If Val(TxtBox8.Text) > 0 Then
                If Val(TxtBox8.Text) <= Val(TxtBox5.Text) Then
                    'Dim strDocNoTmp As String = FGetFeildValues("Tblt_CasherPayed", "ID_Me", "ID=" & TxtBox1.Text & " And DocType=" & cmbTableName.SelectedValue)
                    'If strDocNoTmp <> "" Then FDeleteRecord("Tblt_CasherPayed", "ID_Me=" & Convert.ToInt64(strDocNoTmp))
                    Call SDelete()

                    Dim dRemoteDate As Date = (GetNetRemoteTOD(Mid(strServerName, 1, InStr(strServerName, "\") - 1)))

                    Dim lstFieldName, lstValue As New List(Of String)
                    lstFieldName.AddRange({"ID", "DocType", "cashType", "PayedType", "PayedDate", "PayedTime", "PayedName", "IDPersonNO", "PayedState", "Value", "PayMotbaqyVal", "InvoiceNo", "UserID"})
                    lstValue.AddRange({Val(TxtBox1.Text), cmbTableName.SelectedValue, "", "", FFormatDate2(dRemoteDate), FFormatTime(dRemoteDate), TxtBox6.Text, TxtBox7.Text, cmbPayState.SelectedIndex + 1, Val(TxtBox8.Text), Val(TxtBox5.Text) - Val(TxtBox8.Text), "0", strUserID})

                    Dim intDocNoTmp As Integer = FAddNewRecord2("Tblt_CasherPayed", lstFieldName, lstValue, "ID_Me")
                    MsgBox("تم الحفظ بنجاح", vbOKOnly + vbInformation, ProgName)
                    Call SAddNew()
                    Call SLoadMyGrid()
                Else
                    MsgBox("القيمة المسدده لا يمكن أن تكون" & vbCrLf & " أكبر من القيمة المتبقيه", vbOKOnly + vbCritical, ProgName)
                End If
            Else
                MsgBox("القيمة المسدده يجب أن تكون" & vbCrLf & " أكبر من الصفر", vbOKOnly + vbCritical, ProgName)
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Private Sub SLoadMyGrid()
        Try
            Me.Cursor = Cursors.WaitCursor
            Call SLoadGrid("Tblt_CasherPayed", DataGridView1, "cashType='' And PayedType=''", "ID_Me")
            ''''
            Dim dRemoteDate As Date = (GetNetRemoteTOD(Mid(strServerName, 1, InStr(strServerName, "\") - 1)))

            Dim strCondition As String = "cashType=0 And PayedType=0 And PayedDate='" & FFormatDate2(dRemoteDate) & "'"
            TxtTitleNotPayed.Text = FGetColumnValue("Tblt_CasherPayed", "ID_Me", Expresion.Count, strCondition)
            ''''
            strCondition = "cashType <> 0 And PayedType <> 0 And PayedDate='" & FFormatDate2(dRemoteDate) & "'"
            TxtTitlePayed.Text = FGetColumnValue("Tblt_CasherPayed", "ID_Me", Expresion.Count, strCondition)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
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
            Call SUpdate()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            Call SAddNew()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtBox_GotFocus(sender As Object, e As EventArgs) Handles TxtBox1.GotFocus, TxtBox2.GotFocus, TxtBox3.GotFocus, TxtBox4.GotFocus, TxtBox5.GotFocus, TxtBox6.GotFocus, TxtBox8.GotFocus
        Call FChangeLang()
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Call SAddNew()
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        'strDocNoSearch = ""

        Dim frmNew As New frmTranSearch(strTable, "بحث " & TabPage1.Text, True, strOtherCondition)
        frmNew.ShowDialog()
        If strDocNoSearch <> "" Then
            TxtBox1.Text = strDocNoSearch
            Call SOpen()
            GBPayed.Enabled = True
            TxtBox6.Focus()
            cmbTableName.Enabled = False
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Call SUpdate()
    End Sub

    Private Sub SDelete()
        Try
            Dim strDocNoTmp As String = FGetFeildValues("Tblt_CasherPayed", "ID_Me", "ID=" & TxtBox1.Text & " And DocType=" & cmbTableName.SelectedValue)
            If strDocNoTmp <> "" Then FDeleteRecord("Tblt_CasherPayed", "ID_Me=" & Convert.ToInt64(strDocNoTmp))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbTableName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTableName.SelectedIndexChanged
        If IsNothing(cmbTableName.SelectedIndex) Then
            cmdSearch.Enabled = False
        Else
            cmdSearch.Enabled = True
            '''''''
            Select Case cmbTableName.SelectedValue
                Case 1  ' محاضر السرقات
                    'strTable = "Tblt_EnergyThefts"
                    strOtherCondition = "DocType=1"
                Case 2  ' مخالفات السرقات
                    'strTable = "Tblt_Disagreed"
                    strOtherCondition = "DocType=2"
                Case 3  ' الزينه سرقات
                    'strTable = "Tblt_Zaina"
                    strOtherCondition = "DocType=3"
                Case 4  ' محاضر الضبطيه 
                    'strTable = "Tblt_EnergyTheftsSecond"
                    strOtherCondition = "DocType=4"
                Case 5  ' مخالفات الضبطيه
                    'strTable = "Tblt_DisagreedSecond"
                    strOtherCondition = "DocType=5"
                Case 6  ' الزينة الضبطيه
                    'strTable = "Tblt_ZainaSecond"
                    strOtherCondition = "DocType=6"
            End Select

            strOtherCondition = strOtherCondition & " And PayState<>1"
        End If
    End Sub

    Private Sub cmbPayState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPayState.SelectedIndexChanged
        Select Case cmbPayState.SelectedIndex
            Case 0
                TxtBox8.Text = Val(TxtBox5.Text)
                TxtBox8.Enabled = False
            Case 1
                TxtBox8.Text = "0"
                TxtBox8.Enabled = True
        End Select
    End Sub

    Private Sub TxtBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBox6.KeyPress, TxtBox8.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox7.Name, TxtBox8.Name
                e.KeyChar = FJustNumber(e)
            Case Else
        End Select
    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        TxtBox6.Text = ""
        TxtBox6.Text = TxtBox2.Text
        TxtBox7.Focus()
    End Sub

    Private Sub TxtBox7_Validating(sender As Object, e As CancelEventArgs) Handles TxtBox7.Validating
        If Len(TxtBox7.Text) <> 14 Then
            e.Cancel = True
            MsgBox("يجب أن يكون الرقم القومي 14 رقم", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            Select Case e.ColumnIndex
                Case 1
                    'If DataGridView1.Item(0, e.RowIndex).Value = 1 Then
                    '    DataGridView1.Item(1, e.RowIndex).Value = "السداد بالكامل"
                    'ElseIf DataGridView1.Item(0, e.RowIndex).Value = 2 Then
                    '    DataGridView1.Item(1, e.RowIndex).Value = "سداد جــــــزء"
                    'End If

                    'Dim t As String = DicTranName.Values(DataGridView1.Item(1, e.RowIndex).Value)
                    'DataGridView1.Item(1, e.RowIndex).Value = t
                    DataGridView1.Item(2, e.RowIndex).Value = FGetFeildValues("Tblu_TranName", "TranName", "ID=" & DataGridView1.Item(1, e.RowIndex).Value)

                Case 2

                Case 5
                    If DataGridView1.Item("PayedState", e.RowIndex).Value = 1 Then
                        DataGridView1.Item("PayedStateName", e.RowIndex).Value = "السداد بالكامل"
                    ElseIf DataGridView1.Item("PayedState", e.RowIndex).Value = 2 Then
                        DataGridView1.Item("PayedStateName", e.RowIndex).Value = "سداد جــــــزء"
                    End If
                Case 6

                Case 7 ' set datae time

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdLoadGrid_Click(sender As Object, e As EventArgs) Handles cmdLoadGrid.Click
        Call SLoadMyGrid()
    End Sub

    Private Sub cmdOldRecord_Click(sender As Object, e As EventArgs) Handles cmdOldRecord.Click
        Try
            Dim dRemoteDate As Date = (GetNetRemoteTOD(Mid(strServerName, 1, InStr(strServerName, "\") - 1)))

            Dim strCondition As String = "cashType=0 And PayedType=0 And PayedDate<>'" & FFormatDate2(dRemoteDate) & "'"
            Dim intRecDel As Integer = FDeleteRecord("Tblt_CasherPayed", strCondition)
            If intRecDel = 0 Then
                MsgBox("جميع الحركات المحفوظة بتاريخ اليوم ", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
            Else
                MsgBox("تم حذف عدد " & intRecDel & " أوامر سداد" & vbCrLf & "ليسوا بتاريخ اليوم", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
            End If

            Call SLoadMyGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try

            cmbTableName.SelectedValue = DataGridView1.Item("DocType", e.RowIndex).Value
            TxtBox1.Text = DataGridView1.Item("ID", e.RowIndex).Value
            TxtBox6.Text = DataGridView1.Item("PayedName", e.RowIndex).Value
            TxtBox7.Text = DataGridView1.Item("IDPersonNO", e.RowIndex).Value
            cmbPayState.SelectedIndex = DataGridView1.Item("PayedState", e.RowIndex).Value - 1
            TxtBox8.Text = DataGridView1.Item("Value", e.RowIndex).Value


            If cmbTableName.SelectedValue <> 0 And Val(TxtBox1.Text) > 0 Then
                Call SOpen()
                GBPayed.Enabled = True
                TxtBox6.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_GotFocus(sender As Object, e As EventArgs) Handles DataGridView1.GotFocus
        Call SLoadMyGrid()
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Try
            If MsgBox("هل تريد بالفعل حذف أمر السداد؟", vbYesNo + vbCritical + vbMsgBoxRtlReading, ProgName) = MsgBoxResult.Yes Then
                Call SDelete()
                Call SAddNew()
                Call SLoadMyGrid()
                MsgBox("تم الحذف بنجاح", vbOKOnly + vbInformation + vbMsgBoxRtlReading, ProgName)
            Else
                MsgBox("تم التراجع عن الحذف", vbOKOnly + vbInformation + vbMsgBoxRtlReading, ProgName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class