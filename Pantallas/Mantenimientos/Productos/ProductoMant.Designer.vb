<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductoMant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductoMant))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_PRECIO_3 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TXT_PRECIO_2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXT_MINIMO = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVO = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVO = New System.Windows.Forms.RadioButton()
        Me.TXT_FILA = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXT_ESTANTE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXT_COLUMNA = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXT_PRECIO = New System.Windows.Forms.TextBox()
        Me.TXT_COSTO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXT_EXENTO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXT_IMPUESTO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMB_IMPUESTO_DGTD = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMB_UNIDADES = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_DESC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_COD_BARRA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.Buscador = New VentaRepuestos.Buscador()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TXT_PRECIO_3)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TXT_PRECIO_2)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TXT_MINIMO)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Buscador)
        Me.GroupBox1.Controls.Add(Me.TXT_FILA)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TXT_ESTANTE)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TXT_COLUMNA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TXT_PRECIO)
        Me.GroupBox1.Controls.Add(Me.TXT_COSTO)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TXT_EXENTO)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TXT_IMPUESTO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.CMB_IMPUESTO_DGTD)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CMB_UNIDADES)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXT_DESC)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TXT_COD_BARRA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXT_CODIGO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(572, 358)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información general ]"
        '
        'TXT_PRECIO_3
        '
        Me.TXT_PRECIO_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PRECIO_3.Location = New System.Drawing.Point(475, 258)
        Me.TXT_PRECIO_3.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_PRECIO_3.MaxLength = 18
        Me.TXT_PRECIO_3.Name = "TXT_PRECIO_3"
        Me.TXT_PRECIO_3.Size = New System.Drawing.Size(76, 24)
        Me.TXT_PRECIO_3.TabIndex = 24
        Me.TXT_PRECIO_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label17.Location = New System.Drawing.Point(399, 261)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 18)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Precio 3:"
        '
        'TXT_PRECIO_2
        '
        Me.TXT_PRECIO_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PRECIO_2.Location = New System.Drawing.Point(280, 258)
        Me.TXT_PRECIO_2.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_PRECIO_2.MaxLength = 18
        Me.TXT_PRECIO_2.Name = "TXT_PRECIO_2"
        Me.TXT_PRECIO_2.Size = New System.Drawing.Size(76, 24)
        Me.TXT_PRECIO_2.TabIndex = 22
        Me.TXT_PRECIO_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label16.Location = New System.Drawing.Point(212, 261)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 18)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Precio 2:"
        '
        'TXT_MINIMO
        '
        Me.TXT_MINIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_MINIMO.Location = New System.Drawing.Point(117, 327)
        Me.TXT_MINIMO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_MINIMO.MaxLength = 18
        Me.TXT_MINIMO.Name = "TXT_MINIMO"
        Me.TXT_MINIMO.Size = New System.Drawing.Size(153, 24)
        Me.TXT_MINIMO.TabIndex = 32
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label15.Location = New System.Drawing.Point(10, 330)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 18)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Minimo stock:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RB_INACTIVO)
        Me.GroupBox3.Controls.Add(Me.RB_ACTIVO)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(272, 318)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(278, 33)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estado"
        '
        'RB_INACTIVO
        '
        Me.RB_INACTIVO.AutoSize = True
        Me.RB_INACTIVO.Location = New System.Drawing.Point(130, 10)
        Me.RB_INACTIVO.Name = "RB_INACTIVO"
        Me.RB_INACTIVO.Size = New System.Drawing.Size(72, 20)
        Me.RB_INACTIVO.TabIndex = 1
        Me.RB_INACTIVO.TabStop = True
        Me.RB_INACTIVO.Text = "Inactivo"
        Me.RB_INACTIVO.UseVisualStyleBackColor = True
        '
        'RB_ACTIVO
        '
        Me.RB_ACTIVO.AutoSize = True
        Me.RB_ACTIVO.Checked = True
        Me.RB_ACTIVO.Location = New System.Drawing.Point(58, 10)
        Me.RB_ACTIVO.Name = "RB_ACTIVO"
        Me.RB_ACTIVO.Size = New System.Drawing.Size(63, 20)
        Me.RB_ACTIVO.TabIndex = 0
        Me.RB_ACTIVO.TabStop = True
        Me.RB_ACTIVO.Text = "Activo"
        Me.RB_ACTIVO.UseVisualStyleBackColor = True
        '
        'TXT_FILA
        '
        Me.TXT_FILA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_FILA.Location = New System.Drawing.Point(280, 289)
        Me.TXT_FILA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_FILA.MaxLength = 3
        Me.TXT_FILA.Name = "TXT_FILA"
        Me.TXT_FILA.Size = New System.Drawing.Size(76, 24)
        Me.TXT_FILA.TabIndex = 28
        Me.TXT_FILA.Text = "1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label14.Location = New System.Drawing.Point(399, 292)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 18)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Columna :"
        '
        'TXT_ESTANTE
        '
        Me.TXT_ESTANTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_ESTANTE.Location = New System.Drawing.Point(117, 289)
        Me.TXT_ESTANTE.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_ESTANTE.MaxLength = 3
        Me.TXT_ESTANTE.Name = "TXT_ESTANTE"
        Me.TXT_ESTANTE.Size = New System.Drawing.Size(76, 24)
        Me.TXT_ESTANTE.TabIndex = 26
        Me.TXT_ESTANTE.Text = "1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label13.Location = New System.Drawing.Point(240, 292)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 18)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Fila :"
        '
        'TXT_COLUMNA
        '
        Me.TXT_COLUMNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COLUMNA.Location = New System.Drawing.Point(476, 289)
        Me.TXT_COLUMNA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_COLUMNA.MaxLength = 3
        Me.TXT_COLUMNA.Name = "TXT_COLUMNA"
        Me.TXT_COLUMNA.Size = New System.Drawing.Size(76, 24)
        Me.TXT_COLUMNA.TabIndex = 30
        Me.TXT_COLUMNA.Text = "1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label12.Location = New System.Drawing.Point(50, 292)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 18)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Estante:"
        '
        'TXT_PRECIO
        '
        Me.TXT_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PRECIO.Location = New System.Drawing.Point(117, 258)
        Me.TXT_PRECIO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_PRECIO.MaxLength = 18
        Me.TXT_PRECIO.Name = "TXT_PRECIO"
        Me.TXT_PRECIO.Size = New System.Drawing.Size(76, 24)
        Me.TXT_PRECIO.TabIndex = 20
        Me.TXT_PRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_COSTO
        '
        Me.TXT_COSTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COSTO.Location = New System.Drawing.Point(117, 226)
        Me.TXT_COSTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_COSTO.MaxLength = 18
        Me.TXT_COSTO.Name = "TXT_COSTO"
        Me.TXT_COSTO.Size = New System.Drawing.Size(152, 24)
        Me.TXT_COSTO.TabIndex = 18
        Me.TXT_COSTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label11.Location = New System.Drawing.Point(45, 261)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 18)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Precio 1:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label10.Location = New System.Drawing.Point(15, 229)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 18)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Precio costo:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label9.Location = New System.Drawing.Point(424, 162)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 18)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "%"
        '
        'TXT_EXENTO
        '
        Me.TXT_EXENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_EXENTO.Location = New System.Drawing.Point(510, 159)
        Me.TXT_EXENTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_EXENTO.Name = "TXT_EXENTO"
        Me.TXT_EXENTO.ReadOnly = True
        Me.TXT_EXENTO.Size = New System.Drawing.Size(42, 24)
        Me.TXT_EXENTO.TabIndex = 14
        Me.TXT_EXENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label8.Location = New System.Drawing.Point(447, 162)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 18)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Exento :"
        '
        'TXT_IMPUESTO
        '
        Me.TXT_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_IMPUESTO.Location = New System.Drawing.Point(352, 159)
        Me.TXT_IMPUESTO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_IMPUESTO.Name = "TXT_IMPUESTO"
        Me.TXT_IMPUESTO.ReadOnly = True
        Me.TXT_IMPUESTO.Size = New System.Drawing.Size(68, 24)
        Me.TXT_IMPUESTO.TabIndex = 11
        Me.TXT_IMPUESTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.Location = New System.Drawing.Point(274, 162)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 18)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Impuesto :"
        '
        'CMB_IMPUESTO_DGTD
        '
        Me.CMB_IMPUESTO_DGTD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_IMPUESTO_DGTD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CMB_IMPUESTO_DGTD.FormattingEnabled = True
        Me.CMB_IMPUESTO_DGTD.Location = New System.Drawing.Point(117, 192)
        Me.CMB_IMPUESTO_DGTD.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_IMPUESTO_DGTD.Name = "CMB_IMPUESTO_DGTD"
        Me.CMB_IMPUESTO_DGTD.Size = New System.Drawing.Size(326, 23)
        Me.CMB_IMPUESTO_DGTD.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label6.Location = New System.Drawing.Point(5, 194)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 18)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Código DGTD:"
        '
        'CMB_UNIDADES
        '
        Me.CMB_UNIDADES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_UNIDADES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CMB_UNIDADES.FormattingEnabled = True
        Me.CMB_UNIDADES.Location = New System.Drawing.Point(117, 160)
        Me.CMB_UNIDADES.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_UNIDADES.Name = "CMB_UNIDADES"
        Me.CMB_UNIDADES.Size = New System.Drawing.Size(153, 23)
        Me.CMB_UNIDADES.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(2, 162)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Unidad Medida:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.Location = New System.Drawing.Point(31, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Proveedor:"
        '
        'TXT_DESC
        '
        Me.TXT_DESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESC.Location = New System.Drawing.Point(117, 125)
        Me.TXT_DESC.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_DESC.MaxLength = 150
        Me.TXT_DESC.Name = "TXT_DESC"
        Me.TXT_DESC.Size = New System.Drawing.Size(434, 24)
        Me.TXT_DESC.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.Location = New System.Drawing.Point(21, 128)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Descripción:"
        '
        'TXT_COD_BARRA
        '
        Me.TXT_COD_BARRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COD_BARRA.Location = New System.Drawing.Point(117, 59)
        Me.TXT_COD_BARRA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_COD_BARRA.MaxLength = 25
        Me.TXT_COD_BARRA.Name = "TXT_COD_BARRA"
        Me.TXT_COD_BARRA.Size = New System.Drawing.Size(434, 24)
        Me.TXT_COD_BARRA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label2.Location = New System.Drawing.Point(6, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código barras:"
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(117, 25)
        Me.TXT_CODIGO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_CODIGO.MaxLength = 20
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(152, 24)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label1.Location = New System.Drawing.Point(52, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código:"
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(377, 365)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 1
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(476, 365)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 2
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'Buscador
        '
        Me.Buscador.CAMPO_FILTRAR = "COD_SUCUR"
        Me.Buscador.CODIGO = Nothing
        Me.Buscador.DESCRIPCION = Nothing
        Me.Buscador.Location = New System.Drawing.Point(117, 86)
        Me.Buscador.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Buscador.Name = "Buscador"
        Me.Buscador.OTROS_CAMP0S = ""
        Me.Buscador.PANTALLA = Nothing
        Me.Buscador.Size = New System.Drawing.Size(451, 32)
        Me.Buscador.TabIndex = 5
        Me.Buscador.TABLA_BUSCAR = Nothing
        Me.Buscador.VALOR = ""
        Me.Buscador.VALOR_DESCRIPCION = Nothing
        '
        'ProductoMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(584, 410)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ProductoMant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Producto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_COD_BARRA As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_DESC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents CMB_UNIDADES As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CMB_IMPUESTO_DGTD As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXT_IMPUESTO As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXT_EXENTO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXT_COSTO As TextBox
    Friend WithEvents TXT_PRECIO As TextBox
    Friend WithEvents TXT_FILA As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TXT_ESTANTE As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXT_COLUMNA As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Buscador As Buscador
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RB_INACTIVO As RadioButton
    Friend WithEvents RB_ACTIVO As RadioButton
    Friend WithEvents Label15 As Label
    Friend WithEvents TXT_MINIMO As TextBox
    Friend WithEvents TXT_PRECIO_3 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TXT_PRECIO_2 As TextBox
    Friend WithEvents Label16 As Label
End Class
