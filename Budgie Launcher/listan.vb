Public Class listan
    Public WithEvents listite As ListIt
    Property filenametoopen As String
    Sub New(ByVal listitem As ListIt)
        listite = listitem
    End Sub

    Private Sub listite_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles listite.MouseUp
        Process.Start(filenametoopen)
        End
    End Sub
End Class
