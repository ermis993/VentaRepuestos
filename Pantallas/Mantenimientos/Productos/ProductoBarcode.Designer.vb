<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductoBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductoBarcode))
        Me.BTN_RELACION = New System.Windows.Forms.Button()
        Me.BTN_GENERAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.PB_BARCODE = New System.Windows.Forms.PictureBox()
        CType(Me.PB_BARCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_RELACION
        '
        Me.BTN_RELACION.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_RELACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_RELACION.Image = Global.VentaRepuestos.My.Resources.Resources.relacionar
        Me.BTN_RELACION.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RELACION.Location = New System.Drawing.Point(4, 201)
        Me.BTN_RELACION.Name = "BTN_RELACION"
        Me.BTN_RELACION.Size = New System.Drawing.Size(99, 43)
        Me.BTN_RELACION.TabIndex = 1
        Me.BTN_RELACION.Text = "Relación"
        Me.BTN_RELACION.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_RELACION.UseVisualStyleBackColor = False
        '
        'BTN_GENERAR
        '
        Me.BTN_GENERAR.Image = Global.VentaRepuestos.My.Resources.Resources.barcode
        Me.BTN_GENERAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_GENERAR.Location = New System.Drawing.Point(4, 107)
        Me.BTN_GENERAR.Name = "BTN_GENERAR"
        Me.BTN_GENERAR.Size = New System.Drawing.Size(269, 55)
        Me.BTN_GENERAR.TabIndex = 0
        Me.BTN_GENERAR.Text = "Generar barcode"
        Me.BTN_GENERAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_GENERAR.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(174, 201)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 2
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'PB_BARCODE
        '
        Me.PB_BARCODE.Location = New System.Drawing.Point(49, 12)
        Me.PB_BARCODE.Name = "PB_BARCODE"
        Me.PB_BARCODE.Size = New System.Drawing.Size(179, 89)
        Me.PB_BARCODE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_BARCODE.TabIndex = 0
        Me.PB_BARCODE.TabStop = False
        '
        'ProductoBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(276, 247)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_RELACION)
        Me.Controls.Add(Me.BTN_GENERAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.PB_BARCODE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProductoBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barcode"
        CType(Me.PB_BARCODE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PB_BARCODE As PictureBox
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_GENERAR As Button
    Friend WithEvents BTN_RELACION As Button
End Class
