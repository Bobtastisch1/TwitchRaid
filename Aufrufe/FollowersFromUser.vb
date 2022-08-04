Public Class FollowersFromUser

    Public Shared Sub Aufruf(streamIDgiveback As Integer)
        Twitch.GetFollowersFromUser.GetFollowersFromUser(streamIDgiveback)
    End Sub

End Class
