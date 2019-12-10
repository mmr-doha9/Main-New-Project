Public Class frmAddUser
    Dim DpAccess As OleDb.OleDbDataAdapter
    Dim Dp As SqlClient.SqlDataAdapter
    Dim Cm As CurrencyManager
    Dim ds As New DataSet()
    Dim WithEvents BS As New BindingSource
    Dim currPosition As Integer
    Private bindingSource1 As New BindingSource()

    Private Sub frmCasherCode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = MDI
        Call SAddNew()
        Call SLoadPermission()
    End Sub

    Public Sub LoadDataSet()
        BS.DataSource = "" : BS.DataMember = "" : ds.Clear()
        strSQL = ("SELECT * FROM " & TabPage1.Tag & " order by ID")
        If DataType = DataConnection.SqlServer Then
            Dp = New SqlClient.SqlDataAdapter(strSQL, CON)
            Dp.Fill(ds, TabPage1.Tag)
            BS.DataSource = ds
            BS.DataMember = TabPage1.Tag
        ElseIf DataType = DataConnection.Access Then
            DpAccess = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            DpAccess.Fill(ds, TabPage1.Tag)
            BS.DataSource = ds
            BS.DataMember = TabPage1.Tag
        End If
    End Sub

    Public Sub SAddNew()
        Call LoadDataSet()
        Call RecordCount()
        Call ClearControl(Me.TabPage1)
        TxtBox1.Text = FAutoNumber(TabPage1.Tag, FGetTagData(TxtBox1, Valadation.Tag), False, False)
    End Sub

    Public Sub SUpdate(ByVal frmName As Form, ByVal txtBox As TextBox, ByVal tabCtl As TabPage, Optional ByVal strCondition As String = "")
        Try
            strSQL = ("SELECT * FROM " & tabCtl.Tag & " WHERE ((" & tabCtl.Tag & "." & FGetTagData(TxtBox1, Valadation.Tag) & ")=" & "'" & txtBox.Text & "'" & ")")
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim arrCtl() As String = {} : Dim arrVal() As String = {}
                Dim i As Integer = 0
                For Each Ctl In TabPage1.Controls
                    If FGetTagData(Ctl, Valadation.Tag) <> "" Then
                        If TypeOf Ctl Is System.Windows.Forms.TextBox Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.text : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.ComboBox Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.selectedvalue : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.DateTimePicker Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.value : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.CheckBox Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = IIf(Ctl.checked = True, 1, 0) : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.RadioButton Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.checked : i += 1
                    End If
                Next
                If dr.Read() = False Then
                    dr.Close()
                    FAddNewRecord(TabPage1.Tag, arrCtl, arrVal)
                Else
                    dr.Close()
                    FEditeRecord(TabPage1.Tag, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, arrCtl, arrVal)
                End If
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Dim arrCtl() As String = {} : Dim arrVal() As String = {}
                Dim i As Integer = 0
                For Each Ctl In TabPage1.Controls
                    If FGetTagData(Ctl, Valadation.Tag) <> "" Then
                        If TypeOf Ctl Is System.Windows.Forms.TextBox Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.text : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.ComboBox Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.selectedvalue : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.DateTimePicker Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.value : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.CheckBox Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = IIf(Ctl.checked = True, 1, 0) : i += 1
                        If TypeOf Ctl Is System.Windows.Forms.RadioButton Then ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = FGetTagData(Ctl, Valadation.Tag) : arrVal(i) = Ctl.checked : i += 1
                    End If
                Next
                If dr.Read() = False Then
                    dr.Close()
                    FAddNewRecord(TabPage1.Tag, arrCtl, arrVal)
                Else
                    dr.Close()
                    FEditeRecord(TabPage1.Tag, FGetTagData(TxtBox1, Valadation.Tag), "'" & TxtBox1.Text & "'", arrCtl, arrVal)
                End If
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Private Sub RecordCount()
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = BS.Count
        CurrenRecordst = BS.Position + 1
        'RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If BS.Position < ds.Tables(TabPage1.Tag).Rows.Count - 1 Then
            Forward = True
        End If
        Call DisplayRecord()
    End Sub

    Private Sub DisplayRecord()
        TxtBox1.Text = ds.Tables(TabPage1.Tag).Rows(Me.BS.Position)(FGetTagData(TxtBox1, Valadation.Tag)).ToString
        Call SOpen(TxtBox1, TabPage1)
    End Sub

    Private Sub TxtCode_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtBox1.Text = FSearch(TabPage1.Tag)
    End Sub

    Private Sub TxtBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBox1.DoubleClick
        FSearch(TabPage1.Tag, TxtBox1.Tag, TxtBox2.Tag)
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Call SAddNew()
    End Sub

    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Call SOpen(TxtBox1, TabPage1)
    End Sub

    Private Sub SOpen(ByVal txtBox As TextBox, ByVal tabCtl As TabPage, Optional ByVal strCondition As String = "")
        Try
            strSQL = ("SELECT * FROM " & tabCtl.Tag & " WHERE (((" & tabCtl.Tag & "." & FGetTagData(TxtBox1, Valadation.Tag) & ")='" & TxtBox1.Text & "'))")
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    TxtBox1.Text = dr.Item(FGetTagData(TxtBox1, Valadation.Tag))
                    TxtBox2.Text = dr.Item(FGetTagData(TxtBox2, Valadation.Tag))
                    TxtBox3.Text = Val(dr.Item(FGetTagData(TxtBox3, Valadation.Tag)))
                    TxtBox4.Text = Val(dr.Item(FGetTagData(TxtBox3, Valadation.Tag)))
                    ChkAdmin.Checked = dr.Item(FGetTagData(ChkAdmin, Valadation.Tag))
                    dr.Close()
                Else
                    dr.Close()
                    SAddNew()
                End If
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    TxtBox1.Text = dr.Item(FGetTagData(TxtBox1, Valadation.Tag))
                    TxtBox2.Text = dr.Item(FGetTagData(TxtBox2, Valadation.Tag))
                    TxtBox3.Text = Val(dr.Item(FGetTagData(TxtBox3, Valadation.Tag)))
                    TxtBox4.Text = Val(dr.Item(FGetTagData(TxtBox3, Valadation.Tag)))
                    ChkAdmin.Checked = dr.Item(FGetTagData(ChkAdmin, Valadation.Tag))
                    dr.Close()
                Else
                    dr.Close()
                    SAddNew()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If FValidation(Me, TabPage1) = True Then
            If FCheckDemo(TabPage1.Tag, 5) = True Then
                Call SUpdate(Me, TxtBox1, TabPage1)
                If ChkBoxReSavePermission.Checked = True Then Call SUpdatePer()
                Call SAddNew()
            End If
        End If
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("هل تريد حذف السجل الحالي", MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Ok Then
            FDeleteRecord(TabPage1.Tag, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text)
            FDeleteRecord("Tblt_UserFormPer", "UserCode='" & TxtBox1.Text & "'")
            Call SAddNew()
        End If
    End Sub
    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BS.Position = 0
        Call RecordCount()
        Call SOpenOtherFld()
    End Sub
    Private Sub CmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BS.Position = BS.Position - 1
        Call RecordCount()
        Call SOpenOtherFld()
    End Sub
    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BS.Position = BS.Position + 1
        Call RecordCount()
        Call SOpenOtherFld()
    End Sub
    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BS.Position = BS.Count - 1
        Call RecordCount()
        Call SOpenOtherFld()
    End Sub
    Private Sub SOpenOtherFld()
        TxtBox4.Text = FGetFeildValues(TabPage1.Tag, "UserPassword", "UserCode =" & "'" & TxtBox1.Text & "'")
    End Sub
    Private Sub SLoadPermission()
        Dim frmTag As String = Me.Tag

        If FGetFeildValues("Tblc_UserCode", "UserCode", "UserCode='" & strUserID & "'") = 0 Then
            Dim BoluserNav As Boolean = IIf(FGetFeildValues("Tblt_UserFormPer", "UserNav", "UserCode='" & strUserID & "' And FrmCode='" & frmTag & "'") = 1, True, False)
            cmdFirst.Enabled = BoluserNav : cmdLast.Enabled = BoluserNav : CmdPrevious.Enabled = BoluserNav : cmdNext.Enabled = BoluserNav
            cmdDel.Enabled = IIf(FGetFeildValues("Tblt_UserFormPer", "UserDel", "UserCode='" & strUserID & "' And FrmCode='" & frmTag & "'") = 1, True, False)
            cmdSave.Enabled = IIf(FGetFeildValues("Tblt_UserFormPer", "UserEdit", "UserCode='" & strUserID & "' And FrmCode='" & frmTag & "'") = 1, True, False)
            cmdOpen.Enabled = IIf(FGetFeildValues("Tblt_UserFormPer", "UserOpen", "UserCode='" & strUserID & "' And FrmCode='" & frmTag & "'") = 1, True, False)
        End If
    End Sub
    Private Sub SValadation()
        Shell_Validator.ValidTextbox(Shell_Validator.ValidationType.Numeric, TxtBox1)
        Shell_Validator.ValidTextbox(Shell_Validator.ValidationType.NotNull, TxtBox2)
    End Sub
    Private Sub TextBoxes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox1.KeyPress, TxtBox2.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox1.Name ', TxtBox3.Name, TxtBox4.Name
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
    Private Sub TabControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Call cmdSave_Click(Me, e)
        ElseIf e.Control And e.KeyCode = Keys.O Then
            Call SOpen(TxtBox1, TabPage1)
        ElseIf e.Control And e.KeyCode = Keys.D Then
            cmdDel_Click(Me, e)
        ElseIf e.Control And e.KeyCode = Keys.N Then
            Call SAddNew()
        ElseIf e.Control And e.KeyCode = Keys.Left Then
            Call CmdPrevious_Click(Me, e)
        ElseIf e.Control And e.KeyCode = Keys.Right Then
            Call cmdNext_Click(Me, e)
        ElseIf e.Control And e.KeyCode = Keys.Up Then
            Call cmdFirst_Click(Me, e)
        ElseIf e.Control And e.KeyCode = Keys.Down Then
            Call cmdLast_Click(Me, e)
        End If
    End Sub
    Private Sub SUpdatePer()
        Dim strSqlQry As String

        Call FDeleteRecord("Tblt_UserFormPer", "UserCode=" & "'" & TxtBox1.Text & "'")

        If FGetFeildValues("Tblc_UserCode", "UserType", "UserCode=" & "'" & TxtBox1.Text & "'", False) = 0 Then
            strSqlQry = "INSERT INTO Tblt_UserFormPer ( UserCode, FrmCode, UserPer, UserDel, UserEdit, UserOpen )" & _
            " SELECT " & "'" & TxtBox1.Text & "'" & "  AS Expr1, Tblu_FrmCode.Code, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, 0 AS Expr5 " & _
            " FROM Tblu_FrmCode where ItemType=1 Order By ID;"
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        End If
    End Sub
End Class