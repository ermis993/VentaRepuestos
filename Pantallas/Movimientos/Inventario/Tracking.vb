Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Tracking
    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
            TXT_CODIGO.Select()
            MessageBox.Show(Me, "Es necesario ingresar el código del producto a buscar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            GRID.Rows.Clear()
            GRID.DataSource = Nothing

            Dim SQL = "	SELECT MOV.COD_MOV, TIPO_MOV, NUMERO_DOC, MOV.FECHA_INC, CANTIDAD, DET.COSTO, ISNULL(MOV.SISTEMA, '') AS SISTEMA																									"
            SQL &= Chr(13) & "	FROM INVENTARIO_MOV AS MOV																									"
            SQL &= Chr(13) & "	INNER JOIN INVENTARIO_MOV_DET AS DET																									"
            SQL &= Chr(13) & "		ON DET.COD_CIA = MOV.COD_CIA																								"
            SQL &= Chr(13) & "		AND DET.COD_SUCUR = MOV.COD_SUCUR																								"
            SQL &= Chr(13) & "		AND DET.NUMERO_MOV = MOV.NUMERO_MOV																								"
            SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD																									"
            SQL &= Chr(13) & "		ON PROD.COD_CIA = DET.COD_CIA																								"
            SQL &= Chr(13) & "		AND PROD.COD_PROD = DET.COD_PROD																								"
            SQL &= Chr(13) & "	WHERE MOV.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND MOV.COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND DET.COD_PROD = " & SCM(TXT_CODIGO.Text)
            SQL &= Chr(13) & "	ORDER BY FECHA_INC ASC	"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    Dim row As String() = New String() {ITEM("COD_MOV"), ITEM("TIPO_MOV"), ITEM("NUMERO_DOC"), DMAHms(ITEM("FECHA_INC")), ITEM("CANTIDAD"), ITEM("COSTO"), ITEM("SISTEMA")}
                    GRID.Rows.Add(row)
                Next
            Else
                MessageBox.Show(Me, "El producto " & LVResultados.Items(0).Text & " no tiene registros para mostrar el Tracking", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 7
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "COD_MOV"
        GRID.Columns(1).HeaderText = "Tipo"
        GRID.Columns(1).Name = "TIPO_MOV"
        GRID.Columns(2).HeaderText = "Documento"
        GRID.Columns(2).Name = "NUMERO_DOC"
        GRID.Columns(3).HeaderText = "Fecha"
        GRID.Columns(3).Name = "FECHA_INC"
        GRID.Columns(4).HeaderText = "Cantidad"
        GRID.Columns(4).Name = "CANTIDAD"
        GRID.Columns(5).HeaderText = "Costo"
        GRID.Columns(5).Name = "COSTO"
        GRID.Columns(6).HeaderText = "Sistema"
        GRID.Columns(6).Name = "SISTEMA"
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub Busca_Producto(ByVal Producto_Unico As Boolean)
        Try
            LVResultados.Clear()
            LVResultados.Columns.Add("", 370)

            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                Dim Sql = "	SELECT COD_PROD,  DESCRIPCION "
                Sql &= Chr(13) & "	FROM PRODUCTO AS PROD	"
                Sql &= Chr(13) & "  LEFT JOIN PRODUCTO_RELACION AS REL"
                Sql &= Chr(13) & " 	    ON REL.COD_CIA = PROD.COD_CIA"
                Sql &= Chr(13) & " 	    AND REL.COD_SUCUR = PROD.COD_SUCUR"
                Sql &= Chr(13) & " 	    AND REL.COD_PROD_PADRE = PROD.COD_PROD"
                Sql &= Chr(13) & "	WHERE PROD.COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND PROD.COD_SUCUR = " & SCM(COD_SUCUR)
                If Producto_Unico Then
                    Sql &= Chr(13) & " AND COD_PROD = " & SCM(TXT_CODIGO.Text)
                Else
                    Sql &= Chr(13) & " AND (DESCRIPCION Like " & SCM("%" + TXT_CODIGO.Text + "%") & " Or COD_PROD = " & SCM(TXT_CODIGO.Text) & " Or COD_BARRA = " & SCM(TXT_CODIGO.Text) & " Or REL.COD_PROD_HIJO = " & SCM(TXT_CODIGO.Text) & ")"
                End If
                Sql &= Chr(13) & "	And PROD.ESTADO = 'A'"
                Sql &= Chr(13) & "  GROUP BY COD_PROD, DESCRIPCION "
                Sql &= Chr(13) & "  ORDER BY DESCRIPCION ASC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim LVI As New ListViewItem With {
                            .Text = "(" & ITEM("COD_PROD") & ") " & ITEM("DESCRIPCION"),
                            .Name = ITEM("COD_PROD")
                        }
                        LVResultados.Items.Add(LVI)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LVResultados_DoubleClick(sender As Object, e As EventArgs) Handles LVResultados.DoubleClick
        Try
            Dim Codigo = LVResultados.SelectedItems(0).Name
            Dim Descripcion = LVResultados.SelectedItems(0).Text

            If Not IsNothing(Codigo) Then
                TXT_CODIGO.Text = Codigo
                Busca_Producto(True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TXT_CODIGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CODIGO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Busca_Producto(False)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Tracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FORMATO_GRID()
    End Sub

    Private Sub BTN_EXPORTAR_Click(sender As Object, e As EventArgs) Handles BTN_EXPORTAR.Click
        Try
            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                TXT_CODIGO.Select()
                MessageBox.Show(Me, "Es necesario ingresar el código del producto a buscar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim SQL = "	SELECT MOV.COD_MOV, TIPO_MOV, NUMERO_DOC, MOV.FECHA_INC, CANTIDAD, DET.COSTO, ISNULL(MOV.SISTEMA, '') AS SISTEMA																									"
                SQL &= Chr(13) & "	FROM INVENTARIO_MOV AS MOV																									"
                SQL &= Chr(13) & "	INNER JOIN INVENTARIO_MOV_DET AS DET																									"
                SQL &= Chr(13) & "		ON DET.COD_CIA = MOV.COD_CIA																								"
                SQL &= Chr(13) & "		AND DET.COD_SUCUR = MOV.COD_SUCUR																								"
                SQL &= Chr(13) & "		AND DET.NUMERO_MOV = MOV.NUMERO_MOV																								"
                SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD																									"
                SQL &= Chr(13) & "		ON PROD.COD_CIA = DET.COD_CIA																								"
                SQL &= Chr(13) & "		AND PROD.COD_PROD = DET.COD_PROD																								"
                SQL &= Chr(13) & "	WHERE MOV.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND MOV.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "	AND DET.COD_PROD = " & SCM(TXT_CODIGO.Text)
                SQL &= Chr(13) & "	ORDER BY FECHA_INC ASC	"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    If EXPORTAR_EXCEL(DS, "Tracking_" & LVResultados.Items(0).Text, PB_CARGA) Then
                        MessageBox.Show(Me, "Reporte generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        PB_CARGA.Value = 0
                    End If
                Else
                    PB_CARGA.Value = 0
                    MessageBox.Show(Me, "Sin registros para generar el reporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class