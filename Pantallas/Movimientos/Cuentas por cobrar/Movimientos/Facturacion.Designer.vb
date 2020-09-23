<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Facturacion
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_TIPO_FACT = New System.Windows.Forms.ComboBox()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.CMS_OPCIONES = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MostrarRechazoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegenerarDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReenviarDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Estado = New System.Windows.Forms.GroupBox()
        Me.RB_TODOS = New System.Windows.Forms.RadioButton()
        Me.RB_INACTIVOS = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVOS = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPFINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTPINICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_RECIBO = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_FACTURAR = New System.Windows.Forms.Button()
        Me.BTN_IMPRIMIR = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBL_TOTAL_FACTURADO = New System.Windows.Forms.Label()
        Me.Filtro = New VentaRepuestos.Filtro()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_OPCIONES.SuspendLayout()
        Me.Estado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_TIPO_FACT)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 472)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(116, 43)
        Me.GroupBox1.TabIndex = 5
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
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToResizeColumns = False
        Me.GRID.AllowUserToResizeRows = False
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.ContextMenuStrip = Me.CMS_OPCIONES
        Me.GRID.Location = New System.Drawing.Point(2, 93)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(857, 374)
        Me.GRID.TabIndex = 34
        '
        'CMS_OPCIONES
        '
        Me.CMS_OPCIONES.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CMS_OPCIONES.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostrarRechazoToolStripMenuItem, Me.RegenerarDocumentoToolStripMenuItem, Me.ReenviarDocumentoToolStripMenuItem})
        Me.CMS_OPCIONES.Name = "CMS_OPCIONES"
        Me.CMS_OPCIONES.Size = New System.Drawing.Size(193, 70)
        '
        'MostrarRechazoToolStripMenuItem
        '
        Me.MostrarRechazoToolStripMenuItem.Name = "MostrarRechazoToolStripMenuItem"
        Me.MostrarRechazoToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MostrarRechazoToolStripMenuItem.Text = "Mostrar rechazo"
        '
        'RegenerarDocumentoToolStripMenuItem
        '
        Me.RegenerarDocumentoToolStripMenuItem.Name = "RegenerarDocumentoToolStripMenuItem"
        Me.RegenerarDocumentoToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RegenerarDocumentoToolStripMenuItem.Text = "Regenerar documento"
        '
        'ReenviarDocumentoToolStripMenuItem
        '
        Me.ReenviarDocumentoToolStripMenuItem.Name = "ReenviarDocumentoToolStripMenuItem"
        Me.ReenviarDocumentoToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ReenviarDocumentoToolStripMenuItem.Text = "Reenviar documento"
        '
        'Estado
        '
        Me.Estado.Controls.Add(Me.RB_TODOS)
        Me.Estado.Controls.Add(Me.RB_INACTIVOS)
        Me.Estado.Controls.Add(Me.RB_ACTIVOS)
        Me.Estado.Location = New System.Drawing.Point(713, 1)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(146, 54)
        Me.Estado.TabIndex = 35
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPFINAL)
        Me.GroupBox2.Controls.Add(Me.DTPINICIO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(558, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 54)
        Me.GroupBox2.TabIndex = 36
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
        'BTN_RECIBO
        '
        Me.BTN_RECIBO.Image = Global.VentaRepuestos.My.Resources.Resources.pago
        Me.BTN_RECIBO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RECIBO.Location = New System.Drawing.Point(105, 7)
        Me.BTN_RECIBO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_RECIBO.Name = "BTN_RECIBO"
        Me.BTN_RECIBO.Size = New System.Drawing.Size(99, 43)
        Me.BTN_RECIBO.TabIndex = 39
        Me.BTN_RECIBO.Text = "Recibos/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NC"
        Me.BTN_RECIBO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_RECIBO.UseVisualStyleBackColor = True
        '
        'BTN_REFRESCAR
        '
        Me.BTN_REFRESCAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_REFRESCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_REFRESCAR.Image = Global.VentaRepuestos.My.Resources.Resources.refrescar
        Me.BTN_REFRESCAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(453, 7)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 37
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(761, 471)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 4
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'BTN_FACTURAR
        '
        Me.BTN_FACTURAR.Image = Global.VentaRepuestos.My.Resources.Resources.facturar
        Me.BTN_FACTURAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_FACTURAR.Location = New System.Drawing.Point(2, 7)
        Me.BTN_FACTURAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_FACTURAR.Name = "BTN_FACTURAR"
        Me.BTN_FACTURAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_FACTURAR.TabIndex = 0
        Me.BTN_FACTURAR.Text = "Facturas/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ND"
        Me.BTN_FACTURAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_FACTURAR.UseVisualStyleBackColor = True
        '
        'BTN_IMPRIMIR
        '
        Me.BTN_IMPRIMIR.Image = Global.VentaRepuestos.My.Resources.Resources.imprimir1
        Me.BTN_IMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_IMPRIMIR.Location = New System.Drawing.Point(208, 7)
        Me.BTN_IMPRIMIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_IMPRIMIR.Name = "BTN_IMPRIMIR"
        Me.BTN_IMPRIMIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_IMPRIMIR.TabIndex = 40
        Me.BTN_IMPRIMIR.Text = "Imprimir"
        Me.BTN_IMPRIMIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_IMPRIMIR.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 484)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 24)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Total facturado :"
        '
        'LBL_TOTAL_FACTURADO
        '
        Me.LBL_TOTAL_FACTURADO.AutoSize = True
        Me.LBL_TOTAL_FACTURADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TOTAL_FACTURADO.Location = New System.Drawing.Point(284, 484)
        Me.LBL_TOTAL_FACTURADO.Name = "LBL_TOTAL_FACTURADO"
        Me.LBL_TOTAL_FACTURADO.Size = New System.Drawing.Size(49, 24)
        Me.LBL_TOTAL_FACTURADO.TabIndex = 42
        Me.LBL_TOTAL_FACTURADO.Text = "0.00"
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(2, 58)
        Me.Filtro.Margin = New System.Windows.Forms.Padding(4)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(306, 29)
        Me.Filtro.TabIndex = 38
        Me.Filtro.VALOR = ""
        '
        'Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(864, 517)
        Me.ControlBox = False
        Me.Controls.Add(Me.LBL_TOTAL_FACTURADO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTN_IMPRIMIR)
        Me.Controls.Add(Me.BTN_RECIBO)
        Me.Controls.Add(Me.Filtro)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_FACTURAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturación"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_OPCIONES.ResumeLayout(False)
        Me.Estado.ResumeLayout(False)
        Me.Estado.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_FACTURAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CMB_TIPO_FACT As ComboBox
    Friend WithEvents GRID As DataGridView
    Friend WithEvents Estado As GroupBox
    Friend WithEvents RB_TODOS As RadioButton
    Friend WithEvents RB_INACTIVOS As RadioButton
    Friend WithEvents RB_ACTIVOS As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPINICIO As DateTimePicker
    Friend WithEvents DTPFINAL As DateTimePicker
    Friend WithEvents BTN_REFRESCAR As Button
    Friend WithEvents Filtro As Filtro
    Friend WithEvents BTN_RECIBO As Button
    Friend WithEvents BTN_IMPRIMIR As Button
    Friend WithEvents CMS_OPCIONES As ContextMenuStrip
    Friend WithEvents MostrarRechazoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegenerarDocumentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReenviarDocumentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents LBL_TOTAL_FACTURADO As Label
End Class
