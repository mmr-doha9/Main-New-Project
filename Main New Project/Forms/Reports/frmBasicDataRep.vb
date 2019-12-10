
Public Class frmBasicDataRep
    Dim tblName As String()
    Dim dsTmpRep As New DataSet()
    Dim strCompanyRep As String = strCompanyID
    Dim strTable As String
    Dim strReportName As String
    Dim strReportNo As String
    Public Sub New(strTempReportNo As String, strTempReportName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        strReportName = strTempReportName
        strReportNo = strTempReportNo
    End Sub

    Private Sub frmBasicDataRep_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case strReportNo
            Case "01"
                strTable = "Tblc_EnergyDevices"
                Call SFillCombo(cmbCode, strTable, "ID", "Name", , False, "ID", ComboLoadItemSelect.Min)
            Case "02"
                strTable = "Tblc_MainBranchCode"
                Call SFillCombo(cmbCode, strTable, "ID", "Name", , False, "ID", ComboLoadItemSelect.Min)
            Case "03"
                strTable = "Tblc_PlaceCode"
                Call SFillCombo(cmbCode, strTable, "ID", "Name", , False, "ID", ComboLoadItemSelect.Min)
            Case "04"

        End Select
        Me.MdiParent = Mdi
        'Me.Text = strReportName
        TabPage1.Text = strReportName
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Try
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim mySelectFormula As String = ""
            Dim strRepPath As String = Application.StartupPath & "\Reports\Basic Reports\"

            Select Case strReportNo
                Case "01"
                    objReport.Load(strRepPath & "RepEnergyDevicesCode.rpt")

                    If chkAll.Checked = False Then
                        If cmbCode.Enabled = True Then
                            mySelectFormula = "{" & strTable & ".ID} =" & cmbCode.SelectedValue
                        Else
                            mySelectFormula = "{" & strTable & ".ID} In [" & strFGTreeSearch & "]"
                        End If
                    End If
                Case "02"
                    objReport.Load(strRepPath & "RepBranchCode.rpt")

                    If chkAll.Checked = False Then
                        If cmbCode.Enabled = True Then
                            mySelectFormula = "{" & strTable & ".ID} =" & cmbCode.SelectedValue
                        Else
                            mySelectFormula = "{" & strTable & ".ID} In [" & strFGTreeSearch & "]"
                        End If
                    End If
                Case "03"
                    objReport.Load(strRepPath & "RepPlaceCode.rpt")

                    If chkAll.Checked = False Then
                        If cmbCode.Enabled = True Then
                            mySelectFormula = "{" & strTable & ".ID} =" & cmbCode.SelectedValue
                        Else
                            mySelectFormula = "{" & strTable & ".ID} In [" & strFGTreeSearch & "]"
                        End If
                    End If
            End Select
            objReport.DataDefinition.FormulaFields.Item("FUserName").Text = "totext('" & strUserName & "')"
            objReport.DataDefinition.FormulaFields.Item("ZCompName").Text = "totext('" & strCompanyName & "')"

            If RepSource = RepLoadSource.Database Then
                Call GetServerNameAndDataBaseName(objReport)
            ElseIf RepSource = RepLoadSource.Dataset Then
                objReport.SetDataSource(dsTmpRep)
            End If
            Dim frmReport As New frmReportViewer
            frmReport.CRViewer1.ReportSource = objReport
            frmReport.CRViewer1.SelectionFormula = mySelectFormula
            frmReport.CRViewer1.Zoom(100%)
            frmReport.CRViewer1.RefreshReport()
            frmReport.Text = strReportName
            'Call SUpdateDataForReport()
            frmReport.Show()
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        If Label3.Enabled = False Then
            Label3.Enabled = True : cmbCode.Enabled = True
        Else
            Label3.Enabled = False : cmbCode.Enabled = False
            strFGTreeSearch = FTreeSearch(TreeBranches.SingleBranch, strTable, "ID", , "", strReportName, False, False, "ID", "Name", SearchReturnType.Number)
        End If
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked = True Then
            Label3.Enabled = False : cmbCode.Enabled = False : cmdBrowse.Enabled = False
        Else
            Label3.Enabled = True : cmbCode.Enabled = True : cmdBrowse.Enabled = True
        End If
    End Sub

End Class