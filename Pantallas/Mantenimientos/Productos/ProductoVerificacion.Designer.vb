<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductoVerificacion
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
        Me.BTN_VERIFICAR = New System.Windows.Forms.Button()
        Me.PB_CARGA = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBL_PROD_VERIFICADOS = New System.Windows.Forms.Label()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_CEDULA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BTN_INGRESAR = New System.Windows.Forms.Button()
        Me.TXT_PU = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT_TARIFA = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_DESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Filtro = New VentaRepuestos.Filtro()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_VERIFICAR
        '
        Me.BTN_VERIFICAR.Image = Global.VentaRepuestos.My.Resources.Resources.ajustes
        Me.BTN_VERIFICAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_VERIFICAR.Location = New System.Drawing.Point(139, 21)
        Me.BTN_VERIFICAR.Name = "BTN_VERIFICAR"
        Me.BTN_VERIFICAR.Size = New System.Drawing.Size(139, 45)
        Me.BTN_VERIFICAR.TabIndex = 0
        Me.BTN_VERIFICAR.Text = "Iniciar verificación"
        Me.BTN_VERIFICAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_VERIFICAR.UseVisualStyleBackColor = True
        '
        'PB_CARGA
        '
        Me.PB_CARGA.Location = New System.Drawing.Point(31, 72)
        Me.PB_CARGA.Name = "PB_CARGA"
        Me.PB_CARGA.Size = New System.Drawing.Size(354, 23)
        Me.PB_CARGA.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-1, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Total productos verificados :"
        '
        'LBL_PROD_VERIFICADOS
        '
        Me.LBL_PROD_VERIFICADOS.AutoSize = True
        Me.LBL_PROD_VERIFICADOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PROD_VERIFICADOS.Location = New System.Drawing.Point(146, 120)
        Me.LBL_PROD_VERIFICADOS.Name = "LBL_PROD_VERIFICADOS"
        Me.LBL_PROD_VERIFICADOS.Size = New System.Drawing.Size(14, 13)
        Me.LBL_PROD_VERIFICADOS.TabIndex = 10
        Me.LBL_PROD_VERIFICADOS.Text = "0"
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.AllowUserToDeleteRows = False
        Me.GRID.AllowUserToOrderColumns = True
        Me.GRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GRID.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Location = New System.Drawing.Point(2, 136)
        Me.GRID.MultiSelect = False
        Me.GRID.Name = "GRID"
        Me.GRID.ReadOnly = True
        Me.GRID.RowHeadersVisible = False
        Me.GRID.RowHeadersWidth = 51
        Me.GRID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRID.Size = New System.Drawing.Size(857, 216)
        Me.GRID.TabIndex = 11
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(760, 356)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 15
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TXT_CEDULA)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.BTN_INGRESAR)
        Me.GroupBox1.Controls.Add(Me.TXT_PU)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXT_TARIFA)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXT_DESCRIPCION)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TXT_CODIGO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(429, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 118)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Información producto ]"
        '
        'TXT_CEDULA
        '
        Me.TXT_CEDULA.Location = New System.Drawing.Point(81, 73)
        Me.TXT_CEDULA.Name = "TXT_CEDULA"
        Me.TXT_CEDULA.ReadOnly = True
        Me.TXT_CEDULA.Size = New System.Drawing.Size(100, 20)
        Me.TXT_CEDULA.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Cédula :"
        '
        'BTN_INGRESAR
        '
        Me.BTN_INGRESAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_INGRESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_INGRESAR.Image = Global.VentaRepuestos.My.Resources.Resources.agregar
        Me.BTN_INGRESAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_INGRESAR.Location = New System.Drawing.Point(325, 69)
        Me.BTN_INGRESAR.Name = "BTN_INGRESAR"
        Me.BTN_INGRESAR.Size = New System.Drawing.Size(99, 45)
        Me.BTN_INGRESAR.TabIndex = 17
        Me.BTN_INGRESAR.Text = "Ingresar"
        Me.BTN_INGRESAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_INGRESAR.UseVisualStyleBackColor = False
        '
        'TXT_PU
        '
        Me.TXT_PU.Location = New System.Drawing.Point(310, 21)
        Me.TXT_PU.Name = "TXT_PU"
        Me.TXT_PU.ReadOnly = True
        Me.TXT_PU.Size = New System.Drawing.Size(114, 20)
        Me.TXT_PU.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(272, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "P/C :"
        '
        'TXT_TARIFA
        '
        Me.TXT_TARIFA.Location = New System.Drawing.Point(232, 21)
        Me.TXT_TARIFA.Name = "TXT_TARIFA"
        Me.TXT_TARIFA.ReadOnly = True
        Me.TXT_TARIFA.Size = New System.Drawing.Size(32, 20)
        Me.TXT_TARIFA.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(186, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tarifa :"
        '
        'TXT_DESCRIPCION
        '
        Me.TXT_DESCRIPCION.Location = New System.Drawing.Point(81, 47)
        Me.TXT_DESCRIPCION.Name = "TXT_DESCRIPCION"
        Me.TXT_DESCRIPCION.ReadOnly = True
        Me.TXT_DESCRIPCION.Size = New System.Drawing.Size(343, 20)
        Me.TXT_DESCRIPCION.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descripción :"
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Location = New System.Drawing.Point(81, 21)
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.ReadOnly = True
        Me.TXT_CODIGO.Size = New System.Drawing.Size(100, 20)
        Me.TXT_CODIGO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Código :"
        '
        'Filtro
        '
        Me.Filtro.Location = New System.Drawing.Point(2, 360)
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(306, 29)
        Me.Filtro.TabIndex = 17
        Me.Filtro.VALOR = ""
        '
        'ProductoVerificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 401)
        Me.ControlBox = False
        Me.Controls.Add(Me.Filtro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.LBL_PROD_VERIFICADOS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PB_CARGA)
        Me.Controls.Add(Me.BTN_VERIFICAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ProductoVerificacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producto verificación"
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_VERIFICAR As Button
    Friend WithEvents PB_CARGA As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents LBL_PROD_VERIFICADOS As Label
    Friend WithEvents GRID As DataGridView
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents TXT_DESCRIPCION As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_TARIFA As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_PU As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BTN_INGRESAR As Button
    Friend WithEvents TXT_CEDULA As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Filtro As Filtro
End Class
