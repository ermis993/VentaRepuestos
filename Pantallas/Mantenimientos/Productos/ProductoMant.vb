Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class ProductoMant

    Dim MODO As CRF_Modos
    Dim PADRE As Object
    Dim COD_PROD As String

    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Object, Optional COD_PROD As String = "", Optional DESCRIPCION As String = "", Optional TARIFA As Integer = 0, Optional PRECIO_COSTO As Decimal = 0.0, Optional CEDULA As String = "")
        InitializeComponent()

        Me.MODO = MODO
        Me.COD_PROD = COD_PROD
        Me.PADRE = PADRE

        Buscador.TABLA_BUSCAR = "Proveedor"
        Buscador.CODIGO = "CEDULA"
        Buscador.OTROS_CAMP0S = COD_SUCUR
        Buscador.DESCRIPCION = "NOMBRE"
        Buscador.PANTALLA = New Proveedor(CRF_Modos.Seleccionar, Buscador)
        Buscador.refrescar()

        Buscador_Familia.TABLA_BUSCAR = "FAMILIA"
        Buscador_Familia.CODIGO = "CODIGO"
        Buscador_Familia.DESCRIPCION = "DESCRIPCION"
        Buscador_Familia.PANTALLA = New Familia(CRF_Modos.Seleccionar, Buscador_Familia)
        Buscador_Familia.FILTRAR_POR_COMPANIA = False
        Buscador_Familia.CAMPO_FILTRAR = "ESTADO"
        Buscador_Familia.OTROS_CAMP0S = "A"
        Buscador_Familia.refrescar()

        CARGAR_UNIDAD_MEDIDA()
        CARGAR_IMPUESTO()

        If Me.MODO = CRF_Modos.Modificar Then
            TXT_CODIGO.ReadOnly = True
            LEER()
            TXT_COD_BARRA.Select()
        ElseIf Me.MODO = CRF_Modos.Insertar Then
            TXT_CODIGO.Select()
        Else
            TXT_CODIGO.Text = COD_PROD
            TXT_DESC.Text = DESCRIPCION
            CMB_UNIDADES.SelectedValue = "Unid"
            CMB_IMPUESTO_DGTD.SelectedValue = IIf(TARIFA = 13, "017", "010")
            TXT_COSTO.Text = FMC(PRECIO_COSTO)
            Buscador.VALOR = CEDULA
            Buscador.ACTUALIZAR_COMBO()
        End If

    End Sub


    Private Sub LEER()
        Try
            Dim SQL As String = "EXEC USP_MANT_PRODUCTO"
            SQL &= Chr(13) & " @COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & ",@COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & ",@COD_PROD = " & SCM(COD_PROD)
            SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Seleccionar)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows

                    TXT_CODIGO.Text = COD_PROD
                    TXT_COD_BARRA.Text = ITEM("COD_BARRA")
                    Buscador.VALOR = ITEM("CEDULA")
                    Buscador.ACTUALIZAR_COMBO()
                    TXT_DESC.Text = ITEM("DESCRIPCION")
                    CMB_UNIDADES.SelectedValue = ITEM("COD_UNIDAD")
                    CMB_IMPUESTO_DGTD.SelectedValue = ITEM("COD_IMPUESTO_DGTD")
                    TXT_PRECIO.Text = ITEM("PRECIO")
                    TXT_COSTO.Text = ITEM("COSTO")
                    TXT_MINIMO.Text = ITEM("MINIMO")
                    TXT_PRECIO_2.Text = ITEM("PRECIO_2")
                    TXT_PRECIO_3.Text = ITEM("PRECIO_3")

                    If Trim(ITEM("ESTADO")).Equals("A") Then
                        RB_ACTIVO.Checked = True
                    Else
                        RB_INACTIVO.Checked = True
                    End If

                    Buscador_Familia.VALOR = VALNULL(ITEM("COD_FAMILIA"))
                    Buscador_Familia.ACTUALIZAR_COMBO()
                    TXT_OBSERVACION.Text = VALNULL(ITEM("OBSERVACION"))
                    TXT_COD_CABYS.Text = VALNULL(ITEM("COD_CABYS"))
                    CHK_MODIFICABLE.Checked = IIf(VALNULL(ITEM("IND_PRECIO_MODIFICABLE")) = "S", True, False)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Me.Close()
        Me.PADRE.RELLENAR_GRID()
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                MessageBox.Show("¡Debe digitar un código de producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CODIGO.Select()
            ElseIf String.IsNullOrEmpty(Buscador.VALOR) Then
                MessageBox.Show("¡Debe seleccionar el proveedor!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Buscador.Select()
            ElseIf String.IsNullOrEmpty(TXT_DESC.Text) Then
                MessageBox.Show("¡Debe digitar la descripción del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_DESC.Select()
            ElseIf String.IsNullOrEmpty(TXT_COSTO.Text) Then
                MessageBox.Show("¡Debe digitar el costo del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_COSTO.Select()
            ElseIf String.IsNullOrEmpty(TXT_PRECIO.Text) Then
                MessageBox.Show("¡Debe digitar el precio del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_PRECIO.Select()
            ElseIf String.IsNullOrEmpty(TXT_PRECIO_2.Text) Then
                MessageBox.Show("¡Debe digitar el precio 2 del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_PRECIO_2.Select()
            ElseIf String.IsNullOrEmpty(TXT_PRECIO_3.Text) Then
                MessageBox.Show("¡Debe digitar el precio 3 del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_PRECIO_3.Select()
            ElseIf FMC(TXT_COSTO.Text) > FMC(TXT_PRECIO.Text) Or FMC(TXT_COSTO.Text) > FMC(TXT_PRECIO_2.Text) Or FMC(TXT_COSTO.Text) > FMC(TXT_PRECIO_3.Text) Then
                MessageBox.Show("¡El precio costo es mayor a los precios ingresados, verifique el monto ingresado en los precios!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(TXT_ESTANTE.Text) And Me.MODO = CRF_Modos.Insertar Then
                MessageBox.Show("¡Debe digitar el estante en el que se cuentra el producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_ESTANTE.Select()
            ElseIf String.IsNullOrEmpty(TXT_FILA.Text) And Me.MODO = CRF_Modos.Insertar Then
                MessageBox.Show("¡Debe digitar la fila en la que se encuentra el producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_FILA.Select()
            ElseIf String.IsNullOrEmpty(TXT_COLUMNA.Text) And Me.MODO = CRF_Modos.Insertar Then
                MessageBox.Show("¡Debe digitar la columna en la que se encuentra el producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_COLUMNA.Select()
            ElseIf String.IsNullOrEmpty(TXT_MINIMO.Text) Then
                MessageBox.Show("¡Debe digitar la cantidad minima en stock del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_MINIMO.Select()
            Else

                Me.MODO = IIf(Me.MODO = CRF_Modos.Formula, CRF_Modos.Insertar, Me.MODO)

                Dim Sql = "EXEC	USP_MANT_PRODUCTO "
                Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	,@COD_PROD = " & SCM(TXT_CODIGO.Text)
                Sql &= Chr(13) & "	,@CEDULA = " & SCM(Buscador.VALOR)
                Sql &= Chr(13) & "	,@DESCRIPCION = " & SCM(TXT_DESC.Text)
                Sql &= Chr(13) & "	,@COD_UNIDAD = " & SCM(CMB_UNIDADES.SelectedValue)
                Sql &= Chr(13) & "	,@COSTO = " & FMC(TXT_COSTO.Text)
                Sql &= Chr(13) & "	,@POR_IMPUESTO = " & Val(TXT_IMPUESTO.Text)
                Sql &= Chr(13) & "	,@COD_IMPUESTO = " & SCM(CMB_IMPUESTO_DGTD.SelectedValue)
                Sql &= Chr(13) & "	,@PRECIO = " & FMC(TXT_PRECIO.Text)
                Sql &= Chr(13) & "	,@PRECIO_2 = " & FMC(TXT_PRECIO_2.Text)
                Sql &= Chr(13) & "	,@PRECIO_3 = " & FMC(TXT_PRECIO_3.Text)
                Sql &= Chr(13) & "	,@EXENTO = " & SCM(TXT_EXENTO.Text)
                Sql &= Chr(13) & "	,@ESTADO = " & SCM(IIf(RB_ACTIVO.Checked, "A", "I"))
                Sql &= Chr(13) & "	,@ESTANTE = " & SCM(TXT_ESTANTE.Text)
                Sql &= Chr(13) & "	,@FILA = " & SCM(TXT_FILA.Text)
                Sql &= Chr(13) & "	,@COLUMNA = " & SCM(TXT_COLUMNA.Text)
                Sql &= Chr(13) & "	,@MINIMO = " & FMC(TXT_MINIMO.Text)
                Sql &= Chr(13) & "	,@COD_BARRA = " & SCM(TXT_COD_BARRA.Text)
                Sql &= Chr(13) & "	,@COD_FAMILIA = " & SCM(Buscador_Familia.VALOR)
                Sql &= Chr(13) & "	,@OBSERVACION = " & SCM(TXT_OBSERVACION.Text)
                Sql &= Chr(13) & "	,@IND_PRECIO_MODIFICABLE = " & SCM(IIf(CHK_MODIFICABLE.Checked, "S", "N"))
                Sql &= Chr(13) & "  ,@COD_CABYS = " & SCM(TXT_COD_CABYS.Text)
                Sql &= Chr(13) & "	,@MODO = " & Val(Me.MODO)

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()

                If Me.MODO = CRF_Modos.Insertar Then
                    LIMPIAR_TODO()
                    Cerrar()
                    MessageBox.Show("¡Producto agregado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.Close()
                    MessageBox.Show("¡Producto modificado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CARGAR_UNIDAD_MEDIDA()
        Try
            CMB_UNIDADES.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = "SELECT COD_UNIDAD AS CODIGO, DESCRIPCION"
            SQL &= Chr(13) & " FROM UNIDAD_MEDIDA"
            SQL &= Chr(13) & " WHERE ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("DESCRIPCION").ToString.ToUpper))
                Next


                CMB_UNIDADES.ValueMember = "Key"
                CMB_UNIDADES.DisplayMember = "Value"
                CMB_UNIDADES.DataSource = LISTA_REF

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CARGAR_IMPUESTO()
        Try
            CMB_IMPUESTO_DGTD.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = "SELECT COD_IMPUESTO AS CODIGO, DESCRIPCION"
            SQL &= Chr(13) & " FROM IMPUESTO"
            SQL &= Chr(13) & " WHERE ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("DESCRIPCION").ToString.ToUpper))
                Next


                CMB_IMPUESTO_DGTD.ValueMember = "Key"
                CMB_IMPUESTO_DGTD.DisplayMember = "Value"
                CMB_IMPUESTO_DGTD.DataSource = LISTA_REF

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_IMPUESTO_DGTD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_IMPUESTO_DGTD.SelectedIndexChanged
        Try
            If Not CMB_IMPUESTO_DGTD.DataSource Is Nothing Then
                CARGAR_PORCENTAJE_IMPUESTO()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CARGAR_PORCENTAJE_IMPUESTO()
        Try
            Dim SQL As String = "SELECT PORCENTAJE"
            SQL &= Chr(13) & " FROM IMPUESTO"
            SQL &= Chr(13) & " WHERE ESTADO = 'A'"
            SQL &= Chr(13) & " AND COD_IMPUESTO = " & SCM(CMB_IMPUESTO_DGTD.SelectedValue)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                TXT_IMPUESTO.Text = Val(DS.Tables(0).Rows(0).Item(0))

                If Val(DS.Tables(0).Rows(0).Item(0)) > 0 Then
                    TXT_EXENTO.Text = "N"
                Else
                    TXT_EXENTO.Text = "S"
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LIMPIAR_TODO()
        TXT_CODIGO.Text = ""
        TXT_COD_CABYS.Text = ""
        TXT_COD_BARRA.Text = ""
        TXT_COLUMNA.Text = ""
        TXT_ESTANTE.Text = ""
        TXT_FILA.Text = ""
        TXT_COSTO.Text = ""
        TXT_PRECIO.Text = ""
        TXT_PRECIO_2.Text = ""
        TXT_PRECIO_3.Text = ""
        TXT_DESC.Text = ""
        TXT_MINIMO.Text = ""
        RB_ACTIVO.Checked = True
    End Sub

    Private Sub TXT_COSTO_Leave(sender As Object, e As EventArgs) Handles TXT_COSTO.Leave
        Try
            Dim Porcentaje_Venta As Decimal = 0.0

            Dim valor = MessageBox.Show(Me, "¿Desea aplicar la fórmula automática para el cálculo de precios?", "Consulta fórmula", vbYesNo, MessageBoxIcon.Question)
            If valor = DialogResult.Yes Then
                If String.IsNullOrEmpty(Buscador.VALOR) Then
                    MessageBox.Show("¡Para el cálculo de la fórmula es necesario seleccionar el proveedor!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf String.IsNullOrEmpty(TXT_COSTO.Text) Or FMC(TXT_COSTO.Text) <= 0 Then
                    MessageBox.Show("¡Para el cálculo de la fórmula es necesario ingresar el precio costo!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    Dim SQL As String = "SELECT PORCENTAJE_VENTA"
                    SQL &= Chr(13) & " FROM PROVEEDOR"
                    SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & " AND CEDULA = " & SCM(Buscador.VALOR)

                    CONX.Coneccion_Abrir()
                    Dim DS = CONX.EJECUTE_DS(SQL)
                    CONX.Coneccion_Cerrar()

                    If DS.Tables(0).Rows.Count > 0 Then
                        Porcentaje_Venta = Val(DS.Tables(0).Rows(0).Item(0))
                    End If


                    If Val(Porcentaje_Venta) <= 0 Then
                        MessageBox.Show("¡La fórmula no se puede aplicar, ya que el porcentaje de venta del proveedor es menor o igual a cero!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Porcentaje_Venta = (1 + (Porcentaje_Venta / 100))
                        Dim precio As Decimal = (FMC(TXT_COSTO.Text, 4) * Porcentaje_Venta)


                        TXT_PRECIO.Text = FMCP(precio, 4)
                        TXT_PRECIO_2.Text = FMCP(precio, 4)
                        TXT_PRECIO_3.Text = FMCP(precio, 4)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class