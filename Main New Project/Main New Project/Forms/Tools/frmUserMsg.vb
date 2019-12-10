Public Class frmUserMsg
    Private Sub frmUserMsg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = MDI
        Call SFillCombo(cmbUserCode, "Tblc_UserCode", "UserCode", "UserName", "", False)
        TxtBox2.Focus()
    End Sub
    Private Sub cmdReloadUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadUsers.Click
        Try
            Dim arrCtlFld() As String = {"UserId", "UserIdFrom", "Docdate", "ReadStates", "Notes"}
            Dim arrCtl() As String = {TxtBox1.Text, strUserID, FFormatDateTime(System.DateTime.Now), "False", TxtBox2.Text}

            FAddNewRecord("Tblt_UserMsg", arrCtlFld, arrCtl)
            TxtBox2.Text = "" : TxtBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub TxtBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBox1.TextChanged
        cmbUserCode.SelectedValue = TxtBox1.Text  'FGetFeildValues("Tblc_UserCode", "UserName", "UserCode=" & "'" & TxtBox1.Text & "'", False)
    End Sub
    Private Sub cmbUserCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUserCode.TextChanged
        TxtBox1.Text = cmbUserCode.SelectedValue
    End Sub
    Private Sub TextBoxes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBox1.GotFocus, TxtBox2.GotFocus
        Call FChangeLang()
        sender.SelectAll()
    End Sub
End Class