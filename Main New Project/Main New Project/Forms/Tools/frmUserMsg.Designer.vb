<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserMsg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserMsg))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TxtBox1 = New System.Windows.Forms.TextBox
        Me.TxtBox2 = New System.Windows.Forms.TextBox
        Me.cmdReloadUsers = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmbUserCode = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(354, 204)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.Account_System.My.Resources.Resources._4441
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.TxtBox1)
        Me.TabPage1.Controls.Add(Me.TxtBox2)
        Me.TabPage1.Controls.Add(Me.cmdReloadUsers)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.cmbUserCode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(346, 178)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "إرسال رسالة"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TxtBox1
        '
        Me.TxtBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox1.Location = New System.Drawing.Point(189, 7)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.Size = New System.Drawing.Size(54, 21)
        Me.TxtBox1.TabIndex = 0
        Me.TxtBox1.Tag = "Code,Null,,رقم الحركة"
        '
        'TxtBox2
        '
        Me.TxtBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox2.Location = New System.Drawing.Point(6, 43)
        Me.TxtBox2.Multiline = True
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtBox2.Size = New System.Drawing.Size(328, 118)
        Me.TxtBox2.TabIndex = 2
        Me.TxtBox2.Tag = "Notes,,,"
        '
        'cmdReloadUsers
        '
        Me.cmdReloadUsers.BackgroundImage = CType(resources.GetObject("cmdReloadUsers.BackgroundImage"), System.Drawing.Image)
        Me.cmdReloadUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdReloadUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdReloadUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdReloadUsers.Location = New System.Drawing.Point(6, 6)
        Me.cmdReloadUsers.Name = "cmdReloadUsers"
        Me.cmdReloadUsers.Size = New System.Drawing.Size(31, 21)
        Me.cmdReloadUsers.TabIndex = 303
        Me.cmdReloadUsers.TabStop = False
        Me.ToolTip1.SetToolTip(Me.cmdReloadUsers, "إرسال الرسالة")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(244, 10)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 13)
        Me.Label22.TabIndex = 301
        Me.Label22.Text = "اسم المستخدم :"
        '
        'cmbUserCode
        '
        Me.cmbUserCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUserCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUserCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUserCode.FormattingEnabled = True
        Me.cmbUserCode.Location = New System.Drawing.Point(41, 7)
        Me.cmbUserCode.Name = "cmbUserCode"
        Me.cmbUserCode.Size = New System.Drawing.Size(145, 21)
        Me.cmbUserCode.TabIndex = 1
        Me.cmbUserCode.Tag = "CustId,null,,,1,رقم العميل"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "جينيس تكنولوجي"
        '
        'frmUserMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(354, 204)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.Name = "frmUserMsg"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmdReloadUsers As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbUserCode As System.Windows.Forms.ComboBox
    Friend WithEvents TxtBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
