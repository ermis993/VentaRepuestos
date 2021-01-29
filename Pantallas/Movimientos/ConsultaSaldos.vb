Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ConsultaSaldos

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub TXT_BUSCADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_BUSCADOR.KeyDown
        If e.KeyCode = Keys.Enter Then
            Busca_Producto()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        Try
            Busca_Producto()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Busca_Producto()
        Try
            GRID.Rows.Clear()
            GRID.DataSource = Nothing

            GRID.ColumnCount = 4
            GRID.Columns(0).Name = "Código"
            GRID.Columns(1).Name = "Descripción"
            GRID.Columns(2).Name = "Cantidad"
            GRID.Columns(3).Name = "Precio"

            If Not String.IsNullOrEmpty(TXT_BUSCADOR.Text) Then
                Dim Sql = "	SELECT P.COD_PROD, P.DESCRIPCION, ISNULL(SUM(DET.CANTIDAD), 0) AS CANTIDAD, (PRECIO + ((PRECIO*POR_IMPUESTO) / 100)) AS PRECIO  "
                Sql &= Chr(13) & "	FROM PRODUCTO AS P	"
                Sql &= Chr(13) & "	LEFT JOIN INVENTARIO_MOV_DET AS DET	"
                Sql &= Chr(13) & "	    ON DET.COD_CIA = P.COD_CIA	"
                Sql &= Chr(13) & "	    AND DET.COD_SUCUR = P.COD_SUCUR	"
                Sql &= Chr(13) & "	    AND DET.COD_PROD = P.COD_PROD	"
                Sql &= Chr(13) & "	WHERE P.COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND P.COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND (P.DESCRIPCION LIKE " & SCM("%" + TXT_BUSCADOR.Text + "%") & " Or P.COD_PROD = " & SCM(TXT_BUSCADOR.Text) & " Or P.COD_BARRA = " & SCM(TXT_BUSCADOR.Text) & ")"
                Sql &= Chr(13) & "	AND P.ESTADO = 'A'"
                Sql &= Chr(13) & "  GROUP BY P.COD_PROD, P.DESCRIPCION, (PRECIO + ((PRECIO*POR_IMPUESTO) / 100))"
                Sql &= Chr(13) & "  ORDER BY DESCRIPCION ASC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("COD_PROD"), ITEM("DESCRIPCION"), ITEM("CANTIDAD"), ITEM("PRECIO")}
                        GRID.Rows.Add(row)
                    Next
                    GRID.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    GRID.AutoResizeColumns()
                Else
                    Dim row As String() = New String() {"Sin resultados", "Sin resultados", "Sin resultados", "Sin resultados"}
                    GRID.Rows.Add(row)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class