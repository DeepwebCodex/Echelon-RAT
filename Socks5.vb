Public Class Socks5
    Public socksClient As Net.Sockets.TcpClient
    Public serverClient As Net.Sockets.TcpClient
    Private SOCKS_VERSION As Byte = 5
    Private SOCKS_NOAUTH As Byte = 0
    Private SOCKS_REPLYSUCCESS As Byte = 0
    Private SOCKS_IPV4ADDR As Byte = 1
    Private SOCKS_DNSNAME As Byte = 3
    Public Online As Boolean = False
    Public Sub New(ByVal client As Net.Sockets.TcpClient)
        socksClient = client
    End Sub

    Public Sub Work()
        Try
            Dim socksClientStream As Net.Sockets.NetworkStream = socksClient.GetStream()
            Dim authFields As Byte() = New Byte(1) {}
            socksClientStream.Read(authFields, 0, 2)

            Dim methods As Byte() = New Byte(authFields(1) - 1) {}
            socksClientStream.Read(methods, 0, methods.Length)

            Dim selectedAuthMethod As Byte() = {SOCKS_VERSION, SOCKS_NOAUTH}
            socksClientStream.Write(selectedAuthMethod, 0, 2)

            Dim requestFields As Byte() = New Byte(3) {}
            socksClientStream.Read(requestFields, 0, 4)

            Dim connection_target As String = ""
            Dim target_port As Integer
            If requestFields(3) = SOCKS_IPV4ADDR Then
                Dim target_data As Byte() = New Byte(3) {}
                socksClientStream.Read(target_data, 0, 4)
                Dim ip As New Net.IPAddress(target_data)
                connection_target = ip.ToString()

            ElseIf requestFields(3) = SOCKS_DNSNAME Then
                Dim domainname_length As Byte() = New Byte(0) {}
                socksClientStream.Read(domainname_length, 0, 1)
                Dim target_data As Byte() = New Byte(domainname_length(0) - 1) {}
                socksClientStream.Read(target_data, 0, domainname_length(0))
                connection_target = System.Text.Encoding.[Default].GetString(target_data)
            Else
            End If
            If connection_target <> "" Then
                Dim bintargetport As Byte() = New Byte(1) {}
                socksClientStream.Read(bintargetport, 0, 2)
                Dim tmp_byteorder As Byte() = New Byte(1) {}
                tmp_byteorder(0) = bintargetport(1)
                tmp_byteorder(1) = bintargetport(0)
                target_port = CInt(BitConverter.ToUInt16(tmp_byteorder, 0))
                serverClient = New Net.Sockets.TcpClient(connection_target, target_port)
                If serverClient.Connected Then
                    Dim reply As Byte() = New Byte(9) {}
                    reply(0) = SOCKS_VERSION
                    reply(1) = SOCKS_REPLYSUCCESS
                    reply(2) = 0
                    reply(3) = 1
                    Dim ip As String = serverClient.Client.LocalEndPoint.ToString().Split(":"c)(0)
                    Dim ipaddr As Net.IPAddress = Net.IPAddress.Parse(ip)
                    reply(4) = ipaddr.GetAddressBytes()(0)
                    reply(5) = ipaddr.GetAddressBytes()(1)
                    reply(6) = ipaddr.GetAddressBytes()(2)
                    reply(7) = ipaddr.GetAddressBytes()(3)
                    Dim port As UShort = UShort.Parse(serverClient.Client.LocalEndPoint.ToString().Split(":"c)(1))
                    reply(8) = BitConverter.GetBytes(DirectCast(port, UInt16))(0)
                    reply(9) = BitConverter.GetBytes(DirectCast(port, UInt16))(1)
                    socksClientStream.Write(reply, 0, 10)
                    Dim serverClientStream As Net.Sockets.NetworkStream = serverClient.GetStream()
                    Dim ioError As Boolean = False
                    While serverClient.Connected AndAlso socksClient.Connected AndAlso Not ioError
                        System.Threading.Thread.Sleep(10)
                        Try
                            If socksClientStream.DataAvailable Then
                                Dim readbuffer As Byte() = New Byte(9999) {}
                                Dim count_read As Integer = socksClientStream.Read(readbuffer, 0, 10000)
                                Dim read_data As Byte() = New Byte(count_read - 1) {}
                                Array.Copy(readbuffer, read_data, count_read)
                                serverClientStream.Write(read_data, 0, read_data.Length)
                                'Console.WriteLine("Neue Datenpakete empfangen")
                            End If
                            If serverClientStream.DataAvailable Then
                                Dim receivebuffer As Byte() = New Byte(9999) {}
                                Dim count_receive As Integer = serverClientStream.Read(receivebuffer, 0, 10000)
                                Dim receive_data As Byte() = New Byte(count_receive - 1) {}
                                Array.Copy(receivebuffer, receive_data, count_receive)
                                'Console.WriteLine("Datenpakete gesendet")
                                socksClientStream.Write(receive_data, 0, receive_data.Length)
                            End If
                        Catch
                            ioError = True
                        End Try
                    End While
                    If socksClient.Connected Then
                        socksClient.Close()
                    End If
                    If serverClient.Connected Then
                        serverClient.Close()
                    End If
                Else
                End If
            Else
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
