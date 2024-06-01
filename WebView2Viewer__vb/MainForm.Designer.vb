<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me._btnFunction = New System.Windows.Forms.Button()
        Me._txbInput = New System.Windows.Forms.TextBox()
        Me._panelRoot = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        '_btnFunction
        '
        Me._btnFunction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._btnFunction.BackColor = System.Drawing.Color.DarkMagenta
        Me._btnFunction.Cursor = System.Windows.Forms.Cursors.Hand
        Me._btnFunction.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me._btnFunction.ForeColor = System.Drawing.SystemColors.Control
        Me._btnFunction.Location = New System.Drawing.Point(711, 551)
        Me._btnFunction.Margin = New System.Windows.Forms.Padding(0)
        Me._btnFunction.Name = "_btnFunction"
        Me._btnFunction.Size = New System.Drawing.Size(80, 40)
        Me._btnFunction.TabIndex = 1
        Me._btnFunction.Text = "GO"
        Me._btnFunction.UseVisualStyleBackColor = False
        '
        '_txbInput
        '
        Me._txbInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txbInput.BackColor = System.Drawing.SystemColors.Window
        Me._txbInput.Enabled = False
        Me._txbInput.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me._txbInput.Location = New System.Drawing.Point(15, 561)
        Me._txbInput.Margin = New System.Windows.Forms.Padding(0)
        Me._txbInput.Name = "_txbInput"
        Me._txbInput.ReadOnly = True
        Me._txbInput.Size = New System.Drawing.Size(690, 23)
        Me._txbInput.TabIndex = 2
        '
        '_panelRoot
        '
        Me._panelRoot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._panelRoot.BackColor = System.Drawing.Color.LightGray
        Me._panelRoot.Location = New System.Drawing.Point(9, 9)
        Me._panelRoot.Margin = New System.Windows.Forms.Padding(0)
        Me._panelRoot.Name = "_panelRoot"
        Me._panelRoot.Size = New System.Drawing.Size(782, 534)
        Me._panelRoot.TabIndex = 4
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me._panelRoot)
        Me.Controls.Add(Me._txbInput)
        Me.Controls.Add(Me._btnFunction)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(100, 40)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _btnFunction As System.Windows.Forms.Button
    Friend WithEvents _txbInput As System.Windows.Forms.TextBox
    Friend WithEvents _panelRoot As System.Windows.Forms.Panel
End Class
