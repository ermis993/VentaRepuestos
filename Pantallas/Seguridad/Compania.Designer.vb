﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compania
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
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.BTN_REFRESCAR = New System.Windows.Forms.Button()
        Me.BTN_DERECHO = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.Estado = New System.Windows.Forms.GroupBox()
        Me.RB_TODAS = New System.Windows.Forms.RadioButton()
        Me.RB_INACTIVAS = New System.Windows.Forms.RadioButton()
        Me.RB_ACTIVAS = New System.Windows.Forms.RadioButton()
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
        Me.GRID.Location = New System.Drawing.Point(5, 69)
        Me.GRID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(948, 492)
        Me.GRID.TabIndex = 27
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_AGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AGREGAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(5, 9)
        Me.BTN_AGREGAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(132, 53)
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
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(136, 9)
        Me.BTN_MODIFICAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(132, 53)
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
        Me.BTN_REFRESCAR.Location = New System.Drawing.Point(267, 9)
        Me.BTN_REFRESCAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTN_REFRESCAR.Name = "BTN_REFRESCAR"
        Me.BTN_REFRESCAR.Size = New System.Drawing.Size(132, 53)
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
        Me.BTN_DERECHO.Location = New System.Drawing.Point(397, 9)
        Me.BTN_DERECHO.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTN_DERECHO.Name = "BTN_DERECHO"
        Me.BTN_DERECHO.Size = New System.Drawing.Size(132, 53)
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
        Me.BTN_SALIR.Location = New System.Drawing.Point(528, 9)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(132, 53)
        Me.BTN_SALIR.TabIndex = 22
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'Estado
        '
        Me.Estado.Controls.Add(Me.RB_TODAS)
        Me.Estado.Controls.Add(Me.RB_INACTIVAS)
        Me.Estado.Controls.Add(Me.RB_ACTIVAS)
        Me.Estado.Location = New System.Drawing.Point(759, -1)
        Me.Estado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Estado.Name = "Estado"
        Me.Estado.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Estado.Size = New System.Drawing.Size(195, 63)
        Me.Estado.TabIndex = 28
        Me.Estado.TabStop = False
        Me.Estado.Text = "Estado"
        '
        'RB_TODAS
        '
        Me.RB_TODAS.AutoSize = True
        Me.RB_TODAS.Location = New System.Drawing.Point(113, 14)
        Me.RB_TODAS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RB_TODAS.Name = "RB_TODAS"
        Me.RB_TODAS.Size = New System.Drawing.Size(69, 21)
        Me.RB_TODAS.TabIndex = 2
        Me.RB_TODAS.Text = "Todas"
        Me.RB_TODAS.UseVisualStyleBackColor = True
        '
        'RB_INACTIVAS
        '
        Me.RB_INACTIVAS.AutoSize = True
        Me.RB_INACTIVAS.Location = New System.Drawing.Point(9, 41)
        Me.RB_INACTIVAS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RB_INACTIVAS.Name = "RB_INACTIVAS"
        Me.RB_INACTIVAS.Size = New System.Drawing.Size(84, 21)
        Me.RB_INACTIVAS.TabIndex = 1
        Me.RB_INACTIVAS.TabStop = True
        Me.RB_INACTIVAS.Text = "Inactivas"
        Me.RB_INACTIVAS.UseVisualStyleBackColor = True
        '
        'RB_ACTIVAS
        '
        Me.RB_ACTIVAS.AutoSize = True
        Me.RB_ACTIVAS.Checked = True
        Me.RB_ACTIVAS.Location = New System.Drawing.Point(9, 16)
        Me.RB_ACTIVAS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RB_ACTIVAS.Name = "RB_ACTIVAS"
        Me.RB_ACTIVAS.Size = New System.Drawing.Size(74, 21)
        Me.RB_ACTIVAS.TabIndex = 0
        Me.RB_ACTIVAS.TabStop = True
        Me.RB_ACTIVAS.Text = "Activas"
        Me.RB_ACTIVAS.UseVisualStyleBackColor = True
        '
        'Compania
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(969, 565)
        Me.ControlBox = False
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.BTN_MODIFICAR)
        Me.Controls.Add(Me.BTN_REFRESCAR)
        Me.Controls.Add(Me.BTN_DERECHO)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
End Class
