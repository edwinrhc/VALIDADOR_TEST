Imports Oracle.ManagedDataAccess.Client




Public Class Conexion

    Private _Base As String
    Private _Servidor As String
    Private _Usuario As String
    Private _Clave As String
    Private _Seguridad As Boolean = True


    Public conn As OracleConnection




    Public Property Base As String
        Get
            Return _Base
        End Get
        Set(value As String)
            _Base = value
        End Set
    End Property

    Public Property Servidor As String
        Get
            Return _Servidor
        End Get
        Set(value As String)
            _Servidor = value
        End Set
    End Property
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _Clave
        End Get
        Set(value As String)
            _Clave = value
        End Set
    End Property

    Public Property Seguridad As Boolean
        Get
            Return _Seguridad
        End Get
        Set(value As Boolean)
            _Seguridad = value
        End Set
    End Property

    'Declaramos el constructor de la clase
    Public Sub New()




        'ENTORNO DESARROLLO

        Me.Base = "sifodesa"
        Me.Servidor = "10.0.13.218:1526"
        Me.Usuario = "validador_test"
        Me.Clave = "VALIDADOR_TEST"


        Me.conn = New OracleConnection(CrearCadena)

        'ENTORNO QA
        'Me.Base = "sifoqa"
        'Me.Servidor = "10.0.13.218:1527"
        'Me.Usuario = "validador_test"
        'Me.Clave = "validador_test2023"
        'Me.conn = New OracleConnection(CrearCadena)


        'ENTORNO PRODUCCIÓN 'GIANELA
        'Me.Base = "sifonavi"
        'Me.Servidor = "10.0.13.215:1525"
        'Me.Usuario = "VALIDADOR_EMP"
        'Me.Clave = "V4L1D4D0R"
        'Me.conn = New OracleConnection(CrearCadena)

    End Sub


    Public Function CrearCadena() As String

        Dim cadena As String

        cadena = "User id=" & Me.Usuario & ";Password=" & Me.Clave & ";Data Source=" & Me.Servidor & "/" & Me.Base & ";"

        Return cadena

    End Function

    Public Function ValidarConexion() As Boolean

        Dim conexionExitosa As Boolean = False

        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                conexionExitosa = True
            End If
        Catch ex As Exception
            ' Manejo de excepciones
        Finally
            conn.Close()
        End Try

        Return conexionExitosa


    End Function


End Class
