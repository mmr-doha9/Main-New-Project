Imports System.Data
Imports System.Data.OleDb
Public Enum NavDirection
    DMoveFirst = 0
    DMoveNext = 1
    DMovePrevious = 2
    DMoveLast = 3
End Enum
Public Enum Valadation
    Tag = 0
    Valadtion = 1
    [Default] = 2
    err = 3
    ComboType = 4
End Enum
Public Enum TreeBranches
    MultiBranches = 0
    SingleBranch = 1
End Enum
Public Enum TranType
    Insert = 0
    Delete = 1
End Enum
Public Enum DataConnection
    SqlServer = 0
    Access = 1
End Enum
Public Enum KbLang
    Arabic = 0
    English = 1
End Enum
Public Enum PriceType
    SalePrice = 0
    NasfGomlaPrice = 1
    GomlaPrice = 2
    PurchesPrice = 3
End Enum
Public Enum PrintType
    Preview = 0
    Print = 1
End Enum
Public Enum RepLoadSource
    Database = 0
    Dataset = 1
End Enum
Public Enum SearchReturnType
    [String] = 0
    [Number] = 1
End Enum
Public Enum ComboLoadItemSelect
    [Min] = 0
    [Max] = 1
    [Nothing] = 3
End Enum
Public Enum LoadProgType
    [Min] = 0
    [Max] = 1
End Enum
Public Enum frmEditType
    [Save] = 0
    [Edit] = 1
End Enum
Public Enum loadType
    [Mdi] = 0
    [ShowDialoge] = 1
End Enum
Public Enum TransactionType
    [Save] = 0
    [Edit] = 1
    [Delete] = 2
    [logIn] = 3
    [logOut] = 4
    [Payed] = 5
    [Tazloom] = 6
End Enum
Public Enum typeCalc
    [Auto] = 0
    [Manual] = 1
End Enum

Public Module modGlobals
    Public strServerName As String
    Public strDataBaseName As String '= "Data"
    Public strDataBaseAccPassword As String '= "gtmmr"
    Public strDataBaseUserName As String = "sa"
    Public strDataBasePassword As String = "123456"

    Public strKbLang As KbLang = KbLang.Arabic
    Public DataType As DataConnection = DataConnection.SqlServer

    Public RepSource As RepLoadSource = RepLoadSource.Database

    Public Db_Conn As String
    Public CON As SqlClient.SqlConnection = New SqlClient.SqlConnection
    Public CONAccess As OleDb.OleDbConnection = New OleDb.OleDbConnection
    Public strSQL As String
    Public ProgName As String = " برنامج إدارة السرقات بشركة جنوب القاهرة لتوزيع الكهرباء "
    Public strGTableName As String
    Public strGKeyField As String
    Public strGKeyValue As String
    Public strGCondtion As String
    Public Alpha, Red, Green, Blue As Byte
    'Public strReportName As String
    'Public strReportNo As String
    Public Const KbArabic = 1
    Public Const KbEnglish = 2
    Public Const KLF_ACTIVATE = &H1
    Public strUserAdmin As String ' في حالة تحكم مدير النظام
    Public strUserType As String ' نوع المستخدم
    Public strUserID As String
    Public strUserName As String
    Public strCompanyID As String
    Public strCompanyName As String = "إدارة السرقات"
    Public strUserPassword As String
    Public strSearchGridVal As String
    Public strSearchTreeVal As String
    Public strSearchTreeVal2 As String
    '
    Public strFGTreeSearch As String
    Public strFGTreeSearch2 As String
    Public strFGTreeSearch3 As String
    Public strFGTreeSearch4 As String
    Public strFGTreeSearch5 As String
    Public strFGTreeSearch6 As String
    Public strFGTreeSearch7 As String
    Public strFGTreeSearch8 As String
    Public strFGTreeSearch9 As String
    Public strFGTreeSearch10 As String
    '
    Public bolDemo As Boolean
    '
    Public strTblName As String
    Public strFldName As String
    Public strFldCon As String
    ''
    ''search form
    Public strDocNoSearch As String
    Public strSearchBeginNameMain As String
    Public arrCoulmn() As String = {}
    ''search form

    Public BolCompactDataDate As Boolean
    Public intComboItemNew As Integer ' حفظ قيمة الكومبو للتحميل عند الحفظ
    Public intDocNoMain As New List(Of Integer) ' رقم الحركات في شاشة الحفظ المجمع
End Module
