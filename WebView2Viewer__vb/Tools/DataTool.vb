Imports System
Imports System.IO


Public NotInheritable Class DataTool
    Private Sub New()
    End Sub


    'Private Shared _sddp As String
    'Private Shared Function prGetSaveDataDirectoryPath() As String
    '    If _sddp Is Nothing Then
    '        _sddp = $"{MainProxy.AppDirPath}\SaveData"
    '        Dir()
    '        'Pat
    '    End If
    '    Return _sddp
    'End Function

    Private Shared _sddp As String
    Private Shared Function prGetSaveHtmpFilePath() As String
        If _sddp Is Nothing Then
            _sddp = String.Format("{0}\SaveData\", MainProxy.AppDirPath)
            If Not Directory.Exists(_sddp) Then
                Directory.CreateDirectory(_sddp)
            End If
        End If

        Dim fnm As String = String.Format("{0}.txt", Date.Now.ToString("yyMMddHHmmssfff"))
        Dim hfp As String = Path.Combine(_sddp, fnm)
        Return hfp
    End Function
    Public Shared Sub SaveHtmlText(txt As String)
        Dim sddp As String = prGetSaveHtmpFilePath()
        File.WriteAllText(sddp, txt)
    End Sub

End Class
