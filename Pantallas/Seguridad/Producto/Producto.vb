Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class Producto
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            Dim Pantalla As New ProductoMant(CRF_Modos.Insertar, Me)
            Pantalla.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
End Class