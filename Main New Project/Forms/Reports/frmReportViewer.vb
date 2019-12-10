Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Web.Mail
Imports System.Net.Mail.SmtpClient
Public Class frmReportViewer
    Private Sub frmReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = MDI
    End Sub
    Private Sub frmReportViewer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CRViewer1.Top = 0
        CRViewer1.Left = 0
        'Me.WindowState = FormWindowState.Maximized
        CRViewer1.Height = 2000
        CRViewer1.Width = 2000
    End Sub
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Try
    '        Dim CrExportOptions As ExportOptions = New ExportOptions()

    '        Dim CrDiskFileDestinationOptions As New  _
    '        DiskFileDestinationOptions()
    '        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
    '        CrDiskFileDestinationOptions.DiskFileName = "mmr"
    '        With CrExportOptions
    '            .ExportDestinationType = ExportDestinationType.DiskFile
    '            .ExportFormatType = ExportFormatType.WordForWindows
    '            .DestinationOptions = CrDiskFileDestinationOptions
    '            .FormatOptions = CrFormatTypeOptions
    '        End With
    '        CRViewer1.ExportReport()
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    sendMail()

    'End Sub
    'Private Sub sendMail()
    '    Try
    '        Dim Smtp As SmtpMail
    '        SmtpMail.SmtpServer.Insert(0, "your hostname")
    '        Dim Msg As MailMessage = New MailMessage
    '        Msg.To = "to address here"
    '        Msg.From = "from address here"
    '        Msg.Subject = "Crystal Report Attachment "
    '        Msg.Body = "Crystal Report Attachment "
    '        Msg.Attachments.Add(New MailAttachment("mmr"))
    '        Smtp.Send(Msg)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub
End Class