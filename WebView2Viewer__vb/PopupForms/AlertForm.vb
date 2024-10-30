Imports System
Imports System.Windows.Forms



Namespace PopupForms
    Public NotInheritable Class AlertForm
        Public Shared Function Open(owner As IWin32Window, title As String, text As String) As DialogResult
            Dim rdr As DialogResult = DialogResult.None
            Using frm As New AlertForm
                frm.Text = title
                frm._txbMain.Text = text
                rdr = frm.ShowDialog(owner)
            End Using

            Return rdr
        End Function


        Public Shared Function Open(owner As IWin32Window, text As String) As DialogResult
            Return Open(owner, "알림", text)
        End Function


        Private Sub New()
            ' 디자이너에서 이 호출이 필요합니다.
            InitializeComponent()

            ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        End Sub


        Protected Overrides Sub OnLoad(e As EventArgs)
            MyBase.OnLoad(e)

            AddHandler _btnYes.Click, AddressOf _btnYes__Click
            AddHandler _btnNo.Click, AddressOf _btnNo__Click
        End Sub


        Protected Overrides Sub OnShown(e As EventArgs)
            MyBase.OnShown(e)

            _btnYes.Focus()
        End Sub


        Private Sub _btnYes__Click(sender As Object, e As EventArgs)
            DialogResult = DialogResult.Yes
            Close()
        End Sub


        Private Sub _btnNo__Click(sender As Object, e As EventArgs)
            DialogResult = DialogResult.No
            Close()
        End Sub


        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
            If keyData = Keys.Escape Then
                Close()
            End If

            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
    End Class
End Namespace