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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_SUCURSAL = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TXT_VENTA = New System.Windows.Forms.TextBox()
        Me.TXT_COMPRA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_PROVEEDOR = New System.Windows.Forms.Button()
        Me.BTN_PRODUCTO = New System.Windows.Forms.Button()
        Me.BTN_FE = New System.Windows.Forms.Button()
        Me.BTN_CLIENTE = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_USUARIO = New System.Windows.Forms.Button()
        Me.BTN_SUCURSAL = New System.Windows.Forms.Button()
        Me.BTN_COMPANIA = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.CMB_SUCURSAL)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 458)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(200, 68)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Sucursal ]"
        '
        'CMB_SUCURSAL
        '
        Me.CMB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_SUCURSAL.FormattingEnabled = True
        Me.CMB_SUCURSAL.Location = New System.Drawing.Point(4, 27)
        Me.CMB_SUCURSAL.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_SUCURSAL.Name = "CMB_SUCURSAL"
        Me.CMB_SUCURSAL.Size = New System.Drawing.Size(192, 21)
        Me.CMB_SUCURSAL.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TXT_VENTA)
        Me.GroupBox2.Controls.Add(Me.TXT_COMPRA)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(205, 458)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(248, 68)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Tipo cambio ]"
        '
        'TXT_VENTA
        '
        Me.TXT_VENTA.Enabled = False
        Me.TXT_VENTA.Location = New System.Drawing.Point(69, 41)
        Me.TXT_VENTA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_VENTA.Name = "TXT_VENTA"
        Me.TXT_VENTA.Size = New System.Drawing.Size(76, 20)
        Me.TXT_VENTA.TabIndex = 3
        '
        'TXT_COMPRA
        '
        Me.TXT_COMPRA.Enabled = False
        Me.TXT_COMPRA.Location = New System.Drawing.Point(69, 18)
        Me.TXT_COMPRA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_COMPRA.Name = "TXT_COMPRA"
        Me.TXT_COMPRA.Size = New System.Drawing.Size(76, 20)
        Me.TXT_COMPRA.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 41)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Venta :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compra :"
        '
        'BTN_PROVEEDOR
        '
        Me.BTN_PROVEEDOR.Image = Global.VentaRepuestos.My.Resources.Resources.proveedor1
        Me.BTN_PROVEEDOR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_PROVEEDOR.Location = New System.Drawing.Point(336, 2)
        Me.BTN_PROVEEDOR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_PROVEEDOR.Name = "BTN_PROVEEDOR"
        Me.BTN_PROVEEDOR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_PROVEEDOR.TabIndex = 9
        Me.BTN_PROVEEDOR.Text = "Proveedor"
        Me.BTN_PROVEEDOR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_PROVEEDOR.UseVisualStyleBackColor = True
        '
        'BTN_PRODUCTO
        '
        Me.BTN_PRODUCTO.Image = Global.VentaRepuestos.My.Resources.Resources.productos
        Me.BTN_PRODUCTO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_PRODUCTO.Location = New System.Drawing.Point(269, 2)
        Me.BTN_PRODUCTO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_PRODUCTO.Name = "BTN_PRODUCTO"
        Me.BTN_PRODUCTO.Size = New System.Drawing.Size(64, 55)
        Me.BTN_PRODUCTO.TabIndex = 8
        Me.BTN_PRODUCTO.Text = "Producto"
        Me.BTN_PRODUCTO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_PRODUCTO.UseVisualStyleBackColor = True
        '
        'BTN_FE
        '
        Me.BTN_FE.Image = Global.VentaRepuestos.My.Resources.Resources.factura
        Me.BTN_FE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_FE.Location = New System.Drawing.Point(403, 2)
        Me.BTN_FE.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_FE.Name = "BTN_FE"
        Me.BTN_FE.Size = New System.Drawing.Size(64, 55)
        Me.BTN_FE.TabIndex = 7
        Me.BTN_FE.Text = "F.E"
        Me.BTN_FE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_FE.UseVisualStyleBackColor = True
        '
        'BTN_CLIENTE
        '
        Me.BTN_CLIENTE.Image = Global.VentaRepuestos.My.Resources.Resources.client
        Me.BTN_CLIENTE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_CLIENTE.Location = New System.Drawing.Point(202, 2)
        Me.BTN_CLIENTE.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_CLIENTE.Name = "BTN_CLIENTE"
        Me.BTN_CLIENTE.Size = New System.Drawing.Size(64, 55)
        Me.BTN_CLIENTE.TabIndex = 6
        Me.BTN_CLIENTE.Text = "Cliente"
        Me.BTN_CLIENTE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_CLIENTE.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(806, 2)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 3
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'BTN_USUARIO
        '
        Me.BTN_USUARIO.Image = Global.VentaRepuestos.My.Resources.Resources.usuario
        Me.BTN_USUARIO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_USUARIO.Location = New System.Drawing.Point(135, 2)
        Me.BTN_USUARIO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_USUARIO.Name = "BTN_USUARIO"
        Me.BTN_USUARIO.Size = New System.Drawing.Size(64, 55)
        Me.BTN_USUARIO.TabIndex = 2
        Me.BTN_USUARIO.Text = "Usuario"
        Me.BTN_USUARIO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_USUARIO.UseVisualStyleBackColor = True
        '
        'BTN_SUCURSAL
        '
        Me.BTN_SUCURSAL.Image = Global.VentaRepuestos.My.Resources.Resources.sucursal
        Me.BTN_SUCURSAL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_SUCURSAL.Location = New System.Drawing.Point(68, 2)
        Me.BTN_SUCURSAL.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SUCURSAL.Name = "BTN_SUCURSAL"
        Me.BTN_SUCURSAL.Size = New System.Drawing.Size(64, 55)
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
        Me.BTN_COMPANIA.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_COMPANIA.Name = "BTN_COMPANIA"
        Me.BTN_COMPANIA.Size = New System.Drawing.Size(64, 55)
        Me.BTN_COMPANIA.TabIndex = 0
        Me.BTN_COMPANIA.Text = "Compañía"
        Me.BTN_COMPANIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_COMPANIA.UseVisualStyleBackColor = True
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_PROVEEDOR)
        Me.Controls.Add(Me.BTN_PRODUCTO)
        Me.Controls.Add(Me.BTN_FE)
        Me.Controls.Add(Me.BTN_CLIENTE)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_USUARIO)
        Me.Controls.Add(Me.BTN_SUCURSAL)
        Me.Controls.Add(Me.BTN_COMPANIA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(908, 530)
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_COMPANIA As Button
    Friend WithEvents BTN_SUCURSAL As Button
    Friend WithEvents BTN_USUARIO As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CMB_SUCURSAL As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_VENTA As TextBox
    Friend WithEvents TXT_COMPRA As TextBox
    Friend WithEvents BTN_CLIENTE As Button
    Friend WithEvents BTN_FE As Button
    Friend WithEvents BTN_PRODUCTO As Button
    Friend WithEvents BTN_PROVEEDOR As Button
End Class
