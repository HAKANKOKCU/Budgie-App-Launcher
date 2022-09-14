Imports System.ComponentModel
Imports System.Windows.Threading

Public Class listan
    Public WithEvents listite As ListIt
    Public WithEvents iconloader As New BackgroundWorker
    Property filenametoopen As String
    Sub New(ByVal listitem As ListIt, ByVal filenametoopenVal As String)
        listite = listitem
        filenametoopen = filenametoopenVal
        REM iconloader.RunWorkerAsync()
        Dim icon = System.Drawing.Icon.ExtractAssociatedIcon(filenametoopen)
        Dim bm = icon.ToBitmap()
        icon.Dispose()
        listite.icon.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(bm.Width, bm.Height))
        bm.Dispose()
    End Sub

    Private Sub listite_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles listite.MouseUp
        Process.Start(filenametoopen)
        End
    End Sub

    Private Sub iconloader_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles iconloader.DoWork
        
    End Sub

    Private Sub iconloader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles iconloader.RunWorkerCompleted
    End Sub
End Class
