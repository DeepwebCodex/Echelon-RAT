Public Class Socks5Handler
    Public Event SendText(ByVal sText As String)
    Public Socks5List As New List(Of Socks5)
    Public Sub NewSocks5(ByVal Port As Integer)
        Try
            Dim TcpListener As New System.Net.Sockets.TcpListener(Port)
            TcpListener.Start()
            RaiseEvent SendText("Socks5 Server lauscht nun auf dem Port: " & Port)
            While True
                Dim TcpC As New System.Net.Sockets.TcpClient
                TcpC = TcpListener.AcceptTcpClient()
                Dim ipend As Net.IPEndPoint = DirectCast(TcpC.Client.RemoteEndPoint, Net.IPEndPoint)

                Dim s As New Socks5(TcpC)
                Dim t As New System.Threading.Thread(AddressOf s.Work)

                t.Start()
                Socks5List.Add(s)

                RaiseEvent SendText("Neue Verbindung aufgebaut, IP Adresse: " & ipend.Address.ToString & " auf dem Port: " & Port)
            End While
        Catch ex As Exception
            RaiseEvent SendText("Socks5 Server ist abgestürzt: " & ex.Message)
        End Try
    End Sub
    Public Sub DeleteAllSocks5Server()
        For Each s As Socks5 In Socks5List
            Try
                s.socksClient.Close()
                s.serverClient.Close()
                RaiseEvent SendText("Socks5 Verbindung unterbrochen.")
            Catch ex As Exception
            End Try
        Next
    End Sub
End Class