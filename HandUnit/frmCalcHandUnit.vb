Imports System.Data.SqlClient
Imports Main_New_Project
Imports System.IO

'Imports Main_New_Project.mo

Public Class frmCalcHandUnit
    Dim connectionString As String '= ("Data Source=192.168.0.1\SQLSERVER2014;Initial Catalog=DataMain;User Id=sa;Password=mmr_123456;MultipleActiveResultSets=True;Connection Timeout=300")
    'Dim connectionString As String = ("Data Source=MMR-PC\SQLSERVER2014;Initial Catalog=DataMain;User Id=HandUnit;Password=123456;MultipleActiveResultSets=True;Connection Timeout=300")
    Dim bolClose As Boolean ' للسماح بغلق البرنامج

    Public Sub SDrawMultiTranGrid(ByVal strDataGrid As DataGridView)
        Dim ID As New DataGridViewTextBoxColumn
        With ID
            .HeaderText = "م" : .Width = 60 : .Visible = True : .Tag = "ID" : .Name = "ID"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim MainCode As New DataGridViewTextBoxColumn
        With MainCode
            .HeaderText = "الكود الاساسي" : .AutoSizeMode = .Width = 120 : .Visible = True : .Tag = "MainCode" : .Name = "MainCode"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim IDNo As New DataGridViewTextBoxColumn
        With IDNo
            .HeaderText = "الرقم القومي" : .Width = 120 : .Visible = True : .Tag = "IDNo" : .Name = "IDNo"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim Name As New DataGridViewTextBoxColumn
        With Name
            .HeaderText = "الأســـم" : .Width = 120 : .Visible = True : .Tag = "Name" : .Name = "Name"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim Address As New DataGridViewTextBoxColumn
        With Address
            .HeaderText = "العنوان" : .Width = 150 : .Visible = True : .ReadOnly = True : .Tag = "Address" : .Name = "TranNo"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim Asthlak As New DataGridViewTextBoxColumn
        With Asthlak
            .HeaderText = "الإستهلاك" : .Width = 70 : .Visible = True : .ReadOnly = True : .Tag = "Asthlak" : .Name = "Asthlak"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim DateNow As New DataGridViewTextBoxColumn
        With DateNow
            .HeaderText = "الوقت" : .Width = 120 : .Visible = True : .ReadOnly = True : .Tag = "DateNow" : .Name = "DateNow"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim PriceCalcType As New DataGridViewTextBoxColumn
        With PriceCalcType
            .HeaderText = "طريقة المحاسبه" : .Width = 100 : .Visible = False : .ReadOnly = True : .Tag = "PriceCalcType" : .Name = "PriceCalcType"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim PriceCalcTypeName As New DataGridViewTextBoxColumn
        With PriceCalcTypeName
            .HeaderText = "طريقة المحاسبه" : .Width = 120 : .Visible = True : .ReadOnly = True : .Name = "PriceCalcTypeName"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim ActivitiesCode As New DataGridViewTextBoxColumn
        With ActivitiesCode
            .HeaderText = "نوع النشاط" : .Width = 100 : .Visible = False : .ReadOnly = True : .Tag = "ActivitiesCode" : .Name = "ActivitiesCode"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim ActivitiesName As New DataGridViewTextBoxColumn
        With ActivitiesName
            .HeaderText = "نوع النشاط" : .Width = 100 : .Visible = True : .ReadOnly = True : .Name = "ActivitiesName"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim intEffectDay As New DataGridViewTextBoxColumn
        With intEffectDay
            .HeaderText = "مدة المحاسبه" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "intEffectDay" : .Name = "intEffectDay"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim Total As New DataGridViewTextBoxColumn
        With Total
            .HeaderText = "ق.الإستهلاك" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "Total" : .Name = "Total"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        Dim PayedState As New DataGridViewTextBoxColumn
        With PayedState
            .HeaderText = "حالة السداد" : .Width = 100 : .Visible = False : .ReadOnly = True : .Tag = "PayedState" : .Name = "PayedState"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '''''''''''
        strDataGrid.Columns.Add(ID)
        strDataGrid.Columns.Add(MainCode)
        strDataGrid.Columns.Add(IDNo)
        strDataGrid.Columns.Add(Name)
        strDataGrid.Columns.Add(Address)
        strDataGrid.Columns.Add(Asthlak)
        strDataGrid.Columns.Add(DateNow)
        strDataGrid.Columns.Add(PriceCalcType)
        strDataGrid.Columns.Add(PriceCalcTypeName)
        strDataGrid.Columns.Add(ActivitiesCode)
        strDataGrid.Columns.Add(ActivitiesName)
        strDataGrid.Columns.Add(intEffectDay)
        strDataGrid.Columns.Add(Total)
        strDataGrid.Columns.Add(PayedState)

        strDataGrid.ReadOnly = True

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        strDataGrid.AllowUserToOrderColumns = False
        strDataGrid.AllowUserToResizeColumns = False
        strDataGrid.AllowUserToResizeRows = False

        strDataGrid.RowHeadersVisible = True
        strDataGrid.RowHeadersWidth = 30
    End Sub


    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Select Case DataGridView1.Columns(e.ColumnIndex).Name
            Case "Asthlak"

            Case "PriceCalcType"
                Select Case DataGridView1.Item("PriceCalcType", e.RowIndex).Value
                    Case "0"
                        DataGridView1.Item("PriceCalcTypeName", e.RowIndex).Value = "سنوى"
                    Case "1"
                        DataGridView1.Item("PriceCalcTypeName", e.RowIndex).Value = "اعمال مؤقتة"
                    Case "2"
                        DataGridView1.Item("PriceCalcTypeName", e.RowIndex).Value = "ضبط سابق"
                End Select
            Case "ActivitiesCode"
                Select Case DataGridView1.Item("ActivitiesCode", e.RowIndex).Value
                    Case "1"
                        DataGridView1.Item("ActivitiesName", e.RowIndex).Value = "منزلي"
                    Case "2"
                        DataGridView1.Item("ActivitiesName", e.RowIndex).Value = "سلعي"
                    Case "3"
                        DataGridView1.Item("ActivitiesName", e.RowIndex).Value = "خدمي"
                    Case "4"
                        DataGridView1.Item("ActivitiesName", e.RowIndex).Value = "زراعي"
                End Select
            Case "PayedState"
                If DataGridView1.Item("PayedState", e.RowIndex).Value = 0 Then ' لم يسدد
                    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                ElseIf DataGridView1.Item("PayedState", e.RowIndex).Value = 1 Then ' تم السداد
                    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
                ElseIf DataGridView1.Item("PayedState", e.RowIndex).Value = 2 Then ' تم سداد جزء
                    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                End If
        End Select
    End Sub

    ''''''''''''''''''''''''''''''' 
    Private Sub frmCalcHandUnit_Load(sender As Object, e As EventArgs) Handles Me.Load
        connectionString = FGetConnPath()

        Call SDrawMultiTranGrid(DataGridView1)
        bolClose = False ' لعدم السماح بغلق البرنامج
        GetNames()
        Call SLoadBar()
    End Sub

    Private Sub SLoadGridData(CONString As SqlClient.SqlConnection)
        Try
            '"Tblu_HandUnitCalc"
            Call SLoadGrid("Tblu_HandUnitCalc", DataGridView1, CONString, "", " ID DESC")
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If DataGridView1.Item("Total", i).Value = 0 Then
                    DataGridView1.Item("Total", i).Value = FCalcEnergyMain(DataGridView1.Item("Asthlak", i).Value, Now.Date, DataGridView1.Item("ActivitiesCode", i).Value, DataGridView1.Item("intEffectDay", i).Value, DataGridView1.Item("PriceCalcType", i).Value, 0, CONString)
                    Dim strCondition As String = "ID= " & DataGridView1.Item("ID", i).Value & " And MainCode= '" & DataGridView1.Item("MainCode", i).Value & "'"
                    FEditeRecord("Tblu_HandUnitCalc", strCondition, CONString, {"Total"}, {DataGridView1.Item("Total", i).Value.ToString})
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function DoesUserHavePermission() As Boolean
        Try
            Dim clientPermission As SqlClientPermission = New SqlClientPermission(Security.Permissions.PermissionState.Unrestricted)
            ' this will throw an error if the user does not have the permissions
            clientPermission.Demand()
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


    Public Sub GetNames()
        Try
            If Not DoesUserHavePermission() Then
                Return
            End If
            DataGridView1.Rows.Clear()
            ' You must stop the dependency before starting a new one.
            ' You must start the dependency when creating a new one.
            SqlDependency.Stop(connectionString)
            SqlDependency.Start(connectionString)

            Using cn As SqlConnection = New SqlConnection(connectionString)
                Using cmd As SqlCommand = cn.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT IDNo, Name,Address,EnergyQuntity,EnergyQuntityHourse,Asthlak,Total FROM dbo.[Tblu_HandUnitCalc]"
                    cmd.Notification = Nothing
                    ' creates a new dependency for the SqlCommand
                    Dim dep As SqlDependency = New SqlDependency(cmd)
                    ' creates an event handler for the notification of data changes in the database
                    AddHandler dep.OnChange, AddressOf dep_onchange
                    cn.Open()
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        'While dr.Read()
                        '    lbNames.Items.Add(dr.GetString(0) & " " & dr.GetString(1))
                        'End While
                        If dr.Read = True Then
                            Call SLoadGridData(cn)
                        End If
                    End Using
                End Using

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub


    Private Sub dep_onchange(ByVal sender As System.Object, ByVal e As System.Data.SqlClient.SqlNotificationEventArgs)
        ' this event is run asynchronously so you will need to invoke to run on the UI thread(if required)
        If Me.InvokeRequired Then
            DataGridView1.BeginInvoke(New MethodInvoker(AddressOf GetNames))
        Else
            GetNames()
        End If
        ' this will remove the event handler since the dependency is only for a single notification
        Dim dep As SqlDependency = DirectCast(sender, SqlDependency)
        RemoveHandler dep.OnChange, AddressOf dep_onchange
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If bolClose = False Then

            If e.CloseReason = CloseReason.TaskManagerClosing Then
                e.Cancel = True
                MessageBox.Show("Task manager tried to close me")
            Else
                e.Cancel = True
            End If
            Me.WindowState = FormWindowState.Minimized
        End If
        'SqlDependency.Stop(connectionString)
    End Sub

    Private Sub frmCalcHandUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Control And e.KeyCode = Keys.M Then
                SqlDependency.Stop(connectionString)
                bolClose = True  ' للسماح بغلق البرنامج
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
        ElseIf Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Minimized
        End If

        'ContextMenuStrip1.Show()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'NotifyIcon1.Visible = (Me.WindowState = FormWindowState.Minimized)

        If Me.WindowState = FormWindowState.Minimized Then
            ShowInTaskbar = False
            NotifyIcon1.Visible = True
        Else
            'ShowInTaskbar = True
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub frmCalcHandUnit_MinimumSizeChanged(sender As Object, e As EventArgs) Handles Me.MinimumSizeChanged
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub SLoadBar()
        'strSQL = ("SELECT * FROM Tblu_News")
        'Dim cmd As New SqlClient.SqlCommand(strSQL, CONString)
        'Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
        'Do While dr.Read
        Dim strtmp As String = "برنامج إدارة السرقات" & " - " & "تصميم محاسب مدحت رمضان" & " - " & "01224481228 - 01146021698"
        'lblNews.Text = ""

        lblNews.Text = lblNews.Text + "   -   " + strtmp
        Me.lblNews.Left = -Me.lblNews.Width '- 2550
        Timer1.Start()
        'Loop
        'dr.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '     interval-20 timer enabled=false

        If Me.Timer1.Enabled = True Then
            Me.Timer1.Start()
        End If

        If Me.lblNews.Left = +Me.lblNews.Width Then
            Me.lblNews.Left = Me.Width
        End If
        Me.lblNews.Left += 1
    End Sub

    Private Function FGetConnPath() As String
        Dim FileReader As StreamReader
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
            Return Db_Conn
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FileReader.Close()
        End Try
    End Function

End Class