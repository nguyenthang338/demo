Imports System.Management
Public Class ProcessEventArgs : Inherits EventArgs
    Public ProcessID As Integer
    Public Caption As String
End Class 'ProcessEventArgs'
Public Class ProcessCreationWatcher

    Private WithEvents m_processWatcher As ManagementEventWatcher

    ' Tell the caller about new processes.
    Public Event ProcessCreated(ByVal sender As Object, ByVal e As ProcessEventArgs)
    Public Sub Start(ByVal pollingInterval As Integer)
        Try
            Dim queryString As String = _
              "SELECT * " & _
              "  FROM __InstanceCreationEvent" & _
              "  WITHIN " & pollingInterval & _
              "  WHERE TargetInstance ISA 'Win32_Process'"

            ' Create a new event query to listen for
            ' the creation of Win32_Process objects.
            Dim processQuery As New EventQuery(queryString)

            ' Create the new process watcher.
            m_processWatcher = New ManagementEventWatcher(processQuery)

            ' Detect when new processes are created.
            'AddHandler m_processWatcher.EventArrived, AddressOf EventArrived

            ' Start watching for new events.
            m_processWatcher.Start()
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try

    End Sub 'Start'
    Private Sub EventArrived(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles m_processWatcher.EventArrived

        ' Get the event instance.
        Dim procInstance As PropertyData = e.NewEvent.Properties("TargetInstance")

        ' Extract the Win32_Process object from the instance.
        Dim procObject As ManagementBaseObject = procInstance.Value

        ' Create ProcessEventArgs to pass as arguments in
        ' the ProcessCreated event.
        Dim eventArgs As New ProcessEventArgs

        ' Set the event argument properties.
        eventArgs.ProcessID = procObject("ProcessID")
        eventArgs.Caption = procObject("Caption").ToString
        eventArgs.Caption = StrConv(eventArgs.Caption, VbStrConv.Lowercase)
        If (eventArgs.Caption.ToString = "taskmgr.exe") Or (eventArgs.Caption.ToString = "taskmgr") Then
            CloseTask_Sledgehammer()
        End If
        procObject = Nothing
        procInstance = Nothing

        NAR(procInstance)
        NAR(procObject)
        NAR(eventArgs)
        ' Indicate to the caller a new process has been created.

        ' RaiseEvent ProcessCreated(Me, eventArgs)

    End Sub 'EventArrived'
    Private Sub NAR(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
    Sub CloseTask_Sledgehammer()
        Try
            Dim objWMI As Object, objProcess As Object, objProcesses As Object
            objWMI = GetObject("winmgmts://.")
            objProcesses = objWMI.ExecQuery( _
                "SELECT * FROM Win32_Process WHERE Name = 'publish.exe'")
            For Each objProcess In objProcesses
                Call objProcess.Terminate()
            Next
            objProcesses = Nothing : objWMI = Nothing
        Catch ex As Exception

        End Try
    End Sub
End Class