Imports System.Net
Imports Newtonsoft
Imports Newtonsoft.Json

Public Class GetStreams

    Public Shared Function GetStreamer(StreamerName As String, Live As Boolean) As List(Of Twitch.Stream.StreamValue)

        Try
            Dim req As HttpWebRequest = Nothing
            Dim Params As String = "query="
            Dim url As String = Twitch.URL.GetURL & "search/channels?" & Params.ToString & StreamerName.ToString & "&live_only=" & Live.ToString

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
                        Dim stream As New Twitch.Stream.StreamList
                        Dim streamValues As New List(Of Twitch.Stream.StreamValue)
                        Try
                            stream = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Twitch.Stream.StreamList)(result)

                            streamValues = stream.data

                        Catch ex As Exception
                            Console.WriteLine("Error DeserializeObject: " + ex.Message)
                        End Try
                        res.Close()

                        Return streamValues
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine("Response Error: " + ex.Message)
            End Try

            If res IsNot Nothing Then
                res.Close()
            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine("GetStreams Error:" + ex.Message)
        End Try
        Return Nothing
    End Function
End Class
