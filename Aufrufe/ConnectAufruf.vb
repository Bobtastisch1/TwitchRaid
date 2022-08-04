Imports System.Threading.Tasks

Public Class ConnectAufruf
    Public Shared BotName As String

    Public Shared Async Sub Aufruf()

        Twitch.Connect.ConnectTwitch("irc.twitch.tv", "6667", BotName)

        If Await Connect.Connected() Then
            Await Read()
        Else
            Console.WriteLine("Nicht Verbunden")
        End If
    End Sub

    Public Shared Function RandomStreamer()
        Dim random = New Random()
        Dim randomstreamerName = Twitch.LiveStreamerAufruf.StreamerName(random.Next(0, Twitch.LiveStreamerAufruf.StreamerName.Count))

        Return randomstreamerName
    End Function

    Public Shared Async Function Read() As Task
        Dim onetime As Integer = 0
        While Await Connect.Connected
            Dim s As String = Connect.ReadLine()
            If String.IsNullOrEmpty(s) = False Then

                'Console.WriteLine(s)  'read incoming messages

                If (onetime < 1) Then
                    Connect.Message("/Raid " + RandomStreamer())

                End If
                onetime += 1
            End If
        End While
    End Function
End Class
