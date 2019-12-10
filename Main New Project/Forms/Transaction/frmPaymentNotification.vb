Imports Main_New_Project

Public Class frmPaymentNotification
    Implements IFormMainFunction

    Dim strTable As String = "Tblt_PaymentNotification"
    Dim strFrmTag As String = "بيانات مسلسلات الإخطارات"
    Dim LstCtrl As New List(Of Control) : Dim lstCtlTag As New List(Of String) : Dim lstCtlVal As New List(Of String)
    'Dim arrCtl() As String = {} : Dim arrVal() As String = {} : Dim i As Integer
    Dim strTmpTranNo As String = "" ' رقم الحركة السابقة
    Dim bolReSave As Boolean = True
    Dim bolAcceptAdd As Boolean = True
    Dim frmload2 As loadType
    Dim typeFrm As frmEditType
    Dim BoluserFrmPer, BoluserOPen, BoluserDelete, BoluserSave, BoluserReSave, BolUserOpenOtherUserTran As Boolean ' الصلاحيات
    Dim bolUserOpenOtherUserTranTmp As Boolean ' للتنقل برقم اليوزر

    Private Sub frmPaymentNotification_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        Call SAddNew()
        'Call SLoadPermission()
        Call SDrawPaymentNotificationGrid(DataGridView1)
        Call SLoadControll()
    End Sub

    Private Sub SLoadControll()
        LstCtrl.Clear()
        With LstCtrl
            .Add(TxtBox1)
            .Add(TxtBox2)
            .Add(TxtBox3)
            .Add(TxtBox4)
            .Add(CmbEmployeCode)
        End With
    End Sub

    Public Sub SAddNew() Implements IFormMainFunction.SAddNew
        Call ClearControl(TabPage1)
        TxtBox1.Text = FAutoNumber(strTable, FGetTagData(TxtBox1, Valadation.Tag), False, False)
        Call SFillCombo(CmbEmployeCode, "Tblc_employeeCode", "ID", "Name", "", False, "ID", ComboLoadItemSelect.Min)
        TxtBox2.Focus()
    End Sub

    Public Sub SDrawPaymentNotificationGrid(ByVal strDataGrid As DataGridView)
        Dim InvoiceNo As New DataGridViewTextBoxColumn
        With InvoiceNo
            .HeaderText = "رقم الإيصال" : .Width = 100 : .Visible = True : .Tag = "InvoiceNo" : .Name = "InvoiceNo" : .ReadOnly = True
        End With
        'Dim StatesGood As New DataGridViewCheckBoxColumn
        'With StatesGood
        '    .HeaderText = "حالة الإيصال" : .Visible = True : .Width = 100 : .Tag = "StatesGood" : .Name = "StatesGood" : .ReadOnly = False
        'End With
        strDataGrid.Columns.Add(InvoiceNo)
        'strDataGrid.Columns.Add(StatesGood)

        strDataGrid.AllowUserToAddRows = False
        'strDataGrid.AllowUserToDeleteRows = False
        'strDataGrid.RowHeadersVisible = False
        strDataGrid.RowHeadersWidth = 30
        strDataGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        strDataGrid.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        'strDataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Public Sub SOpen() Implements IFormMainFunction.SOpen
        ''''''''''''''''''''''''''''
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
                        'Dim bolTemp As Boolean = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString 'IIf((dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString() = "0"), False, True)
                        'DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = bolTemp
                        DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString()
                        '''''''''''''''' checkBox
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.DateTimePicker Then
                        DirectCast(ctlItem, System.Windows.Forms.DateTimePicker).Value = dr.Item(FGetTagData(ctlItem, Valadation.Tag))
                    ElseIf TypeOf ctlItem Is System.Windows.Forms.RadioButton Then
                        DirectCast(ctlItem, System.Windows.Forms.RadioButton).Checked = dr.Item(FGetTagData(ctlItem, Valadation.Tag)).ToString
                    Else
                        MsgBox(ctlItem.Name)
                    End If
                Next
                TxtBox1.Text = dr.Item("ID")
            Else
                SAddNew()
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
                TxtBox1.Text = dr.Item("ID")
            Else
                SAddNew()
            End If
            dr.Close()
        End If
        ''''''''''''''
        Call SLoadGrid(strTable & "Grid", DataGridView1, "DocNo", TxtBox1.Text, False, "", "", False)
        ''''''''''''''''''''''''''''
    End Sub

    Public Sub SUpdate() Implements IFormMainFunction.SUpdate
        Try
            If FValidation(Me, TabControl) = True Then
                If FCheckDemo(TabPage1.Tag, 5) = True Then
                    If FCheckGrid(DataGridView1, "جريدة الأحمال") = True Then
                        If FCheckPriviosRecord() = True Then
                            '''''''''''
                            Call SFillCtl()
                            If typeFrm = frmEditType.Save Then
                                TxtBox1.Text = FAddNewRecord2(strTable, lstCtlTag, lstCtlVal)
                                Call FSetTransaction(TransactionType.Save, strFrmTag, TxtBox1.Text) ' transactions save
                            ElseIf typeFrm = frmEditType.Edit Then
                                FEditeRecord(strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, lstCtlTag, lstCtlVal)
                                Call FSetTransaction(TransactionType.Edit, strFrmTag, TxtBox1.Text) ' transactions save
                            End If
                            Call SSaveGrid(strTable & "Grid", DataGridView1, "DocNo", Val(TxtBox1.Text), "", False, False, False)

                            If MsgBox("تم الحفظ بنجاح" & vbCrLf & "رقم الحركة الحالية هو " & TxtBox1.Text & vbCrLf & "هل تريد البدء في حركة جديدة؟", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Yes Then
                                Call SAddNew()
                            Else
                                typeFrm = frmEditType.Edit
                            End If
                        Else
                            MsgBox("يوجد دفتر سابق بنفس الرقم", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                            If MsgBox("هل تريد فتح هذة الحركة", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Yes Then
                                TxtBox1.Text = strTmpTranNo
                                Call SOpen()
                            End If
                        End If
                        Call SSaveGrid(strTable & "Grid", DataGridView1, "DocNo", Val(TxtBox1.Text), "", True, True, False)
                    End If
                End If
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SDelete() Implements IFormMainFunction.SDelete
        If MsgBox("هل تريد حذف السجل الحالي", CType(MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName) = MsgBoxResult.Ok Then
            If FCheckDelete(Val(TxtBox1.Text), "ActivitiesCode") = True Then
                Dim strCondition As String = (FGetTagData(TxtBox1, Valadation.Tag) & "=" & TxtBox1.Text)
                FDeleteRecord(strTable, strCondition)
                Call SAddNew()
            Else
                MsgBox("لايمكن المسح تم الأستخدام في حركات", CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, Global.Microsoft.VisualBasic.MsgBoxStyle), ProgName)
            End If
        End If
    End Sub

    Public Sub SMoveFirst() Implements IFormMainFunction.SMoveFirst
        Dim S As String = FNavigate(NavDirection.DMoveFirst, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMovePrevious() Implements IFormMainFunction.SMovePrevious
        Dim S As String = FNavigate(NavDirection.DMovePrevious, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveNext() Implements IFormMainFunction.SMoveNext
        Dim S As String = FNavigate(NavDirection.DMoveNext, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SMoveLast() Implements IFormMainFunction.SMoveLast
        Dim S As String = FNavigate(NavDirection.DMoveLast, strTable, FGetTagData(TxtBox1, Valadation.Tag), TxtBox1.Text, "ID", False, False)
        If S <> 0 Then TxtBox1.Text = S : Call SOpen()
    End Sub

    Public Sub SPrintReport() Implements IFormMainFunction.SPrintReport
        'Throw New NotImplementedException()
    End Sub

    Public Sub SShowPrint() Implements IFormMainFunction.SShowPrint
        'Throw New NotImplementedException()
    End Sub

    Private Function FCheckPriviosRecord() As Boolean ' التاكد من وجود دفتر سابق بنفس الرقم

        Dim strCondition As String = "DaftrID='" & TxtBox2.Text & "'"

        strTmpTranNo = (FGetFeildValues(strTable, "ID", strCondition, False, False))

        If strTmpTranNo <> Nothing Then
            If strTmpTranNo <> TxtBox1.Text Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
        '''''''''''''''''''''''''''
    End Function

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Call SAddNew()
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
                lstCtlVal.Add((DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked)) 'IIf((DirectCast(ctlItem, System.Windows.Forms.CheckBox).Checked = True), 1, 0)
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
        lstCtlTag.Add("[tranTime]")
        lstCtlVal.Add(FFormatTime(Now))
        lstCtlTag.Add("[UserID]")
        lstCtlVal.Add(Val(strUserID))
    End Sub

    Private Sub TxtBox4_TextChanged(sender As Object, e As EventArgs) Handles TxtBox4.TextChanged

        Call SDelGridData(DataGridView1)
        If (Val(TxtBox4.Text) - Val(TxtBox3.Text)) > 0 Then
            Dim intTmp As Integer = Val(TxtBox3.Text)
            Dim k As Integer = 1

            For i As Integer = 0 To (Val(TxtBox4.Text) - Val(TxtBox3.Text))
                DataGridView1.Rows.Add()
                DataGridView1.Item(0, i).Value = intTmp
                'DataGridView1.Item(1, i).Value = 1
                intTmp += 1
                k += 1
            Next
        End If
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox1.KeyPress, TxtBox2.KeyPress, TxtBox3.KeyPress, TxtBox4.KeyPress
        Select Case DirectCast(sender, TextBox).Name
            Case TxtBox1.Name, TxtBox3.Name, TxtBox4.Name
                e.KeyChar = FJustNumber(e)
        End Select
    End Sub

    Private Sub me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            If strUserType = 0 Then
                If typeFrm = frmEditType.Edit Then
                    If BoluserReSave = True Then
                        Call SUpdate()
                    Else
                        MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    End If
                ElseIf typeFrm = frmEditType.Save Then
                    If BoluserSave = True Then
                        Call SUpdate()
                    Else
                        MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    End If
                End If
            Else
                Call SUpdate()
            End If
        ElseIf e.Control And e.KeyCode = Keys.O Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SOpen()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SOpen()
            End If
        ElseIf e.Control And e.KeyCode = Keys.D Then
            If strUserType = 0 Then
                If BoluserDelete = True Then
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
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMovePrevious()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMovePrevious()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Right Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMoveNext()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveNext()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Up Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMoveFirst()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveFirst()
            End If
        ElseIf e.Control And e.KeyCode = Keys.Down Then
            If strUserType = 0 Then
                If BoluserOPen = True Then
                    Call SMoveLast()
                Else
                    MsgBox("ليس لديك صلاحية لهذة العملية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                End If
            Else
                Call SMoveLast()
            End If
        End If
        '''''''''''''
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Call SUpdate()
    End Sub


End Class