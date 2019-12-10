Public Class frmUserPer

    Dim ds As New DataSet()
    Dim bolDealWithCombo As Boolean = True  ' لدم حدوث خطا في كومبو الادارة

    Private Sub frmUserPer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        Call SDrawGrid()
        bolDealWithCombo = False
        Call SFillCombo(cmbUserCode, "Tblc_UserCode", "ID", "UserName", "UserType=0", False, "ID", ComboLoadItemSelect.Nothing)
        bolDealWithCombo = True
        Call SAddNew()
        Call SLoadFormName()
        Call cmbUserCode_SelectedIndexChanged(sender:=Nothing, e:=Nothing)
    End Sub

    Public Sub SAddNew()
        Call ClearControl(TabPage1)
    End Sub

    Private Sub SDrawGrid()
        Dim FrmCode As New DataGridViewTextBoxColumn
        With FrmCode
            .HeaderText = "رقم الشاشة"
            .Visible = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
            .Visible = True
            .Width = 0
            .Tag = "FrmCode"
            .Name = "FrmCode"
        End With
        '''''''''''
        Dim FrmName As New DataGridViewTextBoxColumn
        With FrmName
            .HeaderText = "اسم الشاشة"
            .Visible = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .ReadOnly = True
        End With
        '''''''''''
        Dim UserPer As New DataGridViewCheckBoxColumn
        With UserPer
            .HeaderText = "التعامل مع الشاشة"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserPer"
            .Name = "UserPer"
        End With
        '''''''''''
        Dim UserOpen As New DataGridViewCheckBoxColumn
        With UserOpen
            .HeaderText = "فتح السجلات"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserOpen"
            .Name = "UserOpen"
        End With
        '''''''''''
        Dim UserDel As New DataGridViewCheckBoxColumn
        With UserDel
            .HeaderText = "حذف السجلات"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserDel"
            .Name = "UserDel"
        End With
        '''''''''''
        Dim UserEdit As New DataGridViewCheckBoxColumn
        With UserEdit
            .HeaderText = "حفظ السجلات"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserEdit"
            .Name = "UserEdit"
        End With
        '''''''''''
        Dim UserReEdit As New DataGridViewCheckBoxColumn
        With UserReEdit
            .HeaderText = "إعادة الحفظ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserReEdit"
            .Name = "UserReEdit"
        End With
        '''''''''''
        Dim UserOpenOtherUserTran As New DataGridViewCheckBoxColumn
        With UserOpenOtherUserTran
            .HeaderText = "فتح حركات جميع المستخدمين"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserOpenOtherUserTran"
            .Name = "UserOpenOtherUserTran"
        End With
        '''''''''''

        DataGridView1.Columns.Add(FrmCode)
        DataGridView1.Columns.Add(FrmName)
        DataGridView1.Columns.Add(UserPer)
        DataGridView1.Columns.Add(UserOpen)
        DataGridView1.Columns.Add(UserDel)
        DataGridView1.Columns.Add(UserEdit)
        DataGridView1.Columns.Add(UserReEdit)
        DataGridView1.Columns.Add(UserOpenOtherUserTran)

        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToOrderColumns = False
        DataGridView1.AllowUserToResizeRows = False
    End Sub

    'Private Sub SloadControls()

    Private Sub SOpen()
        Try
            '                               0                 1                  2                  3               4                  5                     6                   
            Dim strTmp() As String = {"chkfrmDashBoard", "chkThefts", "chkTheftsDisagreed", "chkTheftsZaina", "chkThefts2", "chkThefts2Disagreed", "chkTheftsZainaSecond"}

            Dim StrValueTmp As String() = FGetFeildValuesArry("Tblt_UserFormPerMain", strTmp, "UserCode=" & cmbUserCode.SelectedValue, False, "")
            chkfrmDashBoard.Checked = StrValueTmp(0)
            chkThefts.Checked = StrValueTmp(1)
            chkTheftsDisagreed.Checked = StrValueTmp(2)
            chkTheftsZaina.Checked = StrValueTmp(3)
            chkThefts2.Checked = StrValueTmp(4)
            chkThefts2Disagreed.Checked = StrValueTmp(5)
            chkTheftsZainaSecond.Checked = StrValueTmp(6)
            '''
            Call SLoaddataGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SLoaddataGrid()
        Try
            If bolDealWithCombo = True Then
                Dim strSQL As String = "select * from Tblt_UserFormPer where UserCode='" & cmbUserCode.SelectedValue & "' ORDER BY ID"

                If DataType = DataConnection.SqlServer Then
                    Dim tmpConn As New SqlClient.SqlConnection(Db_Conn)
                    tmpConn.Open()
                    Dim cmd As New SqlClient.SqlCommand(strSQL, tmpConn)
                    Dim tmpDr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Do While tmpDr.Read
                        For i As Integer = 0 To DataGridView1.RowCount
                            Dim m As String = tmpDr("FrmCode")

                            If DataGridView1.Item(0, i).Value = tmpDr("FrmCode") Then
                                DataGridView1.Item(2, i).Value = tmpDr("UserPer")
                                DataGridView1.Item(3, i).Value = tmpDr("UserOpen")
                                DataGridView1.Item(4, i).Value = tmpDr("UserDel")
                                DataGridView1.Item(5, i).Value = tmpDr("UserEdit")
                                DataGridView1.Item(6, i).Value = tmpDr("UserReEdit")
                                DataGridView1.Item(7, i).Value = tmpDr("UserOpenOtherUserTran")
                                Exit For
                            End If
                        Next
                    Loop
                    tmpConn.Close()
                ElseIf DataType = DataConnection.Access Then

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SLoadFormName()
        Try
            DataGridView1.Rows.Clear()

            Dim strSQL As String = "Select * from Tblu_FrmCode where ItemType=1"
            If DataType = DataConnection.SqlServer Then
                Dim tmpConn As New SqlClient.SqlConnection(Db_Conn)
                tmpConn.Open()
                Dim cmd As New SqlClient.SqlCommand(strSQL, tmpConn)
                Dim tmpDr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While tmpDr.Read
                    DataGridView1.Rows.Add()
                    DataGridView1.Item(0, DataGridView1.RowCount - 1).Value = tmpDr("Code").ToString
                    DataGridView1.Item(1, DataGridView1.RowCount - 1).Value = tmpDr("FrmName").ToString
                    Call SSetRowColor(tmpDr("FrmCode"), DataGridView1.RowCount - 1, DataGridView1)
                Loop
                tmpConn.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim tmpConn As New OleDb.OleDbConnection(Db_Conn)
                tmpConn.Open()
                Dim cmd As New OleDb.OleDbCommand(strSQL, tmpConn)
                Dim tmpDr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While tmpDr.Read
                    DataGridView1.Rows.Add()
                    DataGridView1.Item(0, DataGridView1.RowCount - 1).Value = tmpDr("Code")
                    DataGridView1.Item(1, DataGridView1.RowCount - 1).Value = tmpDr("FrmName")
                Loop
                tmpConn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SSetRowColor(tmpDr As String, intRowNo As Integer, GrdName As DataGridView)
        Try
            Select Case Mid(tmpDr.ToString, 1, 1)
                Case "B"
                    GrdName.Rows.Item(intRowNo).DefaultCellStyle.BackColor = Color.AliceBlue
                Case "T"
                    GrdName.Rows.Item(intRowNo).DefaultCellStyle.BackColor = Color.DarkKhaki
                Case "R"
                    GrdName.Rows.Item(intRowNo).DefaultCellStyle.BackColor = Color.AliceBlue
                    For i As Integer = 3 To GrdName.ColumnCount - 1
                        GrdName.Item(i, intRowNo).ReadOnly = True
                        GrdName.Item(i, intRowNo).Style.BackColor = Color.BlanchedAlmond
                    Next
                Case "U"
                    GrdName.Rows.Item(intRowNo).DefaultCellStyle.BackColor = Color.DarkKhaki
                    For i As Integer = 3 To GrdName.ColumnCount - 1
                        'GrdName.Item(i, intRowNo).ReadOnly = True
                        'GrdName.Item(i, intRowNo).Style.BackColor = Color.BlanchedAlmond
                    Next
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            Call FDeleteRecord("Tblt_UserFormPerMain", "UserCode" & "=" & cmbUserCode.SelectedValue)
            Call FDeleteRecord("Tblt_UserFormPer", "UserCode" & "=" & cmbUserCode.SelectedValue)

            Dim lstFieldName, lstValue As New List(Of String)

            lstFieldName.AddRange({"UserCode", "chkfrmDashBoard", "chkThefts", "chkTheftsDisagreed", "chkTheftsZaina", "chkThefts2", "chkThefts2Disagreed", "chkTheftsZainaSecond"})
            lstValue.AddRange({cmbUserCode.SelectedValue, chkfrmDashBoard.Checked, chkThefts.Checked, chkTheftsDisagreed.Checked, chkTheftsZaina.Checked, chkThefts2.Checked, chkThefts2Disagreed.Checked, chkTheftsZainaSecond.Checked})
            FAddNewRecord2("Tblt_UserFormPerMain", lstFieldName, lstValue)

            Call SSaveDataGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SSaveDataGrid()
        Try

            For i As Integer = 0 To DataGridView1.RowCount - 1
                Dim strfeildName, strValue As New List(Of String)
                'Dim As New List(Of String)
                strfeildName.AddRange({"FrmCode", "UserPer", "UserOpen", "UserDel", "UserEdit", "UserReEdit", "UserOpenOtherUserTran", "UserCode"})
                strValue.AddRange({DataGridView1.Item("FrmCode", i).Value, DataGridView1.Item("UserPer", i).Value, DataGridView1.Item("UserOpen", i).Value, DataGridView1.Item("UserDel", i).Value, DataGridView1.Item("UserEdit", i).Value, DataGridView1.Item("UserReEdit", i).Value, DataGridView1.Item("UserOpenOtherUserTran", i).Value, cmbUserCode.SelectedValue})

                Call FAddNewRecord2("Tblt_UserFormPer", strfeildName, strValue)
            Next
            MsgBox("تم الحفظ بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SDelOldData()
        Dim cmd As New OleDb.OleDbCommand
        Dim Dp As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSQL, CON)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM Tblt_UserFormPer WHERE ID ='" & cmbUserCode.SelectedValue & "'"
        cmd.ExecuteNonQuery()
        ds.Clear()
        Dp.Fill(ds, "Tblt_UserFormPer")
    End Sub
    Private Sub cmbUserCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserCode.SelectedIndexChanged
        Try
            If bolDealWithCombo = False Then Exit Sub

            If cmbUserCode.SelectedValue = 0 Then
                GroupBox1.Enabled = False
            Else
                If bolDealWithCombo = True Then
                    GroupBox1.Enabled = True
                    Call SEmpetyGrid()
                    Call SOpen()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SEmpetyGrid()
        Try
            For i As Integer = 0 To DataGridView1.RowCount - 1
                For x As Integer = 0 To DataGridView1.ColumnCount - 1
                    If DataGridView1.Columns(x).CellType.Name = "DataGridViewCheckBoxCell" Then ' لو كانت خانة الجريدة تشك بوكس
                        DataGridView1.Item(x, i).Value = 0
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.RowCount > 0 Then
            Select Case e.RowIndex
                Case -1
                    If e.ColumnIndex <> 1 Then
                        For i As Integer = 0 To DataGridView1.RowCount - 1
                            If DataGridView1.Item(e.ColumnIndex, i).ReadOnly = False Then
                                If DataGridView1.Item(e.ColumnIndex, i).Value = True Then
                                    DataGridView1.Item(e.ColumnIndex, i).Value = False
                                Else
                                    DataGridView1.Item(e.ColumnIndex, i).Value = True
                                End If
                            End If
                        Next
                    End If
                Case Else
                    Select Case e.ColumnIndex
                        Case 1
                            For i As Integer = 2 To DataGridView1.ColumnCount - 1
                                If DataGridView1.Item(i, e.RowIndex).ReadOnly = False Then
                                    If DataGridView1.Item(i, e.RowIndex).Value = True Then
                                        DataGridView1.Item(i, e.RowIndex).Value = False
                                    Else
                                        DataGridView1.Item(i, e.RowIndex).Value = True
                                    End If
                                End If
                            Next
                    End Select
            End Select
        End If
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        Me.Close()
    End Sub

End Class