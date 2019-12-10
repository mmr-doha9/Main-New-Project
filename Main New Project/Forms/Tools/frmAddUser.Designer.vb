<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUser))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddPicMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelPicMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChkAdmin = New System.Windows.Forms.CheckBox()
        Me.TxtBox1 = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(335, 146)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdNew)
        Me.TabPage1.Controls.Add(Me.cmdSave)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.ChkAdmin)
        Me.TabPage1.Controls.Add(Me.TxtBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(327, 117)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "إضافة مستخدم "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNew.ForeColor = System.Drawing.Color.Blue
        Me.cmdNew.Image = CType(resources.GetObject("cmdNew.Image"), System.Drawing.Image)
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdNew.Location = New System.Drawing.Point(114, 69)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(98, 38)
        Me.cmdNew.TabIndex = 123
        Me.cmdNew.TabStop = False
        Me.cmdNew.Text = "جديــد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+N"
        Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdSave.ForeColor = System.Drawing.Color.Blue
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSave.Location = New System.Drawing.Point(217, 69)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(98, 38)
        Me.cmdSave.TabIndex = 122
        Me.cmdSave.TabStop = False
        Me.cmdSave.Tag = ""
        Me.cmdSave.Text = "حفــــظ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+S"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(105, 94)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 120
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "Pic,,,,"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPicMnu, Me.DelPicMnu})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(136, 48)
        '
        'AddPicMnu
        '
        Me.AddPicMnu.Image = CType(resources.GetObject("AddPicMnu.Image"), System.Drawing.Image)
        Me.AddPicMnu.Name = "AddPicMnu"
        Me.AddPicMnu.Size = New System.Drawing.Size(135, 22)
        Me.AddPicMnu.Text = "إضافة صورة"
        '
        'DelPicMnu
        '
        Me.DelPicMnu.Image = CType(resources.GetObject("DelPicMnu.Image"), System.Drawing.Image)
        Me.DelPicMnu.Name = "DelPicMnu"
        Me.DelPicMnu.Size = New System.Drawing.Size(135, 22)
        Me.DelPicMnu.Text = "حذف صورة"
        '
        'ChkAdmin
        '
        Me.ChkAdmin.AutoSize = True
        Me.ChkAdmin.BackColor = System.Drawing.Color.Transparent
        Me.ChkAdmin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAdmin.ForeColor = System.Drawing.Color.Red
        Me.ChkAdmin.Location = New System.Drawing.Point(165, 42)
        Me.ChkAdmin.Name = "ChkAdmin"
        Me.ChkAdmin.Size = New System.Drawing.Size(150, 20)
        Me.ChkAdmin.TabIndex = 114
        Me.ChkAdmin.Tag = "UserType,,,"
        Me.ChkAdmin.Text = "صلاحيات مدير النظام"
        Me.ChkAdmin.UseVisualStyleBackColor = False
        '
        'TxtBox1
        '
        Me.TxtBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox1.Location = New System.Drawing.Point(114, 13)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.Size = New System.Drawing.Size(201, 23)
        Me.TxtBox1.TabIndex = 111
        Me.TxtBox1.Tag = "UserName,Null,\أسم المستخدم"
        '
        'frmAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 146)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddUser"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "0501"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ChkAdmin As CheckBox
    Friend WithEvents TxtBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents AddPicMnu As ToolStripMenuItem
    Friend WithEvents DelPicMnu As ToolStripMenuItem
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdNew As Button
End Class
