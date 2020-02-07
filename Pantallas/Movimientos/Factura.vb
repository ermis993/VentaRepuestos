Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Factura

    Dim Modo As CRF_Modos
    Dim Codigo As String

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Me.Close()
    End Sub

    Sub New(ByVal Modo As CRF_Modos)

        InitializeComponent()
        Me.Modo = Modo
        TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)

        If Me.Modo = CRF_Modos.Insertar Then
            Codigo = GenerarCodigo()
            BloqueaControles()
            CMB_DOCUMENTO.SelectedIndex = 0
            CMB_FORMAPAGO.SelectedIndex = 0
            CMB_MONEDA.SelectedIndex = 0
        End If

    End Sub

    Private Function GenerarCodigo() As String
        Try
        Dim CARACTERES As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim RND As New Random
        Dim Codigo As String = ""
        For i As Integer = 1 To 20
            Codigo += CARACTERES.ToCharArray(RND.Next(0, CARACTERES.Length), 1)
        Next    
    return Codigo
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = False
            TXT_TIPO_CAMBIO.Enabled = False
            DTPFECHA.Enabled = False
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

    Private Sub Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cliente.TABLA_BUSCAR = "CLIENTE"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE"
        Cliente.refrescar()

        Producto.TABLA_BUSCAR = "PRODUCTO"
        Producto.CODIGO = "COD_PROD"
        Producto.DESCRIPCION = "DESCRIPCION"
        Producto.refrescar()
    End Sub

    Private Sub CalculoTotales()
        Try
            If String.IsNullOrEmpty(Producto.VALOR) Then
                MessageBox.Show("¡Debe seleccionar el proveedor!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Producto.Select()
            Else
                Dim Cantidad As Double
                Dim Precio_Unitario As Double
                Dim Descuento As Double
                Dim Descuento_Total As Double
                Dim Impuesto As Double
                Dim Impuesto_Total As Double
                Dim Subtotal As Double
                Dim Total As Double

                Cantidad = FMC(TXT_CANTIDAD.Text)
                Precio_Unitario = FMC(TXT_PRECIO.Text)
                Descuento = FMC(TXT_DESCUENTO.Text)
                Impuesto = FMC(TXT_IMPUESTO.Text)

                Descuento_Total = ((Precio_Unitario * Cantidad) * Descuento) / 100
                Impuesto_Total = (((Precio_Unitario * Cantidad) - Descuento_Total) * Impuesto) / 100
                Subtotal = ((Precio_Unitario * Cantidad) - Descuento_Total)
                Total = Subtotal + Impuesto_Total

                TXT_DESCUENTOTOTAL.Text = FMCP(Descuento_Total)
                TXT_IMPUESTOTOTAL.Text = FMCP(Impuesto_Total)
                TXT_SUBTOTAL.Text = FMCP(Subtotal)
                TXT_TOTAL.Text = FMCP(Total)
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

    Private Sub RellenaProducto()
        Try
            If Not Producto.VALOR Is Nothing Then
                Dim Sql = "	SELECT COD_UNIDAD, PRECIO, POR_IMPUESTO	"
                Sql &= Chr(13) & "	FROM PRODUCTO "
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND COD_PROD = " & SCM(Producto.VALOR)
                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    TXT_UNIDAD.Text = DS.Tables(0).Rows(0).Item("COD_UNIDAD")
                    TXT_PRECIO.Text = DS.Tables(0).Rows(0).Item("PRECIO")
                    TXT_IMPUESTO.Text = DS.Tables(0).Rows(0).Item("POR_IMPUESTO")
                Else
                    TXT_UNIDAD.Text = ""
                    TXT_PRECIO.Text = ""
                    TXT_IMPUESTO.Text = ""
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Producto_Leave(sender As Object, e As EventArgs) Handles Producto.Leave
        RellenaProducto()
    End Sub

    Private Sub BTN_INGRESAR_Click(sender As Object, e As EventArgs) Handles BTN_INGRESAR.Click
        Try
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
                SQL &= Chr(13) & "	,@COD_PROD = " & SCM(Producto.VALOR)
                SQL &= Chr(13) & "	,@COD_UNIDAD = " & SCM(TXT_UNIDAD.Text)
                SQL &= Chr(13) & "	,@CANTIDAD = " & FMC(TXT_CANTIDAD.Text)
                SQL &= Chr(13) & "	,@PRECIO = " & FMC(TXT_PRECIO.Text)
                SQL &= Chr(13) & "	,@POR_DESCUENTO = " & Val(TXT_DESCUENTO.Text)
                SQL &= Chr(13) & "	,@DESCUENTO = " & FMC(TXT_DESCUENTOTOTAL.Text)
                SQL &= Chr(13) & "	,@POR_IMPUESTO = " & Val(TXT_IMPUESTO.Text)
                SQL &= Chr(13) & "	,@IMPUESTO = " & FMC(TXT_IMPUESTOTOTAL.Text)
                SQL &= Chr(13) & "	,@SUBTOTAL = " & FMC(TXT_SUBTOTAL.Text)
                SQL &= Chr(13) & "	,@TOTAL = " & FMC(TXT_TOTAL.Text)
                SQL &= Chr(13) & "	,@MODO =" & Val(Modo)

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                LimpiarControles()

                RELLENAR_GRID()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        TXT_CANTIDAD.Text = ""
        TXT_DESCUENTO.Text = ""
        Producto.VALOR = ""
        Producto.VALOR_DESCRIPCION = ""
        TXT_DESCUENTOTOTAL.Text = ""
        TXT_IMPUESTOTOTAL.Text = ""
        TXT_SUBTOTAL.Text = ""
        TXT_TOTAL.Text = ""
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            GRID.DataSource = Nothing
            Dim SQL = "	SELECT TMP.LINEA AS 'Linea', PROD.COD_PROD AS 'Código', PROD.DESCRIPCION as 'Descripción', TMP.CANTIDAD AS 'Cantidad', TMP.PRECIO AS 'P/U'	"
            SQL &= Chr(13) & "	, TMP.DESCUENTO AS 'Descuento', TMP.IMPUESTO AS 'Impuesto', TMP.SUBTOTAL AS 'Subtotal', TMP.TOTAL AS 'Total'	"
            SQL &= Chr(13) & "	FROM DOCUMENTO_DET_TMP AS TMP	"
            SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD		"
            SQL &= Chr(13) & "		ON PROD.COD_CIA = TMP.COD_CIA	"
            SQL &= Chr(13) & " And PROD.COD_SUCUR = TMP.COD_SUCUR "
            SQL &= Chr(13) & "		AND PROD.COD_PROD = TMP.COD_PROD	"
            SQL &= Chr(13) & "	WHERE TMP.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND TMP.COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & " And TMP.CODIGO =  " & SCM(Codigo)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRID.DataSource = DS.Tables(0)
            End If

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
                Producto.VALOR = seleccionado.Cells(1).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GRID.CellMouseDoubleClick

    End Sub

    Private Sub Producto_KeyDown(sender As Object, e As KeyEventArgs) Handles Producto.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_CANTIDAD.Focus()
        End If
    End Sub

    Private Sub TXT_CANTIDAD_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CANTIDAD.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_DESCUENTO.Focus()
        End If
    End Sub

    Private Sub TXT_DESCUENTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_DESCUENTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            BTN_CALCULAR.Focus()
        End If
    End Sub

    Private Sub BTN_CALCULAR_KeyDown(sender As Object, e As KeyEventArgs) Handles BTN_CALCULAR.KeyDown
        If e.KeyCode = Keys.Enter Then
            CalculoTotales()
            BTN_INGRESAR.Focus()
        End If
    End Sub
End Class