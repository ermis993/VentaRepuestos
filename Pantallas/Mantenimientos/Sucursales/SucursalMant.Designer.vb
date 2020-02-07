<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SucursalMant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SucursalMant))
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.LBL_CODIGO = New System.Windows.Forms.Label()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_NOMBRE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_DIRECCION = New System.Windows.Forms.TextBox()
        Me.TXT_TELEFONO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_CORREO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVA = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVA = New System.Windows.Forms.RadioButton()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(489, 384)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_SALIR.TabIndex = 2
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'LBL_CODIGO
        '
        Me.LBL_CODIGO.AutoSize = True
        Me.LBL_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CODIGO.Location = New System.Drawing.Point(25, 33)
        Me.LBL_CODIGO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBL_CODIGO.Name = "LBL_CODIGO"
        Me.LBL_CODIGO.Size = New System.Drawing.Size(81, 24)
        Me.LBL_CODIGO.TabIndex = 0
        Me.LBL_CODIGO.Text = "Código :"
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Enabled = False
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(120, 33)
        Me.TXT_CODIGO.Margin = New System.Windows.Forms.Padding(4)
        Me.TXT_CODIGO.Multiline = True
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(189, 29)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 71)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre :"
        '
        'TXT_NOMBRE
        '
        Me.TXT_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_NOMBRE.Location = New System.Drawing.Point(120, 70)
        Me.TXT_NOMBRE.Margin = New System.Windows.Forms.Padding(4)
        Me.TXT_NOMBRE.MaxLength = 100
        Me.TXT_NOMBRE.Multiline = True
        Me.TXT_NOMBRE.Name = "TXT_NOMBRE"
        Me.TXT_NOMBRE.Size = New System.Drawing.Size(483, 29)
        Me.TXT_NOMBRE.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Dirección :"
        '
        'TXT_DIRECCION
        '
        Me.TXT_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_DIRECCION.Location = New System.Drawing.Point(120, 107)
        Me.TXT_DIRECCION.Margin = New System.Windows.Forms.Padding(4)
        Me.TXT_DIRECCION.MaxLength = 250
        Me.TXT_DIRECCION.Multiline = True
        Me.TXT_DIRECCION.Name = "TXT_DIRECCION"
        Me.TXT_DIRECCION.Size = New System.Drawing.Size(483, 96)
        Me.TXT_DIRECCION.TabIndex = 5
        '
        'TXT_TELEFONO
        '
        Me.TXT_TELEFONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_TELEFONO.Location = New System.Drawing.Point(120, 219)
        Me.TXT_TELEFONO.MaxLength = 8
        Me.TXT_TELEFONO.Name = "TXT_TELEFONO"
        Me.TXT_TELEFONO.Size = New System.Drawing.Size(187, 29)
        Me.TXT_TELEFONO.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Teléfono:"
        '
        'TXT_CORREO
        '
        Me.TXT_CORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CORREO.Location = New System.Drawing.Point(120, 265)
        Me.TXT_CORREO.MaxLength = 150
        Me.TXT_CORREO.Name = "TXT_CORREO"
        Me.TXT_CORREO.Size = New System.Drawing.Size(483, 29)
        Me.TXT_CORREO.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(33, 265)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Correo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TXT_CODIGO)
        Me.GroupBox1.Controls.Add(Me.TXT_CORREO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LBL_CODIGO)
        Me.GroupBox1.Controls.Add(Me.TXT_NOMBRE)
        Me.GroupBox1.Controls.Add(Me.TXT_TELEFONO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TXT_DIRECCION)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 365)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información General ]"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RB_INACTIVA)
        Me.GroupBox2.Controls.Add(Me.RB_ACTIVA)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox2.Location = New System.Drawing.Point(120, 301)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(483, 59)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado"
        '
        'RB_INACTIVA
        '
        Me.RB_INACTIVA.AutoSize = True
        Me.RB_INACTIVA.Location = New System.Drawing.Point(135, 23)
        Me.RB_INACTIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.RB_INACTIVA.Name = "RB_INACTIVA"
        Me.RB_INACTIVA.Size = New System.Drawing.Size(87, 24)
        Me.RB_INACTIVA.TabIndex = 1
        Me.RB_INACTIVA.TabStop = True
        Me.RB_INACTIVA.Text = "Inactiva"
        Me.RB_INACTIVA.UseVisualStyleBackColor = True
        '
        'RB_ACTIVA
        '
        Me.RB_ACTIVA.AutoSize = True
        Me.RB_ACTIVA.Checked = True
        Me.RB_ACTIVA.Location = New System.Drawing.Point(20, 23)
        Me.RB_ACTIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.RB_ACTIVA.Name = "RB_ACTIVA"
        Me.RB_ACTIVA.Size = New System.Drawing.Size(76, 24)
        Me.RB_ACTIVA.TabIndex = 0
        Me.RB_ACTIVA.TabStop = True
        Me.RB_ACTIVA.Text = "Activa"
        Me.RB_ACTIVA.UseVisualStyleBackColor = True
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(356, 384)
        Me.BTN_ACEPTAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_ACEPTAR.TabIndex = 1
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'SucursalMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(634, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Name = "SucursalMant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucursal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents LBL_CODIGO As Label
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_NOMBRE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_DIRECCION As TextBox
    Friend WithEvents TXT_TELEFONO As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_CORREO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RB_INACTIVA As RadioButton
    Friend WithEvents RB_ACTIVA As RadioButton
    Friend WithEvents BTN_ACEPTAR As Button
End Class
