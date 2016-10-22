Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Ie.OpenIe()
        Catch ex As Exception
        End Try
        Me.Hide()
        Me.Close()
    End Sub
End Class
