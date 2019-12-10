<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayed
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayed))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdPay = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtBoxData6 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtBoxData5 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtBoxData3 = New System.Windows.Forms.TextBox()
        Me.CmbBranchCode = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBoxData1 = New System.Windows.Forms.TextBox()
        Me.TxtBoxData4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtBoxData2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtePayed = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmdAddToGrid = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbPayState = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtBox1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuGridEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GPSearchBox = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.OptType2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OptType1 = New System.Windows.Forms.RadioButton()
        Me.TxtBoxSearchName = New System.Windows.Forms.TextBox()
        Me.cmbPartionCode = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtBoxSearchID = New System.Windows.Forms.TextBox()
        Me.cmbMabahsCode = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtHasrNo = New System.Windows.Forms.TextBox()
        Me.CmbBranchCodeSearch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtBoxSearchAdd = New System.Windows.Forms.TextBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GBTableName = New System.Windows.Forms.GroupBox()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmbTableName = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GPSearchBox.SuspendLayout()
        Me.GBTableName.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(492, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(490, 488)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdPay)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.TxtBox3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(482, 459)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "السداد"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdPay
        '
        Me.cmdPay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPay.Image = CType(resources.GetObject("cmdPay.Image"), System.Drawing.Image)
        Me.cmdPay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPay.Location = New System.Drawing.Point(8, 249)
        Me.cmdPay.Name = "cmdPay"
        Me.cmdPay.Size = New System.Drawing.Size(143, 32)
        Me.cmdPay.TabIndex = 1
        Me.cmdPay.Text = "حفظ عملية السداد"
        Me.cmdPay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPay.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.TxtBoxData6)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.TxtBoxData5)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TxtBoxData3)
        Me.GroupBox1.Controls.Add(Me.CmbBranchCode)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtBoxData1)
        Me.GroupBox1.Controls.Add(Me.TxtBoxData4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TxtBoxData2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 164)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "البيانات الأساسية"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(147, 109)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(101, 14)
        Me.Label21.TabIndex = 138
        Me.Label21.Text = "القيمة المتبقية :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxData6
        '
        Me.TxtBoxData6.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBoxData6.Enabled = False
        Me.TxtBoxData6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxData6.Location = New System.Drawing.Point(6, 105)
        Me.TxtBoxData6.Name = "TxtBoxData6"
        Me.TxtBoxData6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxData6.Size = New System.Drawing.Size(138, 23)
        Me.TxtBoxData6.TabIndex = 137
        Me.TxtBoxData6.Tag = ""
        Me.TxtBoxData6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(169, 137)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 14)
        Me.Label12.TabIndex = 136
        Me.Label12.Text = "تاريخ الضبط :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(384, 137)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 14)
        Me.Label20.TabIndex = 135
        Me.Label20.Text = "رقم حصر :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxData5
        '
        Me.TxtBoxData5.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBoxData5.Enabled = False
        Me.TxtBoxData5.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.TxtBoxData5.Location = New System.Drawing.Point(256, 133)
        Me.TxtBoxData5.Name = "TxtBoxData5"
        Me.TxtBoxData5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxData5.Size = New System.Drawing.Size(124, 22)
        Me.TxtBoxData5.TabIndex = 134
        Me.TxtBoxData5.Tag = ""
        Me.TxtBoxData5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(3, 134)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.RightToLeftLayout = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(141, 21)
        Me.DateTimePicker2.TabIndex = 133
        Me.DateTimePicker2.Tag = ",,,,"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(383, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 16)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "العنـــــــوان :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxData3
        '
        Me.TxtBoxData3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxData3.Location = New System.Drawing.Point(5, 76)
        Me.TxtBoxData3.Name = "TxtBoxData3"
        Me.TxtBoxData3.ReadOnly = True
        Me.TxtBoxData3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxData3.Size = New System.Drawing.Size(375, 23)
        Me.TxtBoxData3.TabIndex = 130
        Me.TxtBoxData3.TabStop = False
        Me.TxtBoxData3.Tag = ""
        Me.TxtBoxData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbBranchCode
        '
        Me.CmbBranchCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBranchCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBranchCode.Enabled = False
        Me.CmbBranchCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBranchCode.FormattingEnabled = True
        Me.CmbBranchCode.Location = New System.Drawing.Point(6, 19)
        Me.CmbBranchCode.Name = "CmbBranchCode"
        Me.CmbBranchCode.Size = New System.Drawing.Size(175, 24)
        Me.CmbBranchCode.TabIndex = 128
        Me.CmbBranchCode.TabStop = False
        Me.CmbBranchCode.Tag = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(187, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 16)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "أسم الإدارة :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(383, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 29)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "القيمة الإساسيـــــة :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxData1
        '
        Me.TxtBoxData1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxData1.Location = New System.Drawing.Point(277, 20)
        Me.TxtBoxData1.Name = "TxtBoxData1"
        Me.TxtBoxData1.ReadOnly = True
        Me.TxtBoxData1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxData1.Size = New System.Drawing.Size(103, 23)
        Me.TxtBoxData1.TabIndex = 122
        Me.TxtBoxData1.TabStop = False
        Me.TxtBoxData1.Tag = ""
        Me.TxtBoxData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtBoxData4
        '
        Me.TxtBoxData4.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBoxData4.Enabled = False
        Me.TxtBoxData4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxData4.Location = New System.Drawing.Point(256, 105)
        Me.TxtBoxData4.Name = "TxtBoxData4"
        Me.TxtBoxData4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxData4.Size = New System.Drawing.Size(124, 23)
        Me.TxtBoxData4.TabIndex = 121
        Me.TxtBoxData4.Tag = ""
        Me.TxtBoxData4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(384, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 16)
        Me.Label10.TabIndex = 125
        Me.Label10.Text = "الأســــــــم :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxData2
        '
        Me.TxtBoxData2.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.TxtBoxData2.Location = New System.Drawing.Point(6, 49)
        Me.TxtBoxData2.Name = "TxtBoxData2"
        Me.TxtBoxData2.ReadOnly = True
        Me.TxtBoxData2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxData2.Size = New System.Drawing.Size(374, 22)
        Me.TxtBoxData2.TabIndex = 123
        Me.TxtBoxData2.TabStop = False
        Me.TxtBoxData2.Tag = ""
        Me.TxtBoxData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(385, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 16)
        Me.Label11.TabIndex = 124
        Me.Label11.Text = "رقم الحركة :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtePayed)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cmdAddToGrid)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.cmbPayState)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TxtBox1)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TxtBox2)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(3, 169)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(476, 77)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "بيانات عملية السداد"
        '
        'dtePayed
        '
        Me.dtePayed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtePayed.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtePayed.Location = New System.Drawing.Point(62, 47)
        Me.dtePayed.Name = "dtePayed"
        Me.dtePayed.RightToLeftLayout = True
        Me.dtePayed.Size = New System.Drawing.Size(94, 21)
        Me.dtePayed.TabIndex = 3
        Me.dtePayed.Tag = ",,,,"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(156, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 159
        Me.Label16.Text = "تاريخ السداد :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAddToGrid
        '
        Me.cmdAddToGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToGrid.Image = Global.Main_New_Project.My.Resources.Resources.Action_Validation_Validate
        Me.cmdAddToGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddToGrid.Location = New System.Drawing.Point(6, 47)
        Me.cmdAddToGrid.Name = "cmdAddToGrid"
        Me.cmdAddToGrid.Size = New System.Drawing.Size(53, 23)
        Me.cmdAddToGrid.TabIndex = 4
        Me.cmdAddToGrid.Text = "تنفيذ"
        Me.cmdAddToGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddToGrid.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(385, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 13)
        Me.Label18.TabIndex = 156
        Me.Label18.Text = "حالة السداد :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPayState
        '
        Me.cmbPayState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPayState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPayState.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPayState.FormattingEnabled = True
        Me.cmbPayState.Items.AddRange(New Object() {"السداد بالكامل", "سداد جـــــــــــــزء"})
        Me.cmbPayState.Location = New System.Drawing.Point(237, 20)
        Me.cmbPayState.Name = "cmbPayState"
        Me.cmbPayState.Size = New System.Drawing.Size(143, 22)
        Me.cmbPayState.TabIndex = 0
        Me.cmbPayState.Tag = "PayState,Null,,حالة السداد,2"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(160, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 126
        Me.Label17.Text = "مبلغ السداد :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBox1
        '
        Me.TxtBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox1.Location = New System.Drawing.Point(5, 20)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox1.Size = New System.Drawing.Size(151, 23)
        Me.TxtBox1.TabIndex = 1
        Me.TxtBox1.Tag = "PayInvoiceVal,,,"
        Me.TxtBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(396, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 13)
        Me.Label15.TabIndex = 123
        Me.Label15.Text = "رقم الإيصال :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBox2
        '
        Me.TxtBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox2.Location = New System.Drawing.Point(237, 47)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox2.Size = New System.Drawing.Size(143, 23)
        Me.TxtBox2.TabIndex = 2
        Me.TxtBox2.Tag = "PayInvoiceNo,,,رقم الإيصال"
        Me.TxtBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 280)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(476, 176)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "بنود السداد"
        '
        'DataGridView2
        '
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 19)
        Me.DataGridView2.Name = "DataGridView2"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.Size = New System.Drawing.Size(470, 154)
        Me.DataGridView2.TabIndex = 22
        Me.DataGridView2.Tag = "Tblt_InspectorTranGrid"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGridEdit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'mnuGridEdit
        '
        Me.mnuGridEdit.Image = Global.Main_New_Project.My.Resources.Resources.removepivotfield_32x32
        Me.mnuGridEdit.Name = "mnuGridEdit"
        Me.mnuGridEdit.Size = New System.Drawing.Size(152, 22)
        Me.mnuGridEdit.Text = "حذف"
        '
        'TxtBox3
        '
        Me.TxtBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBox3.Enabled = False
        Me.TxtBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox3.Location = New System.Drawing.Point(240, 254)
        Me.TxtBox3.Name = "TxtBox3"
        Me.TxtBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox3.Size = New System.Drawing.Size(143, 23)
        Me.TxtBox3.TabIndex = 0
        Me.TxtBox3.Tag = "PayMotbaqyVal,,,رقم الإيصال"
        Me.TxtBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(399, 259)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "المتبقي :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Right
        Me.TabControl.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl.Location = New System.Drawing.Point(2, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.RightToLeftLayout = True
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(490, 488)
        Me.TabControl.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GPSearchBox)
        Me.TabPage2.Controls.Add(Me.GBTableName)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(482, 459)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "البحث عن المحضر"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GPSearchBox
        '
        Me.GPSearchBox.Controls.Add(Me.DateTimePicker1)
        Me.GPSearchBox.Controls.Add(Me.OptType2)
        Me.GPSearchBox.Controls.Add(Me.Label1)
        Me.GPSearchBox.Controls.Add(Me.OptType1)
        Me.GPSearchBox.Controls.Add(Me.TxtBoxSearchName)
        Me.GPSearchBox.Controls.Add(Me.cmbPartionCode)
        Me.GPSearchBox.Controls.Add(Me.Label5)
        Me.GPSearchBox.Controls.Add(Me.Label19)
        Me.GPSearchBox.Controls.Add(Me.TxtBoxSearchID)
        Me.GPSearchBox.Controls.Add(Me.cmbMabahsCode)
        Me.GPSearchBox.Controls.Add(Me.Label8)
        Me.GPSearchBox.Controls.Add(Me.Label6)
        Me.GPSearchBox.Controls.Add(Me.Label7)
        Me.GPSearchBox.Controls.Add(Me.TxtHasrNo)
        Me.GPSearchBox.Controls.Add(Me.CmbBranchCodeSearch)
        Me.GPSearchBox.Controls.Add(Me.Label3)
        Me.GPSearchBox.Controls.Add(Me.TxtBoxSearchAdd)
        Me.GPSearchBox.Controls.Add(Me.cmdSearch)
        Me.GPSearchBox.Controls.Add(Me.Label9)
        Me.GPSearchBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.GPSearchBox.Location = New System.Drawing.Point(3, 56)
        Me.GPSearchBox.Name = "GPSearchBox"
        Me.GPSearchBox.Size = New System.Drawing.Size(476, 225)
        Me.GPSearchBox.TabIndex = 176
        Me.GPSearchBox.TabStop = False
        Me.GPSearchBox.Tag = "بنود البحث"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 25)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeftLayout = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(109, 21)
        Me.DateTimePicker1.TabIndex = 129
        Me.DateTimePicker1.Tag = ",,,,"
        '
        'OptType2
        '
        Me.OptType2.AutoSize = True
        Me.OptType2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptType2.ForeColor = System.Drawing.Color.Red
        Me.OptType2.Location = New System.Drawing.Point(143, 105)
        Me.OptType2.Name = "OptType2"
        Me.OptType2.Size = New System.Drawing.Size(85, 20)
        Me.OptType2.TabIndex = 5
        Me.OptType2.TabStop = True
        Me.OptType2.Tag = "SHTogarya,,,,"
        Me.OptType2.Text = "ش.تجارية"
        Me.OptType2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(348, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "بحث برقم الحركة :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OptType1
        '
        Me.OptType1.AutoSize = True
        Me.OptType1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptType1.ForeColor = System.Drawing.Color.Red
        Me.OptType1.Location = New System.Drawing.Point(242, 104)
        Me.OptType1.Name = "OptType1"
        Me.OptType1.Size = New System.Drawing.Size(85, 20)
        Me.OptType1.TabIndex = 4
        Me.OptType1.TabStop = True
        Me.OptType1.Tag = "Shbakat,,,,"
        Me.OptType1.Text = "شبكــــات"
        Me.OptType1.UseVisualStyleBackColor = True
        '
        'TxtBoxSearchName
        '
        Me.TxtBoxSearchName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxSearchName.Location = New System.Drawing.Point(123, 51)
        Me.TxtBoxSearchName.Name = "TxtBoxSearchName"
        Me.TxtBoxSearchName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxSearchName.Size = New System.Drawing.Size(219, 23)
        Me.TxtBoxSearchName.TabIndex = 2
        Me.TxtBoxSearchName.Tag = ""
        Me.TxtBoxSearchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbPartionCode
        '
        Me.cmbPartionCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPartionCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPartionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPartionCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPartionCode.FormattingEnabled = True
        Me.cmbPartionCode.Location = New System.Drawing.Point(123, 80)
        Me.cmbPartionCode.Name = "cmbPartionCode"
        Me.cmbPartionCode.Size = New System.Drawing.Size(219, 22)
        Me.cmbPartionCode.TabIndex = 3
        Me.cmbPartionCode.Tag = "PartionCode,Null,,أسم القطاع,1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(348, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "بحث بالأســــــــم :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(348, 82)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 16)
        Me.Label19.TabIndex = 173
        Me.Label19.Text = "أسم االقطاع :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxSearchID
        '
        Me.TxtBoxSearchID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxSearchID.Location = New System.Drawing.Point(211, 22)
        Me.TxtBoxSearchID.Name = "TxtBoxSearchID"
        Me.TxtBoxSearchID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxSearchID.Size = New System.Drawing.Size(131, 23)
        Me.TxtBoxSearchID.TabIndex = 1
        Me.TxtBoxSearchID.Tag = ""
        Me.TxtBoxSearchID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbMabahsCode
        '
        Me.cmbMabahsCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMabahsCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMabahsCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMabahsCode.FormattingEnabled = True
        Me.cmbMabahsCode.Location = New System.Drawing.Point(6, 188)
        Me.cmbMabahsCode.Name = "cmbMabahsCode"
        Me.cmbMabahsCode.Size = New System.Drawing.Size(135, 22)
        Me.cmbMabahsCode.TabIndex = 9
        Me.cmbMabahsCode.Tag = "MabahsCode,Null,,وحدة المباحث,1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(348, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 16)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "بحــــــــث بالإدارة :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(151, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "وحدة المباحث :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(119, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "بحث بالتاريخ :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtHasrNo
        '
        Me.TxtHasrNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHasrNo.Location = New System.Drawing.Point(239, 187)
        Me.TxtHasrNo.Name = "TxtHasrNo"
        Me.TxtHasrNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtHasrNo.Size = New System.Drawing.Size(103, 23)
        Me.TxtHasrNo.TabIndex = 8
        Me.TxtHasrNo.Tag = ""
        Me.TxtHasrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbBranchCodeSearch
        '
        Me.CmbBranchCodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBranchCodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBranchCodeSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBranchCodeSearch.FormattingEnabled = True
        Me.CmbBranchCodeSearch.Location = New System.Drawing.Point(123, 128)
        Me.CmbBranchCodeSearch.Name = "CmbBranchCodeSearch"
        Me.CmbBranchCodeSearch.Size = New System.Drawing.Size(219, 24)
        Me.CmbBranchCodeSearch.TabIndex = 6
        Me.CmbBranchCodeSearch.Tag = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(348, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 16)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "بحث برقم الحصـر :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxSearchAdd
        '
        Me.TxtBoxSearchAdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxSearchAdd.Location = New System.Drawing.Point(6, 158)
        Me.TxtBoxSearchAdd.Name = "TxtBoxSearchAdd"
        Me.TxtBoxSearchAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxSearchAdd.Size = New System.Drawing.Size(336, 23)
        Me.TxtBoxSearchAdd.TabIndex = 7
        Me.TxtBoxSearchAdd.Tag = ""
        Me.TxtBoxSearchAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.ForeColor = System.Drawing.Color.Red
        Me.cmdSearch.Image = Global.Main_New_Project.My.Resources.Resources.Action_Search_32x32
        Me.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSearch.Location = New System.Drawing.Point(6, 52)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(109, 100)
        Me.cmdSearch.TabIndex = 131
        Me.cmdSearch.Text = "بحث (F5)"
        Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(348, 163)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 16)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "بحث بالعنـــــــوان :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GBTableName
        '
        Me.GBTableName.Controls.Add(Me.cmdNew)
        Me.GBTableName.Controls.Add(Me.cmbTableName)
        Me.GBTableName.Controls.Add(Me.Label22)
        Me.GBTableName.Dock = System.Windows.Forms.DockStyle.Top
        Me.GBTableName.Location = New System.Drawing.Point(3, 3)
        Me.GBTableName.Name = "GBTableName"
        Me.GBTableName.Size = New System.Drawing.Size(476, 53)
        Me.GBTableName.TabIndex = 178
        Me.GBTableName.TabStop = False
        '
        'cmdNew
        '
        Me.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdNew.ForeColor = System.Drawing.Color.Blue
        Me.cmdNew.Image = CType(resources.GetObject("cmdNew.Image"), System.Drawing.Image)
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdNew.Location = New System.Drawing.Point(6, 12)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(109, 35)
        Me.cmdNew.TabIndex = 193
        Me.cmdNew.TabStop = False
        Me.cmdNew.Text = "جديد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl+N"
        Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTableName
        '
        Me.cmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTableName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTableName.ForeColor = System.Drawing.Color.Red
        Me.cmbTableName.FormattingEnabled = True
        Me.cmbTableName.Location = New System.Drawing.Point(123, 17)
        Me.cmbTableName.Name = "cmbTableName"
        Me.cmbTableName.Size = New System.Drawing.Size(219, 24)
        Me.cmbTableName.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(348, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 16)
        Me.Label22.TabIndex = 177
        Me.Label22.Text = "شاشة البحث :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(3, 287)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(476, 169)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.Tag = "Tblt_InspectorTranGrid"
        '
        'frmPayed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 488)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPayed"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GPSearchBox.ResumeLayout(False)
        Me.GPSearchBox.PerformLayout()
        Me.GBTableName.ResumeLayout(False)
        Me.GBTableName.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtBoxSearchAdd As TextBox
    Friend WithEvents CmbBranchCodeSearch As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtBoxSearchID As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtBoxSearchName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmdSearch As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtePayed As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtBoxData3 As TextBox
    Friend WithEvents CmbBranchCode As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtBoxData1 As TextBox
    Friend WithEvents TxtBoxData4 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtBoxData2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TxtBox1 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtBox2 As TextBox
    Friend WithEvents TxtBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents TxtHasrNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMabahsCode As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbPayState As ComboBox
    Friend WithEvents cmdPay As Button
    Friend WithEvents cmbPartionCode As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents OptType2 As RadioButton
    Friend WithEvents OptType1 As RadioButton
    Friend WithEvents cmdAddToGrid As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents GPSearchBox As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtBoxData5 As TextBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtBoxData6 As TextBox
    Friend WithEvents cmbTableName As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents GBTableName As GroupBox
    Friend WithEvents cmdNew As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents mnuGridEdit As ToolStripMenuItem
End Class
