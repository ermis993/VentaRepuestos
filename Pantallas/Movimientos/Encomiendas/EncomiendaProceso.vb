Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class EncomiendaProceso
    Public Shared Sub Genera_RPT_ENCOMIENDAS_POR_RANGO_FECHAS(ByVal DESDE As String, ByVal HASTA As String, ByVal NOM_REPORTE As String, ByVal RUTA_DESCARGA As String)
        Try
            Dim Impresion_doc As Object = Nothing

            Impresion_doc = New RPT_ENCOMIENDAS_POR_RANGO_FECHAS
            Impresion_doc.SetParameterValue("@COD_CIA", COD_CIA)
            Impresion_doc.SetParameterValue("@COD_SUCUR", COD_SUCUR)
            Impresion_doc.SetParameterValue("@DESDE", DESDE)
            Impresion_doc.SetParameterValue("@HASTA", HASTA)
            Impresion_doc.SummaryInfo.ReportTitle = NOM_REPORTE

            Dim Rep As New Reporte(Impresion_doc)
            Rep.Preparar_reporte("SERVICIO LOCAL", CONX.vUsuarioSQL, CONX.vContraseñaSQL, CONX.vBase_de_datos, CONX.vServidor)
            Rep.Exportar_en_server(RUTA_DESCARGA)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
