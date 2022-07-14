Public Class UserFollows
    Public Class UserFollowsValue
        Public Property followed_at As String
        Public Property from_id As String
        Public Property from_login As String
        Public Property from_name As String
        Public Property to_id As String
        Public Property to_login As String
        Public Property to_name As String
    End Class

    Public Class UserFollowsList
        Public Property pagination As Object
        Public Property total As Integer
        Public Property data As List(Of UserFollowsValue)
    End Class

    Public Class Pagination
        Public Property cursor As String
    End Class

End Class
