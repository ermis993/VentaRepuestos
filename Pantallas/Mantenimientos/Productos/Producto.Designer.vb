<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Producto))
        Me.Estado = New System.Windows.Forms.GroupBox()
        Me.RB_TODOS = New System.Windows.Forms.RadioButton()
        Me.RB_INACTIVOS = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVOS = New System.Windows.Forms.RadioButton()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.BTN_OPCIONES = New System.Windows.Forms.Button()
        Me.BTN_REPORTES = New System.Windows.Forms.Button()
        Me.BTN_VERIFICACION = New System.Windows.Forms.Button()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cm_importar_cátalogo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cm_mant_ubicaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.cm_generar_barcode = New System.Windows.Forms.ToolStripMenuItem()
        Me.cm_imprimir_barcode = New System.Windows.Forms.ToolStripMenuItem()
        Me.cm_etiqueta_producto = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filtro = New VentaRepuestos.Filtro()
        Me.Estado.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Estado
        '
        Me.Estado.Controls.Add(Me.RB_TODOS)
        Me.Estado.Controls.Add(Me.RB_INACTIVOS)
        Me.Estado.Controls.Add(Me.RB_ACTIVOS)
        Me.Estado.Location = New System.Drawing.Point(706, 2)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(146, 51)
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
        Me.RB_INACTIVOS.Location = New System.Drawing.Point(7, 30)
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
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(0, 128)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(852, 418)
        Me.GRID.TabIndex = 11
        '
        'BTN_OPCIONES
        '
        Me.BTN_OPCIONES.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_OPCIONES.Image = Global.VentaRepuestos.My.Resources.Resources.opciones
        Me.BTN_OPCIONES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_OPCIONES.Location = New System.Drawing.Point(2, 45)
        Me.BTN_OPCIONES.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_OPCIONES.Name = "BTN_OPCIONES"
        Me.BTN_OPCIONES.Size = New System.Drawing.Size(99, 43)
        Me.BTN_OPCIONES.TabIndex = 12
        Me.BTN_OPCIONES.Text = "Opciones"
        Me.BTN_OPCIONES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_OPCIONES.UseVisualStyleBackColor = False
        '
        'BTN_REPORTES
        '
        Me.BTN_REPORTES.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_REPORTES.Image = Global.VentaRepuestos.My.Resources.Resources.reportes
        Me.BTN_REPORTES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_REPORTES.Location = New System.Drawing.Point(400, 2)
        Me.BTN_REPORTES.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_REPORTES.Name = "BTN_REPORTES"
        Me.BTN_REPORTES.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REPORTES.TabIndex = 4
        Me.BTN_REPORTES.Text = "Reportes"
        Me.BTN_REPORTES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REPORTES.UseVisualStyleBackColor = False
        '
        'BTN_VERIFICACION
        '
        Me.BTN_VERIFICACION.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_VERIFICACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_VERIFICACION.Image = Global.VentaRepuestos.My.Resources.Resources.aceptar
        Me.BTN_VERIFICACION.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_VERIFICACION.Location = New System.Drawing.Point(301, 2)
        Me.BTN_VERIFICACION.Name = "BTN_VERIFICACION"
        Me.BTN_VERIFICACION.Size = New System.Drawing.Size(99, 43)
        Me.BTN_VERIFICACION.TabIndex = 3
        Me.BTN_VERIFICACION.Text = "Verificar"
        Me.BTN_VERIFICACION.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_VERIFICACION.UseVisualStyleBackColor = False
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_AGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AGREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(2, 2)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_AGREGAR.TabIndex = 0
        Me.BTN_AGREGAR.Text = "Agregar"
        Me.BTN_AGREGAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_AGREGAR.UseVisualStyleBackColor = False
        '
        'BTN_MODIFICAR
        '
        Me.BTN_MODIFICAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_MODIFICAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MODIFICAR.Image = Global.VentaRepuestos.My.Resources.Resources.controles
        Me.BTN_MODIFICAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(101, 2)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_MODIFICAR.TabIndex = 1
        Me.BTN_MODIFICAR.Text = "Modificar"
        Me.BTN_MODIFICAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_MODIFICAR.UseVisualStyleBackColor = False
        '
        'BTN_REFRESCAR
        '
        Me.BTN_REFRESCAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_REFRESCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_REFRESCAR.Image = Global.VentaRepuestos.My.Resources.Resources.refrescar
        Me.BTN_REFRESCAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(201, 2)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 2
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(500, 2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 5
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cm_importar_cátalogo, Me.ToolStripMenuItem1, Me.cm_mant_ubicaciones, Me.cm_generar_barcode, Me.cm_imprimir_barcode, Me.cm_etiqueta_producto})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(235, 120)
        '
        'cm_importar_cátalogo
        '
        Me.cm_importar_cátalogo.Name = "cm_importar_cátalogo"
        Me.cm_importar_cátalogo.Size = New System.Drawing.Size(234, 22)
        Me.cm_importar_cátalogo.Text = "Importar Cátalogo CABYS"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(231, 6)
        '
        'cm_mant_ubicaciones
        '
        Me.cm_mant_ubicaciones.Name = "cm_mant_ubicaciones"
        Me.cm_mant_ubicaciones.Size = New System.Drawing.Size(234, 22)
        Me.cm_mant_ubicaciones.Text = "Mantenimiento ubicaciones"
        '
        'cm_generar_barcode
        '
        Me.cm_generar_barcode.Name = "cm_generar_barcode"
        Me.cm_generar_barcode.Size = New System.Drawing.Size(234, 22)
        Me.cm_generar_barcode.Text = "Generar código de barras"
        '
        'cm_imprimir_barcode
        '
        Me.cm_imprimir_barcode.Name = "cm_imprimir_barcode"
        Me.cm_imprimir_barcode.Size = New System.Drawing.Size(234, 22)
        Me.cm_imprimir_barcode.Text = "Imprimir código de barras"
        '
        'cm_etiqueta_producto
        '
        Me.cm_etiqueta_producto.Name = "cm_etiqueta_producto"
        Me.cm_etiqueta_producto.Size = New System.Drawing.Size(234, 22)
        Me.cm_etiqueta_producto.Text = "Imprimir etiqueta de producto"
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(2, 93)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(305, 29)
        Me.Filtro.TabIndex = 10
        Me.Filtro.VALOR = ""
        '
        'Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_OPCIONES)
        Me.Controls.Add(Me.BTN_REPORTES)
        Me.Controls.Add(Me.BTN_VERIFICACION)
        Me.Controls.Add(Me.Filtro)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.BTN_MODIFICAR)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Producto"
        Me.Estado.ResumeLayout(False)
        Me.Estado.PerformLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Estado As GroupBox
    Friend WithEvents RB_TODOS As RadioButton
    Friend WithEvents RB_INACTIVOS As RadioButton
    Friend WithEvents RB_ACTIVOS As RadioButton
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents BTN_MODIFICAR As Button
    Friend WithEvents BTN_REFRESCAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GRID As DataGridView
    Friend WithEvents Filtro As Filtro
    Friend WithEvents BTN_VERIFICACION As Button
    Friend WithEvents BTN_REPORTES As Button
    Friend WithEvents BTN_OPCIONES As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents cm_importar_cátalogo As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents cm_mant_ubicaciones As ToolStripMenuItem
    Friend WithEvents cm_generar_barcode As ToolStripMenuItem
    Friend WithEvents cm_imprimir_barcode As ToolStripMenuItem
    Friend WithEvents cm_etiqueta_producto As ToolStripMenuItem
End Class
