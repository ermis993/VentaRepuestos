<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentoElectronicoImp
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
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.BTN_ELIMINAR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_EXAMINAR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LBL_RAZON = New System.Windows.Forms.Label()
        Me.TXT_RAZON = New System.Windows.Forms.TextBox()
        Me.CMB_ACTIVIDAD = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXT_TIPO_CAMBIO = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RB_RECHAZADO = New System.Windows.Forms.RadioButton()
        Me.RB_ACEPTADO = New System.Windows.Forms.RadioButton()
        Me.TXT_TOTAL = New System.Windows.Forms.TextBox()
        Me.TXT_O_CARGOS = New System.Windows.Forms.TextBox()
        Me.TXT_IMPUESTO = New System.Windows.Forms.TextBox()
        Me.TXT_DESCUENTO = New System.Windows.Forms.TextBox()
        Me.TXT_SUBTOTAL = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXT_MONEDA = New System.Windows.Forms.TextBox()
        Me.TXT_FECHA = New System.Windows.Forms.TextBox()
        Me.TXT_PROVEEDOR = New System.Windows.Forms.TextBox()
        Me.TXT_CONSECUTIVO = New System.Windows.Forms.TextBox()
        Me.TXT_CLAVE = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OFD
        '
        Me.OFD.FileName = "OFD"
        '
        'BTN_ELIMINAR
        '
        Me.BTN_ELIMINAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_ELIMINAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ELIMINAR.Image = Global.VentaRepuestos.My.Resources.Resources.delete
        Me.BTN_ELIMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ELIMINAR.Location = New System.Drawing.Point(383, 327)
        Me.BTN_ELIMINAR.Name = "BTN_ELIMINAR"
        Me.BTN_ELIMINAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ELIMINAR.TabIndex = 35
        Me.BTN_ELIMINAR.Text = "Eliminar"
        Me.BTN_ELIMINAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ELIMINAR.UseVisualStyleBackColor = False
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = Global.VentaRepuestos.My.Resources.Resources.aceptar
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(295, 454)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 34
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(397, 454)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 33
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_EXAMINAR
        '
        Me.BTN_EXAMINAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_EXAMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_EXAMINAR.Image = Global.VentaRepuestos.My.Resources.Resources.consultas
        Me.BTN_EXAMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_EXAMINAR.Location = New System.Drawing.Point(1, 0)
        Me.BTN_EXAMINAR.Name = "BTN_EXAMINAR"
        Me.BTN_EXAMINAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_EXAMINAR.TabIndex = 36
        Me.BTN_EXAMINAR.Text = "Examinar"
        Me.BTN_EXAMINAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_EXAMINAR.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label1.Location = New System.Drawing.Point(57, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 18)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Clave :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label2.Location = New System.Drawing.Point(11, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 18)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Consecutivo :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.Location = New System.Drawing.Point(25, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 18)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Proveedor :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.Location = New System.Drawing.Point(49, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 18)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Fecha : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(40, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 18)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Moneda :"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 49)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(496, 399)
        Me.TabControl1.TabIndex = 43
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.LBL_RAZON)
        Me.TabPage1.Controls.Add(Me.TXT_RAZON)
        Me.TabPage1.Controls.Add(Me.CMB_ACTIVIDAD)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.TXT_TIPO_CAMBIO)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.TXT_TOTAL)
        Me.TabPage1.Controls.Add(Me.TXT_O_CARGOS)
        Me.TabPage1.Controls.Add(Me.TXT_IMPUESTO)
        Me.TabPage1.Controls.Add(Me.TXT_DESCUENTO)
        Me.TabPage1.Controls.Add(Me.TXT_SUBTOTAL)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.TXT_MONEDA)
        Me.TabPage1.Controls.Add(Me.TXT_FECHA)
        Me.TabPage1.Controls.Add(Me.TXT_PROVEEDOR)
        Me.TabPage1.Controls.Add(Me.TXT_CONSECUTIVO)
        Me.TabPage1.Controls.Add(Me.TXT_CLAVE)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.BTN_ELIMINAR)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(488, 373)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Importación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label12.Location = New System.Drawing.Point(305, 93)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 13)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Actividad económica :"
        '
        'LBL_RAZON
        '
        Me.LBL_RAZON.AutoSize = True
        Me.LBL_RAZON.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LBL_RAZON.Location = New System.Drawing.Point(305, 234)
        Me.LBL_RAZON.Name = "LBL_RAZON"
        Me.LBL_RAZON.Size = New System.Drawing.Size(44, 13)
        Me.LBL_RAZON.TabIndex = 63
        Me.LBL_RAZON.Text = "Razón :"
        Me.LBL_RAZON.Visible = False
        '
        'TXT_RAZON
        '
        Me.TXT_RAZON.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_RAZON.Location = New System.Drawing.Point(308, 252)
        Me.TXT_RAZON.Multiline = True
        Me.TXT_RAZON.Name = "TXT_RAZON"
        Me.TXT_RAZON.Size = New System.Drawing.Size(174, 51)
        Me.TXT_RAZON.TabIndex = 62
        Me.TXT_RAZON.Visible = False
        '
        'CMB_ACTIVIDAD
        '
        Me.CMB_ACTIVIDAD.DropDownHeight = 200
        Me.CMB_ACTIVIDAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_ACTIVIDAD.DropDownWidth = 300
        Me.CMB_ACTIVIDAD.FormattingEnabled = True
        Me.CMB_ACTIVIDAD.IntegralHeight = False
        Me.CMB_ACTIVIDAD.Location = New System.Drawing.Point(308, 110)
        Me.CMB_ACTIVIDAD.Name = "CMB_ACTIVIDAD"
        Me.CMB_ACTIVIDAD.Size = New System.Drawing.Size(174, 21)
        Me.CMB_ACTIVIDAD.TabIndex = 61
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label11.Location = New System.Drawing.Point(40, 174)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 18)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Subtotal :"
        '
        'TXT_TIPO_CAMBIO
        '
        Me.TXT_TIPO_CAMBIO.Enabled = False
        Me.TXT_TIPO_CAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_TIPO_CAMBIO.Location = New System.Drawing.Point(116, 147)
        Me.TXT_TIPO_CAMBIO.Name = "TXT_TIPO_CAMBIO"
        Me.TXT_TIPO_CAMBIO.Size = New System.Drawing.Size(169, 21)
        Me.TXT_TIPO_CAMBIO.TabIndex = 59
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.RB_RECHAZADO)
        Me.GroupBox1.Controls.Add(Me.RB_ACEPTADO)
        Me.GroupBox1.Location = New System.Drawing.Point(308, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 88)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(103, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(37, 22)
        Me.Panel2.TabIndex = 60
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Green
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(103, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(37, 22)
        Me.Panel1.TabIndex = 59
        '
        'RB_RECHAZADO
        '
        Me.RB_RECHAZADO.AutoSize = True
        Me.RB_RECHAZADO.Location = New System.Drawing.Point(17, 57)
        Me.RB_RECHAZADO.Name = "RB_RECHAZADO"
        Me.RB_RECHAZADO.Size = New System.Drawing.Size(80, 17)
        Me.RB_RECHAZADO.TabIndex = 1
        Me.RB_RECHAZADO.TabStop = True
        Me.RB_RECHAZADO.Text = "Rechazado"
        Me.RB_RECHAZADO.UseVisualStyleBackColor = True
        '
        'RB_ACEPTADO
        '
        Me.RB_ACEPTADO.AutoSize = True
        Me.RB_ACEPTADO.Location = New System.Drawing.Point(17, 24)
        Me.RB_ACEPTADO.Name = "RB_ACEPTADO"
        Me.RB_ACEPTADO.Size = New System.Drawing.Size(71, 17)
        Me.RB_ACEPTADO.TabIndex = 0
        Me.RB_ACEPTADO.TabStop = True
        Me.RB_ACEPTADO.Text = "Aceptado"
        Me.RB_ACEPTADO.UseVisualStyleBackColor = True
        '
        'TXT_TOTAL
        '
        Me.TXT_TOTAL.Enabled = False
        Me.TXT_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_TOTAL.Location = New System.Drawing.Point(116, 282)
        Me.TXT_TOTAL.Name = "TXT_TOTAL"
        Me.TXT_TOTAL.Size = New System.Drawing.Size(169, 21)
        Me.TXT_TOTAL.TabIndex = 57
        '
        'TXT_O_CARGOS
        '
        Me.TXT_O_CARGOS.Enabled = False
        Me.TXT_O_CARGOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_O_CARGOS.Location = New System.Drawing.Point(116, 255)
        Me.TXT_O_CARGOS.Name = "TXT_O_CARGOS"
        Me.TXT_O_CARGOS.Size = New System.Drawing.Size(169, 21)
        Me.TXT_O_CARGOS.TabIndex = 56
        '
        'TXT_IMPUESTO
        '
        Me.TXT_IMPUESTO.Enabled = False
        Me.TXT_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_IMPUESTO.Location = New System.Drawing.Point(116, 228)
        Me.TXT_IMPUESTO.Name = "TXT_IMPUESTO"
        Me.TXT_IMPUESTO.Size = New System.Drawing.Size(169, 21)
        Me.TXT_IMPUESTO.TabIndex = 55
        '
        'TXT_DESCUENTO
        '
        Me.TXT_DESCUENTO.Enabled = False
        Me.TXT_DESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_DESCUENTO.Location = New System.Drawing.Point(116, 201)
        Me.TXT_DESCUENTO.Name = "TXT_DESCUENTO"
        Me.TXT_DESCUENTO.Size = New System.Drawing.Size(169, 21)
        Me.TXT_DESCUENTO.TabIndex = 54
        '
        'TXT_SUBTOTAL
        '
        Me.TXT_SUBTOTAL.Enabled = False
        Me.TXT_SUBTOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_SUBTOTAL.Location = New System.Drawing.Point(116, 174)
        Me.TXT_SUBTOTAL.Name = "TXT_SUBTOTAL"
        Me.TXT_SUBTOTAL.Size = New System.Drawing.Size(169, 21)
        Me.TXT_SUBTOTAL.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label10.Location = New System.Drawing.Point(61, 284)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 18)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Total :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label9.Location = New System.Drawing.Point(9, 256)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 18)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Otros cargos :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label8.Location = New System.Drawing.Point(33, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 18)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Impuesto :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.Location = New System.Drawing.Point(25, 202)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 18)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Descuento :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label6.Location = New System.Drawing.Point(12, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 18)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Tipo cambio :"
        '
        'TXT_MONEDA
        '
        Me.TXT_MONEDA.Enabled = False
        Me.TXT_MONEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_MONEDA.Location = New System.Drawing.Point(116, 121)
        Me.TXT_MONEDA.Name = "TXT_MONEDA"
        Me.TXT_MONEDA.Size = New System.Drawing.Size(169, 21)
        Me.TXT_MONEDA.TabIndex = 47
        '
        'TXT_FECHA
        '
        Me.TXT_FECHA.Enabled = False
        Me.TXT_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_FECHA.Location = New System.Drawing.Point(116, 93)
        Me.TXT_FECHA.Name = "TXT_FECHA"
        Me.TXT_FECHA.Size = New System.Drawing.Size(169, 21)
        Me.TXT_FECHA.TabIndex = 46
        '
        'TXT_PROVEEDOR
        '
        Me.TXT_PROVEEDOR.Enabled = False
        Me.TXT_PROVEEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_PROVEEDOR.Location = New System.Drawing.Point(116, 65)
        Me.TXT_PROVEEDOR.Name = "TXT_PROVEEDOR"
        Me.TXT_PROVEEDOR.Size = New System.Drawing.Size(366, 21)
        Me.TXT_PROVEEDOR.TabIndex = 45
        '
        'TXT_CONSECUTIVO
        '
        Me.TXT_CONSECUTIVO.Enabled = False
        Me.TXT_CONSECUTIVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXT_CONSECUTIVO.Location = New System.Drawing.Point(116, 37)
        Me.TXT_CONSECUTIVO.Name = "TXT_CONSECUTIVO"
        Me.TXT_CONSECUTIVO.Size = New System.Drawing.Size(366, 21)
        Me.TXT_CONSECUTIVO.TabIndex = 44
        '
        'TXT_CLAVE
        '
        Me.TXT_CLAVE.Enabled = False
        Me.TXT_CLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CLAVE.Location = New System.Drawing.Point(116, 9)
        Me.TXT_CLAVE.Name = "TXT_CLAVE"
        Me.TXT_CLAVE.Size = New System.Drawing.Size(366, 21)
        Me.TXT_CLAVE.TabIndex = 43
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(488, 373)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DocumentosElectronicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BTN_EXAMINAR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DocumentosElectronicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importación"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OFD As OpenFileDialog
    Friend WithEvents BTN_ELIMINAR As Button
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_EXAMINAR As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TXT_CLAVE As TextBox
    Friend WithEvents TXT_FECHA As TextBox
    Friend WithEvents TXT_PROVEEDOR As TextBox
    Friend WithEvents TXT_CONSECUTIVO As TextBox
    Friend WithEvents TXT_MONEDA As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TXT_TOTAL As TextBox
    Friend WithEvents TXT_O_CARGOS As TextBox
    Friend WithEvents TXT_IMPUESTO As TextBox
    Friend WithEvents TXT_DESCUENTO As TextBox
    Friend WithEvents TXT_SUBTOTAL As TextBox
    Friend WithEvents RB_RECHAZADO As RadioButton
    Friend WithEvents RB_ACEPTADO As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TXT_TIPO_CAMBIO As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CMB_ACTIVIDAD As ComboBox
    Friend WithEvents TXT_RAZON As TextBox
    Friend WithEvents LBL_RAZON As Label
    Friend WithEvents Label12 As Label
End Class
