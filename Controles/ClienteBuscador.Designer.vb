<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClienteBuscador
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.CMB = New System.Windows.Forms.ComboBox()
        Me.TXT_BUSCADOR = New System.Windows.Forms.TextBox()
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CMB
        '
        Me.CMB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB.FormattingEnabled = True
        Me.CMB.Location = New System.Drawing.Point(148, 2)
        Me.CMB.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB.Name = "CMB"
        Me.CMB.Size = New System.Drawing.Size(268, 24)
        Me.CMB.TabIndex = 5
        '
        'TXT_BUSCADOR
        '
        Me.TXT_BUSCADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_BUSCADOR.Location = New System.Drawing.Point(60, 2)
        Me.TXT_BUSCADOR.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_BUSCADOR.Name = "TXT_BUSCADOR"
        Me.TXT_BUSCADOR.Size = New System.Drawing.Size(85, 24)
        Me.TXT_BUSCADOR.TabIndex = 4
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(3, 1)
        Me.BTN_BUSCAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(56, 26)
        Me.BTN_BUSCAR.TabIndex = 3
        Me.BTN_BUSCAR.Text = "Buscar"
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(421, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 26)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "B"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ClienteBuscador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CMB)
        Me.Controls.Add(Me.TXT_BUSCADOR)
        Me.Controls.Add(Me.BTN_BUSCAR)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ClienteBuscador"
        Me.Size = New System.Drawing.Size(451, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CMB As ComboBox
    Friend WithEvents TXT_BUSCADOR As TextBox
    Friend WithEvents BTN_BUSCAR As Button
    Friend WithEvents Button1 As Button
End Class
