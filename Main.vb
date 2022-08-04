Module Main

    Sub Main()
        CreatePasswortFile.Textfile()

        'StreamAufruf.Aufruf("wubbl0rz")                    'get Livestreamer that is live and give back ID of Streamer
        FollowersFromUser.Aufruf(187244607)
        'LiveStreamerAufruf.Aufruf(231641204)
        'FollowersFromUser.Aufruf(StreamAufruf.StreamIDgiveback)       'get Bob followers
        For Each ID In GetFollowersFromUser.Endliste
            LiveStreamerAufruf.Aufruf(ID)              'get all streamstats  from live streamers need to be live
        Next
        Twitch.ConnectAufruf.Aufruf()
        Console.ReadLine()
    End Sub

End Module