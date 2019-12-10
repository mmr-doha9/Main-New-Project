Imports Main_New_Project

Public Class frmTranSearch
    Implements IFormMainFunction

    Dim strTable As String
    Dim strFGTreeSearchUserID As String
    Dim bolUserID As Boolean
    Dim strOtherCondition As String

    Public Sub New(strTableName As String, strFrmName As String, bolUserIDCmb As Boolean, Optional strOtherConditionMain As String = "")
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'strDocNoSearch = "" ' افراغ المتغير
        strTable = strTableName
        bolUserID = bolUserIDCmb
        TabPage1.Text = strFrmName
        strOtherCondition = strOtherConditionMain
        strDocNoSearch = ""
    End Sub

    Private Sub frmTranSearch_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.MdiParent = Mdi
        DataGridView1.ReadOnly = True
        'Call SFillCombo(CmbBranchCodeSearch, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        'Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        If strTable = "Tblt_EnergyThefts" Then
            cmbMabahsCode.Enabled = True
            Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        ElseIf strTable = "Tblt_EnergyTheftsSecond" Then
            cmbMabahsCode.Enabled = False
        End If
        Call SFillCombo(cmbUserID, "Tblc_UserCode", "ID", "UserName", "", False, "", ComboLoadItemSelect.Min) : cmbUserID.SelectedValue = 0
        OptType1.Checked = True
        Call SLoadTypeCombox() ' Load partionCode and Branches
        cmbPartionCode.SelectedValue = 0 : CmbBranchCodeSearch.SelectedValue = 0 : cmbMabahsCode.SelectedValue = 0 : cmbUserID.SelectedValue = 0
        '''''''''''''''''permission
        GPUserCode.Enabled = bolUserID : If bolUserID = False Then cmbUserID.SelectedValue = strUserID
        '''''''''''''''''permission
        strDocNoSearch = ""

        'For i As Long = 2010 To 2040
        '    cmbYear.Items.Add(i)
        'Next
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
                        strCondition = strCondition & " And " & strTable & ".Date2 ='" & FFormatDate(DateTimePicker1.Text) & "'"
                    ElseIf DataType = DataConnection.Access Then
                        strCondition = strCondition & " And " & strTable & ".Date2 =#" & FFormatDate(DateTimePicker1.Text) & "#"
                    End If
                Else
                    If DataType = DataConnection.SqlServer Then
                        strCondition = " " & strTable & ".Date2 ='" & FFormatDate(DateTimePicker1.Text) & "'"
                    ElseIf DataType = DataConnection.Access Then
                        strCondition = " " & strTable & ".Date2 =#" & FFormatDate(DateTimePicker1.Text) & "#"
                    End If
                End If
            End If
            '''''''' Condition 4

            '''''''' Condition 5
            If CmbBranchCodeSearch.SelectedValue <> 0 Then
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
            If ChkUserID.Checked = False Then
                If cmbUserID.SelectedValue <> 0 Then
                    If strCondition <> "" Then
                        strCondition = strCondition & " And " & strTable & ".UserId=" & cmbUserID.SelectedValue
                    Else
                        strCondition = " " & strTable & ".UserId=" & cmbUserID.SelectedValue
                    End If
                ElseIf strFGTreeSearchUserID <> "" Then
                    If strCondition <> "" Then
                        strCondition = strCondition & " and " & strTable & ".UserId in (" & strFGTreeSearchUserID & ")"
                    Else
                        strCondition = " " & strTable & ".UserId in (" & strFGTreeSearchUserID & ")"
                    End If
                End If
            End If
            '''''''' Condition 8

            ''''' other Condition from another forms
            If strCondition <> "" Then
                If strOtherCondition <> "" Then strCondition = strCondition & " and " & strOtherCondition
            Else

            End If
            ''''' other Condition from another forms

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
        If e.RowIndex > -1 Then
            strDocNoSearch = DataGridView1.Item(0, e.RowIndex).Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub SOpen()
        '
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
        'lstCtlTag.Clear() : lstCtlVal.Clear()
        ''''''''''''''''''''''''''
        'With lstCtlVal
        '    .Add(FFormatDate(DateTimePicker3.Value))
        '    .Add(TxtBox5.Text)
        '    .Add(TxtBox6.Text)
        '    .Add(TxtBox8.Text)
        '    '.Add("5")
        '    .Add(cmbPayState.SelectedIndex)
        'End With
        ''''''''''''''''''''''''''
        'With lstCtlTag
        '    .Add("[" & FGetTagData(DateTimePicker3, Valadation.Tag) & "]")
        '    .Add("[" & FGetTagData(TxtBox5, Valadation.Tag) & "]")
        '    .Add("[" & FGetTagData(TxtBox6, Valadation.Tag) & "]")
        '    .Add("[" & FGetTagData(TxtBox8, Valadation.Tag) & "]")
        '    .Add("PayState")
        'End With
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

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBoxSearchID.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBoxSearchID.Name
                e.KeyChar = FJustNumber(e)
            Case Else

        End Select
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
            'CmbBranchCode.DataSource = Nothing
            'CmbBranchCode.DisplayMember = Nothing
            'CmbBranchCode.Items.Clear()
        End If
    End Sub
    Private Sub cmbPartionCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPartionCode.SelectedIndexChanged
        If Not IsNothing(cmbPartionCode.SelectedValue) Then
            Call SFillCombo(CmbBranchCodeSearch, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
            CmbBranchCodeSearch.Enabled = True
        End If
    End Sub

    Private Sub cmdUserID_Click(sender As Object, e As EventArgs) Handles cmdUserID.Click
        If lblUserID.Enabled = False Then
            lblUserID.Enabled = True : cmbUserID.Enabled = True
        Else
            lblUserID.Enabled = False : cmbUserID.Enabled = False
            strFGTreeSearchUserID = FTreeSearch(TreeBranches.SingleBranch, "Tblc_UserCode", "ID", , , "اكواد المستخدمين", False, False, "ID", "UserName", SearchReturnType.Number)
        End If
    End Sub

    Private Sub ChkUserID_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUserID.CheckedChanged
        If ChkUserID.Checked = True Then
            lblUserID.Enabled = False : cmbUserID.Enabled = False : cmdUserID.Enabled = False
        Else
            lblUserID.Enabled = True : cmbUserID.Enabled = True : cmdUserID.Enabled = True
        End If
    End Sub

End Class