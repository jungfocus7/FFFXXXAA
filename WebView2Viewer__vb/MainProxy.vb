Public NotInheritable Class MainProxy
    Private Sub New()
    End Sub


    ''' <summary>
    ''' ???
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetVerInfo(Optional ics As String = Nothing) As String
        Dim dvi As String = "WebView2Viewer__vb"
        Dim vnb As String = "v1.5.3"
        If Not String.IsNullOrWhiteSpace(ics) Then
            Return $"[ {dvi},  {vnb} ]   ""{ics}"""
        Else
            Return $"[ {dvi},  {vnb} ]"
        End If
    End Function
End Class

