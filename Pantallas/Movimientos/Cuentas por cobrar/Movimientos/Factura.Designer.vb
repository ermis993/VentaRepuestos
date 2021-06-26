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
        Me.Label41 = New System.Windows.Forms.Label()
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
        Me.TXT_EXONERACION = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TXT_FILA = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TXT_ESTANTE = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TXT_COLUMNA = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.CMB_PRECIO = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TXT_MONTO_EXONERACION = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
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
        Me.TXT_IMPUESTO = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
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
        Me.TAB_ENCOMIENDA = New System.Windows.Forms.TabPage()
        Me.BTN_MANIFIESTO = New System.Windows.Forms.Button()
        Me.BTN_IMPRIMIR = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TXT_VALOR = New System.Windows.Forms.TextBox()
        Me.TXT_DETALLE_ENVIO = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TXT_TELEFONO_RETIRA = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TXT_RETIRA = New System.Windows.Forms.TextBox()
        Me.TXT_ENVIA = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CHK_MU = New System.Windows.Forms.CheckBox()
        Me.CHK_MN = New System.Windows.Forms.CheckBox()
        Me.CMB_DESTINO = New System.Windows.Forms.ComboBox()
        Me.CMB_ORIGEN = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TXT_CANT_BULTOS = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_NUMERO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMB_DOCUMENTO = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_TIPO_CAMBIO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHA = New System.Windows.Forms.DateTimePicker()
        Me.BTN_FACTURAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TXT_S = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXT_D = New System.Windows.Forms.TextBox()
        Me.TXT_T = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXT_I = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXT_E = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TAB_ENC.SuspendLayout()
        Me.TAB_DET.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TAB_LINEAS.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB_ENCOMIENDA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TAB_ENC)
        Me.TabControl1.Controls.Add(Me.TAB_DET)
        Me.TabControl1.Controls.Add(Me.TAB_LINEAS)
        Me.TabControl1.Controls.Add(Me.TAB_ENCOMIENDA)
        Me.TabControl1.Location = New System.Drawing.Point(2, 85)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(854, 257)
        Me.TabControl1.TabIndex = 1
        '
        'TAB_ENC
        '
        Me.TAB_ENC.Controls.Add(Me.Label41)
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
        Me.TAB_ENC.Size = New System.Drawing.Size(846, 231)
        Me.TAB_ENC.TabIndex = 0
        Me.TAB_ENC.Text = "[ Encabezado ]"
        Me.TAB_ENC.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Navy
        Me.Label41.Location = New System.Drawing.Point(567, 155)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(264, 52)
        Me.Label41.TabIndex = 11
        Me.Label41.Text = resources.GetString("Label41.Text")
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
        Me.Cliente.Size = New System.Drawing.Size(541, 32)
        Me.Cliente.TabIndex = 1
        Me.Cliente.TABLA_BUSCAR = "CLIENTE"
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
        Me.TXT_DESCRIPCION.Size = New System.Drawing.Size(451, 90)
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
        Me.Label8.Location = New System.Drawing.Point(51, 109)
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
        Me.Label6.Location = New System.Drawing.Point(42, 17)
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
        Me.CMB_FORMAPAGO.Size = New System.Drawing.Size(155, 26)
        Me.CMB_FORMAPAGO.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(8, 50)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 18)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Forma Pago :"
        '
        'TAB_DET
        '
        Me.TAB_DET.Controls.Add(Me.BTN_BUSCAR)
        Me.TAB_DET.Controls.Add(Me.TXT_EXONERACION)
        Me.TAB_DET.Controls.Add(Me.Label34)
        Me.TAB_DET.Controls.Add(Me.TXT_FILA)
        Me.TAB_DET.Controls.Add(Me.Label27)
        Me.TAB_DET.Controls.Add(Me.TXT_ESTANTE)
        Me.TAB_DET.Controls.Add(Me.Label28)
        Me.TAB_DET.Controls.Add(Me.TXT_COLUMNA)
        Me.TAB_DET.Controls.Add(Me.Label29)
        Me.TAB_DET.Controls.Add(Me.CMB_PRECIO)
        Me.TAB_DET.Controls.Add(Me.Label26)
        Me.TAB_DET.Controls.Add(Me.GroupBox2)
        Me.TAB_DET.Controls.Add(Me.LVResultados)
        Me.TAB_DET.Controls.Add(Me.Label19)
        Me.TAB_DET.Controls.Add(Me.TXT_CODIGO)
        Me.TAB_DET.Controls.Add(Me.TXT_IMPUESTO)
        Me.TAB_DET.Controls.Add(Me.Label17)
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
        Me.TAB_DET.Size = New System.Drawing.Size(846, 231)
        Me.TAB_DET.TabIndex = 1
        Me.TAB_DET.Text = "[ Detalle ]"
        Me.TAB_DET.UseVisualStyleBackColor = True
        '
        'TXT_EXONERACION
        '
        Me.TXT_EXONERACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_EXONERACION.Location = New System.Drawing.Point(421, 122)
        Me.TXT_EXONERACION.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_EXONERACION.MaxLength = 3
        Me.TXT_EXONERACION.Name = "TXT_EXONERACION"
        Me.TXT_EXONERACION.ReadOnly = True
        Me.TXT_EXONERACION.Size = New System.Drawing.Size(89, 24)
        Me.TXT_EXONERACION.TabIndex = 38
        Me.TXT_EXONERACION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label34.Location = New System.Drawing.Point(301, 125)
        Me.Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(118, 18)
        Me.Label34.TabIndex = 37
        Me.Label34.Text = "Exoneración(%):"
        '
        'TXT_FILA
        '
        Me.TXT_FILA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_FILA.Location = New System.Drawing.Point(656, 157)
        Me.TXT_FILA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_FILA.MaxLength = 3
        Me.TXT_FILA.Name = "TXT_FILA"
        Me.TXT_FILA.ReadOnly = True
        Me.TXT_FILA.Size = New System.Drawing.Size(76, 24)
        Me.TXT_FILA.TabIndex = 34
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label27.Location = New System.Drawing.Point(736, 160)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(27, 18)
        Me.Label27.TabIndex = 35
        Me.Label27.Text = "C :"
        '
        'TXT_ESTANTE
        '
        Me.TXT_ESTANTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_ESTANTE.Location = New System.Drawing.Point(546, 157)
        Me.TXT_ESTANTE.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_ESTANTE.MaxLength = 3
        Me.TXT_ESTANTE.Name = "TXT_ESTANTE"
        Me.TXT_ESTANTE.ReadOnly = True
        Me.TXT_ESTANTE.Size = New System.Drawing.Size(76, 24)
        Me.TXT_ESTANTE.TabIndex = 32
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label28.Location = New System.Drawing.Point(626, 160)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(25, 18)
        Me.Label28.TabIndex = 33
        Me.Label28.Text = "F :"
        '
        'TXT_COLUMNA
        '
        Me.TXT_COLUMNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COLUMNA.Location = New System.Drawing.Point(767, 157)
        Me.TXT_COLUMNA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_COLUMNA.MaxLength = 3
        Me.TXT_COLUMNA.Name = "TXT_COLUMNA"
        Me.TXT_COLUMNA.ReadOnly = True
        Me.TXT_COLUMNA.Size = New System.Drawing.Size(76, 24)
        Me.TXT_COLUMNA.TabIndex = 36
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label29.Location = New System.Drawing.Point(516, 160)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(26, 18)
        Me.Label29.TabIndex = 31
        Me.Label29.Text = "E :"
        '
        'CMB_PRECIO
        '
        Me.CMB_PRECIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_PRECIO.FormattingEnabled = True
        Me.CMB_PRECIO.Items.AddRange(New Object() {"Precio 1 ", "Precio 2", "Precio 3"})
        Me.CMB_PRECIO.Location = New System.Drawing.Point(132, 149)
        Me.CMB_PRECIO.Name = "CMB_PRECIO"
        Me.CMB_PRECIO.Size = New System.Drawing.Size(160, 26)
        Me.CMB_PRECIO.TabIndex = 18
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label26.Location = New System.Drawing.Point(68, 153)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(59, 18)
        Me.Label26.TabIndex = 17
        Me.Label26.Text = "Precio :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TXT_MONTO_EXONERACION)
        Me.GroupBox2.Controls.Add(Me.Label35)
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
        Me.GroupBox2.Size = New System.Drawing.Size(323, 151)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Totales ]"
        '
        'TXT_MONTO_EXONERACION
        '
        Me.TXT_MONTO_EXONERACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_MONTO_EXONERACION.Location = New System.Drawing.Point(135, 66)
        Me.TXT_MONTO_EXONERACION.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_MONTO_EXONERACION.Name = "TXT_MONTO_EXONERACION"
        Me.TXT_MONTO_EXONERACION.ReadOnly = True
        Me.TXT_MONTO_EXONERACION.Size = New System.Drawing.Size(160, 24)
        Me.TXT_MONTO_EXONERACION.TabIndex = 9
        Me.TXT_MONTO_EXONERACION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label35.Location = New System.Drawing.Point(32, 69)
        Me.Label35.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(99, 18)
        Me.Label35.TabIndex = 8
        Me.Label35.Text = "Exoneración :"
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
        Me.TXT_IMPUESTOTOTAL.Location = New System.Drawing.Point(135, 94)
        Me.TXT_IMPUESTOTOTAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_IMPUESTOTOTAL.Name = "TXT_IMPUESTOTOTAL"
        Me.TXT_IMPUESTOTOTAL.ReadOnly = True
        Me.TXT_IMPUESTOTOTAL.Size = New System.Drawing.Size(160, 24)
        Me.TXT_IMPUESTOTOTAL.TabIndex = 3
        Me.TXT_IMPUESTOTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label18.Location = New System.Drawing.Point(22, 96)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(109, 18)
        Me.Label18.TabIndex = 2
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
        Me.TXT_SUBTOTAL.TabIndex = 5
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
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Subtotal :"
        '
        'TXT_TOTAL
        '
        Me.TXT_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TOTAL.Location = New System.Drawing.Point(135, 121)
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
        Me.Label21.Location = New System.Drawing.Point(82, 124)
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
        Me.TXT_CODIGO.Size = New System.Drawing.Size(346, 24)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'TXT_IMPUESTO
        '
        Me.TXT_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_IMPUESTO.Location = New System.Drawing.Point(421, 178)
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
        Me.Label17.Location = New System.Drawing.Point(342, 181)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 18)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Impuesto :"
        '
        'TXT_DESCUENTO
        '
        Me.TXT_DESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCUENTO.Location = New System.Drawing.Point(132, 204)
        Me.TXT_DESCUENTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DESCUENTO.MaxLength = 4
        Me.TXT_DESCUENTO.Name = "TXT_DESCUENTO"
        Me.TXT_DESCUENTO.Size = New System.Drawing.Size(89, 24)
        Me.TXT_DESCUENTO.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label15.Location = New System.Drawing.Point(39, 207)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 18)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Descuento :"
        '
        'TXT_PRECIO
        '
        Me.TXT_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PRECIO.Location = New System.Drawing.Point(132, 178)
        Me.TXT_PRECIO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_PRECIO.Name = "TXT_PRECIO"
        Me.TXT_PRECIO.ReadOnly = True
        Me.TXT_PRECIO.Size = New System.Drawing.Size(160, 24)
        Me.TXT_PRECIO.TabIndex = 7
        Me.TXT_PRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label14.Location = New System.Drawing.Point(16, 181)
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
        Me.TXT_UNIDAD.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label12.Location = New System.Drawing.Point(305, 153)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 18)
        Me.Label12.TabIndex = 10
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
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(742, 184)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_INGRESAR.TabIndex = 16
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
        Me.BTN_CALCULAR.Location = New System.Drawing.Point(637, 184)
        Me.BTN_CALCULAR.Name = "BTN_CALCULAR"
        Me.BTN_CALCULAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_CALCULAR.TabIndex = 15
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
        Me.TAB_LINEAS.Size = New System.Drawing.Size(846, 231)
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
        Me.GRID.Size = New System.Drawing.Size(842, 227)
        Me.GRID.TabIndex = 0
        '
        'TAB_ENCOMIENDA
        '
        Me.TAB_ENCOMIENDA.Controls.Add(Me.BTN_MANIFIESTO)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.BTN_IMPRIMIR)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.GroupBox4)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.TXT_DETALLE_ENVIO)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.Label39)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.TXT_TELEFONO_RETIRA)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.Label38)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.TXT_RETIRA)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.TXT_ENVIA)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.Label37)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.GroupBox3)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.CMB_DESTINO)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.CMB_ORIGEN)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.Label33)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.Label32)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.TXT_CANT_BULTOS)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.Label31)
        Me.TAB_ENCOMIENDA.Controls.Add(Me.Label30)
        Me.TAB_ENCOMIENDA.Location = New System.Drawing.Point(4, 22)
        Me.TAB_ENCOMIENDA.Name = "TAB_ENCOMIENDA"
        Me.TAB_ENCOMIENDA.Size = New System.Drawing.Size(846, 231)
        Me.TAB_ENCOMIENDA.TabIndex = 3
        Me.TAB_ENCOMIENDA.Text = "[ Encomienda ]"
        Me.TAB_ENCOMIENDA.UseVisualStyleBackColor = True
        '
        'BTN_MANIFIESTO
        '
        Me.BTN_MANIFIESTO.Image = Global.VentaRepuestos.My.Resources.Resources.imprimir1
        Me.BTN_MANIFIESTO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_MANIFIESTO.Location = New System.Drawing.Point(733, 177)
        Me.BTN_MANIFIESTO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_MANIFIESTO.Name = "BTN_MANIFIESTO"
        Me.BTN_MANIFIESTO.Size = New System.Drawing.Size(99, 43)
        Me.BTN_MANIFIESTO.TabIndex = 42
        Me.BTN_MANIFIESTO.Text = "Manifiesto"
        Me.BTN_MANIFIESTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_MANIFIESTO.UseVisualStyleBackColor = True
        '
        'BTN_IMPRIMIR
        '
        Me.BTN_IMPRIMIR.Image = Global.VentaRepuestos.My.Resources.Resources.imprimir1
        Me.BTN_IMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_IMPRIMIR.Location = New System.Drawing.Point(579, 177)
        Me.BTN_IMPRIMIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_IMPRIMIR.Name = "BTN_IMPRIMIR"
        Me.BTN_IMPRIMIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_IMPRIMIR.TabIndex = 41
        Me.BTN_IMPRIMIR.Text = "Etiqueta"
        Me.BTN_IMPRIMIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_IMPRIMIR.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.TXT_VALOR)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox4.Location = New System.Drawing.Point(579, 80)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(264, 63)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Valor de mercaderia"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label40.Location = New System.Drawing.Point(5, 29)
        Me.Label40.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(27, 18)
        Me.Label40.TabIndex = 0
        Me.Label40.Text = "₡ :"
        '
        'TXT_VALOR
        '
        Me.TXT_VALOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_VALOR.Location = New System.Drawing.Point(35, 27)
        Me.TXT_VALOR.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_VALOR.MaxLength = 12
        Me.TXT_VALOR.Name = "TXT_VALOR"
        Me.TXT_VALOR.Size = New System.Drawing.Size(218, 24)
        Me.TXT_VALOR.TabIndex = 1
        Me.TXT_VALOR.Text = "0"
        '
        'TXT_DETALLE_ENVIO
        '
        Me.TXT_DETALLE_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DETALLE_ENVIO.Location = New System.Drawing.Point(123, 99)
        Me.TXT_DETALLE_ENVIO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DETALLE_ENVIO.MaxLength = 300
        Me.TXT_DETALLE_ENVIO.Name = "TXT_DETALLE_ENVIO"
        Me.TXT_DETALLE_ENVIO.Size = New System.Drawing.Size(434, 24)
        Me.TXT_DETALLE_ENVIO.TabIndex = 7
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label39.Location = New System.Drawing.Point(24, 102)
        Me.Label39.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(96, 18)
        Me.Label39.TabIndex = 6
        Me.Label39.Text = "Detalle envío:"
        '
        'TXT_TELEFONO_RETIRA
        '
        Me.TXT_TELEFONO_RETIRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TELEFONO_RETIRA.Location = New System.Drawing.Point(123, 71)
        Me.TXT_TELEFONO_RETIRA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_TELEFONO_RETIRA.MaxLength = 9
        Me.TXT_TELEFONO_RETIRA.Name = "TXT_TELEFONO_RETIRA"
        Me.TXT_TELEFONO_RETIRA.Size = New System.Drawing.Size(102, 24)
        Me.TXT_TELEFONO_RETIRA.TabIndex = 5
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label38.Location = New System.Drawing.Point(5, 74)
        Me.Label38.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(117, 18)
        Me.Label38.TabIndex = 4
        Me.Label38.Text = "Teléfono Retira :"
        '
        'TXT_RETIRA
        '
        Me.TXT_RETIRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_RETIRA.Location = New System.Drawing.Point(123, 43)
        Me.TXT_RETIRA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_RETIRA.MaxLength = 300
        Me.TXT_RETIRA.Name = "TXT_RETIRA"
        Me.TXT_RETIRA.Size = New System.Drawing.Size(434, 24)
        Me.TXT_RETIRA.TabIndex = 3
        '
        'TXT_ENVIA
        '
        Me.TXT_ENVIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_ENVIA.Location = New System.Drawing.Point(123, 14)
        Me.TXT_ENVIA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_ENVIA.MaxLength = 300
        Me.TXT_ENVIA.Name = "TXT_ENVIA"
        Me.TXT_ENVIA.Size = New System.Drawing.Size(434, 24)
        Me.TXT_ENVIA.TabIndex = 1
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label37.Location = New System.Drawing.Point(66, 17)
        Me.Label37.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(52, 18)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Envia :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CHK_MU)
        Me.GroupBox3.Controls.Add(Me.CHK_MN)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(579, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(264, 63)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de mercaderia"
        '
        'CHK_MU
        '
        Me.CHK_MU.AutoSize = True
        Me.CHK_MU.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CHK_MU.Location = New System.Drawing.Point(5, 38)
        Me.CHK_MU.Name = "CHK_MU"
        Me.CHK_MU.Size = New System.Drawing.Size(148, 22)
        Me.CHK_MU.TabIndex = 1
        Me.CHK_MU.Text = "Mercadería Usada"
        Me.CHK_MU.UseVisualStyleBackColor = True
        '
        'CHK_MN
        '
        Me.CHK_MN.AutoSize = True
        Me.CHK_MN.Checked = True
        Me.CHK_MN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_MN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CHK_MN.Location = New System.Drawing.Point(6, 17)
        Me.CHK_MN.Name = "CHK_MN"
        Me.CHK_MN.Size = New System.Drawing.Size(144, 22)
        Me.CHK_MN.TabIndex = 0
        Me.CHK_MN.Text = "Mercadería nueva"
        Me.CHK_MN.UseVisualStyleBackColor = True
        '
        'CMB_DESTINO
        '
        Me.CMB_DESTINO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DESTINO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_DESTINO.FormattingEnabled = True
        Me.CMB_DESTINO.Location = New System.Drawing.Point(123, 194)
        Me.CMB_DESTINO.Name = "CMB_DESTINO"
        Me.CMB_DESTINO.Size = New System.Drawing.Size(434, 26)
        Me.CMB_DESTINO.TabIndex = 13
        '
        'CMB_ORIGEN
        '
        Me.CMB_ORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_ORIGEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_ORIGEN.FormattingEnabled = True
        Me.CMB_ORIGEN.Location = New System.Drawing.Point(123, 158)
        Me.CMB_ORIGEN.Name = "CMB_ORIGEN"
        Me.CMB_ORIGEN.Size = New System.Drawing.Size(434, 26)
        Me.CMB_ORIGEN.TabIndex = 11
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label33.Location = New System.Drawing.Point(55, 197)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 18)
        Me.Label33.TabIndex = 12
        Me.Label33.Text = "Destino :"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label32.Location = New System.Drawing.Point(58, 162)
        Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(60, 18)
        Me.Label32.TabIndex = 10
        Me.Label32.Text = "Origen :"
        '
        'TXT_CANT_BULTOS
        '
        Me.TXT_CANT_BULTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_CANT_BULTOS.Location = New System.Drawing.Point(123, 128)
        Me.TXT_CANT_BULTOS.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_CANT_BULTOS.MaxLength = 3
        Me.TXT_CANT_BULTOS.Name = "TXT_CANT_BULTOS"
        Me.TXT_CANT_BULTOS.Size = New System.Drawing.Size(76, 24)
        Me.TXT_CANT_BULTOS.TabIndex = 9
        Me.TXT_CANT_BULTOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label31.Location = New System.Drawing.Point(4, 129)
        Me.Label31.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 18)
        Me.Label31.TabIndex = 8
        Me.Label31.Text = "Cantidad Bultos :"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label30.Location = New System.Drawing.Point(65, 46)
        Me.Label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 18)
        Me.Label30.TabIndex = 2
        Me.Label30.Text = "Retira :"
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
        'BTN_FACTURAR
        '
        Me.BTN_FACTURAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_FACTURAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_FACTURAR.Image = Global.VentaRepuestos.My.Resources.Resources.pagar
        Me.BTN_FACTURAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_FACTURAR.Location = New System.Drawing.Point(559, 375)
        Me.BTN_FACTURAR.Name = "BTN_FACTURAR"
        Me.BTN_FACTURAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_FACTURAR.TabIndex = 12
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
        Me.BTN_SALIR.Location = New System.Drawing.Point(757, 375)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 14
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(658, 375)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 13
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label22.Location = New System.Drawing.Point(28, 350)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 18)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Subtotal :"
        '
        'TXT_S
        '
        Me.TXT_S.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_S.Location = New System.Drawing.Point(101, 347)
        Me.TXT_S.Name = "TXT_S"
        Me.TXT_S.ReadOnly = True
        Me.TXT_S.Size = New System.Drawing.Size(160, 24)
        Me.TXT_S.TabIndex = 3
        Me.TXT_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label23.Location = New System.Drawing.Point(10, 375)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 18)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Descuento :"
        '
        'TXT_D
        '
        Me.TXT_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_D.Location = New System.Drawing.Point(101, 372)
        Me.TXT_D.Name = "TXT_D"
        Me.TXT_D.ReadOnly = True
        Me.TXT_D.Size = New System.Drawing.Size(160, 24)
        Me.TXT_D.TabIndex = 5
        Me.TXT_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_T
        '
        Me.TXT_T.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_T.Location = New System.Drawing.Point(382, 372)
        Me.TXT_T.Name = "TXT_T"
        Me.TXT_T.ReadOnly = True
        Me.TXT_T.Size = New System.Drawing.Size(160, 24)
        Me.TXT_T.TabIndex = 11
        Me.TXT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label24.Location = New System.Drawing.Point(327, 375)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 18)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "Total :"
        '
        'TXT_I
        '
        Me.TXT_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_I.Location = New System.Drawing.Point(382, 347)
        Me.TXT_I.Name = "TXT_I"
        Me.TXT_I.ReadOnly = True
        Me.TXT_I.Size = New System.Drawing.Size(160, 24)
        Me.TXT_I.TabIndex = 9
        Me.TXT_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label25.Location = New System.Drawing.Point(299, 350)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(77, 18)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "Impuesto :"
        '
        'TXT_E
        '
        Me.TXT_E.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_E.Location = New System.Drawing.Point(101, 398)
        Me.TXT_E.Name = "TXT_E"
        Me.TXT_E.ReadOnly = True
        Me.TXT_E.Size = New System.Drawing.Size(160, 24)
        Me.TXT_E.TabIndex = 7
        Me.TXT_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label36.Location = New System.Drawing.Point(-1, 401)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(99, 18)
        Me.Label36.TabIndex = 6
        Me.Label36.Text = "Exoneración :"
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.Image = Global.VentaRepuestos.My.Resources.Resources.filtrar
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(484, 12)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(26, 28)
        Me.BTN_BUSCAR.TabIndex = 39
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'Factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(860, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.TXT_E)
        Me.Controls.Add(Me.Label36)
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
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Factura"
        Me.TabControl1.ResumeLayout(False)
        Me.TAB_ENC.ResumeLayout(False)
        Me.TAB_ENC.PerformLayout()
        Me.TAB_DET.ResumeLayout(False)
        Me.TAB_DET.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TAB_LINEAS.ResumeLayout(False)
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB_ENCOMIENDA.ResumeLayout(False)
        Me.TAB_ENCOMIENDA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents LVResultados As ListView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BTN_FACTURAR As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents TXT_S As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TXT_D As TextBox
    Friend WithEvents TXT_T As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TXT_I As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents CMB_PRECIO As ComboBox
    Friend WithEvents TXT_FILA As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TXT_ESTANTE As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents TXT_COLUMNA As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TAB_ENCOMIENDA As TabPage
    Friend WithEvents Label30 As Label
    Friend WithEvents TXT_CANT_BULTOS As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents CMB_ORIGEN As ComboBox
    Friend WithEvents CMB_DESTINO As ComboBox
    Friend WithEvents TXT_EXONERACION As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents TXT_MONTO_EXONERACION As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents TXT_E As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CHK_MU As CheckBox
    Friend WithEvents CHK_MN As CheckBox
    Friend WithEvents TXT_ENVIA As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TXT_RETIRA As TextBox
    Friend WithEvents TXT_TELEFONO_RETIRA As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents TXT_DETALLE_ENVIO As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TXT_VALOR As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents BTN_IMPRIMIR As Button
    Friend WithEvents Label41 As Label
    Friend WithEvents BTN_MANIFIESTO As Button
    Friend WithEvents BTN_BUSCAR As Button
End Class
