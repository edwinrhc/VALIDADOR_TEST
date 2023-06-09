Public Class verEmpleador
    Private Sub verEmpleador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub verEmpleador_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        DgvEmpleador.Size = New Size(Me.Size.Width - 60, Me.Size.Height - 40)
    End Sub
End Class