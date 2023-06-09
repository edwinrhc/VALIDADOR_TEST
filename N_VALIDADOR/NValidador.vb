Imports System.Reflection.Emit
Imports D_VALIDADOR
Imports E_VALIDADOR


Public Class NValidador


    Public Function Insertar(Obj As Validador, nombreTablas As String()) As Long
        Dim numCar As Long

        Try
            Dim Datos As New DValidador
            numCar = Datos.Insertar(Obj, nombreTablas)
            Console.WriteLine("En la capa negocio nuevo número de carga es: " + numCar.ToString())
            Return numCar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0

        End Try
    End Function

    Public Function Buscar(Valor As String) As DataTable

        Try

            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.Buscar(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try


    End Function

    Public Function BuscarPorEstado(N_Estado As Integer) As DataTable

        Try

            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.BuscarPorEstado(N_Estado)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try


    End Function

    Public Function Listar50Ultimos() As DataTable
        Try
            Dim Datos As New DValidador
            Return Datos.Listar50Ultimos()
        Catch ex As Exception
            Throw New Exception("Error al buscar el registro: " + ex.Message)
        End Try
    End Function

    Public Function TipoEmpleadores() As DataTable
        Try
            Dim Datos As New DValidador
            Return Datos.TipoEmpleadores()
        Catch ex As Exception
            Throw New Exception("Error al buscar el registro: " + ex.Message)
        End Try
    End Function

    Public Function BuscarResumenCargaEmpresas(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_CARGA_EMPRESA(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function BuscarResultadoCargaRealizada(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESULTADO_CARGA_REALIZADA(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
        Return Nothing
        End Try
    End Function

    Public Function BuscarResumenTipoErrorEmpleadores(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_TIPOERROR_EMPLEADORES(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function BuscarResumenTipoErrorTrabajadores(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_TIPOERROR_TRABAJADORES(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function BuscarResumenTipoErrorRemuneraciones(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_TIPOERROR_REMUNERACIONES(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function BuscarResumenTipoErrorRemuneracionesDuplicados(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_TIPOERROR_REMUNERACIONES_DUPLICADOS(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function BuscarResumenTipoErrorTrabajadoresIntegridad(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_TIPOERROR_TRABAJADORES_INTEGRIDAD(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function BuscarResumenTipoErrorRemuneracionesIntegridad(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_TIPOERROR_REMUNERACIONES_INTEGRIDAD(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function BuscarResumenTipoDocumentoTrabajador(Valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.RESUMEN_TIPODOCUMENTO_TRABAJADOR(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function EstadodeCarga(valor As String) As DataTable
        Try
            Dim Datos As New DValidador
            Dim Tabla As New DataTable
            Tabla = Datos.ESTADO_CARGA(valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try


    End Function
End Class
