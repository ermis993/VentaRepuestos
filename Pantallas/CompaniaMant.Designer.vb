<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LBL_CANTON
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
        Me.LBL_CODIGO = New System.Windows.Forms.Label()
        Me.LBL_TIPO_CEDULA = New System.Windows.Forms.Label()
        Me.CMB_TIPO_CEDULA = New System.Windows.Forms.ComboBox()
        Me.LBL_CEDULA = New System.Windows.Forms.Label()
        Me.CEDULA = New System.Windows.Forms.MaskedTextBox()
        Me.LBL_NOMBRE = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.LBL_PROVINCIA = New System.Windows.Forms.Label()
        Me.CMB_PROVINCIA = New System.Windows.Forms.ComboBox()
        Me.L = New System.Windows.Forms.Label()
        Me.CMB_CANTON = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMB_DISTRITO = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LBL_CODIGO
        '
        Me.LBL_CODIGO.AutoSize = True
        Me.LBL_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CODIGO.Location = New System.Drawing.Point(12, 9)
        Me.LBL_CODIGO.Name = "LBL_CODIGO"
        Me.LBL_CODIGO.Size = New System.Drawing.Size(72, 18)
        Me.LBL_CODIGO.TabIndex = 0
        Me.LBL_CODIGO.Text = "Código :"
        '
        'LBL_TIPO_CEDULA
        '
        Me.LBL_TIPO_CEDULA.AutoSize = True
        Me.LBL_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TIPO_CEDULA.Location = New System.Drawing.Point(10, 87)
        Me.LBL_TIPO_CEDULA.Name = "LBL_TIPO_CEDULA"
        Me.LBL_TIPO_CEDULA.Size = New System.Drawing.Size(105, 18)
        Me.LBL_TIPO_CEDULA.TabIndex = 1
        Me.LBL_TIPO_CEDULA.Text = "Tipo cédula :"
        '
        'CMB_TIPO_CEDULA
        '
        Me.CMB_TIPO_CEDULA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TIPO_CEDULA.FormattingEnabled = True
        Me.CMB_TIPO_CEDULA.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_TIPO_CEDULA.Location = New System.Drawing.Point(142, 84)
        Me.CMB_TIPO_CEDULA.Name = "CMB_TIPO_CEDULA"
        Me.CMB_TIPO_CEDULA.Size = New System.Drawing.Size(143, 26)
        Me.CMB_TIPO_CEDULA.TabIndex = 2
        '
        'LBL_CEDULA
        '
        Me.LBL_CEDULA.AutoSize = True
        Me.LBL_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CEDULA.Location = New System.Drawing.Point(298, 87)
        Me.LBL_CEDULA.Name = "LBL_CEDULA"
        Me.LBL_CEDULA.Size = New System.Drawing.Size(70, 18)
        Me.LBL_CEDULA.TabIndex = 3
        Me.LBL_CEDULA.Text = "Cédula :"
        '
        'CEDULA
        '
        Me.CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEDULA.Location = New System.Drawing.Point(387, 84)
        Me.CEDULA.Name = "CEDULA"
        Me.CEDULA.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.CEDULA.Size = New System.Drawing.Size(161, 24)
        Me.CEDULA.TabIndex = 4
        '
        'LBL_NOMBRE
        '
        Me.LBL_NOMBRE.AutoSize = True
        Me.LBL_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_NOMBRE.Location = New System.Drawing.Point(12, 49)
        Me.LBL_NOMBRE.Name = "LBL_NOMBRE"
        Me.LBL_NOMBRE.Size = New System.Drawing.Size(78, 18)
        Me.LBL_NOMBRE.TabIndex = 5
        Me.LBL_NOMBRE.Text = "Nombre :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(142, 43)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(406, 24)
        Me.TextBox1.TabIndex = 6
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(142, 10)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(143, 24)
        Me.TextBox2.TabIndex = 7
        '
        'LBL_PROVINCIA
        '
        Me.LBL_PROVINCIA.AutoSize = True
        Me.LBL_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PROVINCIA.Location = New System.Drawing.Point(12, 140)
        Me.LBL_PROVINCIA.Name = "LBL_PROVINCIA"
        Me.LBL_PROVINCIA.Size = New System.Drawing.Size(88, 18)
        Me.LBL_PROVINCIA.TabIndex = 8
        Me.LBL_PROVINCIA.Text = "Provincia :"
        '
        'CMB_PROVINCIA
        '
        Me.CMB_PROVINCIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_PROVINCIA.FormattingEnabled = True
        Me.CMB_PROVINCIA.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_PROVINCIA.Location = New System.Drawing.Point(142, 137)
        Me.CMB_PROVINCIA.Name = "CMB_PROVINCIA"
        Me.CMB_PROVINCIA.Size = New System.Drawing.Size(143, 26)
        Me.CMB_PROVINCIA.TabIndex = 9
        '
        'L
        '
        Me.L.AutoSize = True
        Me.L.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L.Location = New System.Drawing.Point(12, 191)
        Me.L.Name = "L"
        Me.L.Size = New System.Drawing.Size(72, 18)
        Me.L.TabIndex = 10
        Me.L.Text = "Cantón :"
        '
        'CMB_CANTON
        '
        Me.CMB_CANTON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CANTON.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CANTON.FormattingEnabled = True
        Me.CMB_CANTON.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_CANTON.Location = New System.Drawing.Point(142, 188)
        Me.CMB_CANTON.Name = "CMB_CANTON"
        Me.CMB_CANTON.Size = New System.Drawing.Size(143, 26)
        Me.CMB_CANTON.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(298, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Distrito :"
        '
        'CMB_DISTRITO
        '
        Me.CMB_DISTRITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_DISTRITO.FormattingEnabled = True
        Me.CMB_DISTRITO.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_DISTRITO.Location = New System.Drawing.Point(387, 137)
        Me.CMB_DISTRITO.Name = "CMB_DISTRITO"
        Me.CMB_DISTRITO.Size = New System.Drawing.Size(161, 26)
        Me.CMB_DISTRITO.TabIndex = 13
        '
        'LBL_CANTON
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.CMB_DISTRITO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CMB_CANTON)
        Me.Controls.Add(Me.L)
        Me.Controls.Add(Me.CMB_PROVINCIA)
        Me.Controls.Add(Me.LBL_PROVINCIA)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LBL_NOMBRE)
        Me.Controls.Add(Me.CEDULA)
        Me.Controls.Add(Me.LBL_CEDULA)
        Me.Controls.Add(Me.CMB_TIPO_CEDULA)
        Me.Controls.Add(Me.LBL_TIPO_CEDULA)
        Me.Controls.Add(Me.LBL_CODIGO)
        Me.Name = "LBL_CANTON"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBL_CODIGO As Label
    Friend WithEvents LBL_TIPO_CEDULA As Label
    Friend WithEvents CMB_TIPO_CEDULA As ComboBox
    Friend WithEvents LBL_CEDULA As Label
    Friend WithEvents CEDULA As MaskedTextBox
    Friend WithEvents LBL_NOMBRE As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents LBL_PROVINCIA As Label
    Friend WithEvents CMB_PROVINCIA As ComboBox
    Friend WithEvents L As Label
    Friend WithEvents CMB_CANTON As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CMB_DISTRITO As ComboBox
End Class
