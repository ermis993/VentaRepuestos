<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion
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
        Me.BTN_FACTURAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BTN_FACTURAR
        '
        Me.BTN_FACTURAR.Image = Global.VentaRepuestos.My.Resources.Resources.facturar
        Me.BTN_FACTURAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_FACTURAR.Location = New System.Drawing.Point(2, 1)
        Me.BTN_FACTURAR.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BTN_FACTURAR.Name = "BTN_FACTURAR"
        Me.BTN_FACTURAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_FACTURAR.TabIndex = 0
        Me.BTN_FACTURAR.Text = "Factura"
        Me.BTN_FACTURAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_FACTURAR.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(501, 1)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 4
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(602, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_FACTURAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturación"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_FACTURAR As Button
    Friend WithEvents BTN_SALIR As Button
End Class
