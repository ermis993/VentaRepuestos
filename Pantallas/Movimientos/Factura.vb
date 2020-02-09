﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Factura

    Dim Modo As CRF_Modos
    Dim Codigo As String
    Dim Padre As Facturacion
    Dim Numero_Doc As Integer

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        EliminaTodoTemporal()
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Padre.Refrescar()
        Me.Close()
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

    Sub New(ByVal Modo As CRF_Modos, ByVal Padre As Facturacion, Optional ByVal NUMERO_DOC As Integer = 0, Optional ByVal CODIGO As String = "")

        InitializeComponent()
        Me.Modo = Modo
        Me.Padre = Padre

        If Me.Modo = CRF_Modos.Insertar Then
            TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)
            Me.Codigo = GenerarCodigo()
            BloqueaControles()
            CMB_DOCUMENTO.SelectedIndex = 0
            CMB_FORMAPAGO.SelectedIndex = 0
            CMB_MONEDA.SelectedIndex = 0
        ElseIf Me.Modo = CRF_Modos.Modificar Then

            Me.Codigo = NUMERO_DOC
            Me.Numero_Doc = Val(NUMERO_DOC)
            BloqueaControles()

            If Me.Numero_Doc > 0 Then
                TXT_NUMERO.Text = Me.Numero_Doc
            End If

        End If

    End Sub

    Private Sub RellenaDatos()
        Try
            If String.IsNullOrEmpty(Codigo) Then

            Else

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
    End Sub

    Private Sub CalculoTotales()
        Try
            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then

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
            Dim Sql = "	SELECT COD_UNIDAD, PRECIO, POR_IMPUESTO	"
            Sql &= Chr(13) & "	FROM PRODUCTO "
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	AND COD_PROD = " & SCM(TXT_CODIGO.Text)
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

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IngresarDetalle()
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
                SQL &= Chr(13) & "	,@COD_PROD = " & SCM(TXT_CODIGO.Text)
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
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            GRID.DataSource = Nothing
            Dim SQL = "	SELECT TMP.LINEA AS 'Linea', PROD.COD_PROD AS 'Código', PROD.DESCRIPCION as 'Descripción', TMP.CANTIDAD AS 'Cantidad', TMP.PRECIO AS 'P/U'	"
            SQL &= Chr(13) & "	, TMP.POR_DESCUENTO AS '% Descuento', TMP.IMPUESTO AS 'Impuesto', TMP.TOTAL AS 'Total'	"
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
                TXT_CANTIDAD.Text = seleccionado.Cells(3).Value.ToString
                TXT_DESCUENTO.Text = seleccionado.Cells(5).Value.ToString
                TXT_CODIGO.Text = seleccionado.Cells(1).Value.ToString
                RellenaProducto()
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
        End If
    End Sub

    Private Sub TXT_DESCUENTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_DESCUENTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            BTN_CALCULAR.Focus()
        End If
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Cerrar()
    End Sub

    Private Sub TXT_CODIGO_TextChanged(sender As Object, e As EventArgs) Handles TXT_CODIGO.TextChanged
        Busca_Producto()
    End Sub

    Private Sub Busca_Producto()
        Try
            LVResultados.Clear()
            LVResultados.Columns.Add("", 318)

            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                Dim Sql = "	SELECT COD_PROD,  DESCRIPCION "
                Sql &= Chr(13) & "	FROM PRODUCTO	"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND (DESCRIPCION LIKE " & SCM("%" + TXT_CODIGO.Text + "%") & " Or COD_PROD = " & SCM(TXT_CODIGO.Text) & " Or COD_BARRA = " & SCM(TXT_CODIGO.Text) & ")"

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
        Dim a = LVResultados.SelectedItems(0).Name

        If Not IsNothing(a) Then
            TXT_CODIGO.Text = a
            RellenaProducto()
            TXT_CANTIDAD.Focus()
        End If

    End Sub
End Class