Public Module modMainDataUtilities
    Dim Dp As SqlClient.SqlDataAdapter
    Dim DpAccess As OleDb.OleDbDataAdapter
    Dim ds As New DataSet

    Public Sub Main()
        OpenSqlConnection()
    End Sub

    Public Function FNavigate(ByVal NavName As NavDirection, ByVal strTableName As String, ByVal strFieldNo As String, ByVal strFieldValue As String, ByVal strID As String, Optional ByVal bolUserID As Boolean = False, Optional ByVal bolCompId As Boolean = False) As String
        Try
            If NavName = NavDirection.DMoveNext Then
                'Dim tmp As String = FGetFeildValues(strTableName, strID, strFieldNo & "='" & strFieldValue & "'", bolCompId, bolUserID)
                'If Val(tmp) > 0 Then
                '    Dim tmp2 As String = FGetFeildValues(strTableName, strFieldNo, strID & ">" & tmp, bolCompId, bolUserID, "ID")
                Dim tmp As String = FGetFeildValues(strTableName, strFieldNo, strID & ">" & strFieldValue, bolCompId, bolUserID, "ID")
                If tmp <> Nothing Then
                    Return tmp
                Else
                    Return 0
                    'End If
                End If
            ElseIf NavName = NavDirection.DMovePrevious Then
                'Dim tmp As String = FGetFeildValues(strTableName, strID, strFieldNo & "='" & strFieldValue & "'", bolCompId, bolUserID)
                'Dim tmp2 As String = ""
                'If tmp <> Nothing Or tmp <> 0 Then
                Dim tmp As String = FGetFeildValues(strTableName, strFieldNo, strID & "<" & strFieldValue, bolCompId, bolUserID, " ID Desc")
                'Else
                '    Return 0
                'End If

                If tmp <> Nothing Then
                    Return tmp
                Else
                    Return 0
                End If
            ElseIf NavName = NavDirection.DMoveFirst Then
                Dim tmp As String = ((FMIN(strID, strTableName, "", bolCompId, bolUserID)))
                If tmp = Nothing Then
                    Exit Function
                End If
                'Dim tmp2 As String = FGetFeildValues(strTableName, strFieldNo, strID & "=" & tmp, bolCompId, bolUserID)
                Return tmp
            ElseIf NavName = NavDirection.DMoveLast Then
                Dim tmp As String = ((FMax(strID, strTableName, "", bolCompId, bolUserID)))
                If tmp = Nothing Then
                    Exit Function
                End If
                'Dim tmp2 As String = FGetFeildValues(strTableName, strFieldNo, strID & "=" & tmp, bolCompId, bolUserID)
                Return tmp
            End If
        Catch ex As Exception
            MsgBox(ex.InnerException, MsgBoxStyle.Critical, ProgName)
        End Try
    End Function

    Public Function FSearch(ByVal strGTableName As String, ByVal strColShow() As String, Optional ByVal strGKeyField As String = "", Optional ByVal strCondition As String = "", Optional ByVal StrFrmText As String = "", Optional ByVal strSearchBeginName As String = "", Optional ByVal intComboIndex As Integer = 0, Optional ByVal strOrderBy As String = "") As String
        ds.Clear()
        strGCondtion = strCondition

        strSearchBeginNameMain = strSearchBeginName

        If strCondition <> "" Then
            strSQL = "SELECT *  From " & strGTableName & " WHERE " & strCondition & ""
        Else
            strSQL = "SELECT *  From " & strGTableName
        End If

        If strOrderBy <> "" Then
            strSQL = strSQL & " Order By " & strOrderBy
        End If

        If DataType = DataConnection.SqlServer Then
            Dim DataAdapter1 As New SqlClient.SqlDataAdapter(strSQL, CON)
            DataAdapter1.Fill(ds, strGTableName)
            FrmSearch.DataGridView.DataSource = ds
            FrmSearch.DataGridView.DataMember = strGTableName
            FrmSearch.DataGridView.AutoResizeColumns()

            FrmSearch.ComboBox.Items.Clear()
            For Each dc As DataColumn In ds.Tables.Item(strGTableName).Columns
                If (dc.ColumnName) = "ID" Then
                    FrmSearch.DataGridView.Columns(0).Visible = False
                ElseIf (dc.ColumnName) = "CompanyID" Then
                    FrmSearch.DataGridView.Columns(FrmSearch.DataGridView.Columns.Count - 1).Visible = False
                Else
                    Dim strTmp As String = FGetSearchName(dc.ColumnName, 0)
                    If strTmp = "" Then
                        FrmSearch.DataGridView.Columns(dc.ColumnName).Visible = False
                    Else
                        FrmSearch.ComboBox.Items.Add(strTmp)
                        ReDim Preserve arrCoulmn(arrCoulmn.Length) : arrCoulmn(arrCoulmn.Length - 1) = dc.ColumnName.ToString
                    End If
                End If
            Next
        ElseIf DataType = DataConnection.Access Then
            Dim DataAdapter1 As New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            DataAdapter1.Fill(ds, strGTableName)
            FrmSearch.DataGridView.DataSource = ds
            FrmSearch.DataGridView.DataMember = strGTableName
            FrmSearch.DataGridView.AutoResizeColumns()

            FrmSearch.ComboBox.Items.Clear()
            For Each dc As DataColumn In ds.Tables.Item(strGTableName).Columns
                If (dc.ColumnName) = "ID" Then
                    FrmSearch.DataGridView.Columns(0).Visible = False
                ElseIf (dc.ColumnName) = "CompanyID" Then
                    FrmSearch.DataGridView.Columns(FrmSearch.DataGridView.Columns.Count - 1).Visible = False
                Else
                    Dim strTmp As String = ""

                    For i As Integer = 0 To strColShow.Count - 1
                        If strColShow(i) = dc.ColumnName Then
                            strTmp = FGetSearchName(dc.ColumnName, 0)
                            Exit For
                        Else
                            strTmp = ""
                        End If
                    Next
                    ''''''''''''''''''''''
                    If strTmp = "" Then
                        FrmSearch.DataGridView.Columns(dc.ColumnName).Visible = False
                    Else
                        FrmSearch.ComboBox.Items.Add(strTmp)
                        ReDim Preserve arrCoulmn(arrCoulmn.Length) : arrCoulmn(arrCoulmn.Length - 1) = dc.ColumnName.ToString
                    End If
                End If
            Next
        End If
        FrmSearch.Tag = strGTableName
        FrmSearch.Text = StrFrmText
        If intComboIndex > 0 Then FrmSearch.ComboBox.SelectedIndex = intComboIndex Else FrmSearch.ComboBox.SelectedIndex = 0
        FrmSearch.txtBox.Focus()
        FrmSearch.ShowDialog()
        If strSearchGridVal = Nothing Then FSearch = 0 Else FSearch = strSearchGridVal
        FrmSearch.Tag = "" : strSearchGridVal = ""
    End Function

    Public Function FSearch(ByVal strGTableName As String, Optional ByVal strGKeyField As String = "", Optional ByVal strCondition As String = "", Optional ByVal StrFrmText As String = "", Optional ByVal strSearchBeginName As String = "", Optional ByVal strOrderBy As String = "", Optional ByVal intComboIndex As Integer = 0, Optional ByVal ReturnIntComboIndex As Integer = 1) As String
        ds.Clear()
        strGCondtion = strCondition

        strSearchBeginNameMain = strSearchBeginName

        If strCondition <> "" Then
            strSQL = "SELECT *  From " & strGTableName & " WHERE " & strCondition & ""
        Else
            strSQL = "SELECT *  From " & strGTableName
        End If

        If strOrderBy <> "" Then
            strSQL = strSQL & " Order By " & strOrderBy
        End If

        If DataType = DataConnection.SqlServer Then
            Dim DataAdapter1 As New SqlClient.SqlDataAdapter(strSQL, CON)
            DataAdapter1.Fill(ds, strGTableName)
            FrmSearch.DataGridView.DataSource = ds
            FrmSearch.DataGridView.DataMember = strGTableName
            FrmSearch.DataGridView.AutoResizeColumns()

            FrmSearch.ComboBox.Items.Clear()
            For Each dc As DataColumn In ds.Tables.Item(strGTableName).Columns
                'If (dc.ColumnName) = "ID" Then
                '    'FrmSearch.DataGridView.Columns(0).Visible = False
                'Else

                Dim strTmp As String = FGetSearchName(dc.ColumnName, 0)
                If strTmp = "" Then
                    FrmSearch.DataGridView.Columns(dc.ColumnName).Visible = False
                Else
                    FrmSearch.ComboBox.Items.Add(strTmp)
                    ReDim Preserve arrCoulmn(arrCoulmn.Length) : arrCoulmn(arrCoulmn.Length - 1) = dc.ColumnName.ToString
                End If
            Next
        ElseIf DataType = DataConnection.Access Then
            Dim DataAdapter1 As New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            DataAdapter1.Fill(ds, strGTableName)
            FrmSearch.DataGridView.DataSource = ds
            FrmSearch.DataGridView.DataMember = strGTableName
            FrmSearch.DataGridView.AutoResizeColumns()

            FrmSearch.ComboBox.Items.Clear()
            For Each dc As DataColumn In ds.Tables.Item(strGTableName).Columns
                If (dc.ColumnName) = "ID" Then
                    FrmSearch.DataGridView.Columns(0).Visible = False
                ElseIf (dc.ColumnName) = "CompanyID" Then
                    FrmSearch.DataGridView.Columns(FrmSearch.DataGridView.Columns.Count - 1).Visible = False
                Else
                    Dim strTmp As String = FGetSearchName(dc.ColumnName, 0)
                    If strTmp = "" Then
                        FrmSearch.DataGridView.Columns(dc.ColumnName).Visible = False
                    Else
                        FrmSearch.ComboBox.Items.Add(strTmp)
                        ReDim Preserve arrCoulmn(arrCoulmn.Length) : arrCoulmn(arrCoulmn.Length - 1) = dc.ColumnName.ToString
                    End If
                End If
            Next
        End If
        FrmSearch.Tag = strGTableName
        FrmSearch.Text = StrFrmText
        FrmSearch.TxtTmp.Text = ReturnIntComboIndex
        If intComboIndex > 0 Then FrmSearch.ComboBox.SelectedIndex = intComboIndex Else FrmSearch.ComboBox.SelectedIndex = 0
        FrmSearch.ShowDialog()
        If strSearchGridVal = Nothing Then FSearch = 0 Else FSearch = strSearchGridVal
        FrmSearch.Tag = "" : strSearchGridVal = ""
    End Function

    Public Function FGetSearchName(ByVal strOldName As String, ByVal intType As Integer) As String
        Select Case intType
            Case 0
                Return FGetFeildValues("Tblu_ConvertName", "Arabic", "English='" & strOldName & "'")
            Case 1
                Return FGetFeildValues("Tblu_ConvertName", "English", "Arabic='" & strOldName & "'")
        End Select
    End Function

    Public Function FTreeSearch(ByVal TreeBranches As TreeBranches, ByVal strTableName As String, Optional ByVal strKeyField As String = "", Optional ByVal strKeyValue As String = "", Optional ByVal strCondition As String = "", Optional ByVal strFrmTitle As String = "بداية البحث", Optional ByVal bolCompanyID As Boolean = True, Optional ByVal bolUserId As Boolean = True, Optional ByVal strOrderBy As String = "", Optional ByVal strSecondField As String = "Name", Optional ByVal ReturnType As SearchReturnType = SearchReturnType.String) As String
        strTblName = strTableName : strFldName = strKeyField : strFldCon = strCondition
        Select Case TreeBranches
            Case TreeBranches.MultiBranches
                frmTreeSearch.LoadDataSet(strTableName, strKeyField, strFrmTitle, bolCompanyID, bolUserId, strOrderBy, strCondition)
                frmTreeSearch.ShowDialog()
                FTreeSearch = strSearchTreeVal
            Case TreeBranches.SingleBranch
                frmTreeSearch2.LoadDataSet(strTableName, strKeyField, strFrmTitle, bolCompanyID, bolUserId, strOrderBy, strSecondField, ReturnType)
                frmTreeSearch2.ShowDialog()
                FTreeSearch = strSearchTreeVal2
        End Select
    End Function

    Public Function FGetFeildValues(ByVal strTableName As String, ByVal strFldName As String, ByVal strCondition As String, Optional ByVal bolCompId As Boolean = False, Optional ByVal bolUserID As Boolean = False, Optional ByVal strOrderBy As String = "") As String
        Try
            Dim sql As String = ""
            If strCondition = "" Then
                sql = "SELECT " & "[" & strFldName & "]" & "   From " & strTableName
            Else
                sql = "SELECT " & "[" & strFldName & "]" & "   From " & strTableName & " WHERE " & strCondition
            End If
            If bolCompId = True Then
                If strCondition = "" Then
                    sql = sql & " WHERE CompanyID=" & "'" & strCompanyID & "'"
                Else
                    sql = sql & " and CompanyID=" & "'" & strCompanyID & "'"
                End If
            End If
            If bolUserID = True Then
                sql = sql & " and UserID=" & "'" & strUserID & "'"
            End If
            If strOrderBy <> "" Then
                sql = sql & " Order By " & strOrderBy
            End If
            If DataType = DataConnection.SqlServer Then
                Dim TmpCON As New SqlClient.SqlConnection(Db_Conn)
                TmpCON.Open()
                Dim cmd As New SqlClient.SqlCommand(sql, TmpCON)
                Dim TmpTmpdr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If TmpTmpdr.Read() = True Then
                    FGetFeildValues = TmpTmpdr.Item(strFldName)
                    TmpCON.Close()
                Else
                    TmpTmpdr.Close()
                    TmpCON.Close()
                    Return Nothing
                End If
                TmpTmpdr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim TmpCON As New OleDb.OleDbConnection(Db_Conn)
                TmpCON.Open()
                Dim cmd As New OleDb.OleDbCommand(sql, TmpCON)
                Dim TmpTmpdr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If TmpTmpdr.Read() = True Then
                    FGetFeildValues = TmpTmpdr.Item(strFldName)
                    TmpTmpdr.Close() : TmpCON.Close()
                Else
                    TmpTmpdr.Close() : TmpCON.Close()
                    Return Nothing
                End If
                TmpTmpdr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    'الرجوع بمصفوفة
    Public Function FGetFeildValuesArry(ByVal strTableName As String, ByVal strFldName As String, ByVal strCondition As String, Optional ByVal bolCompId As Boolean = False, Optional ByVal bolUserId As String = "", Optional ByVal strOrderBy As String = "") As String()
        Try
            Dim strTmp() As String = {""}
            Dim sql As String = ""
            If strCondition = "" Then
                sql = "SELECT " & "[" & strFldName & "]" & "   From " & strTableName
            Else
                sql = "SELECT " & "[" & strFldName & "]" & "   From " & strTableName & " WHERE " & strCondition
            End If
            If bolCompId = True Then
                sql = sql & " and CompanyID=" & "'" & strCompanyID & "'"
            End If
            If bolUserId <> "" Then
                sql = sql & " and UserID=" & "'" & bolUserId & "'"
            End If
            If strOrderBy <> "" Then
                sql = sql & " Order By " & strOrderBy
            End If
            If DataType = DataConnection.SqlServer Then
                Dim TmpCON As New SqlClient.SqlConnection(Db_Conn)
                TmpCON.Open()
                Dim cmd As New SqlClient.SqlCommand(sql, TmpCON)
                Dim TmpTmpdr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While TmpTmpdr.Read()
                    ReDim Preserve strTmp(strTmp.Length - 1)
                    strTmp(strTmp.Length - 1) = TmpTmpdr.Item(strFldName)
                Loop
                TmpTmpdr.Close() : TmpCON.Close() : TmpTmpdr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim TmpCON As New OleDb.OleDbConnection(Db_Conn)
                TmpCON.Open()
                Dim cmd As New OleDb.OleDbCommand(sql, TmpCON)
                Dim TmpTmpdr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While TmpTmpdr.Read()
                    If strTmp(0) = "" Then
                        strTmp(0) = TmpTmpdr.Item(strFldName)
                    Else
                        ReDim Preserve strTmp(strTmp.Length)
                        strTmp(strTmp.Length - 1) = TmpTmpdr.Item(strFldName)
                    End If
                Loop
                TmpTmpdr.Close() : TmpCON.Close() : TmpTmpdr.Close()
            End If
            Return strTmp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FGetFeildValuesArry(ByVal strTableName As String, ByVal strFldName() As String, ByVal strCondition As String, Optional ByVal bolCompId As Boolean = False, Optional ByVal bolUserId As String = "", Optional ByVal strOrderBy As String = "") As String()
        Try
            Dim strTmp() As String = {""}
            Dim sql As String = ""
            If strCondition = "" Then
                sql = "SELECT * From " & strTableName
            Else
                sql = "SELECT * From " & strTableName & " WHERE " & strCondition
            End If
            If bolCompId = True Then
                sql = sql & " and CompanyID=" & "'" & strCompanyID & "'"
            End If
            If bolUserId <> "" Then
                sql = sql & " and UserID=" & "'" & bolUserId & "'"
            End If
            If strOrderBy <> "" Then
                sql = sql & " Order By " & strOrderBy
            End If
            If DataType = DataConnection.SqlServer Then
                Dim TmpCON As New SqlClient.SqlConnection(Db_Conn)
                TmpCON.Open()
                Dim cmd As New SqlClient.SqlCommand(sql, TmpCON)
                Dim TmpTmpdr As SqlClient.SqlDataReader = cmd.ExecuteReader
                'Dim i As Integer
                Do While TmpTmpdr.Read()
                    For i As Integer = 0 To strFldName.Length - 1
                        ReDim Preserve strTmp(i)
                        strTmp(i) = TmpTmpdr.Item(strFldName(i))
                    Next
                Loop
                TmpTmpdr.Close() : TmpCON.Close() : TmpTmpdr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim TmpCON As New OleDb.OleDbConnection(Db_Conn)
                TmpCON.Open()
                Dim cmd As New OleDb.OleDbCommand(sql, TmpCON)
                Dim TmpTmpdr As OleDb.OleDbDataReader = cmd.ExecuteReader
                'Dim i As Integer
                Do While TmpTmpdr.Read()
                    For i As Integer = 0 To strFldName.Length - 1
                        ReDim Preserve strTmp(i)
                        strTmp(i) = TmpTmpdr.Item(strFldName(i))
                    Next
                Loop
                TmpTmpdr.Close() : TmpCON.Close() : TmpTmpdr.Close()
            End If
            Return strTmp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FGetFeildValuesBol(ByVal strTableName As String, ByVal strFldName As String, ByVal strCondition As String, Optional ByVal bolCompId As Boolean = False) As Boolean
        Try
            strSQL = "SELECT " & strFldName & " From " & strTableName & " WHERE " & strCondition
            If bolCompId = True Then
                If strCondition = "" Then
                    strSQL = strSQL & " CompanyID=" & "'" & strCompanyID & "'"
                Else
                    strSQL = strSQL & " and CompanyID=" & "'" & strCompanyID & "'"
                End If
            End If
            If DataType = DataConnection.SqlServer Then
                Dim TmpCON As New SqlClient.SqlConnection(Db_Conn)
                TmpCON.Open()
                Dim Cmd As New SqlClient.SqlCommand(strSQL, TmpCON)
                Dim dr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                If dr.Read() = True Then
                    FGetFeildValuesBol = True
                Else
                    FGetFeildValuesBol = False
                End If
                dr.Close() : Cmd.ExecuteReader(CommandBehavior.CloseConnection) : TmpCON.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim TmpCON As New OleDb.OleDbConnection(Db_Conn)
                TmpCON.Open()
                Dim cmd As New OleDb.OleDbCommand(strSQL, TmpCON)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    FGetFeildValuesBol = True
                Else
                    FGetFeildValuesBol = False
                End If
                dr.Close() : cmd.ExecuteReader(CommandBehavior.CloseConnection) : TmpCON.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FFormatDate(ByVal DateVal As Date) As String
        'If DateReturnType = 0 Then
        '    Return Format(DateVal, "dd/MM/yyyy")
        'ElseIf DateReturnType = 1 Then
        '    Return Format(DateVal, "yyyy-MM-dd")
        'End If
        ', Optional ByVal DateReturnType As Integer = 0
        If DataType = DataConnection.SqlServer Then
            Return Format(DateVal, "yyyy-MM-dd")
        ElseIf DataType = DataConnection.Access Then
            Return Format(DateVal, "dd/MM/yyyy")
        End If
    End Function

    Public Function FFormatDate2(ByVal DateVal As Date) As String
        'If DateReturnType = 0 Then
        '    Return Format(DateVal, "dd/MM/yyyy")
        'ElseIf DateReturnType = 1 Then
        '    Return Format(DateVal, "yyyy-MM-dd")
        'End If
        ', Optional ByVal DateReturnType As Integer = 0
        If DataType = DataConnection.SqlServer Then
            Return Format(DateVal, "yyyy-MM-dd")
        ElseIf DataType = DataConnection.Access Then
            Return Format(DateVal, "dd/MM/yyyy")
        End If
    End Function

    Public Function FFormatDateTime(ByVal DateVal As Date, Optional ByVal FormatType As String = "Date") As String
        If DataType = DataConnection.SqlServer Then
            If FormatType = "Date" Then
                Return Format(DateVal, "yyyy-MM-dd hh:mm tt")
            ElseIf FormatType = "Time" Then
                Return Format(DateVal, "hh:mm:ss tt")
            End If
        ElseIf DataType = DataConnection.Access Then
            If FormatType = "Date" Then
                Return FormatDateTime(DateVal, DateFormat.GeneralDate)
                'Return Format(DateVal, "dd/M/yyyy hh:mm:ss tt")
            ElseIf FormatType = "Time" Then
                Return Format(DateVal, "hh:mm tt")
            End If
        End If
    End Function

    Public Sub SFillTextBox(ByVal ctrl As TextBox, ByVal strTableName As String, ByVal strFldCode As String, ByVal strFldName As String, Optional ByVal strCondition As String = "", Optional ByVal bolCompId As Boolean = True, Optional ByVal strOrderBy As String = "")
        If strCondition = "" Then
            strSQL = "SELECT * FROM " & strTableName & ""
        Else
            strSQL = "SELECT * FROM " & strTableName & " WHERE " & strCondition
        End If
        If strTableName <> "Tblc_BranchCode" Then
            If bolCompId = True Then
                If strCondition <> "" Then
                    strSQL = strSQL & " and CompanyID=" & "'" & strCompanyID & "'"
                Else
                    strSQL = strSQL & " WHERE CompanyID=" & "'" & strCompanyID & "'"
                End If
            End If
        End If
        If strOrderBy <> "" Then
            strSQL = strSQL & " ORDER BY " & strOrderBy
        End If
        If DataType = DataConnection.SqlServer Then
            Dim Dp As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSQL, CON)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)

            Dim r As DataRow : Dim dt As New DataTable : Dp.Fill(dt)
            ctrl.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                ctrl.AutoCompleteCustomSource.Add(r.Item(strFldName).ToString)
            Next
            ctrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ElseIf DataType = DataConnection.Access Then
            Dim Dp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)

            Dim r As DataRow : Dim dt As New DataTable : Dp.Fill(dt)
            ctrl.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                ctrl.AutoCompleteCustomSource.Add(r.Item(strFldName).ToString)
            Next
            ctrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End If
    End Sub

    Public Sub SFillCombo(ByVal ctrl As ComboBox, ByVal strTableName As String, ByVal strFldCode As String, ByVal strFldName As String, Optional ByVal strCondition As String = "", Optional ByVal bolCompId As Boolean = True, Optional ByVal strOrderBy As String = "", Optional ByVal SelectItem As ComboLoadItemSelect = ComboLoadItemSelect.Min)

        ctrl.DisplayMember = Nothing : ctrl.ValueMember = Nothing : ctrl.DataSource = Nothing
        If strCondition = "" Then
            strSQL = "SELECT * FROM " & strTableName & ""
        Else
            strSQL = "SELECT * FROM " & strTableName & " WHERE " & strCondition
        End If
        If strTableName <> "Tblc_BranchCode" Then
            If bolCompId = True Then
                If strCondition <> "" Then
                    strSQL = strSQL & " and CompanyID=" & "'" & strCompanyID & "'"
                Else
                    strSQL = strSQL & " WHERE CompanyID=" & "'" & strCompanyID & "'"
                End If
            End If
        End If
        If strOrderBy <> "" Then
            strSQL = strSQL & " ORDER BY " & strOrderBy
        End If
        If DataType = DataConnection.SqlServer Then
            Dim Dp As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSQL, CON)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)
            ctrl.DisplayMember = "" & strTableName & "." & strFldName & ""
            ctrl.ValueMember = "" & strTableName & "." & strFldCode & ""
            ctrl.DataSource = ds2
        ElseIf DataType = DataConnection.Access Then
            Dim Dp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)
            ctrl.DisplayMember = "" & strTableName & "." & strFldName & ""
            ctrl.ValueMember = "" & strTableName & "." & strFldCode & ""
            ctrl.DataSource = ds2
        End If
        If SelectItem = ComboLoadItemSelect.Min Then
            If ctrl.Items.Count <> 0 Then ctrl.SelectedIndex = 0
        ElseIf SelectItem = ComboLoadItemSelect.Max Then
            If ctrl.Items.Count <> 0 Then ctrl.SelectedIndex = ctrl.Items.Count - 1
        End If
    End Sub

    'Public Sub SFillCombo2(ByVal ctrl As DevExpress.XtraEditors.LookUpEdit, ByVal strTableName As String, ByVal strFldCode As String, ByVal strFldName As String, Optional ByVal strCondition As String = "", Optional ByVal bolCompId As Boolean = True, Optional ByVal strOrderBy As String = "", Optional ByVal SelectItem As ComboLoadItemSelect = ComboLoadItemSelect.Min)

    '    ctrl.Properties.DisplayMember = Nothing : ctrl.Properties.DataSource = Nothing : ctrl.Properties.ValueMember = Nothing
    '    If strCondition = "" Then
    '        strSQL = "SELECT " & strFldName & "," & strFldCode & " FROM " & strTableName & ""
    '    Else
    '        strSQL = "SELECT * FROM " & strTableName & " WHERE " & strCondition
    '    End If
    '    If strTableName <> "Tblc_BranchCode" Then
    '        If bolCompId = True Then
    '            If strCondition <> "" Then
    '                strSQL = strSQL & " and CompanyID=" & "'" & strCompanyID & "'"
    '            Else
    '                strSQL = strSQL & " WHERE CompanyID=" & "'" & strCompanyID & "'"
    '            End If
    '        End If
    '    End If
    '    If strOrderBy <> "" Then
    '        strSQL = strSQL & " ORDER BY " & strOrderBy
    '    End If
    '    If DataType = DataConnection.SqlServer Then
    '        Dim Dp As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSQL, CON)
    '        Dim ds2 As New DataSet
    '        Dp.Fill(ds2, strTableName)
    '        ctrl.Properties.DisplayMember = "" & strTableName & "." & strFldName & ""
    '        ctrl.Properties.ValueMember = "" & strTableName & "." & strFldCode & ""
    '        ctrl.Properties.DataSource = ds2.Tables(0)
    '    ElseIf DataType = DataConnection.Access Then
    '        Dim Dp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
    '        Dim ds2 As New DataSet
    '        Dp.Fill(ds2, strTableName)
    '        ctrl.Properties.DisplayMember = "" & strTableName & "." & strFldName & ""
    '        ctrl.Properties.ValueMember = "" & strTableName & "." & strFldCode & ""
    '        ctrl.Properties.DataSource = ds2
    '    End If
    '    If SelectItem = ComboLoadItemSelect.Min Then
    '        If ctrl.Properties.DropDownRows <> 0 Then ctrl.ItemIndex = 0
    '    ElseIf SelectItem = ComboLoadItemSelect.Max Then
    '        If ctrl.Properties.DropDownRows <> 0 Then ctrl.ItemIndex = ctrl.Properties.DropDownRows - 1
    '    End If
    'End Sub

    Public Sub SFillComboGrid(ByVal ctrl As DataGridViewComboBoxColumn, ByVal strTableName As String, ByVal strFldCode As String, ByVal strFldName As String, Optional ByVal strCondition As String = "")
        If strCondition = "" Then
            strSQL = "SELECT * FROM " & strTableName & ""
        Else
            strSQL = "SELECT * FROM " & strTableName & " WHERE " & strCondition
        End If
        If DataType = DataConnection.SqlServer Then
            Dim Dp As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSQL, CON)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)
            ctrl.DisplayMember = "" & strTableName & "." & strFldName & ""
            ctrl.ValueMember = "" & strTableName & "." & strFldCode & ""
            ctrl.DataSource = ds2
        ElseIf DataType = DataConnection.Access Then
            Dim Dp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)
            ctrl.DisplayMember = "" & strTableName & "." & strFldName & ""
            ctrl.ValueMember = "" & strTableName & "." & strFldCode & ""
            ctrl.DataSource = ds2
        End If
    End Sub

    Public Sub SFillTextBoxGrid(ByVal col As AutoCompleteStringCollection, ByVal strTableName As String, ByVal strFldCode As String, ByVal strFldName As String, Optional ByVal strCondition As String = "", Optional ByVal bolCompId As Boolean = True, Optional ByVal strOrderBy As String = "")
        If strCondition = "" Then
            strSQL = "SELECT * FROM " & strTableName & ""
        Else
            strSQL = "SELECT * FROM " & strTableName & " WHERE " & strCondition
        End If
        If strTableName <> "Tblc_BranchCode" Then
            If bolCompId = True Then
                If strCondition <> "" Then
                    strSQL = strSQL & " and CompanyID=" & "'" & strCompanyID & "'"
                Else
                    strSQL = strSQL & " WHERE CompanyID=" & "'" & strCompanyID & "'"
                End If
            End If
        End If
        If strOrderBy <> "" Then
            strSQL = strSQL & " ORDER BY " & strOrderBy
        End If
        If DataType = DataConnection.SqlServer Then
            Dim Dp As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSQL, CON)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)

            Dim r As DataRow : Dim dt As New DataTable : Dp.Fill(dt)
            For Each r In dt.Rows
                col.Add(r.Item(strFldName).ToString)
            Next
        ElseIf DataType = DataConnection.Access Then
            Dim Dp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            Dim ds2 As New DataSet
            Dp.Fill(ds2, strTableName)

            Dim r As DataRow : Dim dt As New DataTable : Dp.Fill(dt)
            For Each r In dt.Rows
                col.Add(r.Item(strFldName).ToString)
            Next
        End If
    End Sub

    Public Function FGetMaxNum(ByVal strTblName As String, ByVal strFldName As String, Optional ByVal IDCom As Boolean = False, Optional ByVal IDUser As Boolean = False) As String
        Return FGetColumnValue(strTblName, strFldName, Expresion.Max, IDCom, IDUser)
    End Function

    Public Function FMax(ByVal strField As String, ByVal strTable As String, Optional ByVal strCondition As String = "", Optional ByVal IDCom As Boolean = False, Optional ByVal IDUser As Boolean = False) As Object

        Dim sqlTmp As String = "select max((" & strField & ")) from " & strTable
        If IDCom = True Then
            sqlTmp = sqlTmp & " Where CompanyID=" & "'" & strCompanyID & "'"
        End If
        If IDUser = True Then
            sqlTmp = sqlTmp & " And UserID='" & strUserID & "'"
        End If
        If strCondition <> "" Then
            sqlTmp = sqlTmp & " And " & strCondition
        End If

        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(sqlTmp, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            If dr.Read() = True Then
                If dr.IsDBNull(0) Then
                    FMax = Nothing
                Else
                    FMax = dr.GetValue(0)
                End If
                dr.Close()
            Else
                Return Nothing
            End If
        ElseIf DataType = DataConnection.Access Then
            Dim cmd As New OleDb.OleDbCommand(sqlTmp, CONAccess)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            If dr.Read() = True Then
                If dr.IsDBNull(0) Then
                    FMax = Nothing
                Else
                    FMax = Int(dr.GetValue(0))
                End If
                dr.Close()
            Else
                Return Nothing
            End If
        End If
    End Function

    'Public Function FAutoNumber(ByVal strTblName As String, ByVal strFldName As String, Optional ByVal IDCom As Boolean = True, Optional ByVal IDUser As Boolean = False, Optional ByVal strCondition As String = "") As String
    '    Dim x As String = (FGetMaxNum(strTblName, strFldName, IDCom, IDUser))
    '    If x = Nothing Then
    '        Return "1"
    '    Else
    '        Return (Val(CStr(CDbl(FMax((strFldName), strTblName, strCondition, IDCom, IDUser) + 1))))
    '    End If
    'End Function

    Public Function FAutoNumber(ByVal strTblName As String, ByVal strFldName As String, Optional ByVal IDCom As Boolean = True, Optional ByVal IDUser As Boolean = False, Optional ByVal strCondition As String = "") As String
        Dim x As String = ""

        If DataType = DataConnection.Access Then
            x = (CStr(CDbl(FMax("Val(" & strFldName & ")", strTblName, strCondition, IDCom, IDUser) + 1)))
        ElseIf DataType = DataConnection.SqlServer Then
            x = (FGetMaxNum(strTblName, "CONVERT(float," & strFldName & ")", IDCom, IDUser))
        End If

        If x = Nothing Then
            Return "1"
        Else
            'Convert .ToInt16 ("")
            'Return (Val(CStr(CDbl(FMax((strFldName), strTblName, strCondition, IDCom, IDUser) + 1)))) ' خطأ
            If DataType = DataConnection.Access Then
                Return (CStr(CDbl(FMax("Val(" & strFldName & ")", strTblName, strCondition, IDCom, IDUser) + 1)))
            ElseIf DataType = DataConnection.SqlServer Then
                Return (CStr(CDbl(FMax("CONVERT(float," & strFldName & ")", strTblName, strCondition, IDCom, IDUser) + 1)))
            End If

        End If
    End Function

    Public Function FMIN(ByVal strField As String, ByVal strTable As String, Optional ByVal strCondition As String = "", Optional ByVal IDCom As Boolean = False, Optional ByVal IDUser As Boolean = False) As Object
        Try
            Dim sqlTmp As String = "select MIN(" & strField & ") from " & strTable
            If IDCom = True Then
                sqlTmp = sqlTmp & " Where CompanyID=" & "'" & strCompanyID & "'"
            End If
            If IDUser = True Then
                sqlTmp = sqlTmp & " And UserID='" & strUserID & "'"
            End If

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sqlTmp, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.IsDBNull(0) Then
                        FMIN = Nothing
                    Else
                        FMIN = dr.GetValue(0)
                    End If
                    dr.Close()
                Else
                    Return Nothing
                End If
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sqlTmp, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.IsDBNull(0) Then
                        FMIN = Nothing
                    Else
                        FMIN = Int(dr.GetValue(0))
                    End If
                    dr.Close()
                Else
                    Return Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Public Function FindValue(ByVal TabelName As String, ByVal FindWhate As String, ByVal ColumnName As String) As Boolean
        'If CON.State = ConnectionState.Closed Then CON.Open()
        ''يمكنك من هذا الاجراء البحث داخل عمود معين عن قيمه معينه بمعلومية اسم الجدول واسم العمود والقيمه التى تبحث عنها
        Dim sql As String = "select " & ColumnName & " from " & TabelName & " where " & ColumnName & " = '" & FindWhate & "'"
        Dim cmd As New SqlClient.SqlCommand(sql, CON)
        Dim dr As SqlClient.SqlDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            Return True
        Else
            Return False
        End If
        'CON.Close()
    End Function

    '' يمكنك من هذا الاجراء البحث داخل عمود معين عن قيمه معينه بمعلومية اسم الجدول واسم العمود والقيمه التى تبحث عنها فى سجلات الجدول والنتيجه تكون اما صح او خطأ فأذا كانت القيمه 
    '' التى تبحث عنها موجوده فى الاجراء يعود بصح اما لو كانت القيمه غير موجوده فأن الاجراء يعود بخطأ
    Public Function FFindValue(ByVal TabelName As String, ByVal FindWhate As String, ByVal ColumnName As String) As Boolean
        Try
            Dim sql As String = "select " & ColumnName & " from " & TabelName & " where " & ColumnName & " = '" & FindWhate & "'"
            Dim cmd As New SqlClient.SqlCommand(sql, CON)
            Dim rr As SqlClient.SqlDataReader
            rr = cmd.ExecuteReader
            If rr.HasRows = True Then
                Return True
            Else
                Return False
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Function

    ''' يستخدم هذا الاجراء فى تكوين جملة الاستعلام التى يتم كتابتها  فى اجراء الاضافه او الحذف او التعديل
    ''' بحيث يمكنك ادخال مصفوفة من اسماء الاعمده وقوم هذا الاجراء بتحويل هذه المصفوفه الى نص يمكن استخدمه فى جملة الاستعلام
    Private Function FGetArray(ByVal value As String()) As String
        Dim r As String
        For g As Integer = 0 To value.Length - 1
            Select Case g
                Case Is = 0
                    r = "'" & value(g)
                Case Is = value.Length - 1
                    r += "','" & value(g) & "')"
                Case Else
                    r += "','" & value(g)
            End Select
        Next
        Return r
    End Function

    Private Function FGetArray(ByVal value As List(Of String)) As String
        Dim r As String
        For g As Integer = 0 To value.Count - 1
            Select Case g
                Case Is = 0
                    r = "'" & value(g)
                Case Is = value.Count - 1
                    r += "','" & value(g) & "')"
                Case Else
                    r += "','" & value(g)
            End Select
        Next
        Return r
    End Function

    Private Function FGetArraySingle(ByVal value As String()) As String
        Dim r As String
        For g As Integer = 0 To value.Length - 1
            Select Case g
                Case Is = 0
                    r = "" & value(g)
                Case Is = value.Length - 1
                    r += "," & value(g) & ")"
                Case Else
                    r += "," & value(g)
            End Select
        Next
        Return r
    End Function

    Private Function FGetArraySingle(ByVal value As List(Of String)) As String
        Dim r As String
        For g As Integer = 0 To value.Count - 1
            Select Case g
                Case Is = 0
                    r = "" & value(g)
                Case Is = value.Count - 1
                    r += "," & value(g) & ")"
                Case Else
                    r += "," & value(g)
            End Select
        Next
        Return r
    End Function

    ''' يستخدم هذا الاجراء فى تكوين جملة الاستعلام التى يتم كتابتها  فى اجراء الاضافه او الحذف او التعديل
    ''' بحيث يمكنك ادخال مصفوفة من اسماء الاعمده ومصفوفه اخرى مساويه لطول مصفوفة الاعمده حيث يقوم هذا الاجراء بتحويل هذه المصفوفه الى نص يمكن استخدمه فى جملة الاستعلام
    Private Function FSetColumnArray(ByVal Column As String(), ByVal Value As String()) As String
        Dim r As String
        If Column.Length > 1 Then
            For g As Integer = 0 To Column.Length - 1
                Select Case g
                    Case Is = 0
                        r = " set " & Column(g) & " ='" & Value(g)
                    Case Is = Column.Length - 1
                        r += "', " & Column(g) & " ='" & Value(g) & "' where "
                    Case Else
                        r += "', " & Column(g) & " ='" & Value(g)
                End Select
            Next
        ElseIf Column.Length = 1 Then
            r = " set " & Column(0) & " ='" & Value(0) & "' where "
        End If
        Return r
    End Function

    Private Function FSetColumnArray(ByVal Column As List(Of String), ByVal Value As List(Of String)) As String
        Dim r As String
        If Column.Count > 1 Then
            For g As Integer = 0 To Column.Count - 1
                Select Case g
                    Case Is = 0
                        r = " set " & Column(g) & " ='" & Value(g)
                    Case Is = Column.Count - 1
                        r += "', " & Column(g) & " ='" & Value(g) & "' where "
                    Case Else
                        r += "', " & Column(g) & " ='" & Value(g)
                End Select
            Next
        ElseIf Column.Count = 1 Then
            r = " set " & Column(0) & " ='" & Value(0) & "' where "
        End If
        Return r
    End Function

    Public Function FAddNewRecord(ByVal TabelName As String, ByVal Columns As String, ByVal Values As String, ByVal bolCompId As Boolean)
        Try
            Dim sql As String = "insert into " & TabelName & "(" & Columns & ")" & " values( " & (Values) & ")"
            If bolCompId = True Then
                sql = sql & " and CompanyID=" & "'" & strCompanyID & "'"
            End If
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As OleDb.OleDbException
            MsgBox(ex.Message)
        End Try
    End Function

    ''' يمكنك من خلال هذا الاجراء اضافة سجل جديد بمعلومية اسم الجدول ومصفوفة الاعمده التى تريد ان تضيف اليها السجل الجديد وايضا بمعلومية مصفوفة القيم المدخله للاعمده  مع العلم انه يجب 
    ''' ان تتساوى مصفوفة اسماء الاعمده مع مصفوفة القيم المدخله فى  طول كل مصفوفه 
    Public Function FAddNewRecord(ByVal TabelName As String, ByVal Columns As String(), ByVal Values As String())
        Try
            Dim sql As String = "insert into " & TabelName & "(" & FGetArraySingle(Columns) & " values( " & FGetArray(Values)
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As OleDb.OleDbException
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FAddNewRecord(ByVal TabelName As String, ByVal Columns As List(Of String), ByVal Values As List(Of String), Optional ByVal bolCompId As Boolean = False)
        Try
            Dim sql As String = "insert into " & TabelName & "(" & FGetArraySingle(Columns) & " values( " & FGetArray(Values)
            If bolCompId = True Then
                sql = sql & " WHERE CompanyID='" & strCompanyID & "'" & ";"
            End If
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As OleDb.OleDbException
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FAddNewRecord2(ByVal TabelName As String, ByVal Columns As List(Of String), ByVal Values As List(Of String)) As Integer
        Try
            If DataType = DataConnection.SqlServer Then
                Dim sql As String = "insert into " & TabelName & "(" & FGetArraySingle(Columns) & " Output inserted.ID values( " & FGetArray(Values)
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                Return cmd.ExecuteScalar()
            Else
                Dim sql As String = "insert into " & TabelName & "(" & FGetArraySingle(Columns) & " values( " & FGetArray(Values)
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Select @@Identity"
                Return cmd.ExecuteScalar()
            End If
            '''''''''''''''''''''''''
        Catch ex As OleDb.OleDbException
            MsgBox(ex.Message)
        End Try
    End Function

    ''' يمكنك هذا الاجراء من اضافة سجل جديد الى جدول معين بمعلومية اسم الجدول والقيم المدخله 
    ''' وسيقوم الاجراء بأضافة السجل الى الجدول بترتيب الحقول على اساس القيم المدخله
    Public Function FAddNewRecord(ByVal TabelName As String, ByVal ParamArray Values As String())
        Try
            Dim sql As String = "insert into " & TabelName & " values ( " & FGetArray(Values)
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                'sql = "insert into Tblc_CustCode([YearlyInstallments],[YearPayment],[Payment],[HalfYearInstallments],[ForthInstallments],[halfYearPayment],[MonthlyPayment],[ForthPayment],[monthlyInstallments],[InstallmentsCount],[Survivor],[FirstPay],[InstallmentsTotal],[Parking],[MeterPrice],[Area],[Pathroom],[RoomsCount],[Department],[UnitNum],[RecieiveDate],[PurchDate],[Notes],[Name],[Add],[Mobile2],[Tel1],[Tel2],[Mobile],[IdNum],[Religion],[Nationality],[IdArea],[IdDate],[ManId],[CustType],[Code]) values( '2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','09/10/2009','09/10/2009','2','2','2','2','2','2','2','2','2','2','2','09/10/2009','2','1','22')"
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As OleDb.OleDbException
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FEditeRecord(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String, ByVal CompanyID As Boolean, ByVal Columns As String(), ByVal ParamArray Values As String()) As Boolean
        Try
            Dim sql As String '= "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value & " and CompanyID=" & "'" & strCompanyID & "'"

            If CompanyID = True Then
                sql = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value & " and CompanyID=" & "'" & strCompanyID & "'"
            Else
                sql = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value
            End If
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
                Return True
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            Return False
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' يمكنك استخدام هذا الاجراء لكى تقوم بعملية تعديل على  سجل موجود فعلا فى قاعدة البيانات  بمعلومية اسم الجدول واسم العمود والقيمه الشرطيه للسجل او قيمة مفتاح السجل
    '''  وبمعلومية مصفوفه الاعمده التى يتم التعديل عليها وايضا مصفوفة القيم التى سيتم اضافتها داخل هذه الاعمده 
    ''' 

    Public Function FEditeRecord(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String, ByVal Columns As String(), ByVal ParamArray Values As String()) As Boolean
        Try
            Dim sql As String = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
                Return True
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            Return False
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
            Return False
        End Try
    End Function

    'Public Function FEditeRecord(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String, ByVal Columns As List(Of String), ByVal Values As List(Of String), Optional ByVal bolCompId As Boolean = False) As Boolean
    '    Try
    '        Dim sql As String = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value
    '        If DataType = DataConnection.SqlServer Then
    '            Dim cmd As New SqlClient.SqlCommand(sql, CON)
    '            cmd.ExecuteNonQuery()
    '            Return True
    '        ElseIf DataType = DataConnection.Access Then
    '            Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
    '            cmd.ExecuteNonQuery()
    '            Return True
    '        End If
    '    Catch ex As SqlClient.SqlException
    '        MsgBox(ex.Message)
    '        Return False
    '    Catch Exp As OleDb.OleDbException
    '        MsgBox(Exp.Message)
    '        Return False
    '    End Try
    'End Function

    Public Function FEditeRecord(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String, ByVal CompanyID As Boolean, ByVal UserID As Boolean, ByVal Columns As List(Of String), ByVal Values As List(Of String)) As Boolean
        Try
            Dim sql As String '= "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value & " and CompanyID=" & "'" & strCompanyID & "'"

            sql = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value

            If CompanyID = True Then
                sql = sql & " and CompanyID=" & "'" & strCompanyID & "'"
            End If

            If UserID = True Then
                sql = sql & " and UserID=" & "'" & strUserID & "'"
            End If


            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
                Return True
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            Return False
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
            Return False
        End Try
    End Function

    Public Function FEditeRecord(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String, ByVal CompanyID As Boolean, ByVal strCondition As String, ByVal Columns As String(), ByVal ParamArray Values As String()) As Boolean
        Try
            Dim sql As String = ""
            If CompanyID = True Then
                sql = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value & " and CompanyID=" & "'" & strCompanyID & "'"
            Else
                sql = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value
            End If
            If strCondition <> "" Then
                sql = sql & " And " & strCondition
            End If
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
                Return True
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            Return False
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
            Return False
        End Try
    End Function

    Public Function FEditeRecord(ByVal TabelName As String, ByVal ColumnName As String, ByVal value As String, ByVal Columns As List(Of String), ByVal Values As List(Of String), Optional ByVal CompanyID As Boolean = False) As Boolean
        Try
            Dim sql As String = ""
            If CompanyID = True Then
                sql = "update " & TabelName & FSetColumnArray(Columns, Values) & ColumnName & " = " & value & " and CompanyID=" & "'" & strCompanyID & "'"
            Else
                sql = "update " & TabelName & FSetColumnArray(Columns, Values) & ColumnName & " = " & value
            End If
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
                Return True
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
        End Try
    End Function

    Public Function FEditeRecord(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String, ByVal CompanyID As Boolean, ByVal UserID As Boolean, ByVal Columns As String(), ByVal ParamArray Values As String()) As Boolean
        Try
            Dim sql As String '= "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value & " and CompanyID=" & "'" & strCompanyID & "'"

            sql = "update " & Tabelname & FSetColumnArray(Columns, Values) & ColumnName & " = " & value

            If CompanyID = True Then
                sql = sql & " and CompanyID=" & "'" & strCompanyID & "'"
            End If

            If UserID = True Then
                sql = sql & " and UserID=" & "'" & strUserID & "'"
            End If


            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
                Return True
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            Return False
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
            Return False
        End Try
    End Function

    Public Function FInsertVal(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String, ByVal strCondition As String, Optional ByVal CompanyID As Boolean = True) As Boolean
        Try
            Dim sql As String = ""
            If strCondition = "" Then
                sql = "update " & Tabelname & " SET " & ColumnName & "=" & value
            Else
                sql = "update " & Tabelname & " SET " & ColumnName & "=" & value & " WHERE " & strCondition
            End If
            If CompanyID = True Then sql = sql & " AND CompanyID=" & "'" & strCompanyID & "'"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
                Return True
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            Return False
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
            Return False
        End Try
    End Function

    ''' لتحديد نطاق عمل الاجراء   
    '''GetColumnValue
    '''تستخدم هذه الترقيمه مع الاجراء
    Public Enum Expresion
        ''' لمعرفة اكبر قيمة سجل فى عمود معين
        Max
        ''' لمعرفة اصغر قيمة سجل فى عمود معين
        Min
        ''' اجراء عملية جمع لجميع السجلات فى  عمود معين
        Sum
        ''' اجراء عملية الجمع لجميع السجلات الموجوده فىعمود معين ووضعها فى مجموعات حسب حقول معينه
        Sum_Groups
        ''' لايجاد الوسط الحسابى للقيم الموجوده فى عمود معين
        Averg
        ''' لمعرفة عدد الصفوف فى العمود بدون السجلات الفارغه
        Count
        ''' لمعرفة عدد السجلات بالكامل فى العمود
        Count_All
        ''' لمعرفة قيمة اول سجل قى عمود معين
        FirstValue
        ''' لمعرفة قيمة اخر سجل فى عمود معين
        LastValue
    End Enum

    Public Function FGetColumnValue(ByVal Tabelname As String, ByVal ColumnName As String, ByVal Expresion As Expresion, Optional ByVal IDCom As Boolean = False, Optional ByVal IDUser As Boolean = False, Optional ByVal IDIndex As String = "", Optional ByVal strCondition As String = "") As Object
        Try
            Dim strsqlStatement As String
            Select Case Expresion
                'Case Is = modMyData.Expresion.Averg
                Case Is = Expresion.Averg
                    strsqlStatement = "select avg(" & ColumnName & ") from " & Tabelname
                Case Is = Expresion.Count
                    If IDCom = False Then
                        strsqlStatement = "select count(" & ColumnName & ") from " & Tabelname
                    Else
                        strsqlStatement = "select count(" & ColumnName & ") from " & Tabelname & " Where CompanyID=" & "'" & strCompanyID & "'"
                        If strCondition <> "" Then strsqlStatement = strsqlStatement & " And " & strCondition
                    End If
                Case Is = Expresion.Count_All
                    strsqlStatement = "select count(*) from " & Tabelname
                Case Is = Expresion.FirstValue
                    strsqlStatement = "select first(" & ColumnName & ") from " & Tabelname
                Case Is = Expresion.LastValue
                    strsqlStatement = "select last(" & ColumnName & ") from " & Tabelname
                Case Is = Expresion.Max
                    If IDCom = False Then
                        strsqlStatement = "select max(" & ColumnName & ") from " & Tabelname
                    Else
                        strsqlStatement = "select max(" & ColumnName & ") from " & Tabelname & " Where CompanyID=" & "'" & strCompanyID & "'"

                    End If
                    If IDUser = True Then
                        strsqlStatement = strsqlStatement & " and UserID=" & "'" & strUserID & "'"
                    End If
                Case Is = Expresion.Min
                    strsqlStatement = "select min(" & ColumnName & ") from " & Tabelname
                Case Is = Expresion.Sum
                    If strCondition = "" Then
                        strsqlStatement = "select sum(" & ColumnName & ") from " & Tabelname
                    Else
                        strsqlStatement = "select sum(" & ColumnName & ") from " & Tabelname & " Where " & strCondition
                    End If
            End Select
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strsqlStatement, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.IsDBNull(0) Then
                        FGetColumnValue = Nothing
                    Else
                        FGetColumnValue = dr.GetValue(0)
                    End If
                    dr.Close()
                Else
                    Return Nothing
                End If
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strsqlStatement, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.IsDBNull(0) Then
                        FGetColumnValue = Nothing
                    Else
                        FGetColumnValue = dr.GetValue(0)
                    End If
                    dr.Close()
                Else
                    Return Nothing
                End If
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Function

    Public Function FGetColumnValue(ByVal Tabelname As String, ByVal ColumnName As String, ByVal ColumnNameGroup As String, Optional ByVal Expresion As Expresion = Expresion.Sum_Groups) As SqlClient.SqlDataReader
        Try
            Dim sql As String = "select " & ColumnNameGroup & "sum(" & ColumnName & " from " & Tabelname & "group by" & ColumnNameGroup
            Dim cmd As New SqlClient.SqlCommand(sql, CON)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader
            Return dr
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Function

    Public Sub FDeleteRecord(ByVal Tabelname As String, ByVal ColumnName As String, ByVal value As String)
        Try
            Dim sql As String = "DELETE FROM " & Tabelname & " WHERE " & ColumnName & "= " & "'" & value & "'"
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub FDeleteRecord(ByVal Tabelname As String, ByVal strCondition As String)
        Try
            Dim sql As String = "DELETE FROM " & Tabelname & " WHERE " & strCondition
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub FDeleteRecord(ByVal Tabelname As String)
        Try
            Dim sql As String = "DELETE FROM " & Tabelname & " "
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(sql, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(sql, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub CompactAccessDB(ByVal connectionString As String, ByVal mdwfilename As String)
        Try
            Dim x As String = Now.Date
            If Now.DayOfWeek.ToString = "Thursday" Then
                If FGetFeildValues("Tblu_DatabaseMaintenance", "MaintenanceDate", "", False, False) <> Now.Date.Day.ToString Then
                    If IO.File.Exists(Application.StartupPath & "\Compact.mdb") Then
                        IO.File.Delete(Application.StartupPath & "\Compactmdb")
                    End If

                    If IO.Directory.Exists(Application.StartupPath & "\DataCopy") = False Then
                        'ان لم يكن موجد يقوم بانشاء مجلد جديد
                        IO.Directory.CreateDirectory(Application.StartupPath & "\DataCopy")
                        ''انشاء مجلد جديد في وضع مخفي
                        'IO.Directory.CreateDirectory(Application.StartupPath & "\DataCopy").Attributes = FileAttributes.Hidden
                    End If

                    ' كود ضغط واصلاح قاعدة البيانات
                    Dim Engine
                    Engine = CreateObject("JRO.JetEngine")
                    Engine.CompactDatabase("provider=microsoft.jet.oledb.4.0;data source=" & Application.StartupPath & "\Data\Data.mdb;user id=admin;jet oledb:database password=gtmmr", _
                                           "provider=microsoft.jet.oledb.4.0;data source=" & Application.StartupPath & "\Data\Compact.mdb;user id=admin;jet oledb:database password=gtmmr")
                    'كود حذف قاعدة البيانات القديمة
                    Kill(Application.StartupPath & "\Data\Data.mdb")
                    'كود اعادة تسمية قاعدة البيانات التي تم ضغطها واصلاحها
                    My.Computer.FileSystem.RenameFile(Application.StartupPath & "\Data\Compact.mdb", "Data.mdb")
                    'كود التحقق من وجود المجلد DataCopy
                    'Call FDeleteRecord("Tblu_DatabaseMaintenance")
                    'Call FAddNewRecord("Tblu_DatabaseMaintenance", "MaintenanceDate", Now.Date.ToString, False)
                    BolCompactDataDate = True
                Else
                    BolCompactDataDate = False  ' عدم مطابقة التاريخ
                End If
            Else
                BolCompactDataDate = False '   عدم مطابقة اليوم
            End If
            'كود نسخة قاعدة البيانات باسخدام البروجريس بار والتاريخ
            'Dim CopyFrom, CopyTo As String
            'Dim Ddatee As Date = Date.Today
            'Dim Ddate As String

            'Ddate = Format(Ddatee, "dd-MM-yyyy")
            'CopyFrom = Application.StartupPath & "\Data\Data.mdb"
            'CopyTo = Application.StartupPath & "\DataCopy\" & Ddate & ".mdb"

            ''ProgressBar1.Visible = True

            'Dim sr As New IO.FileStream(CopyFrom, IO.FileMode.Open) 'source file
            'Dim sw As New IO.FileStream(CopyTo, IO.FileMode.Create) 'target file, defaults overwrite
            'Dim len As Long = sr.Length - 1

            'For i As Long = 0 To len
            '    sw.WriteByte(sr.ReadByte)
            '    If i Mod 1000 = 0 Then
            '        Application.DoEvents()
            '        'ProgressBar1.Value = i * 100 / len
            '        'Label1.Text = ProgressBar1.Value & "% Completed "
            '    End If
            'Next
            'كود البحث عن قواعد البيانات لغاية قبل شهر من تاريخ اليوم ويقوم بحذفها مع ترك اخر قاعدتين بتاريخ قبل يوم
            'Dim a, b As Date
            'Dim c, d As String
            'Dim Ddatee As Date = Date.Today

            'a = DateAdd("d", -1, Ddatee)
            'b = DateAdd("m", -1, Ddatee)
            'c = Format(a, "dd-MM-yyyy")
            'd = Format(b, "dd-MM-yyyy")
            'Do Until d = c
            '    If IO.File.Exists(Application.StartupPath & "\DataCopy\" & d & ".mdb") = True Then
            '        Kill(Application.StartupPath & "\DataCopy\" & d & ".mdb")
            '    End If
            '    d = DateAdd("d", 1, d)
            '    Dim f As Date = d
            '    Dim g As String
            '    g = Format(f, "dd-MM-yyyy")
            '    d = g
            'Loop
            'Application.DoEvents()

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "لم يتم عمل صيانة لقاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("لم تكتمل عملية الصيانة", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
            BolCompactDataDate = False
        End Try
    End Sub

    Public Sub SInsertDataCompactDate()
        'Dim arrVal() As String = {}
        'Dim strDate As String = FFormatDate(Now)

        'ReDim Preserve arrVal(arrVal.Length)
        'arrVal(arrVal.Length - 1) = strCompanyID

        'FAddNewRecord(tabCtl.Tag, arrCtl, arrVal)
        Call FDeleteRecord("Tblu_DatabaseMaintenance")
        '', "dd-MM-yyyy")

        ''FInsertVal("Tblu_DatabaseMaintenance", "MaintenanceDate", strDate, "", False)
        Call FAddNewRecord("Tblu_DatabaseMaintenance", "MaintenanceDate", Now.Date.Day.ToString, False)
    End Sub

    Public Function FCloseAndEndData() As Boolean
        'المخازن
        Dim strSqlQry As String
        Try
            Call FDeleteRecord("Tblu_CloseItemTran")

            strSqlQry = "INSERT INTO Tblu_CloseItemTran ( ItemCode, StoreCode, SignQuantity, CompanyID )" & _
            " SELECT Tblt_ItemTran.ItemCode, Tblt_ItemTran.StoreCode, Sum(Tblt_ItemTran.SignQuantity) AS SumOfSignQuantity, Tblt_ItemTran.CompanyID" & _
            " FROM Tblt_ItemTran" & _
            " GROUP BY Tblt_ItemTran.ItemCode, Tblt_ItemTran.StoreCode, Tblt_ItemTran.CompanyID;"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            Return False
        End Try
        'المخازن
        'العملاء
        strSqlQry = ""
        Try
            Call FDeleteRecord("Tblu_CloseCustTran")

            strSqlQry = "INSERT INTO Tblu_CloseCustTran ( CustCode, SignValue, CompanyID )" & _
            " SELECT Tblt_CustomerTran.CustCode, Sum(Tblt_CustomerTran.SignValue) AS SumOfSignValue, Tblt_CustomerTran.CompanyID" & _
            " FROM(Tblt_CustomerTran)" & _
            " GROUP BY Tblt_CustomerTran.CustCode, Tblt_CustomerTran.CompanyID;"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            Return False
        End Try
        'العملاء
        'الموردين
        strSqlQry = ""
        Try
            Call FDeleteRecord("Tblu_CloseVendTran")

            strSqlQry = "INSERT INTO Tblu_CloseVendTran ( VendCode, SignValue, CompanyID )" & _
            " SELECT Tblt_VendorTran.VendCode, Sum(Tblt_VendorTran.SignValue) AS SumOfSignValue, Tblt_VendorTran.CompanyID" & _
            " FROM(Tblt_VendorTran)" & _
            " GROUP BY Tblt_VendorTran.VendCode, Tblt_VendorTran.CompanyID;"
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If

        Catch Exp As OleDb.OleDbException
            'MsgBox(Exp.Message)
            Return False
        End Try
        'الموردين
        If FCopyCloseData() = True Then
            'Call frmDelData.SDelTranData()
        End If
        Call SSaveFirstStore()
        Call SSaveFirstCust()
        Call SSaveFirstVend()
        Return True
    End Function

    Private Function FCopyCloseData() As Boolean
        Try
            If IO.Directory.Exists(Application.StartupPath & "\Data\Closed Data") = False Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\Data\Closed Data")
            End If
            Dim strFilePath As String = Application.StartupPath & "\Data\Closed Data\" & Format(Now, "dd-MM-yyyy")
            IO.Directory.CreateDirectory(strFilePath)
            IO.File.Copy(Application.StartupPath & "\Data\Data.mdb", strFilePath & "\Data.mdb", True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkOnly, ProgName)
            Return False
        End Try
    End Function

    Private Sub SSaveFirstStore()
        'strSQL = "Select * from Tblu_CloseItemTran"
        'If DataType = DataConnection.SqlServer Then
        '    Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
        '    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
        '    Dim i As Integer = 1
        '    Dim bolSaveTbl As Boolean = False
        '    Do While dr.Read
        '        Dim strDocNo As String = FAutoNumber("Tblt_StockInput", "DocNo", True, False)
        '        If bolSaveTbl = False Then
        '            Dim strTblData() As String = {1, strDocNo, Now.Date, "2", "0", dr("StoreCode"), 0, 0, strUserID, dr("CompanyID")}
        '            FAddNewRecord("Tblt_StockInput", strTblData)
        '            bolSaveTbl = True ' تم الحفظ في الجدول لمرة واحدة 
        '        End If
        '        Dim strTblDataGrid() As String = {strDocNo, dr("ItemCode"), dr("SignQuantity"), 0, i, strUserID, dr("CompanyID")}
        '        FAddNewRecord("Tblt_StockInputGrid", strTblDataGrid)
        '        i += 1
        '    Loop
        '    dr.Close()
        'ElseIf DataType = DataConnection.Access Then
        '    Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
        '    Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
        '    Dim i As Integer = 1
        '    Dim bolSaveTbl As Boolean = False
        '    Dim strDocNo As String
        '    Do While dr.Read
        '        If bolSaveTbl = False Then
        '            strDocNo = FAutoNumber("Tblt_StockInput", "DocNo", True, False)
        '            Dim strTblData() As String = {1, strDocNo, Now.Date, "2", "0", dr("StoreCode"), 0, 0, strUserID, dr("CompanyID")}
        '            FAddNewRecord("Tblt_StockInput", strTblData)
        '            bolSaveTbl = True ' تم الحفظ في الجدول لمرة واحدة 
        '        End If
        '        Dim strTblDataGrid() As String = {strDocNo, dr("ItemCode"), dr("SignQuantity"), 0, i, strUserID, dr("CompanyID")}
        '        FAddNewRecord("Tblt_StockInputGrid", strTblDataGrid)
        '        i += 1
        '    Loop
        '    dr.Close()
        'End If
        strSQL = "Select * from Tblu_CloseItemTran"
        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            Dim i As Integer = 1
            Do While dr.Read
                Dim strDocNo As String = 0
                Dim strTblData() As String = {strDocNo, "9", Now.Date, dr("ItemCode"), Math.Abs(dr("SignQuantity")), 0, dr("StoreCode"), 0, dr("SignQuantity"), 0, strUserID, dr("CompanyID")}
                FAddNewRecord("Tblt_ItemTran", strTblData)
                i += 1
            Loop
            dr.Close()
        ElseIf DataType = DataConnection.Access Then
            Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            Dim i As Integer = 1
            Do While dr.Read
                Dim strDocNo As String = 0
                Dim strTblData() As String = {strDocNo, "9", Now.Date, dr("ItemCode"), Math.Abs(dr("SignQuantity")), 0, dr("StoreCode"), 0, dr("SignQuantity"), 0, strUserID, dr("CompanyID")}
                FAddNewRecord("Tblt_ItemTran", strTblData)
                i += 1
            Loop
            dr.Close()
        End If
    End Sub

    Private Sub SSaveFirstCust()
        strSQL = "Select * from Tblu_CloseCustTran"
        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            Dim i As Integer = 1
            Do While dr.Read
                Dim strDocNo As String = 0
                Dim strTblData() As String = {strDocNo, Now.Date, "13", dr("CustCode"), dr("SignValue"), dr("SignValue"), strUserID, dr("CompanyID")}
                FAddNewRecord("Tblt_CustomerTran", strTblData)
                i += i
            Loop
            dr.Close()
        ElseIf DataType = DataConnection.Access Then
            Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            Dim i As Integer = 1
            Do While dr.Read
                Dim strDocNo As String = 0
                Dim strTblData() As String = {strDocNo, Now.Date, "13", dr("CustCode"), dr("SignValue"), dr("SignValue"), strUserID, dr("CompanyID")}
                FAddNewRecord("Tblt_CustomerTran", strTblData)
                i += i
            Loop
            dr.Close()
        End If
    End Sub

    Private Sub SSaveFirstVend()
        strSQL = "Select * from Tblu_CloseVendTran"
        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            Dim i As Integer = 1
            Do While dr.Read
                Dim strDocNo As String = 0
                Dim strTblData() As String = {strDocNo, Now.Date, "13", dr("VendCode"), dr("SignValue"), dr("SignValue"), strUserID, dr("CompanyID")}
                FAddNewRecord("Tblt_VendorTran", strTblData)
                i += i
            Loop
            dr.Close()
        ElseIf DataType = DataConnection.Access Then
            Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            Dim i As Integer = 1
            Do While dr.Read
                Dim strDocNo As String = 0
                Dim strTblData() As String = {strDocNo, Now.Date, "13", dr("VendCode"), dr("SignValue"), dr("SignValue"), strUserID, dr("CompanyID")}
                FAddNewRecord("Tblt_VendorTran", strTblData)
                i += i
            Loop
            dr.Close()
        End If
    End Sub

    'Private Sub FindText()
    '    Dim objWordApp As Word.Application
    '    objWordApp = CreateObject("Word.Application")
    '    'objWordApp.Visible = True

    '    'Open an existing document.  

    '    Dim objDoc As Word.Document = objWordApp.Documents.Open("C:\dfd.doc", )
    '    Dim findText As String = "template"

    '    objDoc.Content.Find.ClearFormatting()
    '    Try
    '        If objDoc.Content.Find.Execute(findText) = True Then
    '            MessageBox.Show("Text found.")
    '        Else
    '            MessageBox.Show("The text could not be found.")
    '        End If
    '        objDoc.Close()
    '        objWordApp.Quit()
    '    Catch ex As Exception
    '        objDoc.Close()
    '        objWordApp.Quit()
    '    End Try
    'End Sub

    '    Dim appWord As New Word.Application
    '    Dim docWord As New Word.Document
    'docWord = appWord.Documents.Open(“C:\Infofarm\test.doc”)
    'Try
    '    Dim myStoryRange As Microsoft.Office.Interop.Word.Range
    'For Each myStoryRange In docWord.StoryRanges
    'With myStoryRange.Find
    '.Text = “<-email->”
    '.Replacement.Text = “aaa@oooo.com”
    '.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
    '.Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
    'End With
    'Next myStoryRange
    'docWord.Save()
    'appWord.Quit()
    'docWord = Nothing
    'appWord = Nothing
    'Catch ex As Exception
    'MsgBox(ex.Message)
    'End Try

    '    Private Function FindWords(ByVal document As String) As Boolean
    '        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(document, False)
    '        Using (wordDoc)
    '            Dim docText As String = Nothing
    '            Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)

    '            Using (sr)
    '                docText = sr.ReadToEnd
    '            End Using

    '            Dim regexText As Regex = New Regex("Test Word")
    '            Dim m As Match = regexText.Match(docText)
    '            Return m.Success
    '        End Using
    '    End Function

End Module
