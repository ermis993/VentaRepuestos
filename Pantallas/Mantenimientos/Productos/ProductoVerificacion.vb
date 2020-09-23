Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ProductoVerificacion

    Dim COD_PROD As String
    Dim DESC_PROD As String
    Dim TARIFA As Integer
    Dim PC As Decimal

    Sub New()
        InitializeComponent()
        FORMATO_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 4
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "CODIGO"
        GRID.Columns(1).HeaderText = "Descripción"
        GRID.Columns(1).Name = "DETALLE"
        GRID.Columns(2).HeaderText = "Costo"
        GRID.Columns(2).Name = "PRECIO_COSTO"
        GRID.Columns(3).HeaderText = "Tarifa"
        GRID.Columns(3).Name = "TARIFA"
    End Sub
    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                COD_PROD = seleccionado.Cells(0).Value.ToString
                DESC_PROD = seleccionado.Cells(1).Value.ToString
                PC = FMC(seleccionado.Cells(2).Value.ToString, 4)
                TARIFA = Val(seleccionado.Cells(3).Value.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                Dim Calculo As Integer = 0
                Dim Cantidad_Registros As Integer = ObtieneCantidadRegistros()
                Dim Vueltas As Integer = 0

                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim sql = "	SELECT PROD_E.CODIGO, REPLACE(UPPER(PROD_E.DETALLE), '*', '') AS DETALLE, PROD_E.TARIFA, MAX((PROD_E.MONTO_TOTAL_LINEA / PROD_E.CANTIDAD)) AS PRECIO_COSTO	"
                sql &= Chr(13) & "	FROM CXP_DOCUMENTOS_ELECTRONICOS_DET AS PROD_E	"
                sql &= Chr(13) & "	LEFT JOIN PRODUCTO AS PROD	"
                sql &= Chr(13) & "		ON PROD.COD_PROD = PROD_E.CODIGO"
                sql &= Chr(13) & "		AND PROD.COD_CIA = " & SCM(COD_CIA)
                sql &= Chr(13) & "		AND PROD.COD_SUCUR = " & SCM(COD_SUCUR)
                sql &= Chr(13) & "	WHERE TARIFA IS NOT NULL"
                sql &= Chr(13) & "	And PROD.COD_PROD Is NULL	"
                sql &= Chr(13) & "	AND DETALLE NOT LIKE '%TRANSPORTE%'	"
                sql &= Chr(13) & "	AND PROD_E.CODIGO IS NOT NULL"
                sql &= Chr(13) & "	GROUP BY PROD_E.CODIGO, UPPER(PROD_E.DETALLE), PROD_E.TARIFA	"
                sql &= Chr(13) & "	ORDER BY DETALLE ASC	"
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Vueltas += 1
                        Calculo = ((Vueltas * 100) / Cantidad_Registros)

                        PB_CARGA.Increment(Calculo)

                        Dim row As String() = New String() {ITEM("CODIGO"), ITEM("DETALLE"), FMCP(ITEM("PRECIO_COSTO"), 4), Val(ITEM("TARIFA"))}
                        GRID.Rows.Add(row)
                    Next
                    LBL_PROD_VERIFICADOS.Text = Cantidad_Registros
                    MessageBox.Show(Me, "Productos verificados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(Me, "Sin productos para verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                PB_CARGA.Value = 0

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ObtieneCantidadRegistros() As Integer
        Try
            Dim RESPUESTA As Integer = 0
            Dim SQL = "	SELECT COUNT(*)	"
            SQL &= Chr(13) & "	FROM(	"
            SQL &= Chr(13) & "	SELECT PROD_E.CODIGO, REPLACE(UPPER(PROD_E.DETALLE), '*', '') AS DETALLE, PROD_E.TARIFA, MAX((PROD_E.MONTO_TOTAL_LINEA / PROD_E.CANTIDAD)) AS PRECIO_COSTO	"
            SQL &= Chr(13) & "	FROM CXP_DOCUMENTOS_ELECTRONICOS_DET AS PROD_E	"
            SQL &= Chr(13) & "	LEFT JOIN PRODUCTO AS PROD	"
            SQL &= Chr(13) & "		ON PROD.COD_PROD = PROD_E.CODIGO"
            SQL &= Chr(13) & "		AND PROD.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "		AND PROD.COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	WHERE TARIFA IS NOT NULL"
            SQL &= Chr(13) & "	And PROD.COD_PROD Is NULL	"
            SQL &= Chr(13) & "	AND DETALLE NOT LIKE '%TRANSPORTE%'	"
            SQL &= Chr(13) & "	AND PROD_E.CODIGO IS NOT NULL"
            SQL &= Chr(13) & "	GROUP BY PROD_E.CODIGO, UPPER(PROD_E.DETALLE), PROD_E.TARIFA	"
            SQL &= Chr(13) & "	) AS T1	"
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                RESPUESTA = Val(DS.Tables(0).Rows(0).Item(0))
            End If

            Return RESPUESTA

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_VERIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_VERIFICAR.Click
        Try
            Dim valor = MessageBox.Show(Me, "¿Seguro que desea verificar los productos, este proceso puede tardar varios minutos?", "Aviso", vbYesNo, MessageBoxIcon.Question)
            If valor = DialogResult.Yes Then
                RELLENAR_GRID()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                TXT_CODIGO.Text = COD_PROD
                TXT_DESCRIPCION.Text = DESC_PROD
                TXT_PU.Text = FMCP(PC)
                TXT_TARIFA.Text = TARIFA
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class