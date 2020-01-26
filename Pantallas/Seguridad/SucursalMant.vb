Imports System.Data.SqlClient
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class SucursalMant
    Dim MODO As New CRF_Modos
    Dim PADRE As New Sucursal

    Private Sub SucursalMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXT_CODIGO.Text = GeneraCodigoSucursal()
    End Sub

    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Sucursal)
        InitializeComponent()
        Me.MODO = MODO
        Me.PADRE = PADRE
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            Dim Estado As String

            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                MessageBox.Show("El código de sucursal no puede ser vacío")
            ElseIf String.IsNullOrEmpty(TXT_NOMBRE.Text) Then
                MessageBox.Show("Debe ingresar el nombre de la sucursal")
                TXT_NOMBRE.Select()
            ElseIf String.IsNullOrEmpty(TXT_DIRECCION.Text) Then
                MessageBox.Show("Debe ingresar la dirección de la sucursal")
                TXT_DIRECCION.Select()
            ElseIf String.IsNullOrEmpty(TXT_TELEFONO.Text) Then
                MessageBox.Show("Debe ingresar el teléfono de la sucursal")
                TXT_TELEFONO.Select()
            ElseIf String.IsNullOrEmpty(TXT_CORREO.Text) Then
                MessageBox.Show("Es necesario un correo para la sucursal")
                TXT_CORREO.Select()
            Else

                If RB_ACTIVA.Checked Then
                    Estado = "A"
                Else
                    Estado = "I"
                End If

                If MODO = 1 Then
                    Using (CONX.Connection)
                        Dim sqlComm As New SqlCommand With {
                        .Connection = CONX.Connection,
                        .CommandText = "USP_SUCURSAL_MANTENIMIENTO",
                        .CommandType = CommandType.StoredProcedure
                    }

                        sqlComm.Parameters.AddWithValue("@COD_CIA", COD_CIA)
                        sqlComm.Parameters.AddWithValue("@COD_SUCUR", TXT_CODIGO.Text)
                        sqlComm.Parameters.AddWithValue("@NOMBRE", TXT_NOMBRE.Text)
                        sqlComm.Parameters.AddWithValue("@DIRECCION", TXT_DIRECCION.Text)
                        sqlComm.Parameters.AddWithValue("@TELEFONO", TXT_TELEFONO.Text)
                        sqlComm.Parameters.AddWithValue("@CORREO", TXT_CORREO.Text)
                        sqlComm.Parameters.AddWithValue("@ESTADO", Estado)
                        sqlComm.Parameters.AddWithValue("@MODO", Me.MODO)

                        CONX.Coneccion_Abrir()
                        sqlComm.ExecuteNonQuery()
                        CONX.Coneccion_Cerrar()

                    End Using

                    LimpiarTodo()
                    MessageBox.Show("Sucursal ingresada correctamente")
                    PADRE.Refrescar()

                ElseIf MODO = 3 Then
                    Using (CONX.Connection)

                        Dim sqlComm As New SqlCommand With {
                        .Connection = CONX.Connection,
                        .CommandText = "USP_SUCURSAL_MANTENIMIENTO",
                        .CommandType = CommandType.StoredProcedure
                    }

                        sqlComm.Parameters.AddWithValue("@COD_CIA", COD_CIA)
                        sqlComm.Parameters.AddWithValue("@COD_SUCUR", TXT_CODIGO.Text)
                        sqlComm.Parameters.AddWithValue("@NOMBRE", TXT_NOMBRE.Text)
                        sqlComm.Parameters.AddWithValue("@DIRECCION", TXT_DIRECCION.Text)
                        sqlComm.Parameters.AddWithValue("@TELEFONO", TXT_TELEFONO.Text)
                        sqlComm.Parameters.AddWithValue("@CORREO", TXT_CORREO.Text)
                        sqlComm.Parameters.AddWithValue("@ESTADO", Estado)
                        sqlComm.Parameters.AddWithValue("@MODO", Me.MODO)

                        CONX.Coneccion_Abrir()
                        sqlComm.ExecuteNonQuery()
                        CONX.Coneccion_Cerrar()

                    End Using

                    LimpiarTodo()
                    MessageBox.Show("Sucursal modificada correctamente")
                    PADRE.Refrescar()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarTodo()
        TXT_CODIGO.Text = ""
        TXT_NOMBRE.Text = ""
        TXT_CORREO.Text = ""
        TXT_DIRECCION.Text = ""
        TXT_TELEFONO.Text = ""
    End Sub

End Class