Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class ConsultaBitacoras
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        Try
            GRID.Rows.Clear()
            GRID.DataSource = Nothing

            GRID.ColumnCount = 4
            GRID.Columns(0).Name = "Código"
            GRID.Columns(1).Name = "Nombre"
            GRID.Columns(2).Name = "Fecha"
            GRID.Columns(3).Name = "Proceso"

            Dim SQL = "	SELECT U.NOMBRE AS 'Codigo', U.NOMBRE AS 'Nombre', FECHA_IMP AS 'Fecha', REPORTE AS 'Proceso'																									"
            SQL &= Chr(13) & "	FROM USUARIO AS U																									"
            SQL &= Chr(13) & "	INNER JOIN BITACORA_IMPRESIONES AS B																									"
            SQL &= Chr(13) & "		ON B.COD_USUARIO = U.COD_USUARIO																								"
            SQL &= Chr(13) & "	WHERE B.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND B.COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND CONVERT(varchar(10), FECHA_IMP, 111) BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
            If Not String.IsNullOrEmpty(TXT_BUSCADOR.Text) Then
                SQL &= Chr(13) & "	AND B.REPORTE LIKE '%" & TXT_BUSCADOR.Text & "%'"
            End If
            SQL &= Chr(13) & " ORDER BY FECHA_IMP ASC"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    Dim row As String() = New String() {ITEM("Codigo"), ITEM("Nombre"), DMAHms(ITEM("Fecha")), ITEM("Proceso")}
                    GRID.Rows.Add(row)
                Next
                GRID.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                GRID.AutoResizeColumns()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class