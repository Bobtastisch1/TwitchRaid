Public Class Stream
    Public Class StreamValue
        Public Property broadcaster_language As String
        Public Property broadcaster_login As String
        Public Property display_name As String
        Public Property game_id As Integer
        Public Property game_name As String
        Public Property id As String
        Public Property is_live As Boolean
        Public Property tag_ids As List(Of String)
        Public Property thumbnail_url As String
        Public Property title As String
        Public Property started_at As DateTime?
    End Class

    Public Class StreamList
        Public Property pagination As Object
        Public Property data As List(Of StreamValue)
    End Class

End Class
