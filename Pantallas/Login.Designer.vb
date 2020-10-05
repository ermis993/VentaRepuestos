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
        Me.LBL_REGISTRARSE = New System.Windows.Forms.LinkLabel()
        Me.LBL_OLVIDO = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_INGRESAR = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXT_USUARIO
        '
        Me.TXT_USUARIO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TXT_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_USUARIO.Location = New System.Drawing.Point(53, 26)
        Me.TXT_USUARIO.Multiline = True
        Me.TXT_USUARIO.Name = "TXT_USUARIO"
        Me.TXT_USUARIO.Size = New System.Drawing.Size(170, 20)
        Me.TXT_USUARIO.TabIndex = 0
        '
        'TXT_CONTRASENA
        '
        Me.TXT_CONTRASENA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TXT_CONTRASENA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CONTRASENA.Location = New System.Drawing.Point(53, 68)
        Me.TXT_CONTRASENA.Multiline = True
        Me.TXT_CONTRASENA.Name = "TXT_CONTRASENA"
        Me.TXT_CONTRASENA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_CONTRASENA.Size = New System.Drawing.Size(170, 20)
        Me.TXT_CONTRASENA.TabIndex = 1
        '
        'LBL_REGISTRARSE
        '
        Me.LBL_REGISTRARSE.AutoSize = True
        Me.LBL_REGISTRARSE.BackColor = System.Drawing.Color.Transparent
        Me.LBL_REGISTRARSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_REGISTRARSE.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LBL_REGISTRARSE.LinkColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LBL_REGISTRARSE.Location = New System.Drawing.Point(64, 244)
        Me.LBL_REGISTRARSE.Name = "LBL_REGISTRARSE"
        Me.LBL_REGISTRARSE.Size = New System.Drawing.Size(118, 16)
        Me.LBL_REGISTRARSE.TabIndex = 1
        Me.LBL_REGISTRARSE.TabStop = True
        Me.LBL_REGISTRARSE.Text = "Registrese aquí"
        '
        'LBL_OLVIDO
        '
        Me.LBL_OLVIDO.BackColor = System.Drawing.Color.Transparent
        Me.LBL_OLVIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_OLVIDO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LBL_OLVIDO.Location = New System.Drawing.Point(0, 101)
        Me.LBL_OLVIDO.Name = "LBL_OLVIDO"
        Me.LBL_OLVIDO.Size = New System.Drawing.Size(246, 18)
        Me.LBL_OLVIDO.TabIndex = 2
        Me.LBL_OLVIDO.Text = "He olvidado mi contraseña"
        Me.LBL_OLVIDO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.LBL_OLVIDO)
        Me.Panel1.Controls.Add(Me.BTN_SALIR)
        Me.Panel1.Controls.Add(Me.BTN_INGRESAR)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.TXT_CONTRASENA)
        Me.Panel1.Controls.Add(Me.TXT_USUARIO)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(246, 184)
        Me.Panel1.TabIndex = 14
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_SALIR.FlatAppearance.BorderSize = 0
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.ForeColor = System.Drawing.Color.Black
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salida
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(148, 130)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(94, 37)
        Me.BTN_SALIR.TabIndex = 4
        Me.BTN_SALIR.Text = "Apagar"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_INGRESAR
        '
        Me.BTN_INGRESAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_INGRESAR.FlatAppearance.BorderSize = 0
        Me.BTN_INGRESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_INGRESAR.ForeColor = System.Drawing.Color.Black
        Me.BTN_INGRESAR.Image = Global.VentaRepuestos.My.Resources.Resources.entrar
        Me.BTN_INGRESAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(3, 130)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(94, 37)
        Me.BTN_INGRESAR.TabIndex = 3
        Me.BTN_INGRESAR.Text = "Ingresar"
        Me.BTN_INGRESAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_INGRESAR.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.VentaRepuestos.My.Resources.Resources.contrasena_login
        Me.PictureBox2.Location = New System.Drawing.Point(3, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.VentaRepuestos.My.Resources.Resources.usuario
        Me.PictureBox1.Location = New System.Drawing.Point(3, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(246, 184)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RectangleShape2.CornerRadius = 10
        Me.RectangleShape2.Enabled = False
        Me.RectangleShape2.Location = New System.Drawing.Point(43, 55)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(190, 36)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RectangleShape1.CornerRadius = 10
        Me.RectangleShape1.Enabled = False
        Me.RectangleShape1.Location = New System.Drawing.Point(43, 13)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(190, 36)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(30, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[ Inicio de sesión ]"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(245, 269)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBL_REGISTRARSE)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TXT_USUARIO As TextBox
    Friend WithEvents TXT_CONTRASENA As TextBox
    Friend WithEvents BTN_INGRESAR As Button
    Friend WithEvents LBL_REGISTRARSE As LinkLabel
    Friend WithEvents LBL_OLVIDO As Label
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As PowerPacks.RectangleShape
    Friend WithEvents RectangleShape2 As PowerPacks.RectangleShape
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
End Class
