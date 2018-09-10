Public Class DateiSuche
    Private Sollsuchen As Boolean = False
    Public Event DateiGefunden(ByVal Pfad As String, ByVal DateiName As String, ByVal Größe As String, ByVal suchwort As String)
    Private Structure Parameter
        Dim Datei As String
        Dim Ordner As String
    End Structure

    Public Sub Start(ByVal sSuchwort As String, ByVal sStartordner As String)
        Sollsuchen = True
        Dim p As New Parameter
        p.Datei = sSuchwort
        p.Ordner = sStartordner
        Dim t As New System.Threading.Thread(AddressOf Suchen)
        t.IsBackground = True
        t.Start(p)
    End Sub
    Public Sub Stopp()
        Sollsuchen = False
    End Sub
    Private Sub Suchen(ByVal p As Parameter)
        For Each datei As String In My.Computer.FileSystem.GetFiles(p.Ordner)
            Try
                If Sollsuchen = False Then Exit Sub
                If datei.ToString.Contains(p.Datei) Then
                    If datei <> "" Then
                        Dim fi As New IO.FileInfo(datei)
                        RaiseEvent DateiGefunden(fi.FullName, fi.Name, fi.Length.ToString, p.Datei)
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        For Each ordner As String In My.Computer.FileSystem.GetDirectories(p.Ordner)
            Try
                If Sollsuchen = False Then Exit Sub
                Dim p2 As Parameter
                p2.Datei = p.Datei
                p2.Ordner = ordner
                Suchen(p2)
            Catch ex As Exception
            End Try
        Next
    End Sub
End Class
