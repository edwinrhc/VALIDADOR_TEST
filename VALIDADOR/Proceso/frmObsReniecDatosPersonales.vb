
Imports Org.BouncyCastle.Utilities
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Public Class frmObsReniecDatosPersonales
    Private Sub frmObsDatosPersonales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnExportaCSV.Enabled = False
        BarraProgreso.Visible = False

        ComboBoxColumnas.Visible = False
        ComboBoxColumnas.DropDownStyle = ComboBoxStyle.DropDownList
        txtCriterioBusqueda.Visible = False
        btnBuscarEnDataGridView.Visible = False
        btnBuscarTodos.Visible = False
        lblIngreseDatos.Visible = False
        lblTipoCampo.Visible = False

        LlenarComboBoxColumnas()
        'Deshabilita la primera columna del DataGridView
        Dim dgvColumnCheck As New DataGridViewCheckBoxColumn
        dgvColumnCheck.ReadOnly = False
        dtgDatosObsDatosPersonales.Columns.Add(dgvColumnCheck)

    End Sub

    Private Sub Formato()

        dtgDatosObsDatosPersonales.Columns(0).Visible = False
        dtgDatosObsDatosPersonales.Columns(1).Width = 50
        dtgDatosObsDatosPersonales.Columns(2).Width = 70
        dtgDatosObsDatosPersonales.Columns(3).Width = 70
        dtgDatosObsDatosPersonales.Columns(4).Width = 200
        dtgDatosObsDatosPersonales.Columns(5).Width = 200
        dtgDatosObsDatosPersonales.Columns(6).Width = 100
        dtgDatosObsDatosPersonales.Columns(7).Width = 200
        dtgDatosObsDatosPersonales.Columns(8).Width = 200
        dtgDatosObsDatosPersonales.Columns(9).Width = 200
        dtgDatosObsDatosPersonales.Columns(10).Width = 200
        dtgDatosObsDatosPersonales.Columns(11).Width = 200
        dtgDatosObsDatosPersonales.Columns(12).Width = 200
        dtgDatosObsDatosPersonales.Columns(13).Width = 200
        dtgDatosObsDatosPersonales.Columns(14).Width = 200

        dtgDatosObsDatosPersonales.Columns(1).HeaderText = "NRO CARGA"
        dtgDatosObsDatosPersonales.Columns(2).HeaderText = "CASO"
        dtgDatosObsDatosPersonales.Columns(3).HeaderText = "TIPDOC"
        dtgDatosObsDatosPersonales.Columns(4).HeaderText = "NRODOC"
        dtgDatosObsDatosPersonales.Columns(5).HeaderText = "APEPATERNO"
        dtgDatosObsDatosPersonales.Columns(6).HeaderText = "APEMATERNO"
        dtgDatosObsDatosPersonales.Columns(7).HeaderText = "NOMBRES"
        dtgDatosObsDatosPersonales.Columns(8).HeaderText = "FECNAC"
        dtgDatosObsDatosPersonales.Columns(9).HeaderText = "TIPORENIEC"
        dtgDatosObsDatosPersonales.Columns(10).HeaderText = "NRODOCRENIEC"
        dtgDatosObsDatosPersonales.Columns(11).HeaderText = "APEPATERNORENIEC"
        dtgDatosObsDatosPersonales.Columns(12).HeaderText = "APEMATERNORENIEC"
        dtgDatosObsDatosPersonales.Columns(13).HeaderText = "NOMBRESRENIEC"
        dtgDatosObsDatosPersonales.Columns(14).HeaderText = "FECNACRENIEC"


        Dim col1 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("NROCARGA")
        Dim col2 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("CASUISTICA")
        Dim col3 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("TIPDOC")
        Dim col4 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("NRODOC")
        Dim col5 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("APEPATERNO")
        Dim col6 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("APEMATERNO")
        Dim col7 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("NOMBRES")
        Dim col8 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("FECNAC")
        Dim col9 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("TIPDOCRENIEC")
        Dim col10 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("NRODOCRENIEC")
        Dim col11 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("APEPATERNORENIEC")
        Dim col12 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("APEMATERNORENIEC")
        Dim col13 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("NOMBRESRENIEC")
        Dim col14 As DataGridViewColumn = dtgDatosObsDatosPersonales.Columns("FECNACRENIEC")



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
        col6.ReadOnly = True
        col6.DefaultCellStyle.BackColor = Color.White
        col7.ReadOnly = True
        col7.DefaultCellStyle.BackColor = Color.White
        col8.ReadOnly = True
        col8.DefaultCellStyle.BackColor = Color.White
        col9.ReadOnly = True
        col9.DefaultCellStyle.BackColor = Color.White
        col10.ReadOnly = True
        col10.DefaultCellStyle.BackColor = Color.White
        col11.ReadOnly = True
        col11.DefaultCellStyle.BackColor = Color.White
        col12.ReadOnly = True
        col13.DefaultCellStyle.BackColor = Color.White
        col13.ReadOnly = True
        col14.DefaultCellStyle.BackColor = Color.White
        col14.ReadOnly = True

    End Sub
    Private Sub LlenarComboBoxColumnas()
        ' Limpiar el ComboBox
        ComboBoxColumnas.Items.Clear()

        ' Agregar las columnas deseadas al ComboBox
        'ComboBoxColumnas.Items.Add("Caso")
        ComboBoxColumnas.Items.Add("Tipo")
        ComboBoxColumnas.Items.Add("Número Documento")
        ComboBoxColumnas.Items.Add("Apellido Paterno")
        ComboBoxColumnas.Items.Add("Apellido Materno")

    End Sub
    Private Function GetColumnNameByIndex(index As Integer) As String
        Dim dt As DataTable = DirectCast(dtgDatosObsDatosPersonales.DataSource, DataTable)
        If dt IsNot Nothing AndAlso index >= 0 AndAlso index < dt.Columns.Count Then
            Dim columnName As String = ComboBoxColumnas.Items(index).ToString()

            ' Realiza la traducción del nombre de columna según corresponda
            Select Case columnName
                'Case "Caso"
                '    Return "CASUISTICA"

                Case "Tipo"
                    Return "TIPDOC"

                Case "Número Documento"
                    Return "NRODOC"

                Case "Apellido Paterno"
                    Return "APEPATERNO"

                Case "Apellido Materno"
                    Return "APEMATERNO"
                Case Else
                    Return ""
            End Select
        End If
        Return ""
    End Function



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If txtNumCarga.Text = "" Then
            btnExportaCSV.Enabled = False
            MessageBox.Show("Ingrese el número de carga.", "Falta número de carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtgDatosObsDatosPersonales.DataSource = Nothing
        End If


        If Len(Trim(txtNumCarga.Text)) > 0 Then
            ' Verificar si el BackgroundWorker está en ejecución
            If BackgroundWorker1.IsBusy Then
                MessageBox.Show("La búsqueda está en progreso. Espere a que se complete.", "Búsqueda en progreso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Ocultar el DataGridView
            dtgDatosObsDatosPersonales.Visible = False

            ' Mostrar el ProgressBar
            BarraProgreso.Visible = True
            BarraProgreso.Style = ProgressBarStyle.Marquee
            BarraProgreso.MarqueeAnimationSpeed = 50

            ' Deshabilitar el botón de búsqueda
            btnBuscar.Enabled = False

            'No mostrar
            txtCriterioBusqueda.Visible = False
            btnBuscarEnDataGridView.Visible = False
            ComboBoxColumnas.Visible = False
            btnBuscarTodos.Visible = False
            lblIngreseDatos.Visible = False
            lblTipoCampo.Visible = False

            ' Configurar el BackgroundWorker
            BackgroundWorker1.WorkerReportsProgress = False
            BackgroundWorker1.WorkerSupportsCancellation = True

            ' Ejecutar la búsqueda en segundo plano
            BackgroundWorker1.RunWorkerAsync()
        End If


    End Sub


    Private Sub txtNumCarga_TextChanged(sender As Object, e As EventArgs) Handles txtNumCarga.TextChanged

        If txtNumCarga.Text = "" Then
            btnExportaCSV.Enabled = False
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

    Private Sub ExportarACSV(dtgDatos As DataGridView, rutaArchivo As String)
        Dim rowCount As Integer = dtgDatos.RowCount
        Dim colCount As Integer = dtgDatos.ColumnCount

        Using writer As New StreamWriter(rutaArchivo, False, Encoding.UTF8) ' Utilizar StreamWriter para escribir en el archivo
            ' Escribir encabezados
            For col As Integer = 0 To colCount - 1
                writer.Write(dtgDatos.Columns(col).HeaderText)
                If col < colCount - 1 Then
                    writer.Write(";") ' Usar punto y coma como delimitador
                End If
            Next
            writer.WriteLine()

            ' Escribir datos
            For row As Integer = 0 To rowCount - 1
                For col As Integer = 0 To colCount - 1
                    writer.Write(dtgDatos.Rows(row).Cells(col).Value)
                    If col < colCount - 1 Then
                        writer.Write(";") ' Usar punto y coma como delimitador
                    End If
                Next
                writer.WriteLine()



            Next
        End Using

        MessageBox.Show("Datos exportados correctamente.", "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportaCSV_Click(sender As Object, e As EventArgs) Handles btnExportaCSV.Click
        ' Obtén los datos que deseas exportar a Excel (por ejemplo, un DataTable)
        'ExportarAExcel(dtgDatosObsDatosPersonales)
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv" ' Filtrar por archivos CSV
            saveFileDialog.Title = "Guardar archivo CSV"
            saveFileDialog.RestoreDirectory = True

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim rutaArchivo As String = saveFileDialog.FileName ' Obtener la ruta del archivo seleccionada por el usuario
                Dim numeroCarga As String = txtNumCarga.Text
                ExportarACSV(dtgDatosObsDatosPersonales, rutaArchivo)
            End If
        End Using
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click


        txtNumCarga.Text = ""
        txtNumCarga.Focus()
        'Limpiar DataGriview
        dtgDatosObsDatosPersonales.DataSource = Nothing

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim Neg As New N_VALIDADOR.NConsultas
        Dim Valor As String = txtNumCarga.Text

        ' Realizar la búsqueda y obtener los resultados
        Dim resultados As DataTable = Neg.BuscarObsDatosPersonales(Valor)

        ' Pasar los resultados al evento RunWorkerCompleted
        e.Result = resultados
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ' Obtener los resultados de la búsqueda
        Dim resultados As DataTable = DirectCast(e.Result, DataTable)

        ' Actualizar el DataSource del DataGridView y mostrarlo
        dtgDatosObsDatosPersonales.DataSource = resultados
        dtgDatosObsDatosPersonales.Visible = True

        ComboBoxColumnas.Visible = True
        txtCriterioBusqueda.Visible = True
        btnBuscarEnDataGridView.Visible = True
        btnBuscarTodos.Visible = True
        lblIngreseDatos.Visible = True
        lblTipoCampo.Visible = True

        lbltotal.Text = ""

        If (dtgDatosObsDatosPersonales.Rows.Count > 0) Then
            btnExportaCSV.Enabled = True
            lbltotal.Text = "Total Registros: " & dtgDatosObsDatosPersonales.Rows.Count
            Formato()
            ' Mostrar el mensaje de "Búsqueda completada" y realizar otras acciones con los resultados
            MessageBox.Show("Búsqueda completada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Otras acciones que desees realizar con el resultado
        Else
            btnExportaCSV.Enabled = False
            MessageBox.Show("No se encontraron registros", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtgDatosObsDatosPersonales.DataSource = Nothing
        End If

        ' Ocultar el ProgressBar
        BarraProgreso.Visible = False

        ' Habilitar el botón de búsqueda
        btnBuscar.Enabled = True
    End Sub

    Private Sub txtNumCarga_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumCarga.KeyDown

        If e.KeyCode = Keys.Enter Then
            ' Establecer el foco en el botón
            btnBuscar.Focus()
        End If
    End Sub


    Private Sub btnBuscarEnDataGridView_Click(sender As Object, e As EventArgs) Handles btnBuscarEnDataGridView.Click

        Dim criterio As String = txtCriterioBusqueda.Text.Trim()


        If String.IsNullOrEmpty(ComboBoxColumnas.Text) Then
            MessageBox.Show("El campo Tipo de campo está vacío.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf String.IsNullOrEmpty(txtCriterioBusqueda.Text) Then
            MessageBox.Show("El campo Ingresar Dato está vacío.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Not String.IsNullOrEmpty(criterio) Then
                ' Obtener la columna seleccionada en el ComboBox
                Dim columnaSeleccionada As String = GetColumnNameByIndex(ComboBoxColumnas.SelectedIndex)

                ' Filtrar los datos en función del criterio de búsqueda y la columna seleccionada
                FiltrarDataGridView(criterio, columnaSeleccionada)

                ' Verificar si se encontraron resultados
                If dtgDatosObsDatosPersonales.Rows.Count > 0 Then
                    ' Se encontraron resultados
                    MessageBox.Show("Se encontraron coincidencias: " & dtgDatosObsDatosPersonales.Rows.Count, "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lbltotal.Text = "Total Registros: " & dtgDatosObsDatosPersonales.Rows.Count
                Else
                    ' No se encontraron resultados
                    MessageBox.Show("No se encontraron coincidencias.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ComboBoxColumnas.Text = ""
                    txtCriterioBusqueda.Text = ""
                    ' Restaurar el DataView original sin filtro
                    Dim dt As DataTable = DirectCast(dtgDatosObsDatosPersonales.DataSource, DataTable)
                    dt.DefaultView.RowFilter = String.Empty

                    lbltotal.Text = "Total Registros: " & dtgDatosObsDatosPersonales.Rows.Count
                End If
            Else
                ' Restaurar el DataView original sin filtro
                Dim dt As DataTable = DirectCast(dtgDatosObsDatosPersonales.DataSource, DataTable)
                dt.DefaultView.RowFilter = String.Empty
                lbltotal.Text = "Total Registros: " & dtgDatosObsDatosPersonales.Rows.Count
            End If
        End If

    End Sub
    Private Sub FiltrarDataGridView(criterio As String, columna As String)
        Dim datable As DataTable = DirectCast(dtgDatosObsDatosPersonales.DataSource, DataTable)

        If datable IsNot Nothing Then
            datable.DefaultView.RowFilter = $"{columna} LIKE '%{criterio}%'"

        End If
    End Sub


    Private Sub btnBuscarTodos_Click(sender As Object, e As EventArgs) Handles btnBuscarTodos.Click
        ' Restaurar el DataView original sin filtro
        Dim dt As DataTable = DirectCast(dtgDatosObsDatosPersonales.DataSource, DataTable)
        dt.DefaultView.RowFilter = String.Empty

        ComboBoxColumnas.Text = ""
        txtCriterioBusqueda.Text = ""



        lbltotal.Text = "Total Registros: " & dtgDatosObsDatosPersonales.Rows.Count
    End Sub




    Private Sub txtCriterioBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtCriterioBusqueda.TextChanged
        If txtCriterioBusqueda.Text.Length > 40 Then
            txtCriterioBusqueda.Text = txtCriterioBusqueda.Text.Substring(0, 40)
            txtCriterioBusqueda.SelectionStart = 40
        End If
    End Sub

    Private Sub txtCriterioBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCriterioBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Establecer el foco en el botón
            btnBuscarEnDataGridView.Focus()
        End If
    End Sub

    Private Sub dtgDatosObsDatosPersonales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDatosObsDatosPersonales.CellContentClick

    End Sub

    Private Sub dtgDatosObsDatosPersonales_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dtgDatosObsDatosPersonales.CellPainting
        ' Verificar si se está pintando la primera fila (encabezados)
        ' Verificar si se está pintando la primera fila (encabezados)

    End Sub
End Class