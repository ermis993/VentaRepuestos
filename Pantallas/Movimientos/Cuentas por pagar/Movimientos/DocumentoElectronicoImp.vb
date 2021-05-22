Imports System.IO
Imports System.Xml
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class DocumentoElectronicoImp
  Dim XML_CARGADO As Boolean = False
    Dim CEDULA_CIA As String

    Private Sub DocumentosElectronicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Construir_DS()
        Construir_DS_DET()
        CARGAR_ACTIVIDADES()
        CARGAR_TIPO_INGRESO()
        LIMPIAR()
        CARGAR_CEDULA_CIA()
    End Sub

#Region "Generales"
    Dim CLAVE As String = ""
    Dim CONSECUTIVO As String = ""
    Dim FECHA As String
    Dim TIPO_MOV As String = ""
    Dim PLAZO As Integer = 1

    Dim IND_ESTADO As String = ""
    Dim COD_ACT_ECO As String = ""
    Dim TIPO_INGRESO As String = ""
    Dim CONDICION_IVA As String = ""
    Dim POR_IMPUESTO As Decimal = 0.0
    Dim IMPUESTO_ACREDITAR As Decimal = 0.0
    Dim GASTO_APLICABLE As Decimal = 0.0
    Dim DETALLE_MENSAJE As String = ""
    Dim XML_R As String = ""
#End Region

#Region "EMISOR"
    Dim CEDULA_EMISOR As String = ""
    Dim NOMBRE_EMISOR As String = ""
    Dim TIPO_CEDULA_EMISOR As String = ""

    Dim TELEFONO_EMISOR As String = ""
    Dim DIRECCION_EMISOR As String = ""
    Dim EMAIL_EMISOR As String = ""

#End Region

#Region "RECEPTOR"
    Dim CEDULA_RECEPTOR As String = ""
#End Region

#Region "RESUMEN"
    Dim COD_MONEDA As String = ""
    Dim TOTAL_VENTA As Decimal = 0.0
    Dim DESCUENTO As Decimal = 0.0
    Dim OTROS_CARGOS As Decimal = 0.0
    Dim IMPUESTO As Decimal = 0.0
    Dim TOTAL_COMPROBANTE As Decimal = 0.0
    Dim TIPO_CAMBIO As Decimal = 0.0
