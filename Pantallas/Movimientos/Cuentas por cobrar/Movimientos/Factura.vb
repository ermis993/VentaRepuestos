Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Factura

    Dim Modo As CRF_Modos
    Dim Codigo As String
    Dim Padre As Facturacion
    Dim Numero_Doc As Integer
    Dim Tipo_Mov As String
    Dim Cantidad_Global As Double = 0

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        EliminaTodoTemporal()
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Padre.Refrescar()
        Me.Close()
    End Sub

    Private Sub Buscador_Valor_Seleccionado(sender As Object, e As EventArgs) Handles Cliente.ValorSeleccionado
        Try
            If Cliente.VALOR <> "" Then
                Dim Sql = "	SELECT PRECIO_DEFECTO  "
                Sql &= Chr(13) & "	FROM CLIENTE"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND CEDULA = " & SCM(Cliente.VALOR)

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    CMB_PRECIO.SelectedIndex = Val(DS.Tables(0).Rows(0).Item("PRECIO_DEFECTO"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminaTodoTemporal()
        Try
            Dim Sql = "	DELETE FROM DOCUMENTO_ENC_TMP WHERE CODIGO =  " & SCM(Codigo)
            Sql &= Chr(13) & "	DELETE FROM DOCUMENTO_DET_TMP WHERE CODIGO =  " & SCM(Codigo)
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub New(ByVal Modo As CRF_Modos, ByVal Padre As Facturacion, Optional ByVal NUMERO_DOC As Integer = 0, Optional ByVal CODIGO As String = "", Optional ByVal TIPO_MOV As String = "")

        InitializeComponent()
        Me.Modo = Modo
        Me.Padre = Padre
        Me.Tipo_Mov = TIPO_MOV

        Cliente.TABLA_BUSCAR = "CLIENTE"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE+ ' ' + APELLIDO1"
        Cliente.PANTALLA = New Cliente(CRF_Modos.Seleccionar, Cliente)
        Cliente.CAMPO_FILTRAR = "ESTADO"
        Cliente.OTROS_CAMP0S = "A"
        Cliente.refrescar()

        If Me.Modo = CRF_Modos.Insertar Then
            TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)
            Me.Codigo = GenerarCodigo()
            CARGAR_RUTAS()
            BloqueaControles()
            CMB_DOCUMENTO.SelectedIndex = 0
            CMB_FORMAPAGO.SelectedIndex = 0
            CMB_MONEDA.SelectedIndex = 0
        ElseIf Me.Modo = CRF_Modos.Modificar Then
            Me.Codigo = CODIGO
            Me.Numero_Doc = Val(NUMERO_DOC)
            BloqueaControles()
            CARGAR_RUTAS()
            SETEO_ENCOMIENDA()
            RellenaDatos()

            If Me.Numero_Doc > 0 Then
                TXT_NUMERO.Text = Me.Numero_Doc
                BTN_ACEPTAR.Enabled = False
                BTN_FACTURAR.Enabled = False
                BTN_INGRESAR.Enabled = False
                RELLENAR_GRID(1)
            Else
                RELLENAR_GRID()
            End If
        End If

        If IND_ENCOMIENDA = "S" Then
            TAB_ENCOMIENDA.Parent = TabControl1
        Else
            TAB_ENCOMIENDA.Parent = Nothing
        End If

        CMB_PRECIO.SelectedIndex = 0

    End Sub

    Private Sub RellenaDatos()
        Try
            Dim Sql As String = ""
            If String.IsNullOrEmpty(Codigo) Then
                Sql = "	SELECT CEDULA, TIPO_MOV, FECHA, COD_MONEDA, TIPO_CAMBIO, PLAZO, FORMA_PAGO, ISNULL(DESCRIPCION, '') AS DESCRIPCION"
                Sql &= Chr(13) & "	FROM DOCUMENTO_ENC"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "  And COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND NUMERO_DOC = " & Val(Numero_Doc)
                Sql &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        DTPFECHA.Value = DMA(ITEM("FECHA"))

                        If ITEM("TIPO_MOV") = "FC" Then
                            CMB_DOCUMENTO.SelectedIndex = 0
                        Else
                            CMB_DOCUMENTO.SelectedIndex = 1
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
                        TXT_PLAZO.Text = Val(ITEM("PLAZO"))
                        TXT_DESCRIPCION.Text = ITEM("DESCRIPCION")

                        Cliente.VALOR = ITEM("CEDULA")
                        Cliente.ACTUALIZAR_COMBO()
                    Next
                End If
            Else
                Sql = "	SELECT CEDULA, TIPO_MOV, FECHA, COD_MONEDA, TIPO_CAMBIO, PLAZO, FORMA_PAGO, ISNULL(DESCRIPCION, '') AS DESCRIPCION"
                Sql &= Chr(13) & "	FROM DOCUMENTO_ENC_TMP"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND CODIGO = " & SCM(Codigo)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        DTPFECHA.Value = DMA(ITEM("FECHA"))

                        If ITEM("TIPO_MOV") = "FC" Then
                            CMB_DOCUMENTO.SelectedIndex = 0
                        Else
                            CMB_DOCUMENTO.SelectedIndex = 1
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
                        TXT_PLAZO.Text = Val(ITEM("PLAZO"))
                        TXT_DESCRIPCION.Text = ITEM("DESCRIPCION")

                        Cliente.VALOR = ITEM("CEDULA")
                        Cliente.ACTUALIZAR_COMBO()
                    Next
                End If
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

    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = False
            TXT_TIPO_CAMBIO.Enabled = False
            DTPFECHA.Enabled = False
            CMB_DOCUMENTO.Enabled = IIf(Modo = CRF_Modos.Insertar, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_DOCUMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_DOCUMENTO.SelectedIndexChanged
        If CMB_DOCUMENTO.SelectedIndex = 0 Then
            TXT_PLAZO.Text = "0"
            TXT_PLAZO.Enabled = False
        Else
            TXT_PLAZO.Enabled = True
        End If
    End Sub

    Private Sub CalculoTotales()
        Try
            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then

                Dim Cantidad As Decimal
                Dim Precio_Unitario As Decimal
                Dim Descuento As Decimal
                Dim Descuento_Total As Decimal
                Dim Impuesto As Decimal
                Dim Impuesto_Total As Decimal
                Dim Subtotal As Decimal
                Dim Total As Decimal
                Dim Exoneracion As Decimal
                Dim Exoneracion_Total As Decimal

                Cantidad = FMC(TXT_CANTIDAD.Text)
                Precio_Unitario = FMC(TXT_PRECIO.Text)
                Descuento = FMC(TXT_DESCUENTO.Text)
                Impuesto = FMC(TXT_IMPUESTO.Text)
                Exoneracion = FMC(TXT_EXONERACION.Text)

                'Se saca la exoneración
                Impuesto = Impuesto - Exoneracion

                Descuento_Total = FMC(((Precio_Unitario * Cantidad) * Descuento) / 100)
                Impuesto_Total = FMC((((Precio_Unitario * Cantidad) - Descuento_Total) * Impuesto) / 100)
                Subtotal = FMC(((Precio_Unitario * Cantidad) - Descuento_Total))
                Total = FMC(Subtotal + Impuesto_Total)
                Exoneracion_Total = FMC((((Precio_Unitario * Cantidad) - Descuento_Total) * Exoneracion) / 100)

                TXT_DESCUENTOTOTAL.Text = FMCP(Descuento_Total)
                TXT_IMPUESTOTOTAL.Text = FMCP(Impuesto_Total)
                TXT_SUBTOTAL.Text = FMCP(Subtotal)
                TXT_TOTAL.Text = FMCP(Total)
                TXT_MONTO_EXONERACION.Text = FMCP(Exoneracion_Total)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_CALCULAR_Click(sender As Object, e As EventArgs) Handles BTN_CALCULAR.Click
        CalculoTotales()
    End Sub

    Private Sub TXT_CANTIDAD_Leave(sender As Object, e As EventArgs) Handles TXT_CANTIDAD.Leave
        CalculoTotales()
    End Sub

    Private Sub TXT_DESCUENTO_Leave(sender As Object, e As EventArgs) Handles TXT_DESCUENTO.Leave
        CalculoTotales()
    End Sub

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
                TXT_UNIDAD.Text = DS.Tables(0).Rows(0).Item("COD_UNIDAD")
                If CMB_PRECIO.SelectedIndex = 0 Then
                    TXT_PRECIO.Text = DS.Tables(0).Rows(0).Item("PRECIO")
                ElseIf CMB_PRECIO.SelectedIndex = 1 Then
                    TXT_PRECIO.Text = DS.Tables(0).Rows(0).Item("PRECIO_2")
                Else
                    TXT_PRECIO.Text = DS.Tables(0).Rows(0).Item("PRECIO_3")
                End If

                TXT_IMPUESTO.Text = DS.Tables(0).Rows(0).Item("POR_IMPUESTO")
                TXT_ESTANTE.Text = DS.Tables(0).Rows(0).Item("ESTANTE")
                TXT_FILA.Text = DS.Tables(0).Rows(0).Item("FILA")
                TXT_COLUMNA.Text = DS.Tables(0).Rows(0).Item("COLUMNA")

                TXT_PRECIO.ReadOnly = IIf(DS.Tables(0).Rows(0).Item("MODIFICABLE") = "S", False, True)

                If Not String.IsNullOrEmpty(DS.Tables(0).Rows(0).Item("MENSAJE")) Then
                    MessageBox.Show(Me, DS.Tables(0).Rows(0).Item("MENSAJE"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                TXT_UNIDAD.Text = ""
                TXT_PRECIO.Text = ""
                TXT_IMPUESTO.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IngresarDetalle()
        Try
            If FMC(TXT_CANTIDAD.Text) <= 0 Then
                TXT_CANTIDAD.Select()
                MessageBox.Show(Me, "La cantidad del producto no puede ser menor o igual a cero (0)", "Mensaje cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(TXT_ESTANTE.Text) Or String.IsNullOrEmpty(TXT_FILA.Text) Or String.IsNullOrEmpty(TXT_COLUMNA.Text) Then
                MessageBox.Show(Me, "La ubicación del producto es inválida, vuelva a seleccionar el producto", "Mensaje ubicación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(Cliente.VALOR) Then
                MessageBox.Show(Me, "El cliente no ha sido seleccionado", "Mensaje cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf ((Saldo_Actual(TXT_CODIGO.Text) - FMC(TXT_CANTIDAD.Text)) < 0) And IND_VENTAS_NEGATIVAS = "N" Then
                MessageBox.Show(Me, "La sucursal está configurada para no realizar ventas en negativo, actualmente el inventario quedaría en: " & FMCP((Saldo_Actual(TXT_CODIGO.Text) - FMC(TXT_CANTIDAD.Text))), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If FMC(TXT_TOTAL.Text) > 0 Then
                    Dim SQL = "	EXECUTE USP_MANT_FACTURACION_TMP "
                    SQL &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "	,@CODIGO = " & SCM(Codigo)
                    SQL &= Chr(13) & "	,@TIPO_MOV = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                    SQL &= Chr(13) & "	,@CEDULA = " & SCM(Cliente.VALOR)
                    SQL &= Chr(13) & "	,@FECHA = " & SCM(YMD(DTPFECHA.Value))
                    SQL &= Chr(13) & "	,@COD_USUARIO = " & SCM(COD_USUARIO)
                    SQL &= Chr(13) & "	,@COD_MONEDA = " & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                    SQL &= Chr(13) & "	,@TIPO_CAMBIO = " & FMC(TXT_TIPO_CAMBIO.Text)
                    SQL &= Chr(13) & "	,@PLAZO = " & Val(TXT_PLAZO.Text)
                    SQL &= Chr(13) & "	,@FORMA_PAGO = " & SCM(CMB_FORMAPAGO.SelectedItem.ToString.Substring(0, 2))
                    SQL &= Chr(13) & "	,@DESCRIPCION = " & SCM(TXT_DESCRIPCION.Text)
                    SQL &= Chr(13) & "	,@COD_PROD = " & SCM(TXT_CODIGO.Text)
                    SQL &= Chr(13) & "	,@COD_UNIDAD = " & SCM(TXT_UNIDAD.Text)
                    SQL &= Chr(13) & "	,@CANTIDAD = " & FMC(TXT_CANTIDAD.Text)
                    SQL &= Chr(13) & "	,@PRECIO = " & FMC(TXT_PRECIO.Text)
                    SQL &= Chr(13) & "	,@POR_DESCUENTO = " & Val(TXT_DESCUENTO.Text)
                    SQL &= Chr(13) & "	,@DESCUENTO = " & FMC(TXT_DESCUENTOTOTAL.Text)
                    SQL &= Chr(13) & "	,@POR_IMPUESTO = " & Val(TXT_IMPUESTO.Text)
                    SQL &= Chr(13) & "	,@IMPUESTO = " & FMC(TXT_IMPUESTOTOTAL.Text)
                    SQL &= Chr(13) & "	,@POR_EXO = " & Val(TXT_EXONERACION.Text)
                    SQL &= Chr(13) & "	,@EXONERACION = " & FMC(TXT_MONTO_EXONERACION.Text)
                    SQL &= Chr(13) & "	,@SUBTOTAL = " & FMC(TXT_SUBTOTAL.Text)
                    SQL &= Chr(13) & "	,@TOTAL = " & FMC(TXT_TOTAL.Text)
                    SQL &= Chr(13) & "	,@ESTANTE = " & SCM(TXT_ESTANTE.Text)
                    SQL &= Chr(13) & "	,@FILA = " & SCM(TXT_FILA.Text)
                    SQL &= Chr(13) & "	,@COLUMNA = " & SCM(TXT_COLUMNA.Text)
                    SQL &= Chr(13) & "	,@IND_SUMAR_CANTIDAD = " & SCM(IND_SUMAR_CANTIDADES)
                    SQL &= Chr(13) & "	,@MODO =" & Val(Modo)

                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(SQL)
                    CONX.Coneccion_Cerrar()

                    If IND_ENCOMIENDA = "S" Then
                        Cantidad_Global += FMC(TXT_CANTIDAD.Text)
                        TXT_CANT_BULTOS.Text = Val(Cantidad_Global)
                    End If

                    LimpiarControles()

                    RELLENAR_GRID()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_INGRESAR_Click(sender As Object, e As EventArgs) Handles BTN_INGRESAR.Click
        If ExisteProducto() Then
            IngresarDetalle()
        Else
            TXT_CODIGO.Select()
            MessageBox.Show(Me, "El código de producto ingresado no ha sido ingresado a la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function ExisteProducto() As Boolean
        Try
            Dim bandera As Boolean = False

            Dim Sql = "	SELECT *"
            Sql &= Chr(13) & "	FROM PRODUCTO"
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	AND COD_PROD = " & SCM(TXT_CODIGO.Text)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                bandera = True
            End If

            Return bandera
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Sub LimpiarControles()
        TXT_CANTIDAD.Text = ""
        TXT_DESCUENTO.Text = ""
        TXT_DESCUENTOTOTAL.Text = ""
        TXT_IMPUESTOTOTAL.Text = ""
        TXT_SUBTOTAL.Text = ""
        TXT_TOTAL.Text = ""
        TXT_PRECIO.Text = ""
        TXT_UNIDAD.Text = ""
        TXT_CODIGO.Text = ""
        TXT_IMPUESTO.Text = ""
        TXT_FILA.Text = ""
        TXT_COLUMNA.Text = ""
        TXT_ESTANTE.Text = ""
        TXT_EXONERACION.Text = ""
        TXT_MONTO_EXONERACION.Text = ""
        LVResultados.Clear()
    End Sub

    Public Sub RELLENAR_GRID(Optional ByVal modo As Integer = 0)
        Try
            GRID.Rows.Clear()
            GRID.DataSource = Nothing

            GRID.ColumnCount = 11
            GRID.Columns(0).Name = "Linea"
            GRID.Columns(1).Name = "Código"
            GRID.Columns(2).Name = "Descripción"
            GRID.Columns(3).Name = "Estante"
            GRID.Columns(4).Name = "Fila"
            GRID.Columns(5).Name = "Columna"
            GRID.Columns(6).Name = "Cantidad"
            GRID.Columns(7).Name = "P/U"
            GRID.Columns(8).Name = "% Descuento"
            GRID.Columns(9).Name = "Impuesto"
            GRID.Columns(10).Name = "Total"

            If modo = 0 Then
                Dim SQL = "	Select TMP.LINEA , PROD.COD_PROD , PROD.DESCRIPCION , TMP.CANTIDAD, TMP.PRECIO "
                SQL &= Chr(13) & "	, TMP.POR_DESCUENTO , TMP.IMPUESTO, TMP.TOTAL, TMP.ESTANTE, TMP.FILA, TMP.COLUMNA"
                SQL &= Chr(13) & "	FROM DOCUMENTO_DET_TMP AS TMP	"
                SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD		"
                SQL &= Chr(13) & "		ON PROD.COD_CIA = TMP.COD_CIA	"
                SQL &= Chr(13) & " And PROD.COD_SUCUR = TMP.COD_SUCUR "
                SQL &= Chr(13) & "		AND PROD.COD_PROD = TMP.COD_PROD	"
                SQL &= Chr(13) & "	WHERE TMP.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND TMP.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & " And TMP.CODIGO =  " & SCM(Codigo)

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then

                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("LINEA"), ITEM("COD_PROD"), ITEM("DESCRIPCION"), ITEM("ESTANTE"), ITEM("FILA"), ITEM("COLUMNA"), ITEM("CANTIDAD"), ITEM("PRECIO"), ITEM("POR_DESCUENTO"), ITEM("IMPUESTO"), ITEM("TOTAL")}
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
                SQL &= Chr(13) & " And TMP.NUMERO_DOC =  " & Val(Numero_Doc)
                SQL &= Chr(13) & " AND TMP.TIPO_MOV = " & SCM(Tipo_Mov)

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then

                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("LINEA"), ITEM("COD_PROD"), ITEM("DESCRIPCION"), ITEM("ESTANTE"), ITEM("FILA"), ITEM("COLUMNA"), ITEM("CANTIDAD"), ITEM("PRECIO"), ITEM("POR_DESCUENTO"), ITEM("IMPUESTO"), ITEM("TOTAL")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If

            SumatoriaIngreso()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
                TXT_DESCUENTO.Text = seleccionado.Cells(8).Value.ToString
                TXT_CODIGO.Text = seleccionado.Cells(1).Value.ToString
                RellenaProducto(seleccionado.Cells(3).Value.ToString, seleccionado.Cells(4).Value.ToString, seleccionado.Cells(5).Value.ToString)
                RellenaExoneracion()
                CalculoTotales()
                TabControl1.SelectedIndex = 1
                TXT_CANTIDAD.Focus()

                If IND_ENCOMIENDA = "S" Then
                    Cantidad_Global -= FMC(seleccionado.Cells(6).Value)
                    TXT_CANT_BULTOS.Text = Val(Cantidad_Global)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GRID.CellMouseDoubleClick
        Modificar()
    End Sub

    Private Sub TXT_CANTIDAD_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CANTIDAD.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_DESCUENTO.Focus()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TXT_DESCUENTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_DESCUENTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            BTN_CALCULAR.Focus()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click

        If Modo = CRF_Modos.Modificar Then
            Dim Sql = "	UPDATE DOCUMENTO_ENC_TMP	"
            Sql &= Chr(13) & "				SET CEDULA = " & SCM(Cliente.VALOR)
            Sql &= Chr(13) & "				,COD_USUARIO = " & SCM(COD_USUARIO)
            Sql &= Chr(13) & "				,COD_MONEDA = " & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
            Sql &= Chr(13) & "				,PLAZO = " & Val(TXT_PLAZO.Text)
            Sql &= Chr(13) & "				,FORMA_PAGO = " & SCM(CMB_FORMAPAGO.SelectedItem.ToString.Substring(0, 2))
            Sql &= Chr(13) & "				,DESCRIPCION = " & SCM(TXT_DESCRIPCION.Text)
            Sql &= Chr(13) & "				WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "				AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "				AND CODIGO = " & SCM(Codigo)
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()
        End If

        Cerrar()
    End Sub

    Private Sub Busca_Producto(ByVal presiono_enter As Boolean, ByVal Producto_Unico As Boolean)
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
                If Producto_Unico Then
                    Sql &= Chr(13) & " AND COD_PROD = " & SCM(TXT_CODIGO.Text)
                Else
                    Sql &= Chr(13) & " AND (DESCRIPCION Like " & SCM("%" + TXT_CODIGO.Text + "%") & " Or COD_PROD = " & SCM(TXT_CODIGO.Text) & " Or COD_BARRA = " & SCM(TXT_CODIGO.Text) & " Or REL.COD_PROD_HIJO = " & SCM(TXT_CODIGO.Text) & ")"
                End If
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

                    If LVResultados.Items.Count = 1 And presiono_enter And IND_INGRESO_AUTO = "S" Then
                        DobleClickList()
                        TXT_CANTIDAD.Text = IIf(String.IsNullOrEmpty(TXT_CANTIDAD.Text), Min_Venta(TXT_CODIGO.Text), FMC(TXT_CANTIDAD.Text))
                        CalculoTotales()
                        IngresarDetalle()
                        TXT_CODIGO.Select()
                    End If

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

    Private Sub DobleClickList()
        Try
            Dim Codigo = LVResultados.Items(0).Name
            Dim Descripcion = LVResultados.Items(0).Text

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

        Dim Saldo_Producto As Decimal = Saldo_Actual(codigo)
        Dim Minimo_Stock As Decimal = Min_Stock(codigo)

        If ((IND_VENTAS_NEGATIVAS = "S" And Saldo_Producto <= 0.0) Or Saldo_Producto > 0.0) Then

            If IND_MIN_STOCK = "S" And (Saldo_Producto <= Minimo_Stock) Then
                MessageBox.Show(Me, "El producto está llegando a su mínimo actualmente el saldo es: " & FMC(Saldo_Producto), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            RellenaProducto(estante, fila, columna)
            RellenaExoneracion()
            Busca_Producto(False, True)
            TXT_CANTIDAD.Focus()
        Else
            MessageBox.Show(Me, "La sucursal no permite ventas con inventario negativo, el saldo actual del producto es: " & FMC(Saldo_Producto), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function Saldo_Actual(ByVal COD_PROD As String) As Decimal
        Dim Resultado As Decimal = 0.0
        Try
            Dim Sql = "	SELECT ISNULL(SUM(DET.CANTIDAD), 0) AS CANTIDAD  "
            Sql &= Chr(13) & "	FROM PRODUCTO AS P	"
            Sql &= Chr(13) & "	LEFT JOIN INVENTARIO_MOV_DET AS DET	"
            Sql &= Chr(13) & "	    ON DET.COD_CIA = P.COD_CIA	"
            Sql &= Chr(13) & "	    AND DET.COD_SUCUR = P.COD_SUCUR	"
            Sql &= Chr(13) & "	    AND DET.COD_PROD = P.COD_PROD	"
            Sql &= Chr(13) & "	WHERE P.COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	AND P.COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	AND P.COD_PROD = " & SCM(COD_PROD)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                Resultado = FMC(DS.Tables(0).Rows(0).Item("CANTIDAD"))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return Resultado

    End Function

    Private Function Min_Stock(ByVal COD_PROD As String) As Decimal
        Dim Resultado As Decimal = 0.0
        Try
            Dim Sql = "	SELECT ISNULL(MINIMO, 0) AS MIN  "
            Sql &= Chr(13) & "	FROM PRODUCTO"
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	AND COD_PROD = " & SCM(COD_PROD)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                Resultado = FMC(DS.Tables(0).Rows(0).Item("MIN"))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return Resultado

    End Function

    Private Function Min_Venta(ByVal COD_PROD As String) As Decimal
        Dim Resultado As Decimal = 0.0
        Try
            Dim Sql = "	SELECT ISNULL(MIN_VENTA, 0) AS MIN  "
            Sql &= Chr(13) & "	FROM PRODUCTO"
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	AND COD_PROD = " & SCM(COD_PROD)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                Resultado = FMC(DS.Tables(0).Rows(0).Item("MIN"))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return Resultado

    End Function

    Private Sub GRID_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles GRID.CellClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 11 Then
                    Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                    Dim valor = MessageBox.Show(Me, "¿Seguro que desea eliminar la linea :" + seleccionado.Cells(0).Value.ToString + "?", "Eliminar linea", vbYesNo, MessageBoxIcon.Question)

                    If valor = DialogResult.Yes Then

                        Dim SQL = "	DELETE FROM DOCUMENTO_DET_TMP	"
                        SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                        SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                        SQL &= Chr(13) & "	AND CODIGO = " & SCM(Codigo)
                        SQL &= Chr(13) & "	AND LINEA = " & Val(seleccionado.Cells(0).Value)

                        CONX.Coneccion_Abrir()
                        CONX.EJECUTE(SQL)
                        CONX.Coneccion_Cerrar()

                        If IND_ENCOMIENDA = "S" Then
                            Cantidad_Global -= FMC(seleccionado.Cells(6).Value)
                            TXT_CANT_BULTOS.Text = Val(Cantidad_Global)
                        End If

                        RELLENAR_GRID()

                        MessageBox.Show(Me, "Producto eliminado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_FACTURAR_Click(sender As Object, e As EventArgs) Handles BTN_FACTURAR.Click
        Try
            If IND_MENSAJE_FACTURA = "S" Then
                Dim valor = MessageBox.Show(Me, "¿Seguro que desea facturar el documento?", "Facturacion", vbYesNo, MessageBoxIcon.Question)
                If valor = DialogResult.Yes Then
                    If GRID.Rows.Count <= 0 Then
                        MessageBox.Show(Me, "Debe ingresar al menos una linea del documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf String.IsNullOrEmpty(TXT_ENVIA.Text) And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "El cliente que envia la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf String.IsNullOrEmpty(TXT_RETIRA.Text) And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "El cliente que retira la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf String.IsNullOrEmpty(TXT_TELEFONO_RETIRA.Text) And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "El número de teléfono que retira la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf String.IsNullOrEmpty(TXT_DETALLE_ENVIO.Text) And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "No se ha ingresado una descripción de lo enviado en la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf Val(TXT_CANT_BULTOS.Text) <= 0 And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "La cantidad de bultos no puede ser menor o igual a cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf CMB_ORIGEN.SelectedIndex = -1 And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "No se ha elegido el origen de la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf CMB_DESTINO.SelectedIndex = -1 And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "No se ha elegido el destino de la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf FMC(TXT_VALOR.Text) < 0 And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "El valor del producto no puede ser menor a 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf CMB_DESTINO.SelectedIndex = CMB_ORIGEN.SelectedIndex And IND_ENCOMIENDA = "S" Then
                        MessageBox.Show(Me, "La direcciones de origen y destino deben ser distintas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Dim Validacion = ValidaProductosTemporal()
                        If Validacion = "" Then
                            Dim Pantalla As New FacturaCambio(FMC(TXT_T.Text))
                            AddHandler Pantalla.FormClosed, AddressOf Accion_Facturar
                            Pantalla.ShowDialog()
                        Else
                            MessageBox.Show(Me, Validacion, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            Else
                If GRID.Rows.Count <= 0 Then
                    MessageBox.Show(Me, "Debe ingresar al menos una linea del documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf String.IsNullOrEmpty(TXT_ENVIA.Text) And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "El cliente que envia la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf String.IsNullOrEmpty(TXT_RETIRA.Text) And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "El cliente que retira la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf String.IsNullOrEmpty(TXT_TELEFONO_RETIRA.Text) And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "El número de teléfono que retira la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf String.IsNullOrEmpty(TXT_DETALLE_ENVIO.Text) And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "No se ha ingresado una descripción de lo enviado en la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Val(TXT_CANT_BULTOS.Text) <= 0 And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "La cantidad de bultos no puede ser menor o igual a cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf CMB_ORIGEN.SelectedIndex = -1 And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "No se ha elegido el origen de la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf CMB_DESTINO.SelectedIndex = -1 And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "No se ha elegido el destino de la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf FMC(TXT_VALOR.Text) < 0 And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "El valor del producto no puede ser menor a 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf CMB_DESTINO.SelectedIndex = CMB_ORIGEN.SelectedIndex And IND_ENCOMIENDA = "S" Then
                    MessageBox.Show(Me, "La direcciones de origen y destino deben ser distintas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Dim Validacion = ValidaProductosTemporal()
                    If Validacion = "" Then
                        Dim Pantalla As New FacturaCambio(FMC(TXT_T.Text))
                        AddHandler Pantalla.FormClosed, AddressOf Accion_Facturar
                        Pantalla.ShowDialog()
                    Else
                        MessageBox.Show(Me, Validacion, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ValidaProductosTemporal() As String
        Try
            Dim respuesta As String = ""
            Dim SQL = "	SELECT TMP.COD_PROD																						"
            SQL &= Chr(13) & "	FROM DOCUMENTO_DET_TMP AS TMP																						"
            SQL &= Chr(13) & "	LEFT JOIN PRODUCTO AS PROD																						"
            SQL &= Chr(13) & "		 ON PROD.COD_CIA = TMP.COD_CIA																					"
            SQL &= Chr(13) & "		 AND PROD.COD_SUCUR = TMP.COD_SUCUR																					"
            SQL &= Chr(13) & "		 AND PROD.COD_PROD = TMP.COD_PROD																					"
            SQL &= Chr(13) & "	 WHERE TMP.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	 AND TMP.COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	 AND CODIGO = " & SCM(Codigo)
            SQL &= Chr(13) & "   AND PROD.COD_PROD IS NULL "
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Row In DS.Tables(0).Rows
                    respuesta &= "Error con código de producto: " & Row("COD_PROD") & vbNewLine
                Next
            End If

            Return respuesta
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub Accion_Facturar(ByVal sender As Form, ByVal e As EventArgs)
        Try
            Dim imp As New Impresion()
            If GRID.Rows.Count <= 0 Then
                MessageBox.Show(Me, "Debe ingresar al menos una linea del documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(TXT_ENVIA.Text) And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "El cliente que envia la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(TXT_RETIRA.Text) And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "El cliente que retira la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(TXT_TELEFONO_RETIRA.Text) And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "El número de teléfono que retira la encomienda no ha sido ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(TXT_DETALLE_ENVIO.Text) And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "No se ha ingresado una descripción de lo enviado en la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Val(TXT_CANT_BULTOS.Text) <= 0 And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "La cantidad de bultos no puede ser menor o igual a cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf CMB_ORIGEN.SelectedIndex = -1 And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "No se ha elegido el origen de la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf CMB_DESTINO.SelectedIndex = -1 And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "No se ha elegido el destino de la encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf FMC(TXT_VALOR.Text) < 0 And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "El valor del producto no puede ser menor a 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf CMB_DESTINO.SelectedIndex = CMB_ORIGEN.SelectedIndex And IND_ENCOMIENDA = "S" Then
                MessageBox.Show(Me, "La direcciones de origen y destino deben ser distintas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim Sql = "	USP_FACTURACION_TMP_A_REAL	"
                Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	,@TIPO_MOV  = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                Sql &= Chr(13) & "	,@CODIGO = 	" & SCM(Codigo)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If IND_RECIBO_AUTOMATICO = "S" And CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2) = "FC" Then
                    ProcesoIngresoReciboAutomatico(DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                Else
                    Dim pregunta = MessageBox.Show(Me, "¿Desea aplicar un recibo por la totalidad del documento?", Me.Text, vbYesNo, MessageBoxIcon.Question)

                    If pregunta = DialogResult.Yes Then
                        ProcesoIngresoReciboAutomatico(DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                    End If

                End If

                If IND_ENCOMIENDA = "S" Then
                    Dim NUMERO_GUIA = GENERA_NUMERO_GUIA(CMB_ORIGEN.SelectedItem().ToString.Substring(1, 3))
                    Sql = "INSERT INTO DOCUMENTO_GUIA(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,NUMERO_GUIA,CANT_BULTOS,ORIGEN,DESTINO,COD_USUARIO,FECHA_INC,TIPO_MERCADERIA,ENVIA,RETIRA,DESCRIPCION,VALOR_ENCOMIENDA,TELEFONO_RETIRA,COD_DERECHO)"
                    Sql &= Chr(13) & "SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & Val(DS.Tables(0).Rows(0).Item(0)) & "," & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(NUMERO_GUIA)
                    Sql &= Chr(13) & "," & Val(TXT_CANT_BULTOS.Text) & "," & SCM(CMB_ORIGEN.SelectedItem().ToString.Substring(1, 3)) & "," & SCM(CMB_DESTINO.SelectedItem().ToString.Substring(1, 3)) & "," & SCM(COD_USUARIO) & ", GETDATE() , " & SCM(IIf(CHK_MN.Checked, "N", "U"))
                    Sql &= Chr(13) & "," & SCM(TXT_ENVIA.Text) & "," & SCM(TXT_RETIRA.Text) & "," & SCM(TXT_DETALLE_ENVIO.Text) & "," & FMC(TXT_VALOR.Text) & "," & SCM(TXT_TELEFONO_RETIRA.Text) & "," & SCM(COD_SUCUR)
                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(Sql)
                    CONX.Coneccion_Cerrar()

                    Sql = "INSERT INTO DOCUMENTO_GUIA_UBICACION(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,NUMERO_GUIA,COD_UBICACION,COD_USUARIO,FECHA_INC)"
                    Sql &= Chr(13) & "SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & Val(DS.Tables(0).Rows(0).Item(0)) & "," & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(NUMERO_GUIA)
                    Sql &= Chr(13) & "," & SCM(CMB_ORIGEN.SelectedItem().ToString.Substring(1, 3)) & "," & SCM(COD_USUARIO) & ", GETDATE()"
                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(Sql)
                    CONX.Coneccion_Cerrar()
                End If

                If IND_ENCOMIENDA = "S" Then
                    imp.ImprimirEncomienda(COD_CIA, COD_SUCUR, DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                    imp.ImprimirEtiquetas(COD_CIA, COD_SUCUR, DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                    imp.Imprimir(COD_CIA, COD_SUCUR, DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2), IMG_COMPANIA)

                    Me.Close()
                    Padre.Refrescar()
                Else
                    Dim pregunta = MessageBox.Show(Me, "Documento ingresado correctamente, ¿desea imprimir el documento?", Me.Text, vbYesNo, MessageBoxIcon.Question)
                    If pregunta = DialogResult.Yes Then
                        imp.Imprimir(COD_CIA, COD_SUCUR, DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2), IMG_COMPANIA)
                        Me.Close()
                        Padre.Refrescar()
                    Else
                        Me.Close()
                        Padre.Refrescar()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SumatoriaIngreso()
        Try
            Dim sql As String = ""
            If Modo = CRF_Modos.Insertar Then
                sql = "	SELECT SUM(DESCUENTO) AS DESCUENTO, SUM(IMPUESTO) AS IMPUESTO, SUM(EXONERACION) AS EXONERACION , SUM(SUBTOTAL) AS SUBTOTAL, SUM(TOTAL) AS TOTAL "
                sql &= Chr(13) & "	FROM DOCUMENTO_DET_TMP"
                sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                sql &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
                sql &= Chr(13) & "	AND TIPO_MOV = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                sql &= Chr(13) & "	AND CODIGO = " & SCM(Codigo)
            Else
                If String.IsNullOrEmpty(Codigo) Then
                    sql = "	SELECT SUM(DESCUENTO) AS DESCUENTO, SUM(IMPUESTO) AS IMPUESTO, SUM(EXONERACION) AS EXONERACION, SUM(SUBTOTAL) AS SUBTOTAL, SUM(TOTAL) AS TOTAL "
                    sql &= Chr(13) & "	FROM DOCUMENTO_DET"
                    sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                    sql &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
                    sql &= Chr(13) & "	AND TIPO_MOV = " & SCM(Tipo_Mov)
                    sql &= Chr(13) & "	AND NUMERO_DOC = " & Val(Numero_Doc)
                Else
                    sql = "	SELECT SUM(DESCUENTO) AS DESCUENTO, SUM(IMPUESTO) AS IMPUESTO, SUM(EXONERACION) AS EXONERACION, SUM(SUBTOTAL) AS SUBTOTAL, SUM(TOTAL) AS TOTAL "
                    sql &= Chr(13) & "	FROM DOCUMENTO_DET_TMP"
                    sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                    sql &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
                    sql &= Chr(13) & "	AND TIPO_MOV = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                    sql &= Chr(13) & "	AND CODIGO = " & SCM(Codigo)
                End If
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                TXT_S.Text = FMCP(DS.Tables(0).Rows(0).Item("SUBTOTAL"))
                TXT_I.Text = FMCP(DS.Tables(0).Rows(0).Item("IMPUESTO"))
                TXT_D.Text = FMCP(DS.Tables(0).Rows(0).Item("DESCUENTO"))
                TXT_E.Text = FMCP(DS.Tables(0).Rows(0).Item("EXONERACION"))
                TXT_T.Text = FMCP(DS.Tables(0).Rows(0).Item("TOTAL"))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_PRECIO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_PRECIO.SelectedIndexChanged
        Try
            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                RellenaProducto("", "", "")
                CalculoTotales()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Public Sub RellenaUbicaciones(ByVal Estante As String, ByVal Fila As String, ByVal Columna As String, ByVal Cod_Prod As String)
        Proceso(Cod_Prod, Estante, Fila, Columna)
    End Sub

    Private Sub TXT_CODIGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CODIGO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Busca_Producto(True, False)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Function GENERA_NUMERO_GUIA(ByVal Origen As String) As String
        Try
            Dim NUM_GUIA As String = ""

            Dim Sql = "	SELECT ISNULL(MAX(CONVERT(INT, SUBSTRING(NUMERO_GUIA,4,LEN(NUMERO_GUIA) - 3))),0) + 1 AS GUIA "
            Sql &= Chr(13) & "	FROM DOCUMENTO_GUIA	"
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "  AND SUBSTRING(NUMERO_GUIA, 1, 3) = " & SCM(Origen)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                NUM_GUIA = Origen & RellenaEspacioIzquierda(10, "0", DS.Tables(0).Rows(0).Item("GUIA"))
            End If

            Return NUM_GUIA
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub CARGAR_RUTAS()
        Try
            If IND_ENCOMIENDA = "S" Then
                CMB_ORIGEN.DataSource = Nothing
                CMB_DESTINO.DataSource = Nothing

                Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
                Dim LISTA_REF_DES As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

                Dim SQL As String = "SELECT COD_UBICACION AS CODIGO, DESC_UBICACION AS NOMBRE"
                SQL &= Chr(13) & " FROM GUIA_UBICACION"
                SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & " AND ESTADO = 'A'"
                SQL &= Chr(13) & " AND IND_TIPO = 'P'"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each Row In DS.Tables(0).Rows
                        LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString.ToUpper & " - " & Row("NOMBRE").ToString.ToUpper))
                        LISTA_REF_DES.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString.ToUpper & " - " & Row("NOMBRE").ToString.ToUpper))
                    Next

                    CMB_ORIGEN.ValueMember = "Key"
                    CMB_ORIGEN.DisplayMember = "Value"
                    CMB_ORIGEN.DataSource = LISTA_REF
                    CMB_ORIGEN.SelectedIndex = -1

                    CMB_DESTINO.ValueMember = "Key"
                    CMB_DESTINO.DisplayMember = "Value"
                    CMB_DESTINO.DataSource = LISTA_REF_DES

                    CMB_DESTINO.SelectedIndex = -1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SETEO_ENCOMIENDA()
        Try
            If IND_ENCOMIENDA = "S" Then
                Dim SQL As String = "SELECT ORIGEN, DESTINO, CANT_BULTOS, TIPO_MERCADERIA, ENVIA, RETIRA, DESCRIPCION, VALOR_ENCOMIENDA, TELEFONO_RETIRA "
                SQL &= Chr(13) & "	FROM DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                'SQL &= Chr(13) & "	AND COD_DERECHO = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(Numero_Doc)
                SQL &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each Row In DS.Tables(0).Rows
                        CMB_ORIGEN.SelectedValue = Row("ORIGEN")
                        CMB_DESTINO.SelectedValue = Row("DESTINO")
                        TXT_CANT_BULTOS.Text = Val(Row("CANT_BULTOS"))
                        TXT_TELEFONO_RETIRA.Text = Row("TELEFONO_RETIRA")
                        TXT_ENVIA.Text = Row("ENVIA")
                        TXT_RETIRA.Text = Row("RETIRA")
                        TXT_DETALLE_ENVIO.Text = Row("DESCRIPCION")
                        TXT_VALOR.Text = FMC(Row("VALOR_ENCOMIENDA"))
                        CHK_MU.Checked = IIf(Row("TIPO_MERCADERIA") = "N", False, True)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaExoneracion()
        Try
            Dim SQL = "	SELECT PORCENTAJE"
            SQL &= Chr(13) & "	FROM CLIENTE_EXONERACION"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " And CEDULA = " & SCM(Cliente.VALOR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                TXT_EXONERACION.Text = Val(DS.Tables(0).Rows(0).Item("PORCENTAJE"))
            Else
                TXT_EXONERACION.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ProcesoIngresoReciboAutomatico(ByVal Numero_Doc As Integer, ByVal Tipo_Mov As String)
        Try
            Dim Codigo_Recibo = GenerarCodigo()

            Dim Sql = " INSERT INTO DOCUMENTO_AFEC_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,NUMERO_DOC,TIPO_MOV,FECHA,MONTO_DOC,MONTO_AFEC)"
            Sql &= Chr(13) & " SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo_Recibo) & "," & Val(Numero_Doc) & "," & SCM(Tipo_Mov) & "," & SCM(YMD(DTPFECHA.Value)) & "," & FMC(TXT_T.Text) & "," & FMC(TXT_T.Text)
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()


            Sql = "	INSERT INTO DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION,TIPO_NOTA)"
            Sql &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo_Recibo) & "," & SCM("RB") & "," & SCM(Cliente.VALOR)
            Sql &= Chr(13) & "," & SCM(YMD(DTPFECHA.Value)) & ", GETDATE()," & SCM(COD_USUARIO) & "," & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
            Sql &= Chr(13) & "," & FMC(TXT_TIPO_CAMBIO.Text) & ", 0," & SCM(CMB_FORMAPAGO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM("Recibo automático aplicado al documento: " & Val(Numero_Doc)) & ", NULL"

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            Sql = "	USP_FACTURACION_TMP_A_REAL	"
            Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@TIPO_MOV  = " & SCM("RB")
            Sql &= Chr(13) & "	,@CODIGO = 	" & SCM(Codigo_Recibo)
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            Sql = " DELETE FROM DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = " & SCM(Codigo_Recibo)
            Dim SQL2 = " DELETE FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP WHERE CODIGO = " & SCM(Codigo_Recibo)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.EJECUTE(SQL2)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CHK_MN_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_MN.CheckedChanged
        CHK_MU.Checked = IIf(CHK_MN.Checked, False, True)
    End Sub

    Private Sub CHK_MU_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_MU.CheckedChanged
        CHK_MN.Checked = IIf(CHK_MU.Checked, False, True)
    End Sub

    Private Sub BTN_IMPRIMIR_Click(sender As Object, e As EventArgs) Handles BTN_IMPRIMIR.Click
        Try
            Dim imp As New Impresion()
            imp.ImprimirEtiquetas(COD_CIA, COD_SUCUR, Val(TXT_NUMERO.Text), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IND_ENCOMIENDA = "S" Then
            BTN_IMPRIMIR.Enabled = (Me.Modo = CRF_Modos.Modificar And TieneDerecho("DRIMPETI"))
            BTN_MANIFIESTO.Enabled = (Me.Modo = CRF_Modos.Modificar And TieneDerecho("DRIMPETI"))
        End If
    End Sub

    Private Sub TXT_PRECIO_Leave(sender As Object, e As EventArgs) Handles TXT_PRECIO.Leave
        CalculoTotales()
    End Sub

    Private Sub BTN_MANIFIESTO_Click(sender As Object, e As EventArgs) Handles BTN_MANIFIESTO.Click
        Try
            Dim imp As New Impresion()
            imp.ImprimirEncomienda(COD_CIA, COD_SUCUR, Val(TXT_NUMERO.Text), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class