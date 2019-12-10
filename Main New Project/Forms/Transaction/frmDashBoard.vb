Public Class frmDashBoard
    Dim strTableName As String '= "View_UserTransaction"
    Dim strCodition As String

    Public Sub New(strTableNamTmp As String, strCoditionTmp As String)
        strTableName = strTableNamTmp
        strCodition = strCoditionTmp
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmDashBoard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = Mdi
        DataGridView1.ReadOnly = True
        Call SFillCombo(cmbUserID, "Tblc_UserCode", "ID", "UserName", "", False, "", ComboLoadItemSelect.Min) : cmbUserID.SelectedValue = 0
        Call SFillCombo(cmbTran, "Tblu_UserTransactionsTran", "ID", "TranName2", "", False, "", ComboLoadItemSelect.Min) : cmbTran.SelectedValue = 0

        DTPicker1.Value = Now.Date
        Call SLoadData(strTableName, strCodition)
    End Sub

    Private Sub SLoadData(strTableNamTmp As String, strCoditionTmp As String)
        Dim strSQL As String = ("SELECT * from " & strTableNamTmp)
        If strCodition <> "" Then
            strSQL = strSQL & "  WHERE " & strCoditionTmp
        End If
        strSQL = strSQL & " ORDER BY ID Desc"

        If strSQL <> "" Then
            If DataType = DataConnection.SqlServer Then
                Dim Adpt As New SqlClient.SqlDataAdapter(strSQL, CON)
                Dim ds As New DataSet()
                Adpt.Fill(ds, strTableName)
                DataGridView1.DataSource = ds.Tables(0)
            ElseIf DataType = DataConnection.Access Then
                Dim Adpt As New OleDb.OleDbDataAdapter(strSQL, CONAccess)
                Dim ds As New DataSet()
                Adpt.Fill(ds, strTableName)
                DataGridView1.DataSource = ds.Tables(0)
            End If
        End If

        DataGridView1.Columns(0).HeaderText = "رقم المستخدم" : DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "أسم المستخدم" : DataGridView1.Columns(1).Width = 120
        DataGridView1.Columns(2).HeaderText = "كود الشاشة" : DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).HeaderText = "أسم الشاشة" : DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).HeaderText = "رقم الحركة" : DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(5).HeaderText = "كود الحركة" : DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).HeaderText = "أسم الحركة" : DataGridView1.Columns(6).Width = 100
        DataGridView1.Columns(7).HeaderText = "التاريخ" : DataGridView1.Columns(7).Width = 100
        DataGridView1.Columns(8).HeaderText = "الوقت" : DataGridView1.Columns(8).Width = 100
        DataGridView1.Columns(9).HeaderText = "مسلسل" : DataGridView1.Columns(9).Width = 80
        DataGridView1.Columns(10).HeaderText = "اسم الجهاز" : DataGridView1.Columns(10).Width = 80
        DataGridView1.Columns(11).Visible = False

        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.RowHeadersWidth = 50
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        DataGridView1.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        ''''''

        Dim strSQL2 As String = ("SELECT * from " & strTableNamTmp & "2 Where Date='" & FFormatDate(DTPicker1.Value) & "'")
        'If strCodition <> "" Then
        '    strSQL2 = strSQL2 & "  WHERE " & strCoditionTmp
        'End If
        'strSQL2 = strSQL & " ORDER BY ID Desc"

        If strSQL2 <> "" Then
            If DataType = DataConnection.SqlServer Then
                Dim Adpt As New SqlClient.SqlDataAdapter(strSQL2, CON)
                Dim ds As New DataSet()
                Adpt.Fill(ds, strTableName)
                DataGridView2.DataSource = ds.Tables(0)
            ElseIf DataType = DataConnection.Access Then
                Dim Adpt As New OleDb.OleDbDataAdapter(strSQL2, CONAccess)
                Dim ds As New DataSet()
                Adpt.Fill(ds, strTableName)
                DataGridView2.DataSource = ds.Tables(0)
            End If
        End If

        DataGridView2.Columns(0).HeaderText = "رقم المستخدم" : DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).HeaderText = "أسم المستخدم" : DataGridView2.Columns(1).Width = 120
        DataGridView2.Columns(2).HeaderText = "أسم الحركة" : DataGridView2.Columns(2).Visible = False
        DataGridView2.Columns(3).HeaderText = "أسم الحركة" : DataGridView2.Columns(3).Width = 100
        DataGridView2.Columns(4).HeaderText = "عدد المرات" : DataGridView2.Columns(4).Width = 100
        DataGridView2.Columns(5).HeaderText = "التاريخ" : DataGridView2.Columns(5).Width = 100

        DataGridView2.AllowUserToAddRows = False
        DataGridView2.AllowUserToDeleteRows = False
        DataGridView2.RowHeadersWidth = 50
        DataGridView2.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        DataGridView2.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        ''''''
    End Sub

    Private Sub cmbUserID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUserID.SelectedIndexChanged
        'SLoadData("View_UserTransaction", "Date ='" & FFormatDate(DTPicker1.Value) & "'")
    End Sub

    Private Sub DTPicker1_ValueChanged(sender As Object, e As EventArgs) Handles DTPicker1.ValueChanged
        'SLoadData("View_UserTransaction", "Date =" & FFormatDate(DTPicker1.Value))
    End Sub

    Private Sub cmdRun_Click(sender As Object, e As EventArgs) Handles cmdRun.Click
        Dim strConditionTmp As String = ""

        If cmbUserID.Text <> "" Or cmbUserID.SelectedValue <> Nothing Then
            strConditionTmp = "UserID=" & cmbUserID.SelectedValue
        End If

        If strConditionTmp = "" Then
            strConditionTmp = "Date='" & FFormatDate(DTPicker1.Value) & "'"
        Else
            strConditionTmp = strConditionTmp & " And Date='" & FFormatDate(DTPicker1.Value) & "'"
        End If

        If cmbTran.Text <> "" Or cmbTran.SelectedValue <> Nothing Then
            strConditionTmp = strConditionTmp & " And TranType=" & cmbTran.SelectedValue
        End If

        If TxtBoxPcName.Text <> "" Then
            strConditionTmp = strConditionTmp & " And PCName='" & TxtBoxPcName.Text & "'"
        End If

        SLoadData("View_UserTransaction", strConditionTmp)
    End Sub

End Class