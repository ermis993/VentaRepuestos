<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscadorMini
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.CMB = New System.Windows.Forms.ComboBox()
        Me.TXT_BUSCADOR = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(2, 2)
        Me.BTN_BUSCAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(64, 21)
        Me.BTN_BUSCAR.TabIndex = 3
        Me.BTN_BUSCAR.Text = "Buscar"
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'CMB
        '
        Me.CMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CMB.FormattingEnabled = True
        Me.CMB.Location = New System.Drawing.Point(155, 2)
        Me.CMB.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB.Name = "CMB"
        Me.CMB.Size = New System.Drawing.Size(245, 21)
        Me.CMB.TabIndex = 5
        '
        'TXT_BUSCADOR
        '
        Me.TXT_BUSCADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TXT_BUSCADOR.Location = New System.Drawing.Point(67, 2)
        Me.TXT_BUSCADOR.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_BUSCADOR.Name = "TXT_BUSCADOR"
        Me.TXT_BUSCADOR.Size = New System.Drawing.Size(85, 20)
        Me.TXT_BUSCADOR.TabIndex = 4
        '
        'BuscadorMini
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BTN_BUSCAR)
        Me.Controls.Add(Me.CMB)
        Me.Controls.Add(Me.TXT_BUSCADOR)
        Me.Name = "BuscadorMini"
        Me.Size = New System.Drawing.Size(403, 25)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_BUSCAR As Button
    Friend WithEvents CMB As ComboBox
    Friend WithEvents TXT_BUSCADOR As TextBox
End Class
