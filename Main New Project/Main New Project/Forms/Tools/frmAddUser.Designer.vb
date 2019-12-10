<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUser))
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CtlGroup = New System.Windows.Forms.GroupBox
        Me.cmdNew = New System.Windows.Forms.Button
        Me.cmdOpen = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDel = New System.Windows.Forms.Button
        Me.CmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.ChkBoxReSavePermission = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtBox4 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtBox3 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBox1 = New System.Windows.Forms.TextBox
        Me.ChkAdmin = New System.Windows.Forms.CheckBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.CtlGroup.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.RightToLeftLayout = True
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(412, 205)
        Me.TabControl.TabIndex = 1
        Me.TabControl.Tag = ""
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TabPage1.BackgroundImage = Global.Account_System.My.Resources.Resources._4441
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.CtlGroup)
        Me.TabPage1.Controls.Add(Me.ChkBoxReSavePermission)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TxtBox4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TxtBox3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TxtBox2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TxtBox1)
        Me.TabPage1.Controls.Add(Me.ChkAdmin)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(404, 179)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "Tblc_UserCode"
        Me.TabPage1.Text = "إضافة مستخدم"
        '
        'CtlGroup
        '
        Me.CtlGroup.BackColor = System.Drawing.Color.Transparent
        Me.CtlGroup.Controls.Add(Me.cmdNew)
        Me.CtlGroup.Controls.Add(Me.cmdOpen)
        Me.CtlGroup.Controls.Add(Me.cmdSave)
        Me.CtlGroup.Controls.Add(Me.cmdDel)
        Me.CtlGroup.Controls.Add(Me.CmdPrevious)
        Me.CtlGroup.Controls.Add(Me.cmdNext)
        Me.CtlGroup.Controls.Add(Me.cmdFirst)
        Me.CtlGroup.Controls.Add(Me.cmdLast)
        Me.CtlGroup.Location = New System.Drawing.Point(87, -1)
        Me.CtlGroup.Name = "CtlGroup"
        Me.CtlGroup.Size = New System.Drawing.Size(311, 49)
        Me.CtlGroup.TabIndex = 287
        Me.CtlGroup.TabStop = False
        '
        'cmdNew
        '
        Me.cmdNew.BackgroundImage = Global.Account_System.My.Resources.Resources._New
        Me.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdNew.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdNew.Location = New System.Drawing.Point(272, 11)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(33, 34)
        Me.cmdNew.TabIndex = 84
        Me.cmdNew.TabStop = False
        '
        'cmdOpen
        '
        Me.cmdOpen.BackgroundImage = Global.Account_System.My.Resources.Resources.Open
        Me.cmdOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOpen.Location = New System.Drawing.Point(234, 11)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(33, 34)
        Me.cmdOpen.TabIndex = 83
        Me.cmdOpen.TabStop = False
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImage = Global.Account_System.My.Resources.Resources.Save
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSave.Location = New System.Drawing.Point(196, 11)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(33, 34)
        Me.cmdSave.TabIndex = 82
        Me.cmdSave.TabStop = False
        Me.cmdSave.Tag = ""
        '
        'cmdDel
        '
        Me.cmdDel.BackgroundImage = Global.Account_System.My.Resources.Resources.delete
        Me.cmdDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdDel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdDel.Location = New System.Drawing.Point(158, 11)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(33, 34)
        Me.cmdDel.TabIndex = 81
        Me.cmdDel.TabStop = False
        Me.cmdDel.Tag = ""
        '
        'CmdPrevious
        '
        Me.CmdPrevious.BackgroundImage = Global.Account_System.My.Resources.Resources.Right
        Me.CmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdPrevious.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdPrevious.Location = New System.Drawing.Point(82, 11)
        Me.CmdPrevious.Name = "CmdPrevious"
        Me.CmdPrevious.Size = New System.Drawing.Size(33, 34)
        Me.CmdPrevious.TabIndex = 80
        Me.CmdPrevious.TabStop = False
        '
        'cmdNext
        '
        Me.cmdNext.BackgroundImage = Global.Account_System.My.Resources.Resources.Left
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdNext.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdNext.Location = New System.Drawing.Point(44, 11)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(33, 34)
        Me.cmdNext.TabIndex = 78
        Me.cmdNext.TabStop = False
        '
        'cmdFirst
        '
        Me.cmdFirst.BackgroundImage = Global.Account_System.My.Resources.Resources.Top
        Me.cmdFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFirst.Location = New System.Drawing.Point(120, 11)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(33, 34)
        Me.cmdFirst.TabIndex = 79
        Me.cmdFirst.TabStop = False
        '
        'cmdLast
        '
        Me.cmdLast.BackgroundImage = Global.Account_System.My.Resources.Resources.Down
        Me.cmdLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdLast.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdLast.Location = New System.Drawing.Point(6, 11)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(33, 34)
        Me.cmdLast.TabIndex = 77
        Me.cmdLast.TabStop = False
        '
        'ChkBoxReSavePermission
        '
        Me.ChkBoxReSavePermission.AutoSize = True
        Me.ChkBoxReSavePermission.BackColor = System.Drawing.Color.Transparent
        Me.ChkBoxReSavePermission.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBoxReSavePermission.Location = New System.Drawing.Point(68, 153)
        Me.ChkBoxReSavePermission.Name = "ChkBoxReSavePermission"
        Me.ChkBoxReSavePermission.Size = New System.Drawing.Size(106, 17)
        Me.ChkBoxReSavePermission.TabIndex = 110
        Me.ChkBoxReSavePermission.Tag = ""
        Me.ChkBoxReSavePermission.Text = "صلاحيات جديدة "
        Me.ToolTip1.SetToolTip(Me.ChkBoxReSavePermission, "في حالة إعادة الحفظ يتم الغاء الصلاحيات المحفوظ وإدخالها من جديد")
        Me.ChkBoxReSavePermission.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(295, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "تأكيد كلمة المرور:"
        '
        'TxtBox4
        '
        Me.TxtBox4.Location = New System.Drawing.Point(188, 151)
        Me.TxtBox4.Name = "TxtBox4"
        Me.TxtBox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBox4.Size = New System.Drawing.Size(96, 20)
        Me.TxtBox4.TabIndex = 104
        Me.TxtBox4.Tag = ",null,,كلمة المرور"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(322, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "كلمة المرور:"
        '
        'TxtBox3
        '
        Me.TxtBox3.Location = New System.Drawing.Point(188, 125)
        Me.TxtBox3.Name = "TxtBox3"
        Me.TxtBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBox3.Size = New System.Drawing.Size(96, 20)
        Me.TxtBox3.TabIndex = 103
        Me.TxtBox3.Tag = "UserPassword,null,,كلمة المرور"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(301, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "أسم المستخدم:"
        '
        'TxtBox2
        '
        Me.TxtBox2.Location = New System.Drawing.Point(149, 99)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.Size = New System.Drawing.Size(135, 20)
        Me.TxtBox2.TabIndex = 102
        Me.TxtBox2.Tag = "UserName,Null,\أسم المستخدم"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(307, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "كود المستخدم:"
        '
        'TxtBox1
        '
        Me.TxtBox1.Location = New System.Drawing.Point(188, 73)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBox1.Size = New System.Drawing.Size(96, 20)
        Me.TxtBox1.TabIndex = 101
        Me.TxtBox1.Tag = "UserCode,Null,,رقم المستخدم"
        '
        'ChkAdmin
        '
        Me.ChkAdmin.AutoSize = True
        Me.ChkAdmin.BackColor = System.Drawing.Color.Transparent
        Me.ChkAdmin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAdmin.Location = New System.Drawing.Point(43, 127)
        Me.ChkAdmin.Name = "ChkAdmin"
        Me.ChkAdmin.Size = New System.Drawing.Size(131, 17)
        Me.ChkAdmin.TabIndex = 105
        Me.ChkAdmin.Tag = "UserType,,,"
        Me.ChkAdmin.Text = "صلاحيات مدير النظام"
        Me.ToolTip1.SetToolTip(Me.ChkAdmin, "يتمتع بكافة الصلاحيات")
        Me.ChkAdmin.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-4, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(136, 146)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        Me.ErrorProvider.RightToLeft = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "برنامج جينيس تكنولوجي "
        '
        'frmAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(412, 205)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddUser"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.CtlGroup.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ChkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents ChkBoxReSavePermission As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CtlGroup As System.Windows.Forms.GroupBox
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents CmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
End Class
