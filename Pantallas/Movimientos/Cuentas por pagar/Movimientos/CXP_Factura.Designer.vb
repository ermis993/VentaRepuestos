<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CXP_Factura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CXP_Factura))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_TIPO_CAMBIO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHA = New System.Windows.Forms.DateTimePicker()
        Me.TXT_NUMERO = New System.Windows.Forms.TextBox()
        Me.CMB_DOCUMENTO = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TAB_ENC = New System.Windows.Forms.TabPage()
        Me.Cliente = New VentaRepuestos.Buscador()
        Me.TXT_DESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMB_MONEDA = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMB_FORMAPAGO = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TAB_DET = New System.Windows.Forms.TabPage()
        Me.TXT_POR_IMPUESTO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXT_FILA = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TXT_ESTANTE = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TXT_COLUMNA = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TXT_DESCUENTOTOTAL = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXT_IMPUESTOTOTAL = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXT_SUBTOTAL = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TXT_TOTAL = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.LVResultados = New System.Windows.Forms.ListView()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.TXT_DESCUENTO = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXT_PRECIO = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXT_CANTIDAD = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXT_UNIDAD = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BTN_INGRESAR = New System.Windows.Forms.Button()
        Me.BTN_CALCULAR = New System.Windows.Forms.Button()
        Me.TAB_LINEAS = New System.Windows.Forms.TabPage()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.TXT_T = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXT_I = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXT_D = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXT_S = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BTN_FACTURAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TAB_ENC.SuspendLayout()
        Me.TAB_DET.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TAB_LINEAS.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(854, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información ]"
        '
        'TXT_TIPO_CAMBIO
        '
        Me.TXT_TIPO_CAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TIPO_CAMBIO.Location = New System.Drawing.Point(734, 45)
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
        Me.Label4.Location = New System.Drawing.Point(690, 48)
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
        Me.Label3.Location = New System.Drawing.Point(673, 20)
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
        Me.DTPFECHA.Location = New System.Drawing.Point(734, 17)
        Me.DTPFECHA.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPFECHA.Name = "DTPFECHA"
        Me.DTPFECHA.Size = New System.Drawing.Size(116, 24)
        Me.DTPFECHA.TabIndex = 5
        '
        'TXT_NUMERO
        '
        Me.TXT_NUMERO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_NUMERO.Location = New System.Drawing.Point(99, 18)
        Me.TXT_NUMERO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_NUMERO.MaxLength = 10
        Me.TXT_NUMERO.Name = "TXT_NUMERO"
        Me.TXT_NUMERO.Size = New System.Drawing.Size(171, 24)
        Me.TXT_NUMERO.TabIndex = 1
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TAB_ENC)
        Me.TabControl1.Controls.Add(Me.TAB_DET)
        Me.TabControl1.Controls.Add(Me.TAB_LINEAS)
        Me.TabControl1.Location = New System.Drawing.Point(2, 87)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(854, 234)
        Me.TabControl1.TabIndex = 1
        '
        'TAB_ENC
        '
        Me.TAB_ENC.Controls.Add(Me.Cliente)
        Me.TAB_ENC.Controls.Add(Me.TXT_DESCRIPCION)
        Me.TAB_ENC.Controls.Add(Me.Label10)
        Me.TAB_ENC.Controls.Add(Me.CMB_MONEDA)
        Me.TAB_ENC.Controls.Add(Me.Label7)
        Me.TAB_ENC.Controls.Add(Me.Label6)
        Me.TAB_ENC.Controls.Add(Me.CMB_FORMAPAGO)
        Me.TAB_ENC.Controls.Add(Me.Label5)
        Me.TAB_ENC.Location = New System.Drawing.Point(4, 22)
        Me.TAB_ENC.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Name = "TAB_ENC"
        Me.TAB_ENC.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Size = New System.Drawing.Size(846, 208)
        Me.TAB_ENC.TabIndex = 0
        Me.TAB_ENC.Text = "[ Encabezado ]"
        Me.TAB_ENC.UseVisualStyleBackColor = True
        '
        'Cliente
        '
        Me.Cliente.CAMPO_FILTRAR = Nothing
        Me.Cliente.CODIGO = Nothing
        Me.Cliente.DESCRIPCION = Nothing
        Me.Cliente.FILTRAR_POR_COMPANIA = True
        Me.Cliente.Location = New System.Drawing.Point(111, 10)
        Me.Cliente.Margin = New System.Windows.Forms.Padding(2)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OTROS_CAMP0S = Nothing
        Me.Cliente.PANTALLA = Nothing
        Me.Cliente.Size = New System.Drawing.Size(451, 32)
        Me.Cliente.TabIndex = 1
        Me.Cliente.TABLA_BUSCAR = "CLIENTE"
        Me.Cliente.VALOR = ""
        Me.Cliente.VALOR_DESCRIPCION = Nothing
        '
        'TXT_DESCRIPCION
        '
        Me.TXT_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCRIPCION.Location = New System.Drawing.Point(111, 106)
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
        Me.Label10.Location = New System.Drawing.Point(10, 106)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 18)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Descripción :"
        '
        'CMB_MONEDA
        '
        Me.CMB_MONEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_MONEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_MONEDA.FormattingEnabled = True
        Me.CMB_MONEDA.Items.AddRange(New Object() {"LOC-Colones", "DOL-Dólares"})
        Me.CMB_MONEDA.Location = New System.Drawing.Point(111, 76)
        Me.CMB_MONEDA.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_MONEDA.Name = "CMB_MONEDA"
        Me.CMB_MONEDA.Size = New System.Drawing.Size(155, 26)
        Me.CMB_MONEDA.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.Location = New System.Drawing.Point(33, 80)
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
        Me.Label6.Location = New System.Drawing.Point(22, 17)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Proveedor :"
        '
        'CMB_FORMAPAGO
        '
        Me.CMB_FORMAPAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FORMAPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_FORMAPAGO.FormattingEnabled = True
        Me.CMB_FORMAPAGO.Items.AddRange(New Object() {"EF-Efectivo", "TA-Tarjeta", "TR-Transferencia"})
        Me.CMB_FORMAPAGO.Location = New System.Drawing.Point(111, 44)
        Me.CMB_FORMAPAGO.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_FORMAPAGO.Name = "CMB_FORMAPAGO"
        Me.CMB_FORMAPAGO.Size = New System.Drawing.Size(155, 26)
        Me.CMB_FORMAPAGO.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 18)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Forma Pago :"
        '
        'TAB_DET
        '
        Me.TAB_DET.Controls.Add(Me.TXT_POR_IMPUESTO)
        Me.TAB_DET.Controls.Add(Me.Label8)
        Me.TAB_DET.Controls.Add(Me.TXT_FILA)
        Me.TAB_DET.Controls.Add(Me.Label27)
        Me.TAB_DET.Controls.Add(Me.TXT_ESTANTE)
        Me.TAB_DET.Controls.Add(Me.Label28)
        Me.TAB_DET.Controls.Add(Me.TXT_COLUMNA)
        Me.TAB_DET.Controls.Add(Me.Label29)
        Me.TAB_DET.Controls.Add(Me.GroupBox2)
        Me.TAB_DET.Controls.Add(Me.LVResultados)
        Me.TAB_DET.Controls.Add(Me.Label19)
        Me.TAB_DET.Controls.Add(Me.TXT_CODIGO)
        Me.TAB_DET.Controls.Add(Me.TXT_DESCUENTO)
        Me.TAB_DET.Controls.Add(Me.Label15)
        Me.TAB_DET.Controls.Add(Me.TXT_PRECIO)
        Me.TAB_DET.Controls.Add(Me.Label14)
        Me.TAB_DET.Controls.Add(Me.TXT_CANTIDAD)
        Me.TAB_DET.Controls.Add(Me.Label13)
        Me.TAB_DET.Controls.Add(Me.TXT_UNIDAD)
        Me.TAB_DET.Controls.Add(Me.Label12)
        Me.TAB_DET.Controls.Add(Me.Label11)
        Me.TAB_DET.Controls.Add(Me.BTN_INGRESAR)
        Me.TAB_DET.Controls.Add(Me.BTN_CALCULAR)
        Me.TAB_DET.Location = New System.Drawing.Point(4, 22)
        Me.TAB_DET.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Name = "TAB_DET"
        Me.TAB_DET.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Size = New System.Drawing.Size(846, 208)
        Me.TAB_DET.TabIndex = 1
        Me.TAB_DET.Text = "[ Detalle ]"
        Me.TAB_DET.UseVisualStyleBackColor = True
        '
        'TXT_POR_IMPUESTO
        '
        Me.TXT_POR_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_POR_IMPUESTO.Location = New System.Drawing.Point(132, 178)
        Me.TXT_POR_IMPUESTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_POR_IMPUESTO.MaxLength = 2
        Me.TXT_POR_IMPUESTO.Name = "TXT_POR_IMPUESTO"
        Me.TXT_POR_IMPUESTO.Size = New System.Drawing.Size(160, 24)
        Me.TXT_POR_IMPUESTO.TabIndex = 9
        Me.TXT_POR_IMPUESTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label8.Location = New System.Drawing.Point(23, 181)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 18)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Impuesto (%) :"
        '
        'TXT_FILA
        '
        Me.TXT_FILA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_FILA.Location = New System.Drawing.Point(657, 132)
        Me.TXT_FILA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_FILA.MaxLength = 3
        Me.TXT_FILA.Name = "TXT_FILA"
        Me.TXT_FILA.ReadOnly = True
        Me.TXT_FILA.Size = New System.Drawing.Size(76, 24)
        Me.TXT_FILA.TabIndex = 20
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label27.Location = New System.Drawing.Point(737, 135)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(27, 18)
        Me.Label27.TabIndex = 21
        Me.Label27.Text = "C :"
        '
        'TXT_ESTANTE
        '
        Me.TXT_ESTANTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_ESTANTE.Location = New System.Drawing.Point(547, 132)
        Me.TXT_ESTANTE.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_ESTANTE.MaxLength = 3
        Me.TXT_ESTANTE.Name = "TXT_ESTANTE"
        Me.TXT_ESTANTE.ReadOnly = True
        Me.TXT_ESTANTE.Size = New System.Drawing.Size(76, 24)
        Me.TXT_ESTANTE.TabIndex = 18
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label28.Location = New System.Drawing.Point(627, 135)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(25, 18)
        Me.Label28.TabIndex = 19
        Me.Label28.Text = "F :"
        '
        'TXT_COLUMNA
        '
        Me.TXT_COLUMNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COLUMNA.Location = New System.Drawing.Point(768, 132)
        Me.TXT_COLUMNA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_COLUMNA.MaxLength = 3
        Me.TXT_COLUMNA.Name = "TXT_COLUMNA"
        Me.TXT_COLUMNA.ReadOnly = True
        Me.TXT_COLUMNA.Size = New System.Drawing.Size(76, 24)
        Me.TXT_COLUMNA.TabIndex = 22
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label29.Location = New System.Drawing.Point(517, 135)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(26, 18)
        Me.Label29.TabIndex = 17
        Me.Label29.Text = "E :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TXT_DESCUENTOTOTAL)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TXT_IMPUESTOTOTAL)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.TXT_SUBTOTAL)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.TXT_TOTAL)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Location = New System.Drawing.Point(520, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 123)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Totales ]"
        '
        'TXT_DESCUENTOTOTAL
        '
        Me.TXT_DESCUENTOTOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCUENTOTOTAL.Location = New System.Drawing.Point(135, 11)
        Me.TXT_DESCUENTOTOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DESCUENTOTOTAL.Name = "TXT_DESCUENTOTOTAL"
        Me.TXT_DESCUENTOTOTAL.ReadOnly = True
        Me.TXT_DESCUENTOTOTAL.Size = New System.Drawing.Size(160, 24)
        Me.TXT_DESCUENTOTOTAL.TabIndex = 1
        Me.TXT_DESCUENTOTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label16.Location = New System.Drawing.Point(11, 14)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 18)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Descuento total :"
        '
        'TXT_IMPUESTOTOTAL
        '
        Me.TXT_IMPUESTOTOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_IMPUESTOTOTAL.Location = New System.Drawing.Point(135, 65)
        Me.TXT_IMPUESTOTOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_IMPUESTOTOTAL.Name = "TXT_IMPUESTOTOTAL"
        Me.TXT_IMPUESTOTOTAL.ReadOnly = True
        Me.TXT_IMPUESTOTOTAL.Size = New System.Drawing.Size(160, 24)
        Me.TXT_IMPUESTOTOTAL.TabIndex = 5
        Me.TXT_IMPUESTOTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label18.Location = New System.Drawing.Point(22, 67)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(109, 18)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Impuesto total :"
        '
        'TXT_SUBTOTAL
        '
        Me.TXT_SUBTOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_SUBTOTAL.Location = New System.Drawing.Point(135, 38)
        Me.TXT_SUBTOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_SUBTOTAL.Name = "TXT_SUBTOTAL"
        Me.TXT_SUBTOTAL.ReadOnly = True
        Me.TXT_SUBTOTAL.Size = New System.Drawing.Size(160, 24)
        Me.TXT_SUBTOTAL.TabIndex = 3
        Me.TXT_SUBTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label20.Location = New System.Drawing.Point(61, 41)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 18)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Subtotal :"
        '
        'TXT_TOTAL
        '
        Me.TXT_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TOTAL.Location = New System.Drawing.Point(135, 92)
        Me.TXT_TOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_TOTAL.Name = "TXT_TOTAL"
        Me.TXT_TOTAL.ReadOnly = True
        Me.TXT_TOTAL.Size = New System.Drawing.Size(160, 24)
        Me.TXT_TOTAL.TabIndex = 7
        Me.TXT_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label21.Location = New System.Drawing.Point(82, 95)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(49, 18)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Total :"
        '
        'LVResultados
        '
        Me.LVResultados.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LVResultados.HideSelection = False
        Me.LVResultados.Location = New System.Drawing.Point(132, 44)
        Me.LVResultados.Name = "LVResultados"
        Me.LVResultados.Size = New System.Drawing.Size(378, 73)
        Me.LVResultados.TabIndex = 3
        Me.LVResultados.UseCompatibleStateImageBehavior = False
        Me.LVResultados.View = System.Windows.Forms.View.Details
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label19.Location = New System.Drawing.Point(42, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Productos :"
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(132, 13)
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(378, 24)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'TXT_DESCUENTO
        '
        Me.TXT_DESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCUENTO.Location = New System.Drawing.Point(421, 122)
        Me.TXT_DESCUENTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DESCUENTO.MaxLength = 4
        Me.TXT_DESCUENTO.Name = "TXT_DESCUENTO"
        Me.TXT_DESCUENTO.Size = New System.Drawing.Size(89, 24)
        Me.TXT_DESCUENTO.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label15.Location = New System.Drawing.Point(328, 125)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 18)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Descuento :"
        '
        'TXT_PRECIO
        '
        Me.TXT_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PRECIO.Location = New System.Drawing.Point(132, 150)
        Me.TXT_PRECIO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_PRECIO.Name = "TXT_PRECIO"
        Me.TXT_PRECIO.Size = New System.Drawing.Size(160, 24)
        Me.TXT_PRECIO.TabIndex = 7
        Me.TXT_PRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label14.Location = New System.Drawing.Point(16, 153)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 18)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Precio unitario :"
        '
        'TXT_CANTIDAD
        '
        Me.TXT_CANTIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_CANTIDAD.Location = New System.Drawing.Point(132, 122)
        Me.TXT_CANTIDAD.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_CANTIDAD.MaxLength = 6
        Me.TXT_CANTIDAD.Name = "TXT_CANTIDAD"
        Me.TXT_CANTIDAD.Size = New System.Drawing.Size(89, 24)
        Me.TXT_CANTIDAD.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label13.Location = New System.Drawing.Point(53, 125)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 18)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Cantidad :"
        '
        'TXT_UNIDAD
        '
        Me.TXT_UNIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_UNIDAD.Location = New System.Drawing.Point(421, 150)
        Me.TXT_UNIDAD.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_UNIDAD.Name = "TXT_UNIDAD"
        Me.TXT_UNIDAD.ReadOnly = True
        Me.TXT_UNIDAD.Size = New System.Drawing.Size(89, 24)
        Me.TXT_UNIDAD.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label12.Location = New System.Drawing.Point(305, 153)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 18)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Unidad Medida :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label11.Location = New System.Drawing.Point(5, 16)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 18)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Nombre/Código :"
        '
        'BTN_INGRESAR
        '
        Me.BTN_INGRESAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_INGRESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_INGRESAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_INGRESAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(744, 162)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_INGRESAR.TabIndex = 24
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
        Me.BTN_CALCULAR.Location = New System.Drawing.Point(639, 162)
        Me.BTN_CALCULAR.Name = "BTN_CALCULAR"
        Me.BTN_CALCULAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_CALCULAR.TabIndex = 23
        Me.BTN_CALCULAR.Text = "Calcular"
        Me.BTN_CALCULAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CALCULAR.UseVisualStyleBackColor = False
        '
        'TAB_LINEAS
        '
        Me.TAB_LINEAS.Controls.Add(Me.GRID)
        Me.TAB_LINEAS.Location = New System.Drawing.Point(4, 22)
        Me.TAB_LINEAS.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_LINEAS.Name = "TAB_LINEAS"
        Me.TAB_LINEAS.Size = New System.Drawing.Size(846, 208)
        Me.TAB_LINEAS.TabIndex = 2
        Me.TAB_LINEAS.Text = "[ Líneas ]"
        Me.TAB_LINEAS.UseVisualStyleBackColor = True
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AllowUserToResizeColumns = False
        Me.GRID.AllowUserToResizeRows = False
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(2, 2)
        Me.GRID.Margin = New System.Windows.Forms.Padding(2)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.RowTemplate.Height = 24
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(842, 206)
        Me.GRID.TabIndex = 0
        '
        'TXT_T
        '
        Me.TXT_T.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_T.Location = New System.Drawing.Point(382, 345)
        Me.TXT_T.Name = "TXT_T"
        Me.TXT_T.ReadOnly = True
        Me.TXT_T.Size = New System.Drawing.Size(160, 24)
        Me.TXT_T.TabIndex = 9
        Me.TXT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label24.Location = New System.Drawing.Point(327, 348)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 18)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "Total :"
        '
        'TXT_I
        '
        Me.TXT_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_I.Location = New System.Drawing.Point(382, 320)
        Me.TXT_I.Name = "TXT_I"
        Me.TXT_I.ReadOnly = True
        Me.TXT_I.Size = New System.Drawing.Size(160, 24)
        Me.TXT_I.TabIndex = 8
        Me.TXT_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label25.Location = New System.Drawing.Point(299, 323)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(77, 18)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Impuesto :"
        '
        'TXT_D
        '
        Me.TXT_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_D.Location = New System.Drawing.Point(101, 345)
        Me.TXT_D.Name = "TXT_D"
        Me.TXT_D.ReadOnly = True
        Me.TXT_D.Size = New System.Drawing.Size(160, 24)
        Me.TXT_D.TabIndex = 5
        Me.TXT_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label23.Location = New System.Drawing.Point(10, 348)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 18)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Descuento :"
        '
        'TXT_S
        '
        Me.TXT_S.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_S.Location = New System.Drawing.Point(101, 320)
        Me.TXT_S.Name = "TXT_S"
        Me.TXT_S.ReadOnly = True
        Me.TXT_S.Size = New System.Drawing.Size(160, 24)
        Me.TXT_S.TabIndex = 4
        Me.TXT_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label22.Location = New System.Drawing.Point(28, 323)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 18)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Subtotal :"
        '
        'BTN_FACTURAR
        '
        Me.BTN_FACTURAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_FACTURAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_FACTURAR.Image = Global.VentaRepuestos.My.Resources.Resources.pagar
        Me.BTN_FACTURAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_FACTURAR.Location = New System.Drawing.Point(559, 326)
        Me.BTN_FACTURAR.Name = "BTN_FACTURAR"
        Me.BTN_FACTURAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_FACTURAR.TabIndex = 10
        Me.BTN_FACTURAR.Text = "Facturar"
        Me.BTN_FACTURAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_FACTURAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(757, 326)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 12
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(658, 326)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 11
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'CXP_Factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(858, 371)
        Me.ControlBox = False
        Me.Controls.Add(Me.TXT_T)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TXT_I)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TXT_D)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TXT_S)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.BTN_FACTURAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CXP_Factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CXP Factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TAB_ENC.ResumeLayout(False)
        Me.TAB_ENC.PerformLayout()
        Me.TAB_DET.ResumeLayout(False)
        Me.TAB_DET.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TAB_LINEAS.ResumeLayout(False)
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TXT_TIPO_CAMBIO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DTPFECHA As DateTimePicker
    Friend WithEvents TXT_NUMERO As TextBox
    Friend WithEvents CMB_DOCUMENTO As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TAB_ENC As TabPage
    Friend WithEvents Cliente As Buscador
    Friend WithEvents TXT_DESCRIPCION As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CMB_MONEDA As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CMB_FORMAPAGO As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TAB_DET As TabPage
    Friend WithEvents TXT_FILA As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TXT_ESTANTE As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents TXT_COLUMNA As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TXT_DESCUENTOTOTAL As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TXT_IMPUESTOTOTAL As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TXT_SUBTOTAL As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TXT_TOTAL As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents LVResultados As ListView
    Friend WithEvents Label19 As Label
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents TXT_DESCUENTO As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXT_PRECIO As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TXT_CANTIDAD As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXT_UNIDAD As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents BTN_INGRESAR As Button
    Friend WithEvents BTN_CALCULAR As Button
    Friend WithEvents TAB_LINEAS As TabPage
    Friend WithEvents GRID As DataGridView
    Friend WithEvents TXT_T As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TXT_I As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TXT_D As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TXT_S As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents BTN_FACTURAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents TXT_POR_IMPUESTO As TextBox
    Friend WithEvents Label8 As Label
End Class
