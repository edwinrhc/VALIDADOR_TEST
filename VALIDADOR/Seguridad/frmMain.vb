Imports System.Globalization
Imports System.Threading
Imports CONSTANTES

Public Class frmMain

    Private d_user As String
    Private c_user As String
    Private d_perfil As String
    Private c_sede As String
    Private c_user_sede As String
    Private d_nombre As String


    Public Property codigoUsuario() As String
        Get
            Return c_user
        End Get
        Set(ByVal value As String)
            c_user = value
        End Set
    End Property

    Public Property descripcionUsuario() As String
        Get
            Return d_user
        End Get
        Set(ByVal value As String)
            d_user = value
        End Set
    End Property
    Public Property descripcionPerfil() As String
        Get
            Return d_perfil
        End Get
        Set(ByVal value As String)
            d_perfil = value
        End Set
    End Property

    Public Property codigoSede() As String
        Get
            Return c_sede
        End Get
        Set(ByVal value As String)
            c_sede = value
        End Set
    End Property

    Public Property codigoUsuarioSede() As String
        Get
            Return c_user_sede
        End Get
        Set(ByVal value As String)
            c_user_sede = value
        End Set
    End Property


    Public Property nombreCompleto() As String
        Get
            Return d_nombre
        End Get
        Set(ByVal value As String)
            d_nombre = value
        End Set
    End Property


    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim frm As New frmCargarArchivos
        frm.codigoUsuario = Me.codigoUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmLogin.Close()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")



        tssFecha.Text = " Fecha de acceso : " & Date.Now.ToString
        tssUsuario.Text = " Usuario : " & descripcionUsuario
        tssPerfil.Text = " Perfil : " & descripcionPerfil
        tssIp.Text = " IP : " & GetIpV4()
        tssNombreCompleto.Text = "Nombre Persona : " & nombreCompleto
        tssVersion.Text = "Versión : " & Constante.Version


        Dim ambiente As String = System.Configuration.ConfigurationManager.AppSettings("ambiente")
        Select Case ambiente
            Case "0"
                tssAmbiente.Text = "Ambiente : DESARROLLO"
            Case "1"
                tssAmbiente.Text = "Ambiente : CALIDAD"
            Case "2"
                tssAmbiente.Text = "Ambiente : PRODUCCIÓN"
        End Select




    End Sub



    Private Sub SALIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIRToolStripMenuItem.Click

        Dim result As DialogResult = MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
            frmLogin.Close()
        Else
            ' El usuario canceló la operación
        End If
    End Sub


    Private Sub ComunicadoXDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs)


        'Dim frm As New frmBandejaSesion
        'frm.codigoUsuario = Me.codigoUsuario
        'frm.MdiParent = Me
        'frm.Show()
    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

        'Dim frm As New frmEmitirGuia
        'frm.codigoUsuario = Me.codigoUsuario
        'frm.codigoUsuarioSede = Me.codigoUsuarioSede
        'frm.codigoSede = Me.codigoSede
        'frm.MdiParent = Me
        'frm.Show()

    End Sub

    Private Sub ConsultarGuíaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim frm As New frmConsultarGuia
        'frm.MdiParent = Me
        'frm.Show()
    End Sub

    Private Sub PENDIENTESDEIMPRESIÓNToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim frm As New frmPendientesResolucion
        'frm.codigoUsuario = Me.codigoUsuario
        'frm.MdiParent = Me
        'frm.Show()
    End Sub

    Private Sub BANDEJASATENTIDOSToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim frm As New frmAtendidos
        'frm.codigoUsuario = Me.codigoUsuario
        'frm.MdiParent = Me
        'frm.Show()
    End Sub

    Private Sub MToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim frm As New frmBandejaMiembros
        'frm.codigoUsuario = Me.codigoUsuario
        'frm.MdiParent = Me
        'frm.Show()
    End Sub

    Private Sub NÚMERORESOLUCIONESToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim frm As New frmRangoNumeroResolucion
        'frm.codigoUsuario = Me.codigoUsuario
        'frm.MdiParent = Me
        'frm.Show()
    End Sub


    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click


        Dim frm As New frmCargasRealizadas
        frm.codigoUsuario = Me.codigoUsuario
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub tssVersion_Click(sender As Object, e As EventArgs) Handles tssVersion.Click

    End Sub
End Class