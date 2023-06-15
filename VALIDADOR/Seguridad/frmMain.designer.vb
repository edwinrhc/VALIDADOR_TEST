<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PADRONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMICargaArchivosEmpleadores = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMIfrmCargaRealizada = New System.Windows.Forms.ToolStripMenuItem()
        Me.OBSERVACIONESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMDatosPersonales = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMCargaEmpleador = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssPerfil = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssIp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssAmbiente = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssNombreCompleto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PADRONToolStripMenuItem, Me.ToolStripMenuItem1, Me.OBSERVACIONESToolStripMenuItem, Me.SALIRToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1025, 54)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PADRONToolStripMenuItem
        '
        Me.PADRONToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PADRONToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMICargaArchivosEmpleadores})
        Me.PADRONToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PADRONToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue
        Me.PADRONToolStripMenuItem.Name = "PADRONToolStripMenuItem"
        Me.PADRONToolStripMenuItem.Size = New System.Drawing.Size(78, 50)
        Me.PADRONToolStripMenuItem.Text = "PROCESO"
        '
        'SMICargaArchivosEmpleadores
        '
        Me.SMICargaArchivosEmpleadores.BackColor = System.Drawing.SystemColors.Control
        Me.SMICargaArchivosEmpleadores.Image = CType(resources.GetObject("SMICargaArchivosEmpleadores.Image"), System.Drawing.Image)
        Me.SMICargaArchivosEmpleadores.Name = "SMICargaArchivosEmpleadores"
        Me.SMICargaArchivosEmpleadores.Size = New System.Drawing.Size(305, 22)
        Me.SMICargaArchivosEmpleadores.Text = "CARGA DE ARCHIVOS EMPLEADORES"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMIfrmCargaRealizada})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(93, 50)
        Me.ToolStripMenuItem1.Text = "CONSULTAS"
        '
        'SMIfrmCargaRealizada
        '
        Me.SMIfrmCargaRealizada.Image = CType(resources.GetObject("SMIfrmCargaRealizada.Image"), System.Drawing.Image)
        Me.SMIfrmCargaRealizada.Name = "SMIfrmCargaRealizada"
        Me.SMIfrmCargaRealizada.Size = New System.Drawing.Size(208, 22)
        Me.SMIfrmCargaRealizada.Text = "CARGAS REALIZADAS"
        '
        'OBSERVACIONESToolStripMenuItem
        '
        Me.OBSERVACIONESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMDatosPersonales, Me.TSMCargaEmpleador})
        Me.OBSERVACIONESToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.OBSERVACIONESToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue
        Me.OBSERVACIONESToolStripMenuItem.Name = "OBSERVACIONESToolStripMenuItem"
        Me.OBSERVACIONESToolStripMenuItem.Size = New System.Drawing.Size(123, 50)
        Me.OBSERVACIONESToolStripMenuItem.Text = "OBSERVACIONES"
        '
        'TSMDatosPersonales
        '
        Me.TSMDatosPersonales.Image = Global.VALIDADOR.My.Resources.Resources.icons8_accede_redondeado_derecho_64
        Me.TSMDatosPersonales.Name = "TSMDatosPersonales"
        Me.TSMDatosPersonales.Size = New System.Drawing.Size(203, 22)
        Me.TSMDatosPersonales.Text = "DATOS PERSONALES"
        '
        'TSMCargaEmpleador
        '
        Me.TSMCargaEmpleador.Image = Global.VALIDADOR.My.Resources.Resources.icons8_accede_redondeado_derecho_64
        Me.TSMCargaEmpleador.Name = "TSMCargaEmpleador"
        Me.TSMCargaEmpleador.Size = New System.Drawing.Size(203, 22)
        Me.TSMCargaEmpleador.Text = "CARGA EMPLEADOR"
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.SALIRToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SALIRToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(55, 50)
        Me.SALIRToolStripMenuItem.Text = "SALIR"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackgroundImage = CType(resources.GetObject("StatusStrip1.BackgroundImage"), System.Drawing.Image)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssFecha, Me.tssUsuario, Me.tssPerfil, Me.tssIp, Me.tssAmbiente, Me.tssNombreCompleto, Me.tssVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1025, 33)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssFecha
        '
        Me.tssFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssFecha.Image = CType(resources.GetObject("tssFecha.Image"), System.Drawing.Image)
        Me.tssFecha.Name = "tssFecha"
        Me.tssFecha.Size = New System.Drawing.Size(16, 28)
        '
        'tssUsuario
        '
        Me.tssUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssUsuario.Image = CType(resources.GetObject("tssUsuario.Image"), System.Drawing.Image)
        Me.tssUsuario.Name = "tssUsuario"
        Me.tssUsuario.Size = New System.Drawing.Size(16, 28)
        '
        'tssPerfil
        '
        Me.tssPerfil.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssPerfil.Image = CType(resources.GetObject("tssPerfil.Image"), System.Drawing.Image)
        Me.tssPerfil.Name = "tssPerfil"
        Me.tssPerfil.Size = New System.Drawing.Size(16, 28)
        '
        'tssIp
        '
        Me.tssIp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssIp.Image = CType(resources.GetObject("tssIp.Image"), System.Drawing.Image)
        Me.tssIp.Name = "tssIp"
        Me.tssIp.Size = New System.Drawing.Size(16, 28)
        '
        'tssAmbiente
        '
        Me.tssAmbiente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssAmbiente.Image = CType(resources.GetObject("tssAmbiente.Image"), System.Drawing.Image)
        Me.tssAmbiente.Name = "tssAmbiente"
        Me.tssAmbiente.Size = New System.Drawing.Size(16, 28)
        '
        'tssNombreCompleto
        '
        Me.tssNombreCompleto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssNombreCompleto.Image = CType(resources.GetObject("tssNombreCompleto.Image"), System.Drawing.Image)
        Me.tssNombreCompleto.Name = "tssNombreCompleto"
        Me.tssNombreCompleto.Size = New System.Drawing.Size(16, 28)
        '
        'tssVersion
        '
        Me.tssVersion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssVersion.Image = CType(resources.GetObject("tssVersion.Image"), System.Drawing.Image)
        Me.tssVersion.Name = "tssVersion"
        Me.tssVersion.Size = New System.Drawing.Size(16, 28)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1025, 495)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SISTEMA VALIDADOR DE F2"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PADRONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SALIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SMICargaArchivosEmpleadores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssFecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssPerfil As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssIp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssAmbiente As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SMIfrmCargaRealizada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssNombreCompleto As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OBSERVACIONESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TSMDatosPersonales As ToolStripMenuItem
    Friend WithEvents TSMCargaEmpleador As ToolStripMenuItem
End Class
