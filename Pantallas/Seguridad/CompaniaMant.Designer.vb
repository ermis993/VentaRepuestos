<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LBL_CANTON
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LBL_CANTON))
        Me.LBL_CODIGO = New System.Windows.Forms.Label()
        Me.LBL_TIPO_CEDULA = New System.Windows.Forms.Label()
        Me.CMB_TIPO_CEDULA = New System.Windows.Forms.ComboBox()
        Me.LBL_CEDULA = New System.Windows.Forms.Label()
        Me.TXT_CEDULA = New System.Windows.Forms.MaskedTextBox()
        Me.LBL_NOMBRE = New System.Windows.Forms.Label()
        Me.TXT_NOMBRE = New System.Windows.Forms.TextBox()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.LBL_PROVINCIA = New System.Windows.Forms.Label()
        Me.CMB_PROVINCIA = New System.Windows.Forms.ComboBox()
        Me.LBL_CANTO = New System.Windows.Forms.Label()
        Me.CMB_CANTON = New System.Windows.Forms.ComboBox()
        Me.LBL_DISTRITO = New System.Windows.Forms.Label()
        Me.CMB_DISTRITO = New System.Windows.Forms.ComboBox()
        Me.TAB_COMPANIA = New System.Windows.Forms.TabControl()
        Me.TAB_INFO = New System.Windows.Forms.TabPage()
        Me.TXT_TELEFONO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHK_FE = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVA = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVA = New System.Windows.Forms.RadioButton()
        Me.TXT_EMAIL = New System.Windows.Forms.TextBox()
        Me.LBL_EMAIL = New System.Windows.Forms.Label()
        Me.TAB_FE = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GRID_ACTIVIDADES = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TXT_PIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_CLAVE_ATV = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_USUARIO_ATV = New System.Windows.Forms.TextBox()
        Me.OPD_Llave = New System.Windows.Forms.OpenFileDialog()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ELIMINAR = New System.Windows.Forms.Button()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_SELECCIONAR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.TAB_COMPANIA.SuspendLayout()
        Me.TAB_INFO.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TAB_FE.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GRID_ACTIVIDADES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_CODIGO
        '
        Me.LBL_CODIGO.AutoSize = True
        Me.LBL_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CODIGO.Location = New System.Drawing.Point(38, 9)
        Me.LBL_CODIGO.Name = "LBL_CODIGO"
        Me.LBL_CODIGO.Size = New System.Drawing.Size(64, 18)
        Me.LBL_CODIGO.TabIndex = 1
        Me.LBL_CODIGO.Text = "Código :"
        '
        'LBL_TIPO_CEDULA
        '
        Me.LBL_TIPO_CEDULA.AutoSize = True
        Me.LBL_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TIPO_CEDULA.ForeColor = System.Drawing.Color.Black
        Me.LBL_TIPO_CEDULA.Location = New System.Drawing.Point(9, 73)
        Me.LBL_TIPO_CEDULA.Name = "LBL_TIPO_CEDULA"
        Me.LBL_TIPO_CEDULA.Size = New System.Drawing.Size(92, 18)
        Me.LBL_TIPO_CEDULA.TabIndex = 5
        Me.LBL_TIPO_CEDULA.Text = "Tipo cédula :"
        '
        'CMB_TIPO_CEDULA
        '
        Me.CMB_TIPO_CEDULA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TIPO_CEDULA.FormattingEnabled = True
        Me.CMB_TIPO_CEDULA.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_TIPO_CEDULA.Location = New System.Drawing.Point(124, 67)
        Me.CMB_TIPO_CEDULA.Name = "CMB_TIPO_CEDULA"
        Me.CMB_TIPO_CEDULA.Size = New System.Drawing.Size(158, 24)
        Me.CMB_TIPO_CEDULA.TabIndex = 6
        '
        'LBL_CEDULA
        '
        Me.LBL_CEDULA.AutoSize = True
        Me.LBL_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CEDULA.ForeColor = System.Drawing.Color.Black
        Me.LBL_CEDULA.Location = New System.Drawing.Point(40, 99)
        Me.LBL_CEDULA.Name = "LBL_CEDULA"
        Me.LBL_CEDULA.Size = New System.Drawing.Size(62, 18)
        Me.LBL_CEDULA.TabIndex = 7
        Me.LBL_CEDULA.Text = "Cédula :"
        '
        'TXT_CEDULA
        '
        Me.TXT_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CEDULA.Location = New System.Drawing.Point(124, 97)
        Me.TXT_CEDULA.Name = "TXT_CEDULA"
        Me.TXT_CEDULA.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TXT_CEDULA.Size = New System.Drawing.Size(158, 22)
        Me.TXT_CEDULA.TabIndex = 8
        '
        'LBL_NOMBRE
        '
        Me.LBL_NOMBRE.AutoSize = True
        Me.LBL_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_NOMBRE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NOMBRE.Location = New System.Drawing.Point(31, 43)
        Me.LBL_NOMBRE.Name = "LBL_NOMBRE"
        Me.LBL_NOMBRE.Size = New System.Drawing.Size(70, 18)
        Me.LBL_NOMBRE.TabIndex = 3
        Me.LBL_NOMBRE.Text = "Nombre :"
        '
        'TXT_NOMBRE
        '
        Me.TXT_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_NOMBRE.Location = New System.Drawing.Point(124, 37)
        Me.TXT_NOMBRE.Multiline = True
        Me.TXT_NOMBRE.Name = "TXT_NOMBRE"
        Me.TXT_NOMBRE.Size = New System.Drawing.Size(342, 24)
        Me.TXT_NOMBRE.TabIndex = 4
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Enabled = False
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(124, 8)
        Me.TXT_CODIGO.Multiline = True
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(143, 24)
        Me.TXT_CODIGO.TabIndex = 2
        '
        'LBL_PROVINCIA
        '
        Me.LBL_PROVINCIA.AutoSize = True
        Me.LBL_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PROVINCIA.ForeColor = System.Drawing.Color.Black
        Me.LBL_PROVINCIA.Location = New System.Drawing.Point(25, 188)
        Me.LBL_PROVINCIA.Name = "LBL_PROVINCIA"
        Me.LBL_PROVINCIA.Size = New System.Drawing.Size(77, 18)
        Me.LBL_PROVINCIA.TabIndex = 11
        Me.LBL_PROVINCIA.Text = "Provincia :"
        '
        'CMB_PROVINCIA
        '
        Me.CMB_PROVINCIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_PROVINCIA.FormattingEnabled = True
        Me.CMB_PROVINCIA.Location = New System.Drawing.Point(124, 182)
        Me.CMB_PROVINCIA.Name = "CMB_PROVINCIA"
        Me.CMB_PROVINCIA.Size = New System.Drawing.Size(158, 24)
        Me.CMB_PROVINCIA.TabIndex = 12
        '
        'LBL_CANTO
        '
        Me.LBL_CANTO.AutoSize = True
        Me.LBL_CANTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CANTO.ForeColor = System.Drawing.Color.Black
        Me.LBL_CANTO.Location = New System.Drawing.Point(38, 218)
        Me.LBL_CANTO.Name = "LBL_CANTO"
        Me.LBL_CANTO.Size = New System.Drawing.Size(64, 18)
        Me.LBL_CANTO.TabIndex = 13
        Me.LBL_CANTO.Text = "Cantón :"
        '
        'CMB_CANTON
        '
        Me.CMB_CANTON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CANTON.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CANTON.FormattingEnabled = True
        Me.CMB_CANTON.Location = New System.Drawing.Point(124, 212)
        Me.CMB_CANTON.Name = "CMB_CANTON"
        Me.CMB_CANTON.Size = New System.Drawing.Size(158, 24)
        Me.CMB_CANTON.TabIndex = 14
        '
        'LBL_DISTRITO
        '
        Me.LBL_DISTRITO.AutoSize = True
        Me.LBL_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_DISTRITO.ForeColor = System.Drawing.Color.Black
        Me.LBL_DISTRITO.Location = New System.Drawing.Point(38, 248)
        Me.LBL_DISTRITO.Name = "LBL_DISTRITO"
        Me.LBL_DISTRITO.Size = New System.Drawing.Size(63, 18)
        Me.LBL_DISTRITO.TabIndex = 15
        Me.LBL_DISTRITO.Text = "Distrito :"
        '
        'CMB_DISTRITO
        '
        Me.CMB_DISTRITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_DISTRITO.FormattingEnabled = True
        Me.CMB_DISTRITO.Location = New System.Drawing.Point(124, 242)
        Me.CMB_DISTRITO.Name = "CMB_DISTRITO"
        Me.CMB_DISTRITO.Size = New System.Drawing.Size(158, 24)
        Me.CMB_DISTRITO.TabIndex = 16
        '
        'TAB_COMPANIA
        '
        Me.TAB_COMPANIA.Controls.Add(Me.TAB_INFO)
        Me.TAB_COMPANIA.Controls.Add(Me.TAB_FE)
        Me.TAB_COMPANIA.Location = New System.Drawing.Point(3, 3)
        Me.TAB_COMPANIA.Name = "TAB_COMPANIA"
        Me.TAB_COMPANIA.SelectedIndex = 0
        Me.TAB_COMPANIA.Size = New System.Drawing.Size(561, 393)
        Me.TAB_COMPANIA.TabIndex = 15
        '
        'TAB_INFO
        '
        Me.TAB_INFO.Controls.Add(Me.TXT_TELEFONO)
        Me.TAB_INFO.Controls.Add(Me.Label1)
        Me.TAB_INFO.Controls.Add(Me.CHK_FE)
        Me.TAB_INFO.Controls.Add(Me.GroupBox1)
        Me.TAB_INFO.Controls.Add(Me.TXT_EMAIL)
        Me.TAB_INFO.Controls.Add(Me.LBL_EMAIL)
        Me.TAB_INFO.Controls.Add(Me.LBL_CODIGO)
        Me.TAB_INFO.Controls.Add(Me.LBL_TIPO_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.CMB_DISTRITO)
        Me.TAB_INFO.Controls.Add(Me.CMB_TIPO_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.LBL_DISTRITO)
        Me.TAB_INFO.Controls.Add(Me.LBL_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.CMB_CANTON)
        Me.TAB_INFO.Controls.Add(Me.TXT_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.LBL_CANTO)
        Me.TAB_INFO.Controls.Add(Me.LBL_NOMBRE)
        Me.TAB_INFO.Controls.Add(Me.CMB_PROVINCIA)
        Me.TAB_INFO.Controls.Add(Me.TXT_NOMBRE)
        Me.TAB_INFO.Controls.Add(Me.LBL_PROVINCIA)
        Me.TAB_INFO.Controls.Add(Me.TXT_CODIGO)
        Me.TAB_INFO.Location = New System.Drawing.Point(4, 22)
        Me.TAB_INFO.Name = "TAB_INFO"
        Me.TAB_INFO.Padding = New System.Windows.Forms.Padding(3)
        Me.TAB_INFO.Size = New System.Drawing.Size(553, 367)
        Me.TAB_INFO.TabIndex = 0
        Me.TAB_INFO.Text = "Información general"
        Me.TAB_INFO.UseVisualStyleBackColor = True
        '
        'TXT_TELEFONO
        '
        Me.TXT_TELEFONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_TELEFONO.Location = New System.Drawing.Point(124, 124)
        Me.TXT_TELEFONO.Multiline = True
        Me.TXT_TELEFONO.Name = "TXT_TELEFONO"
        Me.TXT_TELEFONO.Size = New System.Drawing.Size(158, 24)
        Me.TXT_TELEFONO.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Teléfono :"
        '
        'CHK_FE
        '
        Me.CHK_FE.AutoSize = True
        Me.CHK_FE.Checked = True
        Me.CHK_FE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_FE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_FE.Location = New System.Drawing.Point(124, 275)
        Me.CHK_FE.Name = "CHK_FE"
        Me.CHK_FE.Size = New System.Drawing.Size(194, 20)
        Me.CHK_FE.TabIndex = 17
        Me.CHK_FE.Text = "¿Es facturación electrónica?"
        Me.CHK_FE.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_INACTIVA)
        Me.GroupBox1.Controls.Add(Me.RB_ACTIVA)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox1.Location = New System.Drawing.Point(124, 306)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 48)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado"
        '
        'RB_INACTIVA
        '
        Me.RB_INACTIVA.AutoSize = True
        Me.RB_INACTIVA.Location = New System.Drawing.Point(263, 19)
        Me.RB_INACTIVA.Name = "RB_INACTIVA"
        Me.RB_INACTIVA.Size = New System.Drawing.Size(72, 20)
        Me.RB_INACTIVA.TabIndex = 19
        Me.RB_INACTIVA.TabStop = True
        Me.RB_INACTIVA.Text = "Inactiva"
        Me.RB_INACTIVA.UseVisualStyleBackColor = True
        '
        'RB_ACTIVA
        '
        Me.RB_ACTIVA.AutoSize = True
        Me.RB_ACTIVA.Checked = True
        Me.RB_ACTIVA.Location = New System.Drawing.Point(15, 19)
        Me.RB_ACTIVA.Name = "RB_ACTIVA"
        Me.RB_ACTIVA.Size = New System.Drawing.Size(63, 20)
        Me.RB_ACTIVA.TabIndex = 18
        Me.RB_ACTIVA.TabStop = True
        Me.RB_ACTIVA.Text = "Activa"
        Me.RB_ACTIVA.UseVisualStyleBackColor = True
        '
        'TXT_EMAIL
        '
        Me.TXT_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_EMAIL.Location = New System.Drawing.Point(124, 152)
        Me.TXT_EMAIL.Multiline = True
        Me.TXT_EMAIL.Name = "TXT_EMAIL"
        Me.TXT_EMAIL.Size = New System.Drawing.Size(342, 24)
        Me.TXT_EMAIL.TabIndex = 10
        '
        'LBL_EMAIL
        '
        Me.LBL_EMAIL.AutoSize = True
        Me.LBL_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_EMAIL.ForeColor = System.Drawing.Color.Black
        Me.LBL_EMAIL.Location = New System.Drawing.Point(49, 157)
        Me.LBL_EMAIL.Name = "LBL_EMAIL"
        Me.LBL_EMAIL.Size = New System.Drawing.Size(53, 18)
        Me.LBL_EMAIL.TabIndex = 9
        Me.LBL_EMAIL.Text = "Email :"
        '
        'TAB_FE
        '
        Me.TAB_FE.Controls.Add(Me.GroupBox4)
        Me.TAB_FE.Controls.Add(Me.GroupBox3)
        Me.TAB_FE.Controls.Add(Me.GroupBox2)
        Me.TAB_FE.Location = New System.Drawing.Point(4, 22)
        Me.TAB_FE.Name = "TAB_FE"
        Me.TAB_FE.Padding = New System.Windows.Forms.Padding(3)
        Me.TAB_FE.Size = New System.Drawing.Size(553, 367)
        Me.TAB_FE.TabIndex = 1
        Me.TAB_FE.Text = "Facturación Electrónica"
        Me.TAB_FE.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BTN_MODIFICAR)
        Me.GroupBox4.Controls.Add(Me.BTN_ELIMINAR)
        Me.GroupBox4.Controls.Add(Me.BTN_AGREGAR)
        Me.GroupBox4.Controls.Add(Me.GRID_ACTIVIDADES)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 159)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(544, 202)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Activiades económicas"
        '
        'GRID_ACTIVIDADES
        '
        Me.GRID_ACTIVIDADES.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID_ACTIVIDADES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID_ACTIVIDADES.Location = New System.Drawing.Point(3, 19)
        Me.GRID_ACTIVIDADES.MultiSelect = False
        Me.GRID_ACTIVIDADES.Name = "GRID_ACTIVIDADES"
        Me.GRID_ACTIVIDADES.ReadOnly = True
        Me.GRID_ACTIVIDADES.Size = New System.Drawing.Size(396, 177)
        Me.GRID_ACTIVIDADES.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BTN_SELECCIONAR)
        Me.GroupBox3.Controls.Add(Me.TXT_PIN)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Green
        Me.GroupBox3.Location = New System.Drawing.Point(279, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(271, 147)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[Llave criptográfica]"
        '
        'TXT_PIN
        '
        Me.TXT_PIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_PIN.Location = New System.Drawing.Point(6, 99)
        Me.TXT_PIN.Name = "TXT_PIN"
        Me.TXT_PIN.Size = New System.Drawing.Size(255, 22)
        Me.TXT_PIN.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "PIN :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TXT_CLAVE_ATV)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TXT_USUARIO_ATV)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Green
        Me.GroupBox2.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 150)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ATV]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(0, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Clave :"
        '
        'TXT_CLAVE_ATV
        '
        Me.TXT_CLAVE_ATV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_CLAVE_ATV.Location = New System.Drawing.Point(3, 102)
        Me.TXT_CLAVE_ATV.Name = "TXT_CLAVE_ATV"
        Me.TXT_CLAVE_ATV.Size = New System.Drawing.Size(255, 22)
        Me.TXT_CLAVE_ATV.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Usuario :"
        '
        'TXT_USUARIO_ATV
        '
        Me.TXT_USUARIO_ATV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_USUARIO_ATV.Location = New System.Drawing.Point(3, 42)
        Me.TXT_USUARIO_ATV.Name = "TXT_USUARIO_ATV"
        Me.TXT_USUARIO_ATV.Size = New System.Drawing.Size(255, 22)
        Me.TXT_USUARIO_ATV.TabIndex = 0
        '
        'OPD_Llave
        '
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(463, 402)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 22
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_ELIMINAR
        '
        Me.BTN_ELIMINAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ELIMINAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_ELIMINAR.Image = Global.VentaRepuestos.My.Resources.Resources.delete
        Me.BTN_ELIMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ELIMINAR.Location = New System.Drawing.Point(405, 153)
        Me.BTN_ELIMINAR.Name = "BTN_ELIMINAR"
        Me.BTN_ELIMINAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ELIMINAR.TabIndex = 24
        Me.BTN_ELIMINAR.Text = "Eliminar"
        Me.BTN_ELIMINAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ELIMINAR.UseVisualStyleBackColor = False
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_AGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AGREGAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_AGREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(405, 19)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_AGREGAR.TabIndex = 24
        Me.BTN_AGREGAR.Text = "Agregar"
        Me.BTN_AGREGAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_AGREGAR.UseVisualStyleBackColor = False
        '
        'BTN_SELECCIONAR
        '
        Me.BTN_SELECCIONAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SELECCIONAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SELECCIONAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_SELECCIONAR.Image = Global.VentaRepuestos.My.Resources.Resources.archivos
        Me.BTN_SELECCIONAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SELECCIONAR.Location = New System.Drawing.Point(6, 18)
        Me.BTN_SELECCIONAR.Name = "BTN_SELECCIONAR"
        Me.BTN_SELECCIONAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SELECCIONAR.TabIndex = 23
        Me.BTN_SELECCIONAR.Text = "Importar"
        Me.BTN_SELECCIONAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SELECCIONAR.UseVisualStyleBackColor = False
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(364, 402)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 21
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'BTN_MODIFICAR
        '
        Me.BTN_MODIFICAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_MODIFICAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MODIFICAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_MODIFICAR.Image = Global.VentaRepuestos.My.Resources.Resources.controles
        Me.BTN_MODIFICAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(405, 84)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_MODIFICAR.TabIndex = 25
        Me.BTN_MODIFICAR.Text = "Modificar"
        Me.BTN_MODIFICAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_MODIFICAR.UseVisualStyleBackColor = False
        '
        'LBL_CANTON
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(565, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.TAB_COMPANIA)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "LBL_CANTON"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compania"
        Me.TAB_COMPANIA.ResumeLayout(False)
        Me.TAB_INFO.ResumeLayout(False)
        Me.TAB_INFO.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TAB_FE.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GRID_ACTIVIDADES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBL_CODIGO As Label
    Friend WithEvents LBL_TIPO_CEDULA As Label
    Friend WithEvents CMB_TIPO_CEDULA As ComboBox
    Friend WithEvents LBL_CEDULA As Label
    Friend WithEvents TXT_CEDULA As MaskedTextBox
    Friend WithEvents LBL_NOMBRE As Label
    Friend WithEvents TXT_NOMBRE As TextBox
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents LBL_PROVINCIA As Label
    Friend WithEvents CMB_PROVINCIA As ComboBox
    Friend WithEvents LBL_CANTO As Label
    Friend WithEvents CMB_CANTON As ComboBox
    Friend WithEvents LBL_DISTRITO As Label
    Friend WithEvents CMB_DISTRITO As ComboBox
    Friend WithEvents TAB_COMPANIA As TabControl
    Friend WithEvents TAB_INFO As TabPage
    Friend WithEvents TAB_FE As TabPage
    Friend WithEvents LBL_EMAIL As Label
    Friend WithEvents TXT_EMAIL As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RB_INACTIVA As RadioButton
    Friend WithEvents RB_ACTIVA As RadioButton
    Friend WithEvents CHK_FE As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TXT_USUARIO_ATV As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_TELEFONO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_CLAVE_ATV As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXT_PIN As TextBox
    Friend WithEvents OPD_Llave As OpenFileDialog
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_SELECCIONAR As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GRID_ACTIVIDADES As DataGridView
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents BTN_ELIMINAR As Button
    Friend WithEvents BTN_MODIFICAR As Button
End Class
