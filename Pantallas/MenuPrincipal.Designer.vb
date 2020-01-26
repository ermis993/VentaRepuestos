<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPrincipal
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
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_USUARIO = New System.Windows.Forms.Button()
        Me.BTN_SUCURSAL = New System.Windows.Forms.Button()
        Me.BTN_COMPANIA = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(1042, 517)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_SALIR.TabIndex = 23
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_USUARIO
        '
        Me.BTN_USUARIO.Image = Global.VentaRepuestos.My.Resources.Resources.usuario
        Me.BTN_USUARIO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_USUARIO.Location = New System.Drawing.Point(183, 2)
        Me.BTN_USUARIO.Name = "BTN_USUARIO"
        Me.BTN_USUARIO.Size = New System.Drawing.Size(85, 59)
        Me.BTN_USUARIO.TabIndex = 2
        Me.BTN_USUARIO.Text = "Usuario"
        Me.BTN_USUARIO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_USUARIO.UseVisualStyleBackColor = True
        '
        'BTN_SUCURSAL
        '
        Me.BTN_SUCURSAL.Image = Global.VentaRepuestos.My.Resources.Resources.sucursal
        Me.BTN_SUCURSAL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_SUCURSAL.Location = New System.Drawing.Point(92, 2)
        Me.BTN_SUCURSAL.Name = "BTN_SUCURSAL"
        Me.BTN_SUCURSAL.Size = New System.Drawing.Size(85, 59)
        Me.BTN_SUCURSAL.TabIndex = 1
        Me.BTN_SUCURSAL.Text = "Sucursal"
        Me.BTN_SUCURSAL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_SUCURSAL.UseVisualStyleBackColor = True
        '
        'BTN_COMPANIA
        '
        Me.BTN_COMPANIA.Image = Global.VentaRepuestos.My.Resources.Resources.compania
        Me.BTN_COMPANIA.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_COMPANIA.Location = New System.Drawing.Point(1, 2)
        Me.BTN_COMPANIA.Name = "BTN_COMPANIA"
        Me.BTN_COMPANIA.Size = New System.Drawing.Size(85, 59)
        Me.BTN_COMPANIA.TabIndex = 0
        Me.BTN_COMPANIA.Text = "Compañía"
        Me.BTN_COMPANIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_COMPANIA.UseVisualStyleBackColor = True
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 583)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_USUARIO)
        Me.Controls.Add(Me.BTN_SUCURSAL)
        Me.Controls.Add(Me.BTN_COMPANIA)
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Principal"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_COMPANIA As Button
    Friend WithEvents BTN_SUCURSAL As Button
    Friend WithEvents BTN_USUARIO As Button
    Friend WithEvents BTN_SALIR As Button
End Class
