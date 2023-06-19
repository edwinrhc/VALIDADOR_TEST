Imports D_VALIDADOR
Imports E_VALIDADOR
Public Class NConsultas

    Public Function BuscarObsDatosPersonales(Valor As String) As DataTable

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
    Public Function BuscarObsCargaEmpleador(Valor As String) As DataTable

        Try

            Dim Datos As New DConsultas
            Dim Tabla As New DataTable
            Tabla = Datos.ObsCargaEmpleador(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try


    End Function

    Public Function TotalObsCargaEmpleador(Valor As String) As DataTable

        Try

            Dim Datos As New DConsultas
            Dim Tabla As New DataTable
            Tabla = Datos.TotalObsCargaEmpleador(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try


    End Function


End Class
