<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistreseAqui
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_NOMUSUARIO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_TELEFONO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_DIRECCION = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_CORREO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT_CONTRASENA = New System.Windows.Forms.TextBox()
        Me.BTN_SELECCIONAR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BTN_GUARDAR = New System.Windows.Forms.Button()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(49, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'TXT_NOMUSUARIO
        '
        Me.TXT_NOMUSUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_NOMUSUARIO.Location = New System.Drawing.Point(149, 57)
        Me.TXT_NOMUSUARIO.MaxLength = 50
        Me.TXT_NOMUSUARIO.Name = "TXT_NOMUSUARIO"
        Me.TXT_NOMUSUARIO.Size = New System.Drawing.Size(260, 29)
        Me.TXT_NOMUSUARIO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(43, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Teléfono:"
        '
        'TXT_TELEFONO
        '
        Me.TXT_TELEFONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_TELEFONO.Location = New System.Drawing.Point(149, 155)
        Me.TXT_TELEFONO.MaxLength = 8
        Me.TXT_TELEFONO.Name = "TXT_TELEFONO"
        Me.TXT_TELEFONO.Size = New System.Drawing.Size(169, 29)
        Me.TXT_TELEFONO.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Direccion:"
        '
        'TXT_DIRECCION
        '
        Me.TXT_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_DIRECCION.Location = New System.Drawing.Point(149, 197)
        Me.TXT_DIRECCION.MaxLength = 250
        Me.TXT_DIRECCION.Multiline = True
        Me.TXT_DIRECCION.Name = "TXT_DIRECCION"
        Me.TXT_DIRECCION.Size = New System.Drawing.Size(260, 131)
        Me.TXT_DIRECCION.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(60, 352)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Correo:"
        '
        'TXT_CORREO
        '
        Me.TXT_CORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CORREO.Location = New System.Drawing.Point(149, 352)
        Me.TXT_CORREO.MaxLength = 150
        Me.TXT_CORREO.Name = "TXT_CORREO"
        Me.TXT_CORREO.Size = New System.Drawing.Size(260, 29)
        Me.TXT_CORREO.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 24)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Contraseña:"
        '
        'TXT_CONTRASENA
        '
        Me.TXT_CONTRASENA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CONTRASENA.Location = New System.Drawing.Point(149, 108)
        Me.TXT_CONTRASENA.MaxLength = 100
        Me.TXT_CONTRASENA.Name = "TXT_CONTRASENA"
        Me.TXT_CONTRASENA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_CONTRASENA.Size = New System.Drawing.Size(260, 29)
        Me.TXT_CONTRASENA.TabIndex = 3
        Me.TXT_CONTRASENA.UseSystemPasswordChar = True
        '
        'BTN_SELECCIONAR
        '
        Me.BTN_SELECCIONAR.ForeColor = System.Drawing.Color.Black
        Me.BTN_SELECCIONAR.Location = New System.Drawing.Point(6, 322)
        Me.BTN_SELECCIONAR.Name = "BTN_SELECCIONAR"
        Me.BTN_SELECCIONAR.Size = New System.Drawing.Size(257, 41)
        Me.BTN_SELECCIONAR.TabIndex = 0
        Me.BTN_SELECCIONAR.Text = "Seleccionar"
        Me.BTN_SELECCIONAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.BTN_SELECCIONAR)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(432, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 369)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Foto ]"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(257, 253)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSalir.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(569, 407)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(132, 53)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BTN_GUARDAR
        '
        Me.BTN_GUARDAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_GUARDAR.Image = Global.VentaRepuestos.My.Resources.Resources.aceptar
        Me.BTN_GUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_GUARDAR.Location = New System.Drawing.Point(431, 407)
        Me.BTN_GUARDAR.Name = "BTN_GUARDAR"
        Me.BTN_GUARDAR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_GUARDAR.TabIndex = 11
        Me.BTN_GUARDAR.Text = "Aceptar"
        Me.BTN_GUARDAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_GUARDAR.UseVisualStyleBackColor = True
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(149, 12)
        Me.TXT_CODIGO.MaxLength = 50
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(169, 29)
        Me.TXT_CODIGO.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(57, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 24)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Código:"
        '
        'RegistreseAqui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(713, 472)
        Me.Controls.Add(Me.TXT_CODIGO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BTN_GUARDAR)
        Me.Controls.Add(Me.TXT_CONTRASENA)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXT_CORREO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXT_DIRECCION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXT_TELEFONO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXT_NOMUSUARIO)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RegistreseAqui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrese aquí"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_NOMUSUARIO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_TELEFONO As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_DIRECCION As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_CORREO As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXT_CONTRASENA As TextBox
    Friend WithEvents BTN_GUARDAR As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BTN_SELECCIONAR As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents Label6 As Label
End Class
