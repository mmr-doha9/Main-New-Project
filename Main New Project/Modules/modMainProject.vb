Module modMainProject

    Public Function FCheckPriviosRecord(strHasrNo As String, strTableName As String, intMabahsCode As Integer, intBranchCode As Integer, intYear As Integer, intDocNo As Integer) As Integer
        'intDocNo رقم الحركة للتاكد من فتح الحرة للتعديل
        Dim strCondition As String = ""

        If strTableName = "Tblt_EnergyThefts" Then
            strCondition = "HasrNo='" & strHasrNo & "' And MabahsCode=" & intMabahsCode & " And year(Date2)= " & intYear
        ElseIf strTableName = "Tblt_EnergyTheftsSecond" Then
            strCondition = "HasrNo='" & strHasrNo & "' And BranchCode=" & intBranchCode & " And year(Date2)= " & intYear
        End If

        Dim strTmpTranNo As String = (FGetFeildValues(strTableName, "ID", strCondition, False, False))
        If strTmpTranNo <> Nothing Then
            If intDocNo <> 0 Then
                If strTmpTranNo <> intDocNo Then
                    Return strTmpTranNo
                Else
                    Return "0"
                End If
            ElseIf intDocNo = 0 Then
                Return strTmpTranNo
            End If
        Else
            Return 0
        End If
        '''''''''''''''''''''''''''
    End Function

    Public Function FCheckPriviosRecordDisagreed(strHasrNo As String, strTableName As String, intMabahsCode As Integer, intBranchCode As Integer, intYear As Integer, intDocNo As Integer) As Integer ' للتأكد من عدم وجود مخالفة سابقة لنفس رقم الحصر
        Dim strCondition As String = ""
        Dim strTmpTranNoDisagreed As String = ""

        If strTableName = "Tblt_EnergyThefts" Then
            strCondition = ""
        ElseIf strTableName = "Tblt_EnergyTheftsSecond" Then
            strCondition = "HasrNo='" & strHasrNo & "' And BranchCode=" & intBranchCode & " And year(Date2)= " & intYear
            strTmpTranNoDisagreed = (FGetFeildValues("Tblt_DisagreedSecond", "ID", strCondition, False, False))
        End If

        If strTmpTranNoDisagreed <> Nothing Then
            Return strTmpTranNoDisagreed
        Else
            Return 0
        End If
        '''''''''''''''''''''''''''
    End Function

End Module
