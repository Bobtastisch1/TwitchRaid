Public Class LiveStreamerAufruf
    Public Shared StreamerName As New List(Of String)

    Public Shared Sub Aufruf(ID As String)
        Dim LiveStreamerObjekt As List(Of Twitch.LiveStreamer.LiveStreamerValue) = Twitch.GetLiveStreamer.GetLiveStreamer(Convert.ToInt64(ID))

        For Each LiveStreamer In LiveStreamerObjekt
            StreamerName.Add(LiveStreamer.user_login)

            'Console.WriteLine("ID: " & LiveStreamer.id)
            'Console.WriteLine("Streamer ID: " + LiveStreamer.user_id)
            'Console.WriteLine("Streamer Name: " + LiveStreamer.user_login)
            'Console.WriteLine("Spiel ID: " + LiveStreamer.game_id)
            'Console.WriteLine("Spiel Name: " + LiveStreamer.game_name)
            'Console.WriteLine("Type: " + LiveStreamer.type)
            'Console.WriteLine("Title: " + LiveStreamer.title)
            'Console.WriteLine("Zuschauer: " & LiveStreamer.viewer_count)
            'Console.WriteLine("Startete um: " + LiveStreamer.started_at)
            'Console.WriteLine("Sprache:" + LiveStreamer.language)
            'Console.WriteLine("Thumbnail_url: " + LiveStreamer.thumbnail_url)
            'Console.WriteLine("Tags: " + LiveStreamer.tag_ids.First)
            'Console.WriteLine("18+ : " & LiveStreamer.is_mature)
            'Console.WriteLine()
        Next
    End Sub
End Class
