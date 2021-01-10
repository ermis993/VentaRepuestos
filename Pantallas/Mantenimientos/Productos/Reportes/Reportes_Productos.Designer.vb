<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Reportes_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reportes_Productos))
        Me.LBL_REPORTE_SELECCIONADO = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CMB_FAMILIA = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTP_FINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTP_INICIO = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TV_REPORTES = New System.Windows.Forms.TreeView()
        Me.BTN_GENERAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.PB_CARGA = New System.Windows.Forms.ProgressBar()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_REPORTE_SELECCIONADO
        '
        Me.LBL_REPORTE_SELECCIONADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_REPORTE_SELECCIONADO.Location = New System.Drawing.Point(3, 330)
        Me.LBL_REPORTE_SELECCIONADO.Name = "LBL_REPORTE_SELECCIONADO"
        Me.LBL_REPORTE_SELECCIONADO.Size = New System.Drawing.Size(381, 43)
        Me.LBL_REPORTE_SELECCIONADO.TabIndex = 21
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CMB_FAMILIA)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DTP_FINAL)
        Me.GroupBox2.Controls.Add(Me.DTP_INICIO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 243)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(487, 81)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Parámetros ]"
        '
        'CMB_FAMILIA
        '
        Me.CMB_FAMILIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FAMILIA.FormattingEnabled = True
        Me.CMB_FAMILIA.Location = New System.Drawing.Point(250, 21)
        Me.CMB_FAMILIA.Name = "CMB_FAMILIA"
        Me.CMB_FAMILIA.Size = New System.Drawing.Size(227, 21)
        Me.CMB_FAMILIA.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(199, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Familia :"
        '
        'DTP_FINAL
        '
        Me.DTP_FINAL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FINAL.Location = New System.Drawing.Point(77, 46)
        Me.DTP_FINAL.Margin = New System.Windows.Forms.Padding(2)
        Me.DTP_FINAL.Name = "DTP_FINAL"
        Me.DTP_FINAL.Size = New System.Drawing.Size(97, 20)
        Me.DTP_FINAL.TabIndex = 3
        '
        'DTP_INICIO
        '
        Me.DTP_INICIO.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_INICIO.Location = New System.Drawing.Point(77, 21)
        Me.DTP_INICIO.Margin = New System.Windows.Forms.Padding(2)
        Me.DTP_INICIO.Name = "DTP_INICIO"
        Me.DTP_INICIO.Size = New System.Drawing.Size(97, 20)
        Me.DTP_INICIO.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha final :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha inicio :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TV_REPORTES)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 61)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(487, 177)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Reportes disponibles ]"
        '
        'TV_REPORTES
        '
        Me.TV_REPORTES.Location = New System.Drawing.Point(7, 18)
        Me.TV_REPORTES.Name = "TV_REPORTES"
        Me.TV_REPORTES.Size = New System.Drawing.Size(475, 154)
        Me.TV_REPORTES.TabIndex = 0
        '
        'BTN_GENERAR
        '
        Me.BTN_GENERAR.Image = Global.VentaRepuestos.My.Resources.Resources.generar
        Me.BTN_GENERAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_GENERAR.Location = New System.Drawing.Point(2, 2)
        Me.BTN_GENERAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_GENERAR.Name = "BTN_GENERAR"
        Me.BTN_GENERAR.Size = New System.Drawing.Size(64, 55)
        Me.BTN_GENERAR.TabIndex = 19
        Me.BTN_GENERAR.Text = "Generar"
        Me.BTN_GENERAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_GENERAR.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(390, 330)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 17
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'PB_CARGA
        '
        Me.PB_CARGA.Location = New System.Drawing.Point(204, 21)
        Me.PB_CARGA.Name = "PB_CARGA"
        Me.PB_CARGA.Size = New System.Drawing.Size(261, 23)
        Me.PB_CARGA.TabIndex = 22
        Me.PB_CARGA.Visible = False
        '
        'Reportes_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.PB_CARGA)
        Me.Controls.Add(Me.LBL_REPORTE_SELECCIONADO)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTN_GENERAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reportes_Productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes productos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBL_REPORTE_SELECCIONADO As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTP_FINAL As DateTimePicker
    Friend WithEvents DTP_INICIO As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_GENERAR As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TV_REPORTES As TreeView
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CMB_FAMILIA As ComboBox
    Friend WithEvents PB_CARGA As ProgressBar
End Class
