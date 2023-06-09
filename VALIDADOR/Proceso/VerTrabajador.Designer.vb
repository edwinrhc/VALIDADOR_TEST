<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerTrabajador
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
        Me.DgvTrabajador = New System.Windows.Forms.DataGridView()
        CType(Me.DgvTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvTrabajador
        '
        Me.DgvTrabajador.AllowUserToAddRows = False
        Me.DgvTrabajador.AllowUserToDeleteRows = False
        Me.DgvTrabajador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvTrabajador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrabajador.Location = New System.Drawing.Point(12, 12)
        Me.DgvTrabajador.Name = "DgvTrabajador"
        Me.DgvTrabajador.ReadOnly = True
        Me.DgvTrabajador.Size = New System.Drawing.Size(1313, 624)
        Me.DgvTrabajador.TabIndex = 14
        '
        'VerTrabajador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1337, 659)
        Me.Controls.Add(Me.DgvTrabajador)
        Me.Name = "VerTrabajador"
        Me.Text = "VerTrabajador"
        CType(Me.DgvTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvTrabajador As DataGridView
End Class
