<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCasherOrder
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCasherOrder))
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdOldRecord = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtTitleNotPayed = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtTitlePayed = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdLoadGrid = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtBox5 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtBox3 = New System.Windows.Forms.TextBox()
        Me.cmbTableName = New System.Windows.Forms.ComboBox()
        Me.TxtBox2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBox4 = New System.Windows.Forms.TextBox()
        Me.TxtBox1 = New System.Windows.Forms.TextBox()
        Me.GBPayed = New System.Windows.Forms.GroupBox()
        Me.TxtBox7 = New System.Windows.Forms.MaskedTextBox()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPayState = New System.Windows.Forms.ComboBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtBox8 = New System.Windows.Forms.TextBox()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.TxtBox6 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
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
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.RightToLeftLayout = True
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(954, 417)
        Me.TabControl.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GBPayed)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(946, 388)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "أمر سداد بالخزينه"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdOldRecord)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtTitleNotPayed)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtTitlePayed)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Green
        Me.GroupBox2.Location = New System.Drawing.Point(527, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 55)
        Me.GroupBox2.TabIndex = 211
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "إحصائيات"
        '
        'cmdOldRecord
        '
        Me.cmdOldRecord.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOldRecord.ForeColor = System.Drawing.Color.Red
        Me.cmdOldRecord.Image = CType(resources.GetObject("cmdOldRecord.Image"), System.Drawing.Image)
        Me.cmdOldRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOldRecord.Location = New System.Drawing.Point(13, 10)
        Me.cmdOldRecord.Name = "cmdOldRecord"
        Me.cmdOldRecord.Size = New System.Drawing.Size(80, 41)
        Me.cmdOldRecord.TabIndex = 214
        Me.cmdOldRecord.Text = "حــــذف" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " الأوامــر" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " القديمه"
        Me.cmdOldRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOldRecord.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(176, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 30)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "عدد غير المسدد :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTitleNotPayed
        '
        Me.TxtTitleNotPayed.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtTitleNotPayed.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TxtTitleNotPayed.ForeColor = System.Drawing.Color.Red
        Me.TxtTitleNotPayed.Location = New System.Drawing.Point(95, 17)
        Me.TxtTitleNotPayed.Multiline = True
        Me.TxtTitleNotPayed.Name = "TxtTitleNotPayed"
        Me.TxtTitleNotPayed.ReadOnly = True
        Me.TxtTitleNotPayed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTitleNotPayed.Size = New System.Drawing.Size(76, 27)
        Me.TxtTitleNotPayed.TabIndex = 212
        Me.TxtTitleNotPayed.TabStop = False
        Me.TxtTitleNotPayed.Tag = ""
        Me.TxtTitleNotPayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(332, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 211
        Me.Label5.Text = "عدد المسدد :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTitlePayed
        '
        Me.TxtTitlePayed.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtTitlePayed.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitlePayed.ForeColor = System.Drawing.Color.Red
        Me.TxtTitlePayed.Location = New System.Drawing.Point(236, 17)
        Me.TxtTitlePayed.Multiline = True
        Me.TxtTitlePayed.Name = "TxtTitlePayed"
        Me.TxtTitlePayed.ReadOnly = True
        Me.TxtTitlePayed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTitlePayed.Size = New System.Drawing.Size(83, 27)
        Me.TxtTitlePayed.TabIndex = 210
        Me.TxtTitlePayed.TabStop = False
        Me.TxtTitlePayed.Tag = ""
        Me.TxtTitlePayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdLoadGrid)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmdSearch)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.TxtBox5)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.TxtBox3)
        Me.GroupBox1.Controls.Add(Me.cmbTableName)
        Me.GroupBox1.Controls.Add(Me.TxtBox2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtBox4)
        Me.GroupBox1.Controls.Add(Me.TxtBox1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(527, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 179)
        Me.GroupBox1.TabIndex = 200
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات المحضر"
        '
        'cmdLoadGrid
        '
        Me.cmdLoadGrid.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoadGrid.ForeColor = System.Drawing.Color.Blue
        Me.cmdLoadGrid.Image = CType(resources.GetObject("cmdLoadGrid.Image"), System.Drawing.Image)
        Me.cmdLoadGrid.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdLoadGrid.Location = New System.Drawing.Point(13, 22)
        Me.cmdLoadGrid.Name = "cmdLoadGrid"
        Me.cmdLoadGrid.Size = New System.Drawing.Size(67, 53)
        Me.cmdLoadGrid.TabIndex = 200
        Me.cmdLoadGrid.Text = "تحميل"
        Me.cmdLoadGrid.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.cmdLoadGrid.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(331, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 189
        Me.Label11.Text = "رقم المحضر :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Image = Global.Main_New_Project.My.Resources.Resources.Action_Search_32x32
        Me.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSearch.Location = New System.Drawing.Point(82, 23)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(67, 53)
        Me.cmdSearch.TabIndex = 1
        Me.cmdSearch.Text = "بحث"
        Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(138, 136)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 29)
        Me.Label21.TabIndex = 199
        Me.Label21.Text = "القيمة المتبقية :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBox5
        '
        Me.TxtBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBox5.Enabled = False
        Me.TxtBox5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox5.ForeColor = System.Drawing.Color.Black
        Me.TxtBox5.Location = New System.Drawing.Point(13, 139)
        Me.TxtBox5.Name = "TxtBox5"
        Me.TxtBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox5.Size = New System.Drawing.Size(117, 23)
        Me.TxtBox5.TabIndex = 6
        Me.TxtBox5.Tag = ""
        Me.TxtBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(336, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 195
        Me.Label13.Text = "العنـــــــوان :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(325, 28)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 13)
        Me.Label22.TabIndex = 185
        Me.Label22.Text = "شاشة البحث :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBox3
        '
        Me.TxtBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox3.ForeColor = System.Drawing.Color.Black
        Me.TxtBox3.Location = New System.Drawing.Point(13, 110)
        Me.TxtBox3.Name = "TxtBox3"
        Me.TxtBox3.ReadOnly = True
        Me.TxtBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox3.Size = New System.Drawing.Size(307, 23)
        Me.TxtBox3.TabIndex = 4
        Me.TxtBox3.TabStop = False
        Me.TxtBox3.Tag = ""
        Me.TxtBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTableName
        '
        Me.cmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTableName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTableName.ForeColor = System.Drawing.Color.Black
        Me.cmbTableName.FormattingEnabled = True
        Me.cmbTableName.Location = New System.Drawing.Point(151, 23)
        Me.cmbTableName.Name = "cmbTableName"
        Me.cmbTableName.Size = New System.Drawing.Size(169, 24)
        Me.cmbTableName.TabIndex = 0
        '
        'TxtBox2
        '
        Me.TxtBox2.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.TxtBox2.ForeColor = System.Drawing.Color.Black
        Me.TxtBox2.Location = New System.Drawing.Point(13, 82)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ReadOnly = True
        Me.TxtBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox2.Size = New System.Drawing.Size(307, 22)
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
        Me.Label10.Location = New System.Drawing.Point(338, 86)
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
        Me.Label2.Location = New System.Drawing.Point(325, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 29)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "القيمة الإساسيـــــة :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBox4
        '
        Me.TxtBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBox4.Enabled = False
        Me.TxtBox4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox4.ForeColor = System.Drawing.Color.Black
        Me.TxtBox4.Location = New System.Drawing.Point(202, 139)
        Me.TxtBox4.Name = "TxtBox4"
        Me.TxtBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox4.Size = New System.Drawing.Size(118, 23)
        Me.TxtBox4.TabIndex = 5
        Me.TxtBox4.Tag = ""
        Me.TxtBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtBox1
        '
        Me.TxtBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox1.Location = New System.Drawing.Point(151, 53)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ReadOnly = True
        Me.TxtBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox1.Size = New System.Drawing.Size(169, 23)
        Me.TxtBox1.TabIndex = 2
        Me.TxtBox1.TabStop = False
        Me.TxtBox1.Tag = ""
        Me.TxtBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBPayed
        '
        Me.GBPayed.Controls.Add(Me.TxtBox7)
        Me.GBPayed.Controls.Add(Me.cmdCopy)
        Me.GBPayed.Controls.Add(Me.Label3)
        Me.GBPayed.Controls.Add(Me.cmbPayState)
        Me.GBPayed.Controls.Add(Me.cmdSave)
        Me.GBPayed.Controls.Add(Me.Label4)
        Me.GBPayed.Controls.Add(Me.TxtBox8)
        Me.GBPayed.Controls.Add(Me.cmdNew)
        Me.GBPayed.Controls.Add(Me.Label1)
        Me.GBPayed.Controls.Add(Me.cmdDelete)
        Me.GBPayed.Controls.Add(Me.TxtBox6)
        Me.GBPayed.Enabled = False
        Me.GBPayed.ForeColor = System.Drawing.Color.Blue
        Me.GBPayed.Location = New System.Drawing.Point(527, 230)
        Me.GBPayed.Name = "GBPayed"
        Me.GBPayed.Size = New System.Drawing.Size(412, 150)
        Me.GBPayed.TabIndex = 209
        Me.GBPayed.TabStop = False
        Me.GBPayed.Text = "بيانات السداد"
        '
        'TxtBox7
        '
        Me.TxtBox7.Location = New System.Drawing.Point(151, 47)
        Me.TxtBox7.Mask = "##############"
        Me.TxtBox7.Name = "TxtBox7"
        Me.TxtBox7.Size = New System.Drawing.Size(170, 23)
        Me.TxtBox7.TabIndex = 8
        Me.TxtBox7.Tag = "IDPersonNO,null,,رقم البطاقه"
        '
        'cmdCopy
        '
        Me.cmdCopy.Image = CType(resources.GetObject("cmdCopy.Image"), System.Drawing.Image)
        Me.cmdCopy.Location = New System.Drawing.Point(12, 19)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(32, 23)
        Me.cmdCopy.TabIndex = 209
        Me.ToolTip1.SetToolTip(Me.cmdCopy, "نسخ أسم صاحب المحضر")
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(327, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "أسم المسدد :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPayState
        '
        Me.cmbPayState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPayState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPayState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPayState.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPayState.FormattingEnabled = True
        Me.cmbPayState.Items.AddRange(New Object() {"السداد بالكامل", "سداد جـــــــــــــزء"})
        Me.cmbPayState.Location = New System.Drawing.Point(13, 48)
        Me.cmbPayState.Name = "cmbPayState"
        Me.cmbPayState.Size = New System.Drawing.Size(130, 22)
        Me.cmbPayState.TabIndex = 9
        Me.cmbPayState.Tag = "PayState,Null,,حالة السداد,2"
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdSave.ForeColor = System.Drawing.Color.Blue
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSave.Location = New System.Drawing.Point(218, 106)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(101, 37)
        Me.cmdSave.TabIndex = 11
        Me.cmdSave.TabStop = False
        Me.cmdSave.Tag = ""
        Me.cmdSave.Text = "حفــــظ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+S"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(325, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "مبلغ السداد :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBox8
        '
        Me.TxtBox8.AcceptsTab = True
        Me.TxtBox8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBox8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox8.Location = New System.Drawing.Point(151, 77)
        Me.TxtBox8.Name = "TxtBox8"
        Me.TxtBox8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox8.Size = New System.Drawing.Size(170, 23)
        Me.TxtBox8.TabIndex = 10
        Me.TxtBox8.Tag = "Value,null,,مبلغ السداد"
        Me.TxtBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdNew
        '
        Me.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdNew.ForeColor = System.Drawing.Color.Blue
        Me.cmdNew.Image = CType(resources.GetObject("cmdNew.Image"), System.Drawing.Image)
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdNew.Location = New System.Drawing.Point(115, 106)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(101, 37)
        Me.cmdNew.TabIndex = 12
        Me.cmdNew.TabStop = False
        Me.cmdNew.Text = "جديد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+N"
        Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(325, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "رقم البطاقـــه :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdDelete
        '
        Me.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdDelete.ForeColor = System.Drawing.Color.Blue
        Me.cmdDelete.Image = Global.Main_New_Project.My.Resources.Resources.removepivotfield_32x32
        Me.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdDelete.Location = New System.Drawing.Point(13, 106)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(100, 37)
        Me.cmdDelete.TabIndex = 205
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "حذف" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtBox6
        '
        Me.TxtBox6.AcceptsTab = True
        Me.TxtBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBox6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox6.Location = New System.Drawing.Point(50, 19)
        Me.TxtBox6.Name = "TxtBox6"
        Me.TxtBox6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox6.Size = New System.Drawing.Size(270, 23)
        Me.TxtBox6.TabIndex = 7
        Me.TxtBox6.Tag = "Name,null,,اسم  السارق"
        Me.TxtBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(518, 382)
        Me.DataGridView1.TabIndex = 206
        '
        'frmCasherOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(954, 417)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCasherOrder"
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
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmbTableName As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtBox5 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtBox3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtBox1 As TextBox
    Friend WithEvents TxtBox4 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtBox2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdNew As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtBox6 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdDelete As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtBox8 As TextBox
    Friend WithEvents cmbPayState As ComboBox
    Friend WithEvents GBPayed As GroupBox
    Friend WithEvents cmdCopy As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TxtBox7 As MaskedTextBox
    Friend WithEvents cmdLoadGrid As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtTitleNotPayed As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtTitlePayed As TextBox
    Friend WithEvents cmdOldRecord As Button
End Class
