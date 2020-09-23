Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports System.Drawing.Printing

Public Class Impresion

    Private Shared Lines As New Queue(Of String)
    Private Shared _myfont As Font
    Private Shared prn As New Printer

    Private Shared Sub Print(ByVal text As String)

        Printer.NewPrint()
        Dim linesarray() = text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        For Each line As String In linesarray
            Printer.Print(line)
        Next

        Printer.DoPrint()
    End Sub

    Private Shared Sub PrintTiquet(ByVal text As String)

        Printer.NewPrintTiquet()
        Dim linesarray() = text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        For Each line As String In linesarray
            Printer.Print(line)
        Next

        Printer.DoPrint()
    End Sub

    Public Shared Sub Imprimir(ByVal COD_CIA As String, ByVal COD_SUCUR As String, ByVal NUMERO_DOC As Integer, ByVal TIPO_MOV As String)
        Try
            Dim strPrint As String
            Dim Ancho_Tiquete As Integer = ANCHO_IMPRESION()
            Dim Sql = "	EXEC USP_DATOS_FACTURA_IMPRESION "
            Sql &= Chr(13) & "	@COD_CIA = 	" & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@NUMERO_DOC = " & Val(NUMERO_DOC)
            Sql &= Chr(13) & "  ,@TIPO_MOV =  " & SCM(TIPO_MOV)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(2).Rows.Count > 0 Then

                strPrint = ""
                strPrint = RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Sucursal").ToString.ToUpper, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Compania").ToString.ToUpper, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("Cedula # " + DS.Tables(0).Rows(0).Item("Cedula").ToString, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("Telefonos :" + DS.Tables(0).Rows(0).Item("Telefono").ToString, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Provincia").ToString.ToUpper & "," & DS.Tables(0).Rows(0).Item("Canton").ToString.ToUpper, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Direccion").ToString, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Correo").ToString, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                strPrint = strPrint & DS.Tables(1).Rows(0).Item("TIPO").ToString & vbCrLf
                strPrint = strPrint & DS.Tables(1).Rows(0).Item("Consec").ToString & vbCrLf
                strPrint = strPrint & DS.Tables(1).Rows(0).Item("CLAVE_S").ToString & vbCrLf
                strPrint = strPrint & DS.Tables(1).Rows(0).Item("Clave").ToString & vbCrLf
                strPrint = strPrint & RELLENODERECHA("Doc #", 8) & ":" & RELLENO(DS.Tables(1).Rows(0).Item("Numero").ToString, 8, "0") & vbCrLf
                strPrint = strPrint & RELLENODERECHA("Fecha", 8) & ":" & DMA(DS.Tables(1).Rows(0).Item("FECHA").ToString) & RELLENOIZQUIERDA("Moneda :", 10) & DS.Tables(1).Rows(0).Item("MONEDA").ToString & vbCrLf
                strPrint = strPrint & RELLENODERECHA("Venta", 8) & ":" & DS.Tables(1).Rows(0).Item("VENTA").ToString & vbCrLf
                strPrint = strPrint & RELLENODERECHA("Cliente", 8) & ":" & DS.Tables(1).Rows(0).Item("Nombre").ToString & vbCrLf
                strPrint = strPrint & RELLENODERECHA("Vendedor", 8) & ":" & DS.Tables(1).Rows(0).Item("Usuario").ToString & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("[DETALLE]", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "") & vbCrLf
                For Each ITEM In DS.Tables(2).Rows
                    strPrint = strPrint & RELLENOIZQUIERDA("Lin:" & RELLENOIZQUIERDA(ITEM("LINEA"), 3) & RELLENOIZQUIERDA("Cod:", 6) & RELLENODERECHA(ITEM("COD_PROD"), 20) & RELLENOIZQUIERDA("Cant:", 6) & RELLENOIZQUIERDA(FMCP(ITEM("CANTIDAD"), 2), 9), Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & ITEM("DESCRIPCION") & vbCrLf
                    strPrint = strPrint & RELLENOIZQUIERDA("P/U:" & RELLENOIZQUIERDA(FMCP(ITEM("PRECIO"), 2), 11) & RELLENOIZQUIERDA("Desc:", 6) & RELLENOIZQUIERDA(FMCP(ITEM("DESCUENTO"), 2), 11) & RELLENOIZQUIERDA("Imp:", 5) & RELLENOIZQUIERDA(FMCP(ITEM("IMPUESTO"), 2), 11), Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENOIZQUIERDA("Total:" & RELLENOIZQUIERDA(FMCP(ITEM("TOTAL"), 2), 11), Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENO("", Ancho_Tiquete, "") & vbCrLf
                Next
                strPrint = strPrint & RELLENOCENTRO("[FIN DETALLE]", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf

                If IND_ENCOMIENDA = "S" Then
                    strPrint = strPrint & RELLENOCENTRO("[ DETALLE TRANSPORTE ]", Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("GUIA #", 8) & ": " & DS.Tables(4).Rows(0).Item("NUMERO_GUIA").ToString & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("ENVIA", 8) & ": " & DS.Tables(4).Rows(0).Item("ENVIA").ToString & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("RETIRA", 8) & ": " & DS.Tables(4).Rows(0).Item("RETIRA").ToString & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("DETALLE", 8) & ": " & DS.Tables(4).Rows(0).Item("DETALLE_GUIA").ToString & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("VALOR", 8) & ": " & FMCP(DS.Tables(4).Rows(0).Item("VALOR")) & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("HORA RECIBIDO", 13) & ": " & DS.Tables(4).Rows(0).Item("HORA_INGRESO").ToString & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("HORA ENVIO", 13) & ": " & DS.Tables(4).Rows(0).Item("HORA_ENVIO").ToString & vbCrLf
                    strPrint = strPrint & RELLENOCENTRO("[ FIN DETALLE TRANSPORTE ]", Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                End If

                strPrint = strPrint & "Cantidad de lineas :" & DS.Tables(3).Rows(0).Item("LINEAS").ToString & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                Dim gravado As String = RELLENOIZQUIERDA("Gravado", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("GRAVADO"), 2), 11)
                Dim exento As String = RELLENOIZQUIERDA("Exento", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("EXENTO"), 2), 11)
                Dim exonerado As String = RELLENOIZQUIERDA("Exonerado", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("EXONERADO"), 2), 11)
                Dim descuento As String = RELLENOIZQUIERDA("Descuento", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("DESCUENTO"), 2), 11)
                Dim subtotal As String = RELLENOIZQUIERDA("Subtotal", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("SUBTOTAL"), 2), 11)
                Dim iva As String = RELLENOIZQUIERDA("I.V.A", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("IMPUESTO"), 2), 11)
                Dim total As String = RELLENOIZQUIERDA("Total", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("TOTAL"), 2), 11)

                strPrint = strPrint & RELLENOIZQUIERDA(gravado, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA(exento, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA(exonerado, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA(descuento, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA(iva, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA(subtotal, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA(total, Ancho_Tiquete) & vbCrLf

                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("AUTORIZADA MEDIANTE RESOLUCION N#", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("DGTD-R-33-2019 DEL 20 DE JUNIO DEL 2019", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-")
                Print(strPrint)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Sub ImprimirEncomienda(ByVal COD_CIA As String, ByVal COD_SUCUR As String, ByVal NUMERO_DOC As Integer, ByVal TIPO_MOV As String)
        Try
            Dim strPrint As String
            Dim Ancho_Tiquete As Integer = ANCHO_IMPRESION()
            Dim Sql = "	EXEC USP_DATOS_FACTURA_ENCOMIENDA "
            Sql &= Chr(13) & "	@COD_CIA = 	" & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@NUMERO_DOC = " & Val(NUMERO_DOC)
            Sql &= Chr(13) & "  ,@TIPO_MOV =  " & SCM(TIPO_MOV)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                strPrint = ""
                strPrint = strPrint & RELLENODERECHA("ENVIA", 8) & ": " & DS.Tables(0).Rows(0).Item("ENVIA").ToString.ToUpper & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENODERECHA("RETIRA", 8) & ": " & DS.Tables(0).Rows(0).Item("RETIRA").ToString.ToUpper & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENODERECHA("TELEFONO", 8) & ": " & DS.Tables(0).Rows(0).Item("TELEFONO").ToString & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENODERECHA("GUIA", 8) & ": " & DS.Tables(0).Rows(0).Item("NUMERO_GUIA").ToString.ToUpper & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENODERECHA("BULTOS", 8) & ": " & DS.Tables(0).Rows(0).Item("CANT_BULTOS").ToString & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENODERECHA("FECHA", 8) & ": " & DMAHms(DS.Tables(0).Rows(0).Item("FECHA_IMP").ToString) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "_") & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("FIRMA Y CEDULA", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete)
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-")
                Print(strPrint)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Sub ImprimirEtiquetas(ByVal COD_CIA As String, ByVal COD_SUCUR As String, ByVal NUMERO_DOC As Integer, ByVal TIPO_MOV As String)
        Try
            Dim strPrint As String = ""
            Dim Ancho_Tiquete As Integer = ANCHO_IMPRESION_ETIQUETA()
            Dim Sql = "	EXEC USP_DATOS_FACTURA_ETIQUETA "
            Sql &= Chr(13) & "	@COD_CIA = 	" & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@NUMERO_DOC = " & Val(NUMERO_DOC)
            Sql &= Chr(13) & "  ,@TIPO_MOV =  " & SCM(TIPO_MOV)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    strPrint = ""
                    strPrint = strPrint & RELLENODERECHA("GUIA", 8) & ": " & ITEM("NUMERO_GUIA") & vbCrLf
                    strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("ENVIA", 8) & ": " & ITEM("ENVIA").ToString.ToUpper & vbCrLf
                    strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("RETIRA", 8) & ": " & ITEM("RETIRA").ToString.ToUpper & vbCrLf
                    strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("TELEFONO", 8) & ": " & ITEM("TELEFONO") & vbCrLf
                    strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("BULTOS", 8) & ": " & ITEM("CONTADOR") & " DE " & ITEM("CANT_BULTOS") & vbCrLf
                    strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf
                    strPrint = strPrint & RELLENODERECHA("DESTINO", 8) & ": " & ITEM("DESC_UBICACION").ToString.ToUpper & vbCrLf
                    strPrint = strPrint & RELLENOCENTRO("", Ancho_Tiquete) & vbCrLf

                    PrintTiquet(strPrint)
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class
