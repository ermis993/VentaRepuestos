<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotaCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotaCredito))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_TIPO_CAMBIO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHA = New System.Windows.Forms.DateTimePicker()
        Me.TXT_NUMERO = New System.Windows.Forms.TextBox()
        Me.CMB_DOCUMENTO = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBLTIPO = New System.Windows.Forms.Label()
        Me.CMB_TIPO = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TAB_ENC = New System.Windows.Forms.TabPage()
        Me.Cliente = New VentaRepuestos.Buscador()
        Me.TXT_DESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMB_MONEDA = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TAB_DET = New System.Windows.Forms.TabPage()
        Me.LVResultados = New System.Windows.Forms.ListView()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.TXT_CANTIDAD = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BTN_INGRESAR = New System.Windows.Forms.Button()
        Me.TAB_FACTURAS = New System.Windows.Forms.TabPage()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.TXT_T = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXT_I = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXT_D = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXT_S = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TAB_ENC.SuspendLayout()
        Me.TAB_DET.SuspendLayout()
        Me.TAB_FACTURAS.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_TIPO)
        Me.GroupBox1.Controls.Add(Me.LBLTIPO)
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
        Me.GroupBox1.Size = New System.Drawing.Size(759, 80)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información ]"
        '
        'TXT_TIPO_CAMBIO
        '
        Me.TXT_TIPO_CAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TIPO_CAMBIO.Location = New System.Drawing.Point(637, 45)
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
        Me.Label4.Location = New System.Drawing.Point(593, 48)
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
        Me.Label3.Location = New System.Drawing.Point(576, 20)
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
        Me.DTPFECHA.Location = New System.Drawing.Point(637, 17)
        Me.DTPFECHA.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPFECHA.Name = "DTPFECHA"
        Me.DTPFECHA.Size = New System.Drawing.Size(116, 24)
        Me.DTPFECHA.TabIndex = 5
        '
        'TXT_NUMERO
        '
        Me.TXT_NUMERO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_NUMERO.Location = New System.Drawing.Point(99, 17)
        Me.TXT_NUMERO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_NUMERO.Name = "TXT_NUMERO"
        Me.TXT_NUMERO.Size = New System.Drawing.Size(195, 24)
        Me.TXT_NUMERO.TabIndex = 1
        '
        'CMB_DOCUMENTO
        '
        Me.CMB_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_DOCUMENTO.FormattingEnabled = True
        Me.CMB_DOCUMENTO.Items.AddRange(New Object() {"RB-Recibo de dinero", "NC-Nota de crédito"})
        Me.CMB_DOCUMENTO.Location = New System.Drawing.Point(99, 44)
        Me.CMB_DOCUMENTO.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_DOCUMENTO.Name = "CMB_DOCUMENTO"
        Me.CMB_DOCUMENTO.Size = New System.Drawing.Size(195, 26)
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
        'LBLTIPO
        '
        Me.LBLTIPO.AutoSize = True
        Me.LBLTIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.LBLTIPO.Location = New System.Drawing.Point(321, 48)
        Me.LBLTIPO.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBLTIPO.Name = "LBLTIPO"
        Me.LBLTIPO.Size = New System.Drawing.Size(45, 18)
        Me.LBLTIPO.TabIndex = 8
        Me.LBLTIPO.Text = "Tipo :"
        '
        'CMB_TIPO
        '
        Me.CMB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_TIPO.FormattingEnabled = True
        Me.CMB_TIPO.Items.AddRange(New Object() {"DV-Devolución", "DF-Diferencia de precio"})
        Me.CMB_TIPO.Location = New System.Drawing.Point(370, 44)
        Me.CMB_TIPO.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_TIPO.Name = "CMB_TIPO"
        Me.CMB_TIPO.Size = New System.Drawing.Size(195, 26)
        Me.CMB_TIPO.TabIndex = 9
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TAB_ENC)
        Me.TabControl1.Controls.Add(Me.TAB_FACTURAS)
        Me.TabControl1.Controls.Add(Me.TAB_DET)
        Me.TabControl1.Location = New System.Drawing.Point(2, 86)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(759, 234)
        Me.TabControl1.TabIndex = 2
        '
        'TAB_ENC
        '
        Me.TAB_ENC.Controls.Add(Me.Cliente)
        Me.TAB_ENC.Controls.Add(Me.TXT_DESCRIPCION)
        Me.TAB_ENC.Controls.Add(Me.Label10)
        Me.TAB_ENC.Controls.Add(Me.CMB_MONEDA)
        Me.TAB_ENC.Controls.Add(Me.Label7)
        Me.TAB_ENC.Controls.Add(Me.Label6)
        Me.TAB_ENC.Location = New System.Drawing.Point(4, 22)
        Me.TAB_ENC.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Name = "TAB_ENC"
        Me.TAB_ENC.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Size = New System.Drawing.Size(788, 208)
        Me.TAB_ENC.TabIndex = 0
        Me.TAB_ENC.Text = "[ Encabezado ]"
        Me.TAB_ENC.UseVisualStyleBackColor = True
        '
        'Cliente
        '
        Me.Cliente.CODIGO = Nothing
        Me.Cliente.DESCRIPCION = Nothing
        Me.Cliente.Location = New System.Drawing.Point(111, 10)
        Me.Cliente.Margin = New System.Windows.Forms.Padding(2)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OTROS_CAMP0S = Nothing
        Me.Cliente.PANTALLA = Nothing
        Me.Cliente.Size = New System.Drawing.Size(451, 32)
        Me.Cliente.TabIndex = 1
        Me.Cliente.TABLA_BUSCAR = Nothing
        Me.Cliente.VALOR = ""
        Me.Cliente.VALOR_DESCRIPCION = Nothing
        '
        'TXT_DESCRIPCION
        '
        Me.TXT_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESCRIPCION.Location = New System.Drawing.Point(110, 75)
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
        Me.Label10.Location = New System.Drawing.Point(9, 75)
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
        Me.CMB_MONEDA.Location = New System.Drawing.Point(111, 42)
        Me.CMB_MONEDA.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_MONEDA.Name = "CMB_MONEDA"
        Me.CMB_MONEDA.Size = New System.Drawing.Size(155, 26)
        Me.CMB_MONEDA.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.Location = New System.Drawing.Point(33, 46)
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
        'TAB_DET
        '
        Me.TAB_DET.Controls.Add(Me.LVResultados)
        Me.TAB_DET.Controls.Add(Me.Label19)
        Me.TAB_DET.Controls.Add(Me.TXT_CODIGO)
        Me.TAB_DET.Controls.Add(Me.TXT_CANTIDAD)
        Me.TAB_DET.Controls.Add(Me.Label13)
        Me.TAB_DET.Controls.Add(Me.Label22)
        Me.TAB_DET.Controls.Add(Me.BTN_INGRESAR)
        Me.TAB_DET.Location = New System.Drawing.Point(4, 22)
        Me.TAB_DET.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Name = "TAB_DET"
        Me.TAB_DET.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Size = New System.Drawing.Size(788, 208)
        Me.TAB_DET.TabIndex = 1
        Me.TAB_DET.Text = "[ Detalle ]"
        Me.TAB_DET.UseVisualStyleBackColor = True
        '
        'LVResultados
        '
        Me.LVResultados.HideSelection = False
        Me.LVResultados.Location = New System.Drawing.Point(132, 44)
        Me.LVResultados.Name = "LVResultados"
        Me.LVResultados.Size = New System.Drawing.Size(378, 73)
        Me.LVResultados.TabIndex = 3
        Me.LVResultados.UseCompatibleStateImageBehavior = False
        Me.LVResultados.View = System.Windows.Forms.View.List
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
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label22.Location = New System.Drawing.Point(5, 16)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 18)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Nombre/Código :"
        '
        'BTN_INGRESAR
        '
        Me.BTN_INGRESAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_INGRESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_INGRESAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_INGRESAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(683, 162)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_INGRESAR.TabIndex = 16
        Me.BTN_INGRESAR.Text = "Ingresar"
        Me.BTN_INGRESAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_INGRESAR.UseVisualStyleBackColor = False
        '
        'TAB_FACTURAS
        '
        Me.TAB_FACTURAS.Controls.Add(Me.GRID)
        Me.TAB_FACTURAS.Location = New System.Drawing.Point(4, 22)
        Me.TAB_FACTURAS.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_FACTURAS.Name = "TAB_FACTURAS"
        Me.TAB_FACTURAS.Size = New System.Drawing.Size(751, 208)
        Me.TAB_FACTURAS.TabIndex = 2
        Me.TAB_FACTURAS.Text = "[ Facturas ]"
        Me.TAB_FACTURAS.UseVisualStyleBackColor = True
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
        Me.GRID.Size = New System.Drawing.Size(747, 206)
        Me.GRID.TabIndex = 0
        '
        'TXT_T
        '
        Me.TXT_T.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_T.Location = New System.Drawing.Point(341, 348)
        Me.TXT_T.Name = "TXT_T"
        Me.TXT_T.ReadOnly = True
        Me.TXT_T.Size = New System.Drawing.Size(160, 24)
        Me.TXT_T.TabIndex = 17
        Me.TXT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label24.Location = New System.Drawing.Point(286, 351)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 18)
        Me.Label24.TabIndex = 16
        Me.Label24.Text = "Total :"
        '
        'TXT_I
        '
        Me.TXT_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_I.Location = New System.Drawing.Point(341, 323)
        Me.TXT_I.Name = "TXT_I"
        Me.TXT_I.ReadOnly = True
        Me.TXT_I.Size = New System.Drawing.Size(160, 24)
        Me.TXT_I.TabIndex = 15
        Me.TXT_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label25.Location = New System.Drawing.Point(258, 326)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(77, 18)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Impuesto :"
        '
        'TXT_D
        '
        Me.TXT_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_D.Location = New System.Drawing.Point(92, 348)
        Me.TXT_D.Name = "TXT_D"
        Me.TXT_D.ReadOnly = True
        Me.TXT_D.Size = New System.Drawing.Size(160, 24)
        Me.TXT_D.TabIndex = 13
        Me.TXT_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label23.Location = New System.Drawing.Point(3, 351)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 18)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Descuento :"
        '
        'TXT_S
        '
        Me.TXT_S.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_S.Location = New System.Drawing.Point(92, 323)
        Me.TXT_S.Name = "TXT_S"
        Me.TXT_S.ReadOnly = True
        Me.TXT_S.Size = New System.Drawing.Size(160, 24)
        Me.TXT_S.TabIndex = 11
        Me.TXT_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label16.Location = New System.Drawing.Point(21, 326)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 18)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Subtotal :"
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(662, 325)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 19
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(563, 325)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 18
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'NotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.TXT_T)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TXT_I)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TXT_D)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TXT_S)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "NotaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TAB_ENC.ResumeLayout(False)
        Me.TAB_ENC.PerformLayout()
        Me.TAB_DET.ResumeLayout(False)
        Me.TAB_DET.PerformLayout()
        Me.TAB_FACTURAS.ResumeLayout(False)
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
    Friend WithEvents CMB_TIPO As ComboBox
    Friend WithEvents LBLTIPO As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TAB_ENC As TabPage
    Friend WithEvents Cliente As Buscador
    Friend WithEvents TXT_DESCRIPCION As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CMB_MONEDA As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TAB_DET As TabPage
    Friend WithEvents LVResultados As ListView
    Friend WithEvents Label19 As Label
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents TXT_CANTIDAD As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents BTN_INGRESAR As Button
    Friend WithEvents TAB_FACTURAS As TabPage
    Friend WithEvents GRID As DataGridView
    Friend WithEvents TXT_T As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TXT_I As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TXT_D As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TXT_S As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_ACEPTAR As Button
End Class
