Imports EchelonPluginInterface.Class1

Public Class PlugInManager
    Public PlugInListe As New List(Of myInterface)
    Public Sub ReFreshPlugIns()
        PlugInListe = New List(Of myInterface)
        For Each plugin As String In System.IO.Directory.GetFiles(My.Application.Info.DirectoryPath & "\P\", "*.dll")
            PlugInListe.Add(PlugInConnector.LoadPlugIn(plugin))
        Next
    End Sub

    Public Function GetPlugInByName(ByVal sPlugInName As String) As myInterface
        For Each p As myInterface In PlugInListe
            If p.GetPlugInName = sPlugInName Then
                Return p
            End If
        Next
        Return Nothing
    End Function

    Public Function StartPlugIn(ByVal sPlugInName As String) As Boolean
        For Each p As myInterface In PlugInListe
            If p.GetPlugInName = sPlugInName Then
                If p.GetPlugInType = &H1 Then
                    p.StartMe(New String() {_Ipadresse, _ConnectionPort, _TransferPort, Application.ExecutablePath, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""})
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    Public Function PlugInIsInstalled(ByVal sName As String) As Boolean
        For Each p As myInterface In PlugInListe
            If p.GetPlugInName = sName Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub SetConnectionToplugIn(ByVal sPlugInName As String, ByVal Tcp_Client As System.Net.Sockets.TcpClient)
        GetPlugInByName(sPlugInName).GetConnection(Tcp_Client)
    End Sub
End Class
Public Class PlugInConnector
    Public Shared Function LoadPlugIn(ByVal strFile As String) As myInterface
        Dim vPlugIn As myInterface
        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(strFile)

        Dim types() As Type = a.GetTypes

        For Each pType As Type In types
            Try
                vPlugIn = CType(a.CreateInstance(pType.FullName), myInterface)
                Return vPlugIn
            Catch ex As Exception
            End Try
        Next
        Return Nothing
    End Function
End Class