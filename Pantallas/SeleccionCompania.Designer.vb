<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SeleccionCompania
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionCompania))
        Me.CMB_COMPANIA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PG_ACTUALIZACIONES = New System.Windows.Forms.ProgressBar()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.LBL_MENSAJE = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CMB_COMPANIA
        '
        Me.CMB_COMPANIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_COMPANIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_COMPANIA.FormattingEnabled = True
        Me.CMB_COMPANIA.Location = New System.Drawing.Point(5, 32)
        Me.CMB_COMPANIA.Name = "CMB_COMPANIA"
        Me.CMB_COMPANIA.Size = New System.Drawing.Size(283, 26)
        Me.CMB_COMPANIA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía a utilizar :"
        '
        'PG_ACTUALIZACIONES
        '
        Me.PG_ACTUALIZACIONES.Location = New System.Drawing.Point(5, 83)
        Me.PG_ACTUALIZACIONES.Name = "PG_ACTUALIZACIONES"
        Me.PG_ACTUALIZACIONES.Size = New System.Drawing.Size(283, 23)
        Me.PG_ACTUALIZACIONES.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PG_ACTUALIZACIONES.TabIndex = 3
        Me.PG_ACTUALIZACIONES.Visible = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(191, 112)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 5
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(92, 112)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 4
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'LBL_MENSAJE
        '
        Me.LBL_MENSAJE.AutoSize = True
        Me.LBL_MENSAJE.BackColor = System.Drawing.Color.Transparent
        Me.LBL_MENSAJE.Location = New System.Drawing.Point(5, 67)
        Me.LBL_MENSAJE.Name = "LBL_MENSAJE"
        Me.LBL_MENSAJE.Size = New System.Drawing.Size(148, 13)
        Me.LBL_MENSAJE.TabIndex = 6
        Me.LBL_MENSAJE.Text = "Realizando actualizaciones ..."
        Me.LBL_MENSAJE.Visible = False
        '
        'SeleccionCompania
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(293, 156)
        Me.ControlBox = False
        Me.Controls.Add(Me.LBL_MENSAJE)
        Me.Controls.Add(Me.PG_ACTUALIZACIONES)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CMB_COMPANIA)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SeleccionCompania"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione la compañía"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents CMB_COMPANIA As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PG_ACTUALIZACIONES As ProgressBar
    Friend WithEvents LBL_MENSAJE As Label
End Class
