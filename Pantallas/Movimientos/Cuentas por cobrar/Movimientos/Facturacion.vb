﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Facturacion
    Dim Numero_Doc As Integer
    Dim Codigo As String
    Dim CONSULTA_FILTRO As String = ""
    Dim Respuesta As String = ""
    Dim Tipo_Mov As String

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
                    Numero_Doc = Val(seleccionado.Cells(0).Value.ToString)
                    Codigo = ""
                    Tipo_Mov = seleccionado.Cells(1).Value.ToString
                    Respuesta = seleccionado.Cells(12).Value.ToString
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
        CMB_VER.Enabled = TieneDerecho("DAPAR")
    End Sub

    Public Sub Refrescar()
        RELLENAR_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        If CMB_TIPO_FACT.SelectedIndex = 0 Then
            GRID.ColumnCount = 13
            GRID.Columns(0).HeaderText = "Documento"
            GRID.Columns(0).Name = "ENC.NUMERO_DOC"
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
            GRID.Columns(8).Name = "MONTO"
            GRID.Columns(9).HeaderText = "Impuesto"
            GRID.Columns(9).Name = "IMPUESTO"
            GRID.Columns(10).HeaderText = "Total"
            GRID.Columns(10).Name = "(MONTO + IMPUESTO)"
            GRID.Columns(11).HeaderText = "Saldo"
            GRID.Columns(11).Name = " ENC.SALDO"
            GRID.Columns(12).HeaderText = "DGTD"
            GRID.Columns(12).Name = " ISNULL(DE.RESPUESTA_DGTD, 'P')"
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

            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL As String = ""

                If CMB_TIPO_FACT.SelectedIndex = 0 Then
                    SQL &= Chr(13) & "	SELECT ENC.NUMERO_DOC AS Documento, ENC.TIPO_MOV as Tipo, C.CEDULA AS Cédula, C.NOMBRE AS Nombre, ENC.DESCRIPCION AS Descripción, CONVERT(VARCHAR(10), ENC.FECHA, 105) AS Fecha	"
                    SQL &= Chr(13) & "	,COD_USUARIO AS Usuario, COD_MONEDA AS Moneda, MONTO AS Subtotal, IMPUESTO AS Impuesto, (MONTO + IMPUESTO) as Total, ENC.SALDO AS Saldo, ISNULL(DE.RESPUESTA_DGTD, 'P') AS Respuesta "
                    SQL &= Chr(13) & "	FROM " & IIf(CMB_VER.SelectedIndex = 0, "DOCUMENTO_ENC", "APARTADO_ENC") & " AS ENC	"
                    SQL &= Chr(13) & "	INNER JOIN CLIENTE As C	"
                    SQL &= Chr(13) & "		On C.COD_CIA = ENC.COD_CIA "
                    SQL &= Chr(13) & "      And C.CEDULA = ENC.CEDULA "
                    SQL &= Chr(13) & "   LEFT JOIN DOCUMENTO_ELECTRONICO As DE "
                    SQL &= Chr(13) & "		On ENC.COD_CIA = DE.COD_CIA "
                    SQL &= Chr(13) & "      And ENC.COD_SUCUR = DE.COD_SUCUR "
                    SQL &= Chr(13) & "      And ENC.NUMERO_DOC = DE.NUMERO_DOC "
                    SQL &= Chr(13) & "      And ENC.TIPO_MOV = DE.TIPO_MOV "
                    SQL &= Chr(13) & " WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                    SQL &= Chr(13) & " And ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                    If RB_ACTIVOS.Checked = True Then
                        SQL &= Chr(13) & "	And ENC.ESTADO ='A'"
                    ElseIf RB_INACTIVOS.Checked = True Then
                        SQL &= Chr(13) & "	AND ENC.ESTADO ='I'"
                    End If
                    SQL &= Chr(13) & " AND ENC.FECHA BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
                    SQL &= Chr(13) & CONSULTA_FILTRO
                    SQL &= Chr(13) & " ORDER BY ENC.TIPO_MOV DESC, ENC.FECHA_INC DESC"
                Else
                    SQL &= Chr(13) & "	SELECT ENC.CODIGO AS Documento, ENC.TIPO_MOV as Tipo, C.CEDULA AS Cédula, C.NOMBRE AS Nombre, ENC.DESCRIPCION AS Descripción, CONVERT(VARCHAR(10), ENC.FECHA, 105) AS Fecha	"
                    SQL &= Chr(13) & "	,COD_USUARIO AS Usuario, COD_MONEDA AS Moneda, SUM(DET.SUBTOTAL) AS Subtotal, SUM(DET.IMPUESTO) AS Impuesto, SUM(DET.TOTAL) as Total, SUM(DET.TOTAL) as Saldo, 'P' AS Respuesta 	"
                    SQL &= Chr(13) & "	FROM " & IIf(CMB_VER.SelectedIndex = 0, "DOCUMENTO_ENC_TMP", "APARTADO_ENC_TMP") & " AS ENC	"
                    SQL &= Chr(13) & "	INNER JOIN CLIENTE AS C		"
                    SQL &= Chr(13) & "		ON C.COD_CIA = ENC.COD_CIA	"
                    SQL &= Chr(13) & "		AND C.CEDULA = ENC.CEDULA "
                    SQL &= Chr(13) & "	INNER JOIN " & IIf(CMB_VER.SelectedIndex = 0, "DOCUMENTO_DET_TMP", "APARTADO_DET_TMP") & " AS DET	 "
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
                        Dim row As String() = New String() {ITEM("Documento"), ITEM("Tipo"), ITEM("Cédula"), ITEM("Nombre"), ITEM("Descripción"), ITEM("Fecha"), ITEM("Usuario"), ITEM("Moneda"), ITEM("Subtotal"), ITEM("Impuesto"), ITEM("Total"), ITEM("Saldo"), ITEM("Respuesta")}
                        GRID.Rows.Add(row)

                        If ITEM("Tipo") = "NC" Then
                            Total_Facturado -= FMC(ITEM("Total"))
                        ElseIf ITEM("Tipo") = "FA" Or ITEM("Tipo") = "FC" Or ITEM("Tipo") = "ND" Then
                            Total_Facturado += FMC(ITEM("Total"))
                        ElseIf ITEM("Tipo") = "AA" Or ITEM("Tipo") = "AC" Then
                            Total_Facturado += FMC(ITEM("Total"))
                        End If
                    Next
                End If

                LBL_TOTAL_FACTURADO.Text = FMCP(Total_Facturado)

                If CMB_TIPO_FACT.SelectedIndex = 0 Then
                    PintarEstados()
                End If

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
                    If dgv.Rows(i).Cells(12).Value = "A" Then
                        dgv.Rows(i).Cells(0).Style.BackColor = Color.ForestGreen
                        dgv.Rows(i).Cells(1).Style.BackColor = Color.ForestGreen
                    ElseIf dgv.Rows(i).Cells(12).Value = "R" Then
                        dgv.Rows(i).Cells(0).Style.BackColor = Color.DarkRed
                        dgv.Rows(i).Cells(1).Style.BackColor = Color.DarkRed
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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
            If CMB_VER.SelectedIndex = 0 Then
                Dim PANTALLA As New Factura(CRF_Modos.Modificar, Me, Numero_Doc, Codigo, Tipo_Mov)
                PANTALLA.ShowDialog()
            Else
                Dim PANTALLA As New Apartado(CRF_Modos.Modificar, Me, Numero_Doc, Codigo, Tipo_Mov)
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
            Dim PANTALLA As New NotaCredito(Me, IIf(CMB_VER.SelectedIndex = 0, "F", "A"))
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_IMPRIMIR_Click(sender As Object, e As EventArgs) Handles BTN_IMPRIMIR.Click
        Try
            Leer_indice()
            If Tipo_Mov = "FC" Or Tipo_Mov = "FA" Then
                Dim imp As New Impresion()
                imp.Imprimir(COD_CIA, COD_SUCUR, Numero_Doc, Tipo_Mov)
            ElseIf Tipo_Mov = "RB" Then
                Dim imp As New Impresion()
                imp.ImprimirRecibo(COD_CIA, COD_SUCUR, Numero_Doc, Tipo_Mov)
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
                    SQL &= Chr(13) & "	SET ESTADO = 'N', SALDO = 0"
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
            Else
                MessageBox.Show(Me, "Solamente se pueden anular apartados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class