<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RespuestaDGTD
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
        Me.BTN_SALIR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_DOCUMENTO = New System.Windows.Forms.TextBox()
        Me.TXT_CONSECUTIVO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_CLAVE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_RECHAZO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_DESCARGAR_XML = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_SALIR.Image = Global.VentaRepuestos.My.Resources.Resources.salir
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SALIR.Location = New System.Drawing.Point(321, 406)
        Me.BTN_SALIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(99, 43)
        Me.BTN_SALIR.TabIndex = 8
        Me.BTN_SALIR.Text = "Salir"
        Me.BTN_SALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Documento"
        '
        'TXT_DOCUMENTO
        '
        Me.TXT_DOCUMENTO.Location = New System.Drawing.Point(3, 25)
        Me.TXT_DOCUMENTO.Name = "TXT_DOCUMENTO"
        Me.TXT_DOCUMENTO.ReadOnly = True
        Me.TXT_DOCUMENTO.Size = New System.Drawing.Size(244, 20)
        Me.TXT_DOCUMENTO.TabIndex = 1
        '
        'TXT_CONSECUTIVO
        '
        Me.TXT_CONSECUTIVO.Location = New System.Drawing.Point(3, 64)
        Me.TXT_CONSECUTIVO.Name = "TXT_CONSECUTIVO"
        Me.TXT_CONSECUTIVO.ReadOnly = True
        Me.TXT_CONSECUTIVO.Size = New System.Drawing.Size(244, 20)
        Me.TXT_CONSECUTIVO.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Consecutivo"
        '
        'TXT_CLAVE
        '
        Me.TXT_CLAVE.Location = New System.Drawing.Point(3, 103)
        Me.TXT_CLAVE.Name = "TXT_CLAVE"
        Me.TXT_CLAVE.ReadOnly = True
        Me.TXT_CLAVE.Size = New System.Drawing.Size(417, 20)
        Me.TXT_CLAVE.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Clave"
        '
        'TXT_RECHAZO
        '
        Me.TXT_RECHAZO.Location = New System.Drawing.Point(3, 142)
        Me.TXT_RECHAZO.Multiline = True
        Me.TXT_RECHAZO.Name = "TXT_RECHAZO"
        Me.TXT_RECHAZO.ReadOnly = True
        Me.TXT_RECHAZO.Size = New System.Drawing.Size(417, 259)
        Me.TXT_RECHAZO.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Motivo rechazo"
        '
        'BTN_DESCARGAR_XML
        '
        Me.BTN_DESCARGAR_XML.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_DESCARGAR_XML.Image = Global.VentaRepuestos.My.Resources.Resources.recibir
        Me.BTN_DESCARGAR_XML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_DESCARGAR_XML.Location = New System.Drawing.Point(3, 406)
        Me.BTN_DESCARGAR_XML.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_DESCARGAR_XML.Name = "BTN_DESCARGAR_XML"
        Me.BTN_DESCARGAR_XML.Size = New System.Drawing.Size(99, 43)
        Me.BTN_DESCARGAR_XML.TabIndex = 9
        Me.BTN_DESCARGAR_XML.Text = "Descargar"
        Me.BTN_DESCARGAR_XML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_DESCARGAR_XML.UseVisualStyleBackColor = True
        '
        'RespuestaDGTD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_DESCARGAR_XML)
        Me.Controls.Add(Me.TXT_RECHAZO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXT_CLAVE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXT_CONSECUTIVO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXT_DOCUMENTO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_SALIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "RespuestaDGTD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Respuesta DGTD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_DOCUMENTO As TextBox
    Friend WithEvents TXT_CONSECUTIVO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_CLAVE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_RECHAZO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_DESCARGAR_XML As Button
End Class
