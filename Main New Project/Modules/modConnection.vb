Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Public Module modConnection
    Dim FileReader As StreamReader

    Sub SCompactDataBase()

        'Dim jro As JRO.JetEngine

        'jro = New JRO.JetEngine()

        'jro.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\nwind.mdb", _
        '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\NewNwind.mdb;Jet OLEDB:Engine Type=5")

        'MsgBox("Finished Compacting Database!")
    End Sub

    'Public Sub OpenSqlConnection()
    '    Try
    '        Call SGetConnPath() 'وضع اسم السرفر وقاعدة البيانات
    '        If GETATTACHDATABASENAME() = False Then
    '            ATTACHDATABASENAME(strDataBaseName, Application.StartupPath & "\Data\" & strDataBaseName & ".MDF", Application.StartupPath & "\Data\" & strDataBaseName & "_log" & ".LDF")
    '        End If

    '        CON.ConnectionString = Db_Conn
    '        CON.Open()
    '    Catch ExSql As SqlClient.SqlException
    '        Dim message As String
    '        Dim se As SqlClient.SqlError
    '        For Each se In ExSql.Errors
    '            Select Case se.Number
    '                Case 17
    '                    message = "خطأ في اسم السيرفر"
    '                Case 4060
    '                    message = "خطأ في اسم قاعدة البيانات"
    '                Case 18456
    '                    message = "خطأ في اسم المستخدم او الباسورد"
    '                Case Else
    '                    message = se.Message
    '            End Select
    '            MessageBox.Show(message)
    '            Exit Sub
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Public Sub OpenAccessConnection()
    '    Try
    '        Call SGetAccessConnPath() 'وضع اسم قاعدة البيانات
    '        'CompactAccessDB(Db_Conn, "Data.mdb")
    '        CONAccess.ConnectionString = Db_Conn
    '        CONAccess.Open()
    '        If BolCompactDataDate = True Then Call SInsertDataCompactDate()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        End
    '    End Try
    'End Sub

    'Private Sub SGetConnPath()
    '    Try
    '        FileReader = New StreamReader(Application.StartupPath & "\Data\TXT.Med")
    '        strServerName = FileReader.ReadLine
    '        strDataBaseName = FileReader.ReadLine
    '        'Db_Conn = ("server=" & strServerName & ";database=" & strDataBaseName & ";integrated security=true")
    '        Db_Conn = ("Data Source=" & strServerName & ";Initial Catalog=" & strDataBaseName & ";User Id=" & strDataBaseUserName & ";Password=" & strDataBasePassword & ";")
    '        Db_Conn = Db_Conn & "MultipleActiveResultSets=True;"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        FileReader.Close()
    '    End Try
    'End Sub
    'Public Sub SGetAccessConnPath()
    '    Db_Conn = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=" & strDataBaseAccPassword & ";Data Source =" & Application.StartupPath & "\Data\Data.mdb"
    'End Sub
    'Public Sub GetServerNameAndDataBaseName(ByVal objReport As Object)
    '    If DataType = DataConnection.SqlServer Then
    '        Dim TBL1 As New CrystalDecisions.Shared.TableLogOnInfo
    '        TBL1.ConnectionInfo.ServerName = strServerName  'My.Computer.Name & "\SQLEXPRESS"
    '        TBL1.ConnectionInfo.DatabaseName = strDataBaseName 'strDataBaseName
    '        TBL1.ConnectionInfo.UserID = strDataBaseUserName
    '        TBL1.ConnectionInfo.Password = strDataBasePassword 'strPassword
    '        TBL1.ConnectionInfo.IntegratedSecurity = False
    '        For I As Integer = 0 To objReport.Database.Tables.Count - 1
    '            objReport.Database.Tables(I).ApplyLogOnInfo(TBL1)
    '        Next I
    '    ElseIf DataType = DataConnection.Access Then
    '        Dim TBL1 As New CrystalDecisions.Shared.TableLogOnInfo
    '        TBL1.ConnectionInfo.ServerName = (Application.StartupPath & "\Data\Data.mdb")
    '        TBL1.ConnectionInfo.DatabaseName = (Application.StartupPath & "\Data\Data.mdb")
    '        TBL1.ConnectionInfo.UserID = "admin"
    '        TBL1.ConnectionInfo.Password = strDataBaseAccPassword
    '        For I As Integer = 0 To objReport.Database.Tables.Count - 1
    '            'objReport.Database.Tables(I).Location = (Application.StartupPath & "\Data\Data.mdb")
    '            objReport.Database.Tables(I).ApplyLogOnInfo(TBL1)
    '        Next I
    '    End If
    'End Sub
    'Public Function GETATTACHDATABASENAME() As Boolean
    '    Try
    '        Dim DS As New DataSet
    '        'Dim SqlConnection1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("server=" & strServerName & ";Initial Catalog=tempdb;Integrated Security=SSPI;")

    '        Dim SqlConnection1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("server=" & strServerName & ";Initial Catalog=tempdb;User ID =" & strDataBaseUserName & ";Password=" & strDataBasePassword & ";")

    '        Dim str As String = "Select DISTINCT name from master.dbo.sysdatabases where name Like " & "'" & strDataBaseName & "'" & " and has_dbaccess(Name) = 1 "
    '        Dim ADP As SqlClient.SqlDataAdapter
    '        ADP = New SqlClient.SqlDataAdapter(str, SqlConnection1)
    '        DS.Clear()
    '        ADP.Fill(DS)
    '        If DS.Tables(0).Rows.Count = 0 Then
    '            GETATTACHDATABASENAME = False
    '            MessageBox.Show("جاري الأتصال بالسيرفر" & vbCrLf & "برجاء الأنتظار قليلا", ProgName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
    '        Else
    '            GETATTACHDATABASENAME = True
    '        End If
    '        ADP.Dispose()
    '        SqlConnection1.Dispose()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function
    'Public Sub ATTACHDATABASENAME(ByVal MYDBNAME As String, ByVal f1lepathprimary As String, ByVal f1lepathlog As String)
    '    Try
    '        Dim cnnConnection As New SqlConnection("Data Source=" & strServerName & ";AttachDbFilename=" & f1lepathprimary & ";Integrated Security=false;User ID =" & strDataBaseUserName & ";Password=" & strDataBasePassword & ";Database='" & MYDBNAME & "';Connect Timeout=30")
    '        cnnConnection.Open()
    '        cnnConnection.Close()
    '        MessageBox.Show("تم انشاء اتصال  قاعدة البيانات بالسرفر ", ProgName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("من فضلك قم بعمل اتصال قاعدة البيانات بالسرفر", ProgName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
    '    End Try
    'End Sub
    'Public Function getConn() As SqlClient.SqlConnection
    '    Return CON
    'End Function
    'Public Sub OpenConn()
    '    CON.Open()
    'End Sub
    'Public Sub CloseConn()
    '    CON.Close()
    '    CON.Dispose()
    '    CON = Nothing
    'End Sub


    '    Public Function AddUserTOSQLServer(ByVal UserName As String, ByVal Password As String, ByVal Database As String) As Boolean
    '        '*************************************************************
    '        'This function adds a user to an SQL server.  YOU MUST CHANGE
    '        'THE CODE TO SUPPLY YOUR OWN CONNECTION STRING, WHERE IDENTIFIED
    '        'BELOW.  A reference to ADO 2.0 or above is required

    '        'Specifically, it adds a User with the Specified Password to
    '        'the Public Group and provides permissions to the database
    '        'specified as the third parameter.

    '        'The return value is true if successful, false otherwise
    '        '***********************************************************
    '        Dim strConnString As String
    '        Dim oConn As New ADODB.Connection

    '        On Error GoTo ErrorHandler

    '        'THIS IS WHERE YOU MUST PUT YOUR OWN CONNECTION STRING IN
    '        'MAKE SUBSTITUTIONS FOR User ID, Password, and Data Source

    '        strConnString = "Provider=SQLOLEDB.1;"
    '        strConnString = strConnString & "User ID=sa;password=mypassword;"
    '        strConnString = strConnString & "Initial Catalog=" & _
    '              Database & ";"
    '        strConnString = strConnString & "Data Source=MySQLServer;"
    '        strConnString = strConnString & "Use Procedure for Prepare=1;"
    '        strConnString = strConnString & "Auto Translate=True;"
    '        strConnString = strConnString & "Packet Size=4096"


    '        oConn.Open(strConnString)
    '        'Add user to database
    '        oConn.Execute("USE Master")
    '        oConn.Execute("EXEC sp_addlogin " & UserName & "," & _
    '          Password & "," & Database)

    '        'Grant user access to Database in public group
    '        oConn.Execute("USE " & Database)
    '        oConn.Execute("EXEC sp_adduser " & UserName)
    '        AddUserTOSQLServer = True

    'ErrorHandler:
    '        If oConn.State <> 0 Then
    '            oConn.Close()
    '        End If

    '        oConn = Nothing

    '    End Function

    Public Sub OpenSqlConnection()
        Try
            Call SGetConnPath() 'وضع اسم السرفر وقاعدة البيانات
            If GETATTACHDATABASENAME() = False Then
                'ATTACHDATABASENAME(strDataBaseName, Application.StartupPath & "\Data\" & strDataBaseName & ".MDF", Application.StartupPath & "\Data\" & strDataBaseName & "_log" & ".LDF")
                End
            End If

            CON.ConnectionString = Db_Conn
            CON.Open()
        Catch ExSql As SqlClient.SqlException
            Dim message As String
            Dim se As SqlClient.SqlError
            For Each se In ExSql.Errors
                Select Case se.Number
                    Case 17
                        message = "خطأ في اسم السيرفر"
                    Case 4060
                        message = "خطأ في اسم قاعدة البيانات"
                    Case 18456
                        message = "خطأ في اسم المستخدم او الباسورد"
                    Case Else
                        message = se.Message
                End Select
                MessageBox.Show(message)
            Next
            End
        Catch ex As Exception

        End Try
    End Sub
    Public Sub OpenAccessConnection()
        Try
            Call SGetAccessConnPath() 'وضع اسم قاعدة البيانات
            CompactAccessDB(Db_Conn, "Data.mdb")
            CONAccess.ConnectionString = Db_Conn
            CONAccess.Open()
            If BolCompactDataDate = True Then Call SInsertDataCompactDate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End
        End Try
    End Sub
    Private Sub SGetConnPath()
        Try
            FileReader = New StreamReader(Application.StartupPath & "\Data\TXT.Med")
            strServerName = FileReader.ReadLine
            strDataBaseName = FileReader.ReadLine
            strDataBaseUserName = FileReader.ReadLine
            strDataBasePassword = FileReader.ReadLine
            Dim NewString As String = FileReader.ReadLine

            If NewString = "" Then
                Db_Conn = ("server=" & strServerName & ";database=" & strDataBaseName & ";integrated security=true")
                Db_Conn = ("Data Source=" & strServerName & ";Initial Catalog=" & strDataBaseName & ";User Id=" & strDataBaseUserName & ";Password=" & strDataBasePassword & ";")
                Db_Conn = Db_Conn & "MultipleActiveResultSets=True"
                Db_Conn = Db_Conn & ";Connection Timeout=300"
                'Db_Conn = "workstation id=DataMain.mssql.somee.com;packet size=4096;user id=mmr_doha_SQLLogin_1;pwd=6b16k2lq47;data source=DataMain.mssql.somee.com;persist security info=False;initial catalog=DataMain"
            Else
                Db_Conn = NewString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FileReader.Close()
        End Try
    End Sub
    Public Sub SGetAccessConnPath()
        Db_Conn = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=" & strDataBaseAccPassword & ";Data Source =" & Application.StartupPath & "\Data\Data.mdb"
    End Sub

    Public Sub GetServerNameAndDataBaseName(ByVal objReport As Object)
        If DataType = DataConnection.SqlServer Then
            Dim TBL1 As New CrystalDecisions.Shared.TableLogOnInfo
            TBL1.ConnectionInfo.ServerName = strServerName  'My.Computer.Name & "\SQLEXPRESS"
            TBL1.ConnectionInfo.DatabaseName = strDataBaseName 'strDataBaseName
            TBL1.ConnectionInfo.UserID = strDataBaseUserName
            TBL1.ConnectionInfo.Password = strDataBasePassword 'strPassword
            TBL1.ConnectionInfo.IntegratedSecurity = False
            For I As Integer = 0 To objReport.Database.Tables.Count - 1
                objReport.Database.Tables(I).ApplyLogOnInfo(TBL1)
            Next I
        ElseIf DataType = DataConnection.Access Then
            Dim TBL1 As New CrystalDecisions.Shared.TableLogOnInfo
            TBL1.ConnectionInfo.ServerName = (Application.StartupPath & "\Data\Data.mdb")
            TBL1.ConnectionInfo.DatabaseName = (Application.StartupPath & "\Data\Data.mdb")
            TBL1.ConnectionInfo.UserID = "admin"
            TBL1.ConnectionInfo.Password = strDataBaseAccPassword
            For I As Integer = 0 To objReport.Database.Tables.Count - 1
                'objReport.Database.Tables(I).Location = (Application.StartupPath & "\Data\Data.mdb")
                objReport.Database.Tables(I).ApplyLogOnInfo(TBL1)
            Next I
        End If
    End Sub

    Public Function GETATTACHDATABASENAME() As Boolean
        Try
            Dim DS As New DataSet
            'Dim SqlConnection1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("server=" & strServerName & ";Initial Catalog=tempdb;Integrated Security=SSPI;")
            'Dim str As String = "Select DISTINCT name from master.dbo.sysdatabases where name Like " & "'" & strDataBaseName & "'" & " and has_dbaccess(Name) = 1 "

            Dim SqlConnection1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("server=" & strServerName & ";Initial Catalog=tempdb;User ID =" & strDataBaseUserName & ";Password=" & strDataBasePassword & ";")
            Dim str As String = "Select DISTINCT name from master.dbo.sysdatabases where name Like " & "'" & strDataBaseName & "'" & " and has_dbaccess(Name) = 1 "

            Dim ADP As SqlClient.SqlDataAdapter
            ADP = New SqlClient.SqlDataAdapter(str, SqlConnection1)
            DS.Clear()
            ADP.Fill(DS)
            If DS.Tables(0).Rows.Count = 0 Then
                GETATTACHDATABASENAME = False
                MessageBox.Show("قاعدة البيانات غير متصلة بالسيرفر" & vbCrLf & "من فضلك تأكد من أتصال قاعدة البيانات بالسيرفر", ProgName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Else
                GETATTACHDATABASENAME = True
            End If
            ADP.Dispose()
            SqlConnection1.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub ATTACHDATABASENAME(ByVal MYDBNAME As String, ByVal f1lepathprimary As String, ByVal f1lepathlog As String)
        Try
            Dim SqlConnection1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=" & strServerName & ";Initial Catalog=tempdb;Integrated Security=SSPI;")
            Dim CMD As SqlClient.SqlCommand = New SqlClient.SqlCommand
            CMD.CommandType = CommandType.Text
            CMD.Connection = SqlConnection1
            If SqlConnection1.State = ConnectionState.Open Then SqlConnection1.Close()
            SqlConnection1.Open()
            CMD.CommandText = "sp_attach_db " & MYDBNAME & ",'" & f1lepathprimary & "'" & ",'" & f1lepathlog & "'"
            'CMD.CommandText = "sp_Detach_db " & MYDBNAME & ",'" & f1lepathprimary & "'" & ",'" & f1lepathlog & "'"
            ' OR CMD.CommandText = "CREATE DATABASE " & MYDBNAME & " ON (FILENAME = '" & f1lepath & "')FOR ATTACH"
            CMD.ExecuteNonQuery()
            SqlConnection1.Dispose()
            MessageBox.Show("تم انشاء اتصال  قاعدة البيانات بالسرفر ", ProgName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        Catch ex As Exception
            Dim result As Integer
            result = MessageBox.Show("من فضلك قم بعمل اتصال قاعدة البيانات بالسرفر", ProgName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Shell(Application.StartupPath & "\EgyptTeam2.exe", AppWinStyle.NormalFocus)
        End Try
    End Sub
    Public Function getConn() As SqlClient.SqlConnection
        Return CON
    End Function
    Public Sub OpenConn()
        CON.Open()
    End Sub
    Public Sub CloseConn()
        CON.Close()
        CON.Dispose()
        CON = Nothing
    End Sub

End Module

