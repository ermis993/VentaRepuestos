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
        Me.TXT_CEDULA = New System.Windows.Forms.MaskedTextBox()
        Me.LBL_NOMBRE = New System.Windows.Forms.Label()
        Me.TXT_NOMBRE = New System.Windows.Forms.TextBox()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.LBL_PROVINCIA = New System.Windows.Forms.Label()
        Me.CMB_PROVINCIA = New System.Windows.Forms.ComboBox()
        Me.LBL_CANTO = New System.Windows.Forms.Label()
        Me.CMB_CANTON = New System.Windows.Forms.ComboBox()
        Me.LBL_DISTRITO = New System.Windows.Forms.Label()
        Me.CMB_DISTRITO = New System.Windows.Forms.ComboBox()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.TAB_COMPANIA = New System.Windows.Forms.TabControl()
        Me.TAB_INFO = New System.Windows.Forms.TabPage()
        Me.CHK_FE = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB_INACTIVA = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVA = New System.Windows.Forms.RadioButton()
        Me.TXT_EMAIL = New System.Windows.Forms.TextBox()
        Me.LBL_EMAIL = New System.Windows.Forms.Label()
        Me.TAB_FE = New System.Windows.Forms.TabPage()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.TAB_COMPANIA.SuspendLayout()
        Me.TAB_INFO.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_CODIGO
        '
        Me.LBL_CODIGO.AutoSize = True
        Me.LBL_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CODIGO.Location = New System.Drawing.Point(37, 12)
        Me.LBL_CODIGO.Name = "LBL_CODIGO"
        Me.LBL_CODIGO.Size = New System.Drawing.Size(72, 18)
        Me.LBL_CODIGO.TabIndex = 1
        Me.LBL_CODIGO.Text = "Código :"
        '
        'LBL_TIPO_CEDULA
        '
        Me.LBL_TIPO_CEDULA.AutoSize = True
        Me.LBL_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TIPO_CEDULA.ForeColor = System.Drawing.Color.Black
        Me.LBL_TIPO_CEDULA.Location = New System.Drawing.Point(4, 71)
        Me.LBL_TIPO_CEDULA.Name = "LBL_TIPO_CEDULA"
        Me.LBL_TIPO_CEDULA.Size = New System.Drawing.Size(105, 18)
        Me.LBL_TIPO_CEDULA.TabIndex = 5
        Me.LBL_TIPO_CEDULA.Text = "Tipo cédula :"
        '
        'CMB_TIPO_CEDULA
        '
        Me.CMB_TIPO_CEDULA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CMB_TIPO_CEDULA.FormattingEnabled = True
        Me.CMB_TIPO_CEDULA.Items.AddRange(New Object() {"Física", "Jurídica", "Nite", "Dimex"})
        Me.CMB_TIPO_CEDULA.Location = New System.Drawing.Point(124, 67)
        Me.CMB_TIPO_CEDULA.Name = "CMB_TIPO_CEDULA"
        Me.CMB_TIPO_CEDULA.Size = New System.Drawing.Size(158, 24)
        Me.CMB_TIPO_CEDULA.TabIndex = 6
        '
        'LBL_CEDULA
        '
        Me.LBL_CEDULA.AutoSize = True
        Me.LBL_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CEDULA.ForeColor = System.Drawing.Color.Black
        Me.LBL_CEDULA.Location = New System.Drawing.Point(39, 99)
        Me.LBL_CEDULA.Name = "LBL_CEDULA"
        Me.LBL_CEDULA.Size = New System.Drawing.Size(70, 18)
        Me.LBL_CEDULA.TabIndex = 7
        Me.LBL_CEDULA.Text = "Cédula :"
        '
        'TXT_CEDULA
        '
        Me.TXT_CEDULA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_CEDULA.Location = New System.Drawing.Point(124, 97)
        Me.TXT_CEDULA.Name = "TXT_CEDULA"
        Me.TXT_CEDULA.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TXT_CEDULA.Size = New System.Drawing.Size(158, 22)
        Me.TXT_CEDULA.TabIndex = 8
        '
        'LBL_NOMBRE
        '
        Me.LBL_NOMBRE.AutoSize = True
        Me.LBL_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_NOMBRE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NOMBRE.Location = New System.Drawing.Point(31, 41)
        Me.LBL_NOMBRE.Name = "LBL_NOMBRE"
        Me.LBL_NOMBRE.Size = New System.Drawing.Size(78, 18)
        Me.LBL_NOMBRE.TabIndex = 3
        Me.LBL_NOMBRE.Text = "Nombre :"
        '
        'TXT_NOMBRE
        '
        Me.TXT_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_NOMBRE.Location = New System.Drawing.Point(124, 37)
        Me.TXT_NOMBRE.Multiline = True
        Me.TXT_NOMBRE.Name = "TXT_NOMBRE"
        Me.TXT_NOMBRE.Size = New System.Drawing.Size(342, 24)
        Me.TXT_NOMBRE.TabIndex = 4
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Enabled = False
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(124, 8)
        Me.TXT_CODIGO.Multiline = True
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(143, 24)
        Me.TXT_CODIGO.TabIndex = 2
        '
        'LBL_PROVINCIA
        '
        Me.LBL_PROVINCIA.AutoSize = True
        Me.LBL_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PROVINCIA.ForeColor = System.Drawing.Color.Black
        Me.LBL_PROVINCIA.Location = New System.Drawing.Point(21, 156)
        Me.LBL_PROVINCIA.Name = "LBL_PROVINCIA"
        Me.LBL_PROVINCIA.Size = New System.Drawing.Size(88, 18)
        Me.LBL_PROVINCIA.TabIndex = 11
        Me.LBL_PROVINCIA.Text = "Provincia :"
        '
        'CMB_PROVINCIA
        '
        Me.CMB_PROVINCIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_PROVINCIA.FormattingEnabled = True
        Me.CMB_PROVINCIA.Location = New System.Drawing.Point(124, 153)
        Me.CMB_PROVINCIA.Name = "CMB_PROVINCIA"
        Me.CMB_PROVINCIA.Size = New System.Drawing.Size(158, 24)
        Me.CMB_PROVINCIA.TabIndex = 12
        '
        'LBL_CANTO
        '
        Me.LBL_CANTO.AutoSize = True
        Me.LBL_CANTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CANTO.ForeColor = System.Drawing.Color.Black
        Me.LBL_CANTO.Location = New System.Drawing.Point(37, 185)
        Me.LBL_CANTO.Name = "LBL_CANTO"
        Me.LBL_CANTO.Size = New System.Drawing.Size(72, 18)
        Me.LBL_CANTO.TabIndex = 13
        Me.LBL_CANTO.Text = "Cantón :"
        '
        'CMB_CANTON
        '
        Me.CMB_CANTON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CANTON.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CMB_CANTON.FormattingEnabled = True
        Me.CMB_CANTON.Location = New System.Drawing.Point(124, 183)
        Me.CMB_CANTON.Name = "CMB_CANTON"
        Me.CMB_CANTON.Size = New System.Drawing.Size(158, 24)
        Me.CMB_CANTON.TabIndex = 14
        '
        'LBL_DISTRITO
        '
        Me.LBL_DISTRITO.AutoSize = True
        Me.LBL_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_DISTRITO.ForeColor = System.Drawing.Color.Black
        Me.LBL_DISTRITO.Location = New System.Drawing.Point(36, 216)
        Me.LBL_DISTRITO.Name = "LBL_DISTRITO"
        Me.LBL_DISTRITO.Size = New System.Drawing.Size(73, 18)
        Me.LBL_DISTRITO.TabIndex = 15
        Me.LBL_DISTRITO.Text = "Distrito :"
        '
        'CMB_DISTRITO
        '
        Me.CMB_DISTRITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DISTRITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CMB_DISTRITO.FormattingEnabled = True
        Me.CMB_DISTRITO.Location = New System.Drawing.Point(124, 213)
        Me.CMB_DISTRITO.Name = "CMB_DISTRITO"
        Me.CMB_DISTRITO.Size = New System.Drawing.Size(158, 24)
        Me.CMB_DISTRITO.TabIndex = 16
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.Location = New System.Drawing.Point(494, 332)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(56, 54)
        Me.BTN_SALIR.TabIndex = 14
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'TAB_COMPANIA
        '
        Me.TAB_COMPANIA.Controls.Add(Me.TAB_INFO)
        Me.TAB_COMPANIA.Controls.Add(Me.TAB_FE)
        Me.TAB_COMPANIA.Location = New System.Drawing.Point(3, 3)
        Me.TAB_COMPANIA.Name = "TAB_COMPANIA"
        Me.TAB_COMPANIA.SelectedIndex = 0
        Me.TAB_COMPANIA.Size = New System.Drawing.Size(561, 413)
        Me.TAB_COMPANIA.TabIndex = 15
        '
        'TAB_INFO
        '
        Me.TAB_INFO.Controls.Add(Me.BTN_ACEPTAR)
        Me.TAB_INFO.Controls.Add(Me.CHK_FE)
        Me.TAB_INFO.Controls.Add(Me.GroupBox1)
        Me.TAB_INFO.Controls.Add(Me.TXT_EMAIL)
        Me.TAB_INFO.Controls.Add(Me.LBL_EMAIL)
        Me.TAB_INFO.Controls.Add(Me.LBL_CODIGO)
        Me.TAB_INFO.Controls.Add(Me.BTN_SALIR)
        Me.TAB_INFO.Controls.Add(Me.LBL_TIPO_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.CMB_DISTRITO)
        Me.TAB_INFO.Controls.Add(Me.CMB_TIPO_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.LBL_DISTRITO)
        Me.TAB_INFO.Controls.Add(Me.LBL_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.CMB_CANTON)
        Me.TAB_INFO.Controls.Add(Me.TXT_CEDULA)
        Me.TAB_INFO.Controls.Add(Me.LBL_CANTO)
        Me.TAB_INFO.Controls.Add(Me.LBL_NOMBRE)
        Me.TAB_INFO.Controls.Add(Me.CMB_PROVINCIA)
        Me.TAB_INFO.Controls.Add(Me.TXT_NOMBRE)
        Me.TAB_INFO.Controls.Add(Me.LBL_PROVINCIA)
        Me.TAB_INFO.Controls.Add(Me.TXT_CODIGO)
        Me.TAB_INFO.Location = New System.Drawing.Point(4, 22)
        Me.TAB_INFO.Name = "TAB_INFO"
        Me.TAB_INFO.Padding = New System.Windows.Forms.Padding(3)
        Me.TAB_INFO.Size = New System.Drawing.Size(553, 387)
        Me.TAB_INFO.TabIndex = 0
        Me.TAB_INFO.Text = "Información general"
        Me.TAB_INFO.UseVisualStyleBackColor = True
        '
        'CHK_FE
        '
        Me.CHK_FE.AutoSize = True
        Me.CHK_FE.Checked = True
        Me.CHK_FE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_FE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_FE.Location = New System.Drawing.Point(124, 246)
        Me.CHK_FE.Name = "CHK_FE"
        Me.CHK_FE.Size = New System.Drawing.Size(194, 20)
        Me.CHK_FE.TabIndex = 17
        Me.CHK_FE.Text = "¿Es facturación electrónica?"
        Me.CHK_FE.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_INACTIVA)
        Me.GroupBox1.Controls.Add(Me.RB_ACTIVA)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox1.Location = New System.Drawing.Point(124, 277)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 48)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado"
        '
        'RB_INACTIVA
        '
        Me.RB_INACTIVA.AutoSize = True
        Me.RB_INACTIVA.Location = New System.Drawing.Point(263, 19)
        Me.RB_INACTIVA.Name = "RB_INACTIVA"
        Me.RB_INACTIVA.Size = New System.Drawing.Size(72, 20)
        Me.RB_INACTIVA.TabIndex = 19
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
        Me.RB_ACTIVA.TabIndex = 18
        Me.RB_ACTIVA.TabStop = True
        Me.RB_ACTIVA.Text = "Activa"
        Me.RB_ACTIVA.UseVisualStyleBackColor = True
        '
        'TXT_EMAIL
        '
        Me.TXT_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TXT_EMAIL.Location = New System.Drawing.Point(124, 124)
        Me.TXT_EMAIL.Multiline = True
        Me.TXT_EMAIL.Name = "TXT_EMAIL"
        Me.TXT_EMAIL.Size = New System.Drawing.Size(342, 24)
        Me.TXT_EMAIL.TabIndex = 10
        '
        'LBL_EMAIL
        '
        Me.LBL_EMAIL.AutoSize = True
        Me.LBL_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_EMAIL.ForeColor = System.Drawing.Color.Black
        Me.LBL_EMAIL.Location = New System.Drawing.Point(49, 127)
        Me.LBL_EMAIL.Name = "LBL_EMAIL"
        Me.LBL_EMAIL.Size = New System.Drawing.Size(60, 18)
        Me.LBL_EMAIL.TabIndex = 9
        Me.LBL_EMAIL.Text = "Email :"
        '
        'TAB_FE
        '
        Me.TAB_FE.Location = New System.Drawing.Point(4, 22)
        Me.TAB_FE.Name = "TAB_FE"
        Me.TAB_FE.Padding = New System.Windows.Forms.Padding(3)
        Me.TAB_FE.Size = New System.Drawing.Size(564, 392)
        Me.TAB_FE.TabIndex = 1
        Me.TAB_FE.Text = "Facturación Electrónica"
        Me.TAB_FE.UseVisualStyleBackColor = True
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.Image = Global.VentaRepuestos.My.Resources.Resources.guardar
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(422, 332)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(56, 54)
        Me.BTN_ACEPTAR.TabIndex = 19
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = True
        '
        'LBL_CANTON
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(565, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.TAB_COMPANIA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "LBL_CANTON"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TAB_COMPANIA.ResumeLayout(False)
        Me.TAB_INFO.ResumeLayout(False)
        Me.TAB_INFO.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBL_CODIGO As Label
    Friend WithEvents LBL_TIPO_CEDULA As Label
    Friend WithEvents CMB_TIPO_CEDULA As ComboBox
    Friend WithEvents LBL_CEDULA As Label
    Friend WithEvents TXT_CEDULA As MaskedTextBox
    Friend WithEvents LBL_NOMBRE As Label
    Friend WithEvents TXT_NOMBRE As TextBox
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents LBL_PROVINCIA As Label
    Friend WithEvents CMB_PROVINCIA As ComboBox
    Friend WithEvents LBL_CANTO As Label
    Friend WithEvents CMB_CANTON As ComboBox
    Friend WithEvents LBL_DISTRITO As Label
    Friend WithEvents CMB_DISTRITO As ComboBox
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents TAB_COMPANIA As TabControl
    Friend WithEvents TAB_INFO As TabPage
    Friend WithEvents TAB_FE As TabPage
    Friend WithEvents LBL_EMAIL As Label
    Friend WithEvents TXT_EMAIL As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RB_INACTIVA As RadioButton
    Friend WithEvents RB_ACTIVA As RadioButton
    Friend WithEvents CHK_FE As CheckBox
    Friend WithEvents BTN_ACEPTAR As Button
End Class
