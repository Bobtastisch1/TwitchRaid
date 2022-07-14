Imports System.Net
Imports Newtonsoft
Imports Newtonsoft.Json

Public Class GetFollowersFromUser
    Public Shared followsFromUser As New Twitch.UserFollows.UserFollowsList
    Public Shared followsfromUserValue As New List(Of Twitch.UserFollows.UserFollowsValue)
    Public Shared Endliste As List(Of String)

    Public Shared Sub GetFollowersFromUser(StreamerID As Integer)
        Dim nummber As Integer = 0
        Dim b_end As Boolean = False
        Dim pragnation As Twitch.UserFollows.Pagination = Nothing
        Dim erst As Boolean = True
        Dim List2 As New List(Of String)
        Do

            Try
                Dim req As HttpWebRequest = Nothing
                Dim Params As String = "to_id="
                Dim url As String = Nothing
                If erst = False Then
                    url = Twitch.URL.GetURL & "users/follows?" & Params.ToString & StreamerID.ToString & "&first=100" & "&after=" & pragnation.cursor.ToString
                Else
                    url = Twitch.URL.GetURL & "users/follows?" & Params.ToString & StreamerID.ToString & "&first=100"
                    erst = False
                End If

                Try
                    req = HttpWebRequest.CreateHttp(url)
                Catch ex As Exception
                    Console.WriteLine("Request Creat Error:" + ex.Message)
                End Try

                req.Method = "GET"
                req.KeepAlive = True
                req.Accept = "application/json"

                Dim token As String = Twitch.Tokenabfrage.Tokenerstellen()
                If token = Nothing Then
                    Console.WriteLine("Token Error")
                End If

                req.Headers.Add("Authorization", "Bearer " & token)
                req.Headers.Add("Client-Id", Twitch.Tokenabfrage.ClientID)

                Dim res As HttpWebResponse = Nothing
                Try
                    res = CType(req.GetResponse, HttpWebResponse)

                    If req.HaveResponse Then
                        Dim receiveStream As System.IO.Stream = res.GetResponseStream
                        Dim readStream As New System.IO.StreamReader(receiveStream, System.Text.Encoding.UTF8)
                        Dim result As String = readStream.ReadToEnd
                        receiveStream.Close()
                        readStream.Close()

                        If res.StatusCode = HttpStatusCode.OK Then
                            Try
                                followsFromUser = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Twitch.UserFollows.UserFollowsList)(result)
                                followsfromUserValue = followsFromUser.data
                                pragnation = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Twitch.UserFollows.Pagination)(followsFromUser.pagination.ToString)
                                If result.Contains("cursor") = False Then
                                    b_end = True
                                End If
                            Catch ex As Exception
                                Console.WriteLine("Error DeserializeObject: " + ex.Message)
                            End Try
                            res.Close()


                        End If
                    End If
                Catch ex As Exception
                    Console.WriteLine("Response Error: " + ex.Message)
                End Try

                If res IsNot Nothing Then
                    res.Close()
                End If

            Catch ex As Exception
                Console.WriteLine("GetStreams Error:" + ex.Message)
            End Try

            For Each x In followsfromUserValue
                List2.Add(x.from_id)
                Console.WriteLine(x.from_id)
                Console.WriteLine("Follower: " + x.from_name)
                Console.WriteLine(x.to_id)
                Console.WriteLine("Streamer: " + x.to_name)
                Console.WriteLine()
                nummber += 1
            Next
        Loop Until b_end = True
        Console.WriteLine(nummber)
        Endliste = List2
    End Sub
End Class
