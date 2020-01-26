<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OlvidoContrasena
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTN_ENVIAR = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_DESTINATARIO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTN_ENVIAR)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXT_DESTINATARIO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 273)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información usuario ]"
        '
        'BTN_ENVIAR
        '
        Me.BTN_ENVIAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.BTN_ENVIAR.Image = Global.VentaRepuestos.My.Resources.Resources.enviar
        Me.BTN_ENVIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ENVIAR.Location = New System.Drawing.Point(315, 96)
        Me.BTN_ENVIAR.Name = "BTN_ENVIAR"
        Me.BTN_ENVIAR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_ENVIAR.TabIndex = 2
        Me.BTN_ENVIAR.Text = "Enviar"
        Me.BTN_ENVIAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ENVIAR.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(676, 48)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "[ Una vez ingresado el correo en un lapso de 5 min cuando máximo debería de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "lleg" &
    "arle un código verificador ]"
        '
        'TXT_DESTINATARIO
        '
        Me.TXT_DESTINATARIO.Location = New System.Drawing.Point(27, 107)
        Me.TXT_DESTINATARIO.Name = "TXT_DESTINATARIO"
        Me.TXT_DESTINATARIO.Size = New System.Drawing.Size(260, 29)
        Me.TXT_DESTINATARIO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(706, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Por favor ingrese el email el cual fue ligado al usuario en el momento que el mis" &
    "mo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "fue creado: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(656, 385)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_SALIR.TabIndex = 1
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'OlvidoContrasena
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OlvidoContrasena"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recuperacion de contraseña"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_DESTINATARIO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_ENVIAR As Button
    Friend WithEvents BTN_SALIR As Button
End Class
