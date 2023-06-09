<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class verRemuneraciones
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
        Me.DgvRemuneraciones = New System.Windows.Forms.DataGridView()
        CType(Me.DgvRemuneraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvRemuneraciones
        '
        Me.DgvRemuneraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRemuneraciones.Location = New System.Drawing.Point(12, 12)
        Me.DgvRemuneraciones.Name = "DgvRemuneraciones"
        Me.DgvRemuneraciones.Size = New System.Drawing.Size(1007, 587)
        Me.DgvRemuneraciones.TabIndex = 0
        '
        'verRemuneraciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 611)
        Me.Controls.Add(Me.DgvRemuneraciones)
        Me.Name = "verRemuneraciones"
        Me.Text = "verRemuneraciones"
        CType(Me.DgvRemuneraciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvRemuneraciones As DataGridView
End Class
