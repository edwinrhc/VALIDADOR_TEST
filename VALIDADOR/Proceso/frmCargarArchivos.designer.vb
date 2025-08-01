<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCargarArchivos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargarArchivos))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTituloFormulario = New System.Windows.Forms.Label()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.gbIFiltros = New System.Windows.Forms.GroupBox()
        Me.cboTipoEmpleadores = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LI_TIPPAD = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ddTipoValidacion = New System.Windows.Forms.ComboBox()
        Me.btnAbrirRemunera = New System.Windows.Forms.Button()
        Me.btnAbrirTrabajador = New System.Windows.Forms.Button()
        Me.txtArchivoRemunera = New System.Windows.Forms.TextBox()
        Me.txtArchivoTrabajador = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnAbrirEmpleador = New System.Windows.Forms.Button()
        Me.txtArchivoEmpleador = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ddFormatoValidacion = New System.Windows.Forms.ComboBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtNumeroCargaGenerado = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnlTitulo.SuspendLayout()
        Me.gbIFiltros.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.AutoSize = True
        Me.pnlTitulo.BackgroundImage = CType(resources.GetObject("pnlTitulo.BackgroundImage"), System.Drawing.Image)
        Me.pnlTitulo.Controls.Add(Me.lblTituloFormulario)
        Me.pnlTitulo.Location = New System.Drawing.Point(-2, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(2000, 37)
        Me.pnlTitulo.TabIndex = 11
        '
        'lblTituloFormulario
        '
        Me.lblTituloFormulario.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloFormulario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloFormulario.ForeColor = System.Drawing.Color.White
        Me.lblTituloFormulario.Location = New System.Drawing.Point(12, 9)
        Me.lblTituloFormulario.Name = "lblTituloFormulario"
        Me.lblTituloFormulario.Size = New System.Drawing.Size(554, 23)
        Me.lblTituloFormulario.TabIndex = 0
        Me.lblTituloFormulario.Text = "CARGA DE ARCHIVO EMPLEADORES"
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "address book.png")
        Me.imgList.Images.SetKeyName(1, "bookmark.png")
        Me.imgList.Images.SetKeyName(2, "file_apply.png")
        '
        'gbIFiltros
        '
        Me.gbIFiltros.Controls.Add(Me.cboTipoEmpleadores)
        Me.gbIFiltros.Controls.Add(Me.Label6)
        Me.gbIFiltros.Controls.Add(Me.LI_TIPPAD)
        Me.gbIFiltros.Controls.Add(Me.Label5)
        Me.gbIFiltros.Controls.Add(Me.ddTipoValidacion)
        Me.gbIFiltros.Controls.Add(Me.btnAbrirRemunera)
        Me.gbIFiltros.Controls.Add(Me.btnAbrirTrabajador)
        Me.gbIFiltros.Controls.Add(Me.txtArchivoRemunera)
        Me.gbIFiltros.Controls.Add(Me.txtArchivoTrabajador)
        Me.gbIFiltros.Controls.Add(Me.Label4)
        Me.gbIFiltros.Controls.Add(Me.Label2)
        Me.gbIFiltros.Controls.Add(Me.btnCargar)
        Me.gbIFiltros.Controls.Add(Me.Label3)
        Me.gbIFiltros.Controls.Add(Me.PictureBox2)
        Me.gbIFiltros.Controls.Add(Me.btnAbrirEmpleador)
        Me.gbIFiltros.Controls.Add(Me.txtArchivoEmpleador)
        Me.gbIFiltros.Controls.Add(Me.Label1)
        Me.gbIFiltros.Controls.Add(Me.ddFormatoValidacion)
        Me.gbIFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbIFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIFiltros.Location = New System.Drawing.Point(6, 44)
        Me.gbIFiltros.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Name = "gbIFiltros"
        Me.gbIFiltros.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Size = New System.Drawing.Size(1047, 324)
        Me.gbIFiltros.TabIndex = 23
        Me.gbIFiltros.TabStop = False
        Me.gbIFiltros.Text = "      Carga de Datos de Empresas"
        '
        'cboTipoEmpleadores
        '
        Me.cboTipoEmpleadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEmpleadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoEmpleadores.FormattingEnabled = True
        Me.cboTipoEmpleadores.Location = New System.Drawing.Point(814, 48)
        Me.cboTipoEmpleadores.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTipoEmpleadores.Name = "cboTipoEmpleadores"
        Me.cboTipoEmpleadores.Size = New System.Drawing.Size(209, 24)
        Me.cboTipoEmpleadores.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(713, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Empleadores(*)"
        '
        'LI_TIPPAD
        '
        Me.LI_TIPPAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LI_TIPPAD.FormattingEnabled = True
        Me.LI_TIPPAD.Location = New System.Drawing.Point(828, 222)
        Me.LI_TIPPAD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LI_TIPPAD.Name = "LI_TIPPAD"
        Me.LI_TIPPAD.Size = New System.Drawing.Size(118, 24)
        Me.LI_TIPPAD.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(398, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Tipo de Validación(*)"
        '
        'ddTipoValidacion
        '
        Me.ddTipoValidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddTipoValidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddTipoValidacion.FormattingEnabled = True
        Me.ddTipoValidacion.Location = New System.Drawing.Point(538, 48)
        Me.ddTipoValidacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddTipoValidacion.Name = "ddTipoValidacion"
        Me.ddTipoValidacion.Size = New System.Drawing.Size(169, 24)
        Me.ddTipoValidacion.TabIndex = 18
        '
        'btnAbrirRemunera
        '
        Me.btnAbrirRemunera.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbrirRemunera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrirRemunera.Font = New System.Drawing.Font("Trebuchet MS", 8.5!)
        Me.btnAbrirRemunera.Image = CType(resources.GetObject("btnAbrirRemunera.Image"), System.Drawing.Image)
        Me.btnAbrirRemunera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbrirRemunera.Location = New System.Drawing.Point(966, 180)
        Me.btnAbrirRemunera.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAbrirRemunera.Name = "btnAbrirRemunera"
        Me.btnAbrirRemunera.Size = New System.Drawing.Size(42, 32)
        Me.btnAbrirRemunera.TabIndex = 17
        Me.btnAbrirRemunera.Text = "     "
        Me.btnAbrirRemunera.UseVisualStyleBackColor = False
        '
        'btnAbrirTrabajador
        '
        Me.btnAbrirTrabajador.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbrirTrabajador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrirTrabajador.Font = New System.Drawing.Font("Trebuchet MS", 8.5!)
        Me.btnAbrirTrabajador.Image = CType(resources.GetObject("btnAbrirTrabajador.Image"), System.Drawing.Image)
        Me.btnAbrirTrabajador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbrirTrabajador.Location = New System.Drawing.Point(966, 140)
        Me.btnAbrirTrabajador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAbrirTrabajador.Name = "btnAbrirTrabajador"
        Me.btnAbrirTrabajador.Size = New System.Drawing.Size(42, 32)
        Me.btnAbrirTrabajador.TabIndex = 16
        Me.btnAbrirTrabajador.Text = "     "
        Me.btnAbrirTrabajador.UseVisualStyleBackColor = False
        '
        'txtArchivoRemunera
        '
        Me.txtArchivoRemunera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArchivoRemunera.Enabled = False
        Me.txtArchivoRemunera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoRemunera.Location = New System.Drawing.Point(244, 182)
        Me.txtArchivoRemunera.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtArchivoRemunera.Multiline = True
        Me.txtArchivoRemunera.Name = "txtArchivoRemunera"
        Me.txtArchivoRemunera.Size = New System.Drawing.Size(707, 32)
        Me.txtArchivoRemunera.TabIndex = 15
        '
        'txtArchivoTrabajador
        '
        Me.txtArchivoTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArchivoTrabajador.Enabled = False
        Me.txtArchivoTrabajador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoTrabajador.Location = New System.Drawing.Point(244, 142)
        Me.txtArchivoTrabajador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtArchivoTrabajador.Multiline = True
        Me.txtArchivoTrabajador.Name = "txtArchivoTrabajador"
        Me.txtArchivoTrabajador.Size = New System.Drawing.Size(707, 32)
        Me.txtArchivoTrabajador.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(61, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Archivo Carga Remunera(*)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(57, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Archivo Carga Empleador(*)"
        '
        'btnCargar
        '
        Me.btnCargar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(445, 234)
        Me.btnCargar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(178, 56)
        Me.btnCargar.TabIndex = 8
        Me.btnCargar.Text = "       CARGAR"
        Me.btnCargar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Archivo Carga Trabajador(*)"
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
        'btnAbrirEmpleador
        '
        Me.btnAbrirEmpleador.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbrirEmpleador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrirEmpleador.Font = New System.Drawing.Font("Trebuchet MS", 8.5!)
        Me.btnAbrirEmpleador.Image = CType(resources.GetObject("btnAbrirEmpleador.Image"), System.Drawing.Image)
        Me.btnAbrirEmpleador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbrirEmpleador.Location = New System.Drawing.Point(966, 100)
        Me.btnAbrirEmpleador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAbrirEmpleador.Name = "btnAbrirEmpleador"
        Me.btnAbrirEmpleador.Size = New System.Drawing.Size(42, 32)
        Me.btnAbrirEmpleador.TabIndex = 6
        Me.btnAbrirEmpleador.Text = "     "
        Me.btnAbrirEmpleador.UseVisualStyleBackColor = False
        '
        'txtArchivoEmpleador
        '
        Me.txtArchivoEmpleador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArchivoEmpleador.Enabled = False
        Me.txtArchivoEmpleador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoEmpleador.Location = New System.Drawing.Point(244, 102)
        Me.txtArchivoEmpleador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtArchivoEmpleador.Multiline = True
        Me.txtArchivoEmpleador.Name = "txtArchivoEmpleador"
        Me.txtArchivoEmpleador.Size = New System.Drawing.Size(707, 32)
        Me.txtArchivoEmpleador.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Formato de Validación(*)"
        '
        'ddFormatoValidacion
        '
        Me.ddFormatoValidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddFormatoValidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddFormatoValidacion.FormattingEnabled = True
        Me.ddFormatoValidacion.IntegralHeight = False
        Me.ddFormatoValidacion.Location = New System.Drawing.Point(244, 48)
        Me.ddFormatoValidacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddFormatoValidacion.Name = "ddFormatoValidacion"
        Me.ddFormatoValidacion.Size = New System.Drawing.Size(146, 24)
        Me.ddFormatoValidacion.TabIndex = 2
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(747, 541)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(134, 41)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "     Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txtNumeroCargaGenerado)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 388)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1023, 132)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "      Carga Generada"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(716, 48)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(292, 43)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "     Consulta estado de la carga"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(421, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(202, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Número de Carga Generado"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'txtNumeroCargaGenerado
        '
        Me.txtNumeroCargaGenerado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroCargaGenerado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroCargaGenerado.Location = New System.Drawing.Point(424, 48)
        Me.txtNumeroCargaGenerado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumeroCargaGenerado.Multiline = True
        Me.txtNumeroCargaGenerado.Name = "txtNumeroCargaGenerado"
        Me.txtNumeroCargaGenerado.ReadOnly = True
        Me.txtNumeroCargaGenerado.Size = New System.Drawing.Size(208, 42)
        Me.txtNumeroCargaGenerado.TabIndex = 4
        Me.txtNumeroCargaGenerado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(901, 541)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(128, 41)
        Me.btnSalir.TabIndex = 36
        Me.btnSalir.Text = "     Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmCargarArchivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1065, 595)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbIFiltros)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargarArchivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de Archivo de Empleadores"
        Me.pnlTitulo.ResumeLayout(False)
        Me.gbIFiltros.ResumeLayout(False)
        Me.gbIFiltros.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTituloFormulario As System.Windows.Forms.Label
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents gbIFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnAbrirEmpleador As System.Windows.Forms.Button
    Friend WithEvents txtArchivoEmpleador As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ddFormatoValidacion As System.Windows.Forms.ComboBox
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ddTipoValidacion As System.Windows.Forms.ComboBox
    Friend WithEvents btnAbrirRemunera As System.Windows.Forms.Button
    Friend WithEvents btnAbrirTrabajador As System.Windows.Forms.Button
    Friend WithEvents txtArchivoRemunera As System.Windows.Forms.TextBox
    Friend WithEvents txtArchivoTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtNumeroCargaGenerado As System.Windows.Forms.TextBox
    Friend WithEvents LI_TIPPAD As ComboBox
    Friend WithEvents cboTipoEmpleadores As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
