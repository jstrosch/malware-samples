Namespace Other
    Module BrowserHandler
        Public Sub OpenWebPage(ByVal URL As String)
            If My.Computer.Info.OSFullName.Contains("10") Then
                OpenWebPageWind10(URL)
            Else
                OpenWebPageOther(URL)
            End If
        End Sub
        Private Function getDefaultBrowser() As String
            Dim retVal As String = String.Empty
            Using baseKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Clients\StartmenuInternet")
                Dim baseName As String = baseKey.GetValue("").ToString
                Dim subKey As String = "SOFTWARE\" & IIf(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") = "AMD64", "Wow6432Node\", "") & "Clients\StartMenuInternet\" & baseName
                Using browserKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(subKey)
                    retVal = browserKey.GetValue("").ToString
                End Using
            End Using
            Return retVal
        End Function
        Public Sub OpenWebPageWind10(ByVal URL As String)
            Try
                If getDefaultBrowserWin10.Contains("Firefox") Then
                    Process.Start("firefox", URL)
                ElseIf getDefaultBrowserWin10.Contains("IE") Then
                    Process.Start("iexplore", URL)
                ElseIf getDefaultBrowserWin10.Contains("Chrome") Then
                    Process.Start("chrome", URL)
                Else
                    Process.Start(URL)
                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub OpenWebPageOther(ByVal URL As String)
            Try
                Select Case getDefaultBrowser()
                    Case "Internet Explorer"
                        Process.Start("iexplore", URL)
                    Case "Mozilla Firefox"
                        Process.Start("firefox", URL)
                    Case "Google Chrome"
                        Process.Start("chrome", URL)
                End Select

            Catch ex As Exception

            End Try
        End Sub
        Private Function getDefaultBrowserWin10() As String
            Dim retVal As String = String.Empty
            Using baseKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\Shell\Associations\UrlAssociations\https\UserChoice")
                retVal = baseKey.GetValue("ProgId").ToString
            End Using
            Return retVal
        End Function
    End Module
End Namespace