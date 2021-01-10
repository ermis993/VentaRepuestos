Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Imports VentaRepuestos.ProductoProceso

Public Class Reportes_Productos
    Private Sub ReportesProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_INICIO.Format = DateTimePickerFormat.Custom
        DTP_INICIO.CustomFormat = "dd-MM-yyyy"

        DTP_FINAL.Format = DateTimePickerFormat.Custom
        DTP_FINAL.CustomFormat = "dd-MM-yyyy"

        RellenaTreeView()
        RellenarFamilias()

        DTP_FINAL.Enabled = TieneDerecho("FECREP")
        DTP_INICIO.Enabled = TieneDerecho("FECREP")
    End Sub

    Private Sub RellenaTreeView()
        Try
            Dim rootNode = TV_REPORTES.Nodes.Add("Reportes")
            rootNode.Nodes.Add("RINVEN", "01. Reporte de inventario por familia")
            rootNode.Nodes.Add("RINVXLS", "02. Reporte de inventario (excel)")
            rootNode.Nodes.Add("RINVDETXLS", "03. Reporte del monto en inventario detallado (excel)")
            rootNode.Nodes.Add("RINVTOTXLS", "04. Reporte del monto en inventario totalizado (excel)")
            TV_REPORTES.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TV_REPORTES_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TV_REPORTES.AfterSelect
        Try
            Dim Nodo_Seleccionado As TreeNode = TV_REPORTES.SelectedNode
            LBL_REPORTE_SELECCIONADO.Text = Nodo_Seleccionado.Text

            If Nodo_Seleccionado.Name = "RINVEN" Then
                ActivarDesactivarControles(False, False, True)
            ElseIf Nodo_Seleccionado.Name = "RINVXLS" Then
                ActivarDesactivarControles(False, False, False)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        Try
            Dim Nodo_Seleccionado As TreeNode = TV_REPORTES.SelectedNode
            PB_CARGA.Visible = True

            If Nodo_Seleccionado IsNot Nothing Then
                Cursor.Current = Cursors.WaitCursor
                Select Case Nodo_Seleccionado.Name
                    Case "RINVEN"
                        Dim f As FolderBrowserDialog = New FolderBrowserDialog
                        If f.ShowDialog() = DialogResult.OK Then
                            Dim Ruta = f.SelectedPath
                            Genera_RPT_INVENTARIO_POR_FAMILIA(CMB_FAMILIA.SelectedValue, Nodo_Seleccionado.Text, Ruta)
                            MessageBox.Show(Me, "Reporte generado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case "RINVXLS"
                        GenerarXLSInventario()
                    Case "RINVDETXLS"
                        GenerarXLSInventarioMontos("S")
                    Case "RINVTOTXLS"
                        GenerarXLSInventarioMontos("N")
                End Select
                Cursor.Current = Cursors.Default
            Else
                MessageBox.Show(Me, "Se debe seleccionar el reporte a generar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            PB_CARGA.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ActivarDesactivarControles(ByVal fecha_inicio As Boolean, ByVal fecha_final As Boolean, ByVal familia As Boolean)
        DTP_INICIO.Enabled = fecha_inicio
        DTP_FINAL.Enabled = fecha_final
        CMB_FAMILIA.Enabled = familia
    End Sub

    Private Sub RellenarFamilias()
        Try
            CMB_FAMILIA.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = ""
            SQL = "SELECT '' AS CODIGO, 'Todas' AS DESCRIPCION"
            SQL &= Chr(13) & " UNION ALL"
            SQL &= Chr(13) & " SELECT CODIGO, DESCRIPCION"
            SQL &= Chr(13) & " FROM FAMILIA"
            SQL &= Chr(13) & " WHERE ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                For Each ITEM In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(ITEM("CODIGO").ToString, ITEM("DESCRIPCION").ToString.ToUpper))
                Next

                CMB_FAMILIA.DataSource = LISTA_REF
                CMB_FAMILIA.ValueMember = "Key"
                CMB_FAMILIA.DisplayMember = "Value"
                CMB_FAMILIA.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub GenerarXLSInventario()
        Try
            PB_CARGA.Increment(5)
            Dim SQL = "	SELECT COD_PROD AS Código, DESCRIPCION AS Descripción, ISNULL(COD_CABYS, '') AS CABYS, COSTO AS Costo					"
            SQL &= Chr(13) & "	, PRECIO AS 'Precio 1', PRECIO_2 AS 'Precio 2', PRECIO_3 as 'Precio 3'							"
            SQL &= Chr(13) & "	FROM PRODUCTO	"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            PB_CARGA.Increment(10)
            If DS.Tables(0).Rows.Count > 0 Then
                If EXPORTAR_EXCEL(DS, "Reporte_Inventario_" & COD_CIA, PB_CARGA) Then
                    MessageBox.Show(Me, "Reporte generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PB_CARGA.Value = 0
                End If
            Else
                PB_CARGA.Value = 0
                MessageBox.Show(Me, "Sin registros para generar el reporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GenerarXLSInventarioMontos(ByVal detallatado As String)
        Try
            PB_CARGA.Increment(5)

            Dim SQL = " "

            If detallatado = "S" Then
                SQL = "	SELECT T1.COD_PROD, T1.DESCRIPCION, T1.CANTIDAD, T1.COSTO, SUM(T1.TOTAL) AS TOTAL																									"
                SQL &= Chr(13) & "	FROM(																									"
                SQL &= Chr(13) & "	SELECT DET.COD_CIA, DET.COD_SUCUR, DET.COD_PROD, PROD.DESCRIPCION, SUM(DET.COSTO*CANTIDAD) AS TOTAL, DET.COSTO, CANTIDAD																									"
                SQL &= Chr(13) & "	FROM INVENTARIO_MOV_DET AS DET																									"
                SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD																									"
                SQL &= Chr(13) & "		ON PROD.COD_CIA = DET.COD_CIA																								"
                SQL &= Chr(13) & "		AND PROD.COD_SUCUR = DET.COD_SUCUR																								"
                SQL &= Chr(13) & "		AND PROD.COD_PROD = DET.COD_PROD																								"
                SQL &= Chr(13) & "	WHERE PROD.ESTADO = 'A'																									"
                SQL &= Chr(13) & "	GROUP BY DET.COD_CIA, DET.COD_SUCUR, DET.COD_PROD, PROD.DESCRIPCION, DET.COSTO, CANTIDAD																									"
                SQL &= Chr(13) & "	HAVING SUM(CANTIDAD) > 0																									"
                SQL &= Chr(13) & "	) AS T1																									"
                SQL &= Chr(13) & "	WHERE T1.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND T1.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "	GROUP BY T1.COD_PROD, T1.DESCRIPCION, T1.CANTIDAD, T1.COSTO													"
            Else
                SQL = "	SELECT ISNULL(SUM(T1.TOTAL), 0) AS TOTAL																									"
                SQL &= Chr(13) & "	FROM(																									"
                SQL &= Chr(13) & "	SELECT DET.COD_CIA, DET.COD_SUCUR, DET.COD_PROD, SUM(DET.COSTO*CANTIDAD) AS TOTAL, DET.COSTO, CANTIDAD																									"
                SQL &= Chr(13) & "	FROM INVENTARIO_MOV_DET AS DET																									"
                SQL &= Chr(13) & "	INNER JOIN PRODUCTO AS PROD																									"
                SQL &= Chr(13) & "		ON PROD.COD_CIA = DET.COD_CIA																								"
                SQL &= Chr(13) & "		AND PROD.COD_SUCUR = DET.COD_SUCUR																								"
                SQL &= Chr(13) & "		AND PROD.COD_PROD = DET.COD_PROD																								"
                SQL &= Chr(13) & "	WHERE PROD.ESTADO = 'A'																									"
                SQL &= Chr(13) & "	GROUP BY DET.COD_CIA, DET.COD_SUCUR, DET.COD_PROD, DET.COSTO, CANTIDAD																									"
                SQL &= Chr(13) & "	HAVING SUM(CANTIDAD) > 0																									"
                SQL &= Chr(13) & "	) AS T1																									"
                SQL &= Chr(13) & "	WHERE T1.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND T1.COD_SUCUR = " & SCM(COD_SUCUR)
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            PB_CARGA.Increment(10)
            If DS.Tables(0).Rows.Count > 0 Then
                If EXPORTAR_EXCEL(DS, "Reporte_Monto_Inventario_" & IIf(detallatado = "S", "Detallado_", "Totalizado_") & COD_CIA, PB_CARGA) Then
                    MessageBox.Show(Me, "Reporte generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PB_CARGA.Value = 0
                End If
            Else
                PB_CARGA.Value = 0
                MessageBox.Show(Me, "Sin registros para generar el reporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class