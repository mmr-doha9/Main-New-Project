<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnergyTheftsRep
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdUserID = New System.Windows.Forms.Button()
        Me.cmdMabahsCode = New System.Windows.Forms.Button()
        Me.cmdPoliceMenCode = New System.Windows.Forms.Button()
        Me.cmdArtisticCode = New System.Windows.Forms.Button()
        Me.cmdBranchCode = New System.Windows.Forms.Button()
        Me.cmdPartionCodeBrowse = New System.Windows.Forms.Button()
        Me.ChkPayState = New System.Windows.Forms.CheckBox()
        Me.cmbPayState = New System.Windows.Forms.ComboBox()
        Me.lblPayState = New System.Windows.Forms.Label()
        Me.ChkUserID = New System.Windows.Forms.CheckBox()
        Me.ChkMabahsCode = New System.Windows.Forms.CheckBox()
        Me.ChkPoliceMenCode = New System.Windows.Forms.CheckBox()
        Me.ChkArtisticCode = New System.Windows.Forms.CheckBox()
        Me.ChkBranchCode = New System.Windows.Forms.CheckBox()
        Me.chkPartionCode = New System.Windows.Forms.CheckBox()
        Me.cmbMabahsCode = New System.Windows.Forms.ComboBox()
        Me.cmbPoliceMenCode = New System.Windows.Forms.ComboBox()
        Me.cmbArtisticCode = New System.Windows.Forms.ComboBox()
        Me.cmbPartionCode = New System.Windows.Forms.ComboBox()
        Me.CmbBranchCode = New System.Windows.Forms.ComboBox()
        Me.lblBranchCode = New System.Windows.Forms.Label()
        Me.lblPartionCode = New System.Windows.Forms.Label()
        Me.lblMabahsCode = New System.Windows.Forms.Label()
        Me.lblPoliceMenCode = New System.Windows.Forms.Label()
        Me.lblArtisticCode = New System.Windows.Forms.Label()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker()
        Me.cmbUserID = New System.Windows.Forms.ComboBox()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(509, 366)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdCancel)
        Me.TabPage1.Controls.Add(Me.cmdOK)
        Me.TabPage1.Controls.Add(Me.cmdUserID)
        Me.TabPage1.Controls.Add(Me.cmdMabahsCode)
        Me.TabPage1.Controls.Add(Me.cmdPoliceMenCode)
        Me.TabPage1.Controls.Add(Me.cmdArtisticCode)
        Me.TabPage1.Controls.Add(Me.cmdBranchCode)
        Me.TabPage1.Controls.Add(Me.cmdPartionCodeBrowse)
        Me.TabPage1.Controls.Add(Me.ChkPayState)
        Me.TabPage1.Controls.Add(Me.cmbPayState)
        Me.TabPage1.Controls.Add(Me.lblPayState)
        Me.TabPage1.Controls.Add(Me.ChkUserID)
        Me.TabPage1.Controls.Add(Me.ChkMabahsCode)
        Me.TabPage1.Controls.Add(Me.ChkPoliceMenCode)
        Me.TabPage1.Controls.Add(Me.ChkArtisticCode)
        Me.TabPage1.Controls.Add(Me.ChkBranchCode)
        Me.TabPage1.Controls.Add(Me.chkPartionCode)
        Me.TabPage1.Controls.Add(Me.cmbMabahsCode)
        Me.TabPage1.Controls.Add(Me.cmbPoliceMenCode)
        Me.TabPage1.Controls.Add(Me.cmbArtisticCode)
        Me.TabPage1.Controls.Add(Me.cmbPartionCode)
        Me.TabPage1.Controls.Add(Me.CmbBranchCode)
        Me.TabPage1.Controls.Add(Me.lblBranchCode)
        Me.TabPage1.Controls.Add(Me.lblPartionCode)
        Me.TabPage1.Controls.Add(Me.lblMabahsCode)
        Me.TabPage1.Controls.Add(Me.lblPoliceMenCode)
        Me.TabPage1.Controls.Add(Me.lblArtisticCode)
        Me.TabPage1.Controls.Add(Me.chkAll)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.DTPicker2)
        Me.TabPage1.Controls.Add(Me.cmbUserID)
        Me.TabPage1.Controls.Add(Me.lblUserID)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.DTPicker1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(501, 337)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "بيانات محاضر السرقات"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Image = Global.Main_New_Project.My.Resources.Resources.RemovePivotField_16x16
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCancel.Location = New System.Drawing.Point(138, 271)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(107, 58)
        Me.cmdCancel.TabIndex = 181
        Me.cmdCancel.Text = "إلغاء"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Image = Global.Main_New_Project.My.Resources.Resources.Action_Validation_Validate
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdOK.Location = New System.Drawing.Point(268, 271)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(106, 58)
        Me.cmdOK.TabIndex = 180
        Me.cmdOK.Text = "موافق"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdUserID
        '
        Me.cmdUserID.Location = New System.Drawing.Point(72, 205)
        Me.cmdUserID.Name = "cmdUserID"
        Me.cmdUserID.Size = New System.Drawing.Size(48, 24)
        Me.cmdUserID.TabIndex = 178
        Me.cmdUserID.Text = "..."
        Me.cmdUserID.UseVisualStyleBackColor = True
        '
        'cmdMabahsCode
        '
        Me.cmdMabahsCode.Location = New System.Drawing.Point(72, 172)
        Me.cmdMabahsCode.Name = "cmdMabahsCode"
        Me.cmdMabahsCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdMabahsCode.TabIndex = 177
        Me.cmdMabahsCode.Text = "..."
        Me.cmdMabahsCode.UseVisualStyleBackColor = True
        '
        'cmdPoliceMenCode
        '
        Me.cmdPoliceMenCode.Location = New System.Drawing.Point(72, 140)
        Me.cmdPoliceMenCode.Name = "cmdPoliceMenCode"
        Me.cmdPoliceMenCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdPoliceMenCode.TabIndex = 176
        Me.cmdPoliceMenCode.Text = "..."
        Me.cmdPoliceMenCode.UseVisualStyleBackColor = True
        '
        'cmdArtisticCode
        '
        Me.cmdArtisticCode.Location = New System.Drawing.Point(72, 108)
        Me.cmdArtisticCode.Name = "cmdArtisticCode"
        Me.cmdArtisticCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdArtisticCode.TabIndex = 175
        Me.cmdArtisticCode.Text = "..."
        Me.cmdArtisticCode.UseVisualStyleBackColor = True
        '
        'cmdBranchCode
        '
        Me.cmdBranchCode.Location = New System.Drawing.Point(72, 75)
        Me.cmdBranchCode.Name = "cmdBranchCode"
        Me.cmdBranchCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdBranchCode.TabIndex = 174
        Me.cmdBranchCode.Text = "..."
        Me.cmdBranchCode.UseVisualStyleBackColor = True
        '
        'cmdPartionCodeBrowse
        '
        Me.cmdPartionCodeBrowse.Location = New System.Drawing.Point(72, 42)
        Me.cmdPartionCodeBrowse.Name = "cmdPartionCodeBrowse"
        Me.cmdPartionCodeBrowse.Size = New System.Drawing.Size(48, 24)
        Me.cmdPartionCodeBrowse.TabIndex = 173
        Me.cmdPartionCodeBrowse.Text = "..."
        Me.cmdPartionCodeBrowse.UseVisualStyleBackColor = True
        '
        'ChkPayState
        '
        Me.ChkPayState.AutoSize = True
        Me.ChkPayState.BackColor = System.Drawing.Color.Transparent
        Me.ChkPayState.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPayState.ForeColor = System.Drawing.Color.Red
        Me.ChkPayState.Location = New System.Drawing.Point(10, 243)
        Me.ChkPayState.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkPayState.Name = "ChkPayState"
        Me.ChkPayState.Size = New System.Drawing.Size(50, 17)
        Me.ChkPayState.TabIndex = 172
        Me.ChkPayState.Text = "الكل"
        Me.ChkPayState.UseVisualStyleBackColor = False
        '
        'cmbPayState
        '
        Me.cmbPayState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPayState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPayState.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPayState.ForeColor = System.Drawing.Color.Red
        Me.cmbPayState.FormattingEnabled = True
        Me.cmbPayState.Items.AddRange(New Object() {"ينتظر", "تم السداد", "لم يتم السداد", "تم عمل تظلم", "تم التحويل للنيابة", "تم التقسيــــــــــط"})
        Me.cmbPayState.Location = New System.Drawing.Point(138, 240)
        Me.cmbPayState.Name = "cmbPayState"
        Me.cmbPayState.Size = New System.Drawing.Size(236, 22)
        Me.cmbPayState.TabIndex = 171
        Me.cmbPayState.Tag = "PayState,Null,,حالة السداد,2"
        '
        'lblPayState
        '
        Me.lblPayState.AutoSize = True
        Me.lblPayState.BackColor = System.Drawing.Color.Transparent
        Me.lblPayState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayState.ForeColor = System.Drawing.Color.Red
        Me.lblPayState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPayState.Location = New System.Drawing.Point(381, 243)
        Me.lblPayState.Name = "lblPayState"
        Me.lblPayState.Size = New System.Drawing.Size(109, 16)
        Me.lblPayState.TabIndex = 170
        Me.lblPayState.Text = "حالة الســـــداد :"
        Me.lblPayState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkUserID
        '
        Me.ChkUserID.AutoSize = True
        Me.ChkUserID.BackColor = System.Drawing.Color.Transparent
        Me.ChkUserID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkUserID.Location = New System.Drawing.Point(10, 209)
        Me.ChkUserID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkUserID.Name = "ChkUserID"
        Me.ChkUserID.Size = New System.Drawing.Size(50, 17)
        Me.ChkUserID.TabIndex = 169
        Me.ChkUserID.Text = "الكل"
        Me.ChkUserID.UseVisualStyleBackColor = False
        '
        'ChkMabahsCode
        '
        Me.ChkMabahsCode.AutoSize = True
        Me.ChkMabahsCode.BackColor = System.Drawing.Color.Transparent
        Me.ChkMabahsCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkMabahsCode.Location = New System.Drawing.Point(10, 176)
        Me.ChkMabahsCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkMabahsCode.Name = "ChkMabahsCode"
        Me.ChkMabahsCode.Size = New System.Drawing.Size(50, 17)
        Me.ChkMabahsCode.TabIndex = 168
        Me.ChkMabahsCode.Text = "الكل"
        Me.ChkMabahsCode.UseVisualStyleBackColor = False
        '
        'ChkPoliceMenCode
        '
        Me.ChkPoliceMenCode.AutoSize = True
        Me.ChkPoliceMenCode.BackColor = System.Drawing.Color.Transparent
        Me.ChkPoliceMenCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPoliceMenCode.Location = New System.Drawing.Point(10, 144)
        Me.ChkPoliceMenCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkPoliceMenCode.Name = "ChkPoliceMenCode"
        Me.ChkPoliceMenCode.Size = New System.Drawing.Size(50, 17)
        Me.ChkPoliceMenCode.TabIndex = 167
        Me.ChkPoliceMenCode.Text = "الكل"
        Me.ChkPoliceMenCode.UseVisualStyleBackColor = False
        '
        'ChkArtisticCode
        '
        Me.ChkArtisticCode.AutoSize = True
        Me.ChkArtisticCode.BackColor = System.Drawing.Color.Transparent
        Me.ChkArtisticCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkArtisticCode.Location = New System.Drawing.Point(10, 112)
        Me.ChkArtisticCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkArtisticCode.Name = "ChkArtisticCode"
        Me.ChkArtisticCode.Size = New System.Drawing.Size(50, 17)
        Me.ChkArtisticCode.TabIndex = 166
        Me.ChkArtisticCode.Text = "الكل"
        Me.ChkArtisticCode.UseVisualStyleBackColor = False
        '
        'ChkBranchCode
        '
        Me.ChkBranchCode.AutoSize = True
        Me.ChkBranchCode.BackColor = System.Drawing.Color.Transparent
        Me.ChkBranchCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBranchCode.Location = New System.Drawing.Point(10, 79)
        Me.ChkBranchCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkBranchCode.Name = "ChkBranchCode"
        Me.ChkBranchCode.Size = New System.Drawing.Size(50, 17)
        Me.ChkBranchCode.TabIndex = 165
        Me.ChkBranchCode.Text = "الكل"
        Me.ChkBranchCode.UseVisualStyleBackColor = False
        '
        'chkPartionCode
        '
        Me.chkPartionCode.AutoSize = True
        Me.chkPartionCode.BackColor = System.Drawing.Color.Transparent
        Me.chkPartionCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPartionCode.Location = New System.Drawing.Point(10, 46)
        Me.chkPartionCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkPartionCode.Name = "chkPartionCode"
        Me.chkPartionCode.Size = New System.Drawing.Size(50, 17)
        Me.chkPartionCode.TabIndex = 164
        Me.chkPartionCode.Text = "الكل"
        Me.chkPartionCode.UseVisualStyleBackColor = False
        '
        'cmbMabahsCode
        '
        Me.cmbMabahsCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMabahsCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMabahsCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMabahsCode.FormattingEnabled = True
        Me.cmbMabahsCode.Location = New System.Drawing.Point(138, 173)
        Me.cmbMabahsCode.Name = "cmbMabahsCode"
        Me.cmbMabahsCode.Size = New System.Drawing.Size(236, 22)
        Me.cmbMabahsCode.TabIndex = 158
        Me.cmbMabahsCode.Tag = "MabahsCode,Null,,وحدة المباحث,1"
        '
        'cmbPoliceMenCode
        '
        Me.cmbPoliceMenCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPoliceMenCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPoliceMenCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPoliceMenCode.FormattingEnabled = True
        Me.cmbPoliceMenCode.Location = New System.Drawing.Point(138, 141)
        Me.cmbPoliceMenCode.Name = "cmbPoliceMenCode"
        Me.cmbPoliceMenCode.Size = New System.Drawing.Size(236, 22)
        Me.cmbPoliceMenCode.TabIndex = 157
        Me.cmbPoliceMenCode.Tag = "PoliceMenCode,Null,,مندوب الشرطة,1"
        '
        'cmbArtisticCode
        '
        Me.cmbArtisticCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbArtisticCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbArtisticCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArtisticCode.FormattingEnabled = True
        Me.cmbArtisticCode.Location = New System.Drawing.Point(138, 109)
        Me.cmbArtisticCode.Name = "cmbArtisticCode"
        Me.cmbArtisticCode.Size = New System.Drawing.Size(236, 22)
        Me.cmbArtisticCode.TabIndex = 156
        Me.cmbArtisticCode.Tag = "ArtisticCode,Null,,رقم الفنى,1"
        '
        'cmbPartionCode
        '
        Me.cmbPartionCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPartionCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPartionCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPartionCode.FormattingEnabled = True
        Me.cmbPartionCode.Location = New System.Drawing.Point(138, 43)
        Me.cmbPartionCode.Name = "cmbPartionCode"
        Me.cmbPartionCode.Size = New System.Drawing.Size(236, 22)
        Me.cmbPartionCode.TabIndex = 154
        Me.cmbPartionCode.Tag = "PartionCode,Null,,أسم القطاع,1"
        '
        'CmbBranchCode
        '
        Me.CmbBranchCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBranchCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBranchCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBranchCode.FormattingEnabled = True
        Me.CmbBranchCode.Location = New System.Drawing.Point(138, 75)
        Me.CmbBranchCode.Name = "CmbBranchCode"
        Me.CmbBranchCode.Size = New System.Drawing.Size(236, 24)
        Me.CmbBranchCode.TabIndex = 155
        Me.CmbBranchCode.Tag = "BranchCode,Null,,أسم الإدارة,1"
        '
        'lblBranchCode
        '
        Me.lblBranchCode.AutoSize = True
        Me.lblBranchCode.BackColor = System.Drawing.Color.Transparent
        Me.lblBranchCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblBranchCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBranchCode.Location = New System.Drawing.Point(403, 79)
        Me.lblBranchCode.Name = "lblBranchCode"
        Me.lblBranchCode.Size = New System.Drawing.Size(87, 16)
        Me.lblBranchCode.TabIndex = 159
        Me.lblBranchCode.Text = "أسم الإدارة :"
        Me.lblBranchCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPartionCode
        '
        Me.lblPartionCode.AutoSize = True
        Me.lblPartionCode.BackColor = System.Drawing.Color.Transparent
        Me.lblPartionCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartionCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPartionCode.Location = New System.Drawing.Point(398, 46)
        Me.lblPartionCode.Name = "lblPartionCode"
        Me.lblPartionCode.Size = New System.Drawing.Size(92, 16)
        Me.lblPartionCode.TabIndex = 160
        Me.lblPartionCode.Text = "أسم االقطاع :"
        Me.lblPartionCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMabahsCode
        '
        Me.lblMabahsCode.AutoSize = True
        Me.lblMabahsCode.BackColor = System.Drawing.Color.Transparent
        Me.lblMabahsCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblMabahsCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMabahsCode.Location = New System.Drawing.Point(388, 176)
        Me.lblMabahsCode.Name = "lblMabahsCode"
        Me.lblMabahsCode.Size = New System.Drawing.Size(102, 16)
        Me.lblMabahsCode.TabIndex = 163
        Me.lblMabahsCode.Text = "وحدة المباحث :"
        Me.lblMabahsCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPoliceMenCode
        '
        Me.lblPoliceMenCode.AutoSize = True
        Me.lblPoliceMenCode.BackColor = System.Drawing.Color.Transparent
        Me.lblPoliceMenCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPoliceMenCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPoliceMenCode.Location = New System.Drawing.Point(380, 144)
        Me.lblPoliceMenCode.Name = "lblPoliceMenCode"
        Me.lblPoliceMenCode.Size = New System.Drawing.Size(110, 16)
        Me.lblPoliceMenCode.TabIndex = 162
        Me.lblPoliceMenCode.Text = "مندوب الشرطة :"
        Me.lblPoliceMenCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArtisticCode
        '
        Me.lblArtisticCode.AutoSize = True
        Me.lblArtisticCode.BackColor = System.Drawing.Color.Transparent
        Me.lblArtisticCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblArtisticCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblArtisticCode.Location = New System.Drawing.Point(392, 112)
        Me.lblArtisticCode.Name = "lblArtisticCode"
        Me.lblArtisticCode.Size = New System.Drawing.Size(98, 16)
        Me.lblArtisticCode.TabIndex = 161
        Me.lblArtisticCode.Text = "رقم الفنـــــى :"
        Me.lblArtisticCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkAll
        '
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.ForeColor = System.Drawing.Color.Red
        Me.chkAll.Location = New System.Drawing.Point(10, 6)
        Me.chkAll.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(50, 31)
        Me.chkAll.TabIndex = 153
        Me.chkAll.Text = "كل الكل"
        Me.chkAll.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(195, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "الي تاريخ:"
        '
        'DTPicker2
        '
        Me.DTPicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPicker2.Location = New System.Drawing.Point(72, 10)
        Me.DTPicker2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(117, 23)
        Me.DTPicker2.TabIndex = 151
        Me.DTPicker2.Value = New Date(2019, 2, 7, 0, 0, 0, 0)
        '
        'cmbUserID
        '
        Me.cmbUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUserID.FormattingEnabled = True
        Me.cmbUserID.Location = New System.Drawing.Point(138, 205)
        Me.cmbUserID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbUserID.Name = "cmbUserID"
        Me.cmbUserID.Size = New System.Drawing.Size(236, 24)
        Me.cmbUserID.TabIndex = 150
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.BackColor = System.Drawing.Color.Transparent
        Me.lblUserID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblUserID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserID.Location = New System.Drawing.Point(378, 209)
        Me.lblUserID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(112, 16)
        Me.lblUserID.TabIndex = 149
        Me.lblUserID.Text = "أسم المستخدم :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(398, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "من تاريـــــــخ:"
        '
        'DTPicker1
        '
        Me.DTPicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPicker1.Location = New System.Drawing.Point(268, 10)
        Me.DTPicker1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(106, 23)
        Me.DTPicker1.TabIndex = 147
        Me.DTPicker1.Value = New Date(2019, 2, 7, 0, 0, 0, 0)
        '
        'frmEnergyTheftsRep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 366)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEnergyTheftsRep"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ChkPayState As CheckBox
    Friend WithEvents cmbPayState As ComboBox
    Friend WithEvents lblPayState As Label
    Friend WithEvents ChkUserID As CheckBox
    Friend WithEvents ChkMabahsCode As CheckBox
    Friend WithEvents ChkPoliceMenCode As CheckBox
    Friend WithEvents ChkArtisticCode As CheckBox
    Friend WithEvents ChkBranchCode As CheckBox
    Friend WithEvents chkPartionCode As CheckBox
    Friend WithEvents cmbMabahsCode As ComboBox
    Friend WithEvents cmbPoliceMenCode As ComboBox
    Friend WithEvents cmbArtisticCode As ComboBox
    Friend WithEvents cmbPartionCode As ComboBox
    Friend WithEvents CmbBranchCode As ComboBox
    Friend WithEvents lblBranchCode As Label
    Friend WithEvents lblPartionCode As Label
    Friend WithEvents lblMabahsCode As Label
    Friend WithEvents lblPoliceMenCode As Label
    Friend WithEvents lblArtisticCode As Label
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DTPicker2 As DateTimePicker
    Friend WithEvents cmbUserID As ComboBox
    Friend WithEvents lblUserID As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPicker1 As DateTimePicker
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdUserID As Button
    Friend WithEvents cmdMabahsCode As Button
    Friend WithEvents cmdPoliceMenCode As Button
    Friend WithEvents cmdArtisticCode As Button
    Friend WithEvents cmdBranchCode As Button
    Friend WithEvents cmdPartionCodeBrowse As Button
End Class
