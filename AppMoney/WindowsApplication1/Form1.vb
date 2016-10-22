Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Net.Mail

Public Class Form1  
    Private Sub WatchForNewProcesses()
        ' Create a new Process watcher
        Dim watcher As New ProcessCreationWatcher
        AddHandler watcher.ProcessCreated, AddressOf NewProcessHandler
        watcher.Start(1)

    End Sub
    Private Sub NewProcessHandler(ByVal sender As Object, ByVal e As ProcessEventArgs)
        ' Get the process ID
        Dim procID As Integer = e.ProcessID
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WatchForNewProcesses()

    End Sub
End Class
