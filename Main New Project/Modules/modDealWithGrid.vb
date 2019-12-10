Public Module modDealWithGrid
    Dim arrCtl() As String = {} : Dim arrVal() As String = {} : Dim i As Integer
    Public Sub SDelGridData(ByVal grdCtl As DataGridView)
        Try
            grdCtl.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SAddGridRow(ByVal grdCtl As DataGridView)
        If grdCtl.CurrentRow.Index = grdCtl.Rows.Count - 1 Then
            grdCtl.AllowUserToAddRows = False
            grdCtl.Rows.Add()
            grdCtl.AllowUserToAddRows = True
        End If
    End Sub

    Public Function FCheckGrid(ByVal grdCtl As DataGridView, ByVal strGrdMessage As String) As Boolean
        If grdCtl.Enabled = True Then
            If grdCtl.RowCount = 1 Then
                MsgBox("من فضلك اكمل ادخال البيانات داخل الجريدة" & vbCrLf & " لم يتم ادخال البيانات بـ" & strGrdMessage, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                Return False
            Else
                For i As Integer = 0 To grdCtl.Rows.Count - 2
                    For x As Integer = 0 To grdCtl.Columns.Count - 1
                        If grdCtl.Columns(x).Visible = True Then
                            If grdCtl.Columns(x).CellType.Name = "DataGridViewTextBoxCell" Then
                                If grdCtl(x, i).ReadOnly = False Then
                                    Dim strTmp As String = grdCtl.Item(x, i).Value
                                    If strTmp = "" Then
                                        MsgBox("من فضلك اكمل ادخال البيانات داخل الجريدة" & vbCrLf & " يجب اكمال ادخال البيانات في " & strGrdMessage & vbCrLf & "في السطر رقم " & (i + 1) & "وفي عمود " & grdCtl.Columns(x).HeaderText, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) : Return False
                                    End If
                                End If
                            ElseIf grdCtl.Columns(x).CellType.Name = "DataGridViewCheckBoxCell" Then

                            End If
                        End If
                    Next
                Next
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Public Sub SSaveGrid(ByVal strTblName As String, ByVal grdCtl As DataGridView, ByVal strFldName As String, ByVal intDocNo As String, Optional ByVal strCondition As String = "", Optional ByVal bolUserId As Boolean = True, Optional ByVal bolStaticGrid As Boolean = False, Optional ByVal bolCompanyId As Boolean = True)
        Try
            Dim intMaxGidNo As Integer = 0

            If strCondition = "" Then
                Call FDeleteRecord(strTblName, strFldName & "=" & intDocNo)
            Else
                Call FDeleteRecord(strTblName, strFldName & "=" & intDocNo & " and " & strCondition & "'")
            End If
            ''''''''''''''''''''''''''''''''''''''''

            If bolStaticGrid = True Then
                intMaxGidNo = 1
            Else
                intMaxGidNo = 2
            End If
            For z As Integer = 0 To (grdCtl.Rows.Count - intMaxGidNo)
                i = 0 : arrCtl = Nothing : arrVal = Nothing
                For x As Integer = 0 To grdCtl.Columns.Count - 1
                    If grdCtl.Columns(x).Tag <> "" Then
                        Dim strTemp As String = grdCtl.Columns(x).Tag 'فقط لمعرفة تاج العمود
                        ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = "[" & grdCtl.Columns(x).Tag & "]" : arrVal(i) = grdCtl.Item(x, z).Value : i += 1
                        Dim s As Object = grdCtl.Columns(x).CellType
                        If grdCtl.Columns(x).CellType.Name = "DataGridViewCheckBoxCell" Then ' لو كانت خانة الجريدة تشك بوكس
                            If arrVal(i - 1) = "True" Then
                                arrVal(i - 1) = "1"
                            Else
                                arrVal(i - 1) = "0"
                            End If
                        ElseIf grdCtl.Columns(x).CellType.Name = "CalendarCell" Then
                            arrVal(i - 1) = FFormatDate(grdCtl.Item(x, z).Value)
                        End If
                    End If
                Next

                ReDim Preserve arrCtl(arrCtl.Length) : ReDim Preserve arrVal(arrVal.Length)
                arrCtl(arrCtl.Length - 1) = "[" & strFldName & "]" : arrVal(arrVal.Length - 1) = intDocNo

                If bolCompanyId = True Then
                    ReDim Preserve arrCtl(arrCtl.Length) : ReDim Preserve arrVal(arrVal.Length)
                    arrCtl(arrCtl.Length - 1) = "[CompanyID]" : arrVal(arrVal.Length - 1) = strCompanyID
                End If

                If bolUserId = True Then
                    ReDim Preserve arrCtl(arrCtl.Length) : ReDim Preserve arrVal(arrVal.Length)
                    arrCtl(arrCtl.Length - 1) = "[UserID]" : arrVal(arrVal.Length - 1) = strUserID
                End If
                Call FAddNewRecord(strTblName, arrCtl, arrVal)
            Next
            'Call SDelGridData(frmItemCode.DataGridView1)
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function FSaveGrid(ByVal strTblName As String, ByVal grdCtl As DataGridView, ByVal strFldName As String, ByVal intDocNo As String, Optional ByVal strCondition As String = "", Optional ByVal bolUserId As Boolean = True, Optional ByVal bolStaticGrid As Boolean = False, Optional ByVal bolCompanyId As Boolean = True) As Boolean
        Try
            Dim intMaxGidNo As Integer = 0

            If strCondition = "" Then
                Call FDeleteRecord(strTblName, strFldName & "=" & intDocNo)
            Else
                Call FDeleteRecord(strTblName, strFldName & "=" & intDocNo & " and " & strCondition & "'")
            End If
            ''''''''''''''''''''''''''''''''''''''''

            If bolStaticGrid = True Then
                intMaxGidNo = 1
            Else
                intMaxGidNo = 2
            End If
            For z As Integer = 0 To (grdCtl.Rows.Count - intMaxGidNo)
                i = 0 : arrCtl = Nothing : arrVal = Nothing
                For x As Integer = 0 To grdCtl.Columns.Count - 1
                    If grdCtl.Columns(x).Tag <> "" Then
                        Dim strTemp As String = grdCtl.Columns(x).Tag 'فقط لمعرفة تاج العمود
                        ReDim Preserve arrCtl(i) : ReDim Preserve arrVal(i) : arrCtl(i) = "[" & grdCtl.Columns(x).Tag & "]" : arrVal(i) = grdCtl.Item(x, z).Value : i += 1
                        Dim s As Object = grdCtl.Columns(x).CellType
                        If grdCtl.Columns(x).CellType.Name = "DataGridViewCheckBoxCell" Then ' لو كانت خانة الجريدة تشك بوكس
                            If arrVal(i - 1) = "True" Then
                                arrVal(i - 1) = "1"
                            Else
                                arrVal(i - 1) = "0"
                            End If
                        ElseIf grdCtl.Columns(x).CellType.Name = "CalendarCell" Then
                            arrVal(i - 1) = FFormatDate(grdCtl.Item(x, z).Value)
                        End If
                    End If
                Next

                ReDim Preserve arrCtl(arrCtl.Length) : ReDim Preserve arrVal(arrVal.Length)
                arrCtl(arrCtl.Length - 1) = "[" & strFldName & "]" : arrVal(arrVal.Length - 1) = intDocNo

                If bolCompanyId = True Then
                    ReDim Preserve arrCtl(arrCtl.Length) : ReDim Preserve arrVal(arrVal.Length)
                    arrCtl(arrCtl.Length - 1) = "[CompanyID]" : arrVal(arrVal.Length - 1) = strCompanyID
                End If

                If bolUserId = True Then
                    ReDim Preserve arrCtl(arrCtl.Length) : ReDim Preserve arrVal(arrVal.Length)
                    arrCtl(arrCtl.Length - 1) = "[UserID]" : arrVal(arrVal.Length - 1) = strUserID
                End If
                Call FAddNewRecord(strTblName, arrCtl, arrVal)
            Next
            'Call SDelGridData(frmItemCode.DataGridView1)
            Return True
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Public Sub SLoadGrid(ByVal strTblName As String, ByVal grdCtl As DataGridView, ByVal strFldName As String, ByVal strDocNo As String, Optional ByVal bolUserId As Boolean = False, Optional ByVal strCondition As String = "", Optional ByVal strOrderBy As String = "", Optional ByVal bolCompId As Boolean = True)
        Try
            Call SDelGridData(grdCtl)

            If strDocNo <> "" Then
                strSQL = ("SELECT * FROM " & strTblName & " WHERE " & strTblName & "." & strFldName & "=" & strDocNo)
            Else
                strSQL = ("SELECT * FROM " & strTblName & " WHERE " & " CompanyID=" & "'" & strCompanyID & "'")
            End If
            If bolUserId = True Then
                strSQL = strSQL & " and UserID=" & "'" & strUserID & "'"
            End If
            If strCondition <> "" Then
                strSQL = strSQL & " and " & strCondition
            End If
            If bolCompId = True Then
                strSQL = strSQL & " and CompanyID=" & "'" & strCompanyID & "'"
            End If
            If strOrderBy <> "" Then
                strSQL = strSQL & " ORDER BY " & strOrderBy
            End If

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    grdCtl.RowCount += 1
                    For x As Integer = 0 To grdCtl.Columns.Count - 1
                        If grdCtl.Columns(x).Tag <> "" Then
                            grdCtl.Item(x, i).Value = dr.Item(grdCtl.Columns(x).Tag).ToString
                        End If
                    Next
                    i += 1
                Loop
                dr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    grdCtl.RowCount += 1
                    For x As Integer = 0 To grdCtl.Columns.Count - 1
                        Dim s As String = grdCtl.Columns(x).Tag
                        If grdCtl.Columns(x).Tag <> "" Then
                            grdCtl.Item(x, i).Value = dr.Item(grdCtl.Columns(x).Tag)
                        End If
                    Next
                    i += 1
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SLoadGrid(ByVal strTblName As String, ByVal grdCtl As DataGridView, Optional ByVal strCondition As String = "", Optional ByVal strOrderBy As String = "")
        Try
            Call SDelGridData(grdCtl)

            strSQL = ("SELECT * FROM " & strTblName)
            If strCondition <> "" Then
                strSQL = strSQL & " WHERE " & strCondition
            End If
            If strOrderBy <> "" Then
                strSQL = strSQL & " ORDER BY " & strOrderBy
            End If

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    grdCtl.RowCount += 1
                    For x As Integer = 0 To grdCtl.Columns.Count - 1
                        If grdCtl.Columns(x).Tag <> "" Then
                            grdCtl.Item(x, i).Value = dr.Item(grdCtl.Columns(x).Tag).ToString
                        End If
                    Next
                    i += 1
                Loop
                dr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    grdCtl.RowCount += 1
                    For x As Integer = 0 To grdCtl.Columns.Count - 1
                        Dim s As String = grdCtl.Columns(x).Tag
                        If grdCtl.Columns(x).Tag <> "" Then
                            grdCtl.Item(x, i).Value = dr.Item(grdCtl.Columns(x).Tag)
                        End If
                    Next
                    i += 1
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SLoadGrid(ByVal strTblName As String, ByVal grdCtl As DataGridView, CONString As SqlClient.SqlConnection, Optional ByVal strCondition As String = "", Optional ByVal strOrderBy As String = "")
        Try
            Call SDelGridData(grdCtl)

            strSQL = ("SELECT * FROM " & strTblName)
            If strCondition <> "" Then
                strSQL = strSQL & " WHERE " & strCondition
            End If
            If strOrderBy <> "" Then
                strSQL = strSQL & " ORDER BY " & strOrderBy
            End If

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CONString)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    grdCtl.RowCount += 1
                    For x As Integer = 0 To grdCtl.Columns.Count - 1
                        If grdCtl.Columns(x).Tag <> "" Then
                            grdCtl.Item(x, i).Value = dr.Item(grdCtl.Columns(x).Tag).ToString
                        End If
                    Next
                    i += 1
                Loop
                dr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Dim i As Integer = 0
                Do While dr.Read
                    grdCtl.RowCount += 1
                    For x As Integer = 0 To grdCtl.Columns.Count - 1
                        Dim s As String = grdCtl.Columns(x).Tag
                        If grdCtl.Columns(x).Tag <> "" Then
                            grdCtl.Item(x, i).Value = dr.Item(grdCtl.Columns(x).Tag)
                        End If
                    Next
                    i += 1
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    'هذا الجزء خاص بالجريدة في حالة عند الضغط انتر ينتقل للزر المجاور
    '    Try
    '        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
    '            SendKeys.Send("{Tab}")
    '            Return True
    '        End If
    '        Return MyBase.ProcessCmdKey(msg, keyData)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function
    'Private Sub Control1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DataGridView1.MouseDoubleClick

    '    Dim messageBoxVB As New System.Text.StringBuilder()
    '    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    '    messageBoxVB.AppendLine()
    '    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    '    messageBoxVB.AppendLine()
    '    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    '    messageBoxVB.AppendLine()
    '    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    '    messageBoxVB.AppendLine()
    '    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    '    messageBoxVB.AppendLine()
    '    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    '    messageBoxVB.AppendLine()
    '    MessageBox.Show(messageBoxVB.ToString(), "MouseDoubleClick Event")
    'End Sub

End Module
