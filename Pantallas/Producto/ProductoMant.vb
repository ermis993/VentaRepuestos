Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class ProductoMant

    Dim MODO As CRF_Modos
    Dim PADRE As Producto
    Dim COD_PROD As String

    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Producto, Optional COD_PROD As String = "")
        InitializeComponent()

        Me.MODO = MODO
        Me.COD_PROD = COD_PROD
        Me.PADRE = PADRE

        Buscador.TABLA_BUSCAR = "Proveedor"
        Buscador.CODIGO = "CEDULA"
        Buscador.DESCRIPCION = "NOMBRE"
        Buscador.PANTALLA = New Proveedor(CRF_Modos.Seleccionar, Buscador)
        Buscador.refrescar()

        CARGAR_UNIDAD_MEDIDA()
        CARGAR_IMPUESTO()

    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Me.Close()
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                MessageBox.Show("¡Debe digitar un código de producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_CODIGO.Select()
            ElseIf String.IsNullOrEmpty(Buscador.VALOR) Then
                MessageBox.Show("¡Debe seleccionar el proveedor!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Buscador.Select()
            ElseIf String.IsNullOrEmpty(TXT_DESC.Text) Then
                MessageBox.Show("¡Debe digitar la descripción del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_DESC.Select()
            ElseIf String.IsNullOrEmpty(TXT_COSTO.Text) Then
                MessageBox.Show("¡Debe digitar el costo del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_COSTO.Select()
            ElseIf String.IsNullOrEmpty(TXT_PRECIO.Text) Then
                MessageBox.Show("¡Debe digitar el precio del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_PRECIO.Select()
            ElseIf String.IsNullOrEmpty(TXT_ESTANTE.Text) Then
                MessageBox.Show("¡Debe digitar el estante en el que se cuentra el producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_ESTANTE.Select()
            ElseIf String.IsNullOrEmpty(TXT_FILA.Text) Then
                MessageBox.Show("¡Debe digitar la fila en la que se encuentra el producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_FILA.Select()
            ElseIf String.IsNullOrEmpty(TXT_COLUMNA.Text) Then
                MessageBox.Show("¡Debe digitar la columna en la que se encuentra el producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_COLUMNA.Select()
            ElseIf String.IsNullOrEmpty(TXT_MINIMO.Text) Then
                MessageBox.Show("¡Debe digitar la cantidad minima en stock del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_MINIMO.Select()
            Else

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
                Sql &= Chr(13) & "	,@EXENTO = " & SCM(TXT_EXENTO.Text)
                Sql &= Chr(13) & "	,@ESTADO = " & SCM(IIf(RB_ACTIVO.Checked, "A", "I"))
                Sql &= Chr(13) & "	,@ESTANTE = " & SCM(TXT_ESTANTE.Text)
                Sql &= Chr(13) & "	,@FILA = " & SCM(TXT_FILA.Text)
                Sql &= Chr(13) & "	,@COLUMNA = " & SCM(TXT_COLUMNA.Text)
                Sql &= Chr(13) & "	,@MINIMO = " & FMC(TXT_MINIMO.Text)
                Sql &= Chr(13) & "	,@COD_BARRA = " & SCM(TXT_COD_BARRA.Text)
                Sql &= Chr(13) & "	,@MODO = " & Val(Me.MODO)

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()

                If Me.MODO = CRF_Modos.Insertar Then
                    LIMPIAR_TODO()
                    MessageBox.Show("¡Cliente agregado correctamente!")
                Else
                    Me.Close()
                    MessageBox.Show("¡Cliente modificado correctamente!")
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
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND ESTADO = 'A'"

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
        TXT_COD_BARRA.Text = ""
        TXT_COLUMNA.Text = ""
        TXT_ESTANTE.Text = ""
        TXT_FILA.Text = ""
        TXT_COSTO.Text = ""
        TXT_PRECIO.Text = ""
        TXT_DESC.Text = ""
        TXT_MINIMO.Text = ""
        RB_ACTIVO.Checked = True
    End Sub

End Class