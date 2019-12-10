Public Class frmLockScreen
    Private bolCloseFrm As Boolean = False

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        TabPage1.Text = strUserName & " من فضلك إدخل كلمة المرور"
    End Sub
    Private Sub frmLockScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtBox1.Focus()
        TxtBox1.Text = ""
    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Try
            strSQL = "select * from Tblc_UserCode where ID ='" & strUserID & "' and UserPassword = '" & TxtBox1.Text & "'"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.Item("ID") = strUserID And dr.Item("UserPassword") = TxtBox1.Text Then
                        dr.Close() : cmd.Dispose()
                        ' لاعادة تشغيل التايمر
                        Mdi.bolMainStop = False
                        Mdi.TimerLockScreen.Start()
                        ' لاعادة تشغيل التايمر
                        bolCloseFrm = True
                        Me.Close()
                    Else
                        MsgBox("برجاء التأكد من كلمة المرور", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        dr.Close() : cmd.Dispose()
                    End If
                End If
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.Item("ID") = strUserID And dr.Item("UserPassword") = strUserPassword Then
                        dr.Close() : cmd.Dispose()
                        ' لاعادة تشغيل التايمر
                        Mdi.bolMainStop = False
                        Mdi.TimerLockScreen.Enabled = True
                        ' لاعادة تشغيل التايمر
                        bolCloseFrm = True
                        Me.Close()
                    Else
                        MsgBox("برجاء التأكد من كلمة المرور", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        dr.Close() : cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        If MsgBox("هل أنت متأكد من إغلاق البرنامج بالكامل؟", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
            If strUserID <> "" Then FEditeRecord("Tblc_UserCode", "ID", strUserID, {"LoginState"}, {"0"})
            CON.Close()
            End
        End If
    End Sub

    Private Sub frmLockScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bolCloseFrm = False Then
            e.Cancel = True
        End If

    End Sub



End Class