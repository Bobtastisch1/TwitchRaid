Module Main
    Public ID As Integer
    Public TwitchStreamerName As String

    Sub Main()
        CreatePasswortFile.Textfile()
        TwitchStreamAufruf.Aufruf(TwitchStreamerName)

        'StreamAufruf.Aufruf("bobtastisch2")                    'get Livestreamer that is live and give back ID of Streamer
        FollowersFromUser.Aufruf(ID)
        'LiveStreamerAufruf.Aufruf(187244607)
        'FollowersFromUser.Aufruf(StreamAufruf.StreamIDgiveback)'get Your followers
        For Each ID In GetFollowersFromUser.Endliste
            LiveStreamerAufruf.Aufruf(ID)                       'get all streamstats  from live streamers need to be live
        Next
        Twitch.ConnectAufruf.Aufruf()
        Console.ReadLine()
    End Sub

End Module