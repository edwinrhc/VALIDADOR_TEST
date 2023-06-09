<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class verEmpleador
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
        Me.DgvEmpleador = New System.Windows.Forms.DataGridView()
        CType(Me.DgvEmpleador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvEmpleador
        '
        Me.DgvEmpleador.AllowUserToAddRows = False
        Me.DgvEmpleador.AllowUserToDeleteRows = False
        Me.DgvEmpleador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvEmpleador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvEmpleador.Location = New System.Drawing.Point(-35, 12)
        Me.DgvEmpleador.Name = "DgvEmpleador"
        Me.DgvEmpleador.ReadOnly = True
        Me.DgvEmpleador.Size = New System.Drawing.Size(1266, 626)
        Me.DgvEmpleador.TabIndex = 15
        '
        'verEmpleador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1243, 653)
        Me.Controls.Add(Me.DgvEmpleador)
        Me.Name = "verEmpleador"
        Me.Text = "verEmpleador"
        CType(Me.DgvEmpleador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvEmpleador As DataGridView
End Class
