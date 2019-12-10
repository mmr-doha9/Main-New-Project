Public Module modLogin
    Public Sub SDisableMenu()
        For Each item As ToolStripMenuItem In Mdi.Menu.Items
            LoopOnMenu(item, False)
        Next
        Mdi.mnuLogout.Enabled = False
    End Sub
    Public Sub SEnableMenu()
        For Each item As ToolStripMenuItem In Mdi.Menu.Items
            LoopOnMenu(item, True)
        Next
        Mdi.mnuLogout.Enabled = False
        Mdi.mnuLogin.Enabled = True
    End Sub
    Private Sub LoopOnMenu(ByVal item As ToolStripMenuItem, ByVal BolEnable As Boolean)
        For Each subItem As Object In item.DropDownItems
            If Not TypeOf subItem Is ToolStripSeparator Then
                LoopOnMenu(subItem, BolEnable)
            End If
        Next
        If item.Tag <> "Menu" And item.Tag <> "M" Then
            item.Enabled = BolEnable
        End If
    End Sub
    Public Function EnterUsers(ByVal strUserID As String, ByVal strUserPassword As String) As Boolean
        Try
            strSQL = "select * from Tblc_UserCode where ID ='" & strUserID & "' and UserPassword = '" & strUserPassword & "'"

            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.Item("ID") = strUserID And dr.Item("UserPassword") = strUserPassword Then
                        If dr.Item("LoginState") = 0 Then
                            EnterUsers = True
                        ElseIf dr.Item("LoginState") = 1 Then
                            If dr.Item("lastTimeConnect").ToString <> "" Then
                                Dim intDiff As Double = DateDiff(DateInterval.Second, dr.Item("lastTimeConnect"), Now)
                                If intDiff >= 40 Then
                                    dr.Close() : cmd.Dispose()
                                    Return True
                                Else
                                    dr.Close() : cmd.Dispose()
                                    MsgBox("لايمكن تسجيل الدخول بهذا المستخدم أكثر من مرة" & vbCrLf & "المستخدم يتعامل مع البرنامج علي جهاز : " & FGetComputerName(), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                                    Return False
                                End If
                            Else
                                dr.Close() : cmd.Dispose()
                                Return True
                            End If
                        End If
                    Else
                        MsgBox("برجاء التأكد من كلمة المرور", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        dr.Close() : cmd.Dispose()
                        Return False
                    End If
                End If

            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If dr.Read() = True Then
                    If dr.Item("ID") = strUserID And dr.Item("UserPassword") = strUserPassword Then
                        dr.Close() : cmd.Dispose()
                        Return True
                    Else
                        MsgBox("برجاء التأكد من كلمة المرور", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                        dr.Close() : cmd.Dispose()
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub SSetUserPer(ByVal strUserCode As String)
        If FGetFeildValues("Tblc_UserCode", "UserType", "ID='" & strUserCode & "'") = 1 Then
            Call SEnableMenu()
        Else
            For Each item As ToolStripMenuItem In Mdi.Menu.Items
                LoopOnMenuPer(item)
            Next
        End If
        Mdi.mnuLogout.Enabled = True : Mdi.mnuLogin.Enabled = False
        Mdi.Label4.Text = "أسم المستخدم : " & strUserName
    End Sub
    Private Sub LoopOnMenuPer(ByVal item As ToolStripMenuItem)
        For Each subItem As Object In item.DropDownItems
            If Not TypeOf subItem Is ToolStripSeparator Then
                LoopOnMenuPer(subItem)
            End If
        Next
        If item.Tag <> "Menu" And item.Tag <> "M" And item.Tag <> "" Then
            If FGetFeildValues("Tblt_UserFormPer", "UserPer", "FrmCode='" & item.Tag & "' and UserCode='" & strUserID & "'") <> "False" Then
                LoopOnMenu(item, True)
            Else
                LoopOnMenu(item, False)
            End If
        End If
    End Sub

End Module
