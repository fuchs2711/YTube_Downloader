Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.Visible = False
        ComboBox1.Visible = False
        ComboBox2.Visible = False
        Button2.Visible = False
        RichTextBox1.Visible = False
        WebBrowser1.Visible = False

        ComboBox3.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not TextBox1.Text.StartsWith("http://www.youtube.com/watch?v=") Then
            MessageBox.Show("Your YouTube URL has to look like this:" & vbNewLine & "http://www.youtube.com/watch?v=BXgMykZWaWE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            GetVideoNShit()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ComboBox1.SelectedIndex = ComboBox2.SelectedIndex
        RichTextBox1.Text = ComboBox1.SelectedItem.ToString

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ComboBox2.SelectedItem = ComboBox3.SelectedItem
            ComboBox1.SelectedIndex = ComboBox2.SelectedIndex
            RichTextBox1.Text = ComboBox1.SelectedItem.ToString

            If ComboBox3.SelectedItem.ToString.Contains("FLV") Then
                SaveFileDialog1.DefaultExt = "flv"
                SaveFileDialog1.Filter = "FLV file (*.flv)|*.flv"

            ElseIf ComboBox3.SelectedItem.ToString.Contains("3GP") Then
                SaveFileDialog1.DefaultExt = "3gp"
                SaveFileDialog1.Filter = "3GP file (*.3gp)|*.3gp"

            ElseIf ComboBox3.SelectedItem.ToString.Contains("MP4") Then
                SaveFileDialog1.DefaultExt = "mp4"
                SaveFileDialog1.Filter = "MP4 file (*.mp4)|*.mp4"

            ElseIf ComboBox3.SelectedItem.ToString.Contains("WebM") Then
                SaveFileDialog1.DefaultExt = "webm"
                SaveFileDialog1.Filter = "WebM file (*.webm)|*.webm"
            End If

            SaveFileDialog1.FileName = Label3.Text
            SaveFileDialog1.InitialDirectory = "C:\"
            SaveFileDialog1.Title = "Save Video"
            SaveFileDialog1.CheckPathExists = True
            SaveFileDialog1.FilterIndex = 1
            SaveFileDialog1.RestoreDirectory = False

            If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
                Downloader.Show()
                'TextBox1.Text = saveFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox("Something went wrong!")
        End Try
    End Sub

    Public Sub GetVideoNShit()
        Try
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()

            WebBrowser1.Navigate(TextBox1.Text)

            Dim t As List(Of String) = GetAvailableYoutubeDownloadLinks(TextBox1.Text)

            'bs.Navigate(t.Item(0).ToString)

            t.ForEach(AddressOf ComboBox1.Items.Add)

            For Each sender In ComboBox1.Items
                If sender.ToString.Contains("&itag=5") Then
                    ComboBox2.Items.Add("FLV-240p")
                ElseIf sender.ToString.Contains("&itag=6") Then
                    ComboBox2.Items.Add("FLV-270p")
                ElseIf sender.ToString.Contains("&itag=13") Then
                    ComboBox2.Items.Add("3GP--")
                ElseIf sender.ToString.Contains("&itag=17") Then
                    ComboBox2.Items.Add("3GP-144p")
                ElseIf sender.ToString.Contains("&itag=18") Then
                    ComboBox2.Items.Add("MP4-270p/360p")
                ElseIf sender.ToString.Contains("&itag=22") Then
                    ComboBox2.Items.Add("MP4-720p")
                ElseIf sender.ToString.Contains("&itag=34") Then
                    ComboBox2.Items.Add("FLV-360p")
                ElseIf sender.ToString.Contains("&itag=35") Then
                    ComboBox2.Items.Add("FLV-480p")
                ElseIf sender.ToString.Contains("&itag=36") Then
                    ComboBox2.Items.Add("3GP-240p")
                ElseIf sender.ToString.Contains("&itag=37") Then
                    ComboBox2.Items.Add("MP4-1080p")
                ElseIf sender.ToString.Contains("&itag=38") Then
                    ComboBox2.Items.Add("MP4-3072p")
                ElseIf sender.ToString.Contains("&itag=43") Then
                    ComboBox2.Items.Add("WebM-360p")
                ElseIf sender.ToString.Contains("&itag=44") Then
                    ComboBox2.Items.Add("WebM-480p")
                ElseIf sender.ToString.Contains("&itag=45") Then
                    ComboBox2.Items.Add("WebM-720p")
                ElseIf sender.ToString.Contains("&itag=46") Then
                    ComboBox2.Items.Add("WebM-1080p")
                ElseIf sender.ToString.Contains("&itag=82") Then
                    ComboBox2.Items.Add("MP4-360p")
                ElseIf sender.ToString.Contains("&itag=83") Then
                    ComboBox2.Items.Add("MP4-240p")
                ElseIf sender.ToString.Contains("&itag=84") Then
                    ComboBox2.Items.Add("MP4-720p")
                ElseIf sender.ToString.Contains("&itag=85") Then
                    ComboBox2.Items.Add("MP4-520p")
                ElseIf sender.ToString.Contains("&itag=100") Then
                    ComboBox2.Items.Add("WebM-360p")
                ElseIf sender.ToString.Contains("&itag=101") Then
                    ComboBox2.Items.Add("WebM-360p")
                ElseIf sender.ToString.Contains("&itag=102") Then
                    ComboBox2.Items.Add("WebM-720p")
                ElseIf sender.ToString.Contains("&itag=120") Then
                    ComboBox2.Items.Add("FLV-720p")
                ElseIf sender.ToString.Contains("&itag=133") Then
                    ComboBox2.Items.Add("MP4-240p")
                ElseIf sender.ToString.Contains("&itag=134") Then
                    ComboBox2.Items.Add("MP4-360p")
                ElseIf sender.ToString.Contains("&itag=135") Then
                    ComboBox2.Items.Add("MP4-480p")
                ElseIf sender.ToString.Contains("&itag=136") Then
                    ComboBox2.Items.Add("MP4-720p")
                ElseIf sender.ToString.Contains("&itag=137") Then
                    ComboBox2.Items.Add("MP4-1080p")
                ElseIf sender.ToString.Contains("&itag=139") Then
                    ComboBox2.Items.Add("MP4-low")
                ElseIf sender.ToString.Contains("&itag=140") Then
                    ComboBox2.Items.Add("MP4-medium")
                ElseIf sender.ToString.Contains("&itag=141") Then
                    ComboBox2.Items.Add("MP4-high")
                ElseIf sender.ToString.Contains("&itag=160") Then
                    ComboBox2.Items.Add("MP4-144p")
                Else
                    ComboBox2.Items.Add(sender)
                End If
            Next


            For Each sender In ComboBox2.Items
                ComboBox3.Items.Add(sender)
            Next

            ComboBox3.Sorted = True

            Dim videoID() As String
            videoID = TextBox1.Text.Split("=")

            PictureBox1.ImageLocation = "http://i1.ytimg.com/vi/" & videoID(1) & "/hqdefault.jpg"

            If ComboBox3.Items.Contains("http://") Then
                GetVideoNShit()
            End If

            ComboBox3.SelectedIndex = 0

            ComboBox3.Enabled = True
            Button3.Enabled = True
        Catch ex As Exception
            Me.Text = "Something went wrong!"
        End Try
    End Sub

    Public Function GetAvailableYoutubeDownloadLinks(ByVal _url As String) As List(Of String)
        Try
            Dim Downloader As New Net.WebClient
            Dim arrayURL As New List(Of String)


            Dim Stream As String = Downloader.DownloadString(_url)
            Stream = Stream.Substring(Stream.IndexOf("url_encoded_fmt_stream_map"))


            While Stream.Contains("fallback_host=")

                Dim part1 As String = Stream.Substring(Stream.IndexOf("url=") + 4)
                part1 = part1.Remove(part1.IndexOf("\")) '<----- backslash ersetzten durch ein normales backslash
                If part1.Contains(",") Then
                    part1 = part1.Remove(part1.IndexOf(","))
                End If

                Dim part2 As String = Stream.Substring(Stream.IndexOf("fallback_host=") + 14)
                part2 = part2.Remove(part2.IndexOf("\")) '<----- backslash ersetzten durch ein normales backslash
                If part2.Contains(",") Then
                    part2 = part2.Remove(part2.IndexOf(","))
                End If

                Dim part3 As String = Stream.Substring(Stream.IndexOf("sig=") + 4)
                part3 = part3.Remove(part3.IndexOf("\")) '<----- backslash ersetzten durch ein normales backslash
                If part3.Contains(",") Then
                    part3 = part3.Remove(part3.IndexOf(","))
                End If

                Dim PatternURL As String = String.Format("{0}&fallback_host={1}&signature={2}", part1, part2, part3)
                Dim FinalURL As String = Web.HttpUtility.UrlDecode(PatternURL)

                If FinalURL.StartsWith("http://") Then
                    arrayURL.Add(FinalURL)
                End If

                Stream = Stream.Replace("url=" & part1, "").Replace("fallback_host=" & part2, "").Replace("sig=" & part3, "")

            End While

            Return arrayURL
        Catch ex As Exception
            MsgBox("Something went wrong!")
        End Try
    End Function


    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If WebBrowser1.DocumentTitle.Contains("YouTube") Then
            Label3.Text = WebBrowser1.DocumentTitle
            Label3.Text = Label3.Text.Replace(" - YouTube", "")
            WebBrowser1.Navigate("about:blank")
            Me.Text = "YT Downloader | " & Label3.Text
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'MsgBox("ToDo!" & vbNewLine & vbNewLine & vbNewLine & vbNewLine & "YT Downloader by Fuzi23")
        About.Show()
    End Sub
End Class
