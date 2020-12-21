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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CHK_ENCOMIENDA = New System.Windows.Forms.CheckBox()
        Me.TXT_DIRECCION = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHK_FE = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVA = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVA = New System.Windows.Forms.RadioButton()
        Me.TXT_EMAIL = New System.Windows.Forms.TextBox()
        Me.LBL_EMAIL = New System.Windows.Forms.Label()
        Me.TAB_FE = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RB_PRUEBAS = New System.Windows.Forms.RadioButton()
        Me.RB_REAL = New System.Windows.Forms.RadioButton()
        Me.LINK_CONSULTAS = New System.Windows.Forms.TextBox()
        Me.LINK_FT = New System.Windows.Forms.TextBox()
        Me.GB_ACTIVIDADES = New System.Windows.Forms.GroupBox()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.BTN_ELIMINAR = New System.Windows.Forms.Button()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.GRID_ACTIVIDADES = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BTN_SELECCIONAR = New System.Windows.Forms.Button()
        Me.TXT_PIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_CLAVE_ATV = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_USUARIO_ATV = New System.Windows.Forms.TextBox()
        Me.TAB_SMTP = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.LBL_RESULTADO = New System.Windows.Forms.Label()
        Me.BTN_PROBAR = New System.Windows.Forms.Button()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.TXT_PUERTO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXT_CONTRASENA = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXT_USUARIO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXT_SERVIDOR = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.OPD_Llave = New System.Windows.Forms.OpenFileDialog()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.CHK_IMAGEN = New System.Windows.Forms.CheckBox()
        Me.TAB_COMPANIA.SuspendLayout()
        Me.TAB_INFO.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TAB_FE.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GB_ACTIVIDADES.SuspendLayout()
        CType(Me.GRID_ACTIVIDADES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TAB_SMTP.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_CODIGO
        '
        Me.LBL_CODIGO.AutoSize = True
        Me.LBL_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CODIGO.Location = New System.Drawing.Point(32, 13)
        Me.LBL_CODIGO.Name = "LBL_CODIGO"
        Me.LBL_CODIGO.Size = New System.Drawing.Size(64, 18)
        Me.LBL_CODIGO.TabIndex = 0
        Me.LBL_CODIGO.Text = "Código :"
        '
        'LBL_TIPO_CEDULA
        '
        Me.LBL_TIPO_CEDULA.AutoSize = True
        Me.LBL_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TIPO_CEDULA.ForeColor = System.Drawing.Color.Black
        Me.LBL_TIPO_CEDULA.Location = New System.Drawing.Point(4, 76)
        Me.LBL_TIPO_CEDULA.Name = "LBL_TIPO_CEDULA"
        Me.LBL_TIPO_CEDULA.Size = New System.Drawing.Size(92, 18)
        Me.LBL_TIPO_CEDULA.TabIndex = 4
        Me.LBL_TIPO_CEDULA.Text = "Tipo cédula :"
        '
        'CMB_TIPO_CEDULA
        '
        Me.CMB_TIPO_CEDULA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TIPO_CEDULA.FormattingEnabled = True
        Me.CMB_TIPO_CEDULA.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_TIPO_CEDULA.Location = New System.Drawing.Point(99, 72)
        Me.CMB_TIPO_CEDULA.Name = "CMB_TIPO_CEDULA"
        Me.CMB_TIPO_CEDULA.Size = New System.Drawing.Size(194, 24)
        Me.CMB_TIPO_CEDULA.TabIndex = 5
        '
        'LBL_CEDULA
        '
        Me.LBL_CEDULA.AutoSize = True
        Me.LBL_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CEDULA.ForeColor = System.Drawing.Color.Black
        Me.LBL_CEDULA.Location = New System.Drawing.Point(34, 105)
        Me.LBL_CEDULA.Name = "LBL_CEDULA"
        Me.LBL_CEDULA.Size = New System.Drawing.Size(62, 18)
        Me.LBL_CEDULA.TabIndex = 6
        Me.LBL_CEDULA.Text = "Cédula :"
        '
        'TXT_CEDULA
        '
        Me.TXT_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CEDULA.Location = New System.Drawing.Point(100, 103)
        Me.TXT_CEDULA.Name = "TXT_CEDULA"
        Me.TXT_CEDULA.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TXT_CEDULA.Size = New System.Drawing.Size(193, 22)
        Me.TXT_CEDULA.TabIndex = 7
        '
        'LBL_NOMBRE
        '
        Me.LBL_NOMBRE.AutoSize = True
        Me.LBL_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_NOMBRE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NOMBRE.Location = New System.Drawing.Point(26, 44)
        Me.LBL_NOMBRE.Name = "LBL_NOMBRE"
        Me.LBL_NOMBRE.Size = New System.Drawing.Size(70, 18)
        Me.LBL_NOMBRE.TabIndex = 2
        Me.LBL_NOMBRE.Text = "Nombre :"
        '
        'TXT_NOMBRE
        '
        Me.TXT_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_NOMBRE.Location = New System.Drawing.Point(100, 40)
        Me.TXT_NOMBRE.MaxLength = 100
        Me.TXT_NOMBRE.Multiline = True
        Me.TXT_NOMBRE.Name = "TXT_NOMBRE"
        Me.TXT_NOMBRE.Size = New System.Drawing.Size(451, 24)
        Me.TXT_NOMBRE.TabIndex = 3
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Enabled = False
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(99, 10)
        Me.TXT_CODIGO.Multiline = True
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(143, 24)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'LBL_PROVINCIA
        '
        Me.LBL_PROVINCIA.AutoSize = True
        Me.LBL_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PROVINCIA.ForeColor = System.Drawing.Color.Black
        Me.LBL_PROVINCIA.Location = New System.Drawing.Point(19, 198)
        Me.LBL_PROVINCIA.Name = "LBL_PROVINCIA"
        Me.LBL_PROVINCIA.Size = New System.Drawing.Size(77, 18)
        Me.LBL_PROVINCIA.TabIndex = 12
        Me.LBL_PROVINCIA.Text = "Provincia :"
        '
        'CMB_PROVINCIA
        '
        Me.CMB_PROVINCIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_PROVINCIA.FormattingEnabled = True
        Me.CMB_PROVINCIA.Location = New System.Drawing.Point(100, 195)
        Me.CMB_PROVINCIA.Name = "CMB_PROVINCIA"
        Me.CMB_PROVINCIA.Size = New System.Drawing.Size(193, 24)
        Me.CMB_PROVINCIA.TabIndex = 13
        '
        'LBL_CANTO
        '
        Me.LBL_CANTO.AutoSize = True
        Me.LBL_CANTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CANTO.ForeColor = System.Drawing.Color.Black
        Me.LBL_CANTO.Location = New System.Drawing.Point(32, 231)
        Me.LBL_CANTO.Name = "LBL_CANTO"
        Me.LBL_CANTO.Size = New System.Drawing.Size(64, 18)
        Me.LBL_CANTO.TabIndex = 14
        Me.LBL_CANTO.Text = "Cantón :"
        '
        'CMB_CANTON
        '
        Me.CMB_CANTON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CANTON.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CANTON.FormattingEnabled = True
        Me.CMB_CANTON.Location = New System.Drawing.Point(99, 228)
        Me.CMB_CANTON.Name = "CMB_CANTON"
        Me.CMB_CANTON.Size = New System.Drawing.Size(194, 24)
        Me.CMB_CANTON.TabIndex = 15
        '
        'LBL_DISTRITO
        '
        Me.LBL_DISTRITO.AutoSize = True
        Me.LBL_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_DISTRITO.ForeColor = System.Drawing.Color.Black
        Me.LBL_DISTRITO.Location = New System.Drawing.Point(33, 264)
        Me.LBL_DISTRITO.Name = "LBL_DISTRITO"
        Me.LBL_DISTRITO.Size = New System.Drawing.Size(63, 18)
        Me.LBL_DISTRITO.TabIndex = 16
        Me.LBL_DISTRITO.Text = "Distrito :"
        '
        'CMB_DISTRITO
        '
        Me.CMB_DISTRITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_DISTRITO.FormattingEnabled = True
        Me.CMB_DISTRITO.Location = New System.Drawing.Point(99, 261)
        Me.CMB_DISTRITO.Name = "CMB_DISTRITO"
        Me.CMB_DISTRITO.Size = New System.Drawing.Size(194, 24)
        Me.CMB_DISTRITO.TabIndex = 17
        '
        'TAB_COMPANIA
        '
        Me.TAB_COMPANIA.Controls.Add(Me.TAB_INFO)
        Me.TAB_COMPANIA.Controls.Add(Me.TAB_FE)
        Me.TAB_COMPANIA.Controls.Add(Me.TAB_SMTP)
        Me.TAB_COMPANIA.Location = New System.Drawing.Point(3, 3)
        Me.TAB_COMPANIA.Name = "TAB_COMPANIA"
        Me.TAB_COMPANIA.SelectedIndex = 0
        Me.TAB_COMPANIA.Size = New System.Drawing.Size(565, 423)
        Me.TAB_COMPANIA.TabIndex = 0
        '
        'TAB_INFO
        '
        Me.TAB_INFO.Controls.Add(Me.CHK_IMAGEN)
        Me.TAB_INFO.Controls.Add(Me.GroupBox5)
        Me.TAB_INFO.Controls.Add(Me.CHK_ENCOMIENDA)
        Me.TAB_INFO.Controls.Add(Me.TXT_DIRECCION)
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
        Me.TAB_INFO.Size = New System.Drawing.Size(557, 397)
        Me.TAB_INFO.TabIndex = 0
        Me.TAB_INFO.Text = "Información general"
        Me.TAB_INFO.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.PictureBox1)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(298, 69)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(253, 275)
        Me.GroupBox5.TabIndex = 21
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "[ Imagen ]"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(4, 23)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(245, 206)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(4, 238)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(245, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Seleccionar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CHK_ENCOMIENDA
        '
        Me.CHK_ENCOMIENDA.AutoSize = True
        Me.CHK_ENCOMIENDA.Enabled = False
        Me.CHK_ENCOMIENDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ENCOMIENDA.Location = New System.Drawing.Point(99, 317)
        Me.CHK_ENCOMIENDA.Name = "CHK_ENCOMIENDA"
        Me.CHK_ENCOMIENDA.Size = New System.Drawing.Size(162, 20)
        Me.CHK_ENCOMIENDA.TabIndex = 20
        Me.CHK_ENCOMIENDA.Text = "¿Utiliza encomiendas?"
        Me.CHK_ENCOMIENDA.UseVisualStyleBackColor = True
        '
        'TXT_DIRECCION
        '
        Me.TXT_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DIRECCION.Location = New System.Drawing.Point(99, 164)
        Me.TXT_DIRECCION.MaxLength = 255
        Me.TXT_DIRECCION.Multiline = True
        Me.TXT_DIRECCION.Name = "TXT_DIRECCION"
        Me.TXT_DIRECCION.Size = New System.Drawing.Size(194, 24)
        Me.TXT_DIRECCION.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Dirección:"
        '
        'CHK_FE
        '
        Me.CHK_FE.AutoSize = True
        Me.CHK_FE.Enabled = False
        Me.CHK_FE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_FE.Location = New System.Drawing.Point(99, 294)
        Me.CHK_FE.Name = "CHK_FE"
        Me.CHK_FE.Size = New System.Drawing.Size(194, 20)
        Me.CHK_FE.TabIndex = 18
        Me.CHK_FE.Text = "¿Es facturación electrónica?"
        Me.CHK_FE.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_INACTIVA)
        Me.GroupBox1.Controls.Add(Me.RB_ACTIVA)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox1.Location = New System.Drawing.Point(298, 346)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 48)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado"
        '
        'RB_INACTIVA
        '
        Me.RB_INACTIVA.AutoSize = True
        Me.RB_INACTIVA.Location = New System.Drawing.Point(92, 19)
        Me.RB_INACTIVA.Name = "RB_INACTIVA"
        Me.RB_INACTIVA.Size = New System.Drawing.Size(72, 20)
        Me.RB_INACTIVA.TabIndex = 1
        Me.RB_INACTIVA.TabStop = True
        Me.RB_INACTIVA.Text = "Inactiva"
        Me.RB_INACTIVA.UseVisualStyleBackColor = True
        '
        'RB_ACTIVA
        '
        Me.RB_ACTIVA.AutoSize = True
        Me.RB_ACTIVA.Checked = True
        Me.RB_ACTIVA.Location = New System.Drawing.Point(16, 19)
        Me.RB_ACTIVA.Name = "RB_ACTIVA"
        Me.RB_ACTIVA.Size = New System.Drawing.Size(63, 20)
        Me.RB_ACTIVA.TabIndex = 0
        Me.RB_ACTIVA.TabStop = True
        Me.RB_ACTIVA.Text = "Activa"
        Me.RB_ACTIVA.UseVisualStyleBackColor = True
        '
        'TXT_EMAIL
        '
        Me.TXT_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_EMAIL.Location = New System.Drawing.Point(100, 133)
        Me.TXT_EMAIL.MaxLength = 150
        Me.TXT_EMAIL.Multiline = True
        Me.TXT_EMAIL.Name = "TXT_EMAIL"
        Me.TXT_EMAIL.Size = New System.Drawing.Size(193, 24)
        Me.TXT_EMAIL.TabIndex = 9
        '
        'LBL_EMAIL
        '
        Me.LBL_EMAIL.AutoSize = True
        Me.LBL_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_EMAIL.ForeColor = System.Drawing.Color.Black
        Me.LBL_EMAIL.Location = New System.Drawing.Point(43, 137)
        Me.LBL_EMAIL.Name = "LBL_EMAIL"
        Me.LBL_EMAIL.Size = New System.Drawing.Size(53, 18)
        Me.LBL_EMAIL.TabIndex = 8
        Me.LBL_EMAIL.Text = "Email :"
        '
        'TAB_FE
        '
        Me.TAB_FE.Controls.Add(Me.Label6)
        Me.TAB_FE.Controls.Add(Me.Label3)
        Me.TAB_FE.Controls.Add(Me.GroupBox4)
        Me.TAB_FE.Controls.Add(Me.LINK_CONSULTAS)
        Me.TAB_FE.Controls.Add(Me.LINK_FT)
        Me.TAB_FE.Controls.Add(Me.GB_ACTIVIDADES)
        Me.TAB_FE.Controls.Add(Me.GroupBox3)
        Me.TAB_FE.Controls.Add(Me.GroupBox2)
        Me.TAB_FE.Location = New System.Drawing.Point(4, 22)
        Me.TAB_FE.Name = "TAB_FE"
        Me.TAB_FE.Padding = New System.Windows.Forms.Padding(3)
        Me.TAB_FE.Size = New System.Drawing.Size(557, 397)
        Me.TAB_FE.TabIndex = 1
        Me.TAB_FE.Text = "Facturación Electrónica"
        Me.TAB_FE.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(101, 306)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 18)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Link envio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(101, 350)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Link consultas:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RB_PRUEBAS)
        Me.GroupBox4.Controls.Add(Me.RB_REAL)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Green
        Me.GroupBox4.Location = New System.Drawing.Point(6, 305)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(92, 89)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "[Tipo tributario]"
        '
        'RB_PRUEBAS
        '
        Me.RB_PRUEBAS.AutoSize = True
        Me.RB_PRUEBAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.RB_PRUEBAS.ForeColor = System.Drawing.Color.Black
        Me.RB_PRUEBAS.Location = New System.Drawing.Point(6, 59)
        Me.RB_PRUEBAS.Name = "RB_PRUEBAS"
        Me.RB_PRUEBAS.Size = New System.Drawing.Size(81, 22)
        Me.RB_PRUEBAS.TabIndex = 1
        Me.RB_PRUEBAS.TabStop = True
        Me.RB_PRUEBAS.Text = "Pruebas"
        Me.RB_PRUEBAS.UseVisualStyleBackColor = True
        '
        'RB_REAL
        '
        Me.RB_REAL.AutoSize = True
        Me.RB_REAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.RB_REAL.ForeColor = System.Drawing.Color.Black
        Me.RB_REAL.Location = New System.Drawing.Point(6, 22)
        Me.RB_REAL.Name = "RB_REAL"
        Me.RB_REAL.Size = New System.Drawing.Size(56, 22)
        Me.RB_REAL.TabIndex = 0
        Me.RB_REAL.TabStop = True
        Me.RB_REAL.Text = "Real"
        Me.RB_REAL.UseVisualStyleBackColor = True
        '
        'LINK_CONSULTAS
        '
        Me.LINK_CONSULTAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LINK_CONSULTAS.Location = New System.Drawing.Point(104, 370)
        Me.LINK_CONSULTAS.MaxLength = 100
        Me.LINK_CONSULTAS.Name = "LINK_CONSULTAS"
        Me.LINK_CONSULTAS.ReadOnly = True
        Me.LINK_CONSULTAS.Size = New System.Drawing.Size(446, 22)
        Me.LINK_CONSULTAS.TabIndex = 8
        '
        'LINK_FT
        '
        Me.LINK_FT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LINK_FT.Location = New System.Drawing.Point(104, 325)
        Me.LINK_FT.MaxLength = 100
        Me.LINK_FT.Name = "LINK_FT"
        Me.LINK_FT.ReadOnly = True
        Me.LINK_FT.Size = New System.Drawing.Size(446, 22)
        Me.LINK_FT.TabIndex = 7
        '
        'GB_ACTIVIDADES
        '
        Me.GB_ACTIVIDADES.Controls.Add(Me.BTN_MODIFICAR)
        Me.GB_ACTIVIDADES.Controls.Add(Me.BTN_ELIMINAR)
        Me.GB_ACTIVIDADES.Controls.Add(Me.BTN_AGREGAR)
        Me.GB_ACTIVIDADES.Controls.Add(Me.GRID_ACTIVIDADES)
        Me.GB_ACTIVIDADES.Location = New System.Drawing.Point(6, 128)
        Me.GB_ACTIVIDADES.Name = "GB_ACTIVIDADES"
        Me.GB_ACTIVIDADES.Size = New System.Drawing.Size(544, 173)
        Me.GB_ACTIVIDADES.TabIndex = 6
        Me.GB_ACTIVIDADES.TabStop = False
        Me.GB_ACTIVIDADES.Text = "Activiades económicas"
        '
        'BTN_MODIFICAR
        '
        Me.BTN_MODIFICAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_MODIFICAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MODIFICAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_MODIFICAR.Image = Global.VentaRepuestos.My.Resources.Resources.controles
        Me.BTN_MODIFICAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(405, 72)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_MODIFICAR.TabIndex = 25
        Me.BTN_MODIFICAR.Text = "Modificar"
        Me.BTN_MODIFICAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_MODIFICAR.UseVisualStyleBackColor = False
        '
        'BTN_ELIMINAR
        '
        Me.BTN_ELIMINAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ELIMINAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_ELIMINAR.Image = Global.VentaRepuestos.My.Resources.Resources.delete
        Me.BTN_ELIMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ELIMINAR.Location = New System.Drawing.Point(405, 124)
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
        'GRID_ACTIVIDADES
        '
        Me.GRID_ACTIVIDADES.AllowUserToAddRows = False
        Me.GRID_ACTIVIDADES.AllowUserToDeleteRows = False
        Me.GRID_ACTIVIDADES.AllowUserToOrderColumns = True
        Me.GRID_ACTIVIDADES.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID_ACTIVIDADES.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID_ACTIVIDADES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID_ACTIVIDADES.Location = New System.Drawing.Point(3, 19)
        Me.GRID_ACTIVIDADES.MultiSelect = False
        Me.GRID_ACTIVIDADES.Name = "GRID_ACTIVIDADES"
        Me.GRID_ACTIVIDADES.ReadOnly = True
        Me.GRID_ACTIVIDADES.RowHeadersVisible = False
        Me.GRID_ACTIVIDADES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID_ACTIVIDADES.Size = New System.Drawing.Size(396, 148)
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
        Me.GroupBox3.Size = New System.Drawing.Size(271, 118)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[Llave criptográfica]"
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
        'TXT_PIN
        '
        Me.TXT_PIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_PIN.Location = New System.Drawing.Point(7, 84)
        Me.TXT_PIN.Name = "TXT_PIN"
        Me.TXT_PIN.Size = New System.Drawing.Size(255, 22)
        Me.TXT_PIN.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(7, 64)
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
        Me.GroupBox2.Size = New System.Drawing.Size(267, 121)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ATV]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Clave :"
        '
        'TXT_CLAVE_ATV
        '
        Me.TXT_CLAVE_ATV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_CLAVE_ATV.Location = New System.Drawing.Point(4, 87)
        Me.TXT_CLAVE_ATV.Name = "TXT_CLAVE_ATV"
        Me.TXT_CLAVE_ATV.Size = New System.Drawing.Size(255, 22)
        Me.TXT_CLAVE_ATV.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Usuario :"
        '
        'TXT_USUARIO_ATV
        '
        Me.TXT_USUARIO_ATV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_USUARIO_ATV.Location = New System.Drawing.Point(3, 38)
        Me.TXT_USUARIO_ATV.Name = "TXT_USUARIO_ATV"
        Me.TXT_USUARIO_ATV.Size = New System.Drawing.Size(255, 22)
        Me.TXT_USUARIO_ATV.TabIndex = 0
        '
        'TAB_SMTP
        '
        Me.TAB_SMTP.Controls.Add(Me.GroupBox6)
        Me.TAB_SMTP.Location = New System.Drawing.Point(4, 22)
        Me.TAB_SMTP.Name = "TAB_SMTP"
        Me.TAB_SMTP.Size = New System.Drawing.Size(557, 397)
        Me.TAB_SMTP.TabIndex = 2
        Me.TAB_SMTP.Text = "Servidores"
        Me.TAB_SMTP.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.GroupBox7)
        Me.GroupBox6.Controls.Add(Me.BTN_PROBAR)
        Me.GroupBox6.Controls.Add(Me.lbl_mensaje)
        Me.GroupBox6.Controls.Add(Me.TXT_PUERTO)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.TXT_CONTRASENA)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.TXT_USUARIO)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.TXT_SERVIDOR)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(545, 179)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "[ SMTP ]"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.LBL_RESULTADO)
        Me.GroupBox7.Location = New System.Drawing.Point(299, 13)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(240, 112)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "[ Resultado ]"
        '
        'LBL_RESULTADO
        '
        Me.LBL_RESULTADO.Location = New System.Drawing.Point(6, 16)
        Me.LBL_RESULTADO.Name = "LBL_RESULTADO"
        Me.LBL_RESULTADO.Size = New System.Drawing.Size(228, 93)
        Me.LBL_RESULTADO.TabIndex = 0
        '
        'BTN_PROBAR
        '
        Me.BTN_PROBAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_PROBAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_PROBAR.Image = CType(resources.GetObject("BTN_PROBAR.Image"), System.Drawing.Image)
        Me.BTN_PROBAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_PROBAR.Location = New System.Drawing.Point(440, 131)
        Me.BTN_PROBAR.Name = "BTN_PROBAR"
        Me.BTN_PROBAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_PROBAR.TabIndex = 9
        Me.BTN_PROBAR.Text = "Probar"
        Me.BTN_PROBAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_PROBAR.UseVisualStyleBackColor = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.AutoSize = True
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.ForeColor = System.Drawing.Color.Navy
        Me.lbl_mensaje.Location = New System.Drawing.Point(6, 131)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(354, 39)
        Me.lbl_mensaje.TabIndex = 8
        Me.lbl_mensaje.Text = "[ Nota importante: Esta configuración se utiliza para todo lo relacionado a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "env" &
    "íos electrónicamente, en caso no de existir ninguna configuración, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "estos proce" &
    "sos no se llevarán acabo. ]"
        '
        'TXT_PUERTO
        '
        Me.TXT_PUERTO.Location = New System.Drawing.Point(74, 96)
        Me.TXT_PUERTO.MaxLength = 4
        Me.TXT_PUERTO.Name = "TXT_PUERTO"
        Me.TXT_PUERTO.Size = New System.Drawing.Size(46, 20)
        Me.TXT_PUERTO.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Puerto :"
        '
        'TXT_CONTRASENA
        '
        Me.TXT_CONTRASENA.Location = New System.Drawing.Point(74, 70)
        Me.TXT_CONTRASENA.MaxLength = 100
        Me.TXT_CONTRASENA.Name = "TXT_CONTRASENA"
        Me.TXT_CONTRASENA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_CONTRASENA.Size = New System.Drawing.Size(219, 20)
        Me.TXT_CONTRASENA.TabIndex = 5
        Me.TXT_CONTRASENA.UseSystemPasswordChar = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Contraseña :"
        '
        'TXT_USUARIO
        '
        Me.TXT_USUARIO.Location = New System.Drawing.Point(74, 44)
        Me.TXT_USUARIO.MaxLength = 100
        Me.TXT_USUARIO.Name = "TXT_USUARIO"
        Me.TXT_USUARIO.Size = New System.Drawing.Size(219, 20)
        Me.TXT_USUARIO.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Usuario :"
        '
        'TXT_SERVIDOR
        '
        Me.TXT_SERVIDOR.Location = New System.Drawing.Point(74, 18)
        Me.TXT_SERVIDOR.MaxLength = 100
        Me.TXT_SERVIDOR.Name = "TXT_SERVIDOR"
        Me.TXT_SERVIDOR.Size = New System.Drawing.Size(219, 20)
        Me.TXT_SERVIDOR.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Servidor :"
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
        Me.BTN_SALIR.Location = New System.Drawing.Point(469, 432)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 2
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(370, 432)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 1
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'CHK_IMAGEN
        '
        Me.CHK_IMAGEN.AutoSize = True
        Me.CHK_IMAGEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_IMAGEN.Location = New System.Drawing.Point(99, 343)
        Me.CHK_IMAGEN.Name = "CHK_IMAGEN"
        Me.CHK_IMAGEN.Size = New System.Drawing.Size(190, 20)
        Me.CHK_IMAGEN.TabIndex = 22
        Me.CHK_IMAGEN.Text = "Imprimir imagen en tiquetes"
        Me.CHK_IMAGEN.UseVisualStyleBackColor = True
        '
        'LBL_CANTON
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(569, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.TAB_COMPANIA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LBL_CANTON"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compania"
        Me.TAB_COMPANIA.ResumeLayout(False)
        Me.TAB_INFO.ResumeLayout(False)
        Me.TAB_INFO.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TAB_FE.ResumeLayout(False)
        Me.TAB_FE.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GB_ACTIVIDADES.ResumeLayout(False)
        CType(Me.GRID_ACTIVIDADES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TAB_SMTP.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
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
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_CLAVE_ATV As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXT_PIN As TextBox
    Friend WithEvents OPD_Llave As OpenFileDialog
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_SELECCIONAR As Button
    Friend WithEvents GB_ACTIVIDADES As GroupBox
    Friend WithEvents GRID_ACTIVIDADES As DataGridView
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents BTN_ELIMINAR As Button
    Friend WithEvents BTN_MODIFICAR As Button
    Friend WithEvents TXT_DIRECCION As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LINK_CONSULTAS As TextBox
    Friend WithEvents LINK_FT As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents RB_PRUEBAS As RadioButton
    Friend WithEvents RB_REAL As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CHK_ENCOMIENDA As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TAB_SMTP As TabPage
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXT_SERVIDOR As TextBox
    Friend WithEvents TXT_USUARIO As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXT_CONTRASENA As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXT_PUERTO As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents lbl_mensaje As Label
    Friend WithEvents BTN_PROBAR As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents LBL_RESULTADO As Label
    Friend WithEvents CHK_IMAGEN As CheckBox
End Class
