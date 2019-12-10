Module modPermissionTran
    Public Enum PermissionKeyName
        Update
        Delete
    End Enum

    Public Enum ExceptionResult
        Wait    'ينتظر
        Accepte 'قبول
        Refusal 'رفض
        Delay   'تاجيل
    End Enum

    Public Function FExceptionAddOrder(TblName As String, ID As Integer, DocType As Integer, PermissionKeyName As PermissionKeyName, ToUserId As Integer, FromUserId As Integer, strReasons As String) As Boolean ' لطلب السماح بحركة
        Try
            'Dim lstFieldName, lstValue As New List(Of String)
            'Dim dRemoteDate As Date = (GetNetRemoteTOD(Mid(strServerName, 1, InStr(strServerName, "\") - 1)))

            'lstFieldName.AddRange({"TblName", "ID", "DocType", "PermissionKeyName", "ToUserId", "FromUserId", "TranDate", "TranTime"})
            'lstValue.AddRange({TblName, ID, DocType, PermissionKeyName, ToUserId, FromUserId})
            Dim dRemoteDate As Date = (GetNetRemoteTOD(Mid(strServerName, 1, InStr(strServerName, "\") - 1)))

            Dim lstFieldName As New List(Of String)({"TblName", "ID", "DocType", "PermissionKeyName", "ToUserId", "FromUserId", "TranDate", "TranTime", "Reasons", "Result"})
            Dim lstValue As New List(Of String)({TblName, ID, DocType, PermissionKeyName, ToUserId, FromUserId, FFormatDate2(dRemoteDate), FFormatTime(dRemoteDate), strReasons, ExceptionResult.Wait})

            If FAddNewRecord2("Tblt_PermissionTran", lstFieldName, lstValue, "ID_Me") = True Then
                Return True
            Else
                Return False
            End If
            Call FExceptionResult(1, ExceptionResult.Accepte, "ss")
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' الرد علي الاستثناء
    ''' </summary>
    ''' <param name="ID_Me ">"رقم حركة الأستثناء"</param>
    ''' <param name="Result">"نتيجة الأستثناء"</param>
    ''' <param name="strResultReasons"></param>
    ''' <returns></returns>
    Public Function FExceptionResult(ID_Me As Integer, Result As ExceptionResult, strResultReasons As String) As Boolean ' لطلب السماح بحركة
        Try
            Dim dRemoteDate As Date = (GetNetRemoteTOD(Mid(strServerName, 1, InStr(strServerName, "\") - 1)))

            Dim lstFieldName As New List(Of String)({"ID_Me", "Result", "ResultTranDate", "ResultTranTime", "ResultReasons"})
            Dim lstValue As New List(Of String)({ID_Me, Result, FFormatDate2(dRemoteDate), FFormatTime(dRemoteDate), strResultReasons})

            If FEditeRecord("Tblt_PermissionTran", "ID_Me", Result, lstFieldName, lstValue) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


End Module
