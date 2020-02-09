Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Facturacion
    Private Sub BTN_FACTURAR_Click(sender As Object, e As EventArgs) Handles BTN_FACTURAR.Click
        Try
            Dim PANTALLA As New Factura(CRF_Modos.Insertar, Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Me.Close()
    End Sub

    Private Sub Facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMB_TIPO_FACT.SelectedIndex = 0
        RELLENAR_GRID()
    End Sub

    Public Sub Refrescar()
        RELLENAR_GRID()
    End Sub

    Private Sub RELLENAR_GRID()
        Try
            GRID.DataSource = Nothing
            Dim SQL As String = ""

            If CMB_TIPO_FACT.SelectedIndex = 0 Then
                SQL &= Chr(13) & "	SELECT NUMERO_DOC AS Documento, TIPO_MOV as Tipo, C.CEDULA AS Cédula, C.NOMBRE AS Nombre, CONVERT(VARCHAR(10), ENC.FECHA, 105) AS Fecha	"
                SQL &= Chr(13) & "	,COD_USUARIO AS Usuario, COD_MONEDA AS Moneda, MONTO AS Subtotal, IMPUESTO AS Impuesto, (MONTO + IMPUESTO) as Total "
                SQL &= Chr(13) & "	FROM DOCUMENTO_ENC AS ENC	"
                SQL &= Chr(13) & "	INNER JOIN CLIENTE AS C	"
                SQL &= Chr(13) & "		ON C.COD_CIA = ENC.COD_CIA "
                SQL &= Chr(13) & "      AND C.CEDULA = ENC.CEDULA "
                SQL &= Chr(13) & " WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & " AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                If RB_ACTIVOS.Checked = True Then
                    SQL &= Chr(13) & "	AND ENC.ESTADO ='A'"
                ElseIf RB_INACTIVOS.Checked = True Then
                    SQL &= Chr(13) & "	AND ENC.ESTADO ='I'"
                End If
                SQL &= Chr(13) & " AND ENC.FECHA BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
            Else
                SQL &= Chr(13) & "	SELECT ENC.CODIGO AS Documento, ENC.TIPO_MOV as Tipo, C.CEDULA AS Cédula, C.NOMBRE AS Nombre, CONVERT(VARCHAR(10), ENC.FECHA, 105) AS Fecha	"
                SQL &= Chr(13) & "	,COD_USUARIO AS Usuario, COD_MONEDA AS Moneda, SUM(DET.SUBTOTAL) AS Subtotal, SUM(DET.IMPUESTO) AS Impuesto, SUM(DET.TOTAL) as Total 	"
                SQL &= Chr(13) & "	FROM DOCUMENTO_ENC_TMP AS ENC	"
                SQL &= Chr(13) & "	INNER JOIN CLIENTE AS C		"
                SQL &= Chr(13) & "		ON C.COD_CIA = ENC.COD_CIA	"
                SQL &= Chr(13) & "		AND C.CEDULA = ENC.CEDULA "
                SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_DET_TMP AS DET	 "
                SQL &= Chr(13) & "		ON DET.COD_CIA = ENC.COD_CIA "
                SQL &= Chr(13) & "		AND DET.COD_SUCUR = ENC.COD_SUCUR "
                SQL &= Chr(13) & "		AND DET.CODIGO = ENC.CODIGO "
                SQL &= Chr(13) & "		AND DET.TIPO_MOV = ENC.TIPO_MOV	"
                SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "  AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "  AND CONVERT(VARCHAR(10),ENC.FECHA, 111) BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
                SQL &= Chr(13) & "	GROUP BY ENC.CODIGO, ENC.TIPO_MOV, C.CEDULA, C.NOMBRE, CONVERT(VARCHAR(10), ENC.FECHA, 105),COD_USUARIO, COD_MONEDA	"
            End If

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

    Private Sub CMB_TIPO_FACT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_FACT.SelectedIndexChanged
        RELLENAR_GRID()
    End Sub

    Private Sub RB_ACTIVOS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVOS.CheckedChanged, RB_INACTIVOS.CheckedChanged, RB_TODOS.CheckedChanged
        RELLENAR_GRID()
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        RELLENAR_GRID()
    End Sub

    Private Sub GRID_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID.CellDoubleClick
        Try
            Dim PANTALLA As New Factura(CRF_Modos.Modificar, Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class