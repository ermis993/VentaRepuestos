Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class Reportes
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        Try
            If CMB_MODULO.SelectedValue = "CXC" Then
                Select Case CMB_TIPO.SelectedValue
                    Case "TRI"
                        Select Case CMB_REPORTE.SelectedValue
                            Case "01"

                                PB_CARGA.Increment(5)

                                Dim SQL = "	SELECT CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2 AS Cliente, ''+DOC_ELEC.CONSECUTIVO AS Documento, CONVERT(VARCHAR(10),ENC.FECHA, 103) AS Fecha, ENC.TIPO_MOV as Tipo	"
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
                                SQL &= Chr(13) & "	AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                                SQL &= Chr(13) & "	AND ENC.FECHA BETWEEN " & SCM(YMD(DTP_INICIO.Value)) & " AND " & SCM(YMD(DTP_FINAL.Value))
                                SQL &= Chr(13) & "	AND ENC.TIPO_MOV IN ('FA', 'FC', 'NC', 'ND') "
                                SQL &= Chr(13) & "	ORDER BY ENC.FECHA ASC	"
                                CONX.Coneccion_Abrir()
                                Dim DS = CONX.EJECUTE_DS(SQL)
                                CONX.Coneccion_Cerrar()

                                PB_CARGA.Increment(10)

                                If DS.Tables(0).Rows.Count > 0 Then
                                    If EXPORTAR_EXCEL(DS, "D151_del_" + DMA(DTP_INICIO.Value).Replace("/", "-") + "_al_" + DMA(DTP_FINAL.Value).Replace("/", "-"), PB_CARGA) Then
                                        MessageBox.Show("Registro generado correctamente")
                                        PB_CARGA.Value = 0
                                    End If
                                Else
                                    PB_CARGA.Value = 0
                                    MessageBox.Show("Sin registros para generar el documento")
                                End If
                        End Select
                End Select
                        ElseIf CMB_MODULO.SelectedValue = "CXP" Then
                Select Case CMB_TIPO.SelectedValue
                    Case "TRI"

                End Select
            End If

            'EXPORTAR_EXCEL(ByVal Datos As DataSet, ByVal Nombre_Reporte As String)
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
                                       New KeyValuePair(Of String, String)("01", "Documentos por rango de fechas")
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