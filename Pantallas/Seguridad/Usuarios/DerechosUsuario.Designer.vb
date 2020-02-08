<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DerechosUsuario
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LVCon = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LVSin = New System.Windows.Forms.ListView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BTN_QUITAR = New System.Windows.Forms.Button()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.LVCon)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(383, 80)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(274, 348)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[ Con derecho ]"
        '
        'LVCon
        '
        Me.LVCon.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LVCon.HideSelection = False
        Me.LVCon.Location = New System.Drawing.Point(4, 22)
        Me.LVCon.Margin = New System.Windows.Forms.Padding(2)
        Me.LVCon.MultiSelect = False
        Me.LVCon.Name = "LVCon"
        Me.LVCon.Size = New System.Drawing.Size(266, 321)
        Me.LVCon.TabIndex = 0
        Me.LVCon.UseCompatibleStateImageBehavior = False
        Me.LVCon.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LVSin)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(3, 76)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(274, 352)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Sin derecho ]"
        '
        'LVSin
        '
        Me.LVSin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LVSin.HideSelection = False
        Me.LVSin.Location = New System.Drawing.Point(4, 25)
        Me.LVSin.Margin = New System.Windows.Forms.Padding(2)
        Me.LVSin.MultiSelect = False
        Me.LVSin.Name = "LVSin"
        Me.LVSin.Size = New System.Drawing.Size(266, 321)
        Me.LVSin.TabIndex = 0
        Me.LVSin.UseCompatibleStateImageBehavior = False
        Me.LVSin.View = System.Windows.Forms.View.Details
        '
        'Button2
        '
        Me.Button2.Image = Global.VentaRepuestos.My.Resources.Resources.izquierda
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(281, 242)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 43)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Todos"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.VentaRepuestos.My.Resources.Resources.derecha
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(281, 195)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 43)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Todos"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BTN_QUITAR
        '
        Me.BTN_QUITAR.Image = Global.VentaRepuestos.My.Resources.Resources.quitar
        Me.BTN_QUITAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_QUITAR.Location = New System.Drawing.Point(281, 289)
        Me.BTN_QUITAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_QUITAR.Name = "BTN_QUITAR"
        Me.BTN_QUITAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_QUITAR.TabIndex = 8
        Me.BTN_QUITAR.Text = "Quitar"
        Me.BTN_QUITAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_QUITAR.UseVisualStyleBackColor = True
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(281, 148)
        Me.BTN_AGREGAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_AGREGAR.TabIndex = 7
        Me.BTN_AGREGAR.Text = "Agregar"
        Me.BTN_AGREGAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_AGREGAR.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(558, 433)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 23
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'DerechosUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 479)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTN_QUITAR)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DerechosUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DerechosUsuario"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_QUITAR As Button
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LVCon As ListView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LVSin As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents BTN_SALIR As Button
End Class
