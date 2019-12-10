Public Class frmUserPer
    Dim ds As New DataSet()
    Private Sub frmUserPer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = MDI
        Call SDrawGrid()
        Call SFillCombo(Combox1, "Tblc_UserCode", "UserCode", "UserName", "UserType=0", False, "ID", ComboLoadItemSelect.Min)
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
        End With
        '''''''''''
        Dim UserNav As New DataGridViewCheckBoxColumn
        With UserNav
            .HeaderText = "التنقل بين السجلات"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserNav"
        End With
        '''''''''''
        Dim UserDel As New DataGridViewCheckBoxColumn
        With UserDel
            .HeaderText = "حذف السجلات"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserDel"
        End With
        '''''''''''
        Dim UserEdit As New DataGridViewCheckBoxColumn
        With UserEdit
            .HeaderText = "حفظ السجلات"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserEdit"
        End With
        '''''''''''
        Dim UserReEdit As New DataGridViewCheckBoxColumn
        With UserReEdit
            .HeaderText = "إعادة الحفظ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserReEdit"
        End With
        Dim UserOpen As New DataGridViewCheckBoxColumn
        With UserOpen
            .HeaderText = "فتح السجلات"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Tag = "UserOpen"
        End With
        '''''''''''
        DataGridView1.Columns.Add(FrmCode)
        DataGridView1.Columns.Add(FrmName)
        DataGridView1.Columns.Add(UserPer)
        DataGridView1.Columns.Add(UserNav)
        DataGridView1.Columns.Add(UserDel)
        DataGridView1.Columns.Add(UserEdit)
        DataGridView1.Columns.Add(UserReEdit)
        DataGridView1.Columns.Add(UserOpen)
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.RowHeadersVisible = False
    End Sub
    Private Sub SLoaddataGrid()
        Try
            Call SLoadGrid("Tblt_UserFormPer", DataGridView1, "UserCode", Combox1.SelectedValue, False, "", "Code", False)
            For i As Integer = 0 To DataGridView1.RowCount - 1
                DataGridView1.Item(1, i).Value = FGetFeildValues("Tblu_FrmCode", "FrmName", "Code='" & DataGridView1.Item(0, i).Value & "'", False)
            Next
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        FrmSearch.DataGridView.AutoResizeColumns()
    End Sub
    Private Sub Comnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Comnd.Click
        Call SSaveDataGrid()
    End Sub
    Private Sub SSaveDataGrid()
        Try
            Call FDeleteRecord("Tblt_UserFormPer", "UserCode='" & Combox1.SelectedValue & "'")
            Call SSaveGrid("Tblt_UserFormPer", DataGridView1, "UserCode", Combox1.SelectedValue, "", False, True, False)
            Call SLoaddataGrid()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub SDelOldData()
        Dim cmd As New OleDb.OleDbCommand
        Dim Dp As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSQL, CON)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM Tblt_UserFormPer WHERE UserCode ='" & Combox1.SelectedValue & "'"
        cmd.ExecuteNonQuery()
        ds.Clear()
        Dp.Fill(ds, "Tblt_UserFormPer")
    End Sub
    Private Sub Combox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combox1.SelectedIndexChanged
        Call SLoaddataGrid()
    End Sub
End Class