Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class NotaCredito

    Dim NUMERO_DOC As Integer
    Dim TIPO_MOV As String
    Dim FECHA As String
    Dim MONTO_DOC As Double
    Dim MONTO_DOC_AFEC As Double
    Dim Codigo As String
    Dim TabProducto As TabPage
    Dim Padre As Facturacion
    Dim Tipo As String

    Dim TIPO_MOV_P As String
    Dim NUMERO_DOC_P As Integer
    Dim MODO_USAR As CRF_Modos


    Private PaginaEscondidas As New List(Of TabPage)

    Sub New(ByVal PADRE As Facturacion, ByVal Tipo_Proceso As String, ByVal Modo As CRF_Modos, Optional ByVal TIPO_MOV_E As String = "", Optional ByVal NUMERO_DOC_E As Integer = 0)
        InitializeComponent()

        Me.Tipo = Tipo_Proceso
        Me.Padre = PADRE
        MODO_USAR = Modo

        Cliente.TABLA_BUSCAR = "CLIENTE"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE+ ' ' + APELLIDO1"
        Cliente.PANTALLA = New Cliente(CRF_Modos.Seleccionar, Cliente)
        Cliente.CAMPO_FILTRAR = "ESTADO"
        Cliente.OTROS_CAMP0S = "A"
        Cliente.refrescar()

        TIPO_MOV_P = TIPO_MOV_E
        NUMERO_DOC_P = NUMERO_DOC_E
    End Sub

    Private Sub RELLENA_DATOS()
        Try
            Dim SQL = "	SELECT TIPO_MOV, ISNULL(TIPO_NOTA, 'A') AS TIPO_NOTA, FECHA, TIPO_CAMBIO, CEDULA, FORMA_PAGO, COD_MONEDA,				"
            SQL &= Chr(13) & "	DESCRIPCION, (MONTO+IMPUESTO) AS TOTAL			"
            SQL &= Chr(13) & "	FROM DOCUMENTO_ENC		"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "  And COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(NUMERO_DOC_P)
            SQL &= Chr(13) & "  AND TIPO_MOV = " & SCM(TIPO_MOV_P)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    DTPFECHA.Value = DMA(ITEM("FECHA"))

                    If ITEM("TIPO_MOV") = "NC" Then
                        CMB_DOCUMENTO.SelectedIndex = 1
                    Else
                        CMB_DOCUMENTO.SelectedIndex = 0
                    End If

                    If ITEM("TIPO_NOTA") = "A" Then
                        CMB_TIPO.SelectedIndex = 1
                    Else
                        CMB_TIPO.SelectedIndex = 0
                    End If

                    If ITEM("FORMA_PAGO") = "EF" Then
                        CMB_FORMAPAGO.SelectedIndex = 0
                    ElseIf ITEM("FORMA_PAGO") = "TA" Then
                        CMB_FORMAPAGO.SelectedIndex = 1
                    Else
                        CMB_FORMAPAGO.SelectedIndex = 2
                    End If

                    If ITEM("COD_MONEDA") = "L" Then
                        CMB_MONEDA.SelectedIndex = 0
                    Else
                        CMB_MONEDA.SelectedIndex = 1
                    End If

                    TXT_TIPO_CAMBIO.Text = FMCP(ITEM("TIPO_CAMBIO"))
                    TXT_DESCRIPCION.Text = ITEM("DESCRIPCION")

                    Cliente.VALOR = ITEM("CEDULA")
                    Cliente.ACTUALIZAR_COMBO()
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = False
            TXT_TIPO_CAMBIO.Enabled = False
            DTPFECHA.Enabled = False
            CMB_DOCUMENTO.Enabled = IIf(MODO_USAR = CRF_Modos.Insertar, True, False)
            BTN_ACEPTAR.Enabled = IIf(MODO_USAR = CRF_Modos.Insertar, True, False)
            CMB_TIPO.Enabled = IIf(MODO_USAR = CRF_Modos.Insertar, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_DOCUMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_DOCUMENTO.SelectedIndexChanged
        If CMB_DOCUMENTO.SelectedIndex = 1 Then
            LBLTIPO.Visible = True
            CMB_TIPO.Visible = True
            CMB_TIPO.SelectedIndex = 0
            EliminarAfecTodo()
            RellenaFacturas()
            RellenaFacturasAfec()
            CalculoTotales()
        Else
            LBLTIPO.Visible = False
            CMB_TIPO.Visible = False
            CMB_TIPO.SelectedIndex = -1
            EliminarAfecTodo()
            RellenaFacturas()
            RellenaFacturasAfec()
            CalculoTotales()
        End If
    End Sub

    Private Sub RellenaFacturas()
        Try
            If Not CMB_MONEDA.SelectedIndex <= -1 And String.IsNullOrEmpty(Cliente.VALOR) = False And MODO_USAR = CRF_Modos.Insertar Then
                Dim SQL As String = ""
                GRID.DataSource = Nothing

                If Tipo = "F" Then
                    SQL = "	SELECT ENC.TIPO_MOV AS Tipo, ENC.NUMERO_DOC AS Número, CONVERT(VARCHAR(10),ENC.FECHA, 103) AS Fecha, MONTO AS Subtotal		"
                    SQL &= Chr(13) & "	, IMPUESTO as Impuesto, (MONTO+IMPUESTO) AS Total, SALDO as Saldo"
                    SQL &= Chr(13) & "	FROM DOCUMENTO_ENC AS ENC"
                    SQL &= Chr(13) & "  LEFT JOIN DOCUMENTO_AFEC_DET_TMP AS AFEC"
                    SQL &= Chr(13) & "      ON AFEC.NUMERO_DOC = ENC.NUMERO_DOC"
                    SQL &= Chr(13) & "      AND AFEC.TIPO_MOV = ENC.TIPO_MOV"
                    SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "  AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "  AND CEDULA = " & SCM(Cliente.VALOR)
                    SQL &= Chr(13) & "	AND COD_MONEDA = " & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                    SQL &= Chr(13) & "  AND SALDO > 0 "
                    SQL &= Chr(13) & "  AND ENC.TIPO_MOV In ('FA', 'FC')"
                    SQL &= Chr(13) & "  AND AFEC.NUMERO_DOC IS NULL"
                Else
                    SQL = "	SELECT ENC.TIPO_MOV AS Tipo, ENC.NUMERO_DOC AS Número, CONVERT(VARCHAR(10),ENC.FECHA, 103) AS Fecha, MONTO AS Subtotal		"
                    SQL &= Chr(13) & "	, IMPUESTO as Impuesto, (MONTO+IMPUESTO) AS Total, SALDO as Saldo"
                    SQL &= Chr(13) & "	FROM APARTADO_ENC AS ENC"
                    SQL &= Chr(13) & "  LEFT JOIN DOCUMENTO_AFEC_DET_TMP AS AFEC"
                    SQL &= Chr(13) & "      ON AFEC.NUMERO_DOC = ENC.NUMERO_DOC"
                    SQL &= Chr(13) & "      AND AFEC.TIPO_MOV = ENC.TIPO_MOV"
                    SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "  AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "  AND CEDULA = " & SCM(Cliente.VALOR)
                    SQL &= Chr(13) & "	AND COD_MONEDA = " & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                    SQL &= Chr(13) & "  AND SALDO > 0 "
                    SQL &= Chr(13) & "  AND ENC.TIPO_MOV In ('AA', 'AC')"
                    SQL &= Chr(13) & "  AND AFEC.NUMERO_DOC IS NULL"
                End If

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    GRID.DataSource = DS.Tables(0)
                End If
            Else
                GRID.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaFacturasAfec()
        Try
            GRID2.DataSource = Nothing
            Dim SQL As String = ""

            If MODO_USAR = CRF_Modos.Insertar Then
                SQL = "	SELECT CODIGO AS Código, NUMERO_DOC AS Número, TIPO_MOV AS Tipo, FECHA AS Fecha, MONTO_DOC AS Monto, (MONTO_DOC - MONTO_AFEC) AS Saldo"
                SQL &= Chr(13) & " FROM DOCUMENTO_AFEC_DET_TMP"
                SQL &= Chr(13) & " WHERE CODIGO = 	" & SCM(Codigo)
            Else
                SQL = "	SELECT 'AXS' AS Código, NUMERO_DOC_AFEC AS Número, TIPO_MOV_AFEC AS Tipo, ENC.FECHA AS Fecha, MONTO_AFEC AS Monto, 0 AS Saldo																									"
                SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC AS AFEC																									"
                SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_ENC AS ENC																									"
                SQL &= Chr(13) & "		ON ENC.COD_CIA = AFEC.COD_CIA																								"
                SQL &= Chr(13) & "		AND ENC.COD_SUCUR = AFEC.COD_SUCUR																								"
                SQL &= Chr(13) & "		AND ENC.TIPO_MOV = AFEC.TIPO_MOV_AFEC																								"
                SQL &= Chr(13) & "		AND ENC.NUMERO_DOC = AFEC.NUMERO_DOC_AFEC																								"
                SQL &= Chr(13) & "	WHERE AFEC.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND AFEC.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "	AND AFEC.TIPO_MOV = " & SCM(TIPO_MOV_P)
                SQL &= Chr(13) & "	AND AFEC.NUMERO_DOC = " & Val(NUMERO_DOC_P)
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRID2.DataSource = DS.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaProductos()
        Try
            GRIDPRODS.DataSource = Nothing
            Dim SQL = "	SELECT DET.NUMERO_DOC AS Número, DET.TIPO_MOV as Tipo, DET.LINEA as Linea, DET.COD_PROD as Código, DET.PRECIO AS 'P/U', DET.POR_DESCUENTO AS Descuento, DET.POR_IMPUESTO AS Impuesto, (DET.CANTIDAD - ISNULL(PROD.CANTIDAD,0)) as Cantidad																									"
            SQL &= Chr(13) & "	, DET.ESTANTE AS Estante, DET.FILA AS Fila, DET.COLUMNA AS Columna																									"
            SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC_DET_TMP AS TMP																									"
            SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_DET AS DET																									"
            SQL &= Chr(13) & "		ON DET.NUMERO_DOC = TMP.NUMERO_DOC																								"
            SQL &= Chr(13) & "		AND DET.TIPO_MOV = TMP.TIPO_MOV																								"
            SQL &= Chr(13) & "		AND DET.COD_CIA = TMP.COD_CIA																								"
            SQL &= Chr(13) & "		AND DET.COD_SUCUR = TMP.COD_SUCUR																								"
            SQL &= Chr(13) & "	LEFT JOIN DOCUMENTO_AFEC_DET_PRODUCTOS AS PROD																									"
            SQL &= Chr(13) & "		ON PROD.NUMERO_DOC_AFEC = DET.NUMERO_DOC																								"
            SQL &= Chr(13) & "		AND PROD.TIPO_MOV_AFEC = DET.TIPO_MOV																								"
            SQL &= Chr(13) & "		AND PROD.COD_PROD = DET.COD_PROD																								"
            SQL &= Chr(13) & "		AND PROD.COD_CIA = DET.COD_CIA																								"
            SQL &= Chr(13) & "		AND PROD.COD_SUCUR = DET.COD_SUCUR																								"
            SQL &= Chr(13) & "	LEFT JOIN DOCUMENTO_AFEC_DET_PRODUCTOS_TMP AS AFEC																									"
            SQL &= Chr(13) & "		ON  AFEC.NUMERO_DOC = DET.NUMERO_DOC																								"
            SQL &= Chr(13) & "		AND AFEC.TIPO_MOV = DET.TIPO_MOV																								"
            SQL &= Chr(13) & "		AND AFEC.COD_PROD = DET.COD_PROD																								"
            SQL &= Chr(13) & "		AND AFEC.COD_CIA = DET.COD_CIA																								"
            SQL &= Chr(13) & "		AND AFEC.COD_SUCUR = DET.COD_SUCUR																								"
            SQL &= Chr(13) & "	WHERE AFEC.COD_PROD IS NULL																									"
            SQL &= Chr(13) & "	AND (DET.CANTIDAD - ISNULL(PROD.CANTIDAD,0)) > 0																									"
            SQL &= Chr(13) & "	AND TMP.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND TMP.COD_SUCUR = " & SCM(COD_SUCUR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRIDPRODS.DataSource = DS.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaProductosAfec()
        Try
            GRIDPRODS2.DataSource = Nothing
            Dim SQL As String = ""

            If MODO_USAR = CRF_Modos.Insertar Then
                SQL = "	SELECT CODIGO AS Código, NUMERO_DOC AS Número, TIPO_MOV AS Tipo, LINEA as Linea, COD_PROD AS Producto, PRECIO_UNITARIO AS 'P/U', POR_DESCUENTO AS Descuento, POR_IMPUESTO AS Impuesto, CANTIDAD AS Cantidad,	"
                SQL &= Chr(13) & "	ESTANTE AS Estante, FILA as Fila, COLUMNA AS Columna"
                SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP	"
                SQL &= Chr(13) & "	WHERE CODIGO = 	" & SCM(Codigo)
            Else
                SQL = "	SELECT 'AXS' AS Código, NUMERO_DOC AS Número, TIPO_MOV AS Tipo, LINEA as Linea, COD_PROD AS Producto, PRECIO_UNITARIO AS 'P/U', POR_DESCUENTO AS Descuento, POR_IMPUESTO AS Impuesto, CANTIDAD AS Cantidad,																									"
                SQL &= Chr(13) & "	ESTANTE AS Estante, FILA as Fila, COLUMNA AS Columna																									"
                SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC_DET_PRODUCTOS																									"
                SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "	AND TIPO_MOV = " & SCM(TIPO_MOV_P)
                SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(NUMERO_DOC_P)
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRIDPRODS2.DataSource = DS.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cliente_Leave(sender As Object, e As EventArgs) Handles Cliente.Leave
        RellenaFacturas()
    End Sub

    Private Sub Leer_indice(ByVal NUM_GRID As Integer)
        Try

            If NUM_GRID = 1 Then
                If Me.GRID.Rows.Count > 0 Then
                    Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)

                    NUMERO_DOC = seleccionado.Cells(1).Value
                    TIPO_MOV = seleccionado.Cells(0).Value
                    FECHA = seleccionado.Cells(2).Value
                    MONTO_DOC = FMC(seleccionado.Cells(6).Value)
                Else
                    NUMERO_DOC = 0
                    TIPO_MOV = ""
                    FECHA = ""
                    MONTO_DOC = 0
                End If
            Else
                If Me.GRID2.Rows.Count > 0 Then
                    Dim seleccionado = GRID2.Rows(GRID2.SelectedRows(0).Index)

                    MONTO_DOC_AFEC = FMC(seleccionado.Cells(4).Value)
                    NUMERO_DOC = seleccionado.Cells(1).Value
                    TIPO_MOV = seleccionado.Cells(2).Value
                Else
                    NUMERO_DOC = 0
                    TIPO_MOV = ""
                    MONTO_DOC_AFEC = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_MONEDA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_MONEDA.SelectedIndexChanged
        RellenaFacturas()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        EliminarAfecTodo()
        Me.Close()
        Me.Padre.Refrescar()
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick, TabControl1.DoubleClick
        Try
            Leer_indice(1)

            If NUMERO_DOC > 0 Then
                Dim SQL = " INSERT INTO DOCUMENTO_AFEC_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,NUMERO_DOC,TIPO_MOV,FECHA,MONTO_DOC,MONTO_AFEC)"
                SQL &= Chr(13) & " SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & Val(NUMERO_DOC) & "," & SCM(TIPO_MOV) & "," & SCM(YMD(FECHA)) & "," & FMC(MONTO_DOC) & ", 0"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                RellenaFacturas()
                RellenaFacturasAfec()
                CalculoTotales()

                If CMB_TIPO.SelectedIndex = 0 Then
                    RellenaProductos()
                End If

                CMB_MONEDA.Enabled = False
                Cliente.Enabled = False
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

    Private Sub EliminarAfec()
        Try
            Dim SQL = " DELETE FROM DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = " & SCM(Codigo) & " AND NUMERO_DOC = " & Val(NUMERO_DOC) & " AND TIPO_MOV = " & SCM(TIPO_MOV)
            Dim SQL2 = " DELETE FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP WHERE CODIGO = " & SCM(Codigo) & " AND NUMERO_DOC = " & Val(NUMERO_DOC) & " AND TIPO_MOV = " & SCM(TIPO_MOV)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.EJECUTE(SQL2)
            CONX.Coneccion_Cerrar()

            RellenaFacturas()
            RellenaFacturasAfec()
            CalculoTotales()

            If CMB_TIPO.SelectedIndex = 0 Then
                RellenaProductos()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarAfecTodo()
        Try
            Dim SQL = " DELETE FROM DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = " & SCM(Codigo)
            Dim SQL2 = " DELETE FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP WHERE CODIGO = " & SCM(Codigo)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.EJECUTE(SQL2)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CalculoTotales()
        Try
            Dim SQL As String = ""
            If MODO_USAR = CRF_Modos.Insertar Then
                SQL = "	SELECT ISNULL(SUM(MONTO_DOC), 0) AS MONTO, ISNULL(SUM(MONTO_AFEC), 0) AS MONTO_AFEC	"
                SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC_DET_TMP		"
                SQL &= Chr(13) & "	WHERE CODIGO= " & SCM(Codigo)
            Else
                SQL = "	SELECT ISNULL(SUM(MONTO_AFEC), 0) AS MONTO, ISNULL(SUM(MONTO_AFEC), 0) AS MONTO_AFEC "
                SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC	"
                SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "	AND TIPO_MOV = " & SCM(TIPO_MOV_P)
                SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(NUMERO_DOC_P)
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            TXT_M.Text = FMCP(DS.Tables(0).Rows(0).Item("MONTO"), 4)
            TXT_DIS.Text = FMCP(DS.Tables(0).Rows(0).Item("MONTO_AFEC"), 4)
            TXT_DIF.Text = FMCP(FMC(DS.Tables(0).Rows(0).Item("MONTO")) - FMC(DS.Tables(0).Rows(0).Item("MONTO_AFEC")), 4)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_TIPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO.SelectedIndexChanged
        If CMB_TIPO.SelectedIndex = 0 Then
            If TabControl1.TabPages.Count < 4 Then
                EscondeTab(TabProducto, True)
            End If
        Else
            EscondeTab(TabProducto, False)
            EliminaProductosTmp()
            IngresaMontoAfec()
            CalculoTotales()
        End If
    End Sub

    Private Sub EliminaProductosTmp()
        Try
            Dim SQL = " DELETE FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP WHERE CODIGO = " & SCM(Codigo)
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EscondeTab(ByVal page As TabPage, ByVal enable As Boolean)
        If (enable) Then
            TabControl1.TabPages.Add(page)
            PaginaEscondidas.Remove(page)
            RellenaProductosAfec()
            RellenaProductos()
        Else
            If TabControl1.SelectedIndex = 3 Then
                TabControl1.SelectedIndex = 2
            End If

            TabControl1.TabPages.Remove(page)
            PaginaEscondidas.Add(page)
        End If
    End Sub

    Private Sub NotaCredito_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            For Each page As TabPage In PaginaEscondidas
                page.Dispose()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRIDPRODS_DoubleClick(sender As Object, e As EventArgs) Handles GRIDPRODS.DoubleClick
        Try
            If GRIDPRODS.Rows.Count > 0 Then
                Dim seleccionado = GRIDPRODS.Rows(GRIDPRODS.SelectedRows(0).Index)

                Dim Cantidad_Actual = seleccionado.Cells(7).Value
                Dim valor As String = InputBox("Ingrese la cantidad del producto a devolver, la cantidad actual es: " & FMC(Cantidad_Actual, 4), "Ingrese el valor")

                If Not String.IsNullOrEmpty(valor) Then
                    If FMC(valor) > 0 Then
                        If (FMC(Cantidad_Actual) - FMC(valor)) >= 0 Then

                            Dim SQL = "	INSERT INTO DOCUMENTO_AFEC_DET_PRODUCTOS_TMP(COD_CIA,COD_SUCUR,CODIGO,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,PRECIO_UNITARIO,POR_DESCUENTO,POR_IMPUESTO,CANTIDAD,ESTANTE,FILA,COLUMNA)	"
                            SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & Val(seleccionado.Cells(0).Value) & "," & SCM(seleccionado.Cells(1).Value) & "," & Val(seleccionado.Cells(2).Value)
                            SQL &= Chr(13) & "," & SCM(seleccionado.Cells(3).Value) & "," & FMC(seleccionado.Cells(4).Value, 4) & "," & Val(seleccionado.Cells(5).Value) & "," & Val(seleccionado.Cells(6).Value) & "," & FMC(FMC(valor), 4)
                            SQL &= Chr(13) & "," & SCM(seleccionado.Cells(8).Value) & "," & SCM(seleccionado.Cells(9).Value) & "," & SCM(seleccionado.Cells(10).Value)
                            CONX.Coneccion_Abrir()
                            CONX.EJECUTE(SQL)
                            CONX.Coneccion_Cerrar()

                            IngresaMontoAfec()
                            RellenaProductosAfec()
                            RellenaProductos()
                            CalculoTotales()
                        Else
                            MessageBox.Show("La cantidad ingresada es mayor a la cantidad que se puede afectar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("La cantidad ingresada no es mayor a 0, es necesario que sea mayor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRIDPRODS2_DoubleClick(sender As Object, e As EventArgs) Handles GRIDPRODS2.DoubleClick
        Try
            If GRIDPRODS2.Rows.Count > 0 Then
                Dim seleccionado = GRIDPRODS2.Rows(GRIDPRODS2.SelectedRows(0).Index)

                Dim SQL = " DELETE FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP WHERE CODIGO = " & SCM(Codigo)
                SQL &= Chr(13) & " AND NUMERO_DOC = " & Val(seleccionado.Cells(1).Value)
                SQL &= Chr(13) & " AND TIPO_MOV = " & SCM(seleccionado.Cells(2).Value)
                SQL &= Chr(13) & " AND LINEA = " & Val(seleccionado.Cells(3).Value)

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                IngresaMontoAfec()
                RellenaProductosAfec()
                RellenaProductos()
                CalculoTotales()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If FMC(TXT_M.Text) = FMC(TXT_DIF.Text) Then
                MessageBox.Show("Debe de afectar el monto del o los documentos ingresados, actualmente no se ha afectado ningún monto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf CMB_TIPO.SelectedIndex = 0 And GRIDPRODS2.Rows.Count <= 0 Then
                MessageBox.Show("Debe de ingresar el o los productos en la devolución, actualmente no se ha ingresado ningún producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If FMC(TXT_DIF.Text) > 0 Then
                    Dim respuesta = MessageBox.Show(Me, "La diferencia está siendo mayor a 0, ¿Seguro desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If respuesta = DialogResult.Yes Then
                        IngresaEncabezadoTemporal()

                        Dim Sql = "	UPDATE DOCUMENTO_AFEC_DET_TMP	"
                        Sql &= Chr(13) & "	SET MONTO_DOC = MONTO_AFEC "
                        Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                        Sql &= Chr(13) & "  AND COD_SUCUR =   " & SCM(COD_SUCUR)
                        Sql &= Chr(13) & "  AND CODIGO =   " & SCM(Codigo)
                        CONX.Coneccion_Abrir()
                        CONX.EJECUTE(Sql)
                        CONX.Coneccion_Cerrar()

                        IngresaDocumentos()
                    End If
                Else
                    IngresaEncabezadoTemporal()
                    IngresaDocumentos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IngresaDocumentos()
        Try
            Dim Sql = "	USP_FACTURACION_TMP_A_REAL	"
            Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@TIPO_MOV  = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
            Sql &= Chr(13) & "	,@CODIGO = 	" & SCM(Codigo)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2) = "RB" Then
                Dim pregunta = MessageBox.Show(Me, "Documento ingresado correctamente, ¿desea imprimir el documento?", Me.Text, vbYesNo, MessageBoxIcon.Question)
                If pregunta = DialogResult.Yes Then
                    Dim imp As New Impresion()
                    imp.ImprimirRecibo(COD_CIA, COD_SUCUR, DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                    Cerrar()
                Else
                    Cerrar()
                End If
            Else
                MessageBox.Show("Documento ingresado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub IngresaEncabezadoTemporal()
        Try
            Dim SQL As String = ""
            If CMB_TIPO.SelectedIndex = 0 Then
                SQL = "	INSERT INTO DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION,TIPO_NOTA)"
                SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(Cliente.VALOR)
                SQL &= Chr(13) & "," & SCM(YMD(DTPFECHA.Value)) & ", GETDATE()," & SCM(COD_USUARIO) & "," & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                SQL &= Chr(13) & "," & FMC(TXT_TIPO_CAMBIO.Text) & ", 0," & SCM(CMB_FORMAPAGO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(TXT_DESCRIPCION.Text) & "," & SCM(CMB_TIPO.SelectedItem.ToString.Substring(0, 2))

            Else
                SQL = "	INSERT INTO DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION,TIPO_NOTA)"
                SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(Cliente.VALOR)
                SQL &= Chr(13) & "," & SCM(YMD(DTPFECHA.Value)) & ", GETDATE()," & SCM(COD_USUARIO) & "," & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                SQL &= Chr(13) & "," & FMC(TXT_TIPO_CAMBIO.Text) & ", 0," & SCM(CMB_FORMAPAGO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(TXT_DESCRIPCION.Text) & ", NULL"
            End If

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IngresaMontoAfec()
        Try
            Dim SQL = "IF EXISTS(SELECT COD_CIA"
            SQL &= Chr(13) & "  FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP		"
            SQL &= Chr(13) & "  WHERE CODIGO =" & SCM(Codigo) & ")"
            SQL &= Chr(13) & "  BEGIN"
            SQL &= Chr(13) & "  UPDATE DOCUMENTO_AFEC_DET_TMP"
            SQL &= Chr(13) & "	SET MONTO_AFEC = T1.TOTAL		"
            SQL &= Chr(13) & "	FROM("
            SQL &= Chr(13) & "  SELECT COD_CIA, COD_SUCUR, CODIGO, SUM((PRECIO_UNITARIO * CANTIDAD) - (((PRECIO_UNITARIO * CANTIDAD) * POR_DESCUENTO) / 100) + (((PRECIO_UNITARIO * CANTIDAD)-((PRECIO_UNITARIO * CANTIDAD) * POR_DESCUENTO) / 100) * POR_IMPUESTO) / 100) AS TOTAL"
            SQL &= Chr(13) & "  FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP "
            SQL &= Chr(13) & "  WHERE CODIGO = " & SCM(Codigo)
            SQL &= Chr(13) & "  GROUP BY COD_CIA, COD_SUCUR, CODIGO"
            SQL &= Chr(13) & ") AS T1"
            SQL &= Chr(13) & " WHERE DOCUMENTO_AFEC_DET_TMP.COD_CIA = T1.COD_CIA"
            SQL &= Chr(13) & " AND DOCUMENTO_AFEC_DET_TMP.COD_SUCUR = T1.COD_SUCUR"
            SQL &= Chr(13) & " AND DOCUMENTO_AFEC_DET_TMP.CODIGO = T1.CODIGO"
            SQL &= Chr(13) & " END "
            SQL &= Chr(13) & " ELSE "
            SQL &= Chr(13) & " BEGIN"
            SQL &= Chr(13) & " UPDATE DOCUMENTO_AFEC_DET_TMP"
            SQL &= Chr(13) & " SET MONTO_AFEC = 0"
            SQL &= Chr(13) & " WHERE CODIGO = " & SCM(Codigo)
            SQL &= Chr(13) & " END"

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IgualarMontoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IgualarMontoToolStripMenuItem.Click
        Leer_indice(2)
        If MONTO_DOC_AFEC > 0 Then
            Dim Sql = "UPDATE DOCUMENTO_AFEC_DET_TMP"
            Sql &= Chr(13) & "  SET MONTO_AFEC = " & FMC(MONTO_DOC_AFEC)
            Sql &= Chr(13) & "  WHERE NUMERO_DOC = " & Val(NUMERO_DOC)
            Sql &= Chr(13) & "  AND TIPO_MOV = " & SCM(TIPO_MOV)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            RellenaFacturasAfec()
            CalculoTotales()
        End If
    End Sub

    Private Sub IngrearMontoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngrearMontoToolStripMenuItem.Click
        Leer_indice(2)
        If MONTO_DOC_AFEC > 0 Then
            Dim Valor As String = InputBox("Ingrese el monto con el cual desea afectar, el monto actual es: " & FMCP(MONTO_DOC, 4), "Ingrese el valor")

            If Not String.IsNullOrEmpty(Valor) Then
                If (FMC(MONTO_DOC_AFEC, 4) - FMC(Valor)) >= 0 Then
                    Dim Sql = "UPDATE DOCUMENTO_AFEC_DET_TMP"
                    Sql &= Chr(13) & "  SET MONTO_AFEC = " & FMC(Valor)
                    Sql &= Chr(13) & "  WHERE NUMERO_DOC = " & Val(NUMERO_DOC)
                    Sql &= Chr(13) & "  AND TIPO_MOV = " & SCM(TIPO_MOV)

                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(Sql)
                    CONX.Coneccion_Cerrar()

                    RellenaFacturasAfec()
                    CalculoTotales()
                End If
            End If
        End If
    End Sub

    Private Sub GRID2_Click(sender As Object, e As MouseEventArgs) Handles GRID2.Click
        If e.Button = MouseButtons.Right And MODO_USAR = CRF_Modos.Insertar Then
            If CMB_TIPO.SelectedIndex <> 0 Then
                CMS.Show(GRID2, GRID2.PointToClient(Cursor.Position))
            Else
                CMS.Hide()
            End If
        End If
    End Sub

    Private Sub GRID2_DoubleClick(sender As Object, e As EventArgs) Handles GRID2.DoubleClick
        Try
            Leer_indice(2)
            EliminarAfec()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub NotaCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If MODO_USAR = CRF_Modos.Insertar Then
                Codigo = GenerarCodigo()

                If Tipo = "A" Then
                    TAB_FACTURAS.Text = "[ Apartados ]"
                    CMB_DOCUMENTO.Enabled = False
                End If

                TabProducto = TabControl1.TabPages(3)
                EscondeTab(TabProducto, False)

                CMB_DOCUMENTO.SelectedIndex = 0
                CMB_MONEDA.SelectedIndex = 0
                CMB_FORMAPAGO.SelectedIndex = 0

                TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)
            ElseIf MODO_USAR = CRF_Modos.Seleccionar Then
                TabProducto = TabControl1.TabPages(3)
                EscondeTab(TabProducto, False)

                TXT_NUMERO.Text = NUMERO_DOC_P
                RELLENA_DATOS()
                RellenaFacturasAfec()
                RellenaProductosAfec()
                CalculoTotales()
            End If

            BloqueaControles()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class