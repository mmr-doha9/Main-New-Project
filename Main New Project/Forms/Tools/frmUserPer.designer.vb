<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserPer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserPer))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkTheftsZaina = New System.Windows.Forms.CheckBox()
        Me.chkTheftsZainaSecond = New System.Windows.Forms.CheckBox()
        Me.chkTheftsDisagreed = New System.Windows.Forms.CheckBox()
        Me.chkThefts2Disagreed = New System.Windows.Forms.CheckBox()
        Me.chkThefts = New System.Windows.Forms.CheckBox()
        Me.chkThefts2 = New System.Windows.Forms.CheckBox()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkfrmDashBoard = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbUserCode = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(472, 515)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.cmdDel)
        Me.TabPage1.Controls.Add(Me.cmdSave)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.cmbUserCode)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(464, 489)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "إضافة وتعديل الصلاحيات"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkTheftsZaina)
        Me.GroupBox2.Controls.Add(Me.chkTheftsZainaSecond)
        Me.GroupBox2.Controls.Add(Me.chkTheftsDisagreed)
        Me.GroupBox2.Controls.Add(Me.chkThefts2Disagreed)
        Me.GroupBox2.Controls.Add(Me.chkThefts)
        Me.GroupBox2.Controls.Add(Me.chkThefts2)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(127, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 66)
        Me.GroupBox2.TabIndex = 182
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "صلاحيات التقارير"
        '
        'chkTheftsZaina
        '
        Me.chkTheftsZaina.AutoSize = True
        Me.chkTheftsZaina.BackColor = System.Drawing.Color.Transparent
        Me.chkTheftsZaina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTheftsZaina.ForeColor = System.Drawing.Color.Red
        Me.chkTheftsZaina.Location = New System.Drawing.Point(18, 19)
        Me.chkTheftsZaina.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkTheftsZaina.Name = "chkTheftsZaina"
        Me.chkTheftsZaina.Size = New System.Drawing.Size(101, 17)
        Me.chkTheftsZaina.TabIndex = 350
        Me.chkTheftsZaina.Text = "الزينة- سرقات"
        Me.chkTheftsZaina.UseVisualStyleBackColor = False
        '
        'chkTheftsZainaSecond
        '
        Me.chkTheftsZainaSecond.AutoSize = True
        Me.chkTheftsZainaSecond.BackColor = System.Drawing.Color.Transparent
        Me.chkTheftsZainaSecond.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTheftsZainaSecond.ForeColor = System.Drawing.Color.Blue
        Me.chkTheftsZainaSecond.Location = New System.Drawing.Point(10, 42)
        Me.chkTheftsZainaSecond.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkTheftsZainaSecond.Name = "chkTheftsZainaSecond"
        Me.chkTheftsZainaSecond.Size = New System.Drawing.Size(109, 17)
        Me.chkTheftsZainaSecond.TabIndex = 351
        Me.chkTheftsZainaSecond.Text = "الزينة - الضبطية"
        Me.chkTheftsZainaSecond.UseVisualStyleBackColor = False
        '
        'chkTheftsDisagreed
        '
        Me.chkTheftsDisagreed.AutoSize = True
        Me.chkTheftsDisagreed.BackColor = System.Drawing.Color.Transparent
        Me.chkTheftsDisagreed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTheftsDisagreed.ForeColor = System.Drawing.Color.Red
        Me.chkTheftsDisagreed.Location = New System.Drawing.Point(125, 19)
        Me.chkTheftsDisagreed.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkTheftsDisagreed.Name = "chkTheftsDisagreed"
        Me.chkTheftsDisagreed.Size = New System.Drawing.Size(118, 17)
        Me.chkTheftsDisagreed.TabIndex = 348
        Me.chkTheftsDisagreed.Text = "مخالفات - سرقات"
        Me.chkTheftsDisagreed.UseVisualStyleBackColor = False
        '
        'chkThefts2Disagreed
        '
        Me.chkThefts2Disagreed.AutoSize = True
        Me.chkThefts2Disagreed.BackColor = System.Drawing.Color.Transparent
        Me.chkThefts2Disagreed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkThefts2Disagreed.ForeColor = System.Drawing.Color.Blue
        Me.chkThefts2Disagreed.Location = New System.Drawing.Point(120, 42)
        Me.chkThefts2Disagreed.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkThefts2Disagreed.Name = "chkThefts2Disagreed"
        Me.chkThefts2Disagreed.Size = New System.Drawing.Size(123, 17)
        Me.chkThefts2Disagreed.TabIndex = 349
        Me.chkThefts2Disagreed.Text = "مخالفات - الضبطية"
        Me.chkThefts2Disagreed.UseVisualStyleBackColor = False
        '
        'chkThefts
        '
        Me.chkThefts.AutoSize = True
        Me.chkThefts.BackColor = System.Drawing.Color.Transparent
        Me.chkThefts.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkThefts.ForeColor = System.Drawing.Color.Red
        Me.chkThefts.Location = New System.Drawing.Point(247, 19)
        Me.chkThefts.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkThefts.Name = "chkThefts"
        Me.chkThefts.Size = New System.Drawing.Size(64, 17)
        Me.chkThefts.TabIndex = 346
        Me.chkThefts.Text = "سرقات"
        Me.chkThefts.UseVisualStyleBackColor = False
        '
        'chkThefts2
        '
        Me.chkThefts2.AutoSize = True
        Me.chkThefts2.BackColor = System.Drawing.Color.Transparent
        Me.chkThefts2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkThefts2.ForeColor = System.Drawing.Color.Blue
        Me.chkThefts2.Location = New System.Drawing.Point(242, 42)
        Me.chkThefts2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkThefts2.Name = "chkThefts2"
        Me.chkThefts2.Size = New System.Drawing.Size(69, 17)
        Me.chkThefts2.TabIndex = 347
        Me.chkThefts2.Text = "الضبطية"
        Me.chkThefts2.UseVisualStyleBackColor = False
        '
        'cmdDel
        '
        Me.cmdDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdDel.ForeColor = System.Drawing.Color.Blue
        Me.cmdDel.Image = Global.Main_New_Project.My.Resources.Resources.walking_32x32
        Me.cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdDel.Location = New System.Drawing.Point(116, 46)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(113, 39)
        Me.cmdDel.TabIndex = 181
        Me.cmdDel.TabStop = False
        Me.cmdDel.Tag = ""
        Me.cmdDel.Text = "خـــروج"
        Me.cmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdSave.ForeColor = System.Drawing.Color.Blue
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSave.Location = New System.Drawing.Point(116, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(113, 39)
        Me.cmdSave.TabIndex = 180
        Me.cmdSave.TabStop = False
        Me.cmdSave.Tag = ""
        Me.cmdSave.Text = "حفــــظ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+S"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkfrmDashBoard)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(235, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 54)
        Me.GroupBox3.TabIndex = 111
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "صلاحيات عامة"
        '
        'chkfrmDashBoard
        '
        Me.chkfrmDashBoard.AutoSize = True
        Me.chkfrmDashBoard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfrmDashBoard.ForeColor = System.Drawing.Color.Black
        Me.chkfrmDashBoard.Location = New System.Drawing.Point(48, 20)
        Me.chkfrmDashBoard.Name = "chkfrmDashBoard"
        Me.chkfrmDashBoard.Size = New System.Drawing.Size(159, 20)
        Me.chkfrmDashBoard.TabIndex = 103
        Me.chkfrmDashBoard.Tag = ",,,,"
        Me.chkfrmDashBoard.Text = "شاشة متابعة الاعمال"
        Me.chkfrmDashBoard.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 79)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 99
        Me.PictureBox1.TabStop = False
        '
        'cmbUserCode
        '
        Me.cmbUserCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUserCode.FormattingEnabled = True
        Me.cmbUserCode.Location = New System.Drawing.Point(235, 6)
        Me.cmbUserCode.Name = "cmbUserCode"
        Me.cmbUserCode.Size = New System.Drawing.Size(216, 21)
        Me.cmbUserCode.TabIndex = 98
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 395)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(3, 83)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.Size = New System.Drawing.Size(452, 309)
        Me.DataGridView1.TabIndex = 95
        '
        'frmUserPer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(472, 515)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserPer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "0602"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbUserCode As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkfrmDashBoard As CheckBox
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdDel As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkTheftsZaina As CheckBox
    Friend WithEvents chkTheftsZainaSecond As CheckBox
    Friend WithEvents chkTheftsDisagreed As CheckBox
    Friend WithEvents chkThefts2Disagreed As CheckBox
    Friend WithEvents chkThefts As CheckBox
    Friend WithEvents chkThefts2 As CheckBox
End Class
