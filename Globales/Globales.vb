Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports Microsoft.Office.Interop.Excel

Public Class Globales

    Public Shared CONX As New SQLCON
    Public Shared CONX_SIC As New SQLCON
    Public Shared RUTA_ADJUNTOS As String
    Public Shared RUTA_BACKUP As String
    Public Shared COD_CIA As String
    Public Shared COD_SUCUR As String
    Public Shared COD_USUARIO As String
    Public Shared IND_ENCOMIENDA As String
    Public Shared IND_VENTAS_NEGATIVAS As String
    Public Shared IND_MIN_STOCK As String
    Public Shared IND_RECIBO_AUTOMATICO As String
    Public Shared IND_MENSAJE_FACTURA As String

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

    Public Shared Function DIA_ESPANOL(ByVal Dia As DayOfWeek) As String
        Select Case Dia
            Case DayOfWeek.Monday
                Return "Lunes"
            Case DayOfWeek.Tuesday
                Return "Martes"
            Case DayOfWeek.Wednesday
                Return "Miércoles"
            Case DayOfWeek.Thursday
                Return "Jueves"
            Case DayOfWeek.Friday
                Return "Viernes"
            Case DayOfWeek.Saturday
                Return "Sábado"
            Case Else
                Return "Domingo"
        End Select
    End Function

    Public Shared Function MES_ESPANOL(ByVal Mes As String) As String
        Select Case Mes
            Case "January"
                Return "Enero"
            Case "February"
                Return "Febrero"
            Case "March"
                Return "Marzo"
            Case "April"
                Return "Abril"
            Case "May"
                Return "Mayo"
            Case "June"
                Return "Junio"
            Case "July"
                Return "Julio"
            Case "August"
                Return "Agosto"
            Case "September"
                Return "Septiembre"
            Case "October"
                Return "Octubre"
            Case "November"
                Return "Noviembre"
            Case "December"
                Return "Diciembre"
        End Select
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

    Public Shared Function EXISTE_TABLA(ByVal TABLA As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT NAME "
            SQL &= Chr(13) & "FROM SYS.TABLES"
            SQL &= Chr(13) & "WHERE NAME =" & SCM(TABLA)
            SQL &= Chr(13) & "AND SCHEMA_ID = SCHEMA_ID('dbo')"
            'SQL &= Chr(13) & "AND CONVERT(VARCHAR(10), MODIFY_DATE, 126) < " & SCM(YMD(FECHA))

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

    Public Shared Function EXISTE_CAMPO(ByVal CAMPO As String, ByVal TABLA As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT *  "
            SQL &= Chr(13) & "FROM INFORMATION_SCHEMA.COLUMNS"
            SQL &= Chr(13) & "WHERE TABLE_NAME = " & SCM(TABLA)
            SQL &= Chr(13) & "AND COLUMN_NAME = " & SCM(CAMPO)

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

    Public Shared Function EXISTE_CAMPO_TIPO(ByVal CAMPO As String, ByVal TABLA As String, ByVal TIPO As String, Optional TAMANO As Integer = 0) As Boolean
        Try
            Dim EXISTE As Boolean = False

            Dim SQL = "	SELECT COLUMN_NAME  "
            SQL &= Chr(13) & "	FROM INFORMATION_SCHEMA.COLUMNS	"
            SQL &= Chr(13) & "	WHERE TABLE_NAME= " & SCM(TABLA)
            SQL &= Chr(13) & "	AND COLUMN_NAME = " & SCM(CAMPO)
            If TAMANO > 0 Then
                SQL &= Chr(13) & "	AND CHARACTER_MAXIMUM_LENGTH = " & Val(TAMANO)
            End If
            SQL &= Chr(13) & "	AND DATA_TYPE = " & SCM(TIPO.ToUpper)

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

    Public Shared Function EXISTE_PROCEDIMIENTO(ByVal PROCEDIMIENTO As String, ByVal FECHA As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT *  "
            SQL &= Chr(13) & "FROM sysobjects"
            SQL &= Chr(13) & "WHERE TYPE = 'P' "
            SQL &= Chr(13) & "AND NAME = " & SCM(PROCEDIMIENTO)
            SQL &= Chr(13) & "AND CONVERT(VARCHAR(10), CRDATE, 111) >= " & SCM(YMD(FECHA))

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

    Public Shared Function EXISTE_TIPO(ByVal TIPO As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT *  "
            SQL &= Chr(13) & "FROM systypes"
            SQL &= Chr(13) & "WHERE NAME = " & SCM(TIPO)

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

    Public Shared Function EXISTE_CONSTRAINT(ByVal CONSTRAINT As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT *  "
            SQL &= Chr(13) & " FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS "
            SQL &= Chr(13) & " WHERE CONSTRAINT_NAME =" & SCM(CONSTRAINT)

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

    Public Shared Sub ELIMINA_PROCEDIMIENTO(ByVal PROCEDIMIENTO As String)
        Try
            Dim SQL = "DROP PROCEDURE IF EXISTS " & PROCEDIMIENTO
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Function EXISTE_TRIGGER(ByVal TRIGGER As String, ByVal FECHA As String) As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "	SELECT *  "
            SQL &= Chr(13) & "FROM sys.triggers"
            SQL &= Chr(13) & "WHERE NAME = " & SCM(TRIGGER)
            SQL &= Chr(13) & "AND CONVERT(VARCHAR(10), MODIFY_DATE, 111) >= " & SCM(YMD(FECHA))

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

    Public Shared Sub ELIMINA_TRIGGER(ByVal TRIGGER As String)
        Try
            Dim SQL = "DROP TRIGGER IF EXISTS " & TRIGGER
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Shared Function ES_ENCOMIENDA(ByVal COD_CIA As String) As String
        Try
            Dim ENCOMIENDA As String = "N"
            Dim SQL = "	SELECT ISNULL(IND_ENCOMIENDA, 'N') AS IND_ENCOMIENDA FROM COMPANIA WHERE COD_CIA = " & SCM(COD_CIA)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    ENCOMIENDA = ITEM("IND_ENCOMIENDA")
                    Exit For
                Next
            End If
            Return ENCOMIENDA
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Sub INDICADORES_SUCURSAL(ByVal COD_CIA As String, ByVal COD_SUCUR As String)
        Try
            Dim SQL = "	SELECT ISNULL(IND_PERMITE_VENTAS_NEGATIVO, 'N') AS IND_VENTAS, ISNULL(IND_AVISO_MIN_STOCK, 'N') AS IND_AVISO_MIN_STOCK "
            SQL &= Chr(13) & " ,ISNULL(IND_RECIBO_AUTOMATICO, 'N') AS IND_RECIBO_AUTOMATICO, ISNULL(IND_MENSAJE_FACTURACION, 'N') AS IND_MENSAJE_FACTURACION"
            SQL &= Chr(13) & " FROM SUCURSAL_INDICADORES "
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    IND_VENTAS_NEGATIVAS = ITEM("IND_VENTAS")
                    IND_MIN_STOCK = ITEM("IND_AVISO_MIN_STOCK")
                    IND_RECIBO_AUTOMATICO = ITEM("IND_RECIBO_AUTOMATICO")
                    IND_MENSAJE_FACTURA = ITEM("IND_MENSAJE_FACTURACION")
                    Exit For
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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

    Public Shared Sub SETEO_CONTROL_MINI(ByVal Buscador As BuscadorMini, ByVal Pantalla As Form, ByVal Valor As String)
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

    Public Shared Function DIRECCION_ETIQUETA() As String
        Try
            Dim respuesta As String = ""
            Dim SQL As String = "SELECT ISNULL(IMPRESION_ETIQUETA,'') AS IMPRESION_TIQUETE"
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

    Public Shared Function ANCHO_IMPRESION_ETIQUETA() As Integer
        Try
            Dim respuesta As Integer = 0
            Dim SQL As String = "SELECT ISNULL(ANCHO_TIQUETE,0) AS ANCHO_ETIQUETA"
            SQL &= Chr(13) & " FROM SUCURSAL "
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                respuesta = DS.Tables(0).Rows(0).Item("ANCHO_ETIQUETA")
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
                        If Tipo_Doc(dr(dc.ColumnName), "Fecha") Then
                            oSheet.Cells(rowIndex + 1, colIndex).NumberFormat = "dd/mm/yyyy"
                        ElseIf Tipo_Doc(dr(dc.ColumnName), "String") Then
                            oSheet.Cells(rowIndex + 1, colIndex).NumberFormat = "@"
                        End If
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
                oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                ProgressBar.Value = 80

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
            ProgressBar.Value = 0
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

    Private Shared Function Tipo_Doc(ByVal Objecto As Object, ByVal tipo_validacion As String) As String
        Try
            Dim bandera = False

            Select Case tipo_validacion
                Case "String"
                    If Val(Objecto) > 0 Then
                        If Objecto.ToString().Length >= 18 Then
                            bandera = True
                        End If
                    End If
                Case "Fecha"
                    Dim test
                    If Date.TryParseExact(Objecto, "yyyy/MM/dd",
                          New CultureInfo("es-ES"),
                          DateTimeStyles.None, test) Then
                        bandera = True
                    End If
            End Select

            Return bandera
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Sub RellenaImagen(ByRef Panel As PictureBox)
        Try
            Dim COMANDO As New SqlCommand With {
                .CommandType = CommandType.Text,
                .CommandText = "SELECT LOGO FROM COMPANIA WHERE COD_CIA = " & SCM(COD_CIA)
            }

            CONX.Coneccion_Abrir()
            COMANDO.Connection = CONX.Connection

            Dim da As New SqlDataAdapter(COMANDO)
            Dim ds As New DataSet()
            da.Fill(ds, "COMPANIA")
            Dim c As Integer = ds.Tables(0).Rows.Count
            If c > 0 Then
                Dim bytBLOBData() As Byte =
                    ds.Tables(0).Rows(c - 1)("LOGO")
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                Panel.Image = Image.FromStream(stmBLOBData)

            End If
            CONX.Coneccion_Cerrar()

        Catch ex As Exception
            CONX.Coneccion_Cerrar()
        End Try
    End Sub

    Public Shared Function TieneDerecho(ByVal COD_DERECHO As String) As Boolean
        Try
            Dim BANDERA As Boolean = False

            Dim SQL As String = "SELECT *"
            SQL &= Chr(13) & " FROM USUARIO_DERECHO "
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND COD_DERECHO = " & SCM(COD_DERECHO)
            SQL &= Chr(13) & " AND COD_USUARIO = " & SCM(COD_USUARIO)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                BANDERA = True
            End If

            Return BANDERA
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function QUITAR_TILDES(ByVal STR As String) As String
        STR = STR.Replace("á", "a")
        STR = STR.Replace("é", "e")
        STR = STR.Replace("í", "i")
        STR = STR.Replace("ó", "o")
        STR = STR.Replace("ú", "u")
        STR = STR.Replace("à", "a")
        STR = STR.Replace("è", "e")
        STR = STR.Replace("ì", "i")
        STR = STR.Replace("ò", "o")
        STR = STR.Replace("ù", "u")
        Return STR
    End Function
    Public Shared Function FormatoCorreo(ByVal correo As String) As Boolean
        Try
            FormatoCorreo = False
            Dim strMessage As String = ""
            Dim regex As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." +
                                           ")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})",
                                           RegexOptions.IgnoreCase _
                                           Or RegexOptions.CultureInvariant _
                                           Or RegexOptions.IgnorePatternWhitespace _
                                           Or RegexOptions.Compiled
                                           )
            Dim IsMatch As Boolean = regex.IsMatch(correo)

            If IsMatch Then
                If correo.Equals(regex.Match(correo).ToString) Then
                    FormatoCorreo = True
                End If
            End If
        Catch
            FormatoCorreo = False
        End Try
    End Function

    Public Shared Function Destinatarios_a_lista(ByVal GDestinatarios As String) As List(Of String)
        Dim inicio As Integer = 0
        Dim final As Integer = 0
        Dim nueva_dir As String = ""
        Dim Lst_destinatarios As New List(Of String)
        GDestinatarios += ";"
        GDestinatarios = Replace(GDestinatarios, ",", ";")
        For i = 1 To GDestinatarios.Length
            If Mid(GDestinatarios, i, 1) <> ";" Then
                nueva_dir += Mid(GDestinatarios, i, 1)
            Else
                If Trim(nueva_dir) <> "" Then
                    Lst_destinatarios.Add(nueva_dir)
                    nueva_dir = ""
                End If
            End If
        Next
        Return Lst_destinatarios
    End Function

    Public Shared Sub ObtieneInfoSMTP(ByRef SERVIDOR_SMTP As String, ByRef PUERTO_SMTP As Integer, ByRef USUARIO_SMTP As String, ByRef CLAVE_SMTP As String)
        Try
            Dim Sql = "	SELECT COD_CIA,SERVIDOR,USUARIO,CONTRASENA AS CLAVE,PUERTO 					"
            Sql &= Chr(13) & "	FROM SMTP_CONFIG					"
            Sql &= Chr(13) & "	WHERE COD_CIA =	" & SCM(COD_CIA)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                SERVIDOR_SMTP = DS.Tables(0).Rows(0).Item("SERVIDOR")
                USUARIO_SMTP = DS.Tables(0).Rows(0).Item("USUARIO")
                CLAVE_SMTP = DS.Tables(0).Rows(0).Item("CLAVE")
                PUERTO_SMTP = DS.Tables(0).Rows(0).Item("PUERTO")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Structure SMTP_CONFIG
        Public SERVIDOR_SMTP As String
        Public USUARIO As String
        Public CLAVE As String
        Public NOMBRE_VISIBLE As String
        Public PUERTO As Integer
        Public REVISION_MINUTOS As Integer
        Public IND_PIE_MENSAJES As Integer
        Public PIE_MENSAJE As String
        Public COLOR_PRIMARIO As String
        Public COLOR_SECUNDARIO As String
        Public TIPO_LETRA As String
        Public TAMANO_LETRA As String
        Public HIPER_TEXTO As String
        Public HIPER_LINK As String
        Public SSL As String
    End Structure

End Class
