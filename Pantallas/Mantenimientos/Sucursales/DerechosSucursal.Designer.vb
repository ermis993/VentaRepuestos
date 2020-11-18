<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DerechosSucursal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DerechosSucursal))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LVCon = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LVSin = New System.Windows.Forms.ListView()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_QUITAR = New System.Windows.Forms.Button()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox3.Controls.Add(Me.LVCon)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(342, 11)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(224, 299)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[ Con derecho ]"
        '
        'LVCon
        '
        Me.LVCon.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LVCon.HideSelection = False
        Me.LVCon.Location = New System.Drawing.Point(4, 23)
        Me.LVCon.Margin = New System.Windows.Forms.Padding(2)
        Me.LVCon.MultiSelect = False
        Me.LVCon.Name = "LVCon"
        Me.LVCon.Size = New System.Drawing.Size(216, 276)
        Me.LVCon.TabIndex = 0
        Me.LVCon.UseCompatibleStateImageBehavior = False
        Me.LVCon.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LVSin)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(8, 11)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(224, 299)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Sin derecho ]"
        '
        'LVSin
        '
        Me.LVSin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LVSin.HideSelection = False
        Me.LVSin.Location = New System.Drawing.Point(4, 23)
        Me.LVSin.Margin = New System.Windows.Forms.Padding(2)
        Me.LVSin.MultiSelect = False
        Me.LVSin.Name = "LVSin"
        Me.LVSin.Size = New System.Drawing.Size(216, 272)
        Me.LVSin.TabIndex = 0
        Me.LVSin.UseCompatibleStateImageBehavior = False
        Me.LVSin.View = System.Windows.Forms.View.Details
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(467, 315)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 48)
        Me.BTN_SALIR.TabIndex = 11
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_QUITAR
        '
        Me.BTN_QUITAR.Image = Global.VentaRepuestos.My.Resources.Resources.Left
        Me.BTN_QUITAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_QUITAR.Location = New System.Drawing.Point(239, 81)
        Me.BTN_QUITAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_QUITAR.Name = "BTN_QUITAR"
        Me.BTN_QUITAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_QUITAR.TabIndex = 10
        Me.BTN_QUITAR.Text = "Quitar"
        Me.BTN_QUITAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_QUITAR.UseVisualStyleBackColor = True
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.Right
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(239, 34)
        Me.BTN_AGREGAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_AGREGAR.TabIndex = 9
        Me.BTN_AGREGAR.Text = "Agregar"
        Me.BTN_AGREGAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_AGREGAR.UseVisualStyleBackColor = True
        '
        'DerechosSucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_QUITAR)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DerechosSucursal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Derechos sucursal"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_QUITAR As Button
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LVCon As ListView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LVSin As ListView
End Class
