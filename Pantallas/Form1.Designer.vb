<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.LB_USUARIO = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LBL_REGISTRARSE = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'TXT_USUARIO
        '
        Me.TXT_USUARIO.Location = New System.Drawing.Point(158, 81)
        Me.TXT_USUARIO.Multiline = True
        Me.TXT_USUARIO.Name = "TXT_USUARIO"
        Me.TXT_USUARIO.Size = New System.Drawing.Size(143, 28)
        Me.TXT_USUARIO.TabIndex = 4
        '
        'TXT_CONTRASENA
        '
        Me.TXT_CONTRASENA.Location = New System.Drawing.Point(158, 199)
        Me.TXT_CONTRASENA.Multiline = True
        Me.TXT_CONTRASENA.Name = "TXT_CONTRASENA"
        Me.TXT_CONTRASENA.Size = New System.Drawing.Size(143, 28)
        Me.TXT_CONTRASENA.TabIndex = 5
        '
        'LB_USUARIO
        '
        Me.LB_USUARIO.AutoSize = True
        Me.LB_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.LB_USUARIO.Location = New System.Drawing.Point(155, 44)
        Me.LB_USUARIO.Name = "LB_USUARIO"
        Me.LB_USUARIO.Size = New System.Drawing.Size(77, 18)
        Me.LB_USUARIO.TabIndex = 6
        Me.LB_USUARIO.Text = "Usuario :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(155, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Contraseña :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(183, 268)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 44)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Ingresar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LBL_REGISTRARSE
        '
        Me.LBL_REGISTRARSE.AutoSize = True
        Me.LBL_REGISTRARSE.Location = New System.Drawing.Point(299, 285)
        Me.LBL_REGISTRARSE.Name = "LBL_REGISTRARSE"
        Me.LBL_REGISTRARSE.Size = New System.Drawing.Size(82, 13)
        Me.LBL_REGISTRARSE.TabIndex = 9
        Me.LBL_REGISTRARSE.TabStop = True
        Me.LBL_REGISTRARSE.Text = "Registrese aquí"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 338)
        Me.Controls.Add(Me.LBL_REGISTRARSE)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LB_USUARIO)
        Me.Controls.Add(Me.TXT_CONTRASENA)
        Me.Controls.Add(Me.TXT_USUARIO)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TXT_USUARIO As TextBox
    Friend WithEvents TXT_CONTRASENA As TextBox
    Friend WithEvents LB_USUARIO As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents LBL_REGISTRARSE As LinkLabel
End Class
