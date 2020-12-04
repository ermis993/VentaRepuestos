<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Generica_Error
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Generica_Error))
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.BTN_EXPORTAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(1, 3)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(797, 395)
        Me.GRID.TabIndex = 42
        '
        'BTN_EXPORTAR
        '
        Me.BTN_EXPORTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_EXPORTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_EXPORTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_EXPORTAR.Image = Global.VentaRepuestos.My.Resources.Resources.excel
        Me.BTN_EXPORTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_EXPORTAR.Location = New System.Drawing.Point(598, 404)
        Me.BTN_EXPORTAR.Name = "BTN_EXPORTAR"
        Me.BTN_EXPORTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_EXPORTAR.TabIndex = 43
        Me.BTN_EXPORTAR.Text = "Exportar"
        Me.BTN_EXPORTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_EXPORTAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(699, 404)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 39
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'Generica_Error
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_EXPORTAR)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Generica_Error"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Error(es) de la importación"
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GRID As DataGridView
    Friend WithEvents BTN_EXPORTAR As Button
End Class
