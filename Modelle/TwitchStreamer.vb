Public Class TwitchStreamer

    Public Class TwitchStreamerValue
        Public Property id As String
        Public Property login As String
        Public Property display_name As String
        Public Property type As String
        Public Property broadcaster_type As String
        Public Property description As String
        Public Property profile_image_url As String
        Public Property offline_image_url As String
        Public Property view_count As String
        Public Property created_at As String

    End Class

    Public Class TwitchStreamerList
        Public Property data As List(Of TwitchStreamerValue)
    End Class
End Class


