Public Module modReport
    Dim Dp As SqlClient.SqlDataAdapter
    Dim DpAccess As OleDb.OleDbDataAdapter

    Public Sub SLoadDataSet(ByVal ds As DataSet)
        Try
            ds.Tables.Clear()
            strSQL = ("SELECT * FROM Tblu_TblName")
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dp = New SqlClient.SqlDataAdapter(strSQL, CON)
                    Dp.Fill(ds, dr.Item(strFldName))
                Loop
                dr.Close()
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While dr.Read
                    DpAccess = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                    DpAccess.Fill(ds, dr.Item("TblName"))
                Loop
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadDataSetRep(ByVal ds As DataSet, ByVal tblName() As String)
        For x As Integer = 0 To tblName.Length - 1
            strSQL = ("SELECT * FROM " & tblName(x))
            If DataType = DataConnection.SqlServer Then
                Dp = New SqlClient.SqlDataAdapter(strSQL, CON)
                Dp.Fill(ds, tblName(x))
            ElseIf DataType = DataConnection.Access Then
                DpAccess = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                DpAccess.Fill(ds, tblName(x))
            End If
        Next
    End Sub

    Public Function FReportDate(ByVal Dat As Object) As String
        If DataType = DataConnection.SqlServer Then
            Return Format(Dat, "yyyy-MM-dd")
        ElseIf DataType = DataConnection.Access Then
            FReportDate = Format(Dat, "yyyy,MM,dd")
        End If
    End Function

End Module
