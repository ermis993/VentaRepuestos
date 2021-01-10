Imports VentaRepuestos.Globales
Imports VentaRepuestos.ReportesProcesos
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class Reportes_CXC

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub Reportes_CXC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_INICIO.Format = DateTimePickerFormat.Custom
        DTP_INICIO.CustomFormat = "dd-MM-yyyy"

        DTP_FINAL.Format = DateTimePickerFormat.Custom
        DTP_FINAL.CustomFormat = "dd-MM-yyyy"

        RellenaTreeView()

        DTP_FINAL.Enabled = TieneDerecho("FECREP")
        DTP_INICIO.Enabled = TieneDerecho("FECREP")
    End Sub


    Private Sub RellenaTreeView()
        Try
            Dim rootNode = TV_REPORTES.Nodes.Add("Reportes")
            rootNode.Nodes.Add("VDIA", "01. Reporte de ventas (impresión tiquete)")
            rootNode.Nodes.Add("DSAL", "02. Reporte de facturas de crédito con saldo")
            TV_REPORTES.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TV_REPORTES_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TV_REPORTES.AfterSelect
        Try
            Dim Nodo_Seleccionado As TreeNode = TV_REPORTES.SelectedNode
            LBL_REPORTE_SELECCIONADO.Text = Nodo_Seleccionado.Text
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
                    Case "VDIA"
                        Dim imp As New Impresion()
                        imp.ImprimirVenta(COD_CIA, COD_SUCUR, DTP_INICIO.Value, DTP_FINAL.Value)
                    Case "DSAL"
                        Dim f As FolderBrowserDialog = New FolderBrowserDialog
                        If f.ShowDialog() = DialogResult.OK Then
                            Dim Ruta = f.SelectedPath
                            Genera_RPT_Documentos_Por_Rango_Fechas("FA", YMD(DTP_INICIO.Value), YMD(DTP_FINAL.Value), "Facturas_credito_con_saldo", Ruta)
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
End Class