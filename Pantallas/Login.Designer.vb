<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Me.TXT_USUARIO = New System.Windows.Forms.TextBox()
        Me.TXT_CONTRASENA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_INGRESAR = New System.Windows.Forms.Button()
        Me.LBL_REGISTRARSE = New System.Windows.Forms.LinkLabel()
        Me.LBL_OLVIDO = New System.Windows.Forms.Label()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.LB_USUARIO = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TXT_USUARIO
        '
        Me.TXT_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_USUARIO.Location = New System.Drawing.Point(28, 177)
        Me.TXT_USUARIO.Name = "TXT_USUARIO"
        Me.TXT_USUARIO.Size = New System.Drawing.Size(310, 20)
        Me.TXT_USUARIO.TabIndex = 4
        '
        'TXT_CONTRASENA
        '
        Me.TXT_CONTRASENA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CONTRASENA.Location = New System.Drawing.Point(28, 227)
        Me.TXT_CONTRASENA.Name = "TXT_CONTRASENA"
        Me.TXT_CONTRASENA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_CONTRASENA.Size = New System.Drawing.Size(310, 20)
        Me.TXT_CONTRASENA.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(25, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Contraseña :"
        '
        'BTN_INGRESAR
        '
        Me.BTN_INGRESAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_INGRESAR.FlatAppearance.BorderSize = 0
        Me.BTN_INGRESAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_INGRESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.BTN_INGRESAR.ForeColor = System.Drawing.Color.Black
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(28, 265)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(310, 37)
        Me.BTN_INGRESAR.TabIndex = 8
        Me.BTN_INGRESAR.Text = "Ingresar"
        Me.BTN_INGRESAR.UseVisualStyleBackColor = False
        '
        'LBL_REGISTRARSE
        '
        Me.LBL_REGISTRARSE.AutoSize = True
        Me.LBL_REGISTRARSE.BackColor = System.Drawing.Color.Transparent
        Me.LBL_REGISTRARSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_REGISTRARSE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LBL_REGISTRARSE.LinkColor = System.Drawing.Color.Black
        Me.LBL_REGISTRARSE.Location = New System.Drawing.Point(121, 348)
        Me.LBL_REGISTRARSE.Name = "LBL_REGISTRARSE"
        Me.LBL_REGISTRARSE.Size = New System.Drawing.Size(125, 18)
        Me.LBL_REGISTRARSE.TabIndex = 9
        Me.LBL_REGISTRARSE.TabStop = True
        Me.LBL_REGISTRARSE.Text = "Registrese aquí"
        '
        'LBL_OLVIDO
        '
        Me.LBL_OLVIDO.AutoSize = True
        Me.LBL_OLVIDO.BackColor = System.Drawing.Color.Transparent
        Me.LBL_OLVIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.LBL_OLVIDO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LBL_OLVIDO.Location = New System.Drawing.Point(81, 379)
        Me.LBL_OLVIDO.Name = "LBL_OLVIDO"
        Me.LBL_OLVIDO.Size = New System.Drawing.Size(209, 18)
        Me.LBL_OLVIDO.TabIndex = 12
        Me.LBL_OLVIDO.Text = "He olvidado mi contraseña"
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_SALIR.FlatAppearance.BorderSize = 0
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.BTN_SALIR.ForeColor = System.Drawing.Color.Black
        Me.BTN_SALIR.Location = New System.Drawing.Point(28, 308)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(310, 37)
        Me.BTN_SALIR.TabIndex = 13
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'LB_USUARIO
        '
        Me.LB_USUARIO.AutoSize = True
        Me.LB_USUARIO.BackColor = System.Drawing.Color.Transparent
        Me.LB_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.LB_USUARIO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LB_USUARIO.Location = New System.Drawing.Point(25, 156)
        Me.LB_USUARIO.Name = "LB_USUARIO"
        Me.LB_USUARIO.Size = New System.Drawing.Size(77, 18)
        Me.LB_USUARIO.TabIndex = 6
        Me.LB_USUARIO.Text = "Usuario :"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(368, 412)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.LBL_OLVIDO)
        Me.Controls.Add(Me.LBL_REGISTRARSE)
        Me.Controls.Add(Me.BTN_INGRESAR)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LB_USUARIO)
        Me.Controls.Add(Me.TXT_CONTRASENA)
        Me.Controls.Add(Me.TXT_USUARIO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TXT_USUARIO As TextBox
    Friend WithEvents TXT_CONTRASENA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_INGRESAR As Button
    Friend WithEvents LBL_REGISTRARSE As LinkLabel
    Friend WithEvents LBL_OLVIDO As Label
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents LB_USUARIO As Label
End Class