#End Region

    Private Sub BTN_EXAMINAR_Click(sender As Object, e As EventArgs) Handles BTN_EXAMINAR.Click
        Try
            Dim OFD As New OpenFileDialog With {
                .Filter = "Archivos .XML|*.xml",
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            }

            If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                LIMPIAR()
                For Each DOC In OFD.FileNames
                    Dim XML As New XmlDocument
                    Dim XMLE As XmlElement
                    Dim XMLD As XmlNodeList
                    Dim NODO_RECEPTOR As XmlNode

                    Dim sr As StreamReader = New StreamReader(DOC.ToString)
                    Dim TEXTO As String = sr.ReadToEnd()
                    sr.Close()
                    XML.LoadXml(TEXTO)

                    XMLE = XML.DocumentElement
                    XMLD = XMLE.GetElementsByTagName("Detalle")
                    NODO_RECEPTOR = XML.GetElementsByTagName("Receptor").Item(0)

                    LEER_INFORMACION_GENERAL(XML)
                    LEER_INFORMACION_EMISOR(XML.GetElementsByTagName("Emisor").Item(0))
                    LEER_INFORMACION_RESUMEN(XML.GetElementsByTagName("ResumenFactura").Item(0))

                    If Mid(CONSECUTIVO, 9, 2) = "01" Or Mid(CONSECUTIVO, 9, 2) = "04" Then
                        Select Case XML.GetElementsByTagName("CondicionVenta").Item(0).InnerXml
                            Case "01"
                                TIPO_MOV = "FC"
                            Case "02"
                                TIPO_MOV = "FA"
                                PLAZO = Val(XML.GetElementsByTagName("PlazoCredito").Item(0).InnerXml)
                            Case Else
                                TIPO_MOV = "FC"
                        End Select
                    ElseIf Mid(CONSECUTIVO, 9, 2) = "02" Then
                        TIPO_MOV = "ND"
                    ElseIf Mid(CONSECUTIVO, 9, 2) = "03" Then
                        TIPO_MOV = "NC"
                    End If

                    XML_R = XML.InnerXml
                    LEER_INFORMACION_DETALLE(XML.GetElementsByTagName("DetalleServicio").Item(0))

                    If IsNothing(NODO_RECEPTOR) Then
                        CEDULA_RECEPTOR = "00-0000-0000"
                    Else
                        If IsNothing(NODO_RECEPTOR.Item("Identificacion")) Then
                            If IsNothing(NODO_RECEPTOR.Item("IdentificacionExtranjero")) Then
                                CEDULA_RECEPTOR = "00-0000-0000"
                            Else
                                CEDULA_RECEPTOR = NODO_RECEPTOR.Item("IdentificacionExtranjero").InnerXml
                            End If
                        Else
                            CEDULA_RECEPTOR = NODO_RECEPTOR.Item("Identificacion").Item("Numero").InnerXml
                        End If
                    End If

                    GroupBox1.Enabled = True
                    RB_ACEPTADO.Checked = True
                    XML_CARGADO = True

                    VALIDAR()
                Next
            End If

        Catch ex As Exception
            If ex.Message.Contains("Object reference not set") Or ex.Message.Contains("Referencia a objeto no establecida") Then
                MessageBox.Show("¡Parece ser que el documento que está tratando de importar no corresponde a un archivo XML!" & vbNewLine & "El error es : " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Private Sub LEER_INFORMACION_GENERAL(ByVal XML As XmlDocument)
        Try
            CLAVE = XML.GetElementsByTagName("Clave").Item(0).InnerXml
            TXT_CLAVE.Text = CLAVE

            CONSECUTIVO = XML.GetElementsByTagName("NumeroConsecutivo").Item(0).InnerXml
            TXT_CONSECUTIVO.Text = CONSECUTIVO

            FECHA = DMA(XML.GetElementsByTagName("FechaEmision").Item(0).InnerXml)
            TXT_FECHA.Text = FECHA
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LEER_INFORMACION_EMISOR(ByVal NODO_EMISOR As XmlNode)
        Try
            CEDULA_EMISOR = NODO_EMISOR.Item("Identificacion").Item("Numero").InnerXml
            NOMBRE_EMISOR = NODO_EMISOR.Item("Nombre").InnerXml
            TXT_PROVEEDOR.Text = NOMBRE_EMISOR


            Select Case NODO_EMISOR.Item("Identificacion").Item("Tipo").InnerXml
                Case "01"
                    TIPO_CEDULA_EMISOR = "F"
                Case "02"
                    TIPO_CEDULA_EMISOR = "J"
                Case "03"
                    TIPO_CEDULA_EMISOR = "D"
                Case "04"
                    TIPO_CEDULA_EMISOR = "N"
            End Select


            If IsNothing(NODO_EMISOR.Item("Telefono")) Then
                TELEFONO_EMISOR = "00000000"
            Else
                If IsNothing(NODO_EMISOR.Item("Telefono").Item("NumTelefono").InnerXml) = False Then
                    TELEFONO_EMISOR = NODO_EMISOR.Item("Telefono").Item("NumTelefono").InnerXml
                Else
                    TELEFONO_EMISOR = "00000000"
                End If
            End If

            If IsNothing(NODO_EMISOR.Item("Ubicacion").Item("OtrasSenas").InnerXml) = False Then
                DIRECCION_EMISOR = NODO_EMISOR.Item("Ubicacion").Item("OtrasSenas").InnerXml
            End If

            If IsNothing(NODO_EMISOR.Item("CorreoElectronico").InnerXml) = False Then
                EMAIL_EMISOR = NODO_EMISOR.Item("CorreoElectronico").InnerXml
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LEER_INFORMACION_RESUMEN(ByVal NODO_TOTALES As XmlNode)
        Try
            If IsNothing(NODO_TOTALES.Item("CodigoTipoMoneda")) = False Then
                Select Case NODO_TOTALES.Item("CodigoTipoMoneda").Item("CodigoMoneda").InnerXml
                    Case "CRC"
                        COD_MONEDA = "C"
                    Case "USD"
                        COD_MONEDA = "D"
                    Case "DOL"
                        COD_MONEDA = "D"
                    Case "USN"
                        COD_MONEDA = "D"
                    Case Else
                        COD_MONEDA = "C"
                End Select
            Else
                If IsNothing(NODO_TOTALES.Item("CodigoMoneda")) = False Then
                    Select Case NODO_TOTALES.Item("CodigoMoneda").InnerXml
                        Case "CRC"
                            COD_MONEDA = "C"
                        Case "USD"
                            COD_MONEDA = "D"
                        Case "DOL"
                            COD_MONEDA = "D"
                        Case "USN"
                            COD_MONEDA = "D"
                        Case Else
                            COD_MONEDA = "C"
                    End Select
                Else
                    COD_MONEDA = "C"
                End If
            End If
            If COD_MONEDA = "C" Then
                TXT_MONEDA.Text = "₡ Colones"
            ElseIf COD_MONEDA = "D" Then
                TXT_MONEDA.Text = "$ Dólares"
            End If

            'TOTAL VENTA
            If IsNothing(NODO_TOTALES.Item("TotalVenta")) = False Then
                TOTAL_VENTA = NODO_TOTALES.Item("TotalVenta").InnerXml
            Else
                TOTAL_VENTA = 0
            End If
            TXT_SUBTOTAL.Text = FMCP(TOTAL_VENTA, 2)

            'DESCUENTOS
            If IsNothing(NODO_TOTALES.Item("TotalDescuentos")) = False Then
                DESCUENTO = NODO_TOTALES.Item("TotalDescuentos").InnerXml
            Else
                DESCUENTO = 0
            End If
            TXT_DESCUENTO.Text = FMCP(DESCUENTO, 2)

            'IMPUESTO
            If IsNothing(NODO_TOTALES.Item("TotalImpuesto")) = False Then
                IMPUESTO = NODO_TOTALES.Item("TotalImpuesto").InnerXml
            Else
                IMPUESTO = 0
            End If
            TXT_IMPUESTO.Text = FMCP(IMPUESTO, 2)

            'OTROS CARGOS   
            If IsNothing(NODO_TOTALES.Item("TotalOtrosCargos")) = False Then
                OTROS_CARGOS = NODO_TOTALES.Item("TotalOtrosCargos").InnerXml
            Else
                OTROS_CARGOS = 0
            End If
            TXT_O_CARGOS.Text = FMCP(OTROS_CARGOS, 2)

            'TOTAL
            If IsNothing(NODO_TOTALES.Item("TotalComprobante")) = False Then
                TOTAL_COMPROBANTE = NODO_TOTALES.Item("TotalComprobante").InnerXml
            Else
                TOTAL_COMPROBANTE = 0
            End If
            TXT_TOTAL.Text = FMCP(TOTAL_COMPROBANTE, 2)


            If IsNothing(NODO_TOTALES.Item("CodigoTipoMoneda")) = False Then
                If IsNothing(NODO_TOTALES.Item("CodigoTipoMoneda").Item("TipoCambio")) = False Then
                    TIPO_CAMBIO = NODO_TOTALES.Item("CodigoTipoMoneda").Item("TipoCambio").InnerXml
                Else
                    TIPO_CAMBIO = 1
                End If
            Else
                If IsNothing(NODO_TOTALES.Item("TipoCambio")) = False Then
                    If (Val(NODO_TOTALES.Item("TipoCambio").InnerXml) > 1) Then
                        TIPO_CAMBIO = NODO_TOTALES.Item("TipoCambio").InnerXml
                    Else
                        TIPO_CAMBIO = 1
                    End If
                Else
                    TIPO_CAMBIO = 1
                End If
            End If
            TXT_TIPO_CAMBIO.Text = FMCP(TIPO_CAMBIO, 2)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LEER_INFORMACION_DETALLE(ByVal NODO_DETALLE As XmlNode)
        Try
            Dim BANDERA_CODIGO_COMERCIAL = False

            If IsNothing(NODO_DETALLE) = False Then

                Dim CANTIDAD As Integer = 1
                For Each NODOS As XmlNode In NODO_DETALLE

                    BANDERA_CODIGO_COMERCIAL = False

                    If (NODOS.Name.ToString.Equals("LineaDetalle")) Then
                        Dim ROW As DataRow = DS_DET.NewRow
                        ROW("CLAVE") = CLAVE
                        ROW("CEDULA") = CEDULA_EMISOR
                        ROW("TIPO_MOV") = TIPO_MOV
                        ROW("LINEA") = CANTIDAD

                        For Each NODO_DET As XmlNode In NODOS

                            If (NODO_DET.Name.ToString.Equals("CodigoComercial")) Then

                                If CheckElement(NODO_DET, "Tipo") Then
                                    ROW("TIPO") = NODO_DET.Item("Tipo").InnerXml
                                End If

                                If CheckElement(NODO_DET, "Codigo") And NODO_DET.Item("Codigo").InnerXml <> "00000000000000" And BANDERA_CODIGO_COMERCIAL = False Then
                                    ROW("CODIGO") = NODO_DET.Item("Codigo").InnerXml
                                    BANDERA_CODIGO_COMERCIAL = True
                                End If

                            ElseIf (NODO_DET.Name.ToString.Equals("Cantidad")) Then
                                ROW("CANTIDAD") = FMC(NODOS.Item("Cantidad").InnerXml, 3)

                            ElseIf (NODO_DET.Name.ToString.Equals("Detalle")) Then
                                ROW("DETALLE") = NODOS.Item("Detalle").InnerXml

                            ElseIf (NODO_DET.Name.ToString.Equals("PrecioUnitario")) Then
                                ROW("PRECIO_UNITARIO") = FMC(NODOS.Item("PrecioUnitario").InnerXml, 5)

                            ElseIf (NODO_DET.Name.ToString.Equals("MontoTotal")) Then
                                ROW("MONTO_SINIV") = FMC(NODOS.Item("MontoTotal").InnerXml, 5)

                            ElseIf (NODO_DET.Name.ToString.Equals("Descuento")) Then

                                If CheckElement(NODO_DET, "MontoDescuento") Then
                                    ROW("MONTO_DESCUENTO") = NODO_DET.Item("MontoDescuento").InnerXml
                                End If

                            ElseIf (NODO_DET.Name.ToString.Equals("Impuesto")) Then

                                If CheckElement(NODO_DET, "Codigo") Then
                                    ROW("CODIGO_IMP") = Mid(NODO_DET.Item("Codigo").InnerXml, 1, 2)
                                End If

                                If CheckElement(NODO_DET, "Tarifa") Then
                                    ROW("TARIFA") = Mid(NODO_DET.Item("Tarifa").InnerXml, 1, 2)
                                End If

                                If CheckElement(NODO_DET, "Monto") Then
                                    ROW("MONTO_IMP") = NODO_DET.Item("Monto").InnerXml
                                End If

                                If CheckElement(NODO_DET, "Exoneración") Then
                                    Dim N As XmlNode = NODO_DET.LastChild

                                    If CheckElement(N, "Tipodocumento") Then
                                        ROW("TIPO_EXO") = N.Item("Tipodocumento").InnerXml
                                    ElseIf CheckElement(N, "TipoDocumento") Then
                                        ROW("TIPO_EXO") = N.Item("TipoDocumento").InnerXml
                                    End If

                                    If CheckElement(N, "NumeroDocumento") Then
                                        ROW("NUMERO_EXO") = N.Item("NumeroDocumento").InnerXml
                                    End If

                                    If CheckElement(N, "PorcentajeExoneracion") Then
                                        ROW("PORCENTAJE_EXO") = N.Item("PorcentajeExoneracion").InnerXml
                                    End If

                                    If CheckElement(N, "MontoExoneracion") Then
                                        ROW("MONTO_EXO") = N.Item("MontoExoneracion").InnerXml
                                    End If

                                ElseIf CheckElement(NODO_DET, "Exoneracion") Then
                                    Dim N As XmlNode = NODO_DET.LastChild

                                    If CheckElement(N, "Tipodocumento") Then
                                        ROW("TIPO_EXO") = N.Item("Tipodocumento").InnerXml
                                    ElseIf CheckElement(N, "TipoDocumento") Then
                                        ROW("TIPO_EXO") = N.Item("TipoDocumento").InnerXml
                                    End If

                                    If CheckElement(N, "NumeroDocumento") Then
                                        ROW("NUMERO_EXO") = N.Item("NumeroDocumento").InnerXml
                                    End If

                                    If CheckElement(N, "PorcentajeExoneracion") Then
                                        ROW("PORCENTAJE_EXO") = N.Item("PorcentajeExoneracion").InnerXml
                                    End If

                                    If CheckElement(N, "MontoExoneracion") Then
                                        ROW("MONTO_EXO") = N.Item("MontoExoneracion").InnerXml
                                    End If

                                End If
                            ElseIf (NODO_DET.Name.ToString.Equals("ImpuestoNeto")) Then
                                ROW("NETO_IMP") = FMC(NODOS.Item("ImpuestoNeto").InnerXml, 5)

                            ElseIf (NODO_DET.Name.ToString.Equals("MontoTotalLinea")) Then
                                ROW("MONTO_TOTAL_LINEA") = FMC(NODOS.Item("MontoTotalLinea").InnerXml, 5)
                            End If
                        Next
                        DS_DET.Rows.Add(ROW)
                        CANTIDAD += 1
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CheckElement(ByVal NODO As XmlNode, ByVal NOMBRE As String) As Boolean
        Try
            Dim retorno As Boolean = False
            Dim NODOXML As String = ""
            NODOXML = NODO.Item(NOMBRE).InnerXml
            If NODOXML <> "" Then
                retorno = True
            End If
            Return retorno
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        LIMPIAR()
    End Sub

    Dim DS_ENC As New DataTable
    Dim DS_DET As New DataTable

    Private Sub Construir_DS()

        DS_ENC.Columns.Add("CLAVE", GetType(String))
        DS_ENC.Columns.Add("CONSECUTIVO", GetType(String)) 'Este es el consecutivo del proveedor.
        DS_ENC.Columns.Add("CEDULA", GetType(String))
        DS_ENC.Columns.Add("TIPO_MOV", GetType(String))
        DS_ENC.Columns.Add("FECHA", GetType(DateTime))
        DS_ENC.Columns.Add("PLAZO", GetType(String))
        DS_ENC.Columns.Add("COD_MONEDA", GetType(String))
        DS_ENC.Columns.Add("TOTAL_VENTA", GetType(Decimal))
        DS_ENC.Columns.Add("DESCUENTO", GetType(Decimal))
        DS_ENC.Columns.Add("OTROS_CARGOS", GetType(Decimal))
        DS_ENC.Columns.Add("IMPUESTO", GetType(Decimal))
        DS_ENC.Columns.Add("TOTAL_COMPROBANTE", GetType(Decimal))
        DS_ENC.Columns.Add("TIPO_CAMBIO", GetType(Decimal))
        DS_ENC.Columns.Add("IND_ESTADO", GetType(String))
        DS_ENC.Columns.Add("COD_ACT_ECO", GetType(String))
        DS_ENC.Columns.Add("TIPO_INGRESO", GetType(String))
        DS_ENC.Columns.Add("CONDICION_IVA", GetType(String))
        DS_ENC.Columns.Add("POR_IMPUESTO", GetType(Integer))
        DS_ENC.Columns.Add("IMPUESTO_ACREDITAR", GetType(Decimal))
        DS_ENC.Columns.Add("GASTO_APLICABLE", GetType(Decimal))
        DS_ENC.Columns.Add("DETALLE_MENSAJE", GetType(String))
        DS_ENC.Columns.Add("XML", GetType(String))

        Dim primaryKey(0) As DataColumn
        primaryKey(0) = DS_ENC.Columns("CLAVE")
        DS_ENC.PrimaryKey = primaryKey
    End Sub

    Private Sub Construir_DS_DET()

        DS_DET.Columns.Add("CLAVE", GetType(String))
        DS_DET.Columns.Add("CEDULA", GetType(String))
        DS_DET.Columns.Add("TIPO_MOV", GetType(String))
        DS_DET.Columns.Add("LINEA", GetType(Integer))
        DS_DET.Columns.Add("TIPO", GetType(String))
        DS_DET.Columns.Add("CODIGO", GetType(String))
        DS_DET.Columns.Add("CANTIDAD", GetType(Decimal))
        DS_DET.Columns.Add("DETALLE", GetType(String))
        DS_DET.Columns.Add("PRECIO_UNITARIO", GetType(Decimal))
        DS_DET.Columns.Add("MONTO_SINIV", GetType(Decimal))
        DS_DET.Columns.Add("MONTO_DESCUENTO", GetType(Decimal))
        DS_DET.Columns.Add("CODIGO_IMP", GetType(String))
        DS_DET.Columns.Add("TARIFA", GetType(Decimal))
        DS_DET.Columns.Add("MONTO_IMP", GetType(Decimal))
        DS_DET.Columns.Add("NETO_IMP", GetType(Decimal))
        DS_DET.Columns.Add("TIPO_EXO", GetType(String))
        DS_DET.Columns.Add("NUMERO_EXO", GetType(String))
        DS_DET.Columns.Add("PORCENTAJE_EXO", GetType(Integer))
        DS_DET.Columns.Add("MONTO_EXO", GetType(Decimal))
        DS_DET.Columns.Add("MONTO_TOTAL_LINEA", GetType(Decimal))

        Dim primaryKey(1) As DataColumn
        primaryKey(0) = DS_DET.Columns("CLAVE")
        primaryKey(0) = DS_DET.Columns("LINEA")
        DS_DET.PrimaryKey = primaryKey

    End Sub

    Private Sub RB_ACEPTADO_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACEPTADO.CheckedChanged, RB_RECHAZADO.CheckedChanged
        Try
            If RB_ACEPTADO.Checked = True Then
                IND_ESTADO = "A"
                LBL_RAZON.Visible = False
                TXT_RAZON.Visible = False
                TXT_RAZON.Text = ""
            ElseIf RB_RECHAZADO.Checked = True Then
                IND_ESTADO = "R"
                LBL_RAZON.Visible = True
                TXT_RAZON.Visible = True
                TXT_RAZON.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'LISTA_REF.Add(New KeyValuePair(Of String, String)("01", "Genera crédito IVA"))
    'LISTA_REF.Add(New KeyValuePair(Of String, String)("02", "Genera Crédito parcial del IVA"))
    'LISTA_REF.Add(New KeyValuePair(Of String, String)("03", "Bienes de Capital"))
    'LISTA_REF.Add(New KeyValuePair(Of String, String)("04", "Gasto corriente, no genera crédito"))
    'LISTA_REF.Add(New KeyValuePair(Of String, String)("05", "Proporcionalidad"))

    Private Sub CARGAR_TIPO_INGRESO()
        Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
        LISTA_REF.Add(New KeyValuePair(Of String, String)("01", "Gasto"))
        LISTA_REF.Add(New KeyValuePair(Of String, String)("02", "Compra"))

        CMB_TIPO_INGRESO.DataSource = LISTA_REF
        CMB_TIPO_INGRESO.ValueMember = "Key"
        CMB_TIPO_INGRESO.DisplayMember = "Value"
        CMB_TIPO_INGRESO.SelectedIndex = 0
    End Sub

    Private Sub CARGAR_ACTIVIDADES()
        Try
            CMB_ACTIVIDAD.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL = "	SELECT COD_ACT,DES_ACT"
            SQL &= Chr(13) & "	FROM ACTIVIDAD_ECONOMICA"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	ORDER BY PRINCIPAL ASC"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(ITEM("COD_ACT").ToString, ITEM("DES_ACT").ToString.ToUpper))
                Next
                CMB_ACTIVIDAD.DataSource = LISTA_REF
                CMB_ACTIVIDAD.ValueMember = "Key"
                CMB_ACTIVIDAD.DisplayMember = "Value"
                CMB_ACTIVIDAD.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If XML_CARGADO = True Then
                If RB_RECHAZADO.Checked = True And TXT_RAZON.Text = "" Then
                    MessageBox.Show("¡Debe indicar la razón del por qué rechaza el documento!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    COD_ACT_ECO = CMB_ACTIVIDAD.SelectedValue.ToString
                    CONDICION_IVA = "01"
                    TIPO_INGRESO = CMB_TIPO_INGRESO.SelectedValue.ToString
                    POR_IMPUESTO = 13
                    IMPUESTO_ACREDITAR = IMPUESTO
                    GASTO_APLICABLE = 0.0
                    DETALLE_MENSAJE = TXT_RAZON.Text
                    AGREGAR_A_DS()

                    If DS_ENC.Rows.Count > 0 And DS_DET.Rows.Count > 0 Then
                        Dim DS As New DataTable
                        Dim COMANDO As New SqlClient.SqlCommand()
                        COMANDO.CommandType = CommandType.StoredProcedure

                        Dim PAR_ENC As New SqlClient.SqlParameter("@DT_DOCUMENTOS", SqlDbType.Structured)
                        PAR_ENC.Value = DS_ENC
                        Dim PAR_DET As New SqlClient.SqlParameter("@DT_DOCUMENTOS_DET", SqlDbType.Structured)
                        PAR_DET.Value = DS_DET
                        Dim PAR_COD_CIA As New SqlClient.SqlParameter("@COD_CIA", SqlDbType.VarChar)
                        PAR_COD_CIA.Value = COD_CIA
                        Dim PAR_SUCURSAL As New SqlClient.SqlParameter("@COD_SUCUR", SqlDbType.VarChar)
                        PAR_SUCURSAL.Value = COD_SUCUR
                        Dim PAR_USUARIO As New SqlClient.SqlParameter("@USUARIO", SqlDbType.VarChar)
                        PAR_USUARIO.Value = COD_USUARIO

                        COMANDO.CommandText = "USP_PROCESA_DOCUMENTOS_XML"
                        COMANDO.Parameters.Add(PAR_ENC)
                        COMANDO.Parameters.Add(PAR_DET)
                        COMANDO.Parameters.Add(PAR_COD_CIA)
                        COMANDO.Parameters.Add(PAR_SUCURSAL)
                        COMANDO.Parameters.Add(PAR_USUARIO)

                        CONX.Coneccion_Abrir()
                        COMANDO.Connection = CONX.Connection
                        COMANDO.CommandTimeout = 300
                        Dim AR = COMANDO.ExecuteReader()
                        DS.Load(AR)
                        AR.Close()
                        CONX.Coneccion_Cerrar()

                        Dim Mensaje As String
                        Mensaje = "¡Documento incluido correctamente!" & vbNewLine
                        Mensaje &= "¿Desea realizar el ingreso de inventario de la factura importada?"

                        Dim valor = MessageBox.Show(Me, Mensaje, "Aviso", vbYesNo, MessageBoxIcon.Question)
                        If valor = DialogResult.Yes Then
                            PROCESO_MOVIMIENTO_DE_INVENTARIO()
                        Else
                            LIMPIAR()
                        End If
                    End If
                End If
            Else
                MessageBox.Show("¡Debe cargar un documento para poder incluirlo en el sistema!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PROCESO_MOVIMIENTO_DE_INVENTARIO()
        Try
            Dim SQL = "	EXECUTE USP_INGRESO_INVENTARIO "
            SQL &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	,@CLAVE = " & SCM(TXT_CLAVE.Text)
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            LIMPIAR()
            MessageBox.Show("¡Inventario ingresado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            LIMPIAR()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AGREGAR_A_DS()
        Try
            Dim ROW As DataRow = DS_ENC.NewRow

            ROW("CLAVE") = CLAVE
            ROW("CONSECUTIVO") = CONSECUTIVO
            ROW("CEDULA") = CEDULA_EMISOR
            ROW("TIPO_MOV") = TIPO_MOV
            ROW("FECHA") = YMD(FECHA)
            ROW("PLAZO") = PLAZO
            ROW("COD_MONEDA") = COD_MONEDA
            ROW("TOTAL_VENTA") = TOTAL_VENTA
            ROW("DESCUENTO") = DESCUENTO
            ROW("OTROS_CARGOS") = OTROS_CARGOS
            ROW("IMPUESTO") = IMPUESTO
            ROW("TOTAL_COMPROBANTE") = TOTAL_COMPROBANTE
            ROW("TIPO_CAMBIO") = TIPO_CAMBIO
            ROW("IND_ESTADO") = IND_ESTADO
            ROW("COD_ACT_ECO") = COD_ACT_ECO
            ROW("TIPO_INGRESO") = TIPO_INGRESO
            ROW("CONDICION_IVA") = CONDICION_IVA
            ROW("POR_IMPUESTO") = POR_IMPUESTO
            ROW("IMPUESTO_ACREDITAR") = IMPUESTO_ACREDITAR
            ROW("GASTO_APLICABLE") = GASTO_APLICABLE
            ROW("DETALLE_MENSAJE") = DETALLE_MENSAJE
            ROW("XML") = XML_R

            DS_ENC.Rows.Add(ROW)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LIMPIAR()
        DS_ENC.Rows.Clear()
        DS_DET.Rows.Clear()

        LBL_RAZON.Visible = False
        TXT_RAZON.Visible = False

        CLAVE = ""
        CONSECUTIVO = ""
        CEDULA_EMISOR = ""
        TIPO_MOV = ""
        FECHA = ""
        PLAZO = 1
        COD_MONEDA = ""
        TOTAL_VENTA = 0.0
        DESCUENTO = 0.0
        OTROS_CARGOS = 0.0
        IMPUESTO = 0.0
        TOTAL_COMPROBANTE = 0.0
        TIPO_CAMBIO = 0.0
        IND_ESTADO = ""
        COD_ACT_ECO = ""
        CONDICION_IVA = ""
        POR_IMPUESTO = 0
        IMPUESTO_ACREDITAR = 0.0
        GASTO_APLICABLE = 0.0
        DETALLE_MENSAJE = ""
        XML_R = ""
        TIPO_CEDULA_EMISOR = ""
        TELEFONO_EMISOR = ""
        DIRECCION_EMISOR = ""
        EMAIL_EMISOR = ""

        TXT_CLAVE.Text = ""
        TXT_CONSECUTIVO.Text = ""
        TXT_PROVEEDOR.Text = ""
        TXT_FECHA.Text = ""
        TXT_MONEDA.Text = ""
        TXT_TIPO_CAMBIO.Text = ""
        TXT_SUBTOTAL.Text = ""
        TXT_DESCUENTO.Text = ""
        TXT_CONSECUTIVO.Text = ""
        TXT_IMPUESTO.Text = ""
        TXT_O_CARGOS.Text = ""
        TXT_TOTAL.Text = ""
        TXT_RAZON.Text = ""
        GroupBox1.Enabled = False
        RB_ACEPTADO.Checked = False
        RB_RECHAZADO.Checked = False
        XML_CARGADO = False
    End Sub

    Private Sub CARGAR_CEDULA_CIA()
        Try
            Dim SQL = "	SELECT * FROM COMPANIA "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    CEDULA_CIA = ITEM("CEDULA")
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub VALIDAR()
        Try
            If Mid(CONSECUTIVO, 9, 2) = "04" Then
                MessageBox.Show("¡El documento que está tratando de importar es un tiquete electrónico, este documento no se puede utilizar para la aceptación de gastos!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
            ElseIf VALIDAR_CEDULA_RECEPTOR() = False Then
                MessageBox.Show("¡La cédula del receptor especificada en el documento electrónico " & CEDULA_RECEPTOR & " no coincide con la cédula de la compañía " & CEDULA_CIA & "!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
            ElseIf FMC(TIPO_CAMBIO, 2) <= 1 And COD_MONEDA.ToUpper = "DOL" Then
                MessageBox.Show("¡El documento que está tratando de importar es un documento en dólares y posee un tipo de cambio inválido!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
            ElseIf EXISTE_DOCUMENTO() = True Then 'El Messagebox está dentro del método
                LIMPIAR()
            Else
                VALIDAR_PROVEEDOR()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function VALIDAR_CEDULA_RECEPTOR() As Boolean
        Try
            VALIDAR_CEDULA_RECEPTOR = False

            Dim SQL = "	SELECT * FROM COMPANIA "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND CEDULA    = " & SCM(CEDULA_RECEPTOR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                VALIDAR_CEDULA_RECEPTOR = True
            End If

            Return VALIDAR_CEDULA_RECEPTOR
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Sub VALIDAR_CEDULA_EMISOR()
        Try

            Dim SQL = "	SELECT * FROM COMPANIA "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND CEDULA    = " & SCM(CEDULA_RECEPTOR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub VALIDAR_PROVEEDOR()
        Try
            Dim SQL As String = "EXEC USP_PROVEEDOR_MANT"
            SQL &= Chr(13) & " @COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & ",@COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Seleccionar)
            SQL &= Chr(13) & ",@CEDULA = " & SCM(CEDULA_EMISOR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
            If DS.Tables(0).Rows.Count <= 0 Then
                SQL = "EXEC USP_PROVEEDOR_MANT"
                SQL &= Chr(13) & " @COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & ",@COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Insertar)
                SQL &= Chr(13) & ",@TIPO_CEDULA = " & SCM(TIPO_CEDULA_EMISOR)
                SQL &= Chr(13) & ",@CEDULA = " & SCM(CEDULA_EMISOR)
                SQL &= Chr(13) & ",@NOMBRE = " & SCM(NOMBRE_EMISOR)
                SQL &= Chr(13) & ",@DIRECCION = " & SCM(DIRECCION_EMISOR)
                SQL &= Chr(13) & ",@TELEFONO = " & SCM(TELEFONO_EMISOR)
                SQL &= Chr(13) & ",@CORREO = " & SCM(EMAIL_EMISOR)
                SQL &= Chr(13) & ",@ESTADO = " & SCM("A")

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function EXISTE_DOCUMENTO() As Boolean
        Try
            EXISTE_DOCUMENTO = False
            Dim Sql = " SELECT ISNULL(RESPUESTA_DGTD,'') AS RESPUESTA_DGTD FROM CXP_DOCUMENTOS_ELECTRONICOS "
            Sql &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & " AND CLAVE = " & SCM(CLAVE)
            Sql &= Chr(13) & " AND TIPO_MOV = " & SCM(TIPO_MOV)
            Sql &= Chr(13) & " AND CEDULA = " & SCM(CEDULA_EMISOR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            Dim ESTADO As String = ""
            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    ESTADO = ITEM("RESPUESTA_DGTD")
                Next
                If Trim(ESTADO) = "A" Then
                    MessageBox.Show("¡El documento que está tratando de importar ya existe en la base de datos y fue aceptado por la DGTD!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EXISTE_DOCUMENTO = True
                ElseIf Trim(ESTADO) = "" Then
                    MessageBox.Show("¡El documento que está tratando de importar ya existe en la base de datos y está siendo procesado por el sistema!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EXISTE_DOCUMENTO = True
                End If
            End If

            Return EXISTE_DOCUMENTO
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub TXT_RAZON_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_RAZON.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub
End Class