Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Threading

Public Class Connect
    Private Shared Server As String = ""
    Private Shared Port As Integer = 0
    Private Shared Username As String = ""
    Private Shared Passwort As String = ""
    Private Shared InputSt As StreamReader
    Public Shared OutputSt As StreamWriter
    Private Shared TcpC As TcpClient
    Private Shared Channel As String = "#bobtastisch2"

    Public Shared Sub ConnectTwitch(_Server As String, _Port As Integer, _Username As String, _Passwort As String)
        Server = _Server
        Port = _Port
        Username = _Username
        Passwort = _Passwort

        Try
            TcpC = New TcpClient(Server, Port)
            InputSt = New StreamReader(TcpC.GetStream())
            OutputSt = New StreamWriter(TcpC.GetStream())

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Dim token As String = Twitch.Tokenabfrage.Tokenerstellen()
        If token = Nothing Then
            Console.WriteLine("Token Error")
        End If

        ' oauth:yxu0rf9awuot19moi4g59cit99dvc4

        'OutputSt.WriteLine("PASS oauth:" + token)
        OutputSt.WriteLine("PASS " + "oauth:yxu0rf9awuot19moi4g59cit99dvc4")
        OutputSt.WriteLine("NICK " + Username)
        OutputSt.WriteLine("JOIN " + Channel)
        OutputSt.Flush()

    End Sub

    Public Shared Sub Message(message As String)
        Dim channel As String = "#bobtastisch2"
        WriteText("PRIVMSG " + channel + " :" + message)

    End Sub


    Public Shared Sub WriteText(data As String)
        OutputSt.WriteLine(data)
        OutputSt.Flush()
    End Sub

    Public Shared Function ReadLine() As String
        Try
            Dim incomingData As String = InputSt.ReadLine()
            If String.IsNullOrEmpty(incomingData) = False Then
                Return incomingData
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New NullReferenceException(ex.Message)
        End Try
    End Function


    Public Shared Async Function Connected() As Task(Of Boolean)
        If IsNothing(TcpC) Or TcpC.Connected = False Then
            Return False
        Else
            Return True
        End If

    End Function
End Class
