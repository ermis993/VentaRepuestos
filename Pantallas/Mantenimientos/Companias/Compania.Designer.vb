﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Compania
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Compania))
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.Estado = New System.Windows.Forms.GroupBox()
        Me.RB_TODAS = New System.Windows.Forms.RadioButton()
        Me.RB_INACTIVAS = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVAS = New System.Windows.Forms.RadioButton()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_DERECHO = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.FILTRO = New VentaRepuestos.Filtro()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Estado.SuspendLayout()
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
        Me.GRID.Location = New System.Drawing.Point(4, 89)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(711, 395)
        Me.GRID.TabIndex = 27
        '
        'Estado
        '
        Me.Estado.Controls.Add(Me.RB_TODAS)
        Me.Estado.Controls.Add(Me.RB_INACTIVAS)
        Me.Estado.Controls.Add(Me.RB_ACTIVAS)
        Me.Estado.Location = New System.Drawing.Point(569, -1)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(146, 51)
        Me.Estado.TabIndex = 28
        Me.Estado.TabStop = False
        Me.Estado.Text = "Estado"
        '
        'RB_TODAS
        '
        Me.RB_TODAS.AutoSize = True
        Me.RB_TODAS.Location = New System.Drawing.Point(85, 11)
        Me.RB_TODAS.Name = "RB_TODAS"
        Me.RB_TODAS.Size = New System.Drawing.Size(55, 17)
        Me.RB_TODAS.TabIndex = 2
        Me.RB_TODAS.Text = "Todas"
        Me.RB_TODAS.UseVisualStyleBackColor = True
        '
        'RB_INACTIVAS
        '
        Me.RB_INACTIVAS.AutoSize = True
        Me.RB_INACTIVAS.Location = New System.Drawing.Point(7, 30)
        Me.RB_INACTIVAS.Name = "RB_INACTIVAS"
        Me.RB_INACTIVAS.Size = New System.Drawing.Size(68, 17)
        Me.RB_INACTIVAS.TabIndex = 1
        Me.RB_INACTIVAS.TabStop = True
        Me.RB_INACTIVAS.Text = "Inactivas"
        Me.RB_INACTIVAS.UseVisualStyleBackColor = True
        '
        'RB_ACTIVAS
        '
        Me.RB_ACTIVAS.AutoSize = True
        Me.RB_ACTIVAS.Checked = True
        Me.RB_ACTIVAS.Location = New System.Drawing.Point(7, 13)
        Me.RB_ACTIVAS.Name = "RB_ACTIVAS"
        Me.RB_ACTIVAS.Size = New System.Drawing.Size(60, 17)
        Me.RB_ACTIVAS.TabIndex = 0
        Me.RB_ACTIVAS.TabStop = True
        Me.RB_ACTIVAS.Text = "Activas"
        Me.RB_ACTIVAS.UseVisualStyleBackColor = True
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_AGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AGREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(4, 7)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_AGREGAR.TabIndex = 26
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
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(102, 7)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_MODIFICAR.TabIndex = 25
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
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(200, 7)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_REFRESCAR.TabIndex = 24
        Me.BTN_REFRESCAR.Text = "Refrescar"
        Me.BTN_REFRESCAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_REFRESCAR.UseVisualStyleBackColor = False
        '
        'BTN_DERECHO
        '
        Me.BTN_DERECHO.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_DERECHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DERECHO.Image = Global.VentaRepuestos.My.Resources.Resources.contrasena
        Me.BTN_DERECHO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_DERECHO.Location = New System.Drawing.Point(298, 7)
        Me.BTN_DERECHO.Name = "BTN_DERECHO"
        Me.BTN_DERECHO.Size = New System.Drawing.Size(99, 43)
        Me.BTN_DERECHO.TabIndex = 23
        Me.BTN_DERECHO.Text = "Derechos"
        Me.BTN_DERECHO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_DERECHO.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(396, 7)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 22
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'FILTRO
        '
        Me.FILTRO.Location = New System.Drawing.Point(4, 54)
        Me.FILTRO.Name = "FILTRO"
        Me.FILTRO.Size = New System.Drawing.Size(306, 29)
        Me.FILTRO.TabIndex = 29
        Me.FILTRO.VALOR = ""
        '
        'Compania
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(727, 487)
        Me.ControlBox = False
        Me.Controls.Add(Me.FILTRO)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.BTN_MODIFICAR)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.BTN_DERECHO)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Compania"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compania"
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Estado.ResumeLayout(False)
        Me.Estado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_DERECHO As Button
    Friend WithEvents BTN_REFRESCAR As Button
    Friend WithEvents BTN_MODIFICAR As Button
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents GRID As DataGridView
    Friend WithEvents Estado As GroupBox
    Friend WithEvents RB_TODAS As RadioButton
    Friend WithEvents RB_INACTIVAS As RadioButton
    Friend WithEvents RB_ACTIVAS As RadioButton
    Friend WithEvents FILTRO As Filtro
End Class
