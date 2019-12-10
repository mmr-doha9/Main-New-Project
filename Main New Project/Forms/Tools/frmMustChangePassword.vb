Public Class frmMustChangePassword
    Dim strPassword As String
    Private bolCloseFrm As Boolean = False
    Dim intMustChangePassword As Integer ' 0==> 1==> مجبر لتغير كلمة السر

    Public Sub New(intMustChangePasswordTmp As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        intMustChangePassword = intMustChangePasswordTmp
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        intMustChangePassword = 1
    End Sub

    Private Sub frmMustChangePassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        strPassword = FGetFeildValues("Tblc_UserCode", "UserPassword", "ID='" & strUserID & "'")
        cmdLogin.Enabled = False
        Me.TxtBox1.Focus()
        TxtBox1.Text = "" : TxtBox2.Text = "" : TxtBox3.Text = ""
        bolCloseFrm = False
    End Sub

    Private Sub frmLockScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If intMustChangePassword = 1 Then
            If bolCloseFrm = False Then
                e.Cancel = True
            End If
        Else

        End If
    End Sub

    Private Sub TxtBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtBox1.TextChanged
        If strPassword = TxtBox1.Text Then
            TxtBox2.Enabled = True : TxtBox3.Enabled = True
            Label2.Enabled = True : Label3.Enabled = True
            PicBoxOld.Visible = False
        Else
            TxtBox2.Enabled = False : TxtBox3.Enabled = False
            Label2.Enabled = False : Label3.Enabled = False
            PicBoxOld.Visible = True
        End If
    End Sub
    Private Sub TxtBox3_TextChanged(sender As Object, e As EventArgs) Handles TxtBox3.TextChanged
        Try
            If TxtBox2.Text <> "" Then
                If TxtBox2.Text = TxtBox3.Text Then
                    cmdLogin.Enabled = True
                Else
                    cmdLogin.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Try
            If TxtBox2.TextLength >= 6 Then
                If TxtBox2.TextLength > 10 Then
                    MsgBox("كلمة المرور لابد أن لا تزيد عن 10 خانات علي الأكثر ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    TxtBox2.Focus()
                Else
                    If TxtBox1.Text = TxtBox2.Text Then
                        MsgBox("كلمة المرور الجديدة لابد أن تختلف عن كلمة المرور القديمه ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    Else
                        FEditeRecord("Tblc_UserCode", "ID", strUserID, {"UserPassword", "MustChangePass"}, {TxtBox2.Text, "False"})
                        bolCloseFrm = True : Me.Close()
                    End If

                End If
            Else
                MsgBox("كلمة المرور لابد أن تتكون من 6 خانات علي الأقل ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                TxtBox2.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        If intMustChangePassword = 1 Then
            If MsgBox("هل أنت متأكد من إغلاق البرنامج بالكامل؟", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
                If strUserID <> "" Then FEditeRecord("Tblc_UserCode", "ID", strUserID, {"LoginState"}, {"0"})
                CON.Close()
                End
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmMustChangePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class