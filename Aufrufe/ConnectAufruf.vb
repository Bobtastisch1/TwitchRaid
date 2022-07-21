Imports System.Threading.Tasks

Public Class ConnectAufruf

    Public Shared Async Sub Aufruf()

        Twitch.Connect.ConnectTwitch("irc.twitch.tv", "6667", "bobtastisch2", "pvgmqpeha7jy10hmuk9boj05jwvyfi")
        If Await Connect.Connected() Then
            Await Read()
        Else
            Console.WriteLine("Nicht Verbunden")
        End If
    End Sub

    Public Shared Async Function Read() As Task
        Dim onetime As Integer = 0
        While Await Connect.Connected
            Dim s As String = Connect.ReadLine()
            If String.IsNullOrEmpty(s) = False Then

                'Console.WriteLine(s)  'read incoming messages

                If (onetime < 1) Then
                    Connect.Message("I am a BOT")
                    Connect.Message("/Raid ")
                End If
                onetime += 1
            End If
        End While
    End Function
End Class
