Public NotInheritable Class frmAbout

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MDI

        Label2.Text = ProgName ' My.Application.Info.ProductName
        'Me.LabelVersion.Text = String.Format("نسخة 2020")
        'My.Application.Info.Description = ""
        'Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Me.Close()
        Me.Dispose()
    End Sub
End Class
