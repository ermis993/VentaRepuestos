<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaBitacoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaBitacoras))
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPFINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTPINICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_GENERAR = New System.Windows.Forms.Button()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_BUSCADOR = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(699, 395)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 14
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
        Me.GroupBox2.Location = New System.Drawing.Point(3, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 58)
        Me.GroupBox2.TabIndex = 15
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
        'BTN_GENERAR
        '
        Me.BTN_GENERAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_GENERAR.Image = Global.VentaRepuestos.My.Resources.Resources.generar
        Me.BTN_GENERAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_GENERAR.Location = New System.Drawing.Point(734, 11)
        Me.BTN_GENERAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_GENERAR.Name = "BTN_GENERAR"
        Me.BTN_GENERAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_GENERAR.TabIndex = 16
        Me.BTN_GENERAR.Text = "Generar"
        Me.BTN_GENERAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_GENERAR.UseVisualStyleBackColor = False
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
        Me.GRID.Location = New System.Drawing.Point(3, 74)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(795, 315)
        Me.GRID.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "[ Dígite un texto o palabra clave a buscar ]"
        '
        'TXT_BUSCADOR
        '
        Me.TXT_BUSCADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_BUSCADOR.Location = New System.Drawing.Point(168, 28)
        Me.TXT_BUSCADOR.Name = "TXT_BUSCADOR"
        Me.TXT_BUSCADOR.Size = New System.Drawing.Size(414, 24)
        Me.TXT_BUSCADOR.TabIndex = 18
        '
        'ConsultaBitacoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 442)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXT_BUSCADOR)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.BTN_GENERAR)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConsultaBitacoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta de bitácoras"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTPFINAL As DateTimePicker
    Friend WithEvents DTPINICIO As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_GENERAR As Button
    Friend WithEvents GRID As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_BUSCADOR As TextBox
End Class
