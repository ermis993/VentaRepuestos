﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Familia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Familia))
        Me.Estado = New System.Windows.Forms.GroupBox()
        Me.RB_TODOS = New System.Windows.Forms.RadioButton()
        Me.RB_INACTIVOS = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVOS = New System.Windows.Forms.RadioButton()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.Filtro = New VentaRepuestos.Filtro()
        Me.Estado.SuspendLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Estado
        '
        Me.Estado.Controls.Add(Me.RB_TODOS)
        Me.Estado.Controls.Add(Me.RB_INACTIVOS)
        Me.Estado.Controls.Add(Me.RB_ACTIVOS)
        Me.Estado.Location = New System.Drawing.Point(567, 0)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(146, 51)
        Me.Estado.TabIndex = 40
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
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_AGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AGREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(2, 4)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_AGREGAR.TabIndex = 39
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
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(100, 4)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_MODIFICAR.TabIndex = 38
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
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(198, 4)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 37
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
        Me.BTN_SALIR.Location = New System.Drawing.Point(296, 4)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 36
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(2, 88)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(711, 372)
        Me.GRID.TabIndex = 42
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(2, 53)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(306, 29)
        Me.Filtro.TabIndex = 41
        Me.Filtro.VALOR = ""
        '
        'Familia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 461)
        Me.ControlBox = False
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.Filtro)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.BTN_MODIFICAR)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Familia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Familia"
        Me.Estado.ResumeLayout(False)
        Me.Estado.PerformLayout()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Filtro As Filtro
    Friend WithEvents Estado As GroupBox
    Friend WithEvents RB_TODOS As RadioButton
    Friend WithEvents RB_INACTIVOS As RadioButton
    Friend WithEvents RB_ACTIVOS As RadioButton
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents BTN_MODIFICAR As Button
    Friend WithEvents BTN_REFRESCAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GRID As DataGridView
End Class
