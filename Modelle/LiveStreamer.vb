Public Class LiveStreamer
    Public Class LiveStreamerValue
        Public Property id As String
        Public Property user_id As String
        Public Property user_login As String
        Public Property user_name As String
        Public Property game_id As String
        Public Property game_name As String
        Public Property type As String
        Public Property title As String
        Public Property viewer_count As Integer
        Public Property started_at As String
        Public Property language As String
        Public Property thumbnail_url As String
        Public Property tag_ids As List(Of String)
        Public Property is_mature As Boolean
    End Class

    Public Class LiveStreamList
        Public Property pagination As Object
        Public Property data As List(Of LiveStreamerValue)
    End Class
End Class
