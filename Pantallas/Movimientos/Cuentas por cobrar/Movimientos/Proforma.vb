Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Proforma
    Dim Modo As CRF_Modos
    Dim Codigo As String = ""
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
            Dim Sql = "	DELETE FROM PROFORMA_ENC_TMP WHERE CODIGO =  " & SCM(Codigo)
            Sql &= Chr(13) & "	DELETE FROM PROFORMA_DET_TMP WHERE CODIGO =  " & SCM(Codigo)
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
            BloqueaControles()
            CMB_DOCUMENTO.SelectedIndex = 0
            CMB_FORMAPAGO.SelectedIndex = 0
            CMB_MONEDA.SelectedIndex = 0
            BTN_FACTURAR.Enabled = False
        ElseIf Me.Modo = CRF_Modos.Modificar Then
            Me.Numero_Doc = Val(NUMERO_DOC)
            TXT_NUMERO.Text = Me.Numero_Doc
            BloqueaControles()
            RellenaDatos()
            Me.Codigo = IIf(CODIGO <> "", CODIGO, GenerarCodigo())
            RellenaTemporales()

            BTN_ACEPTAR.Enabled = True
            BTN_FACTURAR.Enabled = True
            BTN_INGRESAR.Enabled = True
            RELLENAR_GRID()
        End If

        CMB_PRECIO.SelectedIndex = 0

    End Sub

    Private Sub RellenaDatos()
        Try
            Dim Sql As String = ""
            If String.IsNullOrEmpty(Codigo) Then
                Sql = "	SELECT CEDULA, TIPO_MOV, FECHA, COD_MONEDA, TIPO_CAMBIO, PLAZO, FORMA_PAGO, ISNULL(DESCRIPCION, '') AS DESCRIPCION"
                Sql &= Chr(13) & "	FROM PROFORMA_ENC"
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
                Sql &= Chr(13) & "	FROM PROFORMA_ENC_TMP"
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
            Else
                If FMC(TXT_TOTAL.Text) > 0 Then
                    Dim SQL = "	EXECUTE USP_MANT_PROFORMA_TMP "
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
                    SQL &= Chr(13) & "	,@MODO =" & Val(Modo)

                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(SQL)
                    CONX.Coneccion_Cerrar()

                    LimpiarControles()

                    RELLENAR_GRID()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_INGRESAR_Click(sender As Object, e As EventArgs) Handles BTN_INGRESAR.Click
        IngresarDetalle()
    End Sub

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
                SQL &= Chr(13) & "	FROM PROFORMA_DET_TMP AS TMP	"
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
                SQL &= Chr(13) & "	FROM PROFORMA_DET AS TMP	"
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
        Try
            If Modo = CRF_Modos.Modificar Then
                Dim Sql = "	UPDATE PROFORMA_ENC_TMP	"
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

            Accion_Facturar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        Cerrar()
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

        Dim Saldo_Producto As Decimal = Saldo_Actual(codigo)
        Dim Minimo_Stock As Decimal = Min_Stock(codigo)

        If ((IND_VENTAS_NEGATIVAS = "S" And Saldo_Producto <= 0.0) Or Saldo_Producto > 0.0) Then

            If IND_MIN_STOCK = "S" And (Saldo_Producto <= Minimo_Stock) Then
                MessageBox.Show(Me, "El producto está llegando a su mínimo actualmente el saldo es: " & FMC(Saldo_Producto), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            RellenaProducto(estante, fila, columna)
            RellenaExoneracion()
            Busca_Producto()
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

    Private Sub GRID_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles GRID.CellClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 11 Then
                    Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                    Dim valor = MessageBox.Show(Me, "¿Seguro que desea eliminar la linea :" + seleccionado.Cells(0).Value.ToString + "?", "Eliminar linea", vbYesNo, MessageBoxIcon.Question)

                    If valor = DialogResult.Yes Then

                        Dim SQL = "	DELETE FROM PROFORMA_DET_TMP	"
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

    Private Sub BTN_FACTURAR_Click(sender As Object, e As EventArgs) Handles BTN_FACTURAR.Click
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Accion_Facturar()
        Try
            If GRID.Rows.Count <= 0 Then
                MessageBox.Show(Me, "Debe ingresar al menos una linea del documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim Sql = "	USP_PROFORMA_TMP_A_REAL	"
                Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	,@TIPO_MOV  = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                Sql &= Chr(13) & "	,@CODIGO = 	" & SCM(Codigo)
                Sql &= Chr(13) & "	,@NUMERO_DOC = 	" & Val(TXT_NUMERO.Text)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                Me.Close()
                Padre.Refrescar()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SumatoriaIngreso()
        Try
            Dim sql As String = ""
            If Modo = CRF_Modos.Insertar Then
                sql = "	SELECT SUM(DESCUENTO) AS DESCUENTO, SUM(IMPUESTO) AS IMPUESTO, SUM(EXONERACION) AS EXONERACION , SUM(SUBTOTAL) AS SUBTOTAL, SUM(TOTAL) AS TOTAL "
                sql &= Chr(13) & "	FROM PROFORMA_DET_TMP"
                sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                sql &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
                sql &= Chr(13) & "	AND TIPO_MOV = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
                sql &= Chr(13) & "	AND CODIGO = " & SCM(Codigo)
            Else
                If String.IsNullOrEmpty(Codigo) Then
                    sql = "	SELECT SUM(DESCUENTO) AS DESCUENTO, SUM(IMPUESTO) AS IMPUESTO, SUM(EXONERACION) AS EXONERACION, SUM(SUBTOTAL) AS SUBTOTAL, SUM(TOTAL) AS TOTAL "
                    sql &= Chr(13) & "	FROM PROFORMA_DET"
                    sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                    sql &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
                    sql &= Chr(13) & "	AND TIPO_MOV = " & SCM(Tipo_Mov)
                    sql &= Chr(13) & "	AND NUMERO_DOC = " & Val(Numero_Doc)
                Else
                    sql = "	SELECT SUM(DESCUENTO) AS DESCUENTO, SUM(IMPUESTO) AS IMPUESTO, SUM(EXONERACION) AS EXONERACION, SUM(SUBTOTAL) AS SUBTOTAL, SUM(TOTAL) AS TOTAL "
                    sql &= Chr(13) & "	FROM PROFORMA_DET_TMP"
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
            Busca_Producto()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
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

    Private Sub TXT_PRECIO_Leave(sender As Object, e As EventArgs) Handles TXT_PRECIO.Leave
        CalculoTotales()
    End Sub

    Private Sub RellenaTemporales()
        Try
            Dim SQL = "INSERT INTO PROFORMA_ENC_TMP"
            SQL &= Chr(13) & " SELECT COD_CIA,COD_SUCUR," & SCM(Me.Codigo) & ",TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION,TIPO_NOTA																						"
            SQL &= Chr(13) & "	FROM PROFORMA_ENC "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(TXT_NUMERO.Text)
            SQL &= Chr(13) & "	AND TIPO_MOV = 	" & SCM(IIf(CMB_DOCUMENTO.SelectedIndex = 0, "FC", "FA"))
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            SQL = "INSERT INTO PROFORMA_DET_TMP "
            SQL &= Chr(13) & "	SELECT COD_CIA,COD_SUCUR," & SCM(Me.Codigo) & ",TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO	"
            SQL &= Chr(13) & "	,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION	"
            SQL &= Chr(13) & "	FROM PROFORMA_DET "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(TXT_NUMERO.Text)
            SQL &= Chr(13) & "	AND TIPO_MOV = 	" & SCM(IIf(CMB_DOCUMENTO.SelectedIndex = 0, "FC", "FA"))
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class