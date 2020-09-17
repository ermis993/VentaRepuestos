Imports VentaRepuestos.EncomiendaProceso
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class EncomiendaReporte
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub EncomiendaReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_INICIO.Format = DateTimePickerFormat.Custom
        DTP_INICIO.CustomFormat = "dd-MM-yyyy hh:mm:ss"

        DTP_FINAL.Format = DateTimePickerFormat.Custom
        DTP_FINAL.CustomFormat = "dd-MM-yyyy hh:mm:ss"


        RellenaTreeView()
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        Try
            Dim Nodo_Seleccionado As TreeNode = TV_REPORTES.SelectedNode

            If Nodo_Seleccionado IsNot Nothing Then
                Select Case Nodo_Seleccionado.Name
                    Case "ENC01"
                        Dim f As FolderBrowserDialog = New FolderBrowserDialog
                        If f.ShowDialog() = DialogResult.OK Then
                            Dim Ruta = f.SelectedPath
                            Genera_RPT_ENCOMIENDAS_POR_RANGO_FECHAS(YMDHms(DTP_INICIO.Value), YMDHms(DTP_FINAL.Value), Nodo_Seleccionado.Text, Ruta)
                            MessageBox.Show(Me, "Reporte generado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                End Select
            Else
                MessageBox.Show(Me, "Se debe seleccionar el reporte a generar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub RellenaTreeView()
        Try
            Dim rootNode = TV_REPORTES.Nodes.Add("Reportes")
            rootNode.Nodes.Add("ENC01", "01. Reporte de encomiendas pendientes por rango de fechas")

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
End Class