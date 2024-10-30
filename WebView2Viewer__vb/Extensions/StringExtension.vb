Imports System.Runtime.CompilerServices


Namespace Extensions
    Public Module StringExtension
        ''' <summary>
        ''' 문자열이 없으면 기본값으로 리턴
        ''' </summary>
        ''' <param name="txt"></param>
        ''' <param name="dv"></param>
        ''' <returns></returns>
        <Extension()>
        Public Function GetDefault(txt As String, Optional dv As String = Nothing) As String
            If String.IsNullOrWhiteSpace(txt) Then
                If String.IsNullOrWhiteSpace(dv) Then
                    Return String.Empty
                Else
                    Return dv
                End If
            Else
                Return txt
            End If
        End Function
    End Module
End Namespace
