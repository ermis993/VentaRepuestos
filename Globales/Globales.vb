Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class Globales

    Public Shared CONX As New SQLCON
    Public Shared COD_CIA As String
    Public Shared COD_SUCUR As String
    Public Shared COD_USUARIO As String

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

    Public Shared Sub TIPO_CAMBIO_INDICADORES_ECONOMICOS()
        Try
            Dim FECHA As String = "26/01/2019"
            'Dim EMAIL As String = ""
            'Dim TOKEN As String = ""
            Dim CODIGO_VENTA As String = "318"
            Dim CODIGO_COMPRA As String = "317"
            Dim TC_COMPRA As Decimal = 0
            Dim TC_VENTA As Decimal = 0

            'Dim SQL = " SELECT * FROM CRFUSION_OPCIONES_BD"
            'CONX.Coneccion_Abrir()
            'Dim DS = CONX.EJECUTE_DS(SQL)
            'CONX.Coneccion_Cerrar()

            'If DS.Tables(0).Rows.Count > 0 Then
            '    For Each ITEM In DS.Tables(0).Rows
            '        EMAIL = ITEM("EMAIL")
            '        TOKEN = ITEM("TOKEN")
            '        CODIGO_COMPRA = ITEM("COD_TIPO_CAMBIO_COMPRA")
            '        CODIGO_VENTA = ITEM("COD_TIPO_CAMBIO_VENTA")
            '    Next
            'End If

            Try
                Dim TIPO_CAMBIO = New WS_CENTRAL.wsindicadoreseconomicos
                Dim COMPRA = TIPO_CAMBIO.ObtenerIndicadoresEconomicos(CODIGO_COMPRA, FECHA, FECHA, "VR_TIPO_CAMBIO", "N", "tommy@crfusion.net", "2MMMN1Y0M1")
                If COMPRA.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In COMPRA.Tables(0).Rows
                        TC_COMPRA = FMCP(ITEM("NUM_VALOR"), 2)
                    Next
                End If

                Dim VENTA = TIPO_CAMBIO.ObtenerIndicadoresEconomicos(CODIGO_VENTA, FECHA, FECHA, "CRFUSION_CONSULTOR", "N", "tommy@crfusion.net", "2MMMN1Y0M1")
                If VENTA.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In VENTA.Tables(0).Rows
                        TC_VENTA = FMCP(ITEM("NUM_VALOR"), 2)
                    Next
                End If
            Catch ex As Exception
            End Try

            'If TC_VENTA > 0 And TC_COMPRA > 0 Then
            '    SQL = "DELETE FROM MBANCOSTIC_DET"
            '    SQL &= Chr(13) & "/*INSERTA REGISTROS*/"
            '    SQL &= Chr(13) & ""
            '    SQL &= Chr(13) & "INSERT INTO MBANCOSTIC_DET(NOMBRE,MONTO_VENTA,MONTO_COMPRA)"
            '    SQL &= Chr(13) & "VALUES(" & SCM("Banco Central de Costa Rica") & "," & TC_VENTA & "," & TC_COMPRA & ")"
            '    CONX.Coneccion_Abrir()
            '    CONX.EJECUTE(SQL)
            '    CONX.Coneccion_Cerrar()
            'Else
            '    MessageBox.Show("¡No fue posible establecer conexión con la página del Banco Central, vuelva a intentar más tarde o ingrese el tipo de cambio manualmente!")
            'End If

        Catch ex As Exception
            MessageBox.Show("¡No fue posible establecer conexión con la página del Banco Central, vuelva a intentar más tarde o ingrese el tipo de cambio manualmente!")
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
