Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Factura

    Dim Modo As CRF_Modos

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Me.Close()
    End Sub

    Sub New(ByVal Modo As CRF_Modos)

        InitializeComponent()
        Me.Modo = Modo
        TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)

        If Me.Modo = CRF_Modos.Insertar Then
            BloqueaControles()
            CMB_DOCUMENTO.SelectedIndex = 0
            CMB_FORMAPAGO.SelectedIndex = 0
            CMB_MONEDA.SelectedIndex = 0
        End If

    End Sub


    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = False
            TXT_TIPO_CAMBIO.Enabled = False
            DTPFECHA.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_DOCUMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_DOCUMENTO.SelectedIndexChanged
        If CMB_DOCUMENTO.SelectedIndex = 0 Then
            TXT_PLAZO.Text = "0"
            TXT_PLAZO.Enabled = False
        Else
            TXT_PLAZO.Enabled = True
        End If
    End Sub
End Class