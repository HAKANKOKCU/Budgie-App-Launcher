Class MainWindow 

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        searchtb.Focus()
        Me.Top -= 100

    End Sub

    Private Sub searchtb_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles searchtb.TextChanged
        findapps()
    End Sub
    Sub findapps()
        Dim heg As Integer = 150
        cont.Children.Clear()
        Try
            For Each pf As String In My.Computer.FileSystem.GetDirectories("C:\Program Files")
                Try
                    For Each app As String In My.Computer.FileSystem.GetFiles(pf)
                        Dim appname = app.Replace("C:\Program Files" & "\", "")
                        Dim inf As New IO.FileInfo(app)
                        If inf.Extension.ToLower = ".exe" Or inf.Extension.ToLower = ".lnk" Then
                            If Not appname.Contains("desktop.ini") Then
                                If appname.ToLower.Contains(searchtb.Text.ToLower) Then
                                    addicon(appname, app)
                                    If heg < 400 Then
                                        heg += 40
                                    End If
                                End If
                            End If
                        End If
                    Next
                Catch
                End Try
            Next
        Catch ex As Exception

        End Try
        For Each app As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Programs)
            Dim appname = app.Replace(My.Computer.FileSystem.SpecialDirectories.Programs & "\", "")
            Dim inf As New IO.FileInfo(app)
            If inf.Extension.ToLower = ".exe" Or inf.Extension.ToLower = ".lnk" Then
                If Not appname.Contains("desktop.ini") Then
                    If appname.ToLower.Contains(searchtb.Text.ToLower) Then
                        addicon(appname, app)
                        If heg < 300 Then
                            heg += 40
                        End If
                    End If
                End If
            End If
        Next
        If Not My.Computer.FileSystem.SpecialDirectories.ProgramFiles = "C:\Program Files" Then
            For Each pf As String In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.SpecialDirectories.ProgramFiles)
                Try
                    For Each app As String In My.Computer.FileSystem.GetFiles(pf)
                        Dim appname = app.Replace(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\", "")
                        Dim inf As New IO.FileInfo(app)
                        If inf.Extension.ToLower = ".exe" Or inf.Extension.ToLower = ".lnk" Then
                            If Not appname.Contains("desktop.ini") Then
                                If appname.ToLower.Contains(searchtb.Text.ToLower) Then
                                    addicon(appname, app)
                                    If heg < 300 Then
                                        heg += 40
                                    End If
                                End If
                            End If
                        End If
                    Next
                Catch
                End Try
            Next
        End If
        Me.Height = heg
    End Sub

    Private Sub searchtb_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles searchtb.KeyUp
        If e.Key = Key.Enter Then
            Try
                Process.Start(searchtb.Text)
                End
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Window_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MyBase.KeyUp
        If e.Key = Key.Escape Then
            End
        End If
    End Sub

    Sub addicon(ByVal name As String, ByVal path As String)
        If cont.Children.Count < 9 Then
            Dim item As New ListIt
            Dim listan As New listan(item, path)
            item.name.Content = name.Replace(".lnk", "").Replace(".exe", "")
            cont.Children.Add(item)
        End If
    End Sub
End Class
