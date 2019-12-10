Imports System.Runtime.InteropServices

Module ServerDate
    Private Declare Unicode Function NetRemoteTOD Lib "netapi32" (
  <MarshalAs(UnmanagedType.LPWStr)> ByVal ServerName As String,
  ByRef BufferPtr As IntPtr) As Integer
    Private Declare Function NetApiBufferFree Lib _
      "netapi32" (ByVal Buffer As IntPtr) As Integer

    Structure TIME_OF_DAY_INFO
        Dim tod_elapsedt As Integer
        Dim tod_msecs As Integer
        Dim tod_hours As Integer
        Dim tod_mins As Integer
        Dim tod_secs As Integer
        Dim tod_hunds As Integer
        Dim tod_timezone As Integer
        Dim tod_tinterval As Integer
        Dim tod_day As Integer
        Dim tod_month As Integer
        Dim tod_year As Integer
        Dim tod_weekday As Integer
    End Structure

    Function GetNetRemoteTOD(ByVal strServerName As String) As Date
        Try
            Dim iRet As Integer
            Dim ptodi As IntPtr
            Dim todi As TIME_OF_DAY_INFO
            Dim dDate As Date
            strServerName = strServerName & vbNullChar
            iRet = NetRemoteTOD(strServerName, ptodi)
            If iRet = 0 Then
                todi = CType(Marshal.PtrToStructure(ptodi, GetType(TIME_OF_DAY_INFO)),
                  TIME_OF_DAY_INFO)
                NetApiBufferFree(ptodi)
                dDate = DateSerial(todi.tod_year, todi.tod_month, todi.tod_day) + " " +
                TimeSerial(todi.tod_hours, todi.tod_mins - todi.tod_timezone, todi.tod_secs)
                GetNetRemoteTOD = dDate
            Else
                MsgBox("Error retrieving time")
            End If
        Catch
            MsgBox("Error in GetNetRemoteTOD: " & Err.Description)
        End Try
    End Function


End Module
