Imports System.Data.SqlClient
Imports Main_New_Project
'Imports Main_New_Project.mo

Public Class frmCalcHandUnit
    Dim connectionString As String = ("Data Source=MMR-PC\SQLSERVER2014;Initial Catalog=DataMain;User Id=sa;Password=123456;MultipleActiveResultSets=True;Connection Timeout=300")
    'Dim connectionString As String = ("Data Source=MMR-PC\SQLSERVER2014;Initial Catalog=DataMain;User Id=HandUnit;Password=123456;MultipleActiveResultSets=True;Connection Timeout=300")

    Public Sub SDrawMultiTranGrid(ByVal strDataGrid As DataGridView)
        Dim MainCode As New DataGridViewTextBoxColumn
        With MainCode
            .HeaderText = "الكود الاساسي" : .Width = 120 : .Visible = True : .Tag = "MainCode" : .Name = "MainCode"
        End With
        '''''''''''
        Dim IDNo As New DataGridViewTextBoxColumn
        With IDNo
            .HeaderText = "الرقم القومي" : .Width = 120 : .Visible = True : .Tag = "IDNo" : .Name = "IDNo"
        End With
        '''''''''''
        Dim Name As New DataGridViewTextBoxColumn
        With Name
            .HeaderText = "الأســـم" : .Width = 120 : .Visible = True : .Tag = "Name" : .Name = "Name"
        End With
        '''''''''''
        Dim Address As New DataGridViewTextBoxColumn
        With Address
            .HeaderText = "العنوان" : .Width = 150 : .Visible = True : .ReadOnly = True : .Tag = "Address" : .Name = "TranNo"
        End With
        '''''''''''
        Dim Asthlak As New DataGridViewTextBoxColumn
        With Asthlak
            .HeaderText = "الإستهلاك" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "Asthlak" : .Name = "Asthlak"
        End With
        '''''''''''
        Dim DateNow As New DataGridViewTextBoxColumn
        With DateNow
            .HeaderText = "الوقت" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "DateNow" : .Name = "DateNow"
        End With
        '''''''''''
        Dim PriceCalcType As New DataGridViewTextBoxColumn
        With PriceCalcType
            .HeaderText = "طريقة المحاسبه" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "PriceCalcType" : .Name = "PriceCalcType"
        End With
        '''''''''''
        Dim ActivitiesCode As New DataGridViewTextBoxColumn
        With ActivitiesCode
            .HeaderText = "نوع النشاط" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "ActivitiesCode" : .Name = "ActivitiesCode"
        End With
        '''''''''''
        Dim intEffectDay As New DataGridViewTextBoxColumn
        With intEffectDay
            .HeaderText = "مدة المحاسبه" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "intEffectDay" : .Name = "intEffectDay"
        End With
        '''''''''''
        Dim Total As New DataGridViewTextBoxColumn
        With Total
            .HeaderText = "ق.الإستهلاك" : .Width = 100 : .Visible = True : .ReadOnly = True : .Tag = "Total" : .Name = "Total"
        End With
        '''''''''''
        strDataGrid.Columns.Add(MainCode)
        strDataGrid.Columns.Add(IDNo)
        strDataGrid.Columns.Add(Name)
        strDataGrid.Columns.Add(Address)
        strDataGrid.Columns.Add(Asthlak)
        strDataGrid.Columns.Add(DateNow)
        strDataGrid.Columns.Add(PriceCalcType)
        strDataGrid.Columns.Add(ActivitiesCode)
        strDataGrid.Columns.Add(intEffectDay)
        strDataGrid.Columns.Add(Total)
        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = True
        strDataGrid.RowHeadersVisible = True
        strDataGrid.RowHeadersWidth = 30
    End Sub


    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Select Case DataGridView1.Columns(e.ColumnIndex).Name
            Case "Asthlak"
                'Dim StrTemp() As String = FGetFeildValuesArry("Tblc_EnergyDevices", {"Name", "Type", "Power"}, "ID=" & Me.DataGridView1.Item(0, e.RowIndex).Value)
                'DataGridView1.Item("Total", e.RowIndex).Value = FCalcEnergyMain(DataGridView1.Item("Asthlak", e.RowIndex).Value, Now.Date, DataGridView1.Item("ActivitiesCode", e.RowIndex).Value, DataGridView1.Item("intEffectDay", e.RowIndex).Value, DataGridView1.Item("PriceCalcType", e.RowIndex).Value)
            Case "2"

            Case 4

            Case 5

        End Select
    End Sub

    ''''''''''''''''''''''''''''''' 

    Private Sub frmCalcHandUnit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SDrawMultiTranGrid(DataGridView1)
        GetNames()
    End Sub

    Private Sub SLoadGridData(CONString As SqlClient.SqlConnection)
        Try
            '"Tblu_HandUnitCalc"
            Call SLoadGrid("Tblu_HandUnitCalc", DataGridView1, CONString, "", "")
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If DataGridView1.Item("Total", i).Value = 0 Then
                    DataGridView1.Item("Total", i).Value = FCalcEnergyMain(DataGridView1.Item("Asthlak", i).Value, Now.Date, DataGridView1.Item("ActivitiesCode", i).Value, DataGridView1.Item("intEffectDay", i).Value, DataGridView1.Item("PriceCalcType", i).Value, 0, CONString)
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
                    cmd.CommandText = "SELECT IDNo, Name,Address,Asthlak FROM dbo.[Tblu_HandUnitCalc]"
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
        SqlDependency.Stop(connectionString)
    End Sub


End Class