Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class Login
    Public Shared CONX As New SQLCON
    Public Shared USUARIO As String = ""

    Private Sub LOGIN_LOAD(sender As Object, e As EventArgs) Handles MyBase.Load
        CONFIGURACION()
    End Sub
    Private Sub CONFIGURACION()
        Try
            CONX.ConexionSTR("TOMMY\SQLEXPRESS", "sa", "Luna01x", "VR")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub INGRESAR(sender As Object, e As EventArgs) Handles BTN_INGRESAR.Click
        Try
            If VALIDAR() = True Then
                Dim SQL As String = " SELECT * "
                SQL &= Chr(13) & " FROM USUARIO"
                SQL &= Chr(13) & " WHERE COD_USUARIO = " & SCM(TXT_USUARIO.Text)
                SQL &= Chr(13) & " AND CONTRASENA = " & SCM(TXT_CONTRASENA.Text)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                Dim COINCIDENCIA As Boolean = False
                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        If TXT_USUARIO.Text.ToString.Equals(ITEM("COD_USUARIO")) And TXT_CONTRASENA.Text.ToString.Equals(ITEM("CONTRASENA")) Then
                            USUARIO = ITEM("COD_USUARIO")
                            COINCIDENCIA = True
                        End If
                    Next
                End If
                If COINCIDENCIA = True Then
                    Me.Hide()
                    Dim PANTALLA As New LBL_CANTON
                    PANTALLA.ShowDialog()
                Else
                    MessageBox.Show("¡Usuario no encontrado!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean = True
            If TXT_USUARIO.Text.ToString.Equals("") Then
                MessageBox.Show("¡Usuario inválido,no se deben dejar espacios en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ENTRAR = False
            End If
            If TXT_CONTRASENA.Text.ToString.Equals("") Then
                MessageBox.Show("¡Contraseña inválida, no se deben dejar espacios en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ENTRAR = False
            End If
            Return ENTRAR
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Application.Exit()
    End Sub
End Class
