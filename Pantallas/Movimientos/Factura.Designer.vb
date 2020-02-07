<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Factura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Factura))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TAB_ENC = New System.Windows.Forms.TabPage()
        Me.Cliente = New VentaRepuestos.Buscador()
        Me.TXT_DESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXT_PLAZO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMB_MONEDA = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMB_FORMAPAGO = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TAB_DET = New System.Windows.Forms.TabPage()
        Me.BTN_INGRESAR = New System.Windows.Forms.Button()
        Me.BTN_CALCULAR = New System.Windows.Forms.Button()
        Me.TXT_TOTAL = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TXT_SUBTOTAL = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TXT_IMPUESTOTOTAL = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXT_IMPUESTO = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TXT_DESCUENTOTOTAL = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXT_DESCUENTO = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXT_PRECIO = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXT_CANTIDAD = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXT_UNIDAD = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Producto = New VentaRepuestos.Buscador()
        Me.TAB_LINEAS = New System.Windows.Forms.TabPage()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_NUMERO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMB_DOCUMENTO = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_TIPO_CAMBIO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHA = New System.Windows.Forms.DateTimePicker()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TAB_ENC.SuspendLayout()
        Me.TAB_DET.SuspendLayout()
        Me.TAB_LINEAS.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TAB_ENC)
        Me.TabControl1.Controls.Add(Me.TAB_DET)
        Me.TabControl1.Controls.Add(Me.TAB_LINEAS)
        Me.TabControl1.Location = New System.Drawing.Point(2, 85)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(881, 234)
        Me.TabControl1.TabIndex = 1
        '
        'TAB_ENC
        '
        Me.TAB_ENC.Controls.Add(Me.Cliente)
        Me.TAB_ENC.Controls.Add(Me.TXT_DESCRIPCION)
        Me.TAB_ENC.Controls.Add(Me.Label10)
        Me.TAB_ENC.Controls.Add(Me.Label9)
        Me.TAB_ENC.Controls.Add(Me.TXT_PLAZO)
        Me.TAB_ENC.Controls.Add(Me.Label8)
        Me.TAB_ENC.Controls.Add(Me.CMB_MONEDA)
        Me.TAB_ENC.Controls.Add(Me.Label7)
        Me.TAB_ENC.Controls.Add(Me.Label6)
        Me.TAB_ENC.Controls.Add(Me.CMB_FORMAPAGO)
        Me.TAB_ENC.Controls.Add(Me.Label5)
        Me.TAB_ENC.Location = New System.Drawing.Point(4, 22)
        Me.TAB_ENC.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Name = "TAB_ENC"
        Me.TAB_ENC.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Size = New System.Drawing.Size(873, 208)
        Me.TAB_ENC.TabIndex = 0
        Me.TAB_ENC.Text = "[ Encabezado ]"
        Me.TAB_ENC.UseVisualStyleBackColor = True
        '
        'Cliente
        '
        Me.Cliente.CODIGO = Nothing
        Me.Cliente.DESCRIPCION = Nothing
        Me.Cliente.Location = New System.Drawing.Point(111, 15)
        Me.Cliente.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OTROS_CAMP0S = Nothing
        Me.Cliente.PANTALLA = Nothing
        Me.Cliente.Size = New System.Drawing.Size(451, 27)
        Me.Cliente.TabIndex = 1
        Me.Cliente.TABLA_BUSCAR = Nothing
        Me.Cliente.VALOR = ""
        Me.Cliente.VALOR_DESCRIPCION = Nothing
        '
        'TXT_DESCRIPCION
        '
        Me.TXT_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCRIPCION.Location = New System.Drawing.Point(111, 137)
        Me.TXT_DESCRIPCION.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DESCRIPCION.MaxLength = 250
        Me.TXT_DESCRIPCION.Multiline = True
        Me.TXT_DESCRIPCION.Name = "TXT_DESCRIPCION"
        Me.TXT_DESCRIPCION.Size = New System.Drawing.Size(451, 62)
        Me.TXT_DESCRIPCION.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label10.Location = New System.Drawing.Point(10, 137)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 18)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Descripción :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label9.Location = New System.Drawing.Point(190, 108)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 18)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "día(s)"
        '
        'TXT_PLAZO
        '
        Me.TXT_PLAZO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PLAZO.Location = New System.Drawing.Point(111, 106)
        Me.TXT_PLAZO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_PLAZO.MaxLength = 3
        Me.TXT_PLAZO.Name = "TXT_PLAZO"
        Me.TXT_PLAZO.Size = New System.Drawing.Size(76, 24)
        Me.TXT_PLAZO.TabIndex = 7
        Me.TXT_PLAZO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label8.Location = New System.Drawing.Point(51, 108)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 18)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Plazo :"
        '
        'CMB_MONEDA
        '
        Me.CMB_MONEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_MONEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_MONEDA.FormattingEnabled = True
        Me.CMB_MONEDA.Items.AddRange(New Object() {"COL-Colones", "DOL-Dólares"})
        Me.CMB_MONEDA.Location = New System.Drawing.Point(111, 76)
        Me.CMB_MONEDA.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_MONEDA.Name = "CMB_MONEDA"
        Me.CMB_MONEDA.Size = New System.Drawing.Size(132, 26)
        Me.CMB_MONEDA.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.Location = New System.Drawing.Point(33, 79)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 18)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Moneda :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label6.Location = New System.Drawing.Point(42, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cliente :"
        '
        'CMB_FORMAPAGO
        '
        Me.CMB_FORMAPAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FORMAPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_FORMAPAGO.FormattingEnabled = True
        Me.CMB_FORMAPAGO.Items.AddRange(New Object() {"EF-Efectivo", "TA-Tarjeta", "TR-Transferencia"})
        Me.CMB_FORMAPAGO.Location = New System.Drawing.Point(111, 46)
        Me.CMB_FORMAPAGO.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_FORMAPAGO.Name = "CMB_FORMAPAGO"
        Me.CMB_FORMAPAGO.Size = New System.Drawing.Size(132, 26)
        Me.CMB_FORMAPAGO.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(8, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 18)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Forma Pago :"
        '
        'TAB_DET
        '
        Me.TAB_DET.Controls.Add(Me.BTN_INGRESAR)
        Me.TAB_DET.Controls.Add(Me.BTN_CALCULAR)
        Me.TAB_DET.Controls.Add(Me.TXT_TOTAL)
        Me.TAB_DET.Controls.Add(Me.Label21)
        Me.TAB_DET.Controls.Add(Me.TXT_SUBTOTAL)
        Me.TAB_DET.Controls.Add(Me.Label20)
        Me.TAB_DET.Controls.Add(Me.TXT_IMPUESTOTOTAL)
        Me.TAB_DET.Controls.Add(Me.Label18)
        Me.TAB_DET.Controls.Add(Me.TXT_IMPUESTO)
        Me.TAB_DET.Controls.Add(Me.Label17)
        Me.TAB_DET.Controls.Add(Me.TXT_DESCUENTOTOTAL)
        Me.TAB_DET.Controls.Add(Me.Label16)
        Me.TAB_DET.Controls.Add(Me.TXT_DESCUENTO)
        Me.TAB_DET.Controls.Add(Me.Label15)
        Me.TAB_DET.Controls.Add(Me.TXT_PRECIO)
        Me.TAB_DET.Controls.Add(Me.Label14)
        Me.TAB_DET.Controls.Add(Me.TXT_CANTIDAD)
        Me.TAB_DET.Controls.Add(Me.Label13)
        Me.TAB_DET.Controls.Add(Me.TXT_UNIDAD)
        Me.TAB_DET.Controls.Add(Me.Label12)
        Me.TAB_DET.Controls.Add(Me.Label11)
        Me.TAB_DET.Controls.Add(Me.Producto)
        Me.TAB_DET.Location = New System.Drawing.Point(4, 22)
        Me.TAB_DET.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Name = "TAB_DET"
        Me.TAB_DET.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Size = New System.Drawing.Size(873, 208)
        Me.TAB_DET.TabIndex = 1
        Me.TAB_DET.Text = "[ Detalle ]"
        Me.TAB_DET.UseVisualStyleBackColor = True
        '
        'BTN_INGRESAR
        '
        Me.BTN_INGRESAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_INGRESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_INGRESAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_INGRESAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(771, 162)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_INGRESAR.TabIndex = 21
        Me.BTN_INGRESAR.Text = "Ingresar"
        Me.BTN_INGRESAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_INGRESAR.UseVisualStyleBackColor = False
        '
        'BTN_CALCULAR
        '
        Me.BTN_CALCULAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_CALCULAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CALCULAR.Image = Global.VentaRepuestos.My.Resources.Resources.calculadora
        Me.BTN_CALCULAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CALCULAR.Location = New System.Drawing.Point(652, 162)
        Me.BTN_CALCULAR.Name = "BTN_CALCULAR"
        Me.BTN_CALCULAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_CALCULAR.TabIndex = 20
        Me.BTN_CALCULAR.Text = "Calcular"
        Me.BTN_CALCULAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CALCULAR.UseVisualStyleBackColor = False
        '
        'TXT_TOTAL
        '
        Me.TXT_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TOTAL.Location = New System.Drawing.Point(349, 152)
        Me.TXT_TOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_TOTAL.Name = "TXT_TOTAL"
        Me.TXT_TOTAL.ReadOnly = True
        Me.TXT_TOTAL.Size = New System.Drawing.Size(170, 24)
        Me.TXT_TOTAL.TabIndex = 19
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label21.Location = New System.Drawing.Point(301, 155)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(49, 18)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Total :"
        '
        'TXT_SUBTOTAL
        '
        Me.TXT_SUBTOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_SUBTOTAL.Location = New System.Drawing.Point(119, 152)
        Me.TXT_SUBTOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_SUBTOTAL.Name = "TXT_SUBTOTAL"
        Me.TXT_SUBTOTAL.ReadOnly = True
        Me.TXT_SUBTOTAL.Size = New System.Drawing.Size(160, 24)
        Me.TXT_SUBTOTAL.TabIndex = 17
        Me.TXT_SUBTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label20.Location = New System.Drawing.Point(47, 155)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 18)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Subtotal :"
        '
        'TXT_IMPUESTOTOTAL
        '
        Me.TXT_IMPUESTOTOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_IMPUESTOTOTAL.Location = New System.Drawing.Point(349, 122)
        Me.TXT_IMPUESTOTOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_IMPUESTOTOTAL.Name = "TXT_IMPUESTOTOTAL"
        Me.TXT_IMPUESTOTOTAL.ReadOnly = True
        Me.TXT_IMPUESTOTOTAL.Size = New System.Drawing.Size(218, 24)
        Me.TXT_IMPUESTOTOTAL.TabIndex = 15
        Me.TXT_IMPUESTOTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label18.Location = New System.Drawing.Point(240, 125)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(109, 18)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Impuesto total :"
        '
        'TXT_IMPUESTO
        '
        Me.TXT_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_IMPUESTO.Location = New System.Drawing.Point(119, 122)
        Me.TXT_IMPUESTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_IMPUESTO.MaxLength = 3
        Me.TXT_IMPUESTO.Name = "TXT_IMPUESTO"
        Me.TXT_IMPUESTO.ReadOnly = True
        Me.TXT_IMPUESTO.Size = New System.Drawing.Size(89, 24)
        Me.TXT_IMPUESTO.TabIndex = 13
        Me.TXT_IMPUESTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label17.Location = New System.Drawing.Point(40, 125)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 18)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Impuesto :"
        '
        'TXT_DESCUENTOTOTAL
        '
        Me.TXT_DESCUENTOTOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCUENTOTOTAL.Location = New System.Drawing.Point(349, 95)
        Me.TXT_DESCUENTOTOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DESCUENTOTOTAL.Name = "TXT_DESCUENTOTOTAL"
        Me.TXT_DESCUENTOTOTAL.ReadOnly = True
        Me.TXT_DESCUENTOTOTAL.Size = New System.Drawing.Size(218, 24)
        Me.TXT_DESCUENTOTOTAL.TabIndex = 11
        Me.TXT_DESCUENTOTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label16.Location = New System.Drawing.Point(225, 98)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 18)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Descuento total :"
        '
        'TXT_DESCUENTO
        '
        Me.TXT_DESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCUENTO.Location = New System.Drawing.Point(120, 95)
        Me.TXT_DESCUENTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DESCUENTO.MaxLength = 3
        Me.TXT_DESCUENTO.Name = "TXT_DESCUENTO"
        Me.TXT_DESCUENTO.Size = New System.Drawing.Size(89, 24)
        Me.TXT_DESCUENTO.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label15.Location = New System.Drawing.Point(30, 98)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 18)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Descuento :"
        '
        'TXT_PRECIO
        '
        Me.TXT_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PRECIO.Location = New System.Drawing.Point(120, 63)
        Me.TXT_PRECIO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_PRECIO.Name = "TXT_PRECIO"
        Me.TXT_PRECIO.ReadOnly = True
        Me.TXT_PRECIO.Size = New System.Drawing.Size(159, 24)
        Me.TXT_PRECIO.TabIndex = 5
        Me.TXT_PRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label14.Location = New System.Drawing.Point(7, 66)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 18)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Precio unitario :"
        '
        'TXT_CANTIDAD
        '
        Me.TXT_CANTIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_CANTIDAD.Location = New System.Drawing.Point(349, 34)
        Me.TXT_CANTIDAD.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_CANTIDAD.MaxLength = 6
        Me.TXT_CANTIDAD.Name = "TXT_CANTIDAD"
        Me.TXT_CANTIDAD.Size = New System.Drawing.Size(89, 24)
        Me.TXT_CANTIDAD.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label13.Location = New System.Drawing.Point(271, 37)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 18)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Cantidad :"
        '
        'TXT_UNIDAD
        '
        Me.TXT_UNIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_UNIDAD.Location = New System.Drawing.Point(120, 34)
        Me.TXT_UNIDAD.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_UNIDAD.Name = "TXT_UNIDAD"
        Me.TXT_UNIDAD.ReadOnly = True
        Me.TXT_UNIDAD.Size = New System.Drawing.Size(89, 24)
        Me.TXT_UNIDAD.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label12.Location = New System.Drawing.Point(4, 37)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 18)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Unidad Medida :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label11.Location = New System.Drawing.Point(44, 8)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 18)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Producto :"
        '
        'Producto
        '
        Me.Producto.CODIGO = Nothing
        Me.Producto.DESCRIPCION = Nothing
        Me.Producto.Location = New System.Drawing.Point(120, 5)
        Me.Producto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Producto.Name = "Producto"
        Me.Producto.OTROS_CAMP0S = Nothing
        Me.Producto.PANTALLA = Nothing
        Me.Producto.Size = New System.Drawing.Size(451, 27)
        Me.Producto.TabIndex = 1
        Me.Producto.TABLA_BUSCAR = Nothing
        Me.Producto.VALOR = ""
        Me.Producto.VALOR_DESCRIPCION = Nothing
        '
        'TAB_LINEAS
        '
        Me.TAB_LINEAS.Controls.Add(Me.GRID)
        Me.TAB_LINEAS.Location = New System.Drawing.Point(4, 22)
        Me.TAB_LINEAS.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_LINEAS.Name = "TAB_LINEAS"
        Me.TAB_LINEAS.Size = New System.Drawing.Size(873, 208)
        Me.TAB_LINEAS.TabIndex = 2
        Me.TAB_LINEAS.Text = "[ Líneas ]"
        Me.TAB_LINEAS.UseVisualStyleBackColor = True
        '
        'GRID
        '
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(2, 2)
        Me.GRID.Margin = New System.Windows.Forms.Padding(2)
        Me.GRID.Name = "GRID"
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.RowTemplate.Height = 24
        Me.GRID.Size = New System.Drawing.Size(868, 206)
        Me.GRID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label1.Location = New System.Drawing.Point(27, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número :"
        '
        'TXT_NUMERO
        '
        Me.TXT_NUMERO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_NUMERO.Location = New System.Drawing.Point(99, 18)
        Me.TXT_NUMERO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_NUMERO.Name = "TXT_NUMERO"
        Me.TXT_NUMERO.Size = New System.Drawing.Size(171, 24)
        Me.TXT_NUMERO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label2.Location = New System.Drawing.Point(5, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Documento :"
        '
        'CMB_DOCUMENTO
        '
        Me.CMB_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_DOCUMENTO.FormattingEnabled = True
        Me.CMB_DOCUMENTO.Items.AddRange(New Object() {"FC-Factura Contado", "FA-Factura Crédito"})
        Me.CMB_DOCUMENTO.Location = New System.Drawing.Point(99, 45)
        Me.CMB_DOCUMENTO.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_DOCUMENTO.Name = "CMB_DOCUMENTO"
        Me.CMB_DOCUMENTO.Size = New System.Drawing.Size(171, 26)
        Me.CMB_DOCUMENTO.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TXT_TIPO_CAMBIO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFECHA)
        Me.GroupBox1.Controls.Add(Me.TXT_NUMERO)
        Me.GroupBox1.Controls.Add(Me.CMB_DOCUMENTO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(881, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información ]"
        '
        'TXT_TIPO_CAMBIO
        '
        Me.TXT_TIPO_CAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TIPO_CAMBIO.Location = New System.Drawing.Point(758, 43)
        Me.TXT_TIPO_CAMBIO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_TIPO_CAMBIO.Name = "TXT_TIPO_CAMBIO"
        Me.TXT_TIPO_CAMBIO.Size = New System.Drawing.Size(116, 24)
        Me.TXT_TIPO_CAMBIO.TabIndex = 7
        Me.TXT_TIPO_CAMBIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.Location = New System.Drawing.Point(714, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "T.C :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.Location = New System.Drawing.Point(697, 18)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha :"
        '
        'DTPFECHA
        '
        Me.DTPFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.DTPFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHA.Location = New System.Drawing.Point(758, 15)
        Me.DTPFECHA.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPFECHA.Name = "DTPFECHA"
        Me.DTPFECHA.Size = New System.Drawing.Size(116, 24)
        Me.DTPFECHA.TabIndex = 5
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(784, 323)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 3
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(686, 323)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 2
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'Factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(887, 368)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Factura"
        Me.TabControl1.ResumeLayout(False)
        Me.TAB_ENC.ResumeLayout(False)
        Me.TAB_ENC.PerformLayout()
        Me.TAB_DET.ResumeLayout(False)
        Me.TAB_DET.PerformLayout()
        Me.TAB_LINEAS.ResumeLayout(False)
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TAB_ENC As TabPage
    Friend WithEvents TAB_DET As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_NUMERO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CMB_DOCUMENTO As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DTPFECHA As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_TIPO_CAMBIO As TextBox
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents CMB_FORMAPAGO As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CMB_MONEDA As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXT_PLAZO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXT_DESCRIPCION As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Cliente As Buscador
    Friend WithEvents Producto As Buscador
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TXT_UNIDAD As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXT_CANTIDAD As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TXT_PRECIO As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXT_DESCUENTO As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TXT_DESCUENTOTOTAL As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TXT_IMPUESTO As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TXT_IMPUESTOTOTAL As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TXT_SUBTOTAL As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TXT_TOTAL As TextBox
    Friend WithEvents BTN_INGRESAR As Button
    Friend WithEvents BTN_CALCULAR As Button
    Friend WithEvents TAB_LINEAS As TabPage
    Friend WithEvents GRID As DataGridView
End Class
