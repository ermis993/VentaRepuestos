Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class Globales

    Public Shared CONX As New SQLCON
    Public Shared CONX_SIC As New SQLCON
    Public Shared COD_CIA As String
    Public Shared COD_SUCUR As String
    Public Shared COD_USUARIO As String

    Public Shared TC_COMPRA As Decimal
    Public Shared TC_VENTA As Decimal

    Public Shared Property CONEXION() As SQLCON
        Get
            Return CONX
        End Get
        Set(ByVal value As SQLCON)
            CONX = value
        End Set
    End Property
    Public Shared Property COMPANIA() As String
        Get
            Return COD_CIA
        End Get
        Set(ByVal value As String)
            COD_CIA = value
        End Set
    End Property
    Public Shared Property SUCURSAL() As String
        Get
            Return COD_SUCUR
        End Get
        Set(ByVal value As String)
            COD_SUCUR = value
        End Set
    End Property
    Public Shared Property USUARIO() As String
        Get
            Return COD_USUARIO
        End Get
        Set(ByVal value As String)
            COD_USUARIO = value
        End Set
    End Property
    Public Shared Property COMPRA() As String
        Get
            Return TC_COMPRA
        End Get
        Set(ByVal value As String)
            TC_COMPRA = value
        End Set
    End Property
    Public Shared Property VENTA() As String
        Get
            Return TC_VENTA
        End Get
        Set(ByVal value As String)
            TC_VENTA = value
        End Set
    End Property
    Public Shared Function GeneraCodigoSucursal()
        Try
            Dim SQL = "	SELECT ISNULL(MAX(COD_SUCUR),0) + 1 AS COD_SUCUR "
            SQL &= Chr(13) & "	FROM SUCURSAL "
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            Dim Codigo As String = DS.Tables(0).Rows(0).Item("COD_SUCUR")
            Return RellenaEspacioIzquierda(3, "0", Codigo)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function RellenaEspacioIzquierda(ByVal Cantidad As String, ByVal Caracter As String, ByVal Texto As String) As String
        Try
            Return Texto.PadLeft(Cantidad, Caracter)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Sub TIPO_CAMBIO_INDICADORES_ECONOMICOS(ByVal FECHA As String)
        Try
            Dim EMAIL As String = ""
            Dim TOKEN As String = ""
            Dim CODIGO_VENTA As String = ""
            Dim CODIGO_COMPRA As String = ""
            Dim TC_COMPRA As Decimal = 0
            Dim TC_VENTA As Decimal = 0

            Dim SQL = " SELECT * FROM INFORMACION_GENERAL "
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    EMAIL = ITEM("EMAIL")
                    TOKEN = ITEM("TOKEN")
                    CODIGO_COMPRA = ITEM("CODIGO_COMPRA")
                    CODIGO_VENTA = ITEM("CODIGO_VENTA")
                Next
            End If
            Try
                Dim TIPO_CAMBIO = New WS_CENTRAL.wsindicadoreseconomicos
                Dim COMPRA = TIPO_CAMBIO.ObtenerIndicadoresEconomicos(CODIGO_COMPRA, DMA(FECHA), DMA(FECHA), "VR_TIPO_CAMBIO", "N", EMAIL, TOKEN)
                If COMPRA.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In COMPRA.Tables(0).Rows
                        TC_COMPRA = FMCP(ITEM("NUM_VALOR"), 2)
                    Next
                End If

                Dim VENTA = TIPO_CAMBIO.ObtenerIndicadoresEconomicos(CODIGO_VENTA, DMA(FECHA), DMA(FECHA), "VR_TIPO_CAMBIO", "N", EMAIL, TOKEN)
                If VENTA.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In VENTA.Tables(0).Rows
                        TC_VENTA = FMCP(ITEM("NUM_VALOR"), 2)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            If TC_VENTA > 0 And TC_COMPRA > 0 Then
                SQL = "DELETE FROM TIPO_CAMBIO_GENERAL"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "INSERT INTO TIPO_CAMBIO_GENERAL(BANCO,COMPRA,VENTA,FECHA)"
                SQL &= Chr(13) & "VALUES(" & SCM("Banco Central de Costa Rica") & "," & FMC(TC_COMPRA, 2) & "," & FMC(TC_VENTA, 2) & "," & SCM(YMD(FECHA)) & ")"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            Else
                MessageBox.Show("¡No es posible ingresar el tipo de cambio!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Function EXISTE_TC(ByVal FECHA As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT * FROM TIPO_CAMBIO_GENERAL WHERE FECHA = " & SCM(YMD(FECHA))
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE = True
            End If
            Return EXISTE
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function FECHA_HOY() As String
        Try
            Dim FECHA As String = DateTime.Now.ToString
            Return FECHA
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Shared Function EXISTE_TC_CIA(ByVal FECHA As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT * FROM TIPO_CAMBIO_CIA "
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND FECHA = " & SCM(YMD(FECHA))
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE = True
            End If
            Return EXISTE
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    Public Shared Sub GUARDAR_TIPO_CAMBIO(ByVal FECHA As String)
        Try
            Dim COMPRA As Decimal = 0
            Dim VENTA As Decimal = 0
            Dim SQL = "	SELECT * FROM TIPO_CAMBIO_GENERAL WHERE FECHA = " & SCM(YMD(FECHA))
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    COMPRA = FMCP(ITEM("COMPRA"), 2)
                    VENTA = FMCP(ITEM("VENTA"), 2)
                    Exit For
                Next
            End If
            If COMPRA > 0 And VENTA > 0 Then
                SQL = "	INSERT TIPO_CAMBIO_CIA(COD_CIA,FECHA,COMPRA,VENTA)"
                SQL &= Chr(13) & "	VALUES (" & SCM(COD_CIA) & "," & SCM(YMD(FECHA)) & "," & FMC(COMPRA, 2) & "," & FMC(VENTA, 2) & ")"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub VALIDAR_SOLO_NUMEROS(ByVal e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            If Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub
    Public Shared Function EMAIL_VALIDO(ByVal s As String) As Boolean
        Try
            Return Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub SETEO_CONTROL(ByVal Buscador As Buscador, ByVal Pantalla As Form, ByVal Valor As String)
        Try
            Buscador.refrescar()
            Buscador.VALOR = Valor
            Buscador.ACTUALIZAR_COMBO()
            Pantalla.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Function RELLENOCENTRO(ByVal TEXTO As String, ByVal CANTIDAD As Integer) As String
        Try
            TEXTO = TEXTO.PadLeft((CANTIDAD + TEXTO.Length) \ 2).PadRight(CANTIDAD)
            Return TEXTO
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function RELLENO(ByVal TEXTO As String, ByVal CANTIDAD As Integer, ByVal CARACTER As String) As String
        Try
            TEXTO = TEXTO.PadLeft(CANTIDAD, CARACTER)
            Return TEXTO
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function RELLENOIZQUIERDA(ByVal TEXTO As String, ByVal CANTIDAD As Integer) As String
        Try
            TEXTO = TEXTO.PadLeft(CANTIDAD)
            Return TEXTO
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function RELLENODERECHA(ByVal TEXTO As String, ByVal CANTIDAD As Integer) As String
        Try
            TEXTO = TEXTO.PadRight(CANTIDAD)
            Return TEXTO
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function DIRECCION_IMPRESION() As String
        Try
            Dim respuesta As String = ""
            Dim SQL As String = "SELECT ISNULL(IMPRESION_TIQUETE,'') AS IMPRESION_TIQUETE"
            SQL &= Chr(13) & " FROM SUCURSAL "
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                respuesta = DS.Tables(0).Rows(0).Item("IMPRESION_TIQUETE")
            End If

            Return respuesta

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function ANCHO_IMPRESION() As Integer
        Try
            Dim respuesta As Integer = 0
            Dim SQL As String = "SELECT ISNULL(ANCHO_TIQUETE,0) AS ANCHO_TIQUETE"
            SQL &= Chr(13) & " FROM SUCURSAL "
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                respuesta = DS.Tables(0).Rows(0).Item("ANCHO_TIQUETE")
            End If

            Return respuesta

        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Shared Function EXPORTAR_EXCEL(ByVal Datos As DataSet, ByVal Nombre_Reporte As String, ByRef ProgressBar As ProgressBar) As Boolean

        ProgressBar.Value = 15

        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Dim bandera As Boolean = False

        Try
            If f.ShowDialog() = DialogResult.OK Then
                Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Application
                Dim oBook As Workbook
                Dim oSheet As Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim dc As DataColumn
                Dim dr As DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                ProgressBar.Value = 20
                'Se exportan las columnas
                For Each dc In Datos.Tables(0).Columns
                    colIndex += 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next
                ProgressBar.Value = 25


                ProgressBar.Value = 30
                'Se exportan las filas
                For Each dr In Datos.Tables(0).Rows
                    rowIndex += 1
                    colIndex = 0
                    For Each dc In Datos.Tables(0).Columns
                        colIndex += 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
                ProgressBar.Value = 35

                ProgressBar.Value = 40
                'Ruta donde se va a guardar
                Dim fileName As String = "\" + Nombre_Reporte + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                oSheet.Columns.AutoFit()
                ProgressBar.Value = 50

                ProgressBar.Value = 60
                'Save file in final path
                oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                ProgressBar.Value = 80

                'Release the objects
                ReleaseObject(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(oBook)
                oExcel.Quit()
                ReleaseObject(oExcel)
                ProgressBar.Value = 90

                'Limpiar la memoria
                GC.Collect()

                ProgressBar.Value = 100

                bandera = True
            End If
            Return bandera
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Shared Sub ReleaseObject(ByVal o As Object)
        Try
            While (Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

End Class
