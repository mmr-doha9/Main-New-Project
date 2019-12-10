Imports System.ComponentModel
Imports System.Text
Imports Microsoft.Win32

Public Class Mdi

    'Implements IMessageFilter    'This interface allows an application to capture a message before it is dispatched to a control or form.
    Public bolMainStop As Boolean = False '
    Public RecUser As RegistryKey = Registry.CurrentUser.CreateSubKey("RecUser")

    Private Sub MdiForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = New Bitmap(Application.StartupPath & "/Pic/Main2.jpg", True)
        Me.BackgroundImageLayout = ImageLayout.Stretch

        If DataType = DataConnection.SqlServer Then OpenSqlConnection() Else OpenAccessConnection()
        Call SDisableMenu()
        'strUserID = RecUser.GetValue("UserID") : strUserPassword = RecUser.GetValue("UserPass") : strUserName = FGetFeildValues("Tblc_UserCode", "UserName", "ID='" & strUserID & "'") : strUserType = FGetFeildValues("Tblc_UserCode", "UserType", "ID='" & strUserID & "'")
        'If EnterUsers(strUserID, strUserPassword) = True Then
        '    Call SSetUserPer(strUserID)
        'End If
        bolDemo = False  'false نسخة كاملة  true  نسخة للعرض
        Label2.Text = ToHijra(Now, "dddd, d MMMM yyyy")
        Label3.Text = "" 'FormatDateTime(Now, DateFormat.LongDate)
        lblPCName.Text = " أسم الجهاز : " & FGetComputerName()
        'lblTime.Caption = FormatDateTime(Now, DateFormat.ShortTime)
        Label1.Text = strServerName
        Dim strTag As String = CType(IIf(DataType = DataConnection.Access, " / Access", " / SQLSERVER"), String)
        Me.Text = ProgName & strTag
        Call FMakeBackUP(False)
    End Sub

    Private Sub mnuPartionCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPartionCode.Click
        SClickSound()
        Dim frmNew As New frmPartionCode
        frmNew.Show()
    End Sub

    Private Sub mnuMainBranchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainBranchCode.Click
        SClickSound()
        Dim frmNew As New frmMainBranchCode
        frmNew.Show()
    End Sub
    ''' ''''''Main Bar
    ''' 
    Private Sub mnuNew_Click(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SAddNew()
        End If
    End Sub

    Private Sub cmdOpen_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SOpen()
        End If
    End Sub

    Private Sub cmdSave_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SUpdate()
        End If
    End Sub

    Private Sub cmdDelete_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SDelete()
        End If
    End Sub

    Private Sub cmdPrevios_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SMovePrevious()
        End If
    End Sub

    Private Sub cmdNext_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SMoveNext()
        End If
    End Sub

    Private Sub cmdLast_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SMoveLast()
        End If
    End Sub

    Private Sub cmdPreview_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SShowPrint()
        End If
    End Sub

    Private Sub cmdPrint_ItemClick(sender As Object, e As EventArgs)
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SPrintReport()
        End If
    End Sub

    ''''''Main Bar

    Private Sub mnuBasic8_Click(sender As Object, e As EventArgs) Handles mnuBasic8.Click
        SClickSound()
        Dim frmNew As New frmAccountMenCode(loadType.Mdi)
        frmNew.Show()
    End Sub

    Private Sub mnuBasic3_Click(sender As Object, e As EventArgs) Handles mnuBasic3.Click
        SClickSound()
        Dim frmNew As New frmActivities
        frmNew.Show()
    End Sub

    Private Sub mnuBasic4_Click(sender As Object, e As EventArgs) Handles mnuBasic4.Click

    End Sub

    Private Sub mnuBasic5_Click(sender As Object, e As EventArgs) Handles mnuBasic5.Click
        SClickSound()
        Dim frmNew As New frmPlaceCode(loadType.Mdi)
        frmNew.Show()
    End Sub

    Private Sub mnuBasic6_Click(sender As Object, e As EventArgs) Handles mnuBasic6.Click
        SClickSound()
        Dim frmNew As New frmMabahsCode(loadType.Mdi)
        frmNew.Show()
    End Sub

    Private Sub Exitmnu_Click(sender As Object, e As EventArgs) Handles Exitmnu.Click
        If strUserID <> "" Then FEditeRecord("Tblc_UserCode", "ID", strUserID, {"LoginState"}, {"0"})
        CON.Close()
        End
    End Sub

    Private Sub mnuBasic7_Click(sender As Object, e As EventArgs) Handles mnuBasic7.Click
        SClickSound()
        Dim frmNew As New frmPoliceMenCode(loadType.Mdi)
        frmNew.Show()
    End Sub

    Private Sub mnuBasic9_Click(sender As Object, e As EventArgs) Handles mnuBasic9.Click
        SClickSound()
        Dim frmNew As New frmPoliceHouse
        frmNew.Show()
    End Sub

    Private Sub mnuBasic10_Click(sender As Object, e As EventArgs) Handles mnuBasic10.Click
        SClickSound()
        Dim frmNew As New frmArtisticCode(loadType.Mdi)
        frmNew.Show()
    End Sub

    Private Sub mnuBasic11_Click(sender As Object, e As EventArgs) Handles mnuBasic11.Click
        SClickSound()
        Dim frmNew As New frmEnergyDevices(loadType.Mdi)
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyThefts_Click(sender As Object, e As EventArgs) Handles mnuEnergyThefts.Click
        SClickSound()
        Dim frmNew As New frmEnergyThefts("Tblt_EnergyThefts", "سرقات التيار", mnuEnergyThefts.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyTheftsPay_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsPay.Click
        SClickSound()
        Dim frmNew As New frmPayed()
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyDabtya_Click(sender As Object, e As EventArgs) Handles mnuEnergyDabtya.Click
        SClickSound()
        Dim frmNew As New frmEnergyThefts("Tblt_EnergyTheftsSecond", "الضبطية القضائية", mnuEnergyDabtya.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyDabtyaPay_Click(sender As Object, e As EventArgs) Handles mnuEnergyDabtyaPay.Click
        SClickSound()
        Dim frmNew As New frmPayed()
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyDevicesCode_Click(sender As Object, e As EventArgs) Handles mnuEnergyDevicesCode.Click
        SClickSound()
        Dim frmNew As New frmBasicDataRep("01", sender.text)
        frmNew.Show()
    End Sub

    Private Sub mnuBranchCode_Click(sender As Object, e As EventArgs) Handles mnuBranchCode.Click
        SClickSound()
        Dim frmNew As New frmBasicDataRep("02", sender.text)
        frmNew.Show()
    End Sub

    Private Sub mnuPlaceCode_Click(sender As Object, e As EventArgs) Handles mnuPlaceCode.Click
        SClickSound()
        Dim frmNew As New frmBasicDataRep("03", sender.text)
        frmNew.Show()
    End Sub

    'Private Sub mnuEnergyTheftsRep1_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsRep1.Click
    '    SClickSound()
    '    Dim frmNew As New frmEnergyTheftsRep("01", sender.text)
    '    frmNew.Show()
    'End Sub

    'Private Sub mnuEnergyTheftsRep2_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsRep2.Click
    '    SClickSound()
    '    Dim frmNew As New frmEnergyTheftsRep("02", sender.text)
    '    frmNew.Show()
    'End Sub

    'Private Sub mnuEnergyTheftsRep3_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsRep3.Click
    '    SClickSound()
    '    Dim frmNew As New frmEnergyTheftsRep("03", sender.text)
    '    frmNew.Show()
    'End Sub

    'Private Sub mnuEnergyTheftsSecondRep1_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsSecondRep1.Click
    '    SClickSound()
    '    Dim frmNew As New frmEnergyTheftsRep("21", sender.text)
    '    frmNew.Show()
    'End Sub

    'Private Sub mnuEnergyTheftsSecondRep2_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsSecondRep2.Click
    '    SClickSound()
    '    Dim frmNew As New frmEnergyTheftsRep("22", sender.text)
    '    frmNew.Show()
    'End Sub

    'Private Sub mnuEnergyTheftsSecondRep3_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsSecondRep3.Click
    '    SClickSound()
    '    Dim frmNew As New frmEnergyTheftsRep("23", sender.text)
    '    frmNew.Show()
    'End Sub

    Private Sub mnuAddUser_Click(sender As Object, e As EventArgs) Handles mnuAddUser.Click
        SClickSound()
        frmAddUser.Show()
    End Sub

    Private Sub mnuUserPer_Click(sender As Object, e As EventArgs) Handles mnuUserPer.Click
        SClickSound()
        frmUserPer.Show()
    End Sub

    Private Sub Mdi_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'If Not IsNothing(strUserID) Then FInsertVal("Tblc_UserCode", "LoginState", "0", "ID=" & strUserID, False)
        If strUserID <> "" Then FEditeRecord("Tblc_UserCode", "ID", strUserID, {"LoginState"}, {"0"})
        CON.Close()
        End
    End Sub

    Private Sub mnuOption_Click(sender As Object, e As EventArgs) Handles mnuOption.Click
        SClickSound()
        frmPassword.ShowDialog()
    End Sub

    Private Sub mnuLogin_Click(sender As Object, e As EventArgs) Handles mnuLogin.Click
        SClickSound()
        frmLogin.Show()
    End Sub

    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        SClickSound()
        For Each frm In Me.MdiChildren
            frm.Close()
        Next
        Call FEditeRecord("Tblc_UserCode", "ID", strUserID, {"LoginState", "lastTimeConnect"}, {"0", FFormatDateTimeFormat(Now)})
        Call SDisableMenu()
        Me.mnuLogin.Enabled = True
        Label4.Text = "قم بتسجيل الدخول"
        UserMsg.Enabled = False
        frmUserMsg.Close()
        Me.BackgroundImage = New Bitmap(Application.StartupPath & "/Pic/Main2.jpg", True)
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call FSetTransaction(TransactionType.logOut, "", "0") ' transactions save
        MnuLock.Enabled = False
    End Sub

    Private Sub mnuDisagreed_Click(sender As Object, e As EventArgs) Handles mnuDisagreed.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_Disagreed", "مخالفة شروط التعاقد", mnuDisagreed.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuDisagreedSecond_Click(sender As Object, e As EventArgs) Handles mnuDisagreedSecond.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_DisagreedSecond", "مخالفة شروط التعاقد", mnuDisagreedSecond.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuTranRep1_Click(sender As Object, e As EventArgs) Handles mnuTranRep1.Click
        SClickSound()
        Dim frmNew As New frmEnergyTheftsRep(frmEnergyTheftsRep.ReportType.DetailsReports)
        frmNew.Show()
    End Sub

    Private Sub mnuBasic12_Click(sender As Object, e As EventArgs) Handles mnuBasic12.Click
        SClickSound()
        Dim frmNew As New frmEmployeeCode(loadType.Mdi)
        frmNew.Show()
    End Sub

    Private Sub mnuTranRep11_Click(sender As Object, e As EventArgs) Handles mnuTranRep11.Click
        SClickSound()
        Dim frmNew As New frmEnergyTheftsRep(frmEnergyTheftsRep.ReportType.TotalReports)
        frmNew.Show()
    End Sub

    Private Sub mnuZaina_Click(sender As Object, e As EventArgs) Handles mnuZaina.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_Zaina", "شاشة الزينة - مباحث الكهرباء", mnuZaina.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuZainaSecond_Click(sender As Object, e As EventArgs) Handles mnuZainaSecond.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_ZainaSecond", "شاشة الزينة - مباحث الكهرباء", mnuZainaSecond.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub mnuAbout2_Click(sender As Object, e As EventArgs) Handles mnuAbout2.Click
        frmAbout2.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If BackgroundWorker1.CancellationPending Then
                e.Cancel = True
                BackgroundWorker1.ReportProgress(100, "Cancelled.")
            End If
            ''''
            If strUserID <> "" Then
                Call FEditeRecord("Tblc_UserCode", "ID", strUserID, {"LoginState", "lastTimeConnect"}, {"1", FFormatDateTimeFormat(Now)})
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Label1.Text = CType(e.UserState, String)
        'Label2.Text = " تم تحميل  " & e.ProgressPercentage.ToString & "  %  "
        'If BackgroundWorker1.CancellationPending Then
        '    'BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Cancelling...")
        '    'Exit For
        'End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            'هل انتهى backgroundWORKER بخطأ:'MessageBox.Show(e.Error.Message):'Label1.Text = "حدثت مشكلة أثناء التحميل!"
        ElseIf e.Cancelled Then
            'فى حالة اغلاقه   'MessageBox.Show("Task cancelled!")  'Label1.Text = "تم إلغاء التحميل! - " & Now.ToShortTimeString
        Else
            BackgroundWorker1.Dispose()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            BackgroundWorker1.RunWorkerAsync()
            Application.DoEvents()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MnuLock_Click(sender As Object, e As EventArgs) Handles MnuLock.Click
        frmLockScreen.ShowDialog()
    End Sub

    Private Sub mnuEnergyTheftsRep1_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsRep1.Click
        'SClickSound()
        'Dim frmNew As New frmEnergyTheftsRep("01", sender.text)
        'frmNew.Show()
    End Sub

    Private Sub mnuDashBoard_Click(sender As Object, e As EventArgs) Handles mnuDashBoard.Click
        SClickSound()
        Dim frmNew As New frmDashBoard("View_UserTransaction", "Date='" & FFormatDate(Now.Date) & "'")
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyTheftsManual_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsManual.Click
        SClickSound()
        Dim frmNew As New frmEnergyThefts("Tblt_EnergyThefts", "سرقات التيار", mnuEnergyThefts.Tag, typeCalc.Manual)
        frmNew.Show()
    End Sub

    Private Sub mnuDisagreedManual_Click(sender As Object, e As EventArgs) Handles mnuDisagreedManual.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_Disagreed", "مخالفة شروط التعاقد", mnuDisagreed.Tag, typeCalc.Manual)
        frmNew.Show()
    End Sub

    Private Sub mnuZainaManual_Click(sender As Object, e As EventArgs) Handles mnuZainaManual.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_Zaina", "شاشة الزينة - مباحث الكهرباء", mnuZaina.Tag, typeCalc.Manual)
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyDabtyaManual_Click(sender As Object, e As EventArgs) Handles mnuEnergyDabtyaManual.Click
        SClickSound()
        Dim frmNew As New frmEnergyThefts("Tblt_EnergyTheftsSecond", "الضبطية القضائية", mnuEnergyDabtya.Tag, typeCalc.Manual)
        frmNew.Show()
    End Sub

    Private Sub mnuDisagreedSecondManual_Click(sender As Object, e As EventArgs) Handles mnuDisagreedSecondManual.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_DisagreedSecond", "مخالفة شروط التعاقد", mnuDisagreedSecond.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuZainaSecondManual_Click(sender As Object, e As EventArgs) Handles mnuZainaSecondManual.Click
        SClickSound()
        Dim frmNew As New frmDisagreed("Tblt_ZainaSecond", "شاشة الزينة - مباحث الكهرباء", mnuZainaSecond.Tag)
        frmNew.Show()
    End Sub

    Private Sub mnuCasherOrder_Click(sender As Object, e As EventArgs) Handles mnuCasherOrder.Click
        SClickSound()
        'Dim frmNew As New frmCasherOrder()
        frmCasherOrder.Show()
    End Sub

    Private Sub mnuPaymentNotification_Click(sender As Object, e As EventArgs) Handles mnuPaymentNotification.Click
        SClickSound()
        Dim frmNew As New frmPaymentNotification
        frmNew.Show()
    End Sub

    Private Sub mnuChangePassword_Click(sender As Object, e As EventArgs) Handles mnuChangePassword.Click
        SClickSound()
        Dim frmNew As New frmMustChangePassword(1)
        frmNew.ShowDialog()
    End Sub

    Private Sub mnuPayedTmp_Click(sender As Object, e As EventArgs) Handles mnuPayedTmp.Click
        Dim frmNew As New frmPayedTmp
        frmNew.Show()
    End Sub

    ''''''''''''''''''''
    '''' <summary>
    '''' Filters out a message before it is dispatched.
    '''' </summary>
    '''' <param name="m">The message to be dispatched. You cannot modify this message.</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage

    '    'Check for mouse movements and / or clicks
    '    Dim mouse As Boolean = (m.Msg >= &H200 And m.Msg <= &H20D) Or (m.Msg >= &HA0 And m.Msg <= &HAD)

    '    'Check for keyboard button presses
    '    Dim kbd As Boolean = (m.Msg >= &H100 And m.Msg <= &H109)

    '    If mouse Or kbd Then 'if any of these events occur
    '        'If Not TimerLockScreen.Enabled Then MessageBox.Show("Waking up") 'wake up 
    '        If bolMainStop = False Then
    '            TimerLockScreen.Enabled = False
    '            TimerLockScreen.Enabled = True
    '            'TimerLockScreen.Stop()
    '            'TimerLockScreen.Start()
    '        End If
    '    End If
    'End Function

    'Private Sub mdi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    TimerLockScreen.Stop()
    '    TimerLockScreen.Start()
    'End Sub


    'Private Sub mdi_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '    TimerLockScreen.Stop()
    '    TimerLockScreen.Start()
    'End Sub

    'Private Sub mdi_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
    '    TimerLockScreen.Stop()
    '    TimerLockScreen.Start()
    'End Sub

    'Private Sub TimerLockScreen_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerLockScreen.Tick
    '    'MsgBox("Been idle for to long") 'I just have the program exiting, though you could have it do whatever you want.
    'End Sub

    'Private Sub TimerLockScreen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLockScreen.Tick

    '    'Static SecondsCount As Integer 'Counts each second
    '    'SecondsCount += 1 'Increment

    '    'If SecondsCount > 10 Then 'Two minutes have passed since being active
    '    '    TimerLockScreen.Enabled = False
    '    '    'MessageBox.Show("Program has been inactive for 2 minutes.... Exiting Now.... Cheers!")
    '    '    'Application.Exit()
    '    '    bolMainStop = True
    '    '    'TimerLockScreen.Enabled = False
    '    '    TimerLockScreen.Stop()
    '    '    Dim frmNew As New frmLockScreen()
    '    '    frmNew.ShowDialog()

    '    'End If
    'End Sub

End Class
