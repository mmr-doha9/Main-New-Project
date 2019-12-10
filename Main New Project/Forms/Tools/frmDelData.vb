Public Class frmDelData
    Private Sub frmDelData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call ClearControl(Me.TabPage1)
    End Sub
    Private Sub chkDelAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDelAll.CheckedChanged
        If chkDelAll.Checked = True Then
            chkDelTran.Enabled = False
        Else
            chkDelTran.Enabled = True
        End If
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If MsgBox("هل انت متأكد من انك تريد حذف البيانات؟", MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Ok Then
            If MsgBox("تحذير اخير" & vbCrLf & "سيتم الحذف الان هل تريد التأكيد؟", MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName) = MsgBoxResult.Ok Then
                'If chkDelAll.Checked = True Then
                '    Call SDelAllData()
                '    'Call SDelTranData()
                'ElseIf chkDelTran.Checked = True Then
                '    Call SDelTranData()
                'End If
                Call SDelAllData()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, ProgName)
                Me.Close()
            End If
        End If
    End Sub
    Public Sub SDelTranData()
        Try
            strSQL = ("SELECT * FROM Tblu_TblName WHERE (Tblu_TblName.TblType)='" & 2 & "'")
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim x As String = dr.Item("TblName")
                    Call FDeleteRecord(x)
                Loop
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim x As String = dr.Item("TblName")
                    Call FDeleteRecord(x)
                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SDelAllData()
        Try
            strSQL = ("SELECT * FROM Tblu_TblName WHERE (Tblu_TblName.TblType)='" & 1 & "'")
            If DataType = DataConnection.SqlServer Then
                Dim cmd As New SqlClient.SqlCommand(strSQL, CON)
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim x As String = dr.Item("TblName")
                    Call FDeleteRecord(x)
                Loop
            ElseIf DataType = DataConnection.Access Then
                Dim cmd As New OleDb.OleDbCommand(strSQL, CONAccess)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim x As String = dr.Item("TblName")
                    Call FDeleteRecord(x)
                Loop
            End If
            Call SDelTranData()
            ' المستخدم الافتراضي
            Dim arrCtl() As String = {"ID", "UserName", "UserPassword", "UserType"} : Dim arrVal() As String = {"1", "مدير النظام", "123456", "1"}
            Call FAddNewRecord("Tblc_UserCode", arrCtl, arrVal)
            ' المستخدم الافتراضي
            ' الخزينة الافتراضية
            'Dim arrCtl2() As String = {"Code", "Name", "CompanyID"} : Dim arrVal2() As String = {"1", "خزينة رئيسية", "1"}
            'Call FAddNewRecord("Tblc_CasherCode", arrCtl2, arrVal2)
            '' الخزينة الافتراضية
            '' المخزن الافتراضي
            'Dim arrCtl3() As String = {"Code", "Name", "Address", "Tel", "Tel2", "SKeeperName", "SKeeperAdd", "SKeeperTele", "SKeeperIDNo", "CompanyID"} : Dim arrVal3() As String = {"1", "مخزن رئيسي", "0", "0", "0", "0", "0", "0", "0", "1"}
            'Call FAddNewRecord("Tblc_StoreCode", arrCtl3, arrVal3)
            '' المخزن الافتراضي
            '' المندوب الافتراضي
            'Dim arrCtl4() As String = {"Code", "Name", "Address", "Tel", "Tel2", "Mobile", "Mobile2", "IdNumber", "CompanyID"} : Dim arrVal4() As String = {"1", "مندوب رئيسي", "0", "0", "0", "0", "0", "0", "1"}
            'Call FAddNewRecord("Tblc_SalesMenCode", arrCtl4, arrVal4)
            '' المندوب الافتراضي
            '' الوحدة الافتراضية
            'Dim arrCtl5() As String = {"Code", "Name", "UnitRate", "CompanyID"} : Dim arrVal5() As String = {"1", "قطعه", "1", "1"}
            'Call FAddNewRecord("Tblc_UnitCode", arrCtl5, arrVal5)
            ' الوحدة الافتراضية
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class