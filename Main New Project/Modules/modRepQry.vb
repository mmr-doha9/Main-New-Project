Public Module modRepQry
    Private strSqlQry As String

    Public Sub SUpdateDataForReport()
        Call FDeleteRecord("Tblr_RefreshReport")
        For i As Integer = 0 To 2000
            Call FAddNewRecord("Tblr_RefreshReport", i, i)
        Next
    End Sub

    Public Sub SInsertBranchCode(ByVal strYear As String) ' إدراج السنة في حالة عدم ادراج السنة
        Try
            If FGetFeildValuesBol("Tblr_UnitWorkByMonth", "BranchCode", "Year=" & strYear, False) = False Then

                Dim strCondition As String = "((Year([Tblt_InspectorTran]![Date])='" & strYear & "'));"
                If FGetFeildValuesBol("Tblt_InspectorTran", "DocNo", strCondition, False) = True Then
                    If DataType = DataConnection.SqlServer Then
                        strSqlQry = "INSERT INTO Tblr_UnitWorkByMonth ( BranchCode,BranchName, [Year] )" & _
                        " SELECT Tblc_BranchCode.Code,Name, '" & strYear & "' AS Expr1" & _
                        " FROM(Tblc_BranchCode)" & _
                        " ORDER BY Tblc_BranchCode.Partation, Tblc_BranchCode.ID;"
                        Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                        cmd.ExecuteNonQuery()
                    ElseIf DataType = DataConnection.Access Then
                        strSqlQry = "INSERT INTO Tblr_UnitWorkByMonth ( BranchCode,BranchName, [Year] )" & _
                        " SELECT Tblc_BranchCode.Code,Name, '" & strYear & "' AS Expr1" & _
                        " FROM(Tblc_BranchCode)" & _
                        " ORDER BY Tblc_BranchCode.Partation, Tblc_BranchCode.ID;"
                        Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                        cmd.ExecuteNonQuery()
                    End If
                Else
                    MsgBox("لا توجد حركات تفتيش لهذة السنة", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    Exit Sub
                End If
            End If

            Call SInsertCheckingTran()
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertBranchCode2(ByVal strYear As String) ' إدراج السنة في حالة عدم ادراج السنة خاص بمسبوق الدفع
        Try
            If FGetFeildValuesBol("Tblr_UnitWorkByMonth2", "BranchCode", "Year=" & strYear, False) = False Then

                Dim strCondition As String = "((Year([Tblt_PrePaid]![Date])='" & strYear & "'));"
                If FGetFeildValuesBol("Tblt_PrePaid", "DocNo", strCondition, False) = True Then
                    If DataType = DataConnection.SqlServer Then
                        strSqlQry = "INSERT INTO Tblr_UnitWorkByMonth2 ( BranchCode,BranchName, [Year] )" & _
                        " SELECT Tblc_BranchCode.Code,Name, '" & strYear & "' AS Expr1" & _
                        " FROM(Tblc_BranchCode)" & _
                        " ORDER BY Tblc_BranchCode.Partation, Tblc_BranchCode.ID;"
                        Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                        cmd.ExecuteNonQuery()
                    ElseIf DataType = DataConnection.Access Then
                        strSqlQry = "INSERT INTO Tblr_UnitWorkByMonth2 ( BranchCode,BranchName, [Year] )" & _
                        " SELECT Tblc_BranchCode.Code,Name, '" & strYear & "' AS Expr1" & _
                        " FROM(Tblc_BranchCode)" & _
                        " ORDER BY Tblc_BranchCode.Partation, Tblc_BranchCode.ID;"
                        Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                        cmd.ExecuteNonQuery()
                    End If
                Else
                    MsgBox("لا توجد حركات تفتيش لهذة السنة", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                    Exit Sub
                End If
            End If

            Call SInsertCheckingTran2()
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertCheckingTran()
        Dim tmpField() As String = {"Date", "BranchCode"}

        Dim strTmp() As String = FGetFeildValuesArry("Tblt_InspectorTran", "DocNo", "")

        For i As Integer = 0 To strTmp.Count - 1
            Dim strDateBranch() As String = FGetFeildValuesArry("Tblt_InspectorTran", tmpField, "DocNo='" & strTmp(i) & "'")
            Dim strBranchCode As String = strDateBranch(1)
            Dim strMonthNo As String = Month(strDateBranch(0))
            FInsertVal("Tblr_UnitWorkByMonth", strMonthNo, "'" & strDateBranch(0) & "'", "BranchCode='" & strBranchCode & "' And Year=" & Year(strDateBranch(0)), False)
        Next

    End Sub

    Public Sub SInsertCheckingTran2()
        Dim tmpField() As String = {"Date", "BranchCode"}

        Dim strTmp() As String = FGetFeildValuesArry("Qry_PrePaid", "ID", "")

        For i As Integer = 0 To strTmp.Count - 1
            Dim strDateBranch() As String = FGetFeildValuesArry("Qry_PrePaid", tmpField, "ID=" & strTmp(i))
            Dim strBranchCode As String = strDateBranch(1)
            Dim strMonthNo As String = Month(strDateBranch(0))
            FInsertVal("Tblr_UnitWorkByMonth2", strMonthNo, "'" & strDateBranch(0) & "'", "BranchCode='" & strBranchCode & "' And Year=" & Year(strDateBranch(0)), False)
        Next

    End Sub

    'Public Sub SInsertTblr_PaidRasid(ByVal strMonth As String, ByVal strYear As String)
    '    Call FDeleteRecord("Tblr_PaidRasid")

    '    If DataType = DataConnection.SqlServer Then
    '        strSqlQry = ""

    '        Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
    '        cmd.ExecuteNonQuery()
    '    ElseIf DataType = DataConnection.Access Then
    '        ''''''''''''''''''' الحسابات الجارية
    '        strSqlQry = "INSERT INTO Tblr_PaidRasid ( Area, Field, Record, subRecord, StartPay, DocType, ReallyMonth, Reallyyear, CashPaid, ReCreatorPaid, RerPaid, Mosthlak, MosthlakYadwy )" & _
    '        " SELECT Tblt_PaidTran.Area, Tblt_PaidTran.Field, Tblt_PaidTran.Record, Tblt_PaidTran.subRecord, Tblt_AddPaidGrid.StartPay, Tblt_PaidTran.DocType, Tblt_AddPaidGrid.ReallyMonth, Tblt_AddPaidGrid.Reallyyear, IIf([Tblt_AddPaidGrid]![PaidType]=0,[Tblt_AddPaidGrid]![Val],0) AS CashPaid, IIf([Tblt_AddPaidGrid]![PaidType]=1,[Tblt_AddPaidGrid]![Val],0) AS ReCreatorPaid, IIf([Tblt_AddPaidGrid]![PaidType]=3,[Tblt_AddPaidGrid]![Val],0) AS RerPaid, IIf([Tblt_AddPaidGrid]![StartPay]=1,[Tblt_PaidTran]![MO9Tran],0) AS Mosthlak, IIf([Tblt_AddPaidGrid]![StartPay]=2,[Tblt_PaidTran]![MO9Tran],0) AS MosthlakYadwy" & _
    '        " FROM Tblt_AddPaidGrid INNER JOIN Tblt_PaidTran ON (Tblt_AddPaidGrid.CompanyID = Tblt_PaidTran.CompanyID) AND (Tblt_AddPaidGrid.SubRecord = Tblt_PaidTran.subRecord) AND (Tblt_AddPaidGrid.Record = Tblt_PaidTran.Record) AND (Tblt_AddPaidGrid.Field = Tblt_PaidTran.Field) AND (Tblt_AddPaidGrid.Area = Tblt_PaidTran.Area)" & _
    '        " WHERE (((Tblt_AddPaidGrid.StartPay)<>0) AND ((Tblt_PaidTran.DocType)=0) AND ((Tblt_AddPaidGrid.ReallyMonth)=" & strMonth & ") AND ((Tblt_AddPaidGrid.Reallyyear)=" & strYear & "));"

    '        Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
    '        cmd.ExecuteNonQuery()
    '        ''''''''''''''''''' الحسابات الجارية
    '        ''''''''''''''''''' الحسابات المرفوعه
    '        strSqlQry = "INSERT INTO Tblr_PaidRasid ( Area, Field, Record, subRecord, StartPay, DocType, ReallyMonth, Reallyyear, CashPaid, ReCreatorPaid, RerPaid, Mosthlak, MosthlakYadwy )" & _
    '        " SELECT Tblt_PaidTran.Area, Tblt_PaidTran.Field, Tblt_PaidTran.Record, Tblt_PaidTran.subRecord, Tblt_AddPaidGrid.StartPay, Tblt_PaidTran.DocType, Tblt_AddPaidGrid.ReallyMonth, Tblt_AddPaidGrid.Reallyyear, IIf([Tblt_AddPaidGrid]![PaidType]=0,[Tblt_AddPaidGrid]![Val],0) AS CashPaid, IIf([Tblt_AddPaidGrid]![PaidType]=1,[Tblt_AddPaidGrid]![Val],0) AS ReCreatorPaid, IIf([Tblt_AddPaidGrid]![PaidType]=3,[Tblt_AddPaidGrid]![Val],0) AS RerPaid, IIf([Tblt_AddPaidGrid]![StartPay]=1,[Tblt_PaidTran]![MO9Tran],0) AS Mosthlak, IIf([Tblt_AddPaidGrid]![StartPay]=2,[Tblt_PaidTran]![MO9Tran],0) AS MosthlakYadwy" & _
    '        " FROM Tblt_AddPaidGrid INNER JOIN Tblt_PaidTran ON (Tblt_AddPaidGrid.CompanyID = Tblt_PaidTran.CompanyID) AND (Tblt_AddPaidGrid.SubRecord = Tblt_PaidTran.subRecord) AND (Tblt_AddPaidGrid.Record = Tblt_PaidTran.Record) AND (Tblt_AddPaidGrid.Field = Tblt_PaidTran.Field) AND (Tblt_AddPaidGrid.Area = Tblt_PaidTran.Area)" & _
    '        " WHERE (((Tblt_AddPaidGrid.StartPay)<>0) AND ((Tblt_PaidTran.DocType)=1) AND ((Tblt_AddPaidGrid.ReallyMonth)=" & strMonth & ") AND ((Tblt_AddPaidGrid.Reallyyear)=" & strYear & "));"

    '        cmd.ExecuteNonQuery()
    '        ''''''''''''''''''' الحسابات المرفوعه
    '    End If
    'End Sub

    Public Sub SInsertTblr_TahseDayTran(ByVal dtDateValue As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TahselDayTran")

            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_TahselDayTran ( [Date], [month], [year], TotalEng,  BranchCode )" & _
                " SELECT Tblt_TahselTran.Date, Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.engTran, Tblt_TahselTranGrid.BranchCode" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " WHERE(((Tblt_TahselTran.Date) = '" & FFormatDate(dtDateValue) & "')And ((Tblt_TahselTran.month) = '" & intMonth & "') And ((Tblt_TahselTran.year) =" & intYear & "))" & _
                " ORDER BY Tblt_TahselTranGrid.BranchCode;"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TahselDayTran ( [Date], [month], [year], TotalEng,  BranchCode )" & _
                " SELECT Tblt_TahselTran.Date, Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.engTran, Tblt_TahselTranGrid.BranchCode" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " WHERE(((Tblt_TahselTran.Date) = #" & FFormatDate(dtDateValue) & "#)And ((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) =" & intYear & "))" & _
                " ORDER BY Tblt_TahselTranGrid.BranchCode;"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_TahseDayTranOldMonth(ByVal dtDateValue As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TahselDayTranOldMonth")

            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_TahselDayTranOldMonth ( [Date], [month], [year], TotalEng,  BranchCode )" & _
                " SELECT Tblt_TahselTran.Date, Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.engTran, Tblt_TahselTranGrid.BranchCode" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " WHERE(((Tblt_TahselTran.Date) = '" & FFormatDate(dtDateValue) & "')And ((Tblt_TahselTran.month) = '" & intMonth & "') And ((Tblt_TahselTran.year) =" & intYear & "))" & _
                " ORDER BY Tblt_TahselTranGrid.BranchCode;"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TahselDayTranOldMonth ( [Date], [month], [year], TotalEng,  BranchCode )" & _
                " SELECT Tblt_TahselTran.Date, Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.engTran, Tblt_TahselTranGrid.BranchCode" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " WHERE(((Tblt_TahselTran.Date) = #" & FFormatDate(dtDateValue) & "#)And ((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) =" & intYear & "))" & _
                " ORDER BY Tblt_TahselTranGrid.BranchCode;"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_TotalTahsel(ByVal dtFromDate As Date, ByVal dtToDate As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TotalTahsel1")

            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel1 ( [Month], [Year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name, 1 AS Expr1" & _
                " FROM (Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code" & _
                " WHERE(((Tblt_TahselTran.Date) >= #" & FFormatDate(dtFromDate) & "# And (Tblt_TahselTran.Date) <= #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name, 1" & _
                " HAVING(((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) = " & intYear & ") And ((Tblt_TahselTranGrid.PartationCode) <> '6'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel1 ( [month], [year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 2 AS Expr1" & _
                " FROM ((Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code) INNER JOIN Tblc_BranchCode ON Tblt_TahselTranGrid.BranchCode = Tblc_BranchCode.Code" & _
                " WHERE(((Tblt_TahselTranGrid.BranchCode) = '49' Or (Tblt_TahselTranGrid.BranchCode) = '50') And ((Tblt_TahselTran.Date) >= #" & FFormatDate(dtFromDate) & "# And (Tblt_TahselTran.Date) <= #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 2" & _
                " HAVING(((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) = " & intYear & ") And ((Tblt_TahselTranGrid.PartationCode) = '6'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel1 ( [month], [year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 3 AS Expr1" & _
                " FROM ((Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code) INNER JOIN Tblc_BranchCode ON Tblt_TahselTranGrid.BranchCode = Tblc_BranchCode.Code" & _
                " WHERE(((Tblt_TahselTranGrid.BranchCode) = '51' Or (Tblt_TahselTranGrid.BranchCode) = '52') And ((Tblt_TahselTran.Date) >= #" & FFormatDate(dtFromDate) & "# And (Tblt_TahselTran.Date) <= #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 3" & _
                " HAVING(((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) = " & intYear & ") And ((Tblt_TahselTranGrid.PartationCode) = '6'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            ''''''''''''''''''''''''''''
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_TotalTahsel2(ByVal dtFromDate As Date, ByVal dtToDate As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TotalTahsel2")

            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel2 ( [Month], [Year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name, 1 AS Expr1" & _
                " FROM (Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code" & _
                " WHERE(((Tblt_TahselTran.Date) = #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name, 1" & _
                " HAVING(((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) = " & intYear & ") And ((Tblt_TahselTranGrid.PartationCode) <> '6'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel2 ( [month], [year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 2 AS Expr1" & _
                " FROM ((Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code) INNER JOIN Tblc_BranchCode ON Tblt_TahselTranGrid.BranchCode = Tblc_BranchCode.Code" & _
                " WHERE (((Tblt_TahselTran.Date)= #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblt_TahselTranGrid.BranchCode, Tblc_BranchCode.Name, 2" & _
                " HAVING (((Tblt_TahselTran.month)=" & intMonth & ") AND ((Tblt_TahselTran.year)=" & intYear & ") AND ((Tblt_TahselTranGrid.PartationCode)='6') AND ((Tblt_TahselTranGrid.BranchCode)='49' Or (Tblt_TahselTranGrid.BranchCode)='50'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel2 ( [month], [year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 3 AS Expr1" & _
                " FROM ((Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code) INNER JOIN Tblc_BranchCode ON Tblt_TahselTranGrid.BranchCode = Tblc_BranchCode.Code" & _
                " WHERE (((Tblt_TahselTran.Date)= #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblt_TahselTranGrid.BranchCode, Tblc_BranchCode.Name, 3" & _
                " HAVING (((Tblt_TahselTran.month)=" & intMonth & ") AND ((Tblt_TahselTran.year)=" & intYear & ") AND ((Tblt_TahselTranGrid.PartationCode)='6') AND ((Tblt_TahselTranGrid.BranchCode)='51' Or (Tblt_TahselTranGrid.BranchCode)='52'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''''''''''''''''
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_TotalTahsel0(ByVal dtFromDate As Date, ByVal dtToDate As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TotalTahsel0")

            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel0 ( [month], [year], Sader, PartionCode, Name, TranBranchCode )" & _
                " SELECT Qry_Sader.month, Qry_Sader.year, Sum(Qry_Sader.engSader) AS SumOfengSader, Qry_Sader.PartationCode, Tblc_PartionCode.Name, 1 AS Expr1" & _
                " FROM Qry_Sader INNER JOIN Tblc_PartionCode ON Qry_Sader.PartationCode = Tblc_PartionCode.Code" & _
                " GROUP BY Qry_Sader.month, Qry_Sader.year, Qry_Sader.PartationCode, Tblc_PartionCode.Name, 1" & _
                " HAVING (((Qry_Sader.month)=" & intMonth & ") AND ((Qry_Sader.year)=" & intYear & ") AND ((Qry_Sader.PartationCode)<>'6'));"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel0 ( [month], [year], Sader, PartionCode, Name, TranBranchCode )" & _
                " SELECT Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 2 AS Expr2" & _
                " FROM Tblc_BranchCode INNER JOIN Qry_Sader ON Tblc_BranchCode.Code = Qry_Sader.BranchCode" & _
                " WHERE(((Qry_Sader.BranchCode) = '49' Or (Qry_Sader.BranchCode) = '50'))" & _
                " GROUP BY Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 2" & _
                " HAVING (((Qry_Sader.month)=" & intMonth & ") AND ((Qry_Sader.year)=" & intYear & ") AND ((Qry_Sader.PartationCode)='6'));"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel0 ( [month], [year], Sader, PartionCode, Name, TranBranchCode )" & _
                " SELECT Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 3 AS Expr3" & _
                " FROM Tblc_BranchCode INNER JOIN Qry_Sader ON Tblc_BranchCode.Code = Qry_Sader.BranchCode" & _
                " WHERE(((Qry_Sader.BranchCode) = '51' Or (Qry_Sader.BranchCode) = '52'))" & _
                " GROUP BY Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 3" & _
                " HAVING (((Qry_Sader.month)=" & intMonth & ") AND ((Qry_Sader.year)=" & intYear & ") AND ((Qry_Sader.PartationCode)='6'));"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_TahseRasidTranOldMonthTotal(ByVal dtDateValue As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TotalTahsel3Old")

            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel3Old ( [Month], [Year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name, 1 AS Expr1" & _
                " FROM (Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code" & _
                " WHERE(((Tblt_TahselTran.Date) = #" & FFormatDate(dtDateValue) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name, 1" & _
                " HAVING(((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) = " & intYear & ") And ((Tblt_TahselTranGrid.PartationCode) <> '6'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel3Old ( [month], [year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 2 AS Expr1" & _
                " FROM ((Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code) INNER JOIN Tblc_BranchCode ON Tblt_TahselTranGrid.BranchCode = Tblc_BranchCode.Code" & _
                " WHERE (((Tblt_TahselTran.Date)= #" & FFormatDate(dtDateValue) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblt_TahselTranGrid.BranchCode, Tblc_BranchCode.Name, 2" & _
                " HAVING (((Tblt_TahselTran.month)=" & intMonth & ") AND ((Tblt_TahselTran.year)=" & intYear & ") AND ((Tblt_TahselTranGrid.PartationCode)='6') AND ((Tblt_TahselTranGrid.BranchCode)='49' Or (Tblt_TahselTranGrid.BranchCode)='50'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel3Old ( [month], [year], TotalEng, PartionCode, Name, TranBranchCode )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_BranchCode.Name, 3 AS Expr1" & _
                " FROM ((Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code) INNER JOIN Tblc_BranchCode ON Tblt_TahselTranGrid.BranchCode = Tblc_BranchCode.Code" & _
                " WHERE (((Tblt_TahselTran.Date)= #" & FFormatDate(dtDateValue) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblt_TahselTranGrid.BranchCode, Tblc_BranchCode.Name, 3" & _
                " HAVING (((Tblt_TahselTran.month)=" & intMonth & ") AND ((Tblt_TahselTran.year)=" & intYear & ") AND ((Tblt_TahselTranGrid.PartationCode)='6') AND ((Tblt_TahselTranGrid.BranchCode)='51' Or (Tblt_TahselTranGrid.BranchCode)='52'))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''''''''''''''''

        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub
    Public Sub SInsertTblr_TahseRasidTranOldMonthTotal2(ByVal dtDateValue As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TotalTahsel3old2")

            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel3old2 ( [month], [year], SaderOld, PartionCode, Name, TranBranchCode )" & _
                " SELECT Qry_Sader.month, Qry_Sader.year, Sum(Qry_Sader.engSader) AS SumOfengSader, Qry_Sader.PartationCode, Tblc_PartionCode.Name, 1 AS Expr1" & _
                " FROM Qry_Sader INNER JOIN Tblc_PartionCode ON Qry_Sader.PartationCode = Tblc_PartionCode.Code" & _
                " GROUP BY Qry_Sader.month, Qry_Sader.year, Qry_Sader.PartationCode, Tblc_PartionCode.Name, 1" & _
                " HAVING (((Qry_Sader.month)=" & intMonth & ") AND ((Qry_Sader.year)=" & intYear & ") AND ((Qry_Sader.PartationCode)<>'6'));"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel3old2 ( [month], [year], SaderOld, PartionCode, Name, TranBranchCode )" & _
                " SELECT Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 2 AS Expr2" & _
                " FROM Tblc_BranchCode INNER JOIN Qry_Sader ON Tblc_BranchCode.Code = Qry_Sader.BranchCode" & _
                " WHERE(((Qry_Sader.BranchCode) = '49' Or (Qry_Sader.BranchCode) = '50'))" & _
                " GROUP BY Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 2" & _
                " HAVING (((Qry_Sader.month)=" & intMonth & ") AND ((Qry_Sader.year)=" & intYear & ") AND ((Qry_Sader.PartationCode)='6'));"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TotalTahsel3old2 ( [month], [year], SaderOld, PartionCode, Name, TranBranchCode )" & _
                " SELECT Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 3 AS Expr3" & _
                " FROM Tblc_BranchCode INNER JOIN Qry_Sader ON Tblc_BranchCode.Code = Qry_Sader.BranchCode" & _
                " WHERE(((Qry_Sader.BranchCode) = '51' Or (Qry_Sader.BranchCode) = '52'))" & _
                " GROUP BY Qry_Sader.month, Qry_Sader.year, Qry_Sader.engSader, Qry_Sader.PartationCode, Tblc_BranchCode.Name, 3" & _
                " HAVING (((Qry_Sader.month)=" & intMonth & ") AND ((Qry_Sader.year)=" & intYear & ") AND ((Qry_Sader.PartationCode)='6'));"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_TahseRasidTran(ByVal dtFromDate As Date, ByVal dtToDate As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TahselRasidTran")

            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_TahselRasidTran ( [Date], [month], [year], BranchCode, TotalEng )" & _
                " SELECT Max(Tblt_TahselTran.Date) AS MaxOfDate, Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode" & _
                " HAVING(((Tblt_TahselTran.Date) >= #" & FFormatDate(dtFromDate) & "# And (Tblt_TahselTran.Date) <= #" & FFormatDate(dtToDate) & "#))" & _
                " ORDER BY Max(Tblt_TahselTran.Date);"

                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TahselRasidTran ( [month], [year], BranchCode, TotalEng )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " WHERE(((Tblt_TahselTran.Date) >= #" & FFormatDate(dtFromDate) & "# And (Tblt_TahselTran.Date) <= #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode" & _
                " ORDER BY Tblt_TahselTranGrid.BranchCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_TahseRasidTranOldMonth(ByVal dtFromDate As Date, ByVal dtToDate As Date, ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TahselRasidTranOldMonth")

            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_TahselRasidTranOldMonth ( [Date], [month], [year], BranchCode, TotalEng )" & _
                " SELECT Max(Tblt_TahselTran.Date) AS MaxOfDate, Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode" & _
                " HAVING(((Tblt_TahselTran.Date) >= #" & FFormatDate(dtFromDate) & "# And (Tblt_TahselTran.Date) <= #" & FFormatDate(dtToDate) & "#))" & _
                " ORDER BY Max(Tblt_TahselTran.Date);"

                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TahselRasidTranOldMonth ( [month], [year], BranchCode, TotalEng )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran" & _
                " FROM Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo" & _
                " WHERE(((Tblt_TahselTran.Date) >= #" & FFormatDate(dtFromDate) & "# And (Tblt_TahselTran.Date) <= #" & FFormatDate(dtToDate) & "#))" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.BranchCode" & _
                " ORDER BY Tblt_TahselTranGrid.BranchCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub SUintWork(ByVal dtFromDate As Date, ByVal dtToDate As Date)
        Try
            Call FDeleteRecord("Tblr_UnitWork")

            ''''''''''''''''''' التفتيش
            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], BranchCode, DocType, Title, Bady )" & _
                " SELECT Tblt_InspectorTran.DocNo, Tblt_InspectorTran.Date, Tblt_InspectorTran.BranchCode, 1 AS Expr1, 'تفتيش' AS Expr2, 'تفتيش' AS Expr3" & _
                " FROM(Tblt_InspectorTran)" & _
                " WHERE (((Tblt_InspectorTran.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_InspectorTran.Date)<=#" & FFormatDate(dtToDate) & "#));"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], BranchCode, DocType, Title, Bady )" & _
                " SELECT Tblt_InspectorTran.DocNo, Tblt_InspectorTran.Date, Tblt_InspectorTran.BranchCode, 1 AS Expr1, 'تفتيش' AS Expr2, 'تفتيش' AS Expr3" & _
                " FROM(Tblt_InspectorTran)" & _
                " WHERE (((Tblt_InspectorTran.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_InspectorTran.Date)<=#" & FFormatDate(dtToDate) & "#));"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''' التفتيش

            ''''''''''''''''''' شكوى عاملين
            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, BranchCode, Title, Bady )" & _
                " SELECT Tblt_Complaints.DocNo, Tblt_Complaints.Date, 2 AS Expr1, Tblt_Complaints.BranchCode, Tblt_Complaints.EmpName, Tblt_Complaints.EmpBody" & _
                " FROM(Tblt_Complaints)" & _
                " WHERE (((Tblt_Complaints.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_Complaints.Date)<=#" & FFormatDate(dtToDate) & "#) AND ((Tblt_Complaints.Type)=0));"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, BranchCode, Title, Bady )" & _
                " SELECT Tblt_Complaints.DocNo, Tblt_Complaints.Date, 2 AS Expr1, Tblt_Complaints.BranchCode, Tblt_Complaints.EmpName, Tblt_Complaints.EmpBody" & _
                " FROM(Tblt_Complaints)" & _
                " WHERE (((Tblt_Complaints.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_Complaints.Date)<=#" & FFormatDate(dtToDate) & "#) AND ((Tblt_Complaints.Type)=0));"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''' شكوى عاملين

            ''''''''''''''''''' شكوى مشتركين
            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, BranchCode, Title, Bady )" & _
                " SELECT Tblt_Complaints.DocNo, Tblt_Complaints.Date, 3 AS Expr1, Tblt_Complaints.BranchCode, Tblt_Complaints.CustName, Tblt_Complaints.CustBody" & _
                " FROM(Tblt_Complaints)" & _
                " WHERE (((Tblt_Complaints.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_Complaints.Date)<=#" & FFormatDate(dtToDate) & "#) AND ((Tblt_Complaints.Type)=1));"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, BranchCode, Title, Bady )" & _
                " SELECT Tblt_Complaints.DocNo, Tblt_Complaints.Date, 3 AS Expr1, Tblt_Complaints.BranchCode, Tblt_Complaints.CustName, Tblt_Complaints.CustBody" & _
                " FROM(Tblt_Complaints)" & _
                " WHERE (((Tblt_Complaints.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_Complaints.Date)<=#" & FFormatDate(dtToDate) & "#) AND ((Tblt_Complaints.Type)=1));"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''' شكوى مشتركين

            ''''''''''''''''''' تفتيش الكارت المدفوع
            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, BranchCode, Title, Bady )" & _
                " SELECT Tblt_PrePaid.DocNo, Tblt_PrePaid.Date, 4 AS Expr1, Tblt_PrePaidGrid.BranchCode, 'تفتيش الكارت المدفوع' AS Expr2, 'تفتيش الكارت المدفوع' AS Expr3" & _
                " FROM Tblt_PrePaid INNER JOIN Tblt_PrePaidGrid ON Tblt_PrePaid.DocNo = Tblt_PrePaidGrid.DocNo" & _
                " WHERE (((Tblt_PrePaid.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_PrePaid.Date)<=#" & FFormatDate(dtToDate) & "#));"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, BranchCode, Title, Bady )" & _
                " SELECT Tblt_PrePaid.DocNo, Tblt_PrePaid.Date, 4 AS Expr1, Tblt_PrePaidGrid.BranchCode, 'تفتيش الكارت المدفوع' AS Expr2, 'تفتيش الكارت المدفوع' AS Expr3" & _
                " FROM Tblt_PrePaid INNER JOIN Tblt_PrePaidGrid ON Tblt_PrePaid.DocNo = Tblt_PrePaidGrid.DocNo" & _
                " WHERE (((Tblt_PrePaid.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_PrePaid.Date)<=#" & FFormatDate(dtToDate) & "#));"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''' تفتيش الكارت المدفوع

            ''''''''''''''''''' تفتيش اخرى
            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, Title, Bady )" & _
                " SELECT Tblt_OtherTran.DocNo, Tblt_OtherTran.Date, 5 AS Expr1, Tblt_OtherTran.Title, Tblt_OtherTran.Bady" & _
                " FROM Tblt_OtherTran" & _
                " WHERE (((Tblt_OtherTran.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_OtherTran.Date)<=#" & FFormatDate(dtToDate) & "#))" & _
                " ORDER BY Tblt_OtherTran.Date;"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_UnitWork ( DocNo, [Date], DocType, Title, Bady )" & _
                " SELECT Tblt_OtherTran.DocNo, Tblt_OtherTran.Date, 5 AS Expr1, Tblt_OtherTran.Title, Tblt_OtherTran.Bady" & _
                " FROM Tblt_OtherTran" & _
                " WHERE (((Tblt_OtherTran.Date)>=#" & FFormatDate(dtFromDate) & "# And (Tblt_OtherTran.Date)<=#" & FFormatDate(dtToDate) & "#))" & _
                " ORDER BY Tblt_OtherTran.Date;"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
            ''''''''''''''''''' تفتيش اخرى
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
    End Sub

    Public Sub STawredPartion(ByVal intMonth As Integer, ByVal intYear As Integer)
        Try
            Call FDeleteRecord("Tblr_TahselTawredPartion")

            If DataType = DataConnection.SqlServer Then
                strSqlQry = "INSERT INTO Tblr_TahselTawredPartion ( [Month], [Year], EngTran, PartionCode, Name )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name" & _
                " FROM (Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name" & _
                " HAVING(((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) = " & intYear & "))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"
                Dim cmd As New SqlClient.SqlCommand(strSqlQry, CON)
                cmd.ExecuteNonQuery()
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TahselTawredPartion ( [Month], [Year], EngTran, PartionCode, Name )" & _
                " SELECT Tblt_TahselTran.month, Tblt_TahselTran.year, Sum(Tblt_TahselTranGrid.engTran) AS SumOfengTran, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name" & _
                " FROM (Tblt_TahselTran INNER JOIN Tblt_TahselTranGrid ON Tblt_TahselTran.DocNo = Tblt_TahselTranGrid.DocNo) INNER JOIN Tblc_PartionCode ON Tblt_TahselTranGrid.PartationCode = Tblc_PartionCode.Code" & _
                " GROUP BY Tblt_TahselTran.month, Tblt_TahselTran.year, Tblt_TahselTranGrid.PartationCode, Tblc_PartionCode.Name" & _
                " HAVING(((Tblt_TahselTran.month) = " & intMonth & ") And ((Tblt_TahselTran.year) = " & intYear & "))" & _
                " ORDER BY Tblt_TahselTranGrid.PartationCode;"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub STahselAdmin(ByVal intMonth As Integer, ByVal intYear As Integer)

        Try
            Call FDeleteRecord("Tblr_TahselAdminTotal")
            strSqlQry = ""

            If DataType = DataConnection.SqlServer Then
               
            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO Tblr_TahselAdminTotal ( BranchCode, [month], [year], engSader, SumOfengTran, AdminCode, AdminGeneralCode )" & _
                " SELECT Tblt_TahselSaderGrid.BranchCode, Qry_TahselAdminTotal.month, Qry_TahselAdminTotal.year, Tblt_TahselSaderGrid.engSader, Qry_TahselAdminTotal.SumOfengTran, Tblt_TahselSaderGrid.AdminCode, Tblt_TahselSaderGrid.AdminGeneralCode" & _
                " FROM (Tblt_TahselSader INNER JOIN Tblt_TahselSaderGrid ON Tblt_TahselSader.DocNo = Tblt_TahselSaderGrid.DocNo) INNER JOIN Qry_TahselAdminTotal ON Tblt_TahselSaderGrid.BranchCode = Qry_TahselAdminTotal.BranchCode" & _
                " GROUP BY Tblt_TahselSaderGrid.BranchCode, Qry_TahselAdminTotal.month, Qry_TahselAdminTotal.year, Tblt_TahselSaderGrid.engSader, Qry_TahselAdminTotal.SumOfengTran, Tblt_TahselSaderGrid.AdminCode, Tblt_TahselSaderGrid.AdminGeneralCode" & _
                " HAVING (((Qry_TahselAdminTotal.month)=" & intMonth & ") AND ((Qry_TahselAdminTotal.year)=" & intYear & "));"
                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SInsertTblr_Attendance(ByVal strMonth As String, ByVal strYear As String)
        Try
            Call FDeleteRecord("tblr_Attendance")

            If DataType = DataConnection.SqlServer Then

            ElseIf DataType = DataConnection.Access Then
                strSqlQry = "INSERT INTO tblr_Attendance ( InspectorCode, InspectorName )" & _
                " SELECT Tblc_InspectorCode.Code, Tblc_InspectorCode.Name" & _
                " FROM Tblc_InspectorCode;"

                Dim cmd As New OleDb.OleDbCommand(strSqlQry, CONAccess)
                cmd.ExecuteNonQuery()
                strSqlQry = ""
            End If
            '''''''''''''''''''''''''''''''''''''''''''
        Catch Exp As OleDb.OleDbException
            MsgBox(Exp.Message)
        End Try
        Call FAppendAttendance(strMonth, strYear)
    End Sub

    Private Sub FAppendAttendance(ByVal strMonth As String, ByVal strYear As String)
        Dim sql As String = ""

        sql = "SELECT * From Qry_Attendance WHERE MonthNo = " & strMonth & " And YearNo <= " & strYear

        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            Dim i As Integer = 0
            Do While dr.Read

            Loop
            dr.Close()
        ElseIf DataType = DataConnection.Access Then
            Dim TmpCON As New OleDb.OleDbConnection(Db_Conn)
            TmpCON.Open()
            Dim cmd As New OleDb.OleDbCommand(sql, TmpCON)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader

            Dim i As Integer = 0
            Do While dr.Read
                Dim strCloName As String = Microsoft.VisualBasic.DateAndTime.Day(dr.Item("Date"))
                Dim strVal As String = "'" & dr.Item("Name") & "'"
                Dim strCondition As String = "InspectorCode='" & dr.Item("InspectorCode") & "'"
                FInsertVal("tblr_Attendance", strCloName, strVal, strCondition, False)
            Loop
            dr.Close()
        End If
    End Sub


    Private Sub FAppendAttendanceMain(ByVal strMonth As String, ByVal strYear As String)
        Dim sql As String = ""

        sql = "SELECT * From Tblc_InspectorCode"

        If DataType = DataConnection.SqlServer Then
            Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            Dim i As Integer = 0
            Do While dr.Read

            Loop
            dr.Close()
        ElseIf DataType = DataConnection.Access Then
            Dim TmpCON As New OleDb.OleDbConnection(Db_Conn)
            TmpCON.Open()
            Dim cmd As New OleDb.OleDbCommand(sql, TmpCON)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader

            Dim i As Integer = 0
            Do While dr.Read
                Dim strCloName As String = Microsoft.VisualBasic.DateAndTime.Day(dr.Item("Date"))
                Dim strVal As String = "'" & dr.Item("Name") & "'"
                Dim strCondition As String = "InspectorCode='" & dr.Item("InspectorCode") & "'"
                FInsertVal("tblr_Attendance", strCloName, strVal, strCondition, False)
            Loop
            dr.Close()
        End If
    End Sub

End Module
