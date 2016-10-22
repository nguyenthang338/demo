Module Ie
    Sub OpenIe()      
        ' Open popup
        Dim count As Integer
        count = 1
        While (count <= 6)
            count = count + 1
            Ie()
            IE_Sledgehammer()
        End While
        IE_Sledgehammer()
    End Sub
    Sub Ie()
        Dim ie As Object
        Dim x As Object
        Dim arrayLink As String
        Dim random As New Random

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Windows\Software\Url.txt")
        Dim stringReader As String
        Do
            stringReader = fileReader.ReadLine

            Try
                If String.IsNullOrEmpty(stringReader) Then
                    'nothing
                Else

                    x = CreateObject("wscript.shell")
                    ie = CreateObject("InternetExplorer.Application")
                    arrayLink = stringReader.ToString
                    ie.Navigate(arrayLink)
                    ie.Toolbar = 1
                    ie.StatusBar = 1
                    ie.Height = Screen.PrimaryScreen.Bounds.Height
                    ie.Width = Screen.PrimaryScreen.Bounds.Width
                    ie.Top = 0
                    ie.Left = 0
                    ie.Visible = 1

                    Dim Rand As New Random()
                    Dim time As Integer
                    Dim a, b As Integer
                    a = random.Next(100, 700)
                    b = random.Next(10, 800)
                    time = Rand.Next(17000, 22000)
                    Threading.Thread.Sleep(time)

                    'AuTo click Random 
                    Dim number As Integer
                    number = Rand.Next(1, 4)
                    If (number = 1) Then
                        ie.Document.elementFromPoint(a, b).Click()
                        Threading.Thread.Sleep(Rand.Next(7000, 10000))
                    End If

                End If
            Catch ex As Exception
            End Try
          
        Loop Until stringReader Is Nothing

        
    End Sub 
    Sub IE_Sledgehammer()
        Try
            Dim objWMI As Object, objProcess As Object, objProcesses As Object
            objWMI = GetObject("winmgmts://.")
            objProcesses = objWMI.ExecQuery( _
                "SELECT * FROM Win32_Process WHERE Name = 'iexplore.exe'")
            For Each objProcess In objProcesses
                Call objProcess.Terminate()
            Next
            objProcesses = Nothing : objWMI = Nothing
        Catch ex As Exception

        End Try

    End Sub
End Module
