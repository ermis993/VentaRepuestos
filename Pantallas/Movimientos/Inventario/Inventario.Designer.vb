<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPFINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTPINICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.Filtro = New VentaRepuestos.Filtro()
        Me.BTN_TRACKING = New System.Windows.Forms.Button()
        Me.BTN_AJUSTE = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPFINAL)
        Me.GroupBox2.Controls.Add(Me.DTPINICIO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(650, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 58)
        Me.GroupBox2.TabIndex = 17
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
        Me.GRID.AllowUserToResizeColumns = False
        Me.GRID.AllowUserToResizeRows = False
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(3, 90)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(796, 390)
        Me.GRID.TabIndex = 18
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(3, 57)
        Me.Filtro.Margin = New System.Windows.Forms.Padding(4)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(306, 29)
        Me.Filtro.TabIndex = 19
        Me.Filtro.VALOR = ""
        '
        'BTN_TRACKING
        '
        Me.BTN_TRACKING.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_TRACKING.Image = Global.VentaRepuestos.My.Resources.Resources.tracking
        Me.BTN_TRACKING.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_TRACKING.Location = New System.Drawing.Point(102, 3)
        Me.BTN_TRACKING.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_TRACKING.Name = "BTN_TRACKING"
        Me.BTN_TRACKING.Size = New System.Drawing.Size(99, 43)
        Me.BTN_TRACKING.TabIndex = 21
        Me.BTN_TRACKING.Text = "Tracking"
        Me.BTN_TRACKING.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_TRACKING.UseVisualStyleBackColor = False
        '
        'BTN_AJUSTE
        '
        Me.BTN_AJUSTE.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_AJUSTE.Image = Global.VentaRepuestos.My.Resources.Resources.ajuste_inventario
        Me.BTN_AJUSTE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AJUSTE.Location = New System.Drawing.Point(3, 3)
        Me.BTN_AJUSTE.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_AJUSTE.Name = "BTN_AJUSTE"
        Me.BTN_AJUSTE.Size = New System.Drawing.Size(99, 43)
        Me.BTN_AJUSTE.TabIndex = 20
        Me.BTN_AJUSTE.Text = "Ajuste"
        Me.BTN_AJUSTE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_AJUSTE.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(700, 494)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 16
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
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(201, 3)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 22
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = False
        '
        'Inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 539)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.BTN_TRACKING)
        Me.Controls.Add(Me.BTN_AJUSTE)
        Me.Controls.Add(Me.Filtro)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Inventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTPFINAL As DateTimePicker
    Friend WithEvents DTPINICIO As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GRID As DataGridView
    Friend WithEvents Filtro As Filtro
    Friend WithEvents BTN_AJUSTE As Button
    Friend WithEvents BTN_TRACKING As Button
    Friend WithEvents BTN_REFRESCAR As Button
End Class
