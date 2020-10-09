Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class RegistreseAqui
    Private Sub BTN_GUARDAR_Click(sender As Object, e As EventArgs) Handles BTN_GUARDAR.Click
        Try
            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                MessageBox.Show("¡Debe de ingresar el código de usuario!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CODIGO.Select()
            ElseIf String.IsNullOrEmpty(TXT_NOMUSUARIO.Text) Then
                MessageBox.Show("¡Debe de ingresar un nombre de usuario!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_NOMUSUARIO.Select()
            ElseIf String.IsNullOrEmpty(TXT_CONTRASENA.Text) Then
                MessageBox.Show("¡Debe de ingresar la contraseña!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CONTRASENA.Select()
            ElseIf String.IsNullOrEmpty(TXT_TELEFONO.Text) Then
                MessageBox.Show("¡Debe de ingresar el correo del usuario!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_TELEFONO.Select()
            ElseIf String.IsNullOrEmpty(TXT_DIRECCION.Text) Then
                MessageBox.Show("¡Debe de ingresar la dirección del usuario!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_DIRECCION.Select()
            ElseIf String.IsNullOrEmpty(TXT_CORREO.Text) Then
                MessageBox.Show("¡Debe de ingresar el correo del usuario!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CORREO.Select()
            ElseIf PictureBox1.Image Is Nothing Then
                MessageBox.Show("¡Debe seleccionar una imagen para el usuario!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim MS As New MemoryStream
                PictureBox1.Image.Save(MS, PictureBox1.Image.RawFormat)

                Dim COMANDO As New SqlCommand()
                COMANDO.CommandType = CommandType.StoredProcedure
                Dim COD_USUARIO As New SqlParameter("@COD_USUARIO", SqlDbType.VarChar)
                COD_USUARIO.Value = TXT_CODIGO.Text
                Dim NOMBRE As New SqlParameter("@NOMBRE", SqlDbType.VarChar)
                NOMBRE.Value = TXT_NOMUSUARIO.Text
                Dim TELEFONO As New SqlParameter("@TELEFONO", SqlDbType.VarChar)
                TELEFONO.Value = TXT_TELEFONO.Text
                Dim DIRECCION As New SqlParameter("@DIRECCION", SqlDbType.VarChar)
                DIRECCION.Value = TXT_DIRECCION.Text
                Dim CORREO As New SqlParameter("@CORREO", SqlDbType.VarChar)
                CORREO.Value = TXT_CORREO.Text
                Dim FOTO As New SqlParameter("@FOTO", SqlDbType.Image)
                FOTO.Value = MS.ToArray()
                Dim CONTRASENA As New SqlParameter("@CONTRASENA", SqlDbType.VarChar)
                CONTRASENA.Value = TXT_CONTRASENA.Text


                COMANDO.CommandText = "USP_INGRESA_USUARIO"
                COMANDO.Parameters.Add(COD_USUARIO)
                COMANDO.Parameters.Add(NOMBRE)
                COMANDO.Parameters.Add(TELEFONO)
                COMANDO.Parameters.Add(DIRECCION)
                COMANDO.Parameters.Add(CORREO)
                COMANDO.Parameters.Add(FOTO)
                COMANDO.Parameters.Add(CONTRASENA)

                CONX.Coneccion_Abrir()
                COMANDO.Connection = CONX.Connection
                Dim AR = COMANDO.ExecuteReader()
                AR.Close()
                CONX.Coneccion_Cerrar()

                LimpiarTodo()


                MessageBox.Show("Usuario ingresado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try
            Login.Visible = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SELECCIONAR_Click(sender As Object, e As EventArgs) Handles BTN_SELECCIONAR.Click
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

    Public Sub LimpiarTodo()
        TXT_CODIGO.Text = ""
        TXT_CONTRASENA.Text = ""
        TXT_CORREO.Text = ""
        TXT_DIRECCION.Text = ""
        TXT_NOMUSUARIO.Text = ""
        TXT_TELEFONO.Text = ""
        PictureBox1.Image = Nothing
    End Sub
End Class