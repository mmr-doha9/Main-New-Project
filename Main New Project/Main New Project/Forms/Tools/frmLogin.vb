Imports Microsoft.Win32
Public Class frmLogin
    Dim Dp As SqlClient.SqlDataAdapter
    Dim ds As New DataSet()
    Dim currPosition As Integer
    Public RecUser As RegistryKey = Registry.CurrentUser.CreateSubKey("RecUser")

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = MDI
        Call SFillCombo(Combox, "Tblc_UserCode", "UserCode", "UserName", "", False, "ID")
        Combox.SelectedValue = Val(RecUser.GetValue("UserID"))
    End Sub

    Private Sub TextBoxes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBox1.GotFocus
        Call FChangeLang()
    End Sub

    Private Sub TextBoxes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox1.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox1.Name
                'e.KeyChar = FJustNumber(e)
                If e.KeyChar = Chr(13) Then
                    SendKeys.Send("{TAB}")
                End If
            Case Else
                If e.KeyChar = Chr(13) Then
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        If EnterUsers(Combox.SelectedValue, TxtBox1.Text) = True Then
            strUserID = Combox.SelectedValue : strUserName = FGetFeildValues("Tblc_UserCode", "UserName", "UserCode='" & Combox.SelectedValue & "'")
            Call SSetUserPer(strUserID)
            On Error Resume Next
            RecUser.DeleteValue("UserID") : RecUser.DeleteValue("UserPass")
            If ChkBox0.Checked = True And ChkBox1.Checked = True Then
                RecUser.SetValue("UserID", Combox.SelectedValue)
                RecUser.SetValue("UserPass", TxtBox1.Text)
            ElseIf ChkBox0.Checked = True Then
                RecUser.SetValue("UserID", Combox.SelectedValue)
            End If
            MDI.UserMsg.Enabled = True : frmAlert.Show()
            If frmAlert.DataGridView1.RowCount = 0 Then frmAlert.WindowState = FormWindowState.Minimized
            Me.Close()
            Me.Dispose()
        Else
            MsgBox("كلمة مرور خاطئة", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            TxtBox1.Focus()
            TxtBox1.SelectAll()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

End Class