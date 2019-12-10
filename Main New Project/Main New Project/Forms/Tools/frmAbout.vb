Public NotInheritable Class frmAbout

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = ProgName ' My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("حول {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = ProgName ' My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("نسخة 2016-2020")
        Me.LabelCopyright.Text = "البرنامج تصميم محاسب/ مدحت رمضان محمد"
        Me.LabelCompanyName.Text = "01224481228-01146021698"
        'My.Application.Info.Description = ""
        'Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class
