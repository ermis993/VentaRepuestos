Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class CambioContrasena
    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                MessageBox.Show("El código verificador no puede ser vacío")
            ElseIf String.IsNullOrEmpty(TXT_NCONTRASENA.Text) Then
                MessageBox.Show("Debe de ingresar la contraseña nueva")
            ElseIf String.IsNullOrEmpty(TXT_DCONTRASENA.Text) Then
                MessageBox.Show("Debe ingresar nuevamente la contraseña")
            ElseIf TXT_NCONTRASENA.Text <> TXT_DCONTRASENA.Text Then
                MessageBox.Show("Las contraseñas ingresadas no coinciden")
            ElseIf ValidaCodigoVerificador() = False Then
                MessageBox.Show("Código verificador incorrecto")
            Else
                Dim Sql = "	UPDATE USUARIO	"
                Sql &= Chr(13) & "	SET CONTRASENA = " & SCM(TXT_NCONTRASENA.Text)
                Sql &= Chr(13) & "	FROM(	"
                Sql &= Chr(13) & "	SELECT CORREO			"
                Sql &= Chr(13) & "	FROM USUARIO_CONTRA_RECUPERACION "
                Sql &= Chr(13) & "	WHERE CODIGO_VERIFICADOR = " & SCM(TXT_CODIGO.Text)
                Sql &= Chr(13) & "	) AS T1			"
                Sql &= Chr(13) & "	WHERE T1.CORREO = USUARIO.CORREO "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()

                MessageBox.Show("Se cambió la contraseña con exito")
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Function ValidaCodigoVerificador() As Boolean
        Try
            Dim Bandera As Boolean = False
            Dim SQL As String = "SELECT * "
            SQL &= Chr(13) & " FROM USUARIO_CONTRA_RECUPERACION "
            SQL &= Chr(13) & " WHERE CODIGO_VERIFICADOR = " & SCM(TXT_CODIGO.Text)
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

    Private Sub CambioContrasena_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Visible = True
    End Sub
End Class