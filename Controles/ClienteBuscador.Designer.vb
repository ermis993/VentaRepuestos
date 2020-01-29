<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClienteBuscador
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.TXT_BUSCADOR = New System.Windows.Forms.TextBox()
        Me.CMBCLIENTE = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(3, 3)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(75, 23)
        Me.BTN_BUSCAR.TabIndex = 0
        Me.BTN_BUSCAR.Text = "Buscar"
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'TXT_BUSCADOR
        '
        Me.TXT_BUSCADOR.Location = New System.Drawing.Point(84, 4)
        Me.TXT_BUSCADOR.Name = "TXT_BUSCADOR"
        Me.TXT_BUSCADOR.Size = New System.Drawing.Size(112, 22)
        Me.TXT_BUSCADOR.TabIndex = 1
        '
        'CMBCLIENTE
        '
        Me.CMBCLIENTE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMBCLIENTE.FormattingEnabled = True
        Me.CMBCLIENTE.Location = New System.Drawing.Point(202, 3)
        Me.CMBCLIENTE.Name = "CMBCLIENTE"
        Me.CMBCLIENTE.Size = New System.Drawing.Size(375, 24)
        Me.CMBCLIENTE.TabIndex = 2
        '
        'ClienteBuscador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CMBCLIENTE)
        Me.Controls.Add(Me.TXT_BUSCADOR)
        Me.Controls.Add(Me.BTN_BUSCAR)
        Me.Name = "ClienteBuscador"
        Me.Size = New System.Drawing.Size(580, 31)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_BUSCAR As Button
    Friend WithEvents TXT_BUSCADOR As TextBox
    Friend WithEvents CMBCLIENTE As ComboBox
End Class
