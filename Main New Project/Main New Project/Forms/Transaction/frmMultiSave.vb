Public Class frmMultiSave

    Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    Dim strTable As String ' = "Tblt_EnergyThefts"

    Public Sub New(strTableName As String, lstTag As List(Of String), lstVal As List(Of String))
        ' This call is required by the designer.
        InitializeComponent()
        lstCtlTag = lstTag : lstCtlVal = lstVal
        strTable = strTableName
        '''''''''''''
        lstCtlTag.Add("HasrNo") : lstCtlVal.Add("")
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmMultiSave_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SDrawMultiTranGrid(DataGridView5)
        strDocNo.Clear()
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
            For i As Integer = 0 To DataGridView5.RowCount - 2
                lstCtlVal.Item(lstCtlVal.Count - 1) = DataGridView5.Item(1, i).Value
                'lstCtlVal.Add(DataGridView1.Item(1, i).Value)
                DataGridView5.Item(2, i).Value = FAddNewRecord2(strTable, lstCtlTag, lstCtlVal)
                strDocNo.Add(DataGridView5.Item(2, i).Value) ' set Id Into in list
            Next
            MsgBox("تم الحفظ بنجاح" & vbCrLf & "يرجي إدخال أحمال كل حركة", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMultiSave_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub

End Class