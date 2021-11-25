Imports System
Imports System.Text.RegularExpressions
Public Class JsonReader
    Public Data As String

    Public Sub New(ByVal data As String)
        Me.Data = data
    End Sub

    Public Function GetValue(ByVal value As String) As String
        Dim result As String = String.Empty
        Dim rgx As String = "\" & """" & value & "\" & """" & ":" & "[\s\S]*" & "\" & """" & "([^""]+)\" & """" & ""
        Dim valueRegex As Regex = New Regex(rgx)
        Dim valueMatch As Match = valueRegex.Match(Me.Data)
        If Not valueMatch.Success Then Return result
        result = Regex.Split(valueMatch.Value, """")(3)
        Return result
    End Function

    Public Sub Remove(ByVal values As String())
        For Each value As String In values
            Me.Data = Me.Data.Replace(value, "")
        Next
    End Sub

    Public Function SplitData(Optional ByVal delimiter As String = "},") As String()
        Return Regex.Split(Me.Data, delimiter)
    End Function
End Class
