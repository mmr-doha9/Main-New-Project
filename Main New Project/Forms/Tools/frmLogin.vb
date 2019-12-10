Imports Microsoft.Win32
Public Class frmLogin
    Dim Dp As SqlClient.SqlDataAdapter
    Dim ds As New DataSet()
    Dim currPosition As Integer
    Public RecUser As RegistryKey = Registry.CurrentUser.CreateSubKey("RecUser")

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        Call SFillCombo(Combox, "Tblc_UserCode", "ID", "UserName", "", False, "ID")
        'Combox.SelectedValue = Val(RecUser.GetValue("UserID"))
        Combox.SelectedValue = 0
        Combox .Focus 
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
            ' جمع 4 مرات ف استعلام واحد
            strUserID = Combox.SelectedValue : strUserName = FGetFeildValues("Tblc_UserCode", "UserName", "ID='" & Combox.SelectedValue & "'") : strUserType = FGetFeildValues("Tblc_UserCode", "UserType", "ID='" & strUserID & "'")
            'strUserType = FGetFeildValues("Tblc_UserCode", "UserType", "ID='" & strUserID & "'")
            Dim bolMustChangePass As Boolean = FGetFeildValues("Tblc_UserCode", "MustChangePass", "ID='" & strUserID & "'")
            ' جمع 4 مرات ف استعلام واحد

            Call SSetUserPer(strUserID)
            Mdi.UserMsg.Enabled = True : Mdi.mnuChangePassword.Enabled = True : frmAlert.Show()
            If frmAlert.DataGridView1.RowCount = 0 Then frmAlert.WindowState = FormWindowState.Minimized
            ''''''
            Call FEditeRecord("Tblc_UserCode", "ID", strUserID, {"LoginState", "lastTimeConnect"}, {"1", FFormatDateTimeFormat(Now)})

            Mdi.BackgroundWorker1.RunWorkerAsync()
            Mdi.Timer1.Interval = 30000 ' كل دقيقة
            Mdi.Timer1.Start()
            ''''''
            Me.Close()
            Me.Dispose()
            Mdi.BackgroundImage = New Bitmap(Application.StartupPath & "/Pic/Main.jpg", True)
            Mdi.BackgroundImageLayout = ImageLayout.Stretch
            Call FSetTransaction(TransactionType.logIn, "", "0") ' transactions save
            ''''' Lock Screen
            Mdi.TimerLockScreen.Interval = 1000 'Set Timer Interval to 1 second
            Mdi.TimerLockScreen.Enabled = True 'Enable Timer
            'Application.AddMessageFilter(Mdi) 'Add Message Filtering Capabilities
            Mdi.MnuLock.Enabled = True
            If bolMustChangePass = True Then frmMustChangePassword.ShowDialog()
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