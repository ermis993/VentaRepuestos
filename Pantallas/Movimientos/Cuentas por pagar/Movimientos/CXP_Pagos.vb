Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class CXP_Pagos
    Dim NUMERO_DOC As Integer
    Dim TIPO_MOV As String
    Dim FECHA As String
    Dim Modo As CRF_Modos
    Dim Padre As CXP_Facturacion
    Dim Codigo As String
    Dim MONTO_DOC_AFEC As Double
    Dim MONTO_DOC As Double

    Sub New(ByVal Modo As CRF_Modos, ByVal Padre As CXP_Facturacion)

        InitializeComponent()
        Me.Modo = Modo
        Me.Padre = Padre

        Cliente.TABLA_BUSCAR = "PROVEEDOR"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE"
        Cliente.PANTALLA = New Cliente(CRF_Modos.Seleccionar, Cliente)
        Cliente.refrescar()

        Codigo = GenerarCodigo()

        TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)
        BloqueaControles()
        CMB_DOCUMENTO.SelectedIndex = 0
        CMB_FORMAPAGO.SelectedIndex = 0
        CMB_MONEDA.SelectedIndex = 0

    End Sub

    Private Function GenerarCodigo() As String
        Try
            Dim CARACTERES As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim RND As New Random
            Dim Codigo As String = ""
            For i As Integer = 1 To 20
                Codigo += CARACTERES.ToCharArray(RND.Next(0, CARACTERES.Length), 1)
            Next
            Return Codigo
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub Cerrar()
        EliminarAfecTodo()
        Me.Close()
        Me.Padre.Refrescar()
    End Sub

    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = IIf(Modo = CRF_Modos.Insertar, True, False)
            CMB_DOCUMENTO.Enabled = IIf(Modo = CRF_Modos.Insertar, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaFacturas()
        Try
            If Not CMB_MONEDA.SelectedIndex <= -1 And String.IsNullOrEmpty(Cliente.VALOR) = False Then
                Dim SQL As String = ""
                GRID.DataSource = Nothing

                SQL = "	SELECT ENC.TIPO_MOV AS Tipo, ENC.NUMERO_DOC AS Número, CONVERT(VARCHAR(10),ENC.FECHA, 103) AS Fecha, MONTO AS Subtotal		"
                SQL &= Chr(13) & "	, IMPUESTO as Impuesto, (MONTO+IMPUESTO) AS Total, SALDO as Saldo"
                SQL &= Chr(13) & "	FROM CXP_DOCUMENTO_ENC AS ENC"
                SQL &= Chr(13) & "  LEFT JOIN CXP_DOCUMENTO_AFEC_DET_TMP AS AFEC"
                SQL &= Chr(13) & "      ON AFEC.NUMERO_DOC = ENC.NUMERO_DOC"
                SQL &= Chr(13) & "      AND AFEC.TIPO_MOV = ENC.TIPO_MOV"
                SQL &= Chr(13) & "	WHERE ENC.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "  AND ENC.COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "  AND CEDULA = " & SCM(Cliente.VALOR)
                SQL &= Chr(13) & "	AND COD_MONEDA = " & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                SQL &= Chr(13) & "  AND SALDO > 0 "
                SQL &= Chr(13) & "  AND ENC.TIPO_MOV In ('FA', 'FC')"
                SQL &= Chr(13) & "  AND AFEC.NUMERO_DOC IS NULL"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    GRID.DataSource = DS.Tables(0)
                End If
            Else
                GRID.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaFacturasAfec()
        Try
            GRID2.DataSource = Nothing
            Dim SQL = "	SELECT CODIGO AS Código, NUMERO_DOC AS Número, TIPO_MOV AS Tipo, FECHA AS Fecha, MONTO_DOC AS Monto, (MONTO_DOC - MONTO_AFEC) as Saldo"
            SQL &= Chr(13) & " FROM CXP_DOCUMENTO_AFEC_DET_TMP"
            SQL &= Chr(13) & " WHERE CODIGO = 	" & SCM(Codigo)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRID2.DataSource = DS.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cliente_Leave(sender As Object, e As EventArgs) Handles Cliente.Leave
        RellenaFacturas()
    End Sub

    Private Sub Leer_indice(ByVal NUM_GRID As Integer)
        Try
            If NUM_GRID = 1 Then
                If Me.GRID.Rows.Count > 0 Then
                    Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)

                    NUMERO_DOC = seleccionado.Cells(1).Value
                    TIPO_MOV = seleccionado.Cells(0).Value
                    FECHA = seleccionado.Cells(2).Value
                    MONTO_DOC = FMC(seleccionado.Cells(6).Value)
                Else
                    NUMERO_DOC = 0
                    TIPO_MOV = ""
                    FECHA = ""
                    MONTO_DOC = 0
                End If
            Else
                If Me.GRID2.Rows.Count > 0 Then
                    Dim seleccionado = GRID2.Rows(GRID2.SelectedRows(0).Index)

                    MONTO_DOC_AFEC = FMC(seleccionado.Cells(4).Value)
                    NUMERO_DOC = seleccionado.Cells(1).Value
                    TIPO_MOV = seleccionado.Cells(2).Value
                Else
                    NUMERO_DOC = 0
                    TIPO_MOV = ""
                    MONTO_DOC_AFEC = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_MONEDA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_MONEDA.SelectedIndexChanged
        RellenaFacturas()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Try
            Leer_indice(1)

            Dim SQL = " INSERT INTO CXP_DOCUMENTO_AFEC_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,NUMERO_DOC,TIPO_MOV,FECHA,MONTO_DOC,MONTO_AFEC)"
            SQL &= Chr(13) & " SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & Val(Numero_Doc) & "," & SCM(Tipo_Mov) & "," & SCM(YMD(FECHA)) & "," & FMC(MONTO_DOC) & ", 0"

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            RellenaFacturas()
            RellenaFacturasAfec()
            CalculoTotales()

            CMB_MONEDA.Enabled = False
            Cliente.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarAfec()
        Try
            Dim SQL = " DELETE FROM CXP_DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = " & SCM(Codigo) & " AND NUMERO_DOC = " & Val(Numero_Doc) & " AND TIPO_MOV = " & SCM(Tipo_Mov)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarAfecTodo()
        Try
            Dim SQL = " DELETE FROM CXP_DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = " & SCM(Codigo)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID2_DoubleClick(sender As Object, e As EventArgs) Handles GRID2.DoubleClick
        Try
            Leer_indice(2)

            EliminarAfec()

            RellenaFacturas()
            RellenaFacturasAfec()
            CalculoTotales()

            If GRID2.Rows.Count <= 0 Then
                CMB_MONEDA.Enabled = True
                Cliente.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CalculoTotales()
        Try
            Dim SQL = "	SELECT ISNULL(SUM(MONTO_DOC), 0) AS MONTO, ISNULL(SUM(MONTO_AFEC), 0) AS MONTO_AFEC	"
            SQL &= Chr(13) & "	FROM CXP_DOCUMENTO_AFEC_DET_TMP		"
            SQL &= Chr(13) & "	WHERE CODIGO= " & SCM(Codigo)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            TXT_M.Text = FMCP(DS.Tables(0).Rows(0).Item("MONTO"), 4)
            TXT_DIS.Text = FMCP(DS.Tables(0).Rows(0).Item("MONTO_AFEC"), 4)
            TXT_DIF.Text = FMCP(FMC(DS.Tables(0).Rows(0).Item("MONTO")) - FMC(DS.Tables(0).Rows(0).Item("MONTO_AFEC")), 4)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If FMC(TXT_M.Text) = FMC(TXT_DIF.Text) Then
                MessageBox.Show("Debe de afectar el monto del o los documentos ingresados, actualmente no se ha afectado ningún monto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If FMC(TXT_DIF.Text) > 0 Then
                    Dim respuesta = MessageBox.Show(Me, "La diferencia está siendo mayor a 0, ¿Seguro desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If respuesta = DialogResult.Yes Then
                        IngresaEncabezadoTemporal()

                        Dim Sql = "	UPDATE CXP_DOCUMENTO_AFEC_DET_TMP	"
                        Sql &= Chr(13) & "	SET MONTO_DOC = MONTO_AFEC "
                        Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                        Sql &= Chr(13) & "  AND COD_SUCUR =   " & SCM(COD_SUCUR)
                        Sql &= Chr(13) & "  AND CODIGO =   " & SCM(Codigo)
                        CONX.Coneccion_Abrir()
                        CONX.EJECUTE(Sql)
                        CONX.Coneccion_Cerrar()

                        IngresaDocumentos()
                    End If
                Else
                    IngresaEncabezadoTemporal()
                    IngresaDocumentos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IngresaDocumentos()
        Try
            Dim Sql = "	USP_CXP_FACTURACION_TMP_A_REAL	"
            Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@TIPO_MOV  = " & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
            Sql &= Chr(13) & "	,@CODIGO = 	" & SCM(Codigo)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            MessageBox.Show("Documento ingresado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cerrar()

            'If CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2) = "RB" Then
            '    Dim pregunta = MessageBox.Show(Me, "Documento ingresado correctamente, ¿desea imprimir el documento?", Me.Text, vbYesNo, MessageBoxIcon.Question)
            '    If pregunta = DialogResult.Yes Then
            '        Dim imp As New Impresion()
            '        imp.ImprimirRecibo(COD_CIA, COD_SUCUR, DS.Tables(0).Rows(0).Item(0), CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2))
            '        Cerrar()
            '    Else
            '        Cerrar()
            '    End If
            'Else
            '    MessageBox.Show("Documento ingresado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Cerrar()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IngresaEncabezadoTemporal()
        Try
            Dim SQL As String = ""
            SQL = "	INSERT INTO CXP_DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,FORMA_PAGO,DESCRIPCION,TIPO_NOTA)"
            SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & SCM(Codigo) & "," & SCM(CMB_DOCUMENTO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(Cliente.VALOR)
            SQL &= Chr(13) & "," & SCM(YMD(DTPFECHA.Value)) & ", GETDATE()," & SCM(COD_USUARIO) & "," & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
            SQL &= Chr(13) & "," & FMC(TXT_TIPO_CAMBIO.Text) & "," & SCM(CMB_FORMAPAGO.SelectedItem.ToString.Substring(0, 2)) & "," & SCM(TXT_DESCRIPCION.Text) & ", NULL"

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IgualarMontoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IgualarMontoToolStripMenuItem.Click
        Leer_indice(2)
        If MONTO_DOC_AFEC > 0 Then
            Dim Sql = "UPDATE CXP_DOCUMENTO_AFEC_DET_TMP"
            Sql &= Chr(13) & "  SET MONTO_AFEC = " & FMC(MONTO_DOC_AFEC)
            Sql &= Chr(13) & "  WHERE NUMERO_DOC = " & Val(Numero_Doc)
            Sql &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            RellenaFacturasAfec()
            CalculoTotales()
        End If
    End Sub

    Private Sub IngrearMontoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngrearMontoToolStripMenuItem.Click
        Leer_indice(2)
        If MONTO_DOC_AFEC > 0 Then
            Dim Valor As String = InputBox("Ingrese el monto con el cual desea afectar, el monto actual es: " & FMCP(MONTO_DOC, 4), "Ingrese el valor")

            If Not String.IsNullOrEmpty(Valor) Then
                If (FMC(MONTO_DOC_AFEC, 4) - FMC(Valor)) >= 0 Then
                    Dim Sql = "UPDATE CXP_DOCUMENTO_AFEC_DET_TMP"
                    Sql &= Chr(13) & "  SET MONTO_AFEC = " & FMC(Valor)
                    Sql &= Chr(13) & "  WHERE NUMERO_DOC = " & Val(Numero_Doc)
                    Sql &= Chr(13) & "  AND TIPO_MOV = " & SCM(Tipo_Mov)

                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(Sql)
                    CONX.Coneccion_Cerrar()

                    RellenaFacturasAfec()
                    CalculoTotales()
                End If
            End If
        End If
    End Sub

    Private Sub GRID2_Click(sender As Object, e As MouseEventArgs) Handles GRID2.Click
        If e.Button = MouseButtons.Right Then
            CMS.Show(GRID2, GRID2.PointToClient(Cursor.Position))
        End If
    End Sub
End Class