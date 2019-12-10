Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Smo

Public Module modMainGeneral
    Declare Function LoadKeyboardLayout Lib "user32" Alias "LoadKeyboardLayoutA" (ByVal pwszKLID As String, ByVal flags As Long) As Long
    '''''Play Sound
    Declare Auto Function sndPlaySound Lib "WINMM.DLL" (ByVal FileName As String, ByVal Options As Int32) As Int32
    Const SND_SYNC As Long = &H0 'synchronize playback 
    Const SND_ASYNC As Long = &H1 ' played async 
    Const SND_NODEFAULT As Long = &H2 ' No default 
    Const SND_LOOP As Long = &H8 ' 'loop the wave 
    Const SND_NOSTOP As Long = &H10 'don't stop current sound if one playing 
    Const SND_NOWAIT As Long = &H2000 'Do not wait if the sound driver is busy. 
    Const SND_ALIAS As Long = &H10000 ' Play a Windows sound (such as SystemStart, Asterisk, etc.). 

    Public Sub ClearControl(ByVal sender)
        Try
            Dim Ctl As Object
            For Each Ctl In sender.Controls
                If TypeOf Ctl Is System.Windows.Forms.GroupBox Then ClearControl(Ctl)
                'If TypeOf Ctl Is DevExpress.XtraEditors.GroupControl Then ClearControl(Ctl)
                'If TypeOf Ctl Is DevExpress.XtraTab.XtraTabPage Then ClearControl(Ctl)
                'If TypeOf Ctl Is DevExpress.XtraEditors.TextEdit Then Ctl.Text = ""
                'If TypeOf Ctl Is DevExpress.XtraEditors.DateEdit Then Ctl.Text = Now.Date
                If TypeOf Ctl Is System.Windows.Forms.TextBox Then Ctl.Text = ""
                If TypeOf Ctl Is System.Windows.Forms.MaskedTextBox Then Ctl.Text = ""
                If TypeOf Ctl Is System.Windows.Forms.ComboBox Then Ctl.Selectedindex = -1
                If TypeOf Ctl Is System.Windows.Forms.DateTimePicker Then Ctl.value = Date.Now
                If TypeOf Ctl Is System.Windows.Forms.CheckBox Then Ctl.checked = False
                If TypeOf Ctl Is System.Windows.Forms.RadioButton Then Ctl.checked = False
                If TypeOf Ctl Is System.Windows.Forms.ListBox Then Ctl.SelectedIndex = -1
                If TypeOf Ctl Is System.Windows.Forms.RichTextBox Then Ctl.Text = ""
                If TypeOf Ctl Is System.Windows.Forms.DataGridView Then SDelGridData(Ctl)
                If TypeOf Ctl Is System.Windows.Forms.TabControl Then ClearControl(Ctl)
                If TypeOf Ctl Is System.Windows.Forms.TabPage Then ClearControl(Ctl)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub FChangeLang()
        Dim strKbLangID As String
        Select Case strKbLang
            Case KbLang.Arabic
                strKbLangID = "00000401"
            Case KbLang.English
                strKbLangID = "00000409"
            Case Else
                Exit Sub
        End Select
        LoadKeyboardLayout(strKbLangID, KLF_ACTIVATE)
    End Sub

    Public Function FJustNumber(ByRef ee As System.Windows.Forms.KeyPressEventArgs) As Char
        If IsNumeric(ee.KeyChar) Or ee.KeyChar = "" Or ee.KeyChar = "" Or ee.KeyChar = "" Or ee.KeyChar = "" Or ee.KeyChar = Chr(13) Or ee.KeyChar = "." Or ee.KeyChar = "" Or ee.KeyChar = "." Or ee.KeyChar = "-" Then
            Return ee.KeyChar
        Else
            Return ""
        End If
    End Function

    Public Function FJustIntNumber(ByRef ee As System.Windows.Forms.KeyPressEventArgs) As Char
        If IsNumeric(ee.KeyChar) Or ee.KeyChar = "" Or ee.KeyChar = "" Or ee.KeyChar = "" Or ee.KeyChar = "" Or ee.KeyChar = Chr(13) Or ee.KeyChar = "" Or ee.KeyChar = "-" Then
            Return ee.KeyChar
        Else
            Return ""
        End If
    End Function

    Function ToHijra(ByVal gDate As Date, Optional ByVal format As String = Nothing) As String ' التاريخ الهجري
        Return gDate.ToString(format, New Globalization.CultureInfo("ar-SA"))
    End Function

    Public Sub SEnableTab(ByVal ctlName As TabControl, ByVal strTabName As String)
        For i As Integer = 0 To ctlName.TabCount - 1
            If ctlName.TabPages(i).Name = strTabName Then
                ctlName.TabPages(i).Show()  'Visible = True
            Else
                ctlName.TabPages(i).Hide() ' = False
            End If
        Next
    End Sub

    Public Sub SMaxFrm(ByVal frmName As Form, ByVal frmSize As Integer)
        Do Until frmName.Width = frmSize
            frmName.Width += 1
        Loop
    End Sub

    Public Sub SMinFrm(ByVal frmName As Form, ByVal frmSize As Integer)
        Do Until frmName.Width = frmSize
            frmName.Width -= 1
        Loop
    End Sub

    Public Function FCheckDemo(ByVal strTblName As String, ByVal intTranCount As Integer) As Boolean
        If bolDemo = True Then
            If FGetColumnValue(strTblName, "ID", Expresion.Count) >= intTranCount Then
                MsgBox("هذة النسخة للعرض فقط" & vbCrLf & "لشراء نسخة كاملة برجاء الاتصال بالمبيعات", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, ProgName)
                Return False
            End If
        End If
        Return True
    End Function

    Public Function FGetTagData(ByVal ctl As Control, ByVal strReturnValue As Valadation) As String
        If ctl.Tag <> "" Then
            'If ctl.Enabled = True Then
            Dim strValadate As String() = Split(ctl.Tag, ",") '0=Fld Name 1=Valadation 2=Default Value 3=Error Name
            Select Case strReturnValue
                Case Valadation.Tag
                    Return strValadate(0)
                Case Valadation.Valadtion
                    Return strValadate(1)
                Case Valadation.Default
                    Return strValadate(2)
                Case Valadation.err
                    Return strValadate(3)
                Case Valadation.ComboType
                    Return strValadate(4)
            End Select
            'End If
        End If
    End Function

    Public Function FValidation(ByVal frmName As Form, ByVal Ctrl As Control) As Boolean
        For Each Ctl In Ctrl.Controls
            If Ctl.Enabled = True Then
                If TypeOf Ctl Is System.Windows.Forms.TabPage Then
                    If FValidation(frmName, Ctl) = False Then Return False
                ElseIf TypeOf Ctl Is System.Windows.Forms.GroupBox Then
                    If FValidation(frmName, Ctl) = False Then Return False
                    'ElseIf TypeOf Ctl Is DevExpress.XtraEditors.GroupControl Then
                    '    If FValidation(frmName, Ctl) = False Then Return False
                    'ElseIf TypeOf Ctl Is DevExpress.XtraTab.XtraTabPage Then
                    '    If FValidation(frmName, Ctl) = False Then Return False
                ElseIf TypeOf Ctl Is System.Windows.Forms.TextBox Then
                    'If Ctl.name = "TxtBox7" Then MsgBox("")
                    Select Case LCase(FGetTagData(Ctl, Valadation.Valadtion))
                        Case "null"
                            If Ctl.text = "" Then MsgBox("من فضلك إكمل إدخال البيانات الأساسية" & vbCrLf & "يجب ادخال " & FGetTagData(Ctl, Valadation.err), MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                        Case ">0"
                            If Val(Ctl.text) <= 0 Then MsgBox("من فضلك إكمل إدخال البيانات الأساسية" & vbCrLf & "يجب ادخال رقم اكبر من الصفر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                        Case "int"
                            If Ctl.text = "" Then
                                MsgBox("من فضلك إكمل إدخال البيانات الأساسية" & vbCrLf & "يجب ادخال رقم صحيح في  " & FGetTagData(Ctl, Valadation.err), MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                            Else
                                If Ctl.text <> CInt(Ctl.text) Then MsgBox("من فضلك إكمل إدخال البيانات الأساسية" & vbCrLf & "يجب ادخال رقم صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                            End If
                    End Select
                ElseIf TypeOf Ctl Is System.Windows.Forms.ComboBox Then
                    Select Case LCase(FGetTagData(Ctl, Valadation.Valadtion))
                        Case "null"
                            If FGetTagData(Ctl, Valadation.ComboType) = 1 Then
                                If Ctl.selectedValue = Nothing Then MsgBox("من فضلك إكمل إدخال البيانات الأساسية" & vbCrLf & "يجب ادخال " & FGetTagData(Ctl, Valadation.err), MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                            Else
                                If Ctl.text = "" Then MsgBox("من فضلك إكمل إدخال البيانات الأساسية" & vbCrLf & "يجب ادخال " & FGetTagData(Ctl, Valadation.err), MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                            End If
                    End Select
                ElseIf TypeOf Ctl Is System.Windows.Forms.DateTimePicker Then
                    Select Case LCase(FGetTagData(Ctl, Valadation.Valadtion))
                        Case "null"

                    End Select
                ElseIf TypeOf Ctl Is System.Windows.Forms.CheckBox Then
                    Select Case LCase(FGetTagData(Ctl, Valadation.Valadtion))
                        Case "null"

                    End Select
                ElseIf TypeOf Ctl Is System.Windows.Forms.RadioButton Then
                    Select Case LCase(FGetTagData(Ctl, Valadation.Valadtion))
                        Case "null"
                    End Select
                End If
            End If
        Next
        Return True
    End Function

    Public Function FCloseAllForm(ByVal frmName As Form) As Boolean
        Try
            Dim frm As Form
            For Each frm In frmName.MdiChildren
                frm.Close()
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function FMakeBackUP(Optional bolDelData As Boolean = False) As Boolean
        Try
            If DataType = DataConnection.Access Then
                Return FMakeBackUPAccess()
            ElseIf DataType = DataConnection.SqlServer Then
                Return FMakeBackUPSql(bolDelData)
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function FMakeBackUPAccess(Optional bolDelData As Boolean = False) As Boolean
        Try
            Dim strFilePath As String = ""

            If IO.Directory.Exists(Application.StartupPath & "\GTBackup") = False Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\GTBackup")
            End If

            If bolDelData = False Then
                strFilePath = Application.StartupPath & "\GTBackup\" & Format(Now, "dd-MM-yyyy")
            Else
                strFilePath = Application.StartupPath & "\GTBackup\" & Format(Now, "dd-MM-yyyy") & "BeforeDelete"
            End If

            If IO.Directory.Exists(strFilePath) = False Then
                IO.Directory.CreateDirectory(strFilePath)
                IO.File.Copy(Application.StartupPath & "\Data\Data.mdb", strFilePath & "\Data.mdb")
                '''''''''''''
                My.Computer.FileSystem.CopyDirectory(Application.StartupPath & "\Attach", strFilePath & "\Attach", True) ' لنسخ المرفقات
                '''''''''''''
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkOnly, ProgName)
            Return False
        End Try
    End Function

    Private Function FMakeBackUPSql(Optional bolDelData As Boolean = False) As Boolean
        Try
            Dim strFilePath As String = ""

            If IO.Directory.Exists(Application.StartupPath & "\GTBackupSqlData\" & Format(Now, "dd-MM-yyyy")) = False Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\GTBackupSqlData\" & Format(Now, "dd-MM-yyyy"))
            End If
            If bolDelData = False Then
                strFilePath = Application.StartupPath & "\GTBackupSqlData\" & Format(Now, "dd-MM-yyyy") & "\" & Format(Now, "hh-mm-ss tt") & ".bak"
            Else
                strFilePath = Application.StartupPath & "\GTBackupSqlData\" & Format(Now, "dd-MM-yyyy") & "\" & Format(Now, "hh-mm-ss tt") & " BeforeDelete.bak"
            End If

            Dim conn As New SqlClient.SqlConnection(Db_Conn)
            conn.Open()

            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "BACKUP DATABASE [DataMain] TO DISK=N'" & strFilePath & "'" 'C:\Temp\location.BAK'"
            'Backup Database [DataMain] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER2014\MSSQL\Backup\DataMain.bak' WITH NOFORMAT, NOINIT,  NAME = N'DataMain-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10, CHECKSUM
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            '''''''''''''
            Dim dteOld4Delete As Date = DateAdd(DateInterval.Day, -10, Date.Now)
            Dim directory As New IO.DirectoryInfo(Application.StartupPath & "\GTBackupSqlData")
            For Each file As IO.DirectoryInfo In directory.GetDirectories
                'If (Now - file.CreationTime).Days > 7 Then file.GetDirectories() 'file.Delete()
                If (Now - file.CreationTime).Days > 10 Then System.IO.Directory.Delete(file.FullName, True)
            Next
            '''''''''''''
            Return True
        Catch ex As Exception
            'MessageBox.Show("فشلت عملية إنشاء النسخة الإحتياطية لقاعدة البيانات.\nException message :\n\t" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub PlayAWave(ByVal Soundfile As String)
        sndPlaySound(Soundfile, SND_ASYNC)
    End Sub

    Public Sub SClickSound()
        PlayAWave(Application.StartupPath & "\Warning.wav")
    End Sub

    Public Function HANY(ByVal HANY1 As Decimal, ByVal HANY2 As String) As String
        On Error Resume Next
        Dim VPS As Decimal = 0
        Dim V As Decimal = 0
        Dim WORDINTEGER As String = ""
        Dim LE As String = ""
        Dim P As String = ""
        Dim PS As String = ""
        HANY = ""
        Dim POUNDS As String = ""
        Dim WORDPS As String = ""
        Dim DOLLAR As String = ""
        Dim SENT As String = ""
        Dim SENTS As String = ""
        Dim TON As String = ""
        Dim KG As String = ""
        Dim KGS As String = ""
        Select Case HANY2
            Case "EGYPT"
                LE = " جنيها "
                P = " قرشا "
                PS = " قروش "
                POUNDS = " جنيهات "
                V = Int(Math.Abs(HANY1))
                VPS = Val(Right(Format(HANY1, "000000000000.00"), 2))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then HANY = WORDINTEGER & LE & " و " & WORDPS & P & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS >= 3 And VPS <= 9) Then HANY = WORDINTEGER & LE & " و " & WORDPS & PS & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS > 9) Then HANY = WORDINTEGER & LE & " و " & WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And (VPS <= 2) Then HANY = WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And (VPS >= 3 And VPS <= 9) Then HANY = WORDPS & PS & "فقط لاغير "
                If WORDINTEGER = "" And VPS > 9 Then HANY = WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And VPS = 0 Then HANY = ""
                If WORDINTEGER <> "" And VPS = 0 Then HANY = WORDINTEGER & LE & "فقط لاغير "
            Case "USA"
                DOLLAR = " دولار "
                SENT = " سنتاً "
                SENTS = "سنتات"
                V = Int(System.Math.Abs(HANY1))
                VPS = Val(Right(Format(HANY1, "000000000000.00"), 2))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then HANY = WORDINTEGER & DOLLAR & " و " & WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS >= 3 And VPS <= 9) Then HANY = WORDINTEGER & DOLLAR & " و " & WORDPS & " " & SENTS & " " & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS > 9) Then HANY = WORDINTEGER & DOLLAR & " و " & WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER = "" And (VPS <= 2) Then HANY = WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER = "" And (VPS >= 3 And VPS <= 9) Then HANY = WORDPS & " " & SENTS & " " & "فقط لاغير "
                If WORDINTEGER = "" And VPS > 9 Then HANY = WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER = "" And VPS = 0 Then HANY = ""
                If WORDINTEGER <> "" And VPS = 0 Then HANY = WORDINTEGER & DOLLAR & "فقط لاغير "
            Case "WEIGHT"
                TON = " طن "
                KG = " كيلو جرام "
                KGS = "كيلو جرامات"
                V = Int(Math.Abs(HANY1))
                VPS = Val(Right(Format(HANY1, "000000000000.000"), 3))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then HANY = WORDINTEGER & TON & " و " & WORDPS & KG & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS >= 3 And VPS <= 9) Then HANY = WORDINTEGER & TON & " و " & WORDPS & KGS & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS > 9) Then HANY = WORDINTEGER & TON & " و " & WORDPS & KG & "فقط لاغير "
                If WORDINTEGER = "" And (VPS <= 2) Then HANY = WORDPS & KG & "فقط لاغير "
                If WORDINTEGER = "" And (VPS >= 3 And VPS <= 9) Then HANY = WORDPS & KGS & "فقط لاغير "
                If WORDINTEGER = "" And VPS > 9 Then HANY = WORDPS & KG & "فقط لاغير "
                If WORDINTEGER = "" And VPS = 0 Then HANY = ""
                If WORDINTEGER <> "" And VPS = 0 Then HANY = WORDINTEGER & TON & "فقط لاغير "
        End Select
    End Function

    Private Function AmountWord(ByVal AMOUNT As Decimal) As String
        On Error Resume Next
        Dim n As Decimal = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim C4 As Decimal = 0
        Dim C5 As Decimal = 0
        Dim C6 As Decimal = 0
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim S3 As String = ""
        Dim S4 As String = ""
        Dim S5 As String = ""
        Dim S6 As String = ""
        Dim C As String = ""
        n = Int(AMOUNT)
        C = Format(n, "000000000000")
        C1 = Val(Mid(C, 12, 1))
        Select Case C1
            Case Is = 1 : S1 = "واحد"
            Case Is = 2 : S1 = "اثنان"
            Case Is = 3 : S1 = "ثلاثة"
            Case Is = 4 : S1 = "اربعة"
            Case Is = 5 : S1 = "خمسة"
            Case Is = 6 : S1 = "ستة"
            Case Is = 7 : S1 = "سبعة"
            Case Is = 8 : S1 = "ثمانية"
            Case Is = 9 : S1 = "تسعة"
        End Select

        C2 = Val(Mid(C, 11, 1))
        Select Case C2
            Case Is = 1 : S2 = "عشر"
            Case Is = 2 : S2 = "عشرون"
            Case Is = 3 : S2 = "ثلاثون"
            Case Is = 4 : S2 = "اربعون"
            Case Is = 5 : S2 = "خمسون"
            Case Is = 6 : S2 = "ستون"
            Case Is = 7 : S2 = "سبعون"
            Case Is = 8 : S2 = "ثمانون"
            Case Is = 9 : S2 = "تسعون"
        End Select

        If S1 <> "" And C2 > 1 Then S2 = S1 + " و" + S2
        If S2 = "" Then S2 = S1
        If C1 = 0 And C2 = 1 Then S2 = S2 + "ة"
        If C1 = 1 And C2 = 1 Then S2 = "احدى عشر"
        If C1 = 2 And C2 = 1 Then S2 = "اثنى عشر"
        If C1 > 2 And C2 = 1 Then S2 = S1 + " " + S2
        C3 = Val(Mid(C, 10, 1))
        Select Case C3
            Case Is = 1 : S3 = "مائة"
            Case Is = 2 : S3 = "مئتان"
            Case Is > 2 : S3 = Left(AmountWord(C3), Len(AmountWord(C3)) - 1) + "مائة"
        End Select
        If S3 <> "" And S2 <> "" Then S3 = S3 + " و" + S2
        If S3 = "" Then S3 = S2

        C4 = Val(Mid(C, 7, 3))
        Select Case C4
            Case Is = 1 : S4 = "الف"
            Case Is = 2 : S4 = "الفان"
            Case 3 To 10 : S4 = AmountWord(C4) + " آلاف"
            Case Is > 10 : S4 = AmountWord(C4) + " الف"
        End Select
        If S4 <> "" And S3 <> "" Then S4 = S4 + " و" + S3
        If S4 = "" Then S4 = S3
        C5 = Val(Mid(C, 4, 3))
        Select Case C5
            Case Is = 1 : S5 = "مليون"
            Case Is = 2 : S5 = "مليونان"
            Case 3 To 10 : S5 = AmountWord(C5) + " ملايين"
            Case Is > 10 : S5 = AmountWord(C5) + " مليون"
        End Select
        If S5 <> "" And S4 <> "" Then S5 = S5 + " و" + S4
        If S5 = "" Then S5 = S4

        C6 = Val(Mid(C, 1, 3))

        Select Case C6
            Case Is = 1 : S6 = "مليار"
            Case Is = 2 : S6 = "ملياران"
            Case Is > 2 : S6 = AmountWord(C6) + " مليار"
        End Select
        If S6 <> "" And S5 <> "" Then S6 = S6 + " و" + S5
        If S6 = "" Then S6 = S5
        AmountWord = S6
    End Function

    Public Function MydateWord(ByVal MYDATE As Date) As String
        On Error Resume Next
        Dim n As Integer = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim C As String = ""
        MydateWord = ""
        C = Format(MYDATE, "dd-mm-yyyy")
        C1 = MYDATE.Day
        C2 = MYDATE.Month
        C3 = MYDATE.Year
        Select Case C1
            Case Is = 1 : S1 = "الاول"
            Case Is = 2 : S1 = "الثانى"
            Case Is = 3 : S1 = "الثالث"
            Case Is = 4 : S1 = "الرابع"
            Case Is = 5 : S1 = "الخامس"
            Case Is = 6 : S1 = "السادس"
            Case Is = 7 : S1 = "السابع"
            Case Is = 8 : S1 = "الثامن"
            Case Is = 9 : S1 = "التاسع"
            Case Is = 10 : S1 = "العاشر"
            Case Is = 11 : S1 = "الحادى عشر"
            Case Is = 12 : S1 = "الثانى عشر"
            Case Is = 13 : S1 = "الثالث عشر"
            Case Is = 14 : S1 = "الرابع عشر"
            Case Is = 15 : S1 = "الخامس عشر"
            Case Is = 16 : S1 = "السادس عشر"
            Case Is = 17 : S1 = "السابع عشر"
            Case Is = 18 : S1 = "الثامن عشر"
            Case Is = 19 : S1 = "التاسع عشر"
            Case Is = 20 : S1 = "العشرون"
            Case Is = 21 : S1 = "الواحد والعشرون"
            Case Is = 22 : S1 = " الثانى والعشرون"
            Case Is = 23 : S1 = "الثالث والعشرون"
            Case Is = 24 : S1 = " الرابع والعشرون"
            Case Is = 25 : S1 = " الخامس والعشرون"
            Case Is = 26 : S1 = "السادس والعشرون"
            Case Is = 27 : S1 = "السابع والعشرون"
            Case Is = 28 : S1 = "الثامن والعشرون"
            Case Is = 29 : S1 = "التاسع والعشرون"
            Case Is = 30 : S1 = "الثلاثون"
            Case Is = 31 : S1 = "الواحد والثلاثون"
        End Select

        Select Case C2
            Case Is = 1 : S2 = "يناير"
            Case Is = 2 : S2 = "فبراير"
            Case Is = 3 : S2 = "مارس"
            Case Is = 4 : S2 = "ابريل"
            Case Is = 5 : S2 = "مايو"
            Case Is = 6 : S2 = "يونية"
            Case Is = 7 : S2 = "يوليو"
            Case Is = 8 : S2 = "اغسطس"
            Case Is = 9 : S2 = "سبتمبر"
            Case Is = 10 : S2 = "اكتوبر"
            Case Is = 11 : S2 = "نوفمبر"
            Case Is = 12 : S2 = "ديسمبر"
        End Select
        MydateWord = Format(MYDATE, "dddd") & " الموافق " & S1 & " من  شهر " & S2 & " سنة " & AmountWord(CDec(C3)) & " ميلادية "
    End Function

    Public Function MytimeWord(ByVal MYTIME As DateTime) As String
        On Error Resume Next
        Dim n As Integer = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim C4 As String = ""
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim S3 As String = ""
        Dim S4 As String = ""
        Dim S5 As String = ""
        Dim C As DateTime
        MytimeWord = ""
        C = Format(MYTIME, "hh:mm:ss tt")
        C1 = Format(C, "ss")
        C2 = Format(C, "mm")
        C3 = Format(C, "hh")
        C4 = Format(C, "tt")
        Select Case C4
            Case "ص" : S4 = "صباحاَ"
            Case "م" : S4 = "مساءً"
            Case "AM" : S4 = "صباحاَ"
            Case "PM" : S4 = "مساءً"
        End Select
        Select Case C1
            Case Is = 0 : S3 = ""
            Case Is = 1 : S3 = " ثانية واحدة "
            Case Is = 2 : S3 = " ثانيتان"
            Case 3 To 10 : S3 = AmountWord(C1) + " ثوان"
            Case Is > 10 : S3 = AmountWord(C1) + " ثانية"
        End Select
        Select Case C2
            Case Is = 0 : S1 = ""
            Case Is = 1 : S1 = " دقيقة واحدة "
            Case Is = 2 : S1 = " دقيقتان "
            Case 3 To 10 : S1 = AmountWord(C2) + " دقائق "
            Case Is > 10 : S1 = AmountWord(C2) + " دقيقة "
        End Select
        If S1 <> "" And S3 <> "" Then S5 = S1 + " و" + S3
        If S1 = "" Then S5 = S3
        Select Case C3
            Case Is = 0 : S2 = ""
            Case Is = 1 : S2 = "الواحدة"
            Case Is = 2 : S2 = "الثانية"
            Case Is = 3 : S2 = "الثالثة"
            Case Is = 4 : S2 = "الرابعة"
            Case Is = 5 : S2 = "الخامسة"
            Case Is = 6 : S2 = "السادسة"
            Case Is = 7 : S2 = "السابعة"
            Case Is = 8 : S2 = "الثامنة"
            Case Is = 9 : S2 = "التاسعة"
            Case Is = 10 : S2 = "العاشرة"
            Case Is = 11 : S2 = "الحادية عشر"
            Case Is = 12 : S2 = "الثانية عشر"
        End Select
        If S2 <> "" And S1 <> "" And S3 <> "" Then S5 = S2 + " و" + S1 + " و" + S3
        If S2 <> "" And S1 <> "" And S3 = "" Then S5 = S2 + " و" + S1
        If S2 <> "" And S1 = "" And S3 <> "" Then S5 = S2 + " و" + S3
        If S2 <> "" And S1 = "" And S3 = "" Then S5 = S2
        MytimeWord = " الساعة " & S5 & " " & S4
    End Function

    Public Sub MYSHUTDOWN(ByVal OPERATION As Byte)
        Dim resault As String
        Select Case OPERATION
            Case 0
                resault = MessageBox.Show("هل تريد غلق الجهاز", "اغلاق الجهاز ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -s -f -t 0")
                Else
                    Exit Sub
                End If
            Case 1
                resault = MessageBox.Show("هل تريد اعادة تشغيل الويندز ", "اعادة تشغيل الويندز ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -r -f -t 0")
                Else
                    Exit Sub
                End If
            Case 2
                resault = MessageBox.Show("هل تريد عمل Log Off ", "Log Off ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -l -f -t 0")
                Else
                    Exit Sub
                End If
        End Select
    End Sub

    'Public Sub AllowOnlyNumeric(ByRef e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal AllowedChar As String = "")
    '    Dim strAllowed As String() = AllowedChar.Split(",")
    '    Dim ienum As IEnumerator = strAllowed.GetEnumerator

    '    While (ienum.MoveNext)
    '        If e.KeyChar.ToString().ToLower = ienum.Current.ToString().ToLower Then
    '            Return
    '        End If
    '    End While

    '    If Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Public Sub ValidateKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Asc(e.KeyChar) <> 46 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("لابد أن تكون القيمة المدخلة أرقام فقط", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            e.Handled = True
        End If
    End Sub

    Public Function FLoadConditionRep(ByVal strFrom As String, ByVal strTo As String) As String
        Try
            Dim strTmp As String = ""

            If Val(strFrom) > Val(strTo) Then
                MsgBox("لا يمكن البحث في حالة -من- أكبر من -إلي- ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly + vbMsgBoxRtlReading + vbMsgBoxRight, ProgName)
                Return ""
            End If
            For i As Integer = Val(strFrom) To Val(strTo)
                If strTmp = "" Then
                    strTmp = i
                Else
                    strTmp = strTmp & " , " & i
                End If
            Next
            Return strTmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly + vbMsgBoxRtlReading + vbMsgBoxRight, ProgName)
        End Try
    End Function

    Public Sub SShowBaloon(ByVal strMsg As String, ByVal iconName As ToolTipIcon)
        Mdi.nIcon.Text = "برنامج إدارة نقاط البيع"
        'MDI.nIcon.Icon = New Icon(Application.StartupPath & "/Pic/POS.ico")
        Mdi.nIcon.ShowBalloonTip(0.5, "برنامج إدارة نقاط البيع", strMsg, iconName)
    End Sub

    Public Function FGetComputerName() As String
        Dim ComputerName As String
        'ComputerName = System.Net.Dns.GetHostName
        ComputerName = Environment.MachineName
        Return ComputerName
    End Function

    Public Function Ceiling(ByVal X As Double, Optional ByVal Factor As Double = 1, Optional ByRef dblFarq As Double = 0) As Double
        ' X is the value you want to round    
        ' is the multiple to which you want to round  
        Ceiling = (Int(X / Factor) - (X / Factor - Int(X / Factor) > 0)) * Factor
        dblFarq = Math.Round(Ceiling - X, 2, MidpointRounding.AwayFromZero)
    End Function

    Public Function Floor(ByVal X As Double, Optional ByVal Factor As Double = 1) As Double
        ' X is the value you want to round     
        ' is the multiple to which you want to round     
        Floor = Int(X / Factor) * Factor
    End Function

    Public Function RoundUp(ByVal X As Double) As Double ' الجبر للاعلي
        If Fix(X) = X Then
            Return X
        ElseIf Fix(X) > X Then
            Return Fix(X)
        Else
            Return Fix(X) + 1
        End If
    End Function

    Public Sub SLoadPermission(strTable As String, ByRef BoluserPer As Boolean, ByRef BoluserOpen As Boolean, ByRef BoluserDelete As Boolean, ByRef BoluserSave As Boolean, ByRef BoluserReSave As Boolean, ByRef UserOpenOtherUserTran As Boolean)
        If strUserType = "0" Then
            '                             0         1           2            3            4                 5
            Dim strTmp() As String = {"UserPer", "UserOpen", "UserDel", "UserEdit", "UserReEdit", "UserOpenOtherUserTran"}
            Dim StrFrmPer As String() = FGetFeildValuesArry("Tblt_UserFormPer", strTmp, "UserCode='" & strUserID & "' And FrmCode='" & strTable & "'", False, "")
            If StrFrmPer.Length >= 5 Then
                BoluserPer = StrFrmPer(0)
                BoluserOpen = StrFrmPer(1)
                BoluserDelete = StrFrmPer(2)
                BoluserSave = StrFrmPer(3)
                BoluserReSave = StrFrmPer(4)
                UserOpenOtherUserTran = StrFrmPer(5)
            Else
                BoluserPer = False
                BoluserOpen = False
                BoluserDelete = False
                BoluserSave = False
                BoluserReSave = False
                UserOpenOtherUserTran = False
            End If
        End If
    End Sub

End Module
