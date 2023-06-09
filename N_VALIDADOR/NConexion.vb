Public Class NConexion

    Public Function ProbarConexion() As Boolean

        Dim capaDatos As New D_VALIDADOR.Conexion

        Return capaDatos.ValidarConexion()


    End Function

End Class
