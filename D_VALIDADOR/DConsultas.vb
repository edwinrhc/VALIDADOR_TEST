Option Explicit On
Imports System.IO
Imports System.Windows.Forms
Imports E_VALIDADOR

Imports Oracle.ManagedDataAccess.Client

Public Class DConsultas

#Region "Reporte"


    Public Function ObsDatosPersonales(Valor As Long) As DataTable


        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "SELECT * FROM VALIDADOR_TEST.TRAB_OBSERVADOS_CASUISTICA  WHERE  NROCARGA  = :numCar"
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor

            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el registro: " + ex.Message)
        End Try
        Return dtResultado
    End Function


#End Region




End Class
