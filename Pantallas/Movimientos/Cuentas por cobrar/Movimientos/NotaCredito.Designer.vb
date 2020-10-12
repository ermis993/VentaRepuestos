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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotaCredito))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_TIPO = New System.Windows.Forms.ComboBox()
        Me.LBLTIPO = New System.Windows.Forms.Label()
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
        Me.TAB_FACTURAS = New System.Windows.Forms.TabPage()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.TAB_DET = New System.Windows.Forms.TabPage()
        Me.GRID2 = New System.Windows.Forms.DataGridView()
        Me.TAB_PRODUCTOS = New System.Windows.Forms.TabPage()
        Me.GRIDPRODS2 = New System.Windows.Forms.DataGridView()
        Me.GRIDPRODS = New System.Windows.Forms.DataGridView()
        Me.TXT_DIF = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXT_DIS = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXT_M = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IgualarMontoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngrearMontoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TAB_ENC.SuspendLayout()
        Me.TAB_FACTURAS.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB_DET.SuspendLayout()
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB_PRODUCTOS.SuspendLayout()
        CType(Me.GRIDPRODS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDPRODS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS.SuspendLayout()
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
        Me.GroupBox1.Size = New System.Drawing.Size(790, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información ]"
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
        Me.CMB_TIPO.TabIndex = 5
        '
        'LBLTIPO
        '
        Me.LBLTIPO.AutoSize = True
        Me.LBLTIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.LBLTIPO.Location = New System.Drawing.Point(321, 48)
        Me.LBLTIPO.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBLTIPO.Name = "LBLTIPO"
        Me.LBLTIPO.Size = New System.Drawing.Size(45, 18)
        Me.LBLTIPO.TabIndex = 4
        Me.LBLTIPO.Text = "Tipo :"
        '
        'TXT_TIPO_CAMBIO
        '
        Me.TXT_TIPO_CAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_TIPO_CAMBIO.Location = New System.Drawing.Point(670, 44)
        Me.TXT_TIPO_CAMBIO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_TIPO_CAMBIO.Name = "TXT_TIPO_CAMBIO"
        Me.TXT_TIPO_CAMBIO.Size = New System.Drawing.Size(116, 24)
        Me.TXT_TIPO_CAMBIO.TabIndex = 9
        Me.TXT_TIPO_CAMBIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.Location = New System.Drawing.Point(626, 47)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "T.C :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.Location = New System.Drawing.Point(609, 19)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha :"
        '
        'DTPFECHA
        '
        Me.DTPFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.DTPFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHA.Location = New System.Drawing.Point(670, 16)
        Me.DTPFECHA.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPFECHA.Name = "DTPFECHA"
        Me.DTPFECHA.Size = New System.Drawing.Size(116, 24)
        Me.DTPFECHA.TabIndex = 7
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TAB_ENC)
        Me.TabControl1.Controls.Add(Me.TAB_FACTURAS)
        Me.TabControl1.Controls.Add(Me.TAB_DET)
        Me.TabControl1.Controls.Add(Me.TAB_PRODUCTOS)
        Me.TabControl1.Location = New System.Drawing.Point(2, 86)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(790, 234)
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
        Me.TAB_ENC.Location = New System.Drawing.Point(4, 22)
        Me.TAB_ENC.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Name = "TAB_ENC"
        Me.TAB_ENC.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_ENC.Size = New System.Drawing.Size(782, 208)
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
        'TAB_FACTURAS
        '
        Me.TAB_FACTURAS.Controls.Add(Me.GRID)
        Me.TAB_FACTURAS.Location = New System.Drawing.Point(4, 22)
        Me.TAB_FACTURAS.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_FACTURAS.Name = "TAB_FACTURAS"
        Me.TAB_FACTURAS.Size = New System.Drawing.Size(782, 208)
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
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.RowTemplate.Height = 24
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(777, 206)
        Me.GRID.TabIndex = 0
        '
        'TAB_DET
        '
        Me.TAB_DET.Controls.Add(Me.GRID2)
        Me.TAB_DET.Location = New System.Drawing.Point(4, 22)
        Me.TAB_DET.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Name = "TAB_DET"
        Me.TAB_DET.Padding = New System.Windows.Forms.Padding(2)
        Me.TAB_DET.Size = New System.Drawing.Size(782, 208)
        Me.TAB_DET.TabIndex = 1
        Me.TAB_DET.Text = "[ Detalle ]"
        Me.TAB_DET.UseVisualStyleBackColor = True
        '
        'GRID2
        '
        Me.GRID2.AllowUserToAddRows = False
        Me.GRID2.AllowUserToDeleteRows = False
        Me.GRID2.AllowUserToOrderColumns = True
        Me.GRID2.AllowUserToResizeColumns = False
        Me.GRID2.AllowUserToResizeRows = False
        Me.GRID2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GRID2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GRID2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID2.Location = New System.Drawing.Point(3, 1)
        Me.GRID2.Margin = New System.Windows.Forms.Padding(2)
        Me.GRID2.MultiSelect = False
        Me.GRID2.Name = "GRID2"
        Me.GRID2.ReadOnly = True
        Me.GRID2.RowHeadersVisible = False
        Me.GRID2.RowHeadersWidth = 51
        Me.GRID2.RowTemplate.Height = 24
        Me.GRID2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID2.Size = New System.Drawing.Size(777, 206)
        Me.GRID2.TabIndex = 1
        '
        'TAB_PRODUCTOS
        '
        Me.TAB_PRODUCTOS.Controls.Add(Me.GRIDPRODS2)
        Me.TAB_PRODUCTOS.Controls.Add(Me.GRIDPRODS)
        Me.TAB_PRODUCTOS.Location = New System.Drawing.Point(4, 22)
        Me.TAB_PRODUCTOS.Name = "TAB_PRODUCTOS"
        Me.TAB_PRODUCTOS.Size = New System.Drawing.Size(782, 208)
        Me.TAB_PRODUCTOS.TabIndex = 3
        Me.TAB_PRODUCTOS.Text = "[ Productos ]"
        Me.TAB_PRODUCTOS.UseVisualStyleBackColor = True
        '
        'GRIDPRODS2
        '
        Me.GRIDPRODS2.AllowUserToAddRows = False
        Me.GRIDPRODS2.AllowUserToDeleteRows = False
        Me.GRIDPRODS2.AllowUserToOrderColumns = True
        Me.GRIDPRODS2.AllowUserToResizeColumns = False
        Me.GRIDPRODS2.AllowUserToResizeRows = False
        Me.GRIDPRODS2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GRIDPRODS2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GRIDPRODS2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDPRODS2.Location = New System.Drawing.Point(3, 103)
        Me.GRIDPRODS2.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDPRODS2.MultiSelect = False
        Me.GRIDPRODS2.Name = "GRIDPRODS2"
        Me.GRIDPRODS2.ReadOnly = True
        Me.GRIDPRODS2.RowHeadersVisible = False
        Me.GRIDPRODS2.RowHeadersWidth = 51
        Me.GRIDPRODS2.RowTemplate.Height = 24
        Me.GRIDPRODS2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDPRODS2.Size = New System.Drawing.Size(777, 103)
        Me.GRIDPRODS2.TabIndex = 3
        '
        'GRIDPRODS
        '
        Me.GRIDPRODS.AllowUserToAddRows = False
        Me.GRIDPRODS.AllowUserToDeleteRows = False
        Me.GRIDPRODS.AllowUserToOrderColumns = True
        Me.GRIDPRODS.AllowUserToResizeColumns = False
        Me.GRIDPRODS.AllowUserToResizeRows = False
        Me.GRIDPRODS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GRIDPRODS.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GRIDPRODS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDPRODS.Location = New System.Drawing.Point(3, 1)
        Me.GRIDPRODS.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDPRODS.MultiSelect = False
        Me.GRIDPRODS.Name = "GRIDPRODS"
        Me.GRIDPRODS.ReadOnly = True
        Me.GRIDPRODS.RowHeadersVisible = False
        Me.GRIDPRODS.RowHeadersWidth = 51
        Me.GRIDPRODS.RowTemplate.Height = 24
        Me.GRIDPRODS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDPRODS.Size = New System.Drawing.Size(777, 98)
        Me.GRIDPRODS.TabIndex = 2
        '
        'TXT_DIF
        '
        Me.TXT_DIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DIF.Location = New System.Drawing.Point(354, 334)
        Me.TXT_DIF.Name = "TXT_DIF"
        Me.TXT_DIF.ReadOnly = True
        Me.TXT_DIF.Size = New System.Drawing.Size(160, 24)
        Me.TXT_DIF.TabIndex = 7
        Me.TXT_DIF.Text = "0.0000"
        Me.TXT_DIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label25.Location = New System.Drawing.Point(271, 337)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 18)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Diferencia :"
        '
        'TXT_DIS
        '
        Me.TXT_DIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DIS.Location = New System.Drawing.Point(92, 348)
        Me.TXT_DIS.Name = "TXT_DIS"
        Me.TXT_DIS.ReadOnly = True
        Me.TXT_DIS.Size = New System.Drawing.Size(160, 24)
        Me.TXT_DIS.TabIndex = 5
        Me.TXT_DIS.Text = "0.0000"
        Me.TXT_DIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label23.Location = New System.Drawing.Point(3, 351)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 18)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Distribuido :"
        '
        'TXT_M
        '
        Me.TXT_M.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_M.Location = New System.Drawing.Point(92, 323)
        Me.TXT_M.Name = "TXT_M"
        Me.TXT_M.ReadOnly = True
        Me.TXT_M.Size = New System.Drawing.Size(160, 24)
        Me.TXT_M.TabIndex = 3
        Me.TXT_M.Text = "0.0000"
        Me.TXT_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label16.Location = New System.Drawing.Point(21, 326)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 18)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Monto :"
        '
        'CMS
        '
        Me.CMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IgualarMontoToolStripMenuItem, Me.IngrearMontoToolStripMenuItem})
        Me.CMS.Name = "CMS"
        Me.CMS.Size = New System.Drawing.Size(156, 48)
        '
        'IgualarMontoToolStripMenuItem
        '
        Me.IgualarMontoToolStripMenuItem.Name = "IgualarMontoToolStripMenuItem"
        Me.IgualarMontoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.IgualarMontoToolStripMenuItem.Text = "Igualar monto"
        '
        'IngrearMontoToolStripMenuItem
        '
        Me.IngrearMontoToolStripMenuItem.Name = "IngrearMontoToolStripMenuItem"
        Me.IngrearMontoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.IngrearMontoToolStripMenuItem.Text = "Ingresar monto"
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(693, 325)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 9
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(594, 325)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 8
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'NotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.TXT_DIF)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TXT_DIS)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TXT_M)
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
        Me.TAB_FACTURAS.ResumeLayout(False)
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB_DET.ResumeLayout(False)
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB_PRODUCTOS.ResumeLayout(False)
        CType(Me.GRIDPRODS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDPRODS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS.ResumeLayout(False)
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
    Friend WithEvents TAB_FACTURAS As TabPage
    Friend WithEvents GRID As DataGridView
    Friend WithEvents TXT_DIF As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TXT_DIS As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TXT_M As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents GRID2 As DataGridView
    Friend WithEvents TAB_PRODUCTOS As TabPage
    Friend WithEvents GRIDPRODS As DataGridView
    Friend WithEvents GRIDPRODS2 As DataGridView
    Friend WithEvents CMS As ContextMenuStrip
    Friend WithEvents IgualarMontoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IngrearMontoToolStripMenuItem As ToolStripMenuItem
End Class
