<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filtro
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
        Me.CMB = New System.Windows.Forms.ComboBox()
        Me.TXT = New System.Windows.Forms.TextBox()
        Me.BTN_FILTRAR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CMB
        '
        Me.CMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB.FormattingEnabled = True
        Me.CMB.Location = New System.Drawing.Point(0, 3)
        Me.CMB.Name = "CMB"
        Me.CMB.Size = New System.Drawing.Size(135, 23)
        Me.CMB.TabIndex = 0
        '
        'TXT
        '
        Me.TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT.Location = New System.Drawing.Point(136, 3)
        Me.TXT.Multiline = True
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(134, 23)
        Me.TXT.TabIndex = 1
        '
        'BTN_FILTRAR
        '
        Me.BTN_FILTRAR.BackColor = System.Drawing.Color.Transparent
        Me.BTN_FILTRAR.Image = Global.VentaRepuestos.My.Resources.Resources.filtro
        Me.BTN_FILTRAR.Location = New System.Drawing.Point(271, -1)
        Me.BTN_FILTRAR.Name = "BTN_FILTRAR"
        Me.BTN_FILTRAR.Size = New System.Drawing.Size(32, 30)
        Me.BTN_FILTRAR.TabIndex = 2
        Me.BTN_FILTRAR.UseVisualStyleBackColor = False
        '
        'Filtro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BTN_FILTRAR)
        Me.Controls.Add(Me.TXT)
        Me.Controls.Add(Me.CMB)
        Me.Name = "Filtro"
        Me.Size = New System.Drawing.Size(306, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CMB As ComboBox
    Friend WithEvents TXT As TextBox
    Friend WithEvents BTN_FILTRAR As Button
End Class
