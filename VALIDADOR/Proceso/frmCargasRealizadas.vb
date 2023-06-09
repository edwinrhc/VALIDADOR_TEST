Imports System.IO

Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class frmCargasRealizadas


    Private c_user As String



    Public Property codigoUsuario() As String
        Get
            Return c_user
        End Get
        Set(ByVal value As String)
            c_user = value
        End Set
    End Property


    Private Sub frmPadron_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cargarEstados()
        btnResumenCarga.Enabled = False
        btnVisualizacion.Enabled = False
        btnVisualizacion.Visible = False

        Dim dgvColumnCheck As New DataGridViewCheckBoxColumn

        dgvColumnCheck.ReadOnly = False
        dtgDatosAtendidos.Columns.Add(dgvColumnCheck)


        '  ConfigurarColumnasGrillaTramitesAtendidos() '
        txtNumCarga.Enabled = True

    End Sub




    Public Function verificarExistencia(ByVal ht As Hashtable, ByVal valor As String)

        For Each elemento As DictionaryEntry In ht
            If elemento.Key = valor Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub cargarEstados()

        ddlEstado.DataSource = GetEstados()
        ddlEstado.ValueMember = "ID"
        ddlEstado.DisplayMember = "DESCRIPCION"

    End Sub




    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If txtNumCarga.Text = "" Then
            btnResumenCarga.Enabled = False
            btnVisualizacion.Enabled = False
        Else
            btnResumenCarga.Enabled = True
            btnVisualizacion.Enabled = True
        End If

        If Len(Trim(txtNumCarga.Text)) > 0 Then
            Buscar()
            dtgDatosAtendidos.Columns(0).ReadOnly = False
            dtgDatosAtendidos.Columns(1).ReadOnly = False
            If dtgDatosAtendidos.RowCount = 0 Then
                MessageBox.Show("No se encontraron registros.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)

                btnResumenCarga.Enabled = False
                btnVisualizacion.Enabled = False
            End If

        ElseIf IsNumeric(ddlEstado.SelectedValue) Then
            BuscarPorEstado(ddlEstado.SelectedValue)
            dtgDatosAtendidos.Columns(0).ReadOnly = False
            dtgDatosAtendidos.Columns(1).ReadOnly = False
        ElseIf rdbCarga.Checked And txtNumCarga.Text = "" Then
            MessageBox.Show("Ingrese el número de carga", "Número de Carga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtgDatosAtendidos.DataSource = Nothing

        ElseIf rdbEstado.Checked And ddlEstado.SelectedValue = "" Or ddlEstado.SelectedValue = "SELECCIONE" Then
            MessageBox.Show("Ingrese el tipo de Estado", "Tipo Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtgDatosAtendidos.DataSource = Nothing
        End If

    End Sub

    Private Sub rdbCarga_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCarga.CheckedChanged
        ddlEstado.Enabled = False
        ddlEstado.SelectedValue = ""
        txtNumCarga.Enabled = True
        txtNumCarga.Text = ""
        txtNumCarga.Focus()
        dtgDatosAtendidos.DataSource = Nothing
    End Sub

    Private Sub rdbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEstado.CheckedChanged
        ddlEstado.Enabled = True
        txtNumCarga.Enabled = False
        txtNumCarga.Text = ""
        dtgDatosAtendidos.DataSource = Nothing
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        ddlEstado.Enabled = True

        ddlEstado.SelectedIndex = 0

        txtNumCarga.Text = ""
        txtNumCarga.Focus()
        'Limpiar DataGriview
        dtgDatosAtendidos.DataSource = Nothing

    End Sub

    Private Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        Listar50Ultimos()
        txtNumCarga.Text = ""
        ddlEstado.SelectedValue = ""
        dtgDatosAtendidos.Columns(0).ReadOnly = False
        dtgDatosAtendidos.Columns(1).ReadOnly = False
    End Sub



    'Private Sub btnImprimirTramite_Click(sender As Object, e As EventArgs) Handles btnResumenCarga.Click




    '    'For Each row As DataGridViewRow In dtgDatosAtendidos.Rows
    '    '    If row.Cells(0).Value = True Then

    '    '        If row.Cells("PDD_C_MODO_ELAB").Value.ToString.Trim() = SF_GLOBAL_ELABORACION_MANUAL_RESOL Then
    '    '            MessageBox.Show("Para la impresión, sirvase seleccionar solo resoluciones modo AUTOMÁTICO", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    '            Exit Sub
    '    '        End If
    '    '    End If
    '    'Next

    '    '  imprimir(SF_GLOBAL_ACCION_IMPRIMIR)
    'End Sub

    Public Function cargarCampoImagen(ByVal rutaArchivo As String) As Byte()
        If rutaArchivo <> "" Then
            Try
                Dim archivo As FileStream = New FileStream(rutaArchivo, FileMode.Open)
                Dim binRead As BinaryReader = New BinaryReader(archivo)
                Dim imagenEnBytes(archivo.Length) As Byte
                binRead.Read(imagenEnBytes, 0, Integer.Parse(archivo.Length))
                binRead.Close()
                archivo.Close()
                Return imagenEnBytes
            Catch ex As Exception
                Return Nothing
            End Try
        End If
        Return Nothing
    End Function

    Sub imprimir(ByVal accion As String)


    End Sub

    Public Function obtenerRutaCarpeta(ByVal nombre As String) As String
        Dim ruta As String = nombre
        If Directory.Exists(ruta) = False Then
            Directory.CreateDirectory(ruta)
        End If
        Return ruta
    End Function



    Private Sub txtNumCarga_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumCarga.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.Focus()
        End If
    End Sub

    Private Sub txtNumCarga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCarga.KeyPress

        'If ddlEstado.SelectedValue = "0" Or ddlEstado.SelectedValue = "1" Or ddlEstado.SelectedValue = "3" Or ddlEstado.SelectedValue = "4" Then
        '    e.Handled = OnlyNumbers(txtNumCarga, e.KeyChar, True)
        'End If
        'If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
        '    e.Handled = True ' Cancelar la pulsación de tecla si no es un número o una tecla de control
        'End If

        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Evita que se ingrese el carácter no numérico
            MessageBox.Show("Por favor, solo ingrese números.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error) ' Muestra una alerta
        End If
    End Sub

    Private Sub ddlEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles ddlEstado.SelectedValueChanged

        If ddlEstado.SelectedValue.ToString = "0" Or ddlEstado.SelectedValue.ToString = "1" Or ddlEstado.SelectedValue.ToString = "3" Or ddlEstado.SelectedValue.ToString = "4" Then
            txtNumCarga.Text = ""
            txtNumCarga.Focus()
        End If

        If ddlEstado.SelectedValue.ToString = "2" Or ddlEstado.SelectedValue.ToString = "5" Or ddlEstado.SelectedValue.ToString = "6" Then

            txtNumCarga.Focus()
            txtNumCarga.SelectAll()

        End If


    End Sub

    Private Sub Buscar()

        Try
            Dim Neg As New N_VALIDADOR.NValidador
            Dim Valor As String
            Valor = txtNumCarga.Text
            dtgDatosAtendidos.DataSource = Neg.Buscar(Valor) '
            lbltotal.Text = "Total Registros: " & dtgDatosAtendidos.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BuscarPorEstado(selectedValue As Object)

        Try
            Dim Neg As New N_VALIDADOR.NValidador
            Dim Valor As String
            Valor = ddlEstado.Text
            dtgDatosAtendidos.DataSource = Neg.BuscarPorEstado(selectedValue) '
            lbltotal.Text = "Total Registros: " & dtgDatosAtendidos.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Listar50Ultimos()

        Try
            Dim Neg As New N_VALIDADOR.NValidador
            Dim tabla As DataTable = Neg.Listar50Ultimos()
            dtgDatosAtendidos.DataSource = tabla
            lbltotal.Text = "Total Registros: " & tabla.Rows.Count.ToString()
            Me.Formato()
        Catch ex As IndexOutOfRangeException
            MsgBox("Ocurrió un error al listar los registros: El índice estaba fuera del intervalo. Debe ser un valor no negativo e inferior al tamaño de la colección")
        Catch ex As Exception
            MsgBox("Ocurrió un error al listar los registros: " + ex.Message)
        End Try


    End Sub

    Private Sub Formato()

        dtgDatosAtendidos.Columns(0).Visible = False
        dtgDatosAtendidos.Columns(1).Width = 100
        dtgDatosAtendidos.Columns(2).Width = 200
        dtgDatosAtendidos.Columns(3).Width = 200
        dtgDatosAtendidos.Columns(4).Width = 200
        dtgDatosAtendidos.Columns(5).Width = 200

        dtgDatosAtendidos.Columns(1).HeaderText = "Nro Carga"
        dtgDatosAtendidos.Columns(2).HeaderText = "Fecha Carga"
        dtgDatosAtendidos.Columns(3).HeaderText = "Descripción Carga"
        dtgDatosAtendidos.Columns(4).HeaderText = "Estado"
        dtgDatosAtendidos.Columns(5).HeaderText = "Tipo Empl"

        Dim col1 As DataGridViewColumn = dtgDatosAtendidos.Columns("N_numcar")
        Dim col2 As DataGridViewColumn = dtgDatosAtendidos.Columns("D_feccar")
        Dim col3 As DataGridViewColumn = dtgDatosAtendidos.Columns("C_descri")
        Dim col4 As DataGridViewColumn = dtgDatosAtendidos.Columns("N_estado")
        Dim col5 As DataGridViewColumn = dtgDatosAtendidos.Columns("C_TIPEMPL")

        col1.ReadOnly = True
        col1.DefaultCellStyle.BackColor = Color.White
        col2.ReadOnly = True
        col2.DefaultCellStyle.BackColor = Color.White
        col3.ReadOnly = True
        col3.DefaultCellStyle.BackColor = Color.White
        col4.ReadOnly = True
        col4.DefaultCellStyle.BackColor = Color.White
        col5.ReadOnly = True
        col5.DefaultCellStyle.BackColor = Color.White

    End Sub


    Private Sub dtgDatosAtendidos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtgDatosAtendidos.CellFormatting
        If e.ColumnIndex = Me.dtgDatosAtendidos.Columns("N_estado").Index AndAlso e.RowIndex >= 0 Then
            ' Obtén el valor de la celda
            Dim estado As Integer = CInt(e.Value)
            ' Usa una estructura de control para establecer el valor correspondiente en texto
            Select Case estado
                Case 0
                    e.Value = "TERMINADA CON ERRORES"
                Case 1
                    e.Value = "TERMINADA SATISFACTORIAMENTE"
                Case 2
                    e.Value = "REGISTRADA"
                Case 3
                    e.Value = "EN PROCESO"
                Case Else
                    ' Si no se reconoce el valor, muestra el valor original de la celda
                    e.Value = e.Value.ToString()
            End Select
            ' Establece el tipo de formato de la celda como texto
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Application.Exit()
        Me.Close()
    End Sub

    Private Sub btnResumenCarga_Click(sender As Object, e As EventArgs) Handles btnResumenCarga.Click

        Dim Neg As New N_VALIDADOR.NValidador
        Dim Valor As String = txtNumCarga.Text
        Dim EstadoCarga As DataTable = Neg.EstadodeCarga(Valor)

        If EstadoCarga.Rows.Count > 0 Then

            ReporteCargaPDF()
        Else
            MessageBox.Show("La Carga sigue en Proceso, Por favor espere hasta que cambie de estado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub


    Private Sub ReporteCargaPDF()

        Try
            Dim Neg As New N_VALIDADOR.NValidador
            Dim Valor As String = txtNumCarga.Text
            Dim datosCarga As DataTable = Neg.BuscarResumenCargaEmpresas(Valor)

            Dim DatosCargaRealizada As DataTable = Neg.BuscarResultadoCargaRealizada(Valor)

            Dim datosTipoErrorEmpleador As DataTable = Neg.BuscarResumenTipoErrorEmpleadores(Valor)
            Dim datosTipoErrorTrabajadores As DataTable = Neg.BuscarResumenTipoErrorTrabajadores(Valor)
            Dim datosTipoErrorRemuneraciones As DataTable = Neg.BuscarResumenTipoErrorRemuneraciones(Valor)
            Dim datosTipoErrorRemuneracionesDuplicados As DataTable = Neg.BuscarResumenTipoErrorRemuneracionesDuplicados(Valor)
            Dim datosTipoErrorTrabajadoresIntegridad As DataTable = Neg.BuscarResumenTipoErrorTrabajadoresIntegridad(Valor)
            Dim datosTipoErrorRemuneracionesIntegridad As DataTable = Neg.BuscarResumenTipoErrorRemuneracionesIntegridad(Valor)

            Dim datosTipoDoc As DataTable = Neg.BuscarResumenTipoDocumentoTrabajador(Valor)

            Dim doc As New Document()
            Dim ms As New MemoryStream()
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, ms)

            doc.Open()
#Region "Emcabezado del titulo"
            ' Agregar contenido al documento
            Dim table As New PdfPTable(1)
            table.WidthPercentage = 100 ' Ocupar todo el ancho de la página

            Dim celda As New PdfPCell(New Phrase("Ambiente: Pruebas", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.BOLD)))
            celda.HorizontalAlignment = Element.ALIGN_RIGHT ' Alinear a la derecha
            celda.Border = 0 ' Eliminar el borde de la celda
            table.AddCell(celda)

            doc.Add(table)

            ' Agregar el título al documento
            Dim fontTitulo As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)
            Dim titulo As New Paragraph("Resumen Carga Empresas", fontTitulo)
            titulo.Alignment = Element.ALIGN_CENTER
            doc.Add(titulo)


            ' Dim fechaValor As String = datosCarga.Rows(0)("D_FECCAR").ToString() ' Suponiendo que el nombre de la columna sea "fecha"
            Dim fechaValor As String = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            Dim font8 As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
            Dim fecha As New Paragraph(fechaValor, font8)
            fecha.Alignment = Element.ALIGN_CENTER
            fecha.SpacingAfter = 15
            doc.Add(fecha)

#End Region

#Region "Creacion de tabla Resumen Carga Empresas"
            ' Agregar la tabla al documento
            Dim tableCargaEmpresa As New PdfPTable(2)
            tableCargaEmpresa.SetWidths({0.2F, 0.8F})
            tableCargaEmpresa.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableCargaEmpresa.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            'Nro de carga
            Dim cellNroCarga As New PdfPCell(New Phrase("Nro Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
            cellNroCarga.BorderWidth = 0
            Dim cellValorNroCarga As New PdfPCell(New Phrase(datosCarga.Rows(0)("n_numcar").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            cellValorNroCarga.BorderWidth = 0
            tableCargaEmpresa.AddCell(cellNroCarga)
            tableCargaEmpresa.AddCell(cellValorNroCarga)


            'Razon Social de Empresa
            Dim cellRazonSocial As New PdfPCell(New Phrase("Razon Social de Empresa:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
            cellRazonSocial.BorderWidth = 0
            Dim cellValorRazonSocial As New PdfPCell(New Phrase(datosCarga.Rows(0)("C_NOMEMP"), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            cellValorRazonSocial.BorderWidth = 0
            tableCargaEmpresa.AddCell(cellRazonSocial)
            tableCargaEmpresa.AddCell(cellValorRazonSocial)

            ' Fecha de carga
            Dim cellFechaCarga As New PdfPCell(New Phrase("Fecha de Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
            cellFechaCarga.BorderWidth = 0
            'Dar formato a la fecha
            Dim fechaCargaFormato As DateTime = DateTime.Parse(datosCarga.Rows(0)("D_FECCAR").ToString())
            Dim FechaTextoFormato As String = fechaCargaFormato.ToShortDateString()
            Dim cellValorFechaCarga As New PdfPCell(New Phrase(FechaTextoFormato, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            cellValorFechaCarga.BorderWidth = 0

            tableCargaEmpresa.AddCell(cellFechaCarga)
            tableCargaEmpresa.AddCell(cellValorFechaCarga)

            ' Descripción
            Dim cellDescripcion As New PdfPCell(New Phrase("Descripción:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
            cellDescripcion.BorderWidth = 0
            Dim cellValorDescripcion As New PdfPCell(New Phrase(datosCarga.Rows(0)("C_DESCRI"), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            cellValorDescripcion.BorderWidth = 0

            tableCargaEmpresa.AddCell(cellDescripcion)
            tableCargaEmpresa.AddCell(cellValorDescripcion)

            ' Estado
            Dim cellEstado As New PdfPCell(New Phrase("Estado:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
            cellEstado.BorderWidth = 0
            Dim cellValorEstado As New PdfPCell(New Phrase(datosCarga.Rows(0)("C_ESTADO"), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            cellValorEstado.BorderWidth = 0

            tableCargaEmpresa.AddCell(cellEstado)
            tableCargaEmpresa.AddCell(cellValorEstado)

            'Tipo empleador
            Dim cellTipoEmpleador As New PdfPCell(New Phrase("Tipo Empl:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
            cellTipoEmpleador.BorderWidth = 0

            'Dim cellValorTipoEmpleador As New PdfPCell(New Phrase(datosCarga.Rows(0)("TIPEMPL"), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            'cellValorTipoEmpleador.BorderWidth = 0

            'If datosCarga.Rows(0)("TIPEMPL") IsNot DBNull.Value Then
            '    cellValorTipoEmpleador = New PdfPCell(New Phrase(datosCarga.Rows(0)("TIPEMPL").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            'End If
            Dim cellValorTipoEmpleador As PdfPCell

            If datosCarga.Rows(0)("TIPEMPL") IsNot DBNull.Value Then
                cellValorTipoEmpleador = New PdfPCell(New Phrase(datosCarga.Rows(0)("TIPEMPL").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
            Else
                cellValorTipoEmpleador = New PdfPCell()
            End If

            cellValorTipoEmpleador.BorderWidth = 0


            tableCargaEmpresa.AddCell(cellTipoEmpleador)
            tableCargaEmpresa.AddCell(cellValorTipoEmpleador)

            doc.Add(tableCargaEmpresa)

            'Linea aqui horizontal
            Dim line As New Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 2))
            doc.Add(line)
#End Region

#Region "Resultados de Carga realizada"

            ' Agregar el Resultados de Carga realizada
            Dim ResultadoCargaRealizada As New Paragraph("Resultados de Carga realizada", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD))
            ResultadoCargaRealizada.Alignment = Element.ALIGN_CENTER ' Centrar el texto
            ResultadoCargaRealizada.SpacingAfter = 5
            doc.Add(ResultadoCargaRealizada)

            Dim fuenteCargaRealizada As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
            Dim fuenteCuerpoCargaRealizada As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)


            Dim tableResumenCargaRealizada As New PdfPTable(5)
            tableResumenCargaRealizada.SetWidths({0.2F, 0.2F, 0.2F, 0.2F, 0.2F})
            tableResumenCargaRealizada.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableResumenCargaRealizada.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            ' Añadir encabezados de la tabla
            Dim cellCargaRealizadaTipo As New PdfPCell(New Phrase("   ", fuenteCargaRealizada))
            cellCargaRealizadaTipo.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
            cellCargaRealizadaTipo.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            tableResumenCargaRealizada.AddCell(cellCargaRealizadaTipo)

            Dim cellCargaRealizadaRegistroCargados As New PdfPCell(New Phrase("Registros Cargados", fuenteCargaRealizada))
            cellCargaRealizadaRegistroCargados.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
            cellCargaRealizadaRegistroCargados.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            tableResumenCargaRealizada.AddCell(cellCargaRealizadaRegistroCargados)

            Dim cellCargaRealizadaRegistroError As New PdfPCell(New Phrase("Registros con Error", fuenteCargaRealizada))
            cellCargaRealizadaRegistroError.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
            cellCargaRealizadaRegistroError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            tableResumenCargaRealizada.AddCell(cellCargaRealizadaRegistroError)

            Dim cellCargaRealizadaRegistroValidos As New PdfPCell(New Phrase("Registros Validos", fuenteCargaRealizada))
            cellCargaRealizadaRegistroValidos.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
            cellCargaRealizadaRegistroValidos.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            tableResumenCargaRealizada.AddCell(cellCargaRealizadaRegistroValidos)

            Dim cellCargaRealizadaPorcentaje As New PdfPCell(New Phrase("%", fuenteCargaRealizada))
            cellCargaRealizadaPorcentaje.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
            cellCargaRealizadaPorcentaje.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            tableResumenCargaRealizada.AddCell(cellCargaRealizadaPorcentaje)

            'Iterar sobre las filas del DataTable y agregarlas como celdas en la tabla PDF
            For Each row As DataRow In DatosCargaRealizada.Rows
                Dim cellTipoEmpl As New PdfPCell(New Phrase(row("registro").ToString(), fuenteCuerpoCargaRealizada))

                ' Crear la celda para el campo "RegCargados" y establecer su valor con formato numérico
                Dim cellRegistroCargado As New PdfPCell()
                If Double.TryParse(row("RegCargados"), New Double) Then
                    Dim valorRegCargados As Double = Double.Parse(row("RegCargados"))
                    cellRegistroCargado = New PdfPCell(New Phrase(String.Format("{0:N0}", valorRegCargados), fuenteCuerpoCargaRealizada))
                    cellRegistroCargado.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                Else
                    cellRegistroCargado = New PdfPCell(New Phrase(row("RegCargados").ToString(), fuenteCuerpoCargaRealizada))
                    cellRegistroCargado.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                End If
                ' Crear la celda para el campo "RegError" y establecer su valor y color de fondo según corresponda
                Dim cellRegistroError As New PdfPCell()
                If Integer.Parse(row("RegError")) >= 1 Then
                    Dim valorRegCargados As Double = Double.Parse(row("RegError"))
                    cellRegistroError = New PdfPCell(New Phrase(String.Format("{0:N0}", valorRegCargados), fuenteCuerpoCargaRealizada))
                    cellRegistroError.BackgroundColor = New BaseColor(255, 0, 0) ' Rojo
                    cellRegistroError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                Else
                    cellRegistroError = New PdfPCell(New Phrase(row("RegError").ToString(), fuenteCuerpoCargaRealizada))
                    cellRegistroError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                End If

                ' Crear la celda para el campo "RegCargados" y establecer su valor con formato numérico
                'Dim cellRegistroValidos As New PdfPCell(New Phrase(row("RegValido").ToString(), fuenteCuerpoCargaRealizada))
                Dim cellRegistroValidos As New PdfPCell()
                If Double.TryParse(row("RegValido"), New Double) Then
                    Dim valorRegistroValidos As Double = Double.Parse(row("RegValido"))
                    cellRegistroValidos = New PdfPCell(New Phrase(String.Format("{0:N0}", valorRegistroValidos), fuenteCuerpoCargaRealizada))
                    cellRegistroValidos.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                Else
                    cellRegistroValidos = New PdfPCell(New Phrase(row("RegValido").ToString(), fuenteCuerpoCargaRealizada))
                    cellRegistroValidos.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                End If
                'Dim cellPorcentaje As New PdfPCell(New Phrase(row("Porcentaje").ToString(), fuenteCuerpoCargaRealizada))
                ' Crear la celda para el campo "Porcentaje" y establecer su valor con formato de porcentaje
                Dim cellPorcentaje As New PdfPCell()
                If Double.TryParse(row("Porcentaje"), New Double) Then
                    Dim valorPorcentaje As Double = Double.Parse(row("Porcentaje")) / 100
                    cellPorcentaje = New PdfPCell(New Phrase(String.Format("{0:P2}", valorPorcentaje), fuenteCuerpoCargaRealizada))
                    cellPorcentaje.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                Else
                    cellPorcentaje = New PdfPCell(New Phrase(row("Porcentaje").ToString(), fuenteCuerpoCargaRealizada))
                    cellPorcentaje.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                End If


                tableResumenCargaRealizada.AddCell(cellTipoEmpl)
                tableResumenCargaRealizada.AddCell(cellRegistroCargado)
                tableResumenCargaRealizada.AddCell(cellRegistroError)
                tableResumenCargaRealizada.AddCell(cellRegistroValidos)
                tableResumenCargaRealizada.AddCell(cellPorcentaje)

            Next


            doc.Add(tableResumenCargaRealizada)
            'Linea aqui horizontal Resumen 
            doc.Add(line)
#End Region

#Region "Resumen por Tipo de Error ,6. REMUNERACIONES INTEGRIDAD,4. REMUNERACIONES DUPLICADOS,3. REMUNERACIONES,1. EMPLEADORES,5. TRABAJADORES INTEGRIDAD,2. TRABAJADORES"
            ' Agregar el Resumen por Tipo de Error
            Dim ResumenTipoError As New Paragraph("Resumen por Tipo de Error", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD))
            ResumenTipoError.Alignment = Element.ALIGN_CENTER ' Centrar el texto
            ResumenTipoError.SpacingAfter = 5
            doc.Add(ResumenTipoError)

#Region "Mostrar Tipo Error EMPLEADORES"
            'Mostrar Tipo Error EMPLEADORES
            '''''''''''''''''''''
            Dim tableTipoErrorEmpleador As New PdfPTable(2)
            tableTipoErrorEmpleador.SetWidths({0.2F, 0.8F})
            tableTipoErrorEmpleador.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableTipoErrorEmpleador.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            'Si encontramos un registro de datosTipoErrorEmpleador mostrar
            If datosTipoErrorEmpleador.Rows.Count > 0 Then
                Dim cellTipoErrorEmpleador As New PdfPCell(New Phrase("Tipo de Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
                cellTipoErrorEmpleador.BorderWidth = 0
                Dim cellValorcellTipoErrorEmpleador As New PdfPCell(New Phrase(datosTipoErrorEmpleador.Rows(0)("TIPO").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
                cellValorcellTipoErrorEmpleador.BorderWidth = 0
                tableTipoErrorEmpleador.AddCell(cellTipoErrorEmpleador)
                tableTipoErrorEmpleador.AddCell(cellValorcellTipoErrorEmpleador)
                doc.Add(tableTipoErrorEmpleador)

                '''''''''''''''''''''
                Dim tableTipoErrorEmpl As New PdfPTable(2)
                ' Crear una fuente personalizada
                Dim fuenteEmcabezadoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
                Dim fuenteCuerpoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
                tableTipoErrorEmpl.SetWidths({0.1F, 0.9F})
                tableTipoErrorEmpl.WidthPercentage = 100

                ' Añadir encabezados de la tabla
                Dim cellCuentaEmple As New PdfPCell(New Phrase("Nro Errores", fuenteEmcabezadoTipoError))
                cellCuentaEmple.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellCuentaEmple.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoErrorEmpl.AddCell(cellCuentaEmple)

                Dim cellDES_ERROREMPLE As New PdfPCell(New Phrase("Descripción Error", fuenteEmcabezadoTipoError))
                cellDES_ERROREMPLE.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellDES_ERROREMPLE.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoErrorEmpl.AddCell(cellDES_ERROREMPLE)

                Dim erroresPorDescripcion As New Dictionary(Of String, Integer)
                Dim total As Integer = 0

                For Each row As DataRow In datosTipoErrorEmpleador.Rows
                    Dim cuenta As Integer = Convert.ToInt32(row("CUENTA"))
                    Dim descripcion As String = row("DES_ERROR").ToString()

                    ' Si la descripción ya existe en el diccionario, se suma la cantidad de errores
                    ' Si no existe, se agrega la descripción con la cantidad de errores
                    If erroresPorDescripcion.ContainsKey(descripcion) Then
                        erroresPorDescripcion(descripcion) += cuenta
                    Else
                        erroresPorDescripcion.Add(descripcion, cuenta)
                    End If

                    Dim cellN_NUMREG As New PdfPCell(New Phrase(cuenta.ToString(), fuenteCuerpoTipoError))
                    Dim cellC_DESCRI As New PdfPCell(New Phrase(descripcion, fuenteCuerpoTipoError))
                    tableTipoErrorEmpl.AddCell(cellN_NUMREG)
                    tableTipoErrorEmpl.AddCell(cellC_DESCRI)

                    total += cuenta ' Sumamos la cantidad de errores a la variable "total"
                Next

                ' Mostrar la suma de errores por descripción
                For Each descripcion As String In erroresPorDescripcion.Keys
                    Dim cuenta As Integer = erroresPorDescripcion(descripcion)
                    Console.WriteLine(descripcion & ": " & cuenta)
                Next


                'Mostrar el total de número de errores en la última fila
                Dim cellTotal As New PdfPCell(New Phrase("Total", fuenteEmcabezadoTipoError))
                cellTotal.Colspan = 1
                cellTotal.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoErrorEmpl.AddCell(cellTotal)

                'Dim valorRegCargados As Double = Double.Parse(row("RegError"))
                'cellRegistroError = New PdfPCell(New Phrase(String.Format("{0:N0}", valorRegCargados), fuenteCuerpoCargaRealizada))


                'Dim cellTotalValueEmpl As New PdfPCell(New Phrase(total.ToString(), fuenteCuerpoTipoError))
                Dim totalValorEmple As Double = Double.Parse(total.ToString())

                Dim cellTotalValueEmpl As New PdfPCell(New Phrase(String.Format("{0:N0}", totalValorEmple), fuenteCuerpoTipoError))
                cellTotalValueEmpl.Colspan = 1
                cellTotalValueEmpl.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoErrorEmpl.AddCell(cellTotalValueEmpl)
                doc.Add(tableTipoErrorEmpl) ' Añadir la tabla al documento PDF
            End If
#End Region
#Region "Mostrar Tipo Error Trabajadores"
            'Mostrar Tipo Error Trabajadores
            '''''''''''''''''''''
            Dim tableTipoErrorTrabajadores As New PdfPTable(2)
            tableTipoErrorTrabajadores.SetWidths({0.2F, 0.8F})
            tableTipoErrorTrabajadores.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableTipoErrorTrabajadores.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            'Si encontramos un registro de Trabajadores mostrar
            If datosTipoErrorTrabajadores.Rows.Count > 0 Then
                Dim cellTipoErrorTrabajadores As New PdfPCell(New Phrase("Tipo de Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
                cellTipoErrorTrabajadores.BorderWidth = 0
                Dim cellValorcellTipoErrorTrabajadores As New PdfPCell(New Phrase(datosTipoErrorTrabajadores.Rows(0)("TIPO").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
                cellValorcellTipoErrorTrabajadores.BorderWidth = 0
                tableTipoErrorTrabajadores.AddCell(cellTipoErrorTrabajadores)
                tableTipoErrorTrabajadores.AddCell(cellValorcellTipoErrorTrabajadores)
                doc.Add(tableTipoErrorTrabajadores)

                '''''''''''''''''''''
                Dim tableTipoError As New PdfPTable(2)
                ' Crear una fuente personalizada
                Dim fuenteEmcabezadoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
                Dim fuenteCuerpoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
                tableTipoError.SetWidths({0.1F, 0.9F})
                tableTipoError.WidthPercentage = 100

                ' Añadir encabezados de la tabla
                Dim cellNErrores As New PdfPCell(New Phrase("Nro Errores", fuenteEmcabezadoTipoError))
                cellNErrores.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellNErrores.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellNErrores)

                Dim cellDesError As New PdfPCell(New Phrase("Descripción Error", fuenteEmcabezadoTipoError))
                cellDesError.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellDesError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellDesError)

                Dim erroresPorDescripcion As New Dictionary(Of String, Integer)
                Dim total As Integer = 0

                For Each row As DataRow In datosTipoErrorTrabajadores.Rows
                    Dim cuenta As Integer = Convert.ToInt32(row("CUENTA"))
                    Dim descripcion As String = row("DES_ERROR").ToString()

                    ' Si la descripción ya existe en el diccionario, se suma la cantidad de errores
                    ' Si no existe, se agrega la descripción con la cantidad de errores
                    If erroresPorDescripcion.ContainsKey(descripcion) Then
                        erroresPorDescripcion(descripcion) += cuenta
                    Else
                        erroresPorDescripcion.Add(descripcion, cuenta)
                    End If

                    Dim cellN_NUMREG As New PdfPCell(New Phrase(cuenta.ToString(), fuenteCuerpoTipoError))
                    Dim cellC_DESCRI As New PdfPCell(New Phrase(descripcion, fuenteCuerpoTipoError))
                    tableTipoError.AddCell(cellN_NUMREG)
                    tableTipoError.AddCell(cellC_DESCRI)

                    total += cuenta ' Sumamos la cantidad de errores a la variable "total"
                Next

                ' Mostrar la suma de errores por descripción
                For Each descripcion As String In erroresPorDescripcion.Keys
                    Dim cuenta As Integer = erroresPorDescripcion(descripcion)
                    Console.WriteLine(descripcion & ": " & cuenta)
                Next


                'Mostrar el total de número de errores en la última fila
                Dim cellTotal As New PdfPCell(New Phrase("Total", fuenteEmcabezadoTipoError))
                cellTotal.Colspan = 1
                cellTotal.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotal)

                ' Dim cellTotalValue As New PdfPCell(New Phrase(total.ToString(), fuenteCuerpoTipoError))

                Dim totalValorTrabaja As Double = Double.Parse(total.ToString())
                Dim cellTotalValue As New PdfPCell(New Phrase(String.Format("{0:N0}", totalValorTrabaja), fuenteCuerpoTipoError))

                cellTotalValue.Colspan = 1
                cellTotalValue.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotalValue)
                doc.Add(tableTipoError) ' Añadir la tabla al documento PDF
            End If


#End Region
#Region "Mostrar Tipo Error REMUNERACIONES"
            'Mostrar Tipo Error REMUNERACIONES
            '''''''''''''''''''''
            Dim tableTipoErrorRemuneraciones As New PdfPTable(2)
            tableTipoErrorRemuneraciones.SetWidths({0.2F, 0.8F})
            tableTipoErrorRemuneraciones.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableTipoErrorRemuneraciones.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            'Si encontramos un registro de REMUNERACIONES mostrar
            If datosTipoErrorRemuneraciones.Rows.Count > 0 Then
                Dim cellTipoErrorRemuneraciones As New PdfPCell(New Phrase("Tipo de Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
                cellTipoErrorRemuneraciones.BorderWidth = 0
                Dim cellValorcellTipoErrorRemuneraciones As New PdfPCell(New Phrase(datosTipoErrorRemuneraciones.Rows(0)("TIPO").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
                cellValorcellTipoErrorRemuneraciones.BorderWidth = 0
                tableTipoErrorRemuneraciones.AddCell(cellTipoErrorRemuneraciones)
                tableTipoErrorRemuneraciones.AddCell(cellValorcellTipoErrorRemuneraciones)
                doc.Add(tableTipoErrorRemuneraciones)

                '''''''''''''''''''''
                Dim tableTipoError As New PdfPTable(2)
                ' Crear una fuente personalizada
                Dim fuenteEmcabezadoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
                Dim fuenteCuerpoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
                tableTipoError.SetWidths({0.1F, 0.9F})
                tableTipoError.WidthPercentage = 100

                ' Añadir encabezados de la tabla
                Dim cellNErrores As New PdfPCell(New Phrase("Nro Errores", fuenteEmcabezadoTipoError))
                cellNErrores.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellNErrores.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellNErrores)

                Dim cellDesError As New PdfPCell(New Phrase("Descripción Error", fuenteEmcabezadoTipoError))
                cellDesError.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellDesError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellDesError)

                Dim erroresPorDescripcion As New Dictionary(Of String, Integer)
                Dim total As Integer = 0

                For Each row As DataRow In datosTipoErrorRemuneraciones.Rows
                    Dim cuenta As Integer = Convert.ToInt32(row("CUENTA"))
                    Dim descripcion As String = row("DES_ERROR").ToString()

                    ' Si la descripción ya existe en el diccionario, se suma la cantidad de errores
                    ' Si no existe, se agrega la descripción con la cantidad de errores
                    If erroresPorDescripcion.ContainsKey(descripcion) Then
                        erroresPorDescripcion(descripcion) += cuenta
                    Else
                        erroresPorDescripcion.Add(descripcion, cuenta)
                    End If

                    Dim cellN_NUMREG As New PdfPCell(New Phrase(cuenta.ToString(), fuenteCuerpoTipoError))
                    Dim cellC_DESCRI As New PdfPCell(New Phrase(descripcion, fuenteCuerpoTipoError))
                    tableTipoError.AddCell(cellN_NUMREG)
                    tableTipoError.AddCell(cellC_DESCRI)

                    total += cuenta ' Sumamos la cantidad de errores a la variable "total"
                Next

                ' Mostrar la suma de errores por descripción
                For Each descripcion As String In erroresPorDescripcion.Keys
                    Dim cuenta As Integer = erroresPorDescripcion(descripcion)
                    Console.WriteLine(descripcion & ": " & cuenta)
                Next
                'Mostrar el total de número de errores en la última fila
                Dim cellTotal As New PdfPCell(New Phrase("Total", fuenteEmcabezadoTipoError))
                cellTotal.Colspan = 1
                cellTotal.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotal)

                ' Dim cellTotalValue As New PdfPCell(New Phrase(total.ToString(), fuenteCuerpoTipoError))

                Dim totalValorRemunera As Double = Double.Parse(total.ToString())
                Dim cellTotalValue As New PdfPCell(New Phrase(String.Format("{0:N0}", totalValorRemunera), fuenteCuerpoTipoError))

                cellTotalValue.Colspan = 1
                cellTotalValue.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotalValue)
                doc.Add(tableTipoError) ' Añadir la tabla al documento PDF
            End If
#End Region
#Region "Mostrar Tipo Error REMUNERACIONES DUPLICADOS"
            'Mostrar Tipo Error REMUNERACIONES DUPLICADOS
            '''''''''''''''''''''
            Dim tableTipoErrorRemuneracionesDuplicados As New PdfPTable(2)
            tableTipoErrorRemuneracionesDuplicados.SetWidths({0.2F, 0.8F})
            tableTipoErrorRemuneracionesDuplicados.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableTipoErrorRemuneracionesDuplicados.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            'Si encontramos un registro de REMUNERACIONES DUPLICADOS mostrar
            If datosTipoErrorRemuneracionesDuplicados.Rows.Count > 0 Then
                Dim cellTipoErrorRemuneracionesDuplicados As New PdfPCell(New Phrase("Tipo de Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
                cellTipoErrorRemuneracionesDuplicados.BorderWidth = 0
                Dim cellValorcellTipoErrorRemuneracionesDuplicados As New PdfPCell(New Phrase(datosTipoErrorRemuneracionesDuplicados.Rows(0)("TIPO").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
                cellValorcellTipoErrorRemuneracionesDuplicados.BorderWidth = 0
                tableTipoErrorRemuneracionesDuplicados.AddCell(cellTipoErrorRemuneracionesDuplicados)
                tableTipoErrorRemuneracionesDuplicados.AddCell(cellValorcellTipoErrorRemuneracionesDuplicados)
                doc.Add(tableTipoErrorRemuneracionesDuplicados)

                '''''''''''''''''''''
                Dim tableTipoError As New PdfPTable(2)
                ' Crear una fuente personalizada
                Dim fuenteEmcabezadoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
                Dim fuenteCuerpoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
                tableTipoError.SetWidths({0.1F, 0.9F})
                tableTipoError.WidthPercentage = 100

                ' Añadir encabezados de la tabla
                Dim cellNErrores As New PdfPCell(New Phrase("Nro Errores", fuenteEmcabezadoTipoError))
                cellNErrores.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellNErrores.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellNErrores)

                Dim cellDesError As New PdfPCell(New Phrase("Descripción Error", fuenteEmcabezadoTipoError))
                cellDesError.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellDesError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellDesError)

                Dim erroresPorDescripcion As New Dictionary(Of String, Integer)
                Dim total As Integer = 0

                For Each row As DataRow In datosTipoErrorRemuneracionesDuplicados.Rows
                    Dim cuenta As Integer = Convert.ToInt32(row("CUENTA"))
                    Dim descripcion As String = row("DES_ERROR").ToString()

                    ' Si la descripción ya existe en el diccionario, se suma la cantidad de errores
                    ' Si no existe, se agrega la descripción con la cantidad de errores
                    If erroresPorDescripcion.ContainsKey(descripcion) Then
                        erroresPorDescripcion(descripcion) += cuenta
                    Else
                        erroresPorDescripcion.Add(descripcion, cuenta)
                    End If

                    Dim cellN_NUMREG As New PdfPCell(New Phrase(cuenta.ToString(), fuenteCuerpoTipoError))
                    Dim cellC_DESCRI As New PdfPCell(New Phrase(descripcion, fuenteCuerpoTipoError))
                    tableTipoError.AddCell(cellN_NUMREG)
                    tableTipoError.AddCell(cellC_DESCRI)

                    total += cuenta ' Sumamos la cantidad de errores a la variable "total"
                Next

                ' Mostrar la suma de errores por descripción
                For Each descripcion As String In erroresPorDescripcion.Keys
                    Dim cuenta As Integer = erroresPorDescripcion(descripcion)
                    Console.WriteLine(descripcion & ": " & cuenta)
                Next
                'Mostrar el total de número de errores en la última fila
                Dim cellTotal As New PdfPCell(New Phrase("Total", fuenteEmcabezadoTipoError))
                cellTotal.Colspan = 1
                cellTotal.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotal)



                Dim totalValorRemuneraDuplica As Double = Double.Parse(total.ToString())
                Dim cellTotalValue As New PdfPCell(New Phrase(String.Format("{0:N0}", totalValorRemuneraDuplica), fuenteCuerpoTipoError))

                ' Dim cellTotalValue As New PdfPCell(New Phrase(total.ToString(), fuenteCuerpoTipoError))
                cellTotalValue.Colspan = 1
                cellTotalValue.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotalValue)
                doc.Add(tableTipoError) ' Añadir la tabla al documento PDF
            End If
#End Region
#Region "Mostrar Tipo Error TRABAJADORES INTEGRIDAD"
            'Mostrar Tipo Error TRABAJADORES INTEGRIDAD
            '''''''''''''''''''''
            Dim tableTipoErrorTrabajadoresIntegridad As New PdfPTable(2)
            tableTipoErrorTrabajadoresIntegridad.SetWidths({0.2F, 0.8F})
            tableTipoErrorTrabajadoresIntegridad.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableTipoErrorTrabajadoresIntegridad.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            'Si encontramos un registro de REMUNERACIONES DUPLICADOS mostrar
            If datosTipoErrorTrabajadoresIntegridad.Rows.Count > 0 Then
                Dim cellTipoErrorTrabajadoresIntegridad As New PdfPCell(New Phrase("Tipo de Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
                cellTipoErrorTrabajadoresIntegridad.BorderWidth = 0
                Dim cellValorcellTipoTrabajadoresIntegridad As New PdfPCell(New Phrase(datosTipoErrorTrabajadoresIntegridad.Rows(0)("TIPO").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
                cellValorcellTipoTrabajadoresIntegridad.BorderWidth = 0
                tableTipoErrorTrabajadoresIntegridad.AddCell(cellTipoErrorTrabajadoresIntegridad)
                tableTipoErrorTrabajadoresIntegridad.AddCell(cellValorcellTipoTrabajadoresIntegridad)
                doc.Add(tableTipoErrorTrabajadoresIntegridad)

                '''''''''''''''''''''
                Dim tableTipoError As New PdfPTable(2)
                ' Crear una fuente personalizada
                Dim fuenteEmcabezadoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
                Dim fuenteCuerpoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
                tableTipoError.SetWidths({0.1F, 0.9F})
                tableTipoError.WidthPercentage = 100

                ' Añadir encabezados de la tabla
                Dim cellNErrores As New PdfPCell(New Phrase("Nro Errores", fuenteEmcabezadoTipoError))
                cellNErrores.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellNErrores.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellNErrores)

                Dim cellDesError As New PdfPCell(New Phrase("Descripción Error", fuenteEmcabezadoTipoError))
                cellDesError.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellDesError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellDesError)

                Dim erroresPorDescripcion As New Dictionary(Of String, Integer)
                Dim total As Integer = 0

                For Each row As DataRow In datosTipoErrorTrabajadoresIntegridad.Rows
                    Dim cuenta As Integer = Convert.ToInt32(row("CUENTA"))
                    Dim descripcion As String = row("DES_ERROR").ToString()

                    ' Si la descripción ya existe en el diccionario, se suma la cantidad de errores
                    ' Si no existe, se agrega la descripción con la cantidad de errores
                    If erroresPorDescripcion.ContainsKey(descripcion) Then
                        erroresPorDescripcion(descripcion) += cuenta
                    Else
                        erroresPorDescripcion.Add(descripcion, cuenta)
                    End If

                    Dim cellN_NUMREG As New PdfPCell(New Phrase(cuenta.ToString(), fuenteCuerpoTipoError))
                    Dim cellC_DESCRI As New PdfPCell(New Phrase(descripcion, fuenteCuerpoTipoError))
                    tableTipoError.AddCell(cellN_NUMREG)
                    tableTipoError.AddCell(cellC_DESCRI)

                    total += cuenta ' Sumamos la cantidad de errores a la variable "total"
                Next

                ' Mostrar la suma de errores por descripción
                For Each descripcion As String In erroresPorDescripcion.Keys
                    Dim cuenta As Integer = erroresPorDescripcion(descripcion)
                    Console.WriteLine(descripcion & ": " & cuenta)
                Next
                'Mostrar el total de número de errores en la última fila
                Dim cellTotal As New PdfPCell(New Phrase("Total", fuenteEmcabezadoTipoError))
                cellTotal.Colspan = 1
                cellTotal.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotal)



                Dim totalValorTrabajadorInte As Double = Double.Parse(total.ToString())
                Dim cellTotalValue As New PdfPCell(New Phrase(String.Format("{0:N0}", totalValorTrabajadorInte), fuenteCuerpoTipoError))

                'Dim cellTotalValue As New PdfPCell(New Phrase(total.ToString(), fuenteCuerpoTipoError))


                cellTotalValue.Colspan = 1
                cellTotalValue.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotalValue)
                doc.Add(tableTipoError) ' Añadir la tabla al documento PDF
            End If
#End Region
#Region "Mostrar Tipo Error REMUNERACIONES INTEGRIDAD"
            'Mostrar Tipo Error TRABAJADORES INTEGRIDAD
            '''''''''''''''''''''
            Dim tableTipoErrorRemuneracionesIntegridad As New PdfPTable(2)
            tableTipoErrorRemuneracionesIntegridad.SetWidths({0.2F, 0.8F})
            tableTipoErrorRemuneracionesIntegridad.WidthPercentage = 100 ' Ocupar todo el ancho de la página
            tableTipoErrorRemuneracionesIntegridad.DefaultCell.Border = PdfPCell.NO_BORDER ' Eliminar los bordes por defecto de las celdas

            'Si encontramos un registro de REMUNERACIONES DUPLICADOS mostrar
            If datosTipoErrorRemuneracionesIntegridad.Rows.Count > 0 Then
                Dim cellTipoErrorRemuneracionesIntegridad As New PdfPCell(New Phrase("Tipo de Carga:", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
                cellTipoErrorRemuneracionesIntegridad.BorderWidth = 0
                Dim cellValorcellTipoRemuneracionesIntegridad As New PdfPCell(New Phrase(datosTipoErrorRemuneracionesIntegridad.Rows(0)("TIPO").ToString(), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)))
                cellValorcellTipoRemuneracionesIntegridad.BorderWidth = 0
                tableTipoErrorRemuneracionesIntegridad.AddCell(cellTipoErrorRemuneracionesIntegridad)
                tableTipoErrorRemuneracionesIntegridad.AddCell(cellValorcellTipoRemuneracionesIntegridad)
                doc.Add(tableTipoErrorRemuneracionesIntegridad)

                '''''''''''''''''''''
                Dim tableTipoError As New PdfPTable(2)
                ' Crear una fuente personalizada
                Dim fuenteEmcabezadoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
                Dim fuenteCuerpoTipoError As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
                tableTipoError.SetWidths({0.1F, 0.9F})
                tableTipoError.WidthPercentage = 100

                ' Añadir encabezados de la tabla
                Dim cellNErrores As New PdfPCell(New Phrase("Nro Errores", fuenteEmcabezadoTipoError))
                cellNErrores.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellNErrores.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellNErrores)

                Dim cellDesError As New PdfPCell(New Phrase("Descripción Error", fuenteEmcabezadoTipoError))
                cellDesError.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
                cellDesError.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                tableTipoError.AddCell(cellDesError)

                Dim erroresPorDescripcion As New Dictionary(Of String, Integer)
                Dim total As Integer = 0

                For Each row As DataRow In datosTipoErrorRemuneracionesIntegridad.Rows
                    Dim cuenta As Integer = Convert.ToInt32(row("CUENTA"))
                    Dim descripcion As String = row("DES_ERROR").ToString()

                    ' Si la descripción ya existe en el diccionario, se suma la cantidad de errores
                    ' Si no existe, se agrega la descripción con la cantidad de errores
                    If erroresPorDescripcion.ContainsKey(descripcion) Then
                        erroresPorDescripcion(descripcion) += cuenta
                    Else
                        erroresPorDescripcion.Add(descripcion, cuenta)
                    End If

                    Dim cellN_NUMREG As New PdfPCell(New Phrase(cuenta.ToString(), fuenteCuerpoTipoError))
                    Dim cellC_DESCRI As New PdfPCell(New Phrase(descripcion, fuenteCuerpoTipoError))
                    tableTipoError.AddCell(cellN_NUMREG)
                    tableTipoError.AddCell(cellC_DESCRI)

                    total += cuenta ' Sumamos la cantidad de errores a la variable "total"
                Next

                ' Mostrar la suma de errores por descripción
                For Each descripcion As String In erroresPorDescripcion.Keys
                    Dim cuenta As Integer = erroresPorDescripcion(descripcion)
                    Console.WriteLine(descripcion & ": " & cuenta)
                Next
                'Mostrar el total de número de errores en la última fila
                Dim cellTotal As New PdfPCell(New Phrase("Total", fuenteEmcabezadoTipoError))
                cellTotal.Colspan = 1
                cellTotal.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotal)



                Dim totalValorRemuneraInte As Double = Double.Parse(total.ToString())
                Dim cellTotalValue As New PdfPCell(New Phrase(String.Format("{0:N0}", totalValorRemuneraInte), fuenteCuerpoTipoError))

                ' Dim cellTotalValue As New PdfPCell(New Phrase(total.ToString(), fuenteCuerpoTipoError))


                cellTotalValue.Colspan = 1
                cellTotalValue.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                tableTipoError.AddCell(cellTotalValue)
                doc.Add(tableTipoError) ' Añadir la tabla al documento PDF
            End If
#End Region
            'Linea aqui horizontal Resumen por Tipo de Documento x Trabajador
            doc.Add(line)
#End Region


#Region "Resumen por Tipo de Documento x Trabajador"

            ' Agregar el Resumen por Tipo de Error Resumen por Tipo de Documento x Trabajador
            Dim ResumenTipoDocumentoTrabajador As New Paragraph("Resumen por Tipo de Documento x Trabajador", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD))
            ResumenTipoDocumentoTrabajador.Alignment = Element.ALIGN_CENTER ' Centrar el texto
            ResumenTipoDocumentoTrabajador.SpacingAfter = 5
            doc.Add(ResumenTipoDocumentoTrabajador)


            'Resumen por Tipo de Documento x Trabajador
            'Crear un DataTable
            Dim tableDocumentoTrabajador As New PdfPTable(2)
            ' Crear una fuente personalizada
            Dim fuenteEmcabezado As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
            Dim fuenteCuerpo As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
            ' tableDocumentoTrabajador.SetWidths({1, 2}) '
            tableDocumentoTrabajador.SetWidths({0.1F, 0.9F})
            tableDocumentoTrabajador.WidthPercentage = 100
            ' Añadir encabezados de la tabla
            Dim cellNroReg As New PdfPCell(New Phrase("Nro Reg.", fuenteEmcabezado))
            cellNroReg.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
            cellNroReg.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            tableDocumentoTrabajador.AddCell(cellNroReg)

            Dim cellDescTipoDoc As New PdfPCell(New Phrase("Descripción de Tipo Documento", fuenteEmcabezado))
            cellDescTipoDoc.BackgroundColor = New iTextSharp.text.BaseColor(192, 192, 192)
            cellDescTipoDoc.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            tableDocumentoTrabajador.AddCell(cellDescTipoDoc)

            'Iterar sobre las filas del DataTable y agregarlas como celdas en la tabla PDF
            For Each row As DataRow In datosTipoDoc.Rows
                Dim cellNroCuenta As New PdfPCell(New Phrase(row("CUENTA_TIPDOC").ToString(), fuenteCuerpo))
                Dim cellTipoDoc As New PdfPCell(New Phrase(row("TIPO_DOC_TRABAJ").ToString(), fuenteCuerpo))
                tableDocumentoTrabajador.AddCell(cellNroCuenta)
                tableDocumentoTrabajador.AddCell(cellTipoDoc)
            Next

            doc.Add(tableDocumentoTrabajador) ' Añadir la tabla al documento PDF

#End Region


            '' Aqui cierra el pdf y la escritura
            doc.Close()
            writer.Close()

            ' Guardar el archivo PDF con el nuevo nombre
            Dim bytes As Byte() = ms.ToArray()
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "PDF Files (*.pdf)|*.pdf"
            sfd.FileName = "RESUMEN_CARGA_" & datosCarga.Rows(0)("N_numcar").ToString() & ".pdf"
            Try
                If sfd.ShowDialog() = DialogResult.OK Then
                    Using fs As New FileStream(sfd.FileName, FileMode.Create)
                        fs.Write(bytes, 0, bytes.Length)
                    End Using

                    ' Abrir el archivo PDF
                    Process.Start(sfd.FileName)
                End If
            Catch ex As Exception
                Throw ex
                MsgBox(ex.Message)
            End Try


            GC.Collect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtNumCarga_TextChanged(sender As Object, e As EventArgs) Handles txtNumCarga.TextChanged
        If txtNumCarga.Text = "" Then
            btnResumenCarga.Enabled = False
            btnVisualizacion.Enabled = False


        End If

        Dim value As String = txtNumCarga.Text.Trim()
        ' Verificar si el valor ingresado contiene caracteres que no son números
        If Not IsNumeric(value) And value <> "" Then
            ' Si el valor ingresado contiene caracteres no numéricos, mostrar un mensaje de error y borrar el contenido del TextBox
            MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNumCarga.Text = ""
            txtNumCarga.Focus()
        End If

    End Sub

    Private Sub dtgDatosAtendidos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDatosAtendidos.CellContentClick

    End Sub

    Private Sub dtgDatosAtendidos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDatosAtendidos.CellClick
        ' Obtener el valor de la celda de la primera columna de la fila seleccionada
        Dim valorCelda As String = dtgDatosAtendidos.SelectedRows(0).Cells(1).Value.ToString()
        ' Asignar el valor de la celda al TextBox
        txtNumCarga.Text = valorCelda
        ' Verificar si hay un valor en el control TextBox txtNumCar
        If Not String.IsNullOrEmpty(txtNumCarga.Text) Then
            ' Verificar si se ha seleccionado alguna fila en el DataGridView
            If dtgDatosAtendidos.SelectedRows.Count > 0 Then
                ' Habilitar el botón btnGenerartxt
                btnResumenCarga.Enabled = True
            End If
        End If

    End Sub

End Class