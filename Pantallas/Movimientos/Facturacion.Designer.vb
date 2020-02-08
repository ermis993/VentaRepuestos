<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion
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
        Me.BTN_FACTURAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_TIPO_FACT = New System.Windows.Forms.ComboBox()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.Estado = New System.Windows.Forms.GroupBox()
        Me.RB_TODOS = New System.Windows.Forms.RadioButton()
        Me.RB_INACTIVOS = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVOS = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Estado.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_FACTURAR
        '
        Me.BTN_FACTURAR.Image = Global.VentaRepuestos.My.Resources.Resources.facturar
        Me.BTN_FACTURAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_FACTURAR.Location = New System.Drawing.Point(2, 1)
        Me.BTN_FACTURAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_FACTURAR.Name = "BTN_FACTURAR"
        Me.BTN_FACTURAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_FACTURAR.TabIndex = 0
        Me.BTN_FACTURAR.Text = "Factura"
        Me.BTN_FACTURAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_FACTURAR.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(407, 11)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 4
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_TIPO_FACT)
        Me.GroupBox1.Location = New System.Drawing.Point(511, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(116, 51)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo factura"
        '
        'CMB_TIPO_FACT
        '
        Me.CMB_TIPO_FACT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO_FACT.FormattingEnabled = True
        Me.CMB_TIPO_FACT.Items.AddRange(New Object() {"Facturas", "Pre-facturas"})
        Me.CMB_TIPO_FACT.Location = New System.Drawing.Point(6, 20)
        Me.CMB_TIPO_FACT.Name = "CMB_TIPO_FACT"
        Me.CMB_TIPO_FACT.Size = New System.Drawing.Size(103, 21)
        Me.CMB_TIPO_FACT.TabIndex = 0
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(2, 61)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(781, 406)
        Me.GRID.TabIndex = 34
        '
        'Estado
        '
        Me.Estado.Controls.Add(Me.RB_TODOS)
        Me.Estado.Controls.Add(Me.RB_INACTIVOS)
        Me.Estado.Controls.Add(Me.RB_ACTIVOS)
        Me.Estado.Location = New System.Drawing.Point(637, 4)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(146, 51)
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
        'Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(784, 471)
        Me.ControlBox = False
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
        Me.Estado.ResumeLayout(False)
        Me.Estado.PerformLayout()
        Me.ResumeLayout(False)

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
End Class
