Public Class FollowersFromUser

    Public Shared Sub Aufruf(streamIDgiveback As Integer)
        Twitch.GetFollowersFromUser.GetFollowersFromUser(streamIDgiveback)
        'For Each x In GetFollowersFromUser.Endliste
        '    Console.WriteLine(x)
        'Next



    End Sub

End Class
