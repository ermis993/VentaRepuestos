Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class Globales

    Public Shared CONX As New SQLCON
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

    Public Shared Function SETEO_CONTROL(ByVal Buscador As Buscador, ByVal Pantalla As Form, ByVal Valor As String)
        Try
            Buscador.VALOR = Valor
            Buscador.ACTUALIZAR_COMBO()
            Pantalla.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
End Class
