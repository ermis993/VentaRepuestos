<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Buscador
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.CMB = New System.Windows.Forms.ComboBox()
        Me.TXT_BUSCADOR = New System.Windows.Forms.TextBox()
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CMB
        '
        Me.CMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB.FormattingEnabled = True
        Me.CMB.Location = New System.Drawing.Point(212, 2)
        Me.CMB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CMB.Name = "CMB"
        Me.CMB.Size = New System.Drawing.Size(367, 26)
        Me.CMB.TabIndex = 5
        '
        'TXT_BUSCADOR
        '
        Me.TXT_BUSCADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_BUSCADOR.Location = New System.Drawing.Point(95, 2)
        Me.TXT_BUSCADOR.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TXT_BUSCADOR.Name = "TXT_BUSCADOR"
        Me.TXT_BUSCADOR.Size = New System.Drawing.Size(112, 26)
        Me.TXT_BUSCADOR.TabIndex = 4
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(3, 1)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(86, 28)
        Me.BTN_BUSCAR.TabIndex = 6
        Me.BTN_BUSCAR.Text = "Buscar"
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'Buscador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BTN_BUSCAR)
        Me.Controls.Add(Me.CMB)
        Me.Controls.Add(Me.TXT_BUSCADOR)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Buscador"
        Me.Size = New System.Drawing.Size(582, 32)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CMB As ComboBox
    Friend WithEvents TXT_BUSCADOR As TextBox
    Friend WithEvents BTN_BUSCAR As Button
End Class
