<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Encomienda
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPFINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTPINICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_FILTRO = New System.Windows.Forms.ComboBox()
        Me.BTN_ENVIAR = New System.Windows.Forms.Button()
        Me.BTN_ENTREGAR = New System.Windows.Forms.Button()
        Me.BTN_UBICACION = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_RECEPCION = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_REPORTE = New System.Windows.Forms.Button()
        Me.BTN_TODO = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DTPFINAL)
        Me.GroupBox2.Controls.Add(Me.DTPINICIO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(645, 3)
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
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(2, 63)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(796, 338)
        Me.GRID.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_FILTRO)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 404)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 43)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrar por"
        '
        'CMB_FILTRO
        '
        Me.CMB_FILTRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FILTRO.FormattingEnabled = True
        Me.CMB_FILTRO.Items.AddRange(New Object() {"Todos", "Pendientes", "Transportando", "Recibidas", "Entregadas"})
        Me.CMB_FILTRO.Location = New System.Drawing.Point(6, 16)
        Me.CMB_FILTRO.Name = "CMB_FILTRO"
        Me.CMB_FILTRO.Size = New System.Drawing.Size(188, 21)
        Me.CMB_FILTRO.TabIndex = 0
        '
        'BTN_ENVIAR
        '
        Me.BTN_ENVIAR.Image = Global.VentaRepuestos.My.Resources.Resources.transportar
        Me.BTN_ENVIAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_ENVIAR.Location = New System.Drawing.Point(2, 2)
        Me.BTN_ENVIAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_ENVIAR.Name = "BTN_ENVIAR"
        Me.BTN_ENVIAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_ENVIAR.TabIndex = 8
        Me.BTN_ENVIAR.Text = "Enviar"
        Me.BTN_ENVIAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_ENVIAR.UseVisualStyleBackColor = True
        '
        'BTN_ENTREGAR
        '
        Me.BTN_ENTREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.entregar
        Me.BTN_ENTREGAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_ENTREGAR.Location = New System.Drawing.Point(138, 2)
        Me.BTN_ENTREGAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_ENTREGAR.Name = "BTN_ENTREGAR"
        Me.BTN_ENTREGAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_ENTREGAR.TabIndex = 1
        Me.BTN_ENTREGAR.Text = "Entregar"
        Me.BTN_ENTREGAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_ENTREGAR.UseVisualStyleBackColor = True
        '
        'BTN_UBICACION
        '
        Me.BTN_UBICACION.Image = Global.VentaRepuestos.My.Resources.Resources.ruta
        Me.BTN_UBICACION.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_UBICACION.Location = New System.Drawing.Point(580, 2)
        Me.BTN_UBICACION.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_UBICACION.Name = "BTN_UBICACION"
        Me.BTN_UBICACION.Size = New System.Drawing.Size(64, 55)
        Me.BTN_UBICACION.TabIndex = 3
        Me.BTN_UBICACION.Text = "Rutas"
        Me.BTN_UBICACION.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_UBICACION.UseVisualStyleBackColor = True
        '
        'BTN_REFRESCAR
        '
        Me.BTN_REFRESCAR.Image = Global.VentaRepuestos.My.Resources.Resources.refrescar
        Me.BTN_REFRESCAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(206, 2)
        Me.BTN_REFRESCAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_REFRESCAR.TabIndex = 2
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = True
        '
        'BTN_RECEPCION
        '
        Me.BTN_RECEPCION.Image = Global.VentaRepuestos.My.Resources.Resources.recibir
        Me.BTN_RECEPCION.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_RECEPCION.Location = New System.Drawing.Point(70, 2)
        Me.BTN_RECEPCION.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_RECEPCION.Name = "BTN_RECEPCION"
        Me.BTN_RECEPCION.Size = New System.Drawing.Size(64, 55)
        Me.BTN_RECEPCION.TabIndex = 0
        Me.BTN_RECEPCION.Text = "Recibir"
        Me.BTN_RECEPCION.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_RECEPCION.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(695, 404)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 6
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_REPORTE
        '
        Me.BTN_REPORTE.Image = Global.VentaRepuestos.My.Resources.Resources.reportes
        Me.BTN_REPORTE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_REPORTE.Location = New System.Drawing.Point(512, 2)
        Me.BTN_REPORTE.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_REPORTE.Name = "BTN_REPORTE"
        Me.BTN_REPORTE.Size = New System.Drawing.Size(64, 55)
        Me.BTN_REPORTE.TabIndex = 9
        Me.BTN_REPORTE.Text = "Reporte"
        Me.BTN_REPORTE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_REPORTE.UseVisualStyleBackColor = True
        '
        'BTN_TODO
        '
        Me.BTN_TODO.Image = Global.VentaRepuestos.My.Resources.Resources.derecha
        Me.BTN_TODO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_TODO.Location = New System.Drawing.Point(444, 3)
        Me.BTN_TODO.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_TODO.Name = "BTN_TODO"
        Me.BTN_TODO.Size = New System.Drawing.Size(64, 55)
        Me.BTN_TODO.TabIndex = 10
        Me.BTN_TODO.Text = "Todo"
        Me.BTN_TODO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_TODO.UseVisualStyleBackColor = True
        '
        'Encomienda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_TODO)
        Me.Controls.Add(Me.BTN_REPORTE)
        Me.Controls.Add(Me.BTN_ENVIAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_ENTREGAR)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.BTN_UBICACION)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTN_RECEPCION)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Encomienda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Encomienda"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_RECEPCION As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTPFINAL As DateTimePicker
    Friend WithEvents DTPINICIO As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_REFRESCAR As Button
    Friend WithEvents BTN_UBICACION As Button
    Friend WithEvents GRID As DataGridView
    Friend WithEvents BTN_ENTREGAR As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CMB_FILTRO As ComboBox
    Friend WithEvents BTN_ENVIAR As Button
    Friend WithEvents BTN_REPORTE As Button
    Friend WithEvents BTN_TODO As Button
End Class
