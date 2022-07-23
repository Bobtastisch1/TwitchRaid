Imports System.Net


Public Class Tokenabfrage
    Public Const ClientID As String = "4x0y96rzul3zcdv4fa8pc084ug2jct"
    Private Const ClientSecret As String = "pvgmqpeha7jy10hmuk9boj05jwvyfi"
    Private Shared expires As Integer = 0
    Private Shared token As Token

    Public Shared Function Tokenerstellen()

        If token Is Nothing Or expires < 5000 Then
            Try
                Dim URL = "https://id.twitch.tv/oauth2/token"
                Dim req As HttpWebRequest = WebRequest.CreateHttp(URL)
                req.Method = "POST"
                req.ContentType = "application/x-www-form-urlencoded"
                req.Accept = "application/json"
                req.Headers.Add("cache-control", "no-cache")
                Dim data As Byte() = System.Text.Encoding.ASCII.GetBytes(GetBody())
                req.ContentLength = data.Length
                Using stream As IO.Stream = req.GetRequestStream
                    stream.Write(data, 0, data.Length)
                End Using
                Dim response As HttpWebResponse = req.GetResponse()
                Dim result As String = New System.IO.StreamReader(response.GetResponseStream).ReadToEnd
                token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(result)
                expires = token.expires_in
                Return token.access_token
            Catch ex As Exception
                Console.WriteLine("Token abfrage Error:" + ex.Message)
            End Try
        End If
        Return token.access_token
    End Function

    Public Shared Function GetBody()
        Dim params As String

        params = "client_id=4x0y96rzul3zcdv4fa8pc084ug2jct&client_secret=pvgmqpeha7jy10hmuk9boj05jwvyfi&grant_type=client_credentials"
        Return params
    End Function

End Class
