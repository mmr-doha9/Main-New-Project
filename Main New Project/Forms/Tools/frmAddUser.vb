Public Class frmAddUser
    Dim strTable As String = "Tblc_UserCode"
    Dim DpAccess As OleDb.OleDbDataAdapter
    Dim Dp As SqlClient.SqlDataAdapter
    Dim Cm As CurrencyManager
    Dim ds As New DataSet()
    Dim WithEvents BS As New BindingSource
    Dim currPosition As Integer
    Private bindingSource1 As New BindingSource()
    ''
    Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    Dim typeFrm As frmEditType
    'Dim BoluserFrmPer, BoluserOPen, BoluserDelete, BoluserSave, BoluserReSave, BolUserOpenOtherUserTran As Boolean ' الصلاحيات

    Private Sub frmAddUser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        Call SAddNew()
    End Sub

    Public Sub SAddNew()
        Call ClearControl(Me.TabPage1)
        TxtBox1.Focus()
        'PictureEdit1.Visible = False
        TxtBox1.Focus()
    End Sub

    Private Sub SFillCtl(ByVal ctlName As Control)
        lstCtlTag.Clear() : lstCtlVal.Clear()
        '''''''''''''''''''''''''''
        With lstCtlVal
            .Add(TxtBox1.Text)
            .Add("123456")
            .Add(IIf(ChkAdmin.Checked = True, 1, 0))
            .Add("0")
            .Add("")
            .Add("true")
        End With
        '''''''''''''''''''''''''
        With lstCtlTag
            .Add("UserName")
            .Add("UserPassword")
            .Add("UserType")
            .Add("LoginState")
            .Add("lastTimeConnect")
            .Add("MustChangePass")
        End With
        '''''''''''''''''''''''''
    End Sub

    Public Sub SUpdate()
        Try
            Call SFillCtl(Me)
            FAddNewRecord(strTable, lstCtlTag, lstCtlVal)
            MsgBox("تم الحفظ بنجاح", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBox1.GotFocus
        Call FChangeLang()
    End Sub

    Private Sub AddPicMnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPicMnu.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = Application.StartupPath & "\Pic\"
        openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|jpe files (*.jpe)|*.jpe|JPG files (*.JPG)|*.JPG|*.jpe|bmp files (*.bmp)|*.bmp|"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.ShowDialog()
        'TxtBox0.Text = openFileDialog1.FileName
        'PictureBox1.ImageLocation = TxtBox0.Text
        PictureBox1.ImageLocation = openFileDialog1.FileName
    End Sub

    Private Sub DelPicMnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelPicMnu.Click
        'TxtBox0.Text = ""
        'PictureBox1.ImageLocation = TxtBox0.Text
    End Sub

    Private Sub me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Call SUpdate()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            Call SAddNew()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Call SUpdate()
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Call SAddNew()
    End Sub

End Class