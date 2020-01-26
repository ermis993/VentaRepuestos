Public Class MenuPrincipal
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
            Login.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class