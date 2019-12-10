Public Class frmMultiSave

    Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    Dim strTable As String ' = "Tblt_EnergyThefts"
    Dim GridMainName As DataGridView
    Dim intHasrNoItemTmp As Integer

    Public Sub New(strTableName As String, lstTag As List(Of String), lstVal As List(Of String), GridName As DataGridView, intHasrNoItem As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        lstCtlTag = lstTag : lstCtlVal = lstVal
        strTable = strTableName
        '''''''''''''
        'lstCtlTag.Add("HasrNo") : lstCtlVal.Add("")
        ' Add any initialization after the InitializeComponent() call.
        GridMainName = GridName
        intHasrNoItemTmp = intHasrNoItem
    End Sub

    Private Sub frmMultiSave_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SDrawMultiTranGrid(DataGridView5)
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TxtBox2.TextChanged
        SDelGridData(DataGridView5)
        DataGridView5.Rows.Add(Val(TxtBox2.Text))
        Dim intTmp As Integer = Val(TxtBox1.Text)
        Dim k As Integer = 1

        For i As Integer = 0 To (Val(TxtBox2.Text) - 1)
            DataGridView5.Rows.Add()
            DataGridView5.Item(0, i).Value = k
            DataGridView5.Item(1, i).Value = intTmp
            If FCheckPriviosRecord(intTmp, strTable, lstCtlVal.Item(16), lstCtlVal.Item(4), Year(lstCtlVal.Item(17)), 0) = 0 Then
                DataGridView5.Item("HasrNoStates", i).Value = "رقم الحصر متاح"
            Else
                DataGridView5.Item("HasrNoStates", i).Value = "رقم الحصر غير متاح"
            End If
            intTmp += 1
            k += 1
        Next

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        'Me.Hide()
        Me.Close()
    End Sub

    Private Sub cmdAccept_Click(sender As Object, e As EventArgs) Handles cmdAccept.Click
        Try
            Dim strDocNo As String = ""
            intDocNoMain.Clear()
            For i As Integer = 0 To DataGridView5.RowCount - 2
                ''lstCtlVal.Item(13) = DataGridView5.Item(1, i).Value
                'lstCtlVal.Item(intHasrNoItemTmp) = DataGridView5.Item(1, i).Value
                ''lstCtlVal.Add(DataGridView1.Item(1, i).Value)
                'DataGridView5.Item(2, i).Value = FAddNewRecord2(strTable, lstCtlTag, lstCtlVal)
                'intDocNoMain.Add(DataGridView5.Item(2, i).Value)
                If DataGridView5.Item("HasrNoStates", i).Value = "رقم الحصر غير متاح" Then
                    strDocNo = DataGridView5.Item(1, i).Value & ","
                Else
                    lstCtlVal.Item(intHasrNoItemTmp) = DataGridView5.Item(1, i).Value
                    DataGridView5.Item(2, i).Value = FAddNewRecord2(strTable, lstCtlTag, lstCtlVal)
                    intDocNoMain.Add(DataGridView5.Item(2, i).Value)
                End If
            Next
            MsgBox("تم الحفظ بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SDrawMultiTranGrid(ByVal strDataGrid As DataGridView)
        Dim No As New DataGridViewTextBoxColumn
        With No
            .HeaderText = "  م  " : .Width = 40 : .Visible = True : .Name = "No"
        End With
        '''''''''''
        Dim HasrNo As New DataGridViewTextBoxColumn
        With HasrNo
            .HeaderText = "رقم الحصر" : .Width = 50 : .Visible = True : .Name = "HasrNo"
        End With
        '''''''''''
        Dim TranNo As New DataGridViewTextBoxColumn
        With TranNo
            .HeaderText = "رقم الحركة" : .Width = 50 : .Visible = True : .ReadOnly = True : .Name = "TranNo"
        End With
        '''''''''''
        Dim HasrNoStates As New DataGridViewTextBoxColumn
        With HasrNoStates
            .HeaderText = "رقم حصر مكرر" : .Width = 100 : .Visible = True : .ReadOnly = True : .Name = "HasrNoStates"
        End With
        '''''''''''
        strDataGrid.Columns.Add(No)
        strDataGrid.Columns.Add(HasrNo)
        strDataGrid.Columns.Add(TranNo)
        strDataGrid.Columns.Add(HasrNoStates)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = True
        strDataGrid.RowHeadersVisible = True
        strDataGrid.RowHeadersWidth = 30
    End Sub

End Class