Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Inventario
    Dim CONSULTA_FILTRO As String = ""

    Sub New()
        InitializeComponent()
        FORMATO_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 6
        GRID.Columns(0).HeaderText = "Ajuste #"
        GRID.Columns(0).Name = "ENC.NUMERO_DOC"
        GRID.Columns(1).HeaderText = "Fecha"
        GRID.Columns(1).Name = "CONVERT(VARCHAR(10), ENC.FECHA, 105)"
        GRID.Columns(2).HeaderText = "Usuario"
        GRID.Columns(2).Name = "ENC.COD_USUARIO"
        GRID.Columns(3).HeaderText = "Descripción"
        GRID.Columns(3).Name = "ENC.DESCRIPCION"
        GRID.Columns(4).HeaderText = "Tipo ajuste"
        GRID.Columns(4).Name = "CASE WHEN ENC.COD_MOV = 'EPA' THEN 'Entrada por ajuste' ELSE 'Salida por ajuste' END"
        GRID.Columns(5).HeaderText = "# Lineas"
        GRID.Columns(5).Name = "COUNT(DET.LINEA)"
        Filtro.FILTRO_CARGAR_COMBO(GRID)
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim Sql = "	SELECT ENC.NUMERO_DOC, CONVERT(VARCHAR(10), ENC.FECHA, 105) AS FECHA, ENC.COD_USUARIO, ENC.DESCRIPCION"
                Sql &= Chr(13) & "	,CASE WHEN ENC.COD_MOV = 'EPA' THEN 'Entrada por ajuste' ELSE 'Salida por ajuste' END AS COD_MOV, COUNT(DET.LINEA) AS LINEAS	"
                Sql &= Chr(13) & "	FROM INVENTARIO_ENC AS ENC	"
                Sql &= Chr(13) & "	INNER JOIN INVENTARIO_DET AS DET "
                Sql &= Chr(13) & "		ON DET.COD_CIA = ENC.COD_CIA "
                Sql &= Chr(13) & "		AND DET.COD_SUCUR = ENC.COD_SUCUR "
                Sql &= Chr(13) & "		AND DET.NUMERO_DOC = ENC.NUMERO_DOC	"
                Sql &= Chr(13) & "		AND DET.TIPO_MOV = ENC.TIPO_MOV	"
                Sql &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "  AND ENC.FECHA BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
                Sql &= Chr(13) & CONSULTA_FILTRO
                Sql &= Chr(13) & "  GROUP BY ENC.NUMERO_DOC, CONVERT(VARCHAR(10), ENC.FECHA, 105), COD_USUARIO, DESCRIPCION, COD_MOV"
                Sql &= Chr(13) & "  ORDER BY CONVERT(VARCHAR(10), ENC.FECHA, 105) DESC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("NUMERO_DOC"), ITEM("FECHA"), ITEM("COD_USUARIO"), ITEM("DESCRIPCION"), ITEM("COD_MOV"), ITEM("LINEAS")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Refrescar()
        CONSULTA_FILTRO = ""
        RELLENAR_GRID()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_AJUSTE_Click(sender As Object, e As EventArgs) Handles BTN_AJUSTE.Click
        Try
            Dim PANTALLA As New Ajuste(Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_TRACKING_Click(sender As Object, e As EventArgs) Handles BTN_TRACKING.Click
        Try
            Dim PANTALLA As New Tracking()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        Try
            Refrescar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DTPINICIO_KeyDown(sender As Object, e As KeyEventArgs) Handles DTPINICIO.KeyDown
        If e.KeyCode = Keys.Enter Then
            RELLENAR_GRID()
        End If
    End Sub

    Private Sub DTPFINAL_KeyDown(sender As Object, e As KeyEventArgs) Handles DTPFINAL.KeyDown
        If e.KeyCode = Keys.Enter Then
            RELLENAR_GRID()
        End If
    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RELLENAR_GRID()

        BTN_AJUSTE.Enabled = TieneDerecho("DINVAJ")
        BTN_TRACKING.Enabled = TieneDerecho("DINVTR")
    End Sub
End Class