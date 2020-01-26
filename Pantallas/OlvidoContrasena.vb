Imports System.Net.Mail
Imports System.Text
Imports VentaRepuestos.Login
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class OlvidoContrasena

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
            Login.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub EnviarCorreo(ByVal Destinatario As String)
        Try
            If String.IsNullOrEmpty(TXT_DESTINATARIO.Text) Then
                MessageBox.Show("El campo [Destinatario] no puede estar en blanco")
                TXT_DESTINATARIO.Select()
            ElseIf ExisteDestinatario(TXT_DESTINATARIO.Text) = False Then
                MessageBox.Show("El Destinatario ingresado no está registrado en la base de datos")
                TXT_DESTINATARIO.Select()
            Else
                Dim CodigoVerificador As String = GeneraCodigoVerificador()

                Dim addressFrom As MailAddress = New MailAddress("vrenvios@gmail.com", "Recuperación contraseña")
                Dim addressTo As MailAddress = New MailAddress(Destinatario)
                Dim message As MailMessage = New MailMessage(addressFrom, addressTo)

                Dim SQL As String = "DELETE FROM USUARIO_CONTRA_RECUPERACION WHERE CORREO = " & SCM(Destinatario)
                SQL &= Chr(13) & " INSERT INTO USUARIO_CONTRA_RECUPERACION(CORREO,CODIGO_VERIFICADOR) "
                SQL &= Chr(13) & " SELECT " & SCM(Destinatario) & "," & SCM(CodigoVerificador)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                Dim TextoHTML As String = "<p>Estimado usuario, se ha solicitado un cambio en su contraseña actual, para dicho proceso se ha ingresado el correo electrónico <strong>{CORREO},&nbsp;</strong>en caso de que usted no haya solicitado dicho cambio de contraseña por favor informar al teléfono: 22445566.</p>
            <p>Su código de verificación es: <strong><span style=""font-size: 
                  18px;"">{CODIGO_VERIFICADOR}</span></strong></p>
            <p>Recuerde ingresar este código para poder realizar el cambio de contraseña.</p>
            <p><strong>[ No responder este correo, el mismo fue generado por un sistema automatizado]</strong></p>"

                TextoHTML = TextoHTML.Replace("{CORREO}", Destinatario)
                TextoHTML = TextoHTML.Replace("{CODIGO_VERIFICADOR}", CodigoVerificador)

                message.Subject = "Recuperación de contraseña"
                message.Body = TextoHTML
                message.IsBodyHtml = True

                Dim client As SmtpClient = New SmtpClient With {
                    .Host = "smtp.gmail.com",
                    .Port = 587,
                    .Credentials = New System.Net.NetworkCredential("vrenvios@gmail.com", "lenekpevzibiqysp"),
                    .EnableSsl = True
                }

                client.Send(message)
                Me.Close()
                CambioContrasena.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ENVIAR_Click(sender As Object, e As EventArgs) Handles BTN_ENVIAR.Click
        Try
            EnviarCorreo(TXT_DESTINATARIO.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function GeneraCodigoVerificador() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Static r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 6
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Public Function ExisteDestinatario(ByVal Destinatario As String) As Boolean
        Try
            Dim Bandera As Boolean = False
            Dim SQL As String = "SELECT * "
            SQL &= Chr(13) & " FROM USUARIO "
            SQL &= Chr(13) & " WHERE CORREO = " & SCM(TXT_DESTINATARIO.Text)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                Bandera = True
            End If

            Return Bandera
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class