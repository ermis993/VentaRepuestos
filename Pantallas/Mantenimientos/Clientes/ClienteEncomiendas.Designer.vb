<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClienteEncomiendas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClienteEncomiendas))
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.Cliente = New VentaRepuestos.Buscador()
        Me.DTP_FINAL = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTP_INICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CMB_SUCURSAL = New System.Windows.Forms.ComboBox()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.BTN_GENERAR = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(608, 424)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 4
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'Cliente
        '
        Me.Cliente.CAMPO_FILTRAR = Nothing
        Me.Cliente.CODIGO = Nothing
        Me.Cliente.DESCRIPCION = Nothing
        Me.Cliente.FILTRAR_POR_COMPANIA = True
        Me.Cliente.Location = New System.Drawing.Point(5, 18)
        Me.Cliente.Margin = New System.Windows.Forms.Padding(2)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OTROS_CAMP0S = Nothing
        Me.Cliente.PANTALLA = Nothing
        Me.Cliente.Size = New System.Drawing.Size(451, 32)
        Me.Cliente.TabIndex = 0
        Me.Cliente.TABLA_BUSCAR = "CLIENTE"
        Me.Cliente.VALOR = ""
        Me.Cliente.VALOR_DESCRIPCION = Nothing
        '
        'DTP_FINAL
        '
        Me.DTP_FINAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.DTP_FINAL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FINAL.Location = New System.Drawing.Point(99, 54)
        Me.DTP_FINAL.Name = "DTP_FINAL"
        Me.DTP_FINAL.Size = New System.Drawing.Size(96, 24)
        Me.DTP_FINAL.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(14, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Fecha final"
        '
        'DTP_INICIO
        '
        Me.DTP_INICIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.DTP_INICIO.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_INICIO.Location = New System.Drawing.Point(99, 24)
        Me.DTP_INICIO.Name = "DTP_INICIO"
        Me.DTP_INICIO.Size = New System.Drawing.Size(96, 24)
        Me.DTP_INICIO.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label4.Location = New System.Drawing.Point(6, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha inicio"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTN_GENERAR)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DTP_FINAL)
        Me.GroupBox1.Controls.Add(Me.DTP_INICIO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(500, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 133)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Rango de fechas ]"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CMB_SUCURSAL)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(484, 67)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Sucursal ] "
        '
        'CMB_SUCURSAL
        '
        Me.CMB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_SUCURSAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_SUCURSAL.FormattingEnabled = True
        Me.CMB_SUCURSAL.Location = New System.Drawing.Point(9, 27)
        Me.CMB_SUCURSAL.Margin = New System.Windows.Forms.Padding(2)
        Me.CMB_SUCURSAL.Name = "CMB_SUCURSAL"
        Me.CMB_SUCURSAL.Size = New System.Drawing.Size(447, 26)
        Me.CMB_SUCURSAL.TabIndex = 0
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(12, 142)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(695, 276)
        Me.GRID.TabIndex = 3
        '
        'BTN_GENERAR
        '
        Me.BTN_GENERAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_GENERAR.Image = Global.VentaRepuestos.My.Resources.Resources.generar
        Me.BTN_GENERAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_GENERAR.Location = New System.Drawing.Point(57, 83)
        Me.BTN_GENERAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_GENERAR.Name = "BTN_GENERAR"
        Me.BTN_GENERAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_GENERAR.TabIndex = 4
        Me.BTN_GENERAR.Text = "Generar"
        Me.BTN_GENERAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_GENERAR.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Cliente)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(484, 59)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[ Cliente ]"
        '
        'ClienteEncomiendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 470)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ClienteEncomiendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Envios realizados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents Cliente As Buscador
    Friend WithEvents DTP_FINAL As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents DTP_INICIO As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CMB_SUCURSAL As ComboBox
    Friend WithEvents GRID As DataGridView
    Friend WithEvents BTN_GENERAR As Button
    Friend WithEvents GroupBox3 As GroupBox
End Class
