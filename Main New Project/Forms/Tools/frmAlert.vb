Public Class frmAlert
    Private Sub frmAlert_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.WindowState = FormWindowState.Minimized
        'e.Cancel = True
    End Sub
    Private Sub frmAlert_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = MDI
        Call ClearControl(Me.TabPage1)
        Call SDrawAlertGrid(DataGridView1)
        cmbState.SelectedIndex = 0
        Call LoadData()
    End Sub
    Public Sub LoadData()
        Call SLoadAlertGrid()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            DataGridView1.Item(1, i).Value = FGetFeildValues("Tblc_UserCode", "UserName", "ID=" & "'" & DataGridView1.Item(0, i).Value & "'", False)
            DataGridView1.Item(3, i).Value = FGetFeildValues("Tblc_UserCode", "UserName", "ID=" & "'" & DataGridView1.Item(0, i).Value & "'", False)
        Next
    End Sub
    Private Sub SLoadAlertGrid()
        Try
            Dim bolMessageState As Boolean

            Call SDelGridData(DataGridView1)
            If cmbState.SelectedIndex = 0 Then
                bolMessageState = False
            ElseIf cmbState.SelectedIndex = 1 Then
                bolMessageState = True
            End If

            strSQL = ("SELECT * FROM Tblt_UserMsg WHERE Tblt_UserMsg.UserId='" & strUserID & "'" & " And Tblt_UserMsg.ReadStates='" & bolMessageState & "' ORDER BY ID")
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    DataGridView1.RowCount += 1
                    For x As Integer = 0 To DataGridView1.Columns.Count - 1
                        If DataGridView1.Columns(x).Tag <> "" And DataGridView1.Columns(x).Tag = "Docdate" Then
                            DataGridView1.Item(x, i).Value = FFormatDateTime(dr.Item(DataGridView1.Columns(x).Tag))
                        ElseIf DataGridView1.Columns(x).Tag <> "" Then
                            DataGridView1.Item(x, i).Value = dr.Item(DataGridView1.Columns(x).Tag)
                        End If
                        If bolMessageState = False Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                    Next
                    i += 1
                Loop
                dr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    DataGridView1.RowCount += 1
                    For x As Integer = 0 To DataGridView1.Columns.Count - 1
                        If DataGridView1.Columns(x).Tag <> "" And DataGridView1.Columns(x).Tag = "Docdate" Then
                            DataGridView1.Item(x, i).Value = FFormatDateTime(dr.Item(DataGridView1.Columns(x).Tag))
                        ElseIf DataGridView1.Columns(x).Tag <> "" Then
                            DataGridView1.Item(x, i).Value = dr.Item(DataGridView1.Columns(x).Tag)
                        End If
                        If bolMessageState = False Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                    Next
                    i += 1
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            TextBox1.Text = DataGridView1.Item(5, e.RowIndex).Value
            Call FInsertVal("Tblt_UserMsg", "ReadStates", "'True'", "UserId='" & DataGridView1.Item(0, e.RowIndex).Value & "' And Notes='" & DataGridView1.Item(5, e.RowIndex).Value & "'", False)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub cmbState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbState.SelectedIndexChanged
        Call LoadData()
        TextBox1.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call LoadData()
        TextBox1.Text = ""
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class