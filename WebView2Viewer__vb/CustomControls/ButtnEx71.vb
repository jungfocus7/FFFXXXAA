Imports System
Imports System.Windows.Forms


Namespace CustomControls
    Public NotInheritable Class ButtnEx71 : Inherits Button
        Private Sub prMouseDownEffect(bDown As Boolean)
            If bDown Then
                Padding = New Padding(1, 1, 0, 0)
            Else
                Padding = New Padding(0, 0, 0, 0)
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(ea As MouseEventArgs)
            MyBase.OnMouseDown(ea)

            prMouseDownEffect(True)
        End Sub

        Protected Overrides Sub OnMouseUp(ea As MouseEventArgs)
            MyBase.OnMouseUp(ea)

            prMouseDownEffect(False)
        End Sub

        Protected Overrides Sub OnLostFocus(ea As EventArgs)
            MyBase.OnLostFocus(ea)

            prMouseDownEffect(False)
        End Sub
    End Class
End Namespace