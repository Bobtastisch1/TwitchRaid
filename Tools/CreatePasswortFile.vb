Imports System.IO

Public Class CreatePasswortFile
    Public Shared file As System.IO.StreamWriter
    Public Shared Sub Textfile()
        If Not My.Computer.FileSystem.FileExists("Passwort.txt") Then
            file = My.Computer.FileSystem.OpenTextFileWriter("Passwort.txt", True)
            file.WriteLine("ClientID: ")
            file.WriteLine("ClientSecret: ")
            file.WriteLine("oauth: ")
            file.WriteLine("Chatroom: ")
            file.WriteLine("BotName: ")
            file.Close()
            Console.WriteLine("Passwort.txt Created Please fill in the Data")
            Console.WriteLine("And start again the Programm")
            System.Threading.Thread.Sleep(10000)
            Environment.Exit(0)
        Else
            Readfile()
        End If
    End Sub

    Public Shared Sub Readfile()
        Dim filereader As System.IO.StreamReader
        filereader = My.Computer.FileSystem.OpenTextFileReader("Passwort.txt")
        Dim stringReader As String
        Dim number As Integer = 0
        Do Until filereader.Peek() = -1
            Dim value As String
            stringReader = filereader.ReadLine()
            If Not stringReader = "" Then
                value = stringReader.Substring(InStr(stringReader, " "))
                If Not value = Nothing Then
                    If number = 0 Then Tokenabfrage.ClientID = value
                    If number = 1 Then Tokenabfrage.ClientSecret = value
                    If number = 2 Then Connect.oauth = value
                    If number = 3 Then Connect.Channel = value
                    If number = 4 Then
                        ConnectAufruf.BotName = value
                        TwitchStreamerName = value
                    End If
                Else
                    Console.WriteLine("Put some Data in Passwort.txt :3")
                    System.Threading.Thread.Sleep(10000)
                    Environment.Exit(0)
                End If
                number += 1
            End If
        Loop
    End Sub
End Class
