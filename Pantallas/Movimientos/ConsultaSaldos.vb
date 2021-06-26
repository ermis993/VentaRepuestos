Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ConsultaSaldos

    Dim padre As Object
    Dim codigo As String

    Sub New(Optional padre As Object = Nothing)
        InitializeComponent()
        Me.padre = padre
    End Sub

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

            GRID.ColumnCount = 7
            GRID.Columns(0).Name = "Código"
            GRID.Columns(1).Name = "Descripción"
            GRID.Columns(2).Name = "Cantidad"
            GRID.Columns(3).Name = "Precio"
            GRID.Columns(4).Name = "Precio 2"
            GRID.Columns(5).Name = "Precio 3"
            GRID.Columns(6).Name = "Ubicación"

            If Not String.IsNullOrEmpty(TXT_BUSCADOR.Text) Then
                Dim Sql = "	SELECT P.COD_PROD, P.DESCRIPCION, ISNULL(SUM(DET.CANTIDAD), 0) AS CANTIDAD, (PRECIO + ((PRECIO*POR_IMPUESTO) / 100)) AS PRECIO  "
                Sql &= Chr(13) & " ,(PRECIO_2 + ((PRECIO_2*POR_IMPUESTO) / 100)) AS PRECIO2, (PRECIO_3 + ((PRECIO_3*POR_IMPUESTO) / 100)) AS PRECIO3 "
                Sql &= Chr(13) & " ,ISNULL('E: ' + UBI.ESTANTE + ' F: ' + UBI.FILA + ' C: ' + UBI.COLUMNA, 'E: 1 F: 1 C: 1') AS UBICACION"
                Sql &= Chr(13) & "	FROM PRODUCTO AS P	"
                Sql &= Chr(13) & "	LEFT JOIN PRODUCTO_UBICACION AS UBI	"
                Sql &= Chr(13) & "	    ON UBI.COD_CIA = P.COD_CIA	"
                Sql &= Chr(13) & "	    AND UBI.COD_SUCUR = P.COD_SUCUR	"
                Sql &= Chr(13) & "	    AND UBI.COD_PROD = P.COD_PROD	"
                Sql &= Chr(13) & "	LEFT JOIN INVENTARIO_MOV_DET AS DET	"
                Sql &= Chr(13) & "	    ON DET.COD_CIA = UBI.COD_CIA	"
                Sql &= Chr(13) & "	    AND DET.COD_SUCUR = UBI.COD_SUCUR	"
                Sql &= Chr(13) & "	    AND DET.COD_PROD = UBI.COD_PROD	"
                Sql &= Chr(13) & "	    AND DET.ESTANTE = UBI.ESTANTE	"
                Sql &= Chr(13) & "	    AND DET.FILA = UBI.FILA	"
                Sql &= Chr(13) & "	    AND DET.COLUMNA = UBI.COLUMNA	"
                Sql &= Chr(13) & "	WHERE P.COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND P.COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & BuscadorProducto(TXT_BUSCADOR.Text)
                Sql &= Chr(13) & "	AND P.ESTADO = 'A'"
                Sql &= Chr(13) & "  GROUP BY P.COD_PROD, P.DESCRIPCION, (PRECIO + ((PRECIO*POR_IMPUESTO) / 100)), (PRECIO_2 + ((PRECIO_2*POR_IMPUESTO) / 100)), (PRECIO_3 + ((PRECIO_3*POR_IMPUESTO) / 100))"
                Sql &= Chr(13) & " ,ISNULL('E: ' + UBI.ESTANTE + ' F: ' + UBI.FILA + ' C: ' + UBI.COLUMNA, 'E: 1 F: 1 C: 1')"
                Sql &= Chr(13) & "  ORDER BY DESCRIPCION ASC, ISNULL(SUM(DET.CANTIDAD), 0) DESC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("COD_PROD"), ITEM("DESCRIPCION"), ITEM("CANTIDAD"), ITEM("PRECIO"), ITEM("PRECIO2"), ITEM("PRECIO3"), ITEM("UBICACION")}
                        GRID.Rows.Add(row)
                    Next
                    GRID.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    GRID.AutoResizeColumns()
                Else
                    Dim row As String() = New String() {"Sin resultados", "Sin resultados", "Sin resultados", "Sin resultados", "Sin resultados", "Sin resultados", "Sin resultados"}
                    GRID.Rows.Add(row)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID.CellDoubleClick
        If Not IsNothing(padre) Then
            Leer_indice()
            padre.EnvioCodigoConsultaSaldos(codigo)
            Me.Close()
        End If
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                Codigo = seleccionado.Cells(0).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class