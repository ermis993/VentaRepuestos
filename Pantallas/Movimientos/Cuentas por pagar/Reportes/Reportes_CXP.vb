Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Imports VentaRepuestos.CXP_Proceso
Public Class Reportes_CXP
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub Reportes_CXP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_INICIO.Format = DateTimePickerFormat.Custom
        DTP_INICIO.CustomFormat = "dd-MM-yyyy"

        DTP_FINAL.Format = DateTimePickerFormat.Custom
        DTP_FINAL.CustomFormat = "dd-MM-yyyy"

        Bus_Proveedor.TABLA_BUSCAR = "PROVEEDOR"
        Bus_Proveedor.CODIGO = "CEDULA"
        Bus_Proveedor.DESCRIPCION = "NOMBRE"
        Bus_Proveedor.PANTALLA = New Proveedor(CRF_Modos.Seleccionar, Bus_Proveedor)
        Bus_Proveedor.refrescar()

        RellenaTreeView()

        DTP_FINAL.Enabled = TieneDerecho("FECREP")
        DTP_INICIO.Enabled = TieneDerecho("FECREP")
    End Sub

    Private Sub RellenaTreeView()
        Try
            Dim rootNode = TV_REPORTES.Nodes.Add("Reportes")
            rootNode.Nodes.Add("RAS01", "01. Reporte Antiguedad de saldos")

            TV_REPORTES.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TV_REPORTES_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TV_REPORTES.AfterSelect
        Try
            Dim Nodo_Seleccionado As TreeNode = TV_REPORTES.SelectedNode
            LBL_REPORTE_SELECCIONADO.Text = Nodo_Seleccionado.Text

            If Nodo_Seleccionado.Name = "RAS01" Then
                ActivarDesactivarControles(False, True, True)
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
                    Case "RAS01"
                        Dim f As FolderBrowserDialog = New FolderBrowserDialog
                        If f.ShowDialog() = DialogResult.OK Then
                            Dim Ruta = f.SelectedPath
                            Genera_RPT_ANTIGUEDAD_SALDOS(YMD(DTP_FINAL.Value), Bus_Proveedor.VALOR, Nodo_Seleccionado.Text, Ruta)
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

    Private Sub ActivarDesactivarControles(ByVal fecha_inicio As Boolean, ByVal fecha_final As Boolean, ByVal provedor As Boolean)
        DTP_INICIO.Enabled = fecha_inicio
        DTP_FINAL.Enabled = fecha_final
        Bus_Proveedor.Enabled = provedor
    End Sub

End Class