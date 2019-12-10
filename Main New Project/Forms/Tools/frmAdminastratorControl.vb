Public Class frmAdminastratorControl
    Dim Dp As SqlClient.SqlDataAdapter
    Dim ds As New DataSet()
    Dim currPosition As Integer
    Private Sub frmAdminastratorControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = MDI
        Call SFillCombo(Combox, "Tblc_UserCode", "UserCode", "UserName", "UserType=1", False, "ID")
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
    Private Sub Comnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Comnd.Click
        If EnterUsers(Combox.SelectedValue, TxtBox1.Text) = True Then
            strUserAdmin = Combox.SelectedValue
            Call SSetUserPer(strUserAdmin)
            MDI.mnuAdminControl.Enabled = False : MDI.mnuCancelAdminControl.Enabled = True '  تحكم مدير النظام 
            Me.Close() : Me.Dispose()
        Else
            MsgBox("كلمة مرور خاطئة", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            TxtBox1.Focus() : TxtBox1.SelectAll()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class