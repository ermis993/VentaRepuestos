﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class SeleccionCompania

    Private Sub SeleccionCompania_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGAR_COMPANIAS()
    End Sub
    Private Sub CARGAR_COMPANIAS()
        Try
            CMB_COMPANIA.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = ""
            If COD_USUARIO = "LUNAING" Then
                SQL = "SELECT COD_CIA AS CODIGO , NOMBRE"
                SQL &= Chr(13) & " FROM COMPANIA "
            Else
                SQL = "SELECT C.COD_CIA AS CODIGO , C.NOMBRE"
                SQL &= Chr(13) & " FROM COMPANIA AS C"
                SQL &= Chr(13) & " INNER JOIN COMPANIA_USUARIO AS CU"
                SQL &= Chr(13) & "  ON CU.COD_CIA = C.COD_CIA"
                SQL &= Chr(13) & "  AND CU.COD_USUARIO = " & SCM(COD_USUARIO)
                SQL &= Chr(13) & " WHERE C.ESTADO ='A'"
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                LISTA_REF.Add(New KeyValuePair(Of String, String)("", ""))
                For Each ITEM In DS.Tables(0).Rows

                    If ITEM("CODIGO") = "GLB" And COD_USUARIO = "LUNAING" Then
                        LISTA_REF.Add(New KeyValuePair(Of String, String)(ITEM("CODIGO").ToString, ITEM("CODIGO").ToString & " - " & ITEM("NOMBRE").ToString.ToUpper))
                    Else
                        LISTA_REF.Add(New KeyValuePair(Of String, String)(ITEM("CODIGO").ToString, ITEM("CODIGO").ToString & " - " & ITEM("NOMBRE").ToString.ToUpper))
                    End If
                Next
                CMB_COMPANIA.DataSource = LISTA_REF
                CMB_COMPANIA.ValueMember = "Key"
                CMB_COMPANIA.DisplayMember = "Value"
                CMB_COMPANIA.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            COD_CIA = CMB_COMPANIA.SelectedValue
            If COD_CIA <> "" And IsNothing(COD_CIA) = False Then
                Actualizaciones()
                IND_ENCOMIENDA = CARGAR_INDICADORES(COD_CIA)
                Dim FECHA = DateTime.Now.ToString
                If EXISTE_TC_CIA(FECHA) = False Then
                    If EXISTE_TC(FECHA) = False Then
                        TIPO_CAMBIO_INDICADORES_ECONOMICOS(FECHA)
                    End If
                    GUARDAR_TIPO_CAMBIO(FECHA)
                End If
                Me.Close()
                Dim PANTALLA As New MenuPrincipal()
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Actualizaciones()
        Try
            LBL_MENSAJE.Visible = True
            LBL_MENSAJE.Update()
            PG_ACTUALIZACIONES.Visible = True
            Dim Actualizar As New Actualizaciones
            Actualizar.ACTUALIZACIONES(PG_ACTUALIZACIONES)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
        Login.Visible = True
    End Sub
End Class