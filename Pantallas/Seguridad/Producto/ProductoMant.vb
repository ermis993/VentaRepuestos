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

        Cargar_Unidad_Medida()
        Cargar_Impuesto()

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

            ElseIf String.IsNullOrEmpty(Buscador.VALOR) Then

            ElseIf String.IsNullOrEmpty(TXT_DESC.Text) Then

            ElseIf String.IsNullOrEmpty(TXT_COSTO.Text) Then

            ElseIf String.IsNullOrEmpty(TXT_PRECIO.Text) Then

            ElseIf String.IsNullOrEmpty(TXT_ESTANTE.Text) Then

            ElseIf String.IsNullOrEmpty(TXT_FILA.Text) Then

            ElseIf String.IsNullOrEmpty(TXT_COLUMNA.Text) Then

            ElseIf String.IsNullOrEmpty(TXT_MINIMO.Text) Then

            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cargar_Unidad_Medida()
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

    Private Sub Cargar_Impuesto()
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
                Cargar_Porcentaje_Impuesto()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cargar_Porcentaje_Impuesto()
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

End Class