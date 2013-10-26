Imports System.Net

Public Class Downloader

    Public WithEvents downloader As WebClient

    Private Sub downloader_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles downloader.DownloadFileCompleted
        If MsgBox("Download finished!", MsgBoxStyle.Information, "Finished!") = MsgBoxResult.Ok Then
            Me.Close()
        End If

        Me.ProgressBar1.Value = 100
        Me.Text = "Downloader - 100 %"
    End Sub

    Private Sub downloader_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
        Me.Label2.Text = "Status: " & e.BytesReceived & " von " & e.TotalBytesToReceive & " Bytes"
        Me.Text = "Downloader - " & e.ProgressPercentage & " %"
    End Sub

    Private Sub Downloader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = "Title: " & Form1.Label3.Text
        downloader = New WebClient
        downloader.DownloadFileAsync(New Uri(Form1.RichTextBox1.Text), Form1.SaveFileDialog1.FileName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        downloader.CancelAsync()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox("ToDo!")
    End Sub
End Class