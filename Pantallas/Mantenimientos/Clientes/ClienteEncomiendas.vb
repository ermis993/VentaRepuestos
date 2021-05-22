Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class ClienteEncomiendas

    Sub New()
        InitializeComponent()

        Cliente.TABLA_BUSCAR = "CLIENTE"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE+ ' ' + APELLIDO1"
        Cliente.PANTALLA = New Cliente(CRF_Modos.Seleccionar, Cliente)
        Cliente.CAMPO_FILTRAR = "ESTADO"
        Cliente.OTROS_CAMP0S = "A"
        Cliente.refrescar()

        CARGAR_SUCURSALES()
        FORMATO_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 10
        GRID.Columns(0).HeaderText = "Documento"
        GRID.Columns(0).Name = "ENC.NUMERO_DOC"
        GRID.Columns(1).HeaderText = "Tipo"
        GRID.Columns(1).Name = "ENC.TIPO_MOV"
        GRID.Columns(2).HeaderText = "Fecha"
        GRID.Columns(2).Name = "CONVERT(VARCHAR(10), ENC.FECHA, 105)"
        GRID.Columns(3).HeaderText = "Subtotal"
        GRID.Columns(3).Name = "ENC.MONTO"
        GRID.Columns(4).HeaderText = "Impuesto"
        GRID.Columns(4).Name = "ENC.IMPUESTO"
        GRID.Columns(5).HeaderText = "Total"
        GRID.Columns(5).Name = "(ENC.MONTO + ENC.IMPUESTO)"
        GRID.Columns(6).HeaderText = "Guia"
        GRID.Columns(6).Name = "GUIA.NUMERO_GUIA"
        GRID.Columns(7).HeaderText = "Bultos"
        GRID.Columns(7).Name = "GUIA.CANT_BULTOS"
        GRID.Columns(8).HeaderText = "Origen"
        GRID.Columns(8).Name = "ORI.DESC_UBICACION"
        GRID.Columns(9).HeaderText = "Destino"
        GRID.Columns(9).Name = "DEST.DESC_UBICACION"
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        If String.IsNullOrEmpty(Cliente.VALOR) Then
            MessageBox.Show(Me, "El cliente no ha sido seleccionado", "Mensaje cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            RELLENAR_GRID()
        End If
    End Sub

    Private Sub CARGAR_SUCURSALES()
        Try
            CMB_SUCURSAL.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = "SELECT COD_SUCUR AS CODIGO, NOMBRE"
            SQL &= Chr(13) & " FROM SUCURSAL"
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND COD_SUCUR <> " & SCM(COD_SUCUR)
            SQL &= Chr(13) & " AND ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString & " - " & Row("NOMBRE").ToString.ToUpper))
                Next

                CMB_SUCURSAL.ValueMember = "Key"
                CMB_SUCURSAL.DisplayMember = "Value"
                CMB_SUCURSAL.DataSource = LISTA_REF
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL As String = ""

                SQL &= Chr(13) & "	SELECT ENC.NUMERO_DOC, ENC.TIPO_MOV, ENC.FECHA, ENC.MONTO, ENC.IMPUESTO, (ENC.MONTO + ENC.IMPUESTO) AS TOTAL, GUIA.NUMERO_GUIA																									"
                SQL &= Chr(13) & "	,GUIA.CANT_BULTOS, ORI.DESC_UBICACION AS ORIGEN, DEST.DESC_UBICACION AS DESTINO																								"
                SQL &= Chr(13) & "	FROM DOCUMENTO_ENC AS ENC																									"
                SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_GUIA AS GUIA																									"
                SQL &= Chr(13) & "		ON GUIA.COD_CIA = ENC.COD_CIA																								"
                SQL &= Chr(13) & "		AND GUIA.COD_SUCUR = ENC.COD_SUCUR																								"
                SQL &= Chr(13) & "		AND GUIA.NUMERO_DOC = ENC.NUMERO_DOC																								"
                SQL &= Chr(13) & "		AND GUIA.TIPO_MOV = ENC.TIPO_MOV																								"
                SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS ORI																									"
                SQL &= Chr(13) & "		ON ORI.COD_CIA = GUIA.COD_CIA																								"
                SQL &= Chr(13) & "		AND ORI.COD_UBICACION = GUIA.ORIGEN																								"
                SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS DEST																									"
                SQL &= Chr(13) & "		ON DEST.COD_CIA = GUIA.COD_CIA																								"
                SQL &= Chr(13) & "		AND DEST.COD_UBICACION = GUIA.DESTINO																								"
                SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	And ENC.CEDULA = " & SCM(Cliente.VALOR)
                SQL &= Chr(13) & "	AND ENC.COD_SUCUR = " & SCM(CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3))
                SQL &= Chr(13) & "  AND ENC.FECHA BETWEEN " & SCM(YMD(DTP_INICIO.Value)) & " AND " & SCM(YMD(DTP_FINAL.Value))
                SQL &= Chr(13) & "  ORDER BY ENC.NUMERO_DOC ASC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String()
                        row = New String() {ITEM("NUMERO_DOC"), ITEM("TIPO_MOV"), ITEM("FECHA"), ITEM("MONTO"), ITEM("IMPUESTO"), ITEM("TOTAL"), ITEM("NUMERO_GUIA"), ITEM("CANT_BULTOS"), ITEM("ORIGEN"), ITEM("DESTINO")}

                        GRID.Rows.Add(row)
                    Next
                Else
                    MessageBox.Show(Me, "No se encontraron registros con los datos ingresados", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class