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
        Me.TXT_MINIMO = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVO = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVO = New System.Windows.Forms.RadioButton()
        Me.Buscador = New VentaRepuestos.Buscador()
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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(766, 441)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información general ]"
        '
        'TXT_MINIMO
        '
        Me.TXT_MINIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_MINIMO.Location = New System.Drawing.Point(156, 403)
        Me.TXT_MINIMO.MaxLength = 18
        Me.TXT_MINIMO.Name = "TXT_MINIMO"
        Me.TXT_MINIMO.Size = New System.Drawing.Size(203, 29)
        Me.TXT_MINIMO.TabIndex = 27
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label15.Location = New System.Drawing.Point(21, 406)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(125, 24)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Minimo stock:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RB_INACTIVO)
        Me.GroupBox3.Controls.Add(Me.RB_ACTIVO)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(363, 391)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(371, 41)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estado"
        '
        'RB_INACTIVO
        '
        Me.RB_INACTIVO.AutoSize = True
        Me.RB_INACTIVO.Location = New System.Drawing.Point(173, 12)
        Me.RB_INACTIVO.Margin = New System.Windows.Forms.Padding(4)
        Me.RB_INACTIVO.Name = "RB_INACTIVO"
        Me.RB_INACTIVO.Size = New System.Drawing.Size(87, 24)
        Me.RB_INACTIVO.TabIndex = 1
        Me.RB_INACTIVO.TabStop = True
        Me.RB_INACTIVO.Text = "Inactivo"
        Me.RB_INACTIVO.UseVisualStyleBackColor = True
        '
        'RB_ACTIVO
        '
        Me.RB_ACTIVO.AutoSize = True
        Me.RB_ACTIVO.Checked = True
        Me.RB_ACTIVO.Location = New System.Drawing.Point(77, 12)
        Me.RB_ACTIVO.Margin = New System.Windows.Forms.Padding(4)
        Me.RB_ACTIVO.Name = "RB_ACTIVO"
        Me.RB_ACTIVO.Size = New System.Drawing.Size(76, 24)
        Me.RB_ACTIVO.TabIndex = 0
        Me.RB_ACTIVO.TabStop = True
        Me.RB_ACTIVO.Text = "Activo"
        Me.RB_ACTIVO.UseVisualStyleBackColor = True
        '
        'Buscador
        '
        Me.Buscador.CODIGO = Nothing
        Me.Buscador.DESCRIPCION = Nothing
        Me.Buscador.Location = New System.Drawing.Point(152, 115)
        Me.Buscador.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Buscador.Name = "Buscador"
        Me.Buscador.OTROS_CAMP0S = Nothing
        Me.Buscador.PANTALLA = Nothing
        Me.Buscador.Size = New System.Drawing.Size(589, 32)
        Me.Buscador.TabIndex = 5
        Me.Buscador.TABLA_BUSCAR = Nothing
        Me.Buscador.VALOR = ""
        Me.Buscador.VALOR_DESCRIPCION = Nothing
        '
        'TXT_FILA
        '
        Me.TXT_FILA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_FILA.Location = New System.Drawing.Point(374, 355)
        Me.TXT_FILA.MaxLength = 3
        Me.TXT_FILA.Name = "TXT_FILA"
        Me.TXT_FILA.Size = New System.Drawing.Size(100, 29)
        Me.TXT_FILA.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label14.Location = New System.Drawing.Point(532, 358)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 24)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Columna :"
        '
        'TXT_ESTANTE
        '
        Me.TXT_ESTANTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_ESTANTE.Location = New System.Drawing.Point(156, 357)
        Me.TXT_ESTANTE.MaxLength = 3
        Me.TXT_ESTANTE.Name = "TXT_ESTANTE"
        Me.TXT_ESTANTE.Size = New System.Drawing.Size(100, 29)
        Me.TXT_ESTANTE.TabIndex = 21
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label13.Location = New System.Drawing.Point(320, 358)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 24)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Fila :"
        '
        'TXT_COLUMNA
        '
        Me.TXT_COLUMNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COLUMNA.Location = New System.Drawing.Point(634, 355)
        Me.TXT_COLUMNA.MaxLength = 3
        Me.TXT_COLUMNA.Name = "TXT_COLUMNA"
        Me.TXT_COLUMNA.Size = New System.Drawing.Size(100, 29)
        Me.TXT_COLUMNA.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label12.Location = New System.Drawing.Point(69, 360)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 24)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Estante:"
        '
        'TXT_PRECIO
        '
        Me.TXT_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_PRECIO.Location = New System.Drawing.Point(156, 317)
        Me.TXT_PRECIO.MaxLength = 18
        Me.TXT_PRECIO.Name = "TXT_PRECIO"
        Me.TXT_PRECIO.Size = New System.Drawing.Size(202, 29)
        Me.TXT_PRECIO.TabIndex = 19
        Me.TXT_PRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_COSTO
        '
        Me.TXT_COSTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COSTO.Location = New System.Drawing.Point(156, 280)
        Me.TXT_COSTO.MaxLength = 18
        Me.TXT_COSTO.Name = "TXT_COSTO"
        Me.TXT_COSTO.Size = New System.Drawing.Size(202, 29)
        Me.TXT_COSTO.TabIndex = 17
        Me.TXT_COSTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label11.Location = New System.Drawing.Point(27, 318)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 24)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Precio venta:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label10.Location = New System.Drawing.Point(27, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 24)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Precio costo:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label9.Location = New System.Drawing.Point(565, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 24)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "%"
        '
        'TXT_EXENTO
        '
        Me.TXT_EXENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_EXENTO.Location = New System.Drawing.Point(680, 197)
        Me.TXT_EXENTO.Name = "TXT_EXENTO"
        Me.TXT_EXENTO.ReadOnly = True
        Me.TXT_EXENTO.Size = New System.Drawing.Size(54, 29)
        Me.TXT_EXENTO.TabIndex = 15
        Me.TXT_EXENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label8.Location = New System.Drawing.Point(596, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 24)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Exento :"
        '
        'TXT_IMPUESTO
        '
        Me.TXT_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_IMPUESTO.Location = New System.Drawing.Point(459, 197)
        Me.TXT_IMPUESTO.Name = "TXT_IMPUESTO"
        Me.TXT_IMPUESTO.ReadOnly = True
        Me.TXT_IMPUESTO.Size = New System.Drawing.Size(100, 29)
        Me.TXT_IMPUESTO.TabIndex = 13
        Me.TXT_IMPUESTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.Location = New System.Drawing.Point(365, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 24)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Impuesto :"
        '
        'CMB_IMPUESTO_DGTD
        '
        Me.CMB_IMPUESTO_DGTD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_IMPUESTO_DGTD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CMB_IMPUESTO_DGTD.FormattingEnabled = True
        Me.CMB_IMPUESTO_DGTD.Location = New System.Drawing.Point(156, 240)
        Me.CMB_IMPUESTO_DGTD.Name = "CMB_IMPUESTO_DGTD"
        Me.CMB_IMPUESTO_DGTD.Size = New System.Drawing.Size(434, 26)
        Me.CMB_IMPUESTO_DGTD.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label6.Location = New System.Drawing.Point(13, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 24)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Código DGTD:"
        '
        'CMB_UNIDADES
        '
        Me.CMB_UNIDADES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_UNIDADES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CMB_UNIDADES.FormattingEnabled = True
        Me.CMB_UNIDADES.Location = New System.Drawing.Point(156, 201)
        Me.CMB_UNIDADES.Name = "CMB_UNIDADES"
        Me.CMB_UNIDADES.Size = New System.Drawing.Size(203, 26)
        Me.CMB_UNIDADES.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(3, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Unidad Medida:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.Location = New System.Drawing.Point(43, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 24)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Proveedor:"
        '
        'TXT_DESC
        '
        Me.TXT_DESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_DESC.Location = New System.Drawing.Point(156, 157)
        Me.TXT_DESC.MaxLength = 150
        Me.TXT_DESC.Name = "TXT_DESC"
        Me.TXT_DESC.Size = New System.Drawing.Size(578, 29)
        Me.TXT_DESC.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.Location = New System.Drawing.Point(31, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Descripción:"
        '
        'TXT_COD_BARRA
        '
        Me.TXT_COD_BARRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_COD_BARRA.Location = New System.Drawing.Point(156, 73)
        Me.TXT_COD_BARRA.MaxLength = 25
        Me.TXT_COD_BARRA.Name = "TXT_COD_BARRA"
        Me.TXT_COD_BARRA.Size = New System.Drawing.Size(578, 29)
        Me.TXT_COD_BARRA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label2.Location = New System.Drawing.Point(13, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código barras:"
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(156, 31)
        Me.TXT_CODIGO.MaxLength = 20
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(202, 29)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label1.Location = New System.Drawing.Point(70, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código:"
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(505, 451)
        Me.BTN_ACEPTAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(132, 53)
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
        Me.BTN_SALIR.Location = New System.Drawing.Point(638, 451)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_SALIR.TabIndex = 2
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'ProductoMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(782, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimumSize = New System.Drawing.Size(788, 553)
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
End Class
