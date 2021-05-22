Public Class DocumentoElectronicoCorreo
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_PROCESAR_Click(sender As Object, e As EventArgs) Handles BTN_PROCESAR.Click
        Try
            Dim mensaje As String = ""
            mensaje &= "¿Seguro que desea realizar el poceso de lectura del correo electrónico?" & vbNewLine
            mensaje &= "Este proceso leerá la bandeja de entrada del correo configurado" & vbNewLine
            mensaje &= ", el proceso puede tardar varios minutos en su lectura"
            Dim valor = MessageBox.Show(Me, mensaje, "Lectura correo", vbYesNo, MessageBoxIcon.Question)

            If valor Then

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class