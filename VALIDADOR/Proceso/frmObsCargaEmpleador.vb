Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class frmObsCargaEmpleador


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtNumCarga.Text = ""
        txtNumCarga.Focus()
        'Limpiar DataGriview
        dtgDatosObsCargaEmpleador.DataSource = Nothing
        lbltotal.Text = ""

        ComboBoxColumnas.Visible = False
        txtCriterioBusqueda.Visible = False
        btnBuscarEnDataGridView.Visible = False
        btnBuscarTodos.Visible = False
        lblIngreseDatos.Visible = False
        lblTipoCampo.Visible = False
    End Sub

    Private Sub frmObsCargaEmpleador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        dtgDatosObsCargaEmpleador.Columns.Add(dgvColumnCheck)
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtNumCarga.Text = "" Then
            btnExportaCSV.Enabled = False
            MessageBox.Show("Ingrese el número de carga.", "Falta número de carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtgDatosObsCargaEmpleador.DataSource = Nothing
        End If

        If Len(Trim(txtNumCarga.Text)) > 0 Then
            ' Verificar si el BackgroundWorker está en ejecución
            If BackgroundWorker1.IsBusy Then
                MessageBox.Show("La búsqueda está en progreso. Espere a que se complete.", "Búsqueda en progreso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Ocultar el DataGridView
            dtgDatosObsCargaEmpleador.Visible = False

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

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim Neg As New N_VALIDADOR.NConsultas
        Dim Valor As String = txtNumCarga.Text

        ' Realizar la búsqueda y obtener los resultados
        Dim resultados As DataTable = Neg.BuscarObsCargaEmpleador(Valor)

        '' Pasar los resultados al evento RunWorkerCompleted
        e.Result = resultados
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ' Obtener los resultados de la búsqueda
        Dim resultados As DataTable = DirectCast(e.Result, DataTable)

        ' Actualizar el DataSource del DataGridView y mostrarlo
        dtgDatosObsCargaEmpleador.DataSource = resultados
        dtgDatosObsCargaEmpleador.Visible = True

        ComboBoxColumnas.Visible = True
        txtCriterioBusqueda.Visible = True
        btnBuscarEnDataGridView.Visible = True
        btnBuscarTodos.Visible = True
        lblIngreseDatos.Visible = True
        lblTipoCampo.Visible = True

        lbltotal.Text = ""

        If (dtgDatosObsCargaEmpleador.Rows.Count > 0) Then
            btnExportaCSV.Enabled = True
            lbltotal.Text = "Total Registros: " & dtgDatosObsCargaEmpleador.Rows.Count
            Formato()
            ' Mostrar el mensaje de "Búsqueda completada" y realizar otras acciones con los resultados
            MessageBox.Show("Búsqueda completada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Otras acciones que desees realizar con el resultado
        Else
            btnExportaCSV.Enabled = False
            MessageBox.Show("No se encontraron registros", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtgDatosObsCargaEmpleador.DataSource = Nothing
        End If

        ' Ocultar el ProgressBar
        BarraProgreso.Visible = False

        ' Habilitar el botón de búsqueda
        btnBuscar.Enabled = True
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Hide()

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

    Private Sub Formato()

        dtgDatosObsCargaEmpleador.Columns(0).Visible = False
        dtgDatosObsCargaEmpleador.Columns(1).Width = 200
        dtgDatosObsCargaEmpleador.Columns(2).Width = 100
        dtgDatosObsCargaEmpleador.Columns(3).Width = 200
        dtgDatosObsCargaEmpleador.Columns(4).Width = 200
        dtgDatosObsCargaEmpleador.Columns(5).Width = 200
        dtgDatosObsCargaEmpleador.Columns(6).Width = 70
        dtgDatosObsCargaEmpleador.Columns(7).Width = 50
        dtgDatosObsCargaEmpleador.Columns(8).Width = 30
        dtgDatosObsCargaEmpleador.Columns(9).Width = 200
        dtgDatosObsCargaEmpleador.Columns(10).Width = 500
        dtgDatosObsCargaEmpleador.Columns(11).Width = 400
        dtgDatosObsCargaEmpleador.Columns(12).Width = 30
        dtgDatosObsCargaEmpleador.Columns(13).Width = 30


        dtgDatosObsCargaEmpleador.Columns(1).HeaderText = "Tipo Documento"
        dtgDatosObsCargaEmpleador.Columns(2).HeaderText = "Número Documento"
        dtgDatosObsCargaEmpleador.Columns(3).HeaderText = "Apellido Paterno"
        dtgDatosObsCargaEmpleador.Columns(4).HeaderText = "Apellido Materno"
        dtgDatosObsCargaEmpleador.Columns(5).HeaderText = "Nombres"
        dtgDatosObsCargaEmpleador.Columns(6).HeaderText = "Fecha Nac."
        dtgDatosObsCargaEmpleador.Columns(7).HeaderText = "Año"
        dtgDatosObsCargaEmpleador.Columns(8).HeaderText = "Mes"
        dtgDatosObsCargaEmpleador.Columns(9).HeaderText = "Tipo"
        dtgDatosObsCargaEmpleador.Columns(10).HeaderText = "Detalle de Registro"
        dtgDatosObsCargaEmpleador.Columns(11).HeaderText = "Descripción del Error"
        dtgDatosObsCargaEmpleador.Columns(12).HeaderText = "Nro Carga"
        dtgDatosObsCargaEmpleador.Columns(13).HeaderText = "RN"

        Dim col1 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("C_CODTIT")
        Dim col2 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("C_NUMDOT")
        Dim col3 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("C_APEPAT")
        Dim col4 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("C_APEMAT")
        Dim col5 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("C_NOMBRT")
        Dim col6 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("F_NACIMIENTO")
        Dim col7 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("ANIO")
        Dim col8 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("MES")
        Dim col9 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("TIPO")
        Dim col10 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("C_DETREG")
        Dim col11 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("C_DETERR")
        Dim col12 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("N_NUMCAR")
        Dim col13 As DataGridViewColumn = dtgDatosObsCargaEmpleador.Columns("RN")
        'C_CODTIT, C_NUMDOT, C_APEPAT, C_APEMAT, C_NOMBRT, F_NACIMIENTO, ANIO, MES, TIPO, C_DETREG, C_DETERR, N_NUMCAR, RN

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
        col12.DefaultCellStyle.BackColor = Color.White
        col13.ReadOnly = True
        col13.DefaultCellStyle.BackColor = Color.White

    End Sub



    Private Sub btnExportaCSV_Click(sender As Object, e As EventArgs) Handles btnExportaCSV.Click

        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv" ' Filtrar por archivos CSV
            saveFileDialog.Title = "Guardar archivo CSV"
            saveFileDialog.RestoreDirectory = True

            Dim nombreRUC As String = dtgDatosObsCargaEmpleador.Rows(1).Cells(10).Value.ToString()
            Dim nombreRUCFormateado As String = nombreRUC.Substring(4, 13)
            Dim nombreArchivo As String = $"Exportado_RUC_{nombreRUCFormateado}.csv"
            saveFileDialog.FileName = nombreArchivo

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim rutaArchivo As String = saveFileDialog.FileName ' Obtener la ruta del archivo seleccionada por el usuario
                Dim numeroCarga As String = txtNumCarga.Text

                ' Guardar el archivo con el nombre original
                ExportarACSV(dtgDatosObsCargaEmpleador, rutaArchivo)

            End If
        End Using
    End Sub

    Private Sub ExportarACSV(dtgDatos As DataGridView, rutaArchivo As String)

        Dim colCount As Integer = dtgDatos.Columns.Count

        Dim nombreRUC As String = dtgDatos.Rows(1).Cells(10).Value.ToString()

        Console.WriteLine("El valor actual ds: " + nombreRUC)

        Dim nombreRUCFormateado = nombreRUC.Substring(4, 13)

        Console.WriteLine("El valor actual ds: " + nombreRUCFormateado)

        ' Generar el nombre del archivo CSV con el valor de la columna 5
        Dim nombreArchivo As String = $"Exportado_RUC_{nombreRUCFormateado}.csv"

        'Dim nombreArchivo As String = "DATOS Exportados.csv"

        Dim rutaCompletaArchivo As String = Path.Combine(Path.GetDirectoryName(rutaArchivo), nombreArchivo)

        Try

            Using writer As New StreamWriter(rutaCompletaArchivo, False, Encoding.UTF8) ' Utilizar StreamWriter para escribir en el archivo
                ' Escribir encabezados
                For col As Integer = 0 To colCount - 1
                    writer.Write(dtgDatos.Columns(col).HeaderText)
                    If col < colCount - 1 Then
                        writer.Write(";") ' Usar punto y coma como delimitador
                    End If
                Next
                writer.WriteLine()

                ' Escribir datos
                For Each row As DataGridViewRow In dtgDatos.Rows
                    If Not row.IsNewRow Then ' Evitar exportar la fila de nuevo registro
                        For col As Integer = 0 To colCount - 1
                            Dim cellValue As Object = row.Cells(col).Value
                            Dim valorCelda As String = If(cellValue IsNot Nothing, cellValue.ToString(), String.Empty)

                            ' Verificar si es la columna que deseas dar formato en texto
                            ' (Aquí puedes agregar la lógica para dar formato en texto si es necesario)

                            If col = 2 Then ' Aplicar formato a la columna 2 (índice de columna 1)
                                ' Aplica aquí el formato que desees para la columna 2
                                ' Por ejemplo, puedes agregar comillas alrededor del valor
                                valorCelda = " " & valorCelda.ToString()
                                'valorCelda = valorCelda.ToString()
                            End If
                            writer.Write(valorCelda)

                            If col < colCount - 1 Then
                                writer.Write(";") ' Usar punto y coma como delimitador
                            End If
                        Next

                        writer.WriteLine()
                    End If
                Next
            End Using

            MessageBox.Show("Datos exportados correctamente.", "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("El archivo está abierto. Por favor, cierre el archivo y vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNumCarga_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumCarga.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Establecer el foco en el botón
            btnBuscar.Focus()
        End If
    End Sub


    Private Sub LlenarComboBoxColumnas()
        ' Limpiar el ComboBox
        ComboBoxColumnas.Items.Clear()

        ' Agregar las columnas deseadas al ComboBox
        ComboBoxColumnas.Items.Add("Número Documento")
        ComboBoxColumnas.Items.Add("Apellido Paterno")
        ComboBoxColumnas.Items.Add("Apellido Materno")
        ComboBoxColumnas.Items.Add("Nombre Completo")
        ComboBoxColumnas.Items.Add("Tipo")
    End Sub

    Private Function GetColumnNameByIndex(index As Integer) As String
        Dim dt As DataTable = DirectCast(dtgDatosObsCargaEmpleador.DataSource, DataTable)
        If dt IsNot Nothing AndAlso index >= 0 AndAlso index < dt.Columns.Count Then
            Dim columnName As String = ComboBoxColumnas.Items(index).ToString()

            ' Realiza la traducción del nombre de columna según corresponda
            Select Case columnName
                Case "Número Documento"
                    Return "C_NUMDOT"
                Case "Apellido Paterno"
                    Return "C_APEPAT"
                Case "Apellido Materno"
                    Return "C_APEMAT"
                Case "Nombre Completo"
                    Return "C_NOMBRT"
                    ' Agrega más casos según corresponda para otras columnas
                    '...
                Case "Tipo"
                    Return "TIPO"
                Case Else
                    Return ""
            End Select
        End If
        Return ""
    End Function

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
                If dtgDatosObsCargaEmpleador.Rows.Count > 0 Then
                    ' Se encontraron resultados
                    MessageBox.Show("Se encontraron coincidencias: " & dtgDatosObsCargaEmpleador.Rows.Count, "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lbltotal.Text = "Total Registros: " & dtgDatosObsCargaEmpleador.Rows.Count
                Else
                    ' No se encontraron resultados
                    MessageBox.Show("No se encontraron coincidencias.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ComboBoxColumnas.Text = ""
                    txtCriterioBusqueda.Text = ""
                    ' Restaurar el DataView original sin filtro
                    Dim dt As DataTable = DirectCast(dtgDatosObsCargaEmpleador.DataSource, DataTable)
                    dt.DefaultView.RowFilter = String.Empty

                    lbltotal.Text = "Total Registros: " & dtgDatosObsCargaEmpleador.Rows.Count
                End If
            Else
                ' Restaurar el DataView original sin filtro
                Dim dt As DataTable = DirectCast(dtgDatosObsCargaEmpleador.DataSource, DataTable)
                dt.DefaultView.RowFilter = String.Empty
                lbltotal.Text = "Total Registros: " & dtgDatosObsCargaEmpleador.Rows.Count
            End If
        End If


    End Sub


    Private Sub FiltrarDataGridView(criterio As String, columna As String)
        Dim dt As DataTable = DirectCast(dtgDatosObsCargaEmpleador.DataSource, DataTable)

        If dt IsNot Nothing Then
            dt.DefaultView.RowFilter = $"{columna} LIKE '%{criterio}%'"
        End If
    End Sub




    Private Sub txtCriterioBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCriterioBusqueda.KeyDown

        If e.KeyCode = Keys.Enter Then
            ' Establecer el foco en el botón
            btnBuscarEnDataGridView.Focus()
        End If
    End Sub

    Private Sub txtCriterioBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtCriterioBusqueda.TextChanged
        If txtCriterioBusqueda.Text.Length > 40 Then
            txtCriterioBusqueda.Text = txtCriterioBusqueda.Text.Substring(0, 40)
            txtCriterioBusqueda.SelectionStart = 40
        End If
    End Sub



    Private Sub gbDatos_Enter(sender As Object, e As EventArgs) Handles gbDatos.Enter

    End Sub

    Private Sub btnBuscarTodos_Click(sender As Object, e As EventArgs) Handles btnBuscarTodos.Click
        ' Restaurar el DataView original sin filtro
        Dim dt As DataTable = DirectCast(dtgDatosObsCargaEmpleador.DataSource, DataTable)
        dt.DefaultView.RowFilter = String.Empty

        ComboBoxColumnas.Text = ""
        txtCriterioBusqueda.Text = ""



        lbltotal.Text = "Total Registros: " & dtgDatosObsCargaEmpleador.Rows.Count
    End Sub


End Class