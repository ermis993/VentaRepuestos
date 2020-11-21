Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class Reportes
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMB_MODULO.SelectedValue = "CXC" Then
                Select Case CMB_TIPO.SelectedValue
                    Case "TRI"
                        Select Case CMB_REPORTE.SelectedValue
                            Case "01"
                                PB_CARGA.Increment(5)
                                Dim SQL = "	SELECT CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2 AS Cliente, ''+DOC_ELEC.CONSECUTIVO AS Documento, CONVERT(varchar, ENC.FECHA, 111) AS Fecha, ENC.TIPO_MOV as Tipo	"
                                SQL &= Chr(13) & "	,CASE WHEN ENC.TIPO_MOV = 'NC' THEN ENC.MONTO * -1 ELSE  ENC.MONTO END AS Subtotal, CASE WHEN ENC.TIPO_MOV = 'NC' THEN ENC.IMPUESTO * -1 ELSE ENC.IMPUESTO  END AS Impuesto	"
                                SQL &= Chr(13) & "	,CASE WHEN ENC.TIPO_MOV = 'NC' THEN (ENC.MONTO + ENC.IMPUESTO) * -1 ELSE (ENC.MONTO + ENC.IMPUESTO) END AS Total	"
                                SQL &= Chr(13) & "	FROM DOCUMENTO_ENC AS ENC	"
                                SQL &= Chr(13) & "	INNER JOIN CLIENTE AS CLI	"
                                SQL &= Chr(13) & "		ON CLI.COD_CIA = ENC.COD_CIA "
                                SQL &= Chr(13) & "		AND CLI.CEDULA = ENC.CEDULA "
                                SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_ELECTRONICO AS DOC_ELEC "
                                SQL &= Chr(13) & "		ON DOC_ELEC.COD_CIA = ENC.COD_CIA "
                                SQL &= Chr(13) & "		AND DOC_ELEC.COD_SUCUR = ENC.COD_SUCUR "
                                SQL &= Chr(13) & "		AND DOC_ELEC.NUMERO_DOC = ENC.NUMERO_DOC "
                                SQL &= Chr(13) & "		AND DOC_ELEC.TIPO_MOV = ENC.TIPO_MOV "
                                SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                                'SQL &= Chr(13) & "	AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                                SQL &= Chr(13) & "	AND ENC.FECHA BETWEEN " & SCM(YMD(DTP_INICIO.Value)) & " AND " & SCM(YMD(DTP_FINAL.Value))
                                SQL &= Chr(13) & "	AND ENC.TIPO_MOV IN ('FA', 'FC', 'NC', 'ND') "
                                SQL &= Chr(13) & "	ORDER BY ENC.FECHA ASC	"
                                CONX.Coneccion_Abrir()
                                Dim DS = CONX.EJECUTE_DS(SQL)
                                CONX.Coneccion_Cerrar()

                                PB_CARGA.Increment(10)

                                If DS.Tables(0).Rows.Count > 0 Then
                                    If EXPORTAR_EXCEL(DS, "D151(CXC)_del_" + DMA(DTP_INICIO.Value).Replace("/", "-") + "_al_" + DMA(DTP_FINAL.Value).Replace("/", "-"), PB_CARGA) Then
                                        MessageBox.Show(Me, "Registro generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        PB_CARGA.Value = 0
                                    End If
                                Else
                                    PB_CARGA.Value = 0
                                    MessageBox.Show(Me, "Sin registros para generar el documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                        End Select
                    Case "DOC"
                        Select Case CMB_REPORTE.SelectedValue
                            Case "01"
                                PB_CARGA.Increment(5)
                                Dim SQL = "	SELECT CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2 AS Cliente, ENC.NUMERO_DOC AS Número, CONVERT(varchar, ENC.FECHA, 111) AS Fecha, ENC.TIPO_MOV as Tipo	"
                                SQL &= Chr(13) & ", CASE When ENC.COD_MONEDA = 'L' THEN 'Colones' ELSE 'Dólares' END AS Moneda	"
                                SQL &= Chr(13) & "	,CASE WHEN ENC.TIPO_MOV = 'NC' THEN ENC.MONTO * -1 ELSE  ENC.MONTO END AS Subtotal, CASE WHEN ENC.TIPO_MOV = 'NC' THEN ENC.IMPUESTO * -1 ELSE ENC.IMPUESTO  END AS Impuesto	"
                                SQL &= Chr(13) & "	,Case When ENC.TIPO_MOV = 'NC' THEN (ENC.MONTO + ENC.IMPUESTO) * -1 ELSE (ENC.MONTO + ENC.IMPUESTO) END AS Total	"
                                SQL &= Chr(13) & "	FROM DOCUMENTO_ENC AS ENC	"
                                SQL &= Chr(13) & "	INNER JOIN CLIENTE AS CLI	"
                                SQL &= Chr(13) & "		ON CLI.COD_CIA = ENC.COD_CIA"
                                SQL &= Chr(13) & " And CLI.CEDULA = ENC.CEDULA"
                                SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                                SQL &= Chr(13) & "	AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                                SQL &= Chr(13) & "	AND ENC.FECHA BETWEEN " & SCM(YMD(DTP_INICIO.Value)) & " AND " & SCM(YMD(DTP_FINAL.Value))
                                SQL &= Chr(13) & "	ORDER BY ENC.NUMERO_DOC ASC, ENC.FECHA ASC	"
                                CONX.Coneccion_Abrir()
                                Dim DS = CONX.EJECUTE_DS(SQL)
                                CONX.Coneccion_Cerrar()

                                PB_CARGA.Increment(10)

                                If DS.Tables(0).Rows.Count > 0 Then
                                    If EXPORTAR_EXCEL(DS, "Documentos_por_rango_de_fechas_del_" + DMA(DTP_INICIO.Value).Replace("/", "-") + "_al_" + DMA(DTP_FINAL.Value).Replace("/", "-"), PB_CARGA) Then
                                        MessageBox.Show(Me, "Registro generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        PB_CARGA.Value = 0
                                    End If
                                Else
                                    PB_CARGA.Value = 0
                                    MessageBox.Show(Me, "Sin registros para generar el documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                        End Select
                End Select
            ElseIf CMB_MODULO.SelectedValue = "CXP" Then
                Select Case CMB_TIPO.SelectedValue
                    Case "TRI"
                        Select Case CMB_REPORTE.SelectedValue
                            Case "01"
                                PB_CARGA.Increment(5)
                                Dim SQL = "	SELECT PROV.NOMBRE AS 'Proveedor', CXP.CONSECUTIVO_P AS 'Documento', CONVERT(varchar, CXP.FECHA, 111) AS 'Fecha', CXP.TIPO_MOV AS 'Tipo', "
                                SQL &= Chr(13) & "	CASE WHEN CXP.TIPO_MOV = 'NC' THEN CXP.TOTAL_VENTA * -1 ELSE CXP.TOTAL_VENTA END AS 'Subtotal', 	"
                                SQL &= Chr(13) & "  CASE WHEN CXP.TIPO_MOV = 'NC' THEN CXP.DESCUENTO * -1 ELSE CXP.DESCUENTO END AS 'Descuento',"
                                SQL &= Chr(13) & "  CASE WHEN CXP.TIPO_MOV = 'NC' THEN CXP.IMPUESTO * -1  ELSE CXP.IMPUESTO END AS 'Impuesto',"
                                SQL &= Chr(13) & "  CASE WHEN CXP.TIPO_MOV = 'NC' THEN CXP.TOTAL * -1 ELSE CXP.TOTAL END AS 'Total'"
                                SQL &= Chr(13) & "	FROM CXP_DOCUMENTOS_ELECTRONICOS AS CXP	"
                                SQL &= Chr(13) & "	INNER JOIN PROVEEDOR AS PROV"
                                SQL &= Chr(13) & "		ON PROV.COD_CIA = CXP.COD_CIA"
                                SQL &= Chr(13) & " And PROV.COD_SUCUR = CXP.COD_SUCUR"
                                SQL &= Chr(13) & "		AND PROV.CEDULA = CXP.CEDULA"
                                SQL &= Chr(13) & "	WHERE CXP.COD_CIA = " & SCM(COD_CIA)
                                SQL &= Chr(13) & "	AND CXP.FECHA BETWEEN " & SCM(YMD(DTP_INICIO.Value)) & " AND " & SCM(YMD(DTP_FINAL.Value))
                                SQL &= Chr(13) & "	AND CXP.TIPO_MOV IN ('FA', 'FC', 'NC', 'ND') "
                                SQL &= Chr(13) & "	ORDER BY CXP.FECHA ASC	"
                                CONX.Coneccion_Abrir()
                                Dim DS = CONX.EJECUTE_DS(SQL)
                                CONX.Coneccion_Cerrar()

                                PB_CARGA.Increment(10)

                                If DS.Tables(0).Rows.Count > 0 Then
                                    If EXPORTAR_EXCEL(DS, "D151(CXP)_del_" + DMA(DTP_INICIO.Value).Replace("/", "-") + "_al_" + DMA(DTP_FINAL.Value).Replace("/", "-"), PB_CARGA) Then
                                        MessageBox.Show(Me, "Registro generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        PB_CARGA.Value = 0
                                    End If
                                Else
                                    PB_CARGA.Value = 0
                                    MessageBox.Show(Me, "Sin registros para generar el documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                        End Select
                    Case "DOC"
                        Select Case CMB_REPORTE.SelectedValue
                            Case "01"
                                PB_CARGA.Increment(5)
                                Dim SQL = "	SELECT PROV.NOMBRE AS 'Proveedor', CXP.CONSECUTIVO_P AS 'Documento', CONVERT(varchar, CXP.FECHA, 111) AS 'Fecha', CXP.TIPO_MOV AS 'Tipo', "
                                SQL &= Chr(13) & "	CASE WHEN CXP.TIPO_MOV = 'NC' THEN CXP.TOTAL_VENTA * -1 ELSE CXP.TOTAL_VENTA END AS 'Subtotal', 	"
                                SQL &= Chr(13) & "  CASE WHEN CXP.TIPO_MOV = 'NC' THEN CXP.IMPUESTO * -1  ELSE CXP.IMPUESTO END AS 'Impuesto',"
                                SQL &= Chr(13) & "  CASE WHEN CXP.TIPO_MOV = 'NC' THEN CXP.TOTAL * -1 ELSE CXP.TOTAL END AS 'Total'"
                                SQL &= Chr(13) & "	FROM CXP_DOCUMENTOS_ELECTRONICOS AS CXP	"
                                SQL &= Chr(13) & "	INNER JOIN PROVEEDOR AS PROV"
                                SQL &= Chr(13) & "		ON PROV.COD_CIA = CXP.COD_CIA"
                                SQL &= Chr(13) & " And PROV.COD_SUCUR = CXP.COD_SUCUR"
                                SQL &= Chr(13) & "		AND PROV.CEDULA = CXP.CEDULA"
                                SQL &= Chr(13) & "	WHERE CXP.COD_CIA = " & SCM(COD_CIA)
                                SQL &= Chr(13) & "	AND CXP.COD_SUCUR = " & SCM(COD_SUCUR)
                                SQL &= Chr(13) & "	AND CXP.FECHA BETWEEN " & SCM(YMD(DTP_INICIO.Value)) & " AND " & SCM(YMD(DTP_FINAL.Value))
                                SQL &= Chr(13) & "	ORDER BY CXP.FECHA ASC	"
                                CONX.Coneccion_Abrir()
                                Dim DS = CONX.EJECUTE_DS(SQL)
                                CONX.Coneccion_Cerrar()

                                PB_CARGA.Increment(10)

                                If DS.Tables(0).Rows.Count > 0 Then
                                    If EXPORTAR_EXCEL(DS, "Documentos_por_rango_de_fechas_del_" + DMA(DTP_INICIO.Value).Replace("/", "-") + "_al_" + DMA(DTP_FINAL.Value).Replace("/", "-"), PB_CARGA) Then
                                        MessageBox.Show(Me, "Registro generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        PB_CARGA.Value = 0
                                    End If
                                Else
                                    PB_CARGA.Value = 0
                                    MessageBox.Show(Me, "Sin registros para generar el documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                        End Select
                End Select
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub RELLENA_MODULOS()
        Try
            CMB_MODULO.DataSource = Nothing

            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String)) From {
                New KeyValuePair(Of String, String)("CXC", "Cuentas por cobrar"),
                New KeyValuePair(Of String, String)("CXP", "Cuentas por pagar")
            }

            CMB_MODULO.ValueMember = "Key"
            CMB_MODULO.DisplayMember = "Value"
            CMB_MODULO.DataSource = LISTA_REF
            CMB_MODULO.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RELLENA_MODULOS()
        DTP_FINAL.Enabled = TieneDerecho("FECREP")
        DTP_INICIO.Enabled = TieneDerecho("FECREP")
    End Sub

    Private Sub CMB_MODULO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_MODULO.SelectedIndexChanged
        Try
            CMB_TIPO.DataSource = Nothing

            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String)) From {
                New KeyValuePair(Of String, String)("DOC", "Documentos"),
                New KeyValuePair(Of String, String)("TRI", "Tributación")
            }

            CMB_TIPO.ValueMember = "Key"
            CMB_TIPO.DisplayMember = "Value"
            CMB_TIPO.DataSource = LISTA_REF
            CMB_TIPO.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_TIPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO.SelectedIndexChanged
        Try
            CMB_REPORTE.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = Nothing

            If Not IsNothing(CMB_TIPO.SelectedValue) Then

                Select Case CMB_TIPO.SelectedValue
                    Case "DOC"
                        LISTA_REF = New List(Of KeyValuePair(Of String, String)) From {
                                       New KeyValuePair(Of String, String)("01", "Documentos por rango de fechas (excel)")
                                   }
                    Case "TRI"
                        LISTA_REF = New List(Of KeyValuePair(Of String, String)) From {
                                       New KeyValuePair(Of String, String)("01", "D151 exportable (excel)")
                                   }
                End Select

                CMB_REPORTE.ValueMember = "Key"
                CMB_REPORTE.DisplayMember = "Value"
                CMB_REPORTE.DataSource = LISTA_REF
                CMB_REPORTE.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class