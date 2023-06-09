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

        Me.Base = "#"
        Me.Servidor = "#"
        Me.Usuario = "#"
        Me.Clave = "#"


        Me.conn = New OracleConnection(CrearCadena)


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
