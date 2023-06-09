Public Class VerTrabajador


    Private Sub VerTrabajador_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        DgvTrabajador.Size = New Size(Me.Size.Width - 60, Me.Size.Height - 40)
    End Sub

    Private Sub VerTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class