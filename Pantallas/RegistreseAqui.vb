Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports VentaRepuestos.Login

Public Class RegistreseAqui
    Private Sub BTN_GUARDAR_Click(sender As Object, e As EventArgs) Handles BTN_GUARDAR.Click
        Try
            If String.IsNullOrEmpty(TXT_NOMUSUARIO.Text) Then
                MessageBox.Show("¡Debe de ingresar un nombre de usuario!", "Error")
                TXT_NOMUSUARIO.Select()
            ElseIf String.IsNullOrEmpty(TXT_CONTRASENA.Text) Then
                MessageBox.Show("¡Debe de ingresar la contraseña!", "Error")
                TXT_CONTRASENA.Select()
            ElseIf String.IsNullOrEmpty(TXT_TELEFONO.Text) Then
                MessageBox.Show("¡Debe de ingresar el correo del usuario!", "Error")
                TXT_TELEFONO.Select()
            ElseIf String.IsNullOrEmpty(TXT_DIRECCION.Text) Then
                MessageBox.Show("¡Debe de ingresar la dirección del usuario!", "Error")
                TXT_DIRECCION.Select()
            ElseIf String.IsNullOrEmpty(TXT_CORREO.Text) Then
                MessageBox.Show("¡Debe de ingresar el correo del usuario!", "Error")
                TXT_CORREO.Select()
            Else

                Dim MS As New MemoryStream
                PictureBox1.Image.Save(MS, PictureBox1.Image.RawFormat)

                Dim CodigoUsuario = GenerarCodigoUsuario()

                Using (CONX.Connection)

                    Dim sqlComm As New SqlCommand With {
                        .Connection = CONX.Connection,
                        .CommandText = "USP_INGRESA_USUARIO",
                        .CommandType = CommandType.StoredProcedure
                    }

                    sqlComm.Parameters.AddWithValue("@COD_USUARIO", CodigoUsuario)
                    sqlComm.Parameters.AddWithValue("@NOMBRE", TXT_NOMUSUARIO.Text)
                    sqlComm.Parameters.AddWithValue("@TELEFONO", TXT_TELEFONO.Text)
                    sqlComm.Parameters.AddWithValue("@DIRECCION", TXT_DIRECCION.Text)
                    sqlComm.Parameters.AddWithValue("@CORREO", TXT_CORREO.Text)
                    sqlComm.Parameters.AddWithValue("@FOTO", MS.ToArray())
                    sqlComm.Parameters.AddWithValue("@CONTRASENA", TXT_CONTRASENA.Text)

                    CONX.Coneccion_Abrir()
                    sqlComm.ExecuteNonQuery()
                    CONX.Coneccion_Cerrar()

                End Using

                LimpiarTodo()
                MessageBox.Show("Usuario ingresado correctamente", "Aviso")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Login.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTN_SELECCIONAR.Click
        Try
            Dim OPF As New OpenFileDialog With {
                .Filter = "Seleccionar Imagen(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*gif"
            }

            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OPF.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function GenerarCodigoUsuario() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Static r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function


    Public Sub LimpiarTodo()
        TXT_CONTRASENA.Text = ""
        TXT_CORREO.Text = ""
        TXT_DIRECCION.Text = ""
        TXT_NOMUSUARIO.Text = ""
        TXT_TELEFONO.Text = ""
        PictureBox1.Image = Nothing
    End Sub
End Class