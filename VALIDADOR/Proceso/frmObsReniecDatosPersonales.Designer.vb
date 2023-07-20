<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmObsReniecDatosPersonales
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmObsReniecDatosPersonales))
        Me.gbIFiltros = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExportaCSV = New System.Windows.Forms.Button()
        Me.txtNumCarga = New System.Windows.Forms.TextBox()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblIngreseDatos = New System.Windows.Forms.Label()
        Me.lblTipoCampo = New System.Windows.Forms.Label()
        Me.btnBuscarTodos = New System.Windows.Forms.Button()
        Me.ComboBoxColumnas = New System.Windows.Forms.ComboBox()
        Me.txtCriterioBusqueda = New System.Windows.Forms.TextBox()
        Me.btnBuscarEnDataGridView = New System.Windows.Forms.Button()
        Me.BarraProgreso = New System.Windows.Forms.ProgressBar()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.dtgDatosObsDatosPersonales = New System.Windows.Forms.DataGridView()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbIFiltros.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDatosObsDatosPersonales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbIFiltros
        '
        Me.gbIFiltros.Controls.Add(Me.btnSalir)
        Me.gbIFiltros.Controls.Add(Me.Label3)
        Me.gbIFiltros.Controls.Add(Me.PictureBox2)
        Me.gbIFiltros.Controls.Add(Me.btnLimpiar)
        Me.gbIFiltros.Controls.Add(Me.btnBuscar)
        Me.gbIFiltros.Controls.Add(Me.btnExportaCSV)
        Me.gbIFiltros.Controls.Add(Me.txtNumCarga)
        Me.gbIFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbIFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIFiltros.Location = New System.Drawing.Point(12, 70)
        Me.gbIFiltros.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Name = "gbIFiltros"
        Me.gbIFiltros.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Size = New System.Drawing.Size(1748, 91)
        Me.gbIFiltros.TabIndex = 24
        Me.gbIFiltros.TabStop = False
        Me.gbIFiltros.Text = "      Búsqueda de Observados de Datos Personales"
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(1634, 21)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 41)
        Me.btnSalir.TabIndex = 24
        Me.btnSalir.Text = "     Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
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
        'btnExportaCSV
        '
        Me.btnExportaCSV.BackColor = System.Drawing.SystemColors.Control
        Me.btnExportaCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportaCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportaCSV.Image = Global.VALIDADOR.My.Resources.Resources.csv
        Me.btnExportaCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaCSV.Location = New System.Drawing.Point(961, 16)
        Me.btnExportaCSV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExportaCSV.Name = "btnExportaCSV"
        Me.btnExportaCSV.Size = New System.Drawing.Size(99, 45)
        Me.btnExportaCSV.TabIndex = 13
        Me.btnExportaCSV.Text = "                CSV  "
        Me.btnExportaCSV.UseVisualStyleBackColor = False
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
        Me.gbDatos.Controls.Add(Me.GroupBox1)
        Me.gbDatos.Controls.Add(Me.lblIngreseDatos)
        Me.gbDatos.Controls.Add(Me.lblTipoCampo)
        Me.gbDatos.Controls.Add(Me.btnBuscarTodos)
        Me.gbDatos.Controls.Add(Me.ComboBoxColumnas)
        Me.gbDatos.Controls.Add(Me.txtCriterioBusqueda)
        Me.gbDatos.Controls.Add(Me.btnBuscarEnDataGridView)
        Me.gbDatos.Controls.Add(Me.BarraProgreso)
        Me.gbDatos.Controls.Add(Me.lbltotal)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.PictureBox5)
        Me.gbDatos.Controls.Add(Me.PictureBox3)
        Me.gbDatos.Controls.Add(Me.dtgDatosObsDatosPersonales)
        Me.gbDatos.Location = New System.Drawing.Point(12, 169)
        Me.gbDatos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDatos.Size = New System.Drawing.Size(1748, 602)
        Me.gbDatos.TabIndex = 28
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "v"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 454)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 149)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Leyenda"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(63, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(460, 15)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Casuística 3: Nombres y Apellidos Iguales, Tipo y/o Número Documentos diferentes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(63, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(552, 15)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Casuística 4: Tipo Documento y/o Número Documento diferentes - Nombres y/o Apelli" &
    "dos parecidos."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(63, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(531, 15)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Casuística 1: Tipo Documento y Número Documentos iguales - Nombres y/o Apellidos " &
    "diferentes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(63, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(523, 15)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Casuística 2:  Número Documento iguales - Tipo Documento, Nombres y/o Apellidos d" &
    "iferentes"
        '
        'lblIngreseDatos
        '
        Me.lblIngreseDatos.AutoSize = True
        Me.lblIngreseDatos.Location = New System.Drawing.Point(1106, 39)
        Me.lblIngreseDatos.Name = "lblIngreseDatos"
        Me.lblIngreseDatos.Size = New System.Drawing.Size(74, 13)
        Me.lblIngreseDatos.TabIndex = 37
        Me.lblIngreseDatos.Text = "Ingrese  datos"
        '
        'lblTipoCampo
        '
        Me.lblTipoCampo.AutoSize = True
        Me.lblTipoCampo.Location = New System.Drawing.Point(857, 39)
        Me.lblTipoCampo.Name = "lblTipoCampo"
        Me.lblTipoCampo.Size = New System.Drawing.Size(78, 13)
        Me.lblTipoCampo.TabIndex = 36
        Me.lblTipoCampo.Text = "Tipo de campo"
        '
        'btnBuscarTodos
        '
        Me.btnBuscarTodos.Location = New System.Drawing.Point(1614, 29)
        Me.btnBuscarTodos.Name = "btnBuscarTodos"
        Me.btnBuscarTodos.Size = New System.Drawing.Size(95, 32)
        Me.btnBuscarTodos.TabIndex = 35
        Me.btnBuscarTodos.Text = "Mostrar Todo"
        Me.btnBuscarTodos.UseVisualStyleBackColor = True
        '
        'ComboBoxColumnas
        '
        Me.ComboBoxColumnas.FormattingEnabled = True
        Me.ComboBoxColumnas.Location = New System.Drawing.Point(952, 33)
        Me.ComboBoxColumnas.Name = "ComboBoxColumnas"
        Me.ComboBoxColumnas.Size = New System.Drawing.Size(131, 21)
        Me.ComboBoxColumnas.TabIndex = 32
        '
        'txtCriterioBusqueda
        '
        Me.txtCriterioBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCriterioBusqueda.Location = New System.Drawing.Point(1186, 34)
        Me.txtCriterioBusqueda.Name = "txtCriterioBusqueda"
        Me.txtCriterioBusqueda.Size = New System.Drawing.Size(141, 20)
        Me.txtCriterioBusqueda.TabIndex = 33
        '
        'btnBuscarEnDataGridView
        '
        Me.btnBuscarEnDataGridView.Location = New System.Drawing.Point(1333, 26)
        Me.btnBuscarEnDataGridView.Name = "btnBuscarEnDataGridView"
        Me.btnBuscarEnDataGridView.Size = New System.Drawing.Size(77, 32)
        Me.btnBuscarEnDataGridView.TabIndex = 34
        Me.btnBuscarEnDataGridView.Text = "Buscar"
        Me.btnBuscarEnDataGridView.UseVisualStyleBackColor = True
        '
        'BarraProgreso
        '
        Me.BarraProgreso.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BarraProgreso.Location = New System.Drawing.Point(537, 187)
        Me.BarraProgreso.Name = "BarraProgreso"
        Me.BarraProgreso.Size = New System.Drawing.Size(790, 32)
        Me.BarraProgreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.BarraProgreso.TabIndex = 26
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(1569, 506)
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
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(9, 1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(17, 19)
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'dtgDatosObsDatosPersonales
        '
        Me.dtgDatosObsDatosPersonales.AllowUserToAddRows = False
        Me.dtgDatosObsDatosPersonales.AllowUserToDeleteRows = False
        Me.dtgDatosObsDatosPersonales.AllowUserToOrderColumns = True
        Me.dtgDatosObsDatosPersonales.AllowUserToResizeColumns = False
        Me.dtgDatosObsDatosPersonales.AllowUserToResizeRows = False
        Me.dtgDatosObsDatosPersonales.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dtgDatosObsDatosPersonales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDatosObsDatosPersonales.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.dtgDatosObsDatosPersonales.Location = New System.Drawing.Point(22, 68)
        Me.dtgDatosObsDatosPersonales.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtgDatosObsDatosPersonales.Name = "dtgDatosObsDatosPersonales"
        Me.dtgDatosObsDatosPersonales.RowHeadersVisible = False
        Me.dtgDatosObsDatosPersonales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgDatosObsDatosPersonales.Size = New System.Drawing.Size(1707, 379)
        Me.dtgDatosObsDatosPersonales.TabIndex = 12
        '
        'pnlTitulo
        '
        Me.pnlTitulo.AutoSize = True
        Me.pnlTitulo.BackgroundImage = CType(resources.GetObject("pnlTitulo.BackgroundImage"), System.Drawing.Image)
        Me.pnlTitulo.Controls.Add(Me.Label1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1794, 32)
        Me.pnlTitulo.TabIndex = 27
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
        Me.Label1.Text = "DATOS PERSONALES - RENIEC"
        '
        'BackgroundWorker1
        '
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(63, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(430, 30)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Causística 5: Datos Distintos (apellido paterno, materno y nombres parecidos)" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'frmObsReniecDatosPersonales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1794, 784)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.gbIFiltros)
        Me.Name = "frmObsReniecDatosPersonales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones de Datos Personales"
        Me.gbIFiltros.ResumeLayout(False)
        Me.gbIFiltros.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDatosObsDatosPersonales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbIFiltros As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtNumCarga As TextBox
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents gbDatos As GroupBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents lbltotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents btnExportaCSV As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents dtgDatosObsDatosPersonales As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BarraProgreso As ProgressBar
    Friend WithEvents lblIngreseDatos As Label
    Friend WithEvents lblTipoCampo As Label
    Friend WithEvents btnBuscarTodos As Button
    Friend WithEvents ComboBoxColumnas As ComboBox
    Friend WithEvents txtCriterioBusqueda As TextBox
    Friend WithEvents btnBuscarEnDataGridView As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
End Class
