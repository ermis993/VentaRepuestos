<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_REPORTE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMB_TIPO = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMB_MODULO = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTP_INICIO = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FINAL = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PB_CARGA = New System.Windows.Forms.ProgressBar()
        Me.BTN_GENERAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_REPORTE)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CMB_TIPO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CMB_MODULO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(396, 111)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información general ]"
        '
        'CMB_REPORTE
        '
        Me.CMB_REPORTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_REPORTE.FormattingEnabled = True
        Me.CMB_REPORTE.Location = New System.Drawing.Point(68, 76)
        Me.CMB_REPORTE.Name = "CMB_REPORTE"
        Me.CMB_REPORTE.Size = New System.Drawing.Size(322, 21)
        Me.CMB_REPORTE.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Reporte:"
        '
        'CMB_TIPO
        '
        Me.CMB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TIPO.FormattingEnabled = True
        Me.CMB_TIPO.Location = New System.Drawing.Point(68, 48)
        Me.CMB_TIPO.Name = "CMB_TIPO"
        Me.CMB_TIPO.Size = New System.Drawing.Size(233, 21)
        Me.CMB_TIPO.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo :"
        '
        'CMB_MODULO
        '
        Me.CMB_MODULO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_MODULO.FormattingEnabled = True
        Me.CMB_MODULO.Location = New System.Drawing.Point(68, 22)
        Me.CMB_MODULO.Name = "CMB_MODULO"
        Me.CMB_MODULO.Size = New System.Drawing.Size(233, 21)
        Me.CMB_MODULO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Modulo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fecha inicio"
        '
        'DTP_INICIO
        '
        Me.DTP_INICIO.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_INICIO.Location = New System.Drawing.Point(4, 148)
        Me.DTP_INICIO.Name = "DTP_INICIO"
        Me.DTP_INICIO.Size = New System.Drawing.Size(96, 20)
        Me.DTP_INICIO.TabIndex = 2
        '
        'DTP_FINAL
        '
        Me.DTP_FINAL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FINAL.Location = New System.Drawing.Point(110, 148)
        Me.DTP_FINAL.Name = "DTP_FINAL"
        Me.DTP_FINAL.Size = New System.Drawing.Size(96, 20)
        Me.DTP_FINAL.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(107, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fecha final"
        '
        'PB_CARGA
        '
        Me.PB_CARGA.Location = New System.Drawing.Point(4, 191)
        Me.PB_CARGA.Name = "PB_CARGA"
        Me.PB_CARGA.Size = New System.Drawing.Size(202, 23)
        Me.PB_CARGA.TabIndex = 7
        '
        'BTN_GENERAR
        '
        Me.BTN_GENERAR.Image = Global.VentaRepuestos.My.Resources.Resources.generar
        Me.BTN_GENERAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_GENERAR.Location = New System.Drawing.Point(268, 162)
        Me.BTN_GENERAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_GENERAR.Name = "BTN_GENERAR"
        Me.BTN_GENERAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_GENERAR.TabIndex = 5
        Me.BTN_GENERAR.Text = "Generar"
        Me.BTN_GENERAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_GENERAR.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_SALIR.Location = New System.Drawing.Point(336, 162)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_SALIR.TabIndex = 6
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 226)
        Me.ControlBox = False
        Me.Controls.Add(Me.PB_CARGA)
        Me.Controls.Add(Me.BTN_GENERAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.DTP_FINAL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTP_INICIO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CMB_MODULO As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CMB_TIPO As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CMB_REPORTE As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DTP_INICIO As DateTimePicker
    Friend WithEvents DTP_FINAL As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents BTN_GENERAR As Button
    Friend WithEvents PB_CARGA As ProgressBar
End Class
