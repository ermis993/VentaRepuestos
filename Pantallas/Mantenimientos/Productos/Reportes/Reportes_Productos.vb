﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Imports VentaRepuestos.ProductoProceso

Public Class Reportes_Productos
    Private Sub ReportesProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_INICIO.Format = DateTimePickerFormat.Custom
        DTP_INICIO.CustomFormat = "dd-MM-yyyy"

        DTP_FINAL.Format = DateTimePickerFormat.Custom
        DTP_FINAL.CustomFormat = "dd-MM-yyyy"

        RellenaTreeView()
        RellenarFamilias()

        DTP_FINAL.Enabled = TieneDerecho("FECREP")
        DTP_INICIO.Enabled = TieneDerecho("FECREP")
    End Sub

    Private Sub RellenaTreeView()
        Try
            Dim rootNode = TV_REPORTES.Nodes.Add("Reportes")
            rootNode.Nodes.Add("RINVEN", "01. Reporte de inventario por familia")
            TV_REPORTES.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TV_REPORTES_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TV_REPORTES.AfterSelect
        Try
            Dim Nodo_Seleccionado As TreeNode = TV_REPORTES.SelectedNode
            LBL_REPORTE_SELECCIONADO.Text = Nodo_Seleccionado.Text

            If Nodo_Seleccionado.Name = "RINVEN" Then
                ActivarDesactivarControles(False, False, True)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        Try
            Dim Nodo_Seleccionado As TreeNode = TV_REPORTES.SelectedNode

            If Nodo_Seleccionado IsNot Nothing Then
                Cursor.Current = Cursors.WaitCursor
                Select Case Nodo_Seleccionado.Name
                    Case "RINVEN"
                        Dim f As FolderBrowserDialog = New FolderBrowserDialog
                        If f.ShowDialog() = DialogResult.OK Then
                            Dim Ruta = f.SelectedPath
                            Genera_RPT_INVENTARIO_POR_FAMILIA(CMB_FAMILIA.SelectedValue, Nodo_Seleccionado.Text, Ruta)
                            MessageBox.Show(Me, "Reporte generado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                End Select
                Cursor.Current = Cursors.Default
            Else
                MessageBox.Show(Me, "Se debe seleccionar el reporte a generar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ActivarDesactivarControles(ByVal fecha_inicio As Boolean, ByVal fecha_final As Boolean, ByVal familia As Boolean)
        DTP_INICIO.Enabled = fecha_inicio
        DTP_FINAL.Enabled = fecha_final
        CMB_FAMILIA.Enabled = familia
    End Sub

    Private Sub RellenarFamilias()
        Try
            CMB_FAMILIA.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = ""
            SQL = "SELECT '' AS CODIGO, 'Todas' AS DESCRIPCION"
            SQL &= Chr(13) & " UNION ALL"
            SQL &= Chr(13) & " SELECT CODIGO, DESCRIPCION"
            SQL &= Chr(13) & " FROM FAMILIA"
            SQL &= Chr(13) & " WHERE ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                For Each ITEM In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(ITEM("CODIGO").ToString, ITEM("DESCRIPCION").ToString.ToUpper))
                Next

                CMB_FAMILIA.DataSource = LISTA_REF
                CMB_FAMILIA.ValueMember = "Key"
                CMB_FAMILIA.DisplayMember = "Value"
                CMB_FAMILIA.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
End Class