<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTranSearch
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.OptType2 = New System.Windows.Forms.RadioButton()
        Me.OptType1 = New System.Windows.Forms.RadioButton()
        Me.cmbPartionCode = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbMabahsCode = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtHasrNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtBoxSearchAdd = New System.Windows.Forms.TextBox()
        Me.CmbBranchCodeSearch = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtBoxSearchID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtBoxSearchName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GPUserCode = New System.Windows.Forms.GroupBox()
        Me.ChkUserID = New System.Windows.Forms.CheckBox()
        Me.cmdUserID = New System.Windows.Forms.Button()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.cmbUserID = New System.Windows.Forms.ComboBox()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPUserCode.SuspendLayout()
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
        Me.TabControl.Size = New System.Drawing.Size(490, 486)
        Me.TabControl.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.OptType2)
        Me.TabPage1.Controls.Add(Me.OptType1)
        Me.TabPage1.Controls.Add(Me.cmbPartionCode)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.cmbMabahsCode)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.TxtHasrNo)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmdSearch)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.DateTimePicker1)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.TxtBoxSearchAdd)
        Me.TabPage1.Controls.Add(Me.CmbBranchCodeSearch)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.TxtBoxSearchID)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TxtBoxSearchName)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.GPUserCode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(482, 457)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "البحث عن المحضر"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'OptType2
        '
        Me.OptType2.AutoSize = True
        Me.OptType2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptType2.ForeColor = System.Drawing.Color.Red
        Me.OptType2.Location = New System.Drawing.Point(146, 99)
        Me.OptType2.Name = "OptType2"
        Me.OptType2.Size = New System.Drawing.Size(85, 20)
        Me.OptType2.TabIndex = 175
        Me.OptType2.TabStop = True
        Me.OptType2.Tag = "SHTogarya,,,,"
        Me.OptType2.Text = "ش.تجارية"
        Me.OptType2.UseVisualStyleBackColor = True
        '
        'OptType1
        '
        Me.OptType1.AutoSize = True
        Me.OptType1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptType1.ForeColor = System.Drawing.Color.Red
        Me.OptType1.Location = New System.Drawing.Point(245, 99)
        Me.OptType1.Name = "OptType1"
        Me.OptType1.Size = New System.Drawing.Size(85, 20)
        Me.OptType1.TabIndex = 174
        Me.OptType1.TabStop = True
        Me.OptType1.Tag = "Shbakat,,,,"
        Me.OptType1.Text = "شبكــــات"
        Me.OptType1.UseVisualStyleBackColor = True
        '
        'cmbPartionCode
        '
        Me.cmbPartionCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPartionCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPartionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPartionCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPartionCode.FormattingEnabled = True
        Me.cmbPartionCode.Location = New System.Drawing.Point(126, 74)
        Me.cmbPartionCode.Name = "cmbPartionCode"
        Me.cmbPartionCode.Size = New System.Drawing.Size(219, 22)
        Me.cmbPartionCode.TabIndex = 172
        Me.cmbPartionCode.Tag = "PartionCode,Null,,أسم القطاع,1"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(351, 75)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 16)
        Me.Label19.TabIndex = 173
        Me.Label19.Text = "أسم االقطاع :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMabahsCode
        '
        Me.cmbMabahsCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMabahsCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMabahsCode.Enabled = False
        Me.cmbMabahsCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMabahsCode.FormattingEnabled = True
        Me.cmbMabahsCode.Location = New System.Drawing.Point(9, 184)
        Me.cmbMabahsCode.Name = "cmbMabahsCode"
        Me.cmbMabahsCode.Size = New System.Drawing.Size(135, 22)
        Me.cmbMabahsCode.TabIndex = 170
        Me.cmbMabahsCode.Tag = "MabahsCode,Null,,وحدة المباحث,1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(154, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "وحدة المباحث :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtHasrNo
        '
        Me.TxtHasrNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHasrNo.Location = New System.Drawing.Point(242, 184)
        Me.TxtHasrNo.Name = "TxtHasrNo"
        Me.TxtHasrNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtHasrNo.Size = New System.Drawing.Size(103, 23)
        Me.TxtHasrNo.TabIndex = 132
        Me.TxtHasrNo.Tag = ""
        Me.TxtHasrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(351, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 16)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "بحث برقم الحصـر :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Image = Global.Main_New_Project.My.Resources.Resources.Action_Search_32x32
        Me.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSearch.Location = New System.Drawing.Point(9, 45)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(107, 132)
        Me.cmdSearch.TabIndex = 131
        Me.cmdSearch.Text = "بحث (F5)"
        Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSearch.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Location = New System.Drawing.Point(3, 259)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(476, 195)
        Me.DataGridView1.TabIndex = 130
        Me.DataGridView1.Tag = "Tblt_InspectorTranGrid"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(9, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeftLayout = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(107, 21)
        Me.DateTimePicker1.TabIndex = 129
        Me.DateTimePicker1.Tag = ",,,,"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(351, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 16)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "بحث بالعنـــــــوان :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxSearchAdd
        '
        Me.TxtBoxSearchAdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxSearchAdd.Location = New System.Drawing.Point(126, 154)
        Me.TxtBoxSearchAdd.Name = "TxtBoxSearchAdd"
        Me.TxtBoxSearchAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxSearchAdd.Size = New System.Drawing.Size(219, 23)
        Me.TxtBoxSearchAdd.TabIndex = 123
        Me.TxtBoxSearchAdd.Tag = ""
        Me.TxtBoxSearchAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbBranchCodeSearch
        '
        Me.CmbBranchCodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBranchCodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBranchCodeSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBranchCodeSearch.FormattingEnabled = True
        Me.CmbBranchCodeSearch.Location = New System.Drawing.Point(126, 124)
        Me.CmbBranchCodeSearch.Name = "CmbBranchCodeSearch"
        Me.CmbBranchCodeSearch.Size = New System.Drawing.Size(219, 24)
        Me.CmbBranchCodeSearch.TabIndex = 122
        Me.CmbBranchCodeSearch.Tag = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(122, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "بحث بالتاريخ :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(351, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 16)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "بحــــــــث بالإدارة :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxSearchID
        '
        Me.TxtBoxSearchID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxSearchID.Location = New System.Drawing.Point(242, 16)
        Me.TxtBoxSearchID.Name = "TxtBoxSearchID"
        Me.TxtBoxSearchID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxSearchID.Size = New System.Drawing.Size(103, 23)
        Me.TxtBoxSearchID.TabIndex = 120
        Me.TxtBoxSearchID.Tag = ""
        Me.TxtBoxSearchID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(351, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "بحث بالأســــــــم :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBoxSearchName
        '
        Me.TxtBoxSearchName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxSearchName.Location = New System.Drawing.Point(126, 45)
        Me.TxtBoxSearchName.Name = "TxtBoxSearchName"
        Me.TxtBoxSearchName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBoxSearchName.Size = New System.Drawing.Size(219, 23)
        Me.TxtBoxSearchName.TabIndex = 121
        Me.TxtBoxSearchName.Tag = ""
        Me.TxtBoxSearchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(351, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "بحث برقم الحركة :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GPUserCode
        '
        Me.GPUserCode.Controls.Add(Me.ChkUserID)
        Me.GPUserCode.Controls.Add(Me.cmdUserID)
        Me.GPUserCode.Controls.Add(Me.lblUserID)
        Me.GPUserCode.Controls.Add(Me.cmbUserID)
        Me.GPUserCode.Location = New System.Drawing.Point(9, 206)
        Me.GPUserCode.Name = "GPUserCode"
        Me.GPUserCode.Size = New System.Drawing.Size(467, 47)
        Me.GPUserCode.TabIndex = 183
        Me.GPUserCode.TabStop = False
        '
        'ChkUserID
        '
        Me.ChkUserID.AutoSize = True
        Me.ChkUserID.BackColor = System.Drawing.Color.Transparent
        Me.ChkUserID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkUserID.Location = New System.Drawing.Point(7, 19)
        Me.ChkUserID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkUserID.Name = "ChkUserID"
        Me.ChkUserID.Size = New System.Drawing.Size(50, 17)
        Me.ChkUserID.TabIndex = 181
        Me.ChkUserID.Text = "الكل"
        Me.ChkUserID.UseVisualStyleBackColor = False
        '
        'cmdUserID
        '
        Me.cmdUserID.Location = New System.Drawing.Point(65, 15)
        Me.cmdUserID.Name = "cmdUserID"
        Me.cmdUserID.Size = New System.Drawing.Size(48, 24)
        Me.cmdUserID.TabIndex = 182
        Me.cmdUserID.Text = "..."
        Me.cmdUserID.UseVisualStyleBackColor = True
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.BackColor = System.Drawing.Color.Transparent
        Me.lblUserID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblUserID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserID.Location = New System.Drawing.Point(342, 19)
        Me.lblUserID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(112, 16)
        Me.lblUserID.TabIndex = 179
        Me.lblUserID.Text = "أسم المستخدم :"
        '
        'cmbUserID
        '
        Me.cmbUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUserID.FormattingEnabled = True
        Me.cmbUserID.Location = New System.Drawing.Point(124, 15)
        Me.cmbUserID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbUserID.Name = "cmbUserID"
        Me.cmbUserID.Size = New System.Drawing.Size(212, 24)
        Me.cmbUserID.TabIndex = 180
        '
        'frmTranSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(490, 486)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTranSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPUserCode.ResumeLayout(False)
        Me.GPUserCode.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents OptType2 As RadioButton
    Friend WithEvents OptType1 As RadioButton
    Friend WithEvents cmbPartionCode As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbMabahsCode As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtHasrNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdSearch As Button
    Friend WithEvents DataGridView1 As DataGridView
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
    Friend WithEvents cmdUserID As Button
    Friend WithEvents ChkUserID As CheckBox
    Friend WithEvents cmbUserID As ComboBox
    Friend WithEvents lblUserID As Label
    Friend WithEvents GPUserCode As GroupBox
End Class
