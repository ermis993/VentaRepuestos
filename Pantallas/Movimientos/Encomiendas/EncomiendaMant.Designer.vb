<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EncomiendaMant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EncomiendaMant))
        Me.TXT_GUIA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_BULTO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT_DESTINO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_ORIGEN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_RETIRA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_ENVIA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LST_TRACKING = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.CMB_ORIGEN = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.CMB_SUCURSAL = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TXT_GUIA
        '
        Me.TXT_GUIA.Enabled = False
        Me.TXT_GUIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.TXT_GUIA.Location = New System.Drawing.Point(77, 6)
        Me.TXT_GUIA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_GUIA.MaxLength = 3
        Me.TXT_GUIA.Name = "TXT_GUIA"
        Me.TXT_GUIA.Size = New System.Drawing.Size(264, 24)
        Me.TXT_GUIA.TabIndex = 1
        Me.TXT_GUIA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label8.Location = New System.Drawing.Point(20, 9)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Guia :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TXT_BULTO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXT_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXT_ORIGEN)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TXT_RETIRA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXT_ENVIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(348, 154)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'TXT_BULTO
        '
        Me.TXT_BULTO.Enabled = False
        Me.TXT_BULTO.Location = New System.Drawing.Point(65, 127)
        Me.TXT_BULTO.Name = "TXT_BULTO"
        Me.TXT_BULTO.Size = New System.Drawing.Size(68, 20)
        Me.TXT_BULTO.TabIndex = 9
        Me.TXT_BULTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Bultos :"
        '
        'TXT_DESTINO
        '
        Me.TXT_DESTINO.Enabled = False
        Me.TXT_DESTINO.Location = New System.Drawing.Point(65, 101)
        Me.TXT_DESTINO.Name = "TXT_DESTINO"
        Me.TXT_DESTINO.Size = New System.Drawing.Size(264, 20)
        Me.TXT_DESTINO.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Destino :"
        '
        'TXT_ORIGEN
        '
        Me.TXT_ORIGEN.Enabled = False
        Me.TXT_ORIGEN.Location = New System.Drawing.Point(65, 76)
        Me.TXT_ORIGEN.Name = "TXT_ORIGEN"
        Me.TXT_ORIGEN.Size = New System.Drawing.Size(264, 20)
        Me.TXT_ORIGEN.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Origen :"
        '
        'TXT_RETIRA
        '
        Me.TXT_RETIRA.Enabled = False
        Me.TXT_RETIRA.Location = New System.Drawing.Point(65, 50)
        Me.TXT_RETIRA.Name = "TXT_RETIRA"
        Me.TXT_RETIRA.Size = New System.Drawing.Size(264, 20)
        Me.TXT_RETIRA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Retira :"
        '
        'TXT_ENVIA
        '
        Me.TXT_ENVIA.Enabled = False
        Me.TXT_ENVIA.Location = New System.Drawing.Point(65, 24)
        Me.TXT_ENVIA.Name = "TXT_ENVIA"
        Me.TXT_ENVIA.Size = New System.Drawing.Size(264, 20)
        Me.TXT_ENVIA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Envia :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LST_TRACKING)
        Me.GroupBox2.Location = New System.Drawing.Point(366, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 154)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tracking de movimientos"
        '
        'LST_TRACKING
        '
        Me.LST_TRACKING.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LST_TRACKING.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LST_TRACKING.HideSelection = False
        Me.LST_TRACKING.HoverSelection = True
        Me.LST_TRACKING.Location = New System.Drawing.Point(6, 19)
        Me.LST_TRACKING.Name = "LST_TRACKING"
        Me.LST_TRACKING.Size = New System.Drawing.Size(325, 129)
        Me.LST_TRACKING.TabIndex = 0
        Me.LST_TRACKING.UseCompatibleStateImageBehavior = False
        Me.LST_TRACKING.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Ubicación"
        Me.ColumnHeader1.Width = 130
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Usuario"
        Me.ColumnHeader3.Width = 70
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CMB_SUCURSAL)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.CMB_ORIGEN)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(691, 124)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Aplicar ubicación"
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(499, 325)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 2
        Me.BTN_ACEPTAR.Text = "Aceptar"
        Me.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = False
        '
        'CMB_ORIGEN
        '
        Me.CMB_ORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_ORIGEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_ORIGEN.FormattingEnabled = True
        Me.CMB_ORIGEN.Location = New System.Drawing.Point(11, 44)
        Me.CMB_ORIGEN.Name = "CMB_ORIGEN"
        Me.CMB_ORIGEN.Size = New System.Drawing.Size(434, 26)
        Me.CMB_ORIGEN.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label32.Location = New System.Drawing.Point(10, 23)
        Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(121, 18)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Ubicación actual:"
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(604, 325)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 5
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'CMB_SUCURSAL
        '
        Me.CMB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_SUCURSAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.CMB_SUCURSAL.FormattingEnabled = True
        Me.CMB_SUCURSAL.Location = New System.Drawing.Point(11, 94)
        Me.CMB_SUCURSAL.Name = "CMB_SUCURSAL"
        Me.CMB_SUCURSAL.Size = New System.Drawing.Size(434, 26)
        Me.CMB_SUCURSAL.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label6.Location = New System.Drawing.Point(10, 73)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Sucursal destino :"
        '
        'EncomiendaMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 371)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TXT_GUIA)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "EncomiendaMant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Encomienda"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TXT_GUIA As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_ENVIA As TextBox
    Friend WithEvents TXT_RETIRA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_DESTINO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_ORIGEN As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_BULTO As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CMB_ORIGEN As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents LST_TRACKING As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents CMB_SUCURSAL As ComboBox
    Friend WithEvents Label6 As Label
End Class
