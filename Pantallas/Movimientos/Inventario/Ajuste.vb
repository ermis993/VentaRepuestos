Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Ajuste
    Dim Codigo As String
    Dim Padre As Object

    Sub New(ByVal Padrecito As Object)
        InitializeComponent()

        Padre = Padrecito
    End Sub

    Private Sub Ajuste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMB_TIPO.SelectedIndex = 0
        Codigo = GenerarCodigo()
    End Sub

    Private Sub BTN_INGRESAR_ENC_Click(sender As Object, e As EventArgs) Handles BTN_INGRESAR_ENC.Click
        Try
            If String.IsNullOrEmpty(TXT_DESCRIPCION.Text) Then
                MessageBox.Show(Me, "Es necesario ingresar una descripción para el ajuste ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim SQL = "	IF EXISTS(SELECT *																									"
                SQL &= Chr(13) & "			  FROM INVENTARIO_ENC_TMP																							"
                SQL &= Chr(13) & "			  WHERE CODIGO = " & SCM(Codigo) & ")																							"
                SQL &= Chr(13) & "	BEGIN																									"
                SQL &= Chr(13) & "		UPDATE INVENTARIO_ENC_TMP																								"
                SQL &= Chr(13) & "		SET DESCRIPCION = " & SCM(TXT_DESCRIPCION.Text) & ", COD_MOV = " & SCM(CMB_TIPO.SelectedItem.ToString.Substring(0, 3))
                SQL &= Chr(13) & "		WHERE CODIGO = " & SCM(Codigo)
                SQL &= Chr(13) & "	END																									"
                SQL &= Chr(13) & "	ELSE																									"
                SQL &= Chr(13) & "	BEGIN																									"
                SQL &= Chr(13) & "		INSERT INTO INVENTARIO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,DESCRIPCION,COD_MOV)																								"
                SQL &= Chr(13) & "		SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & ", 'IN', '000000000'," & SCM(YMD(DTPFECHA.Value)) & ", GETDATE()," & SCM(COD_USUARIO) & "," & SCM(TXT_DESCRIPCION.Text) & "," & SCM(CMB_TIPO.SelectedItem.ToString.Substring(0, 3))
                SQL &= Chr(13) & "	END	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                MessageBox.Show(Me, "Información del encabezado ingresada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GenerarCodigo() As String
        Try
            Dim CARACTERES As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim RND As New Random
            Dim Codigo As String = ""
            For i As Integer = 1 To 20
                Codigo += CARACTERES.ToCharArray(RND.Next(0, CARACTERES.Length), 1)
            Next
            Return Codigo
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub EliminaTodoTemporal()
        Try
            Dim Sql = "	DELETE FROM INVENTARIO_ENC_TMP WHERE CODIGO =  " & SCM(Codigo)
            Sql &= Chr(13) & "	DELETE FROM INVENTARIO_DET_TMP WHERE CODIGO =  " & SCM(Codigo)
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        EliminaTodoTemporal()
        Cerrar()
    End Sub
    Public Sub Cerrar()
        Padre.Refrescar()
        Me.Close()
    End Sub

    Private Sub TXT_CODIGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CODIGO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Busca_Producto()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Busca_Producto()
        Try
            LVResultados.Clear()
            LVResultados.Columns.Add("", 318)

            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                Dim Sql = "	SELECT COD_PROD,  DESCRIPCION "
                Sql &= Chr(13) & "	FROM PRODUCTO AS PROD	"
                Sql &= Chr(13) & "  LEFT JOIN PRODUCTO_RELACION AS REL"
                Sql &= Chr(13) & " 	    ON REL.COD_CIA = PROD.COD_CIA"
                Sql &= Chr(13) & " 	    AND REL.COD_SUCUR = PROD.COD_SUCUR"
                Sql &= Chr(13) & " 	    AND REL.COD_PROD_PADRE = PROD.COD_PROD"
                Sql &= Chr(13) & "	WHERE PROD.COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND PROD.COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND (DESCRIPCION LIKE " & SCM("%" + TXT_CODIGO.Text + "%") & " Or COD_PROD = " & SCM(TXT_CODIGO.Text) & " Or COD_BARRA = " & SCM(TXT_CODIGO.Text) & " Or REL.COD_PROD_HIJO = " & SCM(TXT_CODIGO.Text) & ")"
                Sql &= Chr(13) & "	AND PROD.ESTADO = 'A'"
                Sql &= Chr(13) & "  GROUP BY COD_PROD, DESCRIPCION "
                Sql &= Chr(13) & "  ORDER BY DESCRIPCION ASC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim LVI As New ListViewItem With {
                            .Text = ITEM("DESCRIPCION"),
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

                TXT_ESTANTE.Text = ""
                TXT_FILA.Text = ""
                TXT_COLUMNA.Text = ""

                If ProductoMasUbicaciones(Codigo) Then
                    Dim PANTALLA As New ProductoUbicacionMant(Codigo, Descripcion, CRF_Modos.Seleccionar, Me)
                    PANTALLA.ShowDialog()
                    TXT_CANTIDAD.Focus()
                Else
                    Proceso(Codigo, "", "", "")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Proceso(ByVal codigo As String, ByVal estante As String, ByVal fila As String, ByVal columna As String)
        TXT_CODIGO.Text = codigo
        RellenaProducto(estante, fila, columna)
        Busca_Producto()
        TXT_CANTIDAD.Focus()
    End Sub

    Private Function ProductoMasUbicaciones(ByVal COD_PROD As String) As Boolean
        Try
            Dim bandera As Boolean = False
            Dim Sql = "	SELECT COD_PROD, ESTANTE, FILA, COLUMNA	"
            Sql &= Chr(13) & "	FROM INVENTARIO_MOV_DET	"
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	AND COD_PROD = " & SCM(COD_PROD)
            Sql &= Chr(13) & "	GROUP BY COD_PROD, ESTANTE, FILA, COLUMNA"
            Sql &= Chr(13) & "	HAVING SUM(CANTIDAD) > 0 "

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 1 Then
                bandera = True
            End If

            Return bandera

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub RellenaProducto(ByVal estante As String, ByVal fila As String, ByVal columna As String)
        Try
            Dim Sql = "	Select COD_UNIDAD, PRECIO, PRECIO_2, PRECIO_3, POR_IMPUESTO, U.ESTANTE, U.FILA, U.COLUMNA, ISNULL(OBSERVACION, '') AS MENSAJE, ISNULL(P.IND_PRECIO_MODIFICABLE, 'N') AS MODIFICABLE	"
            Sql &= Chr(13) & "	FROM PRODUCTO AS P "
            Sql &= Chr(13) & "  INNER JOIN PRODUCTO_UBICACION  AS U"
            Sql &= Chr(13) & "      ON U.COD_PROD = P.COD_PROD"
            Sql &= Chr(13) & "      AND U.ESTADO = 'A'"
            If Not String.IsNullOrEmpty(estante) Then
                Sql &= Chr(13) & "      AND U.ESTANTE =" & SCM(estante)
                Sql &= Chr(13) & "      AND U.FILA = " & SCM(fila)
                Sql &= Chr(13) & "      AND U.COLUMNA = " & SCM(columna)
            End If
            Sql &= Chr(13) & "	WHERE P.COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	And P.COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	And P.COD_PROD = " & SCM(TXT_CODIGO.Text)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                TXT_ESTANTE.Text = DS.Tables(0).Rows(0).Item("ESTANTE")
                TXT_FILA.Text = DS.Tables(0).Rows(0).Item("FILA")
                TXT_COLUMNA.Text = DS.Tables(0).Rows(0).Item("COLUMNA")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function Valida_Encabezado() As Boolean
        Try
            Dim SQL = "	SELECT *	"
            SQL &= Chr(13) & "	FROM INVENTARIO_ENC_TMP	"
            SQL &= Chr(13) & "	WHERE CODIGO = " & SCM(Codigo)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub BTN_INGRESAR_DET_Click(sender As Object, e As EventArgs) Handles BTN_INGRESAR_DET.Click
        IngresarDetalle()
    End Sub

    Private Sub IngresarDetalle()
        Try
            If Valida_Encabezado() Then
                If FMC(TXT_CANTIDAD.Text) <= 0 Then
                    TXT_CANTIDAD.Select()
                    MessageBox.Show(Me, "La cantidad del producto no puede ser menor o igual a cero (0)", "Mensaje cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf String.IsNullOrEmpty(TXT_ESTANTE.Text) Or String.IsNullOrEmpty(TXT_FILA.Text) Or String.IsNullOrEmpty(TXT_COLUMNA.Text) Then
                    MessageBox.Show(Me, "La ubicación del producto es inválida, vuelva a seleccionar el producto", "Mensaje ubicación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Dim SQL = "	IF EXISTS(SELECT COD_PROD FROM INVENTARIO_DET_TMP WHERE COD_CIA = " & SCM(COD_CIA) & " AND COD_SUCUR = " & SCM(COD_SUCUR) & " AND CODIGO = " & SCM(Codigo) & " AND COD_PROD =" & SCM(TXT_CODIGO.Text) & ")"
                    SQL &= Chr(13) & "	                				BEGIN																					"
                    SQL &= Chr(13) & "	                					UPDATE INVENTARIO_DET_TMP																				"
                    SQL &= Chr(13) & "	                					SET CANTIDAD = " & FMC(TXT_CANTIDAD.Text) & ", ESTANTE = " & SCM(TXT_ESTANTE.Text) & ", FILA =" & SCM(TXT_FILA.Text) & ", COLUMNA =" & SCM(TXT_COLUMNA.Text)
                    SQL &= Chr(13) & "	                					WHERE COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "	                					And COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "	                                    AND CODIGO = " & SCM(Codigo)
                    SQL &= Chr(13) & "                                      AND COD_PROD = " & SCM(TXT_CODIGO.Text)
                    SQL &= Chr(13) & "	                				END																					"
                    SQL &= Chr(13) & "	                				ELSE																					"
                    SQL &= Chr(13) & "	                				BEGIN																					"
                    SQL &= Chr(13) & "	                					INSERT INTO INVENTARIO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,CANTIDAD,ESTANTE,FILA,COLUMNA)																				"
                    SQL &= Chr(13) & "	                					SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & ", 'IN', ISNULL(MAX(LINEA), 0) + 1," & SCM(TXT_CODIGO.Text) & "," & FMC(TXT_CANTIDAD.Text) & "," & SCM(TXT_ESTANTE.Text) & "," & SCM(TXT_FILA.Text) & "," & SCM(TXT_COLUMNA.Text)
                    SQL &= Chr(13) & "	                					FROM INVENTARIO_DET_TMP																				"
                    SQL &= Chr(13) & "	                					WHERE COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "	                					And COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "	                                    AND CODIGO = " & SCM(Codigo)
                    SQL &= Chr(13) & "	                				END	"
                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(SQL)
                    CONX.Coneccion_Cerrar()

                    LimpiarControles()
                    TXT_CODIGO.Select()

                    RELLENAR_GRID()
                End If
            Else
                MessageBox.Show(Me, "Es necesario ingresar el encabezado del ajuste antes de ingresar el detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        TXT_CANTIDAD.Text = ""
        TXT_CODIGO.Text = ""
        TXT_FILA.Text = ""
        TXT_COLUMNA.Text = ""
        TXT_ESTANTE.Text = ""
        LVResultados.Clear()
    End Sub

    Public Sub RELLENAR_GRID(Optional ByVal modo As Integer = 0)
        Try
            GRID.Rows.Clear()
            GRID.DataSource = Nothing

            GRID.ColumnCount = 7
            GRID.Columns(0).Name = "Linea"
            GRID.Columns(1).Name = "Código"
            GRID.Columns(2).Name = "Descripción"
            GRID.Columns(3).Name = "Estante"
            GRID.Columns(4).Name = "Fila"
            GRID.Columns(5).Name = "Columna"
            GRID.Columns(6).Name = "Cantidad"

            If modo = 0 Then
                Dim SQL = "	Select TMP.LINEA , PROD.COD_PROD , PROD.DESCRIPCION , TMP.CANTIDAD "
                SQL &= Chr(13) & "	,TMP.ESTANTE, TMP.FILA, TMP.COLUMNA"
                SQL &= Chr(13) & "	FROM INVENTARIO_DET_TMP AS TMP	"
                SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD		"
                SQL &= Chr(13) & "		ON PROD.COD_CIA = TMP.COD_CIA	"
                SQL &= Chr(13) & "      AND PROD.COD_SUCUR = TMP.COD_SUCUR "
                SQL &= Chr(13) & "		AND PROD.COD_PROD = TMP.COD_PROD	"
                SQL &= Chr(13) & "	WHERE TMP.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND TMP.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & " And TMP.CODIGO =  " & SCM(Codigo)

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then

                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("LINEA"), ITEM("COD_PROD"), ITEM("DESCRIPCION"), ITEM("ESTANTE"), ITEM("FILA"), ITEM("COLUMNA"), ITEM("CANTIDAD")}
                        GRID.Rows.Add(row)
                    Next

                    Dim btn As New DataGridViewImageColumn()
                    Dim img As Image = My.Resources.borrar_button

                    GRID.Columns.Add(btn)
                    btn.HeaderText = ""
                    btn.Name = "Eliminar"
                    btn.Width = 32
                    btn.Image = img
                    btn.ImageLayout = DataGridViewImageCellLayout.Normal
                End If
            Else
                Dim SQL = "	Select TMP.LINEA , PROD.COD_PROD , PROD.DESCRIPCION , TMP.CANTIDAD, TMP.PRECIO "
                SQL &= Chr(13) & "	, TMP.POR_DESCUENTO , TMP.IMPUESTO, TMP.TOTAL, TMP.ESTANTE, TMP.FILA, TMP.COLUMNA"
                SQL &= Chr(13) & "	FROM DOCUMENTO_DET AS TMP	"
                SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD		"
                SQL &= Chr(13) & "		ON PROD.COD_CIA = TMP.COD_CIA	"
                SQL &= Chr(13) & " And PROD.COD_SUCUR = TMP.COD_SUCUR "
                SQL &= Chr(13) & "		AND PROD.COD_PROD = TMP.COD_PROD	"
                SQL &= Chr(13) & "	WHERE TMP.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND TMP.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & " And TMP.NUMERO_DOC =  " & Val(TXT_NUMERO.Text)
                SQL &= Chr(13) & " AND TMP.TIPO_MOV = 'IN'"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then

                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("LINEA"), ITEM("COD_PROD"), ITEM("DESCRIPCION"), ITEM("ESTANTE"), ITEM("FILA"), ITEM("COLUMNA"), ITEM("CANTIDAD")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID.CellClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 7 Then
                    Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                    Dim valor = MessageBox.Show(Me, "¿Seguro que desea eliminar la linea :" + seleccionado.Cells(0).Value.ToString + "?", "Eliminar linea", vbYesNo, MessageBoxIcon.Question)

                    If valor = DialogResult.Yes Then

                        Dim SQL = "	DELETE FROM INVENTARIO_DET_TMP	"
                        SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                        SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                        SQL &= Chr(13) & "	AND CODIGO = " & SCM(Codigo)
                        SQL &= Chr(13) & "	AND LINEA = " & Val(seleccionado.Cells(0).Value)

                        CONX.Coneccion_Abrir()
                        CONX.EJECUTE(SQL)
                        CONX.Coneccion_Cerrar()

                        RELLENAR_GRID()

                        MessageBox.Show(Me, "Producto eliminado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXT_CANTIDAD_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CANTIDAD.KeyDown
        If e.KeyCode = Keys.Enter Then
            IngresarDetalle()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub GRID_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID.CellDoubleClick
        Modificar()
    End Sub
    Private Sub Modificar()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                TXT_ESTANTE.Text = seleccionado.Cells(3).Value.ToString
                TXT_FILA.Text = seleccionado.Cells(4).Value.ToString
                TXT_COLUMNA.Text = seleccionado.Cells(5).Value.ToString
                TXT_CANTIDAD.Text = seleccionado.Cells(6).Value.ToString
                TXT_CODIGO.Text = seleccionado.Cells(1).Value.ToString
                RellenaProducto(seleccionado.Cells(3).Value.ToString, seleccionado.Cells(4).Value.ToString, seleccionado.Cells(5).Value.ToString)
                TXT_CANTIDAD.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            Dim Sql = "	USP_INVENTARIO_TMP_A_REAL	"
            Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@TIPO_MOV  = 'IN'"
            Sql &= Chr(13) & "	,@CODIGO = 	" & SCM(Codigo)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            MessageBox.Show(Me, "Ajuste ingresado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            EliminaTodoTemporal()
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class