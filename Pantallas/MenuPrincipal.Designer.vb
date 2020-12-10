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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuPrincipal))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_SUCURSAL = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TXT_VENTA = New System.Windows.Forms.TextBox()
        Me.TXT_COMPRA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBL_SALUDO = New System.Windows.Forms.Label()
        Me.BTN_INVENTARIO = New System.Windows.Forms.Button()
        Me.PB_IMAGEN = New System.Windows.Forms.PictureBox()
        Me.BTN_BACKUP = New System.Windows.Forms.Button()
        Me.BTN_COMPRAS = New System.Windows.Forms.Button()
        Me.BTN_ENCOMIENDA = New System.Windows.Forms.Button()
        Me.BTN_CLIENTE = New System.Windows.Forms.Button()
        Me.BTN_XML = New System.Windows.Forms.Button()
        Me.BTN_REPORTES = New System.Windows.Forms.Button()
        Me.BTN_CONSULTA = New System.Windows.Forms.Button()
        Me.BTN_PROVEEDOR = New System.Windows.Forms.Button()
        Me.BTN_PRODUCTO = New System.Windows.Forms.Button()
        Me.BTN_FE = New System.Windows.Forms.Button()
        Me.BTN_FAMILIA = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_USUARIO = New System.Windows.Forms.Button()
        Me.BTN_SUCURSAL = New System.Windows.Forms.Button()
        Me.BTN_COMPANIA = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PB_IMAGEN, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Size = New System.Drawing.Size(324, 68)
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
        Me.CMB_SUCURSAL.Size = New System.Drawing.Size(316, 21)
        Me.CMB_SUCURSAL.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TXT_VENTA)
        Me.GroupBox2.Controls.Add(Me.TXT_COMPRA)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(329, 458)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(159, 68)
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
        'LBL_SALUDO
        '
        Me.LBL_SALUDO.AutoSize = True
        Me.LBL_SALUDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_SALUDO.Location = New System.Drawing.Point(2, 70)
        Me.LBL_SALUDO.Name = "LBL_SALUDO"
        Me.LBL_SALUDO.Size = New System.Drawing.Size(51, 18)
        Me.LBL_SALUDO.TabIndex = 18
        Me.LBL_SALUDO.Text = "Label3"
        '
        'BTN_INVENTARIO
        '
        Me.BTN_INVENTARIO.Image = Global.VentaRepuestos.My.Resources.Resources.inventario
        Me.BTN_INVENTARIO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_INVENTARIO.Location = New System.Drawing.Point(133, 399)
        Me.BTN_INVENTARIO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_INVENTARIO.Name = "BTN_INVENTARIO"
        Me.BTN_INVENTARIO.Size = New System.Drawing.Size(64, 55)
        Me.BTN_INVENTARIO.TabIndex = 20
        Me.BTN_INVENTARIO.Text = "Inventario"
        Me.BTN_INVENTARIO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_INVENTARIO.UseVisualStyleBackColor = True
        '
        'PB_IMAGEN
        '
        Me.PB_IMAGEN.Location = New System.Drawing.Point(302, 128)
        Me.PB_IMAGEN.Name = "PB_IMAGEN"
        Me.PB_IMAGEN.Size = New System.Drawing.Size(295, 211)
        Me.PB_IMAGEN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_IMAGEN.TabIndex = 19
        Me.PB_IMAGEN.TabStop = False
        '
        'BTN_BACKUP
        '
        Me.BTN_BACKUP.Image = Global.VentaRepuestos.My.Resources.Resources.backup
        Me.BTN_BACKUP.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_BACKUP.Location = New System.Drawing.Point(712, 2)
        Me.BTN_BACKUP.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_BACKUP.Name = "BTN_BACKUP"
        Me.BTN_BACKUP.Size = New System.Drawing.Size(64, 55)
        Me.BTN_BACKUP.TabIndex = 17
        Me.BTN_BACKUP.Text = "BackUp"
        Me.BTN_BACKUP.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_BACKUP.UseVisualStyleBackColor = True
        '
        'BTN_COMPRAS
        '
        Me.BTN_COMPRAS.Image = Global.VentaRepuestos.My.Resources.Resources.compras
        Me.BTN_COMPRAS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_COMPRAS.Location = New System.Drawing.Point(521, 2)
        Me.BTN_COMPRAS.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_COMPRAS.Name = "BTN_COMPRAS"
        Me.BTN_COMPRAS.Size = New System.Drawing.Size(64, 55)
        Me.BTN_COMPRAS.TabIndex = 16
        Me.BTN_COMPRAS.Text = "Compras"
        Me.BTN_COMPRAS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_COMPRAS.UseVisualStyleBackColor = True
        '
        'BTN_ENCOMIENDA
        '
        Me.BTN_ENCOMIENDA.Image = Global.VentaRepuestos.My.Resources.Resources.encomienda
        Me.BTN_ENCOMIENDA.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_ENCOMIENDA.Location = New System.Drawing.Point(840, 56)
        Me.BTN_ENCOMIENDA.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_ENCOMIENDA.Name = "BTN_ENCOMIENDA"
        Me.BTN_ENCOMIENDA.Size = New System.Drawing.Size(64, 55)
        Me.BTN_ENCOMIENDA.TabIndex = 15
        Me.BTN_ENCOMIENDA.Text = "Envios"
        Me.BTN_ENCOMIENDA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_ENCOMIENDA.UseVisualStyleBackColor = True
        '
        'BTN_CLIENTE
        '
        Me.BTN_CLIENTE.Image = Global.VentaRepuestos.My.Resources.Resources.client
        Me.BTN_CLIENTE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_CLIENTE.Location = New System.Drawing.Point(196, 2)
        Me.BTN_CLIENTE.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_CLIENTE.Name = "BTN_CLIENTE"
        Me.BTN_CLIENTE.Size = New System.Drawing.Size(64, 55)
        Me.BTN_CLIENTE.TabIndex = 14
        Me.BTN_CLIENTE.Text = "Cliente"
        Me.BTN_CLIENTE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_CLIENTE.UseVisualStyleBackColor = True
        '
        'BTN_XML
        '
        Me.BTN_XML.Image = Global.VentaRepuestos.My.Resources.Resources.importar_xml
        Me.BTN_XML.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_XML.Location = New System.Drawing.Point(69, 399)
        Me.BTN_XML.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_XML.Name = "BTN_XML"
        Me.BTN_XML.Size = New System.Drawing.Size(64, 55)
        Me.BTN_XML.TabIndex = 12
        Me.BTN_XML.Text = "XMLs"
        Me.BTN_XML.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_XML.UseVisualStyleBackColor = True
        '
        'BTN_REPORTES
        '
        Me.BTN_REPORTES.Image = Global.VentaRepuestos.My.Resources.Resources.reportes
        Me.BTN_REPORTES.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_REPORTES.Location = New System.Drawing.Point(776, 2)
        Me.BTN_REPORTES.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_REPORTES.Name = "BTN_REPORTES"
        Me.BTN_REPORTES.Size = New System.Drawing.Size(64, 55)
        Me.BTN_REPORTES.TabIndex = 11
        Me.BTN_REPORTES.Text = "Reportes"
        Me.BTN_REPORTES.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_REPORTES.UseVisualStyleBackColor = True
        '
        'BTN_CONSULTA
        '
        Me.BTN_CONSULTA.Image = Global.VentaRepuestos.My.Resources.Resources.consultas
        Me.BTN_CONSULTA.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_CONSULTA.Location = New System.Drawing.Point(5, 399)
        Me.BTN_CONSULTA.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_CONSULTA.Name = "BTN_CONSULTA"
        Me.BTN_CONSULTA.Size = New System.Drawing.Size(64, 55)
        Me.BTN_CONSULTA.TabIndex = 10
        Me.BTN_CONSULTA.Text = "Consultas"
        Me.BTN_CONSULTA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_CONSULTA.UseVisualStyleBackColor = True
        '
        'BTN_PROVEEDOR
        '
        Me.BTN_PROVEEDOR.Image = Global.VentaRepuestos.My.Resources.Resources.proveedor1
        Me.BTN_PROVEEDOR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_PROVEEDOR.Location = New System.Drawing.Point(261, 2)
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
        Me.BTN_PRODUCTO.Location = New System.Drawing.Point(391, 2)
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
        Me.BTN_FE.Location = New System.Drawing.Point(456, 2)
        Me.BTN_FE.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_FE.Name = "BTN_FE"
        Me.BTN_FE.Size = New System.Drawing.Size(64, 55)
        Me.BTN_FE.TabIndex = 7
        Me.BTN_FE.Text = "Ventas"
        Me.BTN_FE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_FE.UseVisualStyleBackColor = True
        '
        'BTN_FAMILIA
        '
        Me.BTN_FAMILIA.Image = Global.VentaRepuestos.My.Resources.Resources.familia
        Me.BTN_FAMILIA.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_FAMILIA.Location = New System.Drawing.Point(326, 2)
        Me.BTN_FAMILIA.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_FAMILIA.Name = "BTN_FAMILIA"
        Me.BTN_FAMILIA.Size = New System.Drawing.Size(64, 55)
        Me.BTN_FAMILIA.TabIndex = 13
        Me.BTN_FAMILIA.Text = "Familia"
        Me.BTN_FAMILIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_FAMILIA.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_SALIR.Location = New System.Drawing.Point(840, 2)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_SALIR.TabIndex = 3
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'BTN_USUARIO
        '
        Me.BTN_USUARIO.Image = Global.VentaRepuestos.My.Resources.Resources.usuario
        Me.BTN_USUARIO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_USUARIO.Location = New System.Drawing.Point(131, 2)
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
        Me.BTN_SUCURSAL.Location = New System.Drawing.Point(66, 2)
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
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(906, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_INVENTARIO)
        Me.Controls.Add(Me.PB_IMAGEN)
        Me.Controls.Add(Me.LBL_SALUDO)
        Me.Controls.Add(Me.BTN_BACKUP)
        Me.Controls.Add(Me.BTN_COMPRAS)
        Me.Controls.Add(Me.BTN_ENCOMIENDA)
        Me.Controls.Add(Me.BTN_CLIENTE)
        Me.Controls.Add(Me.BTN_XML)
        Me.Controls.Add(Me.BTN_REPORTES)
        Me.Controls.Add(Me.BTN_CONSULTA)
        Me.Controls.Add(Me.BTN_PROVEEDOR)
        Me.Controls.Add(Me.BTN_PRODUCTO)
        Me.Controls.Add(Me.BTN_FE)
        Me.Controls.Add(Me.BTN_FAMILIA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_USUARIO)
        Me.Controls.Add(Me.BTN_SUCURSAL)
        Me.Controls.Add(Me.BTN_COMPANIA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(908, 530)
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PB_IMAGEN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents BTN_FAMILIA As Button
    Friend WithEvents BTN_FE As Button
    Friend WithEvents BTN_PRODUCTO As Button
    Friend WithEvents BTN_PROVEEDOR As Button
    Friend WithEvents BTN_CONSULTA As Button
    Friend WithEvents BTN_REPORTES As Button
    Friend WithEvents BTN_XML As Button
    Friend WithEvents BTN_CLIENTE As Button
    Friend WithEvents BTN_ENCOMIENDA As Button
    Friend WithEvents BTN_COMPRAS As Button
    Friend WithEvents BTN_BACKUP As Button
    Friend WithEvents LBL_SALUDO As Label
    Friend WithEvents PB_IMAGEN As PictureBox
    Friend WithEvents BTN_INVENTARIO As Button
End Class
