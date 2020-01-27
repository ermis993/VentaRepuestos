<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuPrincipal
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
        Me.BTN_USUARIO = New System.Windows.Forms.Button()
        Me.BTN_SUCURSAL = New System.Windows.Forms.Button()
        Me.BTN_COMPANIA = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_SUCURSAL = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(1053, 2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_SALIR.TabIndex = 3
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.CMB_SUCURSAL)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 516)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 76)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Sucursal ]"
        '
        'CMB_SUCURSAL
        '
        Me.CMB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_SUCURSAL.FormattingEnabled = True
        Me.CMB_SUCURSAL.Location = New System.Drawing.Point(6, 33)
        Me.CMB_SUCURSAL.Name = "CMB_SUCURSAL"
        Me.CMB_SUCURSAL.Size = New System.Drawing.Size(255, 24)
        Me.CMB_SUCURSAL.TabIndex = 0
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1188, 600)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_USUARIO)
        Me.Controls.Add(Me.BTN_SUCURSAL)
        Me.Controls.Add(Me.BTN_COMPANIA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimumSize = New System.Drawing.Size(1206, 647)
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_COMPANIA As Button
    Friend WithEvents BTN_SUCURSAL As Button
    Friend WithEvents BTN_USUARIO As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CMB_SUCURSAL As ComboBox
End Class
