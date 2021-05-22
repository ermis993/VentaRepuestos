<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentoElectronico
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentoElectronico))
        Me.BTN_IMPORTAR = New System.Windows.Forms.Button()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPFINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTPINICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.Filtro = New VentaRepuestos.Filtro()
        Me.BTN_BUSQUEDA = New System.Windows.Forms.Button()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_IMPORTAR
        '
        Me.BTN_IMPORTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_IMPORTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_IMPORTAR.Image = Global.VentaRepuestos.My.Resources.Resources.import
        Me.BTN_IMPORTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_IMPORTAR.Location = New System.Drawing.Point(3, 9)
        Me.BTN_IMPORTAR.Name = "BTN_IMPORTAR"
        Me.BTN_IMPORTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_IMPORTAR.TabIndex = 34
        Me.BTN_IMPORTAR.Text = "Importar"
        Me.BTN_IMPORTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_IMPORTAR.UseVisualStyleBackColor = False
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRID.DefaultCellStyle = DataGridViewCellStyle1
        Me.GRID.Location = New System.Drawing.Point(3, 106)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(794, 293)
        Me.GRID.TabIndex = 38
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(698, 405)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 39
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPFINAL)
        Me.GroupBox2.Controls.Add(Me.DTPINICIO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(648, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 54)
        Me.GroupBox2.TabIndex = 40
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
        'BTN_REFRESCAR
        '
        Me.BTN_REFRESCAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_REFRESCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_REFRESCAR.Image = Global.VentaRepuestos.My.Resources.Resources.refrescar
        Me.BTN_REFRESCAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(543, 9)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 41
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = False
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(3, 71)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(306, 29)
        Me.Filtro.TabIndex = 37
        Me.Filtro.VALOR = ""
        '
        'BTN_BUSQUEDA
        '
        Me.BTN_BUSQUEDA.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_BUSQUEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_BUSQUEDA.Image = Global.VentaRepuestos.My.Resources.Resources.ajustes
        Me.BTN_BUSQUEDA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_BUSQUEDA.Location = New System.Drawing.Point(102, 9)
        Me.BTN_BUSQUEDA.Name = "BTN_BUSQUEDA"
        Me.BTN_BUSQUEDA.Size = New System.Drawing.Size(99, 43)
        Me.BTN_BUSQUEDA.TabIndex = 42
        Me.BTN_BUSQUEDA.Text = "Correo"
        Me.BTN_BUSQUEDA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_BUSQUEDA.UseVisualStyleBackColor = False
        '
        'DocumentoElectronico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_BUSQUEDA)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.Filtro)
        Me.Controls.Add(Me.BTN_IMPORTAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DocumentoElectronico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documentos importados"
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_IMPORTAR As Button
    Friend WithEvents Filtro As Filtro
    Friend WithEvents GRID As DataGridView
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTPFINAL As DateTimePicker
    Friend WithEvents DTPINICIO As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_REFRESCAR As Button
    Friend WithEvents BTN_BUSQUEDA As Button
End Class
