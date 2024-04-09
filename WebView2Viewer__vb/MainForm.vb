Imports System
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.IO
Imports System.Windows.Forms
Imports WebView2Viewer__vb.Controls
Imports WebView2Viewer__vb.Extensions
Imports WebView2Viewer__vb.Tools



Public NotInheritable Class MainForm
#Region "~~~~~~~~~~ 1) 기본설정"
    ''' <summary>
    ''' 생성자
    ''' </summary>
    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        prTestInit()
    End Sub
    Private Sub prTestInit()
        'KeyPreview = True
    End Sub
    'Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
    '    prErrorDisplay("ㅋㅋㅋㅋ")
    '    Return MyBase.ProcessCmdKey(msg, keyData)
    'End Function
    'Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
    '    prErrorDisplay("ㅋㅋㅋㅋ")
    '    MyBase.OnKeyDown(e)
    'End Sub

    ''' <summary>
    ''' Load 이벤트
    ''' </summary>
    ''' <param name="ea"></param>
    Protected Overrides Sub OnLoad(ea As EventArgs)
        MyBase.OnLoad(ea)

        Text = MainProxy.GetVerInfo()
        MinimumSize = Size - New Size(300, 300)
        AlignBottomRight()
        ResizeRenderCancel()

        _cdp = Environment.GetCommandLineArgs()(0)
        _cdp = Path.GetDirectoryName(_cdp)

        prFooterSetting()
    End Sub


    ''' <summary>
    ''' CurrentDirectoryPath
    ''' </summary>
    Private _cdp As String

    ''' <summary>
    ''' OpenFileDialog
    ''' </summary>
    Private _ofd_pr As OpenFileDialog
    Private ReadOnly Property _ofd As OpenFileDialog
        Get
            If _ofd_pr Is Nothing Then
                _ofd_pr = New OpenFileDialog With {
                    .InitialDirectory = _cdp,
                    .Filter = "html files (*.html)|*.html",
                    .RestoreDirectory = True,
                    .Multiselect = False
                }
            End If
            Return _ofd_pr
        End Get
    End Property

    ''' <summary>
    ''' InputSource
    ''' </summary>
    Private _ips As String

    ''' <summary>
    ''' HtmlDirectoryPath
    ''' </summary>
    Private _hdp As String


    ''' <summary>
    ''' 컨텍스트 메뉴
    ''' </summary>
    Private _cms As ContextMenuStrip



    ''' <summary>
    ''' 하단 세팅
    ''' </summary>
    Private Sub prFooterSetting()
        _cms = New ContextMenuStrip()
        Dim tsia() As ToolStripItem = {
            New ToolStripMenuItem("O) 파일 열기", Nothing, AddressOf prCmsAllClick),
            New ToolStripMenuItem("P) 클립보드 열기", Nothing, AddressOf prCmsAllClick),
            New ToolStripMenuItem("C) 뷰 닫기", Nothing, AddressOf prCmsAllClick),
            New ToolStripSeparator(),
            New ToolStripMenuItem("1) 폴더위치 열기", Nothing, AddressOf prCmsAllClick),
            New ToolStripMenuItem("2) VSCode 열기", Nothing, AddressOf prCmsAllClick),
            New ToolStripSeparator(),
            New ToolStripMenuItem("3) 개발자도구 열기", Nothing, AddressOf prCmsAllClick),
            New ToolStripMenuItem("4) 작업관리자 열기", Nothing, AddressOf prCmsAllClick),
            New ToolStripMenuItem("5) 새로 고침", Nothing, AddressOf prCmsAllClick),
            New ToolStripSeparator(),
            New ToolStripMenuItem("S) 이미지 캡처", Nothing, AddressOf prCmsAllClick),
            New ToolStripMenuItem("X) 메뉴 닫기", Nothing, AddressOf prCmsAllClick)
        }
        _cms.Cursor = Cursors.Hand
        _cms.Items.AddRange(tsia)

        AddHandler _btnFunction.MouseDown, AddressOf prBtnFunctionMouseDown
        AddHandler _btnFunction.Click, AddressOf prBtnFunctionClick

        _txbInput.Clear()
    End Sub


    ''' <summary>
    ''' 컨텍스트 메뉴 모든 클릭
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub prCmsAllClick(sd As Object, ea As EventArgs)
        Dim tsi As ToolStripItem = TryCast(sd, ToolStripItem)
        If tsi.Text.StartsWith("O) ") Then
            Try
                If (_ofd.ShowDialog(Me) = DialogResult.OK) Then
                    prOpenFile(_ofd.FileName)
                End If
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("P) ") Then
            Try
                prBtnFunctionClick(Nothing, Nothing)
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("C) ") Then
            Try
                WebView2_exta.ClearFrom(_panelRoot)

                _ips = Nothing
                _hdp = Nothing

                Text = MainProxy.GetVerInfo()
                _txbInput.Clear()
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("1) ") Then
            Try
                If Directory.Exists(_hdp) Then
                    Process.Start(_hdp)
                Else
                    Process.Start(_cdp)
                End If
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("2) ") Then
            Try
                If Directory.Exists(_hdp) Then
                    Dim psi As New ProcessStartInfo() With {
                        .FileName = "code",
                        .WorkingDirectory = _hdp,
                        .Arguments = $"""{_hdp}""",
                        .UseShellExecute = True,
                        .CreateNoWindow = False,
                        .WindowStyle = ProcessWindowStyle.Hidden
                    }
                    Process.Start(psi)
                Else
                End If
            Catch
                DebugTool.Log("실패")
            End Try
        ElseIf tsi.Text.StartsWith("3) ") Then
            Try
                WebView2_exta.OpenDevToolsWindow()
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("4) ") Then
            Try
                WebView2_exta.OpenTaskManagerWindow()
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("5) ") Then
            Try
                WebView2_exta.ReloadFrom()
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("S) ") Then
            Try
                AlertForm.Open(Me, "준비중")
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("X) ") Then
            Try
                _cms.Close()
            Catch
            End Try
        ElseIf tsi.Text.StartsWith("프로그램 종료") Then
            Try
                Application.Exit()
            Catch
            End Try
        End If
    End Sub


    ''' <summary>
    ''' 에러 표시하기
    ''' </summary>
    ''' <param name="msg"></param>
    Private Sub prErrorDisplay(msg As String)
        If String.IsNullOrWhiteSpace(msg) Then
            _txbInput.Clear()
        Else
            _txbInput.Text = $"[#Error: {msg}]"
        End If
    End Sub


    ''' <summary>
    ''' 클립보드에 Uri열기
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub prBtnFunctionClick(sender As Object, e As EventArgs)
        If Clipboard.ContainsFileDropList() Then
            Try
                Dim lst As StringCollection = Clipboard.GetFileDropList()
                prOpenUrl(lst(0))
            Catch
            End Try
        ElseIf Clipboard.ContainsText() Then
            Try
                prOpenUrl(Clipboard.GetText())
            Catch
            End Try
        End If
    End Sub


    ''' <summary>
    ''' 버튼 오른쪽 클릭으로 컨텍스트메뉴 열기
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub prBtnFunctionMouseDown(sd As Object, ea As MouseEventArgs)
        If ea.Button = MouseButtons.Right Then
            Dim btnRct As Rectangle = RectangleToScreen(_btnFunction.Bounds)
            Dim cmsRct As Rectangle = RectangleToScreen(_cms.Bounds)
            Dim pt As New Point(btnRct.Right - (cmsRct.Width + 4), btnRct.Top - (cmsRct.Height + 4))
            _cms.Show(pt, ToolStripDropDownDirection.Default)
            ActiveControl = _btnFunction
        End If
    End Sub
#End Region


#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 2) 기능성"
    Private Function prCheckCritical(fp As String) As Boolean
        Dim excepts As String() = {".exe", ".dll", ".cmd", ".bat", ".lnk"}
        Dim ext As String = Path.GetExtension(fp)
        Return excepts.Contains(ext)
    End Function

    ''' <summary>
    ''' 파일 열기
    ''' </summary>
    ''' <param name="fp"></param>
    Private Sub prOpenFile(fp As String)
        If File.Exists(fp) Then
            If prCheckCritical(fp) Then
                prErrorDisplay("보안상 열수없는 파일임")
                Return
            End If

            Dim uri As New Uri(fp)
            WebView2_exta.OpenFrom(_panelRoot, uri)

            _ips = fp
            _hdp = Path.GetDirectoryName(_ips)

            Text = MainProxy.GetVerInfo(_ips)
            _txbInput.Text = _ips
            _ofd.InitialDirectory = _hdp
        End If
    End Sub


    ''' <summary>
    ''' Url 열기
    ''' </summary>
    ''' <param name="url"></param>
    Private Sub prOpenUrl(url As String)
        Dim uri As New Uri(url)
        WebView2_exta.OpenFrom(_panelRoot, uri)

        _ips = url
        _hdp = Nothing

        Text = MainProxy.GetVerInfo(_ips)
        _txbInput.Text = _ips
        '_ofd.InitialDirectory = _hdp
    End Sub


    ''' <summary>
    ''' 드래그 엔터
    ''' </summary>
    ''' <param name="ea"></param>
    Protected Overrides Sub OnDragEnter(ea As DragEventArgs)
        MyBase.OnDragEnter(ea)

        ea.Effect = DragDropEffects.All
    End Sub


    ''' <summary>
    ''' 드래그 드롭
    ''' </summary>
    ''' <param name="ea"></param>
    Protected Overrides Sub OnDragDrop(ea As DragEventArgs)
        MyBase.OnDragDrop(ea)

        Dim ido As IDataObject = ea.Data
        If ido.GetDataPresent(DataFormats.FileDrop) Then
            '#File Path
            Try
                Dim fpa As String() = TryCast(ido.GetData(DataFormats.FileDrop), String())
                prOpenFile(fpa(0))
            Catch
            End Try
        ElseIf ido.GetDataPresent(DataFormats.Text) Then
            '#Url String
            Try
                Dim url As String = TryCast(ido.GetData(DataFormats.Text), String)
                prOpenUrl(url)
            Catch
            End Try
        End If
    End Sub

#End Region

End Class






