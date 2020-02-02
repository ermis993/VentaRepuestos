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
        Me.TAB_DET = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_NUMERO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMB_DOCUMENTO = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DTPFECHA = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_TIPO_CAMBIO = New System.Windows.Forms.TextBox()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMB_FORMAPAGO = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMB_MONEDA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXT_PLAZO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXT_DESCRIPCION = New System.Windows.Forms.TextBox()
        Me.ClienteBuscador1 = New VentaRepuestos.Buscador()
        Me.TabControl1.SuspendLayout()
        Me.TAB_ENC.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TAB_ENC)
        Me.TabControl1.Controls.Add(Me.TAB_DET)
        Me.TabControl1.Location = New System.Drawing.Point(3, 105)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1046, 280)
        Me.TabControl1.TabIndex = 1
        '
        'TAB_ENC
        '
        Me.TAB_ENC.Controls.Add(Me.ClienteBuscador1)
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
        Me.TAB_ENC.Location = New System.Drawing.Point(4, 25)
        Me.TAB_ENC.Name = "TAB_ENC"
        Me.TAB_ENC.Padding = New System.Windows.Forms.Padding(3)
        Me.TAB_ENC.Size = New System.Drawing.Size(1038, 251)
        Me.TAB_ENC.TabIndex = 0
        Me.TAB_ENC.Text = "[ Encabezado ]"
        Me.TAB_ENC.UseVisualStyleBackColor = True
        '
        'TAB_DET
        '
        Me.TAB_DET.Location = New System.Drawing.Point(4, 25)
        Me.TAB_DET.Name = "TAB_DET"
        Me.TAB_DET.Padding = New System.Windows.Forms.Padding(3)
        Me.TAB_DET.Size = New System.Drawing.Size(1038, 295)
        Me.TAB_DET.TabIndex = 1
        Me.TAB_DET.Text = "[ Detalle ]"
        Me.TAB_DET.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número :"
        '
        'TXT_NUMERO
        '
        Me.TXT_NUMERO.Location = New System.Drawing.Point(101, 28)
        Me.TXT_NUMERO.Name = "TXT_NUMERO"
        Me.TXT_NUMERO.Size = New System.Drawing.Size(182, 22)
        Me.TXT_NUMERO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Documento :"
        '
        'CMB_DOCUMENTO
        '
        Me.CMB_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DOCUMENTO.FormattingEnabled = True
        Me.CMB_DOCUMENTO.Items.AddRange(New Object() {"FC-Factura Contado", "FA-Factura Crédito"})
        Me.CMB_DOCUMENTO.Location = New System.Drawing.Point(101, 56)
        Me.CMB_DOCUMENTO.Name = "CMB_DOCUMENTO"
        Me.CMB_DOCUMENTO.Size = New System.Drawing.Size(182, 24)
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
        Me.GroupBox1.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1042, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información ]"
        '
        'DTPFECHA
        '
        Me.DTPFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHA.Location = New System.Drawing.Point(395, 28)
        Me.DTPFECHA.Name = "DTPFECHA"
        Me.DTPFECHA.Size = New System.Drawing.Size(117, 22)
        Me.DTPFECHA.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(334, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(351, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "T.C :"
        '
        'TXT_TIPO_CAMBIO
        '
        Me.TXT_TIPO_CAMBIO.Location = New System.Drawing.Point(395, 59)
        Me.TXT_TIPO_CAMBIO.Name = "TXT_TIPO_CAMBIO"
        Me.TXT_TIPO_CAMBIO.Size = New System.Drawing.Size(117, 22)
        Me.TXT_TIPO_CAMBIO.TabIndex = 7
        Me.TXT_TIPO_CAMBIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(916, 392)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_SALIR.TabIndex = 3
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(784, 392)
        Me.BTN_ACEPTAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_ACEPTAR.TabIndex = 2
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Forma Pago :"
        '
        'CMB_FORMAPAGO
        '
        Me.CMB_FORMAPAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FORMAPAGO.FormattingEnabled = True
        Me.CMB_FORMAPAGO.Items.AddRange(New Object() {"EF-Efectivo", "TA-Tarjeta", "TR-Transferencia"})
        Me.CMB_FORMAPAGO.Location = New System.Drawing.Point(104, 57)
        Me.CMB_FORMAPAGO.Name = "CMB_FORMAPAGO"
        Me.CMB_FORMAPAGO.Size = New System.Drawing.Size(175, 24)
        Me.CMB_FORMAPAGO.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cliente :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Moneda :"
        '
        'CMB_MONEDA
        '
        Me.CMB_MONEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_MONEDA.FormattingEnabled = True
        Me.CMB_MONEDA.Items.AddRange(New Object() {"COL-Colones", "DOL-Dólares"})
        Me.CMB_MONEDA.Location = New System.Drawing.Point(104, 94)
        Me.CMB_MONEDA.Name = "CMB_MONEDA"
        Me.CMB_MONEDA.Size = New System.Drawing.Size(175, 24)
        Me.CMB_MONEDA.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Plazo :"
        '
        'TXT_PLAZO
        '
        Me.TXT_PLAZO.Location = New System.Drawing.Point(104, 131)
        Me.TXT_PLAZO.MaxLength = 3
        Me.TXT_PLAZO.Name = "TXT_PLAZO"
        Me.TXT_PLAZO.Size = New System.Drawing.Size(100, 22)
        Me.TXT_PLAZO.TabIndex = 7
        Me.TXT_PLAZO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(210, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "día(s)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 17)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Descripción:"
        '
        'TXT_DESCRIPCION
        '
        Me.TXT_DESCRIPCION.Location = New System.Drawing.Point(105, 169)
        Me.TXT_DESCRIPCION.MaxLength = 250
        Me.TXT_DESCRIPCION.Multiline = True
        Me.TXT_DESCRIPCION.Name = "TXT_DESCRIPCION"
        Me.TXT_DESCRIPCION.Size = New System.Drawing.Size(600, 76)
        Me.TXT_DESCRIPCION.TabIndex = 9
        '
        'ClienteBuscador1
        '
        Me.ClienteBuscador1.CODIGO = Nothing
        Me.ClienteBuscador1.DESCRIPCION = Nothing
        Me.ClienteBuscador1.Location = New System.Drawing.Point(104, 14)
        Me.ClienteBuscador1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ClienteBuscador1.Name = "ClienteBuscador1"
        Me.ClienteBuscador1.OTROS_CAMP0S = Nothing
        Me.ClienteBuscador1.Size = New System.Drawing.Size(601, 33)
        Me.ClienteBuscador1.TabIndex = 10
        Me.ClienteBuscador1.TABLA_BUSCAR = Nothing
        Me.ClienteBuscador1.VALOR = ""
        Me.ClienteBuscador1.VALOR_DESCRIPCION = Nothing
        '
        'Factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1053, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(1071, 497)
        Me.MinimumSize = New System.Drawing.Size(1071, 497)
        Me.Name = "Factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Factura"
        Me.TabControl1.ResumeLayout(False)
        Me.TAB_ENC.ResumeLayout(False)
        Me.TAB_ENC.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents ClienteBuscador1 As Buscador
End Class
