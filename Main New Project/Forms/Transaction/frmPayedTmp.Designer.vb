<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayedTmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayedTmp))
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtBox6 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmbCashType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtBox0 = New System.Windows.Forms.TextBox()
        Me.TxtBox1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtBox4 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbTableName = New System.Windows.Forms.ComboBox()
        Me.TxtBox2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBox3 = New System.Windows.Forms.TextBox()
        Me.GBPayed = New System.Windows.Forms.GroupBox()
        Me.TxtBoxID_Main = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtBoxID = New System.Windows.Forms.MaskedTextBox()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GBPayed.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Left
        Me.TabControl.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.RightToLeftLayout = True
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(462, 331)
        Me.TabControl.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GBPayed)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(454, 302)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "سداد محضر"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtBox6)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmdSave)
        Me.GroupBox2.Controls.Add(Me.cmbCashType)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(6, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(438, 87)
        Me.GroupBox2.TabIndex = 210
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "بيانات السداد"
        '
        'TxtBox6
        '
        Me.TxtBox6.AcceptsTab = True
        Me.TxtBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBox6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox6.Location = New System.Drawing.Point(172, 22)
        Me.TxtBox6.Name = "TxtBox6"
        Me.TxtBox6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox6.Size = New System.Drawing.Size(166, 23)
        Me.TxtBox6.TabIndex = 7
        Me.TxtBox6.Tag = "Name,null,,اسم  السارق"
        Me.TxtBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(347, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 28)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "رقم إيصال السداد :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdSave.ForeColor = System.Drawing.Color.Blue
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSave.Location = New System.Drawing.Point(13, 22)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(140, 53)
        Me.cmdSave.TabIndex = 11
        Me.cmdSave.TabStop = False
        Me.cmdSave.Tag = ""
        Me.cmdSave.Text = "حفظ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+S"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCashType
        '
        Me.cmbCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCashType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCashType.ForeColor = System.Drawing.Color.Black
        Me.cmbCashType.FormattingEnabled = True
        Me.cmbCashType.Items.AddRange(New Object() {"سداد نقـدي", "سداد بشيك"})
        Me.cmbCashType.Location = New System.Drawing.Point(172, 51)
        Me.cmbCashType.Name = "cmbCashType"
        Me.cmbCashType.Size = New System.Drawing.Size(166, 24)
        Me.cmbCashType.TabIndex = 204
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(343, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 205
        Me.Label4.Text = "طريقة السداد :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtBox0)
        Me.GroupBox1.Controls.Add(Me.TxtBox1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.TxtBox4)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.cmbTableName)
        Me.GroupBox1.Controls.Add(Me.TxtBox2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtBox3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(6, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 115)
        Me.GroupBox1.TabIndex = 200
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات المحضر"
        '
        'TxtBox0
        '
        Me.TxtBox0.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TxtBox0.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox0.Location = New System.Drawing.Point(6, 23)
        Me.TxtBox0.Name = "TxtBox0"
        Me.TxtBox0.ReadOnly = True
        Me.TxtBox0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox0.Size = New System.Drawing.Size(44, 23)
        Me.TxtBox0.TabIndex = 200
        Me.TxtBox0.TabStop = False
        Me.TxtBox0.Tag = ""
        Me.TxtBox0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtBox0.Visible = False
        '
        'TxtBox1
        '
        Me.TxtBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox1.Location = New System.Drawing.Point(13, 24)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ReadOnly = True
        Me.TxtBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox1.Size = New System.Drawing.Size(101, 23)
        Me.TxtBox1.TabIndex = 2
        Me.TxtBox1.TabStop = False
        Me.TxtBox1.Tag = ""
        Me.TxtBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(114, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 30)
        Me.Label11.TabIndex = 189
        Me.Label11.Text = "رقم" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " المحضر :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(145, 77)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 29)
        Me.Label21.TabIndex = 199
        Me.Label21.Text = "القيمة المتبقية :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBox4
        '
        Me.TxtBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBox4.Enabled = False
        Me.TxtBox4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox4.ForeColor = System.Drawing.Color.Black
        Me.TxtBox4.Location = New System.Drawing.Point(13, 80)
        Me.TxtBox4.Name = "TxtBox4"
        Me.TxtBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox4.Size = New System.Drawing.Size(124, 23)
        Me.TxtBox4.TabIndex = 6
        Me.TxtBox4.Tag = ""
        Me.TxtBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(342, 29)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 13)
        Me.Label22.TabIndex = 185
        Me.Label22.Text = "شاشة البحث :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTableName
        '
        Me.cmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTableName.Enabled = False
        Me.cmbTableName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTableName.ForeColor = System.Drawing.Color.Black
        Me.cmbTableName.FormattingEnabled = True
        Me.cmbTableName.Location = New System.Drawing.Point(177, 23)
        Me.cmbTableName.Name = "cmbTableName"
        Me.cmbTableName.Size = New System.Drawing.Size(161, 24)
        Me.cmbTableName.TabIndex = 0
        '
        'TxtBox2
        '
        Me.TxtBox2.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.TxtBox2.ForeColor = System.Drawing.Color.Black
        Me.TxtBox2.Location = New System.Drawing.Point(13, 53)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ReadOnly = True
        Me.TxtBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox2.Size = New System.Drawing.Size(325, 22)
        Me.TxtBox2.TabIndex = 3
        Me.TxtBox2.TabStop = False
        Me.TxtBox2.Tag = ""
        Me.TxtBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(355, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 190
        Me.Label10.Text = "الأســــــــم :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(342, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 29)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "القيمة الإساسيـــــة :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBox3
        '
        Me.TxtBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBox3.Enabled = False
        Me.TxtBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox3.ForeColor = System.Drawing.Color.Black
        Me.TxtBox3.Location = New System.Drawing.Point(209, 80)
        Me.TxtBox3.Name = "TxtBox3"
        Me.TxtBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox3.Size = New System.Drawing.Size(129, 23)
        Me.TxtBox3.TabIndex = 5
        Me.TxtBox3.Tag = ""
        Me.TxtBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBPayed
        '
        Me.GBPayed.Controls.Add(Me.TxtBoxID_Main)
        Me.GBPayed.Controls.Add(Me.Label5)
        Me.GBPayed.Controls.Add(Me.TxtBoxID)
        Me.GBPayed.Controls.Add(Me.cmdNew)
        Me.GBPayed.Controls.Add(Me.cmdSearch)
        Me.GBPayed.Controls.Add(Me.Label1)
        Me.GBPayed.ForeColor = System.Drawing.Color.Blue
        Me.GBPayed.Location = New System.Drawing.Point(6, 6)
        Me.GBPayed.Name = "GBPayed"
        Me.GBPayed.Size = New System.Drawing.Size(438, 86)
        Me.GBPayed.TabIndex = 209
        Me.GBPayed.TabStop = False
        Me.GBPayed.Text = "بيانات البحث"
        '
        'TxtBoxID_Main
        '
        Me.TxtBoxID_Main.AcceptsTab = True
        Me.TxtBoxID_Main.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBoxID_Main.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxID_Main.Location = New System.Drawing.Point(177, 53)
        Me.TxtBoxID_Main.Name = "TxtBoxID_Main"
        Me.TxtBoxID_Main.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxID_Main.Size = New System.Drawing.Size(161, 23)
        Me.TxtBoxID_Main.TabIndex = 207
        Me.TxtBoxID_Main.Tag = "Name,null,,اسم  السارق"
        Me.TxtBoxID_Main.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(354, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 206
        Me.Label5.Text = "رقم الحركة :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxID
        '
        Me.TxtBoxID.Location = New System.Drawing.Point(177, 22)
        Me.TxtBoxID.Mask = "##############"
        Me.TxtBoxID.Name = "TxtBoxID"
        Me.TxtBoxID.Size = New System.Drawing.Size(161, 23)
        Me.TxtBoxID.TabIndex = 8
        Me.TxtBoxID.Tag = "IDPersonNO,null,,رقم البطاقه"
        '
        'cmdNew
        '
        Me.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdNew.ForeColor = System.Drawing.Color.Blue
        Me.cmdNew.Image = CType(resources.GetObject("cmdNew.Image"), System.Drawing.Image)
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdNew.Location = New System.Drawing.Point(13, 22)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(78, 54)
        Me.cmdNew.TabIndex = 12
        Me.cmdNew.TabStop = False
        Me.cmdNew.Text = "جديد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+N"
        Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Image = Global.Main_New_Project.My.Resources.Resources.Action_Search_32x32
        Me.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSearch.Location = New System.Drawing.Point(93, 22)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(78, 54)
        Me.cmdSearch.TabIndex = 1
        Me.cmdSearch.Text = "بحث"
        Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(343, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "رقم البطاقـــه :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DataGridView1.Location = New System.Drawing.Point(464, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(481, 331)
        Me.DataGridView1.TabIndex = 206
        '
        'frmPayedTmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(945, 331)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPayedTmp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GBPayed.ResumeLayout(False)
        Me.GBPayed.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmdSearch As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtBox4 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmbTableName As ComboBox
    Friend WithEvents TxtBox2 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtBox3 As TextBox
    Friend WithEvents TxtBox1 As TextBox
    Friend WithEvents GBPayed As GroupBox
    Friend WithEvents TxtBoxID As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdNew As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtBox6 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmbCashType As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtBoxID_Main As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtBox0 As TextBox
End Class
