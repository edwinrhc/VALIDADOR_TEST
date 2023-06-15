Public Class frmObsCargaEmpleador


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtNumCarga.Text = ""
        txtNumCarga.Focus()
        'Limpiar DataGriview
        dtgDatosObsCargaEmpleador.DataSource = Nothing
    End Sub

    Private Sub frmObsCargaEmpleador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnExportaCSV.Enabled = False

        'Deshabilita la primera columna del DataGridView
        Dim dgvColumnCheck As New DataGridViewCheckBoxColumn
        dgvColumnCheck.ReadOnly = False
        dtgDatosObsCargaEmpleador.Columns.Add(dgvColumnCheck)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If txtNumCarga.Text = "" Then
            btnExportaCSV.Enabled = False
            MessageBox.Show("Ingrese el número de carga oBS.", "Falta número de carga", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            btnExportaCSV.Enabled = True

        End If
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
End Class