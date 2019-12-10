Public Class frmTreeSearch2
    Dim Dp As SqlClient.SqlDataAdapter
    Dim DpAccess As OleDb.OleDbDataAdapter
    Dim ds As New DataSet()
    Dim tmpReturnType As SearchReturnType
    Private Sub SLoadTree(ByVal strGTableName As String, ByVal strGKeyField As String, ByVal strFrmTitle As String, Optional ByVal strSecondField As String = "Name", Optional ByVal ReturnType As SearchReturnType = SearchReturnType.String)
        TreeView1.Nodes.Clear()
        Dim ParentNode1 As New TreeNode(strFrmTitle) : ParentNode1.Tag = 0
        TreeView1.Nodes.Add(ParentNode1)
        AddSubNode(ParentNode1, strGTableName, strGKeyField, strSecondField)
        TreeView1.CheckBoxes = True
        TreeView1.Sort()
        TreeView1.ExpandAll()
    End Sub
    Private Sub AddSubNode(ByVal Node As TreeNode, ByVal strGTableName As String, ByVal strGKeyField As String, Optional ByVal strSecondField As String = "Name")
        Dim dv1 As DataView = ds.Tables(strGTableName).DefaultView
        Dim m As String = CType(Node.Tag, Long)
        For Each dr As DataRowView In dv1
            Dim SubNode As New TreeNode(dr.Item(strGKeyField) & "-" & dr.Item(strSecondField).ToString())
            SubNode.Tag = dr(strGKeyField).ToString
            Node.Nodes.Add(SubNode)
        Next
    End Sub
    Public Sub LoadDataSet(ByVal strGTableName As String, ByVal strGKeyField As String, ByVal strFrmTitle As String, Optional ByVal bolCompanyID As Boolean = True, Optional ByVal bolUserId As Boolean = True, Optional ByVal strOrderBy As String = "", Optional ByVal strSecondField As String = "Name", Optional ByVal ReturnType As SearchReturnType = SearchReturnType.String, Optional ByVal strCondition As String = "")
        ds.Clear() : tmpReturnType = ReturnType

        strSQL = "SELECT *  From " & strGTableName
        If bolCompanyID = True Then
            strSQL = strSQL & " Where CompanyID=" & "'" & strCompanyID & "'"
        End If
        If bolUserId = True Then
            strSQL = strSQL & " and UserID=" & "'" & strUserID & "'"
        End If
        If strCondition <> "" Then
            strSQL = strSQL & " Where " & strCondition
        End If
        If strOrderBy <> "" Then
            strSQL = strSQL & " ORDER BY " & "'" & strOrderBy & "'"
        End If
        If DataType = DataConnection.SqlServer Then
            Dp = New SqlClient.SqlDataAdapter(strSQL, CON)
            Dp.Fill(ds, strGTableName)
        ElseIf DataType = DataConnection.Access Then
            DpAccess = New OleDb.OleDbDataAdapter(strSQL, CONAccess)
            DpAccess.Fill(ds, strGTableName)
        End If
        SLoadTree(strGTableName, strGKeyField, strFrmTitle, strSecondField, ReturnType)
    End Sub
    Private Sub frmTreeSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SLoadTree()
    End Sub
    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        If e.Node.Checked = True Then
            e.Node.BackColor = Color.SkyBlue
        Else
            e.Node.BackColor = Color.White
        End If
        For Each node As TreeNode In e.Node.Nodes
            node.Checked = e.Node.Checked
        Next
    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        strSearchTreeVal2 = ""

        For Each node As TreeNode In Me.TreeView1.Nodes
            ReadCheckedNodes(node)
        Next
        Me.Close()
    End Sub
    Private Sub ReadCheckedNodes(ByVal node As TreeNode)
        If node.Checked Then
            If node.Tag <> "0" Then
                If strSearchTreeVal2 = "" Then
                    If tmpReturnType = SearchReturnType.String Then
                        strSearchTreeVal2 = "'" & node.Tag & "'"
                    ElseIf tmpReturnType = SearchReturnType.Number Then
                        strSearchTreeVal2 = node.Tag
                    End If
                Else
                    If tmpReturnType = SearchReturnType.String Then
                        strSearchTreeVal2 = strSearchTreeVal2 & " , " & "'" & node.Tag & "'"
                    ElseIf tmpReturnType = SearchReturnType.Number Then
                        strSearchTreeVal2 = strSearchTreeVal2 & " , " & node.Tag
                    End If
                End If
            End If
        End If
        For Each nd As TreeNode In node.Nodes
            ReadCheckedNodes(nd)
        Next
    End Sub
End Class