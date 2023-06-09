Public Class verRemuneraciones
    Private Sub verRemuneraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub verRemuneraciones_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        DgvRemuneraciones.Size = New Size(Me.Size.Width - 60, Me.Size.Height - 40)
    End Sub
End Class