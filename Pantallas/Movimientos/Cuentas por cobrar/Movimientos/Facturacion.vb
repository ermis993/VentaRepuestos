Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Imports VentaRepuestos.ReportesProcesos
Public Class Facturacion
    Dim Numero_Doc As Integer
    Dim Codigo As String
    Dim CONSULTA_FILTRO As String = ""
    Dim Respuesta As String = ""
    Dim Tipo_Mov As String
    Dim Descripcion As String

    Private Sub BTN_FACTURAR_Click(sender As Object, e As EventArgs) Handles BTN_FACTURAR.Click
        Try
            Dim PANTALLA As New Factura(CRF_Modos.Insertar, Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                If CMB_TIPO_FACT.SelectedIndex = 0 Then
                    If IND_ENCOMIENDA = "S" Then
                        Numero_Doc = Val(seleccionado.Cells(0).Value.ToString)
                        Codigo = ""
                        Tipo_Mov = seleccionado.Cells(2).Value.ToString
                        Respuesta = seleccionado.Cells(13).Value.ToString
                    Else
                        Numero_Doc = Val(seleccionado.Cells(0).Value.ToString)
                        Codigo = ""
                        Tipo_Mov = seleccionado.Cells(1).Value.ToString
                        Respuesta = seleccionado.Cells(12).Value.ToString
                    End If
                Else
                    Numero_Doc = 0
                    Codigo = seleccionado.Cells(0).Value.ToString
                    Tipo_Mov = seleccionado.Cells(1).Value.ToString
                End If
            End If
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

        BTN_FACTURAR.Enabled = TieneDerecho("VFACTS")
        BTN_RECIBO.Enabled = TieneDerecho("VREB")
        BTN_REPORTES.Enabled = TieneDerecho("DREPT")
        BTN_APARTADO.Enabled = TieneDerecho("DAPAR")
        BTN_ANULAR.Enabled = TieneDerecho("APART")
        BTN_PROFORMAS.Enabled = TieneDerecho("DPROFOR")
        CMB_VER.Enabled = (TieneDerecho("DAPAR") Or TieneDerecho("DPROFOR"))
    End Sub

    Public Sub Refrescar()
        RELLENAR_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        If CMB_TIPO_FACT.SelectedIndex = 0 Then
            GRID.ColumnCount = IIf(IND_ENCOMIENDA = "S", 14, 13)
            GRID.Columns(0).HeaderText = "Documento"
            GRID.Columns(0).Name = "ENC.NUMERO_DOC"
            If IND_ENCOMIENDA = "S" Then
                GRID.Columns(1).HeaderText = "Encomienda"
                GRID.Columns(1).Name = " ISNULL(DG.NUMERO_GUIA, '0')"
                GRID.Columns(2).HeaderText = "Tipo"
                GRID.Columns(2).Name = "ENC.TIPO_MOV"
                GRID.Columns(3).HeaderText = "Cédula"
                GRID.Columns(3).Name = "C.CEDULA"
                GRID.Columns(4).HeaderText = "Nombre"
                GRID.Columns(4).Name = "C.NOMBRE"
                GRID.Columns(5).HeaderText = "Descripción"
                GRID.Columns(5).Name = "ENC.DESCRIPCION"
                GRID.Columns(6).HeaderText = "Fecha"
                GRID.Columns(6).Name = "CONVERT(VARCHAR(10), ENC.FECHA, 105)"
                GRID.Columns(7).HeaderText = "Usuario"
                GRID.Columns(7).Name = "ENC.COD_USUARIO"
                GRID.Columns(8).HeaderText = "Moneda"
                GRID.Columns(8).Name = "COD_MONEDA"
                GRID.Columns(9).HeaderText = "Subtotal"
                GRID.Columns(9).Name = "MONTO"
                GRID.Columns(10).HeaderText = "Impuesto"
                GRID.Columns(10).Name = "IMPUESTO"
                GRID.Columns(11).HeaderText = "Total"
                GRID.Columns(11).Name = "(MONTO + IMPUESTO)"
                GRID.Columns(12).HeaderText = "Saldo"
                GRID.Columns(12).Name = " ENC.SALDO"
                GRID.Columns(13).HeaderText = "DGTD"
                GRID.Columns(13).Name = " ISNULL(DE.RESPUESTA_DGTD, 'P')"
            Else
                GRID.Columns(1).HeaderText = "Tipo"
                GRID.Columns(1).Name = "ENC.TIPO_MOV"
                GRID.Columns(2).HeaderText = "Cédula"
                GRID.Columns(2).Name = "C.CEDULA"
                GRID.Columns(3).HeaderText = "Nombre"
                GRID.Columns(3).Name = "C.NOMBRE"
                GRID.Columns(4).HeaderText = "Descripción"
                GRID.Columns(4).Name = "ENC.DESCRIPCION"
                GRID.Columns(5).HeaderText = "Fecha"
                GRID.Columns(5).Name = "CONVERT(VARCHAR(10), ENC.FECHA, 105)"
                GRID.Columns(6).HeaderText = "Usuario"
                GRID.Columns(6).Name = "ENC.COD_USUARIO"
                GRID.Columns(7).HeaderText = "Moneda"
                GRID.Columns(7).Name = "COD_MONEDA"
                GRID.Columns(8).HeaderText = "Subtotal"
                GRID.Columns(8).Name = "MONTO"
                GRID.Columns(9).HeaderText = "Impuesto"
                GRID.Columns(9).Name = "IMPUESTO"
                GRID.Columns(10).HeaderText = "Total"
                GRID.Columns(10).Name = "(MONTO + IMPUESTO)"
                GRID.Columns(11).HeaderText = "Saldo"
                GRID.Columns(11).Name = " ENC.SALDO"
                GRID.Columns(12).HeaderText = "DGTD"
                GRID.Columns(12).Name = " ISNULL(DE.RESPUESTA_DGTD, 'P')"
            End If
            Filtro.FILTRO_CARGAR_COMBO(GRID)
        Else
            GRID.ColumnCount = 12
            GRID.Columns(0).HeaderText = "Documento"
            GRID.Columns(0).Name = "ENC.CODIGO"
            GRID.Columns(1).HeaderText = "Tipo"
            GRID.Columns(1).Name = "ENC.TIPO_MOV"
            GRID.Columns(2).HeaderText = "Cédula"
            GRID.Columns(2).Name = "C.CEDULA"
            GRID.Columns(3).HeaderText = "Nombre"
            GRID.Columns(3).Name = "C.NOMBRE"
            GRID.Columns(4).HeaderText = "Descripción"
            GRID.Columns(4).Name = "ENC.DESCRIPCION"
            GRID.Columns(5).HeaderText = "Fecha"
            GRID.Columns(5).Name = "CONVERT(VARCHAR(10), ENC.FECHA, 105)"
            GRID.Columns(6).HeaderText = "Usuario"
            GRID.Columns(6).Name = "COD_USUARIO"
            GRID.Columns(7).HeaderText = "Moneda"
            GRID.Columns(7).Name = "COD_MONEDA"
            GRID.Columns(8).HeaderText = "Subtotal"
            GRID.Columns(8).Name = "SUM(DET.SUBTOTAL)"
            GRID.Columns(9).HeaderText = "Impuesto"
            GRID.Columns(9).Name = "SUM(DET.IMPUESTO)"
            GRID.Columns(10).HeaderText = "Total"
            GRID.Columns(10).Name = " SUM(DET.TOTAL)"
            GRID.Columns(11).HeaderText = "Saldo"
            GRID.Columns(11).Name = " SUM(DET.TOTAL)"
            Filtro.FILTRO_CARGAR_COMBO(GRID)
        End If

    End Sub

    Private Sub RELLENAR_GRID()
        Try
            Dim Total_Facturado As Decimal = 0
            Dim TABLA As String

            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL As String = ""

                Dim SELECCIONADO = CMB_VER.SelectedItem.ToString.Substring(0, 1)

                If SELECCIONADO = "F" Or SELECCIONADO = "R" Or SELECCIONADO = "N" Then
                    TABLA = "DOCUMENTO_ENC"
                ElseIf SELECCIONADO = "A" Then
                    TABLA = "APARTADO_ENC"
                Else
                    TABLA = "PROFORMA_ENC"
                End If

                If CMB_TIPO_FACT.SelectedIndex = 0 Then
                    SQL &= Chr(13) & "	SELECT ENC.NUMERO_DOC AS Documento, ENC.TIPO_MOV as Tipo, C.CEDULA AS Cédula, C.NOMBRE AS Nombre, ENC.DESCRIPCION AS Descripción, CONVERT(VARCHAR(10), ENC.FECHA, 105) AS Fecha	"
                    SQL &= Chr(13) & "	,ENC.COD_USUARIO AS Usuario, COD_MONEDA AS Moneda, MONTO AS Subtotal, IMPUESTO AS Impuesto, (MONTO + IMPUESTO) as Total, ENC.SALDO AS Saldo, ISNULL(DE.RESPUESTA_DGTD, 'P') AS Respuesta "
                    If IND_ENCOMIENDA = "S" Then
                        SQL &= Chr(13) & "	,ISNULL(DG.NUMERO_GUIA, '0') AS Guia"
                    End If
                    If SELECCIONADO = "P" Then
                        SQL &= Chr(13) & "	,ISNULL(ENC.NUM_FACTURA, '') AS Factura"
                    End If
                    SQL &= Chr(13) & "	FROM " & TABLA & " AS ENC	"
                    SQL &= Chr(13) & "	INNER JOIN CLIENTE As C	"
                    SQL &= Chr(13) & "		On C.COD_CIA = ENC.COD_CIA "
                    SQL &= Chr(13) & "      And C.CEDULA = ENC.CEDULA "
                    SQL &= Chr(13) & "   LEFT JOIN DOCUMENTO_ELECTRONICO As DE "
                    SQL &= Chr(13) & "		On ENC.COD_CIA = DE.COD_CIA "
                    SQL &= Chr(13) & "      And ENC.COD_SUCUR = DE.COD_SUCUR "
                    SQL &= Chr(13) & "      And ENC.NUMERO_DOC = DE.NUMERO_DOC "
                    SQL &= Chr(13) & "      And ENC.TIPO_MOV = DE.TIPO_MOV "
                    If IND_ENCOMIENDA = "S" Then
                        SQL &= Chr(13) & "   LEFT JOIN DOCUMENTO_GUIA AS DG "
                        SQL &= Chr(13) & "		ON ENC.COD_CIA = DG.COD_CIA "
                        SQL &= Chr(13) & "      And ENC.COD_SUCUR = DG.COD_SUCUR "
                        SQL &= Chr(13) & "      And ENC.NUMERO_DOC = DG.NUMERO_DOC "
                        SQL &= Chr(13) & "      And ENC.TIPO_MOV = DG.TIPO_MOV "
                    End If
                    SQL &= Chr(13) & " WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & " And ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                    If RB_ACTIVOS.Checked = True Then
                        SQL &= Chr(13) & "	And ENC.ESTADO ='A'"
                    ElseIf RB_INACTIVOS.Checked = True Then
                        SQL &= Chr(13) & "	AND ENC.ESTADO ='I'"
                    End If
                    If SELECCIONADO = "F" Then
                        SQL &= Chr(13) & "	AND ENC.TIPO_MOV IN ('FA', 'FC')"
                    ElseIf SELECCIONADO = "R" Then
                        SQL &= Chr(13) & "	AND ENC.TIPO_MOV = 'RB'"
                    ElseIf SELECCIONADO = "N" Then
                        SQL &= Chr(13) & "	AND ENC.TIPO_MOV = 'NC'"
                    End If
                    SQL &= Chr(13) & " AND ENC.FECHA BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
                    SQL &= Chr(13) & CONSULTA_FILTRO
                    SQL &= Chr(13) & " ORDER BY ENC.TIPO_MOV DESC, ENC.FECHA_INC DESC"
                Else
                    SQL &= Chr(13) & "	SELECT ENC.CODIGO AS Documento, ENC.TIPO_MOV as Tipo, C.CEDULA AS Cédula, C.NOMBRE AS Nombre, ENC.DESCRIPCION AS Descripción, CONVERT(VARCHAR(10), ENC.FECHA, 105) AS Fecha	"
                    SQL &= Chr(13) & "	,COD_USUARIO AS Usuario, COD_MONEDA AS Moneda, SUM(DET.SUBTOTAL) AS Subtotal, SUM(DET.IMPUESTO) AS Impuesto, SUM(DET.TOTAL) as Total, SUM(DET.TOTAL) as Saldo, 'P' AS Respuesta 	"
                    SQL &= Chr(13) & "	FROM " & IIf(SELECCIONADO = "A", "APARTADO_ENC_TMP", "DOCUMENTO_ENC_TMP") & " AS ENC	"
                    SQL &= Chr(13) & "	INNER JOIN CLIENTE AS C		"
                    SQL &= Chr(13) & "		ON C.COD_CIA = ENC.COD_CIA	"
                    SQL &= Chr(13) & "		AND C.CEDULA = ENC.CEDULA "
                    SQL &= Chr(13) & "	INNER JOIN " & IIf(SELECCIONADO = "A", "APARTADO_DET_TMP", "DOCUMENTO_DET_TMP") & " AS DET	 "
                    SQL &= Chr(13) & "		ON DET.COD_CIA = ENC.COD_CIA "
                    SQL &= Chr(13) & "		AND DET.COD_SUCUR = ENC.COD_SUCUR "
                    SQL &= Chr(13) & "		AND DET.CODIGO = ENC.CODIGO "
                    SQL &= Chr(13) & "		AND DET.TIPO_MOV = ENC.TIPO_MOV	"
                    SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "  AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "  AND CONVERT(VARCHAR(10),ENC.FECHA, 111) BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
                    SQL &= Chr(13) & CONSULTA_FILTRO
                    SQL &= Chr(13) & "	GROUP BY ENC.CODIGO, ENC.TIPO_MOV, C.CEDULA, C.NOMBRE, ENC.DESCRIPCION, CONVERT(VARCHAR(10), ENC.FECHA, 105),ENC.FECHA_INC,COD_USUARIO, COD_MONEDA	"
                    SQL &= Chr(13) & "  ORDER BY ENC.TIPO_MOV DESC, ENC.FECHA_INC DESC"
                End If

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String()
                        If IND_ENCOMIENDA = "S" And CMB_TIPO_FACT.SelectedIndex = 0 Then
                            row = New String() {ITEM("Documento"), ITEM("Guia"), ITEM("Tipo"), ITEM("Cédula"), ITEM("Nombre"), ITEM("Descripción"), ITEM("Fecha"), ITEM("Usuario"), ITEM("Moneda"), ITEM("Subtotal"), ITEM("Impuesto"), ITEM("Total"), ITEM("Saldo"), ITEM("Respuesta")}
                        Else
                            If SELECCIONADO = "P" Then
                                row = New String() {ITEM("Documento"), ITEM("Tipo"), ITEM("Cédula"), ITEM("Nombre"), ITEM("Descripción"), ITEM("Fecha"), ITEM("Usuario"), ITEM("Moneda"), ITEM("Subtotal"), ITEM("Impuesto"), ITEM("Total"), ITEM("Saldo"), ITEM("Factura")}
                            ElseIf SELECCIONADO = "R" Or SELECCIONADO = "A" Then
                                row = New String() {ITEM("Documento"), ITEM("Tipo"), ITEM("Cédula"), ITEM("Nombre"), ITEM("Descripción"), ITEM("Fecha"), ITEM("Usuario"), ITEM("Moneda"), ITEM("Subtotal"), ITEM("Impuesto"), ITEM("Total"), ITEM("Saldo"), "N/A"}
                            Else
                                row = New String() {ITEM("Documento"), ITEM("Tipo"), ITEM("Cédula"), ITEM("Nombre"), ITEM("Descripción"), ITEM("Fecha"), ITEM("Usuario"), ITEM("Moneda"), ITEM("Subtotal"), ITEM("Impuesto"), ITEM("Total"), ITEM("Saldo"), ITEM("Respuesta")}
                            End If

                        End If

                        GRID.Rows.Add(row)
                    Next
                End If

                If SELECCIONADO = "P" Then
                    GRID.Columns(12).HeaderText = "Factura #"
                    GRID.Columns(12).Name = " ISNULL(ENC.NUM_FACTURA, '') "
                End If

                If CMB_TIPO_FACT.SelectedIndex = 0 And (SELECCIONADO = "F" Or SELECCIONADO = "N") And IND_FE = "S" Then
                    PintarEstados()
                End If

                LBL_TOTAL_FACTURADO.Text = FMCP(ObtieneTotalFacturado())
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PintarEstados()
        Try
            Dim dgv As DataGridView = Me.GRID
            If dgv.Rows.Count > 0 Then
                For i As Integer = 0 To dgv.Rows.Count - 1
                    If IND_ENCOMIENDA = "S" Then
                        If dgv.Rows(i).Cells(13).Value = "A" Then
                            dgv.Rows(i).Cells(0).Style.BackColor = Color.ForestGreen
                            dgv.Rows(i).Cells(1).Style.BackColor = Color.ForestGreen
                        ElseIf dgv.Rows(i).Cells(13).Value = "R" Then
                            dgv.Rows(i).Cells(0).Style.BackColor = Color.DarkRed
                            dgv.Rows(i).Cells(1).Style.BackColor = Color.DarkRed
                        Else
                            If (dgv.Rows(i).Cells(2).Value = "FA" Or dgv.Rows(i).Cells(2).Value = "FC" Or dgv.Rows(i).Cells(2).Value = "NC" Or dgv.Rows(i).Cells(2).Value = "ND") Then
                                dgv.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                dgv.Rows(i).Cells(1).Style.BackColor = Color.Orange
                            End If
                        End If
                    Else
                        If dgv.Rows(i).Cells(12).Value = "A" Then
                            dgv.Rows(i).Cells(0).Style.BackColor = Color.ForestGreen
                            dgv.Rows(i).Cells(1).Style.BackColor = Color.ForestGreen
                        ElseIf dgv.Rows(i).Cells(12).Value = "R" Then
                            dgv.Rows(i).Cells(0).Style.BackColor = Color.DarkRed
                            dgv.Rows(i).Cells(1).Style.BackColor = Color.DarkRed
                        Else
                            If (dgv.Rows(i).Cells(1).Value = "FA" Or dgv.Rows(i).Cells(1).Value = "FC" Or dgv.Rows(i).Cells(1).Value = "NC" Or dgv.Rows(i).Cells(1).Value = "ND") Then
                                dgv.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                dgv.Rows(i).Cells(1).Style.BackColor = Color.Orange
                            End If
                        End If
                    End If

                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ObtieneTotalFacturado() As Decimal
        Try
            Dim SQL = " SELECT SUM(MONTO) AS MONTO"
            SQL &= Chr(13) & " FROM DOCUMENTO_ENC "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "  AND COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "  AND CONVERT(VARCHAR(10), FECHA, 111) BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
            SQL &= Chr(13) & "  AND TIPO_MOV = 'RB' "
            SQL &= Chr(13) & "  AND ESTADO = 'A' "
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                ObtieneTotalFacturado = FMC(DS.Tables(0).Rows(0).Item(0))
            Else
                ObtieneTotalFacturado = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub CMB_TIPO_FACT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_FACT.SelectedIndexChanged
        FORMATO_GRID()
        RELLENAR_GRID()
    End Sub

    Private Sub RB_ACTIVOS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVOS.CheckedChanged, RB_INACTIVOS.CheckedChanged, RB_TODOS.CheckedChanged
        RELLENAR_GRID()
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        CONSULTA_FILTRO = ""
        RELLENAR_GRID()
    End Sub

    Private Sub GRID_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID.CellDoubleClick
        Modificar()
    End Sub

    Public Sub Modificar()
        Try
            Leer_indice()
            Dim SELECCIONADO = CMB_VER.SelectedItem.ToString.Substring(0, 1)
            If SELECCIONADO = "F" Or SELECCIONADO = "N" Or SELECCIONADO = "R" Then
                If Tipo_Mov = "FA" Or Tipo_Mov = "FC" Then
                    Dim PANTALLA As New Factura(CRF_Modos.Modificar, Me, Numero_Doc, Codigo, Tipo_Mov)
                    PANTALLA.ShowDialog()
                Else
                    Dim PANTALLA As New NotaCredito(Me, IIf(SELECCIONADO = "A", "A", "F"), CRF_Modos.Seleccionar, Tipo_Mov, Numero_Doc)
                    PANTALLA.ShowDialog()
                End If
            ElseIf SELECCIONADO = "A" Then
                Dim PANTALLA As New Apartado(CRF_Modos.Modificar, Me, Numero_Doc, Codigo, Tipo_Mov)
                PANTALLA.ShowDialog()
            Else
                Dim PANTALLA As New Proforma(CRF_Modos.Modificar, Me, Numero_Doc, Codigo, Tipo_Mov)
                PANTALLA.ShowDialog()
            End If

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

    Sub New()
        InitializeComponent()
        CMB_VER.SelectedIndex = 0
        FORMATO_GRID()
    End Sub

    Private Sub FILTRAR(sender As Object, e As EventArgs) Handles Filtro.Filtrar_Click
        If Filtro.VALOR <> "" Then
            CONSULTA_FILTRO = Filtro.FILTRAR()
            RELLENAR_GRID()
        End If
    End Sub

    Private Sub BTN_RECIBO_Click(sender As Object, e As EventArgs) Handles BTN_RECIBO.Click
        Try
            Dim SELECCIONADO = CMB_VER.SelectedItem.ToString.Substring(0, 1)
            Dim PANTALLA As New NotaCredito(Me, IIf(SELECCIONADO = "A", "A", "F"), CRF_Modos.Insertar)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_IMPRIMIR_Click(sender As Object, e As EventArgs) Handles BTN_IMPRIMIR.Click
        Try
            Leer_indice()
            Dim SELECCIONADO = CMB_VER.SelectedItem.ToString.Substring(0, 1)
            If Tipo_Mov = "FC" Or Tipo_Mov = "FA" Then
                If SELECCIONADO = "F" Then
                    Dim imp As New Impresion()
                    imp.Imprimir(COD_CIA, COD_SUCUR, Numero_Doc, Tipo_Mov, IMG_COMPANIA)
                ElseIf SELECCIONADO = "P" Then
                    Dim f As FolderBrowserDialog = New FolderBrowserDialog
                    If f.ShowDialog() = DialogResult.OK Then
                        Dim Ruta = f.SelectedPath
                        Genera_RPT_PROFORMA(Tipo_Mov, Numero_Doc, "Proforma_" & Numero_Doc, Ruta)
                        MessageBox.Show(Me, "Reporte generado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            ElseIf Tipo_Mov = "RB" Then
                Dim imp As New Impresion()
                imp.ImprimirRecibo(COD_CIA, COD_SUCUR, Numero_Doc, Tipo_Mov)
            ElseIf Tipo_Mov = "NC" Then
                Dim f As FolderBrowserDialog = New FolderBrowserDialog
                If f.ShowDialog() = DialogResult.OK Then
                    Dim Ruta = f.SelectedPath
                    Genera_RPT_NC(Tipo_Mov, Numero_Doc, "Nota_De_Credito_" & Numero_Doc, Ruta)
                    MessageBox.Show(Me, "Reporte generado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf Tipo_Mov = "AC" Or Tipo_Mov = "AA" Then
                Dim imp As New Impresion()
                imp.ImprimirApartado(COD_CIA, COD_SUCUR, Numero_Doc, Tipo_Mov, IMG_COMPANIA)
            Else
                MessageBox.Show(Me, "Solamente se pueden imprimir facturas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MostrarRechazoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarRechazoToolStripMenuItem.Click
        Try
            Leer_indice()
            If Respuesta = "R" Then
                Dim Pantalla As New RespuestaDGTD(Numero_Doc, Tipo_Mov)
                Pantalla.ShowDialog()
            Else
                MessageBox.Show(Me, "El estado del documento seleccionado no es 'Rechazado'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RegenerarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegenerarDocumentoToolStripMenuItem.Click
        Try
            Leer_indice()
            If Respuesta = "R" Then
                Dim valor = MessageBox.Show(Me, "¿Está seguro que desea regenerar el documento: " & Numero_Doc & " ?", Me.Text, vbYesNo, MessageBoxIcon.Question)
                If valor = DialogResult.Yes Then
                    Dim SQL = "	EXECUTE USP_REGENERA_DOCUMENTO_ELECTRONICO"
                    SQL &= Chr(13) & "	@COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & ", @COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & ", @NUMERO_DOC = " & Val(Numero_Doc)
                    SQL &= Chr(13) & ", @TIPO_MOV = " & SCM(Tipo_Mov)
                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(SQL)
                    CONX.Coneccion_Cerrar()

                    RELLENAR_GRID()
                    MessageBox.Show(Me, "Documento regenerado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show(Me, "Solamente se pueden regenerar documentos rechazados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ReenviarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReenviarDocumentoToolStripMenuItem.Click
        Try
            Leer_indice()
            If Numero_Doc <> 0 And (Tipo_Mov = "FA" Or Tipo_Mov = "FC") Then
                Dim SQL = "	UPDATE DOCUMENTO_ELECTRONICO"
                SQL &= Chr(13) & "	SET IND_ENVIADO = 'N'"
                SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "  AND COD_SUCUR =" & SCM(COD_SUCUR)
                SQL &= Chr(13) & "  AND NUMERO_DOC = " & Val(Numero_Doc)
                SQL &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                MessageBox.Show(Me, "Se ha marcado el documento correctamente para su reenvió, en unos minutos se realizará el proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(Me, "Solamente se pueden reenviar factura de contado o crédito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REPORTES_Click(sender As Object, e As EventArgs) Handles BTN_REPORTES.Click
        Try
            Dim Pantalla As New Reportes_CXC()
            Pantalla.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_APARTADO_Click(sender As Object, e As EventArgs) Handles BTN_APARTADO.Click
        Try
            Dim PANTALLA As New Apartado(CRF_Modos.Insertar, Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_VER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_VER.SelectedIndexChanged
        FORMATO_GRID()
        RELLENAR_GRID()
    End Sub

    Private Sub BTN_ANULAR_Click(sender As Object, e As EventArgs) Handles BTN_ANULAR.Click
        Try
            Leer_indice()
            If Numero_Doc > 0 And (Tipo_Mov = "AC" Or Tipo_Mov = "AA") Then
                Dim mensaje As String = ""
                mensaje &= "¿Seguro que desea anular el apartado # " & Numero_Doc & " ?" & vbNewLine
                mensaje &= "Si realiza este proceso es imposible recuperar el saldo y estado del documento"

                Dim valor = MessageBox.Show(Me, mensaje, "Facturacion", vbYesNo, MessageBoxIcon.Question)
                If valor = DialogResult.Yes Then
                    Dim SQL = "	UPDATE APARTADO_ENC"
                    SQL &= Chr(13) & "	SET ESTADO = 'I', SALDO = 0"
                    SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "  AND COD_SUCUR =" & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "  AND NUMERO_DOC = " & Val(Numero_Doc)
                    SQL &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)
                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(SQL)
                    CONX.Coneccion_Cerrar()
                    CONSULTA_FILTRO = ""
                    RELLENAR_GRID()
                    MessageBox.Show(Me, "Apartado anulado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf Numero_Doc > 0 And Tipo_Mov = "RB" Then
                Dim mensaje As String = ""
                mensaje &= "¿Seguro que desea anular el recibo # " & Numero_Doc & " ?" & vbNewLine
                mensaje &= "Si realiza este proceso el documento afectado recobrará el saldo"

                Dim valor = MessageBox.Show(Me, mensaje, "Facturacion", vbYesNo, MessageBoxIcon.Question)
                If valor = DialogResult.Yes Then
                    CONX.Coneccion_Abrir()

                    Dim SQL = "	UPDATE DOCUMENTO_ENC																						"
                    SQL &= Chr(13) & "	SET SALDO = SALDO + T1.MONTO_AFEC																						"
                    SQL &= Chr(13) & "	FROM(																						"
                    SQL &= Chr(13) & "	SELECT COD_CIA, COD_SUCUR, NUMERO_DOC_AFEC, TIPO_MOV_AFEC, MONTO_AFEC																						"
                    SQL &= Chr(13) & "	FROM DOCUMENTO_AFEC																						"
                    SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "	AND NUMERO_DOC  = " & Val(Numero_Doc)
                    SQL &= Chr(13) & "	AND TIPO_MOV = " & SCM(Tipo_Mov)
                    SQL &= Chr(13) & "	) AS T1																						"
                    SQL &= Chr(13) & "	WHERE DOCUMENTO_ENC.COD_CIA = T1.COD_CIA																						"
                    SQL &= Chr(13) & "	AND DOCUMENTO_ENC.COD_SUCUR = T1.COD_SUCUR																						"
                    SQL &= Chr(13) & "	AND DOCUMENTO_ENC.NUMERO_DOC = T1.NUMERO_DOC_AFEC																						"
                    SQL &= Chr(13) & "	AND DOCUMENTO_ENC.TIPO_MOV = T1.TIPO_MOV_AFEC	"
                    CONX.EJECUTE(SQL)

                    SQL = "	UPDATE DOCUMENTO_ENC	"
                    SQL &= Chr(13) & "	Set SALDO = 0, DESCRIPCION = " & SCM("Recibo anulado por: " & COD_USUARIO) & ", ESTADO = 'I'"
                    SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & "  AND COD_SUCUR =" & SCM(COD_SUCUR)
                    SQL &= Chr(13) & "  AND NUMERO_DOC = " & Val(Numero_Doc)
                    SQL &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)
                    CONX.EJECUTE(SQL)

                    CONX.Coneccion_Cerrar()
                    CONSULTA_FILTRO = ""
                    RELLENAR_GRID()
                    MessageBox.Show(Me, "Recibo anulado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf Numero_Doc > 0 And (Tipo_Mov = "FC" Or Tipo_Mov = "FA") And CMB_VER.SelectedItem.ToString.Substring(0, 1) = "P" Then

                Dim Sql = "	UPDATE PROFORMA_ENC	"
                Sql &= Chr(13) & "	Set SALDO = 0, DESCRIPCION = " & SCM("Proforma anulada por: " & COD_USUARIO) & ", ESTADO = 'I'"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "  AND COD_SUCUR =" & SCM(COD_SUCUR)
                Sql &= Chr(13) & "  AND NUMERO_DOC = " & Val(Numero_Doc)
                Sql &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()
                CONSULTA_FILTRO = ""
                RELLENAR_GRID()
                MessageBox.Show(Me, "Proforma anulada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(Me, "Solamente se pueden anular Apartados, Proformas y Recibos de Dinero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_PROFORMAS_Click(sender As Object, e As EventArgs) Handles BTN_PROFORMAS.Click
        Try
            Dim PANTALLA As New Proforma(CRF_Modos.Insertar, Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class