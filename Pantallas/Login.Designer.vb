﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.LB_USUARIO = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_INGRESAR = New System.Windows.Forms.Button()
        Me.LBL_REGISTRARSE = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TXT_USUARIO
        '
        Me.TXT_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_USUARIO.Location = New System.Drawing.Point(36, 187)
        Me.TXT_USUARIO.Multiline = True
        Me.TXT_USUARIO.Name = "TXT_USUARIO"
        Me.TXT_USUARIO.Size = New System.Drawing.Size(310, 22)
        Me.TXT_USUARIO.TabIndex = 4
        '
        'TXT_CONTRASENA
        '
        Me.TXT_CONTRASENA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TXT_CONTRASENA.Location = New System.Drawing.Point(36, 275)
        Me.TXT_CONTRASENA.Multiline = True
        Me.TXT_CONTRASENA.Name = "TXT_CONTRASENA"
        Me.TXT_CONTRASENA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_CONTRASENA.Size = New System.Drawing.Size(310, 22)
        Me.TXT_CONTRASENA.TabIndex = 5
        '
        'LB_USUARIO
        '
        Me.LB_USUARIO.AutoSize = True
        Me.LB_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.LB_USUARIO.ForeColor = System.Drawing.Color.Silver
        Me.LB_USUARIO.Location = New System.Drawing.Point(33, 150)
        Me.LB_USUARIO.Name = "LB_USUARIO"
        Me.LB_USUARIO.Size = New System.Drawing.Size(77, 18)
        Me.LB_USUARIO.TabIndex = 6
        Me.LB_USUARIO.Text = "Usuario :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(33, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Contraseña :"
        '
        'BTN_INGRESAR
        '
        Me.BTN_INGRESAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BTN_INGRESAR.FlatAppearance.BorderSize = 0
        Me.BTN_INGRESAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_INGRESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.BTN_INGRESAR.ForeColor = System.Drawing.Color.Gainsboro
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(36, 343)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(310, 37)
        Me.BTN_INGRESAR.TabIndex = 8
        Me.BTN_INGRESAR.Text = "Ingresar"
        Me.BTN_INGRESAR.UseVisualStyleBackColor = False
        '
        'LBL_REGISTRARSE
        '
        Me.LBL_REGISTRARSE.AutoSize = True
        Me.LBL_REGISTRARSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_REGISTRARSE.LinkColor = System.Drawing.Color.Silver
        Me.LBL_REGISTRARSE.Location = New System.Drawing.Point(33, 416)
        Me.LBL_REGISTRARSE.Name = "LBL_REGISTRARSE"
        Me.LBL_REGISTRARSE.Size = New System.Drawing.Size(125, 18)
        Me.LBL_REGISTRARSE.TabIndex = 9
        Me.LBL_REGISTRARSE.TabStop = True
        Me.LBL_REGISTRARSE.Text = "Registrese aquí"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 40)
        Me.Panel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 511)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(390, 15)
        Me.Panel2.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(108, 472)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "¿Olvidó su contraseña?"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(390, 526)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
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
    Friend WithEvents LB_USUARIO As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_INGRESAR As Button
    Friend WithEvents LBL_REGISTRARSE As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
End Class