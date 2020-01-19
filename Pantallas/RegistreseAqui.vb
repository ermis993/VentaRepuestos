Public Class RegistreseAqui
    Private Sub BTN_GUARDAR_Click(sender As Object, e As EventArgs) Handles BTN_GUARDAR.Click
        Try
            If String.IsNullOrEmpty(TXT_NOMUSUARIO.Text) Then
                MessageBox.Show("¡Debe de ingresar un nombre de usuario!")
                TXT_NOMUSUARIO.Select()
            ElseIf String.IsNullOrEmpty(TXT_CONTRASENA.Text) Then
                MessageBox.Show("¡Debe de ingresar la contraseña!")
            ElseIf String.IsNullOrEmpty(TXT_TELEFONO.Text) Then
                MessageBox.Show("¡Debe de ingresar el correo del usuario!")
            ElseIf String.IsNullOrEmpty(TXT_DIRECCION.Text) Then
                MessageBox.Show("¡Debe de ingresar la dirección del usuario!")
            ElseIf String.IsNullOrEmpty(TXT_CORREO.Text) Then
                MessageBox.Show("¡Debe de ingresar el correo del usuario!")
            Else
                MessageBox.Show("Datos están correctos")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Login.Show()
            Me.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class