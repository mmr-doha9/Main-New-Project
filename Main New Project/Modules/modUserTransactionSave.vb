
Module modUserTransactionSave

    Public Function FSetTransaction(tranType As TransactionType, TagFrmName As String, DocNo As String, Optional lstColName As List(Of String) = Nothing, Optional lstColOldValue As List(Of String) = Nothing, Optional lstColNewValue As List(Of String) = Nothing) As Boolean
        Try
            Dim lstColNameToSave, lstColValueToSave As New List(Of String)

            lstColNameToSave.Add("UserID")
            lstColNameToSave.Add("FrmCode")
            lstColNameToSave.Add("TranNo")
            lstColNameToSave.Add("TranType")
            lstColNameToSave.Add("[Date]")
            lstColNameToSave.Add("[Time]")
            lstColNameToSave.Add("PCName")
            ''''''
            lstColValueToSave.Add(strUserID)
            lstColValueToSave.Add(TagFrmName)
            lstColValueToSave.Add(DocNo)
            lstColValueToSave.Add(tranType.GetHashCode)
            lstColValueToSave.Add(FFormatDate(Now))
            lstColValueToSave.Add(FFormatTime(Now))
            lstColValueToSave.Add(FGetComputerName)

            Select Case tranType
                Case TransactionType.Edit
                    FAddNewRecord2("Tblu_UserTransaction", lstColNameToSave, lstColValueToSave)
                    'FAddNewRecord2("Tblu_UserTransactionsGrid", lstColNameToSave, lstColValueToSave)
                Case Else
                    FAddNewRecord2("Tblu_UserTransaction", lstColNameToSave, lstColValueToSave)
            End Select
            'Case TransactionType.Save
            '    FAddNewRecord2("Tblu_UserTransactions", lstColNameToSave, lstColValueToSave)
            'Case TransactionType.Delete
            '    FAddNewRecord2("Tblu_UserTransactions", lstColNameToSave, lstColValueToSave)
            'Case TransactionType.logIn

            'Case TransactionType.Save
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

End Module
