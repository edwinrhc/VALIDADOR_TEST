<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObsCargaEmpleador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmObsCargaEmpleador))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbIFiltros = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtNumCarga = New System.Windows.Forms.TextBox()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btnExportaCSV = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.dtgDatosObsCargaEmpleador = New System.Windows.Forms.DataGridView()
        Me.pnlTitulo.SuspendLayout()
        Me.gbIFiltros.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDatosObsCargaEmpleador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.AutoSize = True
        Me.pnlTitulo.BackgroundImage = CType(resources.GetObject("pnlTitulo.BackgroundImage"), System.Drawing.Image)
        Me.pnlTitulo.Controls.Add(Me.Label1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1318, 32)
        Me.pnlTitulo.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(554, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OBSERVACIONES - CARGA EMPLEADOR"
        '
        'gbIFiltros
        '
        Me.gbIFiltros.Controls.Add(Me.Label3)
        Me.gbIFiltros.Controls.Add(Me.PictureBox2)
        Me.gbIFiltros.Controls.Add(Me.btnLimpiar)
        Me.gbIFiltros.Controls.Add(Me.btnBuscar)
        Me.gbIFiltros.Controls.Add(Me.txtNumCarga)
        Me.gbIFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbIFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIFiltros.Location = New System.Drawing.Point(16, 59)
        Me.gbIFiltros.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Name = "gbIFiltros"
        Me.gbIFiltros.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Size = New System.Drawing.Size(1262, 91)
        Me.gbIFiltros.TabIndex = 29
        Me.gbIFiltros.TabStop = False
        Me.gbIFiltros.Text = "      Búsqueda de Observados de Carga de Empleador"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(247, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nro. de Carga"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(4, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(763, 18)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(134, 41)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "     Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(606, 18)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(134, 41)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "     Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'txtNumCarga
        '
        Me.txtNumCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCarga.Location = New System.Drawing.Point(356, 29)
        Me.txtNumCarga.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumCarga.Name = "txtNumCarga"
        Me.txtNumCarga.Size = New System.Drawing.Size(211, 22)
        Me.txtNumCarga.TabIndex = 4
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.btnSalir)
        Me.gbDatos.Controls.Add(Me.lbltotal)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.PictureBox5)
        Me.gbDatos.Controls.Add(Me.btnExportaCSV)
        Me.gbDatos.Controls.Add(Me.PictureBox3)
        Me.gbDatos.Controls.Add(Me.dtgDatosObsCargaEmpleador)
        Me.gbDatos.Location = New System.Drawing.Point(20, 167)
        Me.gbDatos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDatos.Size = New System.Drawing.Size(1262, 602)
        Me.gbDatos.TabIndex = 30
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "v"
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(1149, 530)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 41)
        Me.btnSalir.TabIndex = 24
        Me.btnSalir.Text = "     Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(953, 575)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(38, 16)
        Me.lbltotal.TabIndex = 21
        Me.lbltotal.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(51, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Bandeja de Observaciones"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(22, 18)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(35, 19)
        Me.PictureBox5.TabIndex = 19
        Me.PictureBox5.TabStop = False
        '
        'btnExportaCSV
        '
        Me.btnExportaCSV.BackColor = System.Drawing.SystemColors.Control
        Me.btnExportaCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportaCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportaCSV.Image = Global.VALIDADOR.My.Resources.Resources.csv
        Me.btnExportaCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaCSV.Location = New System.Drawing.Point(1112, 39)
        Me.btnExportaCSV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExportaCSV.Name = "btnExportaCSV"
        Me.btnExportaCSV.Size = New System.Drawing.Size(99, 48)
        Me.btnExportaCSV.TabIndex = 13
        Me.btnExportaCSV.Text = "                CSV  "
        Me.btnExportaCSV.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(9, 1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(17, 19)
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'dtgDatosObsCargaEmpleador
        '
        Me.dtgDatosObsCargaEmpleador.AllowUserToAddRows = False
        Me.dtgDatosObsCargaEmpleador.AllowUserToDeleteRows = False
        Me.dtgDatosObsCargaEmpleador.AllowUserToOrderColumns = True
        Me.dtgDatosObsCargaEmpleador.AllowUserToResizeColumns = False
        Me.dtgDatosObsCargaEmpleador.AllowUserToResizeRows = False
        Me.dtgDatosObsCargaEmpleador.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dtgDatosObsCargaEmpleador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDatosObsCargaEmpleador.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.dtgDatosObsCargaEmpleador.Location = New System.Drawing.Point(22, 39)
        Me.dtgDatosObsCargaEmpleador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtgDatosObsCargaEmpleador.Name = "dtgDatosObsCargaEmpleador"
        Me.dtgDatosObsCargaEmpleador.RowHeadersVisible = False
        Me.dtgDatosObsCargaEmpleador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgDatosObsCargaEmpleador.Size = New System.Drawing.Size(1084, 532)
        Me.dtgDatosObsCargaEmpleador.TabIndex = 12
        '
        'frmObsCargaEmpleador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1318, 810)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.gbIFiltros)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "frmObsCargaEmpleador"
        Me.Text = "frmObsCargaEmpleador"
        Me.pnlTitulo.ResumeLayout(False)
        Me.gbIFiltros.ResumeLayout(False)
        Me.gbIFiltros.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDatosObsCargaEmpleador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents gbIFiltros As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtNumCarga As TextBox
    Friend WithEvents gbDatos As GroupBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents lbltotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents btnExportaCSV As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents dtgDatosObsCargaEmpleador As DataGridView
End Class
