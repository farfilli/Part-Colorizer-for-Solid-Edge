<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_PartColorizer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_PartColorizer))
        Me.BT_Colorize = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Report = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CheckFastMode = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BT_Colorize
        '
        Me.BT_Colorize.Location = New System.Drawing.Point(302, 11)
        Me.BT_Colorize.Margin = New System.Windows.Forms.Padding(2)
        Me.BT_Colorize.Name = "BT_Colorize"
        Me.BT_Colorize.Size = New System.Drawing.Size(121, 35)
        Me.BT_Colorize.TabIndex = 6
        Me.BT_Colorize.Text = "Colorize"
        Me.BT_Colorize.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Report})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 49)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(434, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Report
        '
        Me.Report.Name = "Report"
        Me.Report.Size = New System.Drawing.Size(42, 17)
        Me.Report.Text = "Report"
        '
        'CheckFastMode
        '
        Me.CheckFastMode.AutoSize = True
        Me.CheckFastMode.Checked = True
        Me.CheckFastMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckFastMode.Location = New System.Drawing.Point(12, 21)
        Me.CheckFastMode.Name = "CheckFastMode"
        Me.CheckFastMode.Size = New System.Drawing.Size(283, 17)
        Me.CheckFastMode.TabIndex = 8
        Me.CheckFastMode.Text = "Fast mode (Create FaceStyles but don't apply to faces)"
        Me.CheckFastMode.UseVisualStyleBackColor = True
        '
        'Form_PartColorizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 71)
        Me.Controls.Add(Me.CheckFastMode)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BT_Colorize)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_PartColorizer"
        Me.Text = "Part Colorizer v0.1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_Colorize As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Report As ToolStripStatusLabel
    Friend WithEvents CheckFastMode As CheckBox
End Class
