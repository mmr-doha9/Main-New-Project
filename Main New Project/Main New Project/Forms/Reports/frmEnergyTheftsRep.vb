Public Class frmEnergyTheftsRep
    Private Sub frmEnergyTheftsRep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '''''''''''''''''
        Call SFillCombo(cmbPartionCode, "Tblc_PartionCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbArtisticCode, "Tblc_ArtisticCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Call SFillCombo(cmbUserID, "Tblc_UserCode", "ID", "UserName", "", False, "", ComboLoadItemSelect.Min)
        cmbPayState.SelectedIndex = 0

        Select Case strReportNo
            Case "01"

            Case "02"

            Case "03"

        End Select
        Me.MdiParent = Mdi
        Me.Text = strReportName
        DTPicker1.Value = Now.Date : DTPicker2.Value = Now.Date
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Try
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim mySelectFormula As String = ""
            Select Case strReportNo
                Case "01"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts01.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\RepEnergyThefts01.rpt")
                    End If
                    mySelectFormula = "{Tblt_EnergyThefts.Date} >=('" & FReportDate(DTPicker1.Value) & "') And {Tblt_EnergyThefts.Date} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PayState} =" & cmbPayState.SelectedIndex
                    End If
                Case "02"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts02.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\RepEnergyThefts02.rpt")
                    End If
                    mySelectFormula = "{Tblt_EnergyThefts.Date} >=('" & FReportDate(DTPicker1.Value) & "') And {Tblt_EnergyThefts.Date} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        If cmbPayState.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PayState} =" & cmbPayState.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PayState} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    objReport.DataDefinition.FormulaFields.Item("FFromDate").Text = "totext('" & FFormatDate2((DTPicker1.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FToDate").Text = "totext('" & FFormatDate2((DTPicker2.Value)) & "')"
                Case "03"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts03.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\RepEnergyThefts03.rpt")
                    End If
                    mySelectFormula = "{Tblt_EnergyThefts.Date} >=('" & FReportDate(DTPicker1.Value) & "') And {Tblt_EnergyThefts.Date} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        If cmbPayState.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PayState} =" & cmbPayState.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PayState} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    objReport.DataDefinition.FormulaFields.Item("FFromDate").Text = "totext('" & FFormatDate2((DTPicker1.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FToDate").Text = "totext('" & FFormatDate2((DTPicker2.Value)) & "')"
                Case "11"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts11.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\RepEnergyThefts11.rpt")
                    End If
                    mySelectFormula = "{Tblt_EnergyThefts.Date} >=('" & FReportDate(DTPicker1.Value) & "') And {Tblt_EnergyThefts.Date} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        mySelectFormula = mySelectFormula & " and {Tblt_EnergyThefts.PayState} =" & cmbPayState.SelectedIndex
                    End If
                Case "12"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts12.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\RepEnergyThefts12.rpt")
                    End If
                    mySelectFormula = "{Tblt_EnergyTheftsSecond.Date} >=('" & FReportDate(DTPicker1.Value) & "') And {Tblt_EnergyTheftsSecond.Date} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        If cmbPayState.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PayState} =" & cmbPayState.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PayState} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    objReport.DataDefinition.FormulaFields.Item("FFromDate").Text = "totext('" & FFormatDate2((DTPicker1.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FToDate").Text = "totext('" & FFormatDate2((DTPicker2.Value)) & "')"
                Case "13"
                    If DataType = DataConnection.SqlServer Then
                        objReport.Load(Application.StartupPath & "\Reports\RepEnergyThefts13.rpt")
                    ElseIf DataType = DataConnection.Access Then
                        objReport.Load(Application.StartupPath & "\Reports2\RepEnergyThefts13.rpt")
                    End If
                    mySelectFormula = "{Tblt_EnergyTheftsSecond.Date} >=('" & FReportDate(DTPicker1.Value) & "') And {Tblt_EnergyTheftsSecond.Date} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        If cmbPayState.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PayState} =" & cmbPayState.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblt_EnergyTheftsSecond.PayState} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    objReport.DataDefinition.FormulaFields.Item("FFromDate").Text = "totext('" & FFormatDate2((DTPicker1.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FToDate").Text = "totext('" & FFormatDate2((DTPicker2.Value)) & "')"
            End Select
            If RepSource = RepLoadSource.Database Then
                Call GetServerNameAndDataBaseName(objReport)
            ElseIf RepSource = RepLoadSource.Dataset Then
                'objReport.SetDataSource(dsTmpRep)
            End If
            objReport.DataDefinition.FormulaFields.Item("FUserName").Text = "totext('" & strUserName & "')"
            objReport.DataDefinition.FormulaFields.Item("ZCompName").Text = "totext('" & strCompanyName & "')"
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

    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged, chkPartionCode.CheckedChanged, ChkBranchCode.CheckedChanged, ChkArtisticCode.CheckedChanged, ChkPoliceMenCode.CheckedChanged, ChkMabahsCode.CheckedChanged, ChkUserID.CheckedChanged, ChkPayState.CheckedChanged
        Select Case DirectCast(sender, CheckBox).Name
            Case chkAll.Name
                If chkAll.Checked = True Then
                    If chkPartionCode.Enabled = True Then chkPartionCode.Checked = True
                    If ChkBranchCode.Enabled = True Then ChkBranchCode.Checked = True
                    If ChkArtisticCode.Enabled = True Then ChkArtisticCode.Checked = True
                    If ChkPoliceMenCode.Enabled = True Then ChkPoliceMenCode.Checked = True
                    If ChkMabahsCode.Enabled = True Then ChkMabahsCode.Checked = True
                    If ChkUserID.Enabled = True Then ChkUserID.Checked = True
                    If ChkPayState.Enabled = True Then ChkPayState.Checked = True
                Else
                    If chkPartionCode.Enabled = True Then chkPartionCode.Checked = False
                    If ChkBranchCode.Enabled = True Then ChkBranchCode.Checked = False
                    If ChkArtisticCode.Enabled = True Then ChkArtisticCode.Checked = False
                    If ChkPoliceMenCode.Enabled = True Then ChkPoliceMenCode.Checked = False
                    If ChkMabahsCode.Enabled = True Then ChkMabahsCode.Checked = False
                    If ChkUserID.Enabled = True Then ChkUserID.Checked = False
                    If ChkPayState.Enabled = True Then ChkPayState.Checked = False
                End If
            Case chkPartionCode.Name
                If chkPartionCode.Checked = True Then
                    lblPartionCode.Enabled = False : cmbPartionCode.Enabled = False : cmdPartionCodeBrowse.Enabled = False
                Else
                    lblPartionCode.Enabled = True : cmbPartionCode.Enabled = True : cmdPartionCodeBrowse.Enabled = True
                End If
            Case ChkBranchCode.Name
                If ChkBranchCode.Checked = True Then
                    lblBranchCode.Enabled = False : CmbBranchCode.Enabled = False : cmdBranchCode.Enabled = False
                Else
                    lblBranchCode.Enabled = True : CmbBranchCode.Enabled = True : cmdBranchCode.Enabled = True
                End If
            Case ChkArtisticCode.Name
                If ChkArtisticCode.Checked = True Then
                    lblArtisticCode.Enabled = False : cmbArtisticCode.Enabled = False : cmdArtisticCode.Enabled = False
                Else
                    lblArtisticCode.Enabled = True : cmbArtisticCode.Enabled = True : cmdArtisticCode.Enabled = True
                End If
            Case ChkPoliceMenCode.Name
                If ChkPoliceMenCode.Checked = True Then
                    lblPoliceMenCode.Enabled = False : cmbPoliceMenCode.Enabled = False : cmdPoliceMenCode.Enabled = False
                Else
                    lblPoliceMenCode.Enabled = True : cmbPoliceMenCode.Enabled = True : cmdPoliceMenCode.Enabled = True
                End If
            Case ChkMabahsCode.Name
                If ChkMabahsCode.Checked = True Then
                    lblMabahsCode.Enabled = False : cmbMabahsCode.Enabled = False : cmdMabahsCode.Enabled = False
                Else
                    lblMabahsCode.Enabled = True : cmbMabahsCode.Enabled = True : cmdMabahsCode.Enabled = True
                End If
            Case ChkUserID.Name
                If ChkUserID.Checked = True Then
                    lblUserID.Enabled = False : cmbUserID.Enabled = False : cmdUserID.Enabled = False
                Else
                    lblUserID.Enabled = True : cmbUserID.Enabled = True : cmdUserID.Enabled = True
                End If
            Case ChkPayState.Name
                If ChkPayState.Checked = True Then
                    lblPayState.Enabled = False : cmbPayState.Enabled = False
                Else
                    lblPayState.Enabled = True : cmbPayState.Enabled = True
                End If
        End Select
    End Sub

    Private Sub cmdCodeBrowse_Click(sender As Object, e As EventArgs) Handles cmdPartionCodeBrowse.Click, cmdBranchCode.Click, cmdArtisticCode.Click, cmdPoliceMenCode.Click, cmdMabahsCode.Click, cmdUserID.Click

        Select Case DirectCast(sender, Button).Name
            Case cmdPartionCodeBrowse.Name
                If lblPartionCode.Enabled = False Then
                    lblPartionCode.Enabled = True : cmbPartionCode.Enabled = True
                Else
                    lblPartionCode.Enabled = False : cmbPartionCode.Enabled = False
                    strFGTreeSearch = FTreeSearch(TreeBranches.SingleBranch, "Tblc_PartionCode", "ID", , "", "بيانات القطاعات", False, False, "ID",, SearchReturnType.Number)
                End If
            Case cmdBranchCode.Name
                If lblBranchCode.Enabled = False Then
                    lblBranchCode.Enabled = True : CmbBranchCode.Enabled = True
                Else
                    lblBranchCode.Enabled = False : CmbBranchCode.Enabled = False
                    strFGTreeSearch2 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_MainBranchCode", "ID", , "", "بيانات الإدارات التجارية", False, False, "ID",, SearchReturnType.Number)
                End If
            Case cmdArtisticCode.Name
                If lblArtisticCode.Enabled = False Then
                    lblArtisticCode.Enabled = True : cmbArtisticCode.Enabled = True
                Else
                    lblArtisticCode.Enabled = False : cmbArtisticCode.Enabled = False
                    strFGTreeSearch3 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_ArtisticCode", "ID", , "", "بيانات الفنيين", False, False, "ID",, SearchReturnType.Number)
                End If
            Case cmdPoliceMenCode.Name
                If lblPoliceMenCode.Enabled = False Then
                    lblPoliceMenCode.Enabled = True : cmbPoliceMenCode.Enabled = True
                Else
                    lblPoliceMenCode.Enabled = False : cmbPoliceMenCode.Enabled = False
                    strFGTreeSearch4 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_PoliceMenCode", "ID", , "", "بيانات مندوبى الشرطة", False, False, "ID",, SearchReturnType.Number)
                End If
            Case cmdMabahsCode.Name
                If lblMabahsCode.Enabled = False Then
                    lblMabahsCode.Enabled = True : cmbMabahsCode.Enabled = True
                Else
                    lblMabahsCode.Enabled = False : cmbMabahsCode.Enabled = False
                    strFGTreeSearch5 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_MabahsCode", "ID", , , "بيانات وحدات المباحث", False, False, "ID",, SearchReturnType.Number)
                End If
            Case cmdUserID.Name
                If lblUserID.Enabled = False Then
                    lblUserID.Enabled = True : cmbUserID.Enabled = True
                Else
                    lblUserID.Enabled = False : cmbUserID.Enabled = False
                    strFGTreeSearch6 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_UserCode", "UserCode", , , "اكواد المستخدمين", False, False, "UserCode", "UserName", SearchReturnType.Number)
                End If
        End Select

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

End Class