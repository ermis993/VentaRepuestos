Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class DocumentoElectronico

    Dim CONSULTA_FILTRO As String = ""
    Sub New()
        InitializeComponent()
        FORMATO_GRID()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        CONSULTA_FILTRO = ""
        RELLENAR_GRID()
    End Sub

    Private Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL As String = ""

                SQL = "	SELECT CONSECUTIVO_FE AS 'Consecutivo', CONSECUTIVO_P AS 'Documento', PROV.NOMBRE AS 'Proveedor', TIPO_MOV AS 'Tipo', CONVERT(VARCHAR(10), FECHA, 105) AS 'Fecha',	"
                SQL &= Chr(13) & "	CASE WHEN COD_MONEDA = 'C' THEN 'Colones' ELSE 'Dólares' END AS 'Moneda', TOTAL_VENTA AS 'Subtotal', IMPUESTO AS 'Impuesto', TOTAL AS 'Total',	"
                SQL &= Chr(13) & "	CASE WHEN ISNULL(RESPUESTA_DGTD, 'P') = 'A' THEN 'Aceptado' WHEN ISNULL(RESPUESTA_DGTD, 'P') = 'R' THEN 'Rechazado' ELSE 'Pendiente' END AS 'Estado'	"
                SQL &= Chr(13) & "	FROM CXP_DOCUMENTOS_ELECTRONICOS AS CXP	"
                SQL &= Chr(13) & "	INNER JOIN PROVEEDOR AS PROV	"
                SQL &= Chr(13) & "		ON PROV.COD_CIA = CXP.COD_CIA"
                SQL &= Chr(13) & "		AND PROV.COD_SUCUR = CXP.COD_SUCUR"
                SQL &= Chr(13) & "      AND PROV.CEDULA = CXP.CEDULA"
                SQL &= Chr(13) & " WHERE CXP.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & " AND CXP.COD_SUCUR =  " & SCM(COD_SUCUR)
                SQL &= Chr(13) & " AND FECHA BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
                SQL &= Chr(13) & CONSULTA_FILTRO
                SQL &= Chr(13) & " ORDER BY FECHA DESC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("Consecutivo"), ITEM("Documento"), ITEM("Proveedor"), ITEM("Tipo"), ITEM("Fecha"), ITEM("Moneda"), ITEM("Subtotal"), ITEM("Impuesto"), ITEM("Total"), ITEM("Estado")}
                        GRID.Rows.Add(row)
                    Next
                End If

                PintarEstados()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DocumentoElectronico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RELLENAR_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 12
        GRID.Columns(0).HeaderText = "Consecutivo"
        GRID.Columns(0).Name = "CONSECUTIVO_FE"
        GRID.Columns(1).HeaderText = "Documento"
        GRID.Columns(1).Name = "CONSECUTIVO_P"
        GRID.Columns(2).HeaderText = "Proveedor"
        GRID.Columns(2).Name = "PROV.NOMBRE"
        GRID.Columns(3).HeaderText = "Tipo"
        GRID.Columns(3).Name = "TIPO_MOV"
        GRID.Columns(4).HeaderText = "Fecha"
        GRID.Columns(4).Name = "CONVERT(VARCHAR(10), FECHA, 105)"
        GRID.Columns(5).HeaderText = "Moneda"
        GRID.Columns(5).Name = "CASE WHEN COD_MONEDA = 'C' THEN 'Colones' ELSE 'Dólares' END"
        GRID.Columns(6).HeaderText = "Subtotal"
        GRID.Columns(6).Name = "TOTAL_VENTA"
        GRID.Columns(7).HeaderText = "Impuesto"
        GRID.Columns(7).Name = "IMPUESTO"
        GRID.Columns(8).HeaderText = "Total"
        GRID.Columns(8).Name = "TOTAL"
        GRID.Columns(9).HeaderText = "Estado"
        GRID.Columns(9).Name = "CASE WHEN ISNULL(RESPUESTA_DGTD, 'P') = 'A' THEN 'Aceptado' WHEN ISNULL(RESPUESTA_DGTD, 'P') = 'R' THEN 'Rechazado' ELSE 'Pendiente' END"
        Filtro.FILTRO_CARGAR_COMBO(GRID)
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

    Private Sub Filtro_Filtrar_Click(sender As Object, e As EventArgs) Handles Filtro.Filtrar_Click
        If Filtro.VALOR <> "" Then
            CONSULTA_FILTRO = Filtro.FILTRAR()
            RELLENAR_GRID()
        End If
    End Sub

    Private Sub PintarEstados()
        Try
            Dim dgv As DataGridView = Me.GRID
            If dgv.Rows.Count > 0 Then
                For i As Integer = 0 To dgv.Rows.Count - 1
                    If dgv.Rows(i).Cells(9).Value = "Aceptado" Then
                        dgv.Rows(i).Cells(0).Style.BackColor = Color.ForestGreen
                        dgv.Rows(i).Cells(1).Style.BackColor = Color.ForestGreen
                    ElseIf dgv.Rows(i).Cells(9).Value = "Rechazado" Then
                        dgv.Rows(i).Cells(0).Style.BackColor = Color.DarkRed
                        dgv.Rows(i).Cells(1).Style.BackColor = Color.DarkRed
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_IMPORTAR_Click(sender As Object, e As EventArgs) Handles BTN_IMPORTAR.Click
        Try
            Dim PANTALLA As New DocumentoElectronicoImp()
            AddHandler PANTALLA.FormClosed, AddressOf Pantalla_Cerrada
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Pantalla_Cerrada(sender As Object, e As FormClosedEventArgs)
        RELLENAR_GRID()
    End Sub

    Private Sub BTN_BUSQUEDA_Click(sender As Object, e As EventArgs) Handles BTN_BUSQUEDA.Click
        Try
            Dim PANTALLA As New DocumentoElectronicoCorreo()
            AddHandler PANTALLA.FormClosed, AddressOf Pantalla_Cerrada
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class