﻿Imports System.IO

Public Class CreatePasswortFile
    Public Shared file As System.IO.StreamWriter
    Public Shared Sub Textfile()
        If My.Computer.FileSystem.FileExists("Passwort.txt") = False Then
            file = My.Computer.FileSystem.OpenTextFileWriter("Passwort.txt", True)
            file.WriteLine("ClientID: ")
            file.WriteLine("ClientSecret: ")
            file.WriteLine("oauth: ")
            file.WriteLine("Chatroom: ")
            file.WriteLine("BotName: ")
            file.Close()
        End If
        Readfile()
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
                If number = 0 Then Tokenabfrage.ClientID = value
                If number = 1 Then Tokenabfrage.ClientSecret = value
                If number = 2 Then Connect.oauth = value
                If number = 3 Then Connect.Channel = value
                If number = 4 Then ConnectAufruf.BotName = value
                number += 1
                End If
        Loop
    End Sub
End Class
