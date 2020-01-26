<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActEconomicaMant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActEconomicaMant))
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.LBL_PROVINCIA = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_COD_ACT = New System.Windows.Forms.TextBox()
        Me.TXT_DES_ACT = New System.Windows.Forms.TextBox()
        Me.CK_PRINCIPAL = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ACEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR.Image = CType(resources.GetObject("BTN_ACEPTAR.Image"), System.Drawing.Image)
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(151, 226)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_ACEPTAR.TabIndex = 22
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
        Me.BTN_SALIR.Location = New System.Drawing.Point(249, 226)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 23
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = False
        '
        'LBL_PROVINCIA
        '
        Me.LBL_PROVINCIA.AutoSize = True
        Me.LBL_PROVINCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PROVINCIA.ForeColor = System.Drawing.Color.Black
        Me.LBL_PROVINCIA.Location = New System.Drawing.Point(12, 97)
        Me.LBL_PROVINCIA.Name = "LBL_PROVINCIA"
        Me.LBL_PROVINCIA.Size = New System.Drawing.Size(176, 18)
        Me.LBL_PROVINCIA.TabIndex = 26
        Me.LBL_PROVINCIA.Text = "Descripción de actividad :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 18)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Código de actividad :"
        '
        'TXT_COD_ACT
        '
        Me.TXT_COD_ACT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_COD_ACT.Location = New System.Drawing.Point(15, 56)
        Me.TXT_COD_ACT.MaxLength = 6
        Me.TXT_COD_ACT.Multiline = True
        Me.TXT_COD_ACT.Name = "TXT_COD_ACT"
        Me.TXT_COD_ACT.Size = New System.Drawing.Size(197, 24)
        Me.TXT_COD_ACT.TabIndex = 28
        '
        'TXT_DES_ACT
        '
        Me.TXT_DES_ACT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DES_ACT.Location = New System.Drawing.Point(15, 127)
        Me.TXT_DES_ACT.Multiline = True
        Me.TXT_DES_ACT.Name = "TXT_DES_ACT"
        Me.TXT_DES_ACT.Size = New System.Drawing.Size(333, 24)
        Me.TXT_DES_ACT.TabIndex = 29
        '
        'CK_PRINCIPAL
        '
        Me.CK_PRINCIPAL.AutoSize = True
        Me.CK_PRINCIPAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CK_PRINCIPAL.Location = New System.Drawing.Point(15, 174)
        Me.CK_PRINCIPAL.Name = "CK_PRINCIPAL"
        Me.CK_PRINCIPAL.Size = New System.Drawing.Size(228, 22)
        Me.CK_PRINCIPAL.TabIndex = 30
        Me.CK_PRINCIPAL.Text = "Definir como actividar principal"
        Me.CK_PRINCIPAL.UseVisualStyleBackColor = True
        '
        'ActEconomicaMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(360, 276)
        Me.ControlBox = False
        Me.Controls.Add(Me.CK_PRINCIPAL)
        Me.Controls.Add(Me.TXT_DES_ACT)
        Me.Controls.Add(Me.TXT_COD_ACT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBL_PROVINCIA)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ActEconomicaMant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actividad económica"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents LBL_PROVINCIA As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_COD_ACT As TextBox
    Friend WithEvents TXT_DES_ACT As TextBox
    Friend WithEvents CK_PRINCIPAL As CheckBox
End Class
