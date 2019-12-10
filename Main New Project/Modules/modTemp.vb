
Public Module modTemp

    Public Function FCalcEnergyMain(intAsthlak As Integer, strDate As String, intPlaceCode As Integer, intEffectDay As Integer, intPriceCalcType As Integer, dblPayed As Double, CONString As SqlClient.SqlConnection) As Double
        'intAsthlak            الاستهلاك بالكيلووات
        'strDate               تاريخ اليوم او تاريخ نهاية المحضر
        'intPlaceCode          نوع الاستعمال 
        'intEffectDay          عدد ايام المحاسبه
        'intPriceCalcType      طريقة الحساب سنوي / مؤقت / ضبط سابق  
        'dblPayed              ماتم سداده

        Dim dblAsthlakVal As Double = 0
        Dim dblForfeitVal As Double = 0

        '''''''''''''''''' Get Price Date
        Dim strCondition As String = "DocDate <='" & FFormatDate(strDate) & "' And DocDateTo >='" & FFormatDate(strDate) & "' And PlaceCode='" & intPlaceCode & "'"
        Dim strPriceCode As String = FGetFeildValues("Tblt_PriceLevel", "DocNo", strCondition, CONString, False, False)

        If strPriceCode <> Nothing Then
            'cmbPriceCode.SelectedValue = strPriceCode
            '''''''''''''''''' Get Price Date
            dblAsthlakVal = calcAsthlakVal(strPriceCode, intAsthlak, intEffectDay, intPriceCalcType, CONString)
            '''''''''''' غرامة العمدى
            If intPriceCalcType = 2 Then ' في حالة من تاريخ ضبط سايق تكون الغرامه مضروبة * 4
                dblForfeitVal = ((FGetFeildValues("Tblt_PriceLevelGrid", "Price", "DocNo='" & strPriceCode & "' Order By SHNO  DESC", CONString) * intAsthlak) - dblPayed) * 4
            Else
                dblForfeitVal = ((FGetFeildValues("Tblt_PriceLevelGrid", "Price", "DocNo='" & strPriceCode & "' Order By SHNO  DESC", CONString) * intAsthlak) - dblPayed) * 2
            End If
            ''''''''''''  غرامة العمدى

            Dim DicStamp As Dictionary(Of Integer, Double) = SCalcStamps(intEffectDay, intAsthlak, strDate, intPlaceCode, intPriceCalcType)        '  حساب الدمغات

            Return SCalcTextValue(dblAsthlakVal, dblForfeitVal, DicStamp, dblPayed)    '  تجميع الخانات
        End If

    End Function

    Public Function calcAsthlakVal(strPriceCode As String, intAsthlak As Integer, intEffectDay As Integer, intPriceCalcType As Integer, CONString As SqlClient.SqlConnection, Optional ByVal bolDealWithAddVal As Boolean = False) As Double
        Try
            Dim IntOldAsthlak As Double = intAsthlak 'وضع قيمة إجمالي الإستهلاك
            Dim intNewAsthlak As Double = intAsthlak ' وضع قيمة مبدائية
            Dim tmpFrom, tmpTo, tmpPrice, tmpAdd, tmpValue, Tmp As Double ' true
            Dim X As Integer = 0    'خاص بالسعر الجديدوالاسعار المتداخلة

            Dim strSQL As String = " Select * From Tblt_PriceLevelGrid Where (((Tblt_PriceLevelGrid.DocNo) = '" & strPriceCode & "'))" &
            " ORDER BY Tblt_PriceLevelGrid.SHNO ;"

            Dim cmd As New SqlClient.SqlCommand(strSQL, CONString)
            Dim reader As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Do While reader.Read
                tmpFrom = reader.Item("From") : tmpTo = reader.Item("To") : tmpPrice = reader.Item("Price") 'set val

                ''''لتصفير الشريحة في الاسعار الجديدة
                If tmpFrom = 1 And X > 0 Then
                    tmpValue = 0 : intNewAsthlak = intAsthlak : X = 0
                End If
                ''''لتصفير الشريحة في الاسعار الجديدة

                '''''''''''''' جزء خاص برسوم الإصدار
                If bolDealWithAddVal = True Then
                    tmpAdd = (reader.Item("Add") / 30) * intEffectDay
                ElseIf bolDealWithAddVal = False Then
                    tmpAdd = 0
                End If
                'Dim t As String = Convert.ToString(intEffectDay)
                '''''''''''''' جزء خاص برسوم الإصدار

                'Tmp = Math.Round((((tmpTo - tmpFrom) + 1) / 30) * intEffectDay) ' نصيب اليوم من الشريحة
                If intPriceCalcType = 0 Then     ' في حالة المدة سنة
                    Tmp = (((tmpTo - tmpFrom) + 1) * 12)
                ElseIf intPriceCalcType = 1 Then ' في حالة المدة 90 يوم
                    Tmp = ((((tmpTo - tmpFrom) + 1) * 12) / 4)
                Else                                           ' في حالة المدة باليوم
                    'Tmp = Math.Round(((((tmpTo - tmpFrom) + 1) * 12) / 365) * intEffectDay)
                    Tmp = (((((tmpTo - tmpFrom) + 1) * 12) / 365) * intEffectDay)
                End If

                'Tmp = ((((tmpTo - tmpFrom) + 1) / 30) * intEffectDay) ' نصيب اليوم من الشريحة
                If intNewAsthlak <= Tmp Then
                    reader.Close()
                    'Return Math.Round(((tmpValue + (intNewAsthlak * tmpPrice)) + tmpAdd), 2)
                    Return ((tmpValue + (intNewAsthlak * tmpPrice)) + tmpAdd)
                Else
                    tmpValue = tmpValue + (Tmp * tmpPrice)
                    intNewAsthlak -= Tmp
                End If
                X += 1
            Loop

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function SCalcStamps(intEffectDay As Integer, intAsthlak As Integer, strDate As String, intPlaceCode As Integer, intPriceCalcType As Integer) As Dictionary(Of Integer, Double)
        Try
            ' SCalcStamp(1)= اذاعه & SCalcStamp(2)= محافظة  & SCalcStamp(3)= استهلاك & SCalcStamp(4)= صناعيه
            Dim dblAsthlakTmp As Double = 0
            If intEffectDay > 0 Then dblAsthlakTmp = ((intAsthlak / intEffectDay) * 30) Else dblAsthlakTmp = 0 ' نصيب الشهر من الكيلووات
            'Dim da As Date = DateAdd(DateInterval.Day, Convert.ToDouble(intEffectDay), strDate)
            Dim SCalcStamp As New Dictionary(Of Integer, Double)

            Dim dteFrom As Date = DateAdd(DateInterval.Day, -1 * intEffectDay, CType(strDate, Date))

            Dim intMonthCount As Integer = (DateDiff(DateInterval.Month, dteFrom, CType(strDate, Date)))

            Select Case intPlaceCode
                Case "1" ' منزلي
                    If intPriceCalcType = 0 Then ' سنوي
                        If Val(intAsthlak) <= 500 Then
                            'TxtBox15.Text = Round((Val(intAsthlak) * 0.002), 2)
                            SCalcStamp.Add(1, Math.Round((Val(intAsthlak) * 0.002), 2))
                        ElseIf Val(intAsthlak) > 500 Then
                            'TxtBox15.Text = "1.08"
                            SCalcStamp.Add(1, 1.08)
                        End If
                        'TxtBox17.Text = "0.12" ' الاذاعة
                        SCalcStamp.Add(2, 0.12)
                    ElseIf intPriceCalcType = 1 Then ' مؤقتة
                        'TxtBox15.Text = "0.27"
                        SCalcStamp.Add(1, 0.27)
                        'TxtBox17.Text = "0.03" ' الاذاعة
                        SCalcStamp.Add(2, 0.03)

                    ElseIf intPriceCalcType = 2 Then ' ضبط سابق
                        If intMonthCount = 0 Then
                            'TxtBox15.Text = "0.09"
                            SCalcStamp.Add(1, 0.09)
                        Else
                            'TxtBox15.Text = intMonthCount * 0.09
                            SCalcStamp.Add(1, intMonthCount * 0.09)
                        End If
                        ''''''''''''  دمغة محافظة
                        If intMonthCount = 0 Then
                            'TxtBox17.Text = "0.01"
                            SCalcStamp.Add(2, 0.01)
                        Else
                            'TxtBox17.Text = intMonthCount * 0.01
                            SCalcStamp.Add(2, intMonthCount * 0.01)
                        End If
                    End If
                    'TxtBox16.Text = "0" ' دمغة استهلاك
                    SCalcStamp.Add(3, 0)
                Case Else 'الانشطة غير المنزلي
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''دمغة اذاعه
                    'TxtBox15.Text = Round((Val(intAsthlak) * 0.002), 2)
                    SCalcStamp.Add(1, Math.Round((Val(intAsthlak) * 0.002), 2))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''دمغة اذاعه

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''' دمغة استهلاك
                    If SCalcStamp.ContainsKey(4) Then
                        If SCalcStamp.Item(4) > 0 Then
                            'If Val(TxtBox14.Text) > 0 Then
                            'TxtBox16.Text = "0"
                            SCalcStamp.Add(3, 0)
                        Else
                            'TxtBox16.Text = Round((0.03 * Val(intAsthlak)), 2)
                            SCalcStamp.Add(3, Math.Round((0.03 * Val(intAsthlak)), 2))
                        End If
                    Else
                        'TxtBox16.Text = Round((0.03 * Val(intAsthlak)), 2)
                        SCalcStamp.Add(3, Math.Round((0.03 * Val(intAsthlak)), 2))
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''' دمغة استهلاك

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''' دمغة محافظة
                    If intPriceCalcType = 0 Then ' سنوي
                        'TxtBox17.Text = "0.12" ' الاذاعة
                        SCalcStamp.Add(2, 0.12)
                    ElseIf intPriceCalcType = 1 Then ' مؤقتة
                        'TxtBox17.Text = "0.03" ' الاذاعة
                        SCalcStamp.Add(2, 0.03)
                    ElseIf intPriceCalcType = 2 Then ' ضبط سابق
                        If intMonthCount = 0 Then
                            'TxtBox17.Text = "0.01"
                            SCalcStamp.Add(2, 0.01)
                        Else
                            'TxtBox17.Text = intMonthCount * 0.01
                            SCalcStamp.Add(2, intMonthCount * 0.01)
                        End If
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''' دمغة محافظة
            End Select
            Return SCalcStamp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function SCalcTextValue(dblAsthlakVal As Double, dblForfeitVal As Double, DicStamp As Dictionary(Of Integer, Double), dblPayed As Double) As Double
        Try
            Dim dblTot As Double = 0
            Dim dblFarq As Double = 0

            If DicStamp.ContainsKey(1) Then dblTot += DicStamp.Item(1)
            If DicStamp.ContainsKey(2) Then dblTot += DicStamp.Item(2)
            If DicStamp.ContainsKey(3) Then dblTot += DicStamp.Item(3)
            If DicStamp.ContainsKey(4) Then dblTot += DicStamp.Item(4)
            'End If

            dblTot = Math.Round(dblTot + dblAsthlakVal - dblPayed + dblForfeitVal, 2, MidpointRounding.AwayFromZero)

            'dblTot = Math.Round(dblAsthlakVal - dblPayed + dblForfeitVal + IIf(DicStamp.ContainsKey(4), 0, DicStamp.Item(4)) + IIf(DicStamp.ContainsKey(1), DicStamp.Item(1), 0) + IIf(DicStamp.ContainsKey(3), DicStamp.Item(3), 0) + IIf(DicStamp.ContainsKey(2), DicStamp.Item(2), 0), 2, MidpointRounding.AwayFromZero)
            'dblTot = Val(TxtBox11.Text) - Val(TxtBox12.Text) + Val(TxtBox13.Text) + Val(TxtBox14.Text) + Val(TxtBox15.Text) + Val(TxtBox16.Text) + Val(TxtBox17.Text) + Val(TxtBox18.Text)

            SCalcTextValue = Ceiling(dblTot, 0.05, dblFarq)
            'TxtBox18.Text = dblFarq ' Round(Val(TxtBox19.Text) - Round(dblTot, 2), 2)
            Return (SCalcTextValue + dblFarq)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

End Module
