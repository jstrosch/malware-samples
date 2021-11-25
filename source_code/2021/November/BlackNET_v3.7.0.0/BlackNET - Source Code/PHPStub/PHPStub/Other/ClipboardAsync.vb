Imports System.Threading

Namespace Other
    Public Class ClipboardAsync
        Private _GetText As String
        Private Sub _thGetText(ByVal format As Object)
            Try
                If format Is Nothing Then
                    _GetText = Clipboard.GetText()
                Else
                    _GetText = Clipboard.GetText(DirectCast(format, TextDataFormat))
                End If

            Catch ex As Exception
                _GetText = String.Empty
            End Try
        End Sub
        Public Function GetText() As String
            Dim instance As New ClipboardAsync
            Dim staThread As New Thread(AddressOf instance._thGetText)
            staThread.SetApartmentState(ApartmentState.STA)
            staThread.Start()
            staThread.Join()
            Return instance._GetText
        End Function
        Public Function GetText(ByVal format As TextDataFormat) As String
            Dim instance As New ClipboardAsync
            Dim staThread As New Thread(AddressOf instance._thGetText)
            staThread.SetApartmentState(ApartmentState.STA)
            staThread.Start(format)
            staThread.Join()
            Return instance._GetText
        End Function

        Private _ContainsText As Boolean
        Private Sub _thContainsText(ByVal format As Object)
            Try
                If format Is Nothing Then
                    _ContainsText = Clipboard.ContainsText()
                Else
                    _ContainsText = Clipboard.ContainsText(DirectCast(format, TextDataFormat))
                End If
            Catch ex As Exception
                _ContainsText = False
            End Try
        End Sub
        Public Function ContainsText() As Boolean
            Dim instance As New ClipboardAsync
            Dim staThread As New Thread(AddressOf instance._thContainsText)
            staThread.SetApartmentState(ApartmentState.STA)
            staThread.Start()
            staThread.Join()
            Return instance._ContainsText
        End Function
        Public Function ContainsText(ByVal format As Object) As Boolean
            Dim instance As New ClipboardAsync
            Dim staThread As New Thread(AddressOf instance._thContainsText)
            staThread.SetApartmentState(ApartmentState.STA)
            staThread.Start(format)
            staThread.Join()
            Return instance._ContainsText
        End Function
    End Class
End Namespace