Public Class TwitchStreamAufruf

    Public Shared Sub Aufruf(TwitchStreamerName)
        Dim TwitchStreamer As List(Of Twitch.TwitchStreamer.TwitchStreamerValue) = Twitch.GetTwitchStreamer.GetTwitchStreamer(TwitchStreamerName)
        For Each TwitchStreamerID In TwitchStreamer
            ID = TwitchStreamerID.id
        Next
    End Sub
End Class
