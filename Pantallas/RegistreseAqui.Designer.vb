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
        Me.BTN_GUARDAR = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(36, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'TXT_NOMUSUARIO
        '
        Me.TXT_NOMUSUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_NOMUSUARIO.Location = New System.Drawing.Point(151, 42)
        Me.TXT_NOMUSUARIO.Name = "TXT_NOMUSUARIO"
        Me.TXT_NOMUSUARIO.Size = New System.Drawing.Size(260, 29)
        Me.TXT_NOMUSUARIO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(28, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Teléfono:"
        '
        'TXT_TELEFONO
        '
        Me.TXT_TELEFONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_TELEFONO.Location = New System.Drawing.Point(151, 140)
        Me.TXT_TELEFONO.Name = "TXT_TELEFONO"
        Me.TXT_TELEFONO.Size = New System.Drawing.Size(169, 29)
        Me.TXT_TELEFONO.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(22, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Direccion:"
        '
        'TXT_DIRECCION
        '
        Me.TXT_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_DIRECCION.Location = New System.Drawing.Point(151, 182)
        Me.TXT_DIRECCION.Multiline = True
        Me.TXT_DIRECCION.Name = "TXT_DIRECCION"
        Me.TXT_DIRECCION.Size = New System.Drawing.Size(260, 113)
        Me.TXT_DIRECCION.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(47, 317)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Correo:"
        '
        'TXT_CORREO
        '
        Me.TXT_CORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CORREO.Location = New System.Drawing.Point(151, 317)
        Me.TXT_CORREO.Name = "TXT_CORREO"
        Me.TXT_CORREO.Size = New System.Drawing.Size(260, 29)
        Me.TXT_CORREO.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(5, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 24)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Contraseña:"
        '
        'TXT_CONTRASENA
        '
        Me.TXT_CONTRASENA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CONTRASENA.Location = New System.Drawing.Point(151, 93)
        Me.TXT_CONTRASENA.Name = "TXT_CONTRASENA"
        Me.TXT_CONTRASENA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_CONTRASENA.Size = New System.Drawing.Size(260, 29)
        Me.TXT_CONTRASENA.TabIndex = 3
        Me.TXT_CONTRASENA.UseSystemPasswordChar = True
        '
        'BTN_GUARDAR
        '
        Me.BTN_GUARDAR.BackgroundImage = Global.VentaRepuestos.My.Resources.Resources.guardar
        Me.BTN_GUARDAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_GUARDAR.Location = New System.Drawing.Point(245, 372)
        Me.BTN_GUARDAR.Name = "BTN_GUARDAR"
        Me.BTN_GUARDAR.Size = New System.Drawing.Size(75, 66)
        Me.BTN_GUARDAR.TabIndex = 10
        Me.BTN_GUARDAR.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(336, 372)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 66)
        Me.Button2.TabIndex = 11
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RegistreseAqui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(425, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
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
    Friend WithEvents Button2 As Button
End Class
