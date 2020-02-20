Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class Impresion

    Private Shared Lines As New Queue(Of String)
    Private Shared _myfont As Font
    Private Shared prn As Printing.PrintDocument

    Sub New()
        _myfont = New Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        prn = New Printing.PrintDocument
        AddHandler prn.PrintPage, AddressOf PrintPageHandler
        prn.PrinterSettings.PrinterName = DIRECCION_IMPRESION()
    End Sub

    Private Shared Sub Print(ByVal text As String)
        Dim linesarray() = text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        For Each line As String In linesarray
            Lines.Enqueue(line)
        Next
        prn.Print()
    End Sub

    Private Sub PrintPageHandler(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)

        Dim sf As New StringFormat()
        Dim vpos As Single = e.PageSettings.HardMarginY

        Do While Lines.Count > 0
            Dim line As String = Lines.Dequeue
            Dim sz As SizeF = e.Graphics.MeasureString(
                line, _myfont, e.PageSettings.Bounds.Size, sf)

            Dim rct As New RectangleF(
                e.PageSettings.HardMarginX, vpos,
                e.PageBounds.Width - e.PageSettings.HardMarginX * 2,
                e.PageBounds.Height - e.PageSettings.HardMarginY * 2)

            e.Graphics.DrawString(line, _myfont, Brushes.Black, rct)
            vpos += sz.Height
            If vpos > e.PageSettings.Bounds.Height -
                e.PageSettings.HardMarginY * 2 Then
                e.HasMorePages = True
                Exit Sub
            End If
        Loop
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

                strPrint = RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Compania").ToString.ToUpper, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Sucursal").ToString.ToUpper, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("Cédula :" + DS.Tables(0).Rows(0).Item("Cedula").ToString, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("Teléfono :" + DS.Tables(0).Rows(0).Item("Telefono").ToString, Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO(DS.Tables(0).Rows(0).Item("Provincia").ToString.ToUpper & "," & DS.Tables(0).Rows(0).Item("Canton").ToString.ToUpper & "," & DS.Tables(0).Rows(0).Item("Distrito").ToString.ToUpper, Ancho_Tiquete) & vbCrLf
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
                    strPrint = strPrint & "Lin:" & RELLENOIZQUIERDA(ITEM("LINEA"), 3) & RELLENOIZQUIERDA("Cod:", 6) & RELLENODERECHA(ITEM("COD_PROD"), 20) & vbCrLf
                    strPrint = strPrint & ITEM("DESCRIPCION") & vbCrLf
                    strPrint = strPrint & "P/U:" & RELLENOIZQUIERDA(FMCP(ITEM("PRECIO"), 2), 11) & RELLENOIZQUIERDA("CAN:", 5) & RELLENOIZQUIERDA(FMCP(ITEM("CANTIDAD"), 2), 11) & vbCrLf
                    strPrint = strPrint & "DES:" & RELLENOIZQUIERDA(FMCP(ITEM("DESCUENTO"), 2), 11) & RELLENOIZQUIERDA("IMP:", 5) & RELLENOIZQUIERDA(FMCP(ITEM("IMPUESTO"), 2), 11) & vbCrLf
                    strPrint = strPrint & "TOT:" & RELLENOIZQUIERDA(FMCP(ITEM("TOTAL"), 2), 11) & vbCrLf
                    strPrint = strPrint & RELLENO("", Ancho_Tiquete, "") & vbCrLf
                Next
                strPrint = strPrint & RELLENOCENTRO("[FIN DETALLE]", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                strPrint = strPrint & "Cantidad de lineas :" & DS.Tables(3).Rows(0).Item("LINEAS").ToString & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA("Gravado", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("GRAVADO"), 2), 11) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA("Exento", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("EXENTO"), 2), 11) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA("Exonerado", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("EXONERADO"), 2), 11) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA("Descuento", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("DESCUENTO"), 2), 11) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA("Subtotal", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("SUBTOTAL"), 2), 11) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA("I.V.A", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("IMPUESTO"), 2), 11) & vbCrLf
                strPrint = strPrint & RELLENOIZQUIERDA("Total", 10) & ":" & RELLENOIZQUIERDA(FMCP(DS.Tables(3).Rows(0).Item("TOTAL"), 2), 11) & vbCrLf
                strPrint = strPrint & RELLENO("", Ancho_Tiquete, "-") & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("AUTORIZADA MEDIANTE RESOLUCION Nº", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("DGTD-R-33-2019 DEL 20 DE JUNIO", Ancho_Tiquete) & vbCrLf
                strPrint = strPrint & RELLENOCENTRO("DEL 2019", Ancho_Tiquete) & vbCrLf

                Print(strPrint)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class
