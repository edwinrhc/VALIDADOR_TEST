Imports Microsoft.Office.Interop.Excel
Imports Org.BouncyCastle.Utilities
Imports System.IO
Imports System.Text

Public Class frmObsDatosPersonales
    Private Sub frmObsDatosPersonales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnExportaCSV.Enabled = False

        'Deshabilita la primera columna del DataGridView
        Dim dgvColumnCheck As New DataGridViewCheckBoxColumn
        dgvColumnCheck.ReadOnly = False
        dtgDatosObsDatosPersonales.Columns.Add(dgvColumnCheck)

    End Sub


    Private Sub BuscarObsDatosPersonales()

        Try
            Dim Neg As New N_VALIDADOR.NConsultas
            Dim Valor As String
            Valor = txtNumCarga.Text
            dtgDatosObsDatosPersonales.DataSource = Neg.BuscarObsDatosPersonales(Valor) '
            lbltotal.Text = "Total Registros: " & dtgDatosObsDatosPersonales.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Formato()

        dtgDatosObsDatosPersonales.Columns(0).Visible = False
        dtgDatosObsDatosPersonales.Columns(1).Width = 100
        dtgDatosObsDatosPersonales.Columns(2).Width = 200
        dtgDatosObsDatosPersonales.Columns(3).Width = 200
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

        dtgDatosObsDatosPersonales.Columns(1).HeaderText = "NRO CARGO"
        dtgDatosObsDatosPersonales.Columns(2).HeaderText = "CASUITICA"
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If txtNumCarga.Text = "" Then
            btnExportaCSV.Enabled = False
            MessageBox.Show("Ingrese el número de carga.", "Falta número de carga", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            btnExportaCSV.Enabled = True

        End If

        If Len(Trim(txtNumCarga.Text)) > 0 Then
            BuscarObsDatosPersonales()
            If dtgDatosObsDatosPersonales.RowCount = 0 Then
                MessageBox.Show("No se encontraron registros.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnExportaCSV.Enabled = False

            End If

        End If

    End Sub

    Private Sub ExportarAExcel(dtgDatos As DataGridView)
        Dim rowCount As Integer = dtgDatos.RowCount

        ' Desactivar actualizaciones automáticas
        dtgDatos.AllowUserToAddRows = False

        ' Crear instancia de Excel
        Dim excelApp As New Application()
        Dim workbook As Workbook = excelApp.Workbooks.Add(Type.Missing)
        Dim worksheet As Worksheet = workbook.Sheets(1)

        ' Configurar encabezados
        For col As Integer = 0 To dtgDatos.ColumnCount - 1
            worksheet.Cells(1, col + 1) = dtgDatos.Columns(col).HeaderText
        Next

        ' Exportar datos
        For rowIndex As Integer = 0 To rowCount - 1
            For col As Integer = 0 To dtgDatos.ColumnCount - 1
                worksheet.Cells(rowIndex + 2, col + 1) = dtgDatos.Rows(rowIndex).Cells(col).Value
            Next
        Next

        ' Ajustar ancho de las columnas
        worksheet.Columns.AutoFit()

        ' Guardar y mostrar el cuadro de diálogo "Guardar como"
        workbook.SaveAs()
        excelApp.Dialogs(XlBuiltInDialog.xlDialogSaveAs).Show()

        ' Cerrar instancia de Excel
        excelApp.Quit()

        ' Activar actualizaciones automáticas
        dtgDatos.AllowUserToAddRows = True
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
End Class