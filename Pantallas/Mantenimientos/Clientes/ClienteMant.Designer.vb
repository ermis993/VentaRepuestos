﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClienteMant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClienteMant))
        Me.LBL_CODIGO = New System.Windows.Forms.Label()
        Me.LBL_TIPO_CEDULA = New System.Windows.Forms.Label()
        Me.CMB_TIPO_CEDULA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_NOMBRE = New System.Windows.Forms.TextBox()
        Me.TXT_PRIMER_APELLIDO = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_DISTRITO = New System.Windows.Forms.ComboBox()
        Me.LBL_DISTRITO = New System.Windows.Forms.Label()
        Me.CMB_CANTON = New System.Windows.Forms.ComboBox()
        Me.LBL_CANTO = New System.Windows.Forms.Label()
        Me.CMB_PROVINCIA = New System.Windows.Forms.ComboBox()
        Me.LBL_PROVINCIA = New System.Windows.Forms.Label()
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.TXT_CEDULA = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CMB_MONEDA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVO = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVO = New System.Windows.Forms.RadioButton()
        Me.CK_TIQUETE = New System.Windows.Forms.CheckBox()
        Me.TXT_SALDO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT_EMAIL = New System.Windows.Forms.TextBox()
        Me.TXT_TELEFONO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXT_DIRECCION = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXT_SEGUNDO_APELLIDO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BTN_ACEPTAR_EXO = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RB_EXO_INACTIVO = New System.Windows.Forms.RadioButton()
        Me.RB_EXO_ACTIVO = New System.Windows.Forms.RadioButton()
        Me.TXT_PORCENTAJE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DTPFECHA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXT_NOMRE_INSTITUCION = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXT_EXO_NUMERO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMB_TIPO = New System.Windows.Forms.ComboBox()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.CMB_PRECIO = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_CODIGO
        '
        Me.LBL_CODIGO.AutoSize = True
        Me.LBL_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CODIGO.Location = New System.Drawing.Point(72, 39)
        Me.LBL_CODIGO.Name = "LBL_CODIGO"
        Me.LBL_CODIGO.Size = New System.Drawing.Size(62, 18)
        Me.LBL_CODIGO.TabIndex = 2
        Me.LBL_CODIGO.Text = "Cédula :"
        '
        'LBL_TIPO_CEDULA
        '
        Me.LBL_TIPO_CEDULA.AutoSize = True
        Me.LBL_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TIPO_CEDULA.ForeColor = System.Drawing.Color.Black
        Me.LBL_TIPO_CEDULA.Location = New System.Drawing.Point(41, 13)
        Me.LBL_TIPO_CEDULA.Name = "LBL_TIPO_CEDULA"
        Me.LBL_TIPO_CEDULA.Size = New System.Drawing.Size(92, 18)
        Me.LBL_TIPO_CEDULA.TabIndex = 0
        Me.LBL_TIPO_CEDULA.Text = "Tipo cédula :"
        '
        'CMB_TIPO_CEDULA
        '
        Me.CMB_TIPO_CEDULA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TIPO_CEDULA.FormattingEnabled = True
        Me.CMB_TIPO_CEDULA.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_TIPO_CEDULA.Location = New System.Drawing.Point(136, 10)
        Me.CMB_TIPO_CEDULA.Name = "CMB_TIPO_CEDULA"
        Me.CMB_TIPO_CEDULA.Size = New System.Drawing.Size(201, 24)
        Me.CMB_TIPO_CEDULA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 18)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Segundo apellido :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Primer apellido : "
        '
        'TXT_NOMBRE
        '
        Me.TXT_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_NOMBRE.Location = New System.Drawing.Point(136, 63)
        Me.TXT_NOMBRE.MaxLength = 250
        Me.TXT_NOMBRE.Multiline = True
        Me.TXT_NOMBRE.Name = "TXT_NOMBRE"
        Me.TXT_NOMBRE.Size = New System.Drawing.Size(297, 24)
        Me.TXT_NOMBRE.TabIndex = 6
        '
        'TXT_PRIMER_APELLIDO
        '
        Me.TXT_PRIMER_APELLIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_PRIMER_APELLIDO.Location = New System.Drawing.Point(136, 91)
        Me.TXT_PRIMER_APELLIDO.Multiline = True
        Me.TXT_PRIMER_APELLIDO.Name = "TXT_PRIMER_APELLIDO"
        Me.TXT_PRIMER_APELLIDO.Size = New System.Drawing.Size(297, 24)
        Me.TXT_PRIMER_APELLIDO.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_PRECIO)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.CMB_DISTRITO)
        Me.GroupBox1.Controls.Add(Me.LBL_DISTRITO)
        Me.GroupBox1.Controls.Add(Me.CMB_CANTON)
        Me.GroupBox1.Controls.Add(Me.LBL_CANTO)
        Me.GroupBox1.Controls.Add(Me.CMB_PROVINCIA)
        Me.GroupBox1.Controls.Add(Me.LBL_PROVINCIA)
        Me.GroupBox1.Controls.Add(Me.BTN_BUSCAR)
        Me.GroupBox1.Controls.Add(Me.TXT_CEDULA)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TXT_EMAIL)
        Me.GroupBox1.Controls.Add(Me.TXT_TELEFONO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TXT_DIRECCION)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXT_SEGUNDO_APELLIDO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXT_PRIMER_APELLIDO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TXT_NOMBRE)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CMB_TIPO_CEDULA)
        Me.GroupBox1.Controls.Add(Me.LBL_TIPO_CEDULA)
        Me.GroupBox1.Controls.Add(Me.LBL_CODIGO)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 484)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CMB_DISTRITO
        '
        Me.CMB_DISTRITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_DISTRITO.FormattingEnabled = True
        Me.CMB_DISTRITO.Location = New System.Drawing.Point(136, 286)
        Me.CMB_DISTRITO.Name = "CMB_DISTRITO"
        Me.CMB_DISTRITO.Size = New System.Drawing.Size(262, 24)
        Me.CMB_DISTRITO.TabIndex = 23
        '
        'LBL_DISTRITO
        '
        Me.LBL_DISTRITO.AutoSize = True
        Me.LBL_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_DISTRITO.ForeColor = System.Drawing.Color.Black
        Me.LBL_DISTRITO.Location = New System.Drawing.Point(70, 290)
        Me.LBL_DISTRITO.Name = "LBL_DISTRITO"
        Me.LBL_DISTRITO.Size = New System.Drawing.Size(63, 18)
        Me.LBL_DISTRITO.TabIndex = 22
        Me.LBL_DISTRITO.Text = "Distrito :"
        '
        'CMB_CANTON
        '
        Me.CMB_CANTON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CANTON.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CANTON.FormattingEnabled = True
        Me.CMB_CANTON.Location = New System.Drawing.Point(136, 260)
        Me.CMB_CANTON.Name = "CMB_CANTON"
        Me.CMB_CANTON.Size = New System.Drawing.Size(262, 24)
        Me.CMB_CANTON.TabIndex = 21
        '
        'LBL_CANTO
        '
        Me.LBL_CANTO.AutoSize = True
        Me.LBL_CANTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CANTO.ForeColor = System.Drawing.Color.Black
        Me.LBL_CANTO.Location = New System.Drawing.Point(69, 263)
        Me.LBL_CANTO.Name = "LBL_CANTO"
        Me.LBL_CANTO.Size = New System.Drawing.Size(64, 18)
        Me.LBL_CANTO.TabIndex = 20
        Me.LBL_CANTO.Text = "Cantón :"
        '
        'CMB_PROVINCIA
        '
        Me.CMB_PROVINCIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_PROVINCIA.FormattingEnabled = True
        Me.CMB_PROVINCIA.Location = New System.Drawing.Point(136, 234)
        Me.CMB_PROVINCIA.Name = "CMB_PROVINCIA"
        Me.CMB_PROVINCIA.Size = New System.Drawing.Size(262, 24)
        Me.CMB_PROVINCIA.TabIndex = 19
        '
        'LBL_PROVINCIA
        '
        Me.LBL_PROVINCIA.AutoSize = True
        Me.LBL_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PROVINCIA.ForeColor = System.Drawing.Color.Black
        Me.LBL_PROVINCIA.Location = New System.Drawing.Point(56, 237)
        Me.LBL_PROVINCIA.Name = "LBL_PROVINCIA"
        Me.LBL_PROVINCIA.Size = New System.Drawing.Size(77, 18)
        Me.LBL_PROVINCIA.TabIndex = 18
        Me.LBL_PROVINCIA.Text = "Provincia :"
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.BackgroundImage = Global.VentaRepuestos.My.Resources.Resources.consultas
        Me.BTN_BUSCAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(343, 37)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(28, 22)
        Me.BTN_BUSCAR.TabIndex = 4
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'TXT_CEDULA
        '
        Me.TXT_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CEDULA.Location = New System.Drawing.Point(136, 37)
        Me.TXT_CEDULA.Name = "TXT_CEDULA"
        Me.TXT_CEDULA.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TXT_CEDULA.Size = New System.Drawing.Size(201, 22)
        Me.TXT_CEDULA.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CMB_MONEDA)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.CK_TIQUETE)
        Me.GroupBox2.Controls.Add(Me.TXT_SALDO)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 380)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(425, 100)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[Extra]"
        '
        'CMB_MONEDA
        '
        Me.CMB_MONEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_MONEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_MONEDA.FormattingEnabled = True
        Me.CMB_MONEDA.Location = New System.Drawing.Point(82, 49)
        Me.CMB_MONEDA.Name = "CMB_MONEDA"
        Me.CMB_MONEDA.Size = New System.Drawing.Size(135, 24)
        Me.CMB_MONEDA.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 18)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Moneda :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RB_INACTIVO)
        Me.GroupBox3.Controls.Add(Me.RB_ACTIVO)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(291, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(99, 83)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estado"
        '
        'RB_INACTIVO
        '
        Me.RB_INACTIVO.AutoSize = True
        Me.RB_INACTIVO.Location = New System.Drawing.Point(7, 54)
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
        Me.RB_ACTIVO.Location = New System.Drawing.Point(7, 20)
        Me.RB_ACTIVO.Name = "RB_ACTIVO"
        Me.RB_ACTIVO.Size = New System.Drawing.Size(63, 20)
        Me.RB_ACTIVO.TabIndex = 0
        Me.RB_ACTIVO.TabStop = True
        Me.RB_ACTIVO.Text = "Activo"
        Me.RB_ACTIVO.UseVisualStyleBackColor = True
        '
        'CK_TIQUETE
        '
        Me.CK_TIQUETE.AutoSize = True
        Me.CK_TIQUETE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CK_TIQUETE.Location = New System.Drawing.Point(28, 79)
        Me.CK_TIQUETE.Name = "CK_TIQUETE"
        Me.CK_TIQUETE.Size = New System.Drawing.Size(189, 20)
        Me.CK_TIQUETE.TabIndex = 2
        Me.CK_TIQUETE.Text = "¿Utiliza tiquete electrónico?"
        Me.CK_TIQUETE.UseVisualStyleBackColor = True
        '
        'TXT_SALDO
        '
        Me.TXT_SALDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SALDO.Location = New System.Drawing.Point(82, 19)
        Me.TXT_SALDO.Multiline = True
        Me.TXT_SALDO.Name = "TXT_SALDO"
        Me.TXT_SALDO.Size = New System.Drawing.Size(135, 24)
        Me.TXT_SALDO.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Saldo :"
        '
        'TXT_EMAIL
        '
        Me.TXT_EMAIL.BackColor = System.Drawing.SystemColors.Window
        Me.TXT_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_EMAIL.Location = New System.Drawing.Point(136, 204)
        Me.TXT_EMAIL.MaxLength = 300
        Me.TXT_EMAIL.Multiline = True
        Me.TXT_EMAIL.Name = "TXT_EMAIL"
        Me.TXT_EMAIL.Size = New System.Drawing.Size(297, 24)
        Me.TXT_EMAIL.TabIndex = 16
        '
        'TXT_TELEFONO
        '
        Me.TXT_TELEFONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_TELEFONO.Location = New System.Drawing.Point(136, 147)
        Me.TXT_TELEFONO.MaxLength = 8
        Me.TXT_TELEFONO.Multiline = True
        Me.TXT_TELEFONO.Name = "TXT_TELEFONO"
        Me.TXT_TELEFONO.Size = New System.Drawing.Size(130, 24)
        Me.TXT_TELEFONO.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(81, 207)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 18)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Email :"
        '
        'TXT_DIRECCION
        '
        Me.TXT_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DIRECCION.Location = New System.Drawing.Point(136, 175)
        Me.TXT_DIRECCION.Multiline = True
        Me.TXT_DIRECCION.Name = "TXT_DIRECCION"
        Me.TXT_DIRECCION.Size = New System.Drawing.Size(297, 24)
        Me.TXT_DIRECCION.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(59, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 18)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Teléfono :"
        '
        'TXT_SEGUNDO_APELLIDO
        '
        Me.TXT_SEGUNDO_APELLIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SEGUNDO_APELLIDO.Location = New System.Drawing.Point(136, 119)
        Me.TXT_SEGUNDO_APELLIDO.Multiline = True
        Me.TXT_SEGUNDO_APELLIDO.Name = "TXT_SEGUNDO_APELLIDO"
        Me.TXT_SEGUNDO_APELLIDO.Size = New System.Drawing.Size(297, 24)
        Me.TXT_SEGUNDO_APELLIDO.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 18)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Dirección :"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(481, 519)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(473, 493)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información general "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(473, 493)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Exoneración"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.GRID)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 240)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(460, 247)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Exoneraciones ingresadas"
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AllowUserToResizeColumns = False
        Me.GRID.AllowUserToResizeRows = False
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(5, 18)
        Me.GRID.Margin = New System.Windows.Forms.Padding(2)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.RowTemplate.Height = 24
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(450, 224)
        Me.GRID.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BTN_ACEPTAR_EXO)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.TXT_PORCENTAJE)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.DTPFECHA)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.TXT_NOMRE_INSTITUCION)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.TXT_EXO_NUMERO)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.CMB_TIPO)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 17)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(460, 217)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Información"
        '
        'BTN_ACEPTAR_EXO
        '
        Me.BTN_ACEPTAR_EXO.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR_EXO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR_EXO.Image = CType(resources.GetObject("BTN_ACEPTAR_EXO.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR_EXO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR_EXO.Location = New System.Drawing.Point(355, 166)
        Me.BTN_ACEPTAR_EXO.Name = "BTN_ACEPTAR_EXO"
        Me.BTN_ACEPTAR_EXO.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR_EXO.TabIndex = 11
        Me.BTN_ACEPTAR_EXO.Text = "Aplicar"
        Me.BTN_ACEPTAR_EXO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR_EXO.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RB_EXO_INACTIVO)
        Me.GroupBox5.Controls.Add(Me.RB_EXO_ACTIVO)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(274, 107)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(180, 53)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Estado"
        '
        'RB_EXO_INACTIVO
        '
        Me.RB_EXO_INACTIVO.AutoSize = True
        Me.RB_EXO_INACTIVO.Location = New System.Drawing.Point(76, 21)
        Me.RB_EXO_INACTIVO.Name = "RB_EXO_INACTIVO"
        Me.RB_EXO_INACTIVO.Size = New System.Drawing.Size(72, 20)
        Me.RB_EXO_INACTIVO.TabIndex = 1
        Me.RB_EXO_INACTIVO.TabStop = True
        Me.RB_EXO_INACTIVO.Text = "Inactivo"
        Me.RB_EXO_INACTIVO.UseVisualStyleBackColor = True
        '
        'RB_EXO_ACTIVO
        '
        Me.RB_EXO_ACTIVO.AutoSize = True
        Me.RB_EXO_ACTIVO.Checked = True
        Me.RB_EXO_ACTIVO.Location = New System.Drawing.Point(7, 20)
        Me.RB_EXO_ACTIVO.Name = "RB_EXO_ACTIVO"
        Me.RB_EXO_ACTIVO.Size = New System.Drawing.Size(63, 20)
        Me.RB_EXO_ACTIVO.TabIndex = 0
        Me.RB_EXO_ACTIVO.TabStop = True
        Me.RB_EXO_ACTIVO.Text = "Activo"
        Me.RB_EXO_ACTIVO.UseVisualStyleBackColor = True
        '
        'TXT_PORCENTAJE
        '
        Me.TXT_PORCENTAJE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_PORCENTAJE.Location = New System.Drawing.Point(113, 135)
        Me.TXT_PORCENTAJE.MaxLength = 2
        Me.TXT_PORCENTAJE.Multiline = True
        Me.TXT_PORCENTAJE.Name = "TXT_PORCENTAJE"
        Me.TXT_PORCENTAJE.Size = New System.Drawing.Size(98, 24)
        Me.TXT_PORCENTAJE.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(25, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 18)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Porcentaje :"
        '
        'DTPFECHA
        '
        Me.DTPFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.DTPFECHA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFECHA.Location = New System.Drawing.Point(113, 107)
        Me.DTPFECHA.Name = "DTPFECHA"
        Me.DTPFECHA.Size = New System.Drawing.Size(156, 22)
        Me.DTPFECHA.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(55, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 18)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Fecha :"
        '
        'TXT_NOMRE_INSTITUCION
        '
        Me.TXT_NOMRE_INSTITUCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_NOMRE_INSTITUCION.Location = New System.Drawing.Point(113, 77)
        Me.TXT_NOMRE_INSTITUCION.Multiline = True
        Me.TXT_NOMRE_INSTITUCION.Name = "TXT_NOMRE_INSTITUCION"
        Me.TXT_NOMRE_INSTITUCION.Size = New System.Drawing.Size(341, 24)
        Me.TXT_NOMRE_INSTITUCION.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(42, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 18)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Nombre :"
        '
        'TXT_EXO_NUMERO
        '
        Me.TXT_EXO_NUMERO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_EXO_NUMERO.Location = New System.Drawing.Point(113, 47)
        Me.TXT_EXO_NUMERO.Multiline = True
        Me.TXT_EXO_NUMERO.Name = "TXT_EXO_NUMERO"
        Me.TXT_EXO_NUMERO.Size = New System.Drawing.Size(341, 24)
        Me.TXT_EXO_NUMERO.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 18)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Documento # :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(67, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Tipo :"
        '
        'CMB_TIPO
        '
        Me.CMB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TIPO.FormattingEnabled = True
        Me.CMB_TIPO.Items.AddRange(New Object() {"01 -Compras autorizadas ", "04 -Exenciones Dirección General de Hacienda"})
        Me.CMB_TIPO.Location = New System.Drawing.Point(113, 15)
        Me.CMB_TIPO.Name = "CMB_TIPO"
        Me.CMB_TIPO.Size = New System.Drawing.Size(341, 24)
        Me.CMB_TIPO.TabIndex = 1
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(383, 528)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 0
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(284, 528)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 2
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'CMB_PRECIO
        '
        Me.CMB_PRECIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_PRECIO.FormattingEnabled = True
        Me.CMB_PRECIO.Items.AddRange(New Object() {"Precio 1 ", "Precio 2", "Precio 3"})
        Me.CMB_PRECIO.Location = New System.Drawing.Point(136, 327)
        Me.CMB_PRECIO.Name = "CMB_PRECIO"
        Me.CMB_PRECIO.Size = New System.Drawing.Size(262, 24)
        Me.CMB_PRECIO.TabIndex = 25
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(31, 330)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 18)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Precio cobro :"
        '
        'ClienteMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 575)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ClienteMant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBL_CODIGO As Label
    Friend WithEvents LBL_TIPO_CEDULA As Label
    Friend WithEvents CMB_TIPO_CEDULA As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_NOMBRE As TextBox
    Friend WithEvents TXT_PRIMER_APELLIDO As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TXT_SEGUNDO_APELLIDO As TextBox
    Friend WithEvents TXT_DIRECCION As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_TELEFONO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXT_EMAIL As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXT_SALDO As TextBox
    Friend WithEvents CK_TIQUETE As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RB_INACTIVO As RadioButton
    Friend WithEvents RB_ACTIVO As RadioButton
    Friend WithEvents TXT_CEDULA As MaskedTextBox
    Friend WithEvents BTN_BUSCAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents CMB_MONEDA As ComboBox
    Friend WithEvents CMB_DISTRITO As ComboBox
    Friend WithEvents LBL_DISTRITO As Label
    Friend WithEvents CMB_CANTON As ComboBox
    Friend WithEvents LBL_CANTO As Label
    Friend WithEvents CMB_PROVINCIA As ComboBox
    Friend WithEvents LBL_PROVINCIA As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CMB_TIPO As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXT_EXO_NUMERO As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXT_NOMRE_INSTITUCION As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents DTPFECHA As DateTimePicker
    Friend WithEvents TXT_PORCENTAJE As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RB_EXO_INACTIVO As RadioButton
    Friend WithEvents RB_EXO_ACTIVO As RadioButton
    Friend WithEvents BTN_ACEPTAR_EXO As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GRID As DataGridView
    Friend WithEvents CMB_PRECIO As ComboBox
    Friend WithEvents Label14 As Label
End Class
