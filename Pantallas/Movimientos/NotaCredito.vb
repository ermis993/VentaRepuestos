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

    Private PaginaEscondidas As New List(Of TabPage)

    Sub New(ByVal PADRE As Facturacion)
        InitializeComponent()

        Me.Padre = PADRE
        Cliente.TABLA_BUSCAR = "CLIENTE"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE"
        Cliente.refrescar()

        Codigo = GenerarCodigo()

        TabProducto = TabControl1.TabPages(3)

        EscondeTab(TabProducto, False)

        CMB_DOCUMENTO.SelectedIndex = 0
        TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)

        BloqueaControles()

    End Sub

    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = False
            TXT_TIPO_CAMBIO.Enabled = False
            DTPFECHA.Enabled = False
            'CMB_DOCUMENTO.Enabled = IIf(Modo = CRF_Modos.Insertar, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_DOCUMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_DOCUMENTO.SelectedIndexChanged
        If CMB_DOCUMENTO.SelectedIndex = 1 Then
            LBLTIPO.Visible = True
            CMB_TIPO.Visible = True
            CMB_TIPO.SelectedIndex = 0
        Else
            LBLTIPO.Visible = False
            CMB_TIPO.Visible = False
            CMB_TIPO.SelectedIndex = -1
            EliminaProductosTmp()
        End If
    End Sub

    Private Sub RellenaFacturas()
        Try
            If Not CMB_MONEDA.SelectedIndex <= -1 And String.IsNullOrEmpty(Cliente.VALOR) = False Then

                GRID.DataSource = Nothing

                Dim SQL = "	SELECT ENC.TIPO_MOV AS Tipo, ENC.NUMERO_DOC AS Número, CONVERT(VARCHAR(10),ENC.FECHA, 105) AS Fecha, MONTO AS Subtotal		"
                SQL &= Chr(13) & "	, IMPUESTO as Impuesto, (MONTO+IMPUESTO) AS Total, SALDO as Saldo"
                SQL &= Chr(13) & "	FROM DOCUMENTO_ENC AS ENC"
                SQL &= Chr(13) & "  LEFT JOIN DOCUMENTO_AFEC_DET_TMP AS AFEC"
                SQL &= Chr(13) & "      ON AFEC.NUMERO_DOC = ENC.NUMERO_DOC"
                SQL &= Chr(13) & "      AND AFEC.TIPO_MOV = ENC.TIPO_MOV"
                SQL &= Chr(13) & "	WHERE CEDULA = " & SCM(Cliente.VALOR)
                SQL &= Chr(13) & "	AND COD_MONEDA = " & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                SQL &= Chr(13) & "  AND SALDO > 0 "
                SQL &= Chr(13) & "  AND ENC.TIPO_MOV IN ('FA', 'FC')"
                SQL &= Chr(13) & "  AND AFEC.NUMERO_DOC IS NULL"

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
            Dim SQL = "	SELECT CODIGO AS Código, NUMERO_DOC AS Número, TIPO_MOV AS Tipo, FECHA AS Fecha, MONTO_DOC AS Monto, MONTO_AFEC AS 'Monto afectado', (MONTO_DOC - MONTO_AFEC) as Saldo"
            SQL &= Chr(13) & " FROM DOCUMENTO_AFEC_DET_TMP"
            SQL &= Chr(13) & " WHERE CODIGO = 	" & SCM(Codigo)

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
            Dim SQL = "	SELECT DET.NUMERO_DOC AS Número, DET.TIPO_MOV as Tipo, DET.LINEA as Linea, DET.COD_PROD as Código, (DET.CANTIDAD - ISNULL(PROD.CANTIDAD,0)) as Cantidad		"
            SQL &= Chr(13) & "	, DET.ESTANTE AS Estante, DET.FILA AS Fila, DET.COLUMNA AS Columna"
            SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC_DET_TMP AS TMP		"
            SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_DET AS DET		"
            SQL &= Chr(13) & "		ON DET.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "      AND DET.COD_SUCUR =" & SCM(COD_SUCUR)
            SQL &= Chr(13) & "		AND DET.NUMERO_DOC = TMP.NUMERO_DOC	"
            SQL &= Chr(13) & "		AND DET.TIPO_MOV = TMP.TIPO_MOV"
            SQL &= Chr(13) & "	LEFT JOIN DOCUMENTO_AFEC_DET_PRODUCTOS AS PROD	"
            SQL &= Chr(13) & "		ON PROD.NUMERO_DOC_AFEC = DET.NUMERO_DOC	"
            SQL &= Chr(13) & "		AND PROD.TIPO_MOV_AFEC = DET.TIPO_MOV	"
            SQL &= Chr(13) & "      AND PROD.COD_PROD = DET.COD_PROD"
            SQL &= Chr(13) & "	LEFT JOIN DOCUMENTO_AFEC_DET_PRODUCTOS_TMP AS AFEC	"
            SQL &= Chr(13) & "		ON  AFEC.NUMERO_DOC = DET.NUMERO_DOC	"
            SQL &= Chr(13) & "		AND AFEC.TIPO_MOV = DET.TIPO_MOV	"
            SQL &= Chr(13) & "		AND AFEC.COD_PROD = DET.COD_PROD"
            SQL &= Chr(13) & "	WHERE AFEC.COD_PROD IS NULL			"
            SQL &= Chr(13) & " AND (DET.CANTIDAD - ISNULL(PROD.CANTIDAD,0)) > 0"


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
            Dim SQL = "	SELECT CODIGO AS Código, NUMERO_DOC AS Número, TIPO_MOV AS Tipo, LINEA as Linea, COD_PROD AS Código, CANTIDAD AS Cantidad,	"
            SQL &= Chr(13) & "	ESTANTE AS Estante, FILA as Fila, COLUMNA AS Columna"
            SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP	"
            SQL &= Chr(13) & "	WHERE CODIGO = 	" & SCM(Codigo)

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
        EliminarTodoTemporal()
        Me.Close()
        Me.Padre.Refrescar()
    End Sub

    Private Sub IgualarMontoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IgualarMontoToolStripMenuItem.Click
        Leer_indice(2)
        If MONTO_DOC_AFEC > 0 Then

            Dim Sql = "	UPDATE DOCUMENTO_AFEC_DET_TMP	"
            Sql &= Chr(13) & "	SET MONTO_AFEC = " & FMC(MONTO_DOC_AFEC)
            Sql &= Chr(13) & "	WHERE NUMERO_DOC = 	" & Val(NUMERO_DOC)
            Sql &= Chr(13) & " And TIPO_MOV =   " & SCM(TIPO_MOV)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            RellenaFacturasAfec()
            CalculoTotales()
        End If
    End Sub

    Private Sub IngresarMontoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarMontoToolStripMenuItem.Click
        Try
            Leer_indice(2)
            If MONTO_DOC_AFEC > 0 Then
                Dim valor As Double = InputBox("Ingrese el monto con el cual desea afectar el documento, el monto actual es: " & FMC(MONTO_DOC_AFEC), "Ingrese el valor")
                If (FMC(MONTO_DOC_AFEC) - FMC(valor)) >= 0 Then

                    Dim Sql = "	UPDATE DOCUMENTO_AFEC_DET_TMP	"
                    Sql &= Chr(13) & "	SET MONTO_AFEC = " & FMC(valor)
                    Sql &= Chr(13) & "	WHERE NUMERO_DOC = 	" & Val(NUMERO_DOC)
                    Sql &= Chr(13) & " And TIPO_MOV =   " & SCM(TIPO_MOV)

                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(Sql)
                    CONX.Coneccion_Cerrar()

                    RellenaFacturasAfec()
                    CalculoTotales()

                Else
                    MessageBox.Show("El monto digitado es mayor al monto que se está afectando")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Try
            Leer_indice(1)

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

    Private Sub GRID2_DoubleClick(sender As Object, e As EventArgs) Handles GRID2.DoubleClick
        Try
            Leer_indice(2)

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
                RellenaProductosAfec()
                RellenaProductos()
            End If

            If GRID2.Rows.Count <= 0 Then
                CMB_MONEDA.Enabled = True
                Cliente.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarTodoTemporal()
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
            Dim SQL = "	SELECT ISNULL(SUM(MONTO_DOC), 0) AS MONTO, ISNULL(SUM(MONTO_AFEC), 0) AS MONTO_AFEC	"
            SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC_DET_TMP		"
            SQL &= Chr(13) & "	WHERE CODIGO= " & SCM(Codigo)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
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

                Dim Cantidad_Actual = seleccionado.Cells(4).Value
                Dim valor As Double = InputBox("Ingrese la cantidad del producto a devolver, la cantidad actual es: " & FMC(Cantidad_Actual, 4), "Ingrese el valor")

                If FMC(valor) > 0 Then
                    If (FMC(Cantidad_Actual) - FMC(valor)) >= 0 Then

                        Dim SQL = "	INSERT INTO DOCUMENTO_AFEC_DET_PRODUCTOS_TMP(COD_CIA, COD_SUCUR, CODIGO,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,CANTIDAD,ESTANTE,FILA,COLUMNA)	"
                        SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & Val(seleccionado.Cells(0).Value) & "," & SCM(seleccionado.Cells(1).Value)
                        SQL &= Chr(13) & "," & Val(seleccionado.Cells(2).Value) & "," & SCM(seleccionado.Cells(3).Value) & "," & FMC(FMC(valor), 4)
                        SQL &= Chr(13) & "," & SCM(seleccionado.Cells(5).Value) & "," & SCM(seleccionado.Cells(6).Value) & "," & SCM(seleccionado.Cells(7).Value)
                        CONX.Coneccion_Abrir()
                        CONX.EJECUTE(SQL)
                        CONX.Coneccion_Cerrar()

                        RellenaProductosAfec()
                        RellenaProductos()
                    Else
                        MessageBox.Show("La cantidad ingresada es mayor a la cantidad que se puede afectar")
                    End If
                Else
                    MessageBox.Show("La cantidad ingresada no es mayor a 0, es necesario que sea mayor")
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

                RellenaProductosAfec()
                RellenaProductos()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If FMC(TXT_M.Text) = FMC(TXT_DIF.Text) Then
                MessageBox.Show("Debe de afectar el monto del o los documentos ingresados, actualmente no se ha afectado ningún monto")
            ElseIf CMB_TIPO.SelectedIndex = 0 And GRIDPRODS2.Rows.Count <= 0 Then
                MessageBox.Show("Debe de ingresar el o los productos en la devolución, actualmente no se ha ingresado ningún producto")
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
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            MessageBox.Show("Documento ingresado correctamente")
            Cerrar()
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
                Sql &= Chr(13) & "," & SCM(YMD(DTPFECHA.Value)) & ", GETDATE()," & SCM(COD_USUARIO) & "," & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                SQL &= Chr(13) & "," & FMC(TXT_TIPO_CAMBIO.Text) & ", 0,'EF'," & SCM(TXT_DESCRIPCION.Text) & "," & SCM(CMB_TIPO.SelectedItem.ToString.Substring(0, 2))

            Else
                SQL = "	INSERT INTO DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION,TIPO_NOTA)"
                SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(Cliente.VALOR)
                SQL &= Chr(13) & "," & SCM(YMD(DTPFECHA.Value)) & ", GETDATE()," & SCM(COD_USUARIO) & "," & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                SQL &= Chr(13) & "," & FMC(TXT_TIPO_CAMBIO.Text) & ", 0,'EF'," & SCM(TXT_DESCRIPCION.Text) & ", NULL"
            End If


            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class