Public Module modResolution
    Private Const mciFudge As Integer = 4
    'Private intTaskWidth As Integer = 110 ' نص عرض البار
    Public Sub FCenterFormInMDI(ByVal mdi As Form, ByVal frm As Form)
        Dim l As Integer, t As Integer, w As Integer, h As Integer

        With frm
            If .WindowState = vbNormal Then
                w = FGetMDIScaleWidth(mdi)
                h = FGetMDIScaleHeight(mdi)
                If w > 0 And h > 0 Then
                    l = (w - .Width) \ 2
                    t = (h - .Height) \ 2
                    If l < 0 Then                       'can't have caption off the screen
                        l = 0
                    End If
                    If t < 0 Then
                        t = 0
                    End If
                    If .Width > w Then
                        .Width = w
                        l = 0
                    End If
                    If .Height > h Then
                        .Height = h
                        t = 0
                    End If
                    .SetBounds(l, t, .Width, .Height)   'move to centered location
                End If
            End If
        End With
    End Sub

    Private Function FGetMDIScaleWidth(ByVal mdi As Form) As Integer
        ' Consider docked controls in the mdi and if docked then reduce the size
        Dim ctl As Control
        Dim w As Integer = mdi.ClientSize.Width

        For Each ctl In mdi.Controls
            With ctl
                If .GetContainerControl() Is mdi Then   'docked to the mdi form
                    If .Dock = DockStyle.Left Or .Dock = DockStyle.Right Then
                        w = w - .Size.Width
                    ElseIf .Name = "TaskPane1" Then

                    End If
                End If
            End With
        Next
        FGetMDIScaleWidth = w - mciFudge
    End Function

    Private Function FGetMDIScaleHeight(ByVal mdi As Form) As Integer
        ' Consider docked controls in the mdi and if docked then reduce the size
        Dim ctl As Control
        Dim h As Integer = mdi.ClientSize.Height

        For Each ctl In mdi.Controls
            With ctl
                If .GetContainerControl() Is mdi Then   'docked to the mdi form
                    If .Dock = DockStyle.Top Or .Dock = DockStyle.Bottom Then
                        h = h - .Size.Height
                    End If
                End If
            End With
        Next
        FGetMDIScaleHeight = h - mciFudge
    End Function

End Module
