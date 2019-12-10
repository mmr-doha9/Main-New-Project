Public Class frmPassword

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If FGetFeildValues("Tblc_UserCode", "UserPassword", "ID=" & "'" & strUserID & "'") = txtPassword.Text Then
            Me.Close()
            frmOption.Show()
        Else
            MsgBox("كلمة مرور خاطئة", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            txtPassword.Focus()
            txtPassword.SelectAll()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmPassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPassword.Text = ""
        txtPassword.Focus()
    End Sub

End Class