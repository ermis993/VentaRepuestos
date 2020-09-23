Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class ProductoUbicacionMant

    Dim MODO As CRF_Modos
    Dim PADRE As Factura

    Sub New(ByVal COD_PROD As String, ByVal DESCRIPCION As String, Optional ByVal MODO As CRF_Modos = CRF_Modos.Nada, Optional ByVal PADRE As Factura = Nothing)
        InitializeComponent()
        TXT_CODIGO.Text = COD_PROD
        TXT_DESC.Text = DESCRIPCION
        Me.MODO = MODO
        Me.PADRE = PADRE

        If Me.MODO = CRF_Modos.Seleccionar Then
            BTN_INGRESAR.Enabled = False
        End If

        RELLENAR_GRID()
    End Sub

    Private Sub GRID_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID.CellDoubleClick
        If Me.GRID.Rows.Count > 0 Then
            Leer_indice()
        End If
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then

                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)

                If MODO = CRF_Modos.Seleccionar Then
                    Me.PADRE.RellenaUbicaciones(seleccionado.Cells(0).Value.ToString, seleccionado.Cells(1).Value.ToString, seleccionado.Cells(2).Value.ToString, TXT_CODIGO.Text)
                    Me.Close()
                Else
                    TXT_ESTANTE.Text = seleccionado.Cells(0).Value.ToString
                    TXT_FILA.Text = seleccionado.Cells(1).Value.ToString
                    TXT_COLUMNA.Text = seleccionado.Cells(2).Value.ToString

                    If seleccionado.Cells(3).Value.ToString = "A" Then
                        RB_ACTIVO.Checked = True
                    Else
                        RB_INACTIVO.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_INGRESAR_Click(sender As Object, e As EventArgs) Handles BTN_INGRESAR.Click
        Try
            If String.IsNullOrEmpty(TXT_ESTANTE.Text) Then
                MessageBox.Show("¡Debe ingresar el estante del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_ESTANTE.Select()
            ElseIf String.IsNullOrEmpty(TXT_FILA.Text) Then
                MessageBox.Show("¡Debe ingresar la fila del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_FILA.Select()
            ElseIf String.IsNullOrEmpty(TXT_COLUMNA.Text) Then
                MessageBox.Show("¡Debe ingresar la columna del producto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_COLUMNA.Select()
            Else

                Dim SQL = "	EXECUTE USP_PRODUCTO_UBICACIONES_MANT "
                SQL &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "	,@COD_PROD = " & SCM(TXT_CODIGO.Text)
                SQL &= Chr(13) & "	,@ESTANTE = " & SCM(TXT_ESTANTE.Text)
                SQL &= Chr(13) & "	,@FILA = " & SCM(TXT_FILA.Text)
                SQL &= Chr(13) & "	,@COLUMNA = " & SCM(TXT_COLUMNA.Text)
                SQL &= Chr(13) & "	,@ESTADO = " & SCM(IIf(RB_ACTIVO.Checked, "A", "I"))

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                LIMPIAR_TODO()
                MessageBox.Show("¡Ubicación ingresada correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                RELLENAR_GRID()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LIMPIAR_TODO()
        TXT_COLUMNA.Text = ""
        TXT_ESTANTE.Text = ""
        TXT_FILA.Text = ""
        RB_ACTIVO.Checked = True
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            GRID.DataSource = Nothing
            Dim SQL = "	SELECT ESTANTE AS Estante, FILA AS Fila, COLUMNA AS Columna, ESTADO AS Estado, CONVERT(VARCHAR(10), FECHA_INC, 105) AS 'Fecha ingreso'"
            SQL &= Chr(13) & "	FROM PRODUCTO_UBICACION	"
            SQL &= Chr(13) & "	WHERE COD_PROD = " & SCM(TXT_CODIGO.Text)
            SQL &= Chr(13) & "	AND COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRID.DataSource = DS.Tables(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
End Class