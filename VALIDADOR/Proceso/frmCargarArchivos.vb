Imports System.IO
Imports System.Web.UI.WebControls.Expressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DocumentFormat.OpenXml.Wordprocessing
Imports N_VALIDADOR

Public Class frmCargarArchivos


    Private c_user As String
    Private numCargaGenerado As Long

    Public Property codigoUsuario() As String
        Get
            Return c_user
        End Get
        Set(ByVal value As String)
            c_user = value
        End Set
    End Property


    Public Function verificarExistencia(ByVal ht As Hashtable, ByVal valor As String)

        For Each elemento As DictionaryEntry In ht
            If elemento.Key = valor Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub cargarFormato()
        ddFormatoValidacion.DataSource = GetFormatos()
        ddFormatoValidacion.ValueMember = "ID"
        ddFormatoValidacion.DisplayMember = "DESCRIPCION"

    End Sub

    Sub cargaTipoAporte()

    End Sub

    Sub cargarTipoValidacion()
        ddTipoValidacion.DataSource = GetTipoValidacion()
        ddTipoValidacion.ValueMember = "ID"
        ddTipoValidacion.DisplayMember = "DESCRIPCION"

        LI_TIPPAD.DataSource = GetTipoAporte()
        LI_TIPPAD.ValueMember = "ID"
        LI_TIPPAD.DisplayMember = "DESCRIPCION"


    End Sub

    Private Sub btnAbrirEmpleador_Click(sender As Object, e As EventArgs) Handles btnAbrirEmpleador.Click

        Dim op As New OpenFileDialog()
        op.Filter = "Archivo de Texto|*.txt"

        If op.ShowDialog() = DialogResult.OK Then

            Dim rutaArchivo As String = op.FileName

            'Validar si la ruta contiene espacios
            If rutaArchivo.Contains(" ") Then
                MessageBox.Show("La ruta del archivo no debe contener espacios.", "Empleador", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtArchivoEmpleador.Text = ""

            Else
                txtArchivoEmpleador.Text = rutaArchivo

                Dim nombreArchivo As String = Path.GetFileName(rutaArchivo)
                If nombreArchivo.Equals("EMPLEADOR.TXT", StringComparison.OrdinalIgnoreCase) Then

                Else
                    'El nombre del archivo no es válido

                    MessageBox.Show("Seleccione el archivo EMPLEADOR.TXT", "Empleador", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtArchivoEmpleador.Text = ""

                End If
            End If


        End If


    End Sub




    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Limpiar()

    End Sub
    Sub Limpiar()
        'ddFormatoValidacion.Enabled = True

        'ddFormatoValidacion.SelectedIndex = 0

        ddFormatoValidacion.SelectedValue = 1
        ddTipoValidacion.SelectedValue = 0
        LI_TIPPAD.SelectedValue = 1
        btnCargar.Enabled = False

        txtArchivoEmpleador.Text = ""
        txtArchivoEmpleador.Focus()

        txtArchivoTrabajador.Text = ""
        txtArchivoRemunera.Text = ""

        txtNumeroCargaGenerado.Text = ""

        TipoEmpleador()

    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Try
            If Me.ValidateChildren Then

                Dim Obj As New E_VALIDADOR.Validador
                Dim Neg As New N_VALIDADOR.NValidador


                Obj.PI_VC2_NOMDIREMPLEADOR = Path.GetDirectoryName(txtArchivoEmpleador.Text) & "\"
                'Direccion del archivo
                Obj.PI_VC2_NOMDIREMPLEADORARCHIVO = Path.GetFullPath(txtArchivoEmpleador.Text)
                Obj.PI_VC2_NOMDIRTRABAJADORARCHIVO = Path.GetFullPath(txtArchivoTrabajador.Text)
                Obj.PI_VC2_NOMDIRREMUNERACIONESARCHIVO = Path.GetFullPath(txtArchivoRemunera.Text)

                'TIPO DE VALIDACION
                Obj.LI_VALIDADOR = ddFormatoValidacion.SelectedValue 'FORMATO DE VALIDACION 1 2 
                Obj.LITIPVAL = ddTipoValidacion.SelectedValue 'TIPO DE VALIDACION empleador 1 , interna 2 , empleador + reniec
                Obj.LITIPPAD = LI_TIPPAD.SelectedValue 'APORTES 1 MINIMO 2

                'TIPO DE EMPLEADORES
                Obj.Pi_TIP_EMPL = cboTipoEmpleadores.SelectedValue

                Dim nombreTablas() As String = {"FOMEMPL", "FODRETR", "FODTREM"} 'Importa el orden


                Dim numCar As Long = Neg.Insertar(Obj, nombreTablas)


                If (numCar > 0) Then
                    Try
                        numCargaGenerado = numCar

                        Dim mensaje As String = "Número de carga " + numCargaGenerado.ToString()
                        Dim titulo As String = "La carga es " + numCargaGenerado.ToString()

                        MsgBox(mensaje, vbOKOnly + vbInformation, titulo)

                        Dim valorSeleccionadoTipoValidacion As String = ddTipoValidacion.SelectedValue.ToString()
                        Dim valorSeleccionadoAportes As String = LI_TIPPAD.SelectedValue.ToString()
                        'Console.WriteLine("Agregando \: " + txtArchivoEmpleador.Text)
                        'Console.WriteLine("El valor actual de ddFormatoValidacion es: " + formatoValidacion)
                        'Console.WriteLine("El valor actual de ddTipoValidacion es: " + valorSeleccionadoTipoValidacion)
                        'Console.WriteLine("El valor actual de LI_TIPPAD es: " + valorSeleccionadoAportes)


                    Catch ex As Exception
                        MessageBox.Show("Ha ocurrido un error al crear las tablas." + ex.Message, "Tablas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ' MsgBox("Ha ocurrido un error al crear las tablas: " + ex.Message, vbOKOnly + vbCritical, "Error")
                    End Try

                Else
                    MessageBox.Show("No se ha podido registrar.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ' MsgBox("No se ha podido registrar", vbOKOnly + vbCritical, "Registro incorrecto")
                    Console.WriteLine("En la capa presentación nuevo número de carga es: " + numCar.ToString())
                End If

                txtNumeroCargaGenerado.Text = numCargaGenerado.ToString()



            Else

                MsgBox("Rellene todos los campos obligatorios (*)", vbOK + vbCritical, "Falta Ingresar Datos")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Sub imprimir(ByVal accion As String)


    End Sub



    Public Function obtenerRutaCarpeta(ByVal nombre As String) As String
        Dim ruta As String = nombre
        If Directory.Exists(ruta) = False Then
            Directory.CreateDirectory(ruta)
        End If
        Return ruta
    End Function



    Private Sub txtNumCarga_KeyDown(sender As Object, e As KeyEventArgs) Handles txtArchivoEmpleador.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAbrirEmpleador.Focus()
        End If
    End Sub

    Private Sub txtNumCarga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArchivoEmpleador.KeyPress
        If ddFormatoValidacion.SelectedValue = "0" Or ddFormatoValidacion.SelectedValue = "1" Or ddFormatoValidacion.SelectedValue = "3" Or ddFormatoValidacion.SelectedValue = "4" Then
            e.Handled = OnlyNumbers(txtArchivoEmpleador, e.KeyChar, True)
        End If

    End Sub

    Private formatoValidacion As String = ""


    Private Sub ddlEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles ddFormatoValidacion.SelectedValueChanged

        formatoValidacion = ddFormatoValidacion.SelectedValue.ToString()

        If ddFormatoValidacion.SelectedValue.ToString = "0" Or ddFormatoValidacion.SelectedValue.ToString = "1" Or ddFormatoValidacion.SelectedValue.ToString = "3" Or ddFormatoValidacion.SelectedValue.ToString = "4" Then
            'txtArchivoEmpleador.Text = ""
            'txtArchivoEmpleador.Focus()
        End If

        If ddFormatoValidacion.SelectedValue.ToString = "2" Or ddFormatoValidacion.SelectedValue.ToString = "5" Or ddFormatoValidacion.SelectedValue.ToString = "6" Then

            'txtArchivoEmpleador.Focus()
            'txtArchivoEmpleador.SelectAll()

        End If


    End Sub


    Private Sub btnAbrirTrabajador_Click(sender As Object, e As EventArgs) Handles btnAbrirTrabajador.Click


        Dim op As New OpenFileDialog()
        op.Filter = "Archivo de Texto|*.txt"

        If op.ShowDialog() = DialogResult.OK Then

            Dim rutaArchivo As String = op.FileName

            'Validar si la ruta contiene espacios
            If rutaArchivo.Contains(" ") Then
                MessageBox.Show("La ruta del archivo no debe contener espacios.", "Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MsgBox("La ruta del archivo no debe contener espacios.", Title:="Trabajador")
                txtArchivoTrabajador.Text = ""

            Else
                txtArchivoTrabajador.Text = rutaArchivo

                Dim nombreArchivo As String = Path.GetFileName(rutaArchivo)
                If nombreArchivo.Equals("TRABAJADOR.TXT", StringComparison.OrdinalIgnoreCase) Then

                Else
                    'El nombre del archivo no es válido
                    MessageBox.Show("Seleccione el archivo TRABAJADOR.TXT", "Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'MsgBox("Seleccione el archivo TRABAJADOR.TXT", Title:="Trabajador")
                    txtArchivoTrabajador.Text = ""

                End If
            End If


        End If


    End Sub

    Private Sub btnAbrirRemunera_Click(sender As Object, e As EventArgs) Handles btnAbrirRemunera.Click
        Dim op As New OpenFileDialog()
        op.Filter = "Archivo de Texto|*.txt"

        If op.ShowDialog() = DialogResult.OK Then

            Dim rutaArchivo As String = op.FileName

            'Validar si la ruta contiene espacios
            If rutaArchivo.Contains(" ") Then
                MessageBox.Show("La ruta del archivo no debe contener espacios.", "Remuneracion Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MsgBox("La ruta del archivo no debe contener espacios.", Title:="Remuneracion Trabajador")
                txtArchivoRemunera.Text = ""
                ' lblCargaRemunera.Text = "Carga Incompleta"
            Else
                txtArchivoRemunera.Text = rutaArchivo

                Dim nombreArchivo As String = Path.GetFileName(rutaArchivo)
                If nombreArchivo.Equals("REMUNERACION_TRABAJADOR.TXT", StringComparison.OrdinalIgnoreCase) Then
                    '  lblCargaRemunera.Text = "Correcto"
                Else
                    'El nombre del archivo no es válido
                    MessageBox.Show("Seleccione el archivo REMUNERACION_TRABAJADOR.TXT", "Remuneracion Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'MsgBox("Seleccione el archivo REMUNERACION_TRABAJADOR.TXT", Title:="Remuneracion Trabajador")
                    txtArchivoRemunera.Text = ""
                    '  lblCargaRemunera.Text = "Carga Incompleta"
                End If
            End If

        End If

    End Sub

    Private Sub frmCargarArchivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarFormato()
        cargarTipoValidacion()

        TipoEmpleador()

        ddFormatoValidacion.SelectedValue = 1
        ddTipoValidacion.SelectedValue = 1
        LI_TIPPAD.SelectedValue = 1
        btnCargar.Enabled = False



    End Sub

    Sub TipoEmpleador()

        Dim negocio As New NValidador()
        Dim dt As DataTable = negocio.TipoEmpleadores()

        ' Agregamos el valor "Seleccione" como primer elemento del DataTable
        Dim row As DataRow = dt.NewRow()
        row("C_CODDET") = "44"
        row("C_DESCRI") = "SELECCIONE"
        dt.Rows.InsertAt(row, 0)

        cboTipoEmpleadores.DisplayMember = "C_DESCRI"
        cboTipoEmpleadores.ValueMember = "C_CODDET"
        cboTipoEmpleadores.DataSource = dt

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        frmCargasRealizadas.Show()
    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtArchivoEmpleador_TextChanged(sender As Object, e As EventArgs) Handles txtArchivoEmpleador.TextChanged

        validarBtnCarga()
    End Sub

    Private Sub txtArchivoTrabajador_TextChanged(sender As Object, e As EventArgs) Handles txtArchivoTrabajador.TextChanged

        validarBtnCarga()
    End Sub

    Private Sub txtArchivoRemunera_TextChanged(sender As Object, e As EventArgs) Handles txtArchivoRemunera.TextChanged

        validarBtnCarga()
    End Sub

    Private Sub cboTipoEmpleadores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoEmpleadores.SelectedIndexChanged

        validarBtnCarga()

    End Sub

    Private Sub ddTipoValidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddTipoValidacion.SelectedIndexChanged

        validarBtnCarga()

    End Sub

    Private Sub ddFormatoValidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddFormatoValidacion.SelectedIndexChanged

        validarBtnCarga()
    End Sub

    Sub validarBtnCarga()

        'Validamos los campos requeridos para habilitar el boton btnCarga
        btnCargar.Enabled = (txtArchivoEmpleador.TextLength > 0) AndAlso (txtArchivoTrabajador.TextLength > 0) AndAlso (txtArchivoRemunera.TextLength > 0) AndAlso (cboTipoEmpleadores.SelectedValue <> "44") AndAlso (ddTipoValidacion.SelectedValue > 0) AndAlso (ddFormatoValidacion.SelectedValue > 0)

    End Sub
End Class