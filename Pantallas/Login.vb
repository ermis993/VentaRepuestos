﻿Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class Login
    Private Sub LOGIN_LOAD(sender As Object, e As EventArgs) Handles MyBase.Load
        CONFIGURACION()
    End Sub
    Private Sub CONFIGURACION()
        Try
            'PRUEBAS
            CONX.Inicializar_cadena_conexion("DESKTOP-42HEF7C,1433", "sa", "1234", "VR_AU")
            CONX_SIC.ConexionSTR("DESKTOP-42HEF7C,1433", "sa", "1234", "INFORMACION_SIC")
            'AUTORESPUESTOS LA UNION
            'CONX.Inicializar_cadena_conexion("DESKTOP-OG4U60G\SQLEXPRESS,1433", "sa", "union1234", "VR")
            'CONX_SIC.ConexionSTR("DESKTOP-OG4U60G\SQLEXPRESS,1433", "sa", "union1234", "INFORMACION_SIC")
            'BIKE_RIDE'
            'CONX.Inicializar_cadena_conexion("DESKTOP-7F4Q844, 1433", "sa", "1234", "VR")
            'CONX_SIC.ConexionSTR("DESKTOP-7F4Q844, 1433", "sa", "1234", "INFORMACION_SIC")
            'VEFESA
            'CONX.Inicializar_cadena_conexion("DESKTOP-4JGE226,1433", "sa", "1234", "VR")
            'CONX_SIC.ConexionSTR("DESKTOP-4JGE226,1433", "sa", "1234", "INFORMACION_SIC")
            ''VEGA SIQUIRRES
            'CONX.Inicializar_cadena_conexion("DESKTOP-3SQLS3O,1433", "sa", "1234", "VR")
            'CONX_SIC.ConexionSTR("DESKTOP-3SQLS3O,1433", "sa", "1234", "INFORMACION_SIC")
            'VEGA TURRIALBA
            'CONX.Inicializar_cadena_conexion("DESKTOP-KN02T18,1433", "sa", "1234", "VR")
            'CONX_SIC.ConexionSTR("DESKTOP-KN02T18,1433", "sa", "1234", "INFORMACION_SIC")
            'REPUESTOS LUNA
            'CONX.ConexionSTR("DESKTOP-QT8JTJF,1433", "sa", "union1234", "VR_REPLUNA")
            'CONX_SIC.ConexionSTR("DESKTOP-QT8JTJF,1433", "sa", "union1234", "INFORMACION_SIC")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Ingreso()
        Try
            If VALIDAR() = True Then
                Dim SQL As String = " SELECT * "
                SQL &= Chr(13) & " FROM USUARIO"
                SQL &= Chr(13) & " WHERE (COD_USUARIO = " & SCM(TXT_USUARIO.Text.Trim) & " OR CORREO =" & SCM(TXT_USUARIO.Text.Trim) & ")"
                SQL &= Chr(13) & " AND CONTRASENA = " & SCM(TXT_CONTRASENA.Text.Trim)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                Dim COINCIDENCIA As Boolean = False
                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        COD_USUARIO = ITEM("COD_USUARIO")
                        COINCIDENCIA = True
                    Next
                End If
                If COINCIDENCIA = True Then
                    If ValidaFormatoPC() Then
                        TXT_USUARIO.Text = ""
                        TXT_CONTRASENA.Text = ""
                        Me.Visible = False
                        Dim PANTALLA As New SeleccionCompania()
                        PANTALLA.Show()
                    Else
                        MessageBox.Show("¡El formato de fecha leído es incorrecto para el sistema, intente cerrar y volver a abrir el sistema!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("¡Usuario no encontrado!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ValidaFormatoPC() As Boolean
        Try
            Dim FECHA_SYSTEMA As String
            FECHA_SYSTEMA = YMD(FECHA_HOY)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Sub INGRESAR(sender As Object, e As EventArgs) Handles BTN_INGRESAR.Click
        Ingreso()
    End Sub

    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean = True
            If TXT_USUARIO.Text.ToString.Equals("") Then
                MessageBox.Show("¡Usuario inválido,no se deben dejar espacios en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ENTRAR = False
            End If
            If TXT_CONTRASENA.Text.ToString.Equals("") Then
                MessageBox.Show("¡Contraseña inválida, no se deben dejar espacios en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ENTRAR = False
            End If
            Return ENTRAR
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub LBL_REGISTRARSE_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LBL_REGISTRARSE.LinkClicked
        Try
            Me.Visible = False
            RegistreseAqui.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LBL_OLVIDO_MouseClick(sender As Object, e As MouseEventArgs) Handles LBL_OLVIDO.MouseClick

    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub LBL_OLVIDO_Click(sender As Object, e As EventArgs) Handles LBL_OLVIDO.Click
        Try
            Me.Visible = False
            OlvidoContrasena.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXT_CONTRASENA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_CONTRASENA.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Ingreso()
        End If
    End Sub

    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        TXT_USUARIO.Select()
    End Sub
End Class
