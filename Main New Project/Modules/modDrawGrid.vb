Public Module modDrawGrid

    Public Sub GiveNumber(ByVal DataGrid As DataGridView)
        For i As Integer = 0 To DataGrid.Rows.Count - 1
            If DataGrid.Rows.Count > 1 Then
                DataGrid.Rows(i).HeaderCell.Value = i.ToString
            End If
        Next
    End Sub

    Public Sub SDrawAlertGrid(ByVal strDataGrid As DataGridView)
        Dim UserId As New DataGridViewTextBoxColumn
        With UserId
            .HeaderText = "رقم المستخدم" : .Tag = "UserId" : .Visible = False
        End With
        '''''''''''
        Dim UserName As New DataGridViewTextBoxColumn
        With UserName
            .HeaderText = "أســـــــــم المستخدم" : .Width = 100
        End With
        '''''''''''
        Dim UserIdFrom As New DataGridViewTextBoxColumn
        With UserIdFrom
            .HeaderText = "رقم المرسل" : .Tag = "UserIdFrom" : .Visible = False
        End With
        '''''''''''
        Dim UserNameFrom As New DataGridViewTextBoxColumn
        With UserNameFrom
            .HeaderText = "أســـــــــم المرسل" : .Width = 100
        End With
        '''''''''''
        Dim DateTime As New DataGridViewTextBoxColumn
        With DateTime
            .HeaderText = "تاريخ الرسالة" : .Width = 130 : .Tag = "Docdate"
        End With
        '''''''''''
        Dim Notes As New DataGridViewTextBoxColumn
        With Notes
            .HeaderText = "الرسالة" : .Width = 130 : .Tag = "Notes"
        End With
        '''''''''''
        strDataGrid.Columns.Add(UserId)
        strDataGrid.Columns.Add(UserName)
        strDataGrid.Columns.Add(UserIdFrom)
        strDataGrid.Columns.Add(UserNameFrom)
        strDataGrid.Columns.Add(DateTime)
        strDataGrid.Columns.Add(Notes)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        strDataGrid.RowHeadersVisible = False
        strDataGrid.RowHeadersWidth = 30
    End Sub
    Public Sub SDrawPriceCodeGrid(ByVal strDataGrid As DataGridView)
        Dim DocNo As New DataGridViewTextBoxColumn
        With DocNo
            .HeaderText = "رقم الحركة" : .Tag = "DocNo" : .Visible = False
        End With
        '''''''''''
        Dim SHFrom As New DataGridViewTextBoxColumn
        With SHFrom
            .HeaderText = "من" : .Width = 130 : .Tag = "From" : .Visible = True
        End With
        '''''''''''
        Dim SHTo As New DataGridViewTextBoxColumn
        With SHTo
            .HeaderText = "الى" : .Width = 100 : .Tag = "To" : .Visible = True
        End With
        '''''''''''
        Dim Price As New DataGridViewTextBoxColumn
        With Price
            .HeaderText = "سعر الشريحة" : .Width = 130 : .Tag = "Price" : .Visible = True
        End With
        '''''''''''
        Dim SHNO As New DataGridViewTextBoxColumn
        With SHNO
            .HeaderText = "الترتيب" : .Width = 100 : .Tag = "SHNO" : .Visible = True : .ReadOnly = True
        End With
        '''''''''''
        strDataGrid.Columns.Add(DocNo)
        strDataGrid.Columns.Add(SHFrom)
        strDataGrid.Columns.Add(SHTo)
        strDataGrid.Columns.Add(Price)
        strDataGrid.Columns.Add(SHNO)

        strDataGrid.AllowUserToAddRows = True
        strDataGrid.AllowUserToDeleteRows = True
        strDataGrid.RowHeadersVisible = True
        strDataGrid.RowHeadersWidth = 30
    End Sub

    Public Sub SDrawenergyQuantityGrid(ByVal strDataGrid As DataGridView)
        Dim EnergyCode As New DataGridViewTextBoxColumn
        With EnergyCode '0
            .HeaderText = "رقم الحَمل" : .Width = 40 : .Tag = "EnergyDevicesCode" : .Visible = True : .DefaultCellStyle.BackColor = Color.Pink : .Name = "EnergyDevicesCode"
            .Name = "EnergyCode"
        End With
        '''''''''''
        Dim EnergyName As New DataGridViewTextBoxColumn
        With EnergyName '1
            .HeaderText = "أسم الحَمل الكهربائي" : .Width = 80 : .Name = "EnergyName"
        End With
        '''''''''''
        Dim KWHHorseWattCode As New DataGridViewTextBoxColumn
        With KWHHorseWattCode '2
            .HeaderText = "كود الوات" : .Tag = "KiloHorseWat" : .Width = "40" : .DefaultCellStyle.BackColor = Color.Pink : .Name = "KWHHorseWattCode" : .ReadOnly = False : .Visible = True
        End With
        '''''''''''
        Dim KWHHorseWattName As New DataGridViewTextBoxColumn
        With KWHHorseWattName '3
            .HeaderText = "و/ح" : .Width = "80" : .Name = "KWHHorseWattName" : .ReadOnly = True
        End With
        '''''''''''
        Dim EnergyQuntity As New DataGridViewTextBoxColumn
        With EnergyQuntity '4
            .HeaderText = "القوة" : .Tag = "Quantity" : .Width = 60 : .Name = "EnergyQuntity" : .ReadOnly = False
        End With
        '''''''''''
        Dim EnergyDevicesCount As New DataGridViewTextBoxColumn
        With EnergyDevicesCount '5
            .HeaderText = "العدد" : .Tag = "EnergyDevicesCount" : .Width = 50 : .Name = "EnergyDevicesCount" : .DefaultCellStyle.BackColor = Color.Pink
        End With
        '''''''''''
        Dim Elkodra As New DataGridViewTextBoxColumn
        With Elkodra '6
            .HeaderText = "ا.القدرة" : .Tag = "Almightiness" : .Width = 50 : .ReadOnly = True : .Visible = True ' : .Visible = False
            .Name = "Elkodra"
        End With
        '''''''''''
        Dim HoursCount As New DataGridViewTextBoxColumn
        With HoursCount '7
            .HeaderText = "الساعات" : .Tag = "Hours" : .Width = 40 : .ReadOnly = False : .Name = "HoursCount" : .ReadOnly = True
        End With
        '''''''''''
        Dim DaysCount As New DataGridViewTextBoxColumn
        With DaysCount '8
            .HeaderText = "الأيام" : .Tag = "Days" : .Width = 50 : .ReadOnly = False : .Name = "DaysCount" : .ReadOnly = True
        End With
        '''''''''''
        Dim Asthlak As New DataGridViewTextBoxColumn
        With Asthlak '9
            .HeaderText = "الاستهلاك" : .Tag = "Asthlak" : .Width = 70 : .ReadOnly = False : .Name = "Asthlak" : .Visible = False
        End With
        '''''''''''
        'Dim ValueAsthlak As New DataGridViewTextBoxColumn
        'With ValueAsthlak '9
        '    .HeaderText = "قيمة الاستهلاك" : .Tag = "ValueAsthlak" : .Width = 75 : .ReadOnly = False
        'End With
        '''''''''''
        strDataGrid.Columns.Add(EnergyCode)                 '0
        strDataGrid.Columns.Add(EnergyName)                 '1
        strDataGrid.Columns.Add(KWHHorseWattCode)           '2
        strDataGrid.Columns.Add(KWHHorseWattName)           '3
        strDataGrid.Columns.Add(EnergyQuntity)              '4
        strDataGrid.Columns.Add(EnergyDevicesCount)         '5
        strDataGrid.Columns.Add(Elkodra)                    '6
        strDataGrid.Columns.Add(HoursCount)                 '7
        strDataGrid.Columns.Add(DaysCount)                  '8
        strDataGrid.Columns.Add(Asthlak)                    '9
        'strDataGrid.Columns.Add(ValueAsthlak)

        strDataGrid.AllowUserToAddRows = True
        strDataGrid.AllowUserToDeleteRows = True
        strDataGrid.RowHeadersVisible = True
        strDataGrid.RowHeadersWidth = 30
    End Sub

    Public Sub SDrawPriceSharehaNoGrid(ByVal strDataGrid As DataGridView)
        Dim SHNO As New DataGridViewTextBoxColumn
        With SHNO
            .HeaderText = "رقم الشريحة" : .Width = 90 : .Tag = "SHNO" : .Visible = True
        End With
        '''''''''''
        Dim SHَQuntity As New DataGridViewTextBoxColumn
        With SHَQuntity
            .HeaderText = "ك.الشريحة" : .Width = 80 : .Tag = "SHَQuntity" : .Visible = True
        End With
        '''''''''''
        Dim SHPrice As New DataGridViewTextBoxColumn
        With SHPrice
            .HeaderText = "سعر الشريحة" : .Width = 90 : .Tag = "SHPrice" : .Visible = True
        End With
        '''''''''''
        Dim EffectDay As New DataGridViewTextBoxColumn
        With EffectDay
            .HeaderText = "أيام المحاسبة" : .Width = 90 : .Tag = "EffectDay" : .Visible = True
        End With
        '''''''''''
        Dim Safy As New DataGridViewTextBoxColumn
        With Safy
            .HeaderText = "الصافى" : .Width = 70 : .Tag = "Safy" : .Visible = True
        End With
        '''''''''''
        Dim Shareha As New DataGridViewTextBoxColumn
        With Shareha
            .HeaderText = "الشريحة" : .Width = 70 : .Tag = "Shareha" : .Visible = True
        End With
        '''''''''''

        strDataGrid.Columns.Add(SHNO)
        strDataGrid.Columns.Add(SHَQuntity)
        strDataGrid.Columns.Add(SHPrice)
        strDataGrid.Columns.Add(EffectDay)
        strDataGrid.Columns.Add(Safy)
        strDataGrid.Columns.Add(Shareha)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        strDataGrid.RowHeadersVisible = True
        strDataGrid.RowHeadersWidth = 30
        strDataGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point)
        strDataGrid.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point)
    End Sub

    Public Sub SDrawPersonsGrid(ByVal strDataGrid As DataGridView)
        Dim PersonName As New DataGridViewTextBoxColumn
        With PersonName
            .HeaderText = "أسم الشخص" : .Width = 160 : .Tag = "Name" : .Visible = True
        End With
        '''''''''''
        Dim PhoneNo As New DataGridViewTextBoxColumn
        With PhoneNo
            .HeaderText = "رقم الهاتف" : .Width = 100 : .Tag = "PhoneNo" : .Visible = True
        End With
        '''''''''''
        Dim IDNo As New DataGridViewTextBoxColumn
        With IDNo
            .HeaderText = "رقم البطاقة" : .Width = 100 : .Tag = "IDNO" : .Visible = True
        End With
        '''''''''''
        Dim RelationName As New DataGridViewTextBoxColumn
        With RelationName
            .HeaderText = "نوع القرابة" : .Width = 120 : .Tag = "RelationName" : .Visible = True
        End With
        '''''''''''
        strDataGrid.Columns.Add(PersonName)
        strDataGrid.Columns.Add(PhoneNo)
        strDataGrid.Columns.Add(IDNo)
        strDataGrid.Columns.Add(RelationName)

        strDataGrid.AllowUserToAddRows = True
        strDataGrid.AllowUserToDeleteRows = True
        strDataGrid.RowHeadersVisible = True
        strDataGrid.RowHeadersWidth = 30
        strDataGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point)
        strDataGrid.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point)
    End Sub

    'Public Sub SDrawMultiTranGrid(ByVal strDataGrid As DataGridView)
    '    Dim No As New DataGridViewTextBoxColumn
    '    With No
    '        .HeaderText = "  م  " : .Width = 40 : .Visible = True
    '    End With
    '    '''''''''''
    '    Dim HasrNo As New DataGridViewTextBoxColumn
    '    With HasrNo
    '        .HeaderText = "رقم الحصر" : .Width = 50 : .Visible = True
    '    End With
    '    '''''''''''
    '    Dim TranNo As New DataGridViewTextBoxColumn
    '    With TranNo
    '        .HeaderText = "رقم الحركة" : .Width = 50 : .Visible = True : .ReadOnly = True
    '    End With
    '    '''''''''''
    '    strDataGrid.Columns.Add(No)
    '    strDataGrid.Columns.Add(HasrNo)
    '    strDataGrid.Columns.Add(TranNo)

    '    strDataGrid.AllowUserToAddRows = False
    '    strDataGrid.AllowUserToDeleteRows = True
    '    strDataGrid.RowHeadersVisible = True
    '    strDataGrid.RowHeadersWidth = 30
    'End Sub

    Public Sub SDrawAlertNotesGrid(ByVal strDataGrid As DataGridView)
        Dim DocNo As New DataGridViewTextBoxColumn
        With DocNo
            .HeaderText = "رقم الحركة" : .Tag = "DocNo" : .Visible = False
        End With
        '''''''''''
        Dim DateTime As New DataGridViewTextBoxColumn
        With DateTime
            .HeaderText = "تاريخ المفكرة" : .Width = 130 : .Tag = "Docdate" : .Visible = False
        End With
        '''''''''''
        Dim NoteName As New DataGridViewTextBoxColumn
        With NoteName
            .HeaderText = "عنوان المفكرة" : .Width = 100 : .Tag = "NoteName"
        End With
        '''''''''''
        Dim NoteDate As New DataGridViewTextBoxColumn
        With NoteDate
            .HeaderText = "تاريخ التذكير" : .Width = 130 : .Tag = "NoteDate"
        End With
        '''''''''''
        Dim NoteType As New DataGridViewTextBoxColumn
        With NoteType
            .HeaderText = "نوع المفكرة" : .Width = 100 : .Tag = "NoteType" : .Visible = False
        End With
        '''''''''''
        Dim NoteTypeName As New DataGridViewTextBoxColumn
        With NoteTypeName
            .HeaderText = "نوع المفكرة" : .Width = 100
        End With
        '''''''''''
        Dim Note As New DataGridViewTextBoxColumn
        With Note
            .HeaderText = "رقم المرسل" : .Width = 100 : .Tag = "Note"
        End With
        '''''''''''
        strDataGrid.Columns.Add(DocNo)
        strDataGrid.Columns.Add(DateTime)
        strDataGrid.Columns.Add(NoteName)
        strDataGrid.Columns.Add(NoteDate)
        strDataGrid.Columns.Add(NoteType)
        strDataGrid.Columns.Add(NoteTypeName)
        strDataGrid.Columns.Add(Note)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        strDataGrid.RowHeadersVisible = False
        strDataGrid.RowHeadersWidth = 30
    End Sub

    Public Sub SDrawPayedGrid(ByVal strDataGrid As DataGridView)
        'Dim ID As New DataGridViewTextBoxColumn
        'With ID
        '    .HeaderText = "رقم الحركة" : .Visible = False ': .Tag = "ID" : .Name = "ID" 
        'End With
        ''''''''''''
        Dim PayedState As New DataGridViewTextBoxColumn
        With PayedState
            .HeaderText = "ح.السداد" : .Width = 50 : .Tag = "PayedState" : .Name = "PayedState" : .ReadOnly = True : .Visible = False
        End With
        '''''''''''
        Dim PayedStateName As New DataGridViewTextBoxColumn
        With PayedStateName
            .HeaderText = "السداد" : .Width = 90 : .Name = "PayedStateName" : .ReadOnly = True
        End With
        '''''''''''
        Dim PayedVal As New DataGridViewTextBoxColumn
        With PayedVal
            .HeaderText = "المسدد" : .Width = 70 : .Tag = "PayedVal" : .Name = "PayedVal" : .ReadOnly = True
        End With
        '''''''''''
        Dim InvoiceNo As New DataGridViewTextBoxColumn
        With InvoiceNo
            .HeaderText = "إيصال السداد" : .Width = 100 : .Tag = "InvoiceNo" : .Name = "InvoiceNo" : .ReadOnly = True
        End With
        '''''''''''
        Dim PayedDate As New DataGridViewTextBoxColumn
        With PayedDate
            .HeaderText = "تاريخ السداد" : .Width = 100 : .Tag = "PayedDate" : .Name = "PayedDate" : .ReadOnly = True
        End With
        '''''''''''
        Dim PayedType As New DataGridViewTextBoxColumn ' 0==> from this app  1==> من برنامج الخزن
        With PayedType
            .HeaderText = "نوع السداد" : .Width = 90 : .Tag = "PayedType" : .Name = "PayedType" : .ReadOnly = True : .Visible = False
        End With
        '''''''''''
        Dim PayedTypeName As New DataGridViewTextBoxColumn
        With PayedTypeName
            .HeaderText = "نوع السداد" : .Width = 100 : .Name = "PayedTypeName" : .ReadOnly = True
        End With
        '''''''''''
        'strDataGrid.Columns.Add(ID)
        strDataGrid.Columns.Add(PayedState)
        strDataGrid.Columns.Add(PayedStateName)
        strDataGrid.Columns.Add(PayedVal)
        strDataGrid.Columns.Add(InvoiceNo)
        strDataGrid.Columns.Add(PayedDate)
        strDataGrid.Columns.Add(PayedType)
        strDataGrid.Columns.Add(PayedTypeName)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        'strDataGrid.RowHeadersVisible = False
        strDataGrid.RowHeadersWidth = 30
        strDataGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        strDataGrid.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
    End Sub

    Public Sub SDrawGrievanceGrid(ByVal strDataGrid As DataGridView)
        Dim DocNoTzaloom As New DataGridViewTextBoxColumn
        With DocNoTzaloom
            .HeaderText = "الرقم" : .Width = 50 : .Tag = "DocNoTzaloom" : .Name = "DocNoTzaloom" : .ReadOnly = True : .Visible = True
        End With
        '''''
        Dim TzaloomDate As New DataGridViewTextBoxColumn
        With TzaloomDate
            .HeaderText = "تاريخ التظلم" : .Width = 75 : .Name = "TzaloomDate" : .Tag = "TzaloomDate" : .ReadOnly = True
        End With
        '''''
        Dim TzaloomNo As New DataGridViewTextBoxColumn
        With TzaloomNo
            .HeaderText = "رقم التظلم" : .Width = 75 : .Name = "TzaloomNo" : .Tag = "TzaloomNo" : .ReadOnly = True
        End With
        '''''
        Dim Asthlak As New DataGridViewTextBoxColumn
        With Asthlak
            .HeaderText = "الإستهلاك" : .Width = 75 : .Name = "Asthlak" : .Tag = "Asthlak" : .ReadOnly = True
        End With
        '''''
        Dim AsthlakVal As New DataGridViewTextBoxColumn
        With AsthlakVal
            .HeaderText = "قيمة الإستهلاك" : .Width = 100 : .Name = "AsthlakVal" : .Tag = "AsthlakVal" : .ReadOnly = True
        End With
        '''''
        Dim Total As New DataGridViewTextBoxColumn
        With Total
            .HeaderText = "إجمالي القيمة" : .Width = 100 : .Name = "Total" : .Tag = "Total" : .ReadOnly = True
        End With
        '''''
        Dim Description As New DataGridViewTextBoxColumn
        With Description
            .HeaderText = "وصف الواقعه" : .Width = 100 : .Name = "Description" : .Tag = "Description" : .ReadOnly = True
        End With
        '''''
        Dim cmdPrint As New DataGridViewButtonColumn
        With cmdPrint
            .HeaderText = "طباعة" : .Width = 50 : .Name = "print" ': .Tag = "Description" : .ReadOnly = True
        End With
        '''''
        strDataGrid.Columns.Add(DocNoTzaloom)
        strDataGrid.Columns.Add(TzaloomDate)
        strDataGrid.Columns.Add(TzaloomNo)
        strDataGrid.Columns.Add(Asthlak)
        strDataGrid.Columns.Add(AsthlakVal)
        strDataGrid.Columns.Add(Total)
        strDataGrid.Columns.Add(Description)
        strDataGrid.Columns.Add(cmdPrint)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        'strDataGrid.RowHeadersVisible = False
        strDataGrid.RowHeadersWidth = 30
        strDataGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point)
        strDataGrid.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point)
    End Sub

    Public Sub SDrawPayedSearshGrid(ByVal strDataGrid As DataGridView)
        Dim ID As New DataGridViewTextBoxColumn
        With ID
            .HeaderText = "رقم الحركة" : .Visible = True
        End With
        '''''''''''
        Dim DocDate As New DataGridViewTextBoxColumn
        With DocDate
            .HeaderText = "تاريخ الحركة" : .Width = 130 : .Tag = "Date" : .Visible = False
        End With
        '''''''''''
        Dim Name As New DataGridViewTextBoxColumn
        With Name
            .HeaderText = "الاســم" : .Width = 100 : .Tag = "Name"
        End With
        '''''''''''
        Dim Address As New DataGridViewTextBoxColumn
        With Address
            .HeaderText = "العنـــــوان" : .Width = 130 : .Tag = "Address"
        End With
        '''''''''''
        strDataGrid.Columns.Add(ID)
        strDataGrid.Columns.Add(DocDate)
        strDataGrid.Columns.Add(Name)
        strDataGrid.Columns.Add(Address)

        strDataGrid.AllowUserToAddRows = False
        strDataGrid.AllowUserToDeleteRows = False
        strDataGrid.RowHeadersVisible = False
        strDataGrid.RowHeadersWidth = 30

        'strDataGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point)
        'strDataGrid.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
    End Sub

End Module
