Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ReportesProcesos
    Public Shared Sub Genera_RPT_NC(ByVal TIPO_MOV As String, ByVal NUMERO_DOC As Integer, ByVal NOM_REPORTE As String, ByVal RUTA_DESCARGA As String)
        Try
            Dim Impresion_doc As Object = Nothing

            Impresion_doc = New Imprime_NC
            Impresion_doc.SetParameterValue("@COD_CIA", COD_CIA)
            Impresion_doc.SetParameterValue("@COD_SUCUR", COD_SUCUR)
            Impresion_doc.SetParameterValue("@NUMERO_DOC", NUMERO_DOC)
            Impresion_doc.SetParameterValue("@TIPO_MOV", TIPO_MOV)
            Impresion_doc.SummaryInfo.ReportTitle = NOM_REPORTE

            Dim Rep As New Reporte(Impresion_doc)
            Rep.Preparar_reporte("SERVICIO LOCAL", CONX.vUsuarioSQL, CONX.vContraseñaSQL, CONX.vBase_de_datos, CONX.vServidor)
            Rep.Exportar_en_server(RUTA_DESCARGA)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
