Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class Form1
    Public Shared CONX As New SQLCON
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim SQL As String = " SELECT * "
            SQL &= Chr(13) & " FROM USUARIO"
            SQL &= Chr(13) & " WHERE COD_USUARIO = " & SCM(TXT_USUARIO.Text)
            SQL &= Chr(13) & " AND CONTRASENA = " & SCM(TXT_CONTRASENA.Text)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Configuracion_inicial()
    End Sub
    Private Sub Configuracion_inicial()
        Try
            CONX.ConexionSTR("TOMMY\SQLEXPRESS", "sa", "Luna01x", "VR")
        Catch ex As Exception
        End Try
    End Sub
End Class
