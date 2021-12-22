Namespace Persistence
    Module Startup
        Public Sub AStartup(ByVal Name As String, ByVal Path As String)
            Try
                Dim Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                Dim Key As Microsoft.Win32.RegistryKey = Registry.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
                Key.SetValue(Name, Path, Microsoft.Win32.RegistryValueKind.String)
            Catch ex As Exception

            End Try
        End Sub
        Public Sub DStartup(ByVal Name As String)
            Try
                Dim Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                Dim Key As Microsoft.Win32.RegistryKey = Registry.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
                Key.DeleteValue(Name)
            Catch ex As Exception

            End Try
        End Sub
    End Module
End Namespace
