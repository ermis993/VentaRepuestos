Imports System.Data.SqlClient
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class SucursalMant
    Dim MODO As New CRF_Modos
    Dim PADRE As Sucursal
    Dim COD_SUCUR As String

    Private Sub SucursalMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MODO = CRF_Modos.Insertar Then
            TXT_CODIGO.Text = GeneraCodigoSucursal()
        End If
    End Sub

    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Sucursal, Optional ByVal COD_SUCUR As String = "")
        InitializeComponent()
        Me.MODO = MODO
        Me.PADRE = PADRE
        Me.COD_SUCUR = COD_SUCUR

        If MODO = CRF_Modos.Modificar Then
            LEER()
        End If

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

                Dim SQL As String = "EXEC USP_SUCURSAL_MANTENIMIENTO"
                SQL &= Chr(13) & " @COD_CIA=" & SCM(COD_CIA)
                SQL &= Chr(13) & ",@COD_SUCUR=" & SCM(TXT_CODIGO.Text)
                SQL &= Chr(13) & ",@NOMBRE=" & SCM(TXT_NOMBRE.Text)
                SQL &= Chr(13) & ",@DIRECCION=" & SCM(TXT_DIRECCION.Text)
                SQL &= Chr(13) & ",@TELEFONO=" & SCM(TXT_TELEFONO.Text)
                SQL &= Chr(13) & ",@CORREO=" & SCM(TXT_CORREO.Text)
                SQL &= Chr(13) & ",@ESTADO=" & SCM(Estado)
                SQL &= Chr(13) & ",@MODO=" & Val(Me.MODO)

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                LimpiarTodo()
                If MODO = CRF_Modos.Insertar Then
                    MessageBox.Show("Sucursal ingresada correctamente")
                    Me.Close()
                ElseIf MODO = CRF_Modos.Modificar Then
                    MessageBox.Show("Sucursal modificada correctamente")
                    Me.Close()
                End If

                PADRE.Refrescar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LEER()
        Try
            Dim SQL As String = "EXEC USP_SUCURSAL_MANTENIMIENTO"
            SQL &= Chr(13) & "@COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & ",@COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Seleccionar)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    TXT_CODIGO.Text = COD_SUCUR
                    TXT_NOMBRE.Text = ITEM("NOMBRE")
                    TXT_DIRECCION.Text = ITEM("DIRECCION")
                    TXT_CORREO.Text = ITEM("CORREO")
                    TXT_TELEFONO.Text = ITEM("TELEFONO")

                    If ITEM("ESTADO") = "A" Then
                        RB_ACTIVA.Checked = True
                    Else
                        RB_INACTIVA.Checked = True
                    End If
                Next
            End If
        Catch ex As Exception

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