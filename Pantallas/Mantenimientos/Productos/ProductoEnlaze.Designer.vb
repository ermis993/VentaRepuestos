<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductoEnlaze
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductoEnlaze))
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.LVResultados = New System.Windows.Forms.ListView()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TXT_CODIGO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LBL_PRODUCTO_SELECCIONADO = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_COD_PROD_HIJO = New System.Windows.Forms.TextBox()
        Me.TXT_DESC_PROD_HIJO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(306, 308)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 3
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(405, 308)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 4
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'LVResultados
        '
        Me.LVResultados.HideSelection = False
        Me.LVResultados.Location = New System.Drawing.Point(126, 37)
        Me.LVResultados.Name = "LVResultados"
        Me.LVResultados.Size = New System.Drawing.Size(378, 73)
        Me.LVResultados.TabIndex = 8
        Me.LVResultados.UseCompatibleStateImageBehavior = False
        Me.LVResultados.View = System.Windows.Forms.View.List
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label19.Location = New System.Drawing.Point(36, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Productos :"
        '
        'TXT_CODIGO
        '
        Me.TXT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_CODIGO.Location = New System.Drawing.Point(126, 6)
        Me.TXT_CODIGO.Name = "TXT_CODIGO"
        Me.TXT_CODIGO.Size = New System.Drawing.Size(378, 24)
        Me.TXT_CODIGO.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label11.Location = New System.Drawing.Point(-1, 9)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 18)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Nombre/Código :"
        '
        'LBL_PRODUCTO_SELECCIONADO
        '
        Me.LBL_PRODUCTO_SELECCIONADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PRODUCTO_SELECCIONADO.Location = New System.Drawing.Point(6, 16)
        Me.LBL_PRODUCTO_SELECCIONADO.Name = "LBL_PRODUCTO_SELECCIONADO"
        Me.LBL_PRODUCTO_SELECCIONADO.Size = New System.Drawing.Size(480, 55)
        Me.LBL_PRODUCTO_SELECCIONADO.TabIndex = 9
        Me.LBL_PRODUCTO_SELECCIONADO.Text = "Producto seleccionado"
        Me.LBL_PRODUCTO_SELECCIONADO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LBL_PRODUCTO_SELECCIONADO)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 74)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Producto padre ]"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TXT_DESC_PROD_HIJO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TXT_COD_PROD_HIJO)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 202)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(492, 100)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Producto hijo ]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código de producto :"
        '
        'TXT_COD_PROD_HIJO
        '
        Me.TXT_COD_PROD_HIJO.Location = New System.Drawing.Point(136, 28)
        Me.TXT_COD_PROD_HIJO.Name = "TXT_COD_PROD_HIJO"
        Me.TXT_COD_PROD_HIJO.ReadOnly = True
        Me.TXT_COD_PROD_HIJO.Size = New System.Drawing.Size(213, 20)
        Me.TXT_COD_PROD_HIJO.TabIndex = 1
        '
        'TXT_DESC_PROD_HIJO
        '
        Me.TXT_DESC_PROD_HIJO.Location = New System.Drawing.Point(136, 54)
        Me.TXT_DESC_PROD_HIJO.Multiline = True
        Me.TXT_DESC_PROD_HIJO.Name = "TXT_DESC_PROD_HIJO"
        Me.TXT_DESC_PROD_HIJO.ReadOnly = True
        Me.TXT_DESC_PROD_HIJO.Size = New System.Drawing.Size(348, 40)
        Me.TXT_DESC_PROD_HIJO.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripcion producto :"
        '
        'ProductoEnlaze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 354)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LVResultados)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TXT_CODIGO)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ProductoEnlaze"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unificar códigos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents LVResultados As ListView
    Friend WithEvents Label19 As Label
    Friend WithEvents TXT_CODIGO As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents LBL_PRODUCTO_SELECCIONADO As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TXT_COD_PROD_HIJO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_DESC_PROD_HIJO As TextBox
    Friend WithEvents Label2 As Label
End Class
