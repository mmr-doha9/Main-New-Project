Public Class frmPayedTmp

    Private Sub frmPayedTmp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        '''''''''''''''''
        Call SAddNew()
        cmdSave.Enabled = False
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Dim strCondition, strSQL As String

        DataGridView1.DataMember = Nothing : DataGridView1.DataSource = Nothing : DataGridView1.Columns.Clear()

        ' Condition 1
        If TxtBoxID.Text <> "" Then strCondition = " IDPersonNO=" & TxtBoxID.Text
        ' Condition 1

        ' Condition 2
        If TxtBoxID_Main.Text <> "" Then
            If strCondition = "" Then
                strCondition = " ID_Me=" & TxtBoxID_Main.Text
            Else
                strCondition = strCondition & " And ID_Me=" & TxtBoxID_Main.Text
            End If
        End If
        ' Condition 2

        If strCondition <> "" Then
            strCondition = strCondition & " And cashType=0 And PayedType=0"
        End If

        If strCondition <> "" Then strSQL = ("SELECT ID_Me,DocType,PayedName,Value,PayMotbaqyVal,ID from Tblt_CasherPayed  WHERE" & strCondition)

        If strSQL <> "" Then
            If DataType = DataConnection.SqlServer Then
                Dim Adpt As New SqlClient.SqlDataAdapter(strSQL, CON)
                Dim ds As New DataSet()
                Adpt.Fill(ds, "Tblt_CasherPayed")
                DataGridView1.DataSource = ds.Tables(0)
            ElseIf DataType = DataConnection.Access Then
                Dim Adpt As New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                Dim ds As New DataSet()
                Adpt.Fill(ds, "Tblt_CasherPayed")
                DataGridView1.DataSource = ds.Tables(0)
            End If
        End If

        DataGridView1.Columns(0).HeaderText = "رقم الحركة" : DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).HeaderText = "نوع الحركة" : DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).HeaderText = "الاسم" : DataGridView1.Columns(2).Width = 170
        DataGridView1.Columns(3).HeaderText = "القيمه" : DataGridView1.Columns(3).Width = 80
        DataGridView1.Columns(4).HeaderText = "المتبقي" : DataGridView1.Columns(4).Width = 75
        DataGridView1.Columns(5).HeaderText = "رقم المحضر" : DataGridView1.Columns(5).Width = 75
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToAddRows = False
        '''''''''''''''''''
        'If DataGridView1.RowCount > 0 Then
        '    GroupBox2.Enabled = True
        'Else
        '    GroupBox2.Enabled = False
        'End If
    End Sub

    Public Sub SAddNew()
        Call ClearControl(TabPage1)
        DataGridView1.DataMember = Nothing : DataGridView1.DataSource = Nothing : DataGridView1.Columns.Clear()
        ''
        Call SFillCombo(cmbTableName, "Tblu_TranName", "ID", "TranName", "", False, "", ComboLoadItemSelect.Nothing)
        'cmbTableName.SelectedValue = 0
        'cmbTableName.Enabled = True
        'GBPayed.Enabled = False
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                TxtBox0.Text = DataGridView1.Item(0, e.RowIndex).Value.ToString
                cmbTableName.SelectedValue = DataGridView1.Item(1, e.RowIndex).Value
                TxtBox2.Text = DataGridView1.Item(2, e.RowIndex).Value
                TxtBox3.Text = DataGridView1.Item(3, e.RowIndex).Value
                TxtBox4.Text = DataGridView1.Item(4, e.RowIndex).Value
                GroupBox2.Enabled = True
                cmbCashType.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            Dim lstFieldName, lstValue As New List(Of String)
            Dim dRemoteDate As Date = (GetNetRemoteTOD(Mid(strServerName, 1, InStr(strServerName, "\") - 1)))

            lstFieldName.AddRange({"cashType", "PayedType", "PayedDate", "PayedTime", "InvoiceNo"})
            lstValue.AddRange({cmbCashType.SelectedIndex + 1, 1, FFormatDate2(dRemoteDate), FFormatTime(dRemoteDate), TxtBox6.Text})

            If FEditeRecord("Tblt_CasherPayed", "ID_Me", TxtBox0.Text, lstFieldName, lstValue) = True Then
                MsgBox("تم الحفظ بنجاح", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
                Call SAddNew()
            Else
                MsgBox("فشل الحفظ", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtBox6_TextChanged(sender As Object, e As EventArgs) Handles TxtBox6.TextChanged
        Call SSetEnabledCtrl
    End Sub

    Private Sub SSetEnabledCtrl()
        If TxtBox6.Text <> "" Then
            cmdSave.Enabled = True
        End If
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Call SAddNew()
    End Sub

End Class