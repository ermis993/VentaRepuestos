Imports Limilabs.Mail
Imports Limilabs.Client.IMAP

Public Class MetodosImap

    Public Shared Function ConectarIMAP(ByVal Servidor As String, ByVal Usuario As String, ByVal Contrasena As String, ByVal Puerto As Integer, ByVal SSL As Boolean) As Imap
        Try
            Dim Imap_V As New Imap()

            Imap_V.Connect(Servidor, Puerto, SSL)
            Imap_V.UseBestLogin(Usuario, Contrasena)

            Return Imap_V
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Sub DesconectarImap(ByVal IMAP As Imap)
        Try
            IMAP.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class
