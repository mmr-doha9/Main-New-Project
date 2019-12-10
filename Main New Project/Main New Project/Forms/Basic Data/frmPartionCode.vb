Imports Main_New_Project

Public Class frmPartionCode
    Implements IFormMainFunction

    Dim strTable As String = "Tblc_PartionCode"
    Dim LstCtrl As New List(Of Control) : Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    'Dim arrCtl() As String = {} : Dim arrVal() As String = {} : Dim i As Integer
    Dim bolReSave As Boolean = True
    Dim bolAcceptAdd As Boolean = True

    Private Sub frmPartionCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        Call SAddNew()
        Call SLoadControll()
        'Call SLoadPermission()
    End Sub
    Private Sub SLoadControll()
        LstCtrl.Clear()
        With LstCtrl
            .Add(TxtBox1)
            .Add(TxtBox2)
            .Add(cmbType)
        End With
    End Sub

    Private Sub SFillCtl()
        lstCtlTag.Clear() : lstCtlVal.Clear()
        '''''''''''''''''''''''''''
        For Each ctlItem In LstCtrl
            'If ctlItem.Enabled = True Then
            lstCtlTag.Add("[" & FGetTagData(ctlItem, Valadation.Tag) & "]")
            '''''''''''''''''''''''''
            If TypeOf ctlItem Is TextBox Then ' TextBox case
                lstCtlVal.Add(ctlItem.Text)
            ElseIf TypeOf ctlItem Is System.Windows.Forms.ComboBox Then
                If FGetTagData(ctlItem, Valadation.ComboType) = 1 Then
                    lstCtlVal.Add(DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedValue)
                ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 2 Then
                    lstCtlVal.Add(DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedIndex)
                ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 3 Then
                    lstCtlVal.Add(DirectCast(ctlItem, System.Windows.Forms.ComboBox).Text)
                End If
                ''''''''''''''''' checkBox
            ElseIf TypeOf ctlItem Is System.Windows.Forms.CheckBox Then
                Dim intTemp As Integer = IIf((DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = True), 1, 0)
                lstCtlVal.Add(intTemp)
                '''''''''''''''' checkBox
            ElseIf TypeOf ctlItem Is System.Windows.Forms.DateTimePicker Then
                lstCtlVal.Add(FFormatDate(DirectCast(ctlItem, System.Windows.Forms.DateTimePicker).Value))
            ElseIf TypeOf ctlItem Is System.Windows.Forms.RadioButton Then
                Dim intTemp As Integer = IIf((DirectCast(ctlItem, System.Windows.Forms.RadioButton).Checked = True), 1, 0)
                lstCtlVal.Add(intTemp)
            End If
            'End If
        Next
        '''''''''''''''''''
        lstCtlTag.Add("[UserID]")
        lstCtlVal.Add(Val(strUserID))
        '''''''''''''''''''''''''
    End Sub

    Private Sub TxtBox_GotFocus(sender As Object, e As EventArgs) Handles TxtBox1.GotFocus, TxtBox2.GotFocus
        Call FChangeLang()
    End Sub

    Private Sub me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SAddNew() Implements IFormMainFunction.SAddNew
        Call ClearControl(TabPage1)
        TxtBox1.Text = FAutoNumber(strTable, FGetTagData(TxtBox1, Valadation.Tag), False, False)
        TxtBox2.Focus()
    End Sub

    Private Sub SOpen() Implements IFormMainFunction.SOpen
        Try
            strSQL = ("SELECT * FROM " & strTable & " WHERE ((" & strTable & "." & FGetTagData(TxtBox1, Valadation.Tag) & ")=" & TxtBox1.Text & ")")
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    For Each ctlItem In LstCtrl
                        If TypeOf ctlItem Is TextBox Then ' TextBox case
                            ctlItem.Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.ComboBox Then
                            If FGetTagData(ctlItem, Valadation.ComboType) = 1 Then
                                DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedValue = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                            ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 2 Then
                                DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedIndex = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                            ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 3 Then
                                DirectCast(ctlItem, System.Windows.Forms.ComboBox).Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                            End If
                            ''''''''''''''''' checkBox
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.CheckBox Then
                            Dim bolTemp As Boolean = IIf((dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString() = "0"), False, True)
                            DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = bolTemp
                            '''''''''''''''' checkBox
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.DateTimePicker Then
                            DirectCast(ctlItem, System.Windows.Forms.DateTimePicker).Value = dr.Item(FGetTagData(ctlItem, Valadation.Tag))
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.RadioButton Then
                            DirectCast(ctlItem, System.Windows.Forms.RadioButton).Checked = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        Else
                            MsgBox(ctlItem.Name)
                        End If
                    Next
                Else
                    Call SAddNew()
                End If
                dr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    For Each ctlItem In LstCtrl
                        If TypeOf ctlItem Is TextBox Then ' TextBox case
                            ctlItem.Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.ComboBox Then
                            If FGetTagData(ctlItem, Valadation.ComboType) = 1 Then
                                DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedValue = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                            ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 2 Then
                                DirectCast(ctlItem, System.Windows.Forms.ComboBox).SelectedIndex = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                            ElseIf FGetTagData(ctlItem, Valadation.ComboType) = 3 Then
                                DirectCast(ctlItem, System.Windows.Forms.ComboBox).Text = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                            End If
                            ''''''''''''''''' checkBox
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.CheckBox Then
                            Dim bolTemp As Boolean = IIf((dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString() = 0), False, True)
                            DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = bolTemp
                            '''''''''''''''' checkBox
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.DateTimePicker Then
                            DirectCast(ctlItem, System.Windows.Forms.DateTimePicker).Value = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        ElseIf TypeOf ctlItem Is System.Windows.Forms.RadioButton Then
                            DirectCast(ctlItem, System.Windows.Forms.RadioButton).Checked = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                        Else
                            MsgBox(ctlItem.Name)
                        End If
                    Next
                Else
                    SAddNew()
                End If
                dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SUpdate() Implements IFormMainFunction.SUpdate
        Try
            Dim StrDocNoTemp As Boolean = FGetFeildValuesBol(strTable, "Name", "ID=" & TxtBox1.Text, False)
            Call SFillCtl()
            If StrDocNoTemp = False Then
                FAddNewRecord(strTable, lstCtlTag, lstCtlVal)
                If TxtBox1.Text <> "" Then MsgBox("تمت الإضافة بنجاح", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            Else
                If FEditeRecord(strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, lstCtlTag, lstCtlVal) = True Then
                    MsgBox("تم التعديل بنجاح", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Private Sub SDelete() Implements IFormMainFunction.SDelete
        If MsgBox("هل تريد حذف السجل الحالي", CType(MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Ok Then
            Dim strCondition As String = (FGetTagData(TxtBox1, Valadation.Tag) & "=" & TxtBox1.Text)
            FDeleteRecord(strTable, strCondition)
            Call SAddNew()
        End If
    End Sub

    Private Sub SMoveFirst() Implements IFormMainFunction.SMoveFirst
        Dim S As String = FNavigate(NavDirection.DMoveFirst, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Private Sub SMovePrevious() Implements IFormMainFunction.SMovePrevious
        Dim S As String = FNavigate(NavDirection.DMovePrevious, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Private Sub SMoveNext() Implements IFormMainFunction.SMoveNext
        Dim S As String = FNavigate(NavDirection.DMoveNext, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Private Sub SMoveLast() Implements IFormMainFunction.SMoveLast
        Dim S As String = FNavigate(NavDirection.DMoveLast, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SPrintReport() Implements IFormMainFunction.SPrintReport
        ''
    End Sub

    Public Sub SShowPrint() Implements IFormMainFunction.SShowPrint
        ''
    End Sub
End Class