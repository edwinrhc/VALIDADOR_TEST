Imports CONSTANTES
Public Class frmLogin

    Dim codigoUsuario As String
    Dim descripcionPerfil As String
    Dim codigoSede As String
    Dim codigoUsuarioSede As String
    Dim nombreCompleto As String


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim usuarioValido As String = "USUARIO"
        Dim contrasenaValida As String = "123456"

        If txtUsuario.Text = usuarioValido AndAlso txtContrasena.Text = contrasenaValida Then



            ' La autenticación es válida
            If VerificarAutenticacion(txtUsuario.Text.Trim.ToUpper, txtContrasena.Text.Trim.ToUpper) Then
                Me.Visible = False
                Dim frm As New frmMain
                frm.codigoUsuario = codigoUsuario
                frm.descripcionUsuario = txtUsuario.Text.Trim.ToUpper
                frm.descripcionPerfil = descripcionPerfil
                frm.codigoUsuarioSede = Me.codigoUsuarioSede
                frm.codigoSede = Me.codigoSede
                frm.nombreCompleto = Me.nombreCompleto
                frm.Show()
            End If

        Else
            ' La autenticación es inválida
            MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If



    End Sub

    Public Function VerificarAutenticacion(ByVal usuario As String, ByVal contrasena As String) As Boolean

        If txtUsuario.Text.Trim = "" Then
            MessageBox.Show("Ingrese el usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Focus()
            Return False
        End If

        If txtContrasena.Text.Trim = "" Then
            MessageBox.Show("Ingrese la contraseña", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtContrasena.Focus()
            Return False
        End If



        Return True


    End Function

    Private Sub txtUsuario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContrasena.Focus()
        End If
    End Sub
    Private Sub txtContrasena_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContrasena.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        lblVersion.Text = "Versión " & Constante.Version

        txtUsuario.Focus()

        txtUsuario.Text = "USUARIO"
        txtContrasena.Text = "123456"

        'txtUsuario.Text = "USUARIO9"
        'txtContrasena.Text = "PL357951"


    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim capaNegocios As New N_VALIDADOR.NConexion
        Dim conexionExitosa As Boolean = capaNegocios.ProbarConexion()

        If conexionExitosa Then
            MsgBox("Conexión exitosa")
        Else
            MsgBox("No se pudo conectar a la base de datos")
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class