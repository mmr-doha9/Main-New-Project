Public Class frmTazlom
    Dim intDocNo As Integer
    Dim strTableName As String
    Dim lstValue As New List(Of String)

    Public Sub New(intDocNoTmp As Integer, strTableNameTmp As String, ByRef lstValueTmp As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        intDocNo = intDocNoTmp
        strTableName = strTableNameTmp
        lstValue = lstValueTmp
    End Sub

    Private Sub frmTazlom_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            lstValue.Clear()
            lstValue.Add(FFormatDate(DateTimePicker1.Value))
            lstValue.Add(TxtBox1.Text)
            lstValue.Add(TxtBox2.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox1.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox1.Name
                e.KeyChar = FJustNumber(e)
            Case Else

        End Select
    End Sub

End Class