<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CXP_Facturacion
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPFINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTPINICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Estado = New System.Windows.Forms.GroupBox()
        Me.RB_TODOS = New System.Windows.Forms.RadioButton()
        Me.RB_INACTIVOS = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVOS = New System.Windows.Forms.RadioButton()
        Me.Filtro = New VentaRepuestos.Filtro()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_TIPO_FACT = New System.Windows.Forms.ComboBox()
        Me.BTN_PAGOS = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_FACTURAR = New System.Windows.Forms.Button()
        Me.BTN_REPORTES = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.Estado.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPFINAL)
        Me.GroupBox2.Controls.Add(Me.DTPINICIO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(557, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 54)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fechas"
        '
        'DTPFINAL
        '
        Me.DTPFINAL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFINAL.Location = New System.Drawing.Point(42, 31)
        Me.DTPFINAL.Name = "DTPFINAL"
        Me.DTPFINAL.Size = New System.Drawing.Size(98, 20)
        Me.DTPFINAL.TabIndex = 3
        '
        'DTPINICIO
        '
        Me.DTPINICIO.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPINICIO.Location = New System.Drawing.Point(42, 13)
        Me.DTPINICIO.Name = "DTPINICIO"
        Me.DTPINICIO.Size = New System.Drawing.Size(98, 20)
        Me.DTPINICIO.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Al :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Del :"
        '
        'Estado
        '
        Me.Estado.Controls.Add(Me.RB_TODOS)
        Me.Estado.Controls.Add(Me.RB_INACTIVOS)
        Me.Estado.Controls.Add(Me.RB_ACTIVOS)
        Me.Estado.Location = New System.Drawing.Point(712, 3)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(146, 54)
        Me.Estado.TabIndex = 5
        Me.Estado.TabStop = False
        Me.Estado.Text = "Estado"
        '
        'RB_TODOS
        '
        Me.RB_TODOS.AutoSize = True
        Me.RB_TODOS.Location = New System.Drawing.Point(85, 11)
        Me.RB_TODOS.Name = "RB_TODOS"
        Me.RB_TODOS.Size = New System.Drawing.Size(55, 17)
        Me.RB_TODOS.TabIndex = 2
        Me.RB_TODOS.Text = "Todos"
        Me.RB_TODOS.UseVisualStyleBackColor = True
        '
        'RB_INACTIVOS
        '
        Me.RB_INACTIVOS.AutoSize = True
        Me.RB_INACTIVOS.Location = New System.Drawing.Point(7, 33)
        Me.RB_INACTIVOS.Name = "RB_INACTIVOS"
        Me.RB_INACTIVOS.Size = New System.Drawing.Size(68, 17)
        Me.RB_INACTIVOS.TabIndex = 1
        Me.RB_INACTIVOS.TabStop = True
        Me.RB_INACTIVOS.Text = "Inactivos"
        Me.RB_INACTIVOS.UseVisualStyleBackColor = True
        '
        'RB_ACTIVOS
        '
        Me.RB_ACTIVOS.AutoSize = True
        Me.RB_ACTIVOS.Checked = True
        Me.RB_ACTIVOS.Location = New System.Drawing.Point(7, 13)
        Me.RB_ACTIVOS.Name = "RB_ACTIVOS"
        Me.RB_ACTIVOS.Size = New System.Drawing.Size(60, 17)
        Me.RB_ACTIVOS.TabIndex = 0
        Me.RB_ACTIVOS.TabStop = True
        Me.RB_ACTIVOS.Text = "Activos"
        Me.RB_ACTIVOS.UseVisualStyleBackColor = True
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(1, 57)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(306, 29)
        Me.Filtro.TabIndex = 6
        Me.Filtro.VALOR = ""
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToResizeColumns = False
        Me.GRID.AllowUserToResizeRows = False
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(1, 92)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(857, 374)
        Me.GRID.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_TIPO_FACT)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 471)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(116, 43)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo factura"
        '
        'CMB_TIPO_FACT
        '
        Me.CMB_TIPO_FACT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO_FACT.FormattingEnabled = True
        Me.CMB_TIPO_FACT.Items.AddRange(New Object() {"Documentos", "Pre-facturas"})
        Me.CMB_TIPO_FACT.Location = New System.Drawing.Point(6, 16)
        Me.CMB_TIPO_FACT.Name = "CMB_TIPO_FACT"
        Me.CMB_TIPO_FACT.Size = New System.Drawing.Size(103, 21)
        Me.CMB_TIPO_FACT.TabIndex = 0
        '
        'BTN_PAGOS
        '
        Me.BTN_PAGOS.Image = Global.VentaRepuestos.My.Resources.Resources.Pagos
        Me.BTN_PAGOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_PAGOS.Location = New System.Drawing.Point(100, 9)
        Me.BTN_PAGOS.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_PAGOS.Name = "BTN_PAGOS"
        Me.BTN_PAGOS.Size = New System.Drawing.Size(99, 43)
        Me.BTN_PAGOS.TabIndex = 10
        Me.BTN_PAGOS.Text = "Pagos"
        Me.BTN_PAGOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_PAGOS.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(759, 471)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 9
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'BTN_REFRESCAR
        '
        Me.BTN_REFRESCAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_REFRESCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_REFRESCAR.Image = Global.VentaRepuestos.My.Resources.Resources.refrescar
        Me.BTN_REFRESCAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(199, 9)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 3
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = False
        '
        'BTN_FACTURAR
        '
        Me.BTN_FACTURAR.Image = Global.VentaRepuestos.My.Resources.Resources.facturar
        Me.BTN_FACTURAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_FACTURAR.Location = New System.Drawing.Point(1, 9)
        Me.BTN_FACTURAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_FACTURAR.Name = "BTN_FACTURAR"
        Me.BTN_FACTURAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_FACTURAR.TabIndex = 0
        Me.BTN_FACTURAR.Text = "Facturas"
        Me.BTN_FACTURAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_FACTURAR.UseVisualStyleBackColor = True
        '
        'BTN_REPORTES
        '
        Me.BTN_REPORTES.Image = Global.VentaRepuestos.My.Resources.Resources.reportes
        Me.BTN_REPORTES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_REPORTES.Location = New System.Drawing.Point(453, 9)
        Me.BTN_REPORTES.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_REPORTES.Name = "BTN_REPORTES"
        Me.BTN_REPORTES.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REPORTES.TabIndex = 11
        Me.BTN_REPORTES.Text = "Reportes"
        Me.BTN_REPORTES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REPORTES.UseVisualStyleBackColor = True
        '
        'CXP_Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(862, 518)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_REPORTES)
        Me.Controls.Add(Me.BTN_PAGOS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.Filtro)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.BTN_FACTURAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "CXP_Facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturación"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Estado.ResumeLayout(False)
        Me.Estado.PerformLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTN_REFRESCAR As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTPFINAL As DateTimePicker
    Friend WithEvents DTPINICIO As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Estado As GroupBox
    Friend WithEvents RB_TODOS As RadioButton
    Friend WithEvents RB_INACTIVOS As RadioButton
    Friend WithEvents RB_ACTIVOS As RadioButton
    Friend WithEvents BTN_FACTURAR As Button
    Friend WithEvents Filtro As Filtro
    Friend WithEvents GRID As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CMB_TIPO_FACT As ComboBox
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_PAGOS As Button
    Friend WithEvents BTN_REPORTES As Button
End Class
