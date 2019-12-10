Public Class frmActivation
    Dim intRegTry As Integer = 1
    Private Sub frmActivation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtBox1.Text = KeyActiveCode
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bolDemo = True  'false نسخة كاملة  true  نسخة للعرض
        Me.Hide()
        MDI.Text = MDI.Text & " - " & "نسخة تجريبية"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtBox2.Text = KeyMotherserialno And txtBox3.Text = KeyRegCode Then
            FAddNewRecord("Tblu_Tools", KeyRegCode, KeyMotherserialno)
            Me.Hide()
            'MDI.Show()
        Else
            If intRegTry < 3 Then
                MsgBox("عملية تسجيل خاطئة" & vbCrLf & "سيتم غلق البرنامج بعد " & vbCrLf & (3 - intRegTry) & " محاولة", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                intRegTry += 1
            ElseIf intRegTry <= 3 Then
                MsgBox("انتهت جميع المحاولات المتاحة لديك", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End
            End If
        End If
    End Sub
End Class