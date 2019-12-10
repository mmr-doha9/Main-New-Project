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
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdPlaceCode = New System.Windows.Forms.Button()
        Me.cmdActivitiesCode = New System.Windows.Forms.Button()
        Me.chkPlaceCode = New System.Windows.Forms.CheckBox()
        Me.chkActivitiesCode = New System.Windows.Forms.CheckBox()
        Me.lblPlaceCode = New System.Windows.Forms.Label()
        Me.cmbPlaceCode = New System.Windows.Forms.ComboBox()
        Me.cmbActivitiesCode = New System.Windows.Forms.ComboBox()
        Me.LblActivitiesCode = New System.Windows.Forms.Label()
        Me.txtValFrom = New System.Windows.Forms.TextBox()
        Me.txtValTo = New System.Windows.Forms.TextBox()
        Me.lblValTo = New System.Windows.Forms.Label()
        Me.lblVal = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblRepNo = New System.Windows.Forms.Label()
        Me.cmbRepNo = New System.Windows.Forms.ComboBox()
        Me.chkShowAdd = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.chkAddSearch = New System.Windows.Forms.CheckBox()
        Me.chkNameSearch = New System.Windows.Forms.CheckBox()
        Me.txtNameSearch = New System.Windows.Forms.TextBox()
        Me.lblNameSearch = New System.Windows.Forms.Label()
        Me.TxtAddSearch = New System.Windows.Forms.TextBox()
        Me.lblAddSearch = New System.Windows.Forms.Label()
        Me.GroupRepBands = New System.Windows.Forms.GroupBox()
        Me.chkThefts = New System.Windows.Forms.CheckBox()
        Me.chkTheftsDisagreed = New System.Windows.Forms.CheckBox()
        Me.chkThefts2 = New System.Windows.Forms.CheckBox()
        Me.chkThefts2Disagreed = New System.Windows.Forms.CheckBox()
        Me.chkTheftsZaina = New System.Windows.Forms.CheckBox()
        Me.chkTheftsZainaSecond = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDateType = New System.Windows.Forms.ComboBox()
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker()
        Me.cmdPartionCodeMain = New System.Windows.Forms.Button()
        Me.chkPartionCodeMain = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPartionCodeMain = New System.Windows.Forms.Label()
        Me.cmbPartionCodeMain = New System.Windows.Forms.ComboBox()
        Me.OptType3 = New System.Windows.Forms.RadioButton()
        Me.cmdAccountMenCode = New System.Windows.Forms.Button()
        Me.chkAccountMenCode = New System.Windows.Forms.CheckBox()
        Me.cmbAccountMenCode = New System.Windows.Forms.ComboBox()
        Me.lblAccountMenCode = New System.Windows.Forms.Label()
        Me.OptType2 = New System.Windows.Forms.RadioButton()
        Me.OptType1 = New System.Windows.Forms.RadioButton()
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
        Me.cmbUserID = New System.Windows.Forms.ComboBox()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupRepBands.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(932, 466)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cmdPlaceCode)
        Me.TabPage1.Controls.Add(Me.cmdActivitiesCode)
        Me.TabPage1.Controls.Add(Me.chkPlaceCode)
        Me.TabPage1.Controls.Add(Me.chkActivitiesCode)
        Me.TabPage1.Controls.Add(Me.lblPlaceCode)
        Me.TabPage1.Controls.Add(Me.cmbPlaceCode)
        Me.TabPage1.Controls.Add(Me.cmbActivitiesCode)
        Me.TabPage1.Controls.Add(Me.LblActivitiesCode)
        Me.TabPage1.Controls.Add(Me.txtValFrom)
        Me.TabPage1.Controls.Add(Me.txtValTo)
        Me.TabPage1.Controls.Add(Me.lblValTo)
        Me.TabPage1.Controls.Add(Me.lblVal)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.cmdCancel)
        Me.TabPage1.Controls.Add(Me.cmdOK)
        Me.TabPage1.Controls.Add(Me.chkAddSearch)
        Me.TabPage1.Controls.Add(Me.chkNameSearch)
        Me.TabPage1.Controls.Add(Me.txtNameSearch)
        Me.TabPage1.Controls.Add(Me.lblNameSearch)
        Me.TabPage1.Controls.Add(Me.TxtAddSearch)
        Me.TabPage1.Controls.Add(Me.lblAddSearch)
        Me.TabPage1.Controls.Add(Me.GroupRepBands)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbDateType)
        Me.TabPage1.Controls.Add(Me.DTPicker1)
        Me.TabPage1.Controls.Add(Me.DTPicker2)
        Me.TabPage1.Controls.Add(Me.cmdPartionCodeMain)
        Me.TabPage1.Controls.Add(Me.chkPartionCodeMain)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.lblPartionCodeMain)
        Me.TabPage1.Controls.Add(Me.cmbPartionCodeMain)
        Me.TabPage1.Controls.Add(Me.OptType3)
        Me.TabPage1.Controls.Add(Me.cmdAccountMenCode)
        Me.TabPage1.Controls.Add(Me.chkAccountMenCode)
        Me.TabPage1.Controls.Add(Me.cmbAccountMenCode)
        Me.TabPage1.Controls.Add(Me.lblAccountMenCode)
        Me.TabPage1.Controls.Add(Me.OptType2)
        Me.TabPage1.Controls.Add(Me.OptType1)
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
        Me.TabPage1.Controls.Add(Me.cmbUserID)
        Me.TabPage1.Controls.Add(Me.lblUserID)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(924, 437)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "بيانات محاضر السرقات"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdPlaceCode
        '
        Me.cmdPlaceCode.Location = New System.Drawing.Point(72, 150)
        Me.cmdPlaceCode.Name = "cmdPlaceCode"
        Me.cmdPlaceCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdPlaceCode.TabIndex = 358
        Me.cmdPlaceCode.Text = "..."
        Me.cmdPlaceCode.UseVisualStyleBackColor = True
        '
        'cmdActivitiesCode
        '
        Me.cmdActivitiesCode.Location = New System.Drawing.Point(72, 120)
        Me.cmdActivitiesCode.Name = "cmdActivitiesCode"
        Me.cmdActivitiesCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdActivitiesCode.TabIndex = 357
        Me.cmdActivitiesCode.Text = "..."
        Me.cmdActivitiesCode.UseVisualStyleBackColor = True
        '
        'chkPlaceCode
        '
        Me.chkPlaceCode.AutoSize = True
        Me.chkPlaceCode.BackColor = System.Drawing.Color.Transparent
        Me.chkPlaceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPlaceCode.Location = New System.Drawing.Point(9, 154)
        Me.chkPlaceCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkPlaceCode.Name = "chkPlaceCode"
        Me.chkPlaceCode.Size = New System.Drawing.Size(50, 17)
        Me.chkPlaceCode.TabIndex = 356
        Me.chkPlaceCode.Text = "الكل"
        Me.chkPlaceCode.UseVisualStyleBackColor = False
        '
        'chkActivitiesCode
        '
        Me.chkActivitiesCode.AutoSize = True
        Me.chkActivitiesCode.BackColor = System.Drawing.Color.Transparent
        Me.chkActivitiesCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivitiesCode.Location = New System.Drawing.Point(9, 124)
        Me.chkActivitiesCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkActivitiesCode.Name = "chkActivitiesCode"
        Me.chkActivitiesCode.Size = New System.Drawing.Size(50, 17)
        Me.chkActivitiesCode.TabIndex = 355
        Me.chkActivitiesCode.Text = "الكل"
        Me.chkActivitiesCode.UseVisualStyleBackColor = False
        '
        'lblPlaceCode
        '
        Me.lblPlaceCode.AutoSize = True
        Me.lblPlaceCode.BackColor = System.Drawing.Color.Transparent
        Me.lblPlaceCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPlaceCode.ForeColor = System.Drawing.Color.Black
        Me.lblPlaceCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPlaceCode.Location = New System.Drawing.Point(404, 154)
        Me.lblPlaceCode.Name = "lblPlaceCode"
        Me.lblPlaceCode.Size = New System.Drawing.Size(86, 14)
        Me.lblPlaceCode.TabIndex = 354
        Me.lblPlaceCode.Text = "وصف المكان :"
        Me.lblPlaceCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPlaceCode
        '
        Me.cmbPlaceCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPlaceCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlaceCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlaceCode.FormattingEnabled = True
        Me.cmbPlaceCode.ItemHeight = 16
        Me.cmbPlaceCode.Location = New System.Drawing.Point(138, 150)
        Me.cmbPlaceCode.Name = "cmbPlaceCode"
        Me.cmbPlaceCode.Size = New System.Drawing.Size(236, 24)
        Me.cmbPlaceCode.TabIndex = 353
        Me.cmbPlaceCode.Tag = "PlaceCode,Null,,وصف المكان,1"
        '
        'cmbActivitiesCode
        '
        Me.cmbActivitiesCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbActivitiesCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbActivitiesCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActivitiesCode.FormattingEnabled = True
        Me.cmbActivitiesCode.ItemHeight = 16
        Me.cmbActivitiesCode.Location = New System.Drawing.Point(138, 120)
        Me.cmbActivitiesCode.Name = "cmbActivitiesCode"
        Me.cmbActivitiesCode.Size = New System.Drawing.Size(236, 24)
        Me.cmbActivitiesCode.TabIndex = 351
        Me.cmbActivitiesCode.Tag = "ActivitiesCode,Null,,نوع النشاط,1"
        '
        'LblActivitiesCode
        '
        Me.LblActivitiesCode.AutoSize = True
        Me.LblActivitiesCode.BackColor = System.Drawing.Color.Transparent
        Me.LblActivitiesCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblActivitiesCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblActivitiesCode.Location = New System.Drawing.Point(411, 124)
        Me.LblActivitiesCode.Name = "LblActivitiesCode"
        Me.LblActivitiesCode.Size = New System.Drawing.Size(79, 14)
        Me.LblActivitiesCode.TabIndex = 352
        Me.LblActivitiesCode.Text = "نوع النشاط :"
        Me.LblActivitiesCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValFrom
        '
        Me.txtValFrom.Enabled = False
        Me.txtValFrom.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValFrom.Location = New System.Drawing.Point(277, 404)
        Me.txtValFrom.Name = "txtValFrom"
        Me.txtValFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValFrom.Size = New System.Drawing.Size(98, 23)
        Me.txtValFrom.TabIndex = 348
        Me.txtValFrom.Tag = "Address,null,,العنوان"
        Me.txtValFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtValFrom, "البحث بين قيمتين مع امكانية البحث بكل خانة علي حدي لكلا من خانة القيمة من وخانة ا" &
        "لقيمة الي")
        '
        'txtValTo
        '
        Me.txtValTo.Enabled = False
        Me.txtValTo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValTo.Location = New System.Drawing.Point(138, 404)
        Me.txtValTo.Name = "txtValTo"
        Me.txtValTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValTo.Size = New System.Drawing.Size(98, 23)
        Me.txtValTo.TabIndex = 350
        Me.txtValTo.Tag = "Address,null,,العنوان"
        Me.txtValTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtValTo, "البحث بين قيمتين مع امكانية البحث بكل خانة علي حدي لكلا من خانة القيمة من وخانة ا" &
        "لقيمة الي")
        '
        'lblValTo
        '
        Me.lblValTo.AutoSize = True
        Me.lblValTo.BackColor = System.Drawing.Color.Transparent
        Me.lblValTo.Enabled = False
        Me.lblValTo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblValTo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblValTo.Location = New System.Drawing.Point(237, 407)
        Me.lblValTo.Name = "lblValTo"
        Me.lblValTo.Size = New System.Drawing.Size(39, 16)
        Me.lblValTo.TabIndex = 349
        Me.lblValTo.Text = "الى :"
        Me.lblValTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVal
        '
        Me.lblVal.AutoSize = True
        Me.lblVal.BackColor = System.Drawing.Color.Transparent
        Me.lblVal.Enabled = False
        Me.lblVal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblVal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVal.Location = New System.Drawing.Point(377, 407)
        Me.lblVal.Name = "lblVal"
        Me.lblVal.Size = New System.Drawing.Size(113, 16)
        Me.lblVal.TabIndex = 347
        Me.lblVal.Text = "بحث بالقيمة من :"
        Me.lblVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblVal, "البحث بين قيمتين مع امكانية البحث بكل خانة علي حدي لكلا من خانة القيمة من وخانة ا" &
        "لقيمة الي")
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox4.Controls.Add(Me.lblRepNo)
        Me.GroupBox4.Controls.Add(Me.cmbRepNo)
        Me.GroupBox4.Controls.Add(Me.chkShowAdd)
        Me.GroupBox4.Location = New System.Drawing.Point(496, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(420, 37)
        Me.GroupBox4.TabIndex = 346
        Me.GroupBox4.TabStop = False
        '
        'lblRepNo
        '
        Me.lblRepNo.AutoSize = True
        Me.lblRepNo.BackColor = System.Drawing.Color.Transparent
        Me.lblRepNo.Enabled = False
        Me.lblRepNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRepNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRepNo.Location = New System.Drawing.Point(331, 12)
        Me.lblRepNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRepNo.Name = "lblRepNo"
        Me.lblRepNo.Size = New System.Drawing.Size(87, 16)
        Me.lblRepNo.TabIndex = 345
        Me.lblRepNo.Text = "أسم التقرير :"
        '
        'cmbRepNo
        '
        Me.cmbRepNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRepNo.Enabled = False
        Me.cmbRepNo.FormattingEnabled = True
        Me.cmbRepNo.Location = New System.Drawing.Point(111, 9)
        Me.cmbRepNo.Name = "cmbRepNo"
        Me.cmbRepNo.Size = New System.Drawing.Size(209, 24)
        Me.cmbRepNo.TabIndex = 344
        '
        'chkShowAdd
        '
        Me.chkShowAdd.AutoSize = True
        Me.chkShowAdd.BackColor = System.Drawing.Color.Transparent
        Me.chkShowAdd.Enabled = False
        Me.chkShowAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowAdd.ForeColor = System.Drawing.Color.Blue
        Me.chkShowAdd.Location = New System.Drawing.Point(9, 13)
        Me.chkShowAdd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkShowAdd.Name = "chkShowAdd"
        Me.chkShowAdd.Size = New System.Drawing.Size(94, 17)
        Me.chkShowAdd.TabIndex = 341
        Me.chkShowAdd.Text = "إظهار العنوان"
        Me.chkShowAdd.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCancel.Image = Global.Main_New_Project.My.Resources.Resources.RemovePivotField_16x16
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(496, 190)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(105, 31)
        Me.cmdCancel.TabIndex = 181
        Me.cmdCancel.Text = "إلغاء"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdOK.Image = Global.Main_New_Project.My.Resources.Resources.Action_Validation_Validate
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(607, 190)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(105, 31)
        Me.cmdOK.TabIndex = 180
        Me.cmdOK.Text = "موافق"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'chkAddSearch
        '
        Me.chkAddSearch.AutoSize = True
        Me.chkAddSearch.BackColor = System.Drawing.Color.Transparent
        Me.chkAddSearch.Enabled = False
        Me.chkAddSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddSearch.Location = New System.Drawing.Point(10, 380)
        Me.chkAddSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkAddSearch.Name = "chkAddSearch"
        Me.chkAddSearch.Size = New System.Drawing.Size(49, 17)
        Me.chkAddSearch.TabIndex = 340
        Me.chkAddSearch.Text = "بحث"
        Me.chkAddSearch.UseVisualStyleBackColor = False
        '
        'chkNameSearch
        '
        Me.chkNameSearch.AutoSize = True
        Me.chkNameSearch.BackColor = System.Drawing.Color.Transparent
        Me.chkNameSearch.Enabled = False
        Me.chkNameSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNameSearch.Location = New System.Drawing.Point(10, 353)
        Me.chkNameSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkNameSearch.Name = "chkNameSearch"
        Me.chkNameSearch.Size = New System.Drawing.Size(49, 17)
        Me.chkNameSearch.TabIndex = 339
        Me.chkNameSearch.Text = "بحث"
        Me.chkNameSearch.UseVisualStyleBackColor = False
        '
        'txtNameSearch
        '
        Me.txtNameSearch.AcceptsTab = True
        Me.txtNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtNameSearch.Enabled = False
        Me.txtNameSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameSearch.Location = New System.Drawing.Point(138, 350)
        Me.txtNameSearch.Name = "txtNameSearch"
        Me.txtNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNameSearch.Size = New System.Drawing.Size(236, 23)
        Me.txtNameSearch.TabIndex = 335
        Me.txtNameSearch.Tag = "Name,null,,اسم  السارق"
        Me.txtNameSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNameSearch
        '
        Me.lblNameSearch.AutoSize = True
        Me.lblNameSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblNameSearch.Enabled = False
        Me.lblNameSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNameSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNameSearch.Location = New System.Drawing.Point(381, 355)
        Me.lblNameSearch.Name = "lblNameSearch"
        Me.lblNameSearch.Size = New System.Drawing.Size(109, 16)
        Me.lblNameSearch.TabIndex = 337
        Me.lblNameSearch.Text = "بحث بالأســـــم :"
        Me.lblNameSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtAddSearch
        '
        Me.TxtAddSearch.Enabled = False
        Me.TxtAddSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddSearch.Location = New System.Drawing.Point(138, 377)
        Me.TxtAddSearch.Name = "TxtAddSearch"
        Me.TxtAddSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtAddSearch.Size = New System.Drawing.Size(236, 23)
        Me.TxtAddSearch.TabIndex = 336
        Me.TxtAddSearch.Tag = "Address,null,,العنوان"
        Me.TxtAddSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAddSearch
        '
        Me.lblAddSearch.AutoSize = True
        Me.lblAddSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblAddSearch.Enabled = False
        Me.lblAddSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAddSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddSearch.Location = New System.Drawing.Point(380, 381)
        Me.lblAddSearch.Name = "lblAddSearch"
        Me.lblAddSearch.Size = New System.Drawing.Size(110, 16)
        Me.lblAddSearch.TabIndex = 338
        Me.lblAddSearch.Text = "بحث العنـــــوان :"
        Me.lblAddSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupRepBands
        '
        Me.GroupRepBands.Controls.Add(Me.chkThefts)
        Me.GroupRepBands.Controls.Add(Me.chkTheftsDisagreed)
        Me.GroupRepBands.Controls.Add(Me.chkThefts2)
        Me.GroupRepBands.Controls.Add(Me.chkThefts2Disagreed)
        Me.GroupRepBands.Controls.Add(Me.chkTheftsZaina)
        Me.GroupRepBands.Controls.Add(Me.chkTheftsZainaSecond)
        Me.GroupRepBands.ForeColor = System.Drawing.Color.Red
        Me.GroupRepBands.Location = New System.Drawing.Point(496, 105)
        Me.GroupRepBands.Name = "GroupRepBands"
        Me.GroupRepBands.Size = New System.Drawing.Size(420, 77)
        Me.GroupRepBands.TabIndex = 329
        Me.GroupRepBands.TabStop = False
        Me.GroupRepBands.Text = "بنود التقريـــــر :"
        '
        'chkThefts
        '
        Me.chkThefts.AutoSize = True
        Me.chkThefts.BackColor = System.Drawing.Color.Transparent
        Me.chkThefts.Enabled = False
        Me.chkThefts.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkThefts.ForeColor = System.Drawing.Color.Red
        Me.chkThefts.Location = New System.Drawing.Point(298, 21)
        Me.chkThefts.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkThefts.Name = "chkThefts"
        Me.chkThefts.Size = New System.Drawing.Size(71, 20)
        Me.chkThefts.TabIndex = 330
        Me.chkThefts.Text = "سرقات"
        Me.chkThefts.UseVisualStyleBackColor = False
        '
        'chkTheftsDisagreed
        '
        Me.chkTheftsDisagreed.AutoSize = True
        Me.chkTheftsDisagreed.BackColor = System.Drawing.Color.Transparent
        Me.chkTheftsDisagreed.Enabled = False
        Me.chkTheftsDisagreed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkTheftsDisagreed.ForeColor = System.Drawing.Color.Red
        Me.chkTheftsDisagreed.Location = New System.Drawing.Point(149, 21)
        Me.chkTheftsDisagreed.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkTheftsDisagreed.Name = "chkTheftsDisagreed"
        Me.chkTheftsDisagreed.Size = New System.Drawing.Size(134, 20)
        Me.chkTheftsDisagreed.TabIndex = 331
        Me.chkTheftsDisagreed.Text = "مخالفات - سرقات"
        Me.chkTheftsDisagreed.UseVisualStyleBackColor = False
        '
        'chkThefts2
        '
        Me.chkThefts2.AutoSize = True
        Me.chkThefts2.BackColor = System.Drawing.Color.Transparent
        Me.chkThefts2.Enabled = False
        Me.chkThefts2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkThefts2.ForeColor = System.Drawing.Color.Blue
        Me.chkThefts2.Location = New System.Drawing.Point(291, 46)
        Me.chkThefts2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkThefts2.Name = "chkThefts2"
        Me.chkThefts2.Size = New System.Drawing.Size(78, 20)
        Me.chkThefts2.TabIndex = 332
        Me.chkThefts2.Text = "الضبطية"
        Me.chkThefts2.UseVisualStyleBackColor = False
        '
        'chkThefts2Disagreed
        '
        Me.chkThefts2Disagreed.AutoSize = True
        Me.chkThefts2Disagreed.BackColor = System.Drawing.Color.Transparent
        Me.chkThefts2Disagreed.Enabled = False
        Me.chkThefts2Disagreed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkThefts2Disagreed.ForeColor = System.Drawing.Color.Blue
        Me.chkThefts2Disagreed.Location = New System.Drawing.Point(142, 46)
        Me.chkThefts2Disagreed.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkThefts2Disagreed.Name = "chkThefts2Disagreed"
        Me.chkThefts2Disagreed.Size = New System.Drawing.Size(141, 20)
        Me.chkThefts2Disagreed.TabIndex = 333
        Me.chkThefts2Disagreed.Text = "مخالفات - الضبطية"
        Me.chkThefts2Disagreed.UseVisualStyleBackColor = False
        '
        'chkTheftsZaina
        '
        Me.chkTheftsZaina.AutoSize = True
        Me.chkTheftsZaina.BackColor = System.Drawing.Color.Transparent
        Me.chkTheftsZaina.Enabled = False
        Me.chkTheftsZaina.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkTheftsZaina.ForeColor = System.Drawing.Color.Red
        Me.chkTheftsZaina.Location = New System.Drawing.Point(18, 21)
        Me.chkTheftsZaina.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkTheftsZaina.Name = "chkTheftsZaina"
        Me.chkTheftsZaina.Size = New System.Drawing.Size(114, 20)
        Me.chkTheftsZaina.TabIndex = 342
        Me.chkTheftsZaina.Text = "الزينة- سرقات"
        Me.chkTheftsZaina.UseVisualStyleBackColor = False
        '
        'chkTheftsZainaSecond
        '
        Me.chkTheftsZainaSecond.AutoSize = True
        Me.chkTheftsZainaSecond.BackColor = System.Drawing.Color.Transparent
        Me.chkTheftsZainaSecond.Enabled = False
        Me.chkTheftsZainaSecond.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkTheftsZainaSecond.ForeColor = System.Drawing.Color.Blue
        Me.chkTheftsZainaSecond.Location = New System.Drawing.Point(7, 46)
        Me.chkTheftsZainaSecond.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkTheftsZainaSecond.Name = "chkTheftsZainaSecond"
        Me.chkTheftsZainaSecond.Size = New System.Drawing.Size(125, 20)
        Me.chkTheftsZainaSecond.TabIndex = 343
        Me.chkTheftsZainaSecond.Text = "الزينة - الضبطية"
        Me.chkTheftsZainaSecond.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(825, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 328
        Me.Label3.Text = "نوع التاريــــخ :"
        '
        'cmbDateType
        '
        Me.cmbDateType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDateType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDateType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDateType.ForeColor = System.Drawing.Color.Red
        Me.cmbDateType.FormattingEnabled = True
        Me.cmbDateType.Items.AddRange(New Object() {"تاريخ الإدخال", "تاريخ الضبط"})
        Me.cmbDateType.Location = New System.Drawing.Point(698, 80)
        Me.cmbDateType.Name = "cmbDateType"
        Me.cmbDateType.Size = New System.Drawing.Size(120, 22)
        Me.cmbDateType.TabIndex = 327
        Me.cmbDateType.Tag = "PayState,Null,,حالة السداد,2"
        '
        'DTPicker1
        '
        Me.DTPicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPicker1.Location = New System.Drawing.Point(698, 52)
        Me.DTPicker1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(118, 23)
        Me.DTPicker1.TabIndex = 147
        Me.DTPicker1.Value = New Date(2019, 2, 7, 0, 0, 0, 0)
        '
        'DTPicker2
        '
        Me.DTPicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPicker2.Location = New System.Drawing.Point(505, 52)
        Me.DTPicker2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(116, 23)
        Me.DTPicker2.TabIndex = 151
        Me.DTPicker2.Value = New Date(2019, 2, 7, 0, 0, 0, 0)
        '
        'cmdPartionCodeMain
        '
        Me.cmdPartionCodeMain.ForeColor = System.Drawing.Color.Blue
        Me.cmdPartionCodeMain.Location = New System.Drawing.Point(72, 92)
        Me.cmdPartionCodeMain.Name = "cmdPartionCodeMain"
        Me.cmdPartionCodeMain.Size = New System.Drawing.Size(48, 24)
        Me.cmdPartionCodeMain.TabIndex = 326
        Me.cmdPartionCodeMain.Text = "..."
        Me.cmdPartionCodeMain.UseVisualStyleBackColor = True
        '
        'chkPartionCodeMain
        '
        Me.chkPartionCodeMain.AutoSize = True
        Me.chkPartionCodeMain.BackColor = System.Drawing.Color.Transparent
        Me.chkPartionCodeMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPartionCodeMain.ForeColor = System.Drawing.Color.Blue
        Me.chkPartionCodeMain.Location = New System.Drawing.Point(10, 96)
        Me.chkPartionCodeMain.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkPartionCodeMain.Name = "chkPartionCodeMain"
        Me.chkPartionCodeMain.Size = New System.Drawing.Size(50, 17)
        Me.chkPartionCodeMain.TabIndex = 325
        Me.chkPartionCodeMain.Text = "الكل"
        Me.chkPartionCodeMain.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(1, 178)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(490, 7)
        Me.GroupBox1.TabIndex = 324
        Me.GroupBox1.TabStop = False
        '
        'lblPartionCodeMain
        '
        Me.lblPartionCodeMain.AutoSize = True
        Me.lblPartionCodeMain.BackColor = System.Drawing.Color.Transparent
        Me.lblPartionCodeMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartionCodeMain.ForeColor = System.Drawing.Color.Blue
        Me.lblPartionCodeMain.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPartionCodeMain.Location = New System.Drawing.Point(390, 96)
        Me.lblPartionCodeMain.Name = "lblPartionCodeMain"
        Me.lblPartionCodeMain.Size = New System.Drawing.Size(100, 14)
        Me.lblPartionCodeMain.TabIndex = 322
        Me.lblPartionCodeMain.Text = "القطاع التجاري :"
        Me.lblPartionCodeMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPartionCodeMain
        '
        Me.cmbPartionCodeMain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPartionCodeMain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPartionCodeMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPartionCodeMain.ForeColor = System.Drawing.Color.Blue
        Me.cmbPartionCodeMain.FormattingEnabled = True
        Me.cmbPartionCodeMain.Location = New System.Drawing.Point(138, 92)
        Me.cmbPartionCodeMain.Name = "cmbPartionCodeMain"
        Me.cmbPartionCodeMain.Size = New System.Drawing.Size(236, 24)
        Me.cmbPartionCodeMain.TabIndex = 323
        Me.cmbPartionCodeMain.Tag = "PartationCodeMain,Null,,أسم القطاع التجاري,1"
        '
        'OptType3
        '
        Me.OptType3.AutoSize = True
        Me.OptType3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptType3.ForeColor = System.Drawing.Color.Red
        Me.OptType3.Location = New System.Drawing.Point(142, 13)
        Me.OptType3.Name = "OptType3"
        Me.OptType3.Size = New System.Drawing.Size(53, 20)
        Me.OptType3.TabIndex = 188
        Me.OptType3.TabStop = True
        Me.OptType3.Tag = "SHTogarya,,,,"
        Me.OptType3.Text = "الكل"
        Me.OptType3.UseVisualStyleBackColor = True
        '
        'cmdAccountMenCode
        '
        Me.cmdAccountMenCode.Location = New System.Drawing.Point(72, 243)
        Me.cmdAccountMenCode.Name = "cmdAccountMenCode"
        Me.cmdAccountMenCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdAccountMenCode.TabIndex = 187
        Me.cmdAccountMenCode.Text = "..."
        Me.cmdAccountMenCode.UseVisualStyleBackColor = True
        '
        'chkAccountMenCode
        '
        Me.chkAccountMenCode.AutoSize = True
        Me.chkAccountMenCode.BackColor = System.Drawing.Color.Transparent
        Me.chkAccountMenCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAccountMenCode.Location = New System.Drawing.Point(10, 247)
        Me.chkAccountMenCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkAccountMenCode.Name = "chkAccountMenCode"
        Me.chkAccountMenCode.Size = New System.Drawing.Size(50, 17)
        Me.chkAccountMenCode.TabIndex = 186
        Me.chkAccountMenCode.Text = "الكل"
        Me.chkAccountMenCode.UseVisualStyleBackColor = False
        '
        'cmbAccountMenCode
        '
        Me.cmbAccountMenCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAccountMenCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAccountMenCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccountMenCode.FormattingEnabled = True
        Me.cmbAccountMenCode.Location = New System.Drawing.Point(138, 244)
        Me.cmbAccountMenCode.Name = "cmbAccountMenCode"
        Me.cmbAccountMenCode.Size = New System.Drawing.Size(236, 22)
        Me.cmbAccountMenCode.TabIndex = 184
        Me.cmbAccountMenCode.Tag = "PoliceMenCode,Null,,مندوب الشرطة,1"
        '
        'lblAccountMenCode
        '
        Me.lblAccountMenCode.AutoSize = True
        Me.lblAccountMenCode.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountMenCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountMenCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountMenCode.Location = New System.Drawing.Point(375, 248)
        Me.lblAccountMenCode.Name = "lblAccountMenCode"
        Me.lblAccountMenCode.Size = New System.Drawing.Size(115, 14)
        Me.lblAccountMenCode.TabIndex = 185
        Me.lblAccountMenCode.Text = "م.الضبط القضائي :"
        Me.lblAccountMenCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OptType2
        '
        Me.OptType2.AutoSize = True
        Me.OptType2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptType2.ForeColor = System.Drawing.Color.Red
        Me.OptType2.Location = New System.Drawing.Point(206, 13)
        Me.OptType2.Name = "OptType2"
        Me.OptType2.Size = New System.Drawing.Size(85, 20)
        Me.OptType2.TabIndex = 183
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
        Me.OptType1.Location = New System.Drawing.Point(301, 13)
        Me.OptType1.Name = "OptType1"
        Me.OptType1.Size = New System.Drawing.Size(69, 20)
        Me.OptType1.TabIndex = 182
        Me.OptType1.TabStop = True
        Me.OptType1.Tag = "Shbakat,,,,"
        Me.OptType1.Text = "شبكات"
        Me.OptType1.UseVisualStyleBackColor = True
        '
        'cmdUserID
        '
        Me.cmdUserID.Location = New System.Drawing.Point(72, 296)
        Me.cmdUserID.Name = "cmdUserID"
        Me.cmdUserID.Size = New System.Drawing.Size(48, 24)
        Me.cmdUserID.TabIndex = 178
        Me.cmdUserID.Text = "..."
        Me.cmdUserID.UseVisualStyleBackColor = True
        '
        'cmdMabahsCode
        '
        Me.cmdMabahsCode.Location = New System.Drawing.Point(72, 269)
        Me.cmdMabahsCode.Name = "cmdMabahsCode"
        Me.cmdMabahsCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdMabahsCode.TabIndex = 177
        Me.cmdMabahsCode.Text = "..."
        Me.cmdMabahsCode.UseVisualStyleBackColor = True
        '
        'cmdPoliceMenCode
        '
        Me.cmdPoliceMenCode.Location = New System.Drawing.Point(72, 217)
        Me.cmdPoliceMenCode.Name = "cmdPoliceMenCode"
        Me.cmdPoliceMenCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdPoliceMenCode.TabIndex = 176
        Me.cmdPoliceMenCode.Text = "..."
        Me.cmdPoliceMenCode.UseVisualStyleBackColor = True
        '
        'cmdArtisticCode
        '
        Me.cmdArtisticCode.Location = New System.Drawing.Point(72, 191)
        Me.cmdArtisticCode.Name = "cmdArtisticCode"
        Me.cmdArtisticCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdArtisticCode.TabIndex = 175
        Me.cmdArtisticCode.Text = "..."
        Me.cmdArtisticCode.UseVisualStyleBackColor = True
        '
        'cmdBranchCode
        '
        Me.cmdBranchCode.ForeColor = System.Drawing.Color.Blue
        Me.cmdBranchCode.Location = New System.Drawing.Point(72, 64)
        Me.cmdBranchCode.Name = "cmdBranchCode"
        Me.cmdBranchCode.Size = New System.Drawing.Size(48, 24)
        Me.cmdBranchCode.TabIndex = 174
        Me.cmdBranchCode.Text = "..."
        Me.cmdBranchCode.UseVisualStyleBackColor = True
        '
        'cmdPartionCodeBrowse
        '
        Me.cmdPartionCodeBrowse.ForeColor = System.Drawing.Color.Blue
        Me.cmdPartionCodeBrowse.Location = New System.Drawing.Point(72, 37)
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
        Me.ChkPayState.Location = New System.Drawing.Point(10, 327)
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
        Me.cmbPayState.Items.AddRange(New Object() {"ينتظر", "تم السداد نقداً", "تم سداد جزء"})
        Me.cmbPayState.Location = New System.Drawing.Point(138, 324)
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
        Me.lblPayState.ForeColor = System.Drawing.Color.Black
        Me.lblPayState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPayState.Location = New System.Drawing.Point(381, 327)
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
        Me.ChkUserID.Location = New System.Drawing.Point(10, 300)
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
        Me.ChkMabahsCode.Location = New System.Drawing.Point(10, 273)
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
        Me.ChkPoliceMenCode.Location = New System.Drawing.Point(10, 221)
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
        Me.ChkArtisticCode.Location = New System.Drawing.Point(10, 195)
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
        Me.ChkBranchCode.ForeColor = System.Drawing.Color.Blue
        Me.ChkBranchCode.Location = New System.Drawing.Point(10, 68)
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
        Me.chkPartionCode.ForeColor = System.Drawing.Color.Blue
        Me.chkPartionCode.Location = New System.Drawing.Point(10, 41)
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
        Me.cmbMabahsCode.Location = New System.Drawing.Point(138, 270)
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
        Me.cmbPoliceMenCode.Location = New System.Drawing.Point(138, 218)
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
        Me.cmbArtisticCode.Location = New System.Drawing.Point(138, 192)
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
        Me.cmbPartionCode.ForeColor = System.Drawing.Color.Blue
        Me.cmbPartionCode.FormattingEnabled = True
        Me.cmbPartionCode.Location = New System.Drawing.Point(138, 38)
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
        Me.CmbBranchCode.ForeColor = System.Drawing.Color.Blue
        Me.CmbBranchCode.FormattingEnabled = True
        Me.CmbBranchCode.Location = New System.Drawing.Point(138, 64)
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
        Me.lblBranchCode.ForeColor = System.Drawing.Color.Blue
        Me.lblBranchCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBranchCode.Location = New System.Drawing.Point(403, 67)
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
        Me.lblPartionCode.ForeColor = System.Drawing.Color.Blue
        Me.lblPartionCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPartionCode.Location = New System.Drawing.Point(398, 40)
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
        Me.lblMabahsCode.Location = New System.Drawing.Point(388, 273)
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
        Me.lblPoliceMenCode.Location = New System.Drawing.Point(380, 221)
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
        Me.lblArtisticCode.Location = New System.Drawing.Point(392, 195)
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
        Me.chkAll.Location = New System.Drawing.Point(10, 8)
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
        Me.Label2.Location = New System.Drawing.Point(627, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "الي تاريخ:"
        '
        'cmbUserID
        '
        Me.cmbUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUserID.FormattingEnabled = True
        Me.cmbUserID.Location = New System.Drawing.Point(138, 296)
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
        Me.lblUserID.Location = New System.Drawing.Point(378, 300)
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
        Me.Label1.Location = New System.Drawing.Point(827, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "من تاريـــــــخ:"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(381, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 16)
        Me.Label4.TabIndex = 359
        Me.Label4.Text = "تقسيمة القطاع :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmEnergyTheftsRep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(932, 466)
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
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupRepBands.ResumeLayout(False)
        Me.GroupRepBands.PerformLayout()
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
    Friend WithEvents OptType2 As RadioButton
    Friend WithEvents OptType1 As RadioButton
    Friend WithEvents cmdAccountMenCode As Button
    Friend WithEvents chkAccountMenCode As CheckBox
    Friend WithEvents cmbAccountMenCode As ComboBox
    Friend WithEvents lblAccountMenCode As Label
    Friend WithEvents OptType3 As RadioButton
    Friend WithEvents lblPartionCodeMain As Label
    Friend WithEvents cmbPartionCodeMain As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdPartionCodeMain As Button
    Friend WithEvents chkPartionCodeMain As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbDateType As ComboBox
    Friend WithEvents GroupRepBands As GroupBox
    Friend WithEvents chkThefts2Disagreed As CheckBox
    Friend WithEvents chkThefts2 As CheckBox
    Friend WithEvents chkTheftsDisagreed As CheckBox
    Friend WithEvents chkThefts As CheckBox
    Friend WithEvents txtNameSearch As TextBox
    Friend WithEvents lblNameSearch As Label
    Friend WithEvents TxtAddSearch As TextBox
    Friend WithEvents lblAddSearch As Label
    Friend WithEvents chkAddSearch As CheckBox
    Friend WithEvents chkNameSearch As CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkShowAdd As CheckBox
    Friend WithEvents chkTheftsZaina As CheckBox
    Friend WithEvents chkTheftsZainaSecond As CheckBox
    Friend WithEvents cmbRepNo As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblRepNo As Label
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblVal As Label
    Friend WithEvents txtValFrom As TextBox
    Friend WithEvents txtValTo As TextBox
    Friend WithEvents lblValTo As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmbActivitiesCode As ComboBox
    Friend WithEvents LblActivitiesCode As Label
    Friend WithEvents lblPlaceCode As Label
    Friend WithEvents cmbPlaceCode As ComboBox
    Friend WithEvents chkPlaceCode As CheckBox
    Friend WithEvents chkActivitiesCode As CheckBox
    Friend WithEvents cmdPlaceCode As Button
    Friend WithEvents cmdActivitiesCode As Button
    Friend WithEvents Label4 As Label
End Class
