<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCargasRealizadas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargasRealizadas))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTituloFormulario = New System.Windows.Forms.Label()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.gbIFiltros = New System.Windows.Forms.GroupBox()
        Me.btnVerTodos = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdbCarga = New System.Windows.Forms.RadioButton()
        Me.rdbEstado = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtNumCarga = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ddlEstado = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dtgDatosAtendidos = New System.Windows.Forms.DataGridView()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnResumenCarga = New System.Windows.Forms.Button()
        Me.btnObservaciones = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.pnlTitulo.SuspendLayout()
        Me.gbIFiltros.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDatosAtendidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
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
        Me.lblTituloFormulario.Text = "CARGAS REALIZADAS"
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
        Me.gbIFiltros.Controls.Add(Me.btnVerTodos)
        Me.gbIFiltros.Controls.Add(Me.Label3)
        Me.gbIFiltros.Controls.Add(Me.rdbCarga)
        Me.gbIFiltros.Controls.Add(Me.rdbEstado)
        Me.gbIFiltros.Controls.Add(Me.PictureBox2)
        Me.gbIFiltros.Controls.Add(Me.btnLimpiar)
        Me.gbIFiltros.Controls.Add(Me.btnBuscar)
        Me.gbIFiltros.Controls.Add(Me.txtNumCarga)
        Me.gbIFiltros.Controls.Add(Me.Label1)
        Me.gbIFiltros.Controls.Add(Me.ddlEstado)
        Me.gbIFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbIFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIFiltros.Location = New System.Drawing.Point(6, 44)
        Me.gbIFiltros.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Name = "gbIFiltros"
        Me.gbIFiltros.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbIFiltros.Size = New System.Drawing.Size(1262, 119)
        Me.gbIFiltros.TabIndex = 23
        Me.gbIFiltros.TabStop = False
        Me.gbIFiltros.Text = "      Búsqueda de Cargas Realizadas"
        '
        'btnVerTodos
        '
        Me.btnVerTodos.BackColor = System.Drawing.SystemColors.Control
        Me.btnVerTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerTodos.Image = CType(resources.GetObject("btnVerTodos.Image"), System.Drawing.Image)
        Me.btnVerTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerTodos.Location = New System.Drawing.Point(765, 30)
        Me.btnVerTodos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnVerTodos.Name = "btnVerTodos"
        Me.btnVerTodos.Size = New System.Drawing.Size(190, 41)
        Me.btnVerTodos.TabIndex = 8
        Me.btnVerTodos.Text = "Listar los 500 Últimos"
        Me.btnVerTodos.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(249, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nro. de Carga"
        '
        'rdbCarga
        '
        Me.rdbCarga.AutoSize = True
        Me.rdbCarga.Checked = True
        Me.rdbCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbCarga.Location = New System.Drawing.Point(31, 84)
        Me.rdbCarga.Name = "rdbCarga"
        Me.rdbCarga.Size = New System.Drawing.Size(86, 20)
        Me.rdbCarga.TabIndex = 9
        Me.rdbCarga.TabStop = True
        Me.rdbCarga.Text = "Por Carga"
        Me.rdbCarga.UseVisualStyleBackColor = True
        '
        'rdbEstado
        '
        Me.rdbEstado.AutoSize = True
        Me.rdbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbEstado.Location = New System.Drawing.Point(31, 40)
        Me.rdbEstado.Name = "rdbEstado"
        Me.rdbEstado.Size = New System.Drawing.Size(92, 20)
        Me.rdbEstado.TabIndex = 1
        Me.rdbEstado.Text = "Por Estado"
        Me.rdbEstado.UseVisualStyleBackColor = True
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
        Me.btnLimpiar.Location = New System.Drawing.Point(973, 30)
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
        Me.btnBuscar.Location = New System.Drawing.Point(606, 30)
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
        Me.txtNumCarga.Enabled = False
        Me.txtNumCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCarga.Location = New System.Drawing.Point(358, 80)
        Me.txtNumCarga.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumCarga.Name = "txtNumCarga"
        Me.txtNumCarga.Size = New System.Drawing.Size(211, 22)
        Me.txtNumCarga.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(249, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Estado"
        '
        'ddlEstado
        '
        Me.ddlEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlEstado.FormattingEnabled = True
        Me.ddlEstado.Location = New System.Drawing.Point(358, 35)
        Me.ddlEstado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddlEstado.Name = "ddlEstado"
        Me.ddlEstado.Size = New System.Drawing.Size(211, 24)
        Me.ddlEstado.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'dtgDatosAtendidos
        '
        Me.dtgDatosAtendidos.AllowUserToAddRows = False
        Me.dtgDatosAtendidos.AllowUserToDeleteRows = False
        Me.dtgDatosAtendidos.AllowUserToOrderColumns = True
        Me.dtgDatosAtendidos.AllowUserToResizeColumns = False
        Me.dtgDatosAtendidos.AllowUserToResizeRows = False
        Me.dtgDatosAtendidos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dtgDatosAtendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDatosAtendidos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.dtgDatosAtendidos.Location = New System.Drawing.Point(22, 39)
        Me.dtgDatosAtendidos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtgDatosAtendidos.Name = "dtgDatosAtendidos"
        Me.dtgDatosAtendidos.RowHeadersVisible = False
        Me.dtgDatosAtendidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgDatosAtendidos.Size = New System.Drawing.Size(1049, 391)
        Me.dtgDatosAtendidos.TabIndex = 12
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
        'btnResumenCarga
        '
        Me.btnResumenCarga.BackColor = System.Drawing.SystemColors.Control
        Me.btnResumenCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResumenCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResumenCarga.Image = CType(resources.GetObject("btnResumenCarga.Image"), System.Drawing.Image)
        Me.btnResumenCarga.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResumenCarga.Location = New System.Drawing.Point(1087, 39)
        Me.btnResumenCarga.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnResumenCarga.Name = "btnResumenCarga"
        Me.btnResumenCarga.Size = New System.Drawing.Size(157, 41)
        Me.btnResumenCarga.TabIndex = 13
        Me.btnResumenCarga.Text = "      Resumen Carga"
        Me.btnResumenCarga.UseVisualStyleBackColor = False
        '
        'btnObservaciones
        '
        Me.btnObservaciones.BackColor = System.Drawing.SystemColors.Control
        Me.btnObservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObservaciones.Image = CType(resources.GetObject("btnObservaciones.Image"), System.Drawing.Image)
        Me.btnObservaciones.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnObservaciones.Location = New System.Drawing.Point(1087, 88)
        Me.btnObservaciones.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnObservaciones.Name = "btnObservaciones"
        Me.btnObservaciones.Size = New System.Drawing.Size(157, 39)
        Me.btnObservaciones.TabIndex = 14
        Me.btnObservaciones.Text = "      Obs de Carga"
        Me.btnObservaciones.UseVisualStyleBackColor = False
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(51, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Bandeja de cargas realizadas"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.btnSalir)
        Me.gbDatos.Controls.Add(Me.lbltotal)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.PictureBox5)
        Me.gbDatos.Controls.Add(Me.btnObservaciones)
        Me.gbDatos.Controls.Add(Me.btnResumenCarga)
        Me.gbDatos.Controls.Add(Me.PictureBox3)
        Me.gbDatos.Controls.Add(Me.dtgDatosAtendidos)
        Me.gbDatos.Location = New System.Drawing.Point(6, 171)
        Me.gbDatos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDatos.Size = New System.Drawing.Size(1262, 490)
        Me.gbDatos.TabIndex = 22
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
        Me.btnSalir.Location = New System.Drawing.Point(1087, 369)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(157, 41)
        Me.btnSalir.TabIndex = 24
        Me.btnSalir.Text = "     Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(958, 437)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(38, 16)
        Me.lbltotal.TabIndex = 21
        Me.lbltotal.Text = "Total"
        '
        'frmCargasRealizadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1279, 683)
        Me.Controls.Add(Me.gbIFiltros)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargasRealizadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Cargas Realizadas"
        Me.pnlTitulo.ResumeLayout(False)
        Me.gbIFiltros.ResumeLayout(False)
        Me.gbIFiltros.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDatosAtendidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTituloFormulario As System.Windows.Forms.Label
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents gbIFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdbCarga As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEstado As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtNumCarga As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ddlEstado As System.Windows.Forms.ComboBox
    Friend WithEvents btnVerTodos As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dtgDatosAtendidos As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnResumenCarga As System.Windows.Forms.Button
    Friend WithEvents btnObservaciones As System.Windows.Forms.Button
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lbltotal As Label
    Friend WithEvents btnSalir As Button
End Class
