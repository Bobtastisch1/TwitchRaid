Public Class StreamAufruf
    Public Shared StreamIDgiveback As Integer

    Public Shared Sub Aufruf(StreamerName2 As String)
        Dim streamername As String = StreamerName2
        Dim Live As Boolean = True
        Dim StreamerObject As List(Of Twitch.Stream.StreamValue) = Twitch.GetStreams.GetStreamer(streamername, Live)
        For Each StreamerOJ In StreamerObject
            If StreamerOJ.display_name = streamername Then
                StreamIDgiveback = StreamerOJ.id
            End If
            Console.WriteLine("Sprache: " + StreamerOJ.broadcaster_language)
            Console.WriteLine("Streamer Login: " + StreamerOJ.broadcaster_login)
            Console.WriteLine("Streamer Name: " + StreamerOJ.display_name)
            Console.WriteLine("Spiel ID: " & StreamerOJ.game_id)
            Console.WriteLine("Spiel Name: " + StreamerOJ.game_name)
            Console.WriteLine("ID: " + StreamerOJ.id)
            Console.WriteLine("Live: " & StreamerOJ.is_live)
            Console.WriteLine("Tags: " & StreamerOJ.tag_ids.Count)
            Console.WriteLine("Profile Bild: " + StreamerOJ.thumbnail_url)
            Console.WriteLine("Titel:" + StreamerOJ.title)
            Console.WriteLine("Started um: " & StreamerOJ.started_at)
            Console.WriteLine()
        Next
    End Sub
End Class
