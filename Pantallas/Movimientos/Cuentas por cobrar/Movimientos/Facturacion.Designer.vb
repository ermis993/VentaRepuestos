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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBL_TOTAL_FACTURADO = New System.Windows.Forms.Label()
        Me.BTN_APARTADO = New System.Windows.Forms.Button()
        Me.BTN_REPORTES = New System.Windows.Forms.Button()
        Me.BTN_IMPRIMIR = New System.Windows.Forms.Button()
        Me.BTN_RECIBO = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_FACTURAR = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CMB_VER = New System.Windows.Forms.ComboBox()
        Me.BTN_ANULAR = New System.Windows.Forms.Button()
        Me.Filtro = New VentaRepuestos.Filtro()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_OPCIONES.SuspendLayout()
        Me.Estado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_TIPO_FACT)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 522)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(116, 43)
        Me.GroupBox1.TabIndex = 12
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
        Me.GRID.Location = New System.Drawing.Point(2, 126)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(857, 390)
        Me.GRID.TabIndex = 11
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
        Me.Estado.Location = New System.Drawing.Point(713, 61)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(146, 54)
        Me.Estado.TabIndex = 9
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
        Me.GroupBox2.Location = New System.Drawing.Point(713, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 58)
        Me.GroupBox2.TabIndex = 8
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 531)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 24)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Total facturado :"
        '
        'LBL_TOTAL_FACTURADO
        '
        Me.LBL_TOTAL_FACTURADO.AutoSize = True
        Me.LBL_TOTAL_FACTURADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TOTAL_FACTURADO.Location = New System.Drawing.Point(284, 531)
        Me.LBL_TOTAL_FACTURADO.Name = "LBL_TOTAL_FACTURADO"
        Me.LBL_TOTAL_FACTURADO.Size = New System.Drawing.Size(49, 24)
        Me.LBL_TOTAL_FACTURADO.TabIndex = 14
        Me.LBL_TOTAL_FACTURADO.Text = "0.00"
        '
        'BTN_APARTADO
        '
        Me.BTN_APARTADO.Image = Global.VentaRepuestos.My.Resources.Resources.apartado
        Me.BTN_APARTADO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_APARTADO.Location = New System.Drawing.Point(200, 7)
        Me.BTN_APARTADO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_APARTADO.Name = "BTN_APARTADO"
        Me.BTN_APARTADO.Size = New System.Drawing.Size(99, 43)
        Me.BTN_APARTADO.TabIndex = 2
        Me.BTN_APARTADO.Text = "Apartados"
        Me.BTN_APARTADO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_APARTADO.UseVisualStyleBackColor = True
        '
        'BTN_REPORTES
        '
        Me.BTN_REPORTES.Image = Global.VentaRepuestos.My.Resources.Resources.reportes
        Me.BTN_REPORTES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_REPORTES.Location = New System.Drawing.Point(399, 7)
        Me.BTN_REPORTES.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_REPORTES.Name = "BTN_REPORTES"
        Me.BTN_REPORTES.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REPORTES.TabIndex = 4
        Me.BTN_REPORTES.Text = "Reportes"
        Me.BTN_REPORTES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REPORTES.UseVisualStyleBackColor = True
        '
        'BTN_IMPRIMIR
        '
        Me.BTN_IMPRIMIR.Image = Global.VentaRepuestos.My.Resources.Resources.imprimir1
        Me.BTN_IMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_IMPRIMIR.Location = New System.Drawing.Point(299, 7)
        Me.BTN_IMPRIMIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_IMPRIMIR.Name = "BTN_IMPRIMIR"
        Me.BTN_IMPRIMIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_IMPRIMIR.TabIndex = 3
        Me.BTN_IMPRIMIR.Text = "Imprimir"
        Me.BTN_IMPRIMIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_IMPRIMIR.UseVisualStyleBackColor = True
        '
        'BTN_RECIBO
        '
        Me.BTN_RECIBO.Image = Global.VentaRepuestos.My.Resources.Resources.pago
        Me.BTN_RECIBO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RECIBO.Location = New System.Drawing.Point(101, 7)
        Me.BTN_RECIBO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_RECIBO.Name = "BTN_RECIBO"
        Me.BTN_RECIBO.Size = New System.Drawing.Size(99, 43)
        Me.BTN_RECIBO.TabIndex = 1
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
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(2, 51)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 5
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(760, 522)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 15
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CMB_VER)
        Me.GroupBox3.Location = New System.Drawing.Point(503, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(204, 48)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtar por"
        '
        'CMB_VER
        '
        Me.CMB_VER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_VER.FormattingEnabled = True
        Me.CMB_VER.Items.AddRange(New Object() {"Facturas", "Apartados"})
        Me.CMB_VER.Location = New System.Drawing.Point(6, 14)
        Me.CMB_VER.Name = "CMB_VER"
        Me.CMB_VER.Size = New System.Drawing.Size(192, 21)
        Me.CMB_VER.TabIndex = 0
        '
        'BTN_ANULAR
        '
        Me.BTN_ANULAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ANULAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ANULAR.Image = Global.VentaRepuestos.My.Resources.Resources.anular
        Me.BTN_ANULAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ANULAR.Location = New System.Drawing.Point(101, 51)
        Me.BTN_ANULAR.Name = "BTN_ANULAR"
        Me.BTN_ANULAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ANULAR.TabIndex = 6
        Me.BTN_ANULAR.Text = "Anular"
        Me.BTN_ANULAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ANULAR.UseVisualStyleBackColor = False
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(2, 95)
        Me.Filtro.Margin = New System.Windows.Forms.Padding(4)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(306, 29)
        Me.Filtro.TabIndex = 10
        Me.Filtro.VALOR = ""
        '
        'Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(864, 567)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_ANULAR)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BTN_APARTADO)
        Me.Controls.Add(Me.BTN_REPORTES)
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
        Me.GroupBox3.ResumeLayout(False)
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
    Friend WithEvents BTN_REPORTES As Button
    Friend WithEvents BTN_APARTADO As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CMB_VER As ComboBox
    Friend WithEvents BTN_ANULAR As Button
End Class
