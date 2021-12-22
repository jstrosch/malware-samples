<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainController
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
        Me.HiddenBrowser = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'HiddenBrowser
        '
        Me.HiddenBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HiddenBrowser.Location = New System.Drawing.Point(0, 0)
        Me.HiddenBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.HiddenBrowser.Name = "HiddenBrowser"
        Me.HiddenBrowser.ScriptErrorsSuppressed = True
        Me.HiddenBrowser.Size = New System.Drawing.Size(20, 20)
        Me.HiddenBrowser.TabIndex = 0
        Me.HiddenBrowser.Visible = False
        '
        'MainController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(10, 10)
        Me.ControlBox = False
        Me.Controls.Add(Me.HiddenBrowser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainController"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Windows Update"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HiddenBrowser As System.Windows.Forms.WebBrowser
End Class
