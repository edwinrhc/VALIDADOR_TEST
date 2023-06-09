Imports D_VALIDADOR
Imports E_VALIDADOR
Public Class NConsultas

    Public Function Buscar(Valor As String) As DataTable

        Try

            Dim Datos As New DConsultas
            Dim Tabla As New DataTable
            Tabla = Datos.ObsDatosPersonales(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try


    End Function


End Class
