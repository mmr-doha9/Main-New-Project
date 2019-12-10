<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMustChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMustChangePassword))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PicBoxOld = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicBoxNew = New System.Windows.Forms.PictureBox()
        Me.TxtBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtBox2 = New System.Windows.Forms.TextBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PicBoxOld, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(412, 188)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.PicBoxOld)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.PicBoxNew)
        Me.TabPage1.Controls.Add(Me.TxtBox3)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TxtBox2)
        Me.TabPage1.Controls.Add(Me.cmdExit)
        Me.TabPage1.Controls.Add(Me.cmdLogin)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TxtBox1)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabPage1.Size = New System.Drawing.Size(404, 159)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "تغيير إجباري لكلمة المرور"
        '
        'PicBoxOld
        '
        Me.PicBoxOld.Image = Global.Main_New_Project.My.Resources.Resources.close_32x32
        Me.PicBoxOld.Location = New System.Drawing.Point(80, 10)
        Me.PicBoxOld.Name = "PicBoxOld"
        Me.PicBoxOld.Size = New System.Drawing.Size(26, 23)
        Me.PicBoxOld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBoxOld.TabIndex = 124
        Me.PicBoxOld.TabStop = False
        Me.PicBoxOld.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.ForeColor = System.Drawing.Color.LightGray
        Me.GroupBox1.Location = New System.Drawing.Point(83, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 11)
        Me.GroupBox1.TabIndex = 123
        Me.GroupBox1.TabStop = False
        '
        'PicBoxNew
        '
        Me.PicBoxNew.Image = Global.Main_New_Project.My.Resources.Resources.close_32x32
        Me.PicBoxNew.Location = New System.Drawing.Point(80, 81)
        Me.PicBoxNew.Name = "PicBoxNew"
        Me.PicBoxNew.Size = New System.Drawing.Size(26, 23)
        Me.PicBoxNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBoxNew.TabIndex = 122
        Me.PicBoxNew.TabStop = False
        Me.PicBoxNew.Visible = False
        '
        'TxtBox3
        '
        Me.TxtBox3.Enabled = False
        Me.TxtBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TxtBox3.Location = New System.Drawing.Point(112, 81)
        Me.TxtBox3.Name = "TxtBox3"
        Me.TxtBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBox3.Size = New System.Drawing.Size(139, 23)
        Me.TxtBox3.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(257, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 16)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "تأكيد كلمة المــــرور :"
        '
        'TxtBox2
        '
        Me.TxtBox2.Enabled = False
        Me.TxtBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TxtBox2.Location = New System.Drawing.Point(112, 50)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBox2.Size = New System.Drawing.Size(139, 23)
        Me.TxtBox2.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(99, 112)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(93, 39)
        Me.cmdExit.TabIndex = 95
        Me.cmdExit.Text = "خروج"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdLogin
        '
        Me.cmdLogin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLogin.Image = CType(resources.GetObject("cmdLogin.Image"), System.Drawing.Image)
        Me.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogin.Location = New System.Drawing.Point(198, 112)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(93, 39)
        Me.cmdLogin.TabIndex = 94
        Me.cmdLogin.Text = "تأكيد"
        Me.cmdLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(257, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "كلمة المرور القديمة :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(257, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "كلمة المرور الجديدة :"
        '
        'TxtBox1
        '
        Me.TxtBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TxtBox1.Location = New System.Drawing.Point(112, 10)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBox1.Size = New System.Drawing.Size(139, 23)
        Me.TxtBox1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(8, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 88)
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        '
        'frmMustChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(412, 188)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMustChangePassword"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PicBoxOld, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TxtBox3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtBox2 As TextBox
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdLogin As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PicBoxNew As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PicBoxOld As PictureBox
End Class
