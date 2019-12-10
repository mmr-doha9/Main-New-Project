Imports System.Management
Public Module modProtection
    Public KeyMotherserialno As String
    Public KeyActiveCode As String
    Public KeyRegCode As String
    Public KeyMultiPcAllow As String

    'Public Function SNCheck() As Boolean
    '    KeyMotherserialno = GetMotherboardSerialNumber()
    '    KeyActiveCode = Str2Int(KeyMotherserialno)
    '    KeyRegCode = Str2Int(KeyActiveCode)

    '    KeyMultiPcAllow = FGetFeildValues("Tblu_Lan", "Type", "")
    '    If KeyMultiPcAllow = "" Then
    '        MsgBox("برجاء الاتصال بالدعم الفني", vbCritical + vbMsgBoxRight + vbMsgBoxRtlReading, ProgName)
    '        End
    '    ElseIf KeyMultiPcAllow = "0" And Strings.Left(Application.StartupPath, 2) = "\\" Then
    '        MsgBox("هذة النسخة نسخة فردية " & vbCrLf & "وغير مجهزة للعمل علي عدة اجهزة", vbCritical + vbMsgBoxRight + vbMsgBoxRtlReading, ProgName)
    '        End
    '    End If
    '    strSQL = ("SELECT * FROM Tblu_Tools")
    '    If DataType = DataConnection.SqlServer Then
    '        Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
    '        Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
    '        Do While dr.Read
    '            If dr.Item("ID") = KeyRegCode And dr.Item("ID2") = KeyMotherserialno Then
    '                SNCheck = True
    '                Exit Function
    '            Else
    '                SNCheck = False
    '            End If
    '        Loop
    '        dr.Close()
    '    ElseIf DataType = DataConnection.Access Then
    '        Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
    '        Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
    '        Do While dr.Read
    '            If dr.Item("ID") = KeyRegCode And dr.Item("ID2") = KeyMotherserialno Then
    '                SNCheck = True
    '                Exit Function
    '            End If
    '        Loop
    '        dr.Close()
    '        SNCheck = False
    '    End If
    'End Function

    'Function GetMotherboardSerialNumber() As String
    '    Dim searcher As New ManagementObjectSearcher("SELECT SerialNumber, Product FROM Win32_BaseBoard")
    '    Dim information As ManagementObjectCollection = searcher.Get()
    '    Dim serialNumber As String = String.Empty

    '    For Each obj As ManagementObject In information
    '        If (obj.Properties("SerialNumber").Value.ToString().Trim() <> String.Empty) Then
    '            serialNumber = obj.Properties("SerialNumber").Value.ToString().Trim()
    '        Else
    '            serialNumber = obj.Properties("Product").Value.ToString().Trim()
    '        End If
    '        Exit For
    '    Next
    '    searcher.Dispose()
    '    Return serialNumber
    'End Function

    Function Str2Int(ByVal InStrng As Object) As String
        Dim StrLn As Long
        Dim Cntr As Long
        Dim NewStr As String

        Str2Int = ""
        StrLn = Len((InStrng))
        If StrLn = 0 Then Exit Function
        NewStr = ""
        For Cntr = 1 To StrLn
            Select Case Mid(InStrng, Cntr, 1)
                ' لكي يتستطيع قراءة الحروف والارقام
                Case "0" To "z"
                    'للتحويل الكامل إلى ارقام الاسكي
                    NewStr = NewStr & Asc(Mid(InStrng, Cntr, 1))
            End Select

        Next Cntr
        Str2Int = NewStr
    End Function

End Module
