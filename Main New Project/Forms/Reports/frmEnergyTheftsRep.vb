Public Class frmEnergyTheftsRep
    Dim strReportName As String
    Dim strReportNo As String
    Dim strReportType As ReportType

    Enum ReportType
        DetailsReports
        TotalReports
    End Enum

    Public Sub New(strReportTypeTmp As ReportType)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        strReportType = strReportTypeTmp
        'Select Case strReportType
        '    Case ReportType.DetailsReports
        '        strReportNo = "31"  ' اول تقرير في التحليلي
        '    Case ReportType.TotalReports
        '        strReportNo = "41"  ' اول تقرير في الإجمالي
        'End Select
    End Sub

    Private Sub frmEnergyTheftsRep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '''''''''''''''''
        cmbDateType.SelectedIndex = 0
        Call SFillCombo(cmbPartionCode, "Tblc_PartionCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : cmbPartionCode.SelectedValue = 0
        Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : CmbBranchCode.SelectedValue = 0
        Call SFillCombo(cmbPartionCodeMain, "Tblc_PartionCode", "ID", "Name", "Type=0", False, "ID", ComboLoadItemSelect.Min) : cmbPartionCodeMain.SelectedValue = 0

        Call SFillCombo(cmbActivitiesCode, "Tblc_ActivitiesCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : cmbActivitiesCode.SelectedValue = 0
        Call SFillCombo(cmbPlaceCode, "Tblc_PlaceCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : cmbPlaceCode.SelectedValue = 0
        Call SFillCombo(cmbArtisticCode, "Tblc_ArtisticCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : cmbArtisticCode.SelectedValue = 0
        Call SFillCombo(cmbPoliceMenCode, "Tblc_PoliceMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : cmbPoliceMenCode.SelectedValue = 0
        Call SFillCombo(cmbAccountMenCode, "Tblc_AccountMenCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : cmbAccountMenCode.SelectedValue = 0
        Call SFillCombo(cmbMabahsCode, "Tblc_MabahsCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min) : cmbMabahsCode.SelectedValue = 0
        Call SFillCombo(cmbUserID, "Tblc_UserCode", "ID", "UserName", "", False, "", ComboLoadItemSelect.Min) : cmbUserID.SelectedValue = 0
        OptType3.Checked = True
        cmbPayState.SelectedIndex = 0

        Select Case strReportType
            Case ReportType.DetailsReports
                lblRepNo.Enabled = True : cmbRepNo.Enabled = True
                cmbRepNo.Items.AddRange({"تحليلـــــــــي", "تحليلــــــــي 2", "تحليلي السداد", "تحليلي التظلمات", "تحليلي تحويل النيابة", "تحليلي أوامر السداد"})
                cmbRepNo.SelectedIndex = 0
                GroupRepBands.Enabled = True
                chkThefts.Enabled = True : chkThefts2.Enabled = True : chkTheftsZaina.Enabled = True
                chkTheftsDisagreed.Enabled = True : chkThefts2Disagreed.Enabled = True : chkTheftsZainaSecond.Enabled = True
                ''''
                lblNameSearch.Enabled = True : txtNameSearch.Enabled = True : chkNameSearch.Enabled = True
                lblAddSearch.Enabled = True : TxtAddSearch.Enabled = True : chkAddSearch.Enabled = True
                chkShowAdd.Enabled = True
                ''''''
                lblVal.Enabled = True : txtValFrom.Enabled = True : lblValTo.Enabled = True : txtValTo.Enabled = True ' بحث بالقيمة
            Case ReportType.TotalReports
                cmbRepNo.Items.AddRange({"الإجماليات بالقطاعات", "الإجماليات بالأنشطة التجارية", "إجماليات مندوبي الضبط "})
                cmbRepNo.SelectedIndex = 0
                ''''
                lblRepNo.Enabled = True : cmbRepNo.Enabled = True
                GroupRepBands.Enabled = True
                chkThefts.Enabled = True : chkThefts2.Enabled = True : chkTheftsZaina.Enabled = True
                chkTheftsDisagreed.Enabled = True : chkThefts2Disagreed.Enabled = True : chkTheftsZainaSecond.Enabled = True
                ''''
                lblNameSearch.Enabled = True : txtNameSearch.Enabled = True : chkNameSearch.Enabled = True
                lblAddSearch.Enabled = True : TxtAddSearch.Enabled = True : chkAddSearch.Enabled = True
                'chkShowAdd.Enabled = True
        End Select
        Me.MdiParent = Mdi
        Me.Text = strReportName
        DTPicker1.Value = Now.Date : DTPicker2.Value = Now.Date
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Try
            Dim strDateType As String = IIf(cmbDateType.SelectedIndex = 0, "Date", "Date2")
            Dim strRepPath As String = Application.StartupPath & "\Reports\"

            If FCheckRepOpen() = False Then Exit Sub ' للتأكد من عدم خلو أحد شروط التقرير

            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim mySelectFormula As String = ""
            Select Case strReportNo
                Case "01"
                    strRepPath = strRepPath & "Rep Details\"

                    objReport.Load(strRepPath & "RepEnergyThefts01.rpt")

                    mySelectFormula = "{Tblt_EnergyThefts." & strDateType & "} >=('" & FReportDate(DTPicker1.Value) & "') And {Tblt_EnergyThefts." & strDateType & "} <= ('" & FReportDate(DTPicker2.Value) & "')"
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
                    If chkPartionCodeMain.Checked = False Then
                        If cmbPartionCodeMain.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {Tblc_MainBranchCode.PartationCodeMain} =" & cmbPartionCodeMain.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {Tblc_MainBranchCode.PartationCodeMain} in [" & strFGTreeSearch8 & "]"
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
                Case "31", "32", "33", "34"
                    strRepPath = strRepPath & "Rep Details\"
                    Dim strTbleName As String = "View_TranMain"
                    Select Case cmbRepNo.SelectedIndex
                        Case "0"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran1.rpt")
                        Case "1"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran2.rpt")
                        Case "2"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran3.rpt")
                        Case "3"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran4.rpt")
                        Case "4"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran5.rpt")
                        Case "5"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran6.rpt")
                            strTbleName = "Tblt_CasherPayed"
                        Case Else
                            MsgBox("يرجي أختيار أحد التقارير", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                            Exit Sub
                    End Select

                    If strReportNo = 34 Then
                        strDateType = "PayedDate"
                    End If

                    mySelectFormula = "{" & strTbleName & "." & strDateType & "} >=('" & FReportDate(DTPicker1.Value) & "') And {" & strTbleName & "." & strDateType & "} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If chkPartionCodeMain.Checked = False Then
                        If cmbPartionCodeMain.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartationCodeMain} =" & cmbPartionCodeMain.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartationCodeMain} in [" & strFGTreeSearch8 & "]"
                        End If
                    End If

                    If chkActivitiesCode.Checked = False Then
                        If cmbActivitiesCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ActivitiesCode} =" & cmbActivitiesCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ActivitiesCode} in [" & strFGTreeSearch9 & "]"
                        End If
                    End If
                    If chkPlaceCode.Checked = False Then
                        If cmbPlaceCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PlaceCode} =" & cmbPlaceCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PlaceCode} in [" & strFGTreeSearch10 & "]"
                        End If
                    End If

                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If chkAccountMenCode.Checked = False Then
                        If cmbAccountMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} =" & cmbAccountMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} in [" & strFGTreeSearch7 & "]"
                        End If
                    End If
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        If cmbPayState.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PayState} =" & cmbPayState.SelectedIndex
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PayState} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    '''''''''''' search by Name & Address
                    If chkNameSearch.Checked = False Then
                        If txtNameSearch.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Name} like ['*" & txtNameSearch.Text & "*']"
                        Else
                            'mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Name} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If chkAddSearch.Checked = False Then
                        If TxtAddSearch.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Address} like ['*" & TxtAddSearch.Text & "*']"
                        Else
                            'mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Address} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    '''''''''''' search by Name & Address

                    '''''''''by val
                    If txtValFrom.Text = "" And txtValTo.Text <> "" Then
                        mySelectFormula = mySelectFormula & " And {" & strTbleName & ".Total} <= (" & Val(txtValTo.Text) & ")"
                    ElseIf txtValFrom.Text <> "" And txtValTo.Text = "" Then
                        mySelectFormula = mySelectFormula & " And {" & strTbleName & ".Total} >= (" & Val(txtValFrom.Text) & ")"
                    ElseIf txtValFrom.Text <> "" And txtValTo.Text <> "" Then
                        mySelectFormula = mySelectFormula & " And {" & strTbleName & ".Total} >= (" & Val(txtValFrom.Text) & ") And {" & strTbleName & ".Total} <= (" & Val(txtValTo.Text) & ")"
                    ElseIf txtValFrom.Text = "" And txtValTo.Text = "" Then
                        ' do nothing
                    End If

                    '''''''''''''''''''''''''''''''''''''''' Rep Type
                    Dim strFormula, strHeadTemp As String
                    If GroupRepBands.Enabled = True Then
                        Call SSetFormula(strTbleName, strFormula, strHeadTemp)

                        mySelectFormula = mySelectFormula & " and (" & strFormula & ")"
                    End If
                    '''''''''''''''''''''''''''''''''''''''' Rep Type
                    objReport.DataDefinition.FormulaFields.Item("FFromDate").Text = "totext('" & FFormatDate2((DTPicker1.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FToDate").Text = "totext('" & FFormatDate2((DTPicker2.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FRepHead").Text = "totext('" & strHeadTemp & "')"
                    If chkShowAdd.Checked = True Then objReport.DataDefinition.FormulaFields.Item("ShowAddBol").Text = "totext('Yes')"
                    If chkActivitiesCode.Checked = False Then
                        objReport.DataDefinition.FormulaFields.Item("FPlaceCode").Text = "totext('" & cmbActivitiesCode.Text & "')"
                    Else
                        objReport.DataDefinition.FormulaFields.Item("FPlaceCode").Text = ""
                    End If
                Case "41", "42", "43"
                    strRepPath = strRepPath & "Rep Total\"
                    Dim strTbleName As String = "View_TranMain"

                    Select Case cmbRepNo.SelectedIndex
                        Case "0"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran20.rpt")
                        Case "1"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran21.rpt")
                        Case "2"
                            objReport.Load(strRepPath & "RepEnergyTheftsTran22.rpt")
                        Case Else
                            MsgBox("يرجي أختيار أحد التقارير", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                            Exit Sub
                    End Select

                    mySelectFormula = "{" & strTbleName & "." & strDateType & "} >=('" & FReportDate(DTPicker1.Value) & "') And {" & strTbleName & "." & strDateType & "} <= ('" & FReportDate(DTPicker2.Value) & "')"
                    If chkPartionCode.Checked = False Then
                        If cmbPartionCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartionCode} =" & cmbPartionCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartionCode} in [" & strFGTreeSearch & "]"
                        End If
                    End If
                    If ChkBranchCode.Checked = False Then
                        If CmbBranchCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".BranchCode} =" & CmbBranchCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".BranchCode} in [" & strFGTreeSearch2 & "]"
                        End If
                    End If
                    If chkPartionCodeMain.Checked = False Then
                        If cmbPartionCodeMain.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartationCodeMain} =" & cmbPartionCodeMain.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PartationCodeMain} in [" & strFGTreeSearch8 & "]"
                        End If
                    End If

                    If chkActivitiesCode.Checked = False Then
                        If cmbActivitiesCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ActivitiesCode} =" & cmbActivitiesCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ActivitiesCode} in [" & strFGTreeSearch9 & "]"
                        End If
                    End If
                    If chkPlaceCode.Checked = False Then
                        If cmbPlaceCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PlaceCode} =" & cmbPlaceCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PlaceCode} in [" & strFGTreeSearch10 & "]"
                        End If
                    End If

                    If ChkArtisticCode.Checked = False Then
                        If cmbArtisticCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ArtisticCode} =" & cmbArtisticCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".ArtisticCode} in [" & strFGTreeSearch3 & "]"
                        End If
                    End If
                    If ChkPoliceMenCode.Checked = False Then
                        If cmbPoliceMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} =" & cmbPoliceMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} in [" & strFGTreeSearch4 & "]"
                        End If
                    End If
                    ''''''''''''''''
                    If chkAccountMenCode.Checked = False Then
                        If cmbAccountMenCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} =" & cmbAccountMenCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PoliceMenCode} in [" & strFGTreeSearch7 & "]"
                        End If
                    End If
                    If ChkMabahsCode.Checked = False Then
                        If cmbMabahsCode.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".MabahsCode} =" & cmbMabahsCode.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".MabahsCode} in [" & strFGTreeSearch5 & "]"
                        End If
                    End If
                    If ChkUserID.Checked = False Then
                        If cmbUserID.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".UserId} =" & cmbUserID.SelectedValue
                        Else
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".UserId} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If ChkPayState.Checked = False Then
                        If cmbPayState.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PayState} =" & cmbPayState.SelectedIndex
                        Else
                            'mySelectFormula = mySelectFormula & " and {" & strTbleName & ".PayState} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    '''''''''''' search by Name & Address
                    If chkNameSearch.Checked = False Then
                        If txtNameSearch.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Name} like ['*" & txtNameSearch.Text & "*']"
                        Else
                            'mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Name} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    If chkAddSearch.Checked = False Then
                        If TxtAddSearch.Enabled = True Then
                            mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Address} like ['*" & TxtAddSearch.Text & "*']"
                        Else
                            'mySelectFormula = mySelectFormula & " and {" & strTbleName & ".Name} in [" & strFGTreeSearch6 & "]"
                        End If
                    End If
                    '''''''''''' search by Name & Address

                    '''''''''''''''''''''''''''''''''''''''' Rep Type
                    Dim strFormula, strHeadTemp As String
                    Call SSetFormula(strTbleName, strFormula, strHeadTemp)

                    mySelectFormula = mySelectFormula & " and (" & strFormula & ")"
                    '''''''''''''''''''''''''''''''''''''''' Rep Type
                    objReport.DataDefinition.FormulaFields.Item("FFromDate").Text = "totext('" & FFormatDate2((DTPicker1.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FToDate").Text = "totext('" & FFormatDate2((DTPicker2.Value)) & "')"
                    objReport.DataDefinition.FormulaFields.Item("FRepHead").Text = "totext('" & strHeadTemp & "')"
                    If chkActivitiesCode.Checked = False Then
                        objReport.DataDefinition.FormulaFields.Item("FPlaceCode").Text = "totext('" & cmbActivitiesCode.Text & "')"
                    Else
                        objReport.DataDefinition.FormulaFields.Item("FPlaceCode").Text = ""
                    End If
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

    Private Sub SSetFormula(strTbleName As String, ByRef strFormula As String, ByRef strHeadTemp As String)
        Try
            Dim mySelectFormulaTemp As New List(Of String)
            Dim strFrmHead As New List(Of String)

            If chkThefts.Checked = True Then mySelectFormulaTemp.Add("{" & strTbleName & ". DocType} =1") : strFrmHead.Add("السرقات")  'السرقات
            If chkTheftsDisagreed.Checked = True Then mySelectFormulaTemp.Add("{" & strTbleName & ". DocType} =2") : strFrmHead.Add("المخالفات")   'المخالفات
            If chkTheftsZaina.Checked = True Then mySelectFormulaTemp.Add("{" & strTbleName & ". DocType} =3") : strFrmHead.Add("الزينة")   'الزينة
            ''
            If chkThefts2.Checked = True Then mySelectFormulaTemp.Add("{" & strTbleName & ". DocType} =4") : strFrmHead.Add("الضبطية")   'الضبطية
            If chkThefts2Disagreed.Checked = True Then mySelectFormulaTemp.Add("{" & strTbleName & ". DocType} =5") : strFrmHead.Add("المخالفات")   'المخالفات
            If chkTheftsZainaSecond.Checked = True Then mySelectFormulaTemp.Add("{" & strTbleName & ". DocType} =6") : strFrmHead.Add("الزينة")   'الزينة

            'Dim strTemp As String = ""
            'Dim strHeadTemp As String = ""

            For i As Integer = 0 To mySelectFormulaTemp.Count - 1
                If i = 0 Then
                    strFormula = mySelectFormulaTemp(i).ToString
                    strHeadTemp = strFrmHead(i).ToString
                ElseIf i > 0 Then
                    strFormula = strFormula & " OR " & mySelectFormulaTemp(i).ToString
                    strHeadTemp = strHeadTemp & " و " & strFrmHead(i).ToString
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged, chkPartionCode.CheckedChanged, ChkBranchCode.CheckedChanged, chkPartionCodeMain.CheckedChanged, ChkArtisticCode.CheckedChanged, ChkPoliceMenCode.CheckedChanged, chkAccountMenCode.CheckedChanged, ChkMabahsCode.CheckedChanged, ChkUserID.CheckedChanged, ChkPayState.CheckedChanged, chkNameSearch.CheckedChanged, chkAddSearch.CheckedChanged, chkActivitiesCode.CheckedChanged, chkPlaceCode.CheckedChanged
        Select Case DirectCast(sender, CheckBox).Name
            Case chkAll.Name
                chkPartionCode.Checked = chkAll.Checked
                ChkBranchCode.Checked = chkAll.Checked
                chkPartionCodeMain.Checked = chkAll.Checked
                ChkArtisticCode.Checked = chkAll.Checked
                ChkPoliceMenCode.Checked = chkAll.Checked
                chkAccountMenCode.Checked = chkAll.Checked
                ChkMabahsCode.Checked = chkAll.Checked
                ChkUserID.Checked = chkAll.Checked
                ChkPayState.Checked = chkAll.Checked
                chkNameSearch.Checked = chkAll.Checked
                chkAddSearch.Checked = chkAll.Checked
                chkActivitiesCode.Checked = chkAll.Checked
                chkPlaceCode.Checked = chkAll.Checked
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
            Case chkPartionCodeMain.Name
                If chkPartionCodeMain.Checked = True Then
                    lblPartionCodeMain.Enabled = False : cmbPartionCodeMain.Enabled = False : cmdPartionCodeMain.Enabled = False
                Else
                    lblPartionCodeMain.Enabled = True : cmbPartionCodeMain.Enabled = True : cmdPartionCodeMain.Enabled = True
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
            Case chkAccountMenCode.Name
                If chkAccountMenCode.Checked = True Then
                    lblAccountMenCode.Enabled = False : cmbAccountMenCode.Enabled = False : cmdAccountMenCode.Enabled = False
                Else
                    lblAccountMenCode.Enabled = True : cmbAccountMenCode.Enabled = True : cmdAccountMenCode.Enabled = True
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
            Case chkNameSearch.Name
                If chkNameSearch.Checked = True Then
                    lblNameSearch.Enabled = False : txtNameSearch.Enabled = False
                Else
                    lblNameSearch.Enabled = True : txtNameSearch.Enabled = True
                End If
            Case chkAddSearch.Name
                If chkAddSearch.Checked = True Then
                    lblAddSearch.Enabled = False : TxtAddSearch.Enabled = False
                Else
                    lblAddSearch.Enabled = True : TxtAddSearch.Enabled = True
                End If
            Case chkActivitiesCode.Name
                If chkActivitiesCode.Checked = True Then
                    LblActivitiesCode.Enabled = False : cmdActivitiesCode.Enabled = False : cmbActivitiesCode.Enabled = False
                Else
                    LblActivitiesCode.Enabled = True : cmdActivitiesCode.Enabled = True : cmbActivitiesCode.Enabled = True
                End If
            Case chkPlaceCode.Name
                If chkPlaceCode.Checked = True Then
                    lblPlaceCode.Enabled = False : cmdPlaceCode.Enabled = False : cmbPlaceCode.Enabled = False
                Else
                    lblPlaceCode.Enabled = True : cmdPlaceCode.Enabled = True : cmbPlaceCode.Enabled = True
                End If
        End Select
    End Sub

    Private Sub cmdCodeBrowse_Click(sender As Object, e As EventArgs) Handles cmdPartionCodeBrowse.Click, cmdBranchCode.Click, cmdPartionCodeMain.Click, cmdArtisticCode.Click, cmdPoliceMenCode.Click, cmdAccountMenCode.Click, cmdMabahsCode.Click, cmdUserID.Click, cmdActivitiesCode.Click, cmdPlaceCode.Click 
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
            Case cmdPartionCodeMain.Name
                If lblPartionCodeMain.Enabled = False Then
                    lblPartionCodeMain.Enabled = True : cmbPartionCodeMain.Enabled = True
                Else
                    lblPartionCodeMain.Enabled = False : cmbPartionCodeMain.Enabled = False
                    strFGTreeSearch8 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_PartionCode", "ID", , "Type=0", "بيانات القطاعات", False, False, "ID",, SearchReturnType.Number)
                End If
            Case cmdActivitiesCode.Name
                If LblActivitiesCode.Enabled = False Then
                    LblActivitiesCode.Enabled = True : cmbActivitiesCode.Enabled = True
                Else
                    LblActivitiesCode.Enabled = False : cmbActivitiesCode.Enabled = False
                    strFGTreeSearch9 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_ActivitiesCode", "ID", , , "بيانات القطاعات", False, False, "ID",, SearchReturnType.Number)
                End If
            Case cmdPlaceCode.Name
                If lblPlaceCode.Enabled = False Then
                    lblPlaceCode.Enabled = True : cmbPlaceCode.Enabled = True
                Else
                    lblPlaceCode.Enabled = False : cmbPlaceCode.Enabled = False
                    strFGTreeSearch10 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_PlaceCode", "ID", , , "بيانات القطاعات", False, False, "ID",, SearchReturnType.Number)
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
            Case cmdAccountMenCode.Name
                If lblAccountMenCode.Enabled = False Then
                    lblAccountMenCode.Enabled = True : cmbAccountMenCode.Enabled = True
                Else
                    lblAccountMenCode.Enabled = False : cmbAccountMenCode.Enabled = False
                    strFGTreeSearch7 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_AccountMenCode", "ID", , "", "بيانات مندوبى الضبط القضائي", False, False, "ID",, SearchReturnType.Number)
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
                    strFGTreeSearch6 = FTreeSearch(TreeBranches.SingleBranch, "Tblc_UserCode", "ID", , , "اكواد المستخدمين", False, False, "ID", "UserName", SearchReturnType.Number)
                End If
        End Select
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles OptType1.CheckedChanged, OptType2.CheckedChanged, OptType3.CheckedChanged
        If OptType3.Checked = True Then
            Call SFillCombo(cmbPartionCode, "Tblc_PartionCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
            Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "", False, "", ComboLoadItemSelect.Min)
        Else
            Call SLoadTypeCombox()
        End If
    End Sub

    Private Sub SLoadTypeCombox()
        Dim intType As Integer = IIf(OptType1.Checked = True, 1, 0)
        Call SFillCombo(cmbPartionCode, "Tblc_PartionCode", "ID", "Name", "Type=" & intType, False, "", ComboLoadItemSelect.Min)
        If cmbPartionCode.Items.Count > 0 Then
            Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
        Else
            CmbBranchCode.DataSource = Nothing
            CmbBranchCode.DisplayMember = Nothing
            CmbBranchCode.Items.Clear()
        End If
    End Sub

    Private Sub cmbPartionCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPartionCode.SelectedIndexChanged
        If Not IsNothing(cmbPartionCode.SelectedValue) Then
            Call SFillCombo(CmbBranchCode, "Tblc_MainBranchCode", "ID", "Name", "PartationCode=" & cmbPartionCode.SelectedValue, False, "", ComboLoadItemSelect.Min)
            CmbBranchCode.Enabled = True
        End If
    End Sub

    Private Function FCheckRepOpen() As Boolean
        Try
            If chkPartionCode.Checked = False Then
                If cmbPartionCode.Enabled = True Then
                    If IsNothing(cmbPartionCode.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد القطاعات", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf cmbPartionCode.Enabled = False And cmdPartionCodeBrowse.Enabled = True Then
                    If IsNothing(strFGTreeSearch) Or strFGTreeSearch = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة القطاعات", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            If ChkBranchCode.Checked = False Then
                If CmbBranchCode.Enabled = True Then
                    If IsNothing(CmbBranchCode.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد الإدارات", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf CmbBranchCode.Enabled = False And cmdBranchCode.Enabled = True Then
                    If IsNothing(strFGTreeSearch2) Or strFGTreeSearch2 = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة الإدارات", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            If chkPartionCodeMain.Checked = False Then
                If cmbPartionCodeMain.Enabled = True Then
                    If IsNothing(cmbPartionCodeMain.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد القطاعات التجارية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf cmbPartionCodeMain.Enabled = False And cmdPartionCodeMain.Enabled = True Then
                    If IsNothing(strFGTreeSearch8) Or strFGTreeSearch8 = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة القطاعات التجارية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            If ChkArtisticCode.Checked = False Then
                If cmbArtisticCode.Enabled = True Then
                    If IsNothing(cmbArtisticCode.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد الفنيين", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf cmbArtisticCode.Enabled = False And cmdArtisticCode.Enabled = True Then
                    If IsNothing(strFGTreeSearch3) Or strFGTreeSearch3 = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة الفنيين", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            If ChkPoliceMenCode.Checked = False Then
                If cmbPoliceMenCode.Enabled = True Then
                    If IsNothing(cmbPoliceMenCode.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد مندوبي الشرطة", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf cmbPoliceMenCode.Enabled = False And cmdPoliceMenCode.Enabled = True Then
                    If IsNothing(strFGTreeSearch4) Or strFGTreeSearch4 = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة مندوبي الشرطة", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            If chkAccountMenCode.Checked = False Then
                If cmbAccountMenCode.Enabled = True Then
                    If IsNothing(cmbAccountMenCode.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد مندوبي الضبط القضائي", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf cmbAccountMenCode.Enabled = False And cmdAccountMenCode.Enabled = True Then
                    If IsNothing(strFGTreeSearch7) Or strFGTreeSearch7 = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة  مندوبي الضبط القضائي", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            ''''''''''''''''
            If ChkMabahsCode.Checked = False Then
                If cmbMabahsCode.Enabled = True Then
                    If IsNothing(cmbMabahsCode.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد وحدات المباحث", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf cmbMabahsCode.Enabled = False And cmdMabahsCode.Enabled = True Then
                    If IsNothing(strFGTreeSearch5) Or strFGTreeSearch5 = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة  وحدات المباحث", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            If ChkUserID.Checked = False Then
                If cmbUserID.Enabled = True Then
                    If IsNothing(cmbUserID.SelectedValue) Then
                        MsgBox("يرجي أختيار أحد المستخدمين", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                ElseIf cmbUserID.Enabled = False And cmdUserID.Enabled = True Then
                    If IsNothing(strFGTreeSearch6) Or strFGTreeSearch6 = "" Then
                        MsgBox("يرجي أختيار أحد بنود شجرة المستخدمين", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        Return False
                    End If
                End If
            End If
            If ChkPayState.Checked = False Then
                If IsNothing(cmbUserID.SelectedIndex) Then
                    MsgBox("يرجي أختيار أحد حالات السداد", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    Return False
                End If
            End If
            If GroupRepBands.Enabled = True Then
                If chkThefts.Checked = False And chkThefts2.Checked = False And chkTheftsZaina.Checked = False And chkTheftsDisagreed.Checked = False And chkThefts2Disagreed.Checked = False And chkTheftsZainaSecond.Checked = False Then
                    MsgBox("يرجي أختيار أحد بنود التقرير", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmbRepNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRepNo.SelectedIndexChanged

        Select Case strReportType
            Case ReportType.DetailsReports
                Select Case cmbRepNo.SelectedIndex
                    Case "0"
                        strReportNo = "31"
                        strReportName = cmbRepNo.SelectedIndex.ToString
                        '
                        cmbDateType.Enabled = True : Label3.Enabled = True ' نوع التاريخ
                        chkShowAdd.Enabled = True  ' إظهار العنوان
                    Case "1"
                        strReportNo = "32"
                        strReportName = cmbRepNo.SelectedIndex.ToString
                        '
                        cmbDateType.Enabled = True : Label3.Enabled = True ' نوع التاريخ
                        chkShowAdd.Enabled = True  ' إظهار العنوان
                    Case "2"
                        strReportNo = "33"
                        strReportName = cmbRepNo.SelectedIndex.ToString
                        '
                        cmbDateType.Enabled = True : Label3.Enabled = True ' نوع التاريخ
                        chkShowAdd.Enabled = True  ' إظهار العنوان
                    Case "5"
                        strReportNo = "34"
                        strReportName = cmbRepNo.SelectedIndex.ToString
                        '
                        GroupRepBands.Enabled = False
                        cmbDateType.Enabled = False : Label3.Enabled = False ' نوع التاريخ
                        chkShowAdd.Enabled = False ' إظهار العنوان
                End Select
            Case ReportType.TotalReports
                Select Case cmbRepNo.SelectedIndex
                    Case "0"
                        strReportNo = "41"
                        chkThefts.Enabled = True : chkTheftsDisagreed.Enabled = True : chkTheftsZaina.Enabled = True
                    Case "1"
                        strReportNo = "42"
                        chkThefts.Enabled = True : chkTheftsDisagreed.Enabled = True : chkTheftsZaina.Enabled = True
                    Case "2"
                        strReportNo = "43"
                        chkThefts.Enabled = False : chkTheftsDisagreed.Enabled = False : chkTheftsZaina.Enabled = False
                End Select
        End Select


    End Sub

End Class