Public Class frmPlaceCode
    Implements IFormMainFunction

    Dim strTable As String = "Tblc_PlaceCode"
    Dim LstCtrl As New List(Of Control) : Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    'Dim arrCtl() As String = {} : Dim arrVal() As String = {} : Dim i As Integer
    Dim bolReSave As Boolean = True
    Dim bolAcceptAdd As Boolean = True
    Dim frmload2 As loadType

    Public Sub New(frmload As loadType)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmload2 = frmload
    End Sub

    Private Sub frmPlaceCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        If frmload2 = loadType.Mdi Then
            Me.MdiParent = Mdi
        ElseIf frmload2 = loadType.ShowDialoge Then

        End If
        Call SAddNew()
        'Call SLoadPermission()
    End Sub

    Public Sub SAddNew() Implements IFormMainFunction.SAddNew
        Call ClearControl(TabPage1)
        TxtBox1.Text = FAutoNumber(strTable, FGetTagData(TxtBox1, Valadation.Tag), False, False)
        TxtBox2.Focus()
    End Sub

    Public Sub SDelete() Implements IFormMainFunction.SDelete
        If MsgBox("هل تريد حذف السجل الحالي", CType(MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Ok Then
            Dim strCondition As String = (FGetTagData(TxtBox1, Valadation.Tag) & "=" & TxtBox1.Text)
            FDeleteRecord(strTable, strCondition)
            Call SAddNew()
        End If
    End Sub

    Public Sub SMoveFirst() Implements IFormMainFunction.SMoveFirst
        Dim S As String = FNavigate(NavDirection.DMoveFirst, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveLast() Implements IFormMainFunction.SMoveLast
        Dim S As String = FNavigate(NavDirection.DMoveLast, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveNext() Implements IFormMainFunction.SMoveNext
        Dim S As String = FNavigate(NavDirection.DMoveNext, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMovePrevious() Implements IFormMainFunction.SMovePrevious
        Dim S As String = FNavigate(NavDirection.DMovePrevious, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SOpen() Implements IFormMainFunction.SOpen
        strSQL = ("SELECT * FROM " & strTable & " WHERE (((" & strTable & ".ID)=" & TxtBox1.Text & "))")
        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            If dr.Read() = True Then
                TxtBox1.Text = dr.Item(FGetTagData(TxtBox1, Valadation.Tag)).ToString
                TxtBox2.Text = dr.Item(FGetTagData(TxtBox2, Valadation.Tag)).ToString
            Else
                SAddNew()
            End If
            dr.Close()
        ElseIf DataType = DataConnection.Access Then
            Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            If dr.Read() = True Then
                TxtBox1.Text = dr.Item(FGetTagData(TxtBox1, Valadation.Tag)).ToString
                TxtBox2.Text = dr.Item(FGetTagData(TxtBox2, Valadation.Tag)).ToString
            Else
                SAddNew()
            End If
            dr.Close()
        End If
    End Sub

    Public Sub SPrintReport() Implements IFormMainFunction.SPrintReport
        ''
    End Sub

    Public Sub SShowPrint() Implements IFormMainFunction.SShowPrint
        ''
    End Sub

    Public Sub SUpdate() Implements IFormMainFunction.SUpdate
        Try
            Dim StrDocNoTemp As Boolean = FGetFeildValuesBol(strTable, "Name", "ID=" & TxtBox1.Text, False)
            Call SFillCtl(Me)

            If StrDocNoTemp = False Then
                FAddNewRecord(strTable, lstCtlTag, lstCtlVal)
            Else
                FEditeRecord(strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, lstCtlTag, lstCtlVal)
            End If
            If frmload2 = loadType.Mdi Then
                MsgBox("تم الحفظ بنجاح", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                Call SAddNew()
            ElseIf frmload2 = loadType.ShowDialoge Then
                intComboItemNew = TxtBox1.Text
                Me.Close()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
            MsgBox("حدثت مشكلة أثناء الحفظ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        End Try
    End Sub

    Private Sub SFillCtl(ByVal ctlName As Control)
        lstCtlTag.Clear() : lstCtlVal.Clear()
        '''''''''''''''''''''''''''
        With lstCtlVal
            .Add(TxtBox2.Text)
            .Add(Val(strUserID))
        End With
        '''''''''''''''''''''''''
        With lstCtlTag
            .Add("[" & FGetTagData(TxtBox2, Valadation.Tag) & "]")
            .Add("[UserId]")
        End With
        '''''''''''''''''''''''''
    End Sub

    Private Sub TxtBox_GotFocus(sender As Object, e As EventArgs) Handles TxtBox1.GotFocus, TxtBox2.GotFocus
        Call FChangeLang()
    End Sub

    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserEdit", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SUpdate()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SUpdate()
            End If
        ElseIf e.Control And e.KeyCode = Keys.O Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SOpen()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SOpen()
            End If
        ElseIf e.Control And e.KeyCode = Keys.D Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserDel", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SDelete()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SDelete()
            End If
        ElseIf e.Control And e.KeyCode = Keys.N Then
            Call SAddNew()
        ElseIf e.Control And e.KeyCode = Keys.Left Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMovePrevious()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMovePrevious()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Right Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMoveNext()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveNext()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Up Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMoveFirst()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveFirst()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Down Then
            If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode='" & strUserID & "'") = 0 Then
                If FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & Me.Tag & "'") = 1 Then
                    Call SMoveLast()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveLast()
            End If
        End If
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox1.KeyPress, TxtBox2.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox1.Name
                e.KeyChar = FJustNumber(e)
                If e.KeyChar = Chr(13) Then
                    SendKeys.Send("{TAB}")
                End If
            Case Else
                If e.KeyChar = Chr(13) Then
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

End Class