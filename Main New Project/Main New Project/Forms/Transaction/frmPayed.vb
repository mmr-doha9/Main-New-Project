Imports Main_New_Project

Public Class frmPayed
    Implements IFormMainFunction

    Dim strTable As String
    Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)

    Public Sub New(strTableName As String, strFrmName As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        strTable = strTableName
        TabPage1.Text = strFrmName
    End Sub
    Private Sub frmPayed_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        DataGridView1.ReadOnly = True
        'Call SFillCombo(CmbBranchCodeSearch, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        'Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        If strTable = "Tblt_EnergyThefts" Then
            cmbMabahsCode.Enabled = True
            Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
            cmbMabahsCode.Enabled = False
        End If
        OptType1.Checked = True
        Call SLoadTypeCombox() ' Load partionCode and Branches
        CmbBranchCodeSearch.Text = "" : cmbMabahsCode.Text = ""
        '''''''''''''''''
        Call SDrawPayedGrid(DataGridView2)
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Try
            Dim strCondition As String = ""
            Dim lstFld As New List(Of String)
            With lstFld
                .Add("ID") : .Add("Date") : .Add("Name") : .Add("Address") : .Add("BranchCode") : .Add("HasrNo") : .Add("MabahsCode")
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
                    strCondition = strCondition & " And " & strTable & ".Name LIKE '%" & TxtBoxSearchName.Text & "%'"
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
            strCondition = strCondition & " And " & strTable & ".PayState<>1"
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
                '''''''''''''''''''
                Dim BranchName As New DataGridViewTextBoxColumn
                With BranchName
                    .HeaderText = "أسم الإدارة" : .Width = 110 : .Tag = "BranchName" : .Name = "BranchName" : .ReadOnly = True
                End With
                DataGridView1.Columns.Insert(5, BranchName)
                '''''''''''''''''''
                Dim MabahsName As New DataGridViewTextBoxColumn
                With MabahsName
                    .HeaderText = "أسم وحدة المباحث" : .Width = 110 : .Tag = "MabahsName" : .Name = "MabahsName" : .ReadOnly = True
                End With
                DataGridView1.Columns.Insert(8, MabahsName)
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
                    DataGridView1.Item(5, i).Value = FGetFeildValues("Tblc_MainBranchCode", "Name", "Code=" & "'" & DataGridView1.Item(4, i).Value & "'", False)
                    DataGridView1.Item(8, i).Value = FGetFeildValues("Tblc_MabahsCode", "Name", "ID=" & "'" & DataGridView1.Item(7, i).Value & "'", False)
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
        TxtBox1.Text = DataGridView1.Item(0, e.RowIndex).Value.ToString
        Call SOpen()
    End Sub

    Private Sub SOpen()
        '                              0          1       2        3         4            5               6                  7                   8        
        Dim strTmp() As String = {"BranchCode", "Name", "Date", "Address", "Total", "PayInvoiceVal", "PayInvoiceNo", "PayInvoiceDate", "PayInstallMentCount"}
        Dim StrValueTmp As String() = FGetFeildValuesArry(strTable, strTmp, "ID=" & TxtBox1.Text, False, "")
        CmbBranchCode.SelectedValue = StrValueTmp(0)
        TxtBox2.Text = StrValueTmp(1)
        DateTimePicker2.Text = StrValueTmp(2)
        TxtBox3.Text = StrValueTmp(3)
        TxtBox4.Text = StrValueTmp(4)
        TxtBox5.Text = StrValueTmp(5)
        TxtBox6.Text = StrValueTmp(6)
        If TxtBox5.Text <> "" Then DateTimePicker3.Value = StrValueTmp(7)
        TxtBox8.Text = StrValueTmp(8)
        '''''''''''''''''''''''''''
        Call SLoadGrid(strTable & "Payed", DataGridView2, "DocNo", TxtBox1.Text, False, "", "", False)
    End Sub

    Public Sub SAddNew() Implements IFormMainFunction.SAddNew
        TxtBoxSearchID.Text = "" : TxtBoxSearchName.Text = "" : CmbBranchCodeSearch.Text = "" : TxtBoxSearchAdd.Text = "" : DateTimePicker1.Value = Now.Date
        ''''''''''''''''''''''''''''
        TxtBoxSearchID.Text = ""
        TxtBoxSearchName.Text = ""
        TxtBoxSearchAdd.Text = ""
        TxtHasrNo.Text = ""
        CmbBranchCodeSearch.Text = "" : cmbMabahsCode.Text = ""
        ''''''''''''''''''''''''''''''
        DataGridView1.DataSource = "" : DataGridView1.DataMember = ""
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
            .Add(FFormatDate(DateTimePicker3.Value))
            .Add(TxtBox5.Text)
            .Add(TxtBox6.Text)
            .Add(TxtBox8.Text)
            '.Add("5")
            .Add(cmbPayState.SelectedIndex)
        End With
        '''''''''''''''''''''''''
        With lstCtlTag
            .Add("[" & FGetTagData(DateTimePicker3, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox5, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox6, Valadation.Tag) & "]")
            .Add("[" & FGetTagData(TxtBox8, Valadation.Tag) & "]")
            .Add("PayState")
        End With
        '''''''''''''''''''''''''
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

    Private Sub SLoadDataGridPayed()
        If TxtBox4.Text <> "" Then
            Dim dblQstVal As Double = 0
            Dim intQstCount As Integer = 0

            Call SDelGridData(DataGridView2)
            'TxtBox6.Text) قيمة القسط 
            TxtBox7.Text = TxtBox4.Text - TxtBox5.Text

            If Val(TxtBox8.Text) > 0 Then
                DataGridView2.RowCount = Val(TxtBox8.Text)
                dblQstVal = Math.Round((TxtBox7.Text / TxtBox8.Text), 2)
                intQstCount = Val(TxtBox8.Text)

                Dim dblMainVal As Double = Val(TxtBox7.Text)
                Dim dblNewMainVal As Double = Val(TxtBox7.Text)

                For i As Integer = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Item(1, i).Value = dblNewMainVal
                    DataGridView2.Item(2, i).Value = dblQstVal
                    DataGridView2.Item(3, i).Value = intQstCount
                    If i = (Val(TxtBox8.Text) - 1) Then
                        DataGridView2.Item(4, i).Value = 0
                    Else
                        DataGridView2.Item(4, i).Value = (DataGridView2.Item(1, i).Value) - (DataGridView2.Item(2, i).Value)
                        dblNewMainVal = Math.Round((dblNewMainVal - dblQstVal), 2)
                    End If
                    intQstCount -= 1
                Next
            End If
        End If
    End Sub

    Private Sub TxtBox_TextChanged(sender As Object, e As EventArgs) Handles TxtBox5.TextChanged, TxtBox8.TextChanged
        Call SLoadDataGridPayed()
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox1.KeyPress, TxtBox2.KeyPress, TxtBox3.KeyPress, TxtBox4.KeyPress, TxtBox8.KeyPress, TxtBox7.KeyPress, TxtBox6.KeyPress, TxtBoxSearchID.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBoxSearchID.Name, TxtBox1.Name, TxtBox4.Name, TxtBox8.Name, TxtBox6.Name, TxtBox7.Name, TxtBox6.Name
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If FValidation(Me, TabControl) = True Then
                If FCheckDemo(TabPage1.Tag, 5) = True Then
                    Call SFillCtl()
                    FEditeRecord(strTable, "ID", TxtBox1.Text, lstCtlTag, lstCtlVal)
                    Call SSaveGrid(strTable & "Payed", DataGridView2, "DocNo", Val(TxtBox1.Text), "", True, True, False)
                    If MsgBox("تم الحفظ بنجاح" & vbCrLf & "هل تريد البدء في حركة جديدة", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Yes Then
                        Call SAddNew()
                    Else

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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
        'If bolDealWithCombo = True Then

        If Not IsNothing(cmbPartionCode.SelectedValue) Then
                'CmbBranchCode.SelectedValue = FGetFeildValues("Tblc_MainBranchCode", "PartationCode", "ID=" & CmbBranchCode.SelectedValue, False, False)
                Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
                CmbBranchCode.Enabled = True
            End If
        'End If
    End Sub

End Class