Imports System.ComponentModel
Imports System.Text
Imports Microsoft.Win32
Public Class Mdi
    Public RecUser As RegistryKey = Registry.CurrentUser.CreateSubKey("RecUser")

    Private Sub MdiForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = New Bitmap(Application.StartupPath & "/Pic/Main.jpg", True)
        Me.BackgroundImageLayout = ImageLayout.Stretch

        If DataType = DataConnection.SqlServer Then OpenSqlConnection() Else OpenAccessConnection()
        Call SDisableMenu()
        strUserID = RecUser.GetValue("UserID") : strUserPassword = RecUser.GetValue("UserPass") : strUserName = FGetFeildValues("Tblc_UserCode", "UserName", "UserCode='" & strUserID & "'") : strUserType = FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'")
        If EnterUsers(strUserID, strUserPassword) = True Then
            Call SSetUserPer(strUserID)
        End If
        bolDemo = False  'false نسخة كاملة  true  نسخة للعرض
        Label2.Text = ToHijra(Now, "dddd, d MMMM yyyy")
        Label3.Text = FormatDateTime(Now, DateFormat.LongDate)
        'lblTime.Caption = FormatDateTime(Now, DateFormat.ShortTime)
        Label1.Text = strServerName
        Dim strTag As String = CType(IIf(DataType = DataConnection.Access, " / Access", " / SQLSERVER"), String)
        Me.Text = ProgName & strTag
        'Call FMakeBackUP()
    End Sub

    Private Sub mnuLogin_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuLogout_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuAddUser_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuUserPer_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuOption_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuBranchsCode_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuAdminControl_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuCancelAdminControl_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SendMsgMnu_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuChangeMonth_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs)

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
    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SAddNew()
        End If
    End Sub

    Private Sub cmdOpen_ItemClick(sender As Object, e As EventArgs) Handles mnuOpen.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SOpen()
        End If
    End Sub

    Private Sub cmdSave_ItemClick(sender As Object, e As EventArgs) Handles mnuSave.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SUpdate()
        End If
    End Sub

    Private Sub cmdDelete_ItemClick(sender As Object, e As EventArgs) Handles mnuDel.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SDelete()
        End If
    End Sub

    Private Sub cmdPrevios_ItemClick(sender As Object, e As EventArgs) Handles mnuPrevios.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SMovePrevious()
        End If
    End Sub

    Private Sub cmdNext_ItemClick(sender As Object, e As EventArgs) Handles mnuNext.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SMoveNext()
        End If
    End Sub

    Private Sub cmdLast_ItemClick(sender As Object, e As EventArgs) Handles mnuLast.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SMoveLast()
        End If
    End Sub

    Private Sub cmdPreview_ItemClick(sender As Object, e As EventArgs) Handles mnuPreview.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SShowPrint()
        End If
    End Sub

    Private Sub cmdPrint_ItemClick(sender As Object, e As EventArgs) Handles mnuPrint.Click
        SClickSound()
        If ActiveMdiChild IsNot Nothing Then
            DirectCast(Me.ActiveMdiChild, IFormMainFunction).SPrintReport()
        End If
    End Sub

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

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
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
        Dim frmNew As New frmEnergyDevices
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyThefts_Click(sender As Object, e As EventArgs) Handles mnuEnergyThefts.Click
        SClickSound()
        Dim frmNew As New frmEnergyThefts("Tblt_EnergyThefts", "سرقات التيار")
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyTheftsPay_Click(sender As Object, e As EventArgs) Handles mnuEnergyTheftsPay.Click
        SClickSound()
        Dim frmNew As New frmPayed("Tblt_EnergyThefts", "سداد سرقات التيار")
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyDabtya_Click(sender As Object, e As EventArgs) Handles mnuEnergyDabtya.Click
        SClickSound()
        Dim frmNew As New frmEnergyThefts("Tblt_EnergyTheftsSecond", "الضبطية القضائية")
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyDabtyaPay_Click(sender As Object, e As EventArgs) Handles mnuEnergyDabtyaPay.Click
        SClickSound()
        Dim frmNew As New frmPayed("Tblt_EnergyTheftsSecond", "سرقات الضبطية القضائية")
        frmNew.Show()
    End Sub

    Private Sub mnuEnergyDevicesCode_Click(sender As Object, e As EventArgs) Handles mnuEnergyDevicesCode.Click
        SClickSound()
        strReportName = mnuEnergyDevicesCode.Text
        strReportNo = "01"
        frmBasicDataRep.Show()
    End Sub

    Private Sub mnuBranchCode_Click(sender As Object, e As EventArgs) Handles mnuBranchCode.Click

    End Sub

    ''''''Main Bar

End Class
