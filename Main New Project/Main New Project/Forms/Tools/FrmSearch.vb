Public Class FrmSearch
    'Dim ds As New DataSet
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Public Sub Clear_GridData()
        'For i As Integer = 0 To DataGridView.ColumnCount - 1
        'For n As Integer = 0 To DataGridView.RowCount - 1
        '    DataGridView.Rows.Remove(DataGridView.CurrentRow)
        'Next
        'Next
        ''مسح المحتويات
        'DataGridView.EditMode = DataGridViewEditMode.EditOnKeystroke
        DataGridView.DataSource = Nothing
        'DataGridView.DataMember = Nothing
        'ds.Dispose()
        'ds = Nothing
        'DataGridView.Rows.Clear()
        'SDelGridData(DataGridView)
    End Sub
    Private Sub FrmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If strSearchBeginNameMain <> "" Then
            ComboBox.SelectedItem = FGetFeildValues("Tblu_ConvertName", "Arabic", "English='" & strSearchBeginNameMain & "'", False, False)
        Else
            'ComboBox.SelectedIndex = 0
        End If
        txtBox.Text = ""
        For i As Integer = 0 To DataGridView.ColumnCount - 1
            DataGridView.Columns(i).HeaderText = FGetSearchName(DataGridView.Columns(i).Name, 0)
            DataGridView.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        'Me.Opacity = 0.9
    End Sub
    Private Sub txtBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBox.GotFocus
        Call FChangeLang()
    End Sub
    Private Sub txtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBox.TextChanged
        Dim ds As New DataSet

        strGKeyValue = txtBox.Text
        If strSearchBeginNameMain = "" Then
            strGKeyField = FGetSearchName(ComboBox.Text, 1)
        Else
            strGKeyField = strSearchBeginNameMain
        End If
        strGTableName = Me.Tag

        Call Clear_GridData()
        If txtBox.Text <> "" Then
            If strGCondtion <> "" Then
                If chkBox0.Checked = True Then
                    strSQL = "SELECT *  From " & strGTableName & " WHERE ((" & strGKeyField & ")='" & strGKeyValue & "') and " & strGCondtion
                ElseIf chkBox1.Checked = True Then
                    strSQL = "SELECT *  From " & strGTableName & " WHERE (" & strGKeyField & ") LIKE '%" & strGKeyValue & "%' and " & strGCondtion
                End If
            Else
                If chkBox0.Checked = True Then
                    strSQL = "SELECT *  From " & strGTableName & " WHERE ((" & strGKeyField & ")='" & strGKeyValue & "')"
                ElseIf chkBox1.Checked = True Then
                    strSQL = "SELECT *  From " & strGTableName & " WHERE (" & strGKeyField & ") LIKE '%" & strGKeyValue & "%'"
                End If
            End If

            If DataType = DataConnection.SqlServer Then
                Dim DataAdapter1 As New SqlClient.SqlDataAdapter(strSQL, CON)
                DataAdapter1.Fill(ds, strGTableName)
                DataGridView.DataSource = ds
                DataGridView.DataMember = strGTableName

                Dim x As String = ""
                For Each dc As DataColumn In ds.Tables.Item(strGTableName).Columns
                    'x = dc.ColumnName
                    For i As Integer = 0 To arrCoulmn.Length - 1
                        DataGridView.Columns(dc.ColumnName).Visible = False
                        If arrCoulmn(i) = dc.ColumnName Then
                            DataGridView.Columns(dc.ColumnName).Visible = True
                            Exit For
                        End If
                    Next
                Next
                For i As Integer = 0 To DataGridView.ColumnCount - 1
                    DataGridView.Columns(i).HeaderText = FGetSearchName(DataGridView.Columns(i).Name, 0)
                    DataGridView.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            ElseIf DataType = DataConnection.Access Then
                Dim DataAdapter1 As New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                DataAdapter1.Fill(ds, strGTableName)
                DataGridView.DataSource = ds
                DataGridView.DataMember = strGTableName

                Dim x As String = ""
                For Each dc As DataColumn In ds.Tables.Item(strGTableName).Columns
                    'x = dc.ColumnName
                    For i As Integer = 0 To arrCoulmn.Length - 1
                        DataGridView.Columns(dc.ColumnName).Visible = False
                        If arrCoulmn(i) = dc.ColumnName Then
                            DataGridView.Columns(dc.ColumnName).Visible = True
                            Exit For
                        End If
                    Next
                Next
                For i As Integer = 0 To DataGridView.ColumnCount - 1
                    DataGridView.Columns(i).HeaderText = FGetSearchName(DataGridView.Columns(i).Name, 0)
                    DataGridView.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End If
        Else
            strSQL = "SELECT *  From " & strGTableName & " WHERE " & strGCondtion
            If DataType = DataConnection.SqlServer Then
                Dim DataAdapter1 As New SqlClient.SqlDataAdapter(strSQL, CON)
                DataAdapter1.Fill(ds, strGTableName)
                DataGridView.DataSource = ds
                DataGridView.DataMember = strGTableName
            ElseIf DataType = DataConnection.Access Then
                Dim DataAdapter1 As New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                DataAdapter1.Fill(ds, strGTableName)
                DataGridView.DataSource = ds
                DataGridView.DataMember = strGTableName
            End If
            Dim x As String = ""
            For Each dc As DataColumn In ds.Tables.Item(strGTableName).Columns
                'x = dc.ColumnName
                For i As Integer = 0 To arrCoulmn.Length - 1
                    DataGridView.Columns(dc.ColumnName).Visible = False
                    If arrCoulmn(i) = dc.ColumnName Then
                        DataGridView.Columns(dc.ColumnName).Visible = True
                        Exit For
                    End If
                Next
            Next
            For i As Integer = 0 To DataGridView.ColumnCount - 1
                DataGridView.Columns(i).HeaderText = FGetSearchName(DataGridView.Columns(i).Name, 0)
                DataGridView.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        End If
    End Sub
    Private Sub DataGridView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellDoubleClick
        Select Case e.RowIndex
            Case -1

            Case Else
                Dim intTmp As Integer = Val(TxtTmp.Text)
                strSearchGridVal = DataGridView.Item(intTmp, e.RowIndex).Value
        End Select
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox.SelectedIndexChanged
        strSearchBeginNameMain = ""
    End Sub
End Class