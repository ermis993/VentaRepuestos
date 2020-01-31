Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class Facturacion
    Private Sub BTN_FACTURAR_Click(sender As Object, e As EventArgs) Handles BTN_FACTURAR.Click
        Try
            Dim PANTALLA As New Factura(CRF_Modos.Insertar)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Me.Close()
    End Sub
End Class