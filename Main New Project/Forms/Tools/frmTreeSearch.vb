Public Class frmTreeSearch
    Dim Dp As SqlClient.SqlDataAdapter
    Dim DpAccess As OleDb.OleDbDataAdapter
    Dim ds As New DataSet()
    Private Sub SLoadTree(ByVal strGTableName As String, ByVal strGKeyField As String, ByVal strFrmTitle As String)
        'If CON.State = ConnectionState.Closed Then CON.Open()
        TreeView1.Nodes.Clear()
        Dim ParentNode1 As New TreeNode(strFrmTitle) : ParentNode1.Tag = 0
        TreeView1.Nodes.Add(ParentNode1)
        AddSubNode(ParentNode1, strGTableName, strGKeyField)
        TreeView1.CheckBoxes = True
        TreeView1.Sort()
        'TreeView1.ExpandAll()
        TreeView1.Nodes(0).Expand()
    End Sub
    Private Sub AddSubNode(ByVal Node As TreeNode, ByVal strGTableName As String, ByVal strGKeyField As String)
        Dim dv1 As DataView = ds.Tables(strGTableName).DefaultView
        Dim m As String = CType(Node.Tag, Long)
        dv1.RowFilter = "Type =" & CType(Node.Tag, Long)
        For Each dr As DataRowView In dv1
            Dim SubNode As New TreeNode(dr.Item(strGKeyField) & "-" & dr("Name").ToString())
            SubNode.Tag = dr(strGKeyField).ToString
            Node.Nodes.Add(SubNode)
            If Not SubNode.Tag Is String.Empty Then
                AddSubNode(SubNode, strGTableName, strGKeyField)
            End If
        Next
    End Sub
    Public Sub LoadDataSet(ByVal strGTableName As String, ByVal strGKeyField As String, ByVal strFrmTitle As String, Optional ByVal bolCompanyID As Boolean = True, Optional ByVal bolUserId As Boolean = True, Optional ByVal strOrderBy As String = "", Optional ByVal strCondition As String = "")
        ds.Clear()
        strSQL = "SELECT *  From " & strGTableName
        If bolCompanyID = True Then
            strSQL = strSQL & " Where CompanyID=" & "'" & strCompanyID & "'"
        End If
        If bolUserId = True Then
            strSQL = strSQL & " UserID=" & "'" & strUserID & "'"
        End If
        If strCondition <> "" And bolCompanyID = True Then
            strSQL = strSQL & " And '" & strCondition & "'"
        ElseIf strCondition <> "" And bolCompanyID = False  Then
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
        SLoadTree(strGTableName, strGKeyField, strFrmTitle)
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
        strSearchTreeVal = Nothing
        Me.Close()
    End Sub
    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        strSearchTreeVal = ""

        For Each node As TreeNode In Me.TreeView1.Nodes
            ReadCheckedNodes(node)
        Next
        Me.Close()
    End Sub
    Private Sub ReadCheckedNodes(ByVal node As TreeNode)
        If node.Checked Then
            If node.Tag <> "0" Then
                If strSearchTreeVal = "" Then
                    strSearchTreeVal = "'" & node.Tag & "'"
                Else
                    strSearchTreeVal = strSearchTreeVal & " , " & "'" & node.Tag & "'"
                End If
            End If
        End If
        For Each nd As TreeNode In node.Nodes
            ReadCheckedNodes(nd)
        Next
    End Sub
End Class