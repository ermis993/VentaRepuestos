﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVA = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVA = New System.Windows.Forms.RadioButton()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TXT_ANCHO_PAPEL = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXT_RUTA_TIQUETE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT_TELEFONO2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(376, 305)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 2
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'LBL_CODIGO
        '
        Me.LBL_CODIGO.AutoSize = True
        Me.LBL_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CODIGO.Location = New System.Drawing.Point(24, 9)
        Me.LBL_CODIGO.Name = "LBL_CODIGO"
        Me.LBL_CODIGO.Size = New System.Drawing.Size(64, 18)
        Me.LBL_CODIGO.TabIndex = 0
        Me.LBL_CODIGO.Text = "Código :"
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Enabled = False
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CODIGO.Location = New System.Drawing.Point(95, 6)
        Me.TXT_CODIGO.Multiline = True
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(143, 24)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre :"
        '
        'TXT_NOMBRE
        '
        Me.TXT_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_NOMBRE.Location = New System.Drawing.Point(94, 37)
        Me.TXT_NOMBRE.MaxLength = 100
        Me.TXT_NOMBRE.Multiline = True
        Me.TXT_NOMBRE.Name = "TXT_NOMBRE"
        Me.TXT_NOMBRE.Size = New System.Drawing.Size(363, 24)
        Me.TXT_NOMBRE.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Dirección :"
        '
        'TXT_DIRECCION
        '
        Me.TXT_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_DIRECCION.Location = New System.Drawing.Point(94, 69)
        Me.TXT_DIRECCION.MaxLength = 250
        Me.TXT_DIRECCION.Multiline = True
        Me.TXT_DIRECCION.Name = "TXT_DIRECCION"
        Me.TXT_DIRECCION.Size = New System.Drawing.Size(363, 79)
        Me.TXT_DIRECCION.TabIndex = 5
        '
        'TXT_TELEFONO
        '
        Me.TXT_TELEFONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_TELEFONO.Location = New System.Drawing.Point(94, 151)
        Me.TXT_TELEFONO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_TELEFONO.MaxLength = 19
        Me.TXT_TELEFONO.Name = "TXT_TELEFONO"
        Me.TXT_TELEFONO.Size = New System.Drawing.Size(141, 22)
        Me.TXT_TELEFONO.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 153)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Teléfono:"
        '
        'TXT_CORREO
        '
        Me.TXT_CORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_CORREO.Location = New System.Drawing.Point(94, 179)
        Me.TXT_CORREO.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_CORREO.MaxLength = 150
        Me.TXT_CORREO.Name = "TXT_CORREO"
        Me.TXT_CORREO.Size = New System.Drawing.Size(363, 22)
        Me.TXT_CORREO.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(29, 181)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 18)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Correo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RB_INACTIVA)
        Me.GroupBox2.Controls.Add(Me.RB_ACTIVA)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox2.Location = New System.Drawing.Point(94, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 48)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado"
        '
        'RB_INACTIVA
        '
        Me.RB_INACTIVA.AutoSize = True
        Me.RB_INACTIVA.Location = New System.Drawing.Point(101, 19)
        Me.RB_INACTIVA.Name = "RB_INACTIVA"
        Me.RB_INACTIVA.Size = New System.Drawing.Size(72, 20)
        Me.RB_INACTIVA.TabIndex = 1
        Me.RB_INACTIVA.TabStop = True
        Me.RB_INACTIVA.Text = "Inactiva"
        Me.RB_INACTIVA.UseVisualStyleBackColor = True
        '
        'RB_ACTIVA
        '
        Me.RB_ACTIVA.AutoSize = True
        Me.RB_ACTIVA.Checked = True
        Me.RB_ACTIVA.Location = New System.Drawing.Point(15, 19)
        Me.RB_ACTIVA.Name = "RB_ACTIVA"
        Me.RB_ACTIVA.Size = New System.Drawing.Size(63, 20)
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
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(276, 305)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 1
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(476, 297)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TXT_TELEFONO2)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.TXT_CORREO)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TXT_CODIGO)
        Me.TabPage1.Controls.Add(Me.LBL_CODIGO)
        Me.TabPage1.Controls.Add(Me.TXT_TELEFONO)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TXT_NOMBRE)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TXT_DIRECCION)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(468, 271)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "[ Información general ]"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TXT_ANCHO_PAPEL)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.TXT_RUTA_TIQUETE)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(468, 271)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "[ Impresión ]"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TXT_ANCHO_PAPEL
        '
        Me.TXT_ANCHO_PAPEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_ANCHO_PAPEL.Location = New System.Drawing.Point(179, 37)
        Me.TXT_ANCHO_PAPEL.MaxLength = 3
        Me.TXT_ANCHO_PAPEL.Name = "TXT_ANCHO_PAPEL"
        Me.TXT_ANCHO_PAPEL.Size = New System.Drawing.Size(100, 24)
        Me.TXT_ANCHO_PAPEL.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label6.Location = New System.Drawing.Point(28, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 18)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Ancho papel tiquete :"
        '
        'TXT_RUTA_TIQUETE
        '
        Me.TXT_RUTA_TIQUETE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_RUTA_TIQUETE.Location = New System.Drawing.Point(179, 10)
        Me.TXT_RUTA_TIQUETE.Name = "TXT_RUTA_TIQUETE"
        Me.TXT_RUTA_TIQUETE.Size = New System.Drawing.Size(282, 24)
        Me.TXT_RUTA_TIQUETE.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(9, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ruta impresión tiquete :"
        '
        'TXT_TELEFONO2
        '
        Me.TXT_TELEFONO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TXT_TELEFONO2.Location = New System.Drawing.Point(315, 151)
        Me.TXT_TELEFONO2.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_TELEFONO2.MaxLength = 19
        Me.TXT_TELEFONO2.Name = "TXT_TELEFONO2"
        Me.TXT_TELEFONO2.Size = New System.Drawing.Size(141, 22)
        Me.TXT_TELEFONO2.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(239, 153)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 18)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Teléfono:"
        '
        'SucursalMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(476, 350)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SucursalMant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucursal"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RB_INACTIVA As RadioButton
    Friend WithEvents RB_ACTIVA As RadioButton
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents TXT_RUTA_TIQUETE As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXT_ANCHO_PAPEL As TextBox
    Friend WithEvents TXT_TELEFONO2 As TextBox
    Friend WithEvents Label7 As Label
End Class
