
Public Class frmBasicDataRep
    Dim tblName As String()
    Dim dsTmpRep As New DataSet()
    Dim strCompanyRep As String = strCompanyID
    Dim strTable As String

    Private Sub frmBasicDataRep_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case strReportNo
            Case "01"
                DTPicker1.Enabled = False : DTPicker2.Enabled = False
                Label1.Enabled = False : Label2.Enabled = False
                strTable = "Tblc_EnergyDevices"
                Call SFillCombo(cmbCode, strTable, "ID", "Name", , False, "ID", ComboLoadItemSelect.Min)
            Case "02"
                DTPicker1.Enabled = False : DTPicker2.Enabled = False
                Label1.Enabled = False : Label2.Enabled = False
                strTable = "Tblc_MainBranchCode"
                Call SFillCombo(cmbCode, strTable, "ID", "Name", , False, "ID", ComboLoadItemSelect.Min)
            Case "03"
                DTPicker1.Enabled = False : DTPicker2.Enabled = False
                Label1.Enabled = False : Label2.Enabled = False
                strTable = "Tblc_PlaceCode"
                Call SFillCombo(cmbCode, strTable, "ID", "Name", , False, "ID", ComboLoadItemSelect.Min)
            Case "04"

        End Select
        Me.MdiParent = Mdi
        'Me.Text = strReportName
        TabPage1.Text = strReportName
        DTPicker1.Value = Now.Date : DTPicker2.Value = Now.Date
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Try
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim mySelectFormula As String = ""
            Select Case strReportNo
                Case "01"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\BasicData\RepEnergyDevicesCode.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\BasicData\RepEnergyDevicesCode.rpt")
                    End If
                    If chkAll.Checked = False Then
                        If cmbCode.Enabled = True Then
                            mySelectFormula = "{" & strTable & ".ID} =" & cmbCode.SelectedValue
                        Else
                            mySelectFormula = "{" & strTable & ".ID} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                Case "02"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\BasicData\RepBranchCode.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\BasicData\RepBranchCode.rpt")
                    End If
                    If chkAll.Checked = False Then
                        If cmbCode.Enabled = True Then
                            mySelectFormula = "{" & strTable & ".ID} =" & cmbCode.SelectedValue
                        Else
                            mySelectFormula = "{" & strTable & ".ID} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                Case "03"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\BasicData\RepPlaceCode.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports\BasicData\RepPlaceCode.rpt")
                    End If
                    If chkAll.Checked = False Then
                        If cmbCode.Enabled = True Then
                            mySelectFormula = "{" & strTable & ".ID} =" & cmbCode.SelectedValue
                        Else
                            mySelectFormula = "{" & strTable & ".ID} in [" & strFGTreeSearch & "]"
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